using BebopCommandSet;
using Fire_Detector.Dialog;
using oyo;
using ParrotBebop2;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

namespace Fire_Detector.Control.SideTabView
{
    public partial class DroneTab : BaseControl
    {
        public static int WARNING_DRONE_SPEED = 15;

        private OpenCvSharp.Size                    _currentResolution = OpenCvSharp.Size.Zero;
        private oyo.OYORecorder.RecordingStateType  _currentRecordType = oyo.OYORecorder.RecordingStateType.None;


        private string _currentPatrolFileName;
        public string PatrolFileName
        {
            get
            {
                return this._currentPatrolFileName;
            }
            private set
            {
                this._currentPatrolFileName = value;
                this.patrolFileTextBox.Text = (this.PatrolFileName == null || this.PatrolFileName == string.Empty) ? "순찰파일을 선택해주세요." : Path.GetFileNameWithoutExtension(this.PatrolFileName);
            }
        }

        private int _elapsedTime;
        public int ElapsedTime
        {
            get
            {
                return this._elapsedTime;
            }

            private set
            {
                this._elapsedTime = value;

                var time = TimeSpan.FromSeconds(this._elapsedTime);
                this.patrolTime.Text = time.ToString(@"hh\:mm\:ss");
            }
        }

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

        private void synchronizeUI()
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

                this.patrolVersionLabel.Invoke(new MethodInvoker(delegate ()
                {
                    if(this.Root.Patrol.Mode == oyo.OYOPatrol.PatrolMode.Read)
                        this.patrolVersionLabel.Text = "순찰 실행모드";
                    else
                        this.patrolVersionLabel.Text = "순찰 기록모드";
                }));

                var isPatrolRunning = this.Root.Patrol.Enabled;
                this.patrolStartEndButton.Invoke(new MethodInvoker(delegate () 
                {
                    this.patrolStartEndButton.ActiveFillColor = isPatrolRunning ? Color.LightSalmon : Color.Transparent;
                    this.patrolStartEndButton.ActiveForecolor = isPatrolRunning ? Color.White : SystemColors.ControlDarkDark;
                    this.patrolStartEndButton.ActiveLineColor = isPatrolRunning ? Color.Salmon : SystemColors.ControlDarkDark;
                    this.patrolStartEndButton.ButtonText = isPatrolRunning ? "순찰 정지" : "순찰 시작";
                }));

                this.patrolTime.Invoke(new MethodInvoker(delegate ()
                {
                    this.patrolTime.Visible = isPatrolRunning;
                }));

                this.patrolStateLabel.Invoke(new MethodInvoker(delegate ()
                {
                    patrolStateLabel.Visible = isPatrolRunning;
                }));

