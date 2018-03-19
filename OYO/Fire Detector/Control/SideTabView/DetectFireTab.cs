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
            desiredTemperatureLabel.Text = desiredTemperatureSlider.Value.ToString();

            if(this.Root == null)
                return;
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

                this.Root.Config.Detecting.Enabled                          = detecting;
            }
            catch (Exception)
            { }
        }

        private void notificationSwitch_OnValueChange(object sender, EventArgs e)
        {
            if (notificationSwitch.Value == true)
                notificationLabel.Text = "On";
            else notificationLabel.Text = "Off";
        }

        private void DetectFireTab_Load(object sender, EventArgs e)
        {
            this.detectionStateSwitch_OnValueChange(this.detectionStateSwitch, EventArgs.Empty);
            this.desiredTemperatureSlider_ValueChanged(this.desiredTemperatureSlider, EventArgs.Empty);
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
            this.detectionStateSwitch.Value = false;
        }
    }
}