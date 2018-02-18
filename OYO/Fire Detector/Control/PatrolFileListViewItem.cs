using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fire_Detector.Control
{
    public partial class PatrolFileListViewItem : UserControl
    {
        private bool _checked = false;
        public bool Checked
        {
            get
            {
                return this._checked;
            }
            set
            {
                this._checked = value;
                this.UpdateUI();
            }
        }

        public PatrolFileListViewItem()
        {
            InitializeComponent();
        }

        private void UpdateUI()
        {
            var backColor = this.Checked ? Color.FromArgb(255, 200, 190) : SystemColors.ControlLight;
            this.BackColor = backColor;
        }

        private void PatrolFileListViewItem_Click(object sender, EventArgs e)
        {
            this.Checked = !this.Checked;
        }

        
    }
}