                this.patrolStateProgressbar.Invoke(new MethodInvoker(delegate ()
                {
                    this.patrolStateProgressbar.Visible = isPatrolRunning;
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

                this.recordFileBrowseButton.Invoke(new MethodInvoker(delegate ()
                {
                    this.recordFileBrowseButton.ActiveFillColor = isRecordActive ? Color.LightSalmon : Color.Transparent;
                    this.recordFileBrowseButton.ActiveForecolor = isRecordActive ? Color.White : SystemColors.ControlDarkDark;
                    this.recordFileBrowseButton.ActiveLineColor = isRecordActive ? Color.Salmon : SystemColors.ControlDarkDark;
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

        public int GetDroneSpeed()
        {
            return (int)(this.droneSpeedSlider.Value * (sbyte.MaxValue / (float)this.droneSpeedSlider.MaximumValue));
        }

        private void ConnectDroneButton_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.mainView.mainConnectionView.droneImageButton_Click(sender, e);
        }

        private void TakeoffSwitch_OnValueChange(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            if(this.takeoffSwitch.Value)
                this.Root.Bebop2.takeoff();
            else
                this.Root.Bebop2.landing();
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

            this.PatrolFileName = null;

            this.patrolFileTextBox.Invoke(new MethodInvoker(delegate ()
            {
                this.patrolFileTextBox.BackColor = this.patrolModeSwitch.Value ? Color.White : Color.Gainsboro;
                this.patrolFileTextBox.Text = this.patrolModeSwitch.Value ? "순찰파일을 선택해주세요." : "순찰 모드를 On 해주세요.";
            }));

            this.patrolFileBrowseButton.Invoke(new MethodInvoker(delegate ()
            {
                this.patrolFileBrowseButton.IdleForecolor = this.patrolModeSwitch.Value ? System.Drawing.Color.Salmon : SystemColors.ControlDarkDark;
                this.patrolFileBrowseButton.IdleLineColor = this.patrolModeSwitch.Value ? System.Drawing.Color.Salmon : SystemColors.ControlDarkDark;
            }));

            this.patrolVersionSwitch.Invoke(new MethodInvoker(delegate ()
            {
                this.patrolVersionSwitch.Visible = patrolModeSwitch.Value;
                this.patrolVersionLabel.Visible = patrolModeSwitch.Value;
            }));


            if (this.patrolModeSwitch.Value)
            {
                var message = "녹화모드와 같이 사용할 수 없습니다.";
                var messageform = new Fire_Detector.Dialog.MessageDialog(message, SystemColors.Control);
                messageform.ShowDialog(this.Root);
            }
            else
            {
                this.Root.Patrol.Stop();
                this.ElapsedTime = 0;
            }

            this.synchronizeUI();
        }

        private void RecordModeSwitch_OnValueChange(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.synchronizeUI();

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
            try
            {
                if (this.Root == null)
                    return;

                if(this.patrolModeSwitch.Value == false)
                    return;

                if(this.PatrolFileName == null)
                    throw new Exception("순찰 파일명을 설정하지 않았습니다.");

                var isActive = this.patrolModeSwitch.Value;
                if (isActive == false)
                    return;

                if (this.Root.Patrol.Enabled)
                {
                    if (this.Root.Patrol.Mode == oyo.OYOPatrol.PatrolMode.Read)
                        this.Root.Patrol.Reader.Stop();
                    else
                        this.Root.Patrol.Writer.Stop();

                    this.patrolWriteTimer.Stop();
                    this.ElapsedTime = 0;
                }
                else
                {
                    if (this.Root.Patrol.Mode == oyo.OYOPatrol.PatrolMode.Read)
                        this.Root.Patrol.Reader.Start(this.PatrolFileName);
                    else
                        this.Root.Patrol.Writer.Start(this.PatrolFileName);

                    this.patrolWriteTimer.Start();
                }

                this.synchronizeUI();
            }
            catch (Exception exc)
            {
                var dialog = new Dialog.MessageDialog(exc.Message);
                dialog.ShowDialog(this);
            }
        }

        private void BeginRecordButton_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            try
            {
                if(this.recordModeSwitch.Value == false)
                    return;

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

            var isActive = this.patrolModeSwitch.Value;
            if(isActive == false)
                return;

            if (this.Root.Patrol.Mode == oyo.OYOPatrol.PatrolMode.Read)
            {
                var patrolform = new PatrolDialog();
                if(patrolform.ShowDialog() == DialogResult.Cancel)
                    return;

                this.PatrolFileName = patrolform.FileName.Clone() as string;
            }
            else
            {
                var patrolform = new PatrolPathDialog();
                if(patrolform.ShowDialog(this.Root) != DialogResult.OK)
                    return;

                this.PatrolFileName = patrolform.FileName.Clone() as string;
            }
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
                this.synchronizeUI();
        }

        public void updatePcmdUI(Pcmd pcmd)
        {
            if(this.Root == null)
                return;

            try
            {
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
            catch(Exception)
            { }
        }

        public void Receiver_OnConnectionChanged(oyo.OYOReceiver receiver)
        {
            try
            {
                this.recordModeSwitch.Invoke(new MethodInvoker(delegate ()
                {
                    if (receiver.Connected == false)
                        this.recordModeSwitch.Value = false;

                    this.recordModeSwitch.Enabled = receiver.Connected;
                }));
            }
            catch (Exception)
            { }
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
            if(this.recordModeSwitch.Value == false)
                return;

            var dialog              = new SaveFileDialog();
            dialog.Filter           = string.Format("Video File | *.{0}", oyo.OYORecorder.DEFAULT_EXTENSION);
            if (dialog.ShowDialog() == DialogResult.OK)
                this.recordFileNameTextBox.Text = dialog.FileName;
        }

        private void patrolVersionSwitch_OnValueChange(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            if(this.Root.Patrol.Mode == oyo.OYOPatrol.PatrolMode.Read)
                this.Root.Patrol.Mode = oyo.OYOPatrol.PatrolMode.Write;
            else
                this.Root.Patrol.Mode = oyo.OYOPatrol.PatrolMode.Read;

            this.PatrolFileName = null;
            this.ElapsedTime = 0;

            this.synchronizeUI();
        }

        private void patrolWriteTimer_Tick(object sender, EventArgs e)
        {
            this.ElapsedTime += 1;
        }

        public void Recorder_OnIncreasedTime(OYORecorder.RecordingStateType type, int count, int seconds)
        {
            this.recordTime.Invoke(new MethodInvoker(delegate ()
            {
                var time = TimeSpan.FromSeconds(seconds);
                this.recordTime.Text = time.ToString(@"hh\:mm\:ss");
            }));
        }

        private async void get()
        {
            try
            {
                var client = new HttpClient();
                var form = new MultipartFormDataContent();

                form.Add(new StringContent("0"), "offset");
                form.Add(new StringContent("3"), "count");
                var response = await client.PostAsync("http://localhost:9997/get", form);

                response.EnsureSuccessStatusCode();
                client.Dispose();
                string sd = response.Content.ReadAsStringAsync().Result;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}