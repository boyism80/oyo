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
            this.panel5 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.detectingProgressbar = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.detectingLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.droneSpeedLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.droneAltitudeLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuProgressBar1 = new Bunifu.Framework.UI.BunifuProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.streamingFrameBox = new System.Windows.Forms.PictureBox();
            this.sideCollapsedBar = new Fire_Detector.Control.SideCollapsedBar();
            this.sideExpandedBar = new Fire_Detector.Control.SideExpandedBar();
            this.currentStateBar.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.streamingFrameBox)).BeginInit();
            this.SuspendLayout();
            // 
            // currentStateBar
            // 
            this.currentStateBar.BackColor = System.Drawing.Color.Black;
            this.currentStateBar.Controls.Add(this.panel5);
            this.currentStateBar.Controls.Add(this.panel4);
            this.currentStateBar.Controls.Add(this.panel3);
            this.currentStateBar.Controls.Add(this.panel2);
            this.currentStateBar.Controls.Add(this.pictureBox2);
            this.currentStateBar.Controls.Add(this.panel1);
            this.currentStateBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.currentStateBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.currentStateBar.Location = new System.Drawing.Point(0, 688);
            this.currentStateBar.Name = "currentStateBar";
            this.currentStateBar.Size = new System.Drawing.Size(604, 50);
            this.currentStateBar.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.bunifuCustomLabel2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(311, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.panel5.Size = new System.Drawing.Size(187, 50);
            this.panel5.TabIndex = 14;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoEllipsis = true;
            this.bunifuCustomLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("NEXON Football Gothic L", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.Lime;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(0, 15);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(187, 20);
            this.bunifuCustomLabel2.TabIndex = 0;
            this.bunifuCustomLabel2.Text = "위치 정보를 얻어오지 못했습니다.";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.detectingProgressbar);
            this.panel4.Controls.Add(this.detectingLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(498, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(106, 50);
            this.panel4.TabIndex = 13;
            // 
            // detectingProgressbar
            // 
            this.detectingProgressbar.animated = true;
            this.detectingProgressbar.animationIterval = 5;
            this.detectingProgressbar.animationSpeed = 3;
            this.detectingProgressbar.BackColor = System.Drawing.Color.Transparent;
            this.detectingProgressbar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("detectingProgressbar.BackgroundImage")));
            this.detectingProgressbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.detectingProgressbar.ForeColor = System.Drawing.Color.SeaGreen;
            this.detectingProgressbar.LabelVisible = false;
            this.detectingProgressbar.LineProgressThickness = 2;
            this.detectingProgressbar.LineThickness = 2;
            this.detectingProgressbar.Location = new System.Drawing.Point(72, 11);
            this.detectingProgressbar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.detectingProgressbar.MaxValue = 100;
            this.detectingProgressbar.Name = "detectingProgressbar";
            this.detectingProgressbar.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.detectingProgressbar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.detectingProgressbar.Size = new System.Drawing.Size(29, 29);
            this.detectingProgressbar.TabIndex = 7;
            this.detectingProgressbar.Value = 15;
            // 
            // detectingLabel
            // 
            this.detectingLabel.AutoSize = true;
            this.detectingLabel.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detectingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.detectingLabel.Location = new System.Drawing.Point(6, 17);
            this.detectingLabel.Name = "detectingLabel";
            this.detectingLabel.Size = new System.Drawing.Size(70, 16);
            this.detectingLabel.TabIndex = 6;
            this.detectingLabel.Text = "산불감지중";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bunifuCustomLabel1);
            this.panel3.Controls.Add(this.droneSpeedLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(187, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(124, 50);
            this.panel3.TabIndex = 12;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Lime;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(7, 17);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(39, 16);
            this.bunifuCustomLabel1.TabIndex = 5;
            this.bunifuCustomLabel1.Text = "속도 :";
            // 
            // droneSpeedLabel
            // 
            this.droneSpeedLabel.AutoSize = true;
            this.droneSpeedLabel.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.droneSpeedLabel.ForeColor = System.Drawing.Color.Lime;
            this.droneSpeedLabel.Location = new System.Drawing.Point(48, 17);
            this.droneSpeedLabel.Name = "droneSpeedLabel";
            this.droneSpeedLabel.Size = new System.Drawing.Size(57, 16);
            this.droneSpeedLabel.TabIndex = 6;
            this.droneSpeedLabel.Text = "0.0 m/s";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bunifuCustomLabel5);
            this.panel2.Controls.Add(this.droneAltitudeLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(82, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(105, 50);
            this.panel2.TabIndex = 11;
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel5.ForeColor = System.Drawing.Color.Lime;
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(7, 17);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(39, 16);
            this.bunifuCustomLabel5.TabIndex = 5;
            this.bunifuCustomLabel5.Text = "고도 :";
            // 
            // droneAltitudeLabel
            // 
            this.droneAltitudeLabel.AutoSize = true;
            this.droneAltitudeLabel.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.droneAltitudeLabel.ForeColor = System.Drawing.Color.Lime;
            this.droneAltitudeLabel.Location = new System.Drawing.Point(48, 17);
            this.droneAltitudeLabel.Name = "droneAltitudeLabel";
            this.droneAltitudeLabel.Size = new System.Drawing.Size(43, 16);
            this.droneAltitudeLabel.TabIndex = 6;
            this.droneAltitudeLabel.Text = "0.0 m";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(60, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bunifuProgressBar1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 50);
            this.panel1.TabIndex = 9;
            // 
            // bunifuProgressBar1
            // 
            this.bunifuProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuProgressBar1.BorderRadius = 3;
            this.bunifuProgressBar1.Location = new System.Drawing.Point(10, 17);
            this.bunifuProgressBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuProgressBar1.MaximumValue = 100;
            this.bunifuProgressBar1.Name = "bunifuProgressBar1";
            this.bunifuProgressBar1.ProgressColor = System.Drawing.Color.Lime;
            this.bunifuProgressBar1.Size = new System.Drawing.Size(37, 14);
            this.bunifuProgressBar1.TabIndex = 7;
            this.bunifuProgressBar1.Value = 67;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(6, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 20);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // streamingFrameBox
            // 
            this.streamingFrameBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.streamingFrameBox.Image = global::Fire_Detector.Properties.Resources.no_image_available;
            this.streamingFrameBox.Location = new System.Drawing.Point(0, 0);
            this.streamingFrameBox.Name = "streamingFrameBox";
            this.streamingFrameBox.Size = new System.Drawing.Size(604, 688);
            this.streamingFrameBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.streamingFrameBox.TabIndex = 6;
            this.streamingFrameBox.TabStop = false;
            this.streamingFrameBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.streamingFrameBox_MouseClick);
            this.streamingFrameBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.streamingFrameBox_MouseDoubleClick);
            this.streamingFrameBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.streamingFrameBox_MouseMove);
            this.streamingFrameBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.streamingFrameBox_MouseWheel);
            // 
            // sideCollapsedBar
            // 
            this.sideCollapsedBar.BackColor = System.Drawing.Color.LightGray;
            this.sideCollapsedBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.sideCollapsedBar.Location = new System.Drawing.Point(604, 0);
            this.sideCollapsedBar.Name = "sideCollapsedBar";
            this.sideCollapsedBar.Size = new System.Drawing.Size(70, 738);
            this.sideCollapsedBar.TabIndex = 4;
            // 
            // sideExpandedBar
            // 
            this.sideExpandedBar.BackColor = System.Drawing.Color.White;
            this.sideExpandedBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.sideExpandedBar.Location = new System.Drawing.Point(674, 0);
            this.sideExpandedBar.Name = "sideExpandedBar";
            this.sideExpandedBar.Size = new System.Drawing.Size(350, 738);
            this.sideExpandedBar.TabIndex = 1;
            this.sideExpandedBar.Visible = false;
            // 
            // DefaultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.streamingFrameBox);
            this.Controls.Add(this.currentStateBar);
            this.Controls.Add(this.sideCollapsedBar);
            this.Controls.Add(this.sideExpandedBar);
            this.Name = "DefaultView";
            this.Size = new System.Drawing.Size(1024, 738);
            this.currentStateBar.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.streamingFrameBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public SideExpandedBar sideExpandedBar;
        public SideCollapsedBar sideCollapsedBar;
        private System.Windows.Forms.Panel currentStateBar;
        private Bunifu.Framework.UI.BunifuProgressBar bunifuProgressBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox streamingFrameBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        public Bunifu.Framework.UI.BunifuCustomLabel droneAltitudeLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        public Bunifu.Framework.UI.BunifuCustomLabel droneSpeedLabel;
        public Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        public Bunifu.Framework.UI.BunifuCircleProgressbar detectingProgressbar;
        public Bunifu.Framework.UI.BunifuCustomLabel detectingLabel;
    }
}
