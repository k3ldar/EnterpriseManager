namespace POS.Staff.Controls.Wizards.StaffSick.CreateSickness
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
            this.lblStaffMember = new System.Windows.Forms.Label();
            this.cmbStaffMember = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblStaffMember
            // 
            this.lblStaffMember.AutoSize = true;
            this.lblStaffMember.Location = new System.Drawing.Point(4, 4);
            this.lblStaffMember.Name = "lblStaffMember";
            this.lblStaffMember.Size = new System.Drawing.Size(35, 13);
            this.lblStaffMember.TabIndex = 0;
            this.lblStaffMember.Text = "label1";
            // 
            // cmbStaffMember
            // 
            this.cmbStaffMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaffMember.FormattingEnabled = true;
            this.cmbStaffMember.Location = new System.Drawing.Point(7, 21);
            this.cmbStaffMember.Name = "cmbStaffMember";
            this.cmbStaffMember.Size = new System.Drawing.Size(282, 21);
            this.cmbStaffMember.TabIndex = 1;
            this.cmbStaffMember.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbStaffMember_Format);
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbStaffMember);
            this.Controls.Add(this.lblStaffMember);
            this.Name = "Step1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStaffMember;
        private System.Windows.Forms.ComboBox cmbStaffMember;
    }
}
