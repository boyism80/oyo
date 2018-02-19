using Fire_Detector.Source;
using OpenCvSharp;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Fire_Detector.Control.SideTabView
{
    public partial class VisualizeTab : BaseTabView , BunifuForm.MainForm.IStateChangedListener
    {
        public VisualizeTab()
        {
            InitializeComponent();

            foreach (var cname in Enum.GetNames(typeof(ColormapTypes)))
                this.palettesDropDown.AddItem(cname);
        }

        private void UpdateUI()
        {
            try
            {
                if(this.Root == null)
                    return;

                var backgroundActiveColor = System.Drawing.Color.LightCoral;
                var backgroundInactiveColor = System.Drawing.Color.DarkGray;

                this.infraredViewButton.Invoke(new MethodInvoker(delegate ()
                {
                    this.infraredViewButton.color = (this.Root.Receiver.Connected && !this.Root.Config.Blending.Enabled && this.Root.StreamingType == oyo.StreamingType.Infrared) ? backgroundActiveColor : backgroundInactiveColor;
                }));

                this.visualViewButton.Invoke(new MethodInvoker(delegate ()
                {
                    this.visualViewButton.color = (this.Root.Receiver.Connected && !this.Root.Config.Blending.Enabled && this.Root.StreamingType == oyo.StreamingType.Visual) ? backgroundActiveColor : backgroundInactiveColor;
                }));

                this.blendingViewButton.Invoke(new MethodInvoker(delegate ()
                {
                    this.blendingViewButton.color = (this.Root.Receiver.Connected && this.Root.Config.Blending.Enabled) ? backgroundActiveColor : backgroundInactiveColor;
                }));
            }
            catch (Exception)
            { }
        }
        
        public void OnStateChanged(bool connected)
        {
            try
            {
                this.connectionCameraProgressbar.Invoke(new MethodInvoker(delegate ()
                {
                    this.connectionCameraProgressbar.animated = connected;
                    this.connectionCameraProgressbar.Value = connected ? 40 : 0;
                }));

                this.connectionLabel.Invoke(new MethodInvoker(delegate ()
                {
                    connectionLabel.Text = connected ? "서버와 연결되었습니다." : "서버와 연결되지 않았습니다.";
                }));

                this.UpdateUI();
            }
            catch (Exception)
            { }
        }

        private void connectCameraButton_Click(object sender, EventArgs e)
        {
            if(this.Root.Receiver.Connected)
                this.Root.DisconnectToCamera();
            else
                this.Root.ConnectToCamera();
        }

        private void infraredViewButton_Click(object sender, EventArgs e)
        {
            this.Root.StreamingType = oyo.StreamingType.Infrared;
            this.Root.Config.Blending.Enabled = false;
            this.UpdateUI();
        }

        private void visualViewButton_Click(object sender, EventArgs e)
        {
            this.Root.StreamingType = oyo.StreamingType.Visual;
            this.Root.Config.Blending.Enabled = false;
            this.UpdateUI();
        }

        private void palettesDropDown_onItemSelected(object sender, EventArgs e)
        {
            this.Root.Config.Visualize.Palette = this.palettesDropDown.selectedValue;
        }

        private void VisualizeTab_Load(object sender, EventArgs e)
        {
            this.UpdateUI();
        }

        private void blendingViewButton_Click(object sender, EventArgs e)
        {
            this.Root.Config.Blending.Enabled = true;
            this.UpdateUI();
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            this.Root.Receiver.FixLevel = this.fixLevelCheckBox.Checked;
            this.Root.Receiver.LevelTemperatureRange = new Rangef(this.levelTemperatureRange.RangeMin, this.levelTemperatureRange.RangeMax);

            this.fixLevelLabel.Invoke(new MethodInvoker(delegate ()
            {
                this.fixLevelLabel.Text = this.fixLevelCheckBox.Checked ? "고정" : "자동";
            }));
        }

        private void levelTemperatureRange_RangeChanged(object sender, EventArgs e)
        {
            this.Root.Receiver.FixLevel = this.fixLevelCheckBox.Checked;
            this.Root.Receiver.LevelTemperatureRange = new Rangef(this.levelTemperatureRange.RangeMin, this.levelTemperatureRange.RangeMax);
        }

        public void OnUpdated(UpdateData updateDataSet)
        {
        }

        private void thresholdSlider_ValueChanged(object sender, EventArgs e)
        {
            this.thresholdLabel.Text = this.thresholdSlider.Value.ToString();
        }

        private void transparencySlider_ValueChanged(object sender, EventArgs e)
        {
            this.transparencyLabel.Text = this.transparencySlider.Value.ToString();
        }

        public void OnSizeChanged(System.Drawing.Size size, bool isMaximize)
        {
            //throw new NotImplementedException();
        }
    }
}
