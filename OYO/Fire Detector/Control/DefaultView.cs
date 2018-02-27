using Fire_Detector.Control.SideTabView;
using Fire_Detector.Source;
using OpenCvSharp;
using oyo;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Fire_Detector.Control
{
    public partial class DefaultView : BaseTabView, BunifuForm.MainForm.IStateChangedListener
    {
        public enum GoogleMapState
        {
            Collapsed, Expanded, Full,
        }


        // 구글맵 표시를 위한 변수입니다.
        public OYOGMapOverlayer                _overlayer;


        public GoogleMapState GmapState { get; private set; }

        public Mat Gmap { get; set; }

        public DefaultView()
        {
            InitializeComponent();

            this._overlayer = new OYOGMapOverlayer(this.streamingFrameBox);
        }

        public void OnSizeChanged(System.Drawing.Size size, bool isMaximize)
        {
            //throw new NotImplementedException();
        }

        public void OnStateChanged(bool connected)
        {
            try
            {
                if (connected == false)
                {
                    this.streamingFrameBox.Invoke(new MethodInvoker(delegate ()
                    {
                        this.streamingFrameBox.SizeMode = PictureBoxSizeMode.CenterImage;
                        this.streamingFrameBox.Image = Properties.Resources.no_image_available;
                    }));
                }
            }
            catch (Exception)
            { }
        }

        public void OnUpdated(UpdatedDataBuffer buffer, Mat updatedFrame, bool invalidated)
        {
            if(this.Root == null)
                return;

            if(invalidated == false)
                return;

            
            updatedFrame = this._overlayer.Overlay(updatedFrame, new OpenCvSharp.Point(50, 50));
            this.streamingFrameBox.Invoke(new MethodInvoker(delegate ()
            {
                this.streamingFrameBox.Image = Image.FromStream(new MemoryStream(updatedFrame.ToBytes(".jpg")));
            }));
        }

        private void streamingFrameBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
                return;

            if(this.Root == null)
                return;

            if (this.Root.Receiver.Connected == false && this.Root.Bebop.Connected == false)
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
        }

        private void streamingFrameBox_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.Config.Visualize.Scaled += (e.Delta / 120);
        }

        private void streamingFrameBox_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
                return;

            var area = this._overlayer.ActiveArea();
            if (area.IsEmpty == false && area.Contains(e.X, e.Y))
            {
                if(this._overlayer.State == oyo.GmapState.Collapsed)
                    this._overlayer.State = oyo.GmapState.Expanded;
                else if(this._overlayer.State == oyo.GmapState.Expanded)
                    this._overlayer.State = oyo.GmapState.Full;
                else
                    this._overlayer.State = oyo.GmapState.Collapsed;

                this._overlayer.Update();

                return;
            }
        }

        private void streamingFrameBox_MouseMove(object sender, MouseEventArgs e)
        {
            var area = this._overlayer.ActiveArea();
            if (area.IsEmpty == false && area.Contains(e.X, e.Y))
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Default;
        }

        
    }
}
