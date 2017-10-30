namespace POS.Invoices.Forms
{
    partial class IssueRefundForm
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
            this.lblUser = new System.Windows.Forms.Label();
            this.btnSelectUser = new System.Windows.Forms.Button();
            this.cmbInvoices = new System.Windows.Forms.ComboBox();
            this.lblSelectInvoice = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnIssueRefund = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblInvoiceAmountDesc = new System.Windows.Forms.Label();
            this.lblInvoiceAmount = new System.Windows.Forms.Label();
            this.lblRefundAmount = new System.Windows.Forms.Label();
            this.txtRefundAmount = new System.Windows.Forms.TextBox();
            this.btnViewInvoice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(12, 17);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(62, 13);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Select User";
            // 
            // btnSelectUser
            // 
            this.btnSelectUser.Location = new System.Drawing.Point(377, 12);
            this.btnSelectUser.Name = "btnSelectUser";
            this.btnSelectUser.Size = new System.Drawing.Size(88, 23);
            this.btnSelectUser.TabIndex = 1;
            this.btnSelectUser.Text = "Select User";
            this.btnSelectUser.UseVisualStyleBackColor = true;
            this.btnSelectUser.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbInvoices
            // 
            this.cmbInvoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvoices.Enabled = false;
            this.cmbInvoices.FormattingEnabled = true;
            this.cmbInvoices.Location = new System.Drawing.Point(15, 69);
            this.cmbInvoices.Name = "cmbInvoices";
            this.cmbInvoices.Size = new System.Drawing.Size(257, 21);
            this.cmbInvoices.TabIndex = 2;
            this.cmbInvoices.SelectedIndexChanged += new System.EventHandler(this.cmbInvoices_SelectedIndexChanged);
            this.cmbInvoices.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbInvoices_Format);
            // 
            // lblSelectInvoice
            // 
            this.lblSelectInvoice.AutoSize = true;
            this.lblSelectInvoice.Location = new System.Drawing.Point(12, 53);
            this.lblSelectInvoice.Name = "lblSelectInvoice";
            this.lblSelectInvoice.Size = new System.Drawing.Size(75, 13);
            this.lblSelectInvoice.TabIndex = 3;
            this.lblSelectInvoice.Text = "Select Invoice";
            // 
            // lblReason
            // 
            this.lblReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(12, 158);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(92, 13);
            this.lblReason.TabIndex = 4;
            this.lblReason.Text = "Reason for refund";
            // 
            // txtReason
            // 
            this.txtReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReason.Enabled = false;
            this.txtReason.Location = new System.Drawing.Point(15, 174);
            this.txtReason.MaxLength = 250;
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(450, 98);
            this.txtReason.TabIndex = 5;
            this.txtReason.TextChanged += new System.EventHandler(this.txtReason_TextChanged);
            // 
            // btnIssueRefund
            // 
            this.btnIssueRefund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIssueRefund.Enabled = false;
            this.btnIssueRefund.Location = new System.Drawing.Point(377, 285);
            this.btnIssueRefund.Name = "btnIssueRefund";
            this.btnIssueRefund.Size = new System.Drawing.Size(88, 23);
            this.btnIssueRefund.TabIndex = 6;
            this.btnIssueRefund.Text = "Issue Refund";
            this.btnIssueRefund.UseVisualStyleBackColor = true;
            this.btnIssueRefund.Click += new System.EventHandler(this.btnIssueRefund_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(290, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblInvoiceAmountDesc
            // 
            this.lblInvoiceAmountDesc.AutoSize = true;
            this.lblInvoiceAmountDesc.Location = new System.Drawing.Point(293, 53);
            this.lblInvoiceAmountDesc.Name = "lblInvoiceAmountDesc";
            this.lblInvoiceAmountDesc.Size = new System.Drawing.Size(81, 13);
            this.lblInvoiceAmountDesc.TabIndex = 8;
            this.lblInvoiceAmountDesc.Text = "Invoice Amount";
            // 
            // lblInvoiceAmount
            // 
            this.lblInvoiceAmount.AutoSize = true;
            this.lblInvoiceAmount.Location = new System.Drawing.Point(293, 72);
            this.lblInvoiceAmount.Name = "lblInvoiceAmount";
            this.lblInvoiceAmount.Size = new System.Drawing.Size(34, 13);
            this.lblInvoiceAmount.TabIndex = 9;
            this.lblInvoiceAmount.Text = "£0.00";
            // 
            // lblRefundAmount
            // 
            this.lblRefundAmount.AutoSize = true;
            this.lblRefundAmount.Location = new System.Drawing.Point(12, 108);
            this.lblRefundAmount.Name = "lblRefundAmount";
            this.lblRefundAmount.Size = new System.Drawing.Size(81, 13);
            this.lblRefundAmount.TabIndex = 10;
            this.lblRefundAmount.Text = "Refund Amount";
            // 
            // txtRefundAmount
            // 
            this.txtRefundAmount.Enabled = false;
            this.txtRefundAmount.Location = new System.Drawing.Point(15, 124);
            this.txtRefundAmount.Name = "txtRefundAmount";
            this.txtRefundAmount.Size = new System.Drawing.Size(110, 20);
            this.txtRefundAmount.TabIndex = 11;
            this.txtRefundAmount.TextChanged += new System.EventHandler(this.txtRefundAmount_TextChanged);
            // 
            // btnViewInvoice
            // 
            this.btnViewInvoice.Enabled = false;
            this.btnViewInvoice.Location = new System.Drawing.Point(377, 67);
            this.btnViewInvoice.Name = "btnViewInvoice";
            this.btnViewInvoice.Size = new System.Drawing.Size(88, 23);
            this.btnViewInvoice.TabIndex = 12;
            this.btnViewInvoice.Text = "View Invoice";
            this.btnViewInvoice.UseVisualStyleBackColor = true;
            this.btnViewInvoice.Click += new System.EventHandler(this.btnViewInvoice_Click);
            // 
            // IssueRefundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 320);
            this.Controls.Add(this.btnViewInvoice);
            this.Controls.Add(this.txtRefundAmount);
            this.Controls.Add(this.lblRefundAmount);
            this.Controls.Add(this.lblInvoiceAmount);
            this.Controls.Add(this.lblInvoiceAmountDesc);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnIssueRefund);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.lblSelectInvoice);
            this.Controls.Add(this.cmbInvoices);
            this.Controls.Add(this.btnSelectUser);
            this.Controls.Add(this.lblUser);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IssueRefundForm";
            this.SaveState = true;
            this.ShowIcon = false;
            this.Text = "Issue Refund";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnSelectUser;
        private System.Windows.Forms.ComboBox cmbInvoices;
        private System.Windows.Forms.Label lblSelectInvoice;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnIssueRefund;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblInvoiceAmountDesc;
        private System.Windows.Forms.Label lblInvoiceAmount;
        private System.Windows.Forms.Label lblRefundAmount;
        private System.Windows.Forms.TextBox txtRefundAmount;
        private System.Windows.Forms.Button btnViewInvoice;
    }
}