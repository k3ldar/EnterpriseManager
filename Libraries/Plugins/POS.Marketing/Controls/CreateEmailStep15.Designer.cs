namespace POS.Marketing.Controls
{
    partial class CreateEmailStep15
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblHeaderDescription = new System.Windows.Forms.Label();
            this.cbRepeat = new System.Windows.Forms.CheckBox();
            this.lblEvery = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.lblDaysFrom = new System.Windows.Forms.Label();
            this.lblRepeatSchedule = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(3, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(215, 24);
            this.lblHeader.TabIndex = 4;
            this.lblHeader.Text = "Repeat Email Campaign";
            // 
            // lblHeaderDescription
            // 
            this.lblHeaderDescription.AutoSize = true;
            this.lblHeaderDescription.Location = new System.Drawing.Point(4, 34);
            this.lblHeaderDescription.Name = "lblHeaderDescription";
            this.lblHeaderDescription.Size = new System.Drawing.Size(281, 13);
            this.lblHeaderDescription.TabIndex = 5;
            this.lblHeaderDescription.Text = "Repeat campaign every n days until the campaign finishes";
            // 
            // cbRepeat
            // 
            this.cbRepeat.AutoSize = true;
            this.cbRepeat.Location = new System.Drawing.Point(7, 70);
            this.cbRepeat.Name = "cbRepeat";
            this.cbRepeat.Size = new System.Drawing.Size(61, 17);
            this.cbRepeat.TabIndex = 6;
            this.cbRepeat.Text = "Repeat";
            this.cbRepeat.UseVisualStyleBackColor = true;
            this.cbRepeat.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lblEvery
            // 
            this.lblEvery.AutoSize = true;
            this.lblEvery.Location = new System.Drawing.Point(7, 110);
            this.lblEvery.Name = "lblEvery";
            this.lblEvery.Size = new System.Drawing.Size(34, 13);
            this.lblEvery.TabIndex = 7;
            this.lblEvery.Text = "Every";
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(62, 107);
            this.txtDays.MaxLength = 2;
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(40, 20);
            this.txtDays.TabIndex = 8;
            this.txtDays.Text = "7";
            this.txtDays.TextChanged += new System.EventHandler(this.txtDays_TextChanged);
            this.txtDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDays_KeyPress);
            // 
            // lblDaysFrom
            // 
            this.lblDaysFrom.AutoSize = true;
            this.lblDaysFrom.Location = new System.Drawing.Point(125, 110);
            this.lblDaysFrom.Name = "lblDaysFrom";
            this.lblDaysFrom.Size = new System.Drawing.Size(55, 13);
            this.lblDaysFrom.TabIndex = 9;
            this.lblDaysFrom.Text = "days, from";
            // 
            // lblRepeatSchedule
            // 
            this.lblRepeatSchedule.Location = new System.Drawing.Point(10, 145);
            this.lblRepeatSchedule.Name = "lblRepeatSchedule";
            this.lblRepeatSchedule.Size = new System.Drawing.Size(472, 176);
            this.lblRepeatSchedule.TabIndex = 10;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(202, 107);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(146, 20);
            this.dtpStartDate.TabIndex = 11;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(10, 336);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(167, 13);
            this.lblProgress.TabIndex = 12;
            this.lblProgress.Text = "Creating Repeat Email Campaigns";
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(183, 330);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(366, 23);
            this.pbProgress.TabIndex = 13;
            // 
            // CreateEmailStep10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblRepeatSchedule);
            this.Controls.Add(this.lblDaysFrom);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.lblEvery);
            this.Controls.Add(this.cbRepeat);
            this.Controls.Add(this.lblHeaderDescription);
            this.Controls.Add(this.lblHeader);
            this.Name = "CreateEmailStep10";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblHeaderDescription;
        private System.Windows.Forms.CheckBox cbRepeat;
        private System.Windows.Forms.Label lblEvery;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Label lblDaysFrom;
        private System.Windows.Forms.Label lblRepeatSchedule;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar pbProgress;
    }
}
