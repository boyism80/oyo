using Fire_Detector.Control.SideTabView;
using Fire_Detector.Source;
using System.Drawing;
using System.Windows.Forms;
using OpenCvSharp;
using System;

namespace Fire_Detector.Control
{
    public partial class MainConnectionView : BaseTabView, BunifuForm.MainForm.IStateChangedListener
    {
        private Panel[]         iconPanels;

        public MainConnectionView()
        {
            InitializeComponent();

            this.iconPanels                 = new Panel[] { this.dronePanel, this.raspCamPanel, this.leapmotionPanel };
        }

        public void OnSizeChanged(System.Drawing.Size size, bool isMaximize)
        {
            this.bottomPanel.Visible = isMaximize;
            this.connectionIconsTablePanel.Padding = isMaximize ? new Padding((int)(size.Width * 0.1f), 0, (int)(size.Width * 0.1f), 0) : new Padding(0, 0, 0, 0);

            foreach(var panel in this.iconPanels)
            {
                var left                    = (panel.Tag as Panel[])[0];
                var right                   = (panel.Tag as Panel[])[1];

                left.Dock = isMaximize ? DockStyle.Left : DockStyle.Fill;

                var progressbar             = left.Tag as Bunifu.Framework.UI.BunifuCircleProgressbar;
                progressbar.Size            = new System.Drawing.Size((int)(left.Width * 0.6f), (int)(left.Width * 0.6f));
                progressbar.Location        = new System.Drawing.Point((left.Width - progressbar.Width) / 2, progressbar.Location.Y);

                var icon                    = progressbar.Tag as Bunifu.Framework.UI.BunifuImageButton;
                icon.Width                  = icon.Height = (int)(left.Width * 0.32f);
                icon.Location               = new System.Drawing.Point(progressbar.Location.X + (progressbar.Width - icon.Width) / 2,
                                                         progressbar.Location.Y + (progressbar.Height - icon.Height) / 2);

                var label                   = icon.Tag as Bunifu.Framework.UI.BunifuCustomLabel;
                label.Font                  = new Font(label.Font.FontFamily, (18.0f / 335.0f) * left.Width, label.Font.Style);

                right.Visible = isMaximize;
            }
        }

        public void OnStateChanged(bool connected)
        {
            try
            {
                this.raspCamProgressbar.Invoke(new MethodInvoker(delegate ()
                {
                    this.raspCamProgressbar.Value               = connected ? 15 : 0;
                    this.raspCamProgressbar.animated            = connected;
                    this.raspCamProgressbar.ProgressBackColor   = connected ? Color.Gainsboro : Color.FromArgb(255, 200, 150);
                }));
            }
            catch (Exception)
            {

            }
        }

        public void OnUpdated(UpdatedDataBuffer buffer, Mat updatedFrame, bool invalidated)
        {
        }

        private void MainConnectionView_Load(object sender, System.EventArgs e)
        {
            this.OnSizeChanged(this.Root.Size, false);
        }

        private void raspCamImageButton_Click(object sender, System.EventArgs e)
        {
            if (this.Root.Receiver.Connected)
                this.Root.Receiver.Exit();
            else
                this.Root.Receiver.Connect();
        }

        private void droneImageButton_Click(object sender, System.EventArgs e)
        {
            // 드론 서버랑 연결
        }

        private void leapMotionImageButton_Click(object sender, System.EventArgs e)
        {
            // 립모션이랑 연결
        }

        private void bunifuCustomLabel9_Click(object sender, EventArgs e)
        {

        }
    }
}
