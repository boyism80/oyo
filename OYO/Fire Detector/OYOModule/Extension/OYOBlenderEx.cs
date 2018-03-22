using OpenCvSharp;

namespace oyo
{
    public partial class OYOBlender
    {
        public bool Enabled { get; set; }
        public int Threshold { get; set; }

        public bool SetInfrared(Mat infrared, Mat temperature)
        {
            var mask = temperature.Threshold(this.Threshold, 255, ThresholdTypes.Binary);
            return this.Update(infrared, mask);
        }

        public bool SetVisual(Mat visual)
        {
            return this.Update(visual);
        }
    }
}