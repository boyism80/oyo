using System;
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
        }

        private void paletteTabButton_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if(mainform == null)
                return;

            //this.Visible = false;
            mainform.defaultView.sideExpandedBar.Visible = true;
            mainform.defaultView.sideExpandedBar.SetActiveTab(mainform.defaultView.sideExpandedBar.visualizeTab);
        }

        private void alarmTabButton_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if(mainform == null)
                return;

           // this.Visible = false;
            mainform.defaultView.sideExpandedBar.Visible = true;
            mainform.defaultView.sideExpandedBar.SetActiveTab(mainform.defaultView.sideExpandedBar.detectFireTab);
        }
    }
}
