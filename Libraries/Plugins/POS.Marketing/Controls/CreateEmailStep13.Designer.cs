namespace POS.Marketing.Controls
{
    partial class CreateEmailStep13
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateEmailStep13));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnCopyEmail = new System.Windows.Forms.Button();
            this.btnSaveCampaign = new System.Windows.Forms.Button();
            this.btnSendTestEmail = new System.Windows.Forms.Button();
            this.progressUpload = new System.Windows.Forms.ProgressBar();
            this.lblUploading = new System.Windows.Forms.Label();
            this.btnPreviewWebPage = new System.Windows.Forms.Button();
            this.lblPreviewDescription = new System.Windows.Forms.Label();
            this.lblPreview = new System.Windows.Forms.Label();
            this.lblImageStyle = new System.Windows.Forms.Label();
            this.cmbImageTemplate = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "cmpg";
            this.saveFileDialog1.Filter = "Campaign Files|*.cmpg";
            // 
            // btnCopyEmail
            // 
            this.btnCopyEmail.Location = new System.Drawing.Point(10, 220);
            this.btnCopyEmail.Name = "btnCopyEmail";
            this.btnCopyEmail.Size = new System.Drawing.Size(132, 23);
            this.btnCopyEmail.TabIndex = 4;
            this.btnCopyEmail.Text = "&Copy Email Html";
            this.btnCopyEmail.UseVisualStyleBackColor = true;
            this.btnCopyEmail.Click += new System.EventHandler(this.btnCopyEmail_Click);
            // 
            // btnSaveCampaign
            // 
            this.btnSaveCampaign.Location = new System.Drawing.Point(10, 249);
            this.btnSaveCampaign.Name = "btnSaveCampaign";
            this.btnSaveCampaign.Size = new System.Drawing.Size(132, 23);
            this.btnSaveCampaign.TabIndex = 5;
            this.btnSaveCampaign.Text = "&Save Campaign";
            this.btnSaveCampaign.UseVisualStyleBackColor = true;
            this.btnSaveCampaign.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSendTestEmail
            // 
            this.btnSendTestEmail.Location = new System.Drawing.Point(10, 152);
            this.btnSendTestEmail.Name = "btnSendTestEmail";
            this.btnSendTestEmail.Size = new System.Drawing.Size(132, 23);
            this.btnSendTestEmail.TabIndex = 3;
            this.btnSendTestEmail.Text = "Send &Test Email";
            this.btnSendTestEmail.UseVisualStyleBackColor = true;
            this.btnSendTestEmail.Click += new System.EventHandler(this.btnSendTestEmail_Click);
            // 
            // progressUpload
            // 
            this.progressUpload.Location = new System.Drawing.Point(106, 324);
            this.progressUpload.Name = "progressUpload";
            this.progressUpload.Size = new System.Drawing.Size(444, 23);
            this.progressUpload.TabIndex = 7;
            this.progressUpload.Visible = false;
            // 
            // lblUploading
            // 
            this.lblUploading.AutoSize = true;
            this.lblUploading.Location = new System.Drawing.Point(7, 330);
            this.lblUploading.Name = "lblUploading";
            this.lblUploading.Size = new System.Drawing.Size(55, 13);
            this.lblUploading.TabIndex = 6;
            this.lblUploading.Text = "Uploading";
            this.lblUploading.Visible = false;
            // 
            // btnPreviewWebPage
            // 
            this.btnPreviewWebPage.Location = new System.Drawing.Point(10, 122);
            this.btnPreviewWebPage.Name = "btnPreviewWebPage";
            this.btnPreviewWebPage.Size = new System.Drawing.Size(132, 23);
            this.btnPreviewWebPage.TabIndex = 2;
            this.btnPreviewWebPage.Text = "&Preview Web Page";
            this.btnPreviewWebPage.UseVisualStyleBackColor = true;
            this.btnPreviewWebPage.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lblPreviewDescription
            // 
            this.lblPreviewDescription.AutoSize = true;
            this.lblPreviewDescription.Location = new System.Drawing.Point(7, 106);
            this.lblPreviewDescription.Name = "lblPreviewDescription";
            this.lblPreviewDescription.Size = new System.Drawing.Size(226, 13);
            this.lblPreviewDescription.TabIndex = 1;
            this.lblPreviewDescription.Text = "Click preview, to view the output of your email.";
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblPreview.Location = new System.Drawing.Point(3, 0);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(79, 24);
            this.lblPreview.TabIndex = 0;
            this.lblPreview.Text = "Preview";
            // 
            // lblImageStyle
            // 
            this.lblImageStyle.AutoSize = true;
            this.lblImageStyle.Location = new System.Drawing.Point(7, 43);
            this.lblImageStyle.Name = "lblImageStyle";
            this.lblImageStyle.Size = new System.Drawing.Size(62, 13);
            this.lblImageStyle.TabIndex = 8;
            this.lblImageStyle.Text = "Image Style";
            // 
            // cmbImageTemplate
            // 
            this.cmbImageTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImageTemplate.FormattingEnabled = true;
            this.cmbImageTemplate.Location = new System.Drawing.Point(10, 60);
            this.cmbImageTemplate.Name = "cmbImageTemplate";
            this.cmbImageTemplate.Size = new System.Drawing.Size(146, 21);
            this.cmbImageTemplate.TabIndex = 9;
            this.cmbImageTemplate.SelectedIndexChanged += new System.EventHandler(this.cmbImageTemplate_SelectedIndexChanged);
            // 
            // CreateEmailStep8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbImageTemplate);
            this.Controls.Add(this.lblImageStyle);
            this.Controls.Add(this.btnCopyEmail);
            this.Controls.Add(this.btnSaveCampaign);
            this.Controls.Add(this.btnSendTestEmail);
            this.Controls.Add(this.progressUpload);
            this.Controls.Add(this.lblUploading);
            this.Controls.Add(this.btnPreviewWebPage);
            this.Controls.Add(this.lblPreviewDescription);
            this.Controls.Add(this.lblPreview);
            this.Name = "CreateEmailStep8";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Label lblPreviewDescription;
        private System.Windows.Forms.Button btnPreviewWebPage;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblUploading;
        private System.Windows.Forms.ProgressBar progressUpload;
        private System.Windows.Forms.Button btnSendTestEmail;
        private System.Windows.Forms.Button btnSaveCampaign;
        private System.Windows.Forms.Button btnCopyEmail;
        private System.Windows.Forms.Label lblImageStyle;
        private System.Windows.Forms.ComboBox cmbImageTemplate;
    }
}
