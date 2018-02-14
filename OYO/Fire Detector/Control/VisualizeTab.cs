using OpenCvSharp;
using System;
using System.Windows.Forms;
using static Fire_Detector.MainForm;

namespace Fire_Detector.Control
{
    public partial class VisualizeTab : UserControl, IStateChangedListener
    {
        public VisualizeTab()
        {
            InitializeComponent();

            foreach (var cname in Enum.GetNames(typeof(ColormapTypes)))
                this.palettesDropDown.AddItem(cname);
        }

        public void OnStateChanged(bool connected)
        {
            try
            {
                this.connectionCameraProgressbar.Invoke(new MethodInvoker(delegate ()
                {
                    this.connectionCameraProgressbar.animated = connected;
                    this.connectionCameraProgressbar.Value = connected ? 40 : 0;
                }));

                this.connectionLabel.Invoke(new MethodInvoker(delegate ()
                {
                    connectionLabel.Text = connected ? "서버와 연결되었습니다." : "서버와 연결되지 않았습니다.";
                }));
            }
            catch (Exception)
            { }
        }

        private void connectCameraProgressbar_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if(mainform == null)
                return;

            if(mainform.Receiver.Connected)
                mainform.DisconnectToCamera();
            else
                mainform.ConnectToCamera();
        }

        private void infraredViewButton_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if(mainform == null)
                return;

            mainform.StreamingType = oyo.StreamingType.Infrared;
        }

        private void visualViewButton_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if(mainform == null)
                return;

            mainform.StreamingType = oyo.StreamingType.Visual;
        }

        private void palettesDropDown_onItemSelected(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if(mainform == null)
                return;

            mainform.Palette = this.palettesDropDown.selectedValue;
        }
    }
}
