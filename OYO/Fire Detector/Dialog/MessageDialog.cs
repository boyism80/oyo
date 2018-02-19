using System;
using System.Windows.Forms;

namespace Fire_Detector.Dialog
{
    public partial class MessageDialog : System.Windows.Forms.Form
    {
        public MessageDialog()
        {
            InitializeComponent();
        }

        public MessageDialog(string message) : this()
        {
            this.messageLabel.Text = message;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
