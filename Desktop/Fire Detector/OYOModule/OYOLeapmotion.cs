using Leap;
using System;

namespace oyo
{
    public class OYOLeapmotion : Leap.Controller
    {
        public new event EventHandler<DeviceEventArgs>  Connect;
        public new event EventHandler<DeviceEventArgs>  Disconnect;
        public new event EventHandler<FrameEventArgs>   FrameReady;

        private bool _enabled;
        public bool Enabled
        {
            get
            {
                return this._enabled && this.IsConnected;
            }

            set
            {
                this._enabled = this.IsConnected && value;
                if(this._enabled)
                    this.Connect.Invoke(this, new DeviceEventArgs(this.Devices.ActiveDevice));
                else
                    this.Disconnect.Invoke(this, new DeviceEventArgs(this.Devices.ActiveDevice));
            }
        }

        public OYOLeapmotion()
        {
            base.Device += this.OnDevice;
            base.DeviceLost += this.OnDeviceLost;
            base.FrameReady += this.OnFrameReady;
        }

        private void OnDevice(object sender, DeviceEventArgs e)
        {
            if(this.Enabled && this.Connect != null)
                this.Connect.Invoke(sender, e);
        }

        private void OnDeviceLost(object sender, DeviceEventArgs e)
        {
            if(this.Disconnect != null)
                this.Disconnect.Invoke(sender, e);
        }

        private void OnFrameReady(object sender, FrameEventArgs e)
        {
            if(this.Enabled && this.FrameReady != null)
                this.FrameReady.Invoke(sender, e);
        }
    }
}