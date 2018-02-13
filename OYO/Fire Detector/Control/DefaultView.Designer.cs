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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCircleProgressbar2 = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel9 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel8 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.streamingFrameBox = new System.Windows.Forms.PictureBox();
            this.sideExpandedBar = new Fire_Detector.Control.SideExpandedBar();
            this.sideCollapsedBar = new Fire_Detector.Control.SideCollapsedBar();
            this.currentStateBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.streamingFrameBox)).BeginInit();
            this.SuspendLayout();
            // 
            // currentStateBar
            // 
            this.currentStateBar.BackColor = System.Drawing.Color.Black;
            this.currentStateBar.Controls.Add(this.bunifuProgressBar1);
            this.currentStateBar.Controls.Add(this.pictureBox1);
            this.currentStateBar.Controls.Add(this.bunifuCircleProgressbar2);
            this.currentStateBar.Controls.Add(this.bunifuCustomLabel4);
            this.currentStateBar.Controls.Add(this.bunifuCustomLabel3);
            this.currentStateBar.Controls.Add(this.bunifuCustomLabel9);
            this.currentStateBar.Controls.Add(this.bunifuCustomLabel8);
            this.currentStateBar.Controls.Add(this.bunifuCustomLabel2);
            this.currentStateBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.currentStateBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.currentStateBar.Location = new System.Drawing.Point(0, 688);
            this.currentStateBar.Name = "currentStateBar";
            this.currentStateBar.Size = new System.Drawing.Size(604, 50);
            this.currentStateBar.TabIndex = 2;
            // 
            // bunifuProgressBar1
            // 
            this.bunifuProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuProgressBar1.BorderRadius = 3;
            this.bunifuProgressBar1.Location = new System.Drawing.Point(18, 18);
            this.bunifuProgressBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuProgressBar1.MaximumValue = 100;
            this.bunifuProgressBar1.Name = "bunifuProgressBar1";
            this.bunifuProgressBar1.ProgressColor = System.Drawing.Color.LightGray;
            this.bunifuProgressBar1.Size = new System.Drawing.Size(37, 13);
            this.bunifuProgressBar1.TabIndex = 7;
            this.bunifuProgressBar1.Value = 67;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 20);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
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
            this.bunifuCircleProgressbar2.Location = new System.Drawing.Point(458, 10);
            this.bunifuCircleProgressbar2.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.bunifuCircleProgressbar2.MaxValue = 100;
            this.bunifuCircleProgressbar2.Name = "bunifuCircleProgressbar2";
            this.bunifuCircleProgressbar2.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuCircleProgressbar2.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bunifuCircleProgressbar2.Size = new System.Drawing.Size(29, 29);
            this.bunifuCircleProgressbar2.TabIndex = 5;
            this.bunifuCircleProgressbar2.Value = 15;
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(332, 17);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(124, 18);
            this.bunifuCustomLabel4.TabIndex = 4;
            this.bunifuCustomLabel4.Text = "No Fire Detection";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.Lime;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(233, 17);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(46, 18);
            this.bunifuCustomLabel3.TabIndex = 4;
            this.bunifuCustomLabel3.Text = "LAT : ";
            // 
            // bunifuCustomLabel9
            // 
            this.bunifuCustomLabel9.AutoSize = true;
            this.bunifuCustomLabel9.ForeColor = System.Drawing.Color.Lime;
            this.bunifuCustomLabel9.Location = new System.Drawing.Point(285, 16);
            this.bunifuCustomLabel9.Name = "bunifuCustomLabel9";
            this.bunifuCustomLabel9.Size = new System.Drawing.Size(28, 18);
            this.bunifuCustomLabel9.TabIndex = 4;
            this.bunifuCustomLabel9.Text = "0.0";
            // 
            // bunifuCustomLabel8
            // 
            this.bunifuCustomLabel8.AutoSize = true;
            this.bunifuCustomLabel8.ForeColor = System.Drawing.Color.Lime;
            this.bunifuCustomLabel8.Location = new System.Drawing.Point(167, 16);
            this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
            this.bunifuCustomLabel8.Size = new System.Drawing.Size(28, 18);
            this.bunifuCustomLabel8.TabIndex = 4;
            this.bunifuCustomLabel8.Text = "0.0";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.Lime;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(128, 16);
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
            this.streamingFrameBox.Size = new System.Drawing.Size(604, 688);
            this.streamingFrameBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.streamingFrameBox.TabIndex = 3;
            this.streamingFrameBox.TabStop = false;
            // 
            // sideExpandedBar
            // 
            this.sideExpandedBar.BackColor = System.Drawing.SystemColors.Control;
            this.sideExpandedBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.sideExpandedBar.Location = new System.Drawing.Point(604, 0);
            this.sideExpandedBar.Name = "sideExpandedBar";
            this.sideExpandedBar.Size = new System.Drawing.Size(350, 738);
            this.sideExpandedBar.TabIndex = 1;
            this.sideExpandedBar.Visible = false;
            // 
            // sideCollapsedBar
            // 
            this.sideCollapsedBar.BackColor = System.Drawing.SystemColors.Control;
            this.sideCollapsedBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.sideCollapsedBar.Location = new System.Drawing.Point(954, 0);
            this.sideCollapsedBar.Name = "sideCollapsedBar";
            this.sideCollapsedBar.Size = new System.Drawing.Size(70, 738);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.streamingFrameBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel currentStateBar;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel9;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel8;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCircleProgressbar bunifuCircleProgressbar2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuProgressBar bunifuProgressBar1;
        private System.Windows.Forms.PictureBox streamingFrameBox;
        public SideCollapsedBar sideCollapsedBar;
        public SideExpandedBar sideExpandedBar;
    }
}
