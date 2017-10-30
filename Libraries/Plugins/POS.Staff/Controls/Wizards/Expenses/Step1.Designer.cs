namespace POS.Staff.Controls.Wizards.Expenses
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
            this.lblSelectNewStaffMember = new System.Windows.Forms.Label();
            this.cmbStaff = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblSelectNewStaffMember
            // 
            this.lblSelectNewStaffMember.AutoSize = true;
            this.lblSelectNewStaffMember.Location = new System.Drawing.Point(3, 13);
            this.lblSelectNewStaffMember.Name = "lblSelectNewStaffMember";
            this.lblSelectNewStaffMember.Size = new System.Drawing.Size(128, 13);
            this.lblSelectNewStaffMember.TabIndex = 3;
            this.lblSelectNewStaffMember.Text = "Select New Staff Member";
            // 
            // cmbStaff
            // 
            this.cmbStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaff.FormattingEnabled = true;
            this.cmbStaff.Location = new System.Drawing.Point(6, 29);
            this.cmbStaff.Name = "cmbStaff";
            this.cmbStaff.Size = new System.Drawing.Size(318, 21);
            this.cmbStaff.TabIndex = 4;
            this.cmbStaff.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbStaff_Format);
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbStaff);
            this.Controls.Add(this.lblSelectNewStaffMember);
            this.Name = "Step1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSelectNewStaffMember;
        private System.Windows.Forms.ComboBox cmbStaff;
    }
}
