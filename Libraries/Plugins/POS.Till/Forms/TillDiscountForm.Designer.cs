namespace POS.Till.Forms
{
    partial class TillDiscountForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtVoucherDescription = new System.Windows.Forms.TextBox();
            this.btnApplyDiscount = new System.Windows.Forms.Button();
            this.lblVoucherDescription = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblDiscountPercent = new System.Windows.Forms.Label();
            this.rbCashAmount = new System.Windows.Forms.RadioButton();
            this.rbPercent = new System.Windows.Forms.RadioButton();
            this.rbCoupon = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtVoucherDescription
            // 
            this.txtVoucherDescription.Location = new System.Drawing.Point(205, 26);
            this.txtVoucherDescription.MaxLength = 29;
            this.txtVoucherDescription.Name = "txtVoucherDescription";
            this.txtVoucherDescription.Size = new System.Drawing.Size(205, 20);
            this.txtVoucherDescription.TabIndex = 6;
            this.txtVoucherDescription.Text = "Salon Voucher";
            // 
            // btnApplyDiscount
            // 
            this.btnApplyDiscount.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApplyDiscount.Location = new System.Drawing.Point(310, 111);
            this.btnApplyDiscount.Name = "btnApplyDiscount";
            this.btnApplyDiscount.Size = new System.Drawing.Size(100, 23);
            this.btnApplyDiscount.TabIndex = 7;
            this.btnApplyDiscount.Text = "Apply Discount";
            this.btnApplyDiscount.UseVisualStyleBackColor = true;
            this.btnApplyDiscount.Click += new System.EventHandler(this.btnApplyDiscount_Click);
            // 
            // lblVoucherDescription
            // 
            this.lblVoucherDescription.AutoSize = true;
            this.lblVoucherDescription.Location = new System.Drawing.Point(202, 9);
            this.lblVoucherDescription.Name = "lblVoucherDescription";
            this.lblVoucherDescription.Size = new System.Drawing.Size(75, 13);
            this.lblVoucherDescription.TabIndex = 5;
            this.lblVoucherDescription.Text = "Voucher Code";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Enabled = false;
            this.txtDiscount.Location = new System.Drawing.Point(122, 26);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(60, 20);
            this.txtDiscount.TabIndex = 4;
            this.txtDiscount.Text = "0";
            // 
            // lblDiscountPercent
            // 
            this.lblDiscountPercent.AutoSize = true;
            this.lblDiscountPercent.Location = new System.Drawing.Point(119, 9);
            this.lblDiscountPercent.Name = "lblDiscountPercent";
            this.lblDiscountPercent.Size = new System.Drawing.Size(58, 13);
            this.lblDiscountPercent.TabIndex = 3;
            this.lblDiscountPercent.Text = "Discount £";
            // 
            // rbCashAmount
            // 
            this.rbCashAmount.AutoSize = true;
            this.rbCashAmount.Location = new System.Drawing.Point(9, 56);
            this.rbCashAmount.Name = "rbCashAmount";
            this.rbCashAmount.Size = new System.Drawing.Size(52, 17);
            this.rbCashAmount.TabIndex = 2;
            this.rbCashAmount.Text = "Value";
            this.rbCashAmount.UseVisualStyleBackColor = true;
            this.rbCashAmount.CheckedChanged += new System.EventHandler(this.rbCoupon_CheckedChanged);
            // 
            // rbPercent
            // 
            this.rbPercent.AutoSize = true;
            this.rbPercent.Location = new System.Drawing.Point(9, 33);
            this.rbPercent.Name = "rbPercent";
            this.rbPercent.Size = new System.Drawing.Size(62, 17);
            this.rbPercent.TabIndex = 1;
            this.rbPercent.Text = "Percent";
            this.rbPercent.UseVisualStyleBackColor = true;
            this.rbPercent.CheckedChanged += new System.EventHandler(this.rbCoupon_CheckedChanged);
            // 
            // rbCoupon
            // 
            this.rbCoupon.AutoSize = true;
            this.rbCoupon.Checked = true;
            this.rbCoupon.Location = new System.Drawing.Point(9, 10);
            this.rbCoupon.Name = "rbCoupon";
            this.rbCoupon.Size = new System.Drawing.Size(62, 17);
            this.rbCoupon.TabIndex = 0;
            this.rbCoupon.TabStop = true;
            this.rbCoupon.Text = "Coupon";
            this.rbCoupon.UseVisualStyleBackColor = true;
            this.rbCoupon.CheckedChanged += new System.EventHandler(this.rbCoupon_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(229, 111);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // TillDiscountForm
            // 
            this.AcceptButton = this.btnApplyDiscount;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(418, 145);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtVoucherDescription);
            this.Controls.Add(this.btnApplyDiscount);
            this.Controls.Add(this.lblVoucherDescription);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.lblDiscountPercent);
            this.Controls.Add(this.rbCashAmount);
            this.Controls.Add(this.rbPercent);
            this.Controls.Add(this.rbCoupon);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TillDiscountForm";
            this.SaveState = true;
            this.Text = "Apply Discount";
            this.Shown += new System.EventHandler(this.TillDiscountForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVoucherDescription;
        private System.Windows.Forms.Button btnApplyDiscount;
        private System.Windows.Forms.Label lblVoucherDescription;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblDiscountPercent;
        private System.Windows.Forms.RadioButton rbCashAmount;
        private System.Windows.Forms.RadioButton rbPercent;
        private System.Windows.Forms.RadioButton rbCoupon;
        private System.Windows.Forms.Button btnCancel;
    }
}