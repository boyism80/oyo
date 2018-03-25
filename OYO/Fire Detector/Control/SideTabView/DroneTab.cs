using BebopCommandSet;
using Fire_Detector.Source.Extension;
using ParrotBebop2;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Fire_Detector.Control.SideTabView
{
    public partial class DroneTab : BaseControl
    {
        public static int WARNING_DRONE_SPEED = 15;

        private OpenCvSharp.Size                    _currentResolution = OpenCvSharp.Size.Zero;
        private oyo.OYORecorder.RecordingStateType  _currentRecordType = oyo.OYORecorder.RecordingStateType.None;

        public bool ShowDetectionBoxes { get; private set; }
        public bool ShowGmap { get; private set; }

        public DroneTab()
        {
            InitializeComponent();
            if (this.Root == null)
                return;

            //0302지승추가
            if (this.Root.Bebop2.Connected)
                enablePanel(true);
            else
                enablePanel(false);
        }

        private void enablePanel(bool isEnable)
        {
            takeoffSwitch.Enabled = isEnable;
            droneSpeedSlider.Enabled = isEnable;
            patrolModeSwitch.Enabled = isEnable;
            recordModeSwitch.Enabled = isEnable;
        }


        private void update()
        {
            if(this.Root == null)
                return;

            try
            {
                var isPatrolActive = this.patrolModeSwitch.Value;
                this.recordModeSwitch.Invoke(new MethodInvoker(delegate () {
                    this.recordModeSwitch.Enabled = !isPatrolActive && this.Root.Receiver.Connected;
                }));

                this.patrolModeLabel.Invoke(new MethodInvoker(delegate ()
                {
                    this.patrolModeLabel.Text = isPatrolActive ? "On" : "Off";
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
                    patrolStateLabel.Visible = isPatrolActive;
                    patrolStateProgressbar.Visible = isPatrolActive;
                    patrolStartEndButton.ButtonText = isPatrolActive ? "순찰 정지" : "순찰 시작";
                }));


                var isRecordActive = this.recordModeSwitch.Value;
                this.patrolModeSwitch.Invoke(new MethodInvoker(delegate ()
                {
                    this.patrolModeSwitch.Enabled = !isRecordActive;
                }));

                this.recordModeLabel.Invoke(new MethodInvoker(delegate ()
                {
                    this.recordModeLabel.Text = isRecordActive ? "On" : "Off";
                }));

                this.recordFileNameTextBox.Invoke(new MethodInvoker(delegate ()
                {
                    this.recordFileNameTextBox.Enabled = isRecordActive;
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

        private void ConnectDroneButton_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            if(this.Root.Bebop2.Connected)
                this.Root.Bebop2.Disconnect();
            else
                this.Root.Bebop2.Connect();

            this.update();
        }

        private void TakeoffSwitch_OnValueChange(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            if(this.takeoffSwitch.Value)
                this.Root.Bebop2.takeoff();
            else
                this.Root.Bebop2.landing();

            //if (takeoffSwitch.Value == true)
            //{
            //    detectionStateLabel.Text = "비행중";
            //    droneFlightProgressbar.Value = 30;
            //    droneFlightProgressbar.animated = true;
            //    droneFlightProgressbar.Visible = true;

            //}
            //else
            //{
            //    detectionStateLabel.Text = "비행정지";
            //    droneFlightProgressbar.Value = 0;
            //    droneFlightProgressbar.animated = false;
            //    droneFlightProgressbar.Visible = false;
            //}
        }

        private void DroneSpeedSlider_ValueChanged(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            droneSpeedLabel.Text = droneSpeedSlider.Value.ToString();

            if (droneSpeedSlider.Value > WARNING_DRONE_SPEED) warningLabel.Visible = true;
            else warningLabel.Visible = false;
        }

        private void PatrolModeSwitch_OnValueChange(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;
            this.update();

            this.patrolFileTextbox.Invoke(new MethodInvoker(delegate ()
            {
                this.patrolFileTextbox.BackColor = this.patrolModeSwitch.Value ? Color.White : Color.Gainsboro;
                this.patrolFileTextbox.Text = this.patrolModeSwitch.Value ? "순찰파일을 선택해주세요." : "순찰 모드를 On 해주세요.";

            }));

            this.patrolFileBrowseButton.Invoke(new MethodInvoker(delegate ()
            {
                this.patrolFileBrowseButton.IdleForecolor = this.patrolModeSwitch.Value ? System.Drawing.Color.Salmon : SystemColors.ControlDarkDark;
                this.patrolFileBrowseButton.IdleLineColor = this.patrolModeSwitch.Value ? System.Drawing.Color.Salmon : SystemColors.ControlDarkDark;
            }));

            if (this.patrolModeSwitch.Value) {
                var message = "녹화모드와 같이 사용할 수 없습니다.";
                var messageform = new Fire_Detector.Dialog.MessageDialog(message, SystemColors.Control);
                messageform.ShowDialog(this.Root);
            }
        }

        private void RecordModeSwitch_OnValueChange(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.update();

            this.recordFileNameTextBox.Invoke(new MethodInvoker(delegate ()
            {
                this.recordFileNameTextBox.BackColor = this.recordModeSwitch.Value ? Color.White : Color.Gainsboro;
                this.recordFileNameTextBox.Text = this.recordModeSwitch.Value ? "파일경로를 선택해주세요." : "녹화 모드를 On 해주세요.";

            }));

            this.recordFileBrowseButton.Invoke(new MethodInvoker(delegate ()
            {
                this.recordFileBrowseButton.IdleForecolor = this.recordModeSwitch.Value ? System.Drawing.Color.Salmon : SystemColors.ControlDarkDark;
                this.recordFileBrowseButton.IdleLineColor = this.recordModeSwitch.Value ? System.Drawing.Color.Salmon : SystemColors.ControlDarkDark;
            }));

            if (this.recordModeSwitch.Value)
            {
                var message             = "순찰모드와 같이 사용할 수 없습니다.";
                var messageform         = new Fire_Detector.Dialog.MessageDialog(message, SystemColors.ControlLightLight);
                messageform.ShowDialog(this.Root);

                this.recordFileSettingButton.Visible = true;
            }
            else
            {
                this.recordFileSettingButton.Invoke(new MethodInvoker(delegate ()
                {
                    this.recordFileSettingButton.Visible    = false;
                }));
                this.recordStateLabel.Invoke(new MethodInvoker(delegate ()
                {
                    this.recordStateLabel.Visible           = false;
                }));

                this.recordStateProgressbar.Invoke(new MethodInvoker(delegate ()
                {
                    this.recordStateProgressbar.Visible     = false;
                }));

                this.recordTime.Invoke(new MethodInvoker(delegate ()
                {
                    this.recordTime.Visible                 = false;
                }));
            }
        }

        private void PatrolStartEndButton_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            var isActive = (bool)this.patrolStartEndButton.Tag;
            if(isActive == false)
                return;

            this.update();
        }

        private void BeginRecordButton_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            try
            {
                if (this.Root.Recorder.IsRecording(this._currentRecordType))
                {
                    this.Root.Recorder.Stop(this._currentRecordType);
                    this.recordTime.Visible                 = false;
                    this.recordStateLabel.Visible           = false;
                    this.recordStateProgressbar.Visible     = false;
                    this.beginRecordButton.ButtonText       = "녹화 시작";
                }
                else
                {
                    if (this._currentRecordType == oyo.OYORecorder.RecordingStateType.None)
                        throw new Exception("녹화 설정을 먼저 한 뒤에 녹화를 시작하세요.");

                    var directoryName = Path.GetDirectoryName(this.recordFileNameTextBox.Text);
                    if(Directory.Exists(directoryName) == false)
                        throw new Exception("올바른 경로가 아닙니다.");

                    var success = this.Root.Recorder.Record(this._currentRecordType, this.recordFileNameTextBox.Text, this._currentResolution, 11);
                    if(success == false)
                        throw new Exception("녹화를 시작할 수 없습니다. 호환성을 확인하세요.");

                    this.recordTime.Visible                 = true;
                    this.recordStateLabel.Visible           = true;
                    this.recordStateProgressbar.Visible     = true;
                    this.beginRecordButton.ButtonText       = "녹화 정지";
                }
            }
            catch (Exception exc)
            {
                var dialog = new Dialog.MessageDialog(exc.Message);
                dialog.ShowDialog(this);
            }
        }

        private void PatrolFileBrowseButton_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            var isActive = (bool)this.patrolFileBrowseButton.Tag;
            if(isActive == false)
                return;

            var patrolform = new Fire_Detector.Dialog.PatrolDialog();
            patrolform.ShowDialog();
        }

        private void RecordFileSettingButton_Click(object sender, EventArgs e)
        {
            var isActive = (bool)this.recordFileSettingButton.Tag;
            if(isActive == false)
                return;

            if(this.Root.Recorder.IsRecording(this._currentRecordType))
                return;

            var dialog = new Fire_Detector.Dialog.RecordDialog();
            if(dialog.ShowDialog() != DialogResult.OK)
                return;

            this._currentRecordType             = dialog.RecordingType;
            this._currentResolution             = dialog.Resolution;
            this.ShowDetectionBoxes             = dialog.ShowDetectionBoxes;
            this.ShowGmap                       = dialog.ShowGmap;
        }

        private void DroneTab_Load(object sender, EventArgs e)
        {
            this.PatrolModeSwitch_OnValueChange(this.patrolModeSwitch, EventArgs.Empty);
            this.RecordModeSwitch_OnValueChange(this.recordModeSwitch, EventArgs.Empty);
        }

        private void DroneTab_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible)
                this.update();
        }

        public void updatePcmdUI(Pcmd pcmd)
        {
            if(this.Root == null)
                return;

            //if(this.Root.Bebop2.Connected == false)
            //    return;

            this.bunifuImageButton5.Invoke(new MethodInvoker(delegate ()
            {
                this.bunifuImageButton5.BackColor = pcmd.pitch > 0 ? Color.Salmon : Color.DarkGray;
            }));


            this.bunifuImageButton6.Invoke(new MethodInvoker(delegate ()
            {
                this.bunifuImageButton6.BackColor = pcmd.pitch < 0 ? Color.Salmon : Color.DarkGray;
            }));

            this.bunifuImageButton7.Invoke(new MethodInvoker(delegate ()
            {
                this.bunifuImageButton7.BackColor = pcmd.roll < 0 ? Color.Salmon : Color.DarkGray;
            }));

            this.bunifuImageButton8.Invoke(new MethodInvoker(delegate ()
            {
                this.bunifuImageButton8.BackColor = pcmd.roll > 0 ? Color.Salmon : Color.DarkGray;
            }));

            this.bunifuImageButton1.Invoke(new MethodInvoker(delegate ()
            {
                this.bunifuImageButton1.BackColor = pcmd.gaz > 0 ? Color.Salmon : Color.DarkGray;
            }));

            this.bunifuImageButton2.Invoke(new MethodInvoker(delegate ()
            {
                this.bunifuImageButton2.BackColor = pcmd.gaz < 0 ? Color.Salmon : Color.DarkGray;
            }));

            this.bunifuImageButton3.Invoke(new MethodInvoker(delegate ()
            {
                this.bunifuImageButton3.BackColor = pcmd.yaw > 0 ? Color.Salmon : Color.DarkGray;
            }));

            this.bunifuImageButton4.Invoke(new MethodInvoker(delegate ()
            {
                this.bunifuImageButton4.BackColor = pcmd.yaw < 0 ? Color.Salmon : Color.DarkGray;
            }));
        }

        public void Receiver_OnConnectionChanged(oyo.OYOReceiver receiver)
        {
            this.recordModeSwitch.Invoke(new MethodInvoker(delegate ()
            {
                if(receiver.Connected == false)
                    this.recordModeSwitch.Value = false;

                this.recordModeSwitch.Enabled = receiver.Connected;
            }));
        }

        public void Bebop_OnConnectionChanged(Bebop2 bebop)
        {
            this.connectDroneProgressbar.Invoke(new MethodInvoker(delegate ()
            {
                connectDroneProgressbar.animated = bebop.Connected;
                connectDroneProgressbar.Value = bebop.Connected ? 15 : 0;
            }));

            this.connectionLabel.Invoke(new MethodInvoker(delegate ()
            {
                this.connectionLabel.Text = bebop.Connected ? "드론과 연결되었습니다." : "드론과 연결되지 않았습니다.";
            }));

            this.takeoffSwitch.Invoke(new MethodInvoker(delegate ()
            {
                this.takeoffSwitch.Enabled = bebop.Connected;
            }));
        }

        private void recordFileBrowseButton_Click(object sender, EventArgs e)
        {
            var dialog              = new SaveFileDialog();
            dialog.Filter           = string.Format("Video File | *.{0}", oyo.OYORecorder.DEFAULT_EXTENSION);
            if (dialog.ShowDialog() == DialogResult.OK)
                this.recordFileNameTextBox.Text = dialog.FileName;
        }
    }
}
