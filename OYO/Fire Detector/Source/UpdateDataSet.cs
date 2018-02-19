using OpenCvSharp;
using oyo;

namespace Fire_Detector.Source
{
    public sealed class UpdateData
    {
        public StreamingType StreamingType { get; private set; }
        public bool Invalidated { get; private set; }
        public Mat Radioactive { get; private set; }

        public Mat Temperature { get; private set; }
        public Mat Infrared { get; private set; }
        public Mat Mask { get; private set; }
        public Mat Visual { get; private set; }
        public Mat UpdatedFrame { get; private set; }

        private Point _minloc;
        public Point MinimumTemperatureLocation
        {
            get
            {
                return this._minloc;
            }
        }

        private Point _maxloc;
        public Point MaximumTemperatureLocation
        {
            get
            {
                return this._maxloc;
            }
        }

        private double _minval;
        public double MinimumTemperature
        {
            get
            {
                return this._minval;
            }
        }

        private double _maxval;
        public double MaximumTemperature
        {
            get
            {
                return this._maxval;
            }
        }

        private double _meanval;
        public double MeanTemperature
        {
            get
            {
                return this._meanval;
            }
        }

        public UpdateData()
        {
            this._minloc = new Point();
            this._maxloc = new Point();
        }

        public void Update(Mat infrared, Mat temperature, double temperatureThreshold)
        {
            this.StreamingType = StreamingType.Infrared;
            this.Infrared = infrared;
            this.Temperature = temperature;
            this.Mask = this.Temperature.Threshold(temperatureThreshold, 255, ThresholdTypes.Binary);

            this.Temperature.MinMaxLoc(out this._minval, out this._maxval, out this._minloc, out this._maxloc);
            this._meanval = this.Temperature.Mean().Val0;
        }

        public void Update(Mat visual)
        {
            this.StreamingType = StreamingType.Visual;
            this.Visual = visual;
        }

        public void SetUpdatedFrame(Mat frame)
        {
            this.UpdatedFrame = frame;
        }

        public bool SetInvalidateState(bool blending, StreamingType currentStreamingType)
        {
            this.Invalidated = blending || (this.StreamingType == currentStreamingType);
            return this.Invalidated;
        }
    }
}
