using BebopCommandSet;
using Fire_Detector.Dialog;
using Fire_Detector.Source.Extension;
using OpenCvSharp;
using oyo;
using ParrotBebop2;
using System;
using System.Diagnostics;
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

        private Stopwatch           _stopwatch = new Stopwatch();
        private int                 _fps, _lastFps;

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Receiver.OnConnected               += this.defaultView.Receiver_OnConnectionChanged;
            this.Receiver.OnConnected               += this.defaultView.sideExpandedBar.visualizeTab.Receiver_OnConnectionChanged;
            this.Receiver.OnConnected               += this.mainView.mainConnectionView.Receiver_OnConnectionChanged;
            this.Receiver.OnConnected               += this.defaultView.sideExpandedBar.droneTab.Receiver_OnConnectionChanged;
            this.Receiver.OnDisconnected            += this.Receiver_OnDisconnected;
            this.Receiver.OnDisconnected            += this.defaultView.Receiver_OnConnectionChanged;
            this.Receiver.OnDisconnected            += this.defaultView.sideExpandedBar.visualizeTab.Receiver_OnConnectionChanged;
            this.Receiver.OnDisconnected            += this.defaultView.sideExpandedBar.detectFireTab.Receiver_OnDisconnected;
            this.Receiver.OnDisconnected            += this.mainView.mainConnectionView.Receiver_OnConnectionChanged;
            this.Receiver.OnDisconnected            += this.defaultView.sideExpandedBar.droneTab.Receiver_OnConnectionChanged;
            this.Receiver.OnUpdate                  += this.Receiver_OnUpdate;
            this.Receiver.OnError                   += this.Receiver_OnError;

            this.Detector.OnEnabledChanged          += this.defaultView.sideExpandedBar.detectFireTab.Detector_OnNotificationChanged;
            this.Detector.OnNotificationChanged     += this.defaultView.sideExpandedBar.detectFireTab.Detector_OnNotificationChanged;
            this.Detector.OnDetectionStateChanged   += this.defaultView.sideExpandedBar.detectFireTab.Detector_OnDetectionStateChanged;

            this.Recorder.OnIncreasedTime           += this.defaultView.sideExpandedBar.droneTab.Recorder_OnIncreasedTime;

            this.Overlayer.OnReceiveAddressEvent    += this.defaultView.Overlayer_OnReceiveAddressEvent;
            this.Overlayer.OnReceiveAddressEvent    += this.mainView.mainConnectionView.Overlayer_OnReceiveAddressEvent;

            this.Bebop2.OnConnected                 += this.mainView.mainConnectionView.Bebop_OnConnectionChanged;
            this.Bebop2.OnConnected                 += this.defaultView.sideExpandedBar.droneTab.Bebop_OnConnectionChanged;
            this.Bebop2.OnDisconnected              += this.mainView.mainConnectionView.Bebop_OnConnectionChanged;
            this.Bebop2.OnDisconnected              += this.defaultView.sideExpandedBar.droneTab.Bebop_OnConnectionChanged;
            this.Bebop2.OnStreaming                 += this.Bebop2_OnStreaming;
            this.Bebop2.OnRequestPcmd               += this.Bebop2_OnRequestPcmd;
            this.Bebop2.OnSpeedChanged              += this.defaultView.Bebop2_OnSpeedChanged;
            this.Bebop2.OnAltitudeChanged           += this.defaultView.Bebop2_OnAltitudeChanged;
            this.Bebop2.OnPositionChanged           += this.Bebop_OnPositionChanged;
            this.Bebop2.OnError                     += this.Bebop_OnError;
            this.Bebop2.OnBatteryChanged            += this.defaultView.Bebop2_OnBatteryChanged;
            this.Bebop2.OnBatteryChanged            += this.mainView.mainConnectionView.Bebop2_OnBatteryChanged;
            this.Bebop2.OnWifiChanged               += this.defaultView.Bebop2_OnWifiChanged;
            this.Bebop2.OnWifiChanged               += this.mainView.mainConnectionView.Bebop2_OnWifiChanged;
            this.Bebop2.OnPositionChanged           += this.mainView.mainConnectionView.Bebop2_OnPositionChanged;



            this.LeapController.Connect             += this.mainView.mainConnectionView.LeapController_Device;
            this.LeapController.Connect             += this.defaultView.sideExpandedBar.leapmotionTab.LeapController_Device;
            this.LeapController.Disconnect          += this.mainView.mainConnectionView.LeapController_DeviceLost;
            this.LeapController.Disconnect          += this.defaultView.sideExpandedBar.leapmotionTab.LeapController_Disconnect;
            this.LeapController.FrameReady          += this.LeapController_FrameReady;
            this.LeapController.FrameReady          += this.mainView.mainConnectionView.LeapController_FrameReady;
            this.LeapController.FrameReady          += this.defaultView.sideExpandedBar.leapmotionTab.LeapController_FrameReady;

            this.OnFrameUpdated                     += this.defaultView.OnFrameUpdated;
            this.OnFrameUpdated                     += this.defaultView.sideExpandedBar.detectFireTab.OnFrameUpdated;

            this.OnScreenStateChanged               += this.mainView.OnScreenStateChanged;
            this.OnScreenStateChanged               += this.mainView.mainConnectionView.OnScreenStateChanged;


            this.Patrol.Reader.OnChanged            += this.PatrolReader_OnChanged;
            this.Patrol.Reader.OnExit               += this.PatrolReader_OnExit;

            OYOKeysHook.OnKeyboardHook              += this.OnKeyboardHook;
            OYOKeysHook.Set();

            this.OnScreenStateChanged.Invoke(this.Size, false);
            this.loadConfig("config.json");

            this._stopwatch.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Receiver.Exit();
            this.Bebop2.Disconnect();
            this.Patrol.Stop();

            OYOKeysHook.Unset();
            this._mutex.Close();

            this.Recorder.Release();
            this.saveConfig("config.json");

            this.LeapController.FrameReady -= this.mainView.mainConnectionView.LeapController_FrameReady;
            this.LeapController.FrameReady -= this.defaultView.sideExpandedBar.leapmotionTab.LeapController_FrameReady;
            this.LeapController.FrameReady -= this.LeapController_FrameReady;
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
                this.Left                           = this._beforePosition.X;
                this.Top                            = this._beforePosition.Y;
                this.Size                           = this._beforeSize;
                this.bunifuDragControl.Vertical     = true;
                this.bunifuDragControl.Horizontal   = true;
            }
            else
            {
                this._beforePosition                = new System.Drawing.Point(this.Left, this.Top);
                this._beforeSize                    = this.Size;
                this.Left                           = 0;
                this.Top                            = 0;
                this.Size                           = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                this.bunifuDragControl.Vertical     = false;
                this.bunifuDragControl.Horizontal   = false;
            }

            this.OnScreenStateChanged.Invoke(this.Size, !isMaximized);
        }

        public void Receiver_OnUpdate(OYOReceiver receiver, StreamingType streamingType)
        {
            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                //
                // Get scaled
                //
                var scaled = this.Visualizer.Scaled / 10.0f;
                var baseSize = new OpenCvSharp.Size(640 * scaled, 480 * scaled);


                //
                // Get updated frame and store buffer
                //
                var updatedFrame                    = new Mat();
                if (streamingType == StreamingType.Infrared)
                {
                    updatedFrame                    = receiver.Infrared(baseSize);
                    this.UpdatedDataBuffer.SetInfrared(this.Visualizer.mappingPalette(updatedFrame), receiver.Temperature(baseSize));
                    this.Recorder.Write(OYORecorder.RecordingStateType.Infrared, updatedFrame);
                }
                else
                {
                    updatedFrame                    = receiver.Visual(baseSize);
                    this.UpdatedDataBuffer.SetVisual(updatedFrame);
                    this.Recorder.Write(OYORecorder.RecordingStateType.Visual, updatedFrame);
                }


                //
                // Set current frame box size to fix frame and temperature table size
                //
                this.Blender.Size                   = baseSize;
                var currentDisplaySize              = this.GetDisplaySize(streamingType, updatedFrame);
                updatedFrame                        = this.UpdatedDataBuffer.SetDisplay(currentDisplaySize);


                //
                // Blend if user checked
                //
                var blendedFrame                    = new Mat();
                if (this.Blender.Enabled || this.Recorder.IsRecording(OYORecorder.RecordingStateType.Blending))
                {
                    var mask                        = this.UpdatedDataBuffer.Temperature.Threshold(this.Blender.Threshold, 255, ThresholdTypes.Binary);
                    this.Blender.Update(this.UpdatedDataBuffer.Visual);
                    this.Blender.Update(this.UpdatedDataBuffer.Infrared, mask);

                    if(this.Blender.Blendable)
                        blendedFrame                = this.Blender.Blending();

                    if(this.Blender.Enabled)
                        updatedFrame                = blendedFrame;

                    if(this.Recorder.IsRecording(OYORecorder.RecordingStateType.Blending) && streamingType == StreamingType.Infrared)
                        this.Recorder.Write(OYORecorder.RecordingStateType.Blending, blendedFrame);
                }


                //
                // Record display frame
                //
                var isDisplayRecordable             = this.Recorder.IsRecording(OYORecorder.RecordingStateType.Display) && ((this.Blender.Enabled && streamingType == StreamingType.Infrared) || (this.Visualizer.StreamingType == streamingType));
                if (isDisplayRecordable)
                {
                    var currentRecordSize           = this.Recorder.GetRecordSize(OYORecorder.RecordingStateType.Display);
                    var displayFrame                = updatedFrame.Resize(currentRecordSize);
                    this.UpdatedDataBuffer.SetDisplay(currentRecordSize);

                    // Draw detection boxes
                    if (this.defaultView.sideExpandedBar.droneTab.ShowDetectionBoxes)
                    {
                        var mask                    = this.UpdatedDataBuffer.Temperature.Threshold(this.defaultView.sideExpandedBar.detectFireTab.desiredTemperatureSlider.Value, 255, ThresholdTypes.Binary);
                        var betweenMin              = this.UpdatedDataBuffer.MeanTemperature - this.UpdatedDataBuffer.MinimumTemperature;
                        var betweenMax              = this.UpdatedDataBuffer.MaximumTemperature - this.UpdatedDataBuffer.MeanTemperature;

                        this.Detector.Update(mask, delegate (RotatedRect detectedRect)
                        {
                            var center              = this.UpdatedDataBuffer.Temperature.Get<float>((int)detectedRect.Center.Y, (int)detectedRect.Center.X);
                            if(center - this.UpdatedDataBuffer.MeanTemperature > betweenMin * DETECTION_ALPHA)
                                return true;

                            return false;
                        });

                        displayFrame                = this.Detector.DrawDetectedRects(displayFrame);


                        // Draw temperature label
                        foreach (var detectedRect in this.Detector.DetectedRects)
                        {
                            var center              = this.UpdatedDataBuffer.Temperature.Get<float>((int)detectedRect.Center.Y, (int)detectedRect.Center.X);
                            this.Visualizer.markTemperature(displayFrame, new Point(detectedRect.Center.X, detectedRect.Center.Y), center, Scalar.Red);
                        }
                    }

                    // Draw google map
                    if (this.defaultView.sideExpandedBar.droneTab.ShowGmap)
                    {
                        displayFrame                = this.Overlayer.Overlay(displayFrame, this.Overlayer.GetGmapPadding(displayFrame));
                    }

                    // Write record frame
                    this.Recorder.Write(OYORecorder.RecordingStateType.Display, displayFrame);

                    // Restore previous size
                    this.UpdatedDataBuffer.SetDisplay(currentDisplaySize);
                }
                

                //
                // Detect current frame that showing
                //
                if (this.Detector.Enabled)
                {
                    var mask                        = this.UpdatedDataBuffer.Temperature.Threshold(this.defaultView.sideExpandedBar.detectFireTab.desiredTemperatureSlider.Value, 255, ThresholdTypes.Binary);
                    var betweenMin                  = this.UpdatedDataBuffer.MeanTemperature - this.UpdatedDataBuffer.MinimumTemperature;
                    var betweenMax                  = this.UpdatedDataBuffer.MaximumTemperature - this.UpdatedDataBuffer.MeanTemperature;

                    this.Detector.Detect(mask, delegate (RotatedRect detectedRect)
                    {
                        var center                  = this.UpdatedDataBuffer.Temperature.Get<float>((int)detectedRect.Center.Y, (int)detectedRect.Center.X);
                        if(center - this.UpdatedDataBuffer.MeanTemperature > betweenMin * DETECTION_ALPHA)
                            return true;

                        return false;
                    });

                    updatedFrame                    = this.Detector.DrawDetectedRects(updatedFrame);


                    // Draw temperature label
                    foreach (var detectedRect in this.Detector.DetectedRects)
                    {
                        var center                  = this.UpdatedDataBuffer.Temperature.Get<float>((int)detectedRect.Center.Y, (int)detectedRect.Center.X);
                        this.Visualizer.markTemperature(updatedFrame, new Point(detectedRect.Center.X, detectedRect.Center.Y), center, Scalar.Red);
                    }
                }

                

                if ((this.Blender.Enabled && streamingType == StreamingType.Infrared) || (!this.Blender.Enabled && this.Visualizer.StreamingType == streamingType))
                    this._fps++;

                if (this._stopwatch.ElapsedMilliseconds > 1000.0f)
                {
                    this._lastFps = this._fps;
                    this._fps = 0;
                    this._stopwatch.Restart();
                }

                updatedFrame                        = updatedFrame.Resize(currentDisplaySize);
                var fontScaled                      = Math.Min(updatedFrame.Width / 1200.0f, 0.8f);
                var baseLine                        = 0;
                var text                            = string.Format("fps : {0}", this._lastFps);
                var font                            = HersheyFonts.HersheyPlain;
                var textSize                        = Cv2.GetTextSize(text, font, fontScaled, 1, out baseLine);
                Cv2.PutText(updatedFrame, text, new OpenCvSharp.Point(updatedFrame.Width - textSize.Width * 2, textSize.Height * 3), HersheyFonts.HersheyDuplex, fontScaled, Scalar.White);


                var invalidated                     = (this.Blender.Enabled || (this.Visualizer.StreamingType == streamingType));
                updatedFrame                        = this.Overlayer.Overlay(updatedFrame);

                this.OnFrameUpdated.Invoke(this.UpdatedDataBuffer, updatedFrame, invalidated);

                stopwatch.Stop();

                var header = string.Empty;
                if(this.Blender.Enabled)
                    header = "Blend";
                else if(this.Visualizer.StreamingType == StreamingType.Infrared)
                    header = "Infrared";
                else
                    header = "Visual";

                stopwatch.Restart();
            }
            catch (Exception e)
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

        /// <summary>
        /// 키보드 조작이 일이나면 호출되는 핸들러입니다.
        /// </summary>
        /// <param name="key">조작된 키</param>
        /// <param name="isDown">키가 눌렸다면 true, 아니라면 false</param>
        private void OnKeyboardHook(Keys key, bool isDown)
        {
            if(this.Patrol.Reader.IsEnabled())
                return;

            if(this.LeapController.Enabled)
                return;

this._mutex.WaitOne();
            switch (key)
            {
                case Keys.Up:
                    this._pcmd.pitch = isDown ? this.defaultView.sideExpandedBar.droneTab.GetDroneSpeed() : 0;
                    break;

                case Keys.Down:
                    this._pcmd.pitch = isDown ? -this.defaultView.sideExpandedBar.droneTab.GetDroneSpeed() : 0;
                    break;

                case Keys.Left:
                    this._pcmd.roll = isDown ? -this.defaultView.sideExpandedBar.droneTab.GetDroneSpeed() : 0;
                    break;

                case Keys.Right:
                    this._pcmd.roll = isDown ? this.defaultView.sideExpandedBar.droneTab.GetDroneSpeed() : 0;
                    break;

                case Keys.W:
                    this._pcmd.gaz = isDown ? this.defaultView.sideExpandedBar.droneTab.GetDroneSpeed() : 0;
                    break;
                    
                case Keys.S:
                    this._pcmd.gaz = isDown ? -this.defaultView.sideExpandedBar.droneTab.GetDroneSpeed() : 0;
                    break;

                case Keys.A:
                    this._pcmd.yaw = isDown ? -this.defaultView.sideExpandedBar.droneTab.GetDroneSpeed() : 0;
                    break;

                case Keys.D:
                    this._pcmd.yaw = isDown ? this.defaultView.sideExpandedBar.droneTab.GetDroneSpeed() : 0;
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
            if(this.Patrol.Mode == OYOPatrol.PatrolMode.Write)
                this.Patrol.Writer.Write(this._pcmd);
this._mutex.ReleaseMutex();
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

        private void LeapController_FrameReady(object sender, Leap.FrameEventArgs e)
        {
            if(this.Patrol.Reader.IsEnabled())
                return;

            var handRight                   = e.frame.RightHand();
            if(handRight != null)
            {
                // move left, right
                var angle_rotated           = handRight.PalmNormal.AngleTo(Leap.Vector.Down) * (180 / Math.PI);
                var cross_rotated           = handRight.PalmNormal.Cross(Leap.Vector.Down);

                if(angle_rotated > MainForm.LEAPMOTION_MINIMUM_MOVE_SIDE_ANGLE)
                    this._pcmd.roll         = 5 * (cross_rotated.z > 0 ? 1 : -1);
                else
                    this._pcmd.roll         = 0;


                
                // move up, down
                if(handRight.PalmPosition.y > MainForm.LEAPMOTION_MINIMUM_UP_POSITION)
                    this._pcmd.gaz          = 25;
                else if(handRight.PalmPosition.y < MainForm.LEAPMOTION_MINIMUM_DOWN_POSITION)
                    this._pcmd.gaz          = -25;
                else
                    this._pcmd.gaz          = 0;



                // move forward, backward
                var direction               = (handRight.PalmPosition - Leap.Vector.Zero).Normalized;
                var angle_forward           = direction.AngleTo(Leap.Vector.Up) * (180 / Math.PI);
                var cross_forward           = direction.Cross(Leap.Vector.Up);
                var calibrated_angle        = MainForm.LEAPMOTION_CALIBRATION_FORWARD_VALUE + angle_forward * (cross_forward.x > 0 ? 1 : -1);
                if(Math.Abs(calibrated_angle) > MainForm.LEAPMOTION_MINIMUM_FORWARD_ANGLE)
                    this._pcmd.pitch        = 5 * (calibrated_angle > 0 ? 1 : -1);
                else
                    this._pcmd.pitch        = 0;
            }
            else
            {
                this._pcmd.roll             = 0;
                this._pcmd.gaz              = 0;
                this._pcmd.pitch            = 0;
            }

            var handLeft = e.frame.LeftHand();
            if(handLeft != null)
            {
                // rotate left, right
                var direction               = handLeft.Direction.Normalized;
                var cross                   = direction.Cross(Leap.Vector.Forward);
                var angle                   = direction.AngleTo(Leap.Vector.Forward) * 180.0f / Math.PI * (cross.y < 0 ? 1 : -1) + MainForm.LEAPMOTION_CALIBRATION_ROTATION_VALUE;

                if(Math.Abs(angle) > MainForm.LEAPMOTION_MINIMUM_ROTATION_ANGLE)
                    this._pcmd.yaw          = 50 * (angle > 0.0f ? 1 : -1);
                else
                    this._pcmd.yaw          = 0;
            }
            else
            {
                this._pcmd.yaw              = 0;
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
        }

        private void PatrolReader_OnExit()
        {
            this._pcmd.Reset();

            this.defaultView.sideExpandedBar.droneTab.updatePcmdUI(this._pcmd);
        }

        private void PatrolReader_OnChanged(Pcmd pcmd)
        {
            this._pcmd = new Pcmd(pcmd);
            this.defaultView.sideExpandedBar.droneTab.updatePcmdUI(this._pcmd);
        }
    }
}