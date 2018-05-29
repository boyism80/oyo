using oyo;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
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

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                base.Dock = value;
            }
        }

        public string FileName { get; private set; }

        public string FileDateTimeText
        {
            get
            {
                return File.GetCreationTime(this.FileName).ToShortDateString();
            }
        }

        public long FileSize
        {
            get
            {
                return new FileInfo(this.FileName).Length;
            }
        }

        public string FileSizeText
        {
            get
            {
                string[] sizes = { "B", "KB", "MB", "GB", "TB" };
                var size = this.FileSize;
                var order = 0;

                while (size >= 1024 && order < sizes.Length - 1)
                {
                    order++;
                    size /= 1024;
                }

                return string.Format("{0:0.##} {1}", size, sizes[order]);
            }
        }

        private int _elapsedTime;
        public int ElapsedTime
        {
            get
            {
                if (this._elapsedTime == 0)
                {
                    var elements = OYOPatrolReader.Read(this.FileName);
                    foreach (var element in elements)
                        this._elapsedTime += element.ElapsedTime;
                }

                return this._elapsedTime;
            }
        }

        public PatrolFileListViewItem(string filename)
        {
            InitializeComponent();

            this.FileName = filename;
            this.fileNameTextBox.Text = Path.GetFileName(this.FileName);
            this.dateTimeTextBox.Text = this.FileDateTimeText;
            this.fileSizeTextBox.Text = this.FileSizeText;

            var time = TimeSpan.FromSeconds(this.ElapsedTime / 1000);
            this.durationTextBox.Text = time.ToString(@"hh\:mm\:ss");
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
