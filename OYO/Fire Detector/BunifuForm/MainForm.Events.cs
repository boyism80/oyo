using BebopCommandSet;
using Fire_Detector.Dialog;
using OpenCvSharp;
using oyo;
using ParrotBebop2;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Fire_Detector.BunifuForm
{
    partial class MainForm
    {
        private Pcmd                _pcmd = new Pcmd();
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

        public void Receiver_OnConnected(OYOReceiver receiver)
        {
            this.OnConnectionChanged.Invoke(true);
        }

        public void Receiver_OnDisconnected(OYOReceiver receiver)
        {
            if(this.OnConnectionChanged != null)
                this.OnConnectionChanged.Invoke(false);
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
                    this.UpdatedDataBuffer.SetInfrared(this.MappingPalette(updatedFrame), receiver.Temperature(scaled));
                }
                else
                {
                    updatedFrame = receiver.Visual();
                    this.UpdatedDataBuffer.SetVisual(updatedFrame);
                }


                //
                // Set current frame box size to fix frame and temperature table size
                //
                updatedFrame = this.UpdatedDataBuffer.SetDisplay(this.GetDisplaySize(streamingType, updatedFrame));


                //
                // Blend if user checked
                //
                var temperature = this.UpdatedDataBuffer.Temperature;
                if (this.Config.Blending.Enabled)
                {
                    var mask = temperature.Threshold(this.defaultView.sideExpandedBar.visualizeTab.thresholdSlider.Value, 255, ThresholdTypes.Binary);
                    this.Blender.Update(this.UpdatedDataBuffer.Visual);
                    this.Blender.Update(this.UpdatedDataBuffer.Infrared, mask);

                    if(this.Blender.Blendable)
                        updatedFrame = this.Blender.Blending();
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Blender.Smooth                 = true;
            this.Blender.Transparency           = this.defaultView.sideExpandedBar.visualizeTab.transparencySlider.Value / 100.0f;

            OYOKeysHook.Set();
            OYOKeysHook.OnKeyboardHook += OnKeyboardHook;

            this.OnScreenStateChanged.Invoke(this.Size, false);
        }

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

            this.defaultView.sideExpandedBar.droneTab.UpdatePcmdUI(this._pcmd);
this._mutex.ReleaseMutex();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Receiver.Exit();
            this.Bebop.Disconnect();

            OYOKeysHook.Unset();
            this._mutex.Close();
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