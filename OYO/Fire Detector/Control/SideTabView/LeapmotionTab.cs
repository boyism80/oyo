﻿using Fire_Detector.Source.Extension;
using System;
using System.Windows.Forms;

namespace Fire_Detector.Control.SideTabView
{
    public partial class LeapmotionTab : BaseControl
    {
        public LeapmotionTab()
        {
            InitializeComponent();
        }

        private void leapmotionButton_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.defaultView.sideExpandedBar.Visible = false;
            this.Root.defaultView.sideCollapsedBar.Visible = true;
        }

        private void connectLeapmotionButton_Click(object sender, EventArgs e)
        {
            if (connectLeapmotionProgressbar.animated == true)
            {
                connectLeapmotionProgressbar.animated = false;
                connectLeapmotionProgressbar.Value = 0;
            }
            else
            {
                connectLeapmotionProgressbar.animated = true;
                connectLeapmotionProgressbar.Value = 15;
            }
        }

        public void LeapController_FrameReady(object sender, Leap.FrameEventArgs e)
        {
            try
            {
                var hand = e.frame.RightHand();
                if(hand != null)
                {
                    // move forward, backward
                    var direction = (hand.PalmPosition - Leap.Vector.Zero).Normalized;
                    var angle_forward = direction.AngleTo(Leap.Vector.Up) * (180 / Math.PI);
                    var cross_forward = direction.Cross(Leap.Vector.Up);
                    this.leapPitchLabel.Text    = (15 + angle_forward * (cross_forward.x > 0 ? 1 : -1)).ToString("0.00");
                    this.leapYawLabel.Text      = cross_forward.y.ToString("0.00");
                    this.leapRollLabel.Text     = cross_forward.z.ToString("0.00");
                }

                var handLeft = e.frame.LeftHand();
                if(handLeft != null)
                { }

                var isDetectedLeft = (handLeft != null);
                var isDetectedRight = (hand != null);

                this.handLeftDetectionLabel.Invoke(new MethodInvoker(delegate ()
                {
                    this.handLeftDetectionLabel.Text = isDetectedLeft ? "인식중입니다." : "인식되지 않은 상태입니다.";
                }));

                this.handLeftDetectionProgressbar.Invoke(new MethodInvoker(delegate ()
                {
                    this.handLeftDetectionProgressbar.Value = isDetectedLeft ? 15 : 0;
                    this.handLeftDetectionProgressbar.animated = isDetectedLeft;
                }));

                this.handRightDetectionLabel.Invoke(new MethodInvoker(delegate ()
                {
                    this.handRightDetectionLabel.Text = isDetectedRight ? "인식중입니다." : "인식되지 않은 상태입니다.";
                }));

                this.handRightDetectionProgressbar.Invoke(new MethodInvoker(delegate ()
                {
                    this.handRightDetectionProgressbar.Value = isDetectedRight ? 15 : 0;
                    this.handRightDetectionProgressbar.animated = isDetectedRight;
                }));
            }
            catch(Exception)
            { }
        }

        public void LeapController_Disconnect(object sender, Leap.DeviceEventArgs e)
        {
            try
            {
                this.connectLeapmotionProgressbar.Invoke(new MethodInvoker(delegate ()
                {
                    this.connectLeapmotionProgressbar.animated = false;
                    this.connectLeapmotionProgressbar.Value = 0;
                }));

                this.leapmotionConnectionLabel.Invoke(new MethodInvoker(delegate ()
                {
                    this.leapmotionConnectionLabel.Text = "립모션과 연결되어 있지 않습니다.";
                }));
            }
            catch(Exception)
            { }
        }

        public void LeapController_Device(object sender, Leap.DeviceEventArgs e)
        {
            try
            {
                if(this.Root == null)
                    return;

                if(this.Root.LeapController.IsConnected == false)
                    return;

                this.connectLeapmotionProgressbar.Invoke(new MethodInvoker(delegate ()
                {
                    this.connectLeapmotionProgressbar.animated = true;
                    this.connectLeapmotionProgressbar.Value = 15;
                }));

                this.leapmotionConnectionLabel.Invoke(new MethodInvoker(delegate ()
                {
                    this.leapmotionConnectionLabel.Text = "립모션과 연결되어 있습니다.";
                }));
            }
            catch(Exception)
            { }
        }

        private void LeapmotionTab_Load(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.LeapController_Device(this.Root.LeapController, new Leap.DeviceEventArgs(this.Root.LeapController.Devices.ActiveDevice));
        }
    }
}
