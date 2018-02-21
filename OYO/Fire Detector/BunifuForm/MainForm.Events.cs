using OpenCvSharp;
using oyo;
using System;
using System.Windows.Forms;

namespace Fire_Detector.BunifuForm
{
    partial class MainForm : OYOReceiver.IReceiveListener
    {
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

            foreach(var listener in this._listener)
                listener.OnSizeChanged(this.Size, !isMaximized);
        }

        public void OnUpdate(StreamingType streamingType, OYOReceiver receiver)
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

                var invalidated = (this.Config.Blending.Enabled || (this.StreamingType == streamingType));
                foreach (var listener in this._listener)
                    listener.OnUpdated(this.UpdatedDataBuffer, updatedFrame, invalidated);
            }
            catch (Exception e)
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Receiver.Exit();
        }

        public void OnConnected()
        {
            foreach(var control in this._listener)
                control.OnStateChanged(true);
        }
    }
}
