namespace POS.Staff.Controls.Wizards.Commission.BonusPayments
{
    partial class Step5
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
            this.lblMayTakeTime = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDateDue = new System.Windows.Forms.Label();
            this.dtpDateDue = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblMayTakeTime
            // 
            this.lblMayTakeTime.AutoSize = true;
            this.lblMayTakeTime.Location = new System.Drawing.Point(3, 186);
            this.lblMayTakeTime.Name = "lblMayTakeTime";
            this.lblMayTakeTime.Size = new System.Drawing.Size(35, 13);
            this.lblMayTakeTime.TabIndex = 3;
            this.lblMayTakeTime.Text = "label1";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(3, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(35, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "label1";
            // 
            // lblDateDue
            // 
            this.lblDateDue.AutoSize = true;
            this.lblDateDue.Location = new System.Drawing.Point(6, 65);
            this.lblDateDue.Name = "lblDateDue";
            this.lblDateDue.Size = new System.Drawing.Size(35, 13);
            this.lblDateDue.TabIndex = 1;
            this.lblDateDue.Text = "label1";
            // 
            // dtpDateDue
            // 
            this.dtpDateDue.Location = new System.Drawing.Point(9, 82);
            this.dtpDateDue.Name = "dtpDateDue";
            this.dtpDateDue.Size = new System.Drawing.Size(142, 20);
            this.dtpDateDue.TabIndex = 2;
            // 
            // Step5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpDateDue);
            this.Controls.Add(this.lblDateDue);
            this.Controls.Add(this.lblMayTakeTime);
            this.Controls.Add(this.lblDescription);
            this.Name = "Step5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMayTakeTime;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDateDue;
        private System.Windows.Forms.DateTimePicker dtpDateDue;

    }
}
