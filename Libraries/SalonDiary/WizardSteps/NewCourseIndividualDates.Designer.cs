namespace SalonDiary.WizardSteps
{
    partial class NewCourseIndividualDates
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
            this.lblDay = new System.Windows.Forms.Label();
            this.dtpCourseDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(3, 11);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(43, 13);
            this.lblDay.TabIndex = 0;
            this.lblDay.Text = "Day {0}";
            // 
            // dtpCourseDate
            // 
            this.dtpCourseDate.Location = new System.Drawing.Point(99, 5);
            this.dtpCourseDate.Name = "dtpCourseDate";
            this.dtpCourseDate.Size = new System.Drawing.Size(183, 20);
            this.dtpCourseDate.TabIndex = 1;
            // 
            // NewCourseIndividualDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpCourseDate);
            this.Controls.Add(this.lblDay);
            this.Name = "NewCourseIndividualDates";
            this.Size = new System.Drawing.Size(285, 36);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.DateTimePicker dtpCourseDate;
    }
}
