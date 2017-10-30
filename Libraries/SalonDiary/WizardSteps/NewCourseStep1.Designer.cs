namespace SalonDiary.WizardSteps
{
    partial class NewCourseStep1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCourseStep1));
            this.lblCourseSelect = new System.Windows.Forms.Label();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.cmbTrainer = new System.Windows.Forms.ComboBox();
            this.lblCourseTrainer = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.cbConsecutiveDays = new System.Windows.Forms.CheckBox();
            this.cbExcludeSaturday = new System.Windows.Forms.CheckBox();
            this.cbExcludeSunday = new System.Windows.Forms.CheckBox();
            this.cbAutoExtendStaffHours = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblCourseSelect
            // 
            this.lblCourseSelect.AutoSize = true;
            this.lblCourseSelect.Location = new System.Drawing.Point(4, 4);
            this.lblCourseSelect.Name = "lblCourseSelect";
            this.lblCourseSelect.Size = new System.Drawing.Size(114, 13);
            this.lblCourseSelect.TabIndex = 0;
            this.lblCourseSelect.Text = "Select Training Course";
            // 
            // cmbCourse
            // 
            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(7, 21);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(392, 21);
            this.cmbCourse.TabIndex = 1;
            this.cmbCourse.SelectedIndexChanged += new System.EventHandler(this.cmbCourse_SelectedIndexChanged);
            this.cmbCourse.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbCourse_Format);
            // 
            // cmbTrainer
            // 
            this.cmbTrainer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrainer.FormattingEnabled = true;
            this.cmbTrainer.Location = new System.Drawing.Point(7, 83);
            this.cmbTrainer.Name = "cmbTrainer";
            this.cmbTrainer.Size = new System.Drawing.Size(392, 21);
            this.cmbTrainer.TabIndex = 3;
            this.cmbTrainer.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbTrainer_Format);
            // 
            // lblCourseTrainer
            // 
            this.lblCourseTrainer.AutoSize = true;
            this.lblCourseTrainer.Location = new System.Drawing.Point(4, 66);
            this.lblCourseTrainer.Name = "lblCourseTrainer";
            this.lblCourseTrainer.Size = new System.Drawing.Size(73, 13);
            this.lblCourseTrainer.TabIndex = 2;
            this.lblCourseTrainer.Text = "Select Trainer";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(4, 125);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(55, 13);
            this.lblStartDate.TabIndex = 4;
            this.lblStartDate.Text = "Start Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(7, 142);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpStartDate.TabIndex = 5;
            // 
            // cbConsecutiveDays
            // 
            this.cbConsecutiveDays.AutoSize = true;
            this.cbConsecutiveDays.Checked = true;
            this.cbConsecutiveDays.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbConsecutiveDays.Location = new System.Drawing.Point(7, 180);
            this.cbConsecutiveDays.Name = "cbConsecutiveDays";
            this.cbConsecutiveDays.Size = new System.Drawing.Size(153, 17);
            this.cbConsecutiveDays.TabIndex = 6;
            this.cbConsecutiveDays.Text = "Consecutive Training Days";
            this.cbConsecutiveDays.UseVisualStyleBackColor = true;
            // 
            // cbExcludeSaturday
            // 
            this.cbExcludeSaturday.AutoSize = true;
            this.cbExcludeSaturday.Location = new System.Drawing.Point(7, 204);
            this.cbExcludeSaturday.Name = "cbExcludeSaturday";
            this.cbExcludeSaturday.Size = new System.Drawing.Size(109, 17);
            this.cbExcludeSaturday.TabIndex = 7;
            this.cbExcludeSaturday.Text = "Exclude Saturday";
            this.cbExcludeSaturday.UseVisualStyleBackColor = true;
            // 
            // cbExcludeSunday
            // 
            this.cbExcludeSunday.AutoSize = true;
            this.cbExcludeSunday.Location = new System.Drawing.Point(7, 228);
            this.cbExcludeSunday.Name = "cbExcludeSunday";
            this.cbExcludeSunday.Size = new System.Drawing.Size(103, 17);
            this.cbExcludeSunday.TabIndex = 8;
            this.cbExcludeSunday.Text = "Exclude Sunday";
            this.cbExcludeSunday.UseVisualStyleBackColor = true;
            // 
            // cbAutoExtendStaffHours
            // 
            this.cbAutoExtendStaffHours.AutoSize = true;
            this.cbAutoExtendStaffHours.Checked = true;
            this.cbAutoExtendStaffHours.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoExtendStaffHours.Location = new System.Drawing.Point(7, 252);
            this.cbAutoExtendStaffHours.Name = "cbAutoExtendStaffHours";
            this.cbAutoExtendStaffHours.Size = new System.Drawing.Size(171, 17);
            this.cbAutoExtendStaffHours.TabIndex = 9;
            this.cbAutoExtendStaffHours.Text = "Automatically adjust staff hours";
            this.cbAutoExtendStaffHours.UseVisualStyleBackColor = true;
            // 
            // NewCourseStep1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbAutoExtendStaffHours);
            this.Controls.Add(this.cbExcludeSunday);
            this.Controls.Add(this.cbExcludeSaturday);
            this.Controls.Add(this.cbConsecutiveDays);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.cmbTrainer);
            this.Controls.Add(this.lblCourseTrainer);
            this.Controls.Add(this.cmbCourse);
            this.Controls.Add(this.lblCourseSelect);
            this.Name = "NewCourseStep1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCourseSelect;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.ComboBox cmbTrainer;
        private System.Windows.Forms.Label lblCourseTrainer;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.CheckBox cbConsecutiveDays;
        private System.Windows.Forms.CheckBox cbExcludeSaturday;
        private System.Windows.Forms.CheckBox cbExcludeSunday;
        private System.Windows.Forms.CheckBox cbAutoExtendStaffHours;
    }
}
