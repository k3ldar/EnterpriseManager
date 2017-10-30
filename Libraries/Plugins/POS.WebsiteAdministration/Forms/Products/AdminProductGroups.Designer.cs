namespace POS.WebsiteAdministration.Forms.Products
{
    partial class AdminProductGroups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminProductGroups));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstProductGroups = new SharedControls.Classes.ListViewEx();
            this.colHeaderGroupName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderSortOrder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderPrimaryGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripMainAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMainRefresh = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 303);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(571, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabelCount.Text = "0 Products Found";
            // 
            // lstProductGroups
            // 
            this.lstProductGroups.AllowColumnReorder = true;
            this.lstProductGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstProductGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderGroupName,
            this.colHeaderSortOrder,
            this.colHeaderPrimaryGroup});
            this.lstProductGroups.ContextMenuStrip = this.contextMenuList;
            this.lstProductGroups.FullRowSelect = true;
            this.lstProductGroups.Location = new System.Drawing.Point(0, 28);
            this.lstProductGroups.Name = "lstProductGroups";
            this.lstProductGroups.OwnerDraw = true;
            this.lstProductGroups.SaveName = "";
            this.lstProductGroups.ShowToolTip = false;
            this.lstProductGroups.Size = new System.Drawing.Size(571, 272);
            this.lstProductGroups.TabIndex = 1;
            this.lstProductGroups.UseCompatibleStateImageBehavior = false;
            this.lstProductGroups.View = System.Windows.Forms.View.Details;
            this.lstProductGroups.SelectedIndexChanged += new System.EventHandler(this.lstProductGroups_SelectedIndexChanged);
            this.lstProductGroups.DoubleClick += new System.EventHandler(this.lstProductGroups_DoubleClick);
            // 
            // colHeaderGroupName
            // 
            this.colHeaderGroupName.Text = "Group Name";
            this.colHeaderGroupName.Width = 300;
            // 
            // colHeaderSortOrder
            // 
            this.colHeaderSortOrder.Text = "Sort Order";
            this.colHeaderSortOrder.Width = 81;
            // 
            // colHeaderPrimaryGroup
            // 
            this.colHeaderPrimaryGroup.Text = "Primary Group Type";
            this.colHeaderPrimaryGroup.Width = 125;
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
            this.toolStripMainRefresh});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(571, 25);
            this.toolStripMain.TabIndex = 4;
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
            // AdminProductGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 325);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lstProductGroups);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminProductGroups";
            this.SaveState = true;
            this.ShowIcon = false;
            this.Text = "Admin Product Groups";
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
        private SharedControls.Classes.ListViewEx lstProductGroups;
        private System.Windows.Forms.ColumnHeader colHeaderGroupName;
        private System.Windows.Forms.ColumnHeader colHeaderSortOrder;
        private System.Windows.Forms.ColumnHeader colHeaderPrimaryGroup;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripMainAdd;
        private System.Windows.Forms.ToolStripButton toolStripMainDelete;
        private System.Windows.Forms.ToolStripButton toolStripMainEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripMainRefresh;
        private System.Windows.Forms.ContextMenuStrip contextMenuList;
    }
}