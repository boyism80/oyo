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

        protected OYOGmapElement()
        {
            this.Color = Color.FromArgb(128, Color.Red);
            this.Points = new List<GCS>();
        }

        protected OYOGmapElement(Color color)
        {
            this.Color = color;
            this.Points = new List<GCS>();
        }
    }

    public class OYOGmapPolygon : OYOGmapPath
    {
        public Color FillColor { get; private set; }

        public OYOGmapPolygon()
        {
            this.FillColor = Color.FromArgb(128, Color.Red);
        }

        public OYOGmapPolygon(int weight, Color fillcolor, Color color) : base(weight, color)
        {
            this.FillColor = fillcolor;
        }
    }

    public class OYOGmapMarker : OYOGmapElement
    {
        public string Label { get; private set; }

        public OYOGmapMarker()
        {
            this.Label = "X";
        }

        public OYOGmapMarker(string label, Color color) : base(color)
        {
            this.Label = label;
        }
    }

    public class OYOGmapPath : OYOGmapElement
    {
        public int Weight { get; set; }

        public OYOGmapPath()
        {
            this.Weight = 3;
        }

        public OYOGmapPath(int weight, Color color) : base(color)
        {
            this.Weight = weight;
        }
    }

    public class GCS
    {
        public float lat, lon;

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

        public GCS(float lat, float lon)
        {
            this.lat = lat;
            this.lon = lon;
        }
    }

    public class OYOGmap
    {
        private static string               GOOGLE_API_KEY = "AIzaSyDO1LpjNHsEWBWLFdBPc6acJgyujd8ur2s";
        public static float                 EARTH_RADIUS = 6371.0f;

        public delegate void                OnReceiveGmap(Mat mat);
        public delegate void                OnReceiveAddress(string addr);
        public delegate void                OnError(string message);

        private GCS                         _gcs = new GCS();
        private int                         _zoom = 18;
        private Mat                         _cached;
        private Mutex                       _mutex_gmap = new Mutex();
        private Mutex                       _mutex_addr = new Mutex();
        private Dictionary<string, OYOGmapPath> _path = new Dictionary<string, OYOGmapPath>();
        private Dictionary<string, OYOGmapMarker> _marker = new Dictionary<string, OYOGmapMarker>();
        private Dictionary<string, OYOGmapPolygon>  _polygons = new Dictionary<string, OYOGmapPolygon>();

        public OnReceiveGmap                ReceiveGmap;
        public OnReceiveAddress             ReceiveAddress;
        public OnError                      Error;

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

        private void RequestGmap()
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
                    

                    //if(this._gcs.IsValid)
                    //    href.Append(string.Format("|{0},{1}", this._gcs.lat, this._gcs.lon));

                    //foreach(var gcs in this._pathes)
                    //    href.Append(string.Format("|{0},{1}", gcs.lat, gcs.lon));
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
                if(this.Error != null)
                    this.Error.Invoke(e.Message);
            }
        }

        private void RequestAddress()
        {
            try
            {
                var url                     = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false&key=AIzaSyDO1LpjNHsEWBWLFdBPc6acJgyujd8ur2s", this._gcs.lat, this._gcs.lon);
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


        public void UpdateGmap()
        {
            var requestGmapThread           = new Thread(this.RequestGmap);
            requestGmapThread.Start();
        }

        public void UpdateAddress()
        {
            var requestAddrThread           = new Thread(this.RequestAddress);
            requestAddrThread.Start();
        }

        public void SetPosition(float lat, float lon, bool update = false)
        {
            this._gcs.lat = lat;
            this._gcs.lon = lon;

            if (update)
            {
                this.UpdateGmap();
                this.UpdateAddress();
            }
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
                this.UpdateGmap();
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
                this.UpdateGmap();
        }

        public GCS Pixel2Coord(int x, int y)
        {
            var parallel_multiplier = Math.Cos(this._gcs.lat * Math.PI / 180);
            var degrees_per_pixelX = 360 / Math.Pow(2, this.Zoom + 8);
            var degrees_per_pixelY = 360 / Math.Pow(2, this.Zoom + 8) * parallel_multiplier;
            var lat = (float)(this._gcs.lat - degrees_per_pixelY * (y - this.Height / 2));
            var lon = (float)(this._gcs.lon + degrees_per_pixelX * (x - this.Width / 2));

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

        public static Vector GetVector(float lat1, float lon1, float lat2, float lon2)
        {
            var delta = new Vector(lon2 - lon1, lat2 - lat1, 0).Normalized;

            return delta * GetDistance(lat1, lon1, lat2, lon2);
        }

        public static float GetDistance(float lat1, float lon1, float lat2, float lon2)
        {
            var rlat1 = Math.PI * lat1 / 180;
            var rlat2 = Math.PI * lat2 / 180;
            var theta = lon1 - lon2;
            var rtheta = Math.PI * theta / 180;
            var distance = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta);
            distance = Math.Acos(distance);
            distance = distance * 180 / Math.PI;
            distance = distance * 60 * 1.1515;

            return (float)distance * 1.609344f;
        }

        public static float GetDistance(GCS begin, GCS end)
        {
            return GetDistance(begin.lat, begin.lon, end.lat, end.lon);
        }

        public float GetDistance(float lat, float lon)
        {
            return GetDistance(this._gcs.lat, this._gcs.lon, lat, lon);
        }

        public void AddMarker(string name, OYOGmapMarker marker, bool update = false)
        {
            this._marker[name] = marker;
            if(update)
                this.UpdateGmap();
        }

        public void ClearMarkers(bool update = false)
        {
            this._marker.Clear();
            if(update)
                this.UpdateGmap();
        }

        public void AddPath(string name, OYOGmapPath path, bool update = false)
        {
            this._path[name] = path;
            if(update)
                this.UpdateGmap();
        }

        public void ClearPath(bool update = false)
        {
            this._path.Clear();
            if(update)
                this.UpdateGmap();
        }

        public void AddPolygon(string name, OYOGmapPolygon polygon, bool update = false)
        {
            this._polygons[name] = polygon;
            if(update)
                this.UpdateGmap();
        }

        public void RemovePolygon(string name)
        {
            this._polygons.Remove(name);
        }
    }
}