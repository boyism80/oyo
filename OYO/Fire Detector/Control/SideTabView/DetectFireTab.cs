using Fire_Detector.Source;
using OpenCvSharp;
using System;
using System.Windows.Forms;

namespace Fire_Detector.Control.SideTabView
{
    public partial class DetectFireTab : BaseTabView, BunifuForm.MainForm.IStateChangedListener
    {
        public DetectFireTab()
        {
            InitializeComponent();
        }

        public void OnStateChanged(bool connected)
        {
            
        }

        private void desiredTemperatureSlider_ValueChanged(object sender, EventArgs e)
        {
            desiredTemperatureLabel.Text = desiredTemperatureSlider.Value.ToString();

            if(this.Root == null)
                return;
        }

        private void detectionStateSwitch_OnValueChange(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

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

        private void DetectFireTab_Load(object sender, EventArgs e)
        {
            this.detectionStateSwitch_OnValueChange(this.detectionStateSwitch, EventArgs.Empty);
            this.desiredTemperatureSlider_ValueChanged(this.desiredTemperatureSlider, EventArgs.Empty);
        }

        public void OnUpdated(UpdatedDataBuffer buffer, Mat updatedFrame, bool invalidated)
        {
            this.maxTemperature.Invoke(new MethodInvoker(delegate ()
            {
                this.maxTemperature.Text = buffer.MaximumTemperature.ToString("0.00");
            }));

            this.minTemperature.Invoke(new MethodInvoker(delegate ()
            {
                this.minTemperature.Text = buffer.MinimumTemperature.ToString("0.00");
            }));

            this.meanTemperature.Invoke(new MethodInvoker(delegate ()
            {
                this.meanTemperature.Text = buffer.MeanTemperature.ToString("0.00");
            }));
        }

        public void OnSizeChanged(System.Drawing.Size size, bool isMaximize)
        {
        }
    }
}
