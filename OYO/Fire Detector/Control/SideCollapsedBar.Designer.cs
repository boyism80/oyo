namespace Fire_Detector.Control
{
    partial class SideCollapsedBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SideCollapsedBar));
            this.buttonExpand = new Bunifu.Framework.UI.BunifuImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExpand)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExpand
            // 
            this.buttonExpand.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonExpand.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonExpand.Image = ((System.Drawing.Image)(resources.GetObject("buttonExpand.Image")));
            this.buttonExpand.ImageActive = null;
            this.buttonExpand.Location = new System.Drawing.Point(0, 0);
            this.buttonExpand.Name = "buttonExpand";
            this.buttonExpand.Size = new System.Drawing.Size(50, 50);
            this.buttonExpand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonExpand.TabIndex = 0;
            this.buttonExpand.TabStop = false;
            this.buttonExpand.Zoom = 1;
            this.buttonExpand.Click += new System.EventHandler(this.buttonExpand_Click);
            // 
            // SideCollapsedBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.buttonExpand);
            this.Name = "SideCollapsedBar";
            this.Size = new System.Drawing.Size(50, 738);
            ((System.ComponentModel.ISupportInitialize)(this.buttonExpand)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuImageButton buttonExpand;
    }
}
