namespace SieraDelta.POS.Orders.Forms
{
    partial class OrderView
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblPriceDesc = new System.Windows.Forms.Label();
            this.lblQuantityDesc = new System.Windows.Forms.Label();
            this.lblCostDesc = new System.Windows.Forms.Label();
            this.lblDescriptionDesc = new System.Windows.Forms.Label();
            this.lblOrderStatus = new System.Windows.Forms.Label();
            this.lblPaymentType = new System.Windows.Forms.Label();
            this.lblOrderStatusDesc = new System.Windows.Forms.Label();
            this.lblPaymentTypeDesc = new System.Windows.Forms.Label();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.lblTelephoneNo = new System.Windows.Forms.Label();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
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
            this.pnlOrderItems = new System.Windows.Forms.FlowLayoutPanel();
            this.lblEmailAddressDesc = new System.Windows.Forms.Label();
            this.lblTelephoneNoDesc = new System.Windows.Forms.Label();
            this.lblInvoiceAddressDesc = new System.Windows.Forms.Label();
            this.lblDateDesc = new System.Windows.Forms.Label();
            this.lblInvoiceDesc = new System.Windows.Forms.Label();
            this.btnMaskAsPaid = new System.Windows.Forms.Button();
            this.btnViewUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(411, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 23);
            this.btnCancel.TabIndex = 77;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(411, 108);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 23);
            this.btnClose.TabIndex = 76;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblPriceDesc
            // 
            this.lblPriceDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPriceDesc.AutoSize = true;
            this.lblPriceDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceDesc.Location = new System.Drawing.Point(499, 248);
            this.lblPriceDesc.Name = "lblPriceDesc";
            this.lblPriceDesc.Size = new System.Drawing.Size(32, 13);
            this.lblPriceDesc.TabIndex = 75;
            this.lblPriceDesc.Text = "Cost";
            // 
            // lblQuantityDesc
            // 
            this.lblQuantityDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuantityDesc.AutoSize = true;
            this.lblQuantityDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantityDesc.Location = new System.Drawing.Point(438, 248);
            this.lblQuantityDesc.Name = "lblQuantityDesc";
            this.lblQuantityDesc.Size = new System.Drawing.Size(26, 13);
            this.lblQuantityDesc.TabIndex = 74;
            this.lblQuantityDesc.Text = "Qty";
            // 
            // lblCostDesc
            // 
            this.lblCostDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCostDesc.AutoSize = true;
            this.lblCostDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostDesc.Location = new System.Drawing.Point(377, 248);
            this.lblCostDesc.Name = "lblCostDesc";
            this.lblCostDesc.Size = new System.Drawing.Size(36, 13);
            this.lblCostDesc.TabIndex = 73;
            this.lblCostDesc.Text = "Price";
            // 
            // lblDescriptionDesc
            // 
            this.lblDescriptionDesc.AutoSize = true;
            this.lblDescriptionDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionDesc.Location = new System.Drawing.Point(21, 248);
            this.lblDescriptionDesc.Name = "lblDescriptionDesc";
            this.lblDescriptionDesc.Size = new System.Drawing.Size(71, 13);
            this.lblDescriptionDesc.TabIndex = 72;
            this.lblDescriptionDesc.Text = "Description";
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrderStatus.AutoSize = true;
            this.lblOrderStatus.Location = new System.Drawing.Point(115, 467);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(41, 13);
            this.lblOrderStatus.TabIndex = 71;
            this.lblOrderStatus.Text = "label10";
            // 
            // lblPaymentType
            // 
            this.lblPaymentType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPaymentType.AutoSize = true;
            this.lblPaymentType.Location = new System.Drawing.Point(115, 442);
            this.lblPaymentType.Name = "lblPaymentType";
            this.lblPaymentType.Size = new System.Drawing.Size(35, 13);
            this.lblPaymentType.TabIndex = 70;
            this.lblPaymentType.Text = "label8";
            // 
            // lblOrderStatusDesc
            // 
            this.lblOrderStatusDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrderStatusDesc.AutoSize = true;
            this.lblOrderStatusDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderStatusDesc.Location = new System.Drawing.Point(12, 468);
            this.lblOrderStatusDesc.Name = "lblOrderStatusDesc";
            this.lblOrderStatusDesc.Size = new System.Drawing.Size(82, 13);
            this.lblOrderStatusDesc.TabIndex = 69;
            this.lblOrderStatusDesc.Text = "Order Status:";
            // 
            // lblPaymentTypeDesc
            // 
            this.lblPaymentTypeDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPaymentTypeDesc.AutoSize = true;
            this.lblPaymentTypeDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentTypeDesc.Location = new System.Drawing.Point(12, 442);
            this.lblPaymentTypeDesc.Name = "lblPaymentTypeDesc";
            this.lblPaymentTypeDesc.Size = new System.Drawing.Size(91, 13);
            this.lblPaymentTypeDesc.TabIndex = 68;
            this.lblPaymentTypeDesc.Text = "Payment Type:";
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Location = new System.Drawing.Point(124, 209);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(41, 13);
            this.lblEmailAddress.TabIndex = 65;
            this.lblEmailAddress.Text = "label10";
            // 
            // lblTelephoneNo
            // 
            this.lblTelephoneNo.AutoSize = true;
            this.lblTelephoneNo.Location = new System.Drawing.Point(121, 184);
            this.lblTelephoneNo.Name = "lblTelephoneNo";
            this.lblTelephoneNo.Size = new System.Drawing.Size(35, 13);
            this.lblTelephoneNo.TabIndex = 64;
            this.lblTelephoneNo.Text = "label8";
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.AutoSize = true;
            this.lblInvoiceDate.Location = new System.Drawing.Point(72, 31);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(41, 13);
            this.lblInvoiceDate.TabIndex = 63;
            this.lblInvoiceDate.Text = "label10";
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Location = new System.Drawing.Point(72, 5);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(35, 13);
            this.lblInvoiceNo.TabIndex = 62;
            this.lblInvoiceNo.Text = "label8";
            // 
            // lblShippingAddress
            // 
            this.lblShippingAddress.AutoSize = true;
            this.lblShippingAddress.Location = new System.Drawing.Point(194, 75);
            this.lblShippingAddress.Name = "lblShippingAddress";
            this.lblShippingAddress.Size = new System.Drawing.Size(41, 13);
            this.lblShippingAddress.TabIndex = 61;
            this.lblShippingAddress.Text = "label17";
            // 
            // lblShipAddressDesc
            // 
            this.lblShipAddressDesc.AutoSize = true;
            this.lblShipAddressDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipAddressDesc.Location = new System.Drawing.Point(194, 58);
            this.lblShipAddressDesc.Name = "lblShipAddressDesc";
            this.lblShipAddressDesc.Size = new System.Drawing.Size(109, 13);
            this.lblShipAddressDesc.TabIndex = 60;
            this.lblShipAddressDesc.Text = "Shipping Address:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(12, 75);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(41, 13);
            this.lblAddress.TabIndex = 59;
            this.lblAddress.Text = "label17";
            // 
            // lblTotalTotal
            // 
            this.lblTotalTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalTotal.Location = new System.Drawing.Point(483, 524);
            this.lblTotalTotal.Name = "lblTotalTotal";
            this.lblTotalTotal.Size = new System.Drawing.Size(63, 23);
            this.lblTotalTotal.TabIndex = 58;
            this.lblTotalTotal.Text = "Total";
            this.lblTotalTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVATTotal
            // 
            this.lblVATTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVATTotal.Location = new System.Drawing.Point(483, 501);
            this.lblVATTotal.Name = "lblVATTotal";
            this.lblVATTotal.Size = new System.Drawing.Size(63, 23);
            this.lblVATTotal.TabIndex = 57;
            this.lblVATTotal.Text = "VAT";
            this.lblVATTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPostageTotal
            // 
            this.lblPostageTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPostageTotal.Location = new System.Drawing.Point(483, 478);
            this.lblPostageTotal.Name = "lblPostageTotal";
            this.lblPostageTotal.Size = new System.Drawing.Size(63, 23);
            this.lblPostageTotal.TabIndex = 56;
            this.lblPostageTotal.Text = "Postage";
            this.lblPostageTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiscountTotal
            // 
            this.lblDiscountTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscountTotal.Location = new System.Drawing.Point(483, 456);
            this.lblDiscountTotal.Name = "lblDiscountTotal";
            this.lblDiscountTotal.Size = new System.Drawing.Size(63, 23);
            this.lblDiscountTotal.TabIndex = 55;
            this.lblDiscountTotal.Text = "Discount";
            this.lblDiscountTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtotalTotal
            // 
            this.lblSubtotalTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotalTotal.Location = new System.Drawing.Point(483, 432);
            this.lblSubtotalTotal.Name = "lblSubtotalTotal";
            this.lblSubtotalTotal.Size = new System.Drawing.Size(63, 23);
            this.lblSubtotalTotal.TabIndex = 54;
            this.lblSubtotalTotal.Text = "Sub Total";
            this.lblSubtotalTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalDesc
            // 
            this.lblTotalDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDesc.Location = new System.Drawing.Point(377, 524);
            this.lblTotalDesc.Name = "lblTotalDesc";
            this.lblTotalDesc.Size = new System.Drawing.Size(100, 23);
            this.lblTotalDesc.TabIndex = 53;
            this.lblTotalDesc.Text = "Total";
            this.lblTotalDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVATDesc
            // 
            this.lblVATDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVATDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVATDesc.Location = new System.Drawing.Point(377, 501);
            this.lblVATDesc.Name = "lblVATDesc";
            this.lblVATDesc.Size = new System.Drawing.Size(100, 23);
            this.lblVATDesc.TabIndex = 52;
            this.lblVATDesc.Text = "VAT";
            this.lblVATDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPostageDesc
            // 
            this.lblPostageDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPostageDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostageDesc.Location = new System.Drawing.Point(377, 478);
            this.lblPostageDesc.Name = "lblPostageDesc";
            this.lblPostageDesc.Size = new System.Drawing.Size(100, 23);
            this.lblPostageDesc.TabIndex = 51;
            this.lblPostageDesc.Text = "Postage";
            this.lblPostageDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiscountDesc
            // 
            this.lblDiscountDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscountDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountDesc.Location = new System.Drawing.Point(211, 457);
            this.lblDiscountDesc.Name = "lblDiscountDesc";
            this.lblDiscountDesc.Size = new System.Drawing.Size(266, 20);
            this.lblDiscountDesc.TabIndex = 50;
            this.lblDiscountDesc.Text = "Discount 0% (No Coupon)";
            this.lblDiscountDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubTotalDesc
            // 
            this.lblSubTotalDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubTotalDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotalDesc.Location = new System.Drawing.Point(377, 432);
            this.lblSubTotalDesc.Name = "lblSubTotalDesc";
            this.lblSubTotalDesc.Size = new System.Drawing.Size(100, 23);
            this.lblSubTotalDesc.TabIndex = 49;
            this.lblSubTotalDesc.Text = "Sub Total";
            this.lblSubTotalDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrderDetailsDesc
            // 
            this.lblOrderDetailsDesc.AutoSize = true;
            this.lblOrderDetailsDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDetailsDesc.Location = new System.Drawing.Point(12, 232);
            this.lblOrderDetailsDesc.Name = "lblOrderDetailsDesc";
            this.lblOrderDetailsDesc.Size = new System.Drawing.Size(85, 13);
            this.lblOrderDetailsDesc.TabIndex = 48;
            this.lblOrderDetailsDesc.Text = "Order Details:";
            // 
            // pnlOrderItems
            // 
            this.pnlOrderItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOrderItems.AutoScroll = true;
            this.pnlOrderItems.Location = new System.Drawing.Point(15, 264);
            this.pnlOrderItems.Name = "pnlOrderItems";
            this.pnlOrderItems.Size = new System.Drawing.Size(531, 165);
            this.pnlOrderItems.TabIndex = 47;
            this.pnlOrderItems.SizeChanged += new System.EventHandler(this.pnlOrderItems_SizeChanged);
            // 
            // lblEmailAddressDesc
            // 
            this.lblEmailAddressDesc.AutoSize = true;
            this.lblEmailAddressDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailAddressDesc.Location = new System.Drawing.Point(12, 210);
            this.lblEmailAddressDesc.Name = "lblEmailAddressDesc";
            this.lblEmailAddressDesc.Size = new System.Drawing.Size(90, 13);
            this.lblEmailAddressDesc.TabIndex = 46;
            this.lblEmailAddressDesc.Text = "Email Address:";
            // 
            // lblTelephoneNoDesc
            // 
            this.lblTelephoneNoDesc.AutoSize = true;
            this.lblTelephoneNoDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelephoneNoDesc.Location = new System.Drawing.Point(12, 184);
            this.lblTelephoneNoDesc.Name = "lblTelephoneNoDesc";
            this.lblTelephoneNoDesc.Size = new System.Drawing.Size(91, 13);
            this.lblTelephoneNoDesc.TabIndex = 45;
            this.lblTelephoneNoDesc.Text = "Telephone No:";
            // 
            // lblInvoiceAddressDesc
            // 
            this.lblInvoiceAddressDesc.AutoSize = true;
            this.lblInvoiceAddressDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceAddressDesc.Location = new System.Drawing.Point(12, 58);
            this.lblInvoiceAddressDesc.Name = "lblInvoiceAddressDesc";
            this.lblInvoiceAddressDesc.Size = new System.Drawing.Size(102, 13);
            this.lblInvoiceAddressDesc.TabIndex = 44;
            this.lblInvoiceAddressDesc.Text = "Invoice Address:";
            // 
            // lblDateDesc
            // 
            this.lblDateDesc.AutoSize = true;
            this.lblDateDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateDesc.Location = new System.Drawing.Point(12, 31);
            this.lblDateDesc.Name = "lblDateDesc";
            this.lblDateDesc.Size = new System.Drawing.Size(38, 13);
            this.lblDateDesc.TabIndex = 43;
            this.lblDateDesc.Text = "Date:";
            // 
            // lblInvoiceDesc
            // 
            this.lblInvoiceDesc.AutoSize = true;
            this.lblInvoiceDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceDesc.Location = new System.Drawing.Point(12, 6);
            this.lblInvoiceDesc.Name = "lblInvoiceDesc";
            this.lblInvoiceDesc.Size = new System.Drawing.Size(53, 13);
            this.lblInvoiceDesc.TabIndex = 42;
            this.lblInvoiceDesc.Text = "Invoice:";
            // 
            // btnMaskAsPaid
            // 
            this.btnMaskAsPaid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaskAsPaid.Location = new System.Drawing.Point(411, 36);
            this.btnMaskAsPaid.Name = "btnMaskAsPaid";
            this.btnMaskAsPaid.Size = new System.Drawing.Size(135, 23);
            this.btnMaskAsPaid.TabIndex = 78;
            this.btnMaskAsPaid.Text = "Mark as Paid";
            this.btnMaskAsPaid.UseVisualStyleBackColor = true;
            this.btnMaskAsPaid.Click += new System.EventHandler(this.btnMaskAsPaid_Click);
            // 
            // btnViewUser
            // 
            this.btnViewUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewUser.Location = new System.Drawing.Point(411, 70);
            this.btnViewUser.Name = "btnViewUser";
            this.btnViewUser.Size = new System.Drawing.Size(135, 23);
            this.btnViewUser.TabIndex = 79;
            this.btnViewUser.Text = "View User";
            this.btnViewUser.UseVisualStyleBackColor = true;
            this.btnViewUser.Click += new System.EventHandler(this.btnViewUser_Click);
            // 
            // OrderView
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 553);
            this.Controls.Add(this.btnViewUser);
            this.Controls.Add(this.btnMaskAsPaid);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblPriceDesc);
            this.Controls.Add(this.lblQuantityDesc);
            this.Controls.Add(this.lblCostDesc);
            this.Controls.Add(this.lblDescriptionDesc);
            this.Controls.Add(this.lblOrderStatus);
            this.Controls.Add(this.lblPaymentType);
            this.Controls.Add(this.lblOrderStatusDesc);
            this.Controls.Add(this.lblPaymentTypeDesc);
            this.Controls.Add(this.lblEmailAddress);
            this.Controls.Add(this.lblTelephoneNo);
            this.Controls.Add(this.lblInvoiceDate);
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
            this.Controls.Add(this.pnlOrderItems);
            this.Controls.Add(this.lblEmailAddressDesc);
            this.Controls.Add(this.lblTelephoneNoDesc);
            this.Controls.Add(this.lblInvoiceAddressDesc);
            this.Controls.Add(this.lblDateDesc);
            this.Controls.Add(this.lblInvoiceDesc);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderView";
            this.SaveState = true;
            this.Text = "View Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblPriceDesc;
        private System.Windows.Forms.Label lblQuantityDesc;
        private System.Windows.Forms.Label lblCostDesc;
        private System.Windows.Forms.Label lblDescriptionDesc;
        private System.Windows.Forms.Label lblOrderStatus;
        private System.Windows.Forms.Label lblPaymentType;
        private System.Windows.Forms.Label lblOrderStatusDesc;
        private System.Windows.Forms.Label lblPaymentTypeDesc;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.Label lblTelephoneNo;
        private System.Windows.Forms.Label lblInvoiceDate;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.Label lblShippingAddress;
        private System.Windows.Forms.Label lblShipAddressDesc;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblTotalTotal;
        private System.Windows.Forms.Label lblVATTotal;
        private System.Windows.Forms.Label lblPostageTotal;
        private System.Windows.Forms.Label lblDiscountTotal;
        private System.Windows.Forms.Label lblSubtotalTotal;
        private System.Windows.Forms.Label lblTotalDesc;
        private System.Windows.Forms.Label lblVATDesc;
        private System.Windows.Forms.Label lblPostageDesc;
        private System.Windows.Forms.Label lblDiscountDesc;
        private System.Windows.Forms.Label lblSubTotalDesc;
        private System.Windows.Forms.Label lblOrderDetailsDesc;
        private System.Windows.Forms.FlowLayoutPanel pnlOrderItems;
        private System.Windows.Forms.Label lblEmailAddressDesc;
        private System.Windows.Forms.Label lblTelephoneNoDesc;
        private System.Windows.Forms.Label lblInvoiceAddressDesc;
        private System.Windows.Forms.Label lblDateDesc;
        private System.Windows.Forms.Label lblInvoiceDesc;
        private System.Windows.Forms.Button btnMaskAsPaid;
        private System.Windows.Forms.Button btnViewUser;
    }
}