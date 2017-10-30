namespace POS.Staff.Controls.Wizards.Commission.ClientPay
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
            this.lblSelectPayDate = new System.Windows.Forms.Label();
            this.dtpPayDate = new System.Windows.Forms.DateTimePicker();
            this.lblPayClientCommissionDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSelectPayDate
            // 
            this.lblSelectPayDate.AutoSize = true;
            this.lblSelectPayDate.Location = new System.Drawing.Point(3, 105);
            this.lblSelectPayDate.Name = "lblSelectPayDate";
            this.lblSelectPayDate.Size = new System.Drawing.Size(35, 13);
            this.lblSelectPayDate.TabIndex = 0;
            this.lblSelectPayDate.Text = "label1";
            // 
            // dtpPayDate
            // 
            this.dtpPayDate.Location = new System.Drawing.Point(6, 122);
            this.dtpPayDate.Name = "dtpPayDate";
            this.dtpPayDate.Size = new System.Drawing.Size(177, 20);
            this.dtpPayDate.TabIndex = 1;
            // 
            // lblPayClientCommissionDesc
            // 
            this.lblPayClientCommissionDesc.AutoSize = true;
            this.lblPayClientCommissionDesc.Location = new System.Drawing.Point(6, 4);
            this.lblPayClientCommissionDesc.Name = "lblPayClientCommissionDesc";
            this.lblPayClientCommissionDesc.Size = new System.Drawing.Size(35, 13);
            this.lblPayClientCommissionDesc.TabIndex = 2;
            this.lblPayClientCommissionDesc.Text = "label2";
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPayClientCommissionDesc);
            this.Controls.Add(this.dtpPayDate);
            this.Controls.Add(this.lblSelectPayDate);
            this.Name = "Step1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectPayDate;
        private System.Windows.Forms.DateTimePicker dtpPayDate;
        private System.Windows.Forms.Label lblPayClientCommissionDesc;
    }
}
