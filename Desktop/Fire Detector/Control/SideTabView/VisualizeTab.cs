﻿using OpenCvSharp;
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
        }

        public bool synchronizeFromConfig()
        {
            try
            {
                if(this.Root == null)
                    throw new Exception("Does not initialized yet.");

                var backgroundActiveColor = System.Drawing.Color.LightCoral;
                var backgroundInactiveColor = System.Drawing.Color.DarkGray;

                this.palettesDropDown.Invoke(new MethodInvoker(delegate ()
                {
                    for (var i = 0; i < this.palettesDropDown.Items.Count; i++)
                    {
                        if (this.palettesDropDown.Items[i].Equals(this.Root.Visualizer.Palette))
                        {
                            this.palettesDropDown.selectedIndex = i;
                            break;
                        }
                    }
                }));


                //
                // 표시 모드(열화상, 실화상, 블렌딩) 선택 버튼
                //
                this.infraredViewButton.Invoke(new MethodInvoker(delegate ()
                {
                    this.infraredViewButton.Enabled = this.Root.Receiver.Connected;
                    this.infraredViewButton.color = (this.Root.Receiver.Connected && !this.Root.Blender.Enabled && this.Root.Visualizer.StreamingType == oyo.StreamingType.Infrared) ? backgroundActiveColor : backgroundInactiveColor;
                }));

                this.visualViewButton.Invoke(new MethodInvoker(delegate ()
                {
                    this.visualViewButton.Enabled = this.Root.Receiver.Connected;
                    this.visualViewButton.color = (this.Root.Receiver.Connected && !this.Root.Blender.Enabled && this.Root.Visualizer.StreamingType == oyo.StreamingType.Visual) ? backgroundActiveColor : backgroundInactiveColor;
                }));

                this.blendingViewButton.Invoke(new MethodInvoker(delegate ()
                {
                    this.blendingViewButton.Enabled = this.Root.Receiver.Connected;
                    this.blendingViewButton.color = (this.Root.Receiver.Connected && this.Root.Blender.Enabled) ? backgroundActiveColor : backgroundInactiveColor;
                }));

                this.fixLevelCheckBox.Invoke(new MethodInvoker(delegate ()
                {
                    this.fixLevelCheckBox.Checked = this.Root.Receiver.FixLevel;
                    this.levelTemperatureRange.RangeMin = (int)this.Root.Receiver.LevelTemperatureRange.Start;
                    this.levelTemperatureRange.RangeMax = (int)this.Root.Receiver.LevelTemperatureRange.End;
                    this.levelTemperatureRange_RangeMinChanged(this.levelTemperatureRange, EventArgs.Empty);
                    this.levelTemperatureRange_RangeMaxChanged(this.levelTemperatureRange, EventArgs.Empty);
                }));

                //
                // 블렌딩 옵션 (임계값, 투명도) 슬라이더
                //
                this.thresholdSlider.Invoke(new MethodInvoker(delegate ()
                {
                    this.thresholdSlider.Value = this.Root.Blender.Threshold;
                    this.thresholdSlider_ValueChanged(this.thresholdSlider, EventArgs.Empty);
                }));

                this.transparencySlider.Invoke(new MethodInvoker(delegate ()
                {
                    this.transparencySlider.Value = (int)(this.Root.Blender.Transparency * 100.0f);
                    this.transparencySlider_ValueChanged(this.transparencySlider, EventArgs.Empty);
                }));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        private void synchronizeStreamingModeUI()
        {
            if (this.Root.Blender.Enabled)
            {
                blendingOptionPanel.Visible = true;
                infraredOptionPanel.Visible = true;
            }
            else if (this.Root.Visualizer.StreamingType == StreamingType.Infrared)
            {
                blendingOptionPanel.Visible = false;
                infraredOptionPanel.Visible = true;
            }
            else // this.Root.Visualizer.StreamingType == StreamingType.Visual
            {
                blendingOptionPanel.Visible = false;
                infraredOptionPanel.Visible = false;
            }
        }

        public void Receiver_OnConnectionChanged(OYOReceiver receiver)
        {
            try
            {
                this.connectionCameraProgressbar.Invoke(new MethodInvoker(delegate ()
                {
                    this.connectionCameraProgressbar.animated = receiver.Connected;
                    this.connectionCameraProgressbar.Value = receiver.Connected ? 15 : 0;
                }));

                this.connectionLabel.Invoke(new MethodInvoker(delegate ()
                {
                    connectionLabel.Text = receiver.Connected ? "서버와 연결되었습니다." : "서버와 연결되지 않았습니다.";
                }));

                this.synchronizeFromConfig();
            }
            catch (Exception)
            { }
        }

        private void connectCameraButton_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.mainView.mainConnectionView.raspCamImageButton_Click(sender, e);
        }

        private void infraredViewButton_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.Visualizer.StreamingType = oyo.StreamingType.Infrared;
            this.Root.Blender.Enabled = false;
            this.synchronizeFromConfig();
            this.synchronizeStreamingModeUI();
        }

        private void visualViewButton_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.Visualizer.StreamingType = oyo.StreamingType.Visual;
            this.Root.Blender.Enabled = false;
            this.synchronizeFromConfig();
            this.synchronizeStreamingModeUI();
        }

        private void palettesDropDown_onItemSelected(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.Visualizer.Palette = this.palettesDropDown.selectedValue;
        }

        private void VisualizeTab_Load(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.synchronizeFromConfig();
            this.synchronizeStreamingModeUI();
        }

        private void blendingViewButton_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.Blender.Enabled = true;
            this.synchronizeFromConfig();
            this.synchronizeStreamingModeUI();
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

            this.Root.Blender.Threshold      = this.thresholdSlider.Value;
            this.thresholdLabel.Text                = this.Root.Blender.Threshold.ToString();
        }

        private void transparencySlider_ValueChanged(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.Blender.Transparency   = this.transparencySlider.Value / 100.0f;
            this.transparencyLabel.Text             = (this.Root.Blender.Transparency * 100.0f).ToString();
        }

        private void levelTemperatureRange_RangeMaxChanged(object sender, EventArgs e)
        {
            this.rangeMax.Text = levelTemperatureRange.RangeMax.ToString();
        }

        private void levelTemperatureRange_RangeMinChanged(object sender, EventArgs e)
        {
            this.rangeMin.Text = levelTemperatureRange.RangeMin.ToString();
        }
    }
}
