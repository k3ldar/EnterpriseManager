namespace POS.AutoUpdate.Forms
{
    partial class AutoUpdatesForm
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
            this.lvAutoUpdateItems = new SharedControls.Classes.ListViewEx();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRunDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRun = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCreatedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCreatedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvAutoUpdateItems
            // 
            this.lvAutoUpdateItems.AllowColumnReorder = true;
            this.lvAutoUpdateItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvAutoUpdateItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderRunDate,
            this.columnHeaderRun,
            this.columnHeaderCreatedBy,
            this.columnHeaderCreatedDate});
            this.lvAutoUpdateItems.FullRowSelect = true;
            this.lvAutoUpdateItems.HideSelection = false;
            this.lvAutoUpdateItems.Location = new System.Drawing.Point(3, 28);
            this.lvAutoUpdateItems.Name = "lvAutoUpdateItems";
            this.lvAutoUpdateItems.OwnerDraw = true;
            this.lvAutoUpdateItems.SaveName = "AutoUpdates";
            this.lvAutoUpdateItems.ShowToolTip = false;
            this.lvAutoUpdateItems.Size = new System.Drawing.Size(766, 230);
            this.lvAutoUpdateItems.TabIndex = 14;
            this.lvAutoUpdateItems.UseCompatibleStateImageBehavior = false;
            this.lvAutoUpdateItems.View = System.Windows.Forms.View.Details;
            this.lvAutoUpdateItems.SelectedIndexChanged += new System.EventHandler(this.lvAutoUpdateItems_SelectedIndexChanged);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Width = 209;
            // 
            // columnHeaderRunDate
            // 
            this.columnHeaderRunDate.Width = 150;
            // 
            // columnHeaderRun
            // 
            this.columnHeaderRun.Width = 82;
            // 
            // columnHeaderCreatedBy
            // 
            this.columnHeaderCreatedBy.Width = 145;
            // 
            // columnHeaderCreatedDate
            // 
            this.columnHeaderCreatedDate.Width = 157;
            // 
            // AutoUpdatesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvAutoUpdateItems);
            this.Name = "AutoUpdatesForm";
            this.Size = new System.Drawing.Size(772, 261);
            this.Controls.SetChildIndex(this.lvAutoUpdateItems, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharedControls.Classes.ListViewEx lvAutoUpdateItems;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderRunDate;
        private System.Windows.Forms.ColumnHeader columnHeaderRun;
        private System.Windows.Forms.ColumnHeader columnHeaderCreatedBy;
        private System.Windows.Forms.ColumnHeader columnHeaderCreatedDate;
    }
}