namespace POS.Administration.Forms.DiscountCoupons
{
    partial class AdminDiscountCoupons
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDiscountCoupons));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstDiscounts = new SharedControls.Classes.ListViewEx();
            this.colHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderExpires = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderDiscount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderUses = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuCoupons = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripMainAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMainRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMainTypes = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 304);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(738, 22);
            this.statusStrip1.TabIndex = 35;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(132, 17);
            this.toolStripStatusLabelCount.Text = "0 Coupon Codes Found";
            // 
            // lstDiscounts
            // 
            this.lstDiscounts.AllowColumnReorder = true;
            this.lstDiscounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDiscounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderName,
            this.colHeaderExpires,
            this.colHeaderDiscount,
            this.colHeaderActive,
            this.colHeaderUses});
            this.lstDiscounts.ContextMenuStrip = this.contextMenuCoupons;
            this.lstDiscounts.FullRowSelect = true;
            this.lstDiscounts.Location = new System.Drawing.Point(0, 28);
            this.lstDiscounts.MultiSelect = false;
            this.lstDiscounts.Name = "lstDiscounts";
            this.lstDiscounts.OwnerDraw = true;
            this.lstDiscounts.SaveName = "";
            this.lstDiscounts.ShowToolTip = false;
            this.lstDiscounts.Size = new System.Drawing.Size(738, 273);
            this.lstDiscounts.TabIndex = 34;
            this.lstDiscounts.UseCompatibleStateImageBehavior = false;
            this.lstDiscounts.View = System.Windows.Forms.View.Details;
            this.lstDiscounts.SelectedIndexChanged += new System.EventHandler(this.lstDiscounts_SelectedIndexChanged);
            this.lstDiscounts.DoubleClick += new System.EventHandler(this.lstDiscounts_DoubleClick);
            // 
            // colHeaderName
            // 
            this.colHeaderName.Text = "Name";
            this.colHeaderName.Width = 150;
            // 
            // colHeaderExpires
            // 
            this.colHeaderExpires.DisplayIndex = 2;
            this.colHeaderExpires.Text = "Expires";
            this.colHeaderExpires.Width = 100;
            // 
            // colHeaderDiscount
            // 
            this.colHeaderDiscount.DisplayIndex = 3;
            this.colHeaderDiscount.Text = "Discount";
            // 
            // colHeaderActive
            // 
            this.colHeaderActive.DisplayIndex = 1;
            this.colHeaderActive.Text = "Active";
            // 
            // colHeaderUses
            // 
            this.colHeaderUses.Text = "Times Used";
            this.colHeaderUses.Width = 80;
            // 
            // contextMenuCoupons
            // 
            this.contextMenuCoupons.Name = "contextMenuCoupons";
            this.contextMenuCoupons.Size = new System.Drawing.Size(153, 26);
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMainAdd,
            this.toolStripMainDelete,
            this.toolStripMainEdit,
            this.toolStripSeparator1,
            this.toolStripMainRefresh,
            this.toolStripSeparator2,
            this.toolStripMainTypes});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(738, 25);
            this.toolStripMain.TabIndex = 38;
            // 
            // toolStripMainAdd
            // 
            this.toolStripMainAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainAdd.Image")));
            this.toolStripMainAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainAdd.Name = "toolStripMainAdd";
            this.toolStripMainAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainAdd.Click += new System.EventHandler(this.toolStripMainAdd_Click);
            // 
            // toolStripMainDelete
            // 
            this.toolStripMainDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainDelete.Image")));
            this.toolStripMainDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainDelete.Name = "toolStripMainDelete";
            this.toolStripMainDelete.Size = new System.Drawing.Size(23, 22);
            // 
            // toolStripMainEdit
            // 
            this.toolStripMainEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainEdit.Image")));
            this.toolStripMainEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainEdit.Name = "toolStripMainEdit";
            this.toolStripMainEdit.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainEdit.Click += new System.EventHandler(this.toolStripMainEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripMainRefresh
            // 
            this.toolStripMainRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainRefresh.Image")));
            this.toolStripMainRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainRefresh.Name = "toolStripMainRefresh";
            this.toolStripMainRefresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainRefresh.Click += new System.EventHandler(this.toolStripMainRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripMainTypes
            // 
            this.toolStripMainTypes.Name = "toolStripMainTypes";
            this.toolStripMainTypes.Size = new System.Drawing.Size(121, 25);
            // 
            // AdminDiscountCoupons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 326);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lstDiscounts);
            this.Name = "AdminDiscountCoupons";
            this.Text = "Administration - Discount Coupons";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private SharedControls.Classes.ListViewEx lstDiscounts;
        private System.Windows.Forms.ColumnHeader colHeaderName;
        private System.Windows.Forms.ColumnHeader colHeaderExpires;
        private System.Windows.Forms.ColumnHeader colHeaderDiscount;
        private System.Windows.Forms.ColumnHeader colHeaderActive;
        private System.Windows.Forms.ColumnHeader colHeaderUses;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripMainAdd;
        private System.Windows.Forms.ToolStripButton toolStripMainDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripMainRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox toolStripMainTypes;
        private System.Windows.Forms.ContextMenuStrip contextMenuCoupons;
        private System.Windows.Forms.ToolStripButton toolStripMainEdit;
    }
}