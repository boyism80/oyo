using Bunifu.Framework.UI;
using Fire_Detector.Control.SideTabView;

namespace Fire_Detector.Control
{
    public partial class SideExpandedBar : BaseControl
    {
        private BaseControl _activatedTab;
        public BaseControl ActivatedTab
        {
            get
            {
                return this._activatedTab;
            }
            set
            {
                var exists = false;
                foreach(var control in this.Controls)
                {
                    var tab = control as BaseControl;
                    if(tab == null)
                        continue;

                    tab.Visible = (tab == value);
                    if(exists == false && (tab == value))
                        exists = true;
                }

                if(exists == false)
                    return;

                var title = (value.Tag as object[])[0] as string;
                var activated_side_button = (value.Tag as object[])[1] as BunifuImageButton;

                this.Root.defaultView.sideCollapsedBar.Activated = activated_side_button;
                this.buttonCollapse.Text = title;

                this._activatedTab = value;
            }
        }

        public SideExpandedBar()
        {
            InitializeComponent();
        }

        private void buttonCollapse_Click(object sender, System.EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.defaultView.sideExpandedBar.Visible = false;
        }

        private void SideExpandedBar_Load(object sender, System.EventArgs e)
        {
            this.droneTab.Tag       = new object[] { "Drone Control", this.Root.defaultView.sideCollapsedBar.droneTabButton }; 
            this.visualizeTab.Tag   = new object[] { "Visualization", this.Root.defaultView.sideCollapsedBar.visualizationTabButton }; 
            this.leapmotionTab.Tag  = new object[] { "Leapmotion", this.Root.defaultView.sideCollapsedBar.leapmotionTabButton }; 
            this.detectFireTab.Tag  = new object[] { "Detection", this.Root.defaultView.sideCollapsedBar.detectionTabButton }; 
        }
    }
}
