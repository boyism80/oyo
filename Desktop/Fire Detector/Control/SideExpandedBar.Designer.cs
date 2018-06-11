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
            this.detectFireTab = new Fire_Detector.Control.SideTabView.DetectFireTab();
            this.leapmotionTab = new Fire_Detector.Control.SideTabView.LeapmotionTab();
            this.visualizeTab = new Fire_Detector.Control.SideTabView.VisualizeTab();
            this.droneTab = new Fire_Detector.Control.SideTabView.DroneTab();
            this.autoFlyingTab = new Fire_Detector.Control.SideTabView.AutoFlyingTab();
            this.SuspendLayout();
            // 
            // buttonCollapse
            // 
            this.buttonCollapse.Active = false;
            this.buttonCollapse.Activecolor = System.Drawing.Color.Tomato;
            this.buttonCollapse.BackColor = System.Drawing.Color.Tomato;
            this.buttonCollapse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonCollapse.BorderRadius = 0;
            this.buttonCollapse.ButtonText = "Drone Control";
            this.buttonCollapse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCollapse.DisabledColor = System.Drawing.Color.Gray;
            this.buttonCollapse.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCollapse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.buttonCollapse.IconZoom = 30D;
            this.buttonCollapse.IsTab = false;
            this.buttonCollapse.Location = new System.Drawing.Point(0, 0);
            this.buttonCollapse.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.buttonCollapse.Name = "buttonCollapse";
            this.buttonCollapse.Normalcolor = System.Drawing.Color.Tomato;
            this.buttonCollapse.OnHovercolor = System.Drawing.Color.Tomato;
            this.buttonCollapse.OnHoverTextColor = System.Drawing.Color.White;
            this.buttonCollapse.selected = false;
            this.buttonCollapse.Size = new System.Drawing.Size(350, 44);
            this.buttonCollapse.TabIndex = 14;
            this.buttonCollapse.Text = "Drone Control";
            this.buttonCollapse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonCollapse.Textcolor = System.Drawing.Color.White;
            this.buttonCollapse.TextFont = new System.Drawing.Font("NEXON Football Gothic B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCollapse.Click += new System.EventHandler(this.buttonCollapse_Click);
            // 
            // detectFireTab
            // 
            this.detectFireTab.BackColor = System.Drawing.Color.Transparent;
            this.detectFireTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detectFireTab.Location = new System.Drawing.Point(0, 44);
            this.detectFireTab.Name = "detectFireTab";
            this.detectFireTab.Size = new System.Drawing.Size(350, 694);
            this.detectFireTab.TabIndex = 18;
            this.detectFireTab.Tag = "Detecting Fire";
            // 
            // leapmotionTab
            // 
            this.leapmotionTab.BackColor = System.Drawing.Color.Transparent;
            this.leapmotionTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leapmotionTab.Location = new System.Drawing.Point(0, 44);
            this.leapmotionTab.Name = "leapmotionTab";
            this.leapmotionTab.Size = new System.Drawing.Size(350, 694);
            this.leapmotionTab.TabIndex = 17;
            this.leapmotionTab.Tag = "Leapmotion";
            // 
            // visualizeTab
            // 
            this.visualizeTab.BackColor = System.Drawing.Color.Transparent;
            this.visualizeTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualizeTab.Location = new System.Drawing.Point(0, 44);
            this.visualizeTab.Name = "visualizeTab";
            this.visualizeTab.Size = new System.Drawing.Size(350, 694);
            this.visualizeTab.TabIndex = 16;
            this.visualizeTab.Tag = "Visualization";
            // 
            // droneTab
            // 
            this.droneTab.BackColor = System.Drawing.Color.Transparent;
            this.droneTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.droneTab.Location = new System.Drawing.Point(0, 44);
            this.droneTab.Name = "droneTab";
            this.droneTab.Size = new System.Drawing.Size(350, 694);
            this.droneTab.TabIndex = 15;
            this.droneTab.Tag = "Drone Control";
            // 
            // autoFlyingTab1
            // 
            this.autoFlyingTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoFlyingTab.Location = new System.Drawing.Point(0, 44);
            this.autoFlyingTab.Name = "autoFlyingTab1";
            this.autoFlyingTab.Size = new System.Drawing.Size(350, 694);
            this.autoFlyingTab.TabIndex = 19;
            // 
            // SideExpandedBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.autoFlyingTab);
            this.Controls.Add(this.detectFireTab);
            this.Controls.Add(this.leapmotionTab);
            this.Controls.Add(this.visualizeTab);
            this.Controls.Add(this.droneTab);
            this.Controls.Add(this.buttonCollapse);
            this.Name = "SideExpandedBar";
            this.Size = new System.Drawing.Size(350, 738);
            this.Load += new System.EventHandler(this.SideExpandedBar_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuFlatButton buttonCollapse;
        public SideTabView.DroneTab droneTab;
        public SideTabView.VisualizeTab visualizeTab;
        public SideTabView.LeapmotionTab leapmotionTab;
        public SideTabView.DetectFireTab detectFireTab;
        public SideTabView.AutoFlyingTab autoFlyingTab;
    }
}
