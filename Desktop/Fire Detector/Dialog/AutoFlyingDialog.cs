using OpenCvSharp;
using oyo;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Fire_Detector.Dialog
{
    public partial class AutoFlyingDialog : Form
    {
        public static float             REFRESH_DRAG_TIME = 0.1f;

        private System.Drawing.Point    _begin, _end;

        private OYOGmap                 _gmap = new OYOGmap();
        private OYODrag                 _drag = new OYODrag();
        private Stopwatch               _dragStopwatch = new Stopwatch();

        public GCS[]                    Points { get; private set; }
        public GCS                      Begin { get; private set; }
        public GCS                      End { get; private set; }

        public AutoFlyingDialog(GCS center)
        {
            InitializeComponent();

            this._gmap.SetPosition(center);
            this._gmap.Resize(this.gmapBox.Size);
            this._gmap.DrawPolygon      = true;
            this._gmap.ReceiveGmap      += this.OnReceiveGmap;

            this._dragStopwatch.Start();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.Points == null || this.Points.Length == 0)
                    throw new Exception("영억을 설정해야 합니다.");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception exc)
            {
                var dialog = new MessageDialog(exc.Message);
                dialog.ShowDialog(this);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Points = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AutoFlyingDialog_Load(object sender, EventArgs e)
        {
            this._gmap.Resize(this.gmapBox.Width, this.gmapBox.Height, true);
        }

        private void OnReceiveGmap(Mat map)
        {
            this.gmapBox.Invoke(new MethodInvoker(delegate () {

                this.gmapBox.Image = Image.FromStream(new MemoryStream(map.ToBytes(".jpg")));
            } ));
        }

        private void gmapBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
                return;

            this._drag.Begin(e.X, e.Y);
        }

        private void gmapBox_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this._gmap.Zoom += (e.Delta / 120);
        }

        private void gmapBox_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
                return;

            var moved = System.Drawing.Point.Empty;
            if(this._drag.End(e.X, e.Y, out moved) == false)
                return;

            if (moved == System.Drawing.Point.Empty)
            {
                if (this._begin.IsEmpty || !this._end.IsEmpty)
                {
                    this._gmap.RemovePolygon("area");

                    this._begin         = new System.Drawing.Point(e.X, e.Y);
                    this._end           = System.Drawing.Point.Empty;

                    var path            = new OYOGmapPath(this._gmap.Pixel2Coord(this._begin));

                    this._gmap.DrawMarker = true;
                    this._gmap.AddPath("begin", path);
                    this._gmap.RequestGmap();
                }
                else
                {
                    this._gmap.DrawMarker = false;
                    this._gmap.ClearPath();

                    this._end           = new System.Drawing.Point(e.X, e.Y);
                    var left_bot        = new System.Drawing.Point(this._begin.X, this._end.Y);
                    var right_top       = new System.Drawing.Point(this._end.X, this._begin.Y);

                    var polygon         = new OYOGmapPolygon(3, Color.FromArgb(64, Color.Blue), Color.Transparent, this._gmap.Pixel2Coord(this._begin), this._gmap.Pixel2Coord(left_bot), this._gmap.Pixel2Coord(this._end), this._gmap.Pixel2Coord(right_top));
                    this._gmap.AddPolygon("area", polygon, true);

                    this.Points         = this.GetPoints(this._begin, this._end);
                    this.Begin          = this._gmap.Pixel2Coord(this._begin);
                    this.End            = this._gmap.Pixel2Coord(this._end);
                }
            }
            else
            {
                this._gmap.SetPosition(this._drag.BeginPoint.X - moved.X, this._drag.BeginPoint.Y - moved.Y, true);
            }
        }

        private GCS[] GetPoints(System.Drawing.Point begin, System.Drawing.Point end)
        {
            var height                  = this._end.Y - this._begin.Y;
            var count                   = (int)Math.Min((height / 5.0f) + 1, 10);
            var margin                  = (height / (float)(count - 1));

            var ret                     = new GCS[count * 2];
            for (var i = 0; i < count * 2; i++)
            {
                var x                   = (i % 4 == 0 || (i + 1) % 4 == 0) ? this._begin.X : this._end.X;   // 왼쪽 포인트인 경우 begin.x, 오른쪽인 경우 end.x
                var y                   = this._begin.Y + (int)(margin * (i / 2));                          // 한 라인당 2개의 포인트

                ret[i]                  = this._gmap.Pixel2Coord(x, y);
            }

            return ret;
        }
    }
}