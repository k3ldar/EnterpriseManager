namespace POS.Staff.Controls.Wizards.StaffAdd
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
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtStaffMemberName = new System.Windows.Forms.TextBox();
            this.lblSelectNewStaffMember = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(459, 15);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(91, 23);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "button1";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtStaffMemberName
            // 
            this.txtStaffMemberName.Location = new System.Drawing.Point(6, 17);
            this.txtStaffMemberName.Name = "txtStaffMemberName";
            this.txtStaffMemberName.ReadOnly = true;
            this.txtStaffMemberName.Size = new System.Drawing.Size(447, 20);
            this.txtStaffMemberName.TabIndex = 1;
            // 
            // lblSelectNewStaffMember
            // 
            this.lblSelectNewStaffMember.AutoSize = true;
            this.lblSelectNewStaffMember.Location = new System.Drawing.Point(3, 0);
            this.lblSelectNewStaffMember.Name = "lblSelectNewStaffMember";
            this.lblSelectNewStaffMember.Size = new System.Drawing.Size(128, 13);
            this.lblSelectNewStaffMember.TabIndex = 0;
            this.lblSelectNewStaffMember.Text = "Select New Staff Member";
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtStaffMemberName);
            this.Controls.Add(this.lblSelectNewStaffMember);
            this.Name = "Step1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtStaffMemberName;
        private System.Windows.Forms.Label lblSelectNewStaffMember;


    }
}
