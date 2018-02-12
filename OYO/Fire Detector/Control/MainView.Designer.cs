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
            BunifuAnimatorNS.Animation animation6 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation5 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation4 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.connectionPanel = new System.Windows.Forms.Panel();
            this.activatedConnectionIconPanel = new System.Windows.Forms.Panel();
            this.connectionIconsPanel = new System.Windows.Forms.Panel();
            this.droneImageButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.raspCamImageButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuCustomLabel7 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.leapMotionImageButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.leapmotionProgressbar = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.raspCamProgressbar = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.bunifuCustomLabel8 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.droneProgressbar = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel10 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel9 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuTransition = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.bunifuTransition1 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.bunifuTransition2 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.colorPanel.SuspendLayout();
            this.connectionPanel.SuspendLayout();
            this.connectionIconsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.droneImageButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.raspCamImageButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leapMotionImageButton)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.bunifuImageButton1);
            this.panel2.Controls.Add(this.bunifuCustomLabel5);
            this.panel2.Controls.Add(this.bunifuCustomLabel4);
            this.panel2.Controls.Add(this.bunifuCustomLabel3);
            this.panel2.Controls.Add(this.bunifuCustomLabel2);
            this.panel2.Controls.Add(this.bunifuCustomLabel1);
            this.bunifuTransition.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 151);
            this.panel2.TabIndex = 1;
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(31, 56);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(70, 70);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 2;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuTransition2.SetDecoration(this.bunifuCustomLabel5, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel5, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.bunifuCustomLabel5, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel5.ForeColor = System.Drawing.Color.DarkSalmon;
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(218, 111);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(55, 16);
            this.bunifuCustomLabel5.TabIndex = 0;
            this.bunifuCustomLabel5.Text = "JE Park";
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuTransition2.SetDecoration(this.bunifuCustomLabel4, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel4, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.bunifuCustomLabel4, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel4.ForeColor = System.Drawing.Color.LightCoral;
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(168, 111);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(49, 16);
            this.bunifuCustomLabel4.TabIndex = 0;
            this.bunifuCustomLabel4.Text = "JS Kim";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuTransition2.SetDecoration(this.bunifuCustomLabel3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.bunifuCustomLabel3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.OrangeRed;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(109, 111);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(62, 16);
            this.bunifuCustomLabel3.TabIndex = 0;
            this.bunifuCustomLabel3.Text = "SH Chae";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuTransition2.SetDecoration(this.bunifuCustomLabel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.bunifuCustomLabel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.Tomato;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(109, 84);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(184, 20);
            this.bunifuCustomLabel2.TabIndex = 0;
            this.bunifuCustomLabel2.Text = "Old Young Old in KPU";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuTransition2.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Coral;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(107, 57);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(310, 29);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "Detecting Fire with Drone";
            // 
            // colorPanel
            // 
            this.colorPanel.Controls.Add(this.connectionPanel);
            this.colorPanel.Controls.Add(this.panel3);
            this.bunifuTransition.SetDecoration(this.colorPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.colorPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.colorPanel, BunifuAnimatorNS.DecorationType.None);
            this.colorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorPanel.Location = new System.Drawing.Point(0, 151);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(1024, 587);
            this.colorPanel.TabIndex = 2;
            // 
            // connectionPanel
            // 
            this.connectionPanel.Controls.Add(this.activatedConnectionIconPanel);
            this.connectionPanel.Controls.Add(this.connectionIconsPanel);
            this.bunifuTransition.SetDecoration(this.connectionPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.connectionPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.connectionPanel, BunifuAnimatorNS.DecorationType.None);
            this.connectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionPanel.Location = new System.Drawing.Point(0, 0);
            this.connectionPanel.Name = "connectionPanel";
            this.connectionPanel.Size = new System.Drawing.Size(1024, 557);
            this.connectionPanel.TabIndex = 3;
            // 
            // activatedConnectionIconPanel
            // 
            this.bunifuTransition.SetDecoration(this.activatedConnectionIconPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.activatedConnectionIconPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.activatedConnectionIconPanel, BunifuAnimatorNS.DecorationType.None);
            this.activatedConnectionIconPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activatedConnectionIconPanel.Location = new System.Drawing.Point(0, 310);
            this.activatedConnectionIconPanel.Name = "activatedConnectionIconPanel";
            this.activatedConnectionIconPanel.Size = new System.Drawing.Size(1024, 247);
            this.activatedConnectionIconPanel.TabIndex = 22;
            this.activatedConnectionIconPanel.Visible = false;
            // 
            // connectionIconsPanel
            // 
            this.connectionIconsPanel.Controls.Add(this.droneImageButton);
            this.connectionIconsPanel.Controls.Add(this.raspCamImageButton);
            this.connectionIconsPanel.Controls.Add(this.bunifuCustomLabel7);
            this.connectionIconsPanel.Controls.Add(this.leapMotionImageButton);
            this.connectionIconsPanel.Controls.Add(this.leapmotionProgressbar);
            this.connectionIconsPanel.Controls.Add(this.bunifuCustomLabel6);
            this.connectionIconsPanel.Controls.Add(this.raspCamProgressbar);
            this.connectionIconsPanel.Controls.Add(this.bunifuCustomLabel8);
            this.connectionIconsPanel.Controls.Add(this.droneProgressbar);
            this.bunifuTransition.SetDecoration(this.connectionIconsPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.connectionIconsPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.connectionIconsPanel, BunifuAnimatorNS.DecorationType.None);
            this.connectionIconsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.connectionIconsPanel.Location = new System.Drawing.Point(0, 0);
            this.connectionIconsPanel.Name = "connectionIconsPanel";
            this.connectionIconsPanel.Size = new System.Drawing.Size(1024, 310);
            this.connectionIconsPanel.TabIndex = 21;
            // 
            // droneImageButton
            // 
            this.droneImageButton.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition.SetDecoration(this.droneImageButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.droneImageButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.droneImageButton, BunifuAnimatorNS.DecorationType.None);
            this.droneImageButton.Image = ((System.Drawing.Image)(resources.GetObject("droneImageButton.Image")));
            this.droneImageButton.ImageActive = null;
            this.droneImageButton.Location = new System.Drawing.Point(129, 78);
            this.droneImageButton.Name = "droneImageButton";
            this.droneImageButton.Size = new System.Drawing.Size(110, 110);
            this.droneImageButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.droneImageButton.TabIndex = 14;
            this.droneImageButton.TabStop = false;
            this.droneImageButton.Zoom = 10;
            // 
            // raspCamImageButton
            // 
            this.raspCamImageButton.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition.SetDecoration(this.raspCamImageButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.raspCamImageButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.raspCamImageButton, BunifuAnimatorNS.DecorationType.None);
            this.raspCamImageButton.Image = ((System.Drawing.Image)(resources.GetObject("raspCamImageButton.Image")));
            this.raspCamImageButton.ImageActive = null;
            this.raspCamImageButton.Location = new System.Drawing.Point(471, 70);
            this.raspCamImageButton.Name = "raspCamImageButton";
            this.raspCamImageButton.Size = new System.Drawing.Size(110, 110);
            this.raspCamImageButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.raspCamImageButton.TabIndex = 17;
            this.raspCamImageButton.TabStop = false;
            this.raspCamImageButton.Zoom = 10;
            // 
            // bunifuCustomLabel7
            // 
            this.bunifuCustomLabel7.AutoSize = true;
            this.bunifuTransition2.SetDecoration(this.bunifuCustomLabel7, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel7, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.bunifuCustomLabel7, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel7.ForeColor = System.Drawing.Color.Coral;
            this.bunifuCustomLabel7.Location = new System.Drawing.Point(460, 229);
            this.bunifuCustomLabel7.Name = "bunifuCustomLabel7";
            this.bunifuCustomLabel7.Size = new System.Drawing.Size(168, 31);
            this.bunifuCustomLabel7.TabIndex = 16;
            this.bunifuCustomLabel7.Text = "RaspPiCam";
            // 
            // leapMotionImageButton
            // 
            this.leapMotionImageButton.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition.SetDecoration(this.leapMotionImageButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.leapMotionImageButton, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.leapMotionImageButton, BunifuAnimatorNS.DecorationType.None);
            this.leapMotionImageButton.Image = ((System.Drawing.Image)(resources.GetObject("leapMotionImageButton.Image")));
            this.leapMotionImageButton.ImageActive = null;
            this.leapMotionImageButton.Location = new System.Drawing.Point(810, 78);
            this.leapMotionImageButton.Name = "leapMotionImageButton";
            this.leapMotionImageButton.Size = new System.Drawing.Size(90, 90);
            this.leapMotionImageButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.leapMotionImageButton.TabIndex = 20;
            this.leapMotionImageButton.TabStop = false;
            this.leapMotionImageButton.Zoom = 10;
            // 
            // leapmotionProgressbar
            // 
            this.leapmotionProgressbar.animated = false;
            this.leapmotionProgressbar.animationIterval = 5;
            this.leapmotionProgressbar.animationSpeed = 3;
            this.leapmotionProgressbar.BackColor = System.Drawing.Color.Transparent;
            this.leapmotionProgressbar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leapmotionProgressbar.BackgroundImage")));
            this.bunifuTransition.SetDecoration(this.leapmotionProgressbar, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.leapmotionProgressbar, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.leapmotionProgressbar, BunifuAnimatorNS.DecorationType.None);
            this.leapmotionProgressbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.leapmotionProgressbar.ForeColor = System.Drawing.Color.Tomato;
            this.leapmotionProgressbar.LabelVisible = false;
            this.leapmotionProgressbar.LineProgressThickness = 5;
            this.leapmotionProgressbar.LineThickness = 5;
            this.leapmotionProgressbar.Location = new System.Drawing.Point(752, 23);
            this.leapmotionProgressbar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.leapmotionProgressbar.MaxValue = 100;
            this.leapmotionProgressbar.Name = "leapmotionProgressbar";
            this.leapmotionProgressbar.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.leapmotionProgressbar.ProgressColor = System.Drawing.Color.Tomato;
            this.leapmotionProgressbar.Size = new System.Drawing.Size(200, 200);
            this.leapmotionProgressbar.TabIndex = 18;
            this.leapmotionProgressbar.Value = 0;
            // 
            // bunifuCustomLabel6
            // 
            this.bunifuCustomLabel6.AutoSize = true;
            this.bunifuTransition2.SetDecoration(this.bunifuCustomLabel6, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel6, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.bunifuCustomLabel6, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel6.ForeColor = System.Drawing.Color.Coral;
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(140, 237);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(93, 31);
            this.bunifuCustomLabel6.TabIndex = 13;
            this.bunifuCustomLabel6.Text = "Drone";
            // 
            // raspCamProgressbar
            // 
            this.raspCamProgressbar.animated = false;
            this.raspCamProgressbar.animationIterval = 5;
            this.raspCamProgressbar.animationSpeed = 3;
            this.raspCamProgressbar.BackColor = System.Drawing.Color.Transparent;
            this.raspCamProgressbar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("raspCamProgressbar.BackgroundImage")));
            this.bunifuTransition.SetDecoration(this.raspCamProgressbar, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.raspCamProgressbar, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.raspCamProgressbar, BunifuAnimatorNS.DecorationType.None);
            this.raspCamProgressbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.raspCamProgressbar.ForeColor = System.Drawing.Color.Tomato;
            this.raspCamProgressbar.LabelVisible = false;
            this.raspCamProgressbar.LineProgressThickness = 5;
            this.raspCamProgressbar.LineThickness = 5;
            this.raspCamProgressbar.Location = new System.Drawing.Point(426, 23);
            this.raspCamProgressbar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.raspCamProgressbar.MaxValue = 100;
            this.raspCamProgressbar.Name = "raspCamProgressbar";
            this.raspCamProgressbar.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.raspCamProgressbar.ProgressColor = System.Drawing.Color.Tomato;
            this.raspCamProgressbar.Size = new System.Drawing.Size(200, 200);
            this.raspCamProgressbar.TabIndex = 15;
            this.raspCamProgressbar.Value = 0;
            // 
            // bunifuCustomLabel8
            // 
            this.bunifuCustomLabel8.AutoSize = true;
            this.bunifuTransition2.SetDecoration(this.bunifuCustomLabel8, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel8, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.bunifuCustomLabel8, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel8.ForeColor = System.Drawing.Color.Coral;
            this.bunifuCustomLabel8.Location = new System.Drawing.Point(786, 229);
            this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
            this.bunifuCustomLabel8.Size = new System.Drawing.Size(165, 31);
            this.bunifuCustomLabel8.TabIndex = 19;
            this.bunifuCustomLabel8.Text = "Leapmotion";
            // 
            // droneProgressbar
            // 
            this.droneProgressbar.animated = false;
            this.droneProgressbar.animationIterval = 5;
            this.droneProgressbar.animationSpeed = 3;
            this.droneProgressbar.BackColor = System.Drawing.Color.Transparent;
            this.droneProgressbar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("droneProgressbar.BackgroundImage")));
            this.bunifuTransition.SetDecoration(this.droneProgressbar, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.droneProgressbar, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.droneProgressbar, BunifuAnimatorNS.DecorationType.None);
            this.droneProgressbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.droneProgressbar.ForeColor = System.Drawing.Color.Tomato;
            this.droneProgressbar.LabelVisible = false;
            this.droneProgressbar.LineProgressThickness = 5;
            this.droneProgressbar.LineThickness = 5;
            this.droneProgressbar.Location = new System.Drawing.Point(84, 31);
            this.droneProgressbar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.droneProgressbar.MaxValue = 100;
            this.droneProgressbar.Name = "droneProgressbar";
            this.droneProgressbar.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.droneProgressbar.ProgressColor = System.Drawing.Color.Tomato;
            this.droneProgressbar.Size = new System.Drawing.Size(200, 200);
            this.droneProgressbar.TabIndex = 12;
            this.droneProgressbar.Value = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel1);
            this.bunifuTransition.SetDecoration(this.panel3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.panel3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.panel3, BunifuAnimatorNS.DecorationType.None);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 557);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1024, 30);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Coral;
            this.panel4.Controls.Add(this.bunifuCustomLabel10);
            this.bunifuTransition.SetDecoration(this.panel4, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.panel4, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.panel4, BunifuAnimatorNS.DecorationType.None);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(200, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 30);
            this.panel4.TabIndex = 1;
            this.panel4.MouseEnter += new System.EventHandler(this.panel4_MouseEnter);
            this.panel4.MouseLeave += new System.EventHandler(this.bunifuCustomLabel9_MouseLeave);
            this.panel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseMove);
            // 
            // bunifuCustomLabel10
            // 
            this.bunifuCustomLabel10.AutoSize = true;
            this.bunifuTransition2.SetDecoration(this.bunifuCustomLabel10, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel10, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.bunifuCustomLabel10, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel10.Location = new System.Drawing.Point(53, 7);
            this.bunifuCustomLabel10.Name = "bunifuCustomLabel10";
            this.bunifuCustomLabel10.Size = new System.Drawing.Size(82, 12);
            this.bunifuCustomLabel10.TabIndex = 21;
            this.bunifuCustomLabel10.Text = "Drone Control";
            this.bunifuCustomLabel10.MouseEnter += new System.EventHandler(this.panel4_MouseEnter);
            this.bunifuCustomLabel10.MouseLeave += new System.EventHandler(this.bunifuCustomLabel9_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Coral;
            this.panel1.Controls.Add(this.bunifuCustomLabel9);
            this.bunifuTransition.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 30);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.bunifuCustomLabel9_Click);
            this.panel1.MouseEnter += new System.EventHandler(this.bunifuCustomLabel9_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.bunifuCustomLabel9_MouseLeave);
            // 
            // bunifuCustomLabel9
            // 
            this.bunifuCustomLabel9.AutoSize = true;
            this.bunifuTransition2.SetDecoration(this.bunifuCustomLabel9, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuCustomLabel9, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this.bunifuCustomLabel9, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel9.Location = new System.Drawing.Point(53, 7);
            this.bunifuCustomLabel9.Name = "bunifuCustomLabel9";
            this.bunifuCustomLabel9.Size = new System.Drawing.Size(82, 12);
            this.bunifuCustomLabel9.TabIndex = 21;
            this.bunifuCustomLabel9.Text = "Drone Control";
            this.bunifuCustomLabel9.Click += new System.EventHandler(this.bunifuCustomLabel9_Click);
            this.bunifuCustomLabel9.MouseEnter += new System.EventHandler(this.bunifuCustomLabel9_MouseEnter);
            this.bunifuCustomLabel9.MouseLeave += new System.EventHandler(this.bunifuCustomLabel9_MouseLeave);
            // 
            // bunifuTransition
            // 
            this.bunifuTransition.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.bunifuTransition.Cursor = null;
            animation6.AnimateOnlyDifferences = true;
            animation6.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.BlindCoeff")));
            animation6.LeafCoeff = 0F;
            animation6.MaxTime = 1F;
            animation6.MinTime = 0F;
            animation6.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.MosaicCoeff")));
            animation6.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation6.MosaicShift")));
            animation6.MosaicSize = 0;
            animation6.Padding = new System.Windows.Forms.Padding(0);
            animation6.RotateCoeff = 0F;
            animation6.RotateLimit = 0F;
            animation6.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.ScaleCoeff")));
            animation6.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.SlideCoeff")));
            animation6.TimeCoeff = 0F;
            animation6.TransparencyCoeff = 1F;
            this.bunifuTransition.DefaultAnimation = animation6;
            this.bunifuTransition.Interval = 20;
            // 
            // bunifuTransition1
            // 
            this.bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.bunifuTransition1.Cursor = null;
            animation5.AnimateOnlyDifferences = true;
            animation5.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.BlindCoeff")));
            animation5.LeafCoeff = 0F;
            animation5.MaxTime = 1F;
            animation5.MinTime = 0F;
            animation5.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.MosaicCoeff")));
            animation5.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation5.MosaicShift")));
            animation5.MosaicSize = 0;
            animation5.Padding = new System.Windows.Forms.Padding(0);
            animation5.RotateCoeff = 0F;
            animation5.RotateLimit = 0F;
            animation5.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.ScaleCoeff")));
            animation5.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.SlideCoeff")));
            animation5.TimeCoeff = 0F;
            animation5.TransparencyCoeff = 1F;
            this.bunifuTransition1.DefaultAnimation = animation5;
            this.bunifuTransition1.Interval = 20;
            // 
            // bunifuTransition2
            // 
            this.bunifuTransition2.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.bunifuTransition2.Cursor = null;
            animation4.AnimateOnlyDifferences = true;
            animation4.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.BlindCoeff")));
            animation4.LeafCoeff = 0F;
            animation4.MaxTime = 1F;
            animation4.MinTime = 0F;
            animation4.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicCoeff")));
            animation4.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicShift")));
            animation4.MosaicSize = 0;
            animation4.Padding = new System.Windows.Forms.Padding(0);
            animation4.RotateCoeff = 0F;
            animation4.RotateLimit = 0F;
            animation4.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.ScaleCoeff")));
            animation4.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.SlideCoeff")));
            animation4.TimeCoeff = 0F;
            animation4.TransparencyCoeff = 1F;
            this.bunifuTransition2.DefaultAnimation = animation4;
            this.bunifuTransition2.Interval = 20;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.panel2);
            this.bunifuTransition2.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1024, 738);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.colorPanel.ResumeLayout(false);
            this.connectionPanel.ResumeLayout(false);
            this.connectionIconsPanel.ResumeLayout(false);
            this.connectionIconsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.droneImageButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.raspCamImageButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leapMotionImageButton)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Panel connectionPanel;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuImageButton droneImageButton;
        private Bunifu.Framework.UI.BunifuCircleProgressbar droneProgressbar;
        private Bunifu.Framework.UI.BunifuImageButton leapMotionImageButton;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel8;
        private Bunifu.Framework.UI.BunifuCircleProgressbar raspCamProgressbar;
        private Bunifu.Framework.UI.BunifuCircleProgressbar leapmotionProgressbar;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel7;
        private Bunifu.Framework.UI.BunifuImageButton raspCamImageButton;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel9;
        private System.Windows.Forms.Panel panel1;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition;
        private System.Windows.Forms.Panel connectionIconsPanel;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition1;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition2;
        private System.Windows.Forms.Panel activatedConnectionIconPanel;
        private System.Windows.Forms.Panel panel4;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel10;
    }
}
