namespace POS.Invoices.Forms
{
    partial class InvoiceManager
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
            this.invoiceManagerControl1 = new POS.Invoices.Controls.InvoiceManagerControl();
            this.SuspendLayout();
            // 
            // invoiceManagerControl1
            // 
            this.invoiceManagerControl1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.invoiceManagerControl1.HintControl = null;
            this.invoiceManagerControl1.Location = new System.Drawing.Point(2, 3);
            this.invoiceManagerControl1.MinimumSize = new System.Drawing.Size(803, 400);
            this.invoiceManagerControl1.Name = "invoiceManagerControl1";
            this.invoiceManagerControl1.Size = new System.Drawing.Size(858, 400);
            this.invoiceManagerControl1.TabIndex = 0;
            // 
            // InvoiceManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 404);
            this.Controls.Add(this.invoiceManagerControl1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(803, 400);
            this.Name = "InvoiceManager";
            this.SaveState = true;
            this.Text = "Invoice Manager";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.InvoiceManagerControl invoiceManagerControl1;
    }
}