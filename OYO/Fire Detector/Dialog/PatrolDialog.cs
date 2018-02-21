using System;
using System.Windows.Forms;

namespace Fire_Detector.Dialog
{
    public partial class PatrolDialog : System.Windows.Forms.Form
    {
        public PatrolDialog()
        {
            InitializeComponent();
        }

        private void scrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var selectedItems = this.patrolFileListView.SelectedItems;
            for (var i = selectedItems.Count - 1; i >= 0; i--)
                this.patrolFileListView.Items.Remove(selectedItems[i]);
        }
    }
}
