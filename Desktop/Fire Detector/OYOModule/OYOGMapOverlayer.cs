using OpenCvSharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace oyo
{
    public struct GPS
    {
        public double lat, lon, alt;

        public bool Valid
        {
            get
            {
                return this.lat != 500 && this.lon != 500;
            }
        }

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

    public class OYOGMapOverlayer : OYOGmap
    {
        public static float                 EXPANDED_WIDTH_RATIO = 0.4f;
        public static float                 EXPANDED_HEIGHT_RATIO = 0.3f;

        // 구글맵 아이콘
        private Mat                         _icon;
        private Mat                         _mask;

        // 표시영역
        private Mat                         _currentFrame;

        private PictureBox                  _owner;

        public GPS GPS { get; set; }

        public GmapState State { get; set; }

        public OYOGMapOverlayer(PictureBox owner)
        {
            this._owner                     = owner;
            this._icon                      = Cv2.ImRead("resources/gmap.png", ImreadModes.Unchanged);
            this._mask                      = this._icon.ExtractChannel(3).Threshold(254, 255, ThresholdTypes.Binary);
        }

        public OpenCvSharp.Point GetGmapPadding(Mat frame)
        {
            var padding                     = new OpenCvSharp.Point();
            var minimum                     = frame.Width > frame.Height ? frame.Height : frame.Width;
            if (this.State == GmapState.Collapsed)
            {
                padding.X                  += Math.Min((int)(minimum / 30.0f), (int)(this._icon.Width / 3.0f));
                padding.Y                  += Math.Min((int)(minimum / 30.0f), (int)(this._icon.Height / 3.0f));
            }

            return padding;
        }

        private OpenCvSharp.Point GetGmapOffset(Mat frame, bool padding = true)
        {
            var offset                      = new OpenCvSharp.Point();
            if (this._owner.SizeMode == PictureBoxSizeMode.CenterImage)
            {
                if(frame.Width > this._owner.Width)
                    offset.X               += (int)((frame.Width - this._owner.Width) / 2.0f);

                if(frame.Height > this._owner.Height)
                    offset.Y               += (int)((frame.Height - this._owner.Height) / 2.0f);
            }

            if (padding)
                offset                     += this.GetGmapPadding(frame);

            return offset;
        }

        private OpenCvSharp.Size GetGmapSize(Mat frame)
        {
            var minimum                     = frame.Width > frame.Height ? frame.Height : frame.Width;
            var size                        = new OpenCvSharp.Size();
            if (this.State == GmapState.Collapsed)
            {
                size.Width                  = Math.Min((int)(minimum / 10.0f), this._icon.Width);
                size.Height                 = Math.Min((int)(minimum / 10.0f), this._icon.Height);
            }
            else if (this.State == GmapState.Expanded)
            {
                if (this._owner.SizeMode == PictureBoxSizeMode.CenterImage)
                {
                    if (frame.Width > this._owner.Width)
                        size.Width          = (int)(this._owner.Width * EXPANDED_WIDTH_RATIO);
                    else
                        size.Width          = (int)(frame.Width * EXPANDED_HEIGHT_RATIO);

                    if (frame.Height > this._owner.Height)
                        size.Height         = (int)(this._owner.Height * EXPANDED_WIDTH_RATIO);
                    else
                        size.Height         = (int)(frame.Height * EXPANDED_HEIGHT_RATIO);
                }
                else if (this._owner.SizeMode == PictureBoxSizeMode.Zoom)
                {
                    if (frame.Width > frame.Height)
                    {
                        size.Width          = (int)(this._owner.Width * EXPANDED_WIDTH_RATIO);
                        size.Height         = (int)(frame.Height * EXPANDED_HEIGHT_RATIO);
                    }
                    else
                    {
                        size.Width          = (int)(frame.Width * EXPANDED_WIDTH_RATIO);
                        size.Height         = (int)(this._owner.Height * EXPANDED_HEIGHT_RATIO);
                    }
                }
                else
                {
                    size.Width              = (int)(this._owner.Width * EXPANDED_WIDTH_RATIO);
                    size.Height             = (int)(this._owner.Height * EXPANDED_HEIGHT_RATIO);
                }
            }
            else
            {
                size.Width                  = frame.Width;
                size.Height                 = frame.Height;
            }

            return size;
        }

        private Rect GetDrawingSpace(Mat frame)
        {
            try
            {
                var offset                  = this.GetGmapOffset(frame);
                var size                    = this.GetGmapSize(frame);
                return new Rect(this.GetGmapOffset(frame), this.GetGmapSize(frame));
            }
            catch (Exception)
            {
                return Rect.Empty;
            }
        }

        public Mat Overlay(Mat frame)
        {
            return this.Overlay(frame, this.GetGmapOffset(frame));
        }

        public Mat Overlay(Mat frame, OpenCvSharp.Point offset)
        {
            if(this.State != GmapState.Collapsed && this.Gmap.Empty())
                return frame;

            var area                        = new OpenCvSharp.Rect(offset, this.GetGmapSize(frame));
            if (this.State == GmapState.Collapsed)
            {
                frame                       = frame.CvtColor(ColorConversionCodes.BGR2BGRA);
                var icon                    = this._icon.Resize(area.Size);
                var mask                    = this._mask.Resize(area.Size);
                icon.CopyTo(new Mat(frame, area), mask);
                frame                       = frame.CvtColor(ColorConversionCodes.BGRA2BGR);
            }
            else if (this.State == GmapState.Expanded)
            {
                var gmap                    = this.Gmap.Resize(area.Size);
                gmap.CopyTo(new Mat(frame, area));
            }
            else
            {
                var gmap                    = this.Gmap.Resize(area.Size);
                frame                       = gmap;
            }

            this._currentFrame              = frame;
            return this._currentFrame;
        }

        public Rectangle ActiveArea()
        {
            try
            {
                if(this._currentFrame == null)
                    throw new Exception();

                var area                    = this.GetDrawingSpace(this._currentFrame);
                var ret                     = new Rectangle(area.X, area.Y, area.Width, area.Height);
                if (this._owner.SizeMode == PictureBoxSizeMode.CenterImage)
                {
                    ret.X                 += (int)((this._owner.Width - this._currentFrame.Width) / 2.0f);
                    ret.Y                 += (int)((this._owner.Height - this._currentFrame.Height) / 2.0f);
                }
                else if (this._owner.SizeMode == PictureBoxSizeMode.Zoom)
                {
                    if (this._currentFrame.Width > this._currentFrame.Height)
                    {
                        ret.Y             += (int)((this._owner.Height - this._currentFrame.Height) / 2.0f);
                    }
                    else
                    {
                        ret.X             += (int)((this._owner.Width - this._currentFrame.Width) / 2.0f);
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

        public void Refresh()
        {
            var size = this.GetDrawingSpace(this._currentFrame);
            this.Resize(size.Width, size.Height);
        }
    }
}