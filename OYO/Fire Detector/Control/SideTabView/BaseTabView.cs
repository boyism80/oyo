using Fire_Detector.BunifuForm;
using System;
using System.Windows.Forms;

namespace Fire_Detector.Control.SideTabView
{
    /// <summary>
    /// 메인폼에서 사용될 하위 컨트롤입니다.
    /// 이 클래스를 상속받으면 쉽게 메인폼에 접근할 수 있습니다.
    /// </summary>
    public class BaseControl : UserControl
    {
        private MainForm _mainform;

        /// <summary>
        /// 메인폼을 얻을 수 있는 프로퍼티입니다.
        /// </summary>
        public MainForm Root
        {
            get
            {
                return this._mainform;
            }
        }

        protected BaseControl()
        {
            base.Load += BaseTabView_Load;
        }

        private void BaseTabView_Load(object sender, EventArgs e)
        {
            this._mainform = this.FindForm() as MainForm;
        }
    }
}
