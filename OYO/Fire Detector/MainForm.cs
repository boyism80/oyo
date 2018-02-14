using OpenCvSharp;
using oyo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static oyo.OYOReceiver;

namespace Fire_Detector
{
    public partial class MainForm : Form, IReceiveListener
    {
        public interface IStateChangedListener
        {
            void OnStateChanged(bool connected);
        }

        private static Mat IRON_BLACK_PALETTE   = new Mat(256, 1, MatType.CV_8UC3, new byte[] { 255, 255, 255, 253, 253, 253, 251, 251, 251, 249, 249, 249, 247, 247, 247, 245, 245, 245, 243, 243, 243, 241, 241, 241, 239, 239, 239, 237, 237, 237, 235, 235, 235, 233, 233, 233, 231, 231, 231, 229, 229, 229, 227, 227, 227, 225, 225, 225, 223, 223, 223, 221, 221, 221, 219, 219, 219, 217, 217, 217, 215, 215, 215, 213, 213, 213, 211, 211, 211, 209, 209, 209, 207, 207, 207, 205, 205, 205, 203, 203, 203, 201, 201, 201, 199, 199, 199, 197, 197, 197, 195, 195, 195, 193, 193, 193, 191, 191, 191, 189, 189, 189, 187, 187, 187, 185, 185, 185, 183, 183, 183, 181, 181, 181, 179, 179, 179, 177, 177, 177, 175, 175, 175, 173, 173, 173, 171, 171, 171, 169, 169, 169, 167, 167, 167, 165, 165, 165, 163, 163, 163, 161, 161, 161, 159, 159, 159, 157, 157, 157, 155, 155, 155, 153, 153, 153, 151, 151, 151, 149, 149, 149, 147, 147, 147, 145, 145, 145, 143, 143, 143, 141, 141, 141, 139, 139, 139, 137, 137, 137, 135, 135, 135, 133, 133, 133, 131, 131, 131, 129, 129, 129, 126, 126, 126, 124, 124, 124, 122, 122, 122, 120, 120, 120, 118, 118, 118, 116, 116, 116, 114, 114, 114, 112, 112, 112, 110, 110, 110, 108, 108, 108, 106, 106, 106, 104, 104, 104, 102, 102, 102, 100, 100, 100, 98, 98, 98, 96, 96, 96, 94, 94, 94, 92, 92, 92, 90, 90, 90, 88, 88, 88, 86, 86, 86, 84, 84, 84, 82, 82, 82, 80, 80, 80, 78, 78, 78, 76, 76, 76, 74, 74, 74, 72, 72, 72, 70, 70, 70, 68, 68, 68, 66, 66, 66, 64, 64, 64, 62, 62, 62, 60, 60, 60, 58, 58, 58, 56, 56, 56, 54, 54, 54, 52, 52, 52, 50, 50, 50, 48, 48, 48, 46, 46, 46, 44, 44, 44, 42, 42, 42, 40, 40, 40, 38, 38, 38, 36, 36, 36, 34, 34, 34, 32, 32, 32, 30, 30, 30, 28, 28, 28, 26, 26, 26, 24, 24, 24, 22, 22, 22, 20, 20, 20, 18, 18, 18, 16, 16, 16, 14, 14, 14, 12, 12, 12, 10, 10, 10, 8, 8, 8, 6, 6, 6, 4, 4, 4, 2, 2, 2, 0, 0, 0, 9, 0, 0, 16, 0, 2, 24, 0, 4, 31, 0, 6, 38, 0, 8, 45, 0, 10, 53, 0, 12, 60, 0, 14, 67, 0, 17, 74, 0, 19, 82, 0, 21, 89, 0, 23, 96, 0, 25, 103, 0, 27, 111, 0, 29, 118, 0, 31, 120, 0, 36, 121, 0, 41, 122, 0, 46, 123, 0, 51, 124, 0, 56, 125, 0, 61, 126, 0, 66, 127, 0, 71, 128, 1, 76, 129, 1, 81, 130, 1, 86, 131, 1, 91, 132, 1, 96, 133, 1, 101, 134, 1, 106, 135, 1, 111, 136, 1, 116, 136, 1, 121, 137, 2, 125, 137, 2, 130, 137, 3, 135, 138, 3, 139, 138, 3, 144, 138, 4, 149, 139, 4, 153, 139, 5, 158, 139, 5, 163, 140, 5, 167, 140, 6, 172, 140, 6, 177, 141, 7, 181, 141, 7, 186, 137, 10, 189, 132, 13, 191, 127, 16, 194, 121, 19, 196, 116, 22, 198, 111, 25, 200, 106, 28, 203, 101, 31, 205, 95, 34, 207, 90, 37, 209, 85, 40, 212, 80, 43, 214, 75, 46, 216, 69, 49, 218, 64, 52, 221, 59, 55, 223, 49, 57, 224, 47, 60, 225, 44, 64, 226, 42, 67, 227, 39, 71, 228, 37, 74, 229, 34, 78, 230, 32, 81, 231, 29, 85, 231, 27, 88, 232, 24, 92, 233, 22, 95, 234, 19, 99, 235, 17, 102, 236, 14, 106, 237, 12, 109, 238, 12, 112, 239, 12, 116, 240, 12, 119, 240, 12, 123, 241, 12, 127, 241, 12, 130, 242, 12, 134, 242, 12, 138, 243, 13, 141, 243, 13, 145, 244, 13, 149, 244, 13, 152, 245, 13, 156, 245, 13, 160, 246, 13, 163, 246, 13, 167, 247, 13, 171, 247, 14, 175, 248, 15, 178, 248, 16, 182, 249, 18, 185, 249, 19, 189, 250, 20, 192, 250, 21, 196, 251, 22, 199, 251, 23, 203, 252, 24, 206, 252, 25, 210, 253, 27, 213, 253, 28, 217, 254, 29, 220, 254, 30, 224, 255, 39, 227, 255, 53, 229, 255, 67, 231, 255, 81, 233, 255, 95, 234, 255, 109, 236, 255, 123, 238, 255, 137, 240, 255, 151, 242, 255, 165, 244, 255, 179, 246, 255, 193, 248, 255, 207, 249, 255, 221, 251, 255, 235, 253, 255, 24, 255, 255 });
        private static float MAX_SCALED_SIZE    = 15.0f;

