namespace POS.Marketing.Controls
{
    partial class CreateEmailIntro
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblHeaderDescription = new System.Windows.Forms.Label();
            this.lblWebsiteURL = new System.Windows.Forms.Label();
            this.lblCampaignName = new System.Windows.Forms.Label();
            this.txtCampaignName = new System.Windows.Forms.TextBox();
            this.btnLoadSavedCampaign = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmbWebsites = new System.Windows.Forms.ComboBox();
            this.lblTrackingCode = new System.Windows.Forms.Label();
            this.txtTrackingCode = new SharedControls.TextBoxEx();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(9, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(214, 24);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Create Marketing Email";
            // 
            // lblHeaderDescription
            // 
            this.lblHeaderDescription.AutoSize = true;
            this.lblHeaderDescription.Location = new System.Drawing.Point(9, 28);
            this.lblHeaderDescription.Name = "lblHeaderDescription";
            this.lblHeaderDescription.Size = new System.Drawing.Size(473, 26);
            this.lblHeaderDescription.TabIndex = 1;
            this.lblHeaderDescription.Text = "You can create an email campaign from here, attach the email to an existing campa" +
    "ign or create an\r\nemail which follows corporate branding\r\n";
            // 
            // lblWebsiteURL
            // 
            this.lblWebsiteURL.AutoSize = true;
            this.lblWebsiteURL.Location = new System.Drawing.Point(9, 191);
            this.lblWebsiteURL.Name = "lblWebsiteURL";
            this.lblWebsiteURL.Size = new System.Drawing.Size(96, 13);
            this.lblWebsiteURL.TabIndex = 8;
            this.lblWebsiteURL.Text = "Enter website URL";
            // 
            // lblCampaignName
            // 
            this.lblCampaignName.AutoSize = true;
            this.lblCampaignName.Location = new System.Drawing.Point(9, 70);
            this.lblCampaignName.Name = "lblCampaignName";
            this.lblCampaignName.Size = new System.Drawing.Size(85, 13);
            this.lblCampaignName.TabIndex = 2;
            this.lblCampaignName.Text = "Campaign Name";
            // 
            // txtCampaignName
            // 
            this.txtCampaignName.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtCampaignName.Location = new System.Drawing.Point(9, 87);
            this.txtCampaignName.MaxLength = 25;
            this.txtCampaignName.Name = "txtCampaignName";
            this.txtCampaignName.Size = new System.Drawing.Size(223, 20);
            this.txtCampaignName.TabIndex = 3;
            // 
            // btnLoadSavedCampaign
            // 
            this.btnLoadSavedCampaign.Location = new System.Drawing.Point(9, 266);
            this.btnLoadSavedCampaign.Name = "btnLoadSavedCampaign";
            this.btnLoadSavedCampaign.Size = new System.Drawing.Size(137, 23);
            this.btnLoadSavedCampaign.TabIndex = 10;
            this.btnLoadSavedCampaign.Text = "Load Saved Campaign";
            this.btnLoadSavedCampaign.UseVisualStyleBackColor = true;
            this.btnLoadSavedCampaign.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Saved Email Campaigns|*.cmpg";
            this.openFileDialog1.FilterIndex = 0;
            // 
            // cmbWebsites
            // 
            this.cmbWebsites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWebsites.FormattingEnabled = true;
            this.cmbWebsites.Location = new System.Drawing.Point(9, 208);
            this.cmbWebsites.Name = "cmbWebsites";
            this.cmbWebsites.Size = new System.Drawing.Size(445, 21);
            this.cmbWebsites.TabIndex = 9;
            // 
            // lblTrackingCode
            // 
            this.lblTrackingCode.AutoSize = true;
            this.lblTrackingCode.Location = new System.Drawing.Point(251, 70);
            this.lblTrackingCode.Name = "lblTrackingCode";
            this.lblTrackingCode.Size = new System.Drawing.Size(35, 13);
            this.lblTrackingCode.TabIndex = 4;
            this.lblTrackingCode.Text = "label1";
            // 
            // txtTrackingCode
            // 
            this.txtTrackingCode.AllowBackSpace = true;
            this.txtTrackingCode.AllowCopy = true;
            this.txtTrackingCode.AllowCut = true;
            this.txtTrackingCode.AllowedCharacters = null;
            this.txtTrackingCode.AllowPaste = true;
            this.txtTrackingCode.Location = new System.Drawing.Point(254, 86);
            this.txtTrackingCode.MaxLength = 20;
            this.txtTrackingCode.Name = "txtTrackingCode";
            this.txtTrackingCode.Size = new System.Drawing.Size(197, 20);
            this.txtTrackingCode.TabIndex = 5;
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Location = new System.Drawing.Point(9, 132);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(35, 13);
            this.lblEmailAddress.TabIndex = 6;
            this.lblEmailAddress.Text = "label1";
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Location = new System.Drawing.Point(9, 149);
            this.txtEmailAddress.MaxLength = 100;
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(445, 20);
            this.txtEmailAddress.TabIndex = 7;
            // 
            // CreateEmailIntro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtEmailAddress);
            this.Controls.Add(this.lblEmailAddress);
            this.Controls.Add(this.txtTrackingCode);
            this.Controls.Add(this.lblTrackingCode);
            this.Controls.Add(this.cmbWebsites);
            this.Controls.Add(this.btnLoadSavedCampaign);
            this.Controls.Add(this.txtCampaignName);
            this.Controls.Add(this.lblCampaignName);
            this.Controls.Add(this.lblWebsiteURL);
            this.Controls.Add(this.lblHeaderDescription);
            this.Controls.Add(this.lblHeader);
            this.Name = "CreateEmailIntro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblHeaderDescription;
        private System.Windows.Forms.Label lblWebsiteURL;
        private System.Windows.Forms.Label lblCampaignName;
        private System.Windows.Forms.TextBox txtCampaignName;
        private System.Windows.Forms.Button btnLoadSavedCampaign;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cmbWebsites;
        private System.Windows.Forms.Label lblTrackingCode;
        private SharedControls.TextBoxEx txtTrackingCode;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.TextBox txtEmailAddress;
    }
}
