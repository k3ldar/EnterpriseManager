namespace POS.Marketing.Controls
{
    partial class CreateEmailStep10
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateEmailStep10));
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblURL = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.gbImage = new System.Windows.Forms.GroupBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.lblImageWidth = new System.Windows.Forms.Label();
            this.btnImageSelect = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gbImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(4, 4);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(213, 24);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Additional Product - {0}";
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(8, 43);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(29, 13);
            this.lblURL.TabIndex = 1;
            this.lblURL.Text = "URL";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(11, 60);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(552, 20);
            this.txtURL.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(11, 87);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(11, 104);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(222, 20);
            this.txtTitle.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(14, 131);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(11, 148);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(222, 205);
            this.txtDescription.TabIndex = 6;
            // 
            // gbImage
            // 
            this.gbImage.Controls.Add(this.picPreview);
            this.gbImage.Controls.Add(this.lblImageWidth);
            this.gbImage.Controls.Add(this.btnImageSelect);
            this.gbImage.Location = new System.Drawing.Point(261, 87);
            this.gbImage.Name = "gbImage";
            this.gbImage.Size = new System.Drawing.Size(302, 266);
            this.gbImage.TabIndex = 7;
            this.gbImage.TabStop = false;
            this.gbImage.Text = "Image";
            // 
            // picPreview
            // 
            this.picPreview.Location = new System.Drawing.Point(6, 49);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(290, 211);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPreview.TabIndex = 2;
            this.picPreview.TabStop = false;
            // 
            // lblImageWidth
            // 
            this.lblImageWidth.AutoSize = true;
            this.lblImageWidth.Location = new System.Drawing.Point(88, 23);
            this.lblImageWidth.Name = "lblImageWidth";
            this.lblImageWidth.Size = new System.Drawing.Size(147, 13);
            this.lblImageWidth.TabIndex = 1;
            this.lblImageWidth.Text = "Image must be {0} pixels wide";
            // 
            // btnImageSelect
            // 
            this.btnImageSelect.Location = new System.Drawing.Point(6, 19);
            this.btnImageSelect.Name = "btnImageSelect";
            this.btnImageSelect.Size = new System.Drawing.Size(75, 23);
            this.btnImageSelect.TabIndex = 0;
            this.btnImageSelect.Text = "Select";
            this.btnImageSelect.UseVisualStyleBackColor = true;
            this.btnImageSelect.Click += new System.EventHandler(this.btnImageSelect_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Image Files|*.jpg;*.png|JPEG Files|*.jpg|PNG Files|*.png";
            this.openFileDialog1.FilterIndex = 0;
            // 
            // CreateEmailStep5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbImage);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.lblHeader);
            this.Name = "CreateEmailStep5";
            this.gbImage.ResumeLayout(false);
            this.gbImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox gbImage;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Label lblImageWidth;
        private System.Windows.Forms.Button btnImageSelect;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
