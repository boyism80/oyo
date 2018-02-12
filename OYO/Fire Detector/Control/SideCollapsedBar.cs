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

        private void buttonExpand_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if(mainform == null)
                return;

            this.Visible = false;
            mainform.defaultView.sideExpandedBar.Visible = true;
        }
    }
}
