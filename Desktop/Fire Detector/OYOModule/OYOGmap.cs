using Leap;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace oyo
{
    public class OYOGmap
    {
        private static string               GOOGLE_API_KEY = "AIzaSyDO1LpjNHsEWBWLFdBPc6acJgyujd8ur2s";
        public static float                 EARTH_RADIUS = 6371.0f;

        public delegate void                OnReceiveGmap(Mat mat);
        public delegate void                OnReceiveAddress(string addr);
        public delegate void                OnError(string message);

        private float                       _lat = 500, _lon = 500;
        private int                         _width = 480, _height = 320;
        private int                         _zoom = 18;
        private Mat                         _cached;
        private Mutex                       _mutex_gmap = new Mutex();
        private Mutex                       _mutex_addr = new Mutex();
        private List<Point2f>               _pathes = new List<Point2f>();

        public OnReceiveGmap                ReceiveGmap;
        public OnReceiveAddress             ReceiveAddress;
        public OnError                      Error;

        public bool                         DrawMarker { get; set; }

        public bool                         DrawSelfMarker { get; set; }

        public bool                         DrawPath { get; set; }

        public int Zoom
        {
            get
            {
                return this._zoom;
            }
            set
            {
                this.SetZoom(value);
            }
        }

        public bool Enabled
        {
            get
            {
                return this._cached != null && !(this._cached.Empty());
            }
        }

        public Mat Gmap
        {
            get
            {
                return this._cached;
            }
        }


        public OYOGmap()
        { }

        private void RequestGmap()
        {
            try
            {
                var href = new StringBuilder(string.Format("http://maps.googleapis.com/maps/api/staticmap?center={0},{1}", this._lat, this._lon));
                if (this.DrawMarker)
                {
                    foreach(var point in this._pathes)
                        href.Append(string.Format("&markers=color:blue%7Clabel:OYO%7C{0},{1}", point.X, point.Y));
                }

                if (this.DrawSelfMarker)
                {
                    href.Append(string.Format("&markers=color:blue%7Clabel:OYO%7C{0},{1}", this._lat, this._lon));
                }

                if (this.DrawPath)
                {
                    href.Append("&path=color:0xff0000ff|weight:3");
                    foreach(var point in this._pathes)
                        href.Append(string.Format("|{0},{1}", point.X, point.Y));

                    href.Append(string.Format("|{0},{1}", this._lat, this._lon));
                }

                href.Append(string.Format("&size={0}x{1}", this._width, this._height));
                href.Append(string.Format("&sensor=true&format=png&maptype=roadmap&zoom=18&language=ko&key={0}", GOOGLE_API_KEY));

                var uri = new Uri(href.ToString());
                var httpRequest = HttpWebRequest.Create(uri) as HttpWebRequest;
                var httpResponse = httpRequest.GetResponse() as HttpWebResponse;
                var imageStream = httpResponse.GetResponseStream();

                var mstream = new MemoryStream();
                imageStream.CopyTo(mstream);

this._mutex_gmap.WaitOne();
                this._cached = Cv2.ImDecode(mstream.ToArray(), ImreadModes.AnyColor);
                if(this.ReceiveGmap != null)
                    this.ReceiveGmap.Invoke(this._cached);
this._mutex_gmap.ReleaseMutex();
            }
            catch (Exception e)
            {
                if(this.Error != null)
                    this.Error.Invoke(e.Message);
            }
        }

        private void RequestAddress()
        {
            try
            {
                var url                     = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false&key=AIzaSyDO1LpjNHsEWBWLFdBPc6acJgyujd8ur2s", this._lat, this._lon);
                var xml                     = XElement.Load(url);
                if (xml.Element("status").Value != "OK")
                    return;

                this.ReceiveAddress(xml.Element("result").Element("formatted_address").Value);
            }
            catch (Exception e)
            {
                if(this.Error != null)
                    this.Error(e.Message);
            }
        }


        private void UpdateGmap()
        {
            var requestGmapThread           = new Thread(this.RequestGmap);
            requestGmapThread.Start();
        }

        private void UpdateAddress()
        {
            var requestAddrThread           = new Thread(this.RequestAddress);
            requestAddrThread.Start();
        }

        public void SetPosition(float lat, float lon)
        {
            this._lat = lat;
            this._lon = lon;

            this.UpdateGmap();
            this.UpdateAddress();
        }

        public void SetPosition(Point2f coord)
        {
            this.SetPosition(coord.X, coord.Y);
        }

        public void Resize(int width, int height)
        {
            this._width = width;
            this._height = height;

            this.UpdateGmap();
        }

        public void Resize(Size size)
        {
            this.Resize(size.Width, size.Height);
        }

        public void SetZoom(int value)
        {
            if(value <= 0)
                return;

            this._zoom = value;
            this.UpdateGmap();
        }

        public Point2f Pixel2Coord(int x, int y)
        {
            var parallel_multiplier = Math.Cos(this._lat * Math.PI / 180);
            var degrees_per_pixelX = 360 / Math.Pow(2, this.Zoom + 8);
            var degrees_per_pixelY = 360 / Math.Pow(2, this.Zoom + 8) * parallel_multiplier;
            var lat = (float)(this._lat - degrees_per_pixelY * (y - this._height / 2));
            var lon = (float)(this._lon + degrees_per_pixelX * (x - this._width / 2));

            return new Point2f(lat, lon);
        }

        public Point2f Pixel2Coord(Point point)
        {
            return this.Pixel2Coord(point.X, point.Y);
        }

        public void Move(int x, int y)
        {
            var coord = this.Pixel2Coord(x, y);
            this.SetPosition(coord);
        }

        public static Vector GetDistance(float lat1, float lon1, float lat2, float lon2)
        {
            var delta = new Vector(lon2 - lon1, lat2 - lat1, 0).Normalized;

            // 실제 길이를 구함
            var a = Math.Pow(Math.Sin(delta.y / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(delta.x / 2), 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var distance = (float)(EARTH_RADIUS * c);

            return delta * distance;
        }

        public Vector GetDistance(float lat, float lon)
        {
            return GetDistance(this._lat, this._lon, lat, lon);
        }

        public void AddPath(Point2f point, bool update = false)
        {
            this._pathes.Add(point);
            if(update)
                this.UpdateGmap();
        }

        public void RemoveLastPath(bool update = false)
        {
            this._pathes.RemoveAt(this._pathes.Count - 1);
            if(update)
                this.UpdateGmap();
        }

        public void ClearPath(bool update = false)
        {
            this._pathes.Clear();
            if(update)
                this.UpdateGmap();
        }
    }
}