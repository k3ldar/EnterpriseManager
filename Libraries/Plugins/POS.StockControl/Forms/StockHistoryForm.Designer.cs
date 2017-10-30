namespace POS.StockControl.Forms
{
    partial class StockHistoryForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageHistory = new System.Windows.Forms.TabPage();
            this.cbInternetSales = new System.Windows.Forms.CheckBox();
            this.lvHistory = new SharedControls.Classes.ListViewEx();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageTotals = new System.Windows.Forms.TabPage();
            this.lvStockTotals = new SharedControls.Classes.ListViewEx();
            this.colHeaderStockTotalsDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderStockTotalsUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderStockTotalsOldQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderStockTotalsNewQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPageHistory.SuspendLayout();
            this.tabPageTotals.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(661, 343);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageHistory);
            this.tabControl1.Controls.Add(this.tabPageTotals);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(729, 323);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageHistory
            // 
            this.tabPageHistory.Controls.Add(this.cbInternetSales);
            this.tabPageHistory.Controls.Add(this.lvHistory);
            this.tabPageHistory.Location = new System.Drawing.Point(4, 22);
            this.tabPageHistory.Name = "tabPageHistory";
            this.tabPageHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHistory.Size = new System.Drawing.Size(721, 297);
            this.tabPageHistory.TabIndex = 0;
            this.tabPageHistory.Text = "History";
            this.tabPageHistory.UseVisualStyleBackColor = true;
            // 
            // cbInternetSales
            // 
            this.cbInternetSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbInternetSales.AutoSize = true;
            this.cbInternetSales.Location = new System.Drawing.Point(6, 274);
            this.cbInternetSales.Name = "cbInternetSales";
            this.cbInternetSales.Size = new System.Drawing.Size(121, 17);
            this.cbInternetSales.TabIndex = 3;
            this.cbInternetSales.Text = "Show &Internet Sales";
            this.cbInternetSales.UseVisualStyleBackColor = true;
            // 
            // lvHistory
            // 
            this.lvHistory.AllowColumnReorder = true;
            this.lvHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colUser,
            this.colLocation,
            this.colReason,
            this.colQuantity});
            this.lvHistory.Location = new System.Drawing.Point(6, 6);
            this.lvHistory.MultiSelect = false;
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.OwnerDraw = true;
            this.lvHistory.SaveName = "";
            this.lvHistory.ShowToolTip = false;
            this.lvHistory.Size = new System.Drawing.Size(709, 262);
            this.lvHistory.TabIndex = 2;
            this.lvHistory.UseCompatibleStateImageBehavior = false;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 150;
            // 
            // colUser
            // 
            this.colUser.Text = "User";
            this.colUser.Width = 150;
            // 
            // colLocation
            // 
            this.colLocation.Text = "Location";
            this.colLocation.Width = 120;
            // 
            // colReason
            // 
            this.colReason.Text = "Reason";
            this.colReason.Width = 190;
            // 
            // colQuantity
            // 
            this.colQuantity.Text = "Quantity";
            // 
            // tabPageTotals
            // 
            this.tabPageTotals.Controls.Add(this.lvStockTotals);
            this.tabPageTotals.Location = new System.Drawing.Point(4, 22);
            this.tabPageTotals.Name = "tabPageTotals";
            this.tabPageTotals.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTotals.Size = new System.Drawing.Size(721, 297);
            this.tabPageTotals.TabIndex = 1;
            this.tabPageTotals.Text = "Totals";
            this.tabPageTotals.UseVisualStyleBackColor = true;
            // 
            // lvStockTotals
            // 
            this.lvStockTotals.AllowColumnReorder = true;
            this.lvStockTotals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvStockTotals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderStockTotalsDate,
            this.colHeaderStockTotalsUser,
            this.colHeaderStockTotalsOldQuantity,
            this.colHeaderStockTotalsNewQuantity});
            this.lvStockTotals.Location = new System.Drawing.Point(6, 6);
            this.lvStockTotals.MultiSelect = false;
            this.lvStockTotals.Name = "lvStockTotals";
            this.lvStockTotals.OwnerDraw = true;
            this.lvStockTotals.SaveName = "lvStockTotals";
            this.lvStockTotals.ShowToolTip = false;
            this.lvStockTotals.Size = new System.Drawing.Size(709, 285);
            this.lvStockTotals.TabIndex = 3;
            this.lvStockTotals.UseCompatibleStateImageBehavior = false;
            this.lvStockTotals.View = System.Windows.Forms.View.Details;
            // 
            // colHeaderStockTotalsDate
            // 
            this.colHeaderStockTotalsDate.Text = "Date";
            this.colHeaderStockTotalsDate.Width = 150;
            // 
            // colHeaderStockTotalsUser
            // 
            this.colHeaderStockTotalsUser.Text = "User";
            this.colHeaderStockTotalsUser.Width = 150;
            // 
            // colHeaderStockTotalsOldQuantity
            // 
            this.colHeaderStockTotalsOldQuantity.Text = "Old Value";
            this.colHeaderStockTotalsOldQuantity.Width = 120;
            // 
            // colHeaderStockTotalsNewQuantity
            // 
            this.colHeaderStockTotalsNewQuantity.Text = "New Quantity";
            this.colHeaderStockTotalsNewQuantity.Width = 120;
            // 
            // StockHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 378);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockHistoryForm";
            this.SaveState = true;
            this.ShowIcon = false;
            this.Text = "Stock History Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockHistoryForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPageHistory.ResumeLayout(false);
            this.tabPageHistory.PerformLayout();
            this.tabPageTotals.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageHistory;
        private System.Windows.Forms.CheckBox cbInternetSales;
        private SharedControls.Classes.ListViewEx lvHistory;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colUser;
        private System.Windows.Forms.ColumnHeader colLocation;
        private System.Windows.Forms.ColumnHeader colReason;
        private System.Windows.Forms.ColumnHeader colQuantity;
        private System.Windows.Forms.TabPage tabPageTotals;
        private SharedControls.Classes.ListViewEx lvStockTotals;
        private System.Windows.Forms.ColumnHeader colHeaderStockTotalsDate;
        private System.Windows.Forms.ColumnHeader colHeaderStockTotalsUser;
        private System.Windows.Forms.ColumnHeader colHeaderStockTotalsOldQuantity;
        private System.Windows.Forms.ColumnHeader colHeaderStockTotalsNewQuantity;
    }
}