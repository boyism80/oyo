using System;
using System.Windows.Forms;

namespace Fire_Detector
{
    public partial class MainForm : Form
    {
        //
        // For maximize & normal state
        //
        private System.Drawing.Point        _beforePosition;
        private System.Drawing.Size         _beforeSize;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void caption_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
                return;

            var isMaximized = this.Left == 0 && this.Top == 0 && this.Size.Width == Screen.PrimaryScreen.WorkingArea.Width && this.Size.Height == Screen.PrimaryScreen.WorkingArea.Height;
            if (isMaximized)
            {
                this.Left = this._beforePosition.X;
                this.Top = this._beforePosition.Y;
                this.Size = this._beforeSize;
            }
            else
            {
                this._beforePosition = new System.Drawing.Point(this.Left, this.Top);
                this._beforeSize = this.Size;

                this.Left = this.Top = 0;
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            }
        }
    }
}
