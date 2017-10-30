namespace POS.Administration.Forms.Products
{
    partial class AdminSetTopProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminSetTopProducts));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripMainAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMainItemCount = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMainItemCount10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMainItemCount15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMainItemCount20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMainItemCount25 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMainItemCount30 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMainDays = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMainDays7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMainDays30 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMainRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMainSetTopProducts = new System.Windows.Forms.ToolStripButton();
            this.lvTopProducts = new SharedControls.Classes.ListViewEx();
            this.colHeaderSKU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMainAdd,
            this.toolStripMainDelete,
            this.toolStripMainEdit,
            this.toolStripSeparator1,
            this.toolStripMainItemCount,
            this.toolStripMainDays,
            this.toolStripSeparator2,
            this.toolStripMainRefresh,
            this.toolStripSeparator3,
            this.toolStripMainSetTopProducts});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(611, 25);
            this.toolStripMain.TabIndex = 5;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // toolStripMainAdd
            // 
            this.toolStripMainAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainAdd.Image")));
            this.toolStripMainAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainAdd.Name = "toolStripMainAdd";
            this.toolStripMainAdd.Size = new System.Drawing.Size(23, 22);
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
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripMainItemCount
            // 
            this.toolStripMainItemCount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainItemCount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMainItemCount10,
            this.toolStripMainItemCount15,
            this.toolStripMainItemCount20,
            this.toolStripMainItemCount25,
            this.toolStripMainItemCount30});
            this.toolStripMainItemCount.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainItemCount.Image")));
            this.toolStripMainItemCount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainItemCount.Name = "toolStripMainItemCount";
            this.toolStripMainItemCount.Size = new System.Drawing.Size(29, 22);
            this.toolStripMainItemCount.Text = "toolStripDropDownButton1";
            this.toolStripMainItemCount.DropDownOpening += new System.EventHandler(this.toolStripMainItemCount_DropDownOpening);
            // 
            // toolStripMainItemCount10
            // 
            this.toolStripMainItemCount10.Name = "toolStripMainItemCount10";
            this.toolStripMainItemCount10.Size = new System.Drawing.Size(86, 22);
            this.toolStripMainItemCount10.Text = "10";
            this.toolStripMainItemCount10.Click += new System.EventHandler(this.ToolStripCountClicked);
            // 
            // toolStripMainItemCount15
            // 
            this.toolStripMainItemCount15.Name = "toolStripMainItemCount15";
            this.toolStripMainItemCount15.Size = new System.Drawing.Size(86, 22);
            this.toolStripMainItemCount15.Text = "15";
            this.toolStripMainItemCount15.Click += new System.EventHandler(this.ToolStripCountClicked);
            // 
            // toolStripMainItemCount20
            // 
            this.toolStripMainItemCount20.Name = "toolStripMainItemCount20";
            this.toolStripMainItemCount20.Size = new System.Drawing.Size(86, 22);
            this.toolStripMainItemCount20.Text = "20";
            this.toolStripMainItemCount20.Click += new System.EventHandler(this.ToolStripCountClicked);
            // 
            // toolStripMainItemCount25
            // 
            this.toolStripMainItemCount25.Name = "toolStripMainItemCount25";
            this.toolStripMainItemCount25.Size = new System.Drawing.Size(86, 22);
            this.toolStripMainItemCount25.Text = "25";
            this.toolStripMainItemCount25.Click += new System.EventHandler(this.ToolStripCountClicked);
            // 
            // toolStripMainItemCount30
            // 
            this.toolStripMainItemCount30.Name = "toolStripMainItemCount30";
            this.toolStripMainItemCount30.Size = new System.Drawing.Size(86, 22);
            this.toolStripMainItemCount30.Text = "30";
            this.toolStripMainItemCount30.Click += new System.EventHandler(this.ToolStripCountClicked);
            // 
            // toolStripMainDays
            // 
            this.toolStripMainDays.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainDays.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMainDays7,
            this.toolStripMainDays30});
            this.toolStripMainDays.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainDays.Image")));
            this.toolStripMainDays.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainDays.Name = "toolStripMainDays";
            this.toolStripMainDays.Size = new System.Drawing.Size(29, 22);
            this.toolStripMainDays.Text = "toolStripDropDownButton1";
            this.toolStripMainDays.DropDownOpening += new System.EventHandler(this.toolStripMainDays_DropDownOpening);
            // 
            // toolStripMainDays7
            // 
            this.toolStripMainDays7.Name = "toolStripMainDays7";
            this.toolStripMainDays7.Size = new System.Drawing.Size(152, 22);
            this.toolStripMainDays7.Text = "7";
            this.toolStripMainDays7.Click += new System.EventHandler(this.ToolStripDaysClicked);
            // 
            // toolStripMainDays30
            // 
            this.toolStripMainDays30.Name = "toolStripMainDays30";
            this.toolStripMainDays30.Size = new System.Drawing.Size(152, 22);
            this.toolStripMainDays30.Text = "30";
            this.toolStripMainDays30.Click += new System.EventHandler(this.ToolStripDaysClicked);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripMainSetTopProducts
            // 
            this.toolStripMainSetTopProducts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainSetTopProducts.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainSetTopProducts.Image")));
            this.toolStripMainSetTopProducts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainSetTopProducts.Name = "toolStripMainSetTopProducts";
            this.toolStripMainSetTopProducts.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainSetTopProducts.Text = "toolStripMainSetValues";
            this.toolStripMainSetTopProducts.Click += new System.EventHandler(this.toolStripMainSetTopProducts_Click);
            // 
            // lvTopProducts
            // 
            this.lvTopProducts.AllowColumnReorder = true;
            this.lvTopProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTopProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderSKU,
            this.colHeaderName,
            this.colHeaderSize,
            this.colHeaderCount});
            this.lvTopProducts.FullRowSelect = true;
            this.lvTopProducts.Location = new System.Drawing.Point(0, 28);
            this.lvTopProducts.MinimumSize = new System.Drawing.Size(522, 196);
            this.lvTopProducts.Name = "lvTopProducts";
            this.lvTopProducts.OwnerDraw = true;
            this.lvTopProducts.SaveName = "SetTopProducts";
            this.lvTopProducts.ShowToolTip = false;
            this.lvTopProducts.Size = new System.Drawing.Size(611, 276);
            this.lvTopProducts.TabIndex = 4;
            this.lvTopProducts.UseCompatibleStateImageBehavior = false;
            this.lvTopProducts.View = System.Windows.Forms.View.Details;
            // 
            // colHeaderSKU
            // 
            this.colHeaderSKU.Text = "SKU";
            this.colHeaderSKU.Width = 73;
            // 
            // colHeaderName
            // 
            this.colHeaderName.Text = "Product";
            this.colHeaderName.Width = 211;
            // 
            // colHeaderSize
            // 
            this.colHeaderSize.Text = "Size";
            this.colHeaderSize.Width = 173;
            // 
            // colHeaderCount
            // 
            this.colHeaderCount.Text = "Count";
            this.colHeaderCount.Width = 50;
            // 
            // AdminSetTopProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 304);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.lvTopProducts);
            this.Name = "AdminSetTopProducts";
            this.Text = "AdminSetTopProducts";
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripMainAdd;
        private System.Windows.Forms.ToolStripButton toolStripMainDelete;
        private System.Windows.Forms.ToolStripButton toolStripMainEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripMainRefresh;
        private SharedControls.Classes.ListViewEx lvTopProducts;
        private System.Windows.Forms.ColumnHeader colHeaderName;
        private System.Windows.Forms.ColumnHeader colHeaderSize;
        private System.Windows.Forms.ColumnHeader colHeaderCount;
        private System.Windows.Forms.ColumnHeader colHeaderSKU;
        private System.Windows.Forms.ToolStripDropDownButton toolStripMainItemCount;
        private System.Windows.Forms.ToolStripMenuItem toolStripMainItemCount10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMainItemCount20;
        private System.Windows.Forms.ToolStripMenuItem toolStripMainItemCount30;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripMainDays;
        private System.Windows.Forms.ToolStripMenuItem toolStripMainDays7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMainDays30;
        private System.Windows.Forms.ToolStripButton toolStripMainSetTopProducts;
        private System.Windows.Forms.ToolStripMenuItem toolStripMainItemCount15;
        private System.Windows.Forms.ToolStripMenuItem toolStripMainItemCount25;
    }
}