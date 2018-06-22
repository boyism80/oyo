using Leap;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace oyo
{
    public class OYOGmapElement
    {
        public Color Color { get; set; }

        public List<GCS> Points { get; private set; }

        protected OYOGmapElement(params GCS[] points)
        {
            this.Color = Color.FromArgb(128, Color.Red);
            this.Points = new List<GCS>(points);
        }

        protected OYOGmapElement(Color color, params GCS[] points)
        {
            this.Color = color;
            this.Points = new List<GCS>(points);
        }
    }

    public class OYOGmapPolygon : OYOGmapPath
    {
        public Color FillColor { get; private set; }

        public OYOGmapPolygon(params GCS[] points) : base(points)
        {
            this.FillColor = Color.FromArgb(128, Color.Red);
        }

        public OYOGmapPolygon(int weight, Color fillcolor, Color color, params GCS[] points) : base(weight, color, points)
        {
            this.FillColor = fillcolor;
        }
    }

    public class OYOGmapMarker : OYOGmapElement
    {
        public string Label { get; private set; }

        public OYOGmapMarker(params GCS[] points) : base(points)
        {
            this.Label = "X";
        }

        public OYOGmapMarker(string label, Color color, params GCS[] points) : base(color, points)
        {
            this.Label = label;
        }
    }

    public class OYOGmapPath : OYOGmapElement
    {
        public int Weight { get; set; }

        public OYOGmapPath(params GCS[] points) : base(points)
        {
            this.Weight = 3;
        }

        public OYOGmapPath(int weight, Color color, params GCS[] points) : base(color, points)
        {
            this.Weight = weight;
        }
    }

    public class GCS
    {
        public double lat, lon;

        public bool IsValid
        {
            get
            {
                return this.lat != 0 && this.lat != 500 &&
                    this.lon != 0 && this.lon != 500;
            }
        }

        public GCS()
        {
            this.lat = 0;
            this.lon = 0;
        }

        public GCS(double lat, double lon)
        {
            this.lat = lat;
            this.lon = lon;
        }
    }

    public class OYOGmap
    {
        private static string               GOOGLE_API_KEY = "AIzaSyDO1LpjNHsEWBWLFdBPc6acJgyujd8ur2s";
        public static double                EARTH_RADIUS = 6373.0f;

        public delegate void                OnReceiveGmap(Mat mat);
        public delegate void                OnReceiveAddress(string name, string addr);
        public delegate void                OnReceiveGmapError(string message);
        public delegate void                OnReceiveAddressError(string name, string message);

        private GCS                         _gcs = new GCS();
        private int                         _zoom = 18;
        private Mat                         _cached;
        private Mutex                       _mutex_gmap = new Mutex();
        private Mutex                       _mutex_addr = new Mutex();
        private Dictionary<string, OYOGmapPath>     _path = new Dictionary<string, OYOGmapPath>();
        private Dictionary<string, OYOGmapMarker>   _marker = new Dictionary<string, OYOGmapMarker>();
        private Dictionary<string, OYOGmapPolygon>  _polygons = new Dictionary<string, OYOGmapPolygon>();

        public OnReceiveGmap                ReceiveGmap;
        public OnReceiveAddress             ReceiveAddress;
        public OnReceiveGmapError           ReceiveGmapError;
        public OnReceiveAddressError        ReceiveAddressError;

        public int                          Width { get; private set; }

        public int                          Height { get; private set; }

        public bool                         DrawMarker { get; set; }

        public bool                         DrawSelfMarker { get; set; }

        public bool                         DrawPath { get; set; }

        public bool                         DrawPolygon { get; set; }

        public int Zoom
        {
            get
            {
                return this._zoom;
            }
            set
            {
                this.SetZoom(value, true);
            }
        }

        public bool AutoZoom { get; set; }

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
        {
            this.Width = 480;
            this.Height = 320;
        }

        private void RequestGmapThreadRoutine()
        {
            try
            {
                var href = new StringBuilder(string.Format("http://maps.googleapis.com/maps/api/staticmap?"));
                if (this._gcs.IsValid)
                {
                    href.Append(string.Format("center={0},{1}", this._gcs.lat, this._gcs.lon));
                }

                if (this.DrawMarker)
                {
                    foreach (var key in this._marker.Keys)
                    {
                        if(this._marker[key].Points.Count == 0)
                            continue;


                        var color = this._marker[key].Color;
                        href.Append(string.Format("&markers=color:0x{0}{1}{2}{3}|label:{4}", color.R.ToString("X2"),
                            color.G.ToString("X2"),
                            color.B.ToString("X2"),
                            color.A.ToString("X2"),
                            this._marker[key].Label));

                        foreach(var gcs in this._marker[key].Points)
                            href.Append(string.Format("|{0},{1}", gcs.lat, gcs.lon));
                    }
                }

                if (this.DrawSelfMarker)
                {
                    href.Append(string.Format("&markers=color:blue|label:OYO|{0},{1}", this._gcs.lat, this._gcs.lon));
                }

                if (this.DrawPolygon)
                {
                    foreach (var key in this._polygons.Keys)
                    {
                        if (this._polygons[key].Points.Count < 3)
                            continue;
                        
                        var color = this._polygons[key].Color;
                        var fillcolor = this._polygons[key].FillColor;
                        href.Append(string.Format("&path=color:0x{0}{1}{2}{3}|weight:{4}|fillcolor:0x{5}{6}{7}{8}", color.R.ToString("X2"),
                            color.G.ToString("X2"),
                            color.B.ToString("X2"),
                            color.A.ToString("X2"),
                            this._polygons[key].Weight,
                            fillcolor.R.ToString("X2"),
                            fillcolor.G.ToString("X2"),
                            fillcolor.B.ToString("X2"),
                            fillcolor.A.ToString("X2")));
                        foreach(var gcs in this._polygons[key].Points)
                            href.Append(string.Format("|{0},{1}", gcs.lat, gcs.lon));
                    }
                }

                if (this.DrawPath)
                {
                    foreach (var key in this._path.Keys)
                    {
                        var color = this._path[key].Color;
                        href.Append(string.Format("&path=color:0x{0}{1}{2}{3}|weight:{4}", color.R.ToString("X2"),
                            color.G.ToString("X2"),
                            color.B.ToString("X2"),
                            color.A.ToString("X2"),
                            this._path[key].Weight));

                        foreach(var gcs in this._path[key].Points)
                            href.Append(string.Format("|{0},{1}", gcs.lat, gcs.lon));
                    }
                }

                href.Append(string.Format("&size={0}x{1}", this.Width, this.Height));
                href.Append("&sensor=true&format=png&maptype=roadmap");
                if(this.AutoZoom == false)
                    href.Append(string.Format("&zoom={0}", this.Zoom));
                href.Append(string.Format("&language=ko&key={0}", GOOGLE_API_KEY));

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
                if(this.ReceiveGmapError != null)
                    this.ReceiveGmapError.Invoke(e.Message);
            }
        }

        private void RequestAddressThreadRoutine(object param)
        {
            var args                        = param as object[];
            var name                        = args[0] as string;
            var gcs                         = args[1] as GCS;
            try
            {
                var url                     = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false&key={2}", gcs.lat, gcs.lon, GOOGLE_API_KEY);
                var xml                     = XElement.Load(url);
                if (xml.Element("status").Value != "OK")
                    throw new Exception("Cannot find address");

                this.ReceiveAddress(name, xml.Element("result").Element("formatted_address").Value);
            }
            catch (Exception e)
            {
                if(this.ReceiveAddressError != null)
                    this.ReceiveAddressError(name, e.Message);
            }
        }


        public void RequestGmap()
        {
            var requestGmapThread           = new Thread(this.RequestGmapThreadRoutine);
            requestGmapThread.Start();
        }

        public void RequestAddress(string name, GCS gcs)
        {
            var requestAddrThread           = new Thread(new ParameterizedThreadStart(this.RequestAddressThreadRoutine));
            requestAddrThread.Start(new object[] { name, gcs });
        }

        public void RequestAddress(string name, double lat, double lon)
        {
            this.RequestAddress(name, new GCS(lat, lon));
        }

        public void SetPosition(double lat, double lon, bool update = false)
        {
            this._gcs.lat = lat;
            this._gcs.lon = lon;

            if (update)
                this.RequestGmap();
        }

        public void SetPosition(GCS coord, bool update = false)
        {
            this.SetPosition(coord.lat, coord.lon, update);
        }

        public void Resize(int width, int height, bool update = false)
        {
            this.Width = width;
            this.Height = height;

            if(update)
                this.RequestGmap();
        }

        public void Resize(System.Drawing.Size size)
        {
            this.Resize(size.Width, size.Height);
        }

        public void SetZoom(int value, bool update = false)
        {
            if(value <= 0)
                return;

            this._zoom = value;
            if(update)
                this.RequestGmap();
        }

        public GCS Pixel2Coord(int x, int y)
        {
            var parallel_multiplier = Math.Cos(this._gcs.lat * Math.PI / 180);
            var degrees_per_pixelX = 360 / Math.Pow(2, this.Zoom + 8);
            var degrees_per_pixelY = 360 / Math.Pow(2, this.Zoom + 8) * parallel_multiplier;
            var lat = (double)(this._gcs.lat - degrees_per_pixelY * (y - this.Height / 2));
            var lon = (double)(this._gcs.lon + degrees_per_pixelX * (x - this.Width / 2));

            return new GCS(lat, lon);
        }

        public GCS Pixel2Coord(System.Drawing.Point point)
        {
            return this.Pixel2Coord(point.X, point.Y);
        }

        public void SetPosition(int pixelX, int pixelY, bool update = false)
        {
            var coord = this.Pixel2Coord(pixelX, pixelY);
            this.SetPosition(coord, update);
        }

        public void SetPosition(System.Drawing.Point pixel, bool update = false)
        {
            this.SetPosition(pixel.Y, pixel.X, update);
        }

        public static OYOVector GetVector(double lat1, double lon1, double lat2, double lon2)
        {
            var delta = new OYOVector(lon2 - lon1, lat2 - lat1).Normalized;
            return delta * GetDistance(lat1, lon1, lat2, lon2);
        }

        public static OYOVector GetVector(GCS gcs1, GCS gcs2)
        {
            return GetVector(gcs1.lat, gcs1.lon, gcs2.lat, gcs2.lon);
        }

        public static double GetDistance(double lat1, double lon1, double lat2, double lon2)
        {
            var lat1_rad        = Math.PI * lat1 / 180;
            var lat2_rad        = Math.PI * lat2 / 180;
            var theta           = lon1 - lon2;
            var theta_rad       = Math.PI * theta / 180;
            var distance        = Math.Sin(lat1_rad) * Math.Sin(lat2_rad) + Math.Cos(lat1_rad) * Math.Cos(lat2_rad) * Math.Cos(theta_rad);
            distance            = Math.Acos(distance);
            distance            = distance * 180 / Math.PI;
            distance            = distance * 60 * 1.1515;

            return distance * 1.609344;    // km
        }

        public static double GetDistance(GCS begin, GCS end)
        {
            return GetDistance(begin.lat, begin.lon, end.lat, end.lon);
        }

        public double GetDistance(double lat, double lon)
        {
            return GetDistance(this._gcs.lat, this._gcs.lon, lat, lon);
        }

        public void AddMarker(string name, OYOGmapMarker marker, bool update = false)
        {
            this._marker[name] = marker;
            if(update)
                this.RequestGmap();
        }

        public void ClearMarkers(bool update = false)
        {
            this._marker.Clear();
            if(update)
                this.RequestGmap();
        }

        public void AddPath(string name, OYOGmapPath path, bool update = false)
        {
            this._path[name] = path;
            if(update)
                this.RequestGmap();
        }

        public void ClearPath(bool update = false)
        {
            this._path.Clear();
            if(update)
                this.RequestGmap();
        }

        public void AddPolygon(string name, OYOGmapPolygon polygon, bool update = false)
        {
            this._polygons[name] = polygon;
            if(update)
                this.RequestGmap();
        }

        public void RemovePolygon(string name)
        {
            this._polygons.Remove(name);
        }
    }
}