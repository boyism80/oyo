using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fire_Detector.Control
{
    public partial class PatrolFileListViewItem : UserControl
    {
        private bool _selected = false;
        public bool Selected
        {
            get
            {
                return this._selected;
            }
            set
            {
                this._selected = value;
                this.UpdateUI();
            }
        }

        public PatrolFileListViewItem()
        {
            InitializeComponent();
        }

        private void UpdateUI()
        {
            var backColor = this.Selected ? Color.FromArgb(255, 200, 190) : SystemColors.ControlLight;
            this.BackColor = backColor;
        }

        private void PatrolFileListViewItem_Click(object sender, EventArgs e)
        {
            this.Selected = !this.Selected;
        }

        
    }
}
