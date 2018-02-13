using System;
using System.Windows.Forms;

namespace Fire_Detector.Control
{
    public partial class SideExpandedBar : UserControl
    {
        public SideExpandedBar()
        {
            InitializeComponent();
        }

        public void SetActiveTab(UserControl customTab)
        {
            foreach(var control in this.Controls)
            {
                var tab = control as UserControl;
                if(tab == null)
                    continue;

                tab.Visible = tab == customTab;
            }
        }

       
    }
}
