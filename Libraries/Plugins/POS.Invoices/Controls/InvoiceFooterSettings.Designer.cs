namespace POS.Invoices.Controls
{
    partial class InvoiceFooterSettings
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
            this.txtInvoiceFooter = new System.Windows.Forms.TextBox();
            this.lblInvoiceFooterDesc = new System.Windows.Forms.Label();
            this.lblPaymentDue = new System.Windows.Forms.Label();
            this.txtInvoiceDue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtInvoiceFooter
            // 
            this.txtInvoiceFooter.AcceptsReturn = true;
            this.txtInvoiceFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceFooter.Location = new System.Drawing.Point(3, 20);
            this.txtInvoiceFooter.MaxLength = 45;
            this.txtInvoiceFooter.Multiline = true;
            this.txtInvoiceFooter.Name = "txtInvoiceFooter";
            this.txtInvoiceFooter.Size = new System.Drawing.Size(454, 103);
            this.txtInvoiceFooter.TabIndex = 1;
            // 
            // lblInvoiceFooterDesc
            // 
            this.lblInvoiceFooterDesc.AutoSize = true;
            this.lblInvoiceFooterDesc.Location = new System.Drawing.Point(4, 4);
            this.lblInvoiceFooterDesc.Name = "lblInvoiceFooterDesc";
            this.lblInvoiceFooterDesc.Size = new System.Drawing.Size(92, 13);
            this.lblInvoiceFooterDesc.TabIndex = 2;
            this.lblInvoiceFooterDesc.Text = "Invoice footer text";
            // 
            // lblPaymentDue
            // 
            this.lblPaymentDue.AutoSize = true;
            this.lblPaymentDue.Location = new System.Drawing.Point(4, 150);
            this.lblPaymentDue.Name = "lblPaymentDue";
            this.lblPaymentDue.Size = new System.Drawing.Size(35, 13);
            this.lblPaymentDue.TabIndex = 3;
            this.lblPaymentDue.Text = "label1";
            // 
            // txtInvoiceDue
            // 
            this.txtInvoiceDue.Location = new System.Drawing.Point(4, 167);
            this.txtInvoiceDue.MaxLength = 50;
            this.txtInvoiceDue.Multiline = true;
            this.txtInvoiceDue.Name = "txtInvoiceDue";
            this.txtInvoiceDue.Size = new System.Drawing.Size(453, 119);
            this.txtInvoiceDue.TabIndex = 4;
            // 
            // InvoiceFooterSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtInvoiceDue);
            this.Controls.Add(this.lblPaymentDue);
            this.Controls.Add(this.lblInvoiceFooterDesc);
            this.Controls.Add(this.txtInvoiceFooter);
            this.Name = "InvoiceFooterSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInvoiceFooter;
        private System.Windows.Forms.Label lblInvoiceFooterDesc;
        private System.Windows.Forms.Label lblPaymentDue;
        private System.Windows.Forms.TextBox txtInvoiceDue;
    }
}
