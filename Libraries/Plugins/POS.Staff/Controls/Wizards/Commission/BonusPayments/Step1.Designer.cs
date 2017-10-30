namespace POS.Staff.Controls.Wizards.Commission.BonusPayments
{
    partial class Step1
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
            this.lblEnterPaymentAmount = new System.Windows.Forms.Label();
            this.udPaymentAmount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.udPaymentAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEnterPaymentAmount
            // 
            this.lblEnterPaymentAmount.AutoSize = true;
            this.lblEnterPaymentAmount.Location = new System.Drawing.Point(4, 4);
            this.lblEnterPaymentAmount.Name = "lblEnterPaymentAmount";
            this.lblEnterPaymentAmount.Size = new System.Drawing.Size(35, 13);
            this.lblEnterPaymentAmount.TabIndex = 0;
            this.lblEnterPaymentAmount.Text = "label1";
            // 
            // udPaymentAmount
            // 
            this.udPaymentAmount.DecimalPlaces = 2;
            this.udPaymentAmount.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udPaymentAmount.Location = new System.Drawing.Point(7, 21);
            this.udPaymentAmount.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.udPaymentAmount.Name = "udPaymentAmount";
            this.udPaymentAmount.Size = new System.Drawing.Size(120, 20);
            this.udPaymentAmount.TabIndex = 1;
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.udPaymentAmount);
            this.Controls.Add(this.lblEnterPaymentAmount);
            this.Name = "Step1";
            ((System.ComponentModel.ISupportInitialize)(this.udPaymentAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEnterPaymentAmount;
        private System.Windows.Forms.NumericUpDown udPaymentAmount;
    }
}
