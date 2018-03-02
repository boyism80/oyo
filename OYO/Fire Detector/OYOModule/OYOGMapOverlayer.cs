using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace oyo
{
    public struct GPS
    {
        public double lat, lon, alt;

        public GPS(double lat, double lon, double alt)
        {
            this.lat = lat;
            this.lon = lon;
            this.alt = alt;
        }

        public GPS(double lat, double lon) : this(lat, lon, 0.0)
        { }
    }

    public enum GmapState
    {
        Collapsed, Expanded, Full,
    }

    public class OYOGMapOverlayer
    {
        public delegate void                OnReceiveGmap(Mat mat);
        public delegate void                OnReceiveAddress(string address);


        public static float                 EXPANDED_WIDTH_RATIO = 0.4f;
        public static float                 EXPANDED_HEIGHT_RATIO = 0.3f;

        // 구글맵 아이콘
        private Mat                         _icon;
        private Mat                         _mask;

        // 구글맵 이미지
        private Mat                         _cachedGmap;

        // 표시영역
        private Mat                         _currentFrame;

        private PictureBox                  _owner;

        private Mutex                       _mutex;

        public event OnReceiveGmap          OnReceiveGmapEvent;
        public event OnReceiveAddress       OnReceiveAddressEvent;

        public GPS GPS { get; set; }

        public GmapState State { get; set; }

        public bool Enabled
        {
            get
            {
                return !this._cachedGmap.Empty();
            }
        }

        public OYOGMapOverlayer(PictureBox owner)
        {
            this._owner                     = owner;
            this._icon                      = Cv2.ImRead("resources/gmap.png", ImreadModes.Unchanged);
            this._mask                      = this._icon.ExtractChannel(3).Threshold(254, 255, ThresholdTypes.Binary);
            this._cachedGmap                      = new Mat();
            this._mutex                     = new Mutex();
            this.GPS                        = new GPS(51.509865, -0.118092);
        }

        private Rect GetDrawingSpace(Mat frame)
        {
            try
            {
                var offset = new OpenCvSharp.Point();
                if (this._owner.SizeMode == PictureBoxSizeMode.CenterImage)
                {
                    if(frame.Width > this._owner.Width)
                        offset.X += (int)((frame.Width - this._owner.Width) / 2.0f);

                    if(frame.Height > this._owner.Height)
                        offset.Y += (int)((frame.Height - this._owner.Height) / 2.0f);
                }

                var minimum = frame.Width > frame.Height ? frame.Height : frame.Width;
                var size = new OpenCvSharp.Size();
                if (this.State == GmapState.Collapsed)
                {
                    offset.X += Math.Min((int)(minimum / 30.0f), (int)(this._icon.Width / 3.0f));
                    offset.Y += Math.Min((int)(minimum / 30.0f), (int)(this._icon.Height / 3.0f));
                    size.Width = Math.Min((int)(minimum / 10.0f), this._icon.Width);
                    size.Height = Math.Min((int)(minimum / 10.0f), this._icon.Height);
                }
                else if (this.State == GmapState.Expanded)
                {
                    if (this._owner.SizeMode == PictureBoxSizeMode.CenterImage)
                    {
                        if (frame.Width > this._owner.Width)
                            size.Width = (int)(this._owner.Width * EXPANDED_WIDTH_RATIO);
                        else
                            size.Width = (int)(frame.Width * EXPANDED_HEIGHT_RATIO);

                        if (frame.Height > this._owner.Height)
                            size.Height = (int)(this._owner.Height * EXPANDED_WIDTH_RATIO);
                        else
                            size.Height = (int)(frame.Height * EXPANDED_HEIGHT_RATIO);
                    }
                    else if (this._owner.SizeMode == PictureBoxSizeMode.Zoom)
                    {
                        if (frame.Width > frame.Height)
                        {
                            size.Width = (int)(this._owner.Width * EXPANDED_WIDTH_RATIO);
                            size.Height = (int)(frame.Height * EXPANDED_HEIGHT_RATIO);
                        }
                        else
                        {
                            size.Width = (int)(frame.Width * EXPANDED_WIDTH_RATIO);
                            size.Height = (int)(this._owner.Height * EXPANDED_HEIGHT_RATIO);
                        }
                    }
                    else
                    {
                        size.Width = (int)(this._owner.Width * EXPANDED_WIDTH_RATIO);
                        size.Height = (int)(this._owner.Height * EXPANDED_HEIGHT_RATIO);
                    }
                }
                else
                {
                    size.Width = frame.Width;
                    size.Height = frame.Height;
                }

                return new Rect(offset, size);
            }
            catch (Exception)
            {
                return Rect.Empty;
            }
        }

        public Mat Overlay(Mat frame)
        {
            if(this.State != GmapState.Collapsed && this._cachedGmap.Empty())
                return frame;

            var area = this.GetDrawingSpace(frame);
            if (this.State == GmapState.Collapsed)
            {
                frame = frame.CvtColor(ColorConversionCodes.BGR2BGRA);
                var icon = this._icon.Resize(area.Size);
                var mask = this._mask.Resize(area.Size);
                icon.CopyTo(new Mat(frame, area), mask);
            }
            else if (this.State == GmapState.Expanded)
            {
                var gmap = this._cachedGmap.Resize(area.Size);
                gmap.CopyTo(new Mat(frame, area));
            }
            else
            {
                var gmap = this._cachedGmap.Resize(area.Size);
                frame = gmap;
            }

            this._currentFrame = frame;
            return frame;
        }

        public Rectangle ActiveArea()
        {
            try
            {
                if(this._currentFrame == null)
                    throw new Exception();

                var area = this.GetDrawingSpace(this._currentFrame);
                var ret = new Rectangle(area.X, area.Y, area.Width, area.Height);
                if (this._owner.SizeMode == PictureBoxSizeMode.CenterImage)
                {
                    ret.X += (int)((this._owner.Width - this._currentFrame.Width) / 2.0f);
                    ret.Y += (int)((this._owner.Height - this._currentFrame.Height) / 2.0f);
                }
                else if (this._owner.SizeMode == PictureBoxSizeMode.Zoom)
                {
                    if (area.Width > area.Height)
                    {
                        ret.Y += (int)((this._owner.Height - this._currentFrame.Height) / 2.0f);
                    }
                    else
                    {
                        ret.X += (int)((this._owner.Width - this._currentFrame.Width) / 2.0f);
                    }
                }
                else
                {

                }

                return ret;
            }
            catch (Exception)
            {
                return Rectangle.Empty;
            }
        }

        private void RequestGmap()
        {
            try
            {
                if(this.OnReceiveGmapEvent == null)
                    return;

                if (this.State == GmapState.Collapsed)
                    throw new Exception();

                if(this._currentFrame == null)
                    throw new Exception();

                var area = this.GetDrawingSpace(this._currentFrame);

                var uri = new Uri(string.Format("http://maps.googleapis.com/maps/api/staticmap?center={0},{1}&markers=color:blue%7Clabel:OYO%7C{2},{3}&size={4}x{5}&sensor=true&format=png&maptype=roadmap&zoom=18&language=ko&key=AIzaSyDO1LpjNHsEWBWLFdBPc6acJgyujd8ur2s", this.GPS.lat, this.GPS.lon, this.GPS.lat, this.GPS.lon, area.Width, area.Height));
                var httpRequest = (HttpWebRequest)HttpWebRequest.Create(uri);
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                var imageStream = httpResponse.GetResponseStream();

                var mstream = new MemoryStream();
                imageStream.CopyTo(mstream);

this._mutex.WaitOne();
                this._cachedGmap = Cv2.ImDecode(mstream.ToArray(), ImreadModes.AnyColor);
this._mutex.ReleaseMutex();

                this.OnReceiveGmapEvent.Invoke(this._cachedGmap);
            }
            catch (Exception)
            {
            }
        }

        private void RequestAddress()
        {
            try
            {
                var url = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false&key=AIzaSyDO1LpjNHsEWBWLFdBPc6acJgyujd8ur2s", this.GPS.lat, this.GPS.lon);
                var xml = XElement.Load(url);
                if (xml.Element("status").Value != "OK")
                    return;

                this.OnReceiveAddressEvent(xml.Element("result").Element("formatted_address").Value);
            }
            catch (Exception)
            {
            }
        }

        public void Update()
        {
            var requestGmapThread = new Thread(this.RequestGmap);
            requestGmapThread.Start();

            var requestAddressThread = new Thread(this.RequestAddress);
            requestAddressThread.Start();
        }

        public void Update(GPS gps)
        {
            this.GPS = gps;
            this.Update();
        }
    }
}