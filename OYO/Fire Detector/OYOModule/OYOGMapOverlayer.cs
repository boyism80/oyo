using OpenCvSharp;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

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
        public static float                 EXPANDED_WIDTH_RATIO = 0.4f;
        public static float                 EXPANDED_HEIGHT_RATIO = 0.3f;

        // 구글맵 아이콘
        private Mat _icon;
        private Mat _mask;

        // 구글맵 이미지
        private Mat _gmap;

        // 표시영역
        private Rect _area;
        private Mat _currentFrame;


        // 구글맵 테스트
        private Thread _gmapUpdateThread;
        public bool Running { get; set; }


        private PictureBox _owner;
        private Mutex _mutex;

        public GPS GPS { get; set; }

        public GmapState State { get; set; }

        public OYOGMapOverlayer(PictureBox owner)
        {
            this._owner                     = owner;
            this._icon                      = Cv2.ImRead("resources/gmap.png", ImreadModes.Unchanged);
            this._mask                      = this._icon.ExtractChannel(3).Threshold(254, 255, ThresholdTypes.Binary);
            this._gmap                      = new Mat();
            this._mutex                     = new Mutex();
            this.GPS                        = new GPS(51.509865, -0.118092);
            
            this.Running = true;
            this._gmapUpdateThread = new Thread(this.gmapUpdateThreadRoutine);
            this._gmapUpdateThread.Start();
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

        public Mat Overlay(Mat frame, OpenCvSharp.Point offset)
        {
            this._area = this.GetDrawingSpace(frame);
            if (this.State == GmapState.Collapsed)
            {
                frame = frame.CvtColor(ColorConversionCodes.BGR2BGRA);
                var icon = this._icon.Resize(this._area.Size);
                var mask = this._mask.Resize(this._area.Size);
                icon.CopyTo(new Mat(frame, this._area), mask);
            }
            else if (this.State == GmapState.Expanded)
            {
                var gmap = this._gmap.Resize(this._area.Size);
                gmap.CopyTo(new Mat(frame, this._area));
            }
            else
            {
                var gmap = this._gmap.Resize(this._area.Size);
                frame = gmap;
            }

            this._currentFrame = frame;
            this.Update();
            return frame;
        }

        public Rectangle ActiveArea()
        {
            try
            {
                var ret = new Rectangle(this._area.X, this._area.Y, this._area.Width, this._area.Height);
                if (this._owner.SizeMode == PictureBoxSizeMode.CenterImage)
                {
                    ret.X += (int)((this._owner.Width - this._currentFrame.Width) / 2.0f);
                    ret.Y += (int)((this._owner.Height - this._currentFrame.Height) / 2.0f);
                }
                else if (this._owner.SizeMode == PictureBoxSizeMode.Zoom)
                {
                    if (this._area.Width > this._area.Height)
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

        private void gmapUpdateThreadRoutine()
        {
            while (this.Running)
            {
                this.Update();
                Thread.Sleep(1000);
            }
        }

        private void RequestGmap()
        {
            try
            {
                if (this.State == GmapState.Collapsed)
                    throw new Exception();

                var uri = new Uri(string.Format("http://maps.googleapis.com/maps/api/staticmap?center={0},{1}&markers=color:blue%7Clabel:OYO%7C{2},{3}&size={4}x{5}&sensor=true&format=png&maptype=roadmap&zoom=18&language=ko&key=AIzaSyDO1LpjNHsEWBWLFdBPc6acJgyujd8ur2s", this.GPS.lat, this.GPS.lon, this.GPS.lat, this.GPS.lon, this._area.Width, this._area.Height));
                var httpRequest = (HttpWebRequest)HttpWebRequest.Create(uri);
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                var imageStream = httpResponse.GetResponseStream();

                var mstream = new MemoryStream();
                imageStream.CopyTo(mstream);

this._mutex.WaitOne();
                this._gmap = Cv2.ImDecode(mstream.ToArray(), ImreadModes.AnyColor);
this._mutex.ReleaseMutex();
            }
            catch (Exception e)
            {
            }
        }

        public void Update()
        {
            var thread = new Thread(this.RequestGmap);
            thread.Start();
        }
    }
}