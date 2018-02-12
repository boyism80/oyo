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
            this.bunifuElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.caption = new System.Windows.Forms.Panel();
            this.bunifuDragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.defaultView = new Fire_Detector.Control.DefaultView();
            this.SuspendLayout();
            // 
            // bunifuElipse
            // 
            this.bunifuElipse.ElipseRadius = 5;
            this.bunifuElipse.TargetControl = this;
            // 
            // caption
            // 
            this.caption.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.caption.Dock = System.Windows.Forms.DockStyle.Top;
            this.caption.Location = new System.Drawing.Point(0, 0);
            this.caption.Name = "caption";
            this.caption.Size = new System.Drawing.Size(1024, 30);
            this.caption.TabIndex = 0;
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
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.defaultView);
            this.Controls.Add(this.caption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse;
        private System.Windows.Forms.Panel caption;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl;
        public Control.DefaultView defaultView;
    }
}

