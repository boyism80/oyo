using System;
using System.IO;
using System.Windows.Forms;

namespace Fire_Detector.Dialog
{
    public partial class PatrolPathDialog : Form
    {
        public string FileName { get; private set; }
        public new string Name { get; private set; }

        public PatrolPathDialog()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists("patrols") == false)
                    Directory.CreateDirectory("patrols");

                this.Name = this.patrolFileNameTextBox.Text.Clone() as string;
                this.FileName = Path.Combine("patrols", this.Name + ".ptr");

                if (this.Name.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                    throw new Exception("파일명이 올바르지 않습니다.");
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception exc)
            {
                var dialog = new MessageDialog(exc.Message);
                dialog.ShowDialog(this);


                this.Name = null;
                this.FileName = null;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}