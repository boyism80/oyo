using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fire_Detector.Control.SideTabView
{
    public partial class DroneTab : BaseTabView
    {
        public static int WARNING_DRONE_SPEED = 15;

        private bool _isPatroling = false;

        public DroneTab()
        {
            InitializeComponent();
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

            if (droneSpeedSlider.Value > WARNING_DRONE_SPEED) warningLabel.Visible = true;
            else warningLabel.Visible = false;
        }

        private void UpdateUI()
        {
            try
            {
                var isPatrolActive = this.patrolModeSwitch.Value;
                this.recordModeSwitch.Invoke(new MethodInvoker(delegate () {
                    this.recordModeSwitch.Enabled = !isPatrolActive;
                }));

                this.patrolFileBrowseButton.Invoke(new MethodInvoker(delegate ()
                {
                
                    this.patrolFileBrowseButton.Tag = isPatrolActive;
                    this.patrolFileBrowseButton.ActiveFillColor = isPatrolActive ? Color.LightSalmon : Color.Transparent;
                    this.patrolFileBrowseButton.ActiveForecolor = isPatrolActive ? Color.White : SystemColors.ControlDarkDark;
                    this.patrolFileBrowseButton.ActiveLineColor = isPatrolActive ? Color.Salmon : SystemColors.ControlDarkDark;
                }));

                this.patrolStartEndButton.Invoke(new MethodInvoker(delegate () {

                    this.patrolStartEndButton.Tag = isPatrolActive;
                    this.patrolStartEndButton.ActiveFillColor = isPatrolActive ? Color.LightSalmon : Color.Transparent;
                    this.patrolStartEndButton.ActiveForecolor = isPatrolActive ? Color.White : SystemColors.ControlDarkDark;
                    this.patrolStartEndButton.ActiveLineColor = isPatrolActive ? Color.Salmon : SystemColors.ControlDarkDark;
                }));

                this.patrolStartEndButton.Invoke(new MethodInvoker(delegate ()
                {
                    patrolStateLabel.Visible = this._isPatroling;
                    patrolStateProgressbar.Visible = this._isPatroling;
                    patrolStartEndButton.ButtonText = this._isPatroling ? "순찰 정지" : "순찰 시작";
                }));


                var isRecordActive = this.recordModeSwitch.Value;
                this.patrolModeSwitch.Invoke(new MethodInvoker(delegate ()
                {
                    this.patrolModeSwitch.Enabled = !isRecordActive;
                }));

                this.recordFileSettingButton.Invoke(new MethodInvoker(delegate ()
                {
                    this.recordFileSettingButton.Tag = isRecordActive;
                    this.recordFileSettingButton.ActiveFillColor = isRecordActive ? Color.LightSalmon : Color.Transparent;
                    this.recordFileSettingButton.ActiveForecolor = isRecordActive ? Color.White : SystemColors.ControlDarkDark;
                    this.recordFileSettingButton.ActiveLineColor = isRecordActive ? Color.Salmon : SystemColors.ControlDarkDark;
                }));

                this.beginRecordButton.Invoke(new MethodInvoker(delegate ()
                {
                    this.beginRecordButton.Tag = isRecordActive;
                    this.beginRecordButton.ActiveFillColor = isRecordActive ? Color.LightSalmon : Color.Transparent;
                    this.beginRecordButton.ActiveForecolor = isRecordActive ? Color.White : SystemColors.ControlDarkDark;
                    this.beginRecordButton.ActiveLineColor = isRecordActive ? Color.Salmon : SystemColors.ControlDarkDark;
                }));
            }
            catch(Exception)
            { }
        }

        private void patrolModeSwitch_OnValueChange(object sender, EventArgs e)
        {
            if(this.patrolModeSwitch.Value == false)
                this._isPatroling = false;

            this.UpdateUI();

            if (this.patrolModeSwitch.Value) {
                var message = "녹화모드와 같이 사용할 수 없습니다.";
                var messageform = new Fire_Detector.Dialog.MessageDialog(message);
                messageform.ShowDialog(this.Root);
            }
        }

        private void recordModeSwitch_OnValueChange(object sender, EventArgs e)
        {
            this.UpdateUI();
            if (this.recordModeSwitch.Value)
            {
                var message = "순찰모드와 같이 사용할 수 없습니다.";
                var messageform = new Fire_Detector.Dialog.MessageDialog(message);
                messageform.ShowDialog(this.Root);
            }
        }

        private void patrolStartEndButton_Click(object sender, EventArgs e)
        {
            var isActive = (bool)this.patrolStartEndButton.Tag;
            if(isActive == false)
                return;

            this._isPatroling = !this._isPatroling;
            this.UpdateUI();
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
            var isActive = (bool)this.patrolFileBrowseButton.Tag;
            if(isActive == false)
                return;

            var patrolform = new Fire_Detector.Dialog.PatrolDialog();
            patrolform.ShowDialog();
        }

        private void recordFileSettingButton_Click(object sender, EventArgs e)
        {
            var isActive = (bool)this.recordFileSettingButton.Tag;
            if(isActive == false)
                return;

            var patrolform = new Fire_Detector.Dialog.RecordDialog();
            patrolform.ShowDialog();
        }

        private void beginRecordButton_Click(object sender, EventArgs e)
        {
            var isActive = (bool)this.beginRecordButton.Tag;
            if (isActive == false)
                return;

        }

        private void DroneTab_Load(object sender, EventArgs e)
        {
            this.patrolModeSwitch_OnValueChange(this.patrolModeSwitch, EventArgs.Empty);
            this.recordModeSwitch_OnValueChange(this.recordModeSwitch, EventArgs.Empty);
        }
    }
}
