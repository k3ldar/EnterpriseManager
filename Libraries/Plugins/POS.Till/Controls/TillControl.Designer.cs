namespace POS.Till.Controls
{
    partial class TillControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TillControl));
            this.btnrefresh = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnArrived = new System.Windows.Forms.Button();
            this.lvAppointments = new SharedControls.Classes.ListViewEx();
            this.colApptClient = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colApptTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colApptStaff = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitBasket = new System.Windows.Forms.SplitContainer();
            this.tabSaleItems = new System.Windows.Forms.TabControl();
            this.tabPageProducts = new System.Windows.Forms.TabPage();
            this.flowLayoutProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmbProductType = new System.Windows.Forms.ComboBox();
            this.lblProductType = new System.Windows.Forms.Label();
            this.lstProducts = new System.Windows.Forms.ListBox();
            this.tabPageTreatments = new System.Windows.Forms.TabPage();
            this.flowLayoutTreatments = new System.Windows.Forms.FlowLayoutPanel();
            this.lstTreatments = new System.Windows.Forms.ListBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnAddtoBasket = new System.Windows.Forms.Button();
            this.shoppingBasketHeader1 = new POS.Till.Controls.ShoppingBasketHeader();
            this.btnApplyDiscount = new System.Windows.Forms.Button();
            this.pnlBasket = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClearBasket = new System.Windows.Forms.Button();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.btnMarkAsPaid = new System.Windows.Forms.Button();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblVAT = new System.Windows.Forms.Label();
            this.lblDiscountTotal = new System.Windows.Forms.Label();
            this.lblPostage = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalTotal = new System.Windows.Forms.Label();
            this.lblSubtotalValue = new System.Windows.Forms.Label();
            this.lblPostageTotal = new System.Windows.Forms.Label();
            this.lblVATTotal = new System.Windows.Forms.Label();
            this.pnlTodaysAppointments = new SharedControls.CollapsablePanel();
            this.pnlCurrentSale = new SharedControls.CollapsablePanel();
            this.statusStripSummary = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusAppointments = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusSubTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusTax = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusDiscount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusPostage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusTotal = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitBasket)).BeginInit();
            this.splitBasket.Panel1.SuspendLayout();
            this.splitBasket.Panel2.SuspendLayout();
            this.splitBasket.SuspendLayout();
            this.tabSaleItems.SuspendLayout();
            this.tabPageProducts.SuspendLayout();
            this.tabPageTreatments.SuspendLayout();
            this.pnlTodaysAppointments.SuspendLayout();
            this.pnlCurrentSale.SuspendLayout();
            this.statusStripSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnrefresh
            // 
            this.btnrefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnrefresh.Location = new System.Drawing.Point(211, 585);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(75, 23);
            this.btnrefresh.TabIndex = 3;
            this.btnrefresh.Text = "Refresh";
            this.btnrefresh.UseVisualStyleBackColor = true;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnComplete.Location = new System.Drawing.Point(130, 585);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(75, 23);
            this.btnComplete.TabIndex = 2;
            this.btnComplete.Text = "Complete";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // btnArrived
            // 
            this.btnArrived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnArrived.Location = new System.Drawing.Point(49, 585);
            this.btnArrived.Name = "btnArrived";
            this.btnArrived.Size = new System.Drawing.Size(75, 23);
            this.btnArrived.TabIndex = 1;
            this.btnArrived.Text = "Arrived";
            this.btnArrived.UseVisualStyleBackColor = true;
            this.btnArrived.Click += new System.EventHandler(this.btnArrived_Click);
            // 
            // lvAppointments
            // 
            this.lvAppointments.AllowColumnReorder = true;
            this.lvAppointments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvAppointments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colApptClient,
            this.colApptTime,
            this.colApptStaff});
            this.lvAppointments.FullRowSelect = true;
            this.lvAppointments.Location = new System.Drawing.Point(39, 5);
            this.lvAppointments.MultiSelect = false;
            this.lvAppointments.Name = "lvAppointments";
            this.lvAppointments.OwnerDraw = true;
            this.lvAppointments.SaveName = "";
            this.lvAppointments.ShowToolTip = false;
            this.lvAppointments.Size = new System.Drawing.Size(250, 569);
            this.lvAppointments.TabIndex = 0;
            this.lvAppointments.UseCompatibleStateImageBehavior = false;
            this.lvAppointments.View = System.Windows.Forms.View.Details;
            this.lvAppointments.SelectedIndexChanged += new System.EventHandler(this.lvAppointments_SelectedIndexChanged);
            // 
            // colApptClient
            // 
            this.colApptClient.Width = 95;
            // 
            // colApptTime
            // 
            this.colApptTime.Width = 55;
            // 
            // colApptStaff
            // 
            this.colApptStaff.Width = 96;
            // 
            // splitBasket
            // 
            this.splitBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitBasket.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitBasket.Location = new System.Drawing.Point(31, 33);
            this.splitBasket.Name = "splitBasket";
            this.splitBasket.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitBasket.Panel1
            // 
            this.splitBasket.Panel1.Controls.Add(this.tabSaleItems);
            // 
            // splitBasket.Panel2
            // 
            this.splitBasket.Panel2.Controls.Add(this.shoppingBasketHeader1);
            this.splitBasket.Panel2.Controls.Add(this.btnApplyDiscount);
            this.splitBasket.Panel2.Controls.Add(this.pnlBasket);
            this.splitBasket.Panel2.Controls.Add(this.btnClearBasket);
            this.splitBasket.Panel2.Controls.Add(this.lblDiscount);
            this.splitBasket.Panel2.Controls.Add(this.btnMarkAsPaid);
            this.splitBasket.Panel2.Controls.Add(this.lblSubtotal);
            this.splitBasket.Panel2.Controls.Add(this.lblVAT);
            this.splitBasket.Panel2.Controls.Add(this.lblDiscountTotal);
            this.splitBasket.Panel2.Controls.Add(this.lblPostage);
            this.splitBasket.Panel2.Controls.Add(this.lblTotal);
            this.splitBasket.Panel2.Controls.Add(this.lblTotalTotal);
            this.splitBasket.Panel2.Controls.Add(this.lblSubtotalValue);
            this.splitBasket.Panel2.Controls.Add(this.lblPostageTotal);
            this.splitBasket.Panel2.Controls.Add(this.lblVATTotal);
            this.splitBasket.Size = new System.Drawing.Size(542, 575);
            this.splitBasket.SplitterDistance = 273;
            this.splitBasket.TabIndex = 20;
            // 
            // tabSaleItems
            // 
            this.tabSaleItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSaleItems.Controls.Add(this.tabPageProducts);
            this.tabSaleItems.Controls.Add(this.tabPageTreatments);
            this.tabSaleItems.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabSaleItems.Location = new System.Drawing.Point(3, 3);
            this.tabSaleItems.Name = "tabSaleItems";
            this.tabSaleItems.SelectedIndex = 0;
            this.tabSaleItems.Size = new System.Drawing.Size(532, 263);
            this.tabSaleItems.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabSaleItems.TabIndex = 0;
            this.tabSaleItems.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabPageProducts
            // 
            this.tabPageProducts.Controls.Add(this.flowLayoutProducts);
            this.tabPageProducts.Controls.Add(this.txtFilter);
            this.tabPageProducts.Controls.Add(this.lblFilter);
            this.tabPageProducts.Controls.Add(this.cmbProductType);
            this.tabPageProducts.Controls.Add(this.lblProductType);
            this.tabPageProducts.Controls.Add(this.lstProducts);
            this.tabPageProducts.Location = new System.Drawing.Point(4, 22);
            this.tabPageProducts.Name = "tabPageProducts";
            this.tabPageProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProducts.Size = new System.Drawing.Size(524, 237);
            this.tabPageProducts.TabIndex = 0;
            this.tabPageProducts.Text = "Products";
            this.tabPageProducts.UseVisualStyleBackColor = true;
            // 
            // flowLayoutProducts
            // 
            this.flowLayoutProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutProducts.AutoScroll = true;
            this.flowLayoutProducts.Location = new System.Drawing.Point(3, 35);
            this.flowLayoutProducts.Name = "flowLayoutProducts";
            this.flowLayoutProducts.Size = new System.Drawing.Size(518, 199);
            this.flowLayoutProducts.TabIndex = 5;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(41, 8);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(221, 20);
            this.txtFilter.TabIndex = 1;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(6, 12);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(29, 13);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter";
            // 
            // cmbProductType
            // 
            this.cmbProductType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductType.FormattingEnabled = true;
            this.cmbProductType.Location = new System.Drawing.Point(352, 8);
            this.cmbProductType.Name = "cmbProductType";
            this.cmbProductType.Size = new System.Drawing.Size(167, 21);
            this.cmbProductType.TabIndex = 3;
            this.cmbProductType.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbProductType_Format);
            // 
            // lblProductType
            // 
            this.lblProductType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductType.AutoSize = true;
            this.lblProductType.Location = new System.Drawing.Point(274, 12);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(71, 13);
            this.lblProductType.TabIndex = 2;
            this.lblProductType.Text = "Product Type";
            // 
            // lstProducts
            // 
            this.lstProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProducts.FormattingEnabled = true;
            this.lstProducts.ItemHeight = 16;
            this.lstProducts.Location = new System.Drawing.Point(3, 35);
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstProducts.Size = new System.Drawing.Size(518, 180);
            this.lstProducts.TabIndex = 4;
            this.lstProducts.Visible = false;
            this.lstProducts.SelectedIndexChanged += new System.EventHandler(this.lstTreatments_SelectedIndexChanged);
            this.lstProducts.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstProducts_Format);
            this.lstProducts.DoubleClick += new System.EventHandler(this.btnAddtoBasket_Click);
            // 
            // tabPageTreatments
            // 
            this.tabPageTreatments.Controls.Add(this.flowLayoutTreatments);
            this.tabPageTreatments.Controls.Add(this.lstTreatments);
            this.tabPageTreatments.Controls.Add(this.btnClearAll);
            this.tabPageTreatments.Controls.Add(this.btnAddtoBasket);
            this.tabPageTreatments.Location = new System.Drawing.Point(4, 22);
            this.tabPageTreatments.Name = "tabPageTreatments";
            this.tabPageTreatments.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTreatments.Size = new System.Drawing.Size(524, 237);
            this.tabPageTreatments.TabIndex = 1;
            this.tabPageTreatments.Text = "Treatments";
            this.tabPageTreatments.UseVisualStyleBackColor = true;
            // 
            // flowLayoutTreatments
            // 
            this.flowLayoutTreatments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutTreatments.AutoScroll = true;
            this.flowLayoutTreatments.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutTreatments.Name = "flowLayoutTreatments";
            this.flowLayoutTreatments.Size = new System.Drawing.Size(515, 228);
            this.flowLayoutTreatments.TabIndex = 5;
            // 
            // lstTreatments
            // 
            this.lstTreatments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTreatments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTreatments.FormattingEnabled = true;
            this.lstTreatments.ItemHeight = 16;
            this.lstTreatments.Location = new System.Drawing.Point(3, 3);
            this.lstTreatments.Name = "lstTreatments";
            this.lstTreatments.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTreatments.Size = new System.Drawing.Size(515, 164);
            this.lstTreatments.TabIndex = 4;
            this.lstTreatments.SelectedIndexChanged += new System.EventHandler(this.lstTreatments_SelectedIndexChanged);
            this.lstTreatments.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstTreatments_Format);
            this.lstTreatments.DoubleClick += new System.EventHandler(this.btnAddtoBasket_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearAll.Location = new System.Drawing.Point(3, 208);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 23);
            this.btnClearAll.TabIndex = 2;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnAddtoBasket
            // 
            this.btnAddtoBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddtoBasket.Location = new System.Drawing.Point(96, 208);
            this.btnAddtoBasket.Name = "btnAddtoBasket";
            this.btnAddtoBasket.Size = new System.Drawing.Size(82, 23);
            this.btnAddtoBasket.TabIndex = 1;
            this.btnAddtoBasket.Text = "Add to Basket";
            this.btnAddtoBasket.UseVisualStyleBackColor = true;
            this.btnAddtoBasket.Click += new System.EventHandler(this.btnAddtoBasket_Click);
            // 
            // shoppingBasketHeader1
            // 
            this.shoppingBasketHeader1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shoppingBasketHeader1.HintControl = null;
            this.shoppingBasketHeader1.Location = new System.Drawing.Point(-2, 3);
            this.shoppingBasketHeader1.Name = "shoppingBasketHeader1";
            this.shoppingBasketHeader1.Size = new System.Drawing.Size(537, 20);
            this.shoppingBasketHeader1.TabIndex = 20;
            // 
            // btnApplyDiscount
            // 
            this.btnApplyDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApplyDiscount.Location = new System.Drawing.Point(6, 266);
            this.btnApplyDiscount.Name = "btnApplyDiscount";
            this.btnApplyDiscount.Size = new System.Drawing.Size(114, 23);
            this.btnApplyDiscount.TabIndex = 19;
            this.btnApplyDiscount.Text = "Apply Discount";
            this.btnApplyDiscount.UseVisualStyleBackColor = true;
            this.btnApplyDiscount.Click += new System.EventHandler(this.btnApplyDiscount_Click);
            // 
            // pnlBasket
            // 
            this.pnlBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBasket.AutoScroll = true;
            this.pnlBasket.Location = new System.Drawing.Point(4, 25);
            this.pnlBasket.Name = "pnlBasket";
            this.pnlBasket.Size = new System.Drawing.Size(529, 165);
            this.pnlBasket.TabIndex = 4;
            // 
            // btnClearBasket
            // 
            this.btnClearBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearBasket.Location = new System.Drawing.Point(6, 237);
            this.btnClearBasket.Name = "btnClearBasket";
            this.btnClearBasket.Size = new System.Drawing.Size(114, 23);
            this.btnClearBasket.TabIndex = 6;
            this.btnClearBasket.Text = "Clear Basket";
            this.btnClearBasket.UseVisualStyleBackColor = true;
            this.btnClearBasket.Click += new System.EventHandler(this.btnClearBasket_Click);
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(267, 236);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(57, 13);
            this.lblDiscount.TabIndex = 17;
            this.lblDiscount.Text = "Discount";
            // 
            // btnMarkAsPaid
            // 
            this.btnMarkAsPaid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMarkAsPaid.BackColor = System.Drawing.Color.LimeGreen;
            this.btnMarkAsPaid.Location = new System.Drawing.Point(125, 236);
            this.btnMarkAsPaid.Name = "btnMarkAsPaid";
            this.btnMarkAsPaid.Size = new System.Drawing.Size(115, 53);
            this.btnMarkAsPaid.TabIndex = 5;
            this.btnMarkAsPaid.Text = "Paid";
            this.btnMarkAsPaid.UseVisualStyleBackColor = false;
            this.btnMarkAsPaid.Click += new System.EventHandler(this.btnMarkAsPaid_Click);
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(267, 193);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(54, 13);
            this.lblSubtotal.TabIndex = 9;
            this.lblSubtotal.Text = "Subtotal";
            // 
            // lblVAT
            // 
            this.lblVAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVAT.AutoSize = true;
            this.lblVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVAT.Location = new System.Drawing.Point(267, 216);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(74, 13);
            this.lblVAT.TabIndex = 10;
            this.lblVAT.Text = "VAT @ 20%";
            // 
            // lblDiscountTotal
            // 
            this.lblDiscountTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscountTotal.Location = new System.Drawing.Point(451, 236);
            this.lblDiscountTotal.Name = "lblDiscountTotal";
            this.lblDiscountTotal.Size = new System.Drawing.Size(80, 13);
            this.lblDiscountTotal.TabIndex = 18;
            this.lblDiscountTotal.Text = "0.00";
            this.lblDiscountTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPostage
            // 
            this.lblPostage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPostage.AutoSize = true;
            this.lblPostage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostage.Location = new System.Drawing.Point(267, 254);
            this.lblPostage.Name = "lblPostage";
            this.lblPostage.Size = new System.Drawing.Size(128, 13);
            this.lblPostage.TabIndex = 11;
            this.lblPostage.Text = "Postage && Packaging";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(267, 276);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(36, 13);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "Total";
            // 
            // lblTotalTotal
            // 
            this.lblTotalTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalTotal.Location = new System.Drawing.Point(451, 276);
            this.lblTotalTotal.Name = "lblTotalTotal";
            this.lblTotalTotal.Size = new System.Drawing.Size(80, 13);
            this.lblTotalTotal.TabIndex = 16;
            this.lblTotalTotal.Text = "0.00";
            this.lblTotalTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtotalValue
            // 
            this.lblSubtotalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotalValue.Location = new System.Drawing.Point(451, 193);
            this.lblSubtotalValue.Name = "lblSubtotalValue";
            this.lblSubtotalValue.Size = new System.Drawing.Size(80, 13);
            this.lblSubtotalValue.TabIndex = 13;
            this.lblSubtotalValue.Text = "0.00";
            this.lblSubtotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPostageTotal
            // 
            this.lblPostageTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPostageTotal.Location = new System.Drawing.Point(451, 254);
            this.lblPostageTotal.Name = "lblPostageTotal";
            this.lblPostageTotal.Size = new System.Drawing.Size(80, 13);
            this.lblPostageTotal.TabIndex = 15;
            this.lblPostageTotal.Text = "0.00";
            this.lblPostageTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVATTotal
            // 
            this.lblVATTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVATTotal.Location = new System.Drawing.Point(451, 216);
            this.lblVATTotal.Name = "lblVATTotal";
            this.lblVATTotal.Size = new System.Drawing.Size(80, 13);
            this.lblVATTotal.TabIndex = 14;
            this.lblVATTotal.Text = "0.00";
            this.lblVATTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlTodaysAppointments
            // 
            this.pnlTodaysAppointments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlTodaysAppointments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTodaysAppointments.CollapsedColorFrom = System.Drawing.Color.DarkBlue;
            this.pnlTodaysAppointments.CollapsedColorTo = System.Drawing.Color.LightBlue;
            this.pnlTodaysAppointments.CollapseImage = ((System.Drawing.Image)(resources.GetObject("pnlTodaysAppointments.CollapseImage")));
            this.pnlTodaysAppointments.Controls.Add(this.lvAppointments);
            this.pnlTodaysAppointments.Controls.Add(this.btnArrived);
            this.pnlTodaysAppointments.Controls.Add(this.btnComplete);
            this.pnlTodaysAppointments.Controls.Add(this.btnrefresh);
            this.pnlTodaysAppointments.ExpandColorFrom = System.Drawing.Color.LightBlue;
            this.pnlTodaysAppointments.ExpandColorTo = System.Drawing.Color.DarkBlue;
            this.pnlTodaysAppointments.ExpandImage = ((System.Drawing.Image)(resources.GetObject("pnlTodaysAppointments.ExpandImage")));
            this.pnlTodaysAppointments.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pnlTodaysAppointments.HeaderForeColor = System.Drawing.Color.Black;
            this.pnlTodaysAppointments.HeaderText = "Collapsable Panel";
            this.pnlTodaysAppointments.HeaderTextAlign = System.Drawing.StringAlignment.Center;
            this.pnlTodaysAppointments.HintControl = null;
            this.pnlTodaysAppointments.Location = new System.Drawing.Point(0, 0);
            this.pnlTodaysAppointments.Name = "pnlTodaysAppointments";
            this.pnlTodaysAppointments.Size = new System.Drawing.Size(294, 615);
            this.pnlTodaysAppointments.TabIndex = 2;
            this.pnlTodaysAppointments.AfterCollapse += new System.EventHandler(this.pnlTodaysAppointments_AfterCollapse);
            this.pnlTodaysAppointments.AfterExpand += new System.EventHandler(this.pnlTodaysAppointments_AfterExpand);
            // 
            // pnlCurrentSale
            // 
            this.pnlCurrentSale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCurrentSale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCurrentSale.CollapsedColorFrom = System.Drawing.Color.DarkBlue;
            this.pnlCurrentSale.CollapsedColorTo = System.Drawing.Color.LightBlue;
            this.pnlCurrentSale.CollapseImage = null;
            this.pnlCurrentSale.Controls.Add(this.splitBasket);
            this.pnlCurrentSale.CustomImages = true;
            this.pnlCurrentSale.ExpandColorFrom = System.Drawing.Color.LightBlue;
            this.pnlCurrentSale.ExpandColorTo = System.Drawing.Color.DarkBlue;
            this.pnlCurrentSale.ExpandImage = null;
            this.pnlCurrentSale.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pnlCurrentSale.HeaderForeColor = System.Drawing.Color.Black;
            this.pnlCurrentSale.HeaderText = "Collapsable Panel";
            this.pnlCurrentSale.HeaderTextAlign = System.Drawing.StringAlignment.Center;
            this.pnlCurrentSale.HintControl = null;
            this.pnlCurrentSale.Location = new System.Drawing.Point(300, 0);
            this.pnlCurrentSale.Name = "pnlCurrentSale";
            this.pnlCurrentSale.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.pnlCurrentSale.Size = new System.Drawing.Size(555, 615);
            this.pnlCurrentSale.TabIndex = 3;
            this.pnlCurrentSale.BeforeCollapse += new System.ComponentModel.CancelEventHandler(this.pnlCurrentSale_BeforeCollapse);
            this.pnlCurrentSale.Resize += new System.EventHandler(this.pnlCurrentSale_Resize);
            // 
            // statusStripSummary
            // 
            this.statusStripSummary.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusAppointments,
            this.toolStripStatusSubTotal,
            this.toolStripStatusTax,
            this.toolStripStatusDiscount,
            this.toolStripStatusPostage,
            this.toolStripStatusTotal});
            this.statusStripSummary.Location = new System.Drawing.Point(0, 622);
            this.statusStripSummary.Name = "statusStripSummary";
            this.statusStripSummary.Size = new System.Drawing.Size(858, 24);
            this.statusStripSummary.TabIndex = 4;
            // 
            // toolStripStatusAppointments
            // 
            this.toolStripStatusAppointments.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusAppointments.Name = "toolStripStatusAppointments";
            this.toolStripStatusAppointments.Size = new System.Drawing.Size(164, 19);
            this.toolStripStatusAppointments.Text = "toolStripStatusAppointments";
            // 
            // toolStripStatusSubTotal
            // 
            this.toolStripStatusSubTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusSubTotal.Name = "toolStripStatusSubTotal";
            this.toolStripStatusSubTotal.Size = new System.Drawing.Size(122, 19);
            this.toolStripStatusSubTotal.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusTax
            // 
            this.toolStripStatusTax.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusTax.Name = "toolStripStatusTax";
            this.toolStripStatusTax.Size = new System.Drawing.Size(105, 19);
            this.toolStripStatusTax.Text = "toolStripStatusTax";
            // 
            // toolStripStatusDiscount
            // 
            this.toolStripStatusDiscount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusDiscount.Name = "toolStripStatusDiscount";
            this.toolStripStatusDiscount.Size = new System.Drawing.Size(135, 19);
            this.toolStripStatusDiscount.Text = "toolStripStatusDiscount";
            // 
            // toolStripStatusPostage
            // 
            this.toolStripStatusPostage.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusPostage.Name = "toolStripStatusPostage";
            this.toolStripStatusPostage.Size = new System.Drawing.Size(122, 19);
            this.toolStripStatusPostage.Text = "toolStripStatusLabel3";
            // 
            // toolStripStatusTotal
            // 
            this.toolStripStatusTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusTotal.Name = "toolStripStatusTotal";
            this.toolStripStatusTotal.Size = new System.Drawing.Size(122, 19);
            this.toolStripStatusTotal.Text = "toolStripStatusLabel3";
            // 
            // TillControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStripSummary);
            this.Controls.Add(this.pnlCurrentSale);
            this.Controls.Add(this.pnlTodaysAppointments);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MinimumSize = new System.Drawing.Size(822, 646);
            this.Name = "TillControl";
            this.Size = new System.Drawing.Size(858, 646);
            this.splitBasket.Panel1.ResumeLayout(false);
            this.splitBasket.Panel2.ResumeLayout(false);
            this.splitBasket.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitBasket)).EndInit();
            this.splitBasket.ResumeLayout(false);
            this.tabSaleItems.ResumeLayout(false);
            this.tabPageProducts.ResumeLayout(false);
            this.tabPageProducts.PerformLayout();
            this.tabPageTreatments.ResumeLayout(false);
            this.pnlTodaysAppointments.ResumeLayout(false);
            this.pnlCurrentSale.ResumeLayout(false);
            this.statusStripSummary.ResumeLayout(false);
            this.statusStripSummary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharedControls.Classes.ListViewEx lvAppointments;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnArrived;
        private System.Windows.Forms.Button btnAddtoBasket;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.FlowLayoutPanel pnlBasket;
        private System.Windows.Forms.Label lblTotalTotal;
        private System.Windows.Forms.Label lblPostageTotal;
        private System.Windows.Forms.Label lblVATTotal;
        private System.Windows.Forms.Label lblSubtotalValue;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPostage;
        private System.Windows.Forms.Label lblVAT;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblDiscountTotal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Button btnMarkAsPaid;
        private System.Windows.Forms.Button btnClearBasket;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.TabControl tabSaleItems;
        private System.Windows.Forms.TabPage tabPageProducts;
        private System.Windows.Forms.TabPage tabPageTreatments;
        private System.Windows.Forms.ListBox lstProducts;
        private System.Windows.Forms.ListBox lstTreatments;
        private System.Windows.Forms.ComboBox cmbProductType;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button btnApplyDiscount;
        private System.Windows.Forms.SplitContainer splitBasket;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutProducts;
        private Controls.ShoppingBasketHeader shoppingBasketHeader1;
        private SharedControls.CollapsablePanel pnlTodaysAppointments;
        private SharedControls.CollapsablePanel pnlCurrentSale;
        private System.Windows.Forms.StatusStrip statusStripSummary;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusAppointments;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSubTotal;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusTax;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusDiscount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusPostage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusTotal;
        private System.Windows.Forms.ColumnHeader colApptClient;
        private System.Windows.Forms.ColumnHeader colApptTime;
        private System.Windows.Forms.ColumnHeader colApptStaff;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutTreatments;
    }
}

