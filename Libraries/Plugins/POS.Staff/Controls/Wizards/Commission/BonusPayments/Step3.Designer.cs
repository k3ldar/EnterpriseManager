namespace POS.Staff.Controls.Wizards.Commission.BonusPayments
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
            this.rbSplitJointly = new System.Windows.Forms.RadioButton();
            this.rbSplitPermanentDate = new System.Windows.Forms.RadioButton();
            this.rbSplitJoinDate = new System.Windows.Forms.RadioButton();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rbSplitJointly
            // 
            this.rbSplitJointly.AutoSize = true;
            this.rbSplitJointly.Location = new System.Drawing.Point(3, 3);
            this.rbSplitJointly.Name = "rbSplitJointly";
            this.rbSplitJointly.Size = new System.Drawing.Size(85, 17);
            this.rbSplitJointly.TabIndex = 0;
            this.rbSplitJointly.Text = "radioButton1";
            this.rbSplitJointly.UseVisualStyleBackColor = true;
            this.rbSplitJointly.CheckedChanged += new System.EventHandler(this.rbSplitPermanentDate_CheckedChanged);
            // 
            // rbSplitPermanentDate
            // 
            this.rbSplitPermanentDate.AutoSize = true;
            this.rbSplitPermanentDate.Checked = true;
            this.rbSplitPermanentDate.Location = new System.Drawing.Point(3, 49);
            this.rbSplitPermanentDate.Name = "rbSplitPermanentDate";
            this.rbSplitPermanentDate.Size = new System.Drawing.Size(85, 17);
            this.rbSplitPermanentDate.TabIndex = 2;
            this.rbSplitPermanentDate.TabStop = true;
            this.rbSplitPermanentDate.Text = "radioButton2";
            this.rbSplitPermanentDate.UseVisualStyleBackColor = true;
            this.rbSplitPermanentDate.CheckedChanged += new System.EventHandler(this.rbSplitPermanentDate_CheckedChanged);
            // 
            // rbSplitJoinDate
            // 
            this.rbSplitJoinDate.AutoSize = true;
            this.rbSplitJoinDate.Location = new System.Drawing.Point(3, 26);
            this.rbSplitJoinDate.Name = "rbSplitJoinDate";
            this.rbSplitJoinDate.Size = new System.Drawing.Size(85, 17);
            this.rbSplitJoinDate.TabIndex = 1;
            this.rbSplitJoinDate.Text = "radioButton1";
            this.rbSplitJoinDate.UseVisualStyleBackColor = true;
            this.rbSplitJoinDate.CheckedChanged += new System.EventHandler(this.rbSplitPermanentDate_CheckedChanged);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(35, 137);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(155, 20);
            this.dtpDateFrom.TabIndex = 5;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(243, 137);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(155, 20);
            this.dtpDateTo.TabIndex = 7;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(32, 118);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(35, 13);
            this.lblDateFrom.TabIndex = 4;
            this.lblDateFrom.Text = "label1";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(243, 118);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(35, 13);
            this.lblDateTo.TabIndex = 6;
            this.lblDateTo.Text = "label2";
            // 
            // lblDateDescription
            // 
            this.lblDateDescription.AutoSize = true;
            this.lblDateDescription.Location = new System.Drawing.Point(32, 83);
            this.lblDateDescription.Name = "lblDateDescription";
            this.lblDateDescription.Size = new System.Drawing.Size(35, 13);
            this.lblDateDescription.TabIndex = 3;
            this.lblDateDescription.Text = "label1";
            // 
            // Step3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDateDescription);
            this.Controls.Add(this.lblDateTo);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.dtpDateTo);
            this.Controls.Add(this.dtpDateFrom);
            this.Controls.Add(this.rbSplitJointly);
            this.Controls.Add(this.rbSplitPermanentDate);
            this.Controls.Add(this.rbSplitJoinDate);
            this.Name = "Step3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbSplitJointly;
        private System.Windows.Forms.RadioButton rbSplitPermanentDate;
        private System.Windows.Forms.RadioButton rbSplitJoinDate;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateDescription;
    }
}
