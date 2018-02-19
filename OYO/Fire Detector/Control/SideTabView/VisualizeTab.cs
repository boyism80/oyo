using OpenCvSharp;
using System;
using System.Windows.Forms;
using static Fire_Detector.MainForm;
using oyo;

namespace Fire_Detector.Control.SideTabView
{
    public partial class VisualizeTab : BaseTabView , IStateChangedListener
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
                    this.infraredViewButton.color = (this.Root.Receiver.Connected && !this.Root.Blending && this.Root.StreamingType == oyo.StreamingType.Infrared) ? backgroundActiveColor : backgroundInactiveColor;
                }));

                this.visualViewButton.Invoke(new MethodInvoker(delegate ()
                {
                    this.visualViewButton.color = (this.Root.Receiver.Connected && !this.Root.Blending && this.Root.StreamingType == oyo.StreamingType.Visual) ? backgroundActiveColor : backgroundInactiveColor;
                }));

                this.blendingViewButton.Invoke(new MethodInvoker(delegate ()
                {
                    this.blendingViewButton.color = (this.Root.Receiver.Connected && this.Root.Blending) ? backgroundActiveColor : backgroundInactiveColor;
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
            this.Root.Blending = false;
            this.UpdateUI();
        }

        private void visualViewButton_Click(object sender, EventArgs e)
        {
            this.Root.StreamingType = oyo.StreamingType.Visual;
            this.Root.Blending = false;
            this.UpdateUI();
        }

        private void palettesDropDown_onItemSelected(object sender, EventArgs e)
        {
            this.Root.Palette = this.palettesDropDown.selectedValue;
        }

        private void VisualizeTab_Load(object sender, EventArgs e)
        {
            this.UpdateUI();
        }

        private void blendingViewButton_Click(object sender, EventArgs e)
        {
            this.Root.Blending = true;
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

        public void OnUpdated(UpdateDataSet updateDataSet)
        {
        }
    }
}
