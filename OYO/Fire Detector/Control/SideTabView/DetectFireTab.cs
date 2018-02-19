using OpenCvSharp;
using System;
using System.Windows.Forms;
using static Fire_Detector.MainForm;

namespace Fire_Detector.Control.SideTabView
{
    public partial class DetectFireTab : BaseTabView, IStateChangedListener
    {
        public DetectFireTab()
        {
            InitializeComponent();
        }

        public void OnStateChanged(bool connected)
        {
            
        }

        public void OnUpdated(UpdateDataSet updateDataSet)
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

            this.Root.TemperatureThreshold = desiredTemperatureSlider.Value;
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
        }

        private void notificationSwitch_OnValueChange(object sender, EventArgs e)
        {
            if (notificationSwitch.Value == true)
                notificationLabel.Text = "On";
            else notificationLabel.Text = "Off";
        }
    }
}
