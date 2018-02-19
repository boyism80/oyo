using Fire_Detector.Source;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Fire_Detector.Control.SideTabView
{
    public partial class DetectFireTab : BaseTabView, BunifuForm.MainForm.IStateChangedListener
    {
        public DetectFireTab()
        {
            InitializeComponent();
        }

        public void OnSizeChanged(Size size, bool isMaximize)
        {
            //throw new NotImplementedException();
        }

        public void OnStateChanged(bool connected)
        {
            
        }

        public void OnUpdated(UpdateData updateDataSet)
        {
            this.maxTemperature.Invoke(new MethodInvoker(delegate ()
            {
                this.maxTemperature.Text = updateDataSet.MaximumTemperature.ToString("0.00");
            }));

            this.minTemperature.Invoke(new MethodInvoker(delegate ()
            {
                this.minTemperature.Text = updateDataSet.MinimumTemperature.ToString("0.00");
            }));

            this.meanTemperature.Invoke(new MethodInvoker(delegate ()
            {
                this.meanTemperature.Text = updateDataSet.MeanTemperature.ToString("0.00");
            }));
        }

        private void desiredTemperatureSlider_ValueChanged(object sender, EventArgs e)
        {
            desiredTemperatureLabel.Text = desiredTemperatureSlider.Value.ToString();

            if(this.Root == null)
                return;

            this.Root.Config.Detecting.Threshold = desiredTemperatureSlider.Value;
        }

        private void detectionStateSwitch_OnValueChange(object sender, EventArgs e)
        {
            if (detectionStateSwitch.Value == true)
            {
                detectionStateLabel.Text = "감지중";
                fireDetectionTemperatruePanel.Visible = true;
            }
            else
            {
                detectionStateLabel.Text = "감지 안함";
                fireDetectionTemperatruePanel.Visible = false;
            }

            this.Root.Config.Detecting.Enabled = detectionStateSwitch.Value;
        }

        private void notificationSwitch_OnValueChange(object sender, EventArgs e)
        {
            if (notificationSwitch.Value == true)
                notificationLabel.Text = "On";
            else notificationLabel.Text = "Off";
        }
    }
}
