using Fire_Detector.Control.SideTabView;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static Fire_Detector.MainForm;

namespace Fire_Detector.Control
{
    public partial class DefaultView : BaseTabView, IStateChangedListener
    {
        public DefaultView()
        {
            InitializeComponent();
        }

        public void OnStateChanged(bool connected)
        {
            try
            {
                this.streamingFrameBox.Invoke(new MethodInvoker(delegate ()
                {
                    this.streamingFrameBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    this.streamingFrameBox.Image = Properties.Resources.no_image_available;
                }));
            }
            catch (Exception)
            { }
        }

        public void OnUpdated(UpdateDataSet updateDataSet)
        {
            if(this.Root == null)
                return;

            if(updateDataSet.Invalidated == false)
                return;

            this.Root.defaultView.streamingFrameBox.Invoke(new MethodInvoker(delegate ()
            {
                this.Root.defaultView.streamingFrameBox.Image = Image.FromStream(new MemoryStream(updateDataSet.UpdatedFrame.ToBytes()));
            }));
        }

        private void streamingFrameBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
                return;

            var mainform = this.FindForm() as MainForm;
            if(mainform == null)
                return;

            if(mainform.Receiver.Connected == false)
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
            var mainform = this.FindForm() as MainForm;
            if(mainform == null)
                return;

            mainform.Scaled += (e.Delta / 120);
        }
    }
}
