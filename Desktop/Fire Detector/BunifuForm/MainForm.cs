using Fire_Detector.Properties;
using Fire_Detector.Source;
using OpenCvSharp;
using oyo;
using ParrotBebop2;
using SimpleJSON;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace Fire_Detector.BunifuForm
{
    /// <summary>
    /// MainForm.cs
    /// 
    /// 메인폼 클래스입니다.
    /// 나뉘어진 모듈들과 UI를 통합하여 표시합니다.
    /// </summary>
    public partial class MainForm : Form
    {
        #region 메인폼 델리게이트 선언부
        /// <summary>
        /// 매 프레임이 업데이트될 때 호출될 이벤트 형식입니다.
        /// </summary>
        /// <param name="buffer">업데이트 된 이후 변경된 버퍼</param>
        /// <param name="updatedFrame">처리가 끝난 프레임</param>
        /// <param name="invalidated">이미지 갱신이 필요한지에 대한 여부</param>
        public delegate void                    FrameUpdatedEvent(UpdatedDataBuffer buffer, Mat updatedFrame, bool invalidated);

        /// <summary>
        /// 메인폼의 화면이 바뀔 때 호출될 이벤트 형식입니다.
        /// </summary>
        /// <param name="size">변경된 폼의 크기</param>
        /// <param name="isMaximize">최대화 여부</param>
        public delegate void                    ScreenStateChangedEvent(System.Drawing.Size size, bool isMaximize);
        #endregion

        #region 정적 공유 상수 선언부
        /// <summary>
        /// 카메라서버의 주소입니다.
        /// </summary>
        private static string                   HOST_NAME            = "192.168.42.80"; // luxir01.iptime.org (포트포워딩 ip)
                                                                                             // 192.168.42.80 (드론 ip)
                                                                                             // 192.168.0.80 (테스트용 라즈베리파이 ip)
        /// <summary>
        /// 이 값은 산불을 감지할 때 사용되는 값입니다.
        /// 사용자가 지정한 일정 온도를 기반으로 어느 영역이 감지되었을 때, 감지된 영역의 온도가 최저온도와 평균온도의 차이보다
        /// 몇 배 이상 차이가 나야 비정상 상태로 감지할 것인지에 대한 값입니다.
        /// 
        /// 즉, 평균온도가 30'C, 최저온도가 25'C이고 이 값이 1.5라면 비정상상태를 감지하기 위한 최소온도는 5x1.5 = 7.5'C가 평균온도에 더해진
        /// 37.5'C부터 비정상 상태로 감지하게 됩니다.
        /// </summary>
        private static float                    DETECTION_ALPHA      = 1.5f;


        private static float                    LEAPMOTION_MINIMUM_MOVE_SIDE_ANGLE      = 15.0f;
        private static float                    LEAPMOTION_MINIMUM_UP_POSITION          = 250.0f;
        private static float                    LEAPMOTION_MINIMUM_DOWN_POSITION        = 150.0f;
        private static float                    LEAPMOTION_MINIMUM_FORWARD_ANGLE        = 20.0f;
        private static float                    LEAPMOTION_CALIBRATION_FORWARD_VALUE    = 15.0f;
        private static float                    LEAPMOTION_MINIMUM_ROTATION_ANGLE       = 25.0f;
        private static float                    LEAPMOTION_CALIBRATION_ROTATION_VALUE   = -10.0f;
        #endregion

        #region private 필드 선언부
        /// <summary>
        /// 캐시된 현재 프레임이 표시되는 사이즈입니다.
        /// </summary>
        private OpenCvSharp.Size                _cachedDisplaySize;


        /// <summary>
        /// 최대화 옵션을 위한 변수입니다.
        /// </summary>
        private System.Drawing.Point            _beforePosition;
        private System.Drawing.Size             _beforeSize;
        #endregion

        #region 이벤트 핸들러 선언부
        /// <summary>
        /// 서버로부터 받은 프레임이 업데이트 된 이후에 호출되는 이벤트입니다.
        /// </summary>
        public event FrameUpdatedEvent          OnFrameUpdated;

        /// <summary>
        /// 메인폼의 크기가 바뀔 때 호출되는 이벤트입니다.
        /// </summary>
        public event ScreenStateChangedEvent    OnScreenStateChanged;

        #endregion

        #region 프로퍼티 선언부
        /// <summary>
        /// 업데이트된 프레임에 대한 정보를 보관하는 버퍼 클래스 인스턴스입니다.
        /// </summary>
        public UpdatedDataBuffer                UpdatedDataBuffer { get; private set; }

        /// <summary>
        /// 서버로부터 데이터를 받아오는 역할을 하는 인스턴스입니다.
        /// </summary>
        public OYOReceiver                      Receiver { get; private set; }

        public OYOBlender                       Blender { get; private set; }

        public OYOVisualizer                    Visualizer { get; private set; }

        public OYODetector                      Detector { get; private set; }

        /// <summary>
        /// 녹화 기능을 수행하는 인스턴스입니다.
        /// </summary>
        public OYORecorder                      Recorder { get; private set; }

        /// <summary>
        /// 구글맵을 화면에 오버레이하는 역할을 수행하는 인스턴스입니다.
        /// </summary>
        public OYOGMapOverlayer                 Overlayer { get; private set; }

        /// <summary>
        /// 드론에 대한 인스턴스입니다.
        /// </summary>
        public Bebop2                           Bebop2 { get; private set; }

        /// <summary>
        /// 립모션 컨트롤러 인스턴스입니다.
        /// </summary>
        public OYOLeapmotion                    LeapController { get; private set; }

        public OYOPatrol                        Patrol { get; private set;}

        public OYOAutoFlight                    AutoFlight { get; private set; }
        #endregion

        public MainForm()
        {
            InitializeComponent();

            this.UpdatedDataBuffer              = new UpdatedDataBuffer();
            this.Receiver                       = new OYOReceiver();
            this.Blender                        = new OYOBlender(new OpenCvSharp.Size(640, 480));
            this.Detector                       = new OYODetector();
            this.Visualizer                     = new OYOVisualizer();
            this.Recorder                       = new OYORecorder();
            this.Overlayer                      = new OYOGMapOverlayer(this.defaultView.streamingFrameBox);
            this.Bebop2                         = new Bebop2();
            this.LeapController                 = new OYOLeapmotion();
            this.Patrol                         = new OYOPatrol();
            this.AutoFlight                     = new OYOAutoFlight();

            this.Receiver.Reset(HOST_NAME, 8000);

            this.LeapController.SetPolicy(Leap.Controller.PolicyFlag.POLICY_ALLOW_PAUSE_RESUME);
        }

        private bool loadConfig(string path)
        {
            try
            {
                var json                                = JSONClass.LoadFromCompressedFile(path);

                this.Receiver.FixLevel                  = json["receiver"]["fix_level"].AsBool;
                this.Receiver.LevelTemperatureRange     = new Rangef(json["receiver"]["level_min"].AsFloat, json["receiver"]["level_max"].AsFloat);
                
                this.Visualizer.Palette                 = json["visualizer"]["palette"].Value;
                this.Visualizer.Scaled                  = json["visualizer"]["scaled"].AsFloat;
                this.Visualizer.StreamingType           = (StreamingType)json["visualizer"]["streaming_type"].AsInt;

                this.Blender.Enabled                    = json["blender"]["enabled"].AsBool;
                this.Blender.Size                       = new OpenCvSharp.Size(json["blender"]["size"]["width"].AsInt, json["blender"]["size"]["height"].AsInt);
                this.Blender.Transparency               = json["blender"]["transparency"].AsFloat;
                this.Blender.Threshold                  = json["blender"]["threshold"].AsInt;
                this.Blender.Smooth                     = json["blender"]["smooth"].AsBool;

                this.Detector.Enabled                   = json["detector"]["enabled"].AsBool;
                this.Detector.Notification              = json["detector"]["notification"].AsBool;
                this.Detector.Threshold                 = json["detector"]["threshold"].AsInt;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool saveConfig(string path)
        {
            try
            {
                var json                                = new JSONClass();

                json["receiver"]["fix_level"]           = new JSONData(this.Receiver.FixLevel);
                json["receiver"]["level_min"]           = new JSONData(this.Receiver.LevelTemperatureRange.Start);
                json["receiver"]["level_max"]           = new JSONData(this.Receiver.LevelTemperatureRange.End);

                json["visualizer"]["palette"]           = new JSONData(this.Visualizer.Palette);
                json["visualizer"]["scaled"]            = new JSONData(this.Visualizer.Scaled);
                json["visualilzer"]["streaming_type"]   = new JSONData((int)this.Visualizer.StreamingType);

                json["blender"]["enabled"]              = new JSONData(this.Blender.Enabled);
                json["blender"]["size"]                 = new JSONClass();
                json["blender"]["size"]["width"]        = new JSONData(this.Blender.Size.Width);
                json["blender"]["size"]["height"]       = new JSONData(this.Blender.Size.Height);
                json["blender"]["transparency"]         = new JSONData(this.Blender.Transparency);
                json["blender"]["threshold"]            = new JSONData(this.Blender.Threshold);
                json["blender"]["smooth"]               = new JSONData(this.Blender.Smooth);

                json["detector"]["enabled"]             = new JSONData(this.Detector.Enabled);
                json["detector"]["notification"]        = new JSONData(this.Detector.Notification);
                json["detector"]["threshold"]           = new JSONData(this.Detector.Threshold);

                json.SaveToCompressedFile(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 이미지가 표시될 크기를 얻습니다.
        /// PictureBox의 사이즈 모드에 따라 이미지의 크기가 변경되므로 이 메소드를 이용해 정확한 크기를 얻어야합니다.
        /// </summary>
        /// <param name="streamingType">스트리밍 타입</param>
        /// <param name="frame">표시될 이미지</param>
        /// <returns>표시될 이미지의 크기</returns>
        public OpenCvSharp.Size GetDisplaySize(StreamingType streamingType, Mat frame)
        {
            if(this.Visualizer.StreamingType == streamingType)
                this._cachedDisplaySize         = frame.Size();

            if (this.defaultView.streamingFrameBox.SizeMode == PictureBoxSizeMode.CenterImage)
            {
                if(this.Blender.Enabled)
                    this._cachedDisplaySize     = this.Blender.Size;

                return this._cachedDisplaySize;
            }
            else if (this.defaultView.streamingFrameBox.SizeMode == PictureBoxSizeMode.StretchImage)
            {
                return new OpenCvSharp.Size(this.defaultView.streamingFrameBox.Width, this.defaultView.streamingFrameBox.Height);
            }
            else
            {
                var aspect = this._cachedDisplaySize.Width / (float)this._cachedDisplaySize.Height;
                if (this._cachedDisplaySize.Width > this._cachedDisplaySize.Height)
                {
                    return new OpenCvSharp.Size(this.defaultView.streamingFrameBox.Width, this.defaultView.streamingFrameBox.Height / aspect);
                }
                else
                {
                    return new OpenCvSharp.Size(this.defaultView.streamingFrameBox.Width * aspect, this.defaultView.streamingFrameBox.Height);
                }
            }
        }

        private async void GenerateDronePosition(double lat, double lon, double alt)
        {
            try
            {
                var client = new HttpClient();
                var form = new MultipartFormDataContent();

                form.Add(new StringContent(this.Bebop2.GPS.lat.ToString()), "lat");
                form.Add(new StringContent(this.Bebop2.GPS.lon.ToString()), "lon");
                form.Add(new StringContent(this.Bebop2.GPS.alt.ToString()), "alt");
                form.Add(new StringContent(this.Bebop2.Battery.ToString()), "battery");

                var response = await client.PostAsync(Resources.CENTRAL_HOST + "/generate", form);

                response.EnsureSuccessStatusCode();
                client.Dispose();

                var result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async void PostDetection(Mat inf, Mat vis, Mat thumb, double lat, double lon, double alt, float temperature)
        {
            try
            {
                var inf_bytes = inf.ToBytes(".jpg");
                var vis_bytes = vis.ToBytes(".jpg");
                var thumb_bytes = thumb.ToBytes(".jpg");

                var client = new HttpClient();
                var form = new MultipartFormDataContent();

                // 테스트용
                //lat = 37.339732028;
                //lon = 126.7335414991;

                form.Add(new StringContent(lat.ToString()), "lat");
                form.Add(new StringContent(lon.ToString()), "lon");
                form.Add(new StringContent(alt.ToString()), "alt");
                form.Add(new StringContent(temperature.ToString()), "tem");

                var inf_content = new ByteArrayContent(inf_bytes, 0, inf_bytes.Length);
                inf_content.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                inf_content.Headers.ContentLength = inf_bytes.Length;
                form.Add(inf_content, "inf", "inf.jpg");

                var vis_content = new ByteArrayContent(vis_bytes, 0, vis_bytes.Length);
                vis_content.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                vis_content.Headers.ContentLength = vis_bytes.Length;
                form.Add(vis_content, "vis", "vis.jpg");

                var bnd_content = new ByteArrayContent(thumb_bytes, 0, thumb_bytes.Length);
                bnd_content.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                bnd_content.Headers.ContentLength = thumb_bytes.Length;
                form.Add(bnd_content, "thumb", "thumb.jpg");

                var response = await client.PostAsync(Resources.CENTRAL_HOST + "/detection", form);

                response.EnsureSuccessStatusCode();
                client.Dispose();
                var result = response.Content.ReadAsStringAsync().Result;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}