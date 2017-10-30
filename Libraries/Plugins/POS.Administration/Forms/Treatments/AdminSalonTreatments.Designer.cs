namespace POS.Administration.Forms.Treatments
{
    partial class AdminSalonTreatments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminSalonTreatments));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstTreatments = new SharedControls.Classes.ListViewEx();
            this.colHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripMainAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMainRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMainFilterLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripMainFilterText = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMainSearch = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 287);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(719, 22);
            this.statusStrip1.TabIndex = 38;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(112, 17);
            this.toolStripStatusLabelCount.Text = "0 Treatments Found";
            // 
            // lstTreatments
            // 
            this.lstTreatments.AllowColumnReorder = true;
            this.lstTreatments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTreatments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderName,
            this.colHeaderPrice,
            this.colHeaderCost,
            this.colHeaderLength,
            this.colHeaderActive});
            this.lstTreatments.ContextMenuStrip = this.contextMenuList;
            this.lstTreatments.FullRowSelect = true;
            this.lstTreatments.Location = new System.Drawing.Point(0, 28);
            this.lstTreatments.MultiSelect = false;
            this.lstTreatments.Name = "lstTreatments";
            this.lstTreatments.OwnerDraw = true;
            this.lstTreatments.SaveName = "";
            this.lstTreatments.ShowToolTip = false;
            this.lstTreatments.Size = new System.Drawing.Size(719, 256);
            this.lstTreatments.TabIndex = 37;
            this.lstTreatments.UseCompatibleStateImageBehavior = false;
            this.lstTreatments.View = System.Windows.Forms.View.Details;
            this.lstTreatments.SelectedIndexChanged += new System.EventHandler(this.lstTreatments_SelectedIndexChanged);
            this.lstTreatments.DoubleClick += new System.EventHandler(this.lstTreatments_DoubleClick);
            // 
            // colHeaderName
            // 
            this.colHeaderName.Text = "Name";
            this.colHeaderName.Width = 400;
            // 
            // colHeaderPrice
            // 
            this.colHeaderPrice.Text = "Price";
            // 
            // colHeaderCost
            // 
            this.colHeaderCost.Text = "Cost";
            // 
            // colHeaderLength
            // 
            this.colHeaderLength.Text = "Length";
            this.colHeaderLength.Width = 178;
            // 
            // colHeaderActive
            // 
            this.colHeaderActive.Text = "Active";
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
            this.toolStripMainFilterLabel,
            this.toolStripMainFilterText,
            this.toolStripMainSearch});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(719, 25);
            this.toolStripMain.TabIndex = 42;
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
            // toolStripMainFilterLabel
            // 
            this.toolStripMainFilterLabel.Name = "toolStripMainFilterLabel";
            this.toolStripMainFilterLabel.Size = new System.Drawing.Size(86, 22);
            this.toolStripMainFilterLabel.Text = "toolStripLabel1";
            // 
            // toolStripMainFilterText
            // 
            this.toolStripMainFilterText.Name = "toolStripMainFilterText";
            this.toolStripMainFilterText.Size = new System.Drawing.Size(150, 25);
            this.toolStripMainFilterText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // toolStripMainSearch
            // 
            this.toolStripMainSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainSearch.Image")));
            this.toolStripMainSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainSearch.Name = "toolStripMainSearch";
            this.toolStripMainSearch.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainSearch.Text = "toolStripButton1";
            this.toolStripMainSearch.Click += new System.EventHandler(this.toolStripMainSearch_Click);
            // 
            // AdminSalonTreatments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lstTreatments);
            this.Name = "AdminSalonTreatments";
            this.Size = new System.Drawing.Size(719, 309);
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
        private SharedControls.Classes.ListViewEx lstTreatments;
        private System.Windows.Forms.ColumnHeader colHeaderName;
        private System.Windows.Forms.ColumnHeader colHeaderCost;
        private System.Windows.Forms.ColumnHeader colHeaderLength;
        private System.Windows.Forms.ColumnHeader colHeaderActive;
        private System.Windows.Forms.ColumnHeader colHeaderPrice;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripMainAdd;
        private System.Windows.Forms.ToolStripButton toolStripMainDelete;
        private System.Windows.Forms.ToolStripButton toolStripMainEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripMainRefresh;
        private System.Windows.Forms.ContextMenuStrip contextMenuList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripMainFilterLabel;
        private System.Windows.Forms.ToolStripTextBox toolStripMainFilterText;
        private System.Windows.Forms.ToolStripButton toolStripMainSearch;
    }
}