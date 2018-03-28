using Fire_Detector.BunifuForm;
using Fire_Detector.Control.SideTabView;
using System;
using System.Drawing;

namespace Fire_Detector.Control
{
    public partial class SideCollapsedBar : BaseControl
    {
        public SideCollapsedBar()
        {
            InitializeComponent();
        }

        private void droneTabButton_Click(object sender, EventArgs e)
        {
            if (this.Root == null)
                return;

            //this.Visible = false;
            this.Root.defaultView.sideExpandedBar.Visible = true;
            this.Root.defaultView.sideExpandedBar.ActivatedTab = this.Root.defaultView.sideExpandedBar.droneTab;

            this.droneTabButton.BackColor = System.Drawing.Color.White;
            this.paletteTabButton.BackColor = Color.FromArgb(255, 200, 160);
            this.leapmotionTabButton.BackColor = Color.FromArgb(255, 200, 160);
            this.alarmTabButton.BackColor = Color.FromArgb(255, 200, 160);
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            if (this.Root == null)
                return;

            this.Root.defaultView.Visible = false;
            this.Root.mainView.Visible = true;
        }

        private void leapmotionTabButton_Click(object sender, EventArgs e)
        {
            if (this.Root == null)
                return;

            //this.Visible = false;
            this.Root.defaultView.sideExpandedBar.Visible = true;
            this.Root.defaultView.sideExpandedBar.ActivatedTab = this.Root.defaultView.sideExpandedBar.leapmotionTab;

            this.droneTabButton.BackColor = Color.FromArgb(255, 200, 160);
            this.paletteTabButton.BackColor = Color.FromArgb(255, 200, 160);
            this.leapmotionTabButton.BackColor = System.Drawing.Color.White;
            this.alarmTabButton.BackColor = Color.FromArgb(255, 200, 160);
        }

        private void paletteTabButton_Click(object sender, EventArgs e)
        {
            if (this.Root == null)
                return;

            //this.Visible = false;
            this.Root.defaultView.sideExpandedBar.Visible = true;
            this.Root.defaultView.sideExpandedBar.ActivatedTab = this.Root.defaultView.sideExpandedBar.visualizeTab;

            this.droneTabButton.BackColor = Color.FromArgb(255, 200, 160);
            this.paletteTabButton.BackColor = System.Drawing.Color.White;
            this.leapmotionTabButton.BackColor = Color.FromArgb(255, 200, 160);
            this.alarmTabButton.BackColor = Color.FromArgb(255, 200, 160);
        }

        private void alarmTabButton_Click(object sender, EventArgs e)
        {
            if (this.Root == null)
                return;

            // this.Visible = false;
            this.Root.defaultView.sideExpandedBar.Visible = true;
            this.Root.defaultView.sideExpandedBar.ActivatedTab = this.Root.defaultView.sideExpandedBar.detectFireTab;

            this.droneTabButton.BackColor = Color.FromArgb(255, 200, 160);
            this.paletteTabButton.BackColor = Color.FromArgb(255, 200, 160);
            this.leapmotionTabButton.BackColor = Color.FromArgb(255, 200, 160);
            this.alarmTabButton.BackColor = System.Drawing.Color.White;
        }

        private void droneTabButton_MouseHover(object sender, EventArgs e)
        {
            this.droneTabButton.BackColor = Color.FromArgb(230, 180, 150);
        }

        private void droneTabButton_MouseLeave(object sender, EventArgs e)
        {
            if (this.Root == null)
                return;

            var current = this.Root.defaultView.sideExpandedBar.ActivatedTab;
            if (current != this.Root.defaultView.sideExpandedBar.droneTab)
            {
                this.droneTabButton.BackColor = Color.FromArgb(255, 200, 160);
            }
            else
                this.droneTabButton.BackColor = System.Drawing.Color.White;
        }

        private void paletteTabButton_MouseHover(object sender, EventArgs e)
        {
            this.paletteTabButton.BackColor = Color.FromArgb(230, 180, 150);
        }

        private void paletteTabButton_MouseLeave(object sender, EventArgs e)
        {
            if (this.Root == null)
                return;

            var current = this.Root.defaultView.sideExpandedBar.ActivatedTab;
            if (current != this.Root.defaultView.sideExpandedBar.visualizeTab)
            {
                this.paletteTabButton.BackColor = Color.FromArgb(255, 200, 160);
            }
            else
                this.paletteTabButton.BackColor = System.Drawing.Color.White;
        }

        private void leapmotionTabButton_MouseHover(object sender, EventArgs e)
        {
            this.leapmotionTabButton.BackColor = Color.FromArgb(230, 180, 150);
        }

        private void leapmotionTabButton_MouseLeave(object sender, EventArgs e)
        {
            if (this.Root == null)
                return;

            var current = this.Root.defaultView.sideExpandedBar.ActivatedTab;
            if (current != this.Root.defaultView.sideExpandedBar.leapmotionTab)
            {
                this.leapmotionTabButton.BackColor = Color.FromArgb(255, 200, 160);
            }
            else
                this.leapmotionTabButton.BackColor = System.Drawing.Color.White;
        }

        private void alarmTabButton_MouseHover(object sender, EventArgs e)
        {
            this.alarmTabButton.BackColor = Color.FromArgb(230, 180, 150);
        }

        private void alarmTabButton_MouseLeave(object sender, EventArgs e)
        {
            if (this.Root == null)
                return;

            var current = this.Root.defaultView.sideExpandedBar.ActivatedTab;
            if (current != this.Root.defaultView.sideExpandedBar.detectFireTab)
            {
                this.alarmTabButton.BackColor = Color.FromArgb(255, 200, 160);
            }
            else
                this.alarmTabButton.BackColor = System.Drawing.Color.White;
        }

        private void homeButton_MouseHover(object sender, EventArgs e)
        {
            this.homeButton.BackColor = Color.FromArgb(230, 180, 150);
        }

        private void homeButton_MouseLeave(object sender, EventArgs e)
        {
            this.homeButton.BackColor = Color.FromArgb(255, 200, 160);
        }
    }
}