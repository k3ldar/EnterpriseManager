namespace POS.StockControl.Forms
{
    partial class CreateStockForm
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
            this.lblStockBeingCreated = new System.Windows.Forms.Label();
            this.lstStockBeingCreated = new System.Windows.Forms.ListBox();
            this.lblNoOfUnits = new System.Windows.Forms.Label();
            this.spinNumberCreated = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstAvailableProducts = new System.Windows.Forms.ListBox();
            this.lblAllProducts = new System.Windows.Forms.Label();
            this.lblItemsUsed = new System.Windows.Forms.Label();
            this.lblProductType = new System.Windows.Forms.Label();
            this.cmbProductTypes = new System.Windows.Forms.ComboBox();
            this.layoutDependencies = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMainProductType = new System.Windows.Forms.Label();
            this.cmbMainProductType = new System.Windows.Forms.ComboBox();
            this.btnCreateStock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spinNumberCreated)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStockBeingCreated
            // 
            this.lblStockBeingCreated.AutoSize = true;
            this.lblStockBeingCreated.Location = new System.Drawing.Point(13, 40);
            this.lblStockBeingCreated.Name = "lblStockBeingCreated";
            this.lblStockBeingCreated.Size = new System.Drawing.Size(126, 13);
            this.lblStockBeingCreated.TabIndex = 0;
            this.lblStockBeingCreated.Text = "Stock Item being created";
            // 
            // lstStockBeingCreated
            // 
            this.lstStockBeingCreated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstStockBeingCreated.FormattingEnabled = true;
            this.lstStockBeingCreated.Location = new System.Drawing.Point(16, 56);
            this.lstStockBeingCreated.Name = "lstStockBeingCreated";
            this.lstStockBeingCreated.Size = new System.Drawing.Size(532, 95);
            this.lstStockBeingCreated.TabIndex = 1;
            this.lstStockBeingCreated.SelectedIndexChanged += new System.EventHandler(this.lstStockBeingCreated_SelectedIndexChanged);
            this.lstStockBeingCreated.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstStockBeingCreated_Format);
            // 
            // lblNoOfUnits
            // 
            this.lblNoOfUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoOfUnits.AutoSize = true;
            this.lblNoOfUnits.Location = new System.Drawing.Point(566, 13);
            this.lblNoOfUnits.Name = "lblNoOfUnits";
            this.lblNoOfUnits.Size = new System.Drawing.Size(151, 13);
            this.lblNoOfUnits.TabIndex = 2;
            this.lblNoOfUnits.Text = "Number of Units being created";
            // 
            // spinNumberCreated
            // 
            this.spinNumberCreated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spinNumberCreated.Location = new System.Drawing.Point(569, 30);
            this.spinNumberCreated.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spinNumberCreated.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinNumberCreated.Name = "spinNumberCreated";
            this.spinNumberCreated.Size = new System.Drawing.Size(148, 20);
            this.spinNumberCreated.TabIndex = 3;
            this.spinNumberCreated.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(16, 155);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 4);
            this.panel1.TabIndex = 4;
            // 
            // lstAvailableProducts
            // 
            this.lstAvailableProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAvailableProducts.FormattingEnabled = true;
            this.lstAvailableProducts.Location = new System.Drawing.Point(569, 208);
            this.lstAvailableProducts.Name = "lstAvailableProducts";
            this.lstAvailableProducts.Size = new System.Drawing.Size(280, 82);
            this.lstAvailableProducts.TabIndex = 5;
            this.lstAvailableProducts.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstStockBeingCreated_Format);
            this.lstAvailableProducts.DoubleClick += new System.EventHandler(this.lstAvailableProducts_DoubleClick);
            // 
            // lblAllProducts
            // 
            this.lblAllProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAllProducts.AutoSize = true;
            this.lblAllProducts.Location = new System.Drawing.Point(566, 192);
            this.lblAllProducts.Name = "lblAllProducts";
            this.lblAllProducts.Size = new System.Drawing.Size(231, 13);
            this.lblAllProducts.TabIndex = 6;
            this.lblAllProducts.Text = "All Available Product Items (double click to add)";
            // 
            // lblItemsUsed
            // 
            this.lblItemsUsed.AutoSize = true;
            this.lblItemsUsed.Location = new System.Drawing.Point(13, 166);
            this.lblItemsUsed.Name = "lblItemsUsed";
            this.lblItemsUsed.Size = new System.Drawing.Size(142, 13);
            this.lblItemsUsed.TabIndex = 7;
            this.lblItemsUsed.Text = "Items used to create product";
            // 
            // lblProductType
            // 
            this.lblProductType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductType.AutoSize = true;
            this.lblProductType.Location = new System.Drawing.Point(566, 166);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(71, 13);
            this.lblProductType.TabIndex = 8;
            this.lblProductType.Text = "Product Type";
            // 
            // cmbProductTypes
            // 
            this.cmbProductTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProductTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductTypes.FormattingEnabled = true;
            this.cmbProductTypes.Location = new System.Drawing.Point(643, 163);
            this.cmbProductTypes.Name = "cmbProductTypes";
            this.cmbProductTypes.Size = new System.Drawing.Size(206, 21);
            this.cmbProductTypes.TabIndex = 9;
            this.cmbProductTypes.SelectedIndexChanged += new System.EventHandler(this.cmbProductTypes_SelectedIndexChanged);
            this.cmbProductTypes.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbProductTypes_Format);
            // 
            // layoutDependencies
            // 
            this.layoutDependencies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutDependencies.AutoScroll = true;
            this.layoutDependencies.Location = new System.Drawing.Point(16, 183);
            this.layoutDependencies.Name = "layoutDependencies";
            this.layoutDependencies.Size = new System.Drawing.Size(532, 116);
            this.layoutDependencies.TabIndex = 10;
            this.layoutDependencies.SizeChanged += new System.EventHandler(this.layoutDependencies_SizeChanged);
            // 
            // lblMainProductType
            // 
            this.lblMainProductType.AutoSize = true;
            this.lblMainProductType.Location = new System.Drawing.Point(13, 16);
            this.lblMainProductType.Name = "lblMainProductType";
            this.lblMainProductType.Size = new System.Drawing.Size(97, 13);
            this.lblMainProductType.TabIndex = 11;
            this.lblMainProductType.Text = "Main Product Type";
            // 
            // cmbMainProductType
            // 
            this.cmbMainProductType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMainProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMainProductType.FormattingEnabled = true;
            this.cmbMainProductType.Location = new System.Drawing.Point(119, 13);
            this.cmbMainProductType.Name = "cmbMainProductType";
            this.cmbMainProductType.Size = new System.Drawing.Size(429, 21);
            this.cmbMainProductType.TabIndex = 12;
            this.cmbMainProductType.SelectedIndexChanged += new System.EventHandler(this.cmbMainProductType_SelectedIndexChanged);
            this.cmbMainProductType.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbProductTypes_Format);
            // 
            // btnCreateStock
            // 
            this.btnCreateStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateStock.Location = new System.Drawing.Point(737, 16);
            this.btnCreateStock.Name = "btnCreateStock";
            this.btnCreateStock.Size = new System.Drawing.Size(112, 90);
            this.btnCreateStock.TabIndex = 13;
            this.btnCreateStock.Text = "Create Stock";
            this.btnCreateStock.UseVisualStyleBackColor = true;
            this.btnCreateStock.Click += new System.EventHandler(this.btnCreateStock_Click);
            // 
            // CreateStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 311);
            this.Controls.Add(this.btnCreateStock);
            this.Controls.Add(this.cmbMainProductType);
            this.Controls.Add(this.lblMainProductType);
            this.Controls.Add(this.layoutDependencies);
            this.Controls.Add(this.cmbProductTypes);
            this.Controls.Add(this.lblProductType);
            this.Controls.Add(this.lblItemsUsed);
            this.Controls.Add(this.lblAllProducts);
            this.Controls.Add(this.lstAvailableProducts);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.spinNumberCreated);
            this.Controls.Add(this.lblNoOfUnits);
            this.Controls.Add(this.lstStockBeingCreated);
            this.Controls.Add(this.lblStockBeingCreated);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(876, 350);
            this.Name = "CreateStockForm";
            this.SaveState = true;
            this.Text = "Create Stock";
            ((System.ComponentModel.ISupportInitialize)(this.spinNumberCreated)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStockBeingCreated;
        private System.Windows.Forms.ListBox lstStockBeingCreated;
        private System.Windows.Forms.Label lblNoOfUnits;
        private System.Windows.Forms.NumericUpDown spinNumberCreated;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstAvailableProducts;
        private System.Windows.Forms.Label lblAllProducts;
        private System.Windows.Forms.Label lblItemsUsed;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.ComboBox cmbProductTypes;
        private System.Windows.Forms.FlowLayoutPanel layoutDependencies;
        private System.Windows.Forms.Label lblMainProductType;
        private System.Windows.Forms.ComboBox cmbMainProductType;
        private System.Windows.Forms.Button btnCreateStock;
    }
}