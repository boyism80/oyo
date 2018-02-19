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
                var scaled = this.Config.Visualize.Scaled;

                if (this.Config.Blending.Enabled || this.defaultView.streamingFrameBox.SizeMode != PictureBoxSizeMode.CenterImage)
                    scaled = Source.Config.VisualizeConfig.MAX_SCALED_SIZE;

                else if (this.StreamingType == StreamingType.Visual)
                    scaled = Source.Config.VisualizeConfig.MAX_SCALED_SIZE / 2.0f;

                //
                // 일단 녹화를 한다.
                //
                if (streamingType == StreamingType.Infrared)
                {
                    var temperature = new Mat();
                    if(this.StreamingType == StreamingType.Infrared)
                        temperature     = receiver.Temperature(scaled);
                    else
                        temperature     = receiver.Temperature(this.DisplaySize);

                    this.UpdatedData.Update(this.MappingPalette(receiver.Infrared(scaled)), temperature, this.Config.Blending.Threshold);

                    //updatedFrame            = this.mappingPalette(receiver.Infrared(scaled));
                    this._currentInfraredFrame  = this.UpdatedData.Infrared.Clone();
                    this.Recorder.Write(OYORecorder.RecordingStateType.Infrared, this.UpdatedData.Infrared);
                }
                else
                {
                    this.UpdatedData.Update(receiver.Visual());
                    //updatedFrame            = receiver.Visual();
                    this._currentVisualFrame    = this.UpdatedData.Visual.Clone();
                    this.Recorder.Write(OYORecorder.RecordingStateType.Visual, this.UpdatedData.Visual);
                }

                //this.Recorder.Write(streamingType == StreamingType.Infrared ? OYORecorder.RecordingStateType.Infrared : OYORecorder.RecordingStateType.Visual, updatedFrame);



                //
                // 블렌딩을 하고 있는 경우에는 블렌딩된 결과를 얻는다.
                //
                if (this.Config.Blending.Enabled)
                {
                    lock (this.Blender)
                    {
                        if (streamingType == StreamingType.Infrared)
                        {
                            this.Blender.Update(this.UpdatedData.Infrared, this.UpdatedData.Mask);
                        }
                        else
                        {
                            this.Blender.Update(this.UpdatedData.Visual);
                        }

                        if (this.Blender.Blendable)
                            this.UpdatedData.SetUpdatedFrame(this.Blender.Blending());
                    }
                }
                else if (this.UpdatedData.StreamingType == StreamingType.Infrared)
                {
                    this.UpdatedData.SetUpdatedFrame(this.UpdatedData.Infrared.Clone());
                }
                else
                {
                    this.UpdatedData.SetUpdatedFrame(this.UpdatedData.Visual.Clone());
                }

                //
                // 산불 감지
                //
                if (this.Config.Detecting.Enabled)
                {
                    var detectionMask = this.UpdatedData.Temperature.Threshold(this.Config.Detecting.Threshold, 255, ThresholdTypes.Binary);
                    this.Detector.Update(detectionMask);
                    this.UpdatedData.SetUpdatedFrame(this.Detector.DrawDetectedRects(this.UpdatedData.UpdatedFrame));
                }

                //
                // 화면에 표시한다.
                //
                if (this.UpdatedData.SetInvalidateState(this.Config.Blending.Enabled, this.StreamingType))
                    this._currentDisplayFrame = this.UpdatedData.UpdatedFrame.Clone();

                foreach(var listener in this._listener)
                    listener.OnUpdated(this.UpdatedData);
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
    }
}
