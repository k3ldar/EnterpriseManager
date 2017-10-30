namespace PointOfSale.Controls.InitialSetupWizard
{
    partial class Step1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Step1));
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblSelectLanguage = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.lblDefaultCurrency = new System.Windows.Forms.Label();
            this.cmbDefaultCountry = new System.Windows.Forms.ComboBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblHelp = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(3, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(89, 24);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Welcome";
            // 
            // lblSelectLanguage
            // 
            this.lblSelectLanguage.AutoSize = true;
            this.lblSelectLanguage.Location = new System.Drawing.Point(7, 172);
            this.lblSelectLanguage.Name = "lblSelectLanguage";
            this.lblSelectLanguage.Size = new System.Drawing.Size(35, 13);
            this.lblSelectLanguage.TabIndex = 3;
            this.lblSelectLanguage.Text = "label1";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(7, 189);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(207, 21);
            this.cmbLanguage.TabIndex = 4;
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            this.cmbLanguage.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbLanguage_Format);
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(7, 121);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(207, 21);
            this.cmbCurrency.TabIndex = 6;
            this.cmbCurrency.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbCurrency_Format);
            // 
            // lblDefaultCurrency
            // 
            this.lblDefaultCurrency.AutoSize = true;
            this.lblDefaultCurrency.Location = new System.Drawing.Point(7, 104);
            this.lblDefaultCurrency.Name = "lblDefaultCurrency";
            this.lblDefaultCurrency.Size = new System.Drawing.Size(86, 13);
            this.lblDefaultCurrency.TabIndex = 5;
            this.lblDefaultCurrency.Text = "Default Currency";
            // 
            // cmbDefaultCountry
            // 
            this.cmbDefaultCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefaultCountry.FormattingEnabled = true;
            this.cmbDefaultCountry.Location = new System.Drawing.Point(7, 61);
            this.cmbDefaultCountry.Name = "cmbDefaultCountry";
            this.cmbDefaultCountry.Size = new System.Drawing.Size(207, 21);
            this.cmbDefaultCountry.TabIndex = 2;
            this.cmbDefaultCountry.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbDefaultCountry_Format);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(7, 44);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(35, 13);
            this.lblCountry.TabIndex = 1;
            this.lblCountry.Text = "label1";
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Location = new System.Drawing.Point(55, 275);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(35, 13);
            this.lblHelp.TabIndex = 7;
            this.lblHelp.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 266);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.cmbDefaultCountry);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.cmbCurrency);
            this.Controls.Add(this.lblDefaultCurrency);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.lblSelectLanguage);
            this.Controls.Add(this.lblHeader);
            this.Name = "Step1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblSelectLanguage;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label lblDefaultCurrency;
        private System.Windows.Forms.ComboBox cmbDefaultCountry;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
