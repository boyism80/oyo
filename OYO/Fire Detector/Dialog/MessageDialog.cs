using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fire_Detector.Dialog
{
    public partial class MessageDialog : System.Windows.Forms.Form
    {
        private MessageDialog()
        {
            InitializeComponent();
        }

        public MessageDialog(string message) : this()
        {
            this.messageLabel.Text = message;
        }

        public MessageDialog(string message, Color backgroundColor) : this(message)
        {
            this.BackColor = backgroundColor;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MessageDialog_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(this.Owner.Location.X + (this.Owner.Size.Width - this.Size.Width) / 2,
                                                     this.Owner.Location.Y + (this.Owner.Size.Height - this.Size.Height) / 2);
        }
    }
}
