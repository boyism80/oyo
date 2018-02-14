namespace Fire_Detector.Control
{
    partial class VisualizeTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualizeTab));
            this.connectionLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.connectionCameraProgressbar = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.blendingViewButton = new Bunifu.Framework.UI.BunifuTileButton();
            this.infraredViewButton = new Bunifu.Framework.UI.BunifuTileButton();
            this.visualViewButton = new Bunifu.Framework.UI.BunifuTileButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.palettesDropDown = new Bunifu.Framework.UI.BunifuDropdown();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCheckbox1 = new Bunifu.Framework.UI.BunifuCheckbox();
            this.bunifuRange1 = new Bunifu.Framework.UI.BunifuRange();
            this.panel7 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.connectionLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.connectionLabel.Location = new System.Drawing.Point(102, 10);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(284, 30);
            this.connectionLabel.TabIndex = 1;
            this.connectionLabel.Text = "서버와 연결되지 않았습니다.";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Gray;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(108, 40);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(201, 12);
            this.bunifuCustomLabel1.TabIndex = 2;
            this.bunifuCustomLabel1.Text = "아이콘을 눌러 상태를 변경하십시오.";
            // 
            // connectionCameraProgressbar
            // 
            this.connectionCameraProgressbar.animated = false;
            this.connectionCameraProgressbar.animationIterval = 5;
            this.connectionCameraProgressbar.animationSpeed = 30;
            this.connectionCameraProgressbar.BackColor = System.Drawing.Color.Transparent;
            this.connectionCameraProgressbar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("connectionCameraProgressbar.BackgroundImage")));
            this.connectionCameraProgressbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.connectionCameraProgressbar.ForeColor = System.Drawing.Color.SeaGreen;
            this.connectionCameraProgressbar.LabelVisible = false;
            this.connectionCameraProgressbar.LineProgressThickness = 8;
            this.connectionCameraProgressbar.LineThickness = 5;
            this.connectionCameraProgressbar.Location = new System.Drawing.Point(0, 0);
            this.connectionCameraProgressbar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.connectionCameraProgressbar.MaxValue = 100;
            this.connectionCameraProgressbar.Name = "connectionCameraProgressbar";
            this.connectionCameraProgressbar.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.connectionCameraProgressbar.ProgressColor = System.Drawing.Color.SeaGreen;
            this.connectionCameraProgressbar.Size = new System.Drawing.Size(100, 100);
            this.connectionCameraProgressbar.TabIndex = 0;
            this.connectionCameraProgressbar.Value = 0;
            this.connectionCameraProgressbar.Click += new System.EventHandler(this.connectCameraProgressbar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.connectionCameraProgressbar);
            this.panel1.Controls.Add(this.bunifuCustomLabel1);
            this.panel1.Controls.Add(this.connectionLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 100);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.bunifuCustomLabel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(350, 27);
            this.panel3.TabIndex = 0;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.DarkOrange;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(5, 5);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(73, 17);
            this.bunifuCustomLabel2.TabIndex = 0;
            this.bunifuCustomLabel2.Text = "디스플레이";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 127);
            this.panel2.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.tableLayoutPanel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 27);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.panel4.Size = new System.Drawing.Size(350, 100);
            this.panel4.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel1.Controls.Add(this.blendingViewButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.infraredViewButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.visualViewButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(340, 100);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // blendingViewButton
            // 
            this.blendingViewButton.BackColor = System.Drawing.Color.DarkOrange;
            this.blendingViewButton.color = System.Drawing.Color.DarkOrange;
            this.blendingViewButton.colorActive = System.Drawing.Color.MediumSeaGreen;
            this.blendingViewButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.blendingViewButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blendingViewButton.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.blendingViewButton.ForeColor = System.Drawing.Color.White;
            this.blendingViewButton.Image = ((System.Drawing.Image)(resources.GetObject("blendingViewButton.Image")));
            this.blendingViewButton.ImagePosition = 14;
            this.blendingViewButton.ImageZoom = 50;
            this.blendingViewButton.LabelPosition = 25;
            this.blendingViewButton.LabelText = "블렌딩";
            this.blendingViewButton.Location = new System.Drawing.Point(230, 4);
            this.blendingViewButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.blendingViewButton.Name = "blendingViewButton";
            this.blendingViewButton.Size = new System.Drawing.Size(106, 92);
            this.blendingViewButton.TabIndex = 2;
            // 
            // infraredViewButton
            // 
            this.infraredViewButton.BackColor = System.Drawing.Color.DarkOrange;
            this.infraredViewButton.color = System.Drawing.Color.DarkOrange;
            this.infraredViewButton.colorActive = System.Drawing.Color.MediumSeaGreen;
            this.infraredViewButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.infraredViewButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infraredViewButton.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.infraredViewButton.ForeColor = System.Drawing.Color.White;
            this.infraredViewButton.Image = ((System.Drawing.Image)(resources.GetObject("infraredViewButton.Image")));
            this.infraredViewButton.ImagePosition = 14;
            this.infraredViewButton.ImageZoom = 50;
            this.infraredViewButton.LabelPosition = 25;
            this.infraredViewButton.LabelText = "열화상";
            this.infraredViewButton.Location = new System.Drawing.Point(4, 4);
            this.infraredViewButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.infraredViewButton.Name = "infraredViewButton";
            this.infraredViewButton.Size = new System.Drawing.Size(105, 92);
            this.infraredViewButton.TabIndex = 0;
            this.infraredViewButton.Click += new System.EventHandler(this.infraredViewButton_Click);
            // 
            // visualViewButton
            // 
            this.visualViewButton.BackColor = System.Drawing.Color.DarkOrange;
            this.visualViewButton.color = System.Drawing.Color.DarkOrange;
            this.visualViewButton.colorActive = System.Drawing.Color.MediumSeaGreen;
            this.visualViewButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.visualViewButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualViewButton.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.visualViewButton.ForeColor = System.Drawing.Color.White;
            this.visualViewButton.Image = ((System.Drawing.Image)(resources.GetObject("visualViewButton.Image")));
            this.visualViewButton.ImagePosition = 14;
            this.visualViewButton.ImageZoom = 50;
            this.visualViewButton.LabelPosition = 25;
            this.visualViewButton.LabelText = "실화상";
            this.visualViewButton.Location = new System.Drawing.Point(117, 4);
            this.visualViewButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.visualViewButton.Name = "visualViewButton";
            this.visualViewButton.Size = new System.Drawing.Size(105, 92);
            this.visualViewButton.TabIndex = 1;
            this.visualViewButton.Click += new System.EventHandler(this.visualViewButton_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 227);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(350, 280);
            this.panel5.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tableLayoutPanel2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 27);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.panel6.Size = new System.Drawing.Size(350, 145);
            this.panel6.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Controls.Add(this.panel9, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel8, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.palettesDropDown, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel10, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.8062F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.1938F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(340, 122);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.AutoSize = true;
            this.panel9.Controls.Add(this.bunifuCustomLabel5);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(3, 33);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(5);
            this.panel9.Size = new System.Drawing.Size(96, 27);
            this.panel9.TabIndex = 3;
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel5.ForeColor = System.Drawing.Color.DarkOrange;
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(5, 5);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(66, 17);
            this.bunifuCustomLabel5.TabIndex = 0;
            this.bunifuCustomLabel5.Text = "레벨/스판";
            // 
            // panel8
            // 
            this.panel8.AutoSize = true;
            this.panel8.Controls.Add(this.bunifuCustomLabel4);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(5);
            this.panel8.Size = new System.Drawing.Size(96, 24);
            this.panel8.TabIndex = 1;
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel4.ForeColor = System.Drawing.Color.DarkOrange;
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(5, 5);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(47, 17);
            this.bunifuCustomLabel4.TabIndex = 0;
            this.bunifuCustomLabel4.Text = "팔레트";
            // 
            // palettesDropDown
            // 
            this.palettesDropDown.BackColor = System.Drawing.Color.Transparent;
            this.palettesDropDown.BorderRadius = 3;
            this.palettesDropDown.DisabledColor = System.Drawing.Color.Gray;
            this.palettesDropDown.ForeColor = System.Drawing.Color.White;
            this.palettesDropDown.Items = new string[] {
        "Grayscale",
        "IronBlack"};
            this.palettesDropDown.Location = new System.Drawing.Point(105, 3);
            this.palettesDropDown.Name = "palettesDropDown";
            this.palettesDropDown.NomalColor = System.Drawing.Color.DarkOrange;
            this.palettesDropDown.onHoverColor = System.Drawing.Color.DarkOrange;
            this.palettesDropDown.selectedIndex = 0;
            this.palettesDropDown.Size = new System.Drawing.Size(232, 24);
            this.palettesDropDown.TabIndex = 2;
            this.palettesDropDown.onItemSelected += new System.EventHandler(this.palettesDropDown_onItemSelected);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Controls.Add(this.bunifuRange1);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(105, 33);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(232, 86);
            this.panel10.TabIndex = 4;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.bunifuCustomLabel6);
            this.panel11.Controls.Add(this.bunifuCheckbox1);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 28);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(232, 34);
            this.panel11.TabIndex = 2;
            // 
            // bunifuCustomLabel6
            // 
            this.bunifuCustomLabel6.AutoSize = true;
            this.bunifuCustomLabel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuCustomLabel6.ForeColor = System.Drawing.Color.DarkOrange;
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(20, 0);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(29, 12);
            this.bunifuCustomLabel6.TabIndex = 3;
            this.bunifuCustomLabel6.Text = "자동";
            // 
            // bunifuCheckbox1
            // 
            this.bunifuCheckbox1.BackColor = System.Drawing.Color.DarkOrange;
            this.bunifuCheckbox1.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.bunifuCheckbox1.Checked = true;
            this.bunifuCheckbox1.CheckedOnColor = System.Drawing.Color.DarkOrange;
            this.bunifuCheckbox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuCheckbox1.ForeColor = System.Drawing.Color.White;
            this.bunifuCheckbox1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCheckbox1.Name = "bunifuCheckbox1";
            this.bunifuCheckbox1.Size = new System.Drawing.Size(20, 20);
            this.bunifuCheckbox1.TabIndex = 2;
            // 
            // bunifuRange1
            // 
            this.bunifuRange1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuRange1.BackgroudColor = System.Drawing.Color.DarkGray;
            this.bunifuRange1.BorderRadius = 0;
            this.bunifuRange1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuRange1.IndicatorColor = System.Drawing.Color.DarkOrange;
            this.bunifuRange1.Location = new System.Drawing.Point(0, 0);
            this.bunifuRange1.MaximumRange = 100;
            this.bunifuRange1.Name = "bunifuRange1";
            this.bunifuRange1.RangeMax = 49;
            this.bunifuRange1.RangeMin = 0;
            this.bunifuRange1.Size = new System.Drawing.Size(232, 28);
            this.bunifuRange1.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.Controls.Add(this.bunifuCustomLabel3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(5);
            this.panel7.Size = new System.Drawing.Size(350, 27);
            this.panel7.TabIndex = 0;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.DarkOrange;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(5, 5);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(78, 17);
            this.bunifuCustomLabel3.TabIndex = 0;
            this.bunifuCustomLabel3.Text = "적외선 옵션";
            // 
            // VisualizeTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "VisualizeTab";
            this.Size = new System.Drawing.Size(350, 738);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCircleProgressbar connectionCameraProgressbar;
        private Bunifu.Framework.UI.BunifuCustomLabel connectionLabel;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Bunifu.Framework.UI.BunifuTileButton blendingViewButton;
        private Bunifu.Framework.UI.BunifuTileButton infraredViewButton;
        private Bunifu.Framework.UI.BunifuTileButton visualViewButton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel9;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        private System.Windows.Forms.Panel panel8;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private System.Windows.Forms.Panel panel10;
        private Bunifu.Framework.UI.BunifuRange bunifuRange1;
        private System.Windows.Forms.Panel panel7;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private System.Windows.Forms.Panel panel11;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;
        private Bunifu.Framework.UI.BunifuCheckbox bunifuCheckbox1;
        public Bunifu.Framework.UI.BunifuDropdown palettesDropDown;
    }
}
