namespace POS.Staff.Forms
{
    partial class ViewLeave
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
            this.contextMenuOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuOptionsApprove = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuOptionsAuthorise = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuOptionsCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuOptionsDeny = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSummary = new System.Windows.Forms.Label();
            this.lvLeaveRequests = new SharedControls.Classes.ListViewEx();
            this.colStaffMember = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colApproved = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAuthorised = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateRequested = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuOptions
            // 
            this.contextMenuOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuOptionsApprove,
            this.contextMenuOptionsAuthorise,
            this.toolStripMenuItem1,
            this.contextMenuOptionsCancel,
            this.contextMenuOptionsDeny});
            this.contextMenuOptions.Name = "contextMenuOptions";
            this.contextMenuOptions.Size = new System.Drawing.Size(153, 120);
            this.contextMenuOptions.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuOptions_Opening);
            // 
            // contextMenuOptionsApprove
            // 
            this.contextMenuOptionsApprove.Name = "contextMenuOptionsApprove";
            this.contextMenuOptionsApprove.Size = new System.Drawing.Size(152, 22);
            this.contextMenuOptionsApprove.Text = "Approve";
            this.contextMenuOptionsApprove.Click += new System.EventHandler(this.contextMenuOptionsApprove_Click);
            // 
            // contextMenuOptionsAuthorise
            // 
            this.contextMenuOptionsAuthorise.Name = "contextMenuOptionsAuthorise";
            this.contextMenuOptionsAuthorise.Size = new System.Drawing.Size(152, 22);
            this.contextMenuOptionsAuthorise.Text = "Authorise";
            this.contextMenuOptionsAuthorise.Click += new System.EventHandler(this.contextMenuOptionsAuthorise_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // contextMenuOptionsCancel
            // 
            this.contextMenuOptionsCancel.Name = "contextMenuOptionsCancel";
            this.contextMenuOptionsCancel.Size = new System.Drawing.Size(152, 22);
            this.contextMenuOptionsCancel.Text = "Cancel";
            this.contextMenuOptionsCancel.Click += new System.EventHandler(this.contextMenuOptionsCancel_Click);
            // 
            // contextMenuOptionsDeny
            // 
            this.contextMenuOptionsDeny.Name = "contextMenuOptionsDeny";
            this.contextMenuOptionsDeny.Size = new System.Drawing.Size(152, 22);
            this.contextMenuOptionsDeny.Text = "Deny";
            this.contextMenuOptionsDeny.Click += new System.EventHandler(this.contextMenuOptionsDeny_Click);
            // 
            // lblSummary
            // 
            this.lblSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(-3, 310);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(50, 13);
            this.lblSummary.TabIndex = 17;
            this.lblSummary.Text = "Summary";
            // 
            // lvLeaveRequests
            // 
            this.lvLeaveRequests.AllowColumnReorder = true;
            this.lvLeaveRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLeaveRequests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colStaffMember,
            this.colFrom,
            this.colTo,
            this.colTotal,
            this.colApproved,
            this.colAuthorised,
            this.colDateRequested});
            this.lvLeaveRequests.ContextMenuStrip = this.contextMenuOptions;
            this.lvLeaveRequests.FullRowSelect = true;
            this.lvLeaveRequests.Location = new System.Drawing.Point(3, 28);
            this.lvLeaveRequests.Name = "lvLeaveRequests";
            this.lvLeaveRequests.OwnerDraw = true;
            this.lvLeaveRequests.SaveName = "";
            this.lvLeaveRequests.ShowToolTip = true;
            this.lvLeaveRequests.Size = new System.Drawing.Size(607, 265);
            this.lvLeaveRequests.TabIndex = 16;
            this.lvLeaveRequests.UseCompatibleStateImageBehavior = false;
            this.lvLeaveRequests.View = System.Windows.Forms.View.Details;
            // 
            // colStaffMember
            // 
            this.colStaffMember.Text = "Staff";
            this.colStaffMember.Width = 120;
            // 
            // colFrom
            // 
            this.colFrom.Text = "From";
            this.colFrom.Width = 130;
            // 
            // colTo
            // 
            this.colTo.Text = "To";
            this.colTo.Width = 130;
            // 
            // colTotal
            // 
            this.colTotal.Text = "Total";
            this.colTotal.Width = 90;
            // 
            // colApproved
            // 
            this.colApproved.Text = "Approved";
            // 
            // colAuthorised
            // 
            this.colAuthorised.Text = "Authorised";
            // 
            // colDateRequested
            // 
            this.colDateRequested.Width = 120;
            // 
            // ViewLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.lvLeaveRequests);
            this.Name = "ViewLeave";
            this.Size = new System.Drawing.Size(613, 334);
            this.Controls.SetChildIndex(this.lvLeaveRequests, 0);
            this.Controls.SetChildIndex(this.lblSummary, 0);
            this.contextMenuOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuOptions;
        private System.Windows.Forms.ToolStripMenuItem contextMenuOptionsApprove;
        private System.Windows.Forms.ToolStripMenuItem contextMenuOptionsAuthorise;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem contextMenuOptionsCancel;
        private System.Windows.Forms.ToolStripMenuItem contextMenuOptionsDeny;
        private System.Windows.Forms.Label lblSummary;
        private SharedControls.Classes.ListViewEx lvLeaveRequests;
        private System.Windows.Forms.ColumnHeader colStaffMember;
        private System.Windows.Forms.ColumnHeader colFrom;
        private System.Windows.Forms.ColumnHeader colTo;
        private System.Windows.Forms.ColumnHeader colTotal;
        private System.Windows.Forms.ColumnHeader colApproved;
        private System.Windows.Forms.ColumnHeader colAuthorised;
        private System.Windows.Forms.ColumnHeader colDateRequested;
    }
}