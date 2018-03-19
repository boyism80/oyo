using System;
using System.Windows.Forms;

namespace Fire_Detector.Dialog
{
    public partial class RecordDialog : Form
    {
        private Bunifu.Framework.UI.BunifuCheckbox[] _recordTypeCheckBoxes;
        private Bunifu.Framework.UI.BunifuCheckbox[] _resolutionCheckBoxes;
        private Bunifu.Framework.UI.BunifuCheckbox[] _optionalCheckBoxes;

        public oyo.OYORecorder.RecordingStateType RecordingType { get; private set; }
        public OpenCvSharp.Size Resolution { get; private set; }

        public RecordDialog()
        {
            InitializeComponent();

            this.bunifuCheckbox1.Tag = oyo.OYORecorder.RecordingStateType.Infrared;
            this.bunifuCheckbox2.Tag = oyo.OYORecorder.RecordingStateType.Visual;
            this.bunifuCheckbox3.Tag = oyo.OYORecorder.RecordingStateType.Blending;
            this.bunifuCheckbox4.Tag = oyo.OYORecorder.RecordingStateType.Display;
            this._recordTypeCheckBoxes = new Bunifu.Framework.UI.BunifuCheckbox[] { bunifuCheckbox1, bunifuCheckbox2, bunifuCheckbox3, bunifuCheckbox4};

            this.bunifuCheckbox5.Tag = new OpenCvSharp.Size(1440, 900);
            this.bunifuCheckbox6.Tag = new OpenCvSharp.Size(1280, 720);
            this.bunifuCheckbox7.Tag = new OpenCvSharp.Size(800, 600);
            this._resolutionCheckBoxes = new Bunifu.Framework.UI.BunifuCheckbox[] { bunifuCheckbox5, bunifuCheckbox6, bunifuCheckbox7 };


            this._optionalCheckBoxes = new Bunifu.Framework.UI.BunifuCheckbox[] { bunifuCheckbox8 };
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            (sender as Bunifu.Framework.UI.BunifuCheckbox).Enabled = false;

            foreach(var checkbox in this._recordTypeCheckBoxes)
            {
                if(sender == checkbox)
                    continue;

                checkbox.Checked = false;
                checkbox.Enabled = true;
            }
        }

        private void bunifuCheckbox7_OnChange(object sender, EventArgs e)
        {
            (sender as Bunifu.Framework.UI.BunifuCheckbox).Enabled = false;

            foreach (var checkbox in this._resolutionCheckBoxes)
            {
                if(checkbox == sender)
                    continue;

                checkbox.Checked = false;
                checkbox.Enabled = true;
            }
        }

        private void bunifuCheckbox8_OnChange(object sender, EventArgs e)
        {
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            foreach (var checkbox in this._recordTypeCheckBoxes)
            {
                if (checkbox.Checked)
                {
                    this.RecordingType = (oyo.OYORecorder.RecordingStateType)checkbox.Tag;
                    break;
                }
            }

            foreach (var checkbox in this._resolutionCheckBoxes)
            {
                if (checkbox.Checked)
                {
                    this.Resolution = (OpenCvSharp.Size)checkbox.Tag;
                    break;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}