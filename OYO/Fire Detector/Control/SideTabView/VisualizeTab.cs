using Fire_Detector.Source;
using OpenCvSharp;
using oyo;
using System;
using System.Windows.Forms;

namespace Fire_Detector.Control.SideTabView
{
    public partial class VisualizeTab : BaseControl
    {
        public VisualizeTab()
        {
            InitializeComponent();

            this.levelTemperatureRange.RangeMin = 0;
            this.levelTemperatureRange.RangeMax = 107;
            this.horizontalRange.RangeMin = 20;
            this.horizontalRange.RangeMax = 80;
            this.verticalityRange.RangeMin = 20;
            this.verticalityRange.RangeMax = 80;

            foreach (var cname in Enum.GetNames(typeof(ColormapTypes)))
                this.palettesDropDown.AddItem(cname);
        }

        public bool synchronizeFromConfig(Config config)
        {
            try
            {
                if(this.Root == null)
                    throw new Exception("Does not initialized yet.");

                var backgroundActiveColor = System.Drawing.Color.LightCoral;
                var backgroundInactiveColor = System.Drawing.Color.DarkGray;

                this.infraredViewButton.Invoke(new MethodInvoker(delegate ()
                {
                    this.infraredViewButton.color = (this.Root.Receiver.Connected && !this.Root.Config.Blender.Enabled && this.Root.Config.Visualizer.StreamingType == oyo.StreamingType.Infrared) ? backgroundActiveColor : backgroundInactiveColor;
                }));

                this.visualViewButton.Invoke(new MethodInvoker(delegate ()
                {
                    this.visualViewButton.color = (this.Root.Receiver.Connected && !this.Root.Config.Blender.Enabled && this.Root.Config.Visualizer.StreamingType == oyo.StreamingType.Visual) ? backgroundActiveColor : backgroundInactiveColor;
                }));

                this.blendingViewButton.Invoke(new MethodInvoker(delegate ()
                {
                    this.blendingViewButton.color = (this.Root.Receiver.Connected && this.Root.Config.Blender.Enabled) ? backgroundActiveColor : backgroundInactiveColor;
                }));

                this.thresholdSlider.Invoke(new MethodInvoker(delegate ()
                {
                    this.thresholdSlider.Value = config.Blender.Threshold;
                }));

                this.transparencySlider.Invoke(new MethodInvoker(delegate ()
                {
                    this.transparencySlider.Value = (int)(config.Blender.Transparency * 100.0f);
                }));

                this.horizontalRange.Invoke(new MethodInvoker(delegate ()
                {
                    this.horizontalRange.MaximumRange = config.Blender.Size.Width;
                    this.horizontalRange.RangeMin = config.Blender.CroppedRect.X;
                    this.horizontalRange.RangeMax = config.Blender.CroppedRect.Width - config.Blender.CroppedRect.X;
                }));

                this.verticalityRange.Invoke(new MethodInvoker(delegate ()
                {
                    this.verticalityRange.MaximumRange = config.Blender.Size.Height;
                    this.verticalityRange.RangeMin = config.Blender.CroppedRect.Y;
                    this.verticalityRange.RangeMax = config.Blender.CroppedRect.Height - config.Blender.CroppedRect.Y;
                }));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public void Receiver_OnConnectionChanged(OYOReceiver receiver)
        {
            try
            {
                this.connectionCameraProgressbar.Invoke(new MethodInvoker(delegate ()
                {
                    this.connectionCameraProgressbar.animated = receiver.Connected;
                    this.connectionCameraProgressbar.Value = receiver.Connected ? 40 : 0;
                }));

                this.connectionLabel.Invoke(new MethodInvoker(delegate ()
                {
                    connectionLabel.Text = receiver.Connected ? "서버와 연결되었습니다." : "서버와 연결되지 않았습니다.";
                }));

                this.synchronizeFromConfig(this.Root.Config);
            }
            catch (Exception)
            { }
        }

        private void connectCameraButton_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            if(this.Root.Receiver.Connected)
                this.Root.Receiver.Exit();
            else
                this.Root.Receiver.Connect();
        }

        private void infraredViewButton_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.Config.Visualizer.StreamingType = oyo.StreamingType.Infrared;
            this.Root.Config.Blender.Enabled = false;
            this.synchronizeFromConfig(Root.Config);
        }

        private void visualViewButton_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.Config.Visualizer.StreamingType = oyo.StreamingType.Visual;
            this.Root.Config.Blender.Enabled = false;
            this.synchronizeFromConfig(Root.Config);
        }

        private void palettesDropDown_onItemSelected(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.Config.Visualizer.Palette = this.palettesDropDown.selectedValue;
        }

        private void VisualizeTab_Load(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            //this.thresholdSlider_ValueChanged(this.thresholdSlider, EventArgs.Empty);
            //this.transparencySlider_ValueChanged(this.transparencySlider, EventArgs.Empty);

            this.synchronizeFromConfig(Root.Config);
        }

        private void blendingViewButton_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.Config.Blender.Enabled = true;
            this.synchronizeFromConfig(Root.Config);
        }

        private void fixLevelCheckBox_OnChange(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.Receiver.FixLevel = this.fixLevelCheckBox.Checked;
            this.Root.Receiver.LevelTemperatureRange = new Rangef(this.levelTemperatureRange.RangeMin, this.levelTemperatureRange.RangeMax);

            this.fixLevelLabel.Invoke(new MethodInvoker(delegate ()
            {
                this.fixLevelLabel.Text = this.fixLevelCheckBox.Checked ? "고정" : "자동";
            }));
        }

        private void levelTemperatureRange_RangeChanged(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.Receiver.FixLevel = this.fixLevelCheckBox.Checked;
            this.Root.Receiver.LevelTemperatureRange = new Rangef(this.levelTemperatureRange.RangeMin, this.levelTemperatureRange.RangeMax);
        }

        private void thresholdSlider_ValueChanged(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.Config.Blender.Threshold      = this.thresholdSlider.Value;
            this.thresholdLabel.Text                = this.Root.Config.Blender.Threshold.ToString();
        }

        private void transparencySlider_ValueChanged(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.Config.Blender.Transparency   = this.transparencySlider.Value / 100.0f;
            this.transparencyLabel.Text             = this.Root.Config.Blender.Transparency.ToString();
        }

        private void levelTemperatureRange_RangeMaxChanged(object sender, EventArgs e)
        {
            this.rangeMax.Text = levelTemperatureRange.RangeMax.ToString();
        }

        private void levelTemperatureRange_RangeMinChanged(object sender, EventArgs e)
        {
            this.rangeMin.Text = levelTemperatureRange.RangeMin.ToString();
        }

        private void horizontalRange_RangeChanged(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.Config.Blender.CroppedRect = new Rect(new OpenCvSharp.Point(this.horizontalRange.RangeMin, this.Root.Config.Blender.CroppedRect.Y), 
                                                     new OpenCvSharp.Size(this.horizontalRange.RangeMax - this.horizontalRange.RangeMin, this.Root.Config.Blender.CroppedRect.Height));
        }

        private void verticalityRange_RangeChanged(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.Config.Blender.CroppedRect = new Rect(new OpenCvSharp.Point(this.Root.Config.Blender.CroppedRect.X, this.verticalityRange.RangeMin), 
                                                     new OpenCvSharp.Size(this.Root.Config.Blender.CroppedRect.Width, this.verticalityRange.RangeMax - this.verticalityRange.RangeMin));
        }
    }
}
