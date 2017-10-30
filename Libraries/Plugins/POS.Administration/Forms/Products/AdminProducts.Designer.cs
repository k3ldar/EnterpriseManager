namespace POS.Administration.Forms.Products
{
    partial class AdminProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminProducts));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstProducts = new SharedControls.Classes.ListViewEx();
            this.colHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderPrimaryGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderSKU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderRegal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderShowOnWeb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripMainAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMainRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMainPrimaryProductType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMainProductGroups = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMainProductName = new System.Windows.Forms.ToolStripTextBox();
            this.statusStrip1.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 266);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(796, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabelCount.Text = "0 Products Found";
            // 
            // lstProducts
            // 
            this.lstProducts.AllowColumnReorder = true;
            this.lstProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderName,
            this.colHeaderPrimaryGroup,
            this.colHeaderSKU,
            this.colHeaderRegal,
            this.colHeaderShowOnWeb});
            this.lstProducts.ContextMenuStrip = this.contextMenuList;
            this.lstProducts.FullRowSelect = true;
            this.lstProducts.Location = new System.Drawing.Point(0, 28);
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.OwnerDraw = true;
            this.lstProducts.SaveName = "";
            this.lstProducts.ShowToolTip = false;
            this.lstProducts.Size = new System.Drawing.Size(790, 235);
            this.lstProducts.TabIndex = 7;
            this.lstProducts.UseCompatibleStateImageBehavior = false;
            this.lstProducts.View = System.Windows.Forms.View.Details;
            this.lstProducts.SelectedIndexChanged += new System.EventHandler(this.lstProducts_SelectedIndexChanged);
            this.lstProducts.DoubleClick += new System.EventHandler(this.lstProducts_DoubleClick);
            // 
            // colHeaderName
            // 
            this.colHeaderName.Text = "Name";
            this.colHeaderName.Width = 300;
            // 
            // colHeaderPrimaryGroup
            // 
            this.colHeaderPrimaryGroup.Text = "Primary Group";
            this.colHeaderPrimaryGroup.Width = 130;
            // 
            // colHeaderSKU
            // 
            this.colHeaderSKU.Text = "SKU";
            this.colHeaderSKU.Width = 100;
            // 
            // colHeaderRegal
            // 
            this.colHeaderRegal.Text = "Regal";
            this.colHeaderRegal.Width = 80;
            // 
            // colHeaderShowOnWeb
            // 
            this.colHeaderShowOnWeb.Text = "Show On Web";
            this.colHeaderShowOnWeb.Width = 100;
            // 
            // contextMenuList
            // 
            this.contextMenuList.Name = "contextMenuList";
            this.contextMenuList.Size = new System.Drawing.Size(61, 4);
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
            this.toolStripMainPrimaryProductType,
            this.toolStripSeparator3,
            this.toolStripMainProductGroups,
            this.toolStripSeparator4,
            this.toolStripMainProductName});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(796, 25);
            this.toolStripMain.TabIndex = 9;
            this.toolStripMain.Text = "toolStrip1";
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
            this.toolStripMainDelete.Click += new System.EventHandler(this.toolStripMainDelete_Click);
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
            // toolStripMainPrimaryProductType
            // 
            this.toolStripMainPrimaryProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripMainPrimaryProductType.DropDownWidth = 200;
            this.toolStripMainPrimaryProductType.Name = "toolStripMainPrimaryProductType";
            this.toolStripMainPrimaryProductType.Size = new System.Drawing.Size(130, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripMainProductGroups
            // 
            this.toolStripMainProductGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripMainProductGroups.DropDownWidth = 130;
            this.toolStripMainProductGroups.Name = "toolStripMainProductGroups";
            this.toolStripMainProductGroups.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripMainProductName
            // 
            this.toolStripMainProductName.Name = "toolStripMainProductName";
            this.toolStripMainProductName.Size = new System.Drawing.Size(150, 25);
            this.toolStripMainProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            // 
            // AdminProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 288);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lstProducts);
            this.MinimumSize = new System.Drawing.Size(812, 327);
            this.Name = "AdminProducts";
            this.Text = "Administration - Products";
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
        private SharedControls.Classes.ListViewEx lstProducts;
        private System.Windows.Forms.ColumnHeader colHeaderName;
        private System.Windows.Forms.ColumnHeader colHeaderSKU;
        private System.Windows.Forms.ColumnHeader colHeaderShowOnWeb;
        private System.Windows.Forms.ColumnHeader colHeaderRegal;
        private System.Windows.Forms.ColumnHeader colHeaderPrimaryGroup;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripMainAdd;
        private System.Windows.Forms.ToolStripButton toolStripMainDelete;
        private System.Windows.Forms.ToolStripButton toolStripMainEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripMainRefresh;
        private System.Windows.Forms.ContextMenuStrip contextMenuList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox toolStripMainPrimaryProductType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox toolStripMainProductGroups;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox toolStripMainProductName;
    }
}