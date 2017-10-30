namespace POS.PurchaseOrders.Controls
{
    partial class PurchaseOrderTab
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
            this.lvPurchaseOrders = new SharedControls.Classes.ListViewEx();
            this.colPOID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPODate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPOStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPOSupplier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvPurchaseOrders
            // 
            this.lvPurchaseOrders.AllowColumnReorder = true;
            this.lvPurchaseOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPurchaseOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPOID,
            this.colPODate,
            this.colPOStatus,
            this.colPOSupplier});
            this.lvPurchaseOrders.FullRowSelect = true;
            this.lvPurchaseOrders.Location = new System.Drawing.Point(3, 28);
            this.lvPurchaseOrders.Name = "lvPurchaseOrders";
            this.lvPurchaseOrders.OwnerDraw = true;
            this.lvPurchaseOrders.SaveName = "";
            this.lvPurchaseOrders.ShowToolTip = false;
            this.lvPurchaseOrders.Size = new System.Drawing.Size(659, 163);
            this.lvPurchaseOrders.TabIndex = 15;
            this.lvPurchaseOrders.UseCompatibleStateImageBehavior = false;
            this.lvPurchaseOrders.View = System.Windows.Forms.View.Details;
            // 
            // colPOID
            // 
            this.colPOID.Text = "ID";
            this.colPOID.Width = 139;
            // 
            // colPODate
            // 
            this.colPODate.Text = "Date";
            this.colPODate.Width = 153;
            // 
            // colPOStatus
            // 
            this.colPOStatus.Text = "Status";
            this.colPOStatus.Width = 124;
            // 
            // colPOSupplier
            // 
            this.colPOSupplier.Text = "Supplier";
            this.colPOSupplier.Width = 302;
            // 
            // PurchaseOrderTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvPurchaseOrders);
            this.Name = "PurchaseOrderTab";
            this.Controls.SetChildIndex(this.lvPurchaseOrders, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharedControls.Classes.ListViewEx lvPurchaseOrders;
        private System.Windows.Forms.ColumnHeader colPOID;
        private System.Windows.Forms.ColumnHeader colPODate;
        private System.Windows.Forms.ColumnHeader colPOStatus;
        private System.Windows.Forms.ColumnHeader colPOSupplier;
    }
}
