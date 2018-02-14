namespace Fire_Detector.Control
{
    partial class DroneTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DroneTab));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.takeoffSwitch = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.detectionStateLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.droneSpeedSlider = new Bunifu.Framework.UI.BunifuSlider();
            this.droneSpeedLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.droneFlightProgressbar = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.bunifuCustomLabel7 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.connectionLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.connectDroneButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.connectDroneProgressbar = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonCollapse = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectDroneButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.buttonCollapse);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 738);
            this.panel2.TabIndex = 17;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.takeoffSwitch);
            this.panel8.Controls.Add(this.detectionStateLabel);
            this.panel8.Controls.Add(this.droneSpeedSlider);
            this.panel8.Controls.Add(this.bunifuCustomLabel2);
            this.panel8.Controls.Add(this.droneSpeedLabel);
            this.panel8.Controls.Add(this.bunifuCustomLabel1);
            this.panel8.Controls.Add(this.droneFlightProgressbar);
            this.panel8.Controls.Add(this.bunifuCustomLabel7);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 229);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(350, 110);
            this.panel8.TabIndex = 40;
            // 
            // takeoffSwitch
            // 
            this.takeoffSwitch.BackColor = System.Drawing.Color.Transparent;
            this.takeoffSwitch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("takeoffSwitch.BackgroundImage")));
            this.takeoffSwitch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.takeoffSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.takeoffSwitch.Location = new System.Drawing.Point(115, 13);
            this.takeoffSwitch.Name = "takeoffSwitch";
            this.takeoffSwitch.OffColor = System.Drawing.Color.Silver;
            this.takeoffSwitch.OnColor = System.Drawing.Color.Salmon;
            this.takeoffSwitch.Size = new System.Drawing.Size(35, 20);
            this.takeoffSwitch.TabIndex = 16;
            this.takeoffSwitch.Value = false;
            this.takeoffSwitch.OnValueChange += new System.EventHandler(this.takeoffSwitch_OnValueChange);
            // 
            // detectionStateLabel
            // 
            this.detectionStateLabel.AutoSize = true;
            this.detectionStateLabel.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.detectionStateLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.detectionStateLabel.Location = new System.Drawing.Point(165, 17);
            this.detectionStateLabel.Name = "detectionStateLabel";
            this.detectionStateLabel.Size = new System.Drawing.Size(49, 15);
            this.detectionStateLabel.TabIndex = 15;
            this.detectionStateLabel.Text = "비행정지";
            // 
            // droneSpeedSlider
            // 
            this.droneSpeedSlider.BackColor = System.Drawing.Color.Transparent;
            this.droneSpeedSlider.BackgroudColor = System.Drawing.Color.DarkGray;
            this.droneSpeedSlider.BorderRadius = 0;
            this.droneSpeedSlider.IndicatorColor = System.Drawing.Color.Salmon;
            this.droneSpeedSlider.Location = new System.Drawing.Point(115, 46);
            this.droneSpeedSlider.MaximumValue = 20;
            this.droneSpeedSlider.Name = "droneSpeedSlider";
            this.droneSpeedSlider.Size = new System.Drawing.Size(160, 28);
            this.droneSpeedSlider.TabIndex = 0;
            this.droneSpeedSlider.Value = 0;
            this.droneSpeedSlider.ValueChanged += new System.EventHandler(this.droneSpeedSlider_ValueChanged);
            // 
            // droneSpeedLabel
            // 
            this.droneSpeedLabel.AutoSize = true;
            this.droneSpeedLabel.ForeColor = System.Drawing.Color.Salmon;
            this.droneSpeedLabel.Location = new System.Drawing.Point(286, 52);
            this.droneSpeedLabel.Name = "droneSpeedLabel";
            this.droneSpeedLabel.Size = new System.Drawing.Size(11, 12);
            this.droneSpeedLabel.TabIndex = 14;
            this.droneSpeedLabel.Text = "0";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(40, 52);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(29, 15);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "속도";
            // 
            // droneFlightProgressbar
            // 
            this.droneFlightProgressbar.animated = false;
            this.droneFlightProgressbar.animationIterval = 5;
            this.droneFlightProgressbar.animationSpeed = 3;
            this.droneFlightProgressbar.BackColor = System.Drawing.Color.Transparent;
            this.droneFlightProgressbar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("droneFlightProgressbar.BackgroundImage")));
            this.droneFlightProgressbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.droneFlightProgressbar.ForeColor = System.Drawing.Color.SeaGreen;
            this.droneFlightProgressbar.LabelVisible = false;
            this.droneFlightProgressbar.LineProgressThickness = 2;
            this.droneFlightProgressbar.LineThickness = 2;
            this.droneFlightProgressbar.Location = new System.Drawing.Point(210, 5);
            this.droneFlightProgressbar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.droneFlightProgressbar.MaxValue = 100;
            this.droneFlightProgressbar.Name = "droneFlightProgressbar";
            this.droneFlightProgressbar.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.droneFlightProgressbar.ProgressColor = System.Drawing.Color.IndianRed;
            this.droneFlightProgressbar.Size = new System.Drawing.Size(35, 35);
            this.droneFlightProgressbar.TabIndex = 18;
            this.droneFlightProgressbar.Value = 0;
            this.droneFlightProgressbar.Visible = false;
            // 
            // bunifuCustomLabel7
            // 
            this.bunifuCustomLabel7.AutoSize = true;
            this.bunifuCustomLabel7.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel7.Location = new System.Drawing.Point(40, 18);
            this.bunifuCustomLabel7.Name = "bunifuCustomLabel7";
            this.bunifuCustomLabel7.Size = new System.Drawing.Size(56, 15);
            this.bunifuCustomLabel7.TabIndex = 0;
            this.bunifuCustomLabel7.Text = "이륙/착륙";
            // 
            // panel9
            // 
            this.panel9.AutoSize = true;
            this.panel9.Controls.Add(this.bunifuCustomLabel3);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 203);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(5);
            this.panel9.Size = new System.Drawing.Size(350, 26);
            this.panel9.TabIndex = 39;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("넥슨 풋볼고딕 B", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.Salmon;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(24, 5);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(32, 16);
            this.bunifuCustomLabel3.TabIndex = 0;
            this.bunifuCustomLabel3.Text = "조종";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.connectionLabel);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 168);
            this.panel6.Margin = new System.Windows.Forms.Padding(5);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(5);
            this.panel6.Size = new System.Drawing.Size(350, 35);
            this.panel6.TabIndex = 32;
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.connectionLabel.ForeColor = System.Drawing.Color.Tomato;
            this.connectionLabel.Location = new System.Drawing.Point(97, 10);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(158, 15);
            this.connectionLabel.TabIndex = 1;
            this.connectionLabel.Text = "드론과 연결 되어있지 않습니다.";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.connectDroneButton);
            this.panel3.Controls.Add(this.connectDroneProgressbar);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 124);
            this.panel3.TabIndex = 30;
            // 
            // connectDroneButton
            // 
            this.connectDroneButton.BackColor = System.Drawing.Color.Transparent;
            this.connectDroneButton.Image = ((System.Drawing.Image)(resources.GetObject("connectDroneButton.Image")));
            this.connectDroneButton.ImageActive = null;
            this.connectDroneButton.Location = new System.Drawing.Point(147, 32);
            this.connectDroneButton.Name = "connectDroneButton";
            this.connectDroneButton.Size = new System.Drawing.Size(63, 61);
            this.connectDroneButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.connectDroneButton.TabIndex = 29;
            this.connectDroneButton.TabStop = false;
            this.connectDroneButton.Zoom = 10;
            this.connectDroneButton.Click += new System.EventHandler(this.connectDroneButton_Click);
            // 
            // connectDroneProgressbar
            // 
            this.connectDroneProgressbar.animated = false;
            this.connectDroneProgressbar.animationIterval = 5;
            this.connectDroneProgressbar.animationSpeed = 20;
            this.connectDroneProgressbar.BackColor = System.Drawing.Color.Transparent;
            this.connectDroneProgressbar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("connectDroneProgressbar.BackgroundImage")));
            this.connectDroneProgressbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.connectDroneProgressbar.ForeColor = System.Drawing.Color.SeaGreen;
            this.connectDroneProgressbar.LabelVisible = false;
            this.connectDroneProgressbar.LineProgressThickness = 5;
            this.connectDroneProgressbar.LineThickness = 5;
            this.connectDroneProgressbar.Location = new System.Drawing.Point(115, 0);
            this.connectDroneProgressbar.Margin = new System.Windows.Forms.Padding(8);
            this.connectDroneProgressbar.MaxValue = 100;
            this.connectDroneProgressbar.Name = "connectDroneProgressbar";
            this.connectDroneProgressbar.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.connectDroneProgressbar.ProgressColor = System.Drawing.Color.OrangeRed;
            this.connectDroneProgressbar.Size = new System.Drawing.Size(125, 125);
            this.connectDroneProgressbar.TabIndex = 2;
            this.connectDroneProgressbar.Value = 0;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(104, 124);
            this.panel5.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(252, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(98, 124);
            this.panel4.TabIndex = 0;
            // 
            // buttonCollapse
            // 
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
            this.buttonCollapse.TabIndex = 13;
            this.buttonCollapse.Text = "Drone Control";
            this.buttonCollapse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonCollapse.Textcolor = System.Drawing.Color.White;
            this.buttonCollapse.TextFont = new System.Drawing.Font("넥슨 풋볼고딕 B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCollapse.Click += new System.EventHandler(this.buttonCollapse_Click);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(303, 52);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(43, 12);
            this.bunifuCustomLabel2.TabIndex = 14;
            this.bunifuCustomLabel2.Text = "m/sec";
            // 
            // DroneTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel2);
            this.Name = "DroneTab";
            this.Size = new System.Drawing.Size(350, 738);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.connectDroneButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCircleProgressbar droneFlightProgressbar;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuImageButton connectDroneButton;
        private Bunifu.Framework.UI.BunifuCircleProgressbar connectDroneProgressbar;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private Bunifu.Framework.UI.BunifuFlatButton buttonCollapse;
        private System.Windows.Forms.Panel panel8;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel7;
        private System.Windows.Forms.Panel panel9;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuCustomLabel connectionLabel;
        private Bunifu.Framework.UI.BunifuSlider droneSpeedSlider;
        private Bunifu.Framework.UI.BunifuCustomLabel droneSpeedLabel;
        private Bunifu.Framework.UI.BunifuiOSSwitch takeoffSwitch;
        private Bunifu.Framework.UI.BunifuCustomLabel detectionStateLabel;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
    }
}
