namespace POS.WebsiteAdministration.Controls.WebSettings
{
    partial class HomeBanner
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
            this.lblLink = new System.Windows.Forms.Label();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.cmbImage = new System.Windows.Forms.ComboBox();
            this.picBanner = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Location = new System.Drawing.Point(10, 4);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(35, 13);
            this.lblLink.TabIndex = 0;
            this.lblLink.Text = "label1";
            // 
            // txtLink
            // 
            this.txtLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLink.Location = new System.Drawing.Point(10, 21);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(690, 20);
            this.txtLink.TabIndex = 1;
            this.txtLink.TextChanged += new System.EventHandler(this.txtLink_TextChanged);
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(10, 57);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(35, 13);
            this.lblImage.TabIndex = 2;
            this.lblImage.Text = "label2";
            // 
            // cmbImage
            // 
            this.cmbImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImage.FormattingEnabled = true;
            this.cmbImage.Location = new System.Drawing.Point(10, 74);
            this.cmbImage.Name = "cmbImage";
            this.cmbImage.Size = new System.Drawing.Size(690, 21);
            this.cmbImage.TabIndex = 3;
            this.cmbImage.SelectedIndexChanged += new System.EventHandler(this.cmbImage_SelectedIndexChanged);
            this.cmbImage.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbImage_Format);
            // 
            // picBanner
            // 
            this.picBanner.Location = new System.Drawing.Point(10, 125);
            this.picBanner.Name = "picBanner";
            this.picBanner.Size = new System.Drawing.Size(100, 50);
            this.picBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBanner.TabIndex = 4;
            this.picBanner.TabStop = false;
            // 
            // HomeBanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.picBanner);
            this.Controls.Add(this.cmbImage);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.lblLink);
            this.Name = "HomeBanner";
            this.Size = new System.Drawing.Size(711, 296);
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLink;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.ComboBox cmbImage;
        private System.Windows.Forms.PictureBox picBanner;
    }
}
