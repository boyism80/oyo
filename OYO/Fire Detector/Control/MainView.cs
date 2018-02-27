using Fire_Detector.Control.SideTabView;
using System;
using System.Windows.Forms;

namespace Fire_Detector.Control
{
    public partial class MainView : BaseTabView
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void bottomLabel_MouseEnter(object sender, EventArgs e)
        {
            var label = sender as Bunifu.Framework.UI.BunifuCustomLabel;
            if(label == null)
                return;

            var tab = label.Tag as UserControl;     // 이 부분 UserControl을 상속받는 부모 클래스 작성해야함
            if(tab == null)
                return;

            this.mainConnectionView.Visible = false;
            this.activatedConnectionIconPanel.Visible = true;
            tab.Visible = true;
        }

        private void bottomLabel_MouseLeave(object sender, EventArgs e)
        {
            var label = sender as Bunifu.Framework.UI.BunifuCustomLabel;
            if(label == null)
                return;

            this.mainConnectionView.Visible = true;
            this.activatedConnectionIconPanel.Visible = false;

            var tab = label.Tag as UserControl;     // 이 부분 UserControl을 상속받는 부모 클래스 작성해야함
            if(tab == null)
                return;

            tab.Visible = false;
        }

        private void bottomLabel_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            var label = sender as Bunifu.Framework.UI.BunifuCustomLabel;
            if(label == null)
                return;

            this.Root.mainView.Visible = false;
            this.Root.defaultView.Visible = true;
            var tab = label.Tag as UserControl;     // 이 부분 UserControl을 상속받는 부모 클래스 작성해야함
            if (tab != null)
            {
                this.Root.defaultView.sideExpandedBar.Visible = true;
                this.Root.defaultView.sideExpandedBar.SetActiveTab(tab.Tag as BaseTabView);
            }
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.droneTabShow.Tag = this.Root.defaultView.sideExpandedBar.droneTab;
            this.droneControlLabel.Tag = this.droneTabShow;

            this.visualizeTabShow.Tag = this.Root.defaultView.sideExpandedBar.visualizeTab;
            this.visualizeLabel.Tag = this.visualizeTabShow;

            this.leapmotionTabShow.Tag = this.Root.defaultView.sideExpandedBar.leapmotionTab;
            this.leapmotionLabel.Tag = this.leapmotionTabShow;

            this.detectFireTabShow.Tag = this.Root.defaultView.sideExpandedBar.detectFireTab;
            this.detectFireLabel.Tag = this.detectFireTabShow;
        }
    }
}
