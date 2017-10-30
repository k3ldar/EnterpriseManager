namespace POS.Staff.Controls.Wizards.StaffAdd
{
    partial class Step2
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
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.cmbMaritalStatus = new System.Windows.Forms.ComboBox();
            this.lblMaritalStatus = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbNationality = new System.Windows.Forms.ComboBox();
            this.lblNationality = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Location = new System.Drawing.Point(3, 183);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(206, 20);
            this.dtpDateOfBirth.TabIndex = 7;
            this.dtpDateOfBirth.ValueChanged += new System.EventHandler(this.cmbNationality_SelectedIndexChanged);
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(3, 166);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(66, 13);
            this.lblDateOfBirth.TabIndex = 6;
            this.lblDateOfBirth.Text = "Date of Birth";
            // 
            // cmbMaritalStatus
            // 
            this.cmbMaritalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaritalStatus.FormattingEnabled = true;
            this.cmbMaritalStatus.Location = new System.Drawing.Point(3, 131);
            this.cmbMaritalStatus.Name = "cmbMaritalStatus";
            this.cmbMaritalStatus.Size = new System.Drawing.Size(206, 21);
            this.cmbMaritalStatus.TabIndex = 5;
            this.cmbMaritalStatus.SelectedIndexChanged += new System.EventHandler(this.cmbNationality_SelectedIndexChanged);
            // 
            // lblMaritalStatus
            // 
            this.lblMaritalStatus.AutoSize = true;
            this.lblMaritalStatus.Location = new System.Drawing.Point(3, 114);
            this.lblMaritalStatus.Name = "lblMaritalStatus";
            this.lblMaritalStatus.Size = new System.Drawing.Size(71, 13);
            this.lblMaritalStatus.TabIndex = 4;
            this.lblMaritalStatus.Text = "Marital Status";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(3, 77);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(206, 21);
            this.cmbGender.TabIndex = 3;
            this.cmbGender.SelectedIndexChanged += new System.EventHandler(this.cmbNationality_SelectedIndexChanged);
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(3, 60);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(42, 13);
            this.lblGender.TabIndex = 2;
            this.lblGender.Text = "Gender";
            // 
            // cmbNationality
            // 
            this.cmbNationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNationality.FormattingEnabled = true;
            this.cmbNationality.Location = new System.Drawing.Point(3, 22);
            this.cmbNationality.Name = "cmbNationality";
            this.cmbNationality.Size = new System.Drawing.Size(206, 21);
            this.cmbNationality.TabIndex = 1;
            this.cmbNationality.SelectedIndexChanged += new System.EventHandler(this.cmbNationality_SelectedIndexChanged);
            this.cmbNationality.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbCountry_Format);
            // 
            // lblNationality
            // 
            this.lblNationality.AutoSize = true;
            this.lblNationality.Location = new System.Drawing.Point(3, 5);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(56, 13);
            this.lblNationality.TabIndex = 0;
            this.lblNationality.Text = "Nationality";
            // 
            // Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpDateOfBirth);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.cmbMaritalStatus);
            this.Controls.Add(this.lblMaritalStatus);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.cmbNationality);
            this.Controls.Add(this.lblNationality);
            this.Name = "Step2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.ComboBox cmbMaritalStatus;
        private System.Windows.Forms.Label lblMaritalStatus;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbNationality;
        private System.Windows.Forms.Label lblNationality;
    }
}
