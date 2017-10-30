namespace POS.Staff.Controls.Wizards.StaffSick.ReturnFromSickness
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
            this.lblDateReturned = new System.Windows.Forms.Label();
            this.dtpDateReturned = new System.Windows.Forms.DateTimePicker();
            this.cbCertificateProvided = new System.Windows.Forms.CheckBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.cbRTWInterviewCompleted = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblDateReturned
            // 
            this.lblDateReturned.AutoSize = true;
            this.lblDateReturned.Location = new System.Drawing.Point(6, 11);
            this.lblDateReturned.Name = "lblDateReturned";
            this.lblDateReturned.Size = new System.Drawing.Size(35, 13);
            this.lblDateReturned.TabIndex = 0;
            this.lblDateReturned.Text = "label1";
            // 
            // dtpDateReturned
            // 
            this.dtpDateReturned.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateReturned.Location = new System.Drawing.Point(6, 30);
            this.dtpDateReturned.Name = "dtpDateReturned";
            this.dtpDateReturned.Size = new System.Drawing.Size(200, 20);
            this.dtpDateReturned.TabIndex = 1;
            // 
            // cbCertificateProvided
            // 
            this.cbCertificateProvided.AutoSize = true;
            this.cbCertificateProvided.Location = new System.Drawing.Point(237, 30);
            this.cbCertificateProvided.Name = "cbCertificateProvided";
            this.cbCertificateProvided.Size = new System.Drawing.Size(80, 17);
            this.cbCertificateProvided.TabIndex = 2;
            this.cbCertificateProvided.Text = "checkBox1";
            this.cbCertificateProvided.UseVisualStyleBackColor = true;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(6, 71);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 4;
            this.lblNotes.Text = "label1";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(6, 88);
            this.txtNotes.MaxLength = 1000;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(557, 265);
            this.txtNotes.TabIndex = 5;
            // 
            // cbRTWInterviewCompleted
            // 
            this.cbRTWInterviewCompleted.AutoSize = true;
            this.cbRTWInterviewCompleted.Location = new System.Drawing.Point(237, 53);
            this.cbRTWInterviewCompleted.Name = "cbRTWInterviewCompleted";
            this.cbRTWInterviewCompleted.Size = new System.Drawing.Size(80, 17);
            this.cbRTWInterviewCompleted.TabIndex = 3;
            this.cbRTWInterviewCompleted.Text = "checkBox1";
            this.cbRTWInterviewCompleted.UseVisualStyleBackColor = true;
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbRTWInterviewCompleted);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.cbCertificateProvided);
            this.Controls.Add(this.lblDateReturned);
            this.Controls.Add(this.dtpDateReturned);
            this.Name = "Step1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDateReturned;
        private System.Windows.Forms.DateTimePicker dtpDateReturned;
        private System.Windows.Forms.CheckBox cbCertificateProvided;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.CheckBox cbRTWInterviewCompleted;
    }
}
