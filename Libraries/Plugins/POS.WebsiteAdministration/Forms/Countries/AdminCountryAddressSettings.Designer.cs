namespace POS.WebsiteAdministration.Forms.CountryAdmin
{
    partial class AdminCountryAddressSettings
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cbBusinessNameShow = new System.Windows.Forms.CheckBox();
            this.cbBusinessNameMandatory = new System.Windows.Forms.CheckBox();
            this.cbAddress1Show = new System.Windows.Forms.CheckBox();
            this.cbAddress1Mandatory = new System.Windows.Forms.CheckBox();
            this.cbAddress2Mandatory = new System.Windows.Forms.CheckBox();
            this.cbAddress2Show = new System.Windows.Forms.CheckBox();
            this.cbAddress3Mandatory = new System.Windows.Forms.CheckBox();
            this.cbAddress3Show = new System.Windows.Forms.CheckBox();
            this.cbCityMandatory = new System.Windows.Forms.CheckBox();
            this.cbCityShow = new System.Windows.Forms.CheckBox();
            this.cbCountyMandatory = new System.Windows.Forms.CheckBox();
            this.cbCountyShow = new System.Windows.Forms.CheckBox();
            this.cbPostcodeMandatory = new System.Windows.Forms.CheckBox();
            this.cbPostcodeShow = new System.Windows.Forms.CheckBox();
            this.cbTelephoneShow = new System.Windows.Forms.CheckBox();
            this.cbTelephoneMandatory = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(409, 233);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(328, 233);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(13, 13);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(401, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Decide which address fields should be shown and wether they are mandatory or not";
            // 
            // cbBusinessNameShow
            // 
            this.cbBusinessNameShow.AutoSize = true;
            this.cbBusinessNameShow.Location = new System.Drawing.Point(16, 64);
            this.cbBusinessNameShow.Name = "cbBusinessNameShow";
            this.cbBusinessNameShow.Size = new System.Drawing.Size(129, 17);
            this.cbBusinessNameShow.TabIndex = 3;
            this.cbBusinessNameShow.Text = "Show Business Name";
            this.cbBusinessNameShow.UseVisualStyleBackColor = true;
            this.cbBusinessNameShow.CheckedChanged += new System.EventHandler(this.ShowCheckBoxChecked);
            // 
            // cbBusinessNameMandatory
            // 
            this.cbBusinessNameMandatory.AutoSize = true;
            this.cbBusinessNameMandatory.Location = new System.Drawing.Point(239, 64);
            this.cbBusinessNameMandatory.Name = "cbBusinessNameMandatory";
            this.cbBusinessNameMandatory.Size = new System.Drawing.Size(162, 17);
            this.cbBusinessNameMandatory.TabIndex = 4;
            this.cbBusinessNameMandatory.Text = "Business Name is Mandatory";
            this.cbBusinessNameMandatory.UseVisualStyleBackColor = true;
            // 
            // cbAddress1Show
            // 
            this.cbAddress1Show.AutoSize = true;
            this.cbAddress1Show.Location = new System.Drawing.Point(16, 88);
            this.cbAddress1Show.Name = "cbAddress1Show";
            this.cbAddress1Show.Size = new System.Drawing.Size(126, 17);
            this.cbAddress1Show.TabIndex = 5;
            this.cbAddress1Show.Text = "Show Address Line 1";
            this.cbAddress1Show.UseVisualStyleBackColor = true;
            this.cbAddress1Show.CheckedChanged += new System.EventHandler(this.ShowCheckBoxChecked);
            // 
            // cbAddress1Mandatory
            // 
            this.cbAddress1Mandatory.AutoSize = true;
            this.cbAddress1Mandatory.Location = new System.Drawing.Point(239, 88);
            this.cbAddress1Mandatory.Name = "cbAddress1Mandatory";
            this.cbAddress1Mandatory.Size = new System.Drawing.Size(159, 17);
            this.cbAddress1Mandatory.TabIndex = 6;
            this.cbAddress1Mandatory.Text = "Address Line 1 is Mandatory";
            this.cbAddress1Mandatory.UseVisualStyleBackColor = true;
            // 
            // cbAddress2Mandatory
            // 
            this.cbAddress2Mandatory.AutoSize = true;
            this.cbAddress2Mandatory.Location = new System.Drawing.Point(239, 111);
            this.cbAddress2Mandatory.Name = "cbAddress2Mandatory";
            this.cbAddress2Mandatory.Size = new System.Drawing.Size(159, 17);
            this.cbAddress2Mandatory.TabIndex = 8;
            this.cbAddress2Mandatory.Text = "Address Line 2 is Mandatory";
            this.cbAddress2Mandatory.UseVisualStyleBackColor = true;
            // 
            // cbAddress2Show
            // 
            this.cbAddress2Show.AutoSize = true;
            this.cbAddress2Show.Location = new System.Drawing.Point(16, 111);
            this.cbAddress2Show.Name = "cbAddress2Show";
            this.cbAddress2Show.Size = new System.Drawing.Size(126, 17);
            this.cbAddress2Show.TabIndex = 7;
            this.cbAddress2Show.Text = "Show Address Line 2";
            this.cbAddress2Show.UseVisualStyleBackColor = true;
            this.cbAddress2Show.CheckedChanged += new System.EventHandler(this.ShowCheckBoxChecked);
            // 
            // cbAddress3Mandatory
            // 
            this.cbAddress3Mandatory.AutoSize = true;
            this.cbAddress3Mandatory.Location = new System.Drawing.Point(239, 134);
            this.cbAddress3Mandatory.Name = "cbAddress3Mandatory";
            this.cbAddress3Mandatory.Size = new System.Drawing.Size(159, 17);
            this.cbAddress3Mandatory.TabIndex = 10;
            this.cbAddress3Mandatory.Text = "Address Line 3 is Mandatory";
            this.cbAddress3Mandatory.UseVisualStyleBackColor = true;
            // 
            // cbAddress3Show
            // 
            this.cbAddress3Show.AutoSize = true;
            this.cbAddress3Show.Location = new System.Drawing.Point(16, 134);
            this.cbAddress3Show.Name = "cbAddress3Show";
            this.cbAddress3Show.Size = new System.Drawing.Size(126, 17);
            this.cbAddress3Show.TabIndex = 9;
            this.cbAddress3Show.Text = "Show Address Line 3";
            this.cbAddress3Show.UseVisualStyleBackColor = true;
            this.cbAddress3Show.CheckedChanged += new System.EventHandler(this.ShowCheckBoxChecked);
            // 
            // cbCityMandatory
            // 
            this.cbCityMandatory.AutoSize = true;
            this.cbCityMandatory.Location = new System.Drawing.Point(239, 157);
            this.cbCityMandatory.Name = "cbCityMandatory";
            this.cbCityMandatory.Size = new System.Drawing.Size(106, 17);
            this.cbCityMandatory.TabIndex = 12;
            this.cbCityMandatory.Text = "City is Mandatory";
            this.cbCityMandatory.UseVisualStyleBackColor = true;
            // 
            // cbCityShow
            // 
            this.cbCityShow.AutoSize = true;
            this.cbCityShow.Location = new System.Drawing.Point(16, 157);
            this.cbCityShow.Name = "cbCityShow";
            this.cbCityShow.Size = new System.Drawing.Size(73, 17);
            this.cbCityShow.TabIndex = 11;
            this.cbCityShow.Text = "Show City";
            this.cbCityShow.UseVisualStyleBackColor = true;
            this.cbCityShow.CheckedChanged += new System.EventHandler(this.ShowCheckBoxChecked);
            // 
            // cbCountyMandatory
            // 
            this.cbCountyMandatory.AutoSize = true;
            this.cbCountyMandatory.Location = new System.Drawing.Point(239, 180);
            this.cbCountyMandatory.Name = "cbCountyMandatory";
            this.cbCountyMandatory.Size = new System.Drawing.Size(122, 17);
            this.cbCountyMandatory.TabIndex = 14;
            this.cbCountyMandatory.Text = "County is Mandatory";
            this.cbCountyMandatory.UseVisualStyleBackColor = true;
            // 
            // cbCountyShow
            // 
            this.cbCountyShow.AutoSize = true;
            this.cbCountyShow.Location = new System.Drawing.Point(16, 180);
            this.cbCountyShow.Name = "cbCountyShow";
            this.cbCountyShow.Size = new System.Drawing.Size(89, 17);
            this.cbCountyShow.TabIndex = 13;
            this.cbCountyShow.Text = "Show County";
            this.cbCountyShow.UseVisualStyleBackColor = true;
            this.cbCountyShow.CheckedChanged += new System.EventHandler(this.ShowCheckBoxChecked);
            // 
            // cbPostcodeMandatory
            // 
            this.cbPostcodeMandatory.AutoSize = true;
            this.cbPostcodeMandatory.Location = new System.Drawing.Point(239, 203);
            this.cbPostcodeMandatory.Name = "cbPostcodeMandatory";
            this.cbPostcodeMandatory.Size = new System.Drawing.Size(134, 17);
            this.cbPostcodeMandatory.TabIndex = 16;
            this.cbPostcodeMandatory.Text = "Postcode is Mandatory";
            this.cbPostcodeMandatory.UseVisualStyleBackColor = true;
            // 
            // cbPostcodeShow
            // 
            this.cbPostcodeShow.AutoSize = true;
            this.cbPostcodeShow.Location = new System.Drawing.Point(16, 203);
            this.cbPostcodeShow.Name = "cbPostcodeShow";
            this.cbPostcodeShow.Size = new System.Drawing.Size(101, 17);
            this.cbPostcodeShow.TabIndex = 15;
            this.cbPostcodeShow.Text = "Show Postcode";
            this.cbPostcodeShow.UseVisualStyleBackColor = true;
            this.cbPostcodeShow.CheckedChanged += new System.EventHandler(this.ShowCheckBoxChecked);
            // 
            // cbTelephoneShow
            // 
            this.cbTelephoneShow.AutoSize = true;
            this.cbTelephoneShow.Location = new System.Drawing.Point(16, 41);
            this.cbTelephoneShow.Name = "cbTelephoneShow";
            this.cbTelephoneShow.Size = new System.Drawing.Size(107, 17);
            this.cbTelephoneShow.TabIndex = 1;
            this.cbTelephoneShow.Text = "Show Telephone";
            this.cbTelephoneShow.UseVisualStyleBackColor = true;
            this.cbTelephoneShow.CheckedChanged += new System.EventHandler(this.ShowCheckBoxChecked);
            // 
            // cbTelephoneMandatory
            // 
            this.cbTelephoneMandatory.AutoSize = true;
            this.cbTelephoneMandatory.Location = new System.Drawing.Point(239, 41);
            this.cbTelephoneMandatory.Name = "cbTelephoneMandatory";
            this.cbTelephoneMandatory.Size = new System.Drawing.Size(130, 17);
            this.cbTelephoneMandatory.TabIndex = 2;
            this.cbTelephoneMandatory.Text = "Telephone Mandatory";
            this.cbTelephoneMandatory.UseVisualStyleBackColor = true;
            // 
            // AdminCountryAddressSettings
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(496, 268);
            this.Controls.Add(this.cbTelephoneMandatory);
            this.Controls.Add(this.cbTelephoneShow);
            this.Controls.Add(this.cbPostcodeMandatory);
            this.Controls.Add(this.cbPostcodeShow);
            this.Controls.Add(this.cbCountyMandatory);
            this.Controls.Add(this.cbCountyShow);
            this.Controls.Add(this.cbCityMandatory);
            this.Controls.Add(this.cbCityShow);
            this.Controls.Add(this.cbAddress3Mandatory);
            this.Controls.Add(this.cbAddress3Show);
            this.Controls.Add(this.cbAddress2Mandatory);
            this.Controls.Add(this.cbAddress2Show);
            this.Controls.Add(this.cbAddress1Mandatory);
            this.Controls.Add(this.cbAddress1Show);
            this.Controls.Add(this.cbBusinessNameMandatory);
            this.Controls.Add(this.cbBusinessNameShow);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminCountryAddressSettings";
            this.SaveState = true;
            this.Text = "Country Address Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CheckBox cbBusinessNameShow;
        private System.Windows.Forms.CheckBox cbBusinessNameMandatory;
        private System.Windows.Forms.CheckBox cbAddress1Show;
        private System.Windows.Forms.CheckBox cbAddress1Mandatory;
        private System.Windows.Forms.CheckBox cbAddress2Mandatory;
        private System.Windows.Forms.CheckBox cbAddress2Show;
        private System.Windows.Forms.CheckBox cbAddress3Mandatory;
        private System.Windows.Forms.CheckBox cbAddress3Show;
        private System.Windows.Forms.CheckBox cbCityMandatory;
        private System.Windows.Forms.CheckBox cbCityShow;
        private System.Windows.Forms.CheckBox cbCountyMandatory;
        private System.Windows.Forms.CheckBox cbCountyShow;
        private System.Windows.Forms.CheckBox cbPostcodeMandatory;
        private System.Windows.Forms.CheckBox cbPostcodeShow;
        private System.Windows.Forms.CheckBox cbTelephoneShow;
        private System.Windows.Forms.CheckBox cbTelephoneMandatory;
    }
}