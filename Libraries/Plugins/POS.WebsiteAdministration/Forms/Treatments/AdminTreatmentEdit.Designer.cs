namespace POS.WebsiteAdministration.Forms.Treatments
{
    partial class AdminTreatmentEdit
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageDescription = new System.Windows.Forms.TabPage();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.tabPageTreatmentGroups = new System.Windows.Forms.TabPage();
            this.lblAssignedTreatmentGroups = new System.Windows.Forms.Label();
            this.lstTreatmentGroups = new System.Windows.Forms.CheckedListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbDuration = new System.Windows.Forms.ComboBox();
            this.spnSortOrder = new System.Windows.Forms.NumericUpDown();
            this.txtWebsiteLink = new System.Windows.Forms.TextBox();
            this.cmbImage = new System.Windows.Forms.ComboBox();
            this.txtTreatmentLength = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.imgTreatment = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblSortOrder = new System.Windows.Forms.Label();
            this.lblWebsiteLink = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblTreatmentLength = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnSpellCheck = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageDescription.SuspendLayout();
            this.tabPageTreatmentGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnSortOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTreatment)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageDescription);
            this.tabControl1.Controls.Add(this.tabPageTreatmentGroups);
            this.tabControl1.Location = new System.Drawing.Point(15, 198);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(569, 246);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPageDescription
            // 
            this.tabPageDescription.Controls.Add(this.txtDescription);
            this.tabPageDescription.Location = new System.Drawing.Point(4, 22);
            this.tabPageDescription.Name = "tabPageDescription";
            this.tabPageDescription.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDescription.Size = new System.Drawing.Size(561, 220);
            this.tabPageDescription.TabIndex = 0;
            this.tabPageDescription.Text = "Description";
            this.tabPageDescription.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(6, 6);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(549, 208);
            this.txtDescription.TabIndex = 0;
            // 
            // tabPageTreatmentGroups
            // 
            this.tabPageTreatmentGroups.Controls.Add(this.lblAssignedTreatmentGroups);
            this.tabPageTreatmentGroups.Controls.Add(this.lstTreatmentGroups);
            this.tabPageTreatmentGroups.Location = new System.Drawing.Point(4, 22);
            this.tabPageTreatmentGroups.Name = "tabPageTreatmentGroups";
            this.tabPageTreatmentGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTreatmentGroups.Size = new System.Drawing.Size(561, 220);
            this.tabPageTreatmentGroups.TabIndex = 1;
            this.tabPageTreatmentGroups.Text = "Treatment Groups";
            this.tabPageTreatmentGroups.UseVisualStyleBackColor = true;
            // 
            // lblAssignedTreatmentGroups
            // 
            this.lblAssignedTreatmentGroups.AutoSize = true;
            this.lblAssignedTreatmentGroups.Location = new System.Drawing.Point(7, 7);
            this.lblAssignedTreatmentGroups.Name = "lblAssignedTreatmentGroups";
            this.lblAssignedTreatmentGroups.Size = new System.Drawing.Size(138, 13);
            this.lblAssignedTreatmentGroups.TabIndex = 0;
            this.lblAssignedTreatmentGroups.Text = "Assigned Treatment Groups";
            // 
            // lstTreatmentGroups
            // 
            this.lstTreatmentGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTreatmentGroups.FormattingEnabled = true;
            this.lstTreatmentGroups.Location = new System.Drawing.Point(7, 26);
            this.lstTreatmentGroups.Name = "lstTreatmentGroups";
            this.lstTreatmentGroups.Size = new System.Drawing.Size(548, 184);
            this.lstTreatmentGroups.TabIndex = 1;
            this.lstTreatmentGroups.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstTreatmentGroups_Format);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(327, 450);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbDuration
            // 
            this.cmbDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDuration.FormattingEnabled = true;
            this.cmbDuration.Items.AddRange(new object[] {
            "15 Minutes",
            "30 Minutes",
            "45 Minutes",
            "60 Minutes",
            "75 Minutes",
            "90 Minutes",
            "105 Minutes",
            "120 Minutes",
            "135 Minutes",
            "150 Minutes",
            "165 Minutes",
            "180 Minutes",
            "195 Minutes",
            "210 Minutes"});
            this.cmbDuration.Location = new System.Drawing.Point(133, 169);
            this.cmbDuration.Name = "cmbDuration";
            this.cmbDuration.Size = new System.Drawing.Size(226, 21);
            this.cmbDuration.TabIndex = 13;
            // 
            // spnSortOrder
            // 
            this.spnSortOrder.Location = new System.Drawing.Point(133, 142);
            this.spnSortOrder.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spnSortOrder.Name = "spnSortOrder";
            this.spnSortOrder.Size = new System.Drawing.Size(120, 20);
            this.spnSortOrder.TabIndex = 11;
            // 
            // txtWebsiteLink
            // 
            this.txtWebsiteLink.Location = new System.Drawing.Point(133, 115);
            this.txtWebsiteLink.Name = "txtWebsiteLink";
            this.txtWebsiteLink.Size = new System.Drawing.Size(269, 20);
            this.txtWebsiteLink.TabIndex = 9;
            // 
            // cmbImage
            // 
            this.cmbImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImage.FormattingEnabled = true;
            this.cmbImage.Location = new System.Drawing.Point(133, 88);
            this.cmbImage.Name = "cmbImage";
            this.cmbImage.Size = new System.Drawing.Size(269, 21);
            this.cmbImage.TabIndex = 7;
            this.cmbImage.SelectedIndexChanged += new System.EventHandler(this.cmbImage_SelectedIndexChanged);
            // 
            // txtTreatmentLength
            // 
            this.txtTreatmentLength.Location = new System.Drawing.Point(133, 62);
            this.txtTreatmentLength.Name = "txtTreatmentLength";
            this.txtTreatmentLength.Size = new System.Drawing.Size(269, 20);
            this.txtTreatmentLength.TabIndex = 5;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(133, 36);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(269, 20);
            this.txtPrice.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(133, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(269, 20);
            this.txtName.TabIndex = 1;
            // 
            // imgTreatment
            // 
            this.imgTreatment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgTreatment.Location = new System.Drawing.Point(464, 12);
            this.imgTreatment.Name = "imgTreatment";
            this.imgTreatment.Size = new System.Drawing.Size(120, 120);
            this.imgTreatment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgTreatment.TabIndex = 11;
            this.imgTreatment.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(428, 450);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(509, 450);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(12, 172);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(47, 13);
            this.lblDuration.TabIndex = 12;
            this.lblDuration.Text = "Duration";
            // 
            // lblSortOrder
            // 
            this.lblSortOrder.AutoSize = true;
            this.lblSortOrder.Location = new System.Drawing.Point(12, 144);
            this.lblSortOrder.Name = "lblSortOrder";
            this.lblSortOrder.Size = new System.Drawing.Size(55, 13);
            this.lblSortOrder.TabIndex = 10;
            this.lblSortOrder.Text = "Sort Order";
            // 
            // lblWebsiteLink
            // 
            this.lblWebsiteLink.AutoSize = true;
            this.lblWebsiteLink.Location = new System.Drawing.Point(12, 118);
            this.lblWebsiteLink.Name = "lblWebsiteLink";
            this.lblWebsiteLink.Size = new System.Drawing.Size(69, 13);
            this.lblWebsiteLink.TabIndex = 8;
            this.lblWebsiteLink.Text = "Website Link";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(12, 91);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(36, 13);
            this.lblImage.TabIndex = 6;
            this.lblImage.Text = "Image";
            // 
            // lblTreatmentLength
            // 
            this.lblTreatmentLength.AutoSize = true;
            this.lblTreatmentLength.Location = new System.Drawing.Point(12, 65);
            this.lblTreatmentLength.Name = "lblTreatmentLength";
            this.lblTreatmentLength.Size = new System.Drawing.Size(91, 13);
            this.lblTreatmentLength.TabIndex = 4;
            this.lblTreatmentLength.Text = "Treatment Length";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(12, 39);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(31, 13);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "Price";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // btnSpellCheck
            // 
            this.btnSpellCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpellCheck.Location = new System.Drawing.Point(225, 450);
            this.btnSpellCheck.Name = "btnSpellCheck";
            this.btnSpellCheck.Size = new System.Drawing.Size(75, 23);
            this.btnSpellCheck.TabIndex = 15;
            this.btnSpellCheck.Text = "Spell Check";
            this.btnSpellCheck.UseVisualStyleBackColor = true;
            this.btnSpellCheck.Click += new System.EventHandler(this.btnSpellCheck_Click);
            // 
            // AdminTreatmentEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 485);
            this.Controls.Add(this.btnSpellCheck);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cmbDuration);
            this.Controls.Add(this.spnSortOrder);
            this.Controls.Add(this.txtWebsiteLink);
            this.Controls.Add(this.cmbImage);
            this.Controls.Add(this.txtTreatmentLength);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.imgTreatment);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblSortOrder);
            this.Controls.Add(this.lblWebsiteLink);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.lblTreatmentLength);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminTreatmentEdit";
            this.SaveState = true;
            this.ShowIcon = false;
            this.Text = "Administration - Treatment Edit";
            this.tabControl1.ResumeLayout(false);
            this.tabPageDescription.ResumeLayout(false);
            this.tabPageDescription.PerformLayout();
            this.tabPageTreatmentGroups.ResumeLayout(false);
            this.tabPageTreatmentGroups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnSortOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTreatment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblTreatmentLength;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Label lblWebsiteLink;
        private System.Windows.Forms.Label lblSortOrder;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox imgTreatment;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtTreatmentLength;
        private System.Windows.Forms.ComboBox cmbImage;
        private System.Windows.Forms.TextBox txtWebsiteLink;
        private System.Windows.Forms.NumericUpDown spnSortOrder;
        private System.Windows.Forms.ComboBox cmbDuration;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TabPage tabPageTreatmentGroups;
        private System.Windows.Forms.Label lblAssignedTreatmentGroups;
        private System.Windows.Forms.CheckedListBox lstTreatmentGroups;
        private System.Windows.Forms.Button btnSpellCheck;
    }
}