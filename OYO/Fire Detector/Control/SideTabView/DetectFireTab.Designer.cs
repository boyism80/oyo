namespace Fire_Detector.Control.SideTabView
{
    partial class DetectFireTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetectFireTab));
            this.buttonCollapse = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.detectionStateSwitch = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.detectionStateLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel9 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.notificationSwitch = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.notificationLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel10 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel12 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel8 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel11 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel7 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.meanTemperature = new System.Windows.Forms.Label();
            this.minTemperature = new System.Windows.Forms.Label();
            this.maxTemperature = new System.Windows.Forms.Label();
            this.desiredTemperatureSlider = new Bunifu.Framework.UI.BunifuSlider();
            this.desiredTemperatureLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel13 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.fireDetectionTemperatruePanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.fireDetectionTemperatruePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCollapse
            // 
            this.buttonCollapse.Activecolor = System.Drawing.Color.Tomato;
            this.buttonCollapse.BackColor = System.Drawing.Color.Tomato;
            this.buttonCollapse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonCollapse.BorderRadius = 0;
            this.buttonCollapse.ButtonText = "Detect Fire";
            this.buttonCollapse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCollapse.DisabledColor = System.Drawing.Color.Gray;
            this.buttonCollapse.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCollapse.Font = new System.Drawing.Font("NEXON Football Gothic B", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.buttonCollapse.TabIndex = 16;
            this.buttonCollapse.Text = "Detect Fire";
            this.buttonCollapse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonCollapse.Textcolor = System.Drawing.Color.White;
            this.buttonCollapse.TextFont = new System.Drawing.Font("NEXON Football Gothic B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 44);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(350, 26);
            this.panel4.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.detectionStateSwitch);
            this.panel1.Controls.Add(this.detectionStateLabel);
            this.panel1.Controls.Add(this.bunifuCustomLabel9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 232);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 36);
            this.panel1.TabIndex = 23;
            // 
            // detectionStateSwitch
            // 
            this.detectionStateSwitch.BackColor = System.Drawing.Color.Transparent;
            this.detectionStateSwitch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("detectionStateSwitch.BackgroundImage")));
            this.detectionStateSwitch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.detectionStateSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.detectionStateSwitch.Location = new System.Drawing.Point(116, 6);
            this.detectionStateSwitch.Name = "detectionStateSwitch";
            this.detectionStateSwitch.OffColor = System.Drawing.Color.Gray;
            this.detectionStateSwitch.OnColor = System.Drawing.Color.Salmon;
            this.detectionStateSwitch.Size = new System.Drawing.Size(35, 20);
            this.detectionStateSwitch.TabIndex = 7;
            this.detectionStateSwitch.Value = true;
            this.detectionStateSwitch.OnValueChange += new System.EventHandler(this.detectionStateSwitch_OnValueChange);
            // 
            // detectionStateLabel
            // 
            this.detectionStateLabel.AutoSize = true;
            this.detectionStateLabel.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.detectionStateLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.detectionStateLabel.Location = new System.Drawing.Point(166, 10);
            this.detectionStateLabel.Name = "detectionStateLabel";
            this.detectionStateLabel.Size = new System.Drawing.Size(40, 15);
            this.detectionStateLabel.TabIndex = 1;
            this.detectionStateLabel.Text = "감지중";
            // 
            // bunifuCustomLabel9
            // 
            this.bunifuCustomLabel9.AutoSize = true;
            this.bunifuCustomLabel9.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel9.Location = new System.Drawing.Point(38, 10);
            this.bunifuCustomLabel9.Name = "bunifuCustomLabel9";
            this.bunifuCustomLabel9.Size = new System.Drawing.Size(73, 15);
            this.bunifuCustomLabel9.TabIndex = 0;
            this.bunifuCustomLabel9.Text = "산불감지모드";
            // 
            // notificationSwitch
            // 
            this.notificationSwitch.BackColor = System.Drawing.Color.Transparent;
            this.notificationSwitch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("notificationSwitch.BackgroundImage")));
            this.notificationSwitch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.notificationSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.notificationSwitch.Location = new System.Drawing.Point(116, 6);
            this.notificationSwitch.Name = "notificationSwitch";
            this.notificationSwitch.OffColor = System.Drawing.Color.Gray;
            this.notificationSwitch.OnColor = System.Drawing.Color.Salmon;
            this.notificationSwitch.Size = new System.Drawing.Size(35, 20);
            this.notificationSwitch.TabIndex = 7;
            this.notificationSwitch.Value = true;
            this.notificationSwitch.OnValueChange += new System.EventHandler(this.notificationSwitch_OnValueChange);
            // 
            // notificationLabel
            // 
            this.notificationLabel.AutoSize = true;
            this.notificationLabel.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.notificationLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.notificationLabel.Location = new System.Drawing.Point(166, 10);
            this.notificationLabel.Name = "notificationLabel";
            this.notificationLabel.Size = new System.Drawing.Size(23, 15);
            this.notificationLabel.TabIndex = 1;
            this.notificationLabel.Text = "On";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(38, 10);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(28, 15);
            this.bunifuCustomLabel2.TabIndex = 0;
            this.bunifuCustomLabel2.Text = "알림";
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.bunifuCustomLabel10);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 206);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(350, 26);
            this.panel3.TabIndex = 22;
            // 
            // bunifuCustomLabel10
            // 
            this.bunifuCustomLabel10.AutoSize = true;
            this.bunifuCustomLabel10.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel10.ForeColor = System.Drawing.Color.Salmon;
            this.bunifuCustomLabel10.Location = new System.Drawing.Point(24, 5);
            this.bunifuCustomLabel10.Name = "bunifuCustomLabel10";
            this.bunifuCustomLabel10.Size = new System.Drawing.Size(33, 16);
            this.bunifuCustomLabel10.TabIndex = 0;
            this.bunifuCustomLabel10.Text = "상태";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bunifuCustomLabel12);
            this.panel2.Controls.Add(this.bunifuCustomLabel8);
            this.panel2.Controls.Add(this.bunifuCustomLabel11);
            this.panel2.Controls.Add(this.bunifuCustomLabel7);
            this.panel2.Controls.Add(this.bunifuCustomLabel5);
            this.panel2.Controls.Add(this.bunifuCustomLabel4);
            this.panel2.Controls.Add(this.meanTemperature);
            this.panel2.Controls.Add(this.minTemperature);
            this.panel2.Controls.Add(this.maxTemperature);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 110);
            this.panel2.TabIndex = 21;
            // 
            // bunifuCustomLabel12
            // 
            this.bunifuCustomLabel12.AutoSize = true;
            this.bunifuCustomLabel12.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel12.Location = new System.Drawing.Point(147, 78);
            this.bunifuCustomLabel12.Name = "bunifuCustomLabel12";
            this.bunifuCustomLabel12.Size = new System.Drawing.Size(21, 15);
            this.bunifuCustomLabel12.TabIndex = 1;
            this.bunifuCustomLabel12.Text = "ºC";
            // 
            // bunifuCustomLabel8
            // 
            this.bunifuCustomLabel8.AutoSize = true;
            this.bunifuCustomLabel8.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel8.Location = new System.Drawing.Point(147, 44);
            this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
            this.bunifuCustomLabel8.Size = new System.Drawing.Size(21, 15);
            this.bunifuCustomLabel8.TabIndex = 1;
            this.bunifuCustomLabel8.Text = "ºC";
            // 
            // bunifuCustomLabel11
            // 
            this.bunifuCustomLabel11.AutoSize = true;
            this.bunifuCustomLabel11.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel11.Location = new System.Drawing.Point(40, 78);
            this.bunifuCustomLabel11.Name = "bunifuCustomLabel11";
            this.bunifuCustomLabel11.Size = new System.Drawing.Size(50, 15);
            this.bunifuCustomLabel11.TabIndex = 0;
            this.bunifuCustomLabel11.Text = "평균온도";
            // 
            // bunifuCustomLabel7
            // 
            this.bunifuCustomLabel7.AutoSize = true;
            this.bunifuCustomLabel7.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel7.Location = new System.Drawing.Point(40, 44);
            this.bunifuCustomLabel7.Name = "bunifuCustomLabel7";
            this.bunifuCustomLabel7.Size = new System.Drawing.Size(51, 15);
            this.bunifuCustomLabel7.TabIndex = 0;
            this.bunifuCustomLabel7.Text = "최저온도";
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(147, 10);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(21, 15);
            this.bunifuCustomLabel5.TabIndex = 1;
            this.bunifuCustomLabel5.Text = "ºC";
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(40, 10);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(51, 15);
            this.bunifuCustomLabel4.TabIndex = 0;
            this.bunifuCustomLabel4.Text = "최고온도";
            // 
            // meanTemperature
            // 
            this.meanTemperature.AutoSize = true;
            this.meanTemperature.Font = new System.Drawing.Font("NEXON Football Gothic L", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.meanTemperature.ForeColor = System.Drawing.Color.MediumPurple;
            this.meanTemperature.Location = new System.Drawing.Point(96, 78);
            this.meanTemperature.Name = "meanTemperature";
            this.meanTemperature.Size = new System.Drawing.Size(14, 13);
            this.meanTemperature.TabIndex = 8;
            this.meanTemperature.Text = "0";
            // 
            // minTemperature
            // 
            this.minTemperature.AutoSize = true;
            this.minTemperature.Font = new System.Drawing.Font("NEXON Football Gothic L", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.minTemperature.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.minTemperature.Location = new System.Drawing.Point(96, 44);
            this.minTemperature.Name = "minTemperature";
            this.minTemperature.Size = new System.Drawing.Size(14, 13);
            this.minTemperature.TabIndex = 8;
            this.minTemperature.Text = "0";
            // 
            // maxTemperature
            // 
            this.maxTemperature.AutoSize = true;
            this.maxTemperature.Font = new System.Drawing.Font("NEXON Football Gothic L", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.maxTemperature.ForeColor = System.Drawing.Color.LightCoral;
            this.maxTemperature.Location = new System.Drawing.Point(96, 10);
            this.maxTemperature.Name = "maxTemperature";
            this.maxTemperature.Size = new System.Drawing.Size(14, 13);
            this.maxTemperature.TabIndex = 8;
            this.maxTemperature.Text = "0";
            // 
            // desiredTemperatureSlider
            // 
            this.desiredTemperatureSlider.BackColor = System.Drawing.Color.Transparent;
            this.desiredTemperatureSlider.BackgroudColor = System.Drawing.Color.DarkGray;
            this.desiredTemperatureSlider.BorderRadius = 5;
            this.desiredTemperatureSlider.IndicatorColor = System.Drawing.Color.Salmon;
            this.desiredTemperatureSlider.Location = new System.Drawing.Point(116, 39);
            this.desiredTemperatureSlider.MaximumValue = 110;
            this.desiredTemperatureSlider.Name = "desiredTemperatureSlider";
            this.desiredTemperatureSlider.Size = new System.Drawing.Size(170, 28);
            this.desiredTemperatureSlider.TabIndex = 15;
            this.desiredTemperatureSlider.Value = 50;
            this.desiredTemperatureSlider.ValueChanged += new System.EventHandler(this.desiredTemperatureSlider_ValueChanged);
            // 
            // desiredTemperatureLabel
            // 
            this.desiredTemperatureLabel.AutoSize = true;
            this.desiredTemperatureLabel.ForeColor = System.Drawing.Color.Salmon;
            this.desiredTemperatureLabel.Location = new System.Drawing.Point(294, 44);
            this.desiredTemperatureLabel.Name = "desiredTemperatureLabel";
            this.desiredTemperatureLabel.Size = new System.Drawing.Size(11, 12);
            this.desiredTemperatureLabel.TabIndex = 14;
            this.desiredTemperatureLabel.Text = "0";
            // 
            // bunifuCustomLabel13
            // 
            this.bunifuCustomLabel13.AutoSize = true;
            this.bunifuCustomLabel13.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel13.Location = new System.Drawing.Point(39, 44);
            this.bunifuCustomLabel13.Name = "bunifuCustomLabel13";
            this.bunifuCustomLabel13.Size = new System.Drawing.Size(71, 15);
            this.bunifuCustomLabel13.TabIndex = 12;
            this.bunifuCustomLabel13.Text = "산불인식온도";
            // 
            // panel8
            // 
            this.panel8.AutoSize = true;
            this.panel8.Controls.Add(this.bunifuCustomLabel3);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 70);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(5);
            this.panel8.Size = new System.Drawing.Size(350, 26);
            this.panel8.TabIndex = 20;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.Salmon;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(24, 5);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(32, 16);
            this.bunifuCustomLabel3.TabIndex = 0;
            this.bunifuCustomLabel3.Text = "온도";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(317, 44);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(21, 15);
            this.bunifuCustomLabel1.TabIndex = 1;
            this.bunifuCustomLabel1.Text = "ºC";
            // 
            // fireDetectionTemperatruePanel
            // 
            this.fireDetectionTemperatruePanel.Controls.Add(this.desiredTemperatureSlider);
            this.fireDetectionTemperatruePanel.Controls.Add(this.desiredTemperatureLabel);
            this.fireDetectionTemperatruePanel.Controls.Add(this.notificationSwitch);
            this.fireDetectionTemperatruePanel.Controls.Add(this.bunifuCustomLabel1);
            this.fireDetectionTemperatruePanel.Controls.Add(this.bunifuCustomLabel2);
            this.fireDetectionTemperatruePanel.Controls.Add(this.bunifuCustomLabel13);
            this.fireDetectionTemperatruePanel.Controls.Add(this.notificationLabel);
            this.fireDetectionTemperatruePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fireDetectionTemperatruePanel.Location = new System.Drawing.Point(0, 268);
            this.fireDetectionTemperatruePanel.Name = "fireDetectionTemperatruePanel";
            this.fireDetectionTemperatruePanel.Size = new System.Drawing.Size(350, 72);
            this.fireDetectionTemperatruePanel.TabIndex = 24;
            // 
            // DetectFireTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.fireDetectionTemperatruePanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.buttonCollapse);
            this.Name = "DetectFireTab";
            this.Size = new System.Drawing.Size(350, 738);
            this.Load += new System.EventHandler(this.DetectFireTab_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.fireDetectionTemperatruePanel.ResumeLayout(false);
            this.fireDetectionTemperatruePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuFlatButton buttonCollapse;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuiOSSwitch notificationSwitch;
        private Bunifu.Framework.UI.BunifuiOSSwitch detectionStateSwitch;
        private Bunifu.Framework.UI.BunifuCustomLabel notificationLabel;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel detectionStateLabel;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel9;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel10;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel12;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel8;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel11;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel7;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private System.Windows.Forms.Label meanTemperature;
        private System.Windows.Forms.Label minTemperature;
        private System.Windows.Forms.Label maxTemperature;
        private System.Windows.Forms.Panel panel8;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel desiredTemperatureLabel;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel13;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.Panel fireDetectionTemperatruePanel;
        public Bunifu.Framework.UI.BunifuSlider desiredTemperatureSlider;
    }
}
