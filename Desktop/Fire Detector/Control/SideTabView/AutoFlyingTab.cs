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
                if (this.Root.Bebop2.GPS.IsValid == false)
                    throw new Exception("현재 드론의 위치정보가 없습니다.");

                var dialog = new Fire_Detector.Dialog.AutoFlyingDialog(new GCS(37.3487547f, 126.74490070000002f));
                if (dialog.ShowDialog(this.Root) != DialogResult.OK)
                    return;

                // 자율비행 시작점과 종료점 마크
                var marker = new OYOGmapMarker(dialog.Begin, dialog.End);
                this._gmap.ClearMarkers();
                this._gmap.AddMarker("point", marker, false);


                // 자율비행 이동경로
                var path = new OYOGmapPath(dialog.Points);
                this._gmap.ClearPath(false);
                this._gmap.AddPath("path", path);

                // 위치와 구글맵 요청
                this._gmap.RequestAddress("begin", dialog.Begin);
                this._gmap.RequestAddress("end", dialog.End);
                this._gmap.RequestGmap();


                // 면적 계산
                var width = OYOGmap.GetDistance(dialog.Begin.lat, dialog.Begin.lon, dialog.Begin.lat, dialog.End.lon);
                var height = OYOGmap.GetDistance(dialog.Begin.lat, dialog.Begin.lon, dialog.End.lat, dialog.Begin.lon);
                this.bunifuCustomLabel1.Text = string.Format("{0} ㎡", ((width * height) * 1000).ToString("0.00"));
            }
            catch (Exception exc)
            {
                var messageBox = new MessageDialog(exc.Message);
                messageBox.ShowDialog(this.Root);
            }
        }

        private void autoFlyingStartEndButton_Click(object sender, System.EventArgs e)
        {
            
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
    }
}