using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;

namespace Fire_Detector.Control
{
    public partial class PatrolFileListView : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PatrolFileListViewCollection Items { get; private set; }

        public class PatrolFileListViewCollection : Collection<PatrolFileListViewItem>
        {
            public PatrolFileListView Owner { get; private set; }

            public PatrolFileListViewCollection(PatrolFileListView owner)
            {
                this.Owner = owner;

                
            }

            public new void Add(PatrolFileListViewItem item)
            {
                base.Add(item);
                this.Owner.Controls.Add(item);
                item.Dock = DockStyle.Top;
            }

            public new void Remove(PatrolFileListViewItem item)
            {
                base.Remove(item);
                this.Owner.Controls.Remove(item);
            }

            public new void RemoveAt(int index)
            {
                var item = this[index];
                base.Remove(item);
                this.Owner.Controls.Remove(item);
            }
        }

        public PatrolFileListView()
        {
            this.Items = new PatrolFileListViewCollection(this);
            InitializeComponent();
        }

        public Collection<PatrolFileListViewItem> SelectedItems
        {
            get
            {
                var ret = new Collection<PatrolFileListViewItem>();
                foreach (var item in this.Items)
                {
                    if(item.Selected)
                        ret.Add(item);
                }

                return  ret;
            }
        }

        private void PatrolFileListView_Load(object sender, System.EventArgs e)
        {
            foreach (var item in this.Items)
            {
                this.Controls.Add(item);
                item.Dock = DockStyle.Top;
            }
        }
    }
}
