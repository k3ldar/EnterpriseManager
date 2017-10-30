namespace POS.AutoUpdate.Controls.Wizards.AddRule
{
    partial class Step6
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.dtpRunTime = new System.Windows.Forms.DateTimePicker();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblRunDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(7, 4);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(35, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "label1";
            // 
            // dtpRunTime
            // 
            this.dtpRunTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRunTime.Location = new System.Drawing.Point(7, 105);
            this.dtpRunTime.Name = "dtpRunTime";
            this.dtpRunTime.Size = new System.Drawing.Size(225, 20);
            this.dtpRunTime.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(7, 163);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "label1";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(7, 180);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(222, 20);
            this.txtName.TabIndex = 3;
            // 
            // lblRunDate
            // 
            this.lblRunDate.AutoSize = true;
            this.lblRunDate.Location = new System.Drawing.Point(7, 86);
            this.lblRunDate.Name = "lblRunDate";
            this.lblRunDate.Size = new System.Drawing.Size(35, 13);
            this.lblRunDate.TabIndex = 4;
            this.lblRunDate.Text = "label1";
            // 
            // Step6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRunDate);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.dtpRunTime);
            this.Controls.Add(this.lblDescription);
            this.Name = "Step6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.DateTimePicker dtpRunTime;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblRunDate;
    }
}
