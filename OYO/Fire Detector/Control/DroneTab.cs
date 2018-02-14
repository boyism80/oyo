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

            if (droneSpeedSlider.Value > 15) warningLabel.Visible = true;
            else warningLabel.Visible = false;
        }

        private void patrolModeSwitch_OnValueChange(object sender, EventArgs e)
        {
            if(recordModeSwitch.Value ==true)
            {
                //대화상자 생성 (녹화모드에서는 사용할 수 없습니다.)
                patrolModeSwitch.Value = false;
                return; //프로그램 종료됨. 어떻게해야하죠?ㅇㅅㅇ..112줄도요

            }
            if (patrolModeSwitch.Value == true)
            {
                patrolModeLabel.Text = "On";
                patrolFileBrowseButton.Enabled = true;
                patrolFileTextbox.BackColor = System.Drawing.Color.White;
                patrolFileTextbox.Enabled = true;
                patrolFileTextbox.Text = "순찰 파일을 찾아주세요.";
                patrolFileBrowseButton.IdleLineColor = System.Drawing.Color.Salmon;
                patrolFileBrowseButton.IdleForecolor = System.Drawing.Color.Salmon;
                patrolFileBrowseButton.Enabled = true;
            }
            else
            {
                patrolModeLabel.Text = "Off";
                patrolFileBrowseButton.Enabled = false;
                patrolFileTextbox.BackColor = System.Drawing.Color.Gainsboro;
                patrolFileTextbox.Enabled = false;
                patrolFileTextbox.Text = "순찰 모드를 On 해주세요.";
                patrolFileBrowseButton.IdleLineColor = System.Drawing.SystemColors.ControlDarkDark;
                patrolFileBrowseButton.IdleForecolor = System.Drawing.SystemColors.ControlDarkDark;
                patrolFileBrowseButton.Enabled = false;
            }
                
                
        }

        private void recordModeSwitch_OnValueChange(object sender, EventArgs e)
        {
            if (patrolModeSwitch.Value == true)
            {
                //대화상자 생성 (순찰모드에서는 사용할 수 없습니다.)
                recordModeSwitch.Value = false;
                return;//프로그램 종료됨. 어떻게해야하죠?ㅇㅅㅇ.. 77줄도요

            }

            //visible등 속성 변경내용 추가하기
            if (recordModeSwitch.Value == true)
            {
                recordModeLabel.Text = "On";
                recordFileBrowseButton.Enabled = true;
                recordFileTextbox.BackColor = System.Drawing.Color.White;
                recordFileTextbox.Enabled = true;
                recordFileTextbox.Text = "순찰 파일을 찾아주세요.";
                recordFileBrowseButton.IdleLineColor = System.Drawing.Color.Salmon;
                recordFileBrowseButton.IdleForecolor = System.Drawing.Color.Salmon;
                recordFileBrowseButton.Enabled = true;
            }
            else
            {
                recordModeLabel.Text = "Off";
                recordFileBrowseButton.Enabled = false;
                recordFileTextbox.BackColor = System.Drawing.Color.Gainsboro;
                recordFileTextbox.Enabled = false;
                recordFileTextbox.Text = "순찰 모드를 On 해주세요.";
                recordFileBrowseButton.IdleLineColor = System.Drawing.SystemColors.ControlDarkDark;
                recordFileBrowseButton.IdleForecolor = System.Drawing.SystemColors.ControlDarkDark;
                recordFileBrowseButton.Enabled = false;
            }


        }

        private void patrolStartEndButton_Click(object sender, EventArgs e)
        {
            if(patrolStartEndButton.ButtonText.Equals("순찰 시작"))
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
            if(recordStartEndButton.ButtonText.Equals("녹화 시작"))
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

        }

        private void recordFileBrowseButton_Click(object sender, EventArgs e)
        {

        }

        
    }
}
