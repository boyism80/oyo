﻿namespace Fire_Detector.Dialog
{
    partial class MessageDialog
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
            this.caption = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.confirmButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.messageLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.caption.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
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
            this.caption.Size = new System.Drawing.Size(364, 28);
            this.caption.TabIndex = 6;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(10, 5);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(32, 16);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "알림";
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
            this.confirmButton.Location = new System.Drawing.Point(143, 132);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Normalcolor = System.Drawing.Color.LightCoral;
            this.confirmButton.OnHovercolor = System.Drawing.Color.Tomato;
            this.confirmButton.OnHoverTextColor = System.Drawing.Color.White;
            this.confirmButton.selected = false;
            this.confirmButton.Size = new System.Drawing.Size(80, 29);
            this.confirmButton.TabIndex = 5;
            this.confirmButton.Text = "확인";
            this.confirmButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.confirmButton.Textcolor = System.Drawing.Color.White;
            this.confirmButton.TextFont = new System.Drawing.Font("넥슨 풋볼고딕 L", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.messageLabel.Font = new System.Drawing.Font("넥슨 풋볼고딕 L", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.messageLabel.Location = new System.Drawing.Point(0, 28);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(364, 101);
            this.messageLabel.TabIndex = 7;
            this.messageLabel.Text = "알림텍스트";
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.caption;
            this.bunifuDragControl1.Vertical = true;
            // 
            // MessageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 168);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.caption);
            this.Controls.Add(this.confirmButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageDialog";
            this.Text = "MessageDialog";
            this.caption.ResumeLayout(false);
            this.caption.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuCustomLabel messageLabel;
        private System.Windows.Forms.Panel caption;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuFlatButton confirmButton;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
    }
}