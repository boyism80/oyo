using System;
using System.Windows.Forms;

namespace Fire_Detector.Control
{
    public partial class LeapmotionTab : UserControl
    {
        public LeapmotionTab()
        {
            InitializeComponent();
        }

        private void leapmotionButton_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if(mainform == null)
                return;

            mainform.defaultView.sideExpandedBar.Visible = false;
            mainform.defaultView.sideCollapsedBar.Visible = true;
        }
    }
}
