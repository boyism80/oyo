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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bunifuProgressBar1 = new Bunifu.Framework.UI.BunifuProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCircleProgressbar2 = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel7 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.droneAltitudeLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.droneLonLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.droneLatLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.streamingFrameBox = new System.Windows.Forms.PictureBox();
            this.sideCollapsedBar = new Fire_Detector.Control.SideCollapsedBar();
            this.sideExpandedBar = new Fire_Detector.Control.SideExpandedBar();
            this.currentStateBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.streamingFrameBox)).BeginInit();
            this.SuspendLayout();
            // 
            // currentStateBar
            // 
            this.currentStateBar.BackColor = System.Drawing.Color.Black;
            this.currentStateBar.Controls.Add(this.pictureBox2);
            this.currentStateBar.Controls.Add(this.bunifuProgressBar1);
            this.currentStateBar.Controls.Add(this.pictureBox1);
            this.currentStateBar.Controls.Add(this.bunifuCircleProgressbar2);
            this.currentStateBar.Controls.Add(this.bunifuCustomLabel4);
            this.currentStateBar.Controls.Add(this.bunifuCustomLabel7);
            this.currentStateBar.Controls.Add(this.bunifuCustomLabel6);
            this.currentStateBar.Controls.Add(this.bunifuCustomLabel5);
            this.currentStateBar.Controls.Add(this.droneAltitudeLabel);
            this.currentStateBar.Controls.Add(this.bunifuCustomLabel3);
            this.currentStateBar.Controls.Add(this.droneLonLabel);
            this.currentStateBar.Controls.Add(this.droneLatLabel);
            this.currentStateBar.Controls.Add(this.bunifuCustomLabel2);
            this.currentStateBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.currentStateBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.currentStateBar.Location = new System.Drawing.Point(0, 688);
            this.currentStateBar.Name = "currentStateBar";
            this.currentStateBar.Size = new System.Drawing.Size(604, 50);
            this.currentStateBar.TabIndex = 5;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(66, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // bunifuProgressBar1
            // 
            this.bunifuProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuProgressBar1.BorderRadius = 3;
            this.bunifuProgressBar1.Location = new System.Drawing.Point(17, 18);
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
            this.bunifuCircleProgressbar2.Location = new System.Drawing.Point(574, 10);
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
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(508, 16);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(70, 16);
            this.bunifuCustomLabel4.TabIndex = 4;
            this.bunifuCustomLabel4.Text = "산불감지중";
            // 
            // bunifuCustomLabel7
            // 
            this.bunifuCustomLabel7.AutoSize = true;
            this.bunifuCustomLabel7.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel7.ForeColor = System.Drawing.Color.Lime;
            this.bunifuCustomLabel7.Location = new System.Drawing.Point(401, 16);
            this.bunifuCustomLabel7.Name = "bunifuCustomLabel7";
            this.bunifuCustomLabel7.Size = new System.Drawing.Size(39, 16);
            this.bunifuCustomLabel7.TabIndex = 4;
            this.bunifuCustomLabel7.Text = "속도 :";
            // 
            // bunifuCustomLabel6
            // 
            this.bunifuCustomLabel6.AutoSize = true;
            this.bunifuCustomLabel6.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel6.ForeColor = System.Drawing.Color.Lime;
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(442, 16);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(57, 16);
            this.bunifuCustomLabel6.TabIndex = 4;
            this.bunifuCustomLabel6.Text = "0.0 m/s";
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel5.ForeColor = System.Drawing.Color.Lime;
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(302, 16);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(39, 16);
            this.bunifuCustomLabel5.TabIndex = 4;
            this.bunifuCustomLabel5.Text = "고도 :";
            // 
            // droneAltitudeLabel
            // 
            this.droneAltitudeLabel.AutoSize = true;
            this.droneAltitudeLabel.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.droneAltitudeLabel.ForeColor = System.Drawing.Color.Lime;
            this.droneAltitudeLabel.Location = new System.Drawing.Point(343, 16);
            this.droneAltitudeLabel.Name = "droneAltitudeLabel";
            this.droneAltitudeLabel.Size = new System.Drawing.Size(43, 16);
            this.droneAltitudeLabel.TabIndex = 4;
            this.droneAltitudeLabel.Text = "0.0 m";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.Lime;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(207, 16);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(39, 16);
            this.bunifuCustomLabel3.TabIndex = 4;
            this.bunifuCustomLabel3.Text = "경도 :";
            // 
            // droneLonLabel
            // 
            this.droneLonLabel.AutoSize = true;
            this.droneLonLabel.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.droneLonLabel.ForeColor = System.Drawing.Color.Lime;
            this.droneLonLabel.Location = new System.Drawing.Point(248, 16);
            this.droneLonLabel.Name = "droneLonLabel";
            this.droneLonLabel.Size = new System.Drawing.Size(28, 16);
            this.droneLonLabel.TabIndex = 4;
            this.droneLonLabel.Text = "0.0";
            // 
            // droneLatLabel
            // 
            this.droneLatLabel.AutoSize = true;
            this.droneLatLabel.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.droneLatLabel.ForeColor = System.Drawing.Color.Lime;
            this.droneLatLabel.Location = new System.Drawing.Point(146, 16);
            this.droneLatLabel.Name = "droneLatLabel";
            this.droneLatLabel.Size = new System.Drawing.Size(28, 16);
            this.droneLatLabel.TabIndex = 4;
            this.droneLatLabel.Text = "0.0";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.Lime;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(104, 16);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(39, 16);
            this.bunifuCustomLabel2.TabIndex = 4;
            this.bunifuCustomLabel2.Text = "위도 :";
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
            this.currentStateBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private Bunifu.Framework.UI.BunifuCircleProgressbar bunifuCircleProgressbar2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        public System.Windows.Forms.PictureBox streamingFrameBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel7;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        public Bunifu.Framework.UI.BunifuCustomLabel droneLonLabel;
        public Bunifu.Framework.UI.BunifuCustomLabel droneLatLabel;
        public Bunifu.Framework.UI.BunifuCustomLabel droneAltitudeLabel;
    }
}
