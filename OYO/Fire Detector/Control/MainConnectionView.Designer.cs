namespace Fire_Detector.Control
{
    partial class MainConnectionView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainConnectionView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.leapmotionNameLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.leapmotionPanel = new System.Windows.Forms.Panel();
            this.leapMotionImageButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.leapmotionProgressbar = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.raspCamNameLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.raspCamPanel = new System.Windows.Forms.Panel();
            this.raspCamImageButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.raspCamProgressbar = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.droneNameLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dronePanel = new System.Windows.Forms.Panel();
            this.droneImageButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.droneProgressbar = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.leapmotionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leapMotionImageButton)).BeginInit();
            this.panel2.SuspendLayout();
            this.raspCamPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.raspCamImageButton)).BeginInit();
            this.panel1.SuspendLayout();
            this.dronePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.droneImageButton)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1024, 510);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.leapmotionNameLabel);
            this.panel3.Controls.Add(this.leapmotionPanel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(685, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(336, 504);
            this.panel3.TabIndex = 2;
            // 
            // bunifuCustomLabel8
            // 
            this.leapmotionNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.leapmotionNameLabel.Font = new System.Drawing.Font("NEXON Football Gothic B", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leapmotionNameLabel.ForeColor = System.Drawing.Color.Coral;
            this.leapmotionNameLabel.Location = new System.Drawing.Point(0, 247);
            this.leapmotionNameLabel.Name = "bunifuCustomLabel8";
            this.leapmotionNameLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.leapmotionNameLabel.Size = new System.Drawing.Size(336, 50);
            this.leapmotionNameLabel.TabIndex = 35;
            this.leapmotionNameLabel.Text = "Leapmotion";
            this.leapmotionNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // leapmotionPanel
            // 
            this.leapmotionPanel.AutoSize = true;
            this.leapmotionPanel.Controls.Add(this.leapMotionImageButton);
            this.leapmotionPanel.Controls.Add(this.leapmotionProgressbar);
            this.leapmotionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.leapmotionPanel.Location = new System.Drawing.Point(0, 0);
            this.leapmotionPanel.Name = "leapmotionPanel";
            this.leapmotionPanel.Size = new System.Drawing.Size(336, 247);
            this.leapmotionPanel.TabIndex = 33;
            this.leapmotionPanel.Tag = this.leapmotionProgressbar;
            // 
            // leapMotionImageButton
            // 
            this.leapMotionImageButton.BackColor = System.Drawing.Color.Transparent;
            this.leapMotionImageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.leapMotionImageButton.Image = ((System.Drawing.Image)(resources.GetObject("leapMotionImageButton.Image")));
            this.leapMotionImageButton.ImageActive = null;
            this.leapMotionImageButton.Location = new System.Drawing.Point(126, 86);
            this.leapMotionImageButton.Name = "leapMotionImageButton";
            this.leapMotionImageButton.Size = new System.Drawing.Size(90, 90);
            this.leapMotionImageButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.leapMotionImageButton.TabIndex = 37;
            this.leapMotionImageButton.TabStop = false;
            this.leapMotionImageButton.Zoom = 10;
            this.leapMotionImageButton.Tag = this.leapmotionNameLabel;
            this.leapMotionImageButton.Click += new System.EventHandler(this.leapMotionImageButton_Click);
            // 
            // leapmotionProgressbar
            // 
            this.leapmotionProgressbar.animated = false;
            this.leapmotionProgressbar.animationIterval = 5;
            this.leapmotionProgressbar.animationSpeed = 3;
            this.leapmotionProgressbar.BackColor = System.Drawing.Color.Transparent;
            this.leapmotionProgressbar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leapmotionProgressbar.BackgroundImage")));
            this.leapmotionProgressbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.leapmotionProgressbar.ForeColor = System.Drawing.Color.Tomato;
            this.leapmotionProgressbar.LabelVisible = false;
            this.leapmotionProgressbar.LineProgressThickness = 5;
            this.leapmotionProgressbar.LineThickness = 5;
            this.leapmotionProgressbar.Location = new System.Drawing.Point(84, 38);
            this.leapmotionProgressbar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.leapmotionProgressbar.MaxValue = 100;
            this.leapmotionProgressbar.Name = "leapmotionProgressbar";
            this.leapmotionProgressbar.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.leapmotionProgressbar.ProgressColor = System.Drawing.Color.Tomato;
            this.leapmotionProgressbar.Size = new System.Drawing.Size(200, 200);
            this.leapmotionProgressbar.TabIndex = 36;
            this.leapmotionProgressbar.Value = 0;
            this.leapmotionProgressbar.Tag = this.leapMotionImageButton;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.raspCamNameLabel);
            this.panel2.Controls.Add(this.raspCamPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(344, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(335, 504);
            this.panel2.TabIndex = 1;
            // 
            // bunifuCustomLabel7
            // 
            this.raspCamNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.raspCamNameLabel.Font = new System.Drawing.Font("NEXON Football Gothic B", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raspCamNameLabel.ForeColor = System.Drawing.Color.Coral;
            this.raspCamNameLabel.Location = new System.Drawing.Point(0, 247);
            this.raspCamNameLabel.Name = "bunifuCustomLabel7";
            this.raspCamNameLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.raspCamNameLabel.Size = new System.Drawing.Size(335, 50);
            this.raspCamNameLabel.TabIndex = 32;
            this.raspCamNameLabel.Text = "RaspCam";
            this.raspCamNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // raspCamPanel
            // 
            this.raspCamPanel.AutoSize = true;
            this.raspCamPanel.Controls.Add(this.raspCamImageButton);
            this.raspCamPanel.Controls.Add(this.raspCamProgressbar);
            this.raspCamPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.raspCamPanel.Location = new System.Drawing.Point(0, 0);
            this.raspCamPanel.Name = "raspCamPanel";
            this.raspCamPanel.Size = new System.Drawing.Size(335, 247);
            this.raspCamPanel.TabIndex = 31;
            this.raspCamPanel.Tag = this.raspCamProgressbar;
            // 
            // raspCamImageButton
            // 
            this.raspCamImageButton.BackColor = System.Drawing.Color.Transparent;
            this.raspCamImageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.raspCamImageButton.Image = ((System.Drawing.Image)(resources.GetObject("raspCamImageButton.Image")));
            this.raspCamImageButton.ImageActive = null;
            this.raspCamImageButton.Location = new System.Drawing.Point(114, 82);
            this.raspCamImageButton.Name = "raspCamImageButton";
            this.raspCamImageButton.Size = new System.Drawing.Size(110, 110);
            this.raspCamImageButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.raspCamImageButton.TabIndex = 34;
            this.raspCamImageButton.TabStop = false;
            this.raspCamImageButton.Zoom = 10;
            this.raspCamImageButton.Tag = this.raspCamNameLabel;
            this.raspCamImageButton.Click += new System.EventHandler(this.raspCamImageButton_Click);
            // 
            // raspCamProgressbar
            // 
            this.raspCamProgressbar.animated = false;
            this.raspCamProgressbar.animationIterval = 5;
            this.raspCamProgressbar.animationSpeed = 3;
            this.raspCamProgressbar.BackColor = System.Drawing.Color.Transparent;
            this.raspCamProgressbar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("raspCamProgressbar.BackgroundImage")));
            this.raspCamProgressbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.raspCamProgressbar.ForeColor = System.Drawing.Color.Tomato;
            this.raspCamProgressbar.LabelVisible = false;
            this.raspCamProgressbar.LineProgressThickness = 5;
            this.raspCamProgressbar.LineThickness = 5;
            this.raspCamProgressbar.Location = new System.Drawing.Point(69, 38);
            this.raspCamProgressbar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.raspCamProgressbar.MaxValue = 100;
            this.raspCamProgressbar.Name = "raspCamProgressbar";
            this.raspCamProgressbar.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.raspCamProgressbar.ProgressColor = System.Drawing.Color.Tomato;
            this.raspCamProgressbar.Size = new System.Drawing.Size(200, 200);
            this.raspCamProgressbar.TabIndex = 33;
            this.raspCamProgressbar.Value = 0;
            this.raspCamProgressbar.Tag = this.raspCamImageButton;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.droneNameLabel);
            this.panel1.Controls.Add(this.dronePanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 504);
            this.panel1.TabIndex = 0;
            // 
            // bunifuCustomLabel6
            // 
            this.droneNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.droneNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.droneNameLabel.Font = new System.Drawing.Font("NEXON Football Gothic B", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.droneNameLabel.ForeColor = System.Drawing.Color.Coral;
            this.droneNameLabel.Location = new System.Drawing.Point(0, 247);
            this.droneNameLabel.Name = "bunifuCustomLabel6";
            this.droneNameLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.droneNameLabel.Size = new System.Drawing.Size(335, 50);
            this.droneNameLabel.TabIndex = 34;
            this.droneNameLabel.Text = "Drone";
            this.droneNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dronePanel
            // 
            this.dronePanel.AutoSize = true;
            this.dronePanel.Controls.Add(this.droneImageButton);
            this.dronePanel.Controls.Add(this.droneProgressbar);
            this.dronePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.dronePanel.Location = new System.Drawing.Point(0, 0);
            this.dronePanel.Name = "dronePanel";
            this.dronePanel.Size = new System.Drawing.Size(335, 247);
            this.dronePanel.TabIndex = 33;
            this.dronePanel.Tag = this.droneProgressbar;
            // 
            // droneImageButton
            // 
            this.droneImageButton.BackColor = System.Drawing.Color.Transparent;
            this.droneImageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.droneImageButton.Image = ((System.Drawing.Image)(resources.GetObject("droneImageButton.Image")));
            this.droneImageButton.ImageActive = null;
            this.droneImageButton.Location = new System.Drawing.Point(124, 82);
            this.droneImageButton.Name = "droneImageButton";
            this.droneImageButton.Size = new System.Drawing.Size(110, 110);
            this.droneImageButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.droneImageButton.TabIndex = 32;
            this.droneImageButton.TabStop = false;
            this.droneImageButton.Zoom = 10;
            this.droneImageButton.Tag = this.droneNameLabel;
            this.droneImageButton.Click += new System.EventHandler(this.droneImageButton_Click);
            // 
            // droneProgressbar
            // 
            this.droneProgressbar.animated = false;
            this.droneProgressbar.animationIterval = 5;
            this.droneProgressbar.animationSpeed = 3;
            this.droneProgressbar.BackColor = System.Drawing.Color.Transparent;
            this.droneProgressbar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("droneProgressbar.BackgroundImage")));
            this.droneProgressbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.droneProgressbar.ForeColor = System.Drawing.Color.Tomato;
            this.droneProgressbar.LabelVisible = false;
            this.droneProgressbar.LineProgressThickness = 5;
            this.droneProgressbar.LineThickness = 5;
            this.droneProgressbar.Location = new System.Drawing.Point(80, 38);
            this.droneProgressbar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.droneProgressbar.MaxValue = 100;
            this.droneProgressbar.Name = "droneProgressbar";
            this.droneProgressbar.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.droneProgressbar.ProgressColor = System.Drawing.Color.Tomato;
            this.droneProgressbar.Size = new System.Drawing.Size(200, 200);
            this.droneProgressbar.TabIndex = 30;
            this.droneProgressbar.Value = 0;
            this.droneProgressbar.Tag = this.droneImageButton;
            // 
            // MainConnectionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainConnectionView";
            this.Size = new System.Drawing.Size(1024, 510);
            this.Load += new System.EventHandler(this.MainConnectionView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.leapmotionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leapMotionImageButton)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.raspCamPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.raspCamImageButton)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.dronePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.droneImageButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuImageButton droneImageButton;
        private Bunifu.Framework.UI.BunifuCircleProgressbar droneProgressbar;
        private Bunifu.Framework.UI.BunifuCustomLabel droneNameLabel;
        private System.Windows.Forms.Panel dronePanel;
        private Bunifu.Framework.UI.BunifuCustomLabel raspCamNameLabel;
        private System.Windows.Forms.Panel raspCamPanel;
        private Bunifu.Framework.UI.BunifuImageButton raspCamImageButton;
        private Bunifu.Framework.UI.BunifuCircleProgressbar raspCamProgressbar;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuCustomLabel leapmotionNameLabel;
        private System.Windows.Forms.Panel leapmotionPanel;
        private Bunifu.Framework.UI.BunifuImageButton leapMotionImageButton;
        private Bunifu.Framework.UI.BunifuCircleProgressbar leapmotionProgressbar;
    }
}
