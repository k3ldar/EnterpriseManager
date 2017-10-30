namespace SalonDiary.Controls.Wizards.NewAppointmentWizard
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.lblPreferredDate = new System.Windows.Forms.Label();
            this.lblPreferredStartTime = new System.Windows.Forms.Label();
            this.cmbStartTime = new System.Windows.Forms.ComboBox();
            this.lblPreferredTherapist = new System.Windows.Forms.Label();
            this.cmbTherapist = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(7, 31);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // lblPreferredDate
            // 
            this.lblPreferredDate.AutoSize = true;
            this.lblPreferredDate.Location = new System.Drawing.Point(4, 9);
            this.lblPreferredDate.Name = "lblPreferredDate";
            this.lblPreferredDate.Size = new System.Drawing.Size(76, 13);
            this.lblPreferredDate.TabIndex = 1;
            this.lblPreferredDate.Text = "Preferred Time";
            // 
            // lblPreferredStartTime
            // 
            this.lblPreferredStartTime.AutoSize = true;
            this.lblPreferredStartTime.Location = new System.Drawing.Point(7, 219);
            this.lblPreferredStartTime.Name = "lblPreferredStartTime";
            this.lblPreferredStartTime.Size = new System.Drawing.Size(101, 13);
            this.lblPreferredStartTime.TabIndex = 2;
            this.lblPreferredStartTime.Text = "Preferred Start Time";
            // 
            // cmbStartTime
            // 
            this.cmbStartTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartTime.FormattingEnabled = true;
            this.cmbStartTime.Location = new System.Drawing.Point(10, 236);
            this.cmbStartTime.Name = "cmbStartTime";
            this.cmbStartTime.Size = new System.Drawing.Size(224, 21);
            this.cmbStartTime.TabIndex = 3;
            // 
            // lblPreferredTherapist
            // 
            this.lblPreferredTherapist.AutoSize = true;
            this.lblPreferredTherapist.Location = new System.Drawing.Point(302, 9);
            this.lblPreferredTherapist.Name = "lblPreferredTherapist";
            this.lblPreferredTherapist.Size = new System.Drawing.Size(51, 13);
            this.lblPreferredTherapist.TabIndex = 4;
            this.lblPreferredTherapist.Text = "Therapist";
            // 
            // cmbTherapist
            // 
            this.cmbTherapist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTherapist.FormattingEnabled = true;
            this.cmbTherapist.Location = new System.Drawing.Point(305, 31);
            this.cmbTherapist.Name = "cmbTherapist";
            this.cmbTherapist.Size = new System.Drawing.Size(258, 21);
            this.cmbTherapist.TabIndex = 5;
            this.cmbTherapist.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbTherapist_Format);
            // 
            // Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbTherapist);
            this.Controls.Add(this.lblPreferredTherapist);
            this.Controls.Add(this.cmbStartTime);
            this.Controls.Add(this.lblPreferredStartTime);
            this.Controls.Add(this.lblPreferredDate);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "Step2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label lblPreferredDate;
        private System.Windows.Forms.Label lblPreferredStartTime;
        private System.Windows.Forms.ComboBox cmbStartTime;
        private System.Windows.Forms.Label lblPreferredTherapist;
        private System.Windows.Forms.ComboBox cmbTherapist;
    }
}
