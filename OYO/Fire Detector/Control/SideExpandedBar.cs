using Fire_Detector.Control.SideTabView;
using System.Windows.Forms;

namespace Fire_Detector.Control
{
    public partial class SideExpandedBar : UserControl
    {
        public SideExpandedBar()
        {
            InitializeComponent();
        }

        public void SetActiveTab(BaseTabView customTab)
        {
            foreach(var control in this.Controls)
            {
                var tab = control as BaseTabView;
                if(tab == null)
                    continue;

                tab.Visible = tab == customTab;
            }
        }
    }
}
