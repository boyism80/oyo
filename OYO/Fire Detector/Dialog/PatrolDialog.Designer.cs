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
            this.confirmButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.cancelButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.deleteButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.caption = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.patrolFileListView = new Fire_Detector.Control.PatrolFileListView();
            this.patrolFileListViewItem1 = new Fire_Detector.Control.PatrolFileListViewItem();
            this.patrolFileListViewItem2 = new Fire_Detector.Control.PatrolFileListViewItem();
            this.caption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.patrolFileListView.SuspendLayout();
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
            this.confirmButton.TextFont = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
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
            this.cancelButton.TextFont = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.deleteButton.TextFont = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // caption
            // 
            this.caption.BackColor = System.Drawing.Color.Salmon;
            this.caption.Controls.Add(this.bunifuCustomLabel1);
            this.caption.Dock = System.Windows.Forms.DockStyle.Top;
            this.caption.Font = new System.Drawing.Font("NEXON Football Gothic L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.caption.ForeColor = System.Drawing.Color.White;
            this.caption.Location = new System.Drawing.Point(0, 0);
            this.caption.Name = "caption";
            this.caption.Size = new System.Drawing.Size(720, 28);
            this.caption.TabIndex = 4;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.caption;
            this.bunifuDragControl1.Vertical = true;
            // 
            // patrolFileListView
            // 
            this.patrolFileListView.AutoScroll = true;
            this.patrolFileListView.Controls.Add(this.patrolFileListViewItem1);
            this.patrolFileListView.Controls.Add(this.patrolFileListViewItem2);
            this.patrolFileListView.Items.Add(this.patrolFileListViewItem1);
            this.patrolFileListView.Items.Add(this.patrolFileListViewItem2);
            this.patrolFileListView.Location = new System.Drawing.Point(12, 41);
            this.patrolFileListView.Name = "patrolFileListView";
            this.patrolFileListView.Size = new System.Drawing.Size(696, 384);
            this.patrolFileListView.TabIndex = 5;
            // 
            // patrolFileListViewItem1
            // 
            this.patrolFileListViewItem1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.patrolFileListViewItem1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.patrolFileListViewItem1.Dock = System.Windows.Forms.DockStyle.Top;
            this.patrolFileListViewItem1.Location = new System.Drawing.Point(0, 80);
            this.patrolFileListViewItem1.Name = "patrolFileListViewItem1";
            this.patrolFileListViewItem1.Padding = new System.Windows.Forms.Padding(10, 10, 30, 10);
            this.patrolFileListViewItem1.Selected = false;
            this.patrolFileListViewItem1.Size = new System.Drawing.Size(696, 80);
            this.patrolFileListViewItem1.TabIndex = 0;
            // 
            // patrolFileListViewItem2
            // 
            this.patrolFileListViewItem2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.patrolFileListViewItem2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.patrolFileListViewItem2.Dock = System.Windows.Forms.DockStyle.Top;
            this.patrolFileListViewItem2.Location = new System.Drawing.Point(0, 0);
            this.patrolFileListViewItem2.Name = "patrolFileListViewItem2";
            this.patrolFileListViewItem2.Padding = new System.Windows.Forms.Padding(10, 10, 30, 10);
            this.patrolFileListViewItem2.Selected = false;
            this.patrolFileListViewItem2.Size = new System.Drawing.Size(696, 80);
            this.patrolFileListViewItem2.TabIndex = 0;
            // 
            // PatrolDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 480);
            this.Controls.Add(this.patrolFileListView);
            this.Controls.Add(this.caption);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.confirmButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PatrolDialog";
            this.Text = "PatrolDialog";
            this.caption.ResumeLayout(false);
            this.caption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.patrolFileListView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuFlatButton cancelButton;
        private Bunifu.Framework.UI.BunifuFlatButton confirmButton;
        private Bunifu.Framework.UI.BunifuFlatButton deleteButton;
        private System.Windows.Forms.Panel caption;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Control.PatrolFileListView patrolFileListView;
        private Control.PatrolFileListViewItem patrolFileListViewItem1;
        private Control.PatrolFileListViewItem patrolFileListViewItem2;
    }
}