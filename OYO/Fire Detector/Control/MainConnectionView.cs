using Fire_Detector.Control.SideTabView;
using Fire_Detector.Source;
using System.Drawing;
using System.Windows.Forms;

namespace Fire_Detector.Control
{
    public partial class MainConnectionView : BaseTabView, BunifuForm.MainForm.IStateChangedListener
    {
        private Panel[] iconPanels = new Panel[3];

        public MainConnectionView()
        {
            InitializeComponent();

            this.droneImageButton.Tag = this.bunifuCustomLabel6;
            this.droneProgressbar.Tag = this.droneImageButton;
            this.dronePanel.Tag = this.droneProgressbar;

            this.raspCamImageButton.Tag = this.bunifuCustomLabel7;
            this.raspCamProgressbar.Tag = this.raspCamImageButton;
            this.raspCamPanel.Tag = this.raspCamProgressbar;

            this.leapMotionImageButton.Tag = this.bunifuCustomLabel8;
            this.leapmotionProgressbar.Tag = this.leapMotionImageButton;
            this.leapmotionPanel.Tag = this.leapmotionProgressbar;

            this.iconPanels = new Panel[] { this.dronePanel, this.raspCamPanel, this.leapmotionPanel };
        }

        public void OnSizeChanged(Size size, bool isMaximize)
        {
            foreach(var panel in this.iconPanels)
            {
                var progressbar = panel.Tag as Bunifu.Framework.UI.BunifuCircleProgressbar;
                progressbar.Size = new Size((int)(panel.Width * 0.6f), (int)(panel.Width * 0.6f));
                progressbar.Location = new Point((panel.Width - progressbar.Width) / 2, progressbar.Location.Y);

                var icon = progressbar.Tag as Bunifu.Framework.UI.BunifuImageButton;
                icon.Width = icon.Height = (int)(panel.Width * 0.32f);
                icon.Location = new Point(progressbar.Location.X + (progressbar.Width - icon.Width) / 2,
                                          progressbar.Location.Y + (progressbar.Height - icon.Height) / 2);

                var label = icon.Tag as Bunifu.Framework.UI.BunifuCustomLabel;
                label.Font = new Font(label.Font.FontFamily, (18.0f / 335.0f) * panel.Width, label.Font.Style);
            }
        }

        public void OnStateChanged(bool connected)
        {
        }

        public void OnUpdated(UpdateData updateDataSet)
        {
        }

        private void MainConnectionView_Load(object sender, System.EventArgs e)
        {
            this.OnSizeChanged(this.Root.Size, false);
        }
    }
}
