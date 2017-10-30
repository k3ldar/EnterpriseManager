namespace POS.Invoices.Forms
{
    partial class CreateOrder
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateOrder));
            this.btnClearBasket = new System.Windows.Forms.Button();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.lblDiscountTotal = new System.Windows.Forms.Label();
            this.lblDiscountDesc = new System.Windows.Forms.Label();
            this.lblTotalTotal = new System.Windows.Forms.Label();
            this.lblPostageTotal = new System.Windows.Forms.Label();
            this.lblVATTotal = new System.Windows.Forms.Label();
            this.lblSubtotalValue = new System.Windows.Forms.Label();
            this.lblTotalDesc = new System.Windows.Forms.Label();
            this.lblPostageDesc = new System.Windows.Forms.Label();
            this.lblVATDesc = new System.Windows.Forms.Label();
            this.lblSubtotalDesc = new System.Windows.Forms.Label();
            this.menuPopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuPopupSetUserDiscounts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPopupRemoveUserDiscounts = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuPopupMimicSage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuPopupRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.grpProducts = new SharedControls.CollapsablePanel();
            this.flowLayoutButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.lstProducts = new System.Windows.Forms.ListBox();
            this.cmbProductType = new System.Windows.Forms.ComboBox();
            this.lblProductType = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnApplyDiscount = new System.Windows.Forms.Button();
            this.btnPostage = new System.Windows.Forms.Button();
            this.btnVATRate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblUserDiscount = new System.Windows.Forms.Label();
            this.lblUserDiscountDesc = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.pnlCurrentSale = new SharedControls.CollapsablePanel();
            this.pnlBasket = new System.Windows.Forms.FlowLayoutPanel();
            this.shoppingBasketHeader1 = new POS.Base.Controls.ShoppingBasketHeader();
            this.btnOpen = new System.Windows.Forms.Button();
            this.menuPopup.SuspendLayout();
            this.grpProducts.SuspendLayout();
            this.flowLayoutButtons.SuspendLayout();
            this.pnlCurrentSale.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClearBasket
            // 
            this.btnClearBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearBasket.Location = new System.Drawing.Point(452, 402);
            this.btnClearBasket.Name = "btnClearBasket";
            this.btnClearBasket.Size = new System.Drawing.Size(114, 23);
            this.btnClearBasket.TabIndex = 5;
            this.btnClearBasket.Text = "Clear Basket";
            this.btnClearBasket.UseVisualStyleBackColor = true;
            this.btnClearBasket.Click += new System.EventHandler(this.btnClearBasket_Click);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateOrder.BackColor = System.Drawing.Color.LimeGreen;
            this.btnCreateOrder.Location = new System.Drawing.Point(572, 399);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(114, 54);
            this.btnCreateOrder.TabIndex = 9;
            this.btnCreateOrder.Text = "Create Order";
            this.btnCreateOrder.UseVisualStyleBackColor = false;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // lblDiscountTotal
            // 
            this.lblDiscountTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscountTotal.AutoSize = true;
            this.lblDiscountTotal.Location = new System.Drawing.Point(932, 380);
            this.lblDiscountTotal.Name = "lblDiscountTotal";
            this.lblDiscountTotal.Size = new System.Drawing.Size(28, 13);
            this.lblDiscountTotal.TabIndex = 15;
            this.lblDiscountTotal.Text = "0.00";
            // 
            // lblDiscountDesc
            // 
            this.lblDiscountDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscountDesc.AutoSize = true;
            this.lblDiscountDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountDesc.Location = new System.Drawing.Point(733, 380);
            this.lblDiscountDesc.Name = "lblDiscountDesc";
            this.lblDiscountDesc.Size = new System.Drawing.Size(57, 13);
            this.lblDiscountDesc.TabIndex = 14;
            this.lblDiscountDesc.Text = "Discount";
            // 
            // lblTotalTotal
            // 
            this.lblTotalTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalTotal.AutoSize = true;
            this.lblTotalTotal.Location = new System.Drawing.Point(932, 439);
            this.lblTotalTotal.Name = "lblTotalTotal";
            this.lblTotalTotal.Size = new System.Drawing.Size(28, 13);
            this.lblTotalTotal.TabIndex = 21;
            this.lblTotalTotal.Text = "0.00";
            // 
            // lblPostageTotal
            // 
            this.lblPostageTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPostageTotal.AutoSize = true;
            this.lblPostageTotal.Location = new System.Drawing.Point(932, 419);
            this.lblPostageTotal.Name = "lblPostageTotal";
            this.lblPostageTotal.Size = new System.Drawing.Size(28, 13);
            this.lblPostageTotal.TabIndex = 19;
            this.lblPostageTotal.Text = "0.00";
            // 
            // lblVATTotal
            // 
            this.lblVATTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVATTotal.AutoSize = true;
            this.lblVATTotal.Location = new System.Drawing.Point(932, 360);
            this.lblVATTotal.Name = "lblVATTotal";
            this.lblVATTotal.Size = new System.Drawing.Size(28, 13);
            this.lblVATTotal.TabIndex = 13;
            this.lblVATTotal.Text = "0.00";
            // 
            // lblSubtotalValue
            // 
            this.lblSubtotalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotalValue.AutoSize = true;
            this.lblSubtotalValue.Location = new System.Drawing.Point(932, 340);
            this.lblSubtotalValue.Name = "lblSubtotalValue";
            this.lblSubtotalValue.Size = new System.Drawing.Size(28, 13);
            this.lblSubtotalValue.TabIndex = 11;
            this.lblSubtotalValue.Text = "0.00";
            // 
            // lblTotalDesc
            // 
            this.lblTotalDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDesc.AutoSize = true;
            this.lblTotalDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDesc.Location = new System.Drawing.Point(733, 439);
            this.lblTotalDesc.Name = "lblTotalDesc";
            this.lblTotalDesc.Size = new System.Drawing.Size(36, 13);
            this.lblTotalDesc.TabIndex = 20;
            this.lblTotalDesc.Text = "Total";
            // 
            // lblPostageDesc
            // 
            this.lblPostageDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPostageDesc.AutoSize = true;
            this.lblPostageDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostageDesc.Location = new System.Drawing.Point(733, 419);
            this.lblPostageDesc.Name = "lblPostageDesc";
            this.lblPostageDesc.Size = new System.Drawing.Size(128, 13);
            this.lblPostageDesc.TabIndex = 18;
            this.lblPostageDesc.Text = "Postage && Packaging";
            // 
            // lblVATDesc
            // 
            this.lblVATDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVATDesc.AutoSize = true;
            this.lblVATDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVATDesc.Location = new System.Drawing.Point(733, 360);
            this.lblVATDesc.Name = "lblVATDesc";
            this.lblVATDesc.Size = new System.Drawing.Size(74, 13);
            this.lblVATDesc.TabIndex = 12;
            this.lblVATDesc.Text = "VAT @ 20%";
            // 
            // lblSubtotalDesc
            // 
            this.lblSubtotalDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotalDesc.AutoSize = true;
            this.lblSubtotalDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalDesc.Location = new System.Drawing.Point(733, 340);
            this.lblSubtotalDesc.Name = "lblSubtotalDesc";
            this.lblSubtotalDesc.Size = new System.Drawing.Size(54, 13);
            this.lblSubtotalDesc.TabIndex = 10;
            this.lblSubtotalDesc.Text = "Subtotal";
            // 
            // menuPopup
            // 
            this.menuPopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPopupSetUserDiscounts,
            this.menuPopupRemoveUserDiscounts,
            this.toolStripMenuItem2,
            this.menuPopupMimicSage,
            this.toolStripMenuItem1,
            this.menuPopupRefresh});
            this.menuPopup.Name = "menuPopup";
            this.menuPopup.Size = new System.Drawing.Size(216, 104);
            this.menuPopup.Opening += new System.ComponentModel.CancelEventHandler(this.menuPopup_Opening);
            // 
            // menuPopupSetUserDiscounts
            // 
            this.menuPopupSetUserDiscounts.Name = "menuPopupSetUserDiscounts";
            this.menuPopupSetUserDiscounts.Size = new System.Drawing.Size(215, 22);
            this.menuPopupSetUserDiscounts.Text = "Set All User Discounts";
            this.menuPopupSetUserDiscounts.Click += new System.EventHandler(this.menuPopupSetUserDiscounts_Click);
            // 
            // menuPopupRemoveUserDiscounts
            // 
            this.menuPopupRemoveUserDiscounts.Name = "menuPopupRemoveUserDiscounts";
            this.menuPopupRemoveUserDiscounts.Size = new System.Drawing.Size(215, 22);
            this.menuPopupRemoveUserDiscounts.Text = "Remove All User Discounts";
            this.menuPopupRemoveUserDiscounts.Click += new System.EventHandler(this.menuPopupRemoveUserDiscounts_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(212, 6);
            // 
            // menuPopupMimicSage
            // 
            this.menuPopupMimicSage.Name = "menuPopupMimicSage";
            this.menuPopupMimicSage.Size = new System.Drawing.Size(215, 22);
            this.menuPopupMimicSage.Text = "Mimic Sage";
            this.menuPopupMimicSage.Click += new System.EventHandler(this.menuPopupMimicSage_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(212, 6);
            // 
            // menuPopupRefresh
            // 
            this.menuPopupRefresh.Name = "menuPopupRefresh";
            this.menuPopupRefresh.Size = new System.Drawing.Size(215, 22);
            this.menuPopupRefresh.Text = "Refresh";
            this.menuPopupRefresh.Click += new System.EventHandler(this.menuPopupRefresh_Click);
            // 
            // grpProducts
            // 
            this.grpProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpProducts.CollapsedColorFrom = System.Drawing.Color.DarkBlue;
            this.grpProducts.CollapsedColorTo = System.Drawing.Color.LightBlue;
            this.grpProducts.CollapseImage = ((System.Drawing.Image)(resources.GetObject("grpProducts.CollapseImage")));
            this.grpProducts.Controls.Add(this.flowLayoutButtons);
            this.grpProducts.Controls.Add(this.cmbProductType);
            this.grpProducts.Controls.Add(this.lblProductType);
            this.grpProducts.Controls.Add(this.txtFilter);
            this.grpProducts.Controls.Add(this.lblFilter);
            this.grpProducts.ExpandColorFrom = System.Drawing.Color.LightBlue;
            this.grpProducts.ExpandColorTo = System.Drawing.Color.DarkBlue;
            this.grpProducts.ExpandImage = ((System.Drawing.Image)(resources.GetObject("grpProducts.ExpandImage")));
            this.grpProducts.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpProducts.HeaderForeColor = System.Drawing.Color.Black;
            this.grpProducts.HeaderText = "Collapsable Panel";
            this.grpProducts.HeaderTextAlign = System.Drawing.StringAlignment.Near;
            this.grpProducts.HintControl = null;
            this.grpProducts.Location = new System.Drawing.Point(3, 3);
            this.grpProducts.Name = "grpProducts";
            this.grpProducts.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.grpProducts.Size = new System.Drawing.Size(443, 454);
            this.grpProducts.TabIndex = 0;
            this.grpProducts.TabStop = false;
            this.grpProducts.BeforeCollapse += new System.ComponentModel.CancelEventHandler(this.pnlCurrentSale_BeforeCollapse);
            this.grpProducts.SizeChanged += new System.EventHandler(this.grpProducts_SizeChanged);
            // 
            // flowLayoutButtons
            // 
            this.flowLayoutButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutButtons.AutoScroll = true;
            this.flowLayoutButtons.Controls.Add(this.lstProducts);
            this.flowLayoutButtons.Location = new System.Drawing.Point(31, 84);
            this.flowLayoutButtons.Name = "flowLayoutButtons";
            this.flowLayoutButtons.Size = new System.Drawing.Size(437, 365);
            this.flowLayoutButtons.TabIndex = 4;
            // 
            // lstProducts
            // 
            this.lstProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstProducts.FormattingEnabled = true;
            this.lstProducts.Location = new System.Drawing.Point(3, 3);
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.Size = new System.Drawing.Size(426, 4);
            this.lstProducts.TabIndex = 0;
            this.lstProducts.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstProducts_Format);
            this.lstProducts.DoubleClick += new System.EventHandler(this.lstProducts_DoubleClick);
            // 
            // cmbProductType
            // 
            this.cmbProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductType.FormattingEnabled = true;
            this.cmbProductType.Location = new System.Drawing.Point(228, 57);
            this.cmbProductType.Name = "cmbProductType";
            this.cmbProductType.Size = new System.Drawing.Size(212, 21);
            this.cmbProductType.TabIndex = 3;
            this.cmbProductType.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbProductType_Format);
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.Location = new System.Drawing.Point(225, 41);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(71, 13);
            this.lblProductType.TabIndex = 2;
            this.lblProductType.Text = "Product Type";
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(31, 57);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(191, 20);
            this.txtFilter.TabIndex = 1;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(31, 41);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(29, 13);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter";
            // 
            // btnApplyDiscount
            // 
            this.btnApplyDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApplyDiscount.Location = new System.Drawing.Point(572, 373);
            this.btnApplyDiscount.Name = "btnApplyDiscount";
            this.btnApplyDiscount.Size = new System.Drawing.Size(114, 23);
            this.btnApplyDiscount.TabIndex = 8;
            this.btnApplyDiscount.Text = "Apply Discount";
            this.btnApplyDiscount.UseVisualStyleBackColor = true;
            this.btnApplyDiscount.Click += new System.EventHandler(this.btnApplyDiscount_Click);
            // 
            // btnPostage
            // 
            this.btnPostage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPostage.Location = new System.Drawing.Point(572, 314);
            this.btnPostage.Name = "btnPostage";
            this.btnPostage.Size = new System.Drawing.Size(114, 23);
            this.btnPostage.TabIndex = 6;
            this.btnPostage.Text = "Postage";
            this.btnPostage.UseVisualStyleBackColor = true;
            this.btnPostage.Click += new System.EventHandler(this.btnPostage_Click);
            // 
            // btnVATRate
            // 
            this.btnVATRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVATRate.Location = new System.Drawing.Point(572, 343);
            this.btnVATRate.Name = "btnVATRate";
            this.btnVATRate.Size = new System.Drawing.Size(114, 23);
            this.btnVATRate.TabIndex = 7;
            this.btnVATRate.Text = "VAT Rate";
            this.btnVATRate.UseVisualStyleBackColor = true;
            this.btnVATRate.Click += new System.EventHandler(this.btnVATRate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(452, 373);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblUserDiscount
            // 
            this.lblUserDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserDiscount.AutoSize = true;
            this.lblUserDiscount.Location = new System.Drawing.Point(932, 400);
            this.lblUserDiscount.Name = "lblUserDiscount";
            this.lblUserDiscount.Size = new System.Drawing.Size(28, 13);
            this.lblUserDiscount.TabIndex = 17;
            this.lblUserDiscount.Text = "0.00";
            // 
            // lblUserDiscountDesc
            // 
            this.lblUserDiscountDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserDiscountDesc.AutoSize = true;
            this.lblUserDiscountDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserDiscountDesc.Location = new System.Drawing.Point(733, 400);
            this.lblUserDiscountDesc.Name = "lblUserDiscountDesc";
            this.lblUserDiscountDesc.Size = new System.Drawing.Size(87, 13);
            this.lblUserDiscountDesc.TabIndex = 16;
            this.lblUserDiscountDesc.Text = "User Discount";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(452, 314);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(114, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // pnlCurrentSale
            // 
            this.pnlCurrentSale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCurrentSale.CollapsedColorFrom = System.Drawing.Color.DarkBlue;
            this.pnlCurrentSale.CollapsedColorTo = System.Drawing.Color.LightBlue;
            this.pnlCurrentSale.CollapseImage = ((System.Drawing.Image)(resources.GetObject("pnlCurrentSale.CollapseImage")));
            this.pnlCurrentSale.Controls.Add(this.pnlBasket);
            this.pnlCurrentSale.Controls.Add(this.shoppingBasketHeader1);
            this.pnlCurrentSale.ExpandColorFrom = System.Drawing.Color.LightBlue;
            this.pnlCurrentSale.ExpandColorTo = System.Drawing.Color.DarkBlue;
            this.pnlCurrentSale.ExpandImage = ((System.Drawing.Image)(resources.GetObject("pnlCurrentSale.ExpandImage")));
            this.pnlCurrentSale.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pnlCurrentSale.HeaderForeColor = System.Drawing.Color.Black;
            this.pnlCurrentSale.HeaderText = "Current Sale";
            this.pnlCurrentSale.HeaderTextAlign = System.Drawing.StringAlignment.Near;
            this.pnlCurrentSale.HintControl = null;
            this.pnlCurrentSale.Location = new System.Drawing.Point(452, 3);
            this.pnlCurrentSale.Name = "pnlCurrentSale";
            this.pnlCurrentSale.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.pnlCurrentSale.Size = new System.Drawing.Size(548, 305);
            this.pnlCurrentSale.TabIndex = 1;
            this.pnlCurrentSale.BeforeCollapse += new System.ComponentModel.CancelEventHandler(this.pnlCurrentSale_BeforeCollapse);
            this.pnlCurrentSale.SizeChanged += new System.EventHandler(this.pnlCurrentSale_SizeChanged);
            // 
            // pnlBasket
            // 
            this.pnlBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBasket.AutoScroll = true;
            this.pnlBasket.ContextMenuStrip = this.menuPopup;
            this.pnlBasket.Location = new System.Drawing.Point(31, 57);
            this.pnlBasket.Name = "pnlBasket";
            this.pnlBasket.Size = new System.Drawing.Size(542, 245);
            this.pnlBasket.TabIndex = 1;
            // 
            // shoppingBasketHeader1
            // 
            this.shoppingBasketHeader1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shoppingBasketHeader1.HintControl = null;
            this.shoppingBasketHeader1.Location = new System.Drawing.Point(31, 31);
            this.shoppingBasketHeader1.Name = "shoppingBasketHeader1";
            this.shoppingBasketHeader1.Size = new System.Drawing.Size(548, 20);
            this.shoppingBasketHeader1.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.Location = new System.Drawing.Point(452, 343);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(114, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // CreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.pnlCurrentSale);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lblUserDiscount);
            this.Controls.Add(this.lblUserDiscountDesc);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnVATRate);
            this.Controls.Add(this.btnPostage);
            this.Controls.Add(this.btnApplyDiscount);
            this.Controls.Add(this.btnClearBasket);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.lblDiscountTotal);
            this.Controls.Add(this.lblDiscountDesc);
            this.Controls.Add(this.lblTotalTotal);
            this.Controls.Add(this.lblPostageTotal);
            this.Controls.Add(this.lblVATTotal);
            this.Controls.Add(this.lblSubtotalValue);
            this.Controls.Add(this.lblTotalDesc);
            this.Controls.Add(this.lblPostageDesc);
            this.Controls.Add(this.lblVATDesc);
            this.Controls.Add(this.lblSubtotalDesc);
            this.Controls.Add(this.grpProducts);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MinimumSize = new System.Drawing.Size(899, 460);
            this.Name = "CreateOrder";
            this.Size = new System.Drawing.Size(1003, 460);
            this.Resize += new System.EventHandler(this.CreateInvoice_Resize);
            this.menuPopup.ResumeLayout(false);
            this.grpProducts.ResumeLayout(false);
            this.grpProducts.PerformLayout();
            this.flowLayoutButtons.ResumeLayout(false);
            this.pnlCurrentSale.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharedControls.CollapsablePanel grpProducts;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ListBox lstProducts;
        private System.Windows.Forms.Button btnClearBasket;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Label lblDiscountTotal;
        private System.Windows.Forms.Label lblDiscountDesc;
        private System.Windows.Forms.Label lblTotalTotal;
        private System.Windows.Forms.Label lblPostageTotal;
        private System.Windows.Forms.Label lblVATTotal;
        private System.Windows.Forms.Label lblSubtotalValue;
        private System.Windows.Forms.Label lblTotalDesc;
        private System.Windows.Forms.Label lblPostageDesc;
        private System.Windows.Forms.Label lblVATDesc;
        private System.Windows.Forms.Label lblSubtotalDesc;
        private System.Windows.Forms.ComboBox cmbProductType;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.Button btnApplyDiscount;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutButtons;
        private System.Windows.Forms.Button btnPostage;
        private System.Windows.Forms.Button btnVATRate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ContextMenuStrip menuPopup;
        private System.Windows.Forms.ToolStripMenuItem menuPopupSetUserDiscounts;
        private System.Windows.Forms.ToolStripMenuItem menuPopupRemoveUserDiscounts;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuPopupMimicSage;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuPopupRefresh;
        private System.Windows.Forms.Label lblUserDiscount;
        private System.Windows.Forms.Label lblUserDiscountDesc;
        private System.Windows.Forms.Button btnNew;
        private SharedControls.CollapsablePanel pnlCurrentSale;
        private System.Windows.Forms.FlowLayoutPanel pnlBasket;
        private Base.Controls.ShoppingBasketHeader shoppingBasketHeader1;
        private System.Windows.Forms.Button btnOpen;
    }
}