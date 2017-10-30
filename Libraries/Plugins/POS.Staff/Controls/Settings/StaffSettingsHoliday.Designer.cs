namespace POS.Staff.Controls.Settings
{
    partial class StaffSettingsHoliday
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
            this.cbAllowBookAcrossYears = new System.Windows.Forms.CheckBox();
            this.lblBookAhead = new System.Windows.Forms.Label();
            this.udBookAhead = new System.Windows.Forms.NumericUpDown();
            this.gbMinTake = new System.Windows.Forms.GroupBox();
            this.udMinTakeHours = new System.Windows.Forms.NumericUpDown();
            this.udMinTakeDays = new System.Windows.Forms.NumericUpDown();
            this.lblMinTakeHours = new System.Windows.Forms.Label();
            this.lblMinTakeDays = new System.Windows.Forms.Label();
            this.gbMaxTake = new System.Windows.Forms.GroupBox();
            this.udMaxTakeHours = new System.Windows.Forms.NumericUpDown();
            this.udMaxTakeDays = new System.Windows.Forms.NumericUpDown();
            this.lblMaxTakeHours = new System.Windows.Forms.Label();
            this.lblMaxTakeDays = new System.Windows.Forms.Label();
            this.gbCarryOver = new System.Windows.Forms.GroupBox();
            this.udCarryOverHours = new System.Windows.Forms.NumericUpDown();
            this.udCarryOverDays = new System.Windows.Forms.NumericUpDown();
            this.lblCarryOverHours = new System.Windows.Forms.Label();
            this.lblCarryOverDays = new System.Windows.Forms.Label();
            this.gbLeaveYear = new System.Windows.Forms.GroupBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblLeaveYearEnds = new System.Windows.Forms.Label();
            this.lblLeaveYearStarts = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udBookAhead)).BeginInit();
            this.gbMinTake.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMinTakeHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMinTakeDays)).BeginInit();
            this.gbMaxTake.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxTakeHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxTakeDays)).BeginInit();
            this.gbCarryOver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udCarryOverHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udCarryOverDays)).BeginInit();
            this.gbLeaveYear.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbAllowBookAcrossYears
            // 
            this.cbAllowBookAcrossYears.AutoSize = true;
            this.cbAllowBookAcrossYears.Location = new System.Drawing.Point(6, 320);
            this.cbAllowBookAcrossYears.Name = "cbAllowBookAcrossYears";
            this.cbAllowBookAcrossYears.Size = new System.Drawing.Size(80, 17);
            this.cbAllowBookAcrossYears.TabIndex = 20;
            this.cbAllowBookAcrossYears.Text = "checkBox1";
            this.cbAllowBookAcrossYears.UseVisualStyleBackColor = true;
            // 
            // lblBookAhead
            // 
            this.lblBookAhead.AutoSize = true;
            this.lblBookAhead.Location = new System.Drawing.Point(3, 277);
            this.lblBookAhead.Name = "lblBookAhead";
            this.lblBookAhead.Size = new System.Drawing.Size(156, 13);
            this.lblBookAhead.TabIndex = 21;
            this.lblBookAhead.Text = "Number of years to book ahead";
            // 
            // udBookAhead
            // 
            this.udBookAhead.Location = new System.Drawing.Point(6, 294);
            this.udBookAhead.Name = "udBookAhead";
            this.udBookAhead.Size = new System.Drawing.Size(120, 20);
            this.udBookAhead.TabIndex = 22;
            // 
            // gbMinTake
            // 
            this.gbMinTake.Controls.Add(this.udMinTakeHours);
            this.gbMinTake.Controls.Add(this.udMinTakeDays);
            this.gbMinTake.Controls.Add(this.lblMinTakeHours);
            this.gbMinTake.Controls.Add(this.lblMinTakeDays);
            this.gbMinTake.Location = new System.Drawing.Point(3, 211);
            this.gbMinTake.Name = "gbMinTake";
            this.gbMinTake.Size = new System.Drawing.Size(375, 63);
            this.gbMinTake.TabIndex = 25;
            this.gbMinTake.TabStop = false;
            this.gbMinTake.Text = "gbMinTake";
            // 
            // udMinTakeHours
            // 
            this.udMinTakeHours.Location = new System.Drawing.Point(223, 35);
            this.udMinTakeHours.Name = "udMinTakeHours";
            this.udMinTakeHours.Size = new System.Drawing.Size(141, 20);
            this.udMinTakeHours.TabIndex = 23;
            // 
            // udMinTakeDays
            // 
            this.udMinTakeDays.Location = new System.Drawing.Point(7, 35);
            this.udMinTakeDays.Name = "udMinTakeDays";
            this.udMinTakeDays.Size = new System.Drawing.Size(144, 20);
            this.udMinTakeDays.TabIndex = 22;
            // 
            // lblMinTakeHours
            // 
            this.lblMinTakeHours.AutoSize = true;
            this.lblMinTakeHours.Location = new System.Drawing.Point(223, 19);
            this.lblMinTakeHours.Name = "lblMinTakeHours";
            this.lblMinTakeHours.Size = new System.Drawing.Size(35, 13);
            this.lblMinTakeHours.TabIndex = 21;
            this.lblMinTakeHours.Text = "Hours";
            // 
            // lblMinTakeDays
            // 
            this.lblMinTakeDays.AutoSize = true;
            this.lblMinTakeDays.Location = new System.Drawing.Point(7, 19);
            this.lblMinTakeDays.Name = "lblMinTakeDays";
            this.lblMinTakeDays.Size = new System.Drawing.Size(31, 13);
            this.lblMinTakeDays.TabIndex = 20;
            this.lblMinTakeDays.Text = "Days";
            // 
            // gbMaxTake
            // 
            this.gbMaxTake.Controls.Add(this.udMaxTakeHours);
            this.gbMaxTake.Controls.Add(this.udMaxTakeDays);
            this.gbMaxTake.Controls.Add(this.lblMaxTakeHours);
            this.gbMaxTake.Controls.Add(this.lblMaxTakeDays);
            this.gbMaxTake.Location = new System.Drawing.Point(3, 142);
            this.gbMaxTake.Name = "gbMaxTake";
            this.gbMaxTake.Size = new System.Drawing.Size(375, 63);
            this.gbMaxTake.TabIndex = 26;
            this.gbMaxTake.TabStop = false;
            this.gbMaxTake.Text = "gbMAxTake";
            // 
            // udMaxTakeHours
            // 
            this.udMaxTakeHours.Location = new System.Drawing.Point(223, 35);
            this.udMaxTakeHours.Name = "udMaxTakeHours";
            this.udMaxTakeHours.Size = new System.Drawing.Size(141, 20);
            this.udMaxTakeHours.TabIndex = 23;
            // 
            // udMaxTakeDays
            // 
            this.udMaxTakeDays.Location = new System.Drawing.Point(7, 35);
            this.udMaxTakeDays.Name = "udMaxTakeDays";
            this.udMaxTakeDays.Size = new System.Drawing.Size(144, 20);
            this.udMaxTakeDays.TabIndex = 22;
            // 
            // lblMaxTakeHours
            // 
            this.lblMaxTakeHours.AutoSize = true;
            this.lblMaxTakeHours.Location = new System.Drawing.Point(223, 19);
            this.lblMaxTakeHours.Name = "lblMaxTakeHours";
            this.lblMaxTakeHours.Size = new System.Drawing.Size(35, 13);
            this.lblMaxTakeHours.TabIndex = 21;
            this.lblMaxTakeHours.Text = "Hours";
            // 
            // lblMaxTakeDays
            // 
            this.lblMaxTakeDays.AutoSize = true;
            this.lblMaxTakeDays.Location = new System.Drawing.Point(7, 19);
            this.lblMaxTakeDays.Name = "lblMaxTakeDays";
            this.lblMaxTakeDays.Size = new System.Drawing.Size(31, 13);
            this.lblMaxTakeDays.TabIndex = 20;
            this.lblMaxTakeDays.Text = "Days";
            // 
            // gbCarryOver
            // 
            this.gbCarryOver.Controls.Add(this.udCarryOverHours);
            this.gbCarryOver.Controls.Add(this.udCarryOverDays);
            this.gbCarryOver.Controls.Add(this.lblCarryOverHours);
            this.gbCarryOver.Controls.Add(this.lblCarryOverDays);
            this.gbCarryOver.Location = new System.Drawing.Point(3, 73);
            this.gbCarryOver.Name = "gbCarryOver";
            this.gbCarryOver.Size = new System.Drawing.Size(375, 63);
            this.gbCarryOver.TabIndex = 27;
            this.gbCarryOver.TabStop = false;
            this.gbCarryOver.Text = "Carry Over";
            // 
            // udCarryOverHours
            // 
            this.udCarryOverHours.Location = new System.Drawing.Point(223, 35);
            this.udCarryOverHours.Name = "udCarryOverHours";
            this.udCarryOverHours.Size = new System.Drawing.Size(141, 20);
            this.udCarryOverHours.TabIndex = 23;
            // 
            // udCarryOverDays
            // 
            this.udCarryOverDays.Location = new System.Drawing.Point(7, 35);
            this.udCarryOverDays.Name = "udCarryOverDays";
            this.udCarryOverDays.Size = new System.Drawing.Size(144, 20);
            this.udCarryOverDays.TabIndex = 22;
            // 
            // lblCarryOverHours
            // 
            this.lblCarryOverHours.AutoSize = true;
            this.lblCarryOverHours.Location = new System.Drawing.Point(223, 19);
            this.lblCarryOverHours.Name = "lblCarryOverHours";
            this.lblCarryOverHours.Size = new System.Drawing.Size(35, 13);
            this.lblCarryOverHours.TabIndex = 21;
            this.lblCarryOverHours.Text = "Hours";
            // 
            // lblCarryOverDays
            // 
            this.lblCarryOverDays.AutoSize = true;
            this.lblCarryOverDays.Location = new System.Drawing.Point(7, 19);
            this.lblCarryOverDays.Name = "lblCarryOverDays";
            this.lblCarryOverDays.Size = new System.Drawing.Size(31, 13);
            this.lblCarryOverDays.TabIndex = 20;
            this.lblCarryOverDays.Text = "Days";
            // 
            // gbLeaveYear
            // 
            this.gbLeaveYear.Controls.Add(this.dtpEnd);
            this.gbLeaveYear.Controls.Add(this.dtpStart);
            this.gbLeaveYear.Controls.Add(this.lblLeaveYearEnds);
            this.gbLeaveYear.Controls.Add(this.lblLeaveYearStarts);
            this.gbLeaveYear.Location = new System.Drawing.Point(3, 3);
            this.gbLeaveYear.Name = "gbLeaveYear";
            this.gbLeaveYear.Size = new System.Drawing.Size(375, 64);
            this.gbLeaveYear.TabIndex = 28;
            this.gbLeaveYear.TabStop = false;
            this.gbLeaveYear.Text = "Leave YEar";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "dd MMMM";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(223, 36);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(141, 20);
            this.dtpEnd.TabIndex = 7;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "dd MMMM";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(7, 36);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(144, 20);
            this.dtpStart.TabIndex = 6;
            // 
            // lblLeaveYearEnds
            // 
            this.lblLeaveYearEnds.AutoSize = true;
            this.lblLeaveYearEnds.Location = new System.Drawing.Point(223, 20);
            this.lblLeaveYearEnds.Name = "lblLeaveYearEnds";
            this.lblLeaveYearEnds.Size = new System.Drawing.Size(35, 13);
            this.lblLeaveYearEnds.TabIndex = 5;
            this.lblLeaveYearEnds.Text = "label2";
            // 
            // lblLeaveYearStarts
            // 
            this.lblLeaveYearStarts.AutoSize = true;
            this.lblLeaveYearStarts.Location = new System.Drawing.Point(7, 20);
            this.lblLeaveYearStarts.Name = "lblLeaveYearStarts";
            this.lblLeaveYearStarts.Size = new System.Drawing.Size(35, 13);
            this.lblLeaveYearStarts.TabIndex = 4;
            this.lblLeaveYearStarts.Text = "label1";
            // 
            // StaffSettingsHoliday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbLeaveYear);
            this.Controls.Add(this.gbCarryOver);
            this.Controls.Add(this.gbMaxTake);
            this.Controls.Add(this.gbMinTake);
            this.Controls.Add(this.udBookAhead);
            this.Controls.Add(this.lblBookAhead);
            this.Controls.Add(this.cbAllowBookAcrossYears);
            this.Name = "StaffSettingsHoliday";
            ((System.ComponentModel.ISupportInitialize)(this.udBookAhead)).EndInit();
            this.gbMinTake.ResumeLayout(false);
            this.gbMinTake.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMinTakeHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMinTakeDays)).EndInit();
            this.gbMaxTake.ResumeLayout(false);
            this.gbMaxTake.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxTakeHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxTakeDays)).EndInit();
            this.gbCarryOver.ResumeLayout(false);
            this.gbCarryOver.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udCarryOverHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udCarryOverDays)).EndInit();
            this.gbLeaveYear.ResumeLayout(false);
            this.gbLeaveYear.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbAllowBookAcrossYears;
        private System.Windows.Forms.Label lblBookAhead;
        private System.Windows.Forms.NumericUpDown udBookAhead;
        private System.Windows.Forms.GroupBox gbMinTake;
        private System.Windows.Forms.NumericUpDown udMinTakeHours;
        private System.Windows.Forms.NumericUpDown udMinTakeDays;
        private System.Windows.Forms.Label lblMinTakeHours;
        private System.Windows.Forms.Label lblMinTakeDays;
        private System.Windows.Forms.GroupBox gbMaxTake;
        private System.Windows.Forms.NumericUpDown udMaxTakeHours;
        private System.Windows.Forms.NumericUpDown udMaxTakeDays;
        private System.Windows.Forms.Label lblMaxTakeHours;
        private System.Windows.Forms.Label lblMaxTakeDays;
        private System.Windows.Forms.GroupBox gbCarryOver;
        private System.Windows.Forms.NumericUpDown udCarryOverHours;
        private System.Windows.Forms.NumericUpDown udCarryOverDays;
        private System.Windows.Forms.Label lblCarryOverHours;
        private System.Windows.Forms.Label lblCarryOverDays;
        private System.Windows.Forms.GroupBox gbLeaveYear;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblLeaveYearEnds;
        private System.Windows.Forms.Label lblLeaveYearStarts;
    }
}
