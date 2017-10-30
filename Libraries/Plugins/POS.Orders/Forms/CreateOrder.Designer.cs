namespace SieraDelta.POS.Orders.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateOrder));
            this.lblCurrentSale = new System.Windows.Forms.Label();
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
            this.pnlBasket = new System.Windows.Forms.FlowLayoutPanel();
            this.grpProducts = new System.Windows.Forms.GroupBox();
            this.flowLayoutButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbProductType = new System.Windows.Forms.ComboBox();
            this.lblProductType = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lstProducts = new System.Windows.Forms.ListBox();
            this.btnApplyDiscount = new System.Windows.Forms.Button();
            this.shoppingBasketHeader1 = new SieraDelta.POS.Controls.ShoppingBasketHeader();
            this.btnPostage = new System.Windows.Forms.Button();
            this.btnVATRate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpProducts.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrentSale
            // 
            this.lblCurrentSale.AutoSize = true;
            this.lblCurrentSale.Location = new System.Drawing.Point(461, 9);
            this.lblCurrentSale.Name = "lblCurrentSale";
            this.lblCurrentSale.Size = new System.Drawing.Size(65, 13);
            this.lblCurrentSale.TabIndex = 1;
            this.lblCurrentSale.Text = "Current Sale";
            // 
            // btnClearBasket
            // 
            this.btnClearBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearBasket.Location = new System.Drawing.Point(464, 341);
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
            this.btnCreateOrder.Location = new System.Drawing.Point(464, 312);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(114, 23);
            this.btnCreateOrder.TabIndex = 4;
            this.btnCreateOrder.Text = "Create Order";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // lblDiscountTotal
            // 
            this.lblDiscountTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscountTotal.AutoSize = true;
            this.lblDiscountTotal.Location = new System.Drawing.Point(908, 352);
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
            this.lblDiscountDesc.Location = new System.Drawing.Point(709, 352);
            this.lblDiscountDesc.Name = "lblDiscountDesc";
            this.lblDiscountDesc.Size = new System.Drawing.Size(57, 13);
            this.lblDiscountDesc.TabIndex = 14;
            this.lblDiscountDesc.Text = "Discount";
            // 
            // lblTotalTotal
            // 
            this.lblTotalTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalTotal.AutoSize = true;
            this.lblTotalTotal.Location = new System.Drawing.Point(908, 392);
            this.lblTotalTotal.Name = "lblTotalTotal";
            this.lblTotalTotal.Size = new System.Drawing.Size(28, 13);
            this.lblTotalTotal.TabIndex = 19;
            this.lblTotalTotal.Text = "0.00";
            // 
            // lblPostageTotal
            // 
            this.lblPostageTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPostageTotal.AutoSize = true;
            this.lblPostageTotal.Location = new System.Drawing.Point(908, 372);
            this.lblPostageTotal.Name = "lblPostageTotal";
            this.lblPostageTotal.Size = new System.Drawing.Size(28, 13);
            this.lblPostageTotal.TabIndex = 17;
            this.lblPostageTotal.Text = "0.00";
            // 
            // lblVATTotal
            // 
            this.lblVATTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVATTotal.AutoSize = true;
            this.lblVATTotal.Location = new System.Drawing.Point(908, 332);
            this.lblVATTotal.Name = "lblVATTotal";
            this.lblVATTotal.Size = new System.Drawing.Size(28, 13);
            this.lblVATTotal.TabIndex = 13;
            this.lblVATTotal.Text = "0.00";
            // 
            // lblSubtotalValue
            // 
            this.lblSubtotalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotalValue.AutoSize = true;
            this.lblSubtotalValue.Location = new System.Drawing.Point(908, 312);
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
            this.lblTotalDesc.Location = new System.Drawing.Point(709, 392);
            this.lblTotalDesc.Name = "lblTotalDesc";
            this.lblTotalDesc.Size = new System.Drawing.Size(36, 13);
            this.lblTotalDesc.TabIndex = 18;
            this.lblTotalDesc.Text = "Total";
            // 
            // lblPostageDesc
            // 
            this.lblPostageDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPostageDesc.AutoSize = true;
            this.lblPostageDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostageDesc.Location = new System.Drawing.Point(709, 372);
            this.lblPostageDesc.Name = "lblPostageDesc";
            this.lblPostageDesc.Size = new System.Drawing.Size(128, 13);
            this.lblPostageDesc.TabIndex = 16;
            this.lblPostageDesc.Text = "Postage && Packaging";
            // 
            // lblVATDesc
            // 
            this.lblVATDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVATDesc.AutoSize = true;
            this.lblVATDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVATDesc.Location = new System.Drawing.Point(709, 332);
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
            this.lblSubtotalDesc.Location = new System.Drawing.Point(709, 312);
            this.lblSubtotalDesc.Name = "lblSubtotalDesc";
            this.lblSubtotalDesc.Size = new System.Drawing.Size(54, 13);
            this.lblSubtotalDesc.TabIndex = 10;
            this.lblSubtotalDesc.Text = "Subtotal";
            // 
            // pnlBasket
            // 
            this.pnlBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBasket.AutoScroll = true;
            this.pnlBasket.Location = new System.Drawing.Point(464, 50);
            this.pnlBasket.Name = "pnlBasket";
            this.pnlBasket.Size = new System.Drawing.Size(530, 256);
            this.pnlBasket.TabIndex = 3;
            // 
            // grpProducts
            // 
            this.grpProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpProducts.Controls.Add(this.flowLayoutButtons);
            this.grpProducts.Controls.Add(this.cmbProductType);
            this.grpProducts.Controls.Add(this.lblProductType);
            this.grpProducts.Controls.Add(this.txtFilter);
            this.grpProducts.Controls.Add(this.lblFilter);
            this.grpProducts.Controls.Add(this.lstProducts);
            this.grpProducts.Location = new System.Drawing.Point(12, 12);
            this.grpProducts.Name = "grpProducts";
            this.grpProducts.Size = new System.Drawing.Size(443, 398);
            this.grpProducts.TabIndex = 0;
            this.grpProducts.TabStop = false;
            this.grpProducts.Text = "Products";
            // 
            // flowLayoutButtons
            // 
            this.flowLayoutButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutButtons.AutoScroll = true;
            this.flowLayoutButtons.Location = new System.Drawing.Point(6, 66);
            this.flowLayoutButtons.Name = "flowLayoutButtons";
            this.flowLayoutButtons.Size = new System.Drawing.Size(426, 316);
            this.flowLayoutButtons.TabIndex = 4;
            // 
            // cmbProductType
            // 
            this.cmbProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductType.FormattingEnabled = true;
            this.cmbProductType.Location = new System.Drawing.Point(219, 32);
            this.cmbProductType.Name = "cmbProductType";
            this.cmbProductType.Size = new System.Drawing.Size(212, 21);
            this.cmbProductType.TabIndex = 3;
            this.cmbProductType.SelectedIndexChanged += new System.EventHandler(this.cmbProductType_SelectedIndexChanged_1);
            this.cmbProductType.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbProductType_Format);
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.Location = new System.Drawing.Point(216, 16);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(71, 13);
            this.lblProductType.TabIndex = 1;
            this.lblProductType.Text = "Product Type";
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(9, 32);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(204, 20);
            this.txtFilter.TabIndex = 2;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(6, 16);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(29, 13);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter";
            // 
            // lstProducts
            // 
            this.lstProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstProducts.FormattingEnabled = true;
            this.lstProducts.Location = new System.Drawing.Point(6, 66);
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.Size = new System.Drawing.Size(426, 316);
            this.lstProducts.TabIndex = 2;
            this.lstProducts.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstProducts_Format);
            this.lstProducts.DoubleClick += new System.EventHandler(this.lstProducts_DoubleClick);
            // 
            // btnApplyDiscount
            // 
            this.btnApplyDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApplyDiscount.Location = new System.Drawing.Point(464, 370);
            this.btnApplyDiscount.Name = "btnApplyDiscount";
            this.btnApplyDiscount.Size = new System.Drawing.Size(114, 23);
            this.btnApplyDiscount.TabIndex = 6;
            this.btnApplyDiscount.Text = "Apply Discount";
            this.btnApplyDiscount.UseVisualStyleBackColor = true;
            this.btnApplyDiscount.Click += new System.EventHandler(this.btnApplyDiscount_Click);
            // 
            // shoppingBasketHeader1
            // 
            this.shoppingBasketHeader1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shoppingBasketHeader1.LocalizedControls = resources.GetString("shoppingBasketHeader1.LocalizedControls");
            this.shoppingBasketHeader1.Location = new System.Drawing.Point(464, 28);
            this.shoppingBasketHeader1.Name = "shoppingBasketHeader1";
            this.shoppingBasketHeader1.Size = new System.Drawing.Size(528, 20);
            this.shoppingBasketHeader1.TabIndex = 2;
            // 
            // btnPostage
            // 
            this.btnPostage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPostage.Location = new System.Drawing.Point(585, 311);
            this.btnPostage.Name = "btnPostage";
            this.btnPostage.Size = new System.Drawing.Size(114, 23);
            this.btnPostage.TabIndex = 7;
            this.btnPostage.Text = "Postage";
            this.btnPostage.UseVisualStyleBackColor = true;
            this.btnPostage.Click += new System.EventHandler(this.btnPostage_Click);
            // 
            // btnVATRate
            // 
            this.btnVATRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVATRate.Location = new System.Drawing.Point(585, 340);
            this.btnVATRate.Name = "btnVATRate";
            this.btnVATRate.Size = new System.Drawing.Size(114, 23);
            this.btnVATRate.TabIndex = 8;
            this.btnVATRate.Text = "VAT Rate";
            this.btnVATRate.UseVisualStyleBackColor = true;
            this.btnVATRate.Click += new System.EventHandler(this.btnVATRate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(585, 369);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 422);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnVATRate);
            this.Controls.Add(this.btnPostage);
            this.Controls.Add(this.shoppingBasketHeader1);
            this.Controls.Add(this.btnApplyDiscount);
            this.Controls.Add(this.lblCurrentSale);
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
            this.Controls.Add(this.pnlBasket);
            this.Controls.Add(this.grpProducts);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(899, 460);
            this.Name = "CreateOrder";
            this.SaveState = true;
            this.Text = "Create Order";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateOrder_FormClosing);
            this.Resize += new System.EventHandler(this.CreateInvoice_Resize);
            this.grpProducts.ResumeLayout(false);
            this.grpProducts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProducts;
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
        private System.Windows.Forms.FlowLayoutPanel pnlBasket;
        private System.Windows.Forms.Label lblCurrentSale;
        private System.Windows.Forms.ComboBox cmbProductType;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.Button btnApplyDiscount;
        private SieraDelta.POS.Controls.ShoppingBasketHeader shoppingBasketHeader1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutButtons;
        private System.Windows.Forms.Button btnPostage;
        private System.Windows.Forms.Button btnVATRate;
        private System.Windows.Forms.Button btnSave;
    }
}