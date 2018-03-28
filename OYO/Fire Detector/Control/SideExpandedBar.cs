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

                this.buttonCollapse.Text = value.Tag as string;
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
    }
}
