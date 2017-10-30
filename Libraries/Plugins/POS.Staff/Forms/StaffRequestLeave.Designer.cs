namespace POS.Staff.Forms
{
    partial class StaffRequestLeave
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
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblStaffMember = new System.Windows.Forms.Label();
            this.cmbStaff = new System.Windows.Forms.ComboBox();
            this.cbFullDay = new System.Windows.Forms.CheckBox();
            this.btnRequest = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.cbAuthorised = new System.Windows.Forms.CheckBox();
            this.cbApproved = new System.Windows.Forms.CheckBox();
            this.lblCalculation = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(15, 94);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(56, 13);
            this.lblDateFrom.TabIndex = 3;
            this.lblDateFrom.Text = "Date From";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(15, 111);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(183, 20);
            this.dtpDateFrom.TabIndex = 4;
            this.dtpDateFrom.ValueChanged += new System.EventHandler(this.dtpDateFrom_ValueChanged);
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(206, 94);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(46, 13);
            this.lblDateTo.TabIndex = 5;
            this.lblDateTo.Text = "Date To";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(209, 111);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(183, 20);
            this.dtpDateTo.TabIndex = 6;
            this.dtpDateTo.ValueChanged += new System.EventHandler(this.dtpDateTo_ValueChanged);
            // 
            // lblStaffMember
            // 
            this.lblStaffMember.AutoSize = true;
            this.lblStaffMember.Location = new System.Drawing.Point(15, 14);
            this.lblStaffMember.Name = "lblStaffMember";
            this.lblStaffMember.Size = new System.Drawing.Size(70, 13);
            this.lblStaffMember.TabIndex = 0;
            this.lblStaffMember.Text = "Staff Member";
            // 
            // cmbStaff
            // 
            this.cmbStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaff.FormattingEnabled = true;
            this.cmbStaff.Location = new System.Drawing.Point(15, 30);
            this.cmbStaff.Name = "cmbStaff";
            this.cmbStaff.Size = new System.Drawing.Size(304, 21);
            this.cmbStaff.TabIndex = 1;
            this.cmbStaff.SelectedIndexChanged += new System.EventHandler(this.cmbStaff_SelectedIndexChanged);
            this.cmbStaff.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbStaff_Format);
            // 
            // cbFullDay
            // 
            this.cbFullDay.AutoSize = true;
            this.cbFullDay.Checked = true;
            this.cbFullDay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFullDay.Location = new System.Drawing.Point(15, 171);
            this.cbFullDay.Name = "cbFullDay";
            this.cbFullDay.Size = new System.Drawing.Size(64, 17);
            this.cbFullDay.TabIndex = 7;
            this.cbFullDay.Text = "Full Day";
            this.cbFullDay.UseVisualStyleBackColor = true;
            this.cbFullDay.CheckedChanged += new System.EventHandler(this.cbFullDay_CheckedChanged);
            // 
            // btnRequest
            // 
            this.btnRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequest.Location = new System.Drawing.Point(317, 290);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(75, 23);
            this.btnRequest.TabIndex = 12;
            this.btnRequest.Text = "Request";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(236, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblRemaining
            // 
            this.lblRemaining.AutoSize = true;
            this.lblRemaining.Location = new System.Drawing.Point(15, 64);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(57, 13);
            this.lblRemaining.TabIndex = 2;
            this.lblRemaining.Text = "Remaining";
            // 
            // cbAuthorised
            // 
            this.cbAuthorised.AutoSize = true;
            this.cbAuthorised.Location = new System.Drawing.Point(15, 195);
            this.cbAuthorised.Name = "cbAuthorised";
            this.cbAuthorised.Size = new System.Drawing.Size(76, 17);
            this.cbAuthorised.TabIndex = 10;
            this.cbAuthorised.Text = "Authorised";
            this.cbAuthorised.UseVisualStyleBackColor = true;
            // 
            // cbApproved
            // 
            this.cbApproved.AutoSize = true;
            this.cbApproved.Location = new System.Drawing.Point(15, 218);
            this.cbApproved.Name = "cbApproved";
            this.cbApproved.Size = new System.Drawing.Size(72, 17);
            this.cbApproved.TabIndex = 11;
            this.cbApproved.Text = "Approved";
            this.cbApproved.UseVisualStyleBackColor = true;
            // 
            // lblCalculation
            // 
            this.lblCalculation.AutoSize = true;
            this.lblCalculation.Location = new System.Drawing.Point(15, 138);
            this.lblCalculation.Name = "lblCalculation";
            this.lblCalculation.Size = new System.Drawing.Size(59, 13);
            this.lblCalculation.TabIndex = 14;
            this.lblCalculation.Text = "Calculation";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(162, 171);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 15;
            this.lblNotes.Text = "label1";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(165, 188);
            this.txtNotes.MaxLength = 60;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(227, 80);
            this.txtNotes.TabIndex = 16;
            // 
            // StaffRequestLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 325);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblCalculation);
            this.Controls.Add(this.cbApproved);
            this.Controls.Add(this.cbAuthorised);
            this.Controls.Add(this.lblRemaining);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRequest);
            this.Controls.Add(this.cbFullDay);
            this.Controls.Add(this.cmbStaff);
            this.Controls.Add(this.lblStaffMember);
            this.Controls.Add(this.dtpDateTo);
            this.Controls.Add(this.lblDateTo);
            this.Controls.Add(this.dtpDateFrom);
            this.Controls.Add(this.lblDateFrom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StaffRequestLeave";
            this.Text = "StaffRequestLeave";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label lblStaffMember;
        private System.Windows.Forms.ComboBox cmbStaff;
        private System.Windows.Forms.CheckBox cbFullDay;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.CheckBox cbAuthorised;
        private System.Windows.Forms.CheckBox cbApproved;
        private System.Windows.Forms.Label lblCalculation;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
    }
}