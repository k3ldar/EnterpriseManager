namespace POS.Administration.Controls.Wizards.Coupons
{
    partial class Step5
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
            this.clbExcludedProducts = new SharedControls.Classes.ListViewEx();
            this.chSKU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbExcludedProducts = new System.Windows.Forms.CheckBox();
            this.lblExcludedProduct = new System.Windows.Forms.Label();
            this.pumSelect = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pumSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.pumUnselectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.pumInvertSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.pumSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbExcludedProducts
            // 
            this.clbExcludedProducts.AllowColumnReorder = true;
            this.clbExcludedProducts.CheckBoxes = true;
            this.clbExcludedProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSKU,
            this.chProductType,
            this.chProductName,
            this.chProductSize});
            this.clbExcludedProducts.ContextMenuStrip = this.pumSelect;
            this.clbExcludedProducts.Location = new System.Drawing.Point(6, 54);
            this.clbExcludedProducts.Name = "clbExcludedProducts";
            this.clbExcludedProducts.OwnerDraw = true;
            this.clbExcludedProducts.SaveName = "Step3Coupons";
            this.clbExcludedProducts.ShowToolTip = false;
            this.clbExcludedProducts.Size = new System.Drawing.Size(557, 293);
            this.clbExcludedProducts.TabIndex = 7;
            this.clbExcludedProducts.UseCompatibleStateImageBehavior = false;
            this.clbExcludedProducts.View = System.Windows.Forms.View.Details;
            // 
            // chSKU
            // 
            this.chSKU.Text = "SKU";
            this.chSKU.Width = 80;
            // 
            // chProductType
            // 
            this.chProductType.Text = "ProductType";
            this.chProductType.Width = 114;
            // 
            // chProductName
            // 
            this.chProductName.Text = "Product Name";
            this.chProductName.Width = 263;
            // 
            // chProductSize
            // 
            this.chProductSize.Text = "Size";
            this.chProductSize.Width = 150;
            // 
            // cbExcludedProducts
            // 
            this.cbExcludedProducts.AutoSize = true;
            this.cbExcludedProducts.Location = new System.Drawing.Point(4, 10);
            this.cbExcludedProducts.Name = "cbExcludedProducts";
            this.cbExcludedProducts.Size = new System.Drawing.Size(321, 17);
            this.cbExcludedProducts.TabIndex = 5;
            this.cbExcludedProducts.Text = "Specific products must be within the basket to use this coupon";
            this.cbExcludedProducts.UseVisualStyleBackColor = true;
            this.cbExcludedProducts.CheckedChanged += new System.EventHandler(this.cbSpecificProducts_CheckedChanged);
            // 
            // lblExcludedProduct
            // 
            this.lblExcludedProduct.AutoSize = true;
            this.lblExcludedProduct.Location = new System.Drawing.Point(3, 38);
            this.lblExcludedProduct.Name = "lblExcludedProduct";
            this.lblExcludedProduct.Size = new System.Drawing.Size(70, 13);
            this.lblExcludedProduct.TabIndex = 6;
            this.lblExcludedProduct.Text = "Main Product";
            // 
            // pumSelect
            // 
            this.pumSelect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pumSelectAll,
            this.pumUnselectAll,
            this.pumInvertSelection});
            this.pumSelect.Name = "pumSelect";
            this.pumSelect.Size = new System.Drawing.Size(156, 70);
            // 
            // pumSelectAll
            // 
            this.pumSelectAll.Name = "pumSelectAll";
            this.pumSelectAll.Size = new System.Drawing.Size(155, 22);
            this.pumSelectAll.Text = "Select All";
            this.pumSelectAll.Click += new System.EventHandler(this.pumSelectAll_Click);
            // 
            // pumUnselectAll
            // 
            this.pumUnselectAll.Name = "pumUnselectAll";
            this.pumUnselectAll.Size = new System.Drawing.Size(155, 22);
            this.pumUnselectAll.Text = "Unselect All";
            this.pumUnselectAll.Click += new System.EventHandler(this.pumUnselectAll_Click);
            // 
            // pumInvertSelection
            // 
            this.pumInvertSelection.Name = "pumInvertSelection";
            this.pumInvertSelection.Size = new System.Drawing.Size(155, 22);
            this.pumInvertSelection.Text = "Invert Selection";
            this.pumInvertSelection.Click += new System.EventHandler(this.pumInvertSelection_Click);
            // 
            // Step5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clbExcludedProducts);
            this.Controls.Add(this.cbExcludedProducts);
            this.Controls.Add(this.lblExcludedProduct);
            this.Name = "Step5";
            this.pumSelect.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharedControls.Classes.ListViewEx clbExcludedProducts;
        private System.Windows.Forms.ColumnHeader chSKU;
        private System.Windows.Forms.ColumnHeader chProductType;
        private System.Windows.Forms.ColumnHeader chProductName;
        private System.Windows.Forms.ColumnHeader chProductSize;
        private System.Windows.Forms.CheckBox cbExcludedProducts;
        private System.Windows.Forms.Label lblExcludedProduct;
        private System.Windows.Forms.ContextMenuStrip pumSelect;
        private System.Windows.Forms.ToolStripMenuItem pumSelectAll;
        private System.Windows.Forms.ToolStripMenuItem pumUnselectAll;
        private System.Windows.Forms.ToolStripMenuItem pumInvertSelection;
    }
}
