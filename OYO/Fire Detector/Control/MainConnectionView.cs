﻿using Fire_Detector.Control.SideTabView;
using Fire_Detector.Source;
using System.Drawing;
using System.Windows.Forms;
using OpenCvSharp;
using System;

namespace Fire_Detector.Control
{
    public partial class MainConnectionView : BaseTabView
    {
        private Panel[]         iconPanels;

        public MainConnectionView()
        {
            InitializeComponent();

            this.iconPanels                 = new Panel[] { this.dronePanel, this.raspCamPanel, this.leapmotionPanel };
        }

        private void UpdateUI()
        {
            if(this.Root == null)
                return;

            try
            {
                this.raspCamProgressbar.Invoke(new MethodInvoker(delegate ()
                {
                    this.raspCamProgressbar.Value               = this.Root.Receiver.Connected ? 15 : 0;
                    this.raspCamProgressbar.animated            = this.Root.Receiver.Connected;
                    this.raspCamProgressbar.ProgressBackColor   = this.Root.Receiver.Connected ? Color.Gainsboro : Color.FromArgb(255, 200, 150);
                }));

                this.droneProgressbar.Invoke(new MethodInvoker(delegate ()
                {
                    this.droneProgressbar.Value               = this.Root.Bebop.Connected ? 15 : 0;
                    this.droneProgressbar.animated            = this.Root.Bebop.Connected;
                    this.droneProgressbar.ProgressBackColor   = this.Root.Bebop.Connected ? Color.Gainsboro : Color.FromArgb(255, 200, 150);
                }));

                this.bunifuCustomLabel17.Invoke(new MethodInvoker(delegate ()
                {
                    this.bunifuCustomLabel17.Text             = this.Root.Receiver.Connected ? "연결됨" : "연결 안됨";
                    this.bunifuCustomLabel15.Visible          = this.Root.Receiver.Connected;
                    this.bunifuCustomLabel16.Visible          = this.Root.Receiver.Connected;
                }));
            }
            catch(Exception)
            {}
        }

        public void OnScreenStateChanged(System.Drawing.Size size, bool isMaximize)
        {
            this.bottomPanel.Visible                = isMaximize;
            this.connectionIconsTablePanel.Padding  = isMaximize ? new Padding((int)(size.Width * 0.003f), 0, (int)(size.Width * 0.003f), 0) : new Padding(0, 0, 0, 0);

            foreach(var panel in this.iconPanels)
            {
                var left                    = (panel.Tag as Panel[])[0];
                var right                   = (panel.Tag as Panel[])[1];

                left.Dock                   = isMaximize ? DockStyle.Left : DockStyle.Fill;

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

        public void OnConnectionChanged(bool connected)
        {
            this.UpdateUI();
        }

        public void OnUpdated(UpdatedDataBuffer buffer, Mat updatedFrame, bool invalidated)
        {
        }

        private void MainConnectionView_Load(object sender, System.EventArgs e)
        {
            if(this.Root == null)
                return;
        }

        private void raspCamImageButton_Click(object sender, System.EventArgs e)
        {
            if(this.Root == null)
                return;

            if (this.Root.Receiver.Connected)
                this.Root.Receiver.Exit();
            else
                this.Root.Receiver.Connect();
        }

        private void droneImageButton_Click(object sender, System.EventArgs e)
        {
            // 드론 서버랑 연결
            if(this.Root == null)
                return;

            if(this.Root.Bebop.Connected)
                this.Root.Bebop.Disconnect();
            else
                this.Root.Bebop.Connect();

            this.UpdateUI();
        }

        private void leapMotionImageButton_Click(object sender, System.EventArgs e)
        {
            // 립모션이랑 연결
        }

        private void bunifuCustomLabel9_Click(object sender, EventArgs e)
        {

        }

        private void MainConnectionView_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible)
                this.UpdateUI();
        }
    }
}
