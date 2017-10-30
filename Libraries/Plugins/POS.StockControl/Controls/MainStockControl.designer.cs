namespace POS.StockControl.Controls
{
    partial class MainStockControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainStockControl));
            this.statusStripStock = new System.Windows.Forms.StatusStrip();
            this.statusLabelTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelHidden = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelFilter = new System.Windows.Forms.ToolStripStatusLabel();
            this.gridStock = new System.Windows.Forms.DataGridView();
            this.contextMenuStripStock = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuContextHide = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContextUnHide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorHideGlobal = new System.Windows.Forms.ToolStripSeparator();
            this.menuContextHideGlobally = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContextUnhideGlobally = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuContextHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuContextUpdateOrderQuantity = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContextUpdateMinimumLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuContextOutOfStock = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContextInStock = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuContextEditProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.cbShowHidden = new System.Windows.Forms.CheckBox();
            this.btnCreateStock = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmbProductType = new System.Windows.Forms.ComboBox();
            this.lblProductType = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lblSelectLocation = new System.Windows.Forms.Label();
            this.btnAudit = new System.Windows.Forms.Button();
            this.btnStockOut = new System.Windows.Forms.Button();
            this.btnStockIn = new System.Windows.Forms.Button();
            this.statusStripStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStock)).BeginInit();
            this.contextMenuStripStock.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripStock
            // 
            this.statusStripStock.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelTotal,
            this.statusLabelHidden,
            this.statusLabelFilter});
            this.statusStripStock.Location = new System.Drawing.Point(0, 241);
            this.statusStripStock.Name = "statusStripStock";
            this.statusStripStock.Size = new System.Drawing.Size(824, 22);
            this.statusStripStock.TabIndex = 3;
            this.statusStripStock.Text = "statusStrip1";
            // 
            // statusLabelTotal
            // 
            this.statusLabelTotal.Name = "statusLabelTotal";
            this.statusLabelTotal.Size = new System.Drawing.Size(92, 17);
            this.statusLabelTotal.Text = "statusLabelTotal";
            // 
            // statusLabelHidden
            // 
            this.statusLabelHidden.Name = "statusLabelHidden";
            this.statusLabelHidden.Size = new System.Drawing.Size(105, 17);
            this.statusLabelHidden.Text = "statusLabelHidden";
            // 
            // statusLabelFilter
            // 
            this.statusLabelFilter.Name = "statusLabelFilter";
            this.statusLabelFilter.Size = new System.Drawing.Size(92, 17);
            this.statusLabelFilter.Text = "statusLabelFilter";
            // 
            // gridStock
            // 
            this.gridStock.AllowUserToAddRows = false;
            this.gridStock.AllowUserToDeleteRows = false;
            this.gridStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridStock.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridStock.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStock.ContextMenuStrip = this.contextMenuStripStock;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridStock.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridStock.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridStock.Location = new System.Drawing.Point(1, 76);
            this.gridStock.MultiSelect = false;
            this.gridStock.Name = "gridStock";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridStock.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridStock.Size = new System.Drawing.Size(820, 162);
            this.gridStock.TabIndex = 2;
            this.gridStock.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridStock_CellBeginEdit);
            this.gridStock.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridStock_CellEndEdit);
            this.gridStock.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridStock_CellFormatting);
            this.gridStock.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridStock_CellMouseDown);
            this.gridStock.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridStock_DataError);
            this.gridStock.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gridStock_Scroll);
            // 
            // contextMenuStripStock
            // 
            this.contextMenuStripStock.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuContextHide,
            this.menuContextUnHide,
            this.toolStripSeparatorHideGlobal,
            this.menuContextHideGlobally,
            this.menuContextUnhideGlobally,
            this.toolStripSeparator1,
            this.menuContextHistory,
            this.toolStripMenuItem1,
            this.menuContextUpdateOrderQuantity,
            this.menuContextUpdateMinimumLevel,
            this.toolStripMenuItem3,
            this.menuContextOutOfStock,
            this.menuContextInStock,
            this.toolStripMenuItem2,
            this.menuContextEditProduct});
            this.contextMenuStripStock.Name = "contextMenuStripStock";
            this.contextMenuStripStock.Size = new System.Drawing.Size(199, 254);
            this.contextMenuStripStock.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripStock_Opening);
            // 
            // menuContextHide
            // 
            this.menuContextHide.Name = "menuContextHide";
            this.menuContextHide.Size = new System.Drawing.Size(198, 22);
            this.menuContextHide.Text = "H&ide";
            this.menuContextHide.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // menuContextUnHide
            // 
            this.menuContextUnHide.Name = "menuContextUnHide";
            this.menuContextUnHide.Size = new System.Drawing.Size(198, 22);
            this.menuContextUnHide.Text = "&Un-hide";
            this.menuContextUnHide.Click += new System.EventHandler(this.toolStripMenuItemUnHide_Click);
            // 
            // toolStripSeparatorHideGlobal
            // 
            this.toolStripSeparatorHideGlobal.Name = "toolStripSeparatorHideGlobal";
            this.toolStripSeparatorHideGlobal.Size = new System.Drawing.Size(195, 6);
            // 
            // menuContextHideGlobally
            // 
            this.menuContextHideGlobally.Name = "menuContextHideGlobally";
            this.menuContextHideGlobally.Size = new System.Drawing.Size(198, 22);
            this.menuContextHideGlobally.Text = "Hide &Globally";
            this.menuContextHideGlobally.Click += new System.EventHandler(this.toolStripMenuItemHideGlobally_Click);
            // 
            // menuContextUnhideGlobally
            // 
            this.menuContextUnhideGlobally.Name = "menuContextUnhideGlobally";
            this.menuContextUnhideGlobally.Size = new System.Drawing.Size(198, 22);
            this.menuContextUnhideGlobally.Text = "Un-hide Glo&bally";
            this.menuContextUnhideGlobally.Click += new System.EventHandler(this.toolStripMenuItemUnhideGlobally_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(195, 6);
            // 
            // menuContextHistory
            // 
            this.menuContextHistory.Name = "menuContextHistory";
            this.menuContextHistory.Size = new System.Drawing.Size(198, 22);
            this.menuContextHistory.Text = "&History";
            this.menuContextHistory.Click += new System.EventHandler(this.historyToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(195, 6);
            // 
            // menuContextUpdateOrderQuantity
            // 
            this.menuContextUpdateOrderQuantity.Name = "menuContextUpdateOrderQuantity";
            this.menuContextUpdateOrderQuantity.Size = new System.Drawing.Size(198, 22);
            this.menuContextUpdateOrderQuantity.Text = "Update Order Quantity";
            this.menuContextUpdateOrderQuantity.Click += new System.EventHandler(this.menuContextUpdateOrderQuantity_Click);
            // 
            // menuContextUpdateMinimumLevel
            // 
            this.menuContextUpdateMinimumLevel.Name = "menuContextUpdateMinimumLevel";
            this.menuContextUpdateMinimumLevel.Size = new System.Drawing.Size(198, 22);
            this.menuContextUpdateMinimumLevel.Text = "Update Minimum Level";
            this.menuContextUpdateMinimumLevel.Click += new System.EventHandler(this.menuContextUpdateMinimumLevel_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(195, 6);
            // 
            // menuContextOutOfStock
            // 
            this.menuContextOutOfStock.Name = "menuContextOutOfStock";
            this.menuContextOutOfStock.Size = new System.Drawing.Size(198, 22);
            this.menuContextOutOfStock.Text = "Change to &Out of Stock";
            this.menuContextOutOfStock.Click += new System.EventHandler(this.changeToOutOfStockToolStripMenuItem_Click);
            // 
            // menuContextInStock
            // 
            this.menuContextInStock.Name = "menuContextInStock";
            this.menuContextInStock.Size = new System.Drawing.Size(198, 22);
            this.menuContextInStock.Text = "Change to &In Stock";
            this.menuContextInStock.Click += new System.EventHandler(this.changeToInStockToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(195, 6);
            // 
            // menuContextEditProduct
            // 
            this.menuContextEditProduct.Name = "menuContextEditProduct";
            this.menuContextEditProduct.Size = new System.Drawing.Size(198, 22);
            this.menuContextEditProduct.Text = "&Edit Product";
            this.menuContextEditProduct.Click += new System.EventHandler(this.editProductToolStripMenuItem_Click);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlToolbar.Controls.Add(this.cbShowHidden);
            this.pnlToolbar.Controls.Add(this.btnCreateStock);
            this.pnlToolbar.Controls.Add(this.txtFilter);
            this.pnlToolbar.Controls.Add(this.lblFilter);
            this.pnlToolbar.Controls.Add(this.cmbProductType);
            this.pnlToolbar.Controls.Add(this.lblProductType);
            this.pnlToolbar.Controls.Add(this.cmbLocation);
            this.pnlToolbar.Controls.Add(this.lblSelectLocation);
            this.pnlToolbar.Controls.Add(this.btnAudit);
            this.pnlToolbar.Controls.Add(this.btnStockOut);
            this.pnlToolbar.Controls.Add(this.btnStockIn);
            this.pnlToolbar.Location = new System.Drawing.Point(1, 1);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(820, 74);
            this.pnlToolbar.TabIndex = 0;
            // 
            // cbShowHidden
            // 
            this.cbShowHidden.AutoSize = true;
            this.cbShowHidden.Location = new System.Drawing.Point(335, 51);
            this.cbShowHidden.Name = "cbShowHidden";
            this.cbShowHidden.Size = new System.Drawing.Size(118, 17);
            this.cbShowHidden.TabIndex = 10;
            this.cbShowHidden.Text = "Show Hidden Items";
            this.cbShowHidden.UseVisualStyleBackColor = true;
            this.cbShowHidden.CheckedChanged += new System.EventHandler(this.cbShowHidden_CheckedChanged);
            // 
            // btnCreateStock
            // 
            this.btnCreateStock.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateStock.Image")));
            this.btnCreateStock.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCreateStock.Location = new System.Drawing.Point(246, 3);
            this.btnCreateStock.Name = "btnCreateStock";
            this.btnCreateStock.Size = new System.Drawing.Size(80, 66);
            this.btnCreateStock.TabIndex = 9;
            this.btnCreateStock.Text = "Create Stock";
            this.btnCreateStock.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCreateStock.UseVisualStyleBackColor = true;
            this.btnCreateStock.Click += new System.EventHandler(this.btnCreateStock_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(667, 28);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(146, 20);
            this.txtFilter.TabIndex = 8;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(666, 10);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(29, 13);
            this.lblFilter.TabIndex = 7;
            this.lblFilter.Text = "Filter";
            // 
            // cmbProductType
            // 
            this.cmbProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductType.DropDownWidth = 220;
            this.cmbProductType.FormattingEnabled = true;
            this.cmbProductType.Items.AddRange(new object[] {
            "2",
            "1",
            "3",
            "0"});
            this.cmbProductType.Location = new System.Drawing.Point(471, 27);
            this.cmbProductType.Name = "cmbProductType";
            this.cmbProductType.Size = new System.Drawing.Size(190, 21);
            this.cmbProductType.TabIndex = 6;
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.Location = new System.Drawing.Point(468, 8);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(71, 13);
            this.lblProductType.TabIndex = 5;
            this.lblProductType.Text = "Product Type";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(335, 27);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(130, 21);
            this.cmbLocation.TabIndex = 4;
            this.cmbLocation.SelectedIndexChanged += new System.EventHandler(this.cmbLocation_SelectedIndexChanged);
            this.cmbLocation.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.comboBox1_Format);
            // 
            // lblSelectLocation
            // 
            this.lblSelectLocation.AutoSize = true;
            this.lblSelectLocation.Location = new System.Drawing.Point(332, 10);
            this.lblSelectLocation.Name = "lblSelectLocation";
            this.lblSelectLocation.Size = new System.Drawing.Size(81, 13);
            this.lblSelectLocation.TabIndex = 3;
            this.lblSelectLocation.Text = "Select Location";
            // 
            // btnAudit
            // 
            this.btnAudit.Image = ((System.Drawing.Image)(resources.GetObject("btnAudit.Image")));
            this.btnAudit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAudit.Location = new System.Drawing.Point(165, 3);
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(80, 66);
            this.btnAudit.TabIndex = 2;
            this.btnAudit.Text = "Stock Audit";
            this.btnAudit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAudit.UseVisualStyleBackColor = true;
            this.btnAudit.Click += new System.EventHandler(this.btnAudit_Click);
            // 
            // btnStockOut
            // 
            this.btnStockOut.Image = ((System.Drawing.Image)(resources.GetObject("btnStockOut.Image")));
            this.btnStockOut.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStockOut.Location = new System.Drawing.Point(84, 3);
            this.btnStockOut.Name = "btnStockOut";
            this.btnStockOut.Size = new System.Drawing.Size(80, 66);
            this.btnStockOut.TabIndex = 1;
            this.btnStockOut.Text = "Stock Out";
            this.btnStockOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStockOut.UseVisualStyleBackColor = true;
            this.btnStockOut.Click += new System.EventHandler(this.btnStockOut_Click);
            // 
            // btnStockIn
            // 
            this.btnStockIn.Image = ((System.Drawing.Image)(resources.GetObject("btnStockIn.Image")));
            this.btnStockIn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStockIn.Location = new System.Drawing.Point(3, 3);
            this.btnStockIn.Name = "btnStockIn";
            this.btnStockIn.Size = new System.Drawing.Size(80, 66);
            this.btnStockIn.TabIndex = 0;
            this.btnStockIn.Text = "Stock In";
            this.btnStockIn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStockIn.UseVisualStyleBackColor = true;
            this.btnStockIn.Click += new System.EventHandler(this.btnStockIn_Click);
            // 
            // MainStockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStripStock);
            this.Controls.Add(this.gridStock);
            this.Controls.Add(this.pnlToolbar);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(824, 263);
            this.Name = "MainStockControl";
            this.Size = new System.Drawing.Size(824, 263);
            this.statusStripStock.ResumeLayout(false);
            this.statusStripStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStock)).EndInit();
            this.contextMenuStripStock.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.DataGridView gridStock;
        private System.Windows.Forms.Button btnAudit;
        private System.Windows.Forms.Button btnStockOut;
        private System.Windows.Forms.Button btnStockIn;
        private System.Windows.Forms.StatusStrip statusStripStock;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lblSelectLocation;
        private System.Windows.Forms.ComboBox cmbProductType;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button btnCreateStock;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelTotal;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelHidden;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelFilter;
        private System.Windows.Forms.CheckBox cbShowHidden;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripStock;
        private System.Windows.Forms.ToolStripMenuItem menuContextHide;
        private System.Windows.Forms.ToolStripMenuItem menuContextUnHide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorHideGlobal;
        private System.Windows.Forms.ToolStripMenuItem menuContextHideGlobally;
        private System.Windows.Forms.ToolStripMenuItem menuContextUnhideGlobally;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuContextHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuContextUpdateOrderQuantity;
        private System.Windows.Forms.ToolStripMenuItem menuContextUpdateMinimumLevel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem menuContextOutOfStock;
        private System.Windows.Forms.ToolStripMenuItem menuContextInStock;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuContextEditProduct;
    }
}