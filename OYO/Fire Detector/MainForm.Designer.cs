namespace Fire_Detector
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
            this.exitButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuDragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.defaultView = new Fire_Detector.Control.DefaultView();
            this.mainView = new Fire_Detector.Control.MainView();
            this.caption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton1)).BeginInit();
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
            this.caption.Controls.Add(this.exitButton1);
            this.caption.Controls.Add(this.bunifuCustomLabel1);
            this.caption.Dock = System.Windows.Forms.DockStyle.Top;
            this.caption.Location = new System.Drawing.Point(0, 0);
            this.caption.Name = "caption";
            this.caption.Size = new System.Drawing.Size(1024, 30);
            this.caption.TabIndex = 0;
            // 
            // exitButton1
            // 
            this.exitButton1.BackColor = System.Drawing.Color.Transparent;
            this.exitButton1.Image = ((System.Drawing.Image)(resources.GetObject("exitButton1.Image")));
            this.exitButton1.ImageActive = null;
            this.exitButton1.Location = new System.Drawing.Point(994, 5);
            this.exitButton1.Name = "exitButton1";
            this.exitButton1.Size = new System.Drawing.Size(20, 20);
            this.exitButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exitButton1.TabIndex = 5;
            this.exitButton1.TabStop = false;
            this.exitButton1.Zoom = 10;
            this.exitButton1.Click += new System.EventHandler(this.ExitButton_Click);
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
            // bunifuDragControl
            // 
            this.bunifuDragControl.Fixed = true;
            this.bunifuDragControl.Horizontal = true;
            this.bunifuDragControl.TargetControl = this.caption;
            this.bunifuDragControl.Vertical = true;
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
            // mainView
            // 
            this.mainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainView.Location = new System.Drawing.Point(0, 30);
            this.mainView.Name = "mainView";
            this.mainView.Size = new System.Drawing.Size(1024, 738);
            this.mainView.TabIndex = 2;
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
            this.caption.ResumeLayout(false);
            this.caption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse;
        private System.Windows.Forms.Panel caption;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl;
        public Control.DefaultView defaultView;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuImageButton exitButton1;
        public Control.MainView mainView;
    }
}

