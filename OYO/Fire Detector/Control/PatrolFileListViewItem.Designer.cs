namespace Fire_Detector.Control
{
    partial class PatrolFileListViewItem
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
            this.fileSizeTextBox = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.durationTextBox = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dateTimeTextBox = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.fileNameTextBox = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.SuspendLayout();
            // 
            // bunifuCustomLabel4
            // 
            this.fileSizeTextBox.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.fileSizeTextBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fileSizeTextBox.Location = new System.Drawing.Point(382, 54);
            this.fileSizeTextBox.Name = "bunifuCustomLabel4";
            this.fileSizeTextBox.Size = new System.Drawing.Size(300, 16);
            this.fileSizeTextBox.TabIndex = 0;
            this.fileSizeTextBox.Text = "1023MB";
            this.fileSizeTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bunifuCustomLabel2
            // 
            this.durationTextBox.AutoSize = true;
            this.durationTextBox.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.durationTextBox.Location = new System.Drawing.Point(15, 54);
            this.durationTextBox.Name = "bunifuCustomLabel2";
            this.durationTextBox.Size = new System.Drawing.Size(62, 16);
            this.durationTextBox.TabIndex = 0;
            this.durationTextBox.Text = "00:00:00";
            // 
            // bunifuCustomLabel3
            // 
            this.dateTimeTextBox.Font = new System.Drawing.Font("NEXON Football Gothic L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimeTextBox.ForeColor = System.Drawing.Color.Tomato;
            this.dateTimeTextBox.Location = new System.Drawing.Point(382, 10);
            this.dateTimeTextBox.Name = "bunifuCustomLabel3";
            this.dateTimeTextBox.Size = new System.Drawing.Size(300, 16);
            this.dateTimeTextBox.TabIndex = 0;
            this.dateTimeTextBox.Text = "2018-3-14";
            this.dateTimeTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bunifuCustomLabel1
            // 
            this.fileNameTextBox.AutoSize = true;
            this.fileNameTextBox.Font = new System.Drawing.Font("NEXON Football Gothic B", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.fileNameTextBox.ForeColor = System.Drawing.Color.Tomato;
            this.fileNameTextBox.Location = new System.Drawing.Point(13, 10);
            this.fileNameTextBox.Name = "bunifuCustomLabel1";
            this.fileNameTextBox.Size = new System.Drawing.Size(91, 27);
            this.fileNameTextBox.TabIndex = 0;
            this.fileNameTextBox.Text = "파일001";
            // 
            // PatrolFileListViewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.fileSizeTextBox);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.durationTextBox);
            this.Controls.Add(this.dateTimeTextBox);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "PatrolFileListViewItem";
            this.Padding = new System.Windows.Forms.Padding(10, 10, 30, 10);
            this.Size = new System.Drawing.Size(696, 80);
            this.Click += new System.EventHandler(this.PatrolFileListViewItem_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuCustomLabel fileNameTextBox;
        private Bunifu.Framework.UI.BunifuCustomLabel fileSizeTextBox;
        private Bunifu.Framework.UI.BunifuCustomLabel durationTextBox;
        private Bunifu.Framework.UI.BunifuCustomLabel dateTimeTextBox;
    }
}
