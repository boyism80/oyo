using Fire_Detector.Control.SideTabView;
using System;
using System.Windows.Forms;
using Fire_Detector.Source;
using OpenCvSharp;
using System.Drawing;

namespace Fire_Detector.Control
{
    public partial class MainView : BaseTabView, BunifuForm.MainForm.IStateChangedListener
    {
        private int _basedHeight;

        public MainView()
        {
            InitializeComponent();

            this._basedHeight = this.OYOPanel.Height;
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

        public void OnStateChanged(bool connected)
        {
            
        }

        public void OnUpdated(UpdatedDataBuffer buffer, Mat updatedFrame, bool invalidated)
        {
            
        }

        public void OnSizeChanged(System.Drawing.Size size, bool isMaximize)
        {
            this.OYOPanel.Invoke(new MethodInvoker(delegate ()
            {
                this.OYOPanel.Height = (isMaximize ? (int)(this._basedHeight * 1.75f) : this._basedHeight);
                this.OYOPanel.Padding = (isMaximize ? new Padding(80) : new Padding(40));
            }));

            this.bunifuCustomLabel1.Invoke(new MethodInvoker(delegate ()
            {
                this.bunifuCustomLabel1.Font = new Font(this.bunifuCustomLabel1.Font.FontFamily, isMaximize ? 26.0f : 18.0f, this.bunifuCustomLabel1.Font.Style);
            }));

            this.bunifuCustomLabel2.Invoke(new MethodInvoker(delegate ()
            {
                this.bunifuCustomLabel2.Font = new Font(this.bunifuCustomLabel2.Font.FontFamily, isMaximize ? 19.0f : 12.0f, this.bunifuCustomLabel2.Font.Style);
                this.bunifuCustomLabel2.Padding = isMaximize ? new Padding(0, 6, 0, 6) : Padding.Empty;
            }));

            this.bunifuCustomLabel3.Invoke(new MethodInvoker(delegate ()
            {
                this.bunifuCustomLabel3.Font = new Font(this.bunifuCustomLabel3.Font.FontFamily, isMaximize ? 15.0f : 10.0f, this.bunifuCustomLabel3.Font.Style);
            }));

            this.bunifuCustomLabel4.Invoke(new MethodInvoker(delegate ()
            {
                this.bunifuCustomLabel4.Font = new Font(this.bunifuCustomLabel4.Font.FontFamily, isMaximize ? 15.0f : 10.0f, this.bunifuCustomLabel4.Font.Style);
            }));

            this.bunifuCustomLabel5.Invoke(new MethodInvoker(delegate ()
            {
                this.bunifuCustomLabel5.Font = new Font(this.bunifuCustomLabel5.Font.FontFamily, isMaximize ? 15.0f : 10.0f, this.bunifuCustomLabel5.Font.Style);
            }));
        }
    }
}
