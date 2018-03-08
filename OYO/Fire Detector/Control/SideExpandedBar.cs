using Fire_Detector.Control.SideTabView;
using System.Windows.Forms;

namespace Fire_Detector.Control
{
    public partial class SideExpandedBar : BaseControl
    {
        public SideExpandedBar()
        {
            InitializeComponent();
        }

        public void SetActiveTab(BaseControl customTab)
        {
            foreach(var control in this.Controls)
            {
                var tab = control as BaseControl;
                if(tab == null)
                    continue;

                tab.Visible = (tab == customTab);
            }

            this.buttonCollapse.Text = customTab.Tag as string;
        }

        private void buttonCollapse_Click(object sender, System.EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.defaultView.sideExpandedBar.Visible = false;
        }
    }
}
