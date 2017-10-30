namespace POS.Invoices.Controls
{
    partial class InvoiceSettings
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
            this.cbAllowCurrencyToBeConverted = new System.Windows.Forms.CheckBox();
            this.cbHideVAT = new System.Windows.Forms.CheckBox();
            this.lblInvoicePrefix = new System.Windows.Forms.Label();
            this.txtInvoicePrefix = new System.Windows.Forms.TextBox();
            this.cbShowProductDiscountOnInvoice = new System.Windows.Forms.CheckBox();
            this.txtMinTrackReference = new SharedControls.TextBoxEx();
            this.lblMinTrackingOrderValue = new System.Windows.Forms.Label();
            this.cbShippingIsTaxable = new System.Windows.Forms.CheckBox();
            this.lblVATNumber = new System.Windows.Forms.Label();
            this.txtVATRegNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbAllowCurrencyToBeConverted
            // 
            this.cbAllowCurrencyToBeConverted.AutoSize = true;
            this.cbAllowCurrencyToBeConverted.Location = new System.Drawing.Point(3, 27);
            this.cbAllowCurrencyToBeConverted.Name = "cbAllowCurrencyToBeConverted";
            this.cbAllowCurrencyToBeConverted.Size = new System.Drawing.Size(173, 17);
            this.cbAllowCurrencyToBeConverted.TabIndex = 1;
            this.cbAllowCurrencyToBeConverted.Text = "Allow currency to be converted";
            this.cbAllowCurrencyToBeConverted.UseVisualStyleBackColor = true;
            // 
            // cbHideVAT
            // 
            this.cbHideVAT.AutoSize = true;
            this.cbHideVAT.Location = new System.Drawing.Point(3, 3);
            this.cbHideVAT.Name = "cbHideVAT";
            this.cbHideVAT.Size = new System.Drawing.Size(174, 17);
            this.cbHideVAT.TabIndex = 0;
            this.cbHideVAT.Text = "Hide VAT from Invoices/Orders";
            this.cbHideVAT.UseVisualStyleBackColor = true;
            // 
            // lblInvoicePrefix
            // 
            this.lblInvoicePrefix.AutoSize = true;
            this.lblInvoicePrefix.Location = new System.Drawing.Point(0, 135);
            this.lblInvoicePrefix.Name = "lblInvoicePrefix";
            this.lblInvoicePrefix.Size = new System.Drawing.Size(71, 13);
            this.lblInvoicePrefix.TabIndex = 4;
            this.lblInvoicePrefix.Text = "Invoice Prefix";
            // 
            // txtInvoicePrefix
            // 
            this.txtInvoicePrefix.Location = new System.Drawing.Point(3, 151);
            this.txtInvoicePrefix.MaxLength = 10;
            this.txtInvoicePrefix.Name = "txtInvoicePrefix";
            this.txtInvoicePrefix.Size = new System.Drawing.Size(155, 20);
            this.txtInvoicePrefix.TabIndex = 5;
            // 
            // cbShowProductDiscountOnInvoice
            // 
            this.cbShowProductDiscountOnInvoice.AutoSize = true;
            this.cbShowProductDiscountOnInvoice.Location = new System.Drawing.Point(3, 50);
            this.cbShowProductDiscountOnInvoice.Name = "cbShowProductDiscountOnInvoice";
            this.cbShowProductDiscountOnInvoice.Size = new System.Drawing.Size(196, 17);
            this.cbShowProductDiscountOnInvoice.TabIndex = 2;
            this.cbShowProductDiscountOnInvoice.Text = "Show Product Discount on Invoices";
            this.cbShowProductDiscountOnInvoice.UseVisualStyleBackColor = true;
            // 
            // txtMinTrackReference
            // 
            this.txtMinTrackReference.AllowBackSpace = true;
            this.txtMinTrackReference.AllowCopy = true;
            this.txtMinTrackReference.AllowCut = true;
            this.txtMinTrackReference.AllowedCharacters = ".0123456789";
            this.txtMinTrackReference.AllowPaste = true;
            this.txtMinTrackReference.Location = new System.Drawing.Point(4, 203);
            this.txtMinTrackReference.MaxLength = 7;
            this.txtMinTrackReference.Name = "txtMinTrackReference";
            this.txtMinTrackReference.Size = new System.Drawing.Size(74, 20);
            this.txtMinTrackReference.TabIndex = 7;
            // 
            // lblMinTrackingOrderValue
            // 
            this.lblMinTrackingOrderValue.AutoSize = true;
            this.lblMinTrackingOrderValue.Location = new System.Drawing.Point(0, 187);
            this.lblMinTrackingOrderValue.Name = "lblMinTrackingOrderValue";
            this.lblMinTrackingOrderValue.Size = new System.Drawing.Size(208, 13);
            this.lblMinTrackingOrderValue.TabIndex = 6;
            this.lblMinTrackingOrderValue.Text = "Minimum order value for tracking reference";
            // 
            // cbShippingIsTaxable
            // 
            this.cbShippingIsTaxable.AutoSize = true;
            this.cbShippingIsTaxable.Location = new System.Drawing.Point(3, 74);
            this.cbShippingIsTaxable.Name = "cbShippingIsTaxable";
            this.cbShippingIsTaxable.Size = new System.Drawing.Size(80, 17);
            this.cbShippingIsTaxable.TabIndex = 3;
            this.cbShippingIsTaxable.Text = "checkBox1";
            this.cbShippingIsTaxable.UseVisualStyleBackColor = true;
            // 
            // lblVATNumber
            // 
            this.lblVATNumber.AutoSize = true;
            this.lblVATNumber.Location = new System.Drawing.Point(3, 239);
            this.lblVATNumber.Name = "lblVATNumber";
            this.lblVATNumber.Size = new System.Drawing.Size(127, 13);
            this.lblVATNumber.TabIndex = 8;
            this.lblVATNumber.Text = "VAT Registration Number";
            // 
            // txtVATRegNumber
            // 
            this.txtVATRegNumber.Location = new System.Drawing.Point(6, 256);
            this.txtVATRegNumber.MaxLength = 15;
            this.txtVATRegNumber.Name = "txtVATRegNumber";
            this.txtVATRegNumber.Size = new System.Drawing.Size(152, 20);
            this.txtVATRegNumber.TabIndex = 9;
            // 
            // InvoiceSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtVATRegNumber);
            this.Controls.Add(this.lblVATNumber);
            this.Controls.Add(this.cbShippingIsTaxable);
            this.Controls.Add(this.lblMinTrackingOrderValue);
            this.Controls.Add(this.txtMinTrackReference);
            this.Controls.Add(this.cbShowProductDiscountOnInvoice);
            this.Controls.Add(this.txtInvoicePrefix);
            this.Controls.Add(this.lblInvoicePrefix);
            this.Controls.Add(this.cbAllowCurrencyToBeConverted);
            this.Controls.Add(this.cbHideVAT);
            this.Name = "InvoiceSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbAllowCurrencyToBeConverted;
        private System.Windows.Forms.CheckBox cbHideVAT;
        private System.Windows.Forms.Label lblInvoicePrefix;
        private System.Windows.Forms.TextBox txtInvoicePrefix;
        private System.Windows.Forms.CheckBox cbShowProductDiscountOnInvoice;
        private SharedControls.TextBoxEx txtMinTrackReference;
        private System.Windows.Forms.Label lblMinTrackingOrderValue;
        private System.Windows.Forms.CheckBox cbShippingIsTaxable;
        private System.Windows.Forms.Label lblVATNumber;
        private System.Windows.Forms.TextBox txtVATRegNumber;
    }
}
