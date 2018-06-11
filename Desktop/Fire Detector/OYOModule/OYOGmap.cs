using OpenCvSharp;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Xml.Linq;

namespace oyo
{
    public class OYOGmap
    {
        public delegate void                OnReceiveGmap(Mat mat);
        public delegate void                OnReceiveAddress(string addr);
        public delegate void                OnError(string message);

        private float                       _lat = 500, _lon = 500;
        private int                         _width = 480, _height = 320;
        private int                         _zoom = 18;
        private Mat                         _cached;
        private Mutex                       _mutex_gmap = new Mutex();
        private Mutex                       _mutex_addr = new Mutex();

        public OnReceiveGmap                ReceiveGmap;
        public OnReceiveAddress             ReceiveAddress;
        public OnError                      Error;

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
                var uri = new Uri(string.Format("http://maps.googleapis.com/maps/api/staticmap?center={0},{1}&markers=color:blue%7Clabel:OYO%7C{2},{3}&size={4}x{5}&sensor=true&format=png&maptype=roadmap&zoom=18&language=ko&key=AIzaSyDO1LpjNHsEWBWLFdBPc6acJgyujd8ur2s", this._lat, this._lon, this._lat, this._lon, this._width, this._height));
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
            var parallelMultiplier = Math.Cos(this._lat * Math.PI / 180);
            var degreesPerPixelX = 360 / Math.Pow(2, this.Zoom + 8);
            var degreesPerPixelY = 360 / Math.Pow(2, this.Zoom + 8) * parallelMultiplier;
            var lat = (float)(this._lat - degreesPerPixelY * (y - this._height / 2));
            var lon = (float)(this._lon + degreesPerPixelX * (x - this._width / 2));

            return new Point2f(lat, lon);
        }

        public void Move(int x, int y)
        {
            var coord = this.Pixel2Coord(x, y);
            this.SetPosition(coord);
        }
    }
}