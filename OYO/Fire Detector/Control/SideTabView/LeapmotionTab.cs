using Fire_Detector.Source.Extension;
using System;
using System.Windows.Forms;

namespace Fire_Detector.Control.SideTabView
{
    public partial class LeapmotionTab : BaseControl
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

        public void LeapController_FrameReady(object sender, Leap.FrameEventArgs e)
        {
            var hand = e.frame.RightHand();
            if(hand == null)
                return;

            this.leapPitchLabel.Text    = hand.PalmPosition.x.ToString("0.00");
            this.leapYawLabel.Text      = hand.PalmPosition.y.ToString("0.00");
            this.leapRollLabel.Text     = hand.PalmPosition.z.ToString("0.00");
        }
    }
}
