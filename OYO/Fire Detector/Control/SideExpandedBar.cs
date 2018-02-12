using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fire_Detector.Control
{
    public partial class SideExpandedBar : UserControl
    {
        public SideExpandedBar()
        {
            InitializeComponent();
        }

        private void buttonCollapse_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if(mainform == null)
                return;

            this.Visible = false;
            mainform.defaultView.sideCollapsedBar.Visible = true;
        }
    }
}
