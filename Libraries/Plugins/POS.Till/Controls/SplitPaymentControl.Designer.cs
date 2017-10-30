namespace POS.Till.Controls
{
    partial class SplitPaymentControl
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
            this.components = new System.ComponentModel.Container();
            this.lblAmountDueTotal = new System.Windows.Forms.Label();
            this.lblAmountDue = new System.Windows.Forms.Label();
            this.lblChangeDue = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblTotalCash = new System.Windows.Forms.Label();
            this.lblTotalCheques = new System.Windows.Forms.Label();
            this.lblTotalCard = new System.Windows.Forms.Label();
            this.lblTotalVouchers = new System.Windows.Forms.Label();
            this.txtTotalCash = new System.Windows.Forms.TextBox();
            this.txtTotalCheque = new System.Windows.Forms.TextBox();
            this.txtTotalCard = new System.Windows.Forms.TextBox();
            this.txtTotalVoucher = new System.Windows.Forms.TextBox();
            this.lblTotalTendered = new System.Windows.Forms.Label();
            this.lblTendered = new System.Windows.Forms.Label();
            this.lstVouchers = new System.Windows.Forms.ListBox();
            this.pumVouchers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pumVouchersAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.pumVouchersRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.pumVouchers.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAmountDueTotal
            // 
            this.lblAmountDueTotal.AutoSize = true;
            this.lblAmountDueTotal.Location = new System.Drawing.Point(127, 9);
            this.lblAmountDueTotal.Name = "lblAmountDueTotal";
            this.lblAmountDueTotal.Size = new System.Drawing.Size(93, 13);
            this.lblAmountDueTotal.TabIndex = 1;
            this.lblAmountDueTotal.Text = "Total Amount Due";
            // 
            // lblAmountDue
            // 
            this.lblAmountDue.AutoSize = true;
            this.lblAmountDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountDue.Location = new System.Drawing.Point(14, 9);
            this.lblAmountDue.Name = "lblAmountDue";
            this.lblAmountDue.Size = new System.Drawing.Size(66, 13);
            this.lblAmountDue.TabIndex = 0;
            this.lblAmountDue.Text = "Amount Due";
            // 
            // lblChangeDue
            // 
            this.lblChangeDue.AutoSize = true;
            this.lblChangeDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeDue.Location = new System.Drawing.Point(127, 57);
            this.lblChangeDue.Name = "lblChangeDue";
            this.lblChangeDue.Size = new System.Drawing.Size(39, 13);
            this.lblChangeDue.TabIndex = 5;
            this.lblChangeDue.Text = "£0.00";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(14, 57);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(46, 13);
            this.lblBalance.TabIndex = 4;
            this.lblBalance.Text = "Balance";
            // 
            // lblTotalCash
            // 
            this.lblTotalCash.AutoSize = true;
            this.lblTotalCash.Location = new System.Drawing.Point(15, 86);
            this.lblTotalCash.Name = "lblTotalCash";
            this.lblTotalCash.Size = new System.Drawing.Size(58, 13);
            this.lblTotalCash.TabIndex = 6;
            this.lblTotalCash.Text = "Total Cash";
            // 
            // lblTotalCheques
            // 
            this.lblTotalCheques.AutoSize = true;
            this.lblTotalCheques.Location = new System.Drawing.Point(15, 117);
            this.lblTotalCheques.Name = "lblTotalCheques";
            this.lblTotalCheques.Size = new System.Drawing.Size(76, 13);
            this.lblTotalCheques.TabIndex = 8;
            this.lblTotalCheques.Text = "Total Cheques";
            // 
            // lblTotalCard
            // 
            this.lblTotalCard.AutoSize = true;
            this.lblTotalCard.Location = new System.Drawing.Point(15, 147);
            this.lblTotalCard.Name = "lblTotalCard";
            this.lblTotalCard.Size = new System.Drawing.Size(56, 13);
            this.lblTotalCard.TabIndex = 10;
            this.lblTotalCard.Text = "Total Card";
            // 
            // lblTotalVouchers
            // 
            this.lblTotalVouchers.AutoSize = true;
            this.lblTotalVouchers.Location = new System.Drawing.Point(15, 182);
            this.lblTotalVouchers.Name = "lblTotalVouchers";
            this.lblTotalVouchers.Size = new System.Drawing.Size(79, 13);
            this.lblTotalVouchers.TabIndex = 12;
            this.lblTotalVouchers.Text = "Total Vouchers";
            // 
            // txtTotalCash
            // 
            this.txtTotalCash.Location = new System.Drawing.Point(130, 83);
            this.txtTotalCash.Name = "txtTotalCash";
            this.txtTotalCash.Size = new System.Drawing.Size(127, 20);
            this.txtTotalCash.TabIndex = 7;
            this.txtTotalCash.TextChanged += new System.EventHandler(this.txtTotalCash_TextChanged);
            this.txtTotalCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotalCash_KeyPress);
            // 
            // txtTotalCheque
            // 
            this.txtTotalCheque.Location = new System.Drawing.Point(130, 114);
            this.txtTotalCheque.Name = "txtTotalCheque";
            this.txtTotalCheque.Size = new System.Drawing.Size(127, 20);
            this.txtTotalCheque.TabIndex = 9;
            this.txtTotalCheque.TextChanged += new System.EventHandler(this.txtTotalCash_TextChanged);
            this.txtTotalCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotalCash_KeyPress);
            // 
            // txtTotalCard
            // 
            this.txtTotalCard.Location = new System.Drawing.Point(130, 144);
            this.txtTotalCard.Name = "txtTotalCard";
            this.txtTotalCard.Size = new System.Drawing.Size(127, 20);
            this.txtTotalCard.TabIndex = 11;
            this.txtTotalCard.TextChanged += new System.EventHandler(this.txtTotalCash_TextChanged);
            this.txtTotalCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotalCash_KeyPress);
            // 
            // txtTotalVoucher
            // 
            this.txtTotalVoucher.Location = new System.Drawing.Point(131, 179);
            this.txtTotalVoucher.Name = "txtTotalVoucher";
            this.txtTotalVoucher.ReadOnly = true;
            this.txtTotalVoucher.Size = new System.Drawing.Size(127, 20);
            this.txtTotalVoucher.TabIndex = 13;
            this.txtTotalVoucher.TextChanged += new System.EventHandler(this.txtTotalCash_TextChanged);
            // 
            // lblTotalTendered
            // 
            this.lblTotalTendered.AutoSize = true;
            this.lblTotalTendered.Location = new System.Drawing.Point(127, 34);
            this.lblTotalTendered.Name = "lblTotalTendered";
            this.lblTotalTendered.Size = new System.Drawing.Size(28, 13);
            this.lblTotalTendered.TabIndex = 3;
            this.lblTotalTendered.Text = "0.00";
            // 
            // lblTendered
            // 
            this.lblTendered.AutoSize = true;
            this.lblTendered.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTendered.Location = new System.Drawing.Point(14, 34);
            this.lblTendered.Name = "lblTendered";
            this.lblTendered.Size = new System.Drawing.Size(80, 13);
            this.lblTendered.TabIndex = 2;
            this.lblTendered.Text = "Total Tendered";
            // 
            // lstVouchers
            // 
            this.lstVouchers.ContextMenuStrip = this.pumVouchers;
            this.lstVouchers.FormattingEnabled = true;
            this.lstVouchers.Location = new System.Drawing.Point(18, 205);
            this.lstVouchers.Name = "lstVouchers";
            this.lstVouchers.Size = new System.Drawing.Size(239, 69);
            this.lstVouchers.TabIndex = 14;
            this.lstVouchers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstVouchers_KeyPress);
            // 
            // pumVouchers
            // 
            this.pumVouchers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pumVouchersAdd,
            this.pumVouchersRemove});
            this.pumVouchers.Name = "pumVouchers";
            this.pumVouchers.Size = new System.Drawing.Size(164, 48);
            this.pumVouchers.Opening += new System.ComponentModel.CancelEventHandler(this.pumVouchers_Opening);
            // 
            // pumVouchersAdd
            // 
            this.pumVouchersAdd.Name = "pumVouchersAdd";
            this.pumVouchersAdd.Size = new System.Drawing.Size(163, 22);
            this.pumVouchersAdd.Text = "Add Voucher";
            this.pumVouchersAdd.Click += new System.EventHandler(this.pumVouchersAdd_Click);
            // 
            // pumVouchersRemove
            // 
            this.pumVouchersRemove.Name = "pumVouchersRemove";
            this.pumVouchersRemove.Size = new System.Drawing.Size(163, 22);
            this.pumVouchersRemove.Text = "Remove Voucher";
            this.pumVouchersRemove.Click += new System.EventHandler(this.pumVouchersRemove_Click);
            // 
            // SplitPaymentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstVouchers);
            this.Controls.Add(this.lblTotalTendered);
            this.Controls.Add(this.lblTendered);
            this.Controls.Add(this.txtTotalVoucher);
            this.Controls.Add(this.txtTotalCard);
            this.Controls.Add(this.txtTotalCheque);
            this.Controls.Add(this.txtTotalCash);
            this.Controls.Add(this.lblTotalVouchers);
            this.Controls.Add(this.lblTotalCard);
            this.Controls.Add(this.lblTotalCheques);
            this.Controls.Add(this.lblTotalCash);
            this.Controls.Add(this.lblChangeDue);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblAmountDueTotal);
            this.Controls.Add(this.lblAmountDue);
            this.Name = "SplitPaymentControl";
            this.Size = new System.Drawing.Size(284, 285);
            this.pumVouchers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAmountDueTotal;
        private System.Windows.Forms.Label lblAmountDue;
        private System.Windows.Forms.Label lblChangeDue;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblTotalCash;
        private System.Windows.Forms.Label lblTotalCheques;
        private System.Windows.Forms.Label lblTotalCard;
        private System.Windows.Forms.Label lblTotalVouchers;
        private System.Windows.Forms.TextBox txtTotalCash;
        private System.Windows.Forms.TextBox txtTotalCheque;
        private System.Windows.Forms.TextBox txtTotalCard;
        private System.Windows.Forms.TextBox txtTotalVoucher;
        private System.Windows.Forms.Label lblTotalTendered;
        private System.Windows.Forms.Label lblTendered;
        private System.Windows.Forms.ListBox lstVouchers;
        private System.Windows.Forms.ContextMenuStrip pumVouchers;
        private System.Windows.Forms.ToolStripMenuItem pumVouchersAdd;
        private System.Windows.Forms.ToolStripMenuItem pumVouchersRemove;
    }
}
