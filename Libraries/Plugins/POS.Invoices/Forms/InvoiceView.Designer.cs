namespace POS.Invoices.Forms
{
    partial class InvoiceView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceView));
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.lblCompletedByName = new System.Windows.Forms.Label();
            this.lblCompletedBy = new System.Windows.Forms.Label();
            this.lnkTrackingReference = new System.Windows.Forms.LinkLabel();
            this.lblOrderStatus = new System.Windows.Forms.Label();
            this.lblPaymentType = new System.Windows.Forms.Label();
            this.lblOrderStatusDesc = new System.Windows.Forms.Label();
            this.lblPaymentTypeDesc = new System.Windows.Forms.Label();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.lblTelephoneNo = new System.Windows.Forms.Label();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.lblShippingAddress = new System.Windows.Forms.Label();
            this.lblShipAddressDesc = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblTotalTotal = new System.Windows.Forms.Label();
            this.lblVATTotal = new System.Windows.Forms.Label();
            this.lblPostageTotal = new System.Windows.Forms.Label();
            this.lblDiscountTotal = new System.Windows.Forms.Label();
            this.lblSubtotalTotal = new System.Windows.Forms.Label();
            this.lblTotalDesc = new System.Windows.Forms.Label();
            this.lblVATDesc = new System.Windows.Forms.Label();
            this.lblPostageDesc = new System.Windows.Forms.Label();
            this.lblDiscountDesc = new System.Windows.Forms.Label();
            this.lblSubTotalDesc = new System.Windows.Forms.Label();
            this.lblOrderDetailsDesc = new System.Windows.Forms.Label();
            this.lblEmailAddressDesc = new System.Windows.Forms.Label();
            this.lblTelephoneNumber = new System.Windows.Forms.Label();
            this.lblInvoiceAddressDesc = new System.Windows.Forms.Label();
            this.lblDateDesc = new System.Windows.Forms.Label();
            this.lblInvoiceDesc = new System.Windows.Forms.Label();
            this.gridInvoiceItems = new System.Windows.Forms.DataGridView();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripMainAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMainRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMainMarkPaid = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainViewUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMainPrintLabel = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainPrintInvoice = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMainNotes = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainUserNotes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMainChangeSalesPerson = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainRefund = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainTracking = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainChangeDate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMainClose = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoiceItems)).BeginInit();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Location = new System.Drawing.Point(528, 37);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(160, 20);
            this.dtpInvoiceDate.TabIndex = 3;
            this.dtpInvoiceDate.ValueChanged += new System.EventHandler(this.dtpInvoiceDate_ValueChanged);
            // 
            // lblCompletedByName
            // 
            this.lblCompletedByName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCompletedByName.AutoSize = true;
            this.lblCompletedByName.Location = new System.Drawing.Point(144, 531);
            this.lblCompletedByName.Name = "lblCompletedByName";
            this.lblCompletedByName.Size = new System.Drawing.Size(70, 13);
            this.lblCompletedByName.TabIndex = 25;
            this.lblCompletedByName.Text = "completed by";
            // 
            // lblCompletedBy
            // 
            this.lblCompletedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCompletedBy.AutoSize = true;
            this.lblCompletedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompletedBy.Location = new System.Drawing.Point(13, 531);
            this.lblCompletedBy.Name = "lblCompletedBy";
            this.lblCompletedBy.Size = new System.Drawing.Size(117, 13);
            this.lblCompletedBy.TabIndex = 24;
            this.lblCompletedBy.Text = "Sale Completed By:";
            // 
            // lnkTrackingReference
            // 
            this.lnkTrackingReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkTrackingReference.AutoSize = true;
            this.lnkTrackingReference.Location = new System.Drawing.Point(144, 495);
            this.lnkTrackingReference.Name = "lnkTrackingReference";
            this.lnkTrackingReference.Size = new System.Drawing.Size(55, 13);
            this.lnkTrackingReference.TabIndex = 23;
            this.lnkTrackingReference.TabStop = true;
            this.lnkTrackingReference.Text = "linkLabel1";
            this.lnkTrackingReference.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTrackingReference_LinkClicked);
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrderStatus.AutoSize = true;
            this.lblOrderStatus.Location = new System.Drawing.Point(144, 475);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(41, 13);
            this.lblOrderStatus.TabIndex = 22;
            this.lblOrderStatus.Text = "label10";
            // 
            // lblPaymentType
            // 
            this.lblPaymentType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPaymentType.AutoSize = true;
            this.lblPaymentType.Location = new System.Drawing.Point(144, 449);
            this.lblPaymentType.Name = "lblPaymentType";
            this.lblPaymentType.Size = new System.Drawing.Size(35, 13);
            this.lblPaymentType.TabIndex = 20;
            this.lblPaymentType.Text = "label8";
            // 
            // lblOrderStatusDesc
            // 
            this.lblOrderStatusDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrderStatusDesc.AutoSize = true;
            this.lblOrderStatusDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderStatusDesc.Location = new System.Drawing.Point(13, 475);
            this.lblOrderStatusDesc.Name = "lblOrderStatusDesc";
            this.lblOrderStatusDesc.Size = new System.Drawing.Size(82, 13);
            this.lblOrderStatusDesc.TabIndex = 21;
            this.lblOrderStatusDesc.Text = "Order Status:";
            // 
            // lblPaymentTypeDesc
            // 
            this.lblPaymentTypeDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPaymentTypeDesc.AutoSize = true;
            this.lblPaymentTypeDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentTypeDesc.Location = new System.Drawing.Point(13, 449);
            this.lblPaymentTypeDesc.Name = "lblPaymentTypeDesc";
            this.lblPaymentTypeDesc.Size = new System.Drawing.Size(91, 13);
            this.lblPaymentTypeDesc.TabIndex = 19;
            this.lblPaymentTypeDesc.Text = "Payment Type:";
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Location = new System.Drawing.Point(525, 103);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(41, 13);
            this.lblEmailAddress.TabIndex = 12;
            this.lblEmailAddress.Text = "label10";
            // 
            // lblTelephoneNo
            // 
            this.lblTelephoneNo.AutoSize = true;
            this.lblTelephoneNo.Location = new System.Drawing.Point(525, 77);
            this.lblTelephoneNo.Name = "lblTelephoneNo";
            this.lblTelephoneNo.Size = new System.Drawing.Size(35, 13);
            this.lblTelephoneNo.TabIndex = 10;
            this.lblTelephoneNo.Text = "label8";
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Location = new System.Drawing.Point(72, 42);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(35, 13);
            this.lblInvoiceNo.TabIndex = 1;
            this.lblInvoiceNo.Text = "label8";
            // 
            // lblShippingAddress
            // 
            this.lblShippingAddress.AutoSize = true;
            this.lblShippingAddress.Location = new System.Drawing.Point(194, 94);
            this.lblShippingAddress.Name = "lblShippingAddress";
            this.lblShippingAddress.Size = new System.Drawing.Size(41, 13);
            this.lblShippingAddress.TabIndex = 8;
            this.lblShippingAddress.Text = "label17";
            // 
            // lblShipAddressDesc
            // 
            this.lblShipAddressDesc.AutoSize = true;
            this.lblShipAddressDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipAddressDesc.Location = new System.Drawing.Point(194, 77);
            this.lblShipAddressDesc.Name = "lblShipAddressDesc";
            this.lblShipAddressDesc.Size = new System.Drawing.Size(109, 13);
            this.lblShipAddressDesc.TabIndex = 7;
            this.lblShipAddressDesc.Text = "Shipping Address:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(12, 94);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(41, 13);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "label17";
            // 
            // lblTotalTotal
            // 
            this.lblTotalTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalTotal.Location = new System.Drawing.Point(688, 531);
            this.lblTotalTotal.Name = "lblTotalTotal";
            this.lblTotalTotal.Size = new System.Drawing.Size(63, 23);
            this.lblTotalTotal.TabIndex = 35;
            this.lblTotalTotal.Text = "Total";
            this.lblTotalTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVATTotal
            // 
            this.lblVATTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVATTotal.Location = new System.Drawing.Point(688, 508);
            this.lblVATTotal.Name = "lblVATTotal";
            this.lblVATTotal.Size = new System.Drawing.Size(63, 23);
            this.lblVATTotal.TabIndex = 33;
            this.lblVATTotal.Text = "VAT";
            this.lblVATTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPostageTotal
            // 
            this.lblPostageTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPostageTotal.Location = new System.Drawing.Point(688, 485);
            this.lblPostageTotal.Name = "lblPostageTotal";
            this.lblPostageTotal.Size = new System.Drawing.Size(63, 23);
            this.lblPostageTotal.TabIndex = 31;
            this.lblPostageTotal.Text = "Postage";
            this.lblPostageTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiscountTotal
            // 
            this.lblDiscountTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscountTotal.Location = new System.Drawing.Point(688, 463);
            this.lblDiscountTotal.Name = "lblDiscountTotal";
            this.lblDiscountTotal.Size = new System.Drawing.Size(63, 23);
            this.lblDiscountTotal.TabIndex = 29;
            this.lblDiscountTotal.Text = "Discount";
            this.lblDiscountTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtotalTotal
            // 
            this.lblSubtotalTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotalTotal.Location = new System.Drawing.Point(688, 439);
            this.lblSubtotalTotal.Name = "lblSubtotalTotal";
            this.lblSubtotalTotal.Size = new System.Drawing.Size(63, 23);
            this.lblSubtotalTotal.TabIndex = 27;
            this.lblSubtotalTotal.Text = "Sub Total";
            this.lblSubtotalTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalDesc
            // 
            this.lblTotalDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDesc.Location = new System.Drawing.Point(582, 531);
            this.lblTotalDesc.Name = "lblTotalDesc";
            this.lblTotalDesc.Size = new System.Drawing.Size(100, 23);
            this.lblTotalDesc.TabIndex = 34;
            this.lblTotalDesc.Text = "Total";
            this.lblTotalDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVATDesc
            // 
            this.lblVATDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVATDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVATDesc.Location = new System.Drawing.Point(582, 508);
            this.lblVATDesc.Name = "lblVATDesc";
            this.lblVATDesc.Size = new System.Drawing.Size(100, 23);
            this.lblVATDesc.TabIndex = 32;
            this.lblVATDesc.Text = "VAT";
            this.lblVATDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPostageDesc
            // 
            this.lblPostageDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPostageDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostageDesc.Location = new System.Drawing.Point(582, 485);
            this.lblPostageDesc.Name = "lblPostageDesc";
            this.lblPostageDesc.Size = new System.Drawing.Size(100, 23);
            this.lblPostageDesc.TabIndex = 30;
            this.lblPostageDesc.Text = "Postage";
            this.lblPostageDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiscountDesc
            // 
            this.lblDiscountDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscountDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountDesc.Location = new System.Drawing.Point(416, 464);
            this.lblDiscountDesc.Name = "lblDiscountDesc";
            this.lblDiscountDesc.Size = new System.Drawing.Size(266, 20);
            this.lblDiscountDesc.TabIndex = 28;
            this.lblDiscountDesc.Text = "Discount 0% (No Coupon)";
            this.lblDiscountDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubTotalDesc
            // 
            this.lblSubTotalDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubTotalDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotalDesc.Location = new System.Drawing.Point(582, 439);
            this.lblSubTotalDesc.Name = "lblSubTotalDesc";
            this.lblSubTotalDesc.Size = new System.Drawing.Size(100, 23);
            this.lblSubTotalDesc.TabIndex = 26;
            this.lblSubTotalDesc.Text = "Sub Total";
            this.lblSubTotalDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrderDetailsDesc
            // 
            this.lblOrderDetailsDesc.AutoSize = true;
            this.lblOrderDetailsDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDetailsDesc.Location = new System.Drawing.Point(12, 181);
            this.lblOrderDetailsDesc.Name = "lblOrderDetailsDesc";
            this.lblOrderDetailsDesc.Size = new System.Drawing.Size(85, 13);
            this.lblOrderDetailsDesc.TabIndex = 13;
            this.lblOrderDetailsDesc.Text = "Order Details:";
            // 
            // lblEmailAddressDesc
            // 
            this.lblEmailAddressDesc.AutoSize = true;
            this.lblEmailAddressDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailAddressDesc.Location = new System.Drawing.Point(416, 103);
            this.lblEmailAddressDesc.Name = "lblEmailAddressDesc";
            this.lblEmailAddressDesc.Size = new System.Drawing.Size(90, 13);
            this.lblEmailAddressDesc.TabIndex = 11;
            this.lblEmailAddressDesc.Text = "Email Address:";
            // 
            // lblTelephoneNumber
            // 
            this.lblTelephoneNumber.AutoSize = true;
            this.lblTelephoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelephoneNumber.Location = new System.Drawing.Point(416, 77);
            this.lblTelephoneNumber.Name = "lblTelephoneNumber";
            this.lblTelephoneNumber.Size = new System.Drawing.Size(91, 13);
            this.lblTelephoneNumber.TabIndex = 9;
            this.lblTelephoneNumber.Text = "Telephone No:";
            // 
            // lblInvoiceAddressDesc
            // 
            this.lblInvoiceAddressDesc.AutoSize = true;
            this.lblInvoiceAddressDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceAddressDesc.Location = new System.Drawing.Point(12, 77);
            this.lblInvoiceAddressDesc.Name = "lblInvoiceAddressDesc";
            this.lblInvoiceAddressDesc.Size = new System.Drawing.Size(102, 13);
            this.lblInvoiceAddressDesc.TabIndex = 5;
            this.lblInvoiceAddressDesc.Text = "Invoice Address:";
            // 
            // lblDateDesc
            // 
            this.lblDateDesc.AutoSize = true;
            this.lblDateDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateDesc.Location = new System.Drawing.Point(416, 43);
            this.lblDateDesc.Name = "lblDateDesc";
            this.lblDateDesc.Size = new System.Drawing.Size(38, 13);
            this.lblDateDesc.TabIndex = 2;
            this.lblDateDesc.Text = "Date:";
            // 
            // lblInvoiceDesc
            // 
            this.lblInvoiceDesc.AutoSize = true;
            this.lblInvoiceDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceDesc.Location = new System.Drawing.Point(12, 43);
            this.lblInvoiceDesc.Name = "lblInvoiceDesc";
            this.lblInvoiceDesc.Size = new System.Drawing.Size(53, 13);
            this.lblInvoiceDesc.TabIndex = 0;
            this.lblInvoiceDesc.Text = "Invoice:";
            // 
            // gridInvoiceItems
            // 
            this.gridInvoiceItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridInvoiceItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInvoiceItems.Location = new System.Drawing.Point(12, 197);
            this.gridInvoiceItems.Name = "gridInvoiceItems";
            this.gridInvoiceItems.Size = new System.Drawing.Size(739, 239);
            this.gridInvoiceItems.TabIndex = 46;
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMainAdd,
            this.toolStripMainDelete,
            this.toolStripMainEdit,
            this.toolStripSeparator1,
            this.toolStripMainRefresh,
            this.toolStripSeparator2,
            this.toolStripMainMarkPaid,
            this.toolStripMainViewUser,
            this.toolStripSeparator3,
            this.toolStripMainPrintLabel,
            this.toolStripMainPrintInvoice,
            this.toolStripSeparator4,
            this.toolStripMainNotes,
            this.toolStripMainUserNotes,
            this.toolStripSeparator5,
            this.toolStripMainChangeSalesPerson,
            this.toolStripMainRefund,
            this.toolStripMainTracking,
            this.toolStripMainChangeDate,
            this.toolStripSeparator6,
            this.toolStripMainClose});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(763, 25);
            this.toolStripMain.TabIndex = 47;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // toolStripMainAdd
            // 
            this.toolStripMainAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainAdd.Image")));
            this.toolStripMainAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainAdd.Name = "toolStripMainAdd";
            this.toolStripMainAdd.Size = new System.Drawing.Size(23, 22);
            // 
            // toolStripMainDelete
            // 
            this.toolStripMainDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainDelete.Image")));
            this.toolStripMainDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainDelete.Name = "toolStripMainDelete";
            this.toolStripMainDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainDelete.Click += new System.EventHandler(this.toolStripMainDelete_Click);
            // 
            // toolStripMainEdit
            // 
            this.toolStripMainEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainEdit.Image")));
            this.toolStripMainEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainEdit.Name = "toolStripMainEdit";
            this.toolStripMainEdit.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainEdit.Click += new System.EventHandler(this.toolStripMainEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripMainRefresh
            // 
            this.toolStripMainRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainRefresh.Image")));
            this.toolStripMainRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainRefresh.Name = "toolStripMainRefresh";
            this.toolStripMainRefresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainRefresh.Click += new System.EventHandler(this.toolStripMainRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripMainMarkPaid
            // 
            this.toolStripMainMarkPaid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainMarkPaid.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainMarkPaid.Image")));
            this.toolStripMainMarkPaid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainMarkPaid.Name = "toolStripMainMarkPaid";
            this.toolStripMainMarkPaid.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainMarkPaid.Text = "toolStripButton1";
            this.toolStripMainMarkPaid.Click += new System.EventHandler(this.toolStripMainMarkPaid_Click);
            // 
            // toolStripMainViewUser
            // 
            this.toolStripMainViewUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainViewUser.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainViewUser.Image")));
            this.toolStripMainViewUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainViewUser.Name = "toolStripMainViewUser";
            this.toolStripMainViewUser.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainViewUser.Text = "toolStripButton2";
            this.toolStripMainViewUser.Click += new System.EventHandler(this.toolStripMainViewUser_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripMainPrintLabel
            // 
            this.toolStripMainPrintLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainPrintLabel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainPrintLabel.Image")));
            this.toolStripMainPrintLabel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainPrintLabel.Name = "toolStripMainPrintLabel";
            this.toolStripMainPrintLabel.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainPrintLabel.Text = "toolStripButton1";
            this.toolStripMainPrintLabel.Click += new System.EventHandler(this.toolStripMainPrintLabel_Click);
            // 
            // toolStripMainPrintInvoice
            // 
            this.toolStripMainPrintInvoice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainPrintInvoice.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainPrintInvoice.Image")));
            this.toolStripMainPrintInvoice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainPrintInvoice.Name = "toolStripMainPrintInvoice";
            this.toolStripMainPrintInvoice.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainPrintInvoice.Text = "toolStripButton2";
            this.toolStripMainPrintInvoice.Click += new System.EventHandler(this.toolStripMainPrintInvoice_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripMainNotes
            // 
            this.toolStripMainNotes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainNotes.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainNotes.Image")));
            this.toolStripMainNotes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainNotes.Name = "toolStripMainNotes";
            this.toolStripMainNotes.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainNotes.Text = "toolStripButton1";
            this.toolStripMainNotes.Click += new System.EventHandler(this.toolStripMainNotes_Click);
            // 
            // toolStripMainUserNotes
            // 
            this.toolStripMainUserNotes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainUserNotes.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainUserNotes.Image")));
            this.toolStripMainUserNotes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainUserNotes.Name = "toolStripMainUserNotes";
            this.toolStripMainUserNotes.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainUserNotes.Text = "toolStripButton2";
            this.toolStripMainUserNotes.Click += new System.EventHandler(this.toolStripMainUserNotes_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripMainChangeSalesPerson
            // 
            this.toolStripMainChangeSalesPerson.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainChangeSalesPerson.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainChangeSalesPerson.Image")));
            this.toolStripMainChangeSalesPerson.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainChangeSalesPerson.Name = "toolStripMainChangeSalesPerson";
            this.toolStripMainChangeSalesPerson.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainChangeSalesPerson.Text = "toolStripButton1";
            this.toolStripMainChangeSalesPerson.Click += new System.EventHandler(this.toolStripMainChangeSalesPerson_Click);
            // 
            // toolStripMainRefund
            // 
            this.toolStripMainRefund.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainRefund.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainRefund.Image")));
            this.toolStripMainRefund.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainRefund.Name = "toolStripMainRefund";
            this.toolStripMainRefund.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainRefund.Text = "toolStripButton1";
            this.toolStripMainRefund.Click += new System.EventHandler(this.toolStripMainRefund_Click);
            // 
            // toolStripMainTracking
            // 
            this.toolStripMainTracking.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainTracking.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainTracking.Image")));
            this.toolStripMainTracking.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainTracking.Name = "toolStripMainTracking";
            this.toolStripMainTracking.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainTracking.Text = "toolStripButton1";
            this.toolStripMainTracking.Click += new System.EventHandler(this.toolStripMainTracking_Click);
            // 
            // toolStripMainChangeDate
            // 
            this.toolStripMainChangeDate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainChangeDate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainChangeDate.Image")));
            this.toolStripMainChangeDate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainChangeDate.Name = "toolStripMainChangeDate";
            this.toolStripMainChangeDate.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainChangeDate.Text = "toolStripButton1";
            this.toolStripMainChangeDate.Click += new System.EventHandler(this.toolStripMainChangeDate_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripMainClose
            // 
            this.toolStripMainClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainClose.Image")));
            this.toolStripMainClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainClose.Name = "toolStripMainClose";
            this.toolStripMainClose.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainClose.Text = "toolStripButton1";
            this.toolStripMainClose.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // InvoiceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 553);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.gridInvoiceItems);
            this.Controls.Add(this.dtpInvoiceDate);
            this.Controls.Add(this.lblCompletedByName);
            this.Controls.Add(this.lblCompletedBy);
            this.Controls.Add(this.lnkTrackingReference);
            this.Controls.Add(this.lblOrderStatus);
            this.Controls.Add(this.lblPaymentType);
            this.Controls.Add(this.lblOrderStatusDesc);
            this.Controls.Add(this.lblPaymentTypeDesc);
            this.Controls.Add(this.lblEmailAddress);
            this.Controls.Add(this.lblTelephoneNo);
            this.Controls.Add(this.lblInvoiceNo);
            this.Controls.Add(this.lblShippingAddress);
            this.Controls.Add(this.lblShipAddressDesc);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblTotalTotal);
            this.Controls.Add(this.lblVATTotal);
            this.Controls.Add(this.lblPostageTotal);
            this.Controls.Add(this.lblDiscountTotal);
            this.Controls.Add(this.lblSubtotalTotal);
            this.Controls.Add(this.lblTotalDesc);
            this.Controls.Add(this.lblVATDesc);
            this.Controls.Add(this.lblPostageDesc);
            this.Controls.Add(this.lblDiscountDesc);
            this.Controls.Add(this.lblSubTotalDesc);
            this.Controls.Add(this.lblOrderDetailsDesc);
            this.Controls.Add(this.lblEmailAddressDesc);
            this.Controls.Add(this.lblTelephoneNumber);
            this.Controls.Add(this.lblInvoiceAddressDesc);
            this.Controls.Add(this.lblDateDesc);
            this.Controls.Add(this.lblInvoiceDesc);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(616, 592);
            this.Name = "InvoiceView";
            this.SaveState = true;
            this.ShowIcon = false;
            this.Text = "View Invoice";
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoiceItems)).EndInit();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInvoiceDesc;
        private System.Windows.Forms.Label lblDateDesc;
        private System.Windows.Forms.Label lblInvoiceAddressDesc;
        private System.Windows.Forms.Label lblTelephoneNumber;
        private System.Windows.Forms.Label lblEmailAddressDesc;
        private System.Windows.Forms.Label lblOrderDetailsDesc;
        private System.Windows.Forms.Label lblSubTotalDesc;
        private System.Windows.Forms.Label lblDiscountDesc;
        private System.Windows.Forms.Label lblPostageDesc;
        private System.Windows.Forms.Label lblVATDesc;
        private System.Windows.Forms.Label lblTotalDesc;
        private System.Windows.Forms.Label lblTotalTotal;
        private System.Windows.Forms.Label lblVATTotal;
        private System.Windows.Forms.Label lblPostageTotal;
        private System.Windows.Forms.Label lblDiscountTotal;
        private System.Windows.Forms.Label lblSubtotalTotal;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblShippingAddress;
        private System.Windows.Forms.Label lblShipAddressDesc;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.Label lblTelephoneNo;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.Label lblOrderStatus;
        private System.Windows.Forms.Label lblPaymentType;
        private System.Windows.Forms.Label lblOrderStatusDesc;
        private System.Windows.Forms.Label lblPaymentTypeDesc;
        private System.Windows.Forms.LinkLabel lnkTrackingReference;
        private System.Windows.Forms.Label lblCompletedBy;
        private System.Windows.Forms.Label lblCompletedByName;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.DataGridView gridInvoiceItems;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripMainAdd;
        private System.Windows.Forms.ToolStripButton toolStripMainDelete;
        private System.Windows.Forms.ToolStripButton toolStripMainEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripMainRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripMainMarkPaid;
        private System.Windows.Forms.ToolStripButton toolStripMainViewUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripMainPrintLabel;
        private System.Windows.Forms.ToolStripButton toolStripMainPrintInvoice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripMainNotes;
        private System.Windows.Forms.ToolStripButton toolStripMainUserNotes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripMainChangeSalesPerson;
        private System.Windows.Forms.ToolStripButton toolStripMainRefund;
        private System.Windows.Forms.ToolStripButton toolStripMainTracking;
        private System.Windows.Forms.ToolStripButton toolStripMainChangeDate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripMainClose;
    }
}