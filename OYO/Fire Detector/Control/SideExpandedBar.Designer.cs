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
            this.droneTab = new Fire_Detector.Control.DroneTab();
            this.leapmotionTab = new Fire_Detector.Control.LeapmotionTab();
            this.visualizeTab = new VisualizeTab();
            this.SuspendLayout();
            // 
            // droneTab
            // 
            this.droneTab.BackColor = System.Drawing.Color.Transparent;
            this.droneTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.droneTab.Location = new System.Drawing.Point(0, 0);
            this.droneTab.Name = "droneTab";
            this.droneTab.Size = new System.Drawing.Size(350, 738);
            this.droneTab.TabIndex = 0;
            // 
            // leapmotionTab
            // 
            this.leapmotionTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leapmotionTab.Location = new System.Drawing.Point(0, 0);
            this.leapmotionTab.Name = "leapmotionTab";
            this.leapmotionTab.Size = new System.Drawing.Size(350, 738);
            this.leapmotionTab.TabIndex = 1;
            // 
            // visualizeTab
            // 
            this.visualizeTab.BackColor = System.Drawing.Color.Transparent;
            this.visualizeTab.Location = new System.Drawing.Point(0, 0);
            this.visualizeTab.Name = "visualizeTab";
            this.visualizeTab.Size = new System.Drawing.Size(350, 738);
            this.visualizeTab.TabIndex = 2;
            // 
            // SideExpandedBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.visualizeTab);
            this.Controls.Add(this.leapmotionTab);
            this.Controls.Add(this.droneTab);
            this.Name = "SideExpandedBar";
            this.Size = new System.Drawing.Size(350, 738);
            this.ResumeLayout(false);

        }

        #endregion

        public DroneTab droneTab;
        public LeapmotionTab leapmotionTab;
        public VisualizeTab visualizeTab;
    }
}
