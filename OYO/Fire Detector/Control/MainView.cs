using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fire_Detector.Control
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void DroneImageButton_Click(object sender, EventArgs e)
        {
            if (this.droneProgressbar.animated == true) {
                this.droneProgressbar.Value = 0;
                this.droneProgressbar.animated = false;
                this.droneProgressbar.ProgressBackColor = System.Drawing.Color.FromArgb(255,200,150);//System.Drawing.Color.Coral;
            }
            else
            {
                this.droneProgressbar.Value = 15;
                this.droneProgressbar.animated = true;
                this.droneProgressbar.ProgressBackColor = System.Drawing.Color.Gainsboro;
            }
            
        }

        private void RaspCamImageButton_Click(object sender, EventArgs e)
        {
            if (this.raspCamProgressbar.animated == true)
            {        
                this.raspCamProgressbar.Value = 0;
                this.raspCamProgressbar.animated = false;
                this.raspCamProgressbar.ProgressBackColor = System.Drawing.Color.FromArgb(255, 200, 150);
            }        
            else     
            {        
                this.raspCamProgressbar.Value = 15;
                this.raspCamProgressbar.animated = true;
                this.raspCamProgressbar.ProgressBackColor = System.Drawing.Color.Gainsboro;
            }
        }

        private void LeapmotionImageButton_Click(object sender, EventArgs e)
        {
            if (this.leapmotionProgressbar.animated == true)
            {
                this.leapmotionProgressbar.Value = 0;
                this.leapmotionProgressbar.animated = false;
                this.leapmotionProgressbar.ProgressBackColor = System.Drawing.Color.FromArgb(255, 200, 150);
            } 
            else
            { 
                this.leapmotionProgressbar.Value = 15;
                this.leapmotionProgressbar.animated = true;
                this.leapmotionProgressbar.ProgressBackColor = System.Drawing.Color.Gainsboro;
            }
        }

        private void droneControlTab_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.activatedConnectionIconPanel.BackColor = Color.Tomato;
                this.activatedConnectionIconPanel.Visible = true;
                this.connectionIconsPanel.Visible = false;
            }
            catch(Exception)
            { }
        }

        

        private void droneControlTab_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if(mainform == null)
                return;

            this.Visible = false;
            mainform.defaultView.Visible = true;
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.activatedConnectionIconPanel.BackColor = Color.Gray;
                this.activatedConnectionIconPanel.Visible = true;
                this.connectionIconsPanel.Visible = false;
            }
            catch(Exception)
            { }
        }

        private void cameraTab_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.activatedConnectionIconPanel.BackColor = Color.Coral;
                this.activatedConnectionIconPanel.Visible = true;
                this.connectionIconsPanel.Visible = false;
            }
            catch (Exception)
            { }
        }

        
        private void cameraTab_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if (mainform == null)
                return;

            this.Visible = false;
            mainform.defaultView.Visible = true;
        }

        private void leapmotionTab_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if (mainform == null)
                return;

            this.Visible = false;
            mainform.defaultView.Visible = true;
        }

        private void leapmotionTab_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.activatedConnectionIconPanel.BackColor = Color.Salmon;
                this.activatedConnectionIconPanel.Visible = true;
                this.connectionIconsPanel.Visible = false;
            }
            catch (Exception)
            { }
        }

        private void tab_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                this.activatedConnectionIconPanel.Visible = false;
                this.connectionIconsPanel.Visible = true;
                //this.bunifuTransition.ShowSync(this.connectionIconsPanel);

                if (this.bunifuTransition.IsCompleted)
                {
                    this.droneImageButton.Visible = false;
                    this.bunifuTransition.Show(this.droneImageButton);
                }

                if (this.bunifuTransition1.IsCompleted)
                {
                    this.raspCamImageButton.Visible = false;
                    this.bunifuTransition1.Show(this.raspCamImageButton);
                }

                if (this.bunifuTransition2.IsCompleted)
                {
                    this.leapMotionImageButton.Visible = false;
                    this.bunifuTransition2.Show(this.leapMotionImageButton);
                }
            }
            catch (Exception)
            { }
        }

        private void detectFireTab_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.activatedConnectionIconPanel.BackColor = Color.LightCoral;
                this.activatedConnectionIconPanel.Visible = true;
                this.connectionIconsPanel.Visible = false;
            }
            catch (Exception)
            { }
        }

        private void detectFireTab_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if (mainform == null)
                return;

            this.Visible = false;
            mainform.defaultView.Visible = true;
        }

        private void etcTab_Click(object sender, EventArgs e)
        {
            var mainform = this.FindForm() as MainForm;
            if (mainform == null)
                return;

            this.Visible = false;
            mainform.defaultView.Visible = true;
        }

        private void etcTab_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.activatedConnectionIconPanel.BackColor = Color.DarkSalmon;
                this.activatedConnectionIconPanel.Visible = true;
                this.connectionIconsPanel.Visible = false;
            }
            catch (Exception)
            { }
        }
    }
}
