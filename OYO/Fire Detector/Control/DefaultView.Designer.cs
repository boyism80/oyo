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
            this.currentStateBar = new System.Windows.Forms.Panel();
            this.streamingFrameBox = new System.Windows.Forms.PictureBox();
            this.sideExpandedBar = new Fire_Detector.Control.SideExpandedBar();
            this.sideCollapsedBar = new Fire_Detector.Control.SideCollapsedBar();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.currentStateBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.streamingFrameBox)).BeginInit();
            this.SuspendLayout();
            // 
            // currentStateBar
            // 
            this.currentStateBar.BackColor = System.Drawing.Color.Black;
            this.currentStateBar.Controls.Add(this.bunifuCustomLabel1);
            this.currentStateBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.currentStateBar.Location = new System.Drawing.Point(0, 688);
            this.currentStateBar.Name = "currentStateBar";
            this.currentStateBar.Size = new System.Drawing.Size(724, 50);
            this.currentStateBar.TabIndex = 2;
            // 
            // streamingFrameBox
            // 
            this.streamingFrameBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.streamingFrameBox.Image = global::Fire_Detector.Properties.Resources._34620595595_b4c90a2e22_b;
            this.streamingFrameBox.Location = new System.Drawing.Point(0, 0);
            this.streamingFrameBox.Name = "streamingFrameBox";
            this.streamingFrameBox.Size = new System.Drawing.Size(724, 688);
            this.streamingFrameBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.streamingFrameBox.TabIndex = 3;
            this.streamingFrameBox.TabStop = false;
            // 
            // sideExpandedBar
            // 
            this.sideExpandedBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sideExpandedBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.sideExpandedBar.Location = new System.Drawing.Point(724, 0);
            this.sideExpandedBar.Name = "sideExpandedBar";
            this.sideExpandedBar.Size = new System.Drawing.Size(250, 738);
            this.sideExpandedBar.TabIndex = 1;
            // 
            // sideCollapsedBar
            // 
            this.sideCollapsedBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sideCollapsedBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.sideCollapsedBar.Location = new System.Drawing.Point(974, 0);
            this.sideCollapsedBar.Name = "sideCollapsedBar";
            this.sideCollapsedBar.Size = new System.Drawing.Size(50, 738);
            this.sideCollapsedBar.TabIndex = 0;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(27, 21);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(120, 12);
            this.bunifuCustomLabel1.TabIndex = 4;
            this.bunifuCustomLabel1.Text = "bunifuCustomLabel1";
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel currentStateBar;
        public SideCollapsedBar sideCollapsedBar;
        public SideExpandedBar sideExpandedBar;
        private System.Windows.Forms.PictureBox streamingFrameBox;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
    }
}
