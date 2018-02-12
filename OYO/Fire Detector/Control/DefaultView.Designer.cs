namespace Fire_Detector.Control
{
    partial class DefaultView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultView));
            this.currentStateBar = new System.Windows.Forms.Panel();
            this.bunifuProgressBar1 = new Bunifu.Framework.UI.BunifuProgressBar();
            this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel9 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel8 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.streamingFrameBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCircleProgressbar3 = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.bunifuCircleProgressbar2 = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.bunifuCircleProgressbar1 = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.sideExpandedBar = new Fire_Detector.Control.SideExpandedBar();
            this.sideCollapsedBar = new Fire_Detector.Control.SideCollapsedBar();
            this.currentStateBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.streamingFrameBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // currentStateBar
            // 
            this.currentStateBar.BackColor = System.Drawing.Color.Black;
            this.currentStateBar.Controls.Add(this.bunifuProgressBar1);
            this.currentStateBar.Controls.Add(this.pictureBox1);
            this.currentStateBar.Controls.Add(this.bunifuCircleProgressbar3);
            this.currentStateBar.Controls.Add(this.bunifuCircleProgressbar2);
            this.currentStateBar.Controls.Add(this.bunifuCircleProgressbar1);
            this.currentStateBar.Controls.Add(this.bunifuCustomLabel6);
            this.currentStateBar.Controls.Add(this.bunifuCustomLabel5);
            this.currentStateBar.Controls.Add(this.bunifuCustomLabel4);
            this.currentStateBar.Controls.Add(this.bunifuCustomLabel3);
            this.currentStateBar.Controls.Add(this.bunifuCustomLabel9);
            this.currentStateBar.Controls.Add(this.bunifuCustomLabel8);
            this.currentStateBar.Controls.Add(this.bunifuCustomLabel2);
            this.currentStateBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.currentStateBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.currentStateBar.Location = new System.Drawing.Point(0, 688);
            this.currentStateBar.Name = "currentStateBar";
            this.currentStateBar.Size = new System.Drawing.Size(624, 50);
            this.currentStateBar.TabIndex = 2;
            // 
            // bunifuProgressBar1
            // 
            this.bunifuProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuProgressBar1.BorderRadius = 3;
            this.bunifuProgressBar1.Location = new System.Drawing.Point(18, 22);
            this.bunifuProgressBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuProgressBar1.MaximumValue = 100;
            this.bunifuProgressBar1.Name = "bunifuProgressBar1";
            this.bunifuProgressBar1.ProgressColor = System.Drawing.Color.LightGray;
            this.bunifuProgressBar1.Size = new System.Drawing.Size(37, 12);
            this.bunifuProgressBar1.TabIndex = 7;
            this.bunifuProgressBar1.Value = 67;
            // 
            // bunifuCustomLabel6
            // 
            this.bunifuCustomLabel6.AutoSize = true;
            this.bunifuCustomLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(533, 21);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(40, 18);
            this.bunifuCustomLabel6.TabIndex = 4;
            this.bunifuCustomLabel6.Text = "Leap";
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(447, 21);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(43, 18);
            this.bunifuCustomLabel5.TabIndex = 4;
            this.bunifuCustomLabel5.Text = "Rasp";
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(360, 21);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(49, 18);
            this.bunifuCustomLabel4.TabIndex = 4;
            this.bunifuCustomLabel4.Text = "Drone";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.Lime;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(233, 21);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(46, 18);
            this.bunifuCustomLabel3.TabIndex = 4;
            this.bunifuCustomLabel3.Text = "LAT : ";
            // 
            // bunifuCustomLabel9
            // 
            this.bunifuCustomLabel9.AutoSize = true;
            this.bunifuCustomLabel9.ForeColor = System.Drawing.Color.Lime;
            this.bunifuCustomLabel9.Location = new System.Drawing.Point(275, 21);
            this.bunifuCustomLabel9.Name = "bunifuCustomLabel9";
            this.bunifuCustomLabel9.Size = new System.Drawing.Size(28, 18);
            this.bunifuCustomLabel9.TabIndex = 4;
            this.bunifuCustomLabel9.Text = "0.0";
            // 
            // bunifuCustomLabel8
            // 
            this.bunifuCustomLabel8.AutoSize = true;
            this.bunifuCustomLabel8.ForeColor = System.Drawing.Color.Lime;
            this.bunifuCustomLabel8.Location = new System.Drawing.Point(165, 21);
            this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
            this.bunifuCustomLabel8.Size = new System.Drawing.Size(28, 18);
            this.bunifuCustomLabel8.TabIndex = 4;
            this.bunifuCustomLabel8.Text = "0.0";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.Lime;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(126, 21);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(51, 18);
            this.bunifuCustomLabel2.TabIndex = 4;
            this.bunifuCustomLabel2.Text = "LON : ";
            // 
            // streamingFrameBox
            // 
            this.streamingFrameBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.streamingFrameBox.Image = global::Fire_Detector.Properties.Resources._34620595595_b4c90a2e22_b;
            this.streamingFrameBox.Location = new System.Drawing.Point(0, 0);
            this.streamingFrameBox.Name = "streamingFrameBox";
            this.streamingFrameBox.Size = new System.Drawing.Size(624, 688);
            this.streamingFrameBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.streamingFrameBox.TabIndex = 3;
            this.streamingFrameBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(13, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 20);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuCircleProgressbar3
            // 
            this.bunifuCircleProgressbar3.animated = true;
            this.bunifuCircleProgressbar3.animationIterval = 5;
            this.bunifuCircleProgressbar3.animationSpeed = 3;
            this.bunifuCircleProgressbar3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCircleProgressbar3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuCircleProgressbar3.BackgroundImage")));
            this.bunifuCircleProgressbar3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.bunifuCircleProgressbar3.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuCircleProgressbar3.LabelVisible = false;
            this.bunifuCircleProgressbar3.LineProgressThickness = 2;
            this.bunifuCircleProgressbar3.LineThickness = 2;
            this.bunifuCircleProgressbar3.Location = new System.Drawing.Point(569, 12);
            this.bunifuCircleProgressbar3.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.bunifuCircleProgressbar3.MaxValue = 100;
            this.bunifuCircleProgressbar3.Name = "bunifuCircleProgressbar3";
            this.bunifuCircleProgressbar3.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuCircleProgressbar3.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bunifuCircleProgressbar3.Size = new System.Drawing.Size(29, 29);
            this.bunifuCircleProgressbar3.TabIndex = 5;
            this.bunifuCircleProgressbar3.Value = 15;
            // 
            // bunifuCircleProgressbar2
            // 
            this.bunifuCircleProgressbar2.animated = true;
            this.bunifuCircleProgressbar2.animationIterval = 5;
            this.bunifuCircleProgressbar2.animationSpeed = 3;
            this.bunifuCircleProgressbar2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCircleProgressbar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuCircleProgressbar2.BackgroundImage")));
            this.bunifuCircleProgressbar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.bunifuCircleProgressbar2.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuCircleProgressbar2.LabelVisible = false;
            this.bunifuCircleProgressbar2.LineProgressThickness = 2;
            this.bunifuCircleProgressbar2.LineThickness = 2;
            this.bunifuCircleProgressbar2.Location = new System.Drawing.Point(485, 12);
            this.bunifuCircleProgressbar2.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.bunifuCircleProgressbar2.MaxValue = 100;
            this.bunifuCircleProgressbar2.Name = "bunifuCircleProgressbar2";
            this.bunifuCircleProgressbar2.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuCircleProgressbar2.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bunifuCircleProgressbar2.Size = new System.Drawing.Size(29, 29);
            this.bunifuCircleProgressbar2.TabIndex = 5;
            this.bunifuCircleProgressbar2.Value = 15;
            // 
            // bunifuCircleProgressbar1
            // 
            this.bunifuCircleProgressbar1.animated = true;
            this.bunifuCircleProgressbar1.animationIterval = 5;
            this.bunifuCircleProgressbar1.animationSpeed = 3;
            this.bunifuCircleProgressbar1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCircleProgressbar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuCircleProgressbar1.BackgroundImage")));
            this.bunifuCircleProgressbar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.bunifuCircleProgressbar1.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuCircleProgressbar1.LabelVisible = false;
            this.bunifuCircleProgressbar1.LineProgressThickness = 2;
            this.bunifuCircleProgressbar1.LineThickness = 2;
            this.bunifuCircleProgressbar1.Location = new System.Drawing.Point(402, 12);
            this.bunifuCircleProgressbar1.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.bunifuCircleProgressbar1.MaxValue = 100;
            this.bunifuCircleProgressbar1.Name = "bunifuCircleProgressbar1";
            this.bunifuCircleProgressbar1.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuCircleProgressbar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bunifuCircleProgressbar1.Size = new System.Drawing.Size(29, 29);
            this.bunifuCircleProgressbar1.TabIndex = 5;
            this.bunifuCircleProgressbar1.Value = 15;
            // 
            // sideExpandedBar
            // 
            this.sideExpandedBar.BackColor = System.Drawing.SystemColors.Control;
            this.sideExpandedBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.sideExpandedBar.Location = new System.Drawing.Point(624, 0);
            this.sideExpandedBar.Name = "sideExpandedBar";
            this.sideExpandedBar.Size = new System.Drawing.Size(350, 738);
            this.sideExpandedBar.TabIndex = 1;
            this.sideExpandedBar.Visible = false;
            // 
            // sideCollapsedBar
            // 
            this.sideCollapsedBar.BackColor = System.Drawing.SystemColors.Control;
            this.sideCollapsedBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.sideCollapsedBar.Location = new System.Drawing.Point(974, 0);
            this.sideCollapsedBar.Name = "sideCollapsedBar";
            this.sideCollapsedBar.Size = new System.Drawing.Size(50, 738);
            this.sideCollapsedBar.TabIndex = 0;
            // 
            // DefaultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.streamingFrameBox);
            this.Controls.Add(this.currentStateBar);
            this.Controls.Add(this.sideExpandedBar);
            this.Controls.Add(this.sideCollapsedBar);
            this.Name = "DefaultView";
            this.Size = new System.Drawing.Size(1024, 738);
            this.currentStateBar.ResumeLayout(false);
            this.currentStateBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.streamingFrameBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel currentStateBar;
        public SideCollapsedBar sideCollapsedBar;
        public SideExpandedBar sideExpandedBar;
        private System.Windows.Forms.PictureBox streamingFrameBox;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel9;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel8;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCircleProgressbar bunifuCircleProgressbar1;
        private Bunifu.Framework.UI.BunifuCircleProgressbar bunifuCircleProgressbar3;
        private Bunifu.Framework.UI.BunifuCircleProgressbar bunifuCircleProgressbar2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuProgressBar bunifuProgressBar1;
    }
}
