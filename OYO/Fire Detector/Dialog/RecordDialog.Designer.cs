namespace Fire_Detector.Dialog
{
    partial class RecordDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordDialog));
            this.caption = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.cancelButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.confirmButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomTextbox1 = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuCustomTextbox2 = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.patrolFileBrowseButton = new Bunifu.Framework.UI.BunifuThinButton2();
            this.caption.SuspendLayout();
            this.SuspendLayout();
            // 
            // caption
            // 
            this.caption.BackColor = System.Drawing.Color.Salmon;
            this.caption.Controls.Add(this.bunifuCustomLabel1);
            this.caption.Dock = System.Windows.Forms.DockStyle.Top;
            this.caption.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.caption.ForeColor = System.Drawing.Color.White;
            this.caption.Location = new System.Drawing.Point(0, 0);
            this.caption.Name = "caption";
            this.caption.Size = new System.Drawing.Size(664, 28);
            this.caption.TabIndex = 5;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(10, 5);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(87, 16);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "녹화 파일 설정";
            // 
            // cancelButton
            // 
            this.cancelButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.cancelButton.BackColor = System.Drawing.Color.LightCoral;
            this.cancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancelButton.BorderRadius = 0;
            this.cancelButton.ButtonText = "취소";
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelButton.DisabledColor = System.Drawing.Color.Gray;
            this.cancelButton.Iconcolor = System.Drawing.Color.Transparent;
            this.cancelButton.Iconimage = null;
            this.cancelButton.Iconimage_right = null;
            this.cancelButton.Iconimage_right_Selected = null;
            this.cancelButton.Iconimage_Selected = null;
            this.cancelButton.IconMarginLeft = 0;
            this.cancelButton.IconMarginRight = 0;
            this.cancelButton.IconRightVisible = true;
            this.cancelButton.IconRightZoom = 0D;
            this.cancelButton.IconVisible = true;
            this.cancelButton.IconZoom = 90D;
            this.cancelButton.IsTab = false;
            this.cancelButton.Location = new System.Drawing.Point(542, 211);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Normalcolor = System.Drawing.Color.LightCoral;
            this.cancelButton.OnHovercolor = System.Drawing.Color.Tomato;
            this.cancelButton.OnHoverTextColor = System.Drawing.Color.White;
            this.cancelButton.selected = false;
            this.cancelButton.Size = new System.Drawing.Size(80, 29);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "취소";
            this.cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cancelButton.Textcolor = System.Drawing.Color.White;
            this.cancelButton.TextFont = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.confirmButton.BackColor = System.Drawing.Color.LightCoral;
            this.confirmButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.confirmButton.BorderRadius = 0;
            this.confirmButton.ButtonText = "확인";
            this.confirmButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirmButton.DisabledColor = System.Drawing.Color.Gray;
            this.confirmButton.Iconcolor = System.Drawing.Color.Transparent;
            this.confirmButton.Iconimage = null;
            this.confirmButton.Iconimage_right = null;
            this.confirmButton.Iconimage_right_Selected = null;
            this.confirmButton.Iconimage_Selected = null;
            this.confirmButton.IconMarginLeft = 0;
            this.confirmButton.IconMarginRight = 0;
            this.confirmButton.IconRightVisible = true;
            this.confirmButton.IconRightZoom = 0D;
            this.confirmButton.IconVisible = true;
            this.confirmButton.IconZoom = 90D;
            this.confirmButton.IsTab = false;
            this.confirmButton.Location = new System.Drawing.Point(456, 211);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Normalcolor = System.Drawing.Color.LightCoral;
            this.confirmButton.OnHovercolor = System.Drawing.Color.Tomato;
            this.confirmButton.OnHoverTextColor = System.Drawing.Color.White;
            this.confirmButton.selected = false;
            this.confirmButton.Size = new System.Drawing.Size(80, 29);
            this.confirmButton.TabIndex = 6;
            this.confirmButton.Text = "확인";
            this.confirmButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.confirmButton.Textcolor = System.Drawing.Color.White;
            this.confirmButton.TextFont = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(48, 78);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(60, 16);
            this.bunifuCustomLabel2.TabIndex = 7;
            this.bunifuCustomLabel2.Text = "저장 경로";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(48, 126);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(60, 16);
            this.bunifuCustomLabel3.TabIndex = 7;
            this.bunifuCustomLabel3.Text = "파일 이름";
            // 
            // bunifuCustomTextbox1
            // 
            this.bunifuCustomTextbox1.BorderColor = System.Drawing.Color.SeaGreen;
            this.bunifuCustomTextbox1.Location = new System.Drawing.Point(133, 123);
            this.bunifuCustomTextbox1.Name = "bunifuCustomTextbox1";
            this.bunifuCustomTextbox1.Size = new System.Drawing.Size(488, 21);
            this.bunifuCustomTextbox1.TabIndex = 8;
            // 
            // bunifuCustomTextbox2
            // 
            this.bunifuCustomTextbox2.BorderColor = System.Drawing.Color.SeaGreen;
            this.bunifuCustomTextbox2.Location = new System.Drawing.Point(133, 76);
            this.bunifuCustomTextbox2.Name = "bunifuCustomTextbox2";
            this.bunifuCustomTextbox2.Size = new System.Drawing.Size(443, 21);
            this.bunifuCustomTextbox2.TabIndex = 8;
            // 
            // patrolFileBrowseButton
            // 
            this.patrolFileBrowseButton.ActiveBorderThickness = 1;
            this.patrolFileBrowseButton.ActiveCornerRadius = 20;
            this.patrolFileBrowseButton.ActiveFillColor = System.Drawing.Color.LightSalmon;
            this.patrolFileBrowseButton.ActiveForecolor = System.Drawing.Color.White;
            this.patrolFileBrowseButton.ActiveLineColor = System.Drawing.Color.Salmon;
            this.patrolFileBrowseButton.BackColor = System.Drawing.SystemColors.Control;
            this.patrolFileBrowseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("patrolFileBrowseButton.BackgroundImage")));
            this.patrolFileBrowseButton.ButtonText = "찾기";
            this.patrolFileBrowseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.patrolFileBrowseButton.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patrolFileBrowseButton.ForeColor = System.Drawing.Color.Salmon;
            this.patrolFileBrowseButton.IdleBorderThickness = 1;
            this.patrolFileBrowseButton.IdleCornerRadius = 20;
            this.patrolFileBrowseButton.IdleFillColor = System.Drawing.Color.Transparent;
            this.patrolFileBrowseButton.IdleForecolor = System.Drawing.SystemColors.ControlDarkDark;
            this.patrolFileBrowseButton.IdleLineColor = System.Drawing.SystemColors.ControlDarkDark;
            this.patrolFileBrowseButton.Location = new System.Drawing.Point(582, 72);
            this.patrolFileBrowseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.patrolFileBrowseButton.Name = "patrolFileBrowseButton";
            this.patrolFileBrowseButton.Size = new System.Drawing.Size(39, 30);
            this.patrolFileBrowseButton.TabIndex = 9;
            this.patrolFileBrowseButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RecordDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 257);
            this.Controls.Add(this.patrolFileBrowseButton);
            this.Controls.Add(this.bunifuCustomTextbox2);
            this.Controls.Add(this.bunifuCustomTextbox1);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.caption);
            this.Controls.Add(this.confirmButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecordDialog";
            this.Text = "RecordDialog";
            this.caption.ResumeLayout(false);
            this.caption.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel caption;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuFlatButton cancelButton;
        private Bunifu.Framework.UI.BunifuFlatButton confirmButton;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox bunifuCustomTextbox1;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox bunifuCustomTextbox2;
        private Bunifu.Framework.UI.BunifuThinButton2 patrolFileBrowseButton;
    }
}