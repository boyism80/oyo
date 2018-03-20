using Fire_Detector.Source;
using OpenCvSharp;
using oyo;
using ParrotBebop2;
using System;
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
        private static string                   HOST_NAME            = "luxir01.iptime.org"; // 192.168.0.80


        /// <summary>
        /// 커스텀 팔레트인 IRON BLACK을 위한 데이터입니다.
        /// 가장 보기 좋은 최적의 팔레트 컬러맵입니다.
        /// </summary>
        private static Mat                      IRON_BLACK_PALETTE   = new Mat(256, 1, MatType.CV_8UC3, new byte[] { 255, 255, 255, 253, 253, 253, 251, 251, 251, 249, 249, 249, 247, 247, 247, 245, 245, 245, 243, 243, 243, 241, 241, 241, 239, 239, 239, 237, 237, 237, 235, 235, 235, 233, 233, 233, 231, 231, 231, 229, 229, 229, 227, 227, 227, 225, 225, 225, 223, 223, 223, 221, 221, 221, 219, 219, 219, 217, 217, 217, 215, 215, 215, 213, 213, 213, 211, 211, 211, 209, 209, 209, 207, 207, 207, 205, 205, 205, 203, 203, 203, 201, 201, 201, 199, 199, 199, 197, 197, 197, 195, 195, 195, 193, 193, 193, 191, 191, 191, 189, 189, 189, 187, 187, 187, 185, 185, 185, 183, 183, 183, 181, 181, 181, 179, 179, 179, 177, 177, 177, 175, 175, 175, 173, 173, 173, 171, 171, 171, 169, 169, 169, 167, 167, 167, 165, 165, 165, 163, 163, 163, 161, 161, 161, 159, 159, 159, 157, 157, 157, 155, 155, 155, 153, 153, 153, 151, 151, 151, 149, 149, 149, 147, 147, 147, 145, 145, 145, 143, 143, 143, 141, 141, 141, 139, 139, 139, 137, 137, 137, 135, 135, 135, 133, 133, 133, 131, 131, 131, 129, 129, 129, 126, 126, 126, 124, 124, 124, 122, 122, 122, 120, 120, 120, 118, 118, 118, 116, 116, 116, 114, 114, 114, 112, 112, 112, 110, 110, 110, 108, 108, 108, 106, 106, 106, 104, 104, 104, 102, 102, 102, 100, 100, 100, 98, 98, 98, 96, 96, 96, 94, 94, 94, 92, 92, 92, 90, 90, 90, 88, 88, 88, 86, 86, 86, 84, 84, 84, 82, 82, 82, 80, 80, 80, 78, 78, 78, 76, 76, 76, 74, 74, 74, 72, 72, 72, 70, 70, 70, 68, 68, 68, 66, 66, 66, 64, 64, 64, 62, 62, 62, 60, 60, 60, 58, 58, 58, 56, 56, 56, 54, 54, 54, 52, 52, 52, 50, 50, 50, 48, 48, 48, 46, 46, 46, 44, 44, 44, 42, 42, 42, 40, 40, 40, 38, 38, 38, 36, 36, 36, 34, 34, 34, 32, 32, 32, 30, 30, 30, 28, 28, 28, 26, 26, 26, 24, 24, 24, 22, 22, 22, 20, 20, 20, 18, 18, 18, 16, 16, 16, 14, 14, 14, 12, 12, 12, 10, 10, 10, 8, 8, 8, 6, 6, 6, 4, 4, 4, 2, 2, 2, 0, 0, 0, 9, 0, 0, 16, 0, 2, 24, 0, 4, 31, 0, 6, 38, 0, 8, 45, 0, 10, 53, 0, 12, 60, 0, 14, 67, 0, 17, 74, 0, 19, 82, 0, 21, 89, 0, 23, 96, 0, 25, 103, 0, 27, 111, 0, 29, 118, 0, 31, 120, 0, 36, 121, 0, 41, 122, 0, 46, 123, 0, 51, 124, 0, 56, 125, 0, 61, 126, 0, 66, 127, 0, 71, 128, 1, 76, 129, 1, 81, 130, 1, 86, 131, 1, 91, 132, 1, 96, 133, 1, 101, 134, 1, 106, 135, 1, 111, 136, 1, 116, 136, 1, 121, 137, 2, 125, 137, 2, 130, 137, 3, 135, 138, 3, 139, 138, 3, 144, 138, 4, 149, 139, 4, 153, 139, 5, 158, 139, 5, 163, 140, 5, 167, 140, 6, 172, 140, 6, 177, 141, 7, 181, 141, 7, 186, 137, 10, 189, 132, 13, 191, 127, 16, 194, 121, 19, 196, 116, 22, 198, 111, 25, 200, 106, 28, 203, 101, 31, 205, 95, 34, 207, 90, 37, 209, 85, 40, 212, 80, 43, 214, 75, 46, 216, 69, 49, 218, 64, 52, 221, 59, 55, 223, 49, 57, 224, 47, 60, 225, 44, 64, 226, 42, 67, 227, 39, 71, 228, 37, 74, 229, 34, 78, 230, 32, 81, 231, 29, 85, 231, 27, 88, 232, 24, 92, 233, 22, 95, 234, 19, 99, 235, 17, 102, 236, 14, 106, 237, 12, 109, 238, 12, 112, 239, 12, 116, 240, 12, 119, 240, 12, 123, 241, 12, 127, 241, 12, 130, 242, 12, 134, 242, 12, 138, 243, 13, 141, 243, 13, 145, 244, 13, 149, 244, 13, 152, 245, 13, 156, 245, 13, 160, 246, 13, 163, 246, 13, 167, 247, 13, 171, 247, 14, 175, 248, 15, 178, 248, 16, 182, 249, 18, 185, 249, 19, 189, 250, 20, 192, 250, 21, 196, 251, 22, 199, 251, 23, 203, 252, 24, 206, 252, 25, 210, 253, 27, 213, 253, 28, 217, 254, 29, 220, 254, 30, 224, 255, 39, 227, 255, 53, 229, 255, 67, 231, 255, 81, 233, 255, 95, 234, 255, 109, 236, 255, 123, 238, 255, 137, 240, 255, 151, 242, 255, 165, 244, 255, 179, 246, 255, 193, 248, 255, 207, 249, 255, 221, 251, 255, 235, 253, 255, 24, 255, 255 });


        /// <summary>
        /// 이 값은 산불을 감지할 때 사용되는 값입니다.
        /// 사용자가 지정한 일정 온도를 기반으로 어느 영역이 감지되었을 때, 감지된 영역의 온도가 최저온도와 평균온도의 차이보다
        /// 몇 배 이상 차이가 나야 비정상 상태로 감지할 것인지에 대한 값입니다.
        /// 
        /// 즉, 평균온도가 30'C, 최저온도가 25'C이고 이 값이 1.5라면 비정상상태를 감지하기 위한 최소온도는 5x1.5 = 7.5'C가 평균온도에 더해진
        /// 37.5'C부터 비정상 상태로 감지하게 됩니다.
        /// </summary>
        private static float                    DETECTION_ALPHA      = 1.5f;
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

        /// <summary>
        /// 적외선 프레임과 실화상 프레임을 블렌딩해주는 인스턴스입니다.
        /// </summary>
        public OYOBlender                       Blender { get; private set; }

        /// <summary>
        /// 산불 감지를 수행하는 인스턴스입니다.
        /// </summary>
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
        /// 현재 스트리밍 타입입니다.
        /// 적외선 타입 혹은 실화상 타입이 될 수 있습니다.
        /// </summary>
        public StreamingType                    StreamingType { get; set; }

        /// <summary>
        /// 사용자가 설정한 현재 설정 상태입니다.
        /// </summary>
        public Config                           Config { get; private set; }

        /// <summary>
        /// 드론에 대한 인스턴스입니다.
        /// </summary>
        public Bebop2                           Bebop { get; private set; }

        /// <summary>
        /// 립모션 컨트롤러 인스턴스입니다.
        /// </summary>
        public Leap.Controller                  LeapController { get; private set; }
        #endregion

        public MainForm()
        {
            InitializeComponent();

            this.UpdatedDataBuffer              = new UpdatedDataBuffer();

            this.Receiver                       = new OYOReceiver(HOST_NAME, 8000);
            this.Receiver.OnConnected          += this.defaultView.Receiver_OnConnectionChanged;
            this.Receiver.OnConnected          += this.defaultView.sideExpandedBar.visualizeTab.Receiver_OnConnectionChanged;
            this.Receiver.OnConnected          += this.mainView.mainConnectionView.Receiver_OnConnectionChanged;
            this.Receiver.OnConnected          += this.defaultView.sideExpandedBar.droneTab.Receiver_OnConnectionChanged;
            this.Receiver.OnDisconnected       += this.Receiver_OnDisconnected;
            this.Receiver.OnDisconnected       += this.defaultView.Receiver_OnConnectionChanged;
            this.Receiver.OnDisconnected       += this.defaultView.sideExpandedBar.visualizeTab.Receiver_OnConnectionChanged;
            this.Receiver.OnDisconnected       += this.defaultView.sideExpandedBar.detectFireTab.Receiver_OnDisconnected;
            this.Receiver.OnDisconnected       += this.mainView.mainConnectionView.Receiver_OnConnectionChanged;
            this.Receiver.OnDisconnected       += this.defaultView.sideExpandedBar.droneTab.Receiver_OnConnectionChanged;
            this.Receiver.OnUpdate             += this.Receiver_OnUpdate;
            this.Receiver.OnError              += this.Receiver_OnError;

            this.Blender                        = new OYOBlender(new OpenCvSharp.Size(720, 480));
            this.Blender.Smooth                 = true;
            this.Blender.Transparency           = this.defaultView.sideExpandedBar.visualizeTab.transparencySlider.Value / 100.0f;

            this.Detector                       = new OYODetector();

            this.Recorder                       = new OYORecorder();

            this.Overlayer                      = new OYOGMapOverlayer(this.defaultView.streamingFrameBox);
            this.Overlayer.OnReceiveAddressEvent += this.defaultView.Overlayer_OnReceiveAddressEvent;

            this.Bebop                          = new Bebop2();
            this.Bebop.OnConnected             += this.mainView.mainConnectionView.Bebop_OnConnectionChanged;
            this.Bebop.OnConnected             += this.defaultView.sideExpandedBar.droneTab.Bebop_OnConnectionChanged;
            this.Bebop.OnDisconnected          += this.mainView.mainConnectionView.Bebop_OnConnectionChanged;
            this.Bebop.OnDisconnected          += this.defaultView.sideExpandedBar.droneTab.Bebop_OnConnectionChanged;
            this.Bebop.OnStreaming             += this.Bebop2_OnStreaming;
            this.Bebop.OnRequestPcmd           += this.Bebop2_OnRequestPcmd;
            this.Bebop.OnAltitudeChanged       += this.Bebop2_OnAltitudeChanged;
            this.Bebop.OnPositionChanged       += this.Bebop_OnPositionChanged;
            this.Bebop.OnError                 += this.Bebop_OnError;


            this.LeapController                 = new Leap.Controller();
            this.LeapController.SetPolicy(Leap.Controller.PolicyFlag.POLICY_ALLOW_PAUSE_RESUME);
            this.LeapController.Connect        += this.mainView.mainConnectionView.LeapmotionController_Connect;
            this.LeapController.Disconnect     += this.mainView.mainConnectionView.LeapmotionController_Disconnect;
            this.LeapController.Device         += this.mainView.mainConnectionView.LeapController_Device;
            this.LeapController.DeviceLost     += this.mainView.mainConnectionView.LeapController_DeviceLost;
            this.LeapController.FrameReady     += this.mainView.mainConnectionView.LeapController_FrameReady;

            this.Config                         = new Config();
            this.Config.Visualize.Palette       = this.defaultView.sideExpandedBar.visualizeTab.palettesDropDown.selectedValue;

            this.OnFrameUpdated                += this.defaultView.OnFrameUpdated;
            this.OnFrameUpdated                += this.defaultView.sideExpandedBar.detectFireTab.OnFrameUpdated;

            this.OnScreenStateChanged          += this.mainView.OnScreenStateChanged;
            this.OnScreenStateChanged          += this.mainView.mainConnectionView.OnScreenStateChanged;

            this.Recorder                       = new OYORecorder();
        }

        /// <summary>
        /// 적외선 이미지에 팔레트를 입힙니다.
        /// </summary>
        /// <param name="frame">팔레트를 적용할 적외선 이미지 프레임</param>
        /// <returns>팔레트가 적용된 이미지 프레임</returns>
        private Mat mappingPalette(Mat frame)
        {
            lock (this.Config.Visualize.Palette)
            {
                var ret = new Mat();
                switch (this.Config.Visualize.Palette)
                {
                    case "Grayscale":
                        ret = frame;
                        break;

                    case "IronBlack":
                        ret = frame.LUT(IRON_BLACK_PALETTE);
                        break;

                    default:
                        var ctype = (ColormapTypes)Enum.Parse(typeof(ColormapTypes), this.Config.Visualize.Palette);
                        Cv2.ApplyColorMap(frame, ret, ctype);
                        break;
                }

                return ret;
            }
        }

        /// <summary>
        /// 이미지에 온도를 표시합니다.
        /// </summary>
        /// <param name="frame">표시할 이미지 프레임</param>
        /// <param name="location">표시할 위치</param>
        /// <param name="temperature">표시할 온도값</param>
        /// <param name="color">레이블 백그라운드 색상</param>
        /// <param name="scaled">스케일된 값. 디폴트는 1.0f</param>
        private void markTemperature(Mat frame, OpenCvSharp.Point location, double temperature, Scalar color)
        {
            var fontScaled                   = frame.Width / 400.0f;
            var baseLine                     = 0;
            var text                         = string.Format("{0} 'C", temperature.ToString("N2"));
            var font                         = HersheyFonts.HersheyPlain;
            var textSize                     = Cv2.GetTextSize(text, font, fontScaled, 1, out baseLine);
            var padding                      = new OpenCvSharp.Size(3, 3);
            textSize.Width                  += (padding.Width * 2);
            textSize.Height                 += (padding.Height * 2);

            Cv2.Rectangle(frame, new Rect(location, textSize), color, -1, LineTypes.Link4);
            Cv2.PutText(frame, text, new OpenCvSharp.Point(location.X + padding.Width, location.Y + (textSize.Height - padding.Height)), font, fontScaled, Scalar.White);
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
            if(this.StreamingType == streamingType)
                this._cachedDisplaySize         = frame.Size();

            if (this.defaultView.streamingFrameBox.SizeMode == PictureBoxSizeMode.CenterImage)
            {
                if(this.Config.Blending.Enabled)
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
    }
}
