using System;

namespace oyo
{
    public class OYOAutoFlight
    {
        public static int MAX_SPEED = 127;
        public static int MIN_SPEED = 1;
        public static int MAX_DISTANCE = 50; // meter
        public static int MIN_DISTANCE = 10; // meter

        private GCS _currentGCS;
        private GCS[] _destinations;
        private float _rotation;
        private int _currentDestinationIndex;

        public bool IsFlying { get; private set; }

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
            this._currentGCS = gcs;
            this._rotation = rotation;

            try
            {
                if(this.IsFlying == false)
                    throw new Exception();

                if(this._currentGCS.IsValid == false)
                    throw new Exception();

                // 현재 드론의 회전 각도
                var degree = this._rotation * 180 / Math.PI;

                // 드론의 현재 위치로부터 목표지점까지의 벡터
                var vector = OYOGmap.GetVector(this._currentGCS, this.Destination);

                // 드론의 회전정도만큼 벡터를 회전
                vector.x = (float)(Math.Cos(degree) * vector.x - Math.Sin(degree) * vector.y);
                vector.y = (float)(Math.Sin(degree) * vector.x + Math.Cos(degree) * vector.y);


                var normal = vector.Normalized;
                var distance = vector.MagnitudeSquared;

                if (distance / 1000.0f < 1)
                {
                    this._currentDestinationIndex++;
                    roll = pitch = 0;
                    Console.WriteLine("near");

                    if (this._currentDestinationIndex > this._destinations.Length - 1)
                    {
                        this.IsFlying = false;
                        Console.WriteLine("complete");
                    }

                    return true;
                }

                var maxSpeed = (int)Math.Max(1, MAX_SPEED * Math.Min(1, (distance - MIN_DISTANCE) / (MAX_DISTANCE - MIN_DISTANCE)));

                if (normal.x > normal.y)
                {
                    roll = maxSpeed;
                    pitch = (int)(maxSpeed * (normal.y / normal.x));
                }
                else
                {
                    pitch = maxSpeed;
                    roll = (int)(maxSpeed * (normal.y / normal.x));
                }

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
            return true;
        }

        public bool Pause()
        {
            if(this.IsFlying == false)
                return false;

            this.IsFlying = false;
            return true;
        }

        public void Stop()
        {
            this.IsFlying = false;
            this._currentDestinationIndex = 0;
        }
    }
}