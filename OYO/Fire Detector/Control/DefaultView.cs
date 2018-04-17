using Fire_Detector.Control.SideTabView;
using Fire_Detector.Source;
using OpenCvSharp;
using oyo;
using ParrotBebop2;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Fire_Detector.Control
{
    /// <summary>
    /// 디폴트 상태 뷰 클래스입니다.
    /// 메인뷰 이외의 상태에서 나타나는 모든 UI를 관리합니다.
    /// </summary>
    public partial class DefaultView : BaseControl
    {
        public DefaultView()
        {
            InitializeComponent();
        }

        public void Receiver_OnConnectionChanged(OYOReceiver receiver)
        {
            try
            {
                this.streamingFrameBox.Invoke(new MethodInvoker(delegate ()
                {
                    this.streamingFrameBox.SizeMode     = PictureBoxSizeMode.CenterImage;
                    this.streamingFrameBox.Image        = Properties.Resources.no_image_available;
                }));

                this.Cursor = Cursors.Default;
            }
            catch (Exception)
            { }
        }

        public void OnFrameUpdated(UpdatedDataBuffer buffer, Mat updatedFrame, bool invalidated)
        {
            if(this.Root == null)
                return;

            if(invalidated == false)
                return;

            this.streamingFrameBox.Invoke(new MethodInvoker(delegate ()
            {
                this.streamingFrameBox.Image = Image.FromStream(new MemoryStream(updatedFrame.ToBytes(".jpg")));
            }));
        }

        private void streamingFrameBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(this.Root == null)
                return;

            if(e.Button != MouseButtons.Left)
                return;

            if (this.Root.Receiver.Connected == false && this.Root.Bebop2.Connected == false)
                return;

            switch (this.streamingFrameBox.SizeMode)
            {
                case PictureBoxSizeMode.CenterImage:
                    this.streamingFrameBox.SizeMode = PictureBoxSizeMode.Zoom;
                    break;

                case PictureBoxSizeMode.Zoom:
                    this.streamingFrameBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;

                default:
                    this.streamingFrameBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    break;
            }

            this.Root.Overlayer.Update();
        }

        private void streamingFrameBox_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.Visualizer.Scaled += (e.Delta / 120);
            this.Root.Overlayer.Update();
        }

        private void streamingFrameBox_MouseClick(object sender, MouseEventArgs e)
        {
            if(this.Root == null)
                return;

            if(e.Button != MouseButtons.Left)
                return;

            if(this.Root.Receiver.Connected == false)
                return;

            var area = this.Root.Overlayer.ActiveArea();
            if (area.IsEmpty == false && area.Contains(e.X, e.Y))
            {
                if(this.Root.Overlayer.State == oyo.GmapState.Collapsed)
                    this.Root.Overlayer.State = oyo.GmapState.Expanded;
                else if(this.Root.Overlayer.State == oyo.GmapState.Expanded)
                    this.Root.Overlayer.State = oyo.GmapState.Full;
                else
                    this.Root.Overlayer.State = oyo.GmapState.Collapsed;

                this.Root.Overlayer.Update();

                return;
            }
        }

        private void streamingFrameBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(this.Root == null)
                return;

            if(this.Root.Receiver.Connected == false)
                return;

            var area = this.Root.Overlayer.ActiveArea();
            if (area.IsEmpty == false && area.Contains(e.X, e.Y))
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Default;
        }

        public void Overlayer_OnReceiveAddressEvent(string address)
        {
            this.bunifuCustomLabel2.Text = address;
        }

        public void Bebop2_OnSpeedChanged(Bebop2 bebop2, Leap.Vector speed)
        {
            this.droneSpeedLabel.Invoke(new MethodInvoker(delegate ()
            {
                this.droneSpeedLabel.Text = string.Format("{0:F2}m/s", speed.MagnitudeSquared);
            }));
        }

        public void Bebop2_OnAltitudeChanged(Bebop2 bebop, double altitude)
        {
            this.droneAltitudeLabel.Invoke(new MethodInvoker(delegate ()
            {
                this.droneAltitudeLabel.Text = string.Format("{0:F2}m", altitude);
            }));
        }
    }
}
