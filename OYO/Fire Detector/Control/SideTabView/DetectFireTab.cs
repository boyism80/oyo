using Fire_Detector.Source;
using OpenCvSharp;
using oyo;
using System;
using System.Windows.Forms;

namespace Fire_Detector.Control.SideTabView
{
    public partial class DetectFireTab : BaseControl
    {
        public DetectFireTab()
        {
            InitializeComponent();
            this.detectionStateSwitch_OnValueChange(this.detectionStateSwitch, EventArgs.Empty);
        }

        private void desiredTemperatureSlider_ValueChanged(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Root.Detector.Threshold            = desiredTemperatureSlider.Value;
            this.desiredTemperatureLabel.Text       = this.Root.Detector.Threshold.ToString();
        }

        private void detectionStateSwitch_OnValueChange(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            try
            {
                var detecting                                               = detectionStateSwitch.Value;

                this.detectionStateLabel.Invoke(new MethodInvoker(delegate ()
                {
                    this.detectionStateLabel.Text                           = detecting ? "감지중" : "감지 안함";
                }));

                this.fireDetectionTemperaturePanel.Invoke(new MethodInvoker(delegate ()
                {
                    this.fireDetectionTemperaturePanel.Visible              = detecting;
                }));

                this.Root.defaultView.detectingLabel.Invoke(new MethodInvoker(delegate ()
                {
                    this.Root.defaultView.detectingLabel.Text               = detecting ? "산불감지중" : "산불감지안함";
                }));

                this.Root.defaultView.detectingProgressbar.Invoke(new MethodInvoker(delegate  ()
                {
                    this.Root.defaultView.detectingProgressbar.animated     = detecting;
                }));

                this.Root.Detector.Enabled                                  = detecting;
            }
            catch (Exception)
            { }
        }

        private void notificationSwitch_OnValueChange(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.notificationLabel.Text         = this.notificationSwitch.Value ? "On" : "Off";
            this.Root.Detector.Notification     = this.notificationSwitch.Value;
        }

        private void DetectFireTab_Load(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.synchronizeFromConfig();
        }

        public void OnFrameUpdated(UpdatedDataBuffer buffer, Mat updatedFrame, bool invalidated)
        {
            this.maxTemperature.Invoke(new MethodInvoker(delegate ()
            {
                this.maxTemperature.Text = buffer.MaximumTemperature.ToString("0.00");
            }));

            this.minTemperature.Invoke(new MethodInvoker(delegate ()
            {
                this.minTemperature.Text = buffer.MinimumTemperature.ToString("0.00");
            }));

            this.meanTemperature.Invoke(new MethodInvoker(delegate ()
            {
                this.meanTemperature.Text = buffer.MeanTemperature.ToString("0.00");
            }));
        }

        public void Receiver_OnDisconnected(OYOReceiver receiver)
        {
            //this.detectionStateSwitch.Value = false;
        }

        public bool synchronizeFromConfig()
        {
            try
            {
                if(this.Root == null)
                    return false;

                this.detectionStateSwitch.Invoke(new MethodInvoker(delegate ()
                {
                    this.detectionStateSwitch.Value         = this.Root.Detector.Enabled;
                    this.detectionStateSwitch_OnValueChange(this.detectionStateSwitch, EventArgs.Empty);
                }));

                this.notificationSwitch.Invoke(new MethodInvoker(delegate ()
                {
                    this.notificationSwitch.Value           = this.Root.Detector.Notification;
                }));

                this.desiredTemperatureSlider.Invoke(new MethodInvoker(delegate ()
                {
                    this.desiredTemperatureSlider.Value     = this.Root.Detector.Threshold;
                    this.desiredTemperatureSlider_ValueChanged(this.desiredTemperatureSlider, EventArgs.Empty);
                }));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}