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
            this.panel1 = new System.Windows.Forms.Panel();
            this.speedSlider = new Bunifu.Framework.UI.BunifuSlider();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.buttonCollapse = new Bunifu.Framework.UI.BunifuFlatButton();
            this.droneFlightProgressbar = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.takeoffButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.landButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.speedSlider);
            this.panel1.Controls.Add(this.bunifuCustomLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(350, 65);
            this.panel1.TabIndex = 13;
            // 
            // speedSlider
            // 
            this.speedSlider.BackColor = System.Drawing.Color.Transparent;
            this.speedSlider.BackgroudColor = System.Drawing.Color.DarkGray;
            this.speedSlider.BorderRadius = 0;
            this.speedSlider.Dock = System.Windows.Forms.DockStyle.Top;
            this.speedSlider.IndicatorColor = System.Drawing.Color.Tomato;
            this.speedSlider.Location = new System.Drawing.Point(5, 30);
            this.speedSlider.MaximumValue = 100;
            this.speedSlider.Name = "speedSlider";
            this.speedSlider.Size = new System.Drawing.Size(340, 28);
            this.speedSlider.TabIndex = 8;
            this.speedSlider.Value = 0;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Coral;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(5, 5);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(74, 25);
            this.bunifuCustomLabel1.TabIndex = 7;
            this.bunifuCustomLabel1.Text = "Speed";
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
            this.buttonCollapse.TabIndex = 12;
            this.buttonCollapse.Text = "Drone Control";
            this.buttonCollapse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonCollapse.Textcolor = System.Drawing.Color.White;
            this.buttonCollapse.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCollapse.Click += new System.EventHandler(this.buttonCollapse_Click);
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
            this.droneFlightProgressbar.Location = new System.Drawing.Point(143, 578);
            this.droneFlightProgressbar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.droneFlightProgressbar.MaxValue = 100;
            this.droneFlightProgressbar.Name = "droneFlightProgressbar";
            this.droneFlightProgressbar.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.droneFlightProgressbar.ProgressColor = System.Drawing.Color.IndianRed;
            this.droneFlightProgressbar.Size = new System.Drawing.Size(51, 51);
            this.droneFlightProgressbar.TabIndex = 15;
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
            this.tableLayoutPanel1.TabIndex = 16;
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
            // DroneTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCollapse);
            this.Controls.Add(this.droneFlightProgressbar);
            this.Name = "DroneTab";
            this.Size = new System.Drawing.Size(350, 738);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuSlider speedSlider;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuFlatButton buttonCollapse;
        private Bunifu.Framework.UI.BunifuCircleProgressbar droneFlightProgressbar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Bunifu.Framework.UI.BunifuFlatButton landButton;
        private Bunifu.Framework.UI.BunifuFlatButton takeoffButton;
    }
}
