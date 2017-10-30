namespace SalonDiary.Controls.Wizards.WaitingListWizard
{
    partial class Step3
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
            this.lblPreferredDate = new System.Windows.Forms.Label();
            this.calPreferredDate = new System.Windows.Forms.MonthCalendar();
            this.lblPreferredTime = new System.Windows.Forms.Label();
            this.cmbPreferredTime = new System.Windows.Forms.ComboBox();
            this.lblPreferredStaff = new System.Windows.Forms.Label();
            this.cmbStaffMembers = new System.Windows.Forms.ComboBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblPreferredDate
            // 
            this.lblPreferredDate.AutoSize = true;
            this.lblPreferredDate.Location = new System.Drawing.Point(4, 4);
            this.lblPreferredDate.Name = "lblPreferredDate";
            this.lblPreferredDate.Size = new System.Drawing.Size(76, 13);
            this.lblPreferredDate.TabIndex = 0;
            this.lblPreferredDate.Text = "Preferred Date";
            // 
            // calPreferredDate
            // 
            this.calPreferredDate.Location = new System.Drawing.Point(7, 21);
            this.calPreferredDate.Name = "calPreferredDate";
            this.calPreferredDate.TabIndex = 1;
            // 
            // lblPreferredTime
            // 
            this.lblPreferredTime.AutoSize = true;
            this.lblPreferredTime.Location = new System.Drawing.Point(262, 4);
            this.lblPreferredTime.Name = "lblPreferredTime";
            this.lblPreferredTime.Size = new System.Drawing.Size(76, 13);
            this.lblPreferredTime.TabIndex = 2;
            this.lblPreferredTime.Text = "Preferred Time";
            // 
            // cmbPreferredTime
            // 
            this.cmbPreferredTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPreferredTime.FormattingEnabled = true;
            this.cmbPreferredTime.Location = new System.Drawing.Point(265, 21);
            this.cmbPreferredTime.Name = "cmbPreferredTime";
            this.cmbPreferredTime.Size = new System.Drawing.Size(142, 21);
            this.cmbPreferredTime.TabIndex = 3;
            this.cmbPreferredTime.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbPreferredTime_Format);
            // 
            // lblPreferredStaff
            // 
            this.lblPreferredStaff.AutoSize = true;
            this.lblPreferredStaff.Location = new System.Drawing.Point(262, 68);
            this.lblPreferredStaff.Name = "lblPreferredStaff";
            this.lblPreferredStaff.Size = new System.Drawing.Size(116, 13);
            this.lblPreferredStaff.TabIndex = 4;
            this.lblPreferredStaff.Text = "Preferred Staff Member";
            // 
            // cmbStaffMembers
            // 
            this.cmbStaffMembers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaffMembers.FormattingEnabled = true;
            this.cmbStaffMembers.Location = new System.Drawing.Point(265, 84);
            this.cmbStaffMembers.Name = "cmbStaffMembers";
            this.cmbStaffMembers.Size = new System.Drawing.Size(298, 21);
            this.cmbStaffMembers.TabIndex = 5;
            this.cmbStaffMembers.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbStaffMembers_Format);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(4, 192);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 6;
            this.lblNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(7, 209);
            this.txtNotes.MaxLength = 5000;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(556, 144);
            this.txtNotes.TabIndex = 7;
            // 
            // Step3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.cmbStaffMembers);
            this.Controls.Add(this.lblPreferredStaff);
            this.Controls.Add(this.cmbPreferredTime);
            this.Controls.Add(this.lblPreferredTime);
            this.Controls.Add(this.calPreferredDate);
            this.Controls.Add(this.lblPreferredDate);
            this.Name = "Step3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPreferredDate;
        private System.Windows.Forms.MonthCalendar calPreferredDate;
        private System.Windows.Forms.Label lblPreferredTime;
        private System.Windows.Forms.ComboBox cmbPreferredTime;
        private System.Windows.Forms.Label lblPreferredStaff;
        private System.Windows.Forms.ComboBox cmbStaffMembers;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
    }
}
