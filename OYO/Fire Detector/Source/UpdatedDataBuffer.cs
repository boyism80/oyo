using OpenCvSharp;

namespace Fire_Detector.Source
{
    public sealed class UpdatedDataBuffer
    {
        private Size _currentDisplaySize;
        
        private Mat _infrared;
        public Mat Infrared
        {
            get
            {
                return this._infrared;
            }
        }


        private Mat _visual;
        public Mat Visual
        {
            get
            {
                return this._visual;
            }
        }


        private Mat _temperature;
        public Mat Temperature
        {
            get
            {
                return this._temperature;
            }
        }

        private Mat _lastFrame;
        public Mat LastFrame
        {
            get
            {
                return this._lastFrame;
            }
        }

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

        public UpdatedDataBuffer()
        {
        }

        private void Update()
        {
            if(this._currentDisplaySize == OpenCvSharp.Size.Zero)
                return;

            if(this._infrared != null)
                this._infrared = this._infrared.Resize(this._currentDisplaySize);

            if(this._temperature != null)
                this._temperature = this._temperature.Resize(this._currentDisplaySize);

            if(this._visual != null)
                this._visual = this._visual.Resize(this._currentDisplaySize);

            if(this._lastFrame != null)
                this._lastFrame = this._lastFrame.Resize(this._currentDisplaySize);


            Cv2.MinMaxLoc(this._temperature, out this._minval, out this._maxval, out this._minloc, out this._maxloc);
            this._meanval = this._temperature.Mean().Val0;
        }

        public Mat SetDisplay(Size currentDisplaySize)
        {
            this._currentDisplaySize = currentDisplaySize;
            this.Update();
            return this.LastFrame;
        }

        public void SetInfrared(Mat infrared, Mat temperature)
        {
            this._infrared = infrared;
            this._temperature = temperature;
            this._lastFrame = infrared;

            this.Update();
        }

        public void SetVisual(Mat visual)
        {
            this._visual = visual;
            this._lastFrame = visual;

            this.Update();
        }
    }
}