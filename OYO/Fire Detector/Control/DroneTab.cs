using System;
using System.Windows.Forms;

namespace Fire_Detector.Control
{
    public partial class DroneTab : UserControl
    {
        public DroneTab()
        {
            InitializeComponent();
        }

        private void buttonCollapse_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if (mainform == null)
                return;

            mainform.defaultView.sideExpandedBar.Visible = false;
            //mainform.defaultView.sideCollapsedBar.Visible = true;
        }

        

        private void connectDroneButton_Click(object sender, EventArgs e)
        {
            if(connectDroneProgressbar.animated == true)
            {
                connectDroneProgressbar.animated = false;
                connectDroneProgressbar.Value = 0;


            }
            else
            {
                connectDroneProgressbar.animated = true;
                connectDroneProgressbar.Value = 15;


            }
        }

        
private void takeoffSwitch_OnValueChange(object sender, EventArgs e)
        {
            if(takeoffSwitch.Value == true)
            {
                detectionStateLabel.Text = "비행중";
                droneFlightProgressbar.Value = 30;
                droneFlightProgressbar.animated = true;
                droneFlightProgressbar.Visible = true;
                
            }
            else
            {
                detectionStateLabel.Text = "비행정지";
                droneFlightProgressbar.Value = 0;
                droneFlightProgressbar.animated = false;
                droneFlightProgressbar.Visible = false;
            }
        }

        private void droneSpeedSlider_ValueChanged(object sender, EventArgs e)
        {
            droneSpeedLabel.Text = droneSpeedSlider.Value.ToString();
        }
    }
}
