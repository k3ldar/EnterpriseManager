namespace POS.Staff.Forms
{
    partial class StaffExpensesControl
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
            this.lvExpenses = new SharedControls.Classes.ListViewEx();
            this.lvExpensesColDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvExpensesColStaffMember = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvExpensesColAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvExpensesColType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvExpensesColQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvExpensesColReceipt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvExpensesColStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvExpensesColApprovedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvExpensesColApprovedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvExpensesColReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pumExpenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pumExpensesNew = new System.Windows.Forms.ToolStripMenuItem();
            this.pumExpensesEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.pumExpensesViewReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.pumExpensesApprove = new System.Windows.Forms.ToolStripMenuItem();
            this.pumExpensesDecline = new System.Windows.Forms.ToolStripMenuItem();
            this.lvExpensesColTaxPaid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pumExpenses.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvExpenses
            // 
            this.lvExpenses.AllowColumnReorder = true;
            this.lvExpenses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvExpenses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvExpensesColDate,
            this.lvExpensesColStaffMember,
            this.lvExpensesColAmount,
            this.lvExpensesColType,
            this.lvExpensesColQuantity,
            this.lvExpensesColReceipt,
            this.lvExpensesColStatus,
            this.lvExpensesColApprovedBy,
            this.lvExpensesColApprovedDate,
            this.lvExpensesColReason,
            this.lvExpensesColTaxPaid});
            this.lvExpenses.ContextMenuStrip = this.pumExpenses;
            this.lvExpenses.FullRowSelect = true;
            this.lvExpenses.HideSelection = false;
            this.lvExpenses.Location = new System.Drawing.Point(3, 28);
            this.lvExpenses.Name = "lvExpenses";
            this.lvExpenses.OwnerDraw = true;
            this.lvExpenses.SaveName = "";
            this.lvExpenses.ShowToolTip = false;
            this.lvExpenses.Size = new System.Drawing.Size(838, 172);
            this.lvExpenses.TabIndex = 15;
            this.lvExpenses.UseCompatibleStateImageBehavior = false;
            this.lvExpenses.View = System.Windows.Forms.View.Details;
            this.lvExpenses.SelectedIndexChanged += new System.EventHandler(this.lvExpenses_SelectedIndexChanged);
            // 
            // lvExpensesColDate
            // 
            this.lvExpensesColDate.Text = "Date";
            this.lvExpensesColDate.Width = 130;
            // 
            // lvExpensesColStaffMember
            // 
            this.lvExpensesColStaffMember.Text = "Staff Member";
            this.lvExpensesColStaffMember.Width = 180;
            // 
            // lvExpensesColAmount
            // 
            this.lvExpensesColAmount.Text = "Amount";
            this.lvExpensesColAmount.Width = 100;
            // 
            // lvExpensesColType
            // 
            this.lvExpensesColType.Text = "Type";
            this.lvExpensesColType.Width = 120;
            // 
            // lvExpensesColQuantity
            // 
            this.lvExpensesColQuantity.Text = "Quantity";
            this.lvExpensesColQuantity.Width = 90;
            // 
            // lvExpensesColReceipt
            // 
            this.lvExpensesColReceipt.Text = "Receipt";
            this.lvExpensesColReceipt.Width = 80;
            // 
            // lvExpensesColStatus
            // 
            this.lvExpensesColStatus.Text = "Status";
            this.lvExpensesColStatus.Width = 90;
            // 
            // lvExpensesColApprovedBy
            // 
            this.lvExpensesColApprovedBy.Width = 180;
            // 
            // lvExpensesColApprovedDate
            // 
            this.lvExpensesColApprovedDate.Width = 130;
            // 
            // lvExpensesColReason
            // 
            this.lvExpensesColReason.Width = 200;
            // 
            // pumExpenses
            // 
            this.pumExpenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pumExpensesNew,
            this.pumExpensesEdit,
            this.toolStripMenuItem1,
            this.pumExpensesViewReceipt,
            this.toolStripMenuItem2,
            this.pumExpensesApprove,
            this.pumExpensesDecline});
            this.pumExpenses.Name = "pumExpenses";
            this.pumExpenses.Size = new System.Drawing.Size(142, 126);
            this.pumExpenses.Opening += new System.ComponentModel.CancelEventHandler(this.pumExpenses_Opening);
            // 
            // pumExpensesNew
            // 
            this.pumExpensesNew.Name = "pumExpensesNew";
            this.pumExpensesNew.Size = new System.Drawing.Size(141, 22);
            this.pumExpensesNew.Text = "New";
            this.pumExpensesNew.Click += new System.EventHandler(this.pumExpensesNew_Click);
            // 
            // pumExpensesEdit
            // 
            this.pumExpensesEdit.Name = "pumExpensesEdit";
            this.pumExpensesEdit.Size = new System.Drawing.Size(141, 22);
            this.pumExpensesEdit.Text = "Edit";
            this.pumExpensesEdit.Click += new System.EventHandler(this.pumExpensesEdit_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(138, 6);
            // 
            // pumExpensesViewReceipt
            // 
            this.pumExpensesViewReceipt.Name = "pumExpensesViewReceipt";
            this.pumExpensesViewReceipt.Size = new System.Drawing.Size(141, 22);
            this.pumExpensesViewReceipt.Text = "View Receipt";
            this.pumExpensesViewReceipt.Click += new System.EventHandler(this.pumExpensesViewReceipt_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(138, 6);
            // 
            // pumExpensesApprove
            // 
            this.pumExpensesApprove.Name = "pumExpensesApprove";
            this.pumExpensesApprove.Size = new System.Drawing.Size(141, 22);
            this.pumExpensesApprove.Text = "Approve";
            this.pumExpensesApprove.Click += new System.EventHandler(this.pumExpensesApprove_Click);
            // 
            // pumExpensesDecline
            // 
            this.pumExpensesDecline.Name = "pumExpensesDecline";
            this.pumExpensesDecline.Size = new System.Drawing.Size(141, 22);
            this.pumExpensesDecline.Text = "Decline";
            this.pumExpensesDecline.Click += new System.EventHandler(this.pumExpensesDecline_Click);
            // 
            // StaffExpensesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvExpenses);
            this.Name = "StaffExpensesControl";
            this.Size = new System.Drawing.Size(844, 203);
            this.Controls.SetChildIndex(this.lvExpenses, 0);
            this.pumExpenses.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharedControls.Classes.ListViewEx lvExpenses;
        private System.Windows.Forms.ColumnHeader lvExpensesColDate;
        private System.Windows.Forms.ColumnHeader lvExpensesColStaffMember;
        private System.Windows.Forms.ColumnHeader lvExpensesColAmount;
        private System.Windows.Forms.ColumnHeader lvExpensesColType;
        private System.Windows.Forms.ColumnHeader lvExpensesColQuantity;
        private System.Windows.Forms.ColumnHeader lvExpensesColReceipt;
        private System.Windows.Forms.ColumnHeader lvExpensesColStatus;
        private System.Windows.Forms.ContextMenuStrip pumExpenses;
        private System.Windows.Forms.ToolStripMenuItem pumExpensesNew;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pumExpensesViewReceipt;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem pumExpensesApprove;
        private System.Windows.Forms.ToolStripMenuItem pumExpensesDecline;
        private System.Windows.Forms.ColumnHeader lvExpensesColApprovedBy;
        private System.Windows.Forms.ColumnHeader lvExpensesColApprovedDate;
        private System.Windows.Forms.ColumnHeader lvExpensesColReason;
        private System.Windows.Forms.ToolStripMenuItem pumExpensesEdit;
        private System.Windows.Forms.ColumnHeader lvExpensesColTaxPaid;
    }
}
