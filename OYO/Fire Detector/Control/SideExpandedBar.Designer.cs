namespace Fire_Detector.Control
{
    partial class SideExpandedBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SideExpandedBar));
            this.buttonCollapse = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // buttonCollapse
            // 
            this.buttonCollapse.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.buttonCollapse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.buttonCollapse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCollapse.BorderRadius = 0;
            this.buttonCollapse.ButtonText = "bunifuFlatButton1";
            this.buttonCollapse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCollapse.DisabledColor = System.Drawing.Color.Gray;
            this.buttonCollapse.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCollapse.Iconcolor = System.Drawing.Color.Transparent;
            this.buttonCollapse.Iconimage = ((System.Drawing.Image)(resources.GetObject("buttonCollapse.Iconimage")));
            this.buttonCollapse.Iconimage_right = null;
            this.buttonCollapse.Iconimage_right_Selected = null;
            this.buttonCollapse.Iconimage_Selected = null;
            this.buttonCollapse.IconMarginLeft = 0;
            this.buttonCollapse.IconMarginRight = 0;
            this.buttonCollapse.IconRightVisible = true;
            this.buttonCollapse.IconRightZoom = 0D;
            this.buttonCollapse.IconVisible = true;
            this.buttonCollapse.IconZoom = 90D;
            this.buttonCollapse.IsTab = false;
            this.buttonCollapse.Location = new System.Drawing.Point(0, 0);
            this.buttonCollapse.Name = "buttonCollapse";
            this.buttonCollapse.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.buttonCollapse.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.buttonCollapse.OnHoverTextColor = System.Drawing.Color.White;
            this.buttonCollapse.selected = false;
            this.buttonCollapse.Size = new System.Drawing.Size(250, 44);
            this.buttonCollapse.TabIndex = 0;
            this.buttonCollapse.Text = "bunifuFlatButton1";
            this.buttonCollapse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCollapse.Textcolor = System.Drawing.Color.White;
            this.buttonCollapse.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCollapse.Click += new System.EventHandler(this.buttonCollapse_Click);
            // 
            // SideExpandedBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.buttonCollapse);
            this.Name = "SideExpandedBar";
            this.Size = new System.Drawing.Size(250, 738);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuFlatButton buttonCollapse;
    }
}
