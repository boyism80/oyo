using OpenCvSharp;
using oyo;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Fire_Detector.Control.SideTabView
{
    public partial class AutoFlyingTab : BaseControl
    {
        private OYOGmap _gmap = new OYOGmap();

        public AutoFlyingTab()
        {
            InitializeComponent();

            this._gmap.AutoZoom = true;
            this._gmap.Resize(this.gmapBox.Size);
            this._gmap.DrawMarker = true;
            this._gmap.DrawPath = true;
            this._gmap.ReceiveGmap += this.OnReceiveGmap;
        }

        private void autoFlyingSettingButton_Click(object sender, System.EventArgs e)
        {
            var dialog = new Fire_Detector.Dialog.AutoFlyingDialog();
            if (dialog.ShowDialog(this.Root) != DialogResult.OK)
                return;

            
            var marker = new OYOGmapMarker();
            marker.Points.Add(dialog.Begin);
            marker.Points.Add(dialog.End);
            this._gmap.ClearMarkers();
            this._gmap.AddMarker("point", marker, false);

            var path = new OYOGmapPath();
            foreach(var gcs in dialog.Points)
                path.Points.Add(gcs);
            this._gmap.ClearPath(false);
            this._gmap.AddPath("path", path, true);

            var width = OYOGmap.GetDistance(dialog.Begin.lat, dialog.Begin.lon, dialog.Begin.lat, dialog.End.lon);
            var height = OYOGmap.GetDistance(dialog.Begin.lat, dialog.Begin.lon, dialog.End.lat, dialog.Begin.lon);
            
            this.bunifuCustomLabel1.Text = string.Format("{0} ㎡", ((width * height) * 1000).ToString("0.00"));
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

        private void AutoFlyingTab_Load(object sender, System.EventArgs e)
        {
        }
    }
}