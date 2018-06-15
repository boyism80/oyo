using Bunifu.Framework.UI;
using Fire_Detector.Control.SideTabView;
using Fire_Detector.Dialog;
using Fire_Detector.Source.Extension;
using oyo;
using ParrotBebop2;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fire_Detector.Control
{
    public partial class MainConnectionView : BaseControl
    {
        private Panel[]         iconPanels;
        private BunifuCircleProgressbar[] progressbars;

        public MainConnectionView()
        {
            InitializeComponent();

            this.iconPanels                         = new Panel[] { this.dronePanel, this.raspCamPanel, this.leapmotionPanel };
            this.progressbars                       = new BunifuCircleProgressbar[] { this.droneProgressbar, this.raspCamProgressbar, this.leapmotionProgressbar };
        }

        public void OnScreenStateChanged(System.Drawing.Size size, bool isMaximize)
        {
            this.bottomPanel.Visible                = isMaximize;
            this.connectionIconsTablePanel.Padding  = isMaximize ? new Padding((int)(size.Width * 0.003f), 0, (int)(size.Width * 0.003f), 0) : new Padding(0, 0, 0, 0);

            foreach(var panel in this.iconPanels)
            {
                var left                            = (panel.Tag as Panel[])[0];
                var right                           = (panel.Tag as Panel[])[1];

                left.Dock                           = isMaximize ? DockStyle.Left : DockStyle.Fill;

                var progressbar                     = left.Tag as Bunifu.Framework.UI.BunifuCircleProgressbar;
                progressbar.Size                    = new System.Drawing.Size((int)(left.Width * 0.6f), (int)(left.Width * 0.6f));
                progressbar.Location                = new System.Drawing.Point((left.Width - progressbar.Width) / 2, progressbar.Location.Y);

                var icon                            = progressbar.Tag as Bunifu.Framework.UI.BunifuImageButton;
                icon.Width                          = icon.Height = (int)(left.Width * 0.32f);
                icon.Location                       = new System.Drawing.Point(progressbar.Location.X + (progressbar.Width - icon.Width) / 2,
                                                                               progressbar.Location.Y + (progressbar.Height - icon.Height) / 2);

                var label                           = icon.Tag as Bunifu.Framework.UI.BunifuCustomLabel;
                label.Font                          = new Font(label.Font.FontFamily, (18.0f / 335.0f) * left.Width, label.Font.Style);

                right.Visible = isMaximize;
            }
        }

        public void Receiver_OnConnectionChanged(OYOReceiver receiver)
        {
            try
            {
                this.SetProgressbarState(this.raspCamProgressbar, receiver.Connected);

                this.raspCamProgressbar.Invoke(new MethodInvoker(delegate ()
                {
                    this.raspCamProgressbar.Value               = receiver.Connected ? 15 : 0;
                    this.raspCamProgressbar.ProgressBackColor   = receiver.Connected ? Color.Gainsboro : Color.FromArgb(255, 200, 150);
                }));

                this.cameraConnectionLabel.Invoke(new MethodInvoker(delegate ()
                {
                    this.cameraConnectionLabel.Text             = receiver.Connected ? "연결됨" : "연결 안됨";
                }));

                this.cameraStatePanel.Invoke(new MethodInvoker(delegate ()
                {
                    this.cameraStatePanel.Visible               = receiver.Connected;
                }));
            }
            catch (Exception)
            { }
        }

        private void MainConnectionView_Load(object sender, System.EventArgs e)
        {
            if(this.Root == null)
                return;

            this.LeapController_Device(this.Root.LeapController, new Leap.DeviceEventArgs(this.Root.LeapController.Devices.ActiveDevice));
        }

        public void raspCamImageButton_Click(object sender, System.EventArgs e)
        {
            if(this.Root == null)
                return;

            if (this.Root.Receiver.Connected)
                this.Root.Receiver.Exit();
            else
                this.Root.Receiver.Connect();
        }

        public void droneImageButton_Click(object sender, System.EventArgs e)
        {
            if(this.Root == null)
                return;

            if(this.Root.Bebop2.Connected)
                this.Root.Bebop2.Disconnect();
            else
                this.Root.Bebop2.Connect();
        }

        public void leapMotionImageButton_Click(object sender, System.EventArgs e)
        {
            if(this.Root == null)
                return;

            if(this.Root.LeapController.Enabled == false)
            {
                this.Root.LeapController.Enabled = true;
                if(this.Root.LeapController.Enabled == false)
                {
                    var dialog = new MessageDialog("립모션이 연결되어 있지 않습니다.");
                    dialog.ShowDialog(this.Root);
                }
            }
            else
            {
                this.Root.LeapController.Enabled = false;
            }
        }

        public void Bebop_OnConnectionChanged(Bebop2 bebop)
        {
            try
            {
                this.SetProgressbarState(this.droneProgressbar, this.Root.Bebop2.Connected);

                this.droneProgressbar.Invoke(new MethodInvoker(delegate ()
                {
                    this.droneProgressbar.Value             = this.Root.Bebop2.Connected ? 15 : 0;
                    this.droneProgressbar.ProgressBackColor = this.Root.Bebop2.Connected ? Color.Gainsboro : Color.FromArgb(255, 200, 150);
                }));
            
                this.droneStatePanel.Invoke(new MethodInvoker(delegate ()
                {
                    this.droneConnectionLabel.Text          = this.Root.Bebop2.Connected ? "연결됨" : "연결 안 됨";
                    this.droneStatePanel.Visible            = this.Root.Bebop2.Connected;
                }));
            }
            catch(Exception)
            { }
        }

        public void LeapController_FrameReady(object sender, Leap.FrameEventArgs e)
        {
            try
            {
                var frame                               = e.frame;
                var isLeftActive                        = (frame.LeftHand() != null);
                var isRightActive                       = (frame.RightHand() != null);
                this.leapLeftDetectingLabel.Invoke(new MethodInvoker(delegate ()
                {
                    this.leapLeftDetectingLabel.Text    = isLeftActive ? "왼손 인식중" : "왼손 인식 안됨";
                }));

                this.leapRightDetectingLabel.Invoke(new MethodInvoker(delegate ()
                {
                    this.leapRightDetectingLabel.Text   = isRightActive ? "오른손 인식중" : "오른손 인식 안됨";
                }));
            }
            catch(Exception)
            {

            }
        }

        public void LeapController_DeviceLost(object sender, Leap.DeviceEventArgs e)
        {
            if(this.Root == null)
                return;

            this.SetProgressbarState(this.leapmotionProgressbar, true);

            this.leapmotionProgressbar.Invoke(new MethodInvoker(delegate ()
            {
                this.leapmotionProgressbar.Invoke(new MethodInvoker(delegate ()
                {
                    this.leapmotionProgressbar.Value               = 0;
                    this.leapmotionProgressbar.ProgressBackColor   = Color.FromArgb(255, 200, 150);
                }));
            }));

            this.leapmotionStatePanel.Invoke(new MethodInvoker(delegate ()
            {
                this.leapmotionStatePanel.Visible = false;
            }));

            this.leapmotionConnectionLabel.Invoke(new MethodInvoker(delegate ()
            {
                this.leapmotionConnectionLabel.Text             = "연결 안 됨";
            }));
        }

        public void LeapController_Device(object sender, Leap.DeviceEventArgs e)
        {
            if(this.Root == null)
                return;

            if(this.Root.LeapController.Enabled == false)
                return;

            this.SetProgressbarState(this.leapmotionProgressbar, true);

            this.leapmotionProgressbar.Invoke(new MethodInvoker(delegate ()
            {
                this.leapmotionProgressbar.Value               = 15;
                this.leapmotionProgressbar.ProgressBackColor   = Color.Gainsboro;
            }));

            this.leapmotionStatePanel.Invoke(new MethodInvoker(delegate ()
            {
                this.leapmotionStatePanel.Visible = true;
            }));

            this.leapmotionConnectionLabel.Invoke(new MethodInvoker(delegate ()
            {
                this.leapmotionConnectionLabel.Text             = "연결됨";
            }));
        }

        public void SetProgressbarState(Bunifu.Framework.UI.BunifuCircleProgressbar target, bool value)
        {
            foreach (var progressbar in this.progressbars)
            {
                if(target != progressbar && value == false)
                    continue;

                progressbar.Invoke(new MethodInvoker(delegate ()
                {
                    var old = progressbar.animated;
                    progressbar.animated = false;

                    if (progressbar == target)
                        progressbar.animated = value;
                    else
                        progressbar.animated = old;
                }));
            }
        }

        public void Overlayer_OnReceiveAddressEvent(string name, string address)
        {
            this.addressLabel.Invoke(new MethodInvoker(delegate ()
            {
                this.addressLabel.Text = address;
            }));
        }

        public void Bebop2_OnPositionChanged(Bebop2 bebop2, double lat, double lon, double alt)
        {
            this.latLabel.Invoke(new MethodInvoker(delegate ()
            {
                this.latLabel.Text = string.Format("위도 {0}", lat);
            }));
            
            this.lonLabel.Invoke(new MethodInvoker(delegate ()
            {
                this.lonLabel.Text = string.Format("경도 {0}", lon);
            }));
        }
    }
}
