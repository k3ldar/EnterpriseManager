namespace POS.Staff.Controls.Wizards.StaffSick.CreateSickness
{
    partial class Summary
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
            this.lblSummary = new System.Windows.Forms.Label();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.lblCancelAppointments = new System.Windows.Forms.Label();
            this.lblRescheduledAppointments = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(3, 0);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(35, 13);
            this.lblSummary.TabIndex = 0;
            this.lblSummary.Text = "label1";
            // 
            // lblStaffName
            // 
            this.lblStaffName.AutoSize = true;
            this.lblStaffName.Location = new System.Drawing.Point(3, 42);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(35, 13);
            this.lblStaffName.TabIndex = 1;
            this.lblStaffName.Text = "label2";
            // 
            // lblCancelAppointments
            // 
            this.lblCancelAppointments.AutoSize = true;
            this.lblCancelAppointments.Location = new System.Drawing.Point(3, 96);
            this.lblCancelAppointments.Name = "lblCancelAppointments";
            this.lblCancelAppointments.Size = new System.Drawing.Size(35, 13);
            this.lblCancelAppointments.TabIndex = 2;
            this.lblCancelAppointments.Text = "label3";
            // 
            // lblRescheduledAppointments
            // 
            this.lblRescheduledAppointments.AutoSize = true;
            this.lblRescheduledAppointments.Location = new System.Drawing.Point(3, 126);
            this.lblRescheduledAppointments.Name = "lblRescheduledAppointments";
            this.lblRescheduledAppointments.Size = new System.Drawing.Size(35, 13);
            this.lblRescheduledAppointments.TabIndex = 3;
            this.lblRescheduledAppointments.Text = "label4";
            // 
            // Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRescheduledAppointments);
            this.Controls.Add(this.lblCancelAppointments);
            this.Controls.Add(this.lblStaffName);
            this.Controls.Add(this.lblSummary);
            this.Name = "Summary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.Label lblCancelAppointments;
        private System.Windows.Forms.Label lblRescheduledAppointments;
    }
}
