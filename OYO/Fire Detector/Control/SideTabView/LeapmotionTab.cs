using System;
using System.Windows.Forms;

namespace Fire_Detector.Control.SideTabView
{
    public partial class LeapmotionTab : BaseTabView
    {
        public LeapmotionTab()
        {
            InitializeComponent();
        }

        private void leapmotionButton_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.defaultView.sideExpandedBar.Visible = false;
            this.Root.defaultView.sideCollapsedBar.Visible = true;
        }

        private void connectLeapmotionButton_Click(object sender, EventArgs e)
        {
            if (connectLeapmotionProgressbar.animated == true)
            {
                connectLeapmotionProgressbar.animated = false;
                connectLeapmotionProgressbar.Value = 0;
            }
            else
            {
                connectLeapmotionProgressbar.animated = true;
                connectLeapmotionProgressbar.Value = 15;
            }
        }
    }
}
