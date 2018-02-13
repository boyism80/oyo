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
            this.connectionPanel = new System.Windows.Forms.Panel();
            this.defaultPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.speedSlider = new Bunifu.Framework.UI.BunifuSlider();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.panel3 = new System.Windows.Forms.Panel();
            this.connectDroneButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.connectDroneProgressbar = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.droneFlightProgressbar = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.landButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.takeoffButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.buttonCollapse = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectDroneButton)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.connectionPanel);
            this.panel2.Controls.Add(this.defaultPanel);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.droneFlightProgressbar);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.buttonCollapse);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 738);
            this.panel2.TabIndex = 17;
            // 
            // connectionPanel
            // 
            this.connectionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.connectionPanel.Location = new System.Drawing.Point(0, 393);
            this.connectionPanel.Name = "connectionPanel";
            this.connectionPanel.Size = new System.Drawing.Size(350, 118);
            this.connectionPanel.TabIndex = 35;
            // 
            // defaultPanel
            // 
            this.defaultPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.defaultPanel.Location = new System.Drawing.Point(0, 268);
            this.defaultPanel.Name = "defaultPanel";
            this.defaultPanel.Size = new System.Drawing.Size(350, 125);
            this.defaultPanel.TabIndex = 34;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.speedSlider);
            this.panel1.Controls.Add(this.bunifuCustomLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 203);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panel1.Size = new System.Drawing.Size(350, 65);
            this.panel1.TabIndex = 33;
            // 
            // speedSlider
            // 
            this.speedSlider.BackColor = System.Drawing.Color.Transparent;
            this.speedSlider.BackgroudColor = System.Drawing.Color.DarkGray;
            this.speedSlider.BorderRadius = 0;
            this.speedSlider.Dock = System.Windows.Forms.DockStyle.Top;
            this.speedSlider.IndicatorColor = System.Drawing.Color.Tomato;
            this.speedSlider.Location = new System.Drawing.Point(20, 35);
            this.speedSlider.MaximumValue = 100;
            this.speedSlider.Name = "speedSlider";
            this.speedSlider.Size = new System.Drawing.Size(310, 28);
            this.speedSlider.TabIndex = 8;
            this.speedSlider.Value = 0;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Gray;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(20, 10);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(74, 25);
            this.bunifuCustomLabel1.TabIndex = 7;
            this.bunifuCustomLabel1.Text = "Speed";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.bunifuSeparator1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 168);
            this.panel6.Margin = new System.Windows.Forms.Padding(5);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(5);
            this.panel6.Size = new System.Drawing.Size(350, 35);
            this.panel6.TabIndex = 32;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bunifuSeparator1.LineThickness = 2;
            this.bunifuSeparator1.Location = new System.Drawing.Point(10, 0);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(326, 35);
            this.bunifuSeparator1.TabIndex = 0;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
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
            this.droneFlightProgressbar.LineProgressThickness = 5;
            this.droneFlightProgressbar.LineThickness = 5;
            this.droneFlightProgressbar.Location = new System.Drawing.Point(147, 628);
            this.droneFlightProgressbar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.droneFlightProgressbar.MaxValue = 100;
            this.droneFlightProgressbar.Name = "droneFlightProgressbar";
            this.droneFlightProgressbar.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.droneFlightProgressbar.ProgressColor = System.Drawing.Color.IndianRed;
            this.droneFlightProgressbar.Size = new System.Drawing.Size(51, 51);
            this.droneFlightProgressbar.TabIndex = 18;
            this.droneFlightProgressbar.Value = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.landButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.takeoffButton, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 688);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 50);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // landButton
            // 
            this.landButton.Activecolor = System.Drawing.Color.IndianRed;
            this.landButton.BackColor = System.Drawing.Color.LightGray;
            this.landButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.landButton.BorderRadius = 0;
            this.landButton.ButtonText = "Land";
            this.landButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.landButton.DisabledColor = System.Drawing.Color.Gray;
            this.landButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.landButton.Iconcolor = System.Drawing.Color.Transparent;
            this.landButton.Iconimage = null;
            this.landButton.Iconimage_right = null;
            this.landButton.Iconimage_right_Selected = null;
            this.landButton.Iconimage_Selected = null;
            this.landButton.IconMarginLeft = 0;
            this.landButton.IconMarginRight = 0;
            this.landButton.IconRightVisible = true;
            this.landButton.IconRightZoom = 0D;
            this.landButton.IconVisible = true;
            this.landButton.IconZoom = 90D;
            this.landButton.IsTab = false;
            this.landButton.Location = new System.Drawing.Point(178, 3);
            this.landButton.Name = "landButton";
            this.landButton.Normalcolor = System.Drawing.Color.LightGray;
            this.landButton.OnHovercolor = System.Drawing.Color.Coral;
            this.landButton.OnHoverTextColor = System.Drawing.Color.White;
            this.landButton.selected = false;
            this.landButton.Size = new System.Drawing.Size(169, 44);
            this.landButton.TabIndex = 2;
            this.landButton.Text = "Land";
            this.landButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.landButton.Textcolor = System.Drawing.Color.White;
            this.landButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.landButton.Click += new System.EventHandler(this.landButton_Click);
            // 
            // takeoffButton
            // 
            this.takeoffButton.Activecolor = System.Drawing.Color.IndianRed;
            this.takeoffButton.BackColor = System.Drawing.Color.LightCoral;
            this.takeoffButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.takeoffButton.BorderRadius = 0;
            this.takeoffButton.ButtonText = "Take off";
            this.takeoffButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.takeoffButton.DisabledColor = System.Drawing.Color.Gray;
            this.takeoffButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.takeoffButton.Iconcolor = System.Drawing.Color.Transparent;
            this.takeoffButton.Iconimage = null;
            this.takeoffButton.Iconimage_right = null;
            this.takeoffButton.Iconimage_right_Selected = null;
            this.takeoffButton.Iconimage_Selected = null;
            this.takeoffButton.IconMarginLeft = 0;
            this.takeoffButton.IconMarginRight = 0;
            this.takeoffButton.IconRightVisible = true;
            this.takeoffButton.IconRightZoom = 0D;
            this.takeoffButton.IconVisible = true;
            this.takeoffButton.IconZoom = 90D;
            this.takeoffButton.IsTab = false;
            this.takeoffButton.Location = new System.Drawing.Point(3, 3);
            this.takeoffButton.Name = "takeoffButton";
            this.takeoffButton.Normalcolor = System.Drawing.Color.LightCoral;
            this.takeoffButton.OnHovercolor = System.Drawing.Color.Coral;
            this.takeoffButton.OnHoverTextColor = System.Drawing.Color.White;
            this.takeoffButton.selected = false;
            this.takeoffButton.Size = new System.Drawing.Size(169, 44);
            this.takeoffButton.TabIndex = 1;
            this.takeoffButton.Text = "Take off";
            this.takeoffButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.takeoffButton.Textcolor = System.Drawing.Color.White;
            this.takeoffButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.takeoffButton.Click += new System.EventHandler(this.takeoffButton_Click);
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
            this.buttonCollapse.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 660);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(350, 28);
            this.panel7.TabIndex = 38;
            // 
            // DroneTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "DroneTab";
            this.Size = new System.Drawing.Size(350, 738);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.connectDroneButton)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCircleProgressbar droneFlightProgressbar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Bunifu.Framework.UI.BunifuFlatButton landButton;
        private Bunifu.Framework.UI.BunifuFlatButton takeoffButton;
        private Bunifu.Framework.UI.BunifuFlatButton buttonCollapse;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuImageButton connectDroneButton;
        private Bunifu.Framework.UI.BunifuCircleProgressbar connectDroneProgressbar;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuSlider speedSlider;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.Panel panel6;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Panel connectionPanel;
        private System.Windows.Forms.Panel defaultPanel;
        private System.Windows.Forms.Panel panel7;
    }
}
