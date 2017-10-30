namespace POS.WebsiteAdministration.Forms.Products
{
    partial class AdminProductGroupEdit
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.txtSubHeader = new System.Windows.Forms.TextBox();
            this.lblSubHeader = new System.Windows.Forms.Label();
            this.txtPrimaryHeader = new System.Windows.Forms.TextBox();
            this.lblPrimaryHeader = new System.Windows.Forms.Label();
            this.cmbMemberLevel = new System.Windows.Forms.ComboBox();
            this.lblMemberLevel = new System.Windows.Forms.Label();
            this.cmbGroupType = new System.Windows.Forms.ComboBox();
            this.lblGroupType = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lblURL = new System.Windows.Forms.Label();
            this.cbShowOnWebsite = new System.Windows.Forms.CheckBox();
            this.txtTagLine = new System.Windows.Forms.TextBox();
            this.lblTagLine = new System.Windows.Forms.Label();
            this.spnSortOrder = new System.Windows.Forms.NumericUpDown();
            this.lblSortOrder = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.tabPageMobile = new System.Windows.Forms.TabPage();
            this.pbMobileImage = new System.Windows.Forms.PictureBox();
            this.cmbMobileImage = new System.Windows.Forms.ComboBox();
            this.lblMobileImage = new System.Windows.Forms.Label();
            this.cbShowOnMobilePage = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnSortOrder)).BeginInit();
            this.tabPageMobile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMobileImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(320, 94);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(320, 65);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(320, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageGeneral);
            this.tabControl1.Controls.Add(this.tabPageMobile);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(302, 376);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.txtSubHeader);
            this.tabPageGeneral.Controls.Add(this.lblSubHeader);
            this.tabPageGeneral.Controls.Add(this.txtPrimaryHeader);
            this.tabPageGeneral.Controls.Add(this.lblPrimaryHeader);
            this.tabPageGeneral.Controls.Add(this.cmbMemberLevel);
            this.tabPageGeneral.Controls.Add(this.lblMemberLevel);
            this.tabPageGeneral.Controls.Add(this.cmbGroupType);
            this.tabPageGeneral.Controls.Add(this.lblGroupType);
            this.tabPageGeneral.Controls.Add(this.txtURL);
            this.tabPageGeneral.Controls.Add(this.lblURL);
            this.tabPageGeneral.Controls.Add(this.cbShowOnWebsite);
            this.tabPageGeneral.Controls.Add(this.txtTagLine);
            this.tabPageGeneral.Controls.Add(this.lblTagLine);
            this.tabPageGeneral.Controls.Add(this.spnSortOrder);
            this.tabPageGeneral.Controls.Add(this.lblSortOrder);
            this.tabPageGeneral.Controls.Add(this.txtGroupName);
            this.tabPageGeneral.Controls.Add(this.lblGroupName);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(294, 350);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // txtSubHeader
            // 
            this.txtSubHeader.Location = new System.Drawing.Point(6, 149);
            this.txtSubHeader.MaxLength = 100;
            this.txtSubHeader.Name = "txtSubHeader";
            this.txtSubHeader.Size = new System.Drawing.Size(283, 20);
            this.txtSubHeader.TabIndex = 7;
            // 
            // lblSubHeader
            // 
            this.lblSubHeader.AutoSize = true;
            this.lblSubHeader.Location = new System.Drawing.Point(6, 132);
            this.lblSubHeader.Name = "lblSubHeader";
            this.lblSubHeader.Size = new System.Drawing.Size(64, 13);
            this.lblSubHeader.TabIndex = 6;
            this.lblSubHeader.Text = "Sub Header";
            // 
            // txtPrimaryHeader
            // 
            this.txtPrimaryHeader.Location = new System.Drawing.Point(6, 106);
            this.txtPrimaryHeader.MaxLength = 100;
            this.txtPrimaryHeader.Name = "txtPrimaryHeader";
            this.txtPrimaryHeader.Size = new System.Drawing.Size(283, 20);
            this.txtPrimaryHeader.TabIndex = 5;
            // 
            // lblPrimaryHeader
            // 
            this.lblPrimaryHeader.AutoSize = true;
            this.lblPrimaryHeader.Location = new System.Drawing.Point(6, 89);
            this.lblPrimaryHeader.Name = "lblPrimaryHeader";
            this.lblPrimaryHeader.Size = new System.Drawing.Size(79, 13);
            this.lblPrimaryHeader.TabIndex = 4;
            this.lblPrimaryHeader.Text = "Primary Header";
            // 
            // cmbMemberLevel
            // 
            this.cmbMemberLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMemberLevel.FormattingEnabled = true;
            this.cmbMemberLevel.Location = new System.Drawing.Point(6, 319);
            this.cmbMemberLevel.Name = "cmbMemberLevel";
            this.cmbMemberLevel.Size = new System.Drawing.Size(239, 21);
            this.cmbMemberLevel.TabIndex = 16;
            this.cmbMemberLevel.Visible = false;
            // 
            // lblMemberLevel
            // 
            this.lblMemberLevel.AutoSize = true;
            this.lblMemberLevel.Location = new System.Drawing.Point(6, 302);
            this.lblMemberLevel.Name = "lblMemberLevel";
            this.lblMemberLevel.Size = new System.Drawing.Size(74, 13);
            this.lblMemberLevel.TabIndex = 15;
            this.lblMemberLevel.Text = "Member Level";
            this.lblMemberLevel.Visible = false;
            // 
            // cmbGroupType
            // 
            this.cmbGroupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupType.FormattingEnabled = true;
            this.cmbGroupType.Location = new System.Drawing.Point(6, 20);
            this.cmbGroupType.Name = "cmbGroupType";
            this.cmbGroupType.Size = new System.Drawing.Size(239, 21);
            this.cmbGroupType.TabIndex = 1;
            this.cmbGroupType.Visible = false;
            this.cmbGroupType.SelectedIndexChanged += new System.EventHandler(this.cmbGroupType_SelectedIndexChanged);
            this.cmbGroupType.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbGroupType_Format);
            // 
            // lblGroupType
            // 
            this.lblGroupType.AutoSize = true;
            this.lblGroupType.Location = new System.Drawing.Point(6, 3);
            this.lblGroupType.Name = "lblGroupType";
            this.lblGroupType.Size = new System.Drawing.Size(63, 13);
            this.lblGroupType.TabIndex = 0;
            this.lblGroupType.Text = "Group Type";
            this.lblGroupType.Visible = false;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(6, 276);
            this.txtURL.MaxLength = 150;
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(284, 20);
            this.txtURL.TabIndex = 14;
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(6, 260);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(29, 13);
            this.lblURL.TabIndex = 13;
            this.lblURL.Text = "URL";
            // 
            // cbShowOnWebsite
            // 
            this.cbShowOnWebsite.AutoSize = true;
            this.cbShowOnWebsite.Location = new System.Drawing.Point(184, 235);
            this.cbShowOnWebsite.Name = "cbShowOnWebsite";
            this.cbShowOnWebsite.Size = new System.Drawing.Size(110, 17);
            this.cbShowOnWebsite.TabIndex = 12;
            this.cbShowOnWebsite.Text = "Show on Website";
            this.cbShowOnWebsite.UseVisualStyleBackColor = true;
            // 
            // txtTagLine
            // 
            this.txtTagLine.Location = new System.Drawing.Point(6, 191);
            this.txtTagLine.MaxLength = 250;
            this.txtTagLine.Name = "txtTagLine";
            this.txtTagLine.Size = new System.Drawing.Size(284, 20);
            this.txtTagLine.TabIndex = 9;
            // 
            // lblTagLine
            // 
            this.lblTagLine.AutoSize = true;
            this.lblTagLine.Location = new System.Drawing.Point(6, 175);
            this.lblTagLine.Name = "lblTagLine";
            this.lblTagLine.Size = new System.Drawing.Size(42, 13);
            this.lblTagLine.TabIndex = 8;
            this.lblTagLine.Text = "Tagline";
            // 
            // spnSortOrder
            // 
            this.spnSortOrder.Location = new System.Drawing.Point(6, 234);
            this.spnSortOrder.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.spnSortOrder.Name = "spnSortOrder";
            this.spnSortOrder.Size = new System.Drawing.Size(120, 20);
            this.spnSortOrder.TabIndex = 11;
            // 
            // lblSortOrder
            // 
            this.lblSortOrder.AutoSize = true;
            this.lblSortOrder.Location = new System.Drawing.Point(6, 217);
            this.lblSortOrder.Name = "lblSortOrder";
            this.lblSortOrder.Size = new System.Drawing.Size(55, 13);
            this.lblSortOrder.TabIndex = 10;
            this.lblSortOrder.Text = "Sort Order";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(6, 63);
            this.txtGroupName.MaxLength = 100;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(284, 20);
            this.txtGroupName.TabIndex = 3;
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(6, 47);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(67, 13);
            this.lblGroupName.TabIndex = 2;
            this.lblGroupName.Text = "Group Name";
            // 
            // tabPageMobile
            // 
            this.tabPageMobile.Controls.Add(this.pbMobileImage);
            this.tabPageMobile.Controls.Add(this.cmbMobileImage);
            this.tabPageMobile.Controls.Add(this.lblMobileImage);
            this.tabPageMobile.Controls.Add(this.cbShowOnMobilePage);
            this.tabPageMobile.Location = new System.Drawing.Point(4, 22);
            this.tabPageMobile.Name = "tabPageMobile";
            this.tabPageMobile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMobile.Size = new System.Drawing.Size(294, 350);
            this.tabPageMobile.TabIndex = 1;
            this.tabPageMobile.Text = "Mobile Website";
            this.tabPageMobile.UseVisualStyleBackColor = true;
            // 
            // pbMobileImage
            // 
            this.pbMobileImage.Location = new System.Drawing.Point(10, 98);
            this.pbMobileImage.Name = "pbMobileImage";
            this.pbMobileImage.Size = new System.Drawing.Size(154, 160);
            this.pbMobileImage.TabIndex = 3;
            this.pbMobileImage.TabStop = false;
            // 
            // cmbMobileImage
            // 
            this.cmbMobileImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMobileImage.FormattingEnabled = true;
            this.cmbMobileImage.Location = new System.Drawing.Point(10, 60);
            this.cmbMobileImage.Name = "cmbMobileImage";
            this.cmbMobileImage.Size = new System.Drawing.Size(278, 21);
            this.cmbMobileImage.TabIndex = 2;
            this.cmbMobileImage.SelectedIndexChanged += new System.EventHandler(this.cmbMobileImage_SelectedIndexChanged);
            // 
            // lblMobileImage
            // 
            this.lblMobileImage.AutoSize = true;
            this.lblMobileImage.Location = new System.Drawing.Point(7, 40);
            this.lblMobileImage.Name = "lblMobileImage";
            this.lblMobileImage.Size = new System.Drawing.Size(74, 13);
            this.lblMobileImage.TabIndex = 1;
            this.lblMobileImage.Text = "Custom Image";
            // 
            // cbShowOnMobilePage
            // 
            this.cbShowOnMobilePage.AutoSize = true;
            this.cbShowOnMobilePage.Location = new System.Drawing.Point(7, 7);
            this.cbShowOnMobilePage.Name = "cbShowOnMobilePage";
            this.cbShowOnMobilePage.Size = new System.Drawing.Size(157, 17);
            this.cbShowOnMobilePage.TabIndex = 0;
            this.cbShowOnMobilePage.Text = "Show on Mobile Homepage";
            this.cbShowOnMobilePage.UseVisualStyleBackColor = true;
            // 
            // AdminProductGroupEdit
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(425, 396);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminProductGroupEdit";
            this.SaveState = true;
            this.Text = "Admin Product Group Edit";
            this.tabControl1.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnSortOrder)).EndInit();
            this.tabPageMobile.ResumeLayout(false);
            this.tabPageMobile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMobileImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TextBox txtSubHeader;
        private System.Windows.Forms.Label lblSubHeader;
        private System.Windows.Forms.TextBox txtPrimaryHeader;
        private System.Windows.Forms.Label lblPrimaryHeader;
        private System.Windows.Forms.ComboBox cmbMemberLevel;
        private System.Windows.Forms.Label lblMemberLevel;
        private System.Windows.Forms.ComboBox cmbGroupType;
        private System.Windows.Forms.Label lblGroupType;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.CheckBox cbShowOnWebsite;
        private System.Windows.Forms.TextBox txtTagLine;
        private System.Windows.Forms.Label lblTagLine;
        private System.Windows.Forms.NumericUpDown spnSortOrder;
        private System.Windows.Forms.Label lblSortOrder;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.TabPage tabPageMobile;
        private System.Windows.Forms.PictureBox pbMobileImage;
        private System.Windows.Forms.ComboBox cmbMobileImage;
        private System.Windows.Forms.Label lblMobileImage;
        private System.Windows.Forms.CheckBox cbShowOnMobilePage;
    }
}