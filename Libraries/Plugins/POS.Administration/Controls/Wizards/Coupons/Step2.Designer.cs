namespace POS.Administration.Controls.Wizards.Coupons
{
    partial class Step2
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
            this.cmbVoucherType = new System.Windows.Forms.ComboBox();
            this.lblVoucherType = new System.Windows.Forms.Label();
            this.lblDiscountAmount2 = new System.Windows.Forms.Label();
            this.spnDiscount = new System.Windows.Forms.NumericUpDown();
            this.lblDiscountAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spnDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbVoucherType
            // 
            this.cmbVoucherType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVoucherType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoucherType.FormattingEnabled = true;
            this.cmbVoucherType.Location = new System.Drawing.Point(127, 3);
            this.cmbVoucherType.Name = "cmbVoucherType";
            this.cmbVoucherType.Size = new System.Drawing.Size(226, 21);
            this.cmbVoucherType.TabIndex = 22;
            this.cmbVoucherType.SelectedIndexChanged += new System.EventHandler(this.cmbVoucherType_SelectedIndexChanged);
            // 
            // lblVoucherType
            // 
            this.lblVoucherType.AutoSize = true;
            this.lblVoucherType.Location = new System.Drawing.Point(4, 6);
            this.lblVoucherType.Name = "lblVoucherType";
            this.lblVoucherType.Size = new System.Drawing.Size(74, 13);
            this.lblVoucherType.TabIndex = 21;
            this.lblVoucherType.Text = "Voucher Type";
            // 
            // lblDiscountAmount2
            // 
            this.lblDiscountAmount2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscountAmount2.AutoSize = true;
            this.lblDiscountAmount2.Location = new System.Drawing.Point(205, 59);
            this.lblDiscountAmount2.Name = "lblDiscountAmount2";
            this.lblDiscountAmount2.Size = new System.Drawing.Size(15, 13);
            this.lblDiscountAmount2.TabIndex = 29;
            this.lblDiscountAmount2.Text = "%";
            // 
            // spnDiscount
            // 
            this.spnDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spnDiscount.Location = new System.Drawing.Point(127, 57);
            this.spnDiscount.Name = "spnDiscount";
            this.spnDiscount.Size = new System.Drawing.Size(72, 20);
            this.spnDiscount.TabIndex = 28;
            this.spnDiscount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblDiscountAmount
            // 
            this.lblDiscountAmount.AutoSize = true;
            this.lblDiscountAmount.Location = new System.Drawing.Point(3, 59);
            this.lblDiscountAmount.Name = "lblDiscountAmount";
            this.lblDiscountAmount.Size = new System.Drawing.Size(60, 13);
            this.lblDiscountAmount.TabIndex = 27;
            this.lblDiscountAmount.Text = "Discount %";
            // 
            // Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDiscountAmount2);
            this.Controls.Add(this.spnDiscount);
            this.Controls.Add(this.lblDiscountAmount);
            this.Controls.Add(this.cmbVoucherType);
            this.Controls.Add(this.lblVoucherType);
            this.Name = "Step2";
            ((System.ComponentModel.ISupportInitialize)(this.spnDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbVoucherType;
        private System.Windows.Forms.Label lblVoucherType;
        private System.Windows.Forms.Label lblDiscountAmount2;
        private System.Windows.Forms.NumericUpDown spnDiscount;
        private System.Windows.Forms.Label lblDiscountAmount;
    }
}
