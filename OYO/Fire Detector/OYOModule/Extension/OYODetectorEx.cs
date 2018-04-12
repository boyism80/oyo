using OpenCvSharp;

namespace oyo
{
    public partial class OYODetector
    {
        public delegate void                    DetectionStateChangedEvent(bool isDetected, RotatedRect[] detectedRects);
        public delegate void                    DetectionCountChangedEvent(RotatedRect[] detectedRects);
        public delegate void                    EnabledChangedEvent(bool enabled, bool isDetected);
        public delegate void                    NotificationChangedEvent(bool enabled, bool isDetected);

        private bool                            _currentDetected;
        private int                             _currentDetectedCount;

        public event DetectionStateChangedEvent OnDetectionStateChanged;
        public event DetectionCountChangedEvent OnDetectionCountChanged;
        public event EnabledChangedEvent        OnEnabledChanged;
        public event NotificationChangedEvent   OnNotificationChanged;

        private bool _enabled;
        public bool Enabled
        {
            get
            {
                return this._enabled;
            }
            set
            {
                if(this._enabled != value && this.OnEnabledChanged != null)
                    this.OnEnabledChanged.Invoke(value, this.IsDetected);

                this._enabled = value;
            }
        }

        private bool _notification;
        public bool Notification
        {
            get
            {
                return this._notification;
            }
            set
            {
                if(this._notification != value && this.OnNotificationChanged != null)
                    this.OnNotificationChanged.Invoke(value, this.IsDetected);

                this._notification = value;
            }
        }

        public int Threshold { get; set; }

        public bool IsDetected
        {
            get
            {
                return this.DetectedRects.Length != 0;
            }
        }

        public void Detect(Mat source, isDetectedDelegate callback)
        {
            this.Update(source, callback);
            var detected = this.DetectedRects.Length != 0;
            if(this._currentDetected != detected)
            {
                this._currentDetected = detected;
                if(this.OnDetectionStateChanged != null && this.Notification)
                    this.OnDetectionStateChanged.Invoke(this._currentDetected, this.DetectedRects);
            }

            if(this.DetectedRects.Length != this._currentDetectedCount)
            {
                this._currentDetectedCount = this.DetectedRects.Length;
                if(this.OnDetectionCountChanged != null && this.Notification)
                    this.OnDetectionCountChanged.Invoke(this.DetectedRects);
            }
        }
    }
}