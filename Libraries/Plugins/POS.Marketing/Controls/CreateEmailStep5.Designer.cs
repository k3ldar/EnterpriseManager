namespace POS.Marketing.Controls
{
    partial class CreateEmailStep5
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblHeader = new System.Windows.Forms.Label();
            this.picMainImage = new System.Windows.Forms.PictureBox();
            this.lblHeaderDescription = new System.Windows.Forms.Label();
            this.lblWebLink = new System.Windows.Forms.Label();
            this.txtWebLink = new System.Windows.Forms.TextBox();
            this.btnTestLink = new System.Windows.Forms.Button();
            this.cmbImages = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMainImage)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Image Files|*.jpg;*.png|JPEG Files|*.jpg|PNG Files|*.png";
            this.openFileDialog1.FilterIndex = 0;
            this.openFileDialog1.Title = "Select main image for email";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(6, 2);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(188, 24);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "Primary Email Image";
            // 
            // picMainImage
            // 
            this.picMainImage.Location = new System.Drawing.Point(10, 90);
            this.picMainImage.Name = "picMainImage";
            this.picMainImage.Size = new System.Drawing.Size(553, 216);
            this.picMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMainImage.TabIndex = 5;
            this.picMainImage.TabStop = false;
            // 
            // lblHeaderDescription
            // 
            this.lblHeaderDescription.AutoSize = true;
            this.lblHeaderDescription.Location = new System.Drawing.Point(7, 38);
            this.lblHeaderDescription.Name = "lblHeaderDescription";
            this.lblHeaderDescription.Size = new System.Drawing.Size(366, 13);
            this.lblHeaderDescription.TabIndex = 4;
            this.lblHeaderDescription.Text = "Select Primary Issue to be used within the email, this must be {0} pixels wide.";
            // 
            // lblWebLink
            // 
            this.lblWebLink.AutoSize = true;
            this.lblWebLink.Location = new System.Drawing.Point(10, 324);
            this.lblWebLink.Name = "lblWebLink";
            this.lblWebLink.Size = new System.Drawing.Size(35, 13);
            this.lblWebLink.TabIndex = 7;
            this.lblWebLink.Text = "label1";
            // 
            // txtWebLink
            // 
            this.txtWebLink.Location = new System.Drawing.Point(84, 321);
            this.txtWebLink.Name = "txtWebLink";
            this.txtWebLink.Size = new System.Drawing.Size(363, 20);
            this.txtWebLink.TabIndex = 8;
            // 
            // btnTestLink
            // 
            this.btnTestLink.Location = new System.Drawing.Point(453, 319);
            this.btnTestLink.Name = "btnTestLink";
            this.btnTestLink.Size = new System.Drawing.Size(110, 23);
            this.btnTestLink.TabIndex = 9;
            this.btnTestLink.Text = "Test Link";
            this.btnTestLink.UseVisualStyleBackColor = true;
            this.btnTestLink.Click += new System.EventHandler(this.btnTestLink_Click);
            // 
            // cmbImages
            // 
            this.cmbImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImages.FormattingEnabled = true;
            this.cmbImages.Location = new System.Drawing.Point(10, 61);
            this.cmbImages.Name = "cmbImages";
            this.cmbImages.Size = new System.Drawing.Size(553, 21);
            this.cmbImages.TabIndex = 10;
            this.cmbImages.SelectedIndexChanged += new System.EventHandler(this.cmbImages_SelectedIndexChanged);
            this.cmbImages.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbImages_Format);
            // 
            // CreateEmailStep4B
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbImages);
            this.Controls.Add(this.btnTestLink);
            this.Controls.Add(this.txtWebLink);
            this.Controls.Add(this.lblWebLink);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.picMainImage);
            this.Controls.Add(this.lblHeaderDescription);
            this.Name = "CreateEmailStep4B";
            ((System.ComponentModel.ISupportInitialize)(this.picMainImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.PictureBox picMainImage;
        private System.Windows.Forms.Label lblHeaderDescription;
        private System.Windows.Forms.Label lblWebLink;
        private System.Windows.Forms.TextBox txtWebLink;
        private System.Windows.Forms.Button btnTestLink;
        private System.Windows.Forms.ComboBox cmbImages;
    }
}
