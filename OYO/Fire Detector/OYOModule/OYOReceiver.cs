using OpenCvSharp;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace oyo
{
    public enum StreamingType { Visual = 0x00000000, Infrared = 0x00000001, Unknown = 0x00000002 }

    //
    // Lx8Receiver
    //  카메라 서버로부터 데이터를 받아오는 작업을 하는 클래스입니다.
    //  Connect 함수를 사용하여 서버에 연결하고 난 뒤 지속적으로 서버로부터 적외선 방사데이터와 실화상 이미지를 받아옵니다.
    //  ILx8Listener 인터페이스를 등록한 객체에게 서버로부터 데이터를 받을때마다 데이터를 전달합니다.
    //  방사데이터로부터 얻은 이미지와 온도정보도 함께 얻을 수 있으며 얻기 전 원하는 크기로 조절이 가능합니다.
    //
    public class OYOReceiver
    {
        //
        // LeptonWidth, LeptonHeight
        //  Lepton 2.5가 제공하는 해상도입니다.
        //  이 해상도는 Lepton 3.0 혹은 다른 모듈로 교체하면서 변경될 수 있습니다.
        //
        public static readonly uint             LeptonWidth                 = 80;
        public static readonly uint             LeptonHeight                = 60;

        //
        // LeptonBufferSize
        //  서버로부터 방사 데이터를 얻는데 필요한 버퍼의 크기입니다.
        //  실화상 이미지의 크기는 jpg로 인코딩되어 유동적인 크기를 가지지만 방사데이터는 항상 고정된 버퍼의 크기를 가집니다.
        //  방사값 하나의 데이터 크기는 2bytes입니다.
        //
        public static readonly uint             LeptonBufferSize            = LeptonWidth * LeptonHeight * sizeof(ushort);

        //
        // CriteriaTable, RadioactiveBoundaryTable
        //  방사값을 온도로 변환하기 위해 필요한 데이터입니다.
        //  방사값과 온도의 상관관계는 선형적이지 않고 계단형식의 그래프를 가지는 것을 확인했습니다.
        //  그 분기점을 배열로써 저장한 값입니다.
        //
        private static  float[]                 CriteriaTable               = new  float[] { 96.54f, 89.18f, 89.45f, 80.72f, 91.72f, 80.81f, 89.00f, 83.27f, 89.09f, 80.00f, 88.90f, 89.81f, 89.81f };
        private static ushort[]                 RadioactiveBoundaryTable    = new ushort[] {  27165,  28227,  29208,  30192,  31080,  32089,  32978,  33957,  34873,  35851,  36811,  37789,  38777 };


        public delegate void                    ConnectionEvent(OYOReceiver receiver);
        public delegate void                    DisconnectionEvent(OYOReceiver receiver);
        public delegate void                    UpdateEvent(OYOReceiver receiver, StreamingType streamingType);
        public delegate void                    ErrorEvent(OYOReceiver receiver, string message);

        //
        // _socket, _host, _port
        //  카메라 서버와 연결할 소켓에 대한 멤버 필드입니다.
        //  현재 카메라 서버는 192.168.0.80:8000으로 설정되어 있습니다.
        //
        private Socket                          _socket;
        private string                          _host;
        private ushort                          _port;

        //
        // _updateFrameThread
        //  서버로부터 데이터를 지속적으로 받기 위한 스레드 인스턴스입니다.
        //
        private Thread                          _updateFrameThread;

        //
        // _radioactiveTable
        //  방사값 테이블입니다.
        //  서버로부터 얻은 방사값을 2차원 배열에 저장합니다.
        //  업데이트가 될 때마다 이 값은 변경됩니다.
        //
        private ushort[,]                       _radioactiveTable           = new ushort[LeptonHeight, LeptonWidth];

        //
        // _temperatureTable
        //  방사값 테이블을 온도정보와 맵핑한 결과를 저장하는 온도 테이블입니다.
        //  방사값 테이블과 마찬가지로 업데이트가 될 때마다 이 값은 변경됩니다.
        //
        private  float[,]                       _temperatureTable           = new  float[LeptonHeight, LeptonWidth];

        //
        // _visual
        //  실화상 카메라로 촬영된 이미지 객체입니다.
        //
        private Mat                             _visual;

        public event ConnectionEvent            OnConnected;
        public event DisconnectionEvent         OnDisconnected;
        public event UpdateEvent                OnUpdate;
        public event ErrorEvent                 OnError;


        //
        // FixLevel
        //  Level & Span을 고정시킬지에 대한 여부입니다.
        //  이 값이 true라면 LEvelTemperatureRange 값에 의한 이미지가 표현됩니다.
        //  반대로 false라면 서버로부터 받은 방사값의 최저점과 최고점에 따른 이미지가 표현되므로
        //  갑작스럽게 온도가 변화하는 경우에 이미지가 크게 바뀔 수 있습니다.
        //
        private bool _fixLevel = false;
        public bool FixLevel
        {
            get
            {
                return this._fixLevel;
            }
            set
            {
                lock (this)
                {
                    this._fixLevel = value;
                }
            }
        }

        //
        // LevelTemperatureRange
        //  FixLevel이 true일 경우에만 사용되는 프로퍼티입니다.
        //  Level & Span을 고정하기 위한 최저온도와 최고온도입니다.
        //
        private Rangef _levelTemperatureRange = new Rangef(10.0f, 60.0f);
        public Rangef LevelTemperatureRange
        {
            get
            {
                return this._levelTemperatureRange;
            }
            set
            {
                this._levelTemperatureRange = value;
            }
        }

        //
        // Running
        //  서버로부터 데이터를 받아오는 작업이 진행중인지의 여부를 나타냅니다.
        //
        public bool Running { get; private set; }

        //
        // 서버와 연결이 되어있는 상태를 나타내는 프로퍼티입니다.
        //
        public bool Connected
        {
            get
            {
                if(this._socket == null)
                    return false;

                return this._socket.Connected;
            }
        }

        public OYOReceiver(string host, ushort port)
        {
            this._host                      = host;
            this._port                      = port;
        }

        //
        // Connect
        //  서버에 연결을 요청합니다.
        //
        // Return
        //  성공시 true, 실패시 false를 리턴합니다.
        //
        public bool Connect()
        {
            if(this._socket != null)
                return false;

            try
            {
                this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this._socket.Connect(this._host, this._port);

                if (this.Connected)
                {
                    if(this.OnConnected != null)
                        this.OnConnected.Invoke(this);
                    this.Execute();
                }
                else
                {
                    if(this.OnError != null)
                        this.OnError.Invoke(this, "서버와 연결할 수 없습니다.");
                }

                return this._socket.Connected;
            }
            catch (Exception e)
            {
                this._socket.Close();
                this._socket = null;

                if(this.OnError != null)
                    this.OnError.Invoke(this, "서버와 연결할 수 없습니다.");
                return false;
            }
        }

        //
        // Disconnect
        //  서버와 연결을 해제합니다.
        //
        private void Disconnect()
        {
            if(this._socket == null)
                return;

            if(this._socket.Connected == false)
                return;

            this._socket.Shutdown(SocketShutdown.Both);
            this._socket.Close();
            this._socket = null;
        }

        private byte[] Receive(int size)
        {
            var bytes = new byte[size];
            var offset = 0;

            while (size != offset)
            {
                var recvsize = this._socket.Receive(bytes, offset, size - offset, SocketFlags.None);
                if(recvsize == 0)
                    return null;

                offset += recvsize;
            }

            return bytes;
        }

        //
        // Receive
        //  서버로부터 데이터를 얻어옵니다.
        //
        // Parameters
        //  streamingType       서버로부터 얻은 데이터가 어떤 데이터인지가 저장됩니다.
        //                      Infrared라면 방사값을, Visual이라면 실화상 이미지를 얻습니다.
        //
        // Return
        //  해당 데이터를 바이트배열 형식으로 리턴합니다.
        //
        private byte[] Receive(ref StreamingType streamingType)
        {
            lock(this._socket)
            {
                var header                      = this.Receive(sizeof(int) + sizeof(int));
                if(header == null)
                    return null;
            
                using (var reader = new BinaryReader(new MemoryStream(header)))
                {
                    var type                    = reader.ReadInt32();
                    var size                    = reader.ReadInt32();
                    streamingType               = (type == 0 ? StreamingType.Infrared : StreamingType.Visual);

                    
                    return this.Receive(size);
                }
            }
        }

        //
        // Update
        //  서버로부터 데이터를 얻고 해당 데이터를 가공합니다.
        //  이 함수가 호출되므로써 방사값과 관련된 정보(온도정보와 적외선 이미지)가 갱신됩니다.
        //
        // Parameters
        //  streamingType       서버로부터 얻은 데이터가 어떤 데이터인지가 저장됩니다.
        //                      Infrared라면 방사값을, Visual이라면 실화상 이미지를 얻습니다.
        //
        private void Update(ref StreamingType streamingType)
        {
            var buffer = this.Receive(ref streamingType);
            if (buffer == null)
                throw new SocketException(10024);

            if (streamingType == StreamingType.Infrared)
            {
                var reader = new BinaryReader(new MemoryStream(buffer));
                for (var row = 0; row < LeptonHeight; row++)
                {
                    for (var col = 0; col < LeptonWidth; col++)
                    {
                        //var bytes = reader.ReadBytes(sizeof(ushort));
                        //Array.Reverse(bytes);
                        //BitConverter.ToInt16(bytes, 0);
                        //this._radioactiveTable[row, col] = BitConverter.ToUInt16(bytes, 0);

                        this._radioactiveTable[row, col] = reader.ReadUInt16();
                        this._temperatureTable[row, col] = Radioactive2Temperature(this._radioactiveTable[row, col]);
                    }
                }
            }
            else if (streamingType == StreamingType.Visual)
            {
                this._visual = Cv2.ImDecode(buffer, ImreadModes.AnyColor);
            }
            else
            {
            }
        }

        //
        // ReceiveFrameRoutine
        //  서버로부터 데이터를 전달받기 위해 작업되는 스레드입니다.
        //  서버로부터 데이터를 얻거나 중간에 오류가 발생하는 경우 등록된 인터페이스를 통해 그 내용을 전달합니다.
        //
        private void ReceiveFrameRoutine()
        {
            var streamingType       = StreamingType.Unknown;
            while (this.Running)
            {
                try
                {
                    this.Update(ref streamingType);
                    if (this.OnUpdate != null)
                        this.OnUpdate.Invoke(this, streamingType);
                }
                catch (SocketException)
                {
                    this.Exit();
                    break;
                }
                catch (ObjectDisposedException)
                {
                    this.Exit();
                    break;
                }
                catch (Exception e)
                {
                    if (this.OnError != null)
                        this.OnError.Invoke(this, e.Message);
                }
            }
        }

        //
        // GetRadioactivePartitions
        //  방사값을 온도로 변환하기 위해 필요한 요소들을 얻습니다.
        //  방사값과 온도의 관계는 계단형식을 띄기 때문에 층마다의 요구값이 필요하며 그 값을 얻습니다.
        //
        // Parameters
        //  radioactive             변환하고자 하는 방사값
        //  criteria                반환될 기준치
        //  minTemperature          해당 층에서의 최소 온도
        //  minRadioactive          해당 층에서의 최소 방사값
        //
        // Return
        //  성공시 true, 실패시 false를 리턴
        //
        private bool GetRadioactivePartitions(ushort radioact, out float criteria, out float minTemperature, out ushort minRadioactive)
        {
            var boundaryLength      = RadioactiveBoundaryTable.Length - 1;
            for (var i = 0; i < boundaryLength; i++)
            {
                if (radioact >= RadioactiveBoundaryTable[i] && radioact <= RadioactiveBoundaryTable[i + 1])
                {
                    criteria = CriteriaTable[i];
                    minTemperature  = i * 10;
                    minRadioactive  = RadioactiveBoundaryTable[i];
                    return true;
                }
            }

            if (radioact >= RadioactiveBoundaryTable[boundaryLength - 1])
            {
                criteria            = CriteriaTable[boundaryLength];
                minTemperature      = (boundaryLength - 1) * 10;
                minRadioactive      = RadioactiveBoundaryTable[boundaryLength - 1 - 1];
                return true;
            }

            criteria                = 0.0f;
            minTemperature          = 0.0f;
            minRadioactive          = 0;
            return false;
        }

        //
        // GetTemperaturePartitions
        //  온도를 방사값으로 변환하기 위해 필요한 요소들을 얻습니다.
        //  방사값과 온도의 관계는 계단형식을 띄기 때문에 층마다의 요구값이 필요하며 그 값을 얻습니다.
        //
        // Parameters
        //  temperature             변환하고자 하는 온도
        //  criteria                반환될 기준치
        //  minTemperature          해당 층에서의 최소 온도
        //  minRadioactive          해당 층에서의 최소 방사값
        //
        // Return
        //  성공시 true, 실패시 false를 리턴
        //
        private bool GetTemperaturePartitions(float temperature, out float criteria, out float minTemperature, out ushort minRadioactive)
        {
            var boundaryLength      = RadioactiveBoundaryTable.Length - 1;
            var index               = (int)(temperature / 10);

            if(temperature <= boundaryLength * 10)
            {
                minTemperature      = index * 10;
                criteria            = CriteriaTable[index];
                minRadioactive      = RadioactiveBoundaryTable[index];
                return true;
            }

            if (temperature > boundaryLength * 10)
            {
                criteria            = CriteriaTable[boundaryLength];
                minTemperature      = (boundaryLength - 1) * 10;
                minRadioactive      = RadioactiveBoundaryTable[boundaryLength - 1];
                return true;
            }

            criteria                = 0.0f;
            minTemperature          = 0.0f;
            minRadioactive          = 0;
            return false;
        }

        //
        // Radioactive2Temperature
        //  방사값을 온도로 변환합니다.
        //
        // Parameters
        //  radioactive             방사값
        //
        // Return
        //  변환된 온도를 리턴합니다.
        //
        private float Radioactive2Temperature(ushort radioact)
        {
            var criteria            = 0.0f;
            var minTemperature      = 0.0f;
            var minRadioactive      = (ushort)0;
            if(this.GetRadioactivePartitions(radioact, out criteria, out minTemperature, out minRadioactive) == false)
                return 0.0f;

            return minTemperature + ((radioact - minRadioactive) / criteria);
        }

        //
        // Temperature2Radioactive
        //  온도를 방사값으로 변환합니다.
        //
        // Parameters
        //  temperature             온도
        //
        // Return
        //  변환된 방사값을 리턴합니다.
        //
        private ushort Temperature2Radioactive(float temperature)
        {
            var criteria            = 0.0f;
            var minTemperature      = 0.0f;
            var minRadioactive      = (ushort)0;

            if (this.GetTemperaturePartitions(temperature, out criteria, out minTemperature, out minRadioactive) == false)
                return 0;

            return (ushort)((temperature - minTemperature) * criteria + minRadioactive);
        }

        //
        // Execute
        //  서버로부터 데이터 받아오는 작업을 시작합니다.
        //
        // Return
        //  성공시 true, 실패시 false를 리턴
        //
        private bool Execute()
        {
            if (this.Running)
                return false;

            this.Running            = true;
            this._updateFrameThread = new Thread(new ThreadStart(this.ReceiveFrameRoutine));
            this._updateFrameThread.Start();
            return true;
        }

        //
        // Exit
        //  서버로부터 데이터 받아오는 작업을 중지합니다.
        //
        public void Exit()
        {
            this.Disconnect();
            this.Running = false;

            if(this.OnDisconnected != null)
                this.OnDisconnected.Invoke(this);
        }

        //
        // Radioactive
        //  방사값 테이블을 opencv의 행렬 형식으로 얻습니다.
        //
        // Parameters
        //  scaled          확대할 배수
        //  size            변경할 크기
        //
        // Return
        //  변환된 행렬정보를 리턴합니다.
        //
        public Mat Radioactive()
        {
            return new Mat(this._radioactiveTable.GetLength(0), this._radioactiveTable.GetLength(1), MatType.CV_16UC1, this._radioactiveTable);
        }

        public Mat Radioactive(float scaled)
        {
            var ret                 = this.Radioactive();
            return ret.Resize(new Size(ret.Width * scaled, ret.Height * scaled));
        }

        public Mat Radioactive(Size size)
        {
            return this.Radioactive().Resize(size);
        }

        //
        // Infrared
        //  적외선 이미지를 얻습니다.
        //
        // Parameters
        //  scaled          확대할 배수
        //  size            변경할 크기
        //
        // Return
        //  적외선 이미지를 리턴합니다.
        //
        public Mat Infrared()
        {
            var radioactive         = this.Radioactive();
            if (this.FixLevel)
            {
                var minRadioactive  = this.Temperature2Radioactive(this.LevelTemperatureRange.Start);   // 사용자 지정 최저 방사값
                var maxRadioactive  = this.Temperature2Radioactive(this.LevelTemperatureRange.End);     // 사용자 지정 최고 방사값
                var x               = 255.0f / (float)(maxRadioactive - minRadioactive);                // 픽셀 변환 파라미터

                var minCurrentRadio = 0.0;
                var maxCurrentRadio = 0.0;
                radioactive.MinMaxLoc(out minCurrentRadio, out maxCurrentRadio);                        // 현재 최저, 최고 방사값

                var minPixel        = (minCurrentRadio - minRadioactive) * x;                           // 표시되는 최저 픽셀값
                var maxPixel        = (maxCurrentRadio - minRadioactive) * x;                           // 표시되는 최고 픽셀값

                return radioactive.Normalize(minPixel, maxPixel, NormTypes.MinMax, MatType.CV_8UC1).CvtColor(ColorConversionCodes.GRAY2BGR);
            }
            else
            {
                return radioactive.Normalize(0, 255, NormTypes.MinMax, MatType.CV_8UC1).CvtColor(ColorConversionCodes.GRAY2BGR);
            }
        }

        public Mat Infrared(float scaled)
        {
            var ret                 = this.Infrared();
            return ret.Resize(new Size(ret.Width * scaled, ret.Height * scaled));
        }

        public Mat Infrared(Size size)
        {
            return this.Infrared().Resize(size);
        }

        //
        // Temperature
        //  온도 정보를 opencv의 행렬 형식으로 얻습니다.
        //
        // Parameters
        //  scaled          확대할 배수
        //  size            변경할 크기
        //
        // Return
        //  온도값 행렬을 리턴합니다.
        //
        public Mat Temperature()
        {
            return new Mat(this._temperatureTable.GetLength(0), this._temperatureTable.GetLength(1), MatType.CV_32FC1, this._temperatureTable);
        }

        public Mat Temperature(float scaled)
        {
            var ret                 = this.Temperature();
            return ret.Resize(new Size(ret.Width * scaled, ret.Height * scaled));
        }

        public Mat Temperature(Size size)
        {
            return this.Temperature().Resize(size);
        }

        //
        // Visual
        //  실화상 이미지를 얻습니다.
        //
        // Parameters
        //  scaled          확대할 배수
        //  size            변경할 크기
        //
        // Return
        //  실화상 이미지를 리턴합니다.
        //
        public Mat Visual()
        {
            return this._visual;
        }

        public Mat Visual(float scaled)
        {
            return this._visual.Resize(new Size(this._visual.Width * scaled, this._visual.Height * scaled));
        }

        public Mat Visual(Size size)
        {
            return this._visual.Resize(size);
        }
    }
}