namespace SalonDiary.WizardSteps
{
    partial class NewCourseStep3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCourseStep3));
            this.lblReviewDesc = new System.Windows.Forms.Label();
            this.lblCourseName = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblConsecutive = new System.Windows.Forms.Label();
            this.lblTrainer = new System.Windows.Forms.Label();
            this.lblExcludeSaturday = new System.Windows.Forms.Label();
            this.lblExcludeSunday = new System.Windows.Forms.Label();
            this.lblFinishDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblReviewDesc
            // 
            this.lblReviewDesc.AutoSize = true;
            this.lblReviewDesc.Location = new System.Drawing.Point(4, 4);
            this.lblReviewDesc.Name = "lblReviewDesc";
            this.lblReviewDesc.Size = new System.Drawing.Size(216, 13);
            this.lblReviewDesc.TabIndex = 0;
            this.lblReviewDesc.Text = "Please review the options you have chosen:";
            // 
            // lblCourseName
            // 
            this.lblCourseName.AutoSize = true;
            this.lblCourseName.Location = new System.Drawing.Point(30, 35);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(91, 13);
            this.lblCourseName.TabIndex = 1;
            this.lblCourseName.Text = "Course Name: {0}";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(30, 85);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(75, 13);
            this.lblStartDate.TabIndex = 3;
            this.lblStartDate.Text = "Start Date: {0}";
            // 
            // lblConsecutive
            // 
            this.lblConsecutive.AutoSize = true;
            this.lblConsecutive.Location = new System.Drawing.Point(30, 110);
            this.lblConsecutive.Name = "lblConsecutive";
            this.lblConsecutive.Size = new System.Drawing.Size(113, 13);
            this.lblConsecutive.TabIndex = 4;
            this.lblConsecutive.Text = "Consecutive Days: {0}";
            // 
            // lblTrainer
            // 
            this.lblTrainer.AutoSize = true;
            this.lblTrainer.Location = new System.Drawing.Point(30, 60);
            this.lblTrainer.Name = "lblTrainer";
            this.lblTrainer.Size = new System.Drawing.Size(60, 13);
            this.lblTrainer.TabIndex = 2;
            this.lblTrainer.Text = "Trainer: {0}";
            // 
            // lblExcludeSaturday
            // 
            this.lblExcludeSaturday.AutoSize = true;
            this.lblExcludeSaturday.Location = new System.Drawing.Point(30, 135);
            this.lblExcludeSaturday.Name = "lblExcludeSaturday";
            this.lblExcludeSaturday.Size = new System.Drawing.Size(110, 13);
            this.lblExcludeSaturday.TabIndex = 5;
            this.lblExcludeSaturday.Text = "Exclude Saturday: {0}";
            // 
            // lblExcludeSunday
            // 
            this.lblExcludeSunday.AutoSize = true;
            this.lblExcludeSunday.Location = new System.Drawing.Point(30, 160);
            this.lblExcludeSunday.Name = "lblExcludeSunday";
            this.lblExcludeSunday.Size = new System.Drawing.Size(104, 13);
            this.lblExcludeSunday.TabIndex = 6;
            this.lblExcludeSunday.Text = "Exclude Sunday: {0}";
            // 
            // lblFinishDesc
            // 
            this.lblFinishDesc.AutoSize = true;
            this.lblFinishDesc.Location = new System.Drawing.Point(7, 250);
            this.lblFinishDesc.Name = "lblFinishDesc";
            this.lblFinishDesc.Size = new System.Drawing.Size(161, 13);
            this.lblFinishDesc.TabIndex = 7;
            this.lblFinishDesc.Text = "Click Finish to create the course.";
            // 
            // NewCourseStep3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFinishDesc);
            this.Controls.Add(this.lblExcludeSunday);
            this.Controls.Add(this.lblExcludeSaturday);
            this.Controls.Add(this.lblTrainer);
            this.Controls.Add(this.lblConsecutive);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblCourseName);
            this.Controls.Add(this.lblReviewDesc);
            this.Name = "NewCourseStep3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReviewDesc;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblConsecutive;
        private System.Windows.Forms.Label lblTrainer;
        private System.Windows.Forms.Label lblExcludeSaturday;
        private System.Windows.Forms.Label lblExcludeSunday;
        private System.Windows.Forms.Label lblFinishDesc;
    }
}
