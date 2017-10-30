namespace POS.Staff.Controls.Settings
{
    partial class CommissionPoolSettings
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
            this.rbContinuousPayments = new System.Windows.Forms.RadioButton();
            this.rbYearlyPayments = new System.Windows.Forms.RadioButton();
            this.lblWait = new System.Windows.Forms.Label();
            this.udMonthsToWait = new System.Windows.Forms.NumericUpDown();
            this.lblWaitDescription = new System.Windows.Forms.Label();
            this.dtpYearly = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.udMonthsToWait)).BeginInit();
            this.SuspendLayout();
            // 
            // rbContinuousPayments
            // 
            this.rbContinuousPayments.AutoSize = true;
            this.rbContinuousPayments.Location = new System.Drawing.Point(4, 4);
            this.rbContinuousPayments.Name = "rbContinuousPayments";
            this.rbContinuousPayments.Size = new System.Drawing.Size(85, 17);
            this.rbContinuousPayments.TabIndex = 0;
            this.rbContinuousPayments.TabStop = true;
            this.rbContinuousPayments.Text = "radioButton1";
            this.rbContinuousPayments.UseVisualStyleBackColor = true;
            this.rbContinuousPayments.CheckedChanged += new System.EventHandler(this.rbYearlyPayments_CheckedChanged);
            // 
            // rbYearlyPayments
            // 
            this.rbYearlyPayments.AutoSize = true;
            this.rbYearlyPayments.Location = new System.Drawing.Point(4, 32);
            this.rbYearlyPayments.Name = "rbYearlyPayments";
            this.rbYearlyPayments.Size = new System.Drawing.Size(85, 17);
            this.rbYearlyPayments.TabIndex = 1;
            this.rbYearlyPayments.TabStop = true;
            this.rbYearlyPayments.Text = "radioButton2";
            this.rbYearlyPayments.UseVisualStyleBackColor = true;
            this.rbYearlyPayments.CheckedChanged += new System.EventHandler(this.rbYearlyPayments_CheckedChanged);
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.Location = new System.Drawing.Point(10, 114);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(29, 13);
            this.lblWait.TabIndex = 3;
            this.lblWait.Text = "Wait";
            // 
            // udMonthsToWait
            // 
            this.udMonthsToWait.Location = new System.Drawing.Point(64, 112);
            this.udMonthsToWait.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.udMonthsToWait.Name = "udMonthsToWait";
            this.udMonthsToWait.Size = new System.Drawing.Size(67, 20);
            this.udMonthsToWait.TabIndex = 4;
            // 
            // lblWaitDescription
            // 
            this.lblWaitDescription.AutoSize = true;
            this.lblWaitDescription.Location = new System.Drawing.Point(157, 114);
            this.lblWaitDescription.Name = "lblWaitDescription";
            this.lblWaitDescription.Size = new System.Drawing.Size(35, 13);
            this.lblWaitDescription.TabIndex = 5;
            this.lblWaitDescription.Text = "label2";
            // 
            // dtpYearly
            // 
            this.dtpYearly.CustomFormat = "dd MMMM";
            this.dtpYearly.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYearly.Location = new System.Drawing.Point(27, 56);
            this.dtpYearly.Name = "dtpYearly";
            this.dtpYearly.Size = new System.Drawing.Size(179, 20);
            this.dtpYearly.TabIndex = 2;
            // 
            // CommissionPoolSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpYearly);
            this.Controls.Add(this.lblWaitDescription);
            this.Controls.Add(this.udMonthsToWait);
            this.Controls.Add(this.lblWait);
            this.Controls.Add(this.rbYearlyPayments);
            this.Controls.Add(this.rbContinuousPayments);
            this.Name = "CommissionPoolSettings";
            ((System.ComponentModel.ISupportInitialize)(this.udMonthsToWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbContinuousPayments;
        private System.Windows.Forms.RadioButton rbYearlyPayments;
        private System.Windows.Forms.Label lblWait;
        private System.Windows.Forms.NumericUpDown udMonthsToWait;
        private System.Windows.Forms.Label lblWaitDescription;
        private System.Windows.Forms.DateTimePicker dtpYearly;
    }
}
