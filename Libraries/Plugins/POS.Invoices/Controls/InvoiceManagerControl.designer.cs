namespace POS.Invoices.Controls
{
    partial class InvoiceManagerControl
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.statusStripInvoices = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpacer1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpacer2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstInvoices = new SharedControls.Classes.ListViewEx();
            this.chInvoice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPurchaseDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chInvoiceAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPaymentType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.btnPrintAll = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.gbDiscount = new System.Windows.Forms.GroupBox();
            this.cmbDiscount = new System.Windows.Forms.ComboBox();
            this.gbPaymentStatus = new System.Windows.Forms.GroupBox();
            this.cmbPaymentStatus = new System.Windows.Forms.ComboBox();
            this.gbDateRange = new System.Windows.Forms.GroupBox();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpFinish = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.rbSpecifyDate = new System.Windows.Forms.RadioButton();
            this.rbDateRange = new System.Windows.Forms.RadioButton();
            this.rbTodayOnly = new System.Windows.Forms.RadioButton();
            this.rbAnyDate = new System.Windows.Forms.RadioButton();
            this.gbOrderStatus = new System.Windows.Forms.GroupBox();
            this.cbOrderCancelled = new System.Windows.Forms.CheckBox();
            this.cbDispatched = new System.Windows.Forms.CheckBox();
            this.cbProcessing = new System.Windows.Forms.CheckBox();
            this.cbOrderReceived = new System.Windows.Forms.CheckBox();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.statusStripInvoices.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.gbDiscount.SuspendLayout();
            this.gbPaymentStatus.SuspendLayout();
            this.gbDateRange.SuspendLayout();
            this.gbOrderStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(766, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // statusStripInvoices
            // 
            this.statusStripInvoices.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount,
            this.toolStripStatusLabelSpacer1,
            this.toolStripStatusLabelSpacer2});
            this.statusStripInvoices.Location = new System.Drawing.Point(0, 378);
            this.statusStripInvoices.Name = "statusStripInvoices";
            this.statusStripInvoices.Size = new System.Drawing.Size(858, 22);
            this.statusStripInvoices.TabIndex = 2;
            this.statusStripInvoices.Text = "statusStrip1";
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
            // lstInvoices
            // 
            this.lstInvoices.AllowColumnReorder = true;
            this.lstInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstInvoices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chInvoice,
            this.chUserName,
            this.chPurchaseDate,
            this.chInvoiceAmount,
            this.chPaymentType,
            this.chStatus});
            this.lstInvoices.FullRowSelect = true;
            this.lstInvoices.Location = new System.Drawing.Point(3, 156);
            this.lstInvoices.Name = "lstInvoices";
            this.lstInvoices.OwnerDraw = true;
            this.lstInvoices.SaveName = "";
            this.lstInvoices.ShowToolTip = false;
            this.lstInvoices.Size = new System.Drawing.Size(852, 219);
            this.lstInvoices.TabIndex = 1;
            this.lstInvoices.UseCompatibleStateImageBehavior = false;
            this.lstInvoices.View = System.Windows.Forms.View.Details;
            this.lstInvoices.DoubleClick += new System.EventHandler(this.lstInvoices_DoubleClick);
            // 
            // chInvoice
            // 
            this.chInvoice.Text = "Invoice";
            this.chInvoice.Width = 120;
            // 
            // chUserName
            // 
            this.chUserName.Text = "Username";
            this.chUserName.Width = 200;
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
            this.chPaymentType.Width = 181;
            // 
            // chStatus
            // 
            this.chStatus.Text = "Status";
            this.chStatus.Width = 138;
            // 
            // gbOptions
            // 
            this.gbOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOptions.Controls.Add(this.btnPrintAll);
            this.gbOptions.Controls.Add(this.btnReset);
            this.gbOptions.Controls.Add(this.gbDiscount);
            this.gbOptions.Controls.Add(this.gbPaymentStatus);
            this.gbOptions.Controls.Add(this.btnSearch);
            this.gbOptions.Controls.Add(this.gbDateRange);
            this.gbOptions.Controls.Add(this.gbOrderStatus);
            this.gbOptions.Controls.Add(this.txtInvoiceNumber);
            this.gbOptions.Controls.Add(this.lblInvoiceNumber);
            this.gbOptions.Location = new System.Drawing.Point(3, 3);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(852, 147);
            this.gbOptions.TabIndex = 0;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Options";
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintAll.Location = new System.Drawing.Point(766, 88);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(75, 23);
            this.btnPrintAll.TabIndex = 16;
            this.btnPrintAll.Text = "&Print All";
            this.btnPrintAll.UseVisualStyleBackColor = true;
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(766, 58);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // gbDiscount
            // 
            this.gbDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDiscount.Controls.Add(this.cmbDiscount);
            this.gbDiscount.Location = new System.Drawing.Point(577, 79);
            this.gbDiscount.Name = "gbDiscount";
            this.gbDiscount.Size = new System.Drawing.Size(181, 52);
            this.gbDiscount.TabIndex = 14;
            this.gbDiscount.TabStop = false;
            this.gbDiscount.Text = "Discount";
            // 
            // cmbDiscount
            // 
            this.cmbDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiscount.FormattingEnabled = true;
            this.cmbDiscount.Items.AddRange(new object[] {
            "Any Payment Type",
            "Paid",
            "Paypal",
            "Phone",
            "Cheque",
            "Paynet",
            "Paypal Pending",
            "In Store"});
            this.cmbDiscount.Location = new System.Drawing.Point(6, 24);
            this.cmbDiscount.Name = "cmbDiscount";
            this.cmbDiscount.Size = new System.Drawing.Size(167, 21);
            this.cmbDiscount.TabIndex = 1;
            // 
            // gbPaymentStatus
            // 
            this.gbPaymentStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPaymentStatus.Controls.Add(this.cmbPaymentStatus);
            this.gbPaymentStatus.Location = new System.Drawing.Point(577, 20);
            this.gbPaymentStatus.Name = "gbPaymentStatus";
            this.gbPaymentStatus.Size = new System.Drawing.Size(182, 49);
            this.gbPaymentStatus.TabIndex = 13;
            this.gbPaymentStatus.TabStop = false;
            this.gbPaymentStatus.Text = "Payment Status";
            // 
            // cmbPaymentStatus
            // 
            this.cmbPaymentStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPaymentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentStatus.FormattingEnabled = true;
            this.cmbPaymentStatus.Items.AddRange(new object[] {
            "Any Payment Type",
            "Paid",
            "Paypal",
            "Phone",
            "Cheque",
            "Paynet",
            "Paypal Pending",
            "Office",
            "Salon Cash",
            "Salon Card",
            "Salon Cheque",
            "Salon Split Payment"});
            this.cmbPaymentStatus.Location = new System.Drawing.Point(6, 20);
            this.cmbPaymentStatus.Name = "cmbPaymentStatus";
            this.cmbPaymentStatus.Size = new System.Drawing.Size(167, 21);
            this.cmbPaymentStatus.TabIndex = 0;
            // 
            // gbDateRange
            // 
            this.gbDateRange.Controls.Add(this.lblDateTo);
            this.gbDateRange.Controls.Add(this.lblDateFrom);
            this.gbDateRange.Controls.Add(this.dtpFinish);
            this.gbDateRange.Controls.Add(this.dtpStart);
            this.gbDateRange.Controls.Add(this.rbSpecifyDate);
            this.gbDateRange.Controls.Add(this.rbDateRange);
            this.gbDateRange.Controls.Add(this.rbTodayOnly);
            this.gbDateRange.Controls.Add(this.rbAnyDate);
            this.gbDateRange.Location = new System.Drawing.Point(269, 19);
            this.gbDateRange.Name = "gbDateRange";
            this.gbDateRange.Size = new System.Drawing.Size(302, 113);
            this.gbDateRange.TabIndex = 11;
            this.gbDateRange.TabStop = false;
            this.gbDateRange.Text = "Date Range";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(123, 69);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(46, 13);
            this.lblDateTo.TabIndex = 18;
            this.lblDateTo.Text = "Date To";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(123, 21);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(30, 13);
            this.lblDateFrom.TabIndex = 17;
            this.lblDateFrom.Text = "Date";
            // 
            // dtpFinish
            // 
            this.dtpFinish.Location = new System.Drawing.Point(123, 85);
            this.dtpFinish.Name = "dtpFinish";
            this.dtpFinish.Size = new System.Drawing.Size(169, 20);
            this.dtpFinish.TabIndex = 16;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(123, 37);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(169, 20);
            this.dtpStart.TabIndex = 15;
            // 
            // rbSpecifyDate
            // 
            this.rbSpecifyDate.AutoSize = true;
            this.rbSpecifyDate.Location = new System.Drawing.Point(20, 88);
            this.rbSpecifyDate.Name = "rbSpecifyDate";
            this.rbSpecifyDate.Size = new System.Drawing.Size(89, 17);
            this.rbSpecifyDate.TabIndex = 14;
            this.rbSpecifyDate.TabStop = true;
            this.rbSpecifyDate.Text = "Specific Date";
            this.rbSpecifyDate.UseVisualStyleBackColor = true;
            this.rbSpecifyDate.CheckedChanged += new System.EventHandler(this.rbDateType_CheckedChanged);
            // 
            // rbDateRange
            // 
            this.rbDateRange.AutoSize = true;
            this.rbDateRange.Location = new System.Drawing.Point(20, 65);
            this.rbDateRange.Name = "rbDateRange";
            this.rbDateRange.Size = new System.Drawing.Size(83, 17);
            this.rbDateRange.TabIndex = 13;
            this.rbDateRange.Text = "Date Range";
            this.rbDateRange.UseVisualStyleBackColor = true;
            this.rbDateRange.CheckedChanged += new System.EventHandler(this.rbDateType_CheckedChanged);
            // 
            // rbTodayOnly
            // 
            this.rbTodayOnly.AutoSize = true;
            this.rbTodayOnly.Checked = true;
            this.rbTodayOnly.Location = new System.Drawing.Point(20, 42);
            this.rbTodayOnly.Name = "rbTodayOnly";
            this.rbTodayOnly.Size = new System.Drawing.Size(79, 17);
            this.rbTodayOnly.TabIndex = 12;
            this.rbTodayOnly.TabStop = true;
            this.rbTodayOnly.Text = "Today Only";
            this.rbTodayOnly.UseVisualStyleBackColor = true;
            this.rbTodayOnly.CheckedChanged += new System.EventHandler(this.rbDateType_CheckedChanged);
            // 
            // rbAnyDate
            // 
            this.rbAnyDate.AutoSize = true;
            this.rbAnyDate.Location = new System.Drawing.Point(20, 19);
            this.rbAnyDate.Name = "rbAnyDate";
            this.rbAnyDate.Size = new System.Drawing.Size(69, 17);
            this.rbAnyDate.TabIndex = 11;
            this.rbAnyDate.Text = "Any Date";
            this.rbAnyDate.UseVisualStyleBackColor = true;
            this.rbAnyDate.CheckedChanged += new System.EventHandler(this.rbDateType_CheckedChanged);
            // 
            // gbOrderStatus
            // 
            this.gbOrderStatus.Controls.Add(this.cbOrderCancelled);
            this.gbOrderStatus.Controls.Add(this.cbDispatched);
            this.gbOrderStatus.Controls.Add(this.cbProcessing);
            this.gbOrderStatus.Controls.Add(this.cbOrderReceived);
            this.gbOrderStatus.Location = new System.Drawing.Point(131, 19);
            this.gbOrderStatus.Name = "gbOrderStatus";
            this.gbOrderStatus.Size = new System.Drawing.Size(132, 113);
            this.gbOrderStatus.TabIndex = 6;
            this.gbOrderStatus.TabStop = false;
            this.gbOrderStatus.Text = "Order Status";
            // 
            // cbOrderCancelled
            // 
            this.cbOrderCancelled.AutoSize = true;
            this.cbOrderCancelled.Location = new System.Drawing.Point(15, 91);
            this.cbOrderCancelled.Name = "cbOrderCancelled";
            this.cbOrderCancelled.Size = new System.Drawing.Size(102, 17);
            this.cbOrderCancelled.TabIndex = 9;
            this.cbOrderCancelled.Text = "Order Cancelled";
            this.cbOrderCancelled.UseVisualStyleBackColor = true;
            // 
            // cbDispatched
            // 
            this.cbDispatched.AutoSize = true;
            this.cbDispatched.Location = new System.Drawing.Point(15, 67);
            this.cbDispatched.Name = "cbDispatched";
            this.cbDispatched.Size = new System.Drawing.Size(109, 17);
            this.cbDispatched.TabIndex = 8;
            this.cbDispatched.Text = "Order Dispatched";
            this.cbDispatched.UseVisualStyleBackColor = true;
            // 
            // cbProcessing
            // 
            this.cbProcessing.AutoSize = true;
            this.cbProcessing.Checked = true;
            this.cbProcessing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProcessing.Location = new System.Drawing.Point(15, 43);
            this.cbProcessing.Name = "cbProcessing";
            this.cbProcessing.Size = new System.Drawing.Size(107, 17);
            this.cbProcessing.TabIndex = 7;
            this.cbProcessing.Text = "Order Processing";
            this.cbProcessing.UseVisualStyleBackColor = true;
            // 
            // cbOrderReceived
            // 
            this.cbOrderReceived.AutoSize = true;
            this.cbOrderReceived.Checked = true;
            this.cbOrderReceived.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOrderReceived.Location = new System.Drawing.Point(15, 19);
            this.cbOrderReceived.Name = "cbOrderReceived";
            this.cbOrderReceived.Size = new System.Drawing.Size(101, 17);
            this.cbOrderReceived.TabIndex = 6;
            this.cbOrderReceived.Text = "Order Received";
            this.cbOrderReceived.UseVisualStyleBackColor = true;
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(10, 49);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(102, 20);
            this.txtInvoiceNumber.TabIndex = 1;
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Location = new System.Drawing.Point(7, 33);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(82, 13);
            this.lblInvoiceNumber.TabIndex = 0;
            this.lblInvoiceNumber.Text = "Invoice Number";
            // 
            // InvoiceManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStripInvoices);
            this.Controls.Add(this.lstInvoices);
            this.Controls.Add(this.gbOptions);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MinimumSize = new System.Drawing.Size(803, 400);
            this.Name = "InvoiceManagerControl";
            this.Size = new System.Drawing.Size(858, 400);
            this.statusStripInvoices.ResumeLayout(false);
            this.statusStripInvoices.PerformLayout();
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.gbDiscount.ResumeLayout(false);
            this.gbPaymentStatus.ResumeLayout(false);
            this.gbDateRange.ResumeLayout(false);
            this.gbDateRange.PerformLayout();
            this.gbOrderStatus.ResumeLayout(false);
            this.gbOrderStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox gbDateRange;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpFinish;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.RadioButton rbSpecifyDate;
        private System.Windows.Forms.RadioButton rbDateRange;
        private System.Windows.Forms.RadioButton rbTodayOnly;
        private System.Windows.Forms.RadioButton rbAnyDate;
        private System.Windows.Forms.GroupBox gbOrderStatus;
        private System.Windows.Forms.CheckBox cbOrderCancelled;
        private System.Windows.Forms.CheckBox cbDispatched;
        private System.Windows.Forms.CheckBox cbProcessing;
        private System.Windows.Forms.CheckBox cbOrderReceived;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private SharedControls.Classes.ListViewEx lstInvoices;
        private System.Windows.Forms.ColumnHeader chInvoice;
        private System.Windows.Forms.ColumnHeader chUserName;
        private System.Windows.Forms.ColumnHeader chPurchaseDate;
        private System.Windows.Forms.StatusStrip statusStripInvoices;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpacer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpacer2;
        private System.Windows.Forms.GroupBox gbPaymentStatus;
        private System.Windows.Forms.ComboBox cmbPaymentStatus;
        private System.Windows.Forms.ColumnHeader chInvoiceAmount;
        private System.Windows.Forms.GroupBox gbDiscount;
        private System.Windows.Forms.ComboBox cmbDiscount;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnPrintAll;
        private System.Windows.Forms.ColumnHeader chPaymentType;
        private System.Windows.Forms.ColumnHeader chStatus;
    }
}