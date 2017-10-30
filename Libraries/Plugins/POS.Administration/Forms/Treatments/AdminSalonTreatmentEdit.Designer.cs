namespace POS.Administration.Forms.Treatments
{
    partial class AdminSalonTreatmentEdit
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
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.cbFollowOn = new System.Windows.Forms.CheckBox();
            this.cmbTreatmentLength = new System.Windows.Forms.ComboBox();
            this.udMaximum = new System.Windows.Forms.NumericUpDown();
            this.lblMaxAvailable = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.cbactive = new System.Windows.Forms.CheckBox();
            this.tabPageStaff = new System.Windows.Forms.TabPage();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstAssigned = new System.Windows.Forms.ListBox();
            this.lstAvailable = new System.Windows.Forms.ListBox();
            this.lblAssignedTherapists = new System.Windows.Forms.Label();
            this.lblAvailableTherapists = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTreatmentName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.tabPageImage = new System.Windows.Forms.TabPage();
            this.cmbImages = new System.Windows.Forms.ComboBox();
            this.picTreatmentImage = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMaximum)).BeginInit();
            this.tabPageStaff.SuspendLayout();
            this.tabPageImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTreatmentImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageSettings);
            this.tabControl1.Controls.Add(this.tabPageStaff);
            this.tabControl1.Controls.Add(this.tabPageImage);
            this.tabControl1.Location = new System.Drawing.Point(12, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(511, 278);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.txtCost);
            this.tabPageSettings.Controls.Add(this.cbFollowOn);
            this.tabPageSettings.Controls.Add(this.cmbTreatmentLength);
            this.tabPageSettings.Controls.Add(this.udMaximum);
            this.tabPageSettings.Controls.Add(this.lblMaxAvailable);
            this.tabPageSettings.Controls.Add(this.lblCost);
            this.tabPageSettings.Controls.Add(this.lblLength);
            this.tabPageSettings.Controls.Add(this.cbactive);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(503, 252);
            this.tabPageSettings.TabIndex = 0;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(19, 82);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(100, 20);
            this.txtCost.TabIndex = 3;
            // 
            // cbFollowOn
            // 
            this.cbFollowOn.AutoSize = true;
            this.cbFollowOn.Location = new System.Drawing.Point(16, 203);
            this.cbFollowOn.Name = "cbFollowOn";
            this.cbFollowOn.Size = new System.Drawing.Size(180, 17);
            this.cbFollowOn.TabIndex = 7;
            this.cbFollowOn.Text = "Require Follow On Appointments";
            this.cbFollowOn.UseVisualStyleBackColor = true;
            // 
            // cmbTreatmentLength
            // 
            this.cmbTreatmentLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTreatmentLength.FormattingEnabled = true;
            this.cmbTreatmentLength.Location = new System.Drawing.Point(16, 33);
            this.cmbTreatmentLength.Name = "cmbTreatmentLength";
            this.cmbTreatmentLength.Size = new System.Drawing.Size(206, 21);
            this.cmbTreatmentLength.TabIndex = 1;
            this.cmbTreatmentLength.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbTreatmentLength_Format);
            // 
            // udMaximum
            // 
            this.udMaximum.Location = new System.Drawing.Point(16, 135);
            this.udMaximum.Name = "udMaximum";
            this.udMaximum.Size = new System.Drawing.Size(120, 20);
            this.udMaximum.TabIndex = 5;
            // 
            // lblMaxAvailable
            // 
            this.lblMaxAvailable.AutoSize = true;
            this.lblMaxAvailable.Location = new System.Drawing.Point(16, 118);
            this.lblMaxAvailable.Name = "lblMaxAvailable";
            this.lblMaxAvailable.Size = new System.Drawing.Size(97, 13);
            this.lblMaxAvailable.TabIndex = 4;
            this.lblMaxAvailable.Text = "Maximum Available";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(16, 65);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(28, 13);
            this.lblCost.TabIndex = 2;
            this.lblCost.Text = "Cost";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(16, 16);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(91, 13);
            this.lblLength.TabIndex = 0;
            this.lblLength.Text = "Treatment Length";
            // 
            // cbactive
            // 
            this.cbactive.AutoSize = true;
            this.cbactive.Location = new System.Drawing.Point(16, 179);
            this.cbactive.Name = "cbactive";
            this.cbactive.Size = new System.Drawing.Size(56, 17);
            this.cbactive.TabIndex = 6;
            this.cbactive.Text = "Active";
            this.cbactive.UseVisualStyleBackColor = true;
            // 
            // tabPageStaff
            // 
            this.tabPageStaff.Controls.Add(this.btnRemove);
            this.tabPageStaff.Controls.Add(this.btnAdd);
            this.tabPageStaff.Controls.Add(this.lstAssigned);
            this.tabPageStaff.Controls.Add(this.lstAvailable);
            this.tabPageStaff.Controls.Add(this.lblAssignedTherapists);
            this.tabPageStaff.Controls.Add(this.lblAvailableTherapists);
            this.tabPageStaff.Location = new System.Drawing.Point(4, 22);
            this.tabPageStaff.Name = "tabPageStaff";
            this.tabPageStaff.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStaff.Size = new System.Drawing.Size(503, 252);
            this.tabPageStaff.TabIndex = 1;
            this.tabPageStaff.Text = "Therapists";
            this.tabPageStaff.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(215, 138);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "<< Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(215, 108);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add >>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstAssigned
            // 
            this.lstAssigned.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstAssigned.FormattingEnabled = true;
            this.lstAssigned.Location = new System.Drawing.Point(303, 24);
            this.lstAssigned.Name = "lstAssigned";
            this.lstAssigned.Size = new System.Drawing.Size(190, 212);
            this.lstAssigned.TabIndex = 4;
            this.lstAssigned.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstAvailable_Format);
            this.lstAssigned.DoubleClick += new System.EventHandler(this.btnRemove_Click);
            // 
            // lstAvailable
            // 
            this.lstAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstAvailable.FormattingEnabled = true;
            this.lstAvailable.Location = new System.Drawing.Point(10, 24);
            this.lstAvailable.Name = "lstAvailable";
            this.lstAvailable.Size = new System.Drawing.Size(190, 212);
            this.lstAvailable.TabIndex = 1;
            this.lstAvailable.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstAvailable_Format);
            this.lstAvailable.DoubleClick += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblAssignedTherapists
            // 
            this.lblAssignedTherapists.AutoSize = true;
            this.lblAssignedTherapists.Location = new System.Drawing.Point(300, 6);
            this.lblAssignedTherapists.Name = "lblAssignedTherapists";
            this.lblAssignedTherapists.Size = new System.Drawing.Size(102, 13);
            this.lblAssignedTherapists.TabIndex = 3;
            this.lblAssignedTherapists.Text = "Assigned Therapists";
            // 
            // lblAvailableTherapists
            // 
            this.lblAvailableTherapists.AutoSize = true;
            this.lblAvailableTherapists.Location = new System.Drawing.Point(7, 7);
            this.lblAvailableTherapists.Name = "lblAvailableTherapists";
            this.lblAvailableTherapists.Size = new System.Drawing.Size(102, 13);
            this.lblAvailableTherapists.TabIndex = 0;
            this.lblAvailableTherapists.Text = "Available Therapists";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(448, 343);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(367, 343);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblTreatmentName
            // 
            this.lblTreatmentName.AutoSize = true;
            this.lblTreatmentName.Location = new System.Drawing.Point(9, 9);
            this.lblTreatmentName.Name = "lblTreatmentName";
            this.lblTreatmentName.Size = new System.Drawing.Size(86, 13);
            this.lblTreatmentName.TabIndex = 0;
            this.lblTreatmentName.Text = "Treatment Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(12, 26);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(507, 20);
            this.txtName.TabIndex = 1;
            // 
            // tabPageImage
            // 
            this.tabPageImage.Controls.Add(this.picTreatmentImage);
            this.tabPageImage.Controls.Add(this.cmbImages);
            this.tabPageImage.Location = new System.Drawing.Point(4, 22);
            this.tabPageImage.Name = "tabPageImage";
            this.tabPageImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImage.Size = new System.Drawing.Size(503, 252);
            this.tabPageImage.TabIndex = 2;
            this.tabPageImage.Text = "tabPage1";
            this.tabPageImage.UseVisualStyleBackColor = true;
            // 
            // cmbImages
            // 
            this.cmbImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImages.FormattingEnabled = true;
            this.cmbImages.Location = new System.Drawing.Point(7, 7);
            this.cmbImages.Name = "cmbImages";
            this.cmbImages.Size = new System.Drawing.Size(490, 21);
            this.cmbImages.TabIndex = 0;
            this.cmbImages.SelectedIndexChanged += new System.EventHandler(this.cmbImages_SelectedIndexChanged);
            // 
            // picTreatmentImage
            // 
            this.picTreatmentImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTreatmentImage.Location = new System.Drawing.Point(7, 35);
            this.picTreatmentImage.Name = "picTreatmentImage";
            this.picTreatmentImage.Size = new System.Drawing.Size(100, 50);
            this.picTreatmentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picTreatmentImage.TabIndex = 1;
            this.picTreatmentImage.TabStop = false;
            // 
            // AdminSalonTreatmentEdit
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(535, 377);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblTreatmentName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(551, 416);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(551, 416);
            this.Name = "AdminSalonTreatmentEdit";
            this.SaveState = true;
            this.Text = "Salon Treatment Edit";
            this.tabControl1.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMaximum)).EndInit();
            this.tabPageStaff.ResumeLayout(false);
            this.tabPageStaff.PerformLayout();
            this.tabPageImage.ResumeLayout(false);
            this.tabPageImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTreatmentImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TabPage tabPageStaff;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbFollowOn;
        private System.Windows.Forms.ComboBox cmbTreatmentLength;
        private System.Windows.Forms.NumericUpDown udMaximum;
        private System.Windows.Forms.Label lblMaxAvailable;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.CheckBox cbactive;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstAssigned;
        private System.Windows.Forms.ListBox lstAvailable;
        private System.Windows.Forms.Label lblAssignedTherapists;
        private System.Windows.Forms.Label lblAvailableTherapists;
        private System.Windows.Forms.Label lblTreatmentName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.TabPage tabPageImage;
        private System.Windows.Forms.PictureBox picTreatmentImage;
        private System.Windows.Forms.ComboBox cmbImages;
    }
}