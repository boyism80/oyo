using Leap;
using System;

namespace oyo
{
    public class OYOAutoFlight
    {
        public delegate void                        OnStartEvent();
        public delegate void                        OnPauseEvent();
        public delegate void                        OnStopEvent();
        public delegate void                        OnCompleteEvent();
        public delegate void                        OnLookNextDestinationEvent();

        public static int                           MAX_SPEED = 127;
        public static int                           MIN_SPEED = 1;
        public static int                           MAX_DISTANCE = 200; // meter
        public static int                           MIN_DISTANCE = 10; // meter

        private GCS                                 _currentGCS;
        private GCS[]                               _destinations;
        private float                               _rotation;
        private int                                 _currentDestinationIndex;

        public bool                                 IsFlying { get; private set; }

        public event OnStartEvent                   OnStart;
        public event OnPauseEvent                   OnPause;
        public event OnStopEvent                    OnStop;
        public event OnCompleteEvent                OnComplete;
        public event OnLookNextDestinationEvent     OnLookNextDestination;

        private GCS Destination
        {
            get
            {
                return this._destinations[this._currentDestinationIndex];
            }
        }

        public OYOAutoFlight()
        { }

        public bool Update(GCS gcs, float rotation, out int roll, out int pitch)
        {
            try
            {
                if (this.IsFlying == false)
                    throw new Exception();

                if (gcs.IsValid == false)
                    throw new Exception();

                this._currentGCS                    = gcs;
                this._rotation                      = rotation;
                //this._rotation                      -= (float)(-6.7f * (Math.PI / 180.0f));
                //this._rotation -= (float)(-6.7f * (Math.PI / 180.0f));

                // 현재 드론의 회전 각도
                var degree                          = this._rotation * 180 / Math.PI;

                // 드론의 현재 위치로부터 목표지점까지의 벡터
                var vector                          = OYOGmap.GetVector(this._currentGCS, this.Destination);

                // 드론의 회전정도만큼 벡터를 회전
                vector.x                            = Math.Cos(this._rotation) * vector.x - Math.Sin(this._rotation) * vector.y;
                vector.y                            = Math.Sin(this._rotation) * vector.x + Math.Cos(this._rotation) * vector.y;

                var normal                          = vector.Normalized;
                var distance                        = vector.Magnitude;
                Console.WriteLine("distance : {0}m", (distance * 1000.0f).ToString("0.00"));

                if (distance * 1000.0f < 1)
                {
                    this._currentDestinationIndex++;
                    roll = pitch = 0;
                    this.OnLookNextDestination?.Invoke();
                    Console.WriteLine("next point");

                    if (this._currentDestinationIndex > this._destinations.Length - 1)
                    {
                        this.IsFlying               = false;
                        this.OnComplete?.Invoke();
                        Console.WriteLine("complete");
                    }

                    return true;
                }

                // 이게 무조건 양수인 문제가 있음
                var maxSpeed                        = (int)Math.Max(1, MAX_SPEED * Math.Min(1, (distance - MIN_DISTANCE) / (MAX_DISTANCE - MIN_DISTANCE)));
                var directionX                      = normal.x > 0 ? 1 : -1;
                var directionY                      = normal.y > 0 ? 1 : -1;

                if(Math.Abs(normal.x / normal.y) > 0) // x가 y보다 클 때
                {
                    roll                            = maxSpeed * directionX;
                    pitch                           = (int)(maxSpeed * Math.Abs(normal.y / normal.x)) * directionY;
                }
                else
                {
                    pitch                           = maxSpeed * directionX;
                    roll                            = (int)(maxSpeed * Math.Abs(normal.x / normal.y)) * directionY;
                }

                //Console.WriteLine("x speed : {0}, z speed : {1}", roll, pitch);

                //if (this.IsFlying == false)
                //{
                //    pitch = roll = 0;
                //}

                return true;
            }
            catch (Exception)
            {
                roll = pitch = 0;
                return false;
            }
        }

        public void SetDestinationPoints(params GCS[] points)
        {
            this._destinations = points;
        }

        public bool Start()
        {
            if(this._destinations == null || this._destinations.Length == 0)
                return false;

            if(this.IsFlying)
                return false;

            this._currentDestinationIndex = 0;
            this.IsFlying = true;
            this.OnStart?.Invoke();

            return true;
        }

        public bool Pause()
        {
            if(this.IsFlying == false)
                return false;

            this.IsFlying = false;
            this.OnPause?.Invoke();
            return true;
        }

        public void Stop()
        {
            if(this.IsFlying == false)
                return;

            this.IsFlying = false;
            this._currentDestinationIndex = 0;
            this.OnStop?.Invoke();
        }
    }
}