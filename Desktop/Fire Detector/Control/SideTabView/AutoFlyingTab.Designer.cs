namespace Fire_Detector.Control.SideTabView
{
    partial class AutoFlyingTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoFlyingTab));
            this.panel3 = new System.Windows.Forms.Panel();
            this.autoFlyingButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.connectDroneProgressbar = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.autoFlyingStateLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.autoFlyingStartEndButton = new Bunifu.Framework.UI.BunifuThinButton2();
            this.autoFlyingSettingButton = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.areaLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.endSpotLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.startSpotLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomeLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.gmapBox = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoFlyingButton)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gmapBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.autoFlyingButton);
            this.panel3.Controls.Add(this.connectDroneProgressbar);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 124);
            this.panel3.TabIndex = 32;
            // 
            // autoFlyingButton
            // 
            this.autoFlyingButton.BackColor = System.Drawing.Color.Transparent;
            this.autoFlyingButton.Image = ((System.Drawing.Image)(resources.GetObject("autoFlyingButton.Image")));
            this.autoFlyingButton.ImageActive = null;
            this.autoFlyingButton.Location = new System.Drawing.Point(147, 32);
            this.autoFlyingButton.Name = "autoFlyingButton";
            this.autoFlyingButton.Size = new System.Drawing.Size(63, 61);
            this.autoFlyingButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.autoFlyingButton.TabIndex = 29;
            this.autoFlyingButton.TabStop = false;
            this.autoFlyingButton.Zoom = 10;
            this.autoFlyingButton.Click += new System.EventHandler(this.autoFlyingButton_Click);
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
            // panel7
            // 
            this.panel7.Controls.Add(this.panel6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 124);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(350, 43);
            this.panel7.TabIndex = 34;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.autoFlyingStateLabel);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panel6.Size = new System.Drawing.Size(350, 44);
            this.panel6.TabIndex = 37;
            // 
            // autoFlyingStateLabel
            // 
            this.autoFlyingStateLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.autoFlyingStateLabel.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.autoFlyingStateLabel.ForeColor = System.Drawing.Color.Tomato;
            this.autoFlyingStateLabel.Location = new System.Drawing.Point(20, 10);
            this.autoFlyingStateLabel.Name = "autoFlyingStateLabel";
            this.autoFlyingStateLabel.Size = new System.Drawing.Size(310, 15);
            this.autoFlyingStateLabel.TabIndex = 0;
            this.autoFlyingStateLabel.Text = "자율비행 정지 상태입니다.";
            this.autoFlyingStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 222);
            this.panel1.TabIndex = 35;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.autoFlyingStartEndButton);
            this.panel2.Controls.Add(this.autoFlyingSettingButton);
            this.panel2.Controls.Add(this.bunifuCustomLabel2);
            this.panel2.Controls.Add(this.bunifuCustomLabel6);
            this.panel2.Controls.Add(this.areaLabel);
            this.panel2.Controls.Add(this.endSpotLabel);
            this.panel2.Controls.Add(this.startSpotLabel);
            this.panel2.Controls.Add(this.bunifuCustomeLabel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 196);
            this.panel2.TabIndex = 23;
            // 
            // autoFlyingStartEndButton
            // 
            this.autoFlyingStartEndButton.ActiveBorderThickness = 1;
            this.autoFlyingStartEndButton.ActiveCornerRadius = 20;
            this.autoFlyingStartEndButton.ActiveFillColor = System.Drawing.Color.LightSalmon;
            this.autoFlyingStartEndButton.ActiveForecolor = System.Drawing.Color.White;
            this.autoFlyingStartEndButton.ActiveLineColor = System.Drawing.Color.Salmon;
            this.autoFlyingStartEndButton.BackColor = System.Drawing.Color.Transparent;
            this.autoFlyingStartEndButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("autoFlyingStartEndButton.BackgroundImage")));
            this.autoFlyingStartEndButton.ButtonText = "자동 비행 시작";
            this.autoFlyingStartEndButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.autoFlyingStartEndButton.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoFlyingStartEndButton.ForeColor = System.Drawing.Color.Salmon;
            this.autoFlyingStartEndButton.IdleBorderThickness = 1;
            this.autoFlyingStartEndButton.IdleCornerRadius = 20;
            this.autoFlyingStartEndButton.IdleFillColor = System.Drawing.Color.Transparent;
            this.autoFlyingStartEndButton.IdleForecolor = System.Drawing.Color.Salmon;
            this.autoFlyingStartEndButton.IdleLineColor = System.Drawing.Color.Salmon;
            this.autoFlyingStartEndButton.Location = new System.Drawing.Point(244, 159);
            this.autoFlyingStartEndButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.autoFlyingStartEndButton.Name = "autoFlyingStartEndButton";
            this.autoFlyingStartEndButton.Size = new System.Drawing.Size(86, 30);
            this.autoFlyingStartEndButton.TabIndex = 22;
            this.autoFlyingStartEndButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.autoFlyingStartEndButton.Click += new System.EventHandler(this.autoFlyingStartEndButton_Click);
            // 
            // autoFlyingSettingButton
            // 
            this.autoFlyingSettingButton.ActiveBorderThickness = 1;
            this.autoFlyingSettingButton.ActiveCornerRadius = 20;
            this.autoFlyingSettingButton.ActiveFillColor = System.Drawing.Color.LightSalmon;
            this.autoFlyingSettingButton.ActiveForecolor = System.Drawing.Color.White;
            this.autoFlyingSettingButton.ActiveLineColor = System.Drawing.Color.Salmon;
            this.autoFlyingSettingButton.BackColor = System.Drawing.Color.Transparent;
            this.autoFlyingSettingButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("autoFlyingSettingButton.BackgroundImage")));
            this.autoFlyingSettingButton.ButtonText = "영역 설정";
            this.autoFlyingSettingButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.autoFlyingSettingButton.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoFlyingSettingButton.ForeColor = System.Drawing.Color.Salmon;
            this.autoFlyingSettingButton.IdleBorderThickness = 1;
            this.autoFlyingSettingButton.IdleCornerRadius = 20;
            this.autoFlyingSettingButton.IdleFillColor = System.Drawing.Color.Transparent;
            this.autoFlyingSettingButton.IdleForecolor = System.Drawing.Color.Salmon;
            this.autoFlyingSettingButton.IdleLineColor = System.Drawing.Color.Salmon;
            this.autoFlyingSettingButton.Location = new System.Drawing.Point(171, 159);
            this.autoFlyingSettingButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.autoFlyingSettingButton.Name = "autoFlyingSettingButton";
            this.autoFlyingSettingButton.Size = new System.Drawing.Size(67, 30);
            this.autoFlyingSettingButton.TabIndex = 22;
            this.autoFlyingSettingButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.autoFlyingSettingButton.Click += new System.EventHandler(this.autoFlyingSettingButton_Click);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(40, 137);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(52, 15);
            this.bunifuCustomLabel2.TabIndex = 0;
            this.bunifuCustomLabel2.Text = "비행 면적";
            // 
            // bunifuCustomLabel6
            // 
            this.bunifuCustomLabel6.AutoSize = true;
            this.bunifuCustomLabel6.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(40, 72);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(53, 15);
            this.bunifuCustomLabel6.TabIndex = 0;
            this.bunifuCustomLabel6.Text = "종료 지점";
            // 
            // bunifuCustomLabel1
            // 
            this.areaLabel.AutoSize = true;
            this.areaLabel.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.areaLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.areaLabel.Location = new System.Drawing.Point(112, 137);
            this.areaLabel.Name = "bunifuCustomLabel1";
            this.areaLabel.Size = new System.Drawing.Size(30, 15);
            this.areaLabel.TabIndex = 0;
            this.areaLabel.Text = "0 ㎡";
            // 
            // endSpotLabel
            // 
            this.endSpotLabel.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.endSpotLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.endSpotLabel.Location = new System.Drawing.Point(112, 72);
            this.endSpotLabel.Name = "endSpotLabel";
            this.endSpotLabel.Size = new System.Drawing.Size(218, 45);
            this.endSpotLabel.TabIndex = 0;
            this.endSpotLabel.Text = "영역 설정이 필요합니다.";
            // 
            // startSpotLabel
            // 
            this.startSpotLabel.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.startSpotLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.startSpotLabel.Location = new System.Drawing.Point(112, 10);
            this.startSpotLabel.Name = "startSpotLabel";
            this.startSpotLabel.Size = new System.Drawing.Size(218, 45);
            this.startSpotLabel.TabIndex = 0;
            this.startSpotLabel.Text = "영역 설정이 필요합니다.";
            // 
            // bunifuCustomeLabel2
            // 
            this.bunifuCustomeLabel2.AutoSize = true;
            this.bunifuCustomeLabel2.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomeLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomeLabel2.Location = new System.Drawing.Point(40, 10);
            this.bunifuCustomeLabel2.Name = "bunifuCustomeLabel2";
            this.bunifuCustomeLabel2.Size = new System.Drawing.Size(52, 15);
            this.bunifuCustomeLabel2.TabIndex = 0;
            this.bunifuCustomeLabel2.Text = "시작 지점";
            // 
            // panel8
            // 
            this.panel8.AutoSize = true;
            this.panel8.Controls.Add(this.bunifuCustomLabel3);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(5);
            this.panel8.Size = new System.Drawing.Size(350, 26);
            this.panel8.TabIndex = 22;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.Salmon;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(24, 5);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(60, 16);
            this.bunifuCustomLabel3.TabIndex = 0;
            this.bunifuCustomLabel3.Text = "자동 비행";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.gmapBox);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 389);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(5);
            this.panel9.Size = new System.Drawing.Size(350, 305);
            this.panel9.TabIndex = 36;
            // 
            // gmapBox
            // 
            this.gmapBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmapBox.Location = new System.Drawing.Point(5, 5);
            this.gmapBox.Name = "gmapBox";
            this.gmapBox.Size = new System.Drawing.Size(340, 295);
            this.gmapBox.TabIndex = 25;
            this.gmapBox.TabStop = false;
            // 
            // AutoFlyingTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel3);
            this.Name = "AutoFlyingTab";
            this.Size = new System.Drawing.Size(350, 694);
            this.Tag = "Auto Flying";
            this.Load += new System.EventHandler(this.AutoFlyingTab_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.autoFlyingButton)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gmapBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuImageButton autoFlyingButton;
        private Bunifu.Framework.UI.BunifuCircleProgressbar connectDroneProgressbar;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private Bunifu.Framework.UI.BunifuCustomLabel autoFlyingStateLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuThinButton2 autoFlyingStartEndButton;
        private Bunifu.Framework.UI.BunifuThinButton2 autoFlyingSettingButton;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomeLabel2;
        private System.Windows.Forms.Panel panel8;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;
        private Bunifu.Framework.UI.BunifuCustomLabel endSpotLabel;
        private Bunifu.Framework.UI.BunifuCustomLabel startSpotLabel;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel areaLabel;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.PictureBox gmapBox;
    }
}
