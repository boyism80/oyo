using System;
using System.IO;
using System.Windows.Forms;

namespace Fire_Detector.Dialog
{
    public partial class PatrolDialog : System.Windows.Forms.Form
    {
        public string FileName { get; private set; }

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
            try
            {
                var selectedItems = this.patrolFileListView.SelectedItems;
                if(selectedItems.Count == 0)
                    throw new Exception("순찰 파일을 선택하세요");

                this.FileName = selectedItems[0].FileName;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception exc)
            {
                var dialog = new MessageDialog(exc.Message);
                dialog.ShowDialog(this);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var selectedItems = this.patrolFileListView.SelectedItems;
            for (var i = selectedItems.Count - 1; i >= 0; i--)
                this.patrolFileListView.Items.Remove(selectedItems[i]);
        }

        private void PatrolDialog_Load(object sender, EventArgs e)
        {
            try
            {
                foreach(var file in Directory.GetFiles("patrols", "*.ptr"))
                    this.patrolFileListView.Items.Add(new Control.PatrolFileListViewItem(file));
            }
            catch (Exception exc)
            { }
        }
    }
}
