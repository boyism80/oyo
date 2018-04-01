namespace Fire_Detector.Control
{
    partial class MainView
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation3 = new BunifuAnimatorNS.Animation();
            this.OYOPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.connectionPanel = new System.Windows.Forms.Panel();
            this.mainConnectionView = new Fire_Detector.Control.MainConnectionView();
            this.activatedConnectionIconPanel = new System.Windows.Forms.Panel();
            this.detectFireTabShow = new Fire_Detector.Control.DetectFireTabShow();
            this.leapmotionTabShow = new Fire_Detector.Control.LeapmotionTabShow();
            this.visualizeTabShow = new Fire_Detector.Control.VisualizeTabShow();
            this.droneTabShow = new Fire_Detector.Control.DroneTabShow();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.detectFirePanel = new System.Windows.Forms.Panel();
            this.detectFireLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.etcPanel = new System.Windows.Forms.Panel();
            this.etcLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.leapmotionPanel = new System.Windows.Forms.Panel();
            this.leapmotionLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.droneControlPanel = new System.Windows.Forms.Panel();
            this.droneControlLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.cameraPanel = new System.Windows.Forms.Panel();
            this.visualizeLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuTransition = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.bunifuTransition1 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.bunifuTransition2 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.OYOPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.colorPanel.SuspendLayout();
            this.connectionPanel.SuspendLayout();
            this.activatedConnectionIconPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.detectFirePanel.SuspendLayout();
            this.etcPanel.SuspendLayout();
            this.leapmotionPanel.SuspendLayout();
            this.droneControlPanel.SuspendLayout();
            this.cameraPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // OYOPanel
            // 
            this.OYOPanel.BackColor = System.Drawing.Color.Transparent;
            this.OYOPanel.Controls.Add(this.tableLayoutPanel1);
            this.bunifuTransition.SetDecoration(this.OYOPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.OYOPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.OYOPanel, BunifuAnimatorNS.DecorationType.None);
            this.OYOPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.OYOPanel.Location = new System.Drawing.Point(0, 0);
            this.OYOPanel.Name = "OYOPanel";
            this.OYOPanel.Padding = new System.Windows.Forms.Padding(40);
            this.OYOPanel.Size = new System.Drawing.Size(1024, 182);
            this.OYOPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.16949F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.83051F));
            this.tableLayoutPanel1.Controls.Add(this.bunifuImageButton1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.bunifuTransition.SetDecoration(this.tableLayoutPanel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.tableLayoutPanel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.tableLayoutPanel1, BunifuAnimatorNS.DecorationType.None);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(40, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(944, 102);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuImageButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(3, 3);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(89, 96);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 2;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.bunifuCustomLabel2);
            this.panel1.Controls.Add(this.bunifuCustomLabel1);
            this.bunifuTransition.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(98, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.panel1.Size = new System.Drawing.Size(843, 96);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bunifuCustomLabel5);
            this.panel2.Controls.Add(this.bunifuCustomLabel4);
            this.panel2.Controls.Add(this.bunifuCustomLabel3);
            this.bunifuTransition.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(843, 36);
            this.panel2.TabIndex = 4;
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuTransition2.SetDecoration(this.bunifuCustomLabel5, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel5, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.bunifuCustomLabel5, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel5.ForeColor = System.Drawing.Color.DarkSalmon;
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(97, 0);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(49, 15);
            this.bunifuCustomLabel5.TabIndex = 2;
            this.bunifuCustomLabel5.Text = "JE Park";
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuTransition2.SetDecoration(this.bunifuCustomLabel4, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel4, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.bunifuCustomLabel4, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel4.ForeColor = System.Drawing.Color.LightCoral;
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(53, 0);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(44, 15);
            this.bunifuCustomLabel4.TabIndex = 1;
            this.bunifuCustomLabel4.Text = "JS Kim";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuTransition2.SetDecoration(this.bunifuCustomLabel3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.bunifuCustomLabel3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.OrangeRed;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(0, 0);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(53, 15);
            this.bunifuCustomLabel3.TabIndex = 0;
            this.bunifuCustomLabel3.Text = "SH Chae";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuTransition2.SetDecoration(this.bunifuCustomLabel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.bunifuCustomLabel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("넥슨 풋볼고딕 B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.Tomato;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(0, 42);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(159, 18);
            this.bunifuCustomLabel2.TabIndex = 1;
            this.bunifuCustomLabel2.Text = "Old Young Old in KPU";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuTransition2.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("넥슨 풋볼고딕 B", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Coral;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(0, 15);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(291, 27);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "Detecting Fire with Drone";
            // 
            // colorPanel
            // 
            this.colorPanel.Controls.Add(this.connectionPanel);
            this.bunifuTransition.SetDecoration(this.colorPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.colorPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.colorPanel, BunifuAnimatorNS.DecorationType.None);
            this.colorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorPanel.Location = new System.Drawing.Point(0, 182);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(1024, 556);
            this.colorPanel.TabIndex = 2;
            // 
            // connectionPanel
            // 
            this.connectionPanel.Controls.Add(this.mainConnectionView);
            this.connectionPanel.Controls.Add(this.activatedConnectionIconPanel);
            this.connectionPanel.Controls.Add(this.tableLayoutPanel2);
            this.bunifuTransition.SetDecoration(this.connectionPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.connectionPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.connectionPanel, BunifuAnimatorNS.DecorationType.None);
            this.connectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionPanel.Location = new System.Drawing.Point(0, 0);
            this.connectionPanel.Name = "connectionPanel";
            this.connectionPanel.Size = new System.Drawing.Size(1024, 556);
            this.connectionPanel.TabIndex = 3;
            // 
            // mainConnectionView
            // 
            this.bunifuTransition.SetDecoration(this.mainConnectionView, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.mainConnectionView, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.mainConnectionView, BunifuAnimatorNS.DecorationType.None);
            this.mainConnectionView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainConnectionView.Location = new System.Drawing.Point(0, 0);
            this.mainConnectionView.Name = "mainConnectionView";
            this.mainConnectionView.Size = new System.Drawing.Size(1024, 510);
            this.mainConnectionView.TabIndex = 25;
            // 
            // activatedConnectionIconPanel
            // 
            this.activatedConnectionIconPanel.Controls.Add(this.detectFireTabShow);
            this.activatedConnectionIconPanel.Controls.Add(this.leapmotionTabShow);
            this.activatedConnectionIconPanel.Controls.Add(this.visualizeTabShow);
            this.activatedConnectionIconPanel.Controls.Add(this.droneTabShow);
            this.bunifuTransition.SetDecoration(this.activatedConnectionIconPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.activatedConnectionIconPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.activatedConnectionIconPanel, BunifuAnimatorNS.DecorationType.None);
            this.activatedConnectionIconPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activatedConnectionIconPanel.Location = new System.Drawing.Point(0, 0);
            this.activatedConnectionIconPanel.Name = "activatedConnectionIconPanel";
            this.activatedConnectionIconPanel.Size = new System.Drawing.Size(1024, 510);
            this.activatedConnectionIconPanel.TabIndex = 24;
            this.activatedConnectionIconPanel.Visible = false;
            // 
            // detectFireTabShow
            // 
            this.bunifuTransition2.SetDecoration(this.detectFireTabShow, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.detectFireTabShow, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.detectFireTabShow, BunifuAnimatorNS.DecorationType.None);
            this.detectFireTabShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detectFireTabShow.Location = new System.Drawing.Point(0, 0);
            this.detectFireTabShow.Name = "detectFireTabShow";
            this.detectFireTabShow.Size = new System.Drawing.Size(1024, 510);
            this.detectFireTabShow.TabIndex = 3;
            this.detectFireTabShow.Visible = false;
            // 
            // leapmotionTabShow
            // 
            this.leapmotionTabShow.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuTransition2.SetDecoration(this.leapmotionTabShow, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.leapmotionTabShow, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.leapmotionTabShow, BunifuAnimatorNS.DecorationType.None);
            this.leapmotionTabShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leapmotionTabShow.Location = new System.Drawing.Point(0, 0);
            this.leapmotionTabShow.Name = "leapmotionTabShow";
            this.leapmotionTabShow.Size = new System.Drawing.Size(1024, 510);
            this.leapmotionTabShow.TabIndex = 2;
            this.leapmotionTabShow.Visible = false;
            // 
            // visualizeTabShow
            // 
            this.bunifuTransition2.SetDecoration(this.visualizeTabShow, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.visualizeTabShow, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.visualizeTabShow, BunifuAnimatorNS.DecorationType.None);
            this.visualizeTabShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualizeTabShow.Location = new System.Drawing.Point(0, 0);
            this.visualizeTabShow.Name = "visualizeTabShow";
            this.visualizeTabShow.Size = new System.Drawing.Size(1024, 510);
            this.visualizeTabShow.TabIndex = 1;
            this.visualizeTabShow.Visible = false;
            // 
            // droneTabShow
            // 
            this.droneTabShow.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition2.SetDecoration(this.droneTabShow, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.droneTabShow, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.droneTabShow, BunifuAnimatorNS.DecorationType.None);
            this.droneTabShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.droneTabShow.Location = new System.Drawing.Point(0, 0);
            this.droneTabShow.Name = "droneTabShow";
            this.droneTabShow.Size = new System.Drawing.Size(1024, 510);
            this.droneTabShow.TabIndex = 0;
            this.droneTabShow.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.detectFirePanel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.etcPanel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.leapmotionPanel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.droneControlPanel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cameraPanel, 0, 0);
            this.bunifuTransition.SetDecoration(this.tableLayoutPanel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.tableLayoutPanel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.tableLayoutPanel2, BunifuAnimatorNS.DecorationType.None);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 510);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1024, 46);
            this.tableLayoutPanel2.TabIndex = 23;
            // 
            // detectFirePanel
            // 
            this.detectFirePanel.BackColor = System.Drawing.Color.LightCoral;
            this.detectFirePanel.Controls.Add(this.detectFireLabel);
            this.bunifuTransition.SetDecoration(this.detectFirePanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.detectFirePanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.detectFirePanel, BunifuAnimatorNS.DecorationType.None);
            this.detectFirePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detectFirePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.detectFirePanel.ForeColor = System.Drawing.SystemColors.Control;
            this.detectFirePanel.Location = new System.Drawing.Point(612, 0);
            this.detectFirePanel.Margin = new System.Windows.Forms.Padding(0);
            this.detectFirePanel.Name = "detectFirePanel";
            this.detectFirePanel.Size = new System.Drawing.Size(204, 46);
            this.detectFirePanel.TabIndex = 7;
            // 
            // detectFireLabel
            // 
            this.detectFireLabel.BackColor = System.Drawing.Color.LightCoral;
            this.detectFireLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition2.SetDecoration(this.detectFireLabel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.detectFireLabel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.detectFireLabel, BunifuAnimatorNS.DecorationType.None);
            this.detectFireLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detectFireLabel.Font = new System.Drawing.Font("넥슨 풋볼고딕 B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detectFireLabel.Location = new System.Drawing.Point(0, 0);
            this.detectFireLabel.Name = "detectFireLabel";
            this.detectFireLabel.Size = new System.Drawing.Size(204, 46);
            this.detectFireLabel.TabIndex = 21;
            this.detectFireLabel.Tag = "";
            this.detectFireLabel.Text = "Detect Fire";
            this.detectFireLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.detectFireLabel.Click += new System.EventHandler(this.bottomLabel_Click);
            this.detectFireLabel.MouseEnter += new System.EventHandler(this.bottomLabel_MouseEnter);
            this.detectFireLabel.MouseLeave += new System.EventHandler(this.bottomLabel_MouseLeave);
            // 
            // etcPanel
            // 
            this.etcPanel.BackColor = System.Drawing.Color.DarkSalmon;
            this.etcPanel.Controls.Add(this.etcLabel);
            this.bunifuTransition.SetDecoration(this.etcPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.etcPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.etcPanel, BunifuAnimatorNS.DecorationType.None);
            this.etcPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.etcPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etcPanel.ForeColor = System.Drawing.SystemColors.Control;
            this.etcPanel.Location = new System.Drawing.Point(816, 0);
            this.etcPanel.Margin = new System.Windows.Forms.Padding(0);
            this.etcPanel.Name = "etcPanel";
            this.etcPanel.Size = new System.Drawing.Size(208, 46);
            this.etcPanel.TabIndex = 6;
            // 
            // etcLabel
            // 
            this.etcLabel.BackColor = System.Drawing.Color.DarkSalmon;
            this.etcLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition2.SetDecoration(this.etcLabel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.etcLabel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.etcLabel, BunifuAnimatorNS.DecorationType.None);
            this.etcLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.etcLabel.Font = new System.Drawing.Font("넥슨 풋볼고딕 B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etcLabel.Location = new System.Drawing.Point(0, 0);
            this.etcLabel.Name = "etcLabel";
            this.etcLabel.Size = new System.Drawing.Size(208, 46);
            this.etcLabel.TabIndex = 21;
            this.etcLabel.Text = "etc";
            this.etcLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.etcLabel.Click += new System.EventHandler(this.bottomLabel_Click);
            this.etcLabel.MouseEnter += new System.EventHandler(this.bottomLabel_MouseEnter);
            this.etcLabel.MouseLeave += new System.EventHandler(this.bottomLabel_MouseLeave);
            // 
            // leapmotionPanel
            // 
            this.leapmotionPanel.BackColor = System.Drawing.Color.Salmon;
            this.leapmotionPanel.Controls.Add(this.leapmotionLabel);
            this.bunifuTransition.SetDecoration(this.leapmotionPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.leapmotionPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.leapmotionPanel, BunifuAnimatorNS.DecorationType.None);
            this.leapmotionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leapmotionPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.leapmotionPanel.ForeColor = System.Drawing.SystemColors.Control;
            this.leapmotionPanel.Location = new System.Drawing.Point(408, 0);
            this.leapmotionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.leapmotionPanel.Name = "leapmotionPanel";
            this.leapmotionPanel.Size = new System.Drawing.Size(204, 46);
            this.leapmotionPanel.TabIndex = 5;
            // 
            // leapmotionLabel
            // 
            this.leapmotionLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition2.SetDecoration(this.leapmotionLabel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.leapmotionLabel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.leapmotionLabel, BunifuAnimatorNS.DecorationType.None);
            this.leapmotionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leapmotionLabel.Font = new System.Drawing.Font("넥슨 풋볼고딕 B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leapmotionLabel.Location = new System.Drawing.Point(0, 0);
            this.leapmotionLabel.Name = "leapmotionLabel";
            this.leapmotionLabel.Size = new System.Drawing.Size(204, 46);
            this.leapmotionLabel.TabIndex = 21;
            this.leapmotionLabel.Tag = "";
            this.leapmotionLabel.Text = "Leapmotion";
            this.leapmotionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.leapmotionLabel.Click += new System.EventHandler(this.bottomLabel_Click);
            this.leapmotionLabel.MouseEnter += new System.EventHandler(this.bottomLabel_MouseEnter);
            this.leapmotionLabel.MouseLeave += new System.EventHandler(this.bottomLabel_MouseLeave);
            // 
            // droneControlPanel
            // 
            this.droneControlPanel.BackColor = System.Drawing.Color.Tomato;
            this.droneControlPanel.Controls.Add(this.droneControlLabel);
            this.bunifuTransition.SetDecoration(this.droneControlPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.droneControlPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.droneControlPanel, BunifuAnimatorNS.DecorationType.None);
            this.droneControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.droneControlPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.droneControlPanel.ForeColor = System.Drawing.SystemColors.Control;
            this.droneControlPanel.Location = new System.Drawing.Point(0, 0);
            this.droneControlPanel.Margin = new System.Windows.Forms.Padding(0);
            this.droneControlPanel.Name = "droneControlPanel";
            this.droneControlPanel.Size = new System.Drawing.Size(204, 46);
            this.droneControlPanel.TabIndex = 3;
            // 
            // droneControlLabel
            // 
            this.droneControlLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition2.SetDecoration(this.droneControlLabel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.droneControlLabel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.droneControlLabel, BunifuAnimatorNS.DecorationType.None);
            this.droneControlLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.droneControlLabel.Font = new System.Drawing.Font("넥슨 풋볼고딕 B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.droneControlLabel.Location = new System.Drawing.Point(0, 0);
            this.droneControlLabel.Name = "droneControlLabel";
            this.droneControlLabel.Size = new System.Drawing.Size(204, 46);
            this.droneControlLabel.TabIndex = 21;
            this.droneControlLabel.Tag = "";
            this.droneControlLabel.Text = "Drone Control";
            this.droneControlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.droneControlLabel.Click += new System.EventHandler(this.bottomLabel_Click);
            this.droneControlLabel.MouseEnter += new System.EventHandler(this.bottomLabel_MouseEnter);
            this.droneControlLabel.MouseLeave += new System.EventHandler(this.bottomLabel_MouseLeave);
            // 
            // cameraPanel
            // 
            this.cameraPanel.BackColor = System.Drawing.Color.Coral;
            this.cameraPanel.Controls.Add(this.visualizeLabel);
            this.bunifuTransition.SetDecoration(this.cameraPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.cameraPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.cameraPanel, BunifuAnimatorNS.DecorationType.None);
            this.cameraPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cameraPanel.ForeColor = System.Drawing.SystemColors.Control;
            this.cameraPanel.Location = new System.Drawing.Point(204, 0);
            this.cameraPanel.Margin = new System.Windows.Forms.Padding(0);
            this.cameraPanel.Name = "cameraPanel";
            this.cameraPanel.Size = new System.Drawing.Size(204, 46);
            this.cameraPanel.TabIndex = 2;
            // 
            // visualizeLabel
            // 
            this.visualizeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition2.SetDecoration(this.visualizeLabel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.visualizeLabel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.visualizeLabel, BunifuAnimatorNS.DecorationType.None);
            this.visualizeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualizeLabel.Font = new System.Drawing.Font("넥슨 풋볼고딕 B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visualizeLabel.Location = new System.Drawing.Point(0, 0);
            this.visualizeLabel.Name = "visualizeLabel";
            this.visualizeLabel.Size = new System.Drawing.Size(204, 46);
            this.visualizeLabel.TabIndex = 21;
            this.visualizeLabel.Tag = "";
            this.visualizeLabel.Text = "Visualize";
            this.visualizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.visualizeLabel.Click += new System.EventHandler(this.bottomLabel_Click);
            this.visualizeLabel.MouseEnter += new System.EventHandler(this.bottomLabel_MouseEnter);
            this.visualizeLabel.MouseLeave += new System.EventHandler(this.bottomLabel_MouseLeave);
            // 
            // bunifuTransition
            // 
            this.bunifuTransition.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.bunifuTransition.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 1F;
            this.bunifuTransition.DefaultAnimation = animation1;
            this.bunifuTransition.Interval = 20;
            // 
            // bunifuTransition1
            // 
            this.bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.bunifuTransition1.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 1F;
            this.bunifuTransition1.DefaultAnimation = animation2;
            this.bunifuTransition1.Interval = 20;
            // 
            // bunifuTransition2
            // 
            this.bunifuTransition2.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.bunifuTransition2.Cursor = null;
            animation3.AnimateOnlyDifferences = true;
            animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
            animation3.LeafCoeff = 0F;
            animation3.MaxTime = 1F;
            animation3.MinTime = 0F;
            animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
            animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
            animation3.MosaicSize = 0;
            animation3.Padding = new System.Windows.Forms.Padding(0);
            animation3.RotateCoeff = 0F;
            animation3.RotateLimit = 0F;
            animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
            animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
            animation3.TimeCoeff = 0F;
            animation3.TransparencyCoeff = 1F;
            this.bunifuTransition2.DefaultAnimation = animation3;
            this.bunifuTransition2.Interval = 20;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.OYOPanel);
            this.bunifuTransition1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1024, 738);
            this.Load += new System.EventHandler(this.MainView_Load);
            this.OYOPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.colorPanel.ResumeLayout(false);
            this.connectionPanel.ResumeLayout(false);
            this.activatedConnectionIconPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.detectFirePanel.ResumeLayout(false);
            this.etcPanel.ResumeLayout(false);
            this.leapmotionPanel.ResumeLayout(false);
            this.droneControlPanel.ResumeLayout(false);
            this.cameraPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel OYOPanel;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private System.Windows.Forms.Panel colorPanel;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition1;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition2;
        private System.Windows.Forms.Panel connectionPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel detectFirePanel;
        private System.Windows.Forms.Panel etcPanel;
        private System.Windows.Forms.Panel leapmotionPanel;
        private System.Windows.Forms.Panel droneControlPanel;
        private System.Windows.Forms.Panel cameraPanel;
        private System.Windows.Forms.Panel activatedConnectionIconPanel;
        public MainConnectionView mainConnectionView;
        public DetectFireTabShow detectFireTabShow;
        public LeapmotionTabShow leapmotionTabShow;
        public VisualizeTabShow visualizeTabShow;
        public DroneTabShow droneTabShow;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        public Bunifu.Framework.UI.BunifuCustomLabel detectFireLabel;
        public Bunifu.Framework.UI.BunifuCustomLabel etcLabel;
        public Bunifu.Framework.UI.BunifuCustomLabel leapmotionLabel;
        public Bunifu.Framework.UI.BunifuCustomLabel droneControlLabel;
        public Bunifu.Framework.UI.BunifuCustomLabel visualizeLabel;
    }
}
