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
            this.panel12 = new System.Windows.Forms.Panel();
            this.connectionLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.connectVisualizeButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.connectionCameraProgressbar = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCollapse = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel16 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.blendingViewButton = new Bunifu.Framework.UI.BunifuTileButton();
            this.infraredViewButton = new Bunifu.Framework.UI.BunifuTileButton();
            this.visualViewButton = new Bunifu.Framework.UI.BunifuTileButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel15 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.palettesDropDown = new Bunifu.Framework.UI.BunifuDropdown();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCheckbox1 = new Bunifu.Framework.UI.BunifuCheckbox();
            this.bunifuRange1 = new Bunifu.Framework.UI.BunifuRange();
            this.panel7 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectVisualizeButton)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel16.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
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
            // panel12
            // 
            this.panel12.Controls.Add(this.connectionLabel);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 170);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panel12.Size = new System.Drawing.Size(350, 44);
            this.panel12.TabIndex = 37;
            // 
            // connectionLabel
            // 
            this.connectionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionLabel.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.connectionLabel.ForeColor = System.Drawing.Color.Tomato;
            this.connectionLabel.Location = new System.Drawing.Point(20, 10);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(310, 24);
            this.connectionLabel.TabIndex = 1;
            this.connectionLabel.Text = "서버와 연결 되어있지 않습니다.";
            this.connectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.connectVisualizeButton);
            this.panel13.Controls.Add(this.connectionCameraProgressbar);
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Controls.Add(this.panel15);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 46);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(350, 124);
            this.panel13.TabIndex = 36;
            // 
            // connectVisualizeButton
            // 
            this.connectVisualizeButton.BackColor = System.Drawing.Color.Transparent;
            this.connectVisualizeButton.Image = ((System.Drawing.Image)(resources.GetObject("connectVisualizeButton.Image")));
            this.connectVisualizeButton.ImageActive = null;
            this.connectVisualizeButton.Location = new System.Drawing.Point(147, 32);
            this.connectVisualizeButton.Name = "connectVisualizeButton";
            this.connectVisualizeButton.Size = new System.Drawing.Size(63, 61);
            this.connectVisualizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.connectVisualizeButton.TabIndex = 29;
            this.connectVisualizeButton.TabStop = false;
            this.connectVisualizeButton.Zoom = 10;
            this.connectVisualizeButton.Click += new System.EventHandler(this.connectCameraButton_Click);
            // 
            // connectionCameraProgressbar
            // 
            this.connectionCameraProgressbar.animated = false;
            this.connectionCameraProgressbar.animationIterval = 5;
            this.connectionCameraProgressbar.animationSpeed = 20;
            this.connectionCameraProgressbar.BackColor = System.Drawing.Color.Transparent;
            this.connectionCameraProgressbar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("connectionCameraProgressbar.BackgroundImage")));
            this.connectionCameraProgressbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.connectionCameraProgressbar.ForeColor = System.Drawing.Color.SeaGreen;
            this.connectionCameraProgressbar.LabelVisible = false;
            this.connectionCameraProgressbar.LineProgressThickness = 5;
            this.connectionCameraProgressbar.LineThickness = 5;
            this.connectionCameraProgressbar.Location = new System.Drawing.Point(115, 0);
            this.connectionCameraProgressbar.Margin = new System.Windows.Forms.Padding(8);
            this.connectionCameraProgressbar.MaxValue = 100;
            this.connectionCameraProgressbar.Name = "connectionCameraProgressbar";
            this.connectionCameraProgressbar.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.connectionCameraProgressbar.ProgressColor = System.Drawing.Color.OrangeRed;
            this.connectionCameraProgressbar.Size = new System.Drawing.Size(125, 125);
            this.connectionCameraProgressbar.TabIndex = 2;
            this.connectionCameraProgressbar.Value = 0;
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(104, 124);
            this.panel14.TabIndex = 1;
            // 
            // panel15
            // 
            this.panel15.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel15.Location = new System.Drawing.Point(252, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(98, 124);
            this.panel15.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 0);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.bunifuCustomLabel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 214);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(350, 28);
            this.panel3.TabIndex = 38;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.Salmon;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(24, 7);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(46, 16);
            this.bunifuCustomLabel2.TabIndex = 1;
            this.bunifuCustomLabel2.Text = "카메라";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCollapse);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 46);
            this.panel1.TabIndex = 3;
            // 
            // buttonCollapse
            // 
            this.buttonCollapse.Activecolor = System.Drawing.Color.Tomato;
            this.buttonCollapse.BackColor = System.Drawing.Color.Tomato;
            this.buttonCollapse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonCollapse.BorderRadius = 0;
            this.buttonCollapse.ButtonText = "Visualize";
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
            this.buttonCollapse.Text = "Visualize";
            this.buttonCollapse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonCollapse.Textcolor = System.Drawing.Color.White;
            this.buttonCollapse.TextFont = new System.Drawing.Font("넥슨 풋볼고딕 B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCollapse.Click += new System.EventHandler(this.infraredViewButton_Click);
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.tableLayoutPanel3);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(0, 242);
            this.panel16.Name = "panel16";
            this.panel16.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.panel16.Size = new System.Drawing.Size(350, 99);
            this.panel16.TabIndex = 42;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel3.Controls.Add(this.blendingViewButton, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.infraredViewButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.visualViewButton, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(20, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(310, 100);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // blendingViewButton
            // 
            this.blendingViewButton.BackColor = System.Drawing.Color.DarkGray;
            this.blendingViewButton.color = System.Drawing.Color.DarkGray;
            this.blendingViewButton.colorActive = System.Drawing.Color.LightCoral;
            this.blendingViewButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.blendingViewButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blendingViewButton.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.blendingViewButton.ForeColor = System.Drawing.Color.White;
            this.blendingViewButton.Image = ((System.Drawing.Image)(resources.GetObject("blendingViewButton.Image")));
            this.blendingViewButton.ImagePosition = 13;
            this.blendingViewButton.ImageZoom = 50;
            this.blendingViewButton.LabelPosition = 24;
            this.blendingViewButton.LabelText = "블렌딩";
            this.blendingViewButton.Location = new System.Drawing.Point(210, 4);
            this.blendingViewButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.blendingViewButton.Name = "blendingViewButton";
            this.blendingViewButton.Size = new System.Drawing.Size(96, 92);
            this.blendingViewButton.TabIndex = 2;
            // 
            // infraredViewButton
            // 
            this.infraredViewButton.BackColor = System.Drawing.Color.DarkGray;
            this.infraredViewButton.color = System.Drawing.Color.DarkGray;
            this.infraredViewButton.colorActive = System.Drawing.Color.LightCoral;
            this.infraredViewButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.infraredViewButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infraredViewButton.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.infraredViewButton.ForeColor = System.Drawing.Color.White;
            this.infraredViewButton.Image = ((System.Drawing.Image)(resources.GetObject("infraredViewButton.Image")));
            this.infraredViewButton.ImagePosition = 13;
            this.infraredViewButton.ImageZoom = 50;
            this.infraredViewButton.LabelPosition = 24;
            this.infraredViewButton.LabelText = "열화상";
            this.infraredViewButton.Location = new System.Drawing.Point(4, 4);
            this.infraredViewButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.infraredViewButton.Name = "infraredViewButton";
            this.infraredViewButton.Size = new System.Drawing.Size(95, 92);
            this.infraredViewButton.TabIndex = 0;
            this.infraredViewButton.Click += new System.EventHandler(this.infraredViewButton_Click);
            // 
            // visualViewButton
            // 
            this.visualViewButton.BackColor = System.Drawing.Color.DarkGray;
            this.visualViewButton.color = System.Drawing.Color.DarkGray;
            this.visualViewButton.colorActive = System.Drawing.Color.LightCoral;
            this.visualViewButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.visualViewButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualViewButton.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.visualViewButton.ForeColor = System.Drawing.Color.White;
            this.visualViewButton.Image = ((System.Drawing.Image)(resources.GetObject("visualViewButton.Image")));
            this.visualViewButton.ImagePosition = 13;
            this.visualViewButton.ImageZoom = 50;
            this.visualViewButton.LabelPosition = 24;
            this.visualViewButton.LabelText = "실화상";
            this.visualViewButton.Location = new System.Drawing.Point(107, 4);
            this.visualViewButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.visualViewButton.Name = "visualViewButton";
            this.visualViewButton.Size = new System.Drawing.Size(95, 92);
            this.visualViewButton.TabIndex = 1;
            this.visualViewButton.Click += new System.EventHandler(this.visualViewButton_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 341);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(350, 280);
            this.panel5.TabIndex = 43;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tableLayoutPanel2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 28);
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
            this.panel9.Controls.Add(this.bunifuCustomLabel4);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(3, 33);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(5);
            this.panel9.Size = new System.Drawing.Size(96, 26);
            this.panel9.TabIndex = 3;
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(34, 6);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(57, 15);
            this.bunifuCustomLabel4.TabIndex = 2;
            this.bunifuCustomLabel4.Text = "레벨/스판";
            // 
            // panel8
            // 
            this.panel8.AutoSize = true;
            this.panel8.Controls.Add(this.bunifuCustomLabel15);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(5);
            this.panel8.Size = new System.Drawing.Size(96, 24);
            this.panel8.TabIndex = 1;
            // 
            // bunifuCustomLabel15
            // 
            this.bunifuCustomLabel15.AutoSize = true;
            this.bunifuCustomLabel15.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel15.Location = new System.Drawing.Point(35, 5);
            this.bunifuCustomLabel15.Name = "bunifuCustomLabel15";
            this.bunifuCustomLabel15.Size = new System.Drawing.Size(40, 15);
            this.bunifuCustomLabel15.TabIndex = 1;
            this.bunifuCustomLabel15.Text = "팔레트";
            // 
            // palettesDropDown
            // 
            this.palettesDropDown.BackColor = System.Drawing.Color.Transparent;
            this.palettesDropDown.BorderRadius = 3;
            this.palettesDropDown.DisabledColor = System.Drawing.Color.Gray;
            this.palettesDropDown.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.palettesDropDown.ForeColor = System.Drawing.Color.White;
            this.palettesDropDown.Items = new string[] {
        "Grayscale",
        "IronBlack"};
            this.palettesDropDown.Location = new System.Drawing.Point(105, 4);
            this.palettesDropDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.palettesDropDown.Name = "palettesDropDown";
            this.palettesDropDown.NomalColor = System.Drawing.Color.Salmon;
            this.palettesDropDown.onHoverColor = System.Drawing.Color.DarkSalmon;
            this.palettesDropDown.selectedIndex = 0;
            this.palettesDropDown.Size = new System.Drawing.Size(232, 22);
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
            this.bunifuCustomLabel6.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(24, 4);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(29, 15);
            this.bunifuCustomLabel6.TabIndex = 3;
            this.bunifuCustomLabel6.Text = "자동";
            // 
            // bunifuCheckbox1
            // 
            this.bunifuCheckbox1.BackColor = System.Drawing.Color.Salmon;
            this.bunifuCheckbox1.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.bunifuCheckbox1.Checked = true;
            this.bunifuCheckbox1.CheckedOnColor = System.Drawing.Color.Salmon;
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
            this.bunifuRange1.IndicatorColor = System.Drawing.Color.Salmon;
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
            this.panel7.Size = new System.Drawing.Size(350, 28);
            this.panel7.TabIndex = 0;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.Salmon;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(24, 7);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(71, 16);
            this.bunifuCustomLabel3.TabIndex = 1;
            this.bunifuCustomLabel3.Text = "적외선 옵션";
            // 
            // VisualizeTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel16);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "VisualizeTab";
            this.Size = new System.Drawing.Size(350, 738);
            this.Load += new System.EventHandler(this.VisualizeTab_Load);
            this.panel12.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.connectVisualizeButton)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
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

        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private Bunifu.Framework.UI.BunifuImageButton connectVisualizeButton;
        private Bunifu.Framework.UI.BunifuCircleProgressbar connectionCameraProgressbar;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuFlatButton buttonCollapse;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Bunifu.Framework.UI.BunifuTileButton blendingViewButton;
        private Bunifu.Framework.UI.BunifuTileButton infraredViewButton;
        private Bunifu.Framework.UI.BunifuTileButton visualViewButton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel9;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private System.Windows.Forms.Panel panel8;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel15;
        public Bunifu.Framework.UI.BunifuDropdown palettesDropDown;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;
        private Bunifu.Framework.UI.BunifuCheckbox bunifuCheckbox1;
        private Bunifu.Framework.UI.BunifuRange bunifuRange1;
        private System.Windows.Forms.Panel panel7;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel connectionLabel;
    }
}
