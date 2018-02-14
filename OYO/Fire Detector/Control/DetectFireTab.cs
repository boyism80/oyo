using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fire_Detector.Control
{
    public partial class DetectFireTab : UserControl
    {
        public DetectFireTab()
        {
            InitializeComponent();
        }

        private void desiredTemperatureProgressbar_ValueChanged(object sender, EventArgs e)
        {
            desiredTemperatureLabel.Text = desiredTemperatureProgressbar.Value.ToString();


        }
    }
}
