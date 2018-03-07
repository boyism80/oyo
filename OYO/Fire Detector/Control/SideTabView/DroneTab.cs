﻿using BebopCommandSet;
using ParrotBebop2;
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
            if (this.Root == null) return;

            //0302지승추가
            if (this.Root.Bebop.Connected)
                enablePanel(true);
            else
                enablePanel(false);
            
            ////
        }

        private void enablePanel(bool isEnable)
        {
            takeoffSwitch.Enabled = isEnable;
            droneSpeedSlider.Enabled = isEnable;
            patrolModeSwitch.Enabled = isEnable;
            recordModeSwitch.Enabled = isEnable;
        }

        private void buttonCollapse_Click(object sender, EventArgs e)
        {
            this.Root.defaultView.sideExpandedBar.Visible = false;
            //this.Root.defaultView.sideCollapsedBar.Visible = true;
        }

        private void connectDroneButton_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            if (this.Root.Bebop.Connected)
            {
                this.Root.Bebop.Disconnect();
                enablePanel(false);
            }

            else
            {
                this.Root.Bebop.Connect();
                enablePanel(true);
            }
                

            this.UpdateUI();
        }


        private void takeoffSwitch_OnValueChange(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            if(this.takeoffSwitch.Value)
                this.Root.Bebop.takeoff();
            else
                this.Root.Bebop.landing();

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

        private void droneSpeedSlider_ValueChanged(object sender, EventArgs e)
        {
            droneSpeedLabel.Text = droneSpeedSlider.Value.ToString();

            if (droneSpeedSlider.Value > WARNING_DRONE_SPEED) warningLabel.Visible = true;
            else warningLabel.Visible = false;
        }

        private void UpdateUI()
        {
            if(this.Root == null)
                return;

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

                this.connectDroneProgressbar.Invoke(new MethodInvoker(delegate ()
                {
                    connectDroneProgressbar.animated = this.Root.Bebop.Connected;
                    connectDroneProgressbar.Value = this.Root.Bebop.Connected ? 15 : 0;
                }));

                this.connectionLabel.Invoke(new MethodInvoker(delegate ()
                {
                    this.connectionLabel.Text = this.Root.Bebop.Connected ? "드론과 연결되었습니다." : "드론과 연결되지 않았습니다.";
                }));

                this.takeoffSwitch.Invoke(new MethodInvoker(delegate ()
                {
                    this.takeoffSwitch.Enabled = this.Root.Bebop.Connected;
                }));
            }
            catch(Exception)
            { }
        }

        private void patrolModeSwitch_OnValueChange(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            if(this.patrolModeSwitch.Value == false)
                this._isPatroling = false;

            this.UpdateUI();

            if (this.patrolModeSwitch.Value) {
                var message = "녹화모드와 같이 사용할 수 없습니다.";
                var messageform = new Fire_Detector.Dialog.MessageDialog(message, SystemColors.Control);
                messageform.ShowDialog(this.Root);
            }
        }

        private void recordModeSwitch_OnValueChange(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.UpdateUI();
            if (this.recordModeSwitch.Value)
            {
                var message = "순찰모드와 같이 사용할 수 없습니다.";
                var messageform = new Fire_Detector.Dialog.MessageDialog(message, SystemColors.ControlLightLight);
                messageform.ShowDialog(this.Root);
            }
        }

        private void patrolStartEndButton_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

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

        private void DroneTab_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible)
                this.UpdateUI();
        }

        public void UpdatePcmdUI(Pcmd pcmd)
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

        public void Bebop_OnDisconnected(Bebop2 bebop)
        {
            this.UpdateUI();
        }

        public void Bebop_OnConnected(Bebop2 bebop)
        {
            this.UpdateUI();
        }
    }
}
