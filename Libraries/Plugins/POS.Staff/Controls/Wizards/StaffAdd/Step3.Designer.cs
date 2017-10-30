namespace POS.Staff.Controls.Wizards.StaffAdd
{
    partial class Step3
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
            this.cmbEmploymentType = new System.Windows.Forms.ComboBox();
            this.lblEmploymentType = new System.Windows.Forms.Label();
            this.dtpDateProbationEnds = new System.Windows.Forms.DateTimePicker();
            this.lblDateProbationEnds = new System.Windows.Forms.Label();
            this.dtpDatePermanent = new System.Windows.Forms.DateTimePicker();
            this.lblDatePermanent = new System.Windows.Forms.Label();
            this.dtpDateJoined = new System.Windows.Forms.DateTimePicker();
            this.lblDateJoined = new System.Windows.Forms.Label();
            this.udWeeklyHours = new System.Windows.Forms.NumericUpDown();
            this.lblWeeklyHours = new System.Windows.Forms.Label();
            this.cmbPayPeriod = new System.Windows.Forms.ComboBox();
            this.lblPayPeriod = new System.Windows.Forms.Label();
            this.txtPayrollNumber = new System.Windows.Forms.TextBox();
            this.lblPayrollNumber = new System.Windows.Forms.Label();
            this.cbPartTime = new System.Windows.Forms.CheckBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.lblJobTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udWeeklyHours)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEmploymentType
            // 
            this.cmbEmploymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmploymentType.FormattingEnabled = true;
            this.cmbEmploymentType.Location = new System.Drawing.Point(3, 317);
            this.cmbEmploymentType.Name = "cmbEmploymentType";
            this.cmbEmploymentType.Size = new System.Drawing.Size(214, 21);
            this.cmbEmploymentType.TabIndex = 12;
            // 
            // lblEmploymentType
            // 
            this.lblEmploymentType.AutoSize = true;
            this.lblEmploymentType.Location = new System.Drawing.Point(3, 301);
            this.lblEmploymentType.Name = "lblEmploymentType";
            this.lblEmploymentType.Size = new System.Drawing.Size(91, 13);
            this.lblEmploymentType.TabIndex = 11;
            this.lblEmploymentType.Text = "Employment Type";
            // 
            // dtpDateProbationEnds
            // 
            this.dtpDateProbationEnds.Location = new System.Drawing.Point(292, 321);
            this.dtpDateProbationEnds.Name = "dtpDateProbationEnds";
            this.dtpDateProbationEnds.Size = new System.Drawing.Size(200, 20);
            this.dtpDateProbationEnds.TabIndex = 18;
            // 
            // lblDateProbationEnds
            // 
            this.lblDateProbationEnds.AutoSize = true;
            this.lblDateProbationEnds.Location = new System.Drawing.Point(292, 305);
            this.lblDateProbationEnds.Name = "lblDateProbationEnds";
            this.lblDateProbationEnds.Size = new System.Drawing.Size(105, 13);
            this.lblDateProbationEnds.TabIndex = 17;
            this.lblDateProbationEnds.Text = "Date Probation Ends";
            // 
            // dtpDatePermanent
            // 
            this.dtpDatePermanent.Location = new System.Drawing.Point(292, 267);
            this.dtpDatePermanent.Name = "dtpDatePermanent";
            this.dtpDatePermanent.Size = new System.Drawing.Size(200, 20);
            this.dtpDatePermanent.TabIndex = 16;
            // 
            // lblDatePermanent
            // 
            this.lblDatePermanent.AutoSize = true;
            this.lblDatePermanent.Location = new System.Drawing.Point(292, 250);
            this.lblDatePermanent.Name = "lblDatePermanent";
            this.lblDatePermanent.Size = new System.Drawing.Size(84, 13);
            this.lblDatePermanent.TabIndex = 15;
            this.lblDatePermanent.Text = "Date Permanent";
            // 
            // dtpDateJoined
            // 
            this.dtpDateJoined.Location = new System.Drawing.Point(292, 213);
            this.dtpDateJoined.Name = "dtpDateJoined";
            this.dtpDateJoined.Size = new System.Drawing.Size(200, 20);
            this.dtpDateJoined.TabIndex = 14;
            this.dtpDateJoined.ValueChanged += new System.EventHandler(this.dtpDateJoined_ValueChanged);
            // 
            // lblDateJoined
            // 
            this.lblDateJoined.AutoSize = true;
            this.lblDateJoined.Location = new System.Drawing.Point(292, 196);
            this.lblDateJoined.Name = "lblDateJoined";
            this.lblDateJoined.Size = new System.Drawing.Size(64, 13);
            this.lblDateJoined.TabIndex = 13;
            this.lblDateJoined.Text = "Date Joined";
            // 
            // udWeeklyHours
            // 
            this.udWeeklyHours.DecimalPlaces = 1;
            this.udWeeklyHours.Location = new System.Drawing.Point(3, 157);
            this.udWeeklyHours.Name = "udWeeklyHours";
            this.udWeeklyHours.Size = new System.Drawing.Size(80, 20);
            this.udWeeklyHours.TabIndex = 6;
            // 
            // lblWeeklyHours
            // 
            this.lblWeeklyHours.AutoSize = true;
            this.lblWeeklyHours.Location = new System.Drawing.Point(3, 141);
            this.lblWeeklyHours.Name = "lblWeeklyHours";
            this.lblWeeklyHours.Size = new System.Drawing.Size(74, 13);
            this.lblWeeklyHours.TabIndex = 5;
            this.lblWeeklyHours.Text = "Weekly Hours";
            // 
            // cmbPayPeriod
            // 
            this.cmbPayPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayPeriod.FormattingEnabled = true;
            this.cmbPayPeriod.Location = new System.Drawing.Point(3, 267);
            this.cmbPayPeriod.Name = "cmbPayPeriod";
            this.cmbPayPeriod.Size = new System.Drawing.Size(214, 21);
            this.cmbPayPeriod.TabIndex = 10;
            // 
            // lblPayPeriod
            // 
            this.lblPayPeriod.AutoSize = true;
            this.lblPayPeriod.Location = new System.Drawing.Point(3, 250);
            this.lblPayPeriod.Name = "lblPayPeriod";
            this.lblPayPeriod.Size = new System.Drawing.Size(58, 13);
            this.lblPayPeriod.TabIndex = 9;
            this.lblPayPeriod.Text = "Pay Period";
            // 
            // txtPayrollNumber
            // 
            this.txtPayrollNumber.Location = new System.Drawing.Point(3, 213);
            this.txtPayrollNumber.Name = "txtPayrollNumber";
            this.txtPayrollNumber.Size = new System.Drawing.Size(214, 20);
            this.txtPayrollNumber.TabIndex = 8;
            // 
            // lblPayrollNumber
            // 
            this.lblPayrollNumber.AutoSize = true;
            this.lblPayrollNumber.Location = new System.Drawing.Point(3, 196);
            this.lblPayrollNumber.Name = "lblPayrollNumber";
            this.lblPayrollNumber.Size = new System.Drawing.Size(78, 13);
            this.lblPayrollNumber.TabIndex = 7;
            this.lblPayrollNumber.Text = "Payroll Number";
            // 
            // cbPartTime
            // 
            this.cbPartTime.AutoSize = true;
            this.cbPartTime.Location = new System.Drawing.Point(3, 109);
            this.cbPartTime.Name = "cbPartTime";
            this.cbPartTime.Size = new System.Drawing.Size(71, 17);
            this.cbPartTime.TabIndex = 4;
            this.cbPartTime.Text = "Part Time";
            this.cbPartTime.UseVisualStyleBackColor = true;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(3, 70);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(353, 20);
            this.txtLocation.TabIndex = 3;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(3, 53);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 2;
            this.lblLocation.Text = "Location";
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.Location = new System.Drawing.Point(3, 17);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.Size = new System.Drawing.Size(353, 20);
            this.txtJobTitle.TabIndex = 1;
            // 
            // lblJobTitle
            // 
            this.lblJobTitle.AutoSize = true;
            this.lblJobTitle.Location = new System.Drawing.Point(3, 0);
            this.lblJobTitle.Name = "lblJobTitle";
            this.lblJobTitle.Size = new System.Drawing.Size(47, 13);
            this.lblJobTitle.TabIndex = 0;
            this.lblJobTitle.Text = "Job Title";
            // 
            // Step3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbEmploymentType);
            this.Controls.Add(this.lblEmploymentType);
            this.Controls.Add(this.dtpDateProbationEnds);
            this.Controls.Add(this.lblDateProbationEnds);
            this.Controls.Add(this.dtpDatePermanent);
            this.Controls.Add(this.lblDatePermanent);
            this.Controls.Add(this.dtpDateJoined);
            this.Controls.Add(this.lblDateJoined);
            this.Controls.Add(this.udWeeklyHours);
            this.Controls.Add(this.lblWeeklyHours);
            this.Controls.Add(this.cmbPayPeriod);
            this.Controls.Add(this.lblPayPeriod);
            this.Controls.Add(this.txtPayrollNumber);
            this.Controls.Add(this.lblPayrollNumber);
            this.Controls.Add(this.cbPartTime);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.txtJobTitle);
            this.Controls.Add(this.lblJobTitle);
            this.Name = "Step3";
            ((System.ComponentModel.ISupportInitialize)(this.udWeeklyHours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEmploymentType;
        private System.Windows.Forms.Label lblEmploymentType;
        private System.Windows.Forms.DateTimePicker dtpDateProbationEnds;
        private System.Windows.Forms.Label lblDateProbationEnds;
        private System.Windows.Forms.DateTimePicker dtpDatePermanent;
        private System.Windows.Forms.Label lblDatePermanent;
        private System.Windows.Forms.DateTimePicker dtpDateJoined;
        private System.Windows.Forms.Label lblDateJoined;
        private System.Windows.Forms.NumericUpDown udWeeklyHours;
        private System.Windows.Forms.Label lblWeeklyHours;
        private System.Windows.Forms.ComboBox cmbPayPeriod;
        private System.Windows.Forms.Label lblPayPeriod;
        private System.Windows.Forms.TextBox txtPayrollNumber;
        private System.Windows.Forms.Label lblPayrollNumber;
        private System.Windows.Forms.CheckBox cbPartTime;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtJobTitle;
        private System.Windows.Forms.Label lblJobTitle;
    }
}
