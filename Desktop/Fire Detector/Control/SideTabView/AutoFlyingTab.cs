using Fire_Detector.Dialog;
using OpenCvSharp;
using oyo;
using ParrotBebop2;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Fire_Detector.Control.SideTabView
{
    public partial class AutoFlyingTab : BaseControl
    {
        private OYOGmap                     _gmap = new OYOGmap();
        private GCS[]                       _points;

        public AutoFlyingTab()
        {
            InitializeComponent();

            this._gmap.AutoZoom             = true;
            this._gmap.DrawMarker           = true;
            this._gmap.DrawPath             = true;
            this._gmap.ReceiveGmap          += this.OnReceiveGmap;
            this._gmap.ReceiveAddress       += this.OnReceiveAddress;
            this._gmap.ReceiveAddressError  += this.OnReceiveAddressError;
            this._gmap.Resize(this.gmapBox.Size);
        }

        private void autoFlyingSettingButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                if(this.Root == null)
                    return;

                if(this.Root.AutoFlight.IsFlying)
                    return;

                //if (this.Root.Bebop2.GPS.IsValid == false)
                //    throw new Exception("현재 드론의 위치정보가 없습니다.");

                //var dialog = new Fire_Detector.Dialog.AutoFlyingDialog(this.Root.Bebop2.GPS);
                var dialog = new Fire_Detector.Dialog.AutoFlyingDialog(new GCS(37.3403904, 126.7334985));
                if (dialog.ShowDialog(this.Root) != DialogResult.OK)
                    return;

                // 자율비행 시작점과 종료점 마크
                var marker = new OYOGmapMarker(dialog.Begin, dialog.End);
                this._gmap.ClearMarkers();
                this._gmap.AddMarker("point", marker, false);


                // 자율비행 이동경로
                this._points = dialog.Points;
                var path = new OYOGmapPath(this._points);
                this._gmap.ClearPath(false);
                this._gmap.AddPath("path", path);

                // 위치와 구글맵 요청
                this._gmap.RequestAddress("begin", dialog.Begin);
                this._gmap.RequestAddress("end", dialog.End);
                this._gmap.RequestGmap();


                // 면적 계산
                var width = OYOGmap.GetDistance(dialog.Begin.lat, dialog.Begin.lon, dialog.Begin.lat, dialog.End.lon) * 1000.0;
                var height = OYOGmap.GetDistance(dialog.Begin.lat, dialog.Begin.lon, dialog.End.lat, dialog.Begin.lon) * 1000.0;
                this.areaLabel.Text = string.Format("{0} ㎡", (width * height).ToString("0.00"));
            }
            catch (Exception exc)
            {
                var messageBox = new MessageDialog(exc.Message);
                messageBox.ShowDialog(this.Root);
            }
        }

        private void autoFlyingStartEndButton_Click(object sender, System.EventArgs e)
        {
            if(this.Root == null)
                return;

            if(this.Root.AutoFlight.IsFlying)
                this.Root.AutoFlight.Stop();
            else
                this.Root.AutoFlight.Start();
        }

        private void OnReceiveGmap(Mat map)
        {
            this.gmapBox.Invoke(new MethodInvoker(delegate ()
            {
                this.gmapBox.Image = Image.FromStream(new MemoryStream(map.ToBytes()));
            }));
        }

        private void OnReceiveAddress(string name, string address)
        {
            switch (name)
            {
                case "begin":
                    this.startSpotLabel.Invoke(new MethodInvoker(delegate ()
                    {
                        this.startSpotLabel.Text = address;
                    }));
                    break;

                case "end":
                    this.endSpotLabel.Invoke(new MethodInvoker(delegate ()
                    {
                        this.endSpotLabel.Text = address;
                    }));
                    break;
            }
        }

        private void OnReceiveAddressError(string name, string message)
        {
            switch (name)
            {
                case "begin":
                    this.startSpotLabel.Invoke(new MethodInvoker(delegate ()
                    {
                        this.startSpotLabel.Text = message;
                    }));
                    break;

                case "end":
                    this.endSpotLabel.Invoke(new MethodInvoker(delegate ()
                    {
                        this.endSpotLabel.Text = message;
                    }));
                    break;
            }
        }

        private void AutoFlyingTab_Load(object sender, System.EventArgs e)
        {
        }

        public void Bebop2_OnPositionChanged(Bebop2 bebop2, double lat, double lon, double alt)
        {

        }

        private void autoFlyingButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.Root == null)
                    return;

                if(this.Root.AutoFlight.IsFlying == false)
                {
                    if(this.Root.Patrol.Enabled)
                        throw new Exception("순찰중에는 자율비행을 할 수 없습니다.");

                    if(this._points == null || this._points.Length == 0)
                        throw new Exception("자율비행 경로를 먼저 설정해야 합니다.");

                    this.Root.AutoFlight.SetDestinationPoints(this._points);
                    if(this.Root.AutoFlight.Start() == false)
                        throw new Exception("자율비행을 시작할 수 없습니다.");
                }
                else
                {
                    this.Root.AutoFlight.Stop();
                }
            }
            catch(Exception exc)
            {
                var dialog = new MessageDialog(exc.Message);
                dialog.ShowDialog(this.Root);
            }
        }

        private void synchronizeUI(bool active)
        {
            this.connectDroneProgressbar.Invoke(new MethodInvoker(delegate ()
            {
                this.connectDroneProgressbar.Value = active ? 40 : 0;
                this.connectDroneProgressbar.animated = active;
            }));
        }

        public void AutoFlight_OnComplete()
        {
            this.synchronizeUI(false);
        }

        public void AutoFlight_OnLookNextDestination()
        {
            
        }

        public void AutoFlight_OnStop()
        {
            this.synchronizeUI(false);
        }

        public void AutoFlight_OnPause()
        {
            this.synchronizeUI(false);
        }

        public void AutoFlight_OnStart()
        {
            this.synchronizeUI(true);
        }
    }
}