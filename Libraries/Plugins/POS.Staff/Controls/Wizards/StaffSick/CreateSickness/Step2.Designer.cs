namespace POS.Staff.Controls.Wizards.StaffSick.CreateSickness
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
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateNotified = new System.Windows.Forms.Label();
            this.dtpDateNotified = new System.Windows.Forms.DateTimePicker();
            this.cbPreBooked = new System.Windows.Forms.CheckBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.cbCertificateProvided = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(6, 40);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpDateFrom.TabIndex = 1;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(6, 21);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(35, 13);
            this.lblDateFrom.TabIndex = 0;
            this.lblDateFrom.Text = "label1";
            // 
            // lblDateNotified
            // 
            this.lblDateNotified.AutoSize = true;
            this.lblDateNotified.Location = new System.Drawing.Point(6, 77);
            this.lblDateNotified.Name = "lblDateNotified";
            this.lblDateNotified.Size = new System.Drawing.Size(35, 13);
            this.lblDateNotified.TabIndex = 2;
            this.lblDateNotified.Text = "label1";
            // 
            // dtpDateNotified
            // 
            this.dtpDateNotified.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateNotified.Location = new System.Drawing.Point(6, 96);
            this.dtpDateNotified.Name = "dtpDateNotified";
            this.dtpDateNotified.Size = new System.Drawing.Size(200, 20);
            this.dtpDateNotified.TabIndex = 3;
            // 
            // cbPreBooked
            // 
            this.cbPreBooked.AutoSize = true;
            this.cbPreBooked.Location = new System.Drawing.Point(338, 41);
            this.cbPreBooked.Name = "cbPreBooked";
            this.cbPreBooked.Size = new System.Drawing.Size(80, 17);
            this.cbPreBooked.TabIndex = 4;
            this.cbPreBooked.Text = "checkBox1";
            this.cbPreBooked.UseVisualStyleBackColor = true;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(6, 138);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(35, 13);
            this.lblReason.TabIndex = 6;
            this.lblReason.Text = "label1";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(6, 155);
            this.txtReason.MaxLength = 400;
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(557, 198);
            this.txtReason.TabIndex = 7;
            // 
            // cbCertificateProvided
            // 
            this.cbCertificateProvided.AutoSize = true;
            this.cbCertificateProvided.Location = new System.Drawing.Point(338, 65);
            this.cbCertificateProvided.Name = "cbCertificateProvided";
            this.cbCertificateProvided.Size = new System.Drawing.Size(80, 17);
            this.cbCertificateProvided.TabIndex = 5;
            this.cbCertificateProvided.Text = "checkBox1";
            this.cbCertificateProvided.UseVisualStyleBackColor = true;
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbCertificateProvided);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.cbPreBooked);
            this.Controls.Add(this.lblDateNotified);
            this.Controls.Add(this.dtpDateNotified);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.dtpDateFrom);
            this.Name = "Step1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateNotified;
        private System.Windows.Forms.DateTimePicker dtpDateNotified;
        private System.Windows.Forms.CheckBox cbPreBooked;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.CheckBox cbCertificateProvided;

    }
}
