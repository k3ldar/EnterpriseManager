namespace POS.Administration.Controls.Wizards.Coupons
{
    partial class Step3
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
            this.lblMainProduct = new System.Windows.Forms.Label();
            this.cbSpecificProducts = new System.Windows.Forms.CheckBox();
            this.clbMustHaveProducts = new SharedControls.Classes.ListViewEx();
            this.chSKU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pumSelect = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pumSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.pumUnselectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.pumInvertSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.pumSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMainProduct
            // 
            this.lblMainProduct.AutoSize = true;
            this.lblMainProduct.Location = new System.Drawing.Point(3, 32);
            this.lblMainProduct.Name = "lblMainProduct";
            this.lblMainProduct.Size = new System.Drawing.Size(70, 13);
            this.lblMainProduct.TabIndex = 1;
            this.lblMainProduct.Text = "Main Product";
            // 
            // cbSpecificProducts
            // 
            this.cbSpecificProducts.AutoSize = true;
            this.cbSpecificProducts.Location = new System.Drawing.Point(4, 4);
            this.cbSpecificProducts.Name = "cbSpecificProducts";
            this.cbSpecificProducts.Size = new System.Drawing.Size(321, 17);
            this.cbSpecificProducts.TabIndex = 0;
            this.cbSpecificProducts.Text = "Specific products must be within the basket to use this coupon";
            this.cbSpecificProducts.UseVisualStyleBackColor = true;
            this.cbSpecificProducts.CheckedChanged += new System.EventHandler(this.cbSpecificProducts_CheckedChanged);
            // 
            // clbMustHaveProducts
            // 
            this.clbMustHaveProducts.AllowColumnReorder = true;
            this.clbMustHaveProducts.CheckBoxes = true;
            this.clbMustHaveProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSKU,
            this.chProductType,
            this.chProductName,
            this.chProductSize});
            this.clbMustHaveProducts.ContextMenuStrip = this.pumSelect;
            this.clbMustHaveProducts.Location = new System.Drawing.Point(6, 48);
            this.clbMustHaveProducts.Name = "clbMustHaveProducts";
            this.clbMustHaveProducts.OwnerDraw = true;
            this.clbMustHaveProducts.SaveName = "Step3Coupons";
            this.clbMustHaveProducts.ShowToolTip = false;
            this.clbMustHaveProducts.Size = new System.Drawing.Size(557, 293);
            this.clbMustHaveProducts.TabIndex = 4;
            this.clbMustHaveProducts.UseCompatibleStateImageBehavior = false;
            this.clbMustHaveProducts.View = System.Windows.Forms.View.Details;
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
            // pumSelect
            // 
            this.pumSelect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pumSelectAll,
            this.pumUnselectAll,
            this.pumInvertSelection});
            this.pumSelect.Name = "pumSelect";
            this.pumSelect.Size = new System.Drawing.Size(156, 92);
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
            // Step3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clbMustHaveProducts);
            this.Controls.Add(this.cbSpecificProducts);
            this.Controls.Add(this.lblMainProduct);
            this.Name = "Step3";
            this.pumSelect.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMainProduct;
        private System.Windows.Forms.CheckBox cbSpecificProducts;
        private SharedControls.Classes.ListViewEx clbMustHaveProducts;
        private System.Windows.Forms.ColumnHeader chProductType;
        private System.Windows.Forms.ColumnHeader chProductName;
        private System.Windows.Forms.ColumnHeader chProductSize;
        private System.Windows.Forms.ColumnHeader chSKU;
        private System.Windows.Forms.ContextMenuStrip pumSelect;
        private System.Windows.Forms.ToolStripMenuItem pumSelectAll;
        private System.Windows.Forms.ToolStripMenuItem pumUnselectAll;
        private System.Windows.Forms.ToolStripMenuItem pumInvertSelection;
    }
}
