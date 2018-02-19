namespace Fire_Detector.BunifuForm
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bunifuElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.caption = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.maximizeButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exitButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.mainView = new Fire_Detector.Control.MainView();
            this.defaultView = new Fire_Detector.Control.DefaultView();
            this.bunifuDragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.caption.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximizeButton)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse
            // 
            this.bunifuElipse.ElipseRadius = 5;
            this.bunifuElipse.TargetControl = this;
            // 
            // caption
            // 
            this.caption.BackColor = System.Drawing.Color.Coral;
            this.caption.Controls.Add(this.panel2);
            this.caption.Controls.Add(this.panel1);
            this.caption.Controls.Add(this.bunifuCustomLabel1);
            this.caption.Dock = System.Windows.Forms.DockStyle.Top;
            this.caption.Location = new System.Drawing.Point(0, 0);
            this.caption.Name = "caption";
            this.caption.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.caption.Size = new System.Drawing.Size(1024, 30);
            this.caption.TabIndex = 0;
            this.caption.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.caption_MouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.maximizeButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(971, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(24, 30);
            this.panel2.TabIndex = 4;
            // 
            // maximizeButton
            // 
            this.maximizeButton.BackColor = System.Drawing.Color.Transparent;
            this.maximizeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maximizeButton.Image = ((System.Drawing.Image)(resources.GetObject("maximizeButton.Image")));
            this.maximizeButton.ImageActive = null;
            this.maximizeButton.Location = new System.Drawing.Point(4, 4);
            this.maximizeButton.Name = "maximizeButton";
            this.maximizeButton.Size = new System.Drawing.Size(16, 22);
            this.maximizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.maximizeButton.TabIndex = 1;
            this.maximizeButton.TabStop = false;
            this.maximizeButton.Zoom = 10;
            this.maximizeButton.Click += new System.EventHandler(this.maximizeButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(995, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(24, 30);
            this.panel1.TabIndex = 3;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exitButton.Image = ((System.Drawing.Image)(resources.GetObject("exitButton.Image")));
            this.exitButton.ImageActive = null;
            this.exitButton.Location = new System.Drawing.Point(4, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(16, 22);
            this.exitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exitButton.TabIndex = 1;
            this.exitButton.TabStop = false;
            this.exitButton.Zoom = 10;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(29, 8);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(83, 15);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "Fire Detector";
            // 
            // mainView
            // 
            this.mainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainView.Location = new System.Drawing.Point(0, 30);
            this.mainView.Name = "mainView";
            this.mainView.Size = new System.Drawing.Size(1024, 738);
            this.mainView.TabIndex = 2;
            // 
            // defaultView
            // 
            this.defaultView.BackColor = System.Drawing.Color.Transparent;
            this.defaultView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultView.Location = new System.Drawing.Point(0, 30);
            this.defaultView.Name = "defaultView";
            this.defaultView.Size = new System.Drawing.Size(1024, 738);
            this.defaultView.TabIndex = 1;
            this.defaultView.Visible = false;
            // 
            // bunifuDragControl
            // 
            this.bunifuDragControl.Fixed = true;
            this.bunifuDragControl.Horizontal = true;
            this.bunifuDragControl.TargetControl = this.caption;
            this.bunifuDragControl.Vertical = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.mainView);
            this.Controls.Add(this.defaultView);
            this.Controls.Add(this.caption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.caption.ResumeLayout(false);
            this.caption.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.maximizeButton)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse;
        private System.Windows.Forms.Panel caption;
        public Control.DefaultView defaultView;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        public Control.MainView mainView;
        private Bunifu.Framework.UI.BunifuImageButton exitButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuImageButton maximizeButton;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl;
    }
}

