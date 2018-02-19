using Fire_Detector.BunifuForm;
using System;
using System.Windows.Forms;

namespace Fire_Detector.Control.SideTabView
{
    public class BaseTabView : UserControl
    {
        private MainForm _mainform;
        public MainForm Root
        {
            get
            {
                return this._mainform;
            }
        }

        protected BaseTabView()
        {
            base.Load += BaseTabView_Load;
        }

        private void BaseTabView_Load(object sender, EventArgs e)
        {
            this._mainform = this.FindForm() as MainForm;
        }
    }
}
