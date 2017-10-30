namespace POS.Marketing.Controls
{
    partial class MailChimpSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailChimpSettings));
            this.lblAPIKey = new System.Windows.Forms.Label();
            this.txtMailChimpAPIKey = new System.Windows.Forms.TextBox();
            this.gbDefaultOptions = new System.Windows.Forms.GroupBox();
            this.cbGoogleAnalytics = new System.Windows.Forms.CheckBox();
            this.cbPostToFaceBook = new System.Windows.Forms.CheckBox();
            this.cbAddFooter = new System.Windows.Forms.CheckBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.gbDefaultOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAPIKey
            // 
            this.lblAPIKey.AutoSize = true;
            this.lblAPIKey.Location = new System.Drawing.Point(4, 4);
            this.lblAPIKey.Name = "lblAPIKey";
            this.lblAPIKey.Size = new System.Drawing.Size(96, 13);
            this.lblAPIKey.TabIndex = 0;
            this.lblAPIKey.Text = "MailChimp API Key";
            // 
            // txtMailChimpAPIKey
            // 
            this.txtMailChimpAPIKey.Location = new System.Drawing.Point(7, 21);
            this.txtMailChimpAPIKey.MaxLength = 150;
            this.txtMailChimpAPIKey.Name = "txtMailChimpAPIKey";
            this.txtMailChimpAPIKey.Size = new System.Drawing.Size(349, 20);
            this.txtMailChimpAPIKey.TabIndex = 1;
            // 
            // gbDefaultOptions
            // 
            this.gbDefaultOptions.Controls.Add(this.cbGoogleAnalytics);
            this.gbDefaultOptions.Controls.Add(this.cbPostToFaceBook);
            this.gbDefaultOptions.Controls.Add(this.cbAddFooter);
            this.gbDefaultOptions.Location = new System.Drawing.Point(7, 56);
            this.gbDefaultOptions.Name = "gbDefaultOptions";
            this.gbDefaultOptions.Size = new System.Drawing.Size(450, 100);
            this.gbDefaultOptions.TabIndex = 3;
            this.gbDefaultOptions.TabStop = false;
            this.gbDefaultOptions.Text = "Options";
            // 
            // cbGoogleAnalytics
            // 
            this.cbGoogleAnalytics.AutoSize = true;
            this.cbGoogleAnalytics.Enabled = false;
            this.cbGoogleAnalytics.Location = new System.Drawing.Point(7, 67);
            this.cbGoogleAnalytics.Name = "cbGoogleAnalytics";
            this.cbGoogleAnalytics.Size = new System.Drawing.Size(105, 17);
            this.cbGoogleAnalytics.TabIndex = 2;
            this.cbGoogleAnalytics.Text = "Google Analytics";
            this.cbGoogleAnalytics.UseVisualStyleBackColor = true;
            // 
            // cbPostToFaceBook
            // 
            this.cbPostToFaceBook.AutoSize = true;
            this.cbPostToFaceBook.Enabled = false;
            this.cbPostToFaceBook.Location = new System.Drawing.Point(6, 43);
            this.cbPostToFaceBook.Name = "cbPostToFaceBook";
            this.cbPostToFaceBook.Size = new System.Drawing.Size(110, 17);
            this.cbPostToFaceBook.TabIndex = 1;
            this.cbPostToFaceBook.Text = "Post to Facebook";
            this.cbPostToFaceBook.UseVisualStyleBackColor = true;
            // 
            // cbAddFooter
            // 
            this.cbAddFooter.AutoSize = true;
            this.cbAddFooter.Location = new System.Drawing.Point(6, 19);
            this.cbAddFooter.Name = "cbAddFooter";
            this.cbAddFooter.Size = new System.Drawing.Size(78, 17);
            this.cbAddFooter.TabIndex = 0;
            this.cbAddFooter.Text = "Add Footer";
            this.cbAddFooter.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(363, 21);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(94, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // MailChimpSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.gbDefaultOptions);
            this.Controls.Add(this.txtMailChimpAPIKey);
            this.Controls.Add(this.lblAPIKey);
            this.Name = "MailChimpSettings";
            this.gbDefaultOptions.ResumeLayout(false);
            this.gbDefaultOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAPIKey;
        private System.Windows.Forms.TextBox txtMailChimpAPIKey;
        private System.Windows.Forms.GroupBox gbDefaultOptions;
        private System.Windows.Forms.CheckBox cbAddFooter;
        private System.Windows.Forms.CheckBox cbPostToFaceBook;
        private System.Windows.Forms.CheckBox cbGoogleAnalytics;
        private System.Windows.Forms.Button btnTest;
    }
}
