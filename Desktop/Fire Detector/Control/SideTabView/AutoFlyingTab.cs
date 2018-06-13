using System.Windows.Forms;

namespace Fire_Detector.Control.SideTabView
{
    public partial class AutoFlyingTab : BaseControl
    {
        public AutoFlyingTab()
        {
            InitializeComponent();
        }

        

        private void autoflySettingButton_Click(object sender, System.EventArgs e)
        {
            
            
        }

        private void autoflyStartEndButton_Click(object sender, System.EventArgs e)
        {

        }

        private void autoFlyingSettingButton_Click(object sender, System.EventArgs e)
        {
            var dialog = new Fire_Detector.Dialog.AutoFlyingDialog();
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
        }

        private void autoFlyingStartEndButton_Click(object sender, System.EventArgs e)
        {

        }
    }
}
