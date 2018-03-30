using Bunifu.Framework.UI;
using Fire_Detector.Control.SideTabView;
using System;
using System.Drawing;

namespace Fire_Detector.Control
{
    public partial class SideCollapsedBar : BaseControl
    {
        public static Color ACTIVATED_COLOR = Color.White;
        public static Color INACTIVATED_COLOR = Color.FromArgb(255, 200, 160);
        public static Color HOVERED_COLOR = Color.White;


        private BunifuImageButton[] buttons;

        private BunifuImageButton _activated;
        public BunifuImageButton Activated
        {
            get
            {
                return this._activated;
            }
            set
            {
                if(this._activated != null && this._activated != this._hovered)
                    this._activated.BackColor = INACTIVATED_COLOR;

                this._activated = value;
                if(this._activated != null)
                    this._activated.BackColor = ACTIVATED_COLOR;
            }
        }

        private BunifuImageButton _hovered;
        public BunifuImageButton Hovered
        {
            get
            {
                return this._hovered;
            }
            set
            {
                if(this._hovered != null && this._hovered != this._activated)
                    this._hovered.BackColor = INACTIVATED_COLOR;

                this._hovered = value;
                if(this._hovered != null)
                    this._hovered.BackColor = ACTIVATED_COLOR;
            }
        }

        public SideCollapsedBar()
        {
            InitializeComponent();

            this.buttons = new Bunifu.Framework.UI.BunifuImageButton[] { this.droneTabButton, this.visualizationTabButton, this.leapmotionTabButton, this.detectionTabButton, this.homeButton };
        }

        private void SideCollapsedBar_Load(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.droneTabButton.Tag = this.Root.mainView.droneControlLabel;
            this.visualizationTabButton.Tag = this.Root.mainView.visualizeLabel;
            this.leapmotionTabButton.Tag = this.Root.mainView.leapmotionLabel;
            this.detectionTabButton.Tag = this.Root.mainView.detectFireLabel;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            var activated_label = (sender as BunifuImageButton).Tag as BunifuCustomLabel;
            this.Root.mainView.bottomLabel_Click(activated_label, EventArgs.Empty);
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;
            
            this.Root.defaultView.Visible = false;
            this.Root.mainView.Visible = true;
        }

        private void buttons_MouseHover(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Hovered = sender as BunifuImageButton;
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            if(this.Root == null)
                return;

            this.Hovered = null;
        }
    }
}
