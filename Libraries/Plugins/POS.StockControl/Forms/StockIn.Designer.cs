namespace POS.StockControl.Forms
{
    partial class StockIn
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
            this.gridStock = new System.Windows.Forms.DataGridView();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmbProductType = new System.Windows.Forms.ComboBox();
            this.lblProductType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridStock)).BeginInit();
            this.SuspendLayout();
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
            this.gridStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStock.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridStock.Location = new System.Drawing.Point(0, 53);
            this.gridStock.MultiSelect = false;
            this.gridStock.Name = "gridStock";
            this.gridStock.Size = new System.Drawing.Size(634, 351);
            this.gridStock.TabIndex = 3;
            this.gridStock.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridStock_CellBeginEdit);
            this.gridStock.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridStock_CellFormatting);
            this.gridStock.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridStock_DataError);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(263, 26);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(191, 20);
            this.txtFilter.TabIndex = 12;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(260, 9);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(29, 13);
            this.lblFilter.TabIndex = 11;
            this.lblFilter.Text = "Filter";
            // 
            // cmbProductType
            // 
            this.cmbProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductType.FormattingEnabled = true;
            this.cmbProductType.Location = new System.Drawing.Point(7, 26);
            this.cmbProductType.Name = "cmbProductType";
            this.cmbProductType.Size = new System.Drawing.Size(232, 21);
            this.cmbProductType.TabIndex = 10;
            this.cmbProductType.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbProductType_Format);
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.Location = new System.Drawing.Point(7, 9);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(71, 13);
            this.lblProductType.TabIndex = 9;
            this.lblProductType.Text = "Product Type";
            // 
            // StockIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 404);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cmbProductType);
            this.Controls.Add(this.lblProductType);
            this.Controls.Add(this.gridStock);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MaximizeBox = false;
            this.Name = "StockIn";
            this.SaveState = true;
            this.Text = "Bring Stock In";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockIn_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridStock;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbProductType;
        private System.Windows.Forms.Label lblProductType;
    }
}