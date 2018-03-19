using BebopCommandSet;
using Fire_Detector.Dialog;
using OpenCvSharp;
using oyo;
using ParrotBebop2;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Fire_Detector.BunifuForm
{
    /// <summary>
    /// MainForm.Events.cs
    /// 
    /// 메인폼에서 등록한 이벤트들을 처리합니다.
    /// </summary>
    partial class MainForm
    {
        /// <summary>
        /// 드론에게 보낼 컨트롤 정보입니다.
        /// </summary>
        private Pcmd                _pcmd = new Pcmd();

        /// <summary>
        /// 드론에게 보낼 컨트롤을 조작하는데 필요한 뮤텍스 인스턴스입니다.
        /// </summary>
        private Mutex               _mutex = new Mutex();

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

            this.OnScreenStateChanged.Invoke(this.Size, !isMaximized);
        }

        public void Receiver_OnUpdate(OYOReceiver receiver, StreamingType streamingType)
        {
            try
            {
                //
                // Get scaled
                //
                var scaled = this.Config.Visualize.Scaled;
                if (this.Config.Blending.Enabled || this.defaultView.streamingFrameBox.SizeMode != PictureBoxSizeMode.CenterImage)
                    scaled = Source.Config.VisualizeConfig.MAX_SCALED_SIZE;

                else if (this.StreamingType == StreamingType.Visual)
                    scaled = Source.Config.VisualizeConfig.MAX_SCALED_SIZE / 2.0f;


                //
                // Get updated frame and store buffer
                //
                var updatedFrame = new Mat();
                if (streamingType == StreamingType.Infrared)
                {
                    updatedFrame = receiver.Infrared(scaled);
                    this.UpdatedDataBuffer.SetInfrared(this.mappingPalette(updatedFrame), receiver.Temperature(scaled));
                    this.Recorder.Write(OYORecorder.RecordingStateType.Infrared, updatedFrame);
                }
                else
                {
                    updatedFrame = receiver.Visual();
                    this.UpdatedDataBuffer.SetVisual(updatedFrame);
                    this.Recorder.Write(OYORecorder.RecordingStateType.Visual, updatedFrame);
                }


                //
                // Set current frame box size to fix frame and temperature table size
                //
                updatedFrame = this.UpdatedDataBuffer.SetDisplay(this.GetDisplaySize(streamingType, updatedFrame));


                //
                // Blend if user checked
                //
                var temperature = this.UpdatedDataBuffer.Temperature;
                var blendedFrame = new Mat();
                if (this.Config.Blending.Enabled || this.Recorder.IsRecording(OYORecorder.RecordingStateType.Blending))
                {
                    var mask = temperature.Threshold(this.defaultView.sideExpandedBar.visualizeTab.thresholdSlider.Value, 255, ThresholdTypes.Binary);
                    this.Blender.Update(this.UpdatedDataBuffer.Visual);
                    this.Blender.Update(this.UpdatedDataBuffer.Infrared, mask);

                    if(this.Blender.Blendable)
                        blendedFrame = this.Blender.Blending();

                    if(this.Config.Blending.Enabled)
                        updatedFrame = blendedFrame;

                    if(this.Recorder.IsRecording(OYORecorder.RecordingStateType.Blending) && streamingType == StreamingType.Infrared)
                        this.Recorder.Write(OYORecorder.RecordingStateType.Blending, blendedFrame);
                }
                
                //
                // Detect if user checked
                //
                if (this.Config.Detecting.Enabled)
                {
                    var mask = temperature.Threshold(this.defaultView.sideExpandedBar.detectFireTab.desiredTemperatureSlider.Value, 255, ThresholdTypes.Binary);
                    var betweenMin = this.UpdatedDataBuffer.MeanTemperature - this.UpdatedDataBuffer.MinimumTemperature;
                    var betweenMax = this.UpdatedDataBuffer.MaximumTemperature - this.UpdatedDataBuffer.MeanTemperature;

                    this.Detector.Update(mask, delegate (RotatedRect detectedRect)
                    {
                        var center = temperature.Get<float>((int)detectedRect.Center.Y, (int)detectedRect.Center.X);
                        if(center - this.UpdatedDataBuffer.MeanTemperature > betweenMin * DETECTION_ALPHA)
                            return true;

                        return false;
                    });

                    updatedFrame = this.Detector.DrawDetectedRects(updatedFrame);


                    // Draw temperature label
                    foreach (var detectedRect in this.Detector.DetectedRects)
                    {
                        var center = temperature.Get<float>((int)detectedRect.Center.Y, (int)detectedRect.Center.X);
                        this.markTemperature(updatedFrame, new Point(detectedRect.Center.X, detectedRect.Center.Y), center, Scalar.Red, scaled);
                    }
                }

                updatedFrame = this.Overlayer.Overlay(updatedFrame);

                var invalidated = (this.Config.Blending.Enabled || (this.StreamingType == streamingType));
                if(this.Recorder.IsRecording(OYORecorder.RecordingStateType.Display))
                {
                    if((this.Config.Blending.Enabled && streamingType == StreamingType.Infrared) || (this.StreamingType == streamingType))
                        this.Recorder.Write(OYORecorder.RecordingStateType.Display, updatedFrame);
                }

                this.OnFrameUpdated.Invoke(this.UpdatedDataBuffer, updatedFrame, invalidated);
            }
            catch (Exception)
            {
                return;
            }
        }

        public void Receiver_OnError(OYOReceiver receiver, string message)
        {
            var mainform = this;

            this.Invoke(new MethodInvoker(delegate ()
            {
                var dialog = new MessageDialog(message, System.Drawing.Color.Gainsboro);
                dialog.ShowDialog(mainform);
            }));
        }

        private void Receiver_OnDisconnected(OYOReceiver receiver)
        {
            this.Recorder.Release();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //
            // 글로벌 키보드 후킹을 연결합니다.
            // 드론 컨트롤에 사용됩니다.
            //
            OYOKeysHook.OnKeyboardHook += this.OnKeyboardHook;
            OYOKeysHook.Set();

            this.OnScreenStateChanged.Invoke(this.Size, false);
        }

        /// <summary>
        /// 키보드 조작이 일이나면 호출되는 핸들러입니다.
        /// </summary>
        /// <param name="key">조작된 키</param>
        /// <param name="isDown">키가 눌렸다면 true, 아니라면 false</param>
        private void OnKeyboardHook(Keys key, bool isDown)
        {
this._mutex.WaitOne();
            switch (key)
            {
                case Keys.Up:
                    this._pcmd.pitch = isDown ? 5 : 0;
                    break;

                case Keys.Down:
                    this._pcmd.pitch = isDown ? -5 : 0;
                    break;

                case Keys.Left:
                    this._pcmd.roll = isDown ? -5 : 0;
                    break;

                case Keys.Right:
                    this._pcmd.roll = isDown ? 5 : 0;
                    break;

                case Keys.W:
                    this._pcmd.gaz = isDown ? 25 : 0;
                    break;

                case Keys.S:
                    this._pcmd.gaz = isDown ? -25 : 0;
                    break;

                case Keys.A:
                    this._pcmd.yaw = isDown ? 50 : 0;
                    break;

                case Keys.D:
                    this._pcmd.yaw = isDown ? -50 : 0;
                    break;
            }

            if (this._pcmd.pitch == 0 && this._pcmd.roll == 0)
            {
                this._pcmd.flag = 0;
                this._pcmd.pitch = 0;
                this._pcmd.roll = 0;
            }
            else
            {
                this._pcmd.flag = 1;
                this._pcmd.yaw = 0;
                this._pcmd.gaz = 0;
            }

            this.defaultView.sideExpandedBar.droneTab.updatePcmdUI(this._pcmd);
this._mutex.ReleaseMutex();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Receiver.Exit();
            this.Bebop.Disconnect();

            OYOKeysHook.Unset();
            this._mutex.Close();

            this.Recorder.Release();
        }

        public void Bebop2_OnStreaming(Bebop2 bebop, Mat frame)
        {
        }

        public Pcmd Bebop2_OnRequestPcmd(Bebop2 bebop)
        {
this._mutex.WaitOne();
            var pcmd = new Pcmd(this._pcmd);
this._mutex.ReleaseMutex();
            return pcmd;
        }

        public void Bebop2_OnAltitudeChanged(Bebop2 bebop, double altitude)
        {
            this.defaultView.droneAltitudeLabel.Invoke(new MethodInvoker(delegate ()
            {
                this.defaultView.droneAltitudeLabel.Text = altitude.ToString();
            }));
        }

        private void Bebop_OnPositionChanged(Bebop2 bebop2, double lat, double lon, double alt)
        {
            this.Overlayer.Update(bebop2.GPS);
        }

        private void Bebop_OnError(Bebop2 bebop, string message)
        {
            var mainform = this;
            this.Invoke(new MethodInvoker(delegate ()
            {
                var dialog = new MessageDialog(message, System.Drawing.Color.Gainsboro);
                dialog.ShowDialog(mainform);
            }));
        }
    }
}