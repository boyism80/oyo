using System;
using System.Windows.Forms;

namespace Fire_Detector.Control
{
    public partial class DroneTab : UserControl
    {
        public DroneTab()
        {
            InitializeComponent();
        }

        private void buttonCollapse_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if (mainform == null)
                return;

            mainform.defaultView.sideExpandedBar.Visible = false;
            mainform.defaultView.sideCollapsedBar.Visible = true;
        }

        private void takeoffButton_Click(object sender, EventArgs e)
        {
            droneFlightProgressbar.Value = 7;
            droneFlightProgressbar.animated = true;
            landButton.Normalcolor = System.Drawing.Color.LightGray;
            takeoffButton.BackColor = System.Drawing.Color.IndianRed;
            takeoffButton.Normalcolor = System.Drawing.Color.IndianRed;
        }

        private void landButton_Click(object sender, EventArgs e)
        {
            droneFlightProgressbar.Value = 0;
            droneFlightProgressbar.animated = false;
            takeoffButton.Normalcolor = System.Drawing.Color.LightGray;
            landButton.BackColor = System.Drawing.Color.IndianRed;
            landButton.Normalcolor = System.Drawing.Color.IndianRed;
            //landButton.Normalcolor = System.Drawing.Color.LightCoral;
        }
    }
}
