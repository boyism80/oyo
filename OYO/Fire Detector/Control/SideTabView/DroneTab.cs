using System;
using System.Windows.Forms;

namespace Fire_Detector.Control.SideTabView
{
    public partial class DroneTab : BaseTabView
    {
        public DroneTab()
        {
            InitializeComponent();

            this.patrolModeSwitch_OnValueChange(this.patrolModeSwitch, EventArgs.Empty);
            this.recordModeSwitch_OnValueChange(this.recordModeSwitch, EventArgs.Empty);
        }

        private void buttonCollapse_Click(object sender, EventArgs e)
        {
            this.Root.defaultView.sideExpandedBar.Visible = false;
            //this.Root.defaultView.sideCollapsedBar.Visible = true;
        }



        private void connectDroneButton_Click(object sender, EventArgs e)
        {
            if (connectDroneProgressbar.animated == true)
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
            if (takeoffSwitch.Value == true)
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

            if (droneSpeedSlider.Value > 15) warningLabel.Visible = true;
            else warningLabel.Visible = false;
        }

        private void patrolModeSwitch_OnValueChange(object sender, EventArgs e)
        {
            this.recordPanel.Enabled = !this.patrolModeSwitch.Value;
            this.patrolControlPanel.Enabled = this.patrolModeSwitch.Value;
            if (this.patrolModeSwitch.Value)
                MessageBox.Show("녹화모드랑 같이 사용할 수 없습니다.");
        }

        private void recordModeSwitch_OnValueChange(object sender, EventArgs e)
        {
            this.patrolPanel.Enabled = !this.recordModeSwitch.Value;
            this.recordControlPanel.Enabled = this.recordModeSwitch.Value;
            if (this.recordModeSwitch.Value)
                MessageBox.Show("순찰모드랑 같이 사용할 수 없습니다.");
        }

        private void patrolStartEndButton_Click(object sender, EventArgs e)
        {
            if (patrolStartEndButton.ButtonText.Equals("순찰 시작"))
            {
                patrolStateLabel.Visible = true;
                patrolStateProgressbar.Visible = true;
                patrolStartEndButton.ButtonText = "순찰 정지";
            }
            else
            {
                patrolStateLabel.Visible = false;
                patrolStateProgressbar.Visible = false;
                patrolStartEndButton.ButtonText = "순찰 시작";
            }

        }

        private void recordStartEndButton_Click(object sender, EventArgs e)
        {
            if (recordStartEndButton.ButtonText.Equals("녹화 시작"))
            {
                recordStateLabel.Visible = true;
                recordStateProgressbar.Visible = true;
                recordStartEndButton.ButtonText = "녹화 정지";
            }
            else
            {
                recordStateLabel.Visible = false;
                recordStateProgressbar.Visible = false;
                recordStartEndButton.ButtonText = "녹화 시작";
            }
        }

        private void patrolFileBrowseButton_Click(object sender, EventArgs e)
        {
            Form patrolform = new Fire_Detector.Dialog.PatrolDialog();
            patrolform.ShowDialog();
        }

        private void recordFileSettingButton_Click(object sender, EventArgs e)
        {
            Form patrolform = new Fire_Detector.Dialog.RecordDialog();
            patrolform.ShowDialog();
        }
    }
}
