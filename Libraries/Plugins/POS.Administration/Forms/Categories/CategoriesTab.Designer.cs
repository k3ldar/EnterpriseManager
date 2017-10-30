namespace POS.Administration.Forms.Categories
{
    partial class CategoriesTab
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
            this.components = new System.ComponentModel.Container();
            this.tabCategories = new System.Windows.Forms.TabControl();
            this.tabPageProductTypes = new System.Windows.Forms.TabPage();
            this.lvProductType = new SharedControls.Classes.ListViewEx();
            this.colProductTypeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductTypePrimary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.popupMenuProductType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabPageProductCostTypes = new System.Windows.Forms.TabPage();
            this.lvProductCostType = new SharedControls.Classes.ListViewEx();
            this.colProductItemTypeDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageProductGroupTypes = new System.Windows.Forms.TabPage();
            this.tabPageTicketDepartments = new System.Windows.Forms.TabPage();
            this.tabPageDownloadTypes = new System.Windows.Forms.TabPage();
            this.tabPageAppointmentGroups = new System.Windows.Forms.TabPage();
            this.popupMenuProductCostTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lvProductGroupType = new SharedControls.Classes.ListViewEx();
            this.colHeaderGroupName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvTicketDepartments = new SharedControls.Classes.ListViewEx();
            this.colTicketDepartmentsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvDownloadTypes = new SharedControls.Classes.ListViewEx();
            this.colDownloadTypeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvAppointmentGroups = new SharedControls.Classes.ListViewEx();
            this.colAppointGroupName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabCategories.SuspendLayout();
            this.tabPageProductTypes.SuspendLayout();
            this.tabPageProductCostTypes.SuspendLayout();
            this.tabPageProductGroupTypes.SuspendLayout();
            this.tabPageTicketDepartments.SuspendLayout();
            this.tabPageDownloadTypes.SuspendLayout();
            this.tabPageAppointmentGroups.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCategories
            // 
            this.tabCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCategories.Controls.Add(this.tabPageProductTypes);
            this.tabCategories.Controls.Add(this.tabPageProductCostTypes);
            this.tabCategories.Controls.Add(this.tabPageProductGroupTypes);
            this.tabCategories.Controls.Add(this.tabPageTicketDepartments);
            this.tabCategories.Controls.Add(this.tabPageDownloadTypes);
            this.tabCategories.Controls.Add(this.tabPageAppointmentGroups);
            this.tabCategories.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabCategories.Location = new System.Drawing.Point(3, 28);
            this.tabCategories.Multiline = true;
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.SelectedIndex = 0;
            this.tabCategories.Size = new System.Drawing.Size(659, 276);
            this.tabCategories.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabCategories.TabIndex = 1;
            this.tabCategories.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabCategories_DrawItem);
            this.tabCategories.SelectedIndexChanged += new System.EventHandler(this.tabCategories_SelectedIndexChanged);
            // 
            // tabPageProductTypes
            // 
            this.tabPageProductTypes.Controls.Add(this.lvProductType);
            this.tabPageProductTypes.Location = new System.Drawing.Point(4, 22);
            this.tabPageProductTypes.Name = "tabPageProductTypes";
            this.tabPageProductTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProductTypes.Size = new System.Drawing.Size(651, 250);
            this.tabPageProductTypes.TabIndex = 0;
            this.tabPageProductTypes.Text = "ProductTypes";
            this.tabPageProductTypes.UseVisualStyleBackColor = true;
            // 
            // lvProductType
            // 
            this.lvProductType.AllowColumnReorder = true;
            this.lvProductType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvProductType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProductTypeName,
            this.colProductTypePrimary});
            this.lvProductType.ContextMenuStrip = this.popupMenuProductType;
            this.lvProductType.FullRowSelect = true;
            this.lvProductType.Location = new System.Drawing.Point(7, 7);
            this.lvProductType.Name = "lvProductType";
            this.lvProductType.OwnerDraw = true;
            this.lvProductType.SaveName = "";
            this.lvProductType.ShowToolTip = false;
            this.lvProductType.Size = new System.Drawing.Size(638, 237);
            this.lvProductType.TabIndex = 0;
            this.lvProductType.UseCompatibleStateImageBehavior = false;
            this.lvProductType.View = System.Windows.Forms.View.Details;
            this.lvProductType.SelectedIndexChanged += new System.EventHandler(this.lvProductType_SelectedIndexChanged);
            this.lvProductType.DoubleClick += new System.EventHandler(this.lvProductType_DoubleClick);
            // 
            // colProductTypeName
            // 
            this.colProductTypeName.Text = "Name";
            this.colProductTypeName.Width = 335;
            // 
            // colProductTypePrimary
            // 
            this.colProductTypePrimary.Text = "Primary";
            this.colProductTypePrimary.Width = 100;
            // 
            // popupMenuProductType
            // 
            this.popupMenuProductType.Name = "popupMenuProductType";
            this.popupMenuProductType.Size = new System.Drawing.Size(61, 4);
            // 
            // tabPageProductCostTypes
            // 
            this.tabPageProductCostTypes.Controls.Add(this.lvProductCostType);
            this.tabPageProductCostTypes.Location = new System.Drawing.Point(4, 22);
            this.tabPageProductCostTypes.Name = "tabPageProductCostTypes";
            this.tabPageProductCostTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProductCostTypes.Size = new System.Drawing.Size(651, 250);
            this.tabPageProductCostTypes.TabIndex = 1;
            this.tabPageProductCostTypes.Text = "tabPage2";
            this.tabPageProductCostTypes.UseVisualStyleBackColor = true;
            // 
            // lvProductCostType
            // 
            this.lvProductCostType.AllowColumnReorder = true;
            this.lvProductCostType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvProductCostType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProductItemTypeDescription});
            this.lvProductCostType.ContextMenuStrip = this.popupMenuProductCostTypes;
            this.lvProductCostType.FullRowSelect = true;
            this.lvProductCostType.Location = new System.Drawing.Point(6, 7);
            this.lvProductCostType.Name = "lvProductCostType";
            this.lvProductCostType.OwnerDraw = true;
            this.lvProductCostType.SaveName = "";
            this.lvProductCostType.ShowToolTip = false;
            this.lvProductCostType.Size = new System.Drawing.Size(638, 237);
            this.lvProductCostType.TabIndex = 1;
            this.lvProductCostType.UseCompatibleStateImageBehavior = false;
            this.lvProductCostType.View = System.Windows.Forms.View.Details;
            this.lvProductCostType.SelectedIndexChanged += new System.EventHandler(this.lvProductCostType_SelectedIndexChanged);
            this.lvProductCostType.DoubleClick += new System.EventHandler(this.lvProductCostType_DoubleClick);
            // 
            // colProductItemTypeDescription
            // 
            this.colProductItemTypeDescription.Text = "Name";
            this.colProductItemTypeDescription.Width = 335;
            // 
            // tabPageProductGroupTypes
            // 
            this.tabPageProductGroupTypes.Controls.Add(this.lvProductGroupType);
            this.tabPageProductGroupTypes.Location = new System.Drawing.Point(4, 22);
            this.tabPageProductGroupTypes.Name = "tabPageProductGroupTypes";
            this.tabPageProductGroupTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProductGroupTypes.Size = new System.Drawing.Size(651, 250);
            this.tabPageProductGroupTypes.TabIndex = 2;
            this.tabPageProductGroupTypes.Text = "tabPage1";
            this.tabPageProductGroupTypes.UseVisualStyleBackColor = true;
            // 
            // tabPageTicketDepartments
            // 
            this.tabPageTicketDepartments.Controls.Add(this.lvTicketDepartments);
            this.tabPageTicketDepartments.Location = new System.Drawing.Point(4, 22);
            this.tabPageTicketDepartments.Name = "tabPageTicketDepartments";
            this.tabPageTicketDepartments.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTicketDepartments.Size = new System.Drawing.Size(651, 250);
            this.tabPageTicketDepartments.TabIndex = 3;
            this.tabPageTicketDepartments.Text = "tabPage1";
            this.tabPageTicketDepartments.UseVisualStyleBackColor = true;
            // 
            // tabPageDownloadTypes
            // 
            this.tabPageDownloadTypes.Controls.Add(this.lvDownloadTypes);
            this.tabPageDownloadTypes.Location = new System.Drawing.Point(4, 22);
            this.tabPageDownloadTypes.Name = "tabPageDownloadTypes";
            this.tabPageDownloadTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDownloadTypes.Size = new System.Drawing.Size(651, 250);
            this.tabPageDownloadTypes.TabIndex = 4;
            this.tabPageDownloadTypes.Text = "tabPage1";
            this.tabPageDownloadTypes.UseVisualStyleBackColor = true;
            // 
            // tabPageAppointmentGroups
            // 
            this.tabPageAppointmentGroups.Controls.Add(this.lvAppointmentGroups);
            this.tabPageAppointmentGroups.Location = new System.Drawing.Point(4, 22);
            this.tabPageAppointmentGroups.Name = "tabPageAppointmentGroups";
            this.tabPageAppointmentGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAppointmentGroups.Size = new System.Drawing.Size(651, 250);
            this.tabPageAppointmentGroups.TabIndex = 5;
            this.tabPageAppointmentGroups.Text = "tabPage1";
            this.tabPageAppointmentGroups.UseVisualStyleBackColor = true;
            // 
            // popupMenuProductCostTypes
            // 
            this.popupMenuProductCostTypes.Name = "popupMenuProductCostTypes";
            this.popupMenuProductCostTypes.Size = new System.Drawing.Size(61, 4);
            // 
            // lvProductGroupType
            // 
            this.lvProductGroupType.AllowColumnReorder = true;
            this.lvProductGroupType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvProductGroupType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderGroupName});
            this.lvProductGroupType.ContextMenuStrip = this.popupMenuProductCostTypes;
            this.lvProductGroupType.FullRowSelect = true;
            this.lvProductGroupType.Location = new System.Drawing.Point(6, 7);
            this.lvProductGroupType.Name = "lvProductGroupType";
            this.lvProductGroupType.OwnerDraw = true;
            this.lvProductGroupType.SaveName = "";
            this.lvProductGroupType.ShowToolTip = false;
            this.lvProductGroupType.Size = new System.Drawing.Size(638, 237);
            this.lvProductGroupType.TabIndex = 2;
            this.lvProductGroupType.UseCompatibleStateImageBehavior = false;
            this.lvProductGroupType.View = System.Windows.Forms.View.Details;
            this.lvProductGroupType.SelectedIndexChanged += new System.EventHandler(this.lvProductGroupType_SelectedIndexChanged);
            this.lvProductGroupType.DoubleClick += new System.EventHandler(this.lvProductGroupType_DoubleClick);
            // 
            // colHeaderGroupName
            // 
            this.colHeaderGroupName.Text = "Name";
            this.colHeaderGroupName.Width = 335;
            // 
            // lvTicketDepartments
            // 
            this.lvTicketDepartments.AllowColumnReorder = true;
            this.lvTicketDepartments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTicketDepartments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTicketDepartmentsName});
            this.lvTicketDepartments.ContextMenuStrip = this.popupMenuProductCostTypes;
            this.lvTicketDepartments.FullRowSelect = true;
            this.lvTicketDepartments.Location = new System.Drawing.Point(6, 7);
            this.lvTicketDepartments.Name = "lvTicketDepartments";
            this.lvTicketDepartments.OwnerDraw = true;
            this.lvTicketDepartments.SaveName = "";
            this.lvTicketDepartments.ShowToolTip = false;
            this.lvTicketDepartments.Size = new System.Drawing.Size(638, 237);
            this.lvTicketDepartments.TabIndex = 3;
            this.lvTicketDepartments.UseCompatibleStateImageBehavior = false;
            this.lvTicketDepartments.View = System.Windows.Forms.View.Details;
            this.lvTicketDepartments.SelectedIndexChanged += new System.EventHandler(this.lvTicketDepartmentsType_SelectedIndexChanged);
            this.lvTicketDepartments.DoubleClick += new System.EventHandler(this.lvTicketDepartments_DoubleClick);
            // 
            // colTicketDepartmentsName
            // 
            this.colTicketDepartmentsName.Text = "Name";
            this.colTicketDepartmentsName.Width = 335;
            // 
            // lvDownloadTypes
            // 
            this.lvDownloadTypes.AllowColumnReorder = true;
            this.lvDownloadTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDownloadTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDownloadTypeName});
            this.lvDownloadTypes.ContextMenuStrip = this.popupMenuProductCostTypes;
            this.lvDownloadTypes.FullRowSelect = true;
            this.lvDownloadTypes.Location = new System.Drawing.Point(6, 7);
            this.lvDownloadTypes.Name = "lvDownloadTypes";
            this.lvDownloadTypes.OwnerDraw = true;
            this.lvDownloadTypes.SaveName = "";
            this.lvDownloadTypes.ShowToolTip = false;
            this.lvDownloadTypes.Size = new System.Drawing.Size(638, 237);
            this.lvDownloadTypes.TabIndex = 4;
            this.lvDownloadTypes.UseCompatibleStateImageBehavior = false;
            this.lvDownloadTypes.View = System.Windows.Forms.View.Details;
            this.lvDownloadTypes.SelectedIndexChanged += new System.EventHandler(this.lvDownloadType_SelectedIndexChanged);
            this.lvDownloadTypes.DoubleClick += new System.EventHandler(this.lvDownloadType_DoubleClick);
            // 
            // colDownloadTypeName
            // 
            this.colDownloadTypeName.Text = "Name";
            this.colDownloadTypeName.Width = 335;
            // 
            // lvAppointmentGroups
            // 
            this.lvAppointmentGroups.AllowColumnReorder = true;
            this.lvAppointmentGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvAppointmentGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAppointGroupName});
            this.lvAppointmentGroups.ContextMenuStrip = this.popupMenuProductCostTypes;
            this.lvAppointmentGroups.FullRowSelect = true;
            this.lvAppointmentGroups.Location = new System.Drawing.Point(6, 7);
            this.lvAppointmentGroups.Name = "lvAppointmentGroups";
            this.lvAppointmentGroups.OwnerDraw = true;
            this.lvAppointmentGroups.SaveName = "";
            this.lvAppointmentGroups.ShowToolTip = false;
            this.lvAppointmentGroups.Size = new System.Drawing.Size(638, 237);
            this.lvAppointmentGroups.TabIndex = 4;
            this.lvAppointmentGroups.UseCompatibleStateImageBehavior = false;
            this.lvAppointmentGroups.View = System.Windows.Forms.View.Details;
            this.lvAppointmentGroups.SelectedIndexChanged += new System.EventHandler(this.lvAppointmentGroups_SelectedIndexChanged);
            this.lvAppointmentGroups.DoubleClick += new System.EventHandler(this.lvAppointmentGroups_DoubleClick);
            // 
            // colAppointGroupName
            // 
            this.colAppointGroupName.Text = "Name";
            this.colAppointGroupName.Width = 335;
            // 
            // CategoriesTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabCategories);
            this.Name = "CategoriesTab";
            this.Size = new System.Drawing.Size(665, 307);
            this.Controls.SetChildIndex(this.tabCategories, 0);
            this.tabCategories.ResumeLayout(false);
            this.tabPageProductTypes.ResumeLayout(false);
            this.tabPageProductCostTypes.ResumeLayout(false);
            this.tabPageProductGroupTypes.ResumeLayout(false);
            this.tabPageTicketDepartments.ResumeLayout(false);
            this.tabPageDownloadTypes.ResumeLayout(false);
            this.tabPageAppointmentGroups.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabCategories;
        private System.Windows.Forms.TabPage tabPageProductTypes;
        private System.Windows.Forms.TabPage tabPageProductCostTypes;
        private System.Windows.Forms.TabPage tabPageProductGroupTypes;
        private System.Windows.Forms.TabPage tabPageTicketDepartments;
        private System.Windows.Forms.TabPage tabPageDownloadTypes;
        private System.Windows.Forms.TabPage tabPageAppointmentGroups;
        private SharedControls.Classes.ListViewEx lvProductType;
        private System.Windows.Forms.ColumnHeader colProductTypeName;
        private System.Windows.Forms.ColumnHeader colProductTypePrimary;
        private System.Windows.Forms.ContextMenuStrip popupMenuProductType;
        private SharedControls.Classes.ListViewEx lvProductCostType;
        private System.Windows.Forms.ColumnHeader colProductItemTypeDescription;
        private System.Windows.Forms.ContextMenuStrip popupMenuProductCostTypes;
        private SharedControls.Classes.ListViewEx lvProductGroupType;
        private System.Windows.Forms.ColumnHeader colHeaderGroupName;
        private SharedControls.Classes.ListViewEx lvTicketDepartments;
        private System.Windows.Forms.ColumnHeader colTicketDepartmentsName;
        private SharedControls.Classes.ListViewEx lvDownloadTypes;
        private System.Windows.Forms.ColumnHeader colDownloadTypeName;
        private SharedControls.Classes.ListViewEx lvAppointmentGroups;
        private System.Windows.Forms.ColumnHeader colAppointGroupName;
    }
}
