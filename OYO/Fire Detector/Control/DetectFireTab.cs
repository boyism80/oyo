using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fire_Detector.Control
{
    public partial class DetectFireTab : UserControl
    {
        public DetectFireTab()
        {
            InitializeComponent();
        }

        private void desiredTemperatureSlider_ValueChanged(object sender, EventArgs e)
        {
            desiredTemperatureLabel.Text = desiredTemperatureSlider.Value.ToString();


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
