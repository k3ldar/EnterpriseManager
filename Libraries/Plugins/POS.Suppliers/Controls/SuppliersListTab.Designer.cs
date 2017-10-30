namespace POS.Suppliers
{
    partial class SuppliersListTab
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
            this.lvSuppliers = new SharedControls.Classes.ListViewEx();
            this.colSupplierName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSupplierStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSupplierContact = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSupplierTelephone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSupplierWebsite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSupplierAddressLine1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSupplierPostcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuSuppliers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuSuppliersEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSuppliersWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.lvProducts = new SharedControls.Classes.ListViewEx();
            this.colProductsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductsMake = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductsModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductsCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductsSKU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductsType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductsNotes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.suppliersProductSplitter = new System.Windows.Forms.SplitContainer();
            this.contextMenuSuppliers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersProductSplitter)).BeginInit();
            this.suppliersProductSplitter.Panel1.SuspendLayout();
            this.suppliersProductSplitter.Panel2.SuspendLayout();
            this.suppliersProductSplitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvSuppliers
            // 
            this.lvSuppliers.AllowColumnReorder = true;
            this.lvSuppliers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSuppliers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSupplierName,
            this.colSupplierStatus,
            this.colSupplierContact,
            this.colSupplierTelephone,
            this.colSupplierWebsite,
            this.colSupplierAddressLine1,
            this.colSupplierPostcode});
            this.lvSuppliers.ContextMenuStrip = this.contextMenuSuppliers;
            this.lvSuppliers.FullRowSelect = true;
            this.lvSuppliers.HideSelection = false;
            this.lvSuppliers.Location = new System.Drawing.Point(3, 3);
            this.lvSuppliers.Name = "lvSuppliers";
            this.lvSuppliers.OwnerDraw = true;
            this.lvSuppliers.SaveName = "";
            this.lvSuppliers.ShowToolTip = false;
            this.lvSuppliers.Size = new System.Drawing.Size(674, 235);
            this.lvSuppliers.TabIndex = 16;
            this.lvSuppliers.UseCompatibleStateImageBehavior = false;
            this.lvSuppliers.View = System.Windows.Forms.View.Details;
            this.lvSuppliers.SelectedIndexChanged += new System.EventHandler(this.lvSuppliers_SelectedIndexChanged);
            this.lvSuppliers.DoubleClick += new System.EventHandler(this.lvSuppliers_DoubleClick);
            // 
            // colSupplierName
            // 
            this.colSupplierName.Text = "Name";
            this.colSupplierName.Width = 348;
            // 
            // colSupplierStatus
            // 
            this.colSupplierStatus.Text = "Status";
            this.colSupplierStatus.Width = 151;
            // 
            // colSupplierContact
            // 
            this.colSupplierContact.Width = 95;
            // 
            // colSupplierTelephone
            // 
            this.colSupplierTelephone.Width = 90;
            // 
            // colSupplierWebsite
            // 
            this.colSupplierWebsite.Width = 120;
            // 
            // colSupplierAddressLine1
            // 
            this.colSupplierAddressLine1.Width = 200;
            // 
            // colSupplierPostcode
            // 
            this.colSupplierPostcode.Width = 100;
            // 
            // contextMenuSuppliers
            // 
            this.contextMenuSuppliers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuSuppliersEdit,
            this.contextMenuSuppliersWebsite});
            this.contextMenuSuppliers.Name = "contextMenuSuppliers";
            this.contextMenuSuppliers.Size = new System.Drawing.Size(142, 48);
            this.contextMenuSuppliers.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuSuppliers_Opening);
            // 
            // contextMenuSuppliersEdit
            // 
            this.contextMenuSuppliersEdit.Name = "contextMenuSuppliersEdit";
            this.contextMenuSuppliersEdit.Size = new System.Drawing.Size(141, 22);
            this.contextMenuSuppliersEdit.Text = "Edit";
            this.contextMenuSuppliersEdit.Click += new System.EventHandler(this.contextMenuSuppliersEdit_Click);
            // 
            // contextMenuSuppliersWebsite
            // 
            this.contextMenuSuppliersWebsite.Name = "contextMenuSuppliersWebsite";
            this.contextMenuSuppliersWebsite.Size = new System.Drawing.Size(141, 22);
            this.contextMenuSuppliersWebsite.Text = "Visit Website";
            this.contextMenuSuppliersWebsite.Click += new System.EventHandler(this.contextMenuSuppliersWebsite_Click);
            // 
            // lvProducts
            // 
            this.lvProducts.AllowColumnReorder = true;
            this.lvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProductsName,
            this.colProductsMake,
            this.colProductsModel,
            this.colProductsCost,
            this.colProductsSKU,
            this.colProductsType,
            this.colProductsNotes});
            this.lvProducts.FullRowSelect = true;
            this.lvProducts.Location = new System.Drawing.Point(3, 3);
            this.lvProducts.Name = "lvProducts";
            this.lvProducts.OwnerDraw = true;
            this.lvProducts.SaveName = "";
            this.lvProducts.ShowToolTip = false;
            this.lvProducts.Size = new System.Drawing.Size(674, 106);
            this.lvProducts.TabIndex = 17;
            this.lvProducts.UseCompatibleStateImageBehavior = false;
            this.lvProducts.View = System.Windows.Forms.View.Details;
            this.lvProducts.SelectedIndexChanged += new System.EventHandler(this.lvProducts_SelectedIndexChanged);
            this.lvProducts.DoubleClick += new System.EventHandler(this.lvProducts_DoubleClick);
            // 
            // colProductsName
            // 
            this.colProductsName.Text = "Name";
            this.colProductsName.Width = 161;
            // 
            // colProductsMake
            // 
            this.colProductsMake.Text = "Make";
            this.colProductsMake.Width = 151;
            // 
            // colProductsModel
            // 
            this.colProductsModel.Text = "Model";
            this.colProductsModel.Width = 95;
            // 
            // colProductsCost
            // 
            this.colProductsCost.Width = 80;
            // 
            // colProductsSKU
            // 
            this.colProductsSKU.Text = "SKU";
            this.colProductsSKU.Width = 90;
            // 
            // colProductsType
            // 
            this.colProductsType.Width = 80;
            // 
            // colProductsNotes
            // 
            this.colProductsNotes.Width = 200;
            // 
            // suppliersProductSplitter
            // 
            this.suppliersProductSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suppliersProductSplitter.Location = new System.Drawing.Point(3, 28);
            this.suppliersProductSplitter.Name = "suppliersProductSplitter";
            this.suppliersProductSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // suppliersProductSplitter.Panel1
            // 
            this.suppliersProductSplitter.Panel1.Controls.Add(this.lvSuppliers);
            // 
            // suppliersProductSplitter.Panel2
            // 
            this.suppliersProductSplitter.Panel2.Controls.Add(this.lvProducts);
            this.suppliersProductSplitter.Size = new System.Drawing.Size(680, 357);
            this.suppliersProductSplitter.SplitterDistance = 241;
            this.suppliersProductSplitter.TabIndex = 18;
            // 
            // SuppliersListTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.suppliersProductSplitter);
            this.Name = "SuppliersListTab";
            this.Size = new System.Drawing.Size(686, 388);
            this.Controls.SetChildIndex(this.suppliersProductSplitter, 0);
            this.contextMenuSuppliers.ResumeLayout(false);
            this.suppliersProductSplitter.Panel1.ResumeLayout(false);
            this.suppliersProductSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.suppliersProductSplitter)).EndInit();
            this.suppliersProductSplitter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharedControls.Classes.ListViewEx lvSuppliers;
        private System.Windows.Forms.ColumnHeader colSupplierName;
        private System.Windows.Forms.ColumnHeader colSupplierStatus;
        private System.Windows.Forms.ColumnHeader colSupplierAddressLine1;
        private System.Windows.Forms.ColumnHeader colSupplierPostcode;
        private System.Windows.Forms.ColumnHeader colSupplierContact;
        private System.Windows.Forms.ColumnHeader colSupplierTelephone;
        private System.Windows.Forms.ColumnHeader colSupplierWebsite;
        private SharedControls.Classes.ListViewEx lvProducts;
        private System.Windows.Forms.ColumnHeader colProductsName;
        private System.Windows.Forms.ColumnHeader colProductsMake;
        private System.Windows.Forms.ColumnHeader colProductsModel;
        private System.Windows.Forms.ColumnHeader colProductsSKU;
        private System.Windows.Forms.ColumnHeader colProductsType;
        private System.Windows.Forms.ColumnHeader colProductsNotes;
        private System.Windows.Forms.SplitContainer suppliersProductSplitter;
        private System.Windows.Forms.ContextMenuStrip contextMenuSuppliers;
        private System.Windows.Forms.ToolStripMenuItem contextMenuSuppliersEdit;
        private System.Windows.Forms.ToolStripMenuItem contextMenuSuppliersWebsite;
        private System.Windows.Forms.ColumnHeader colProductsCost;
    }
}