        private List<IStateChangedListener> _listener;
        private Mat                         _temperature;
        private Mat                         _mask;


        //
        // For maximize & normal state
        //
        private System.Drawing.Point        _beforePosition;
        private System.Drawing.Size         _beforeSize;


        public OYOReceiver Receiver { get; private set; }
        public OYOBlender Blender { get; private set; }
        public OYODetector Detector { get; private set; }
        public OYORecorder Recorder { get; private set; }

        public StreamingType StreamingType { get; set; }

        public string Palette { get; set; }

        public bool Blending { get; set; }

        public double TemperatureThreshold { get; set; }

        public bool DetectMarkEnabled { get; set; }

        private float _scaled = 1.0f;
        public float Scaled
        {
            get
            {
                if (this.Blending || this.defaultView.streamingFrameBox.SizeMode != PictureBoxSizeMode.CenterImage)
                    return MAX_SCALED_SIZE;

                if(this.StreamingType == StreamingType.Visual)
                    return MAX_SCALED_SIZE / 2.0f;

                return this._scaled;
            }

            set
            {
                this._scaled = Math.Max(1.0f, Math.Min(MAX_SCALED_SIZE, value));
            }
        }

        public OpenCvSharp.Size DisplaySize
        {
            get
            {
                var currentFrame = this.defaultView.streamingFrameBox.Image;
                var currentSize = new OpenCvSharp.Size(currentFrame.Width, currentFrame.Height);

                if (this.defaultView.streamingFrameBox.SizeMode == PictureBoxSizeMode.StretchImage)
                {
                    return new OpenCvSharp.Size(this.defaultView.streamingFrameBox.Size.Width, this.defaultView.streamingFrameBox.Size.Height);
                }
                else if (this.defaultView.streamingFrameBox.SizeMode == PictureBoxSizeMode.Zoom)
                {
                    var aspect = currentFrame.Width / (float)currentFrame.Height;
                    if (currentFrame.Width > currentFrame.Height)
                    {
                        return new OpenCvSharp.Size(this.defaultView.streamingFrameBox.Width, (int)(currentFrame.Height * (this.defaultView.streamingFrameBox.Height / (float)this.defaultView.streamingFrameBox.Width)));
                    }
                    else
                    {
                        return new OpenCvSharp.Size((int)(currentFrame.Width * (this.defaultView.streamingFrameBox.Width / (float)this.defaultView.streamingFrameBox.Height)), this.defaultView.streamingFrameBox.Height);
                    }
                }
                else
                {
                    return new OpenCvSharp.Size(currentFrame.Width, currentFrame.Height);
                }
            }
        }

        public Mat LastInfraredFrame { get; private set; }
        public Mat LastVisualFrame { get; private set; }
        public Mat LastDisplayFrame { get; private set; }

        public MainForm()
        {
            InitializeComponent();

            this.Receiver = new OYOReceiver("192.168.0.80", 8000, this);
            this.Blender = new OYOBlender(new OpenCvSharp.Size(720, 480));
            this.Detector = new OYODetector();
            this.Recorder = new OYORecorder();

            this._listener = new List<IStateChangedListener>();
            this._listener.Add(this.mainView);
            this._listener.Add(this.defaultView);
            this._listener.Add(this.defaultView.sideExpandedBar.visualizeTab);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void caption_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
                return;

            this.maximizeButton_Click(this.maximizeButton, EventArgs.Empty);
        }

