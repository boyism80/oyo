namespace Fire_Detector.Dialog
{
    partial class PatrolDialog
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
            this.components = new System.ComponentModel.Container();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.patrolFileListView = new System.Windows.Forms.ListView();
            this.fileNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileCapacity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.confirmButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.cancelButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.deleteButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.caption = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel1.SuspendLayout();
            this.caption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 5;
            this.bunifuElipse2.TargetControl = this;
            // 
            // patrolFileListView
            // 
            this.patrolFileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileNumber,
            this.fileName,
            this.fileCapacity});
            this.patrolFileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patrolFileListView.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.patrolFileListView.Location = new System.Drawing.Point(0, 0);
            this.patrolFileListView.Name = "patrolFileListView";
            this.patrolFileListView.Size = new System.Drawing.Size(696, 385);
            this.patrolFileListView.TabIndex = 0;
            this.patrolFileListView.UseCompatibleStateImageBehavior = false;
            this.patrolFileListView.View = System.Windows.Forms.View.Details;
            // 
            // fileNumber
            // 
            this.fileNumber.Text = "번호";
            this.fileNumber.Width = 40;
            // 
            // fileName
            // 
            this.fileName.Text = "이름";
            this.fileName.Width = 500;
            // 
            // fileCapacity
            // 
            this.fileCapacity.Text = "용량";
            this.fileCapacity.Width = 204;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.patrolFileListView);
            this.panel1.Location = new System.Drawing.Point(12, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(696, 385);
            this.panel1.TabIndex = 2;
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
            this.confirmButton.Location = new System.Drawing.Point(542, 443);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Normalcolor = System.Drawing.Color.LightCoral;
            this.confirmButton.OnHovercolor = System.Drawing.Color.Tomato;
            this.confirmButton.OnHoverTextColor = System.Drawing.Color.White;
            this.confirmButton.selected = false;
            this.confirmButton.Size = new System.Drawing.Size(80, 29);
            this.confirmButton.TabIndex = 3;
            this.confirmButton.Text = "확인";
            this.confirmButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.confirmButton.Textcolor = System.Drawing.Color.White;
            this.confirmButton.TextFont = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cancelButton.Location = new System.Drawing.Point(628, 443);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Normalcolor = System.Drawing.Color.LightCoral;
            this.cancelButton.OnHovercolor = System.Drawing.Color.Tomato;
            this.cancelButton.OnHoverTextColor = System.Drawing.Color.White;
            this.cancelButton.selected = false;
            this.cancelButton.Size = new System.Drawing.Size(80, 29);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "취소";
            this.cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cancelButton.Textcolor = System.Drawing.Color.White;
            this.cancelButton.TextFont = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.deleteButton.BackColor = System.Drawing.Color.LightCoral;
            this.deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteButton.BorderRadius = 0;
            this.deleteButton.ButtonText = "삭제";
            this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteButton.DisabledColor = System.Drawing.Color.Gray;
            this.deleteButton.Iconcolor = System.Drawing.Color.Transparent;
            this.deleteButton.Iconimage = null;
            this.deleteButton.Iconimage_right = null;
            this.deleteButton.Iconimage_right_Selected = null;
            this.deleteButton.Iconimage_Selected = null;
            this.deleteButton.IconMarginLeft = 0;
            this.deleteButton.IconMarginRight = 0;
            this.deleteButton.IconRightVisible = true;
            this.deleteButton.IconRightZoom = 0D;
            this.deleteButton.IconVisible = true;
            this.deleteButton.IconZoom = 90D;
            this.deleteButton.IsTab = false;
            this.deleteButton.Location = new System.Drawing.Point(12, 443);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Normalcolor = System.Drawing.Color.LightCoral;
            this.deleteButton.OnHovercolor = System.Drawing.Color.Tomato;
            this.deleteButton.OnHoverTextColor = System.Drawing.Color.White;
            this.deleteButton.selected = false;
            this.deleteButton.Size = new System.Drawing.Size(80, 29);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "삭제";
            this.deleteButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deleteButton.Textcolor = System.Drawing.Color.White;
            this.deleteButton.TextFont = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.caption.Size = new System.Drawing.Size(720, 28);
            this.caption.TabIndex = 4;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(10, 5);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(89, 16);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "순찰 파일 찾기";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // PatrolDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 480);
            this.Controls.Add(this.caption);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PatrolDialog";
            this.Text = "PatrolDialog";
            this.panel1.ResumeLayout(false);
            this.caption.ResumeLayout(false);
            this.caption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.ColumnHeader fileNumber;
        private System.Windows.Forms.ColumnHeader fileName;
        private System.Windows.Forms.ColumnHeader fileCapacity;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuFlatButton cancelButton;
        private Bunifu.Framework.UI.BunifuFlatButton confirmButton;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuFlatButton deleteButton;
        private System.Windows.Forms.Panel caption;
        public System.Windows.Forms.ListView patrolFileListView;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}