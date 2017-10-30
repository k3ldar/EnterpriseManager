namespace SieraDelta.POS.Orders.Forms
{
    partial class InvoicesReceived
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
            this.lstInvoices = new System.Windows.Forms.ListView();
            this.chInvoice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCustomer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPurchaseDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chInvoiceAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPaymentType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnProcessing = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpacer1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpacer2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmbPaymentStatus = new System.Windows.Forms.ComboBox();
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstInvoices
            // 
            this.lstInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstInvoices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chInvoice,
            this.chCustomer,
            this.chPurchaseDate,
            this.chInvoiceAmount,
            this.chPaymentType});
            this.lstInvoices.FullRowSelect = true;
            this.lstInvoices.HideSelection = false;
            this.lstInvoices.Location = new System.Drawing.Point(12, 45);
            this.lstInvoices.Name = "lstInvoices";
            this.lstInvoices.Size = new System.Drawing.Size(641, 163);
            this.lstInvoices.TabIndex = 4;
            this.lstInvoices.UseCompatibleStateImageBehavior = false;
            this.lstInvoices.View = System.Windows.Forms.View.Details;
            this.lstInvoices.SelectedIndexChanged += new System.EventHandler(this.lstInvoices_SelectedIndexChanged);
            this.lstInvoices.DoubleClick += new System.EventHandler(this.lstInvoices_DoubleClick);
            // 
            // chInvoice
            // 
            this.chInvoice.Text = "Invoice";
            this.chInvoice.Width = 120;
            // 
            // chCustomer
            // 
            this.chCustomer.Text = "Username";
            this.chCustomer.Width = 200;
            // 
            // chPurchaseDate
            // 
            this.chPurchaseDate.Text = "PurchaseDate";
            this.chPurchaseDate.Width = 130;
            // 
            // chInvoiceAmount
            // 
            this.chInvoiceAmount.Text = "Invoice Amount";
            this.chInvoiceAmount.Width = 100;
            // 
            // chPaymentType
            // 
            this.chPaymentType.Text = "Payment Type";
            this.chPaymentType.Width = 100;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(497, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnProcessing
            // 
            this.btnProcessing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessing.Location = new System.Drawing.Point(578, 10);
            this.btnProcessing.Name = "btnProcessing";
            this.btnProcessing.Size = new System.Drawing.Size(75, 23);
            this.btnProcessing.TabIndex = 3;
            this.btnProcessing.Text = "Processing";
            this.btnProcessing.UseVisualStyleBackColor = true;
            this.btnProcessing.Click += new System.EventHandler(this.btnProcessing_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount,
            this.toolStripStatusLabelSpacer1,
            this.toolStripStatusLabelSpacer2,
            this.toolStripStatusLabelSelected});
            this.statusStrip1.Location = new System.Drawing.Point(0, 211);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(659, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(96, 17);
            this.toolStripStatusLabelCount.Text = "0 Invoices Found";
            // 
            // toolStripStatusLabelSpacer1
            // 
            this.toolStripStatusLabelSpacer1.Name = "toolStripStatusLabelSpacer1";
            this.toolStripStatusLabelSpacer1.Size = new System.Drawing.Size(19, 17);
            this.toolStripStatusLabelSpacer1.Text = "    ";
            // 
            // toolStripStatusLabelSpacer2
            // 
            this.toolStripStatusLabelSpacer2.Name = "toolStripStatusLabelSpacer2";
            this.toolStripStatusLabelSpacer2.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabelSpacer2.Text = "   ";
            // 
            // toolStripStatusLabelSelected
            // 
            this.toolStripStatusLabelSelected.Name = "toolStripStatusLabelSelected";
            this.toolStripStatusLabelSelected.Size = new System.Drawing.Size(116, 17);
            this.toolStripStatusLabelSelected.Text = "No Invoices Selected";
            // 
            // cmbPaymentStatus
            // 
            this.cmbPaymentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentStatus.FormattingEnabled = true;
            this.cmbPaymentStatus.Location = new System.Drawing.Point(142, 12);
            this.cmbPaymentStatus.Name = "cmbPaymentStatus";
            this.cmbPaymentStatus.Size = new System.Drawing.Size(223, 21);
            this.cmbPaymentStatus.TabIndex = 1;
            this.cmbPaymentStatus.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentStatus_SelectedIndexChanged);
            this.cmbPaymentStatus.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbPaymentStatus_Format);
            // 
            // lblPaymentStatus
            // 
            this.lblPaymentStatus.AutoSize = true;
            this.lblPaymentStatus.Location = new System.Drawing.Point(12, 15);
            this.lblPaymentStatus.Name = "lblPaymentStatus";
            this.lblPaymentStatus.Size = new System.Drawing.Size(81, 13);
            this.lblPaymentStatus.TabIndex = 0;
            this.lblPaymentStatus.Text = "Payment Status";
            // 
            // InvoicesReceived
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 233);
            this.Controls.Add(this.lblPaymentStatus);
            this.Controls.Add(this.cmbPaymentStatus);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnProcessing);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lstInvoices);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoicesReceived";
            this.SaveState = true;
            this.Text = "Invoices Received";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstInvoices;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ColumnHeader chInvoice;
        private System.Windows.Forms.ColumnHeader chCustomer;
        private System.Windows.Forms.ColumnHeader chPurchaseDate;
        private System.Windows.Forms.Button btnProcessing;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpacer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpacer2;
        private System.Windows.Forms.ColumnHeader chInvoiceAmount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSelected;
        private System.Windows.Forms.ComboBox cmbPaymentStatus;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.ColumnHeader chPaymentType;
    }
}