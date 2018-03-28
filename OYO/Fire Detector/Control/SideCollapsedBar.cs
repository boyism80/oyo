using Fire_Detector.BunifuForm;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fire_Detector.Control
{
    public partial class SideCollapsedBar : UserControl
    {
        public SideCollapsedBar()
        {
            InitializeComponent();
        }

        private void droneTabButton_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if(mainform == null)
                return;

            //this.Visible = false;
            mainform.defaultView.sideExpandedBar.Visible = true;
            mainform.defaultView.sideExpandedBar.SetActiveTab(mainform.defaultView.sideExpandedBar.droneTab);
            
            this.droneTabButton.BackColor = System.Drawing.Color.White;
            this.paletteTabButton.BackColor = Color.FromArgb(255, 200, 160);
            this.leapmotionTabButton.BackColor = Color.FromArgb(255, 200, 160);
            this.alarmTabButton.BackColor = Color.FromArgb(255, 200, 160); 
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if(mainform == null)
                return;
            
            mainform.defaultView.Visible = false;
            mainform.mainView.Visible = true;
        }

        private void leapmotionTabButton_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if(mainform == null)
                return;

            //this.Visible = false;
            mainform.defaultView.sideExpandedBar.Visible = true;
            mainform.defaultView.sideExpandedBar.SetActiveTab(mainform.defaultView.sideExpandedBar.leapmotionTab);

            this.droneTabButton.BackColor = Color.FromArgb(255, 200, 160);
            this.paletteTabButton.BackColor = Color.FromArgb(255, 200, 160);
            this.leapmotionTabButton.BackColor = System.Drawing.Color.White;
            this.alarmTabButton.BackColor = Color.FromArgb(255, 200, 160);
        }

        private void paletteTabButton_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if(mainform == null)
                return;

            //this.Visible = false;
            mainform.defaultView.sideExpandedBar.Visible = true;
            mainform.defaultView.sideExpandedBar.SetActiveTab(mainform.defaultView.sideExpandedBar.visualizeTab);

            this.droneTabButton.BackColor = Color.FromArgb(255, 200, 160);
            this.paletteTabButton.BackColor = System.Drawing.Color.White;
            this.leapmotionTabButton.BackColor = Color.FromArgb(255, 200, 160);
            this.alarmTabButton.BackColor = Color.FromArgb(255, 200, 160);
        }

        private void alarmTabButton_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if(mainform == null)
                return;

           // this.Visible = false;
            mainform.defaultView.sideExpandedBar.Visible = true;
            mainform.defaultView.sideExpandedBar.SetActiveTab(mainform.defaultView.sideExpandedBar.detectFireTab);

            this.droneTabButton.BackColor = Color.FromArgb(255, 200, 160);
            this.paletteTabButton.BackColor = Color.FromArgb(255, 200, 160);
            this.leapmotionTabButton.BackColor = Color.FromArgb(255, 200, 160);
            this.alarmTabButton.BackColor = System.Drawing.Color.White;
        }

        private void droneTabButton_MouseHover(object sender, EventArgs e)
        {
            this.droneTabButton.BackColor = System.Drawing.Color.White;
        }

        private void droneTabButton_MouseLeave(object sender, EventArgs e)
        {
            //조건문넣기(getActiveTab이 droneTab이 아닐때
            this.droneTabButton.BackColor = Color.FromArgb(255, 200, 160);
        }

        private void paletteTabButton_MouseHover(object sender, EventArgs e)
        {
            this.paletteTabButton.BackColor = System.Drawing.Color.White;
        }

        private void paletteTabButton_MouseLeave(object sender, EventArgs e)
        {
            this.paletteTabButton.BackColor = Color.FromArgb(255, 200, 160);
        }

        private void leapmotionTabButton_MouseHover(object sender, EventArgs e)
        {
            this.leapmotionTabButton.BackColor = System.Drawing.Color.White;
        }

        private void leapmotionTabButton_MouseLeave(object sender, EventArgs e)
        {
            this.leapmotionTabButton.BackColor = Color.FromArgb(255, 200, 160);
        }

        private void alarmTabButton_MouseHover(object sender, EventArgs e)
        {
            this.alarmTabButton.BackColor = System.Drawing.Color.White;
        }

        private void alarmTabButton_MouseLeave(object sender, EventArgs e)
        {
            this.alarmTabButton.BackColor = Color.FromArgb(255, 200, 160);
        }

        private void homeButton_MouseHover(object sender, EventArgs e)
        {
            this.homeButton.BackColor = System.Drawing.Color.White;
        }

        private void homeButton_MouseLeave(object sender, EventArgs e)
        {
            this.homeButton.BackColor = Color.FromArgb(255, 200, 160);
        }
    }
}