        private void maximizeButton_Click(object sender, EventArgs e)
        {
            var isMaximized = this.Left == 0 && this.Top == 0 && this.Size.Width == Screen.PrimaryScreen.WorkingArea.Width && this.Size.Height == Screen.PrimaryScreen.WorkingArea.Height;
            if (isMaximized)
            {
                this.Left = this._beforePosition.X;
                this.Top = this._beforePosition.Y;
                this.Size = this._beforeSize;
                this.bunifuDragControl.Vertical = true;
                this.bunifuDragControl.Horizontal = true;
            }
            else
            {
                this._beforePosition = new System.Drawing.Point(this.Left, this.Top);
                this._beforeSize = this.Size;

                this.Left = this.Top = 0;
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                this.bunifuDragControl.Vertical = false;
                this.bunifuDragControl.Horizontal = false;
            }
        }

        private Mat mappingPalette(Mat frame)
        {
            lock (this.Palette)
            {
                var ret = new Mat();
                switch (this.Palette)
                {
                    case "Grayscale":
                        ret = frame;
                        break;

                    case "Rainbow":
                        Cv2.ApplyColorMap(frame, ret, ColormapTypes.Rainbow);
                        break;

                    case "IronBlack":
                        ret = frame.LUT(IRON_BLACK_PALETTE);
                        break;

                    default:
                        var ctype = (ColormapTypes)Enum.Parse(typeof(ColormapTypes), this.Palette);
                        Cv2.ApplyColorMap(frame, ret, ctype);
                        break;
                }

                return ret;
            }
        }

        public bool ConnectToCamera()
        {
            var result = this.Receiver.Connect();
            if(result)
                this.Receiver.Execute();

            foreach(var control in this._listener)
                control.OnStateChanged(this.Receiver.Connected);

            if(result == false)
                MessageBox.Show("서버와 연결할 수 없습니다.");
            return result;
        }

        public void DisconnectToCamera()
        {
            this.Receiver.Exit();
            foreach(var control in this._listener)
                control.OnStateChanged(false);
        }

        public void OnUpdate(StreamingType streamingType, OYOReceiver receiver)
        {
            try
            {
                var updatedFrame        = null as Mat;

                //
                // 일단 녹화를 한다.
                //
                if (streamingType == StreamingType.Infrared)
                {
                    updatedFrame            = this.mappingPalette(receiver.Infrared(this.Scaled));
                    this.LastInfraredFrame  = updatedFrame.Clone();
                }
                else
                {
                    updatedFrame            = receiver.Visual();
                    this.LastVisualFrame    = updatedFrame.Clone();
                }

                this.Recorder.Write(streamingType == StreamingType.Infrared ? OYORecorder.RecordingStateType.Infrared : OYORecorder.RecordingStateType.Visual, updatedFrame);


                //
                // 적외선 영상을 받아오는 경우에는 온도값과 마스크를 얻는다.
                //
                if (streamingType == StreamingType.Infrared)
                {
                    if (this.Blending)
                        this._temperature     = receiver.Temperature(this.Blender.Size);
                    else if(this.StreamingType == StreamingType.Visual)
                        this._temperature     = receiver.Temperature(this.DisplaySize);
                    else
                        this._temperature     = receiver.Temperature(this.Scaled);

                    this._mask                = this._temperature.Threshold(this.TemperatureThreshold, 255, ThresholdTypes.Binary);
                }


                //
                // 블렌딩을 하고 있는 경우에는 블렌딩된 결과를 얻는다.
                //
                if (this.Blending)
                {
                    lock (this.Blender)
                    {
                        if (streamingType == StreamingType.Infrared)
                        {
                            this.Blender.Update(updatedFrame, this._mask);
                        }
                        else
                        {
                            this.Blender.Update(updatedFrame);
                        }

                        if (this.Blender.Blendable)
                            updatedFrame        = this.Blender.Blending();
                    }
                }

                //
                // 화면에 표시한다.
                //
                if (this.Blending || this.StreamingType == streamingType)
                {
                    this.LastDisplayFrame = updatedFrame.Clone();

                    this.defaultView.streamingFrameBox.Invoke(new MethodInvoker(delegate ()
                    {
                        this.defaultView.streamingFrameBox.Image = Image.FromStream(new MemoryStream(updatedFrame.ToBytes()));
                    }));
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        public void OnError(string message)
        {
        }

        public void OnDisconnected()
        {
            foreach(var control in this._listener)
                control.OnStateChanged(false);
        }
    }
}
