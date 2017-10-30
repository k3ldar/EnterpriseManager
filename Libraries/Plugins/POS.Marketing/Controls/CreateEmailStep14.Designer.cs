namespace POS.Marketing.Controls
{
    partial class CreateEmailStep14
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
            this.btnCreateUpdateCampaign = new System.Windows.Forms.Button();
            this.lblEndDateTime = new System.Windows.Forms.Label();
            this.dtpFinish = new System.Windows.Forms.DateTimePicker();
            this.lblStartDateTime = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.txtEmailTitle = new System.Windows.Forms.TextBox();
            this.lblEmailTitle = new System.Windows.Forms.Label();
            this.cmbCampaigns = new System.Windows.Forms.ComboBox();
            this.rbExistingCampaign = new System.Windows.Forms.RadioButton();
            this.rbNewCampaign = new System.Windows.Forms.RadioButton();
            this.lblCampaign = new System.Windows.Forms.Label();
            this.gbCampaignSender = new System.Windows.Forms.GroupBox();
            this.gbMailChimpSettings = new System.Windows.Forms.GroupBox();
            this.txtMailChimpSenderEmail = new System.Windows.Forms.TextBox();
            this.txtMailChimpSenderName = new System.Windows.Forms.TextBox();
            this.lblSenderEmail = new System.Windows.Forms.Label();
            this.lblSenderName = new System.Windows.Forms.Label();
            this.cmbMailChimpLists = new System.Windows.Forms.ComboBox();
            this.lblMailList = new System.Windows.Forms.Label();
            this.cmbMailType = new System.Windows.Forms.ComboBox();
            this.gbCampaignSender.SuspendLayout();
            this.gbMailChimpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateUpdateCampaign
            // 
            this.btnCreateUpdateCampaign.Location = new System.Drawing.Point(460, 194);
            this.btnCreateUpdateCampaign.Name = "btnCreateUpdateCampaign";
            this.btnCreateUpdateCampaign.Size = new System.Drawing.Size(85, 23);
            this.btnCreateUpdateCampaign.TabIndex = 14;
            this.btnCreateUpdateCampaign.Text = "Create";
            this.btnCreateUpdateCampaign.UseVisualStyleBackColor = true;
            this.btnCreateUpdateCampaign.Click += new System.EventHandler(this.btnCreateUpdateCampaign_Click);
            // 
            // lblEndDateTime
            // 
            this.lblEndDateTime.AutoSize = true;
            this.lblEndDateTime.Location = new System.Drawing.Point(281, 127);
            this.lblEndDateTime.Name = "lblEndDateTime";
            this.lblEndDateTime.Size = new System.Drawing.Size(80, 13);
            this.lblEndDateTime.TabIndex = 13;
            this.lblEndDateTime.Text = "End Date/Time";
            // 
            // dtpFinish
            // 
            this.dtpFinish.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFinish.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinish.Location = new System.Drawing.Point(281, 146);
            this.dtpFinish.Name = "dtpFinish";
            this.dtpFinish.Size = new System.Drawing.Size(264, 20);
            this.dtpFinish.TabIndex = 12;
            this.dtpFinish.Value = new System.DateTime(2016, 2, 7, 23, 40, 0, 0);
            // 
            // lblStartDateTime
            // 
            this.lblStartDateTime.AutoSize = true;
            this.lblStartDateTime.Location = new System.Drawing.Point(10, 127);
            this.lblStartDateTime.Name = "lblStartDateTime";
            this.lblStartDateTime.Size = new System.Drawing.Size(83, 13);
            this.lblStartDateTime.TabIndex = 11;
            this.lblStartDateTime.Text = "Start Date/Time";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(10, 146);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(265, 20);
            this.dtpStart.TabIndex = 10;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // txtEmailTitle
            // 
            this.txtEmailTitle.Location = new System.Drawing.Point(10, 96);
            this.txtEmailTitle.Name = "txtEmailTitle";
            this.txtEmailTitle.Size = new System.Drawing.Size(535, 20);
            this.txtEmailTitle.TabIndex = 9;
            // 
            // lblEmailTitle
            // 
            this.lblEmailTitle.AutoSize = true;
            this.lblEmailTitle.Location = new System.Drawing.Point(7, 79);
            this.lblEmailTitle.Name = "lblEmailTitle";
            this.lblEmailTitle.Size = new System.Drawing.Size(55, 13);
            this.lblEmailTitle.TabIndex = 8;
            this.lblEmailTitle.Text = "Email Title";
            // 
            // cmbCampaigns
            // 
            this.cmbCampaigns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCampaigns.FormattingEnabled = true;
            this.cmbCampaigns.Location = new System.Drawing.Point(249, 36);
            this.cmbCampaigns.Name = "cmbCampaigns";
            this.cmbCampaigns.Size = new System.Drawing.Size(296, 21);
            this.cmbCampaigns.TabIndex = 7;
            this.cmbCampaigns.SelectedIndexChanged += new System.EventHandler(this.cmbCampaigns_SelectedIndexChanged);
            this.cmbCampaigns.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbCampaigns_Format);
            // 
            // rbExistingCampaign
            // 
            this.rbExistingCampaign.AutoSize = true;
            this.rbExistingCampaign.Location = new System.Drawing.Point(122, 37);
            this.rbExistingCampaign.Name = "rbExistingCampaign";
            this.rbExistingCampaign.Size = new System.Drawing.Size(111, 17);
            this.rbExistingCampaign.TabIndex = 6;
            this.rbExistingCampaign.TabStop = true;
            this.rbExistingCampaign.Text = "Existing Campaign";
            this.rbExistingCampaign.UseVisualStyleBackColor = true;
            this.rbExistingCampaign.CheckedChanged += new System.EventHandler(this.rbNewCampaign_CheckedChanged);
            // 
            // rbNewCampaign
            // 
            this.rbNewCampaign.AutoSize = true;
            this.rbNewCampaign.Location = new System.Drawing.Point(7, 37);
            this.rbNewCampaign.Name = "rbNewCampaign";
            this.rbNewCampaign.Size = new System.Drawing.Size(97, 17);
            this.rbNewCampaign.TabIndex = 5;
            this.rbNewCampaign.TabStop = true;
            this.rbNewCampaign.Text = "New Campaign";
            this.rbNewCampaign.UseVisualStyleBackColor = true;
            this.rbNewCampaign.CheckedChanged += new System.EventHandler(this.rbNewCampaign_CheckedChanged);
            // 
            // lblCampaign
            // 
            this.lblCampaign.AutoSize = true;
            this.lblCampaign.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblCampaign.Location = new System.Drawing.Point(3, 0);
            this.lblCampaign.Name = "lblCampaign";
            this.lblCampaign.Size = new System.Drawing.Size(98, 24);
            this.lblCampaign.TabIndex = 4;
            this.lblCampaign.Text = "Campaign";
            // 
            // gbCampaignSender
            // 
            this.gbCampaignSender.Controls.Add(this.cmbMailType);
            this.gbCampaignSender.Location = new System.Drawing.Point(7, 180);
            this.gbCampaignSender.Name = "gbCampaignSender";
            this.gbCampaignSender.Size = new System.Drawing.Size(316, 51);
            this.gbCampaignSender.TabIndex = 15;
            this.gbCampaignSender.TabStop = false;
            this.gbCampaignSender.Text = "Sender";
            // 
            // gbMailChimpSettings
            // 
            this.gbMailChimpSettings.Controls.Add(this.txtMailChimpSenderEmail);
            this.gbMailChimpSettings.Controls.Add(this.txtMailChimpSenderName);
            this.gbMailChimpSettings.Controls.Add(this.lblSenderEmail);
            this.gbMailChimpSettings.Controls.Add(this.lblSenderName);
            this.gbMailChimpSettings.Controls.Add(this.cmbMailChimpLists);
            this.gbMailChimpSettings.Controls.Add(this.lblMailList);
            this.gbMailChimpSettings.Location = new System.Drawing.Point(7, 248);
            this.gbMailChimpSettings.Name = "gbMailChimpSettings";
            this.gbMailChimpSettings.Size = new System.Drawing.Size(316, 105);
            this.gbMailChimpSettings.TabIndex = 16;
            this.gbMailChimpSettings.TabStop = false;
            this.gbMailChimpSettings.Text = "Mail Chimp Settings";
            // 
            // txtMailChimpSenderEmail
            // 
            this.txtMailChimpSenderEmail.Location = new System.Drawing.Point(126, 79);
            this.txtMailChimpSenderEmail.MaxLength = 150;
            this.txtMailChimpSenderEmail.Name = "txtMailChimpSenderEmail";
            this.txtMailChimpSenderEmail.Size = new System.Drawing.Size(171, 20);
            this.txtMailChimpSenderEmail.TabIndex = 5;
            // 
            // txtMailChimpSenderName
            // 
            this.txtMailChimpSenderName.Location = new System.Drawing.Point(126, 52);
            this.txtMailChimpSenderName.MaxLength = 150;
            this.txtMailChimpSenderName.Name = "txtMailChimpSenderName";
            this.txtMailChimpSenderName.Size = new System.Drawing.Size(171, 20);
            this.txtMailChimpSenderName.TabIndex = 4;
            // 
            // lblSenderEmail
            // 
            this.lblSenderEmail.AutoSize = true;
            this.lblSenderEmail.Location = new System.Drawing.Point(6, 79);
            this.lblSenderEmail.Name = "lblSenderEmail";
            this.lblSenderEmail.Size = new System.Drawing.Size(69, 13);
            this.lblSenderEmail.TabIndex = 3;
            this.lblSenderEmail.Text = "Sender Email";
            // 
            // lblSenderName
            // 
            this.lblSenderName.AutoSize = true;
            this.lblSenderName.Location = new System.Drawing.Point(6, 52);
            this.lblSenderName.Name = "lblSenderName";
            this.lblSenderName.Size = new System.Drawing.Size(72, 13);
            this.lblSenderName.TabIndex = 2;
            this.lblSenderName.Text = "Sender Name";
            // 
            // cmbMailChimpLists
            // 
            this.cmbMailChimpLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMailChimpLists.FormattingEnabled = true;
            this.cmbMailChimpLists.Location = new System.Drawing.Point(126, 20);
            this.cmbMailChimpLists.Name = "cmbMailChimpLists";
            this.cmbMailChimpLists.Size = new System.Drawing.Size(171, 21);
            this.cmbMailChimpLists.TabIndex = 1;
            this.cmbMailChimpLists.SelectedIndexChanged += new System.EventHandler(this.cmbMailChimpLists_SelectedIndexChanged);
            this.cmbMailChimpLists.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbMailChimpLists_Format);
            // 
            // lblMailList
            // 
            this.lblMailList.AutoSize = true;
            this.lblMailList.Location = new System.Drawing.Point(6, 23);
            this.lblMailList.Name = "lblMailList";
            this.lblMailList.Size = new System.Drawing.Size(45, 13);
            this.lblMailList.TabIndex = 0;
            this.lblMailList.Text = "Mail List";
            // 
            // cmbMailType
            // 
            this.cmbMailType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMailType.FormattingEnabled = true;
            this.cmbMailType.Location = new System.Drawing.Point(9, 19);
            this.cmbMailType.Name = "cmbMailType";
            this.cmbMailType.Size = new System.Drawing.Size(301, 21);
            this.cmbMailType.TabIndex = 0;
            this.cmbMailType.SelectedIndexChanged += new System.EventHandler(this.rbMailChimp_CheckedChanged);
            // 
            // CreateEmailStep9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbMailChimpSettings);
            this.Controls.Add(this.gbCampaignSender);
            this.Controls.Add(this.btnCreateUpdateCampaign);
            this.Controls.Add(this.lblEndDateTime);
            this.Controls.Add(this.dtpFinish);
            this.Controls.Add(this.lblStartDateTime);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.txtEmailTitle);
            this.Controls.Add(this.lblEmailTitle);
            this.Controls.Add(this.cmbCampaigns);
            this.Controls.Add(this.rbExistingCampaign);
            this.Controls.Add(this.rbNewCampaign);
            this.Controls.Add(this.lblCampaign);
            this.Name = "CreateEmailStep9";
            this.gbCampaignSender.ResumeLayout(false);
            this.gbMailChimpSettings.ResumeLayout(false);
            this.gbMailChimpSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCampaign;
        private System.Windows.Forms.RadioButton rbNewCampaign;
        private System.Windows.Forms.RadioButton rbExistingCampaign;
        private System.Windows.Forms.ComboBox cmbCampaigns;
        private System.Windows.Forms.Label lblEmailTitle;
        private System.Windows.Forms.TextBox txtEmailTitle;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblStartDateTime;
        private System.Windows.Forms.Label lblEndDateTime;
        private System.Windows.Forms.DateTimePicker dtpFinish;
        private System.Windows.Forms.Button btnCreateUpdateCampaign;
        private System.Windows.Forms.GroupBox gbCampaignSender;
        private System.Windows.Forms.GroupBox gbMailChimpSettings;
        private System.Windows.Forms.ComboBox cmbMailChimpLists;
        private System.Windows.Forms.Label lblMailList;
        private System.Windows.Forms.TextBox txtMailChimpSenderEmail;
        private System.Windows.Forms.TextBox txtMailChimpSenderName;
        private System.Windows.Forms.Label lblSenderEmail;
        private System.Windows.Forms.Label lblSenderName;
        private System.Windows.Forms.ComboBox cmbMailType;
    }
}
