namespace POS.Staff.Controls
{
    partial class LeaveRequests
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
            this.grpLeaveRequests = new System.Windows.Forms.GroupBox();
            this.lblSummary = new System.Windows.Forms.Label();
            this.lvLeaveRequests = new SharedControls.Classes.ListViewEx();
            this.colStaffMember = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colApproved = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAuthorised = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuOptionsApprove = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuOptionsAuthorise = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuOptionsCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuOptionsDeny = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbLeaveYear = new System.Windows.Forms.ComboBox();
            this.lblLeaveYear = new System.Windows.Forms.Label();
            this.grpLeaveRequests.SuspendLayout();
            this.contextMenuOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLeaveRequests
            // 
            this.grpLeaveRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLeaveRequests.Controls.Add(this.lblSummary);
            this.grpLeaveRequests.Controls.Add(this.lvLeaveRequests);
            this.grpLeaveRequests.Controls.Add(this.cmbLeaveYear);
            this.grpLeaveRequests.Controls.Add(this.lblLeaveYear);
            this.grpLeaveRequests.Location = new System.Drawing.Point(3, 3);
            this.grpLeaveRequests.Name = "grpLeaveRequests";
            this.grpLeaveRequests.Size = new System.Drawing.Size(455, 233);
            this.grpLeaveRequests.TabIndex = 7;
            this.grpLeaveRequests.TabStop = false;
            this.grpLeaveRequests.Text = "Leave Requests";
            // 
            // lblSummary
            // 
            this.lblSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(6, 213);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(50, 13);
            this.lblSummary.TabIndex = 3;
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
            this.colAuthorised});
            this.lvLeaveRequests.ContextMenuStrip = this.contextMenuOptions;
            this.lvLeaveRequests.FullRowSelect = true;
            this.lvLeaveRequests.Location = new System.Drawing.Point(9, 47);
            this.lvLeaveRequests.Name = "lvLeaveRequests";
            this.lvLeaveRequests.OwnerDraw = true;
            this.lvLeaveRequests.SaveName = "";
            this.lvLeaveRequests.ShowToolTip = true;
            this.lvLeaveRequests.Size = new System.Drawing.Size(435, 147);
            this.lvLeaveRequests.TabIndex = 2;
            this.lvLeaveRequests.UseCompatibleStateImageBehavior = false;
            this.lvLeaveRequests.View = System.Windows.Forms.View.Details;
            this.lvLeaveRequests.ToolTipShow += new Shared.ToolTipEventHandler(this.lvLeaveRequests_ToolTipShow);
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
            // contextMenuOptions
            // 
            this.contextMenuOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuOptionsApprove,
            this.contextMenuOptionsAuthorise,
            this.toolStripMenuItem1,
            this.contextMenuOptionsCancel,
            this.contextMenuOptionsDeny});
            this.contextMenuOptions.Name = "contextMenuOptions";
            this.contextMenuOptions.Size = new System.Drawing.Size(126, 98);
            this.contextMenuOptions.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuOptions_Opening);
            // 
            // contextMenuOptionsApprove
            // 
            this.contextMenuOptionsApprove.Name = "contextMenuOptionsApprove";
            this.contextMenuOptionsApprove.Size = new System.Drawing.Size(125, 22);
            this.contextMenuOptionsApprove.Text = "Approve";
            this.contextMenuOptionsApprove.Click += new System.EventHandler(this.contextMenuOptionsApprove_Click);
            // 
            // contextMenuOptionsAuthorise
            // 
            this.contextMenuOptionsAuthorise.Name = "contextMenuOptionsAuthorise";
            this.contextMenuOptionsAuthorise.Size = new System.Drawing.Size(125, 22);
            this.contextMenuOptionsAuthorise.Text = "Authorise";
            this.contextMenuOptionsAuthorise.Click += new System.EventHandler(this.contextMenuOptionsAuthorise_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 6);
            // 
            // contextMenuOptionsCancel
            // 
            this.contextMenuOptionsCancel.Name = "contextMenuOptionsCancel";
            this.contextMenuOptionsCancel.Size = new System.Drawing.Size(125, 22);
            this.contextMenuOptionsCancel.Text = "Cancel";
            this.contextMenuOptionsCancel.Click += new System.EventHandler(this.contextMenuOptionsCancel_Click);
            // 
            // contextMenuOptionsDeny
            // 
            this.contextMenuOptionsDeny.Name = "contextMenuOptionsDeny";
            this.contextMenuOptionsDeny.Size = new System.Drawing.Size(125, 22);
            this.contextMenuOptionsDeny.Text = "Deny";
            this.contextMenuOptionsDeny.Click += new System.EventHandler(this.contextMenuOptionsDeny_Click);
            // 
            // cmbLeaveYear
            // 
            this.cmbLeaveYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeaveYear.FormattingEnabled = true;
            this.cmbLeaveYear.Location = new System.Drawing.Point(124, 20);
            this.cmbLeaveYear.Name = "cmbLeaveYear";
            this.cmbLeaveYear.Size = new System.Drawing.Size(205, 21);
            this.cmbLeaveYear.TabIndex = 1;
            this.cmbLeaveYear.SelectedIndexChanged += new System.EventHandler(this.cmbLeaveYear_SelectedIndexChanged);
            this.cmbLeaveYear.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbLeaveYear_Format);
            // 
            // lblLeaveYear
            // 
            this.lblLeaveYear.AutoSize = true;
            this.lblLeaveYear.Location = new System.Drawing.Point(6, 23);
            this.lblLeaveYear.Name = "lblLeaveYear";
            this.lblLeaveYear.Size = new System.Drawing.Size(62, 13);
            this.lblLeaveYear.TabIndex = 0;
            this.lblLeaveYear.Text = "Leave Year";
            // 
            // LeaveRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpLeaveRequests);
            this.MinimumSize = new System.Drawing.Size(347, 240);
            this.Name = "LeaveRequests";
            this.Size = new System.Drawing.Size(462, 240);
            this.grpLeaveRequests.ResumeLayout(false);
            this.grpLeaveRequests.PerformLayout();
            this.contextMenuOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLeaveRequests;
        private SharedControls.Classes.ListViewEx lvLeaveRequests;
        private System.Windows.Forms.ComboBox cmbLeaveYear;
        private System.Windows.Forms.Label lblLeaveYear;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.ColumnHeader colFrom;
        private System.Windows.Forms.ColumnHeader colTo;
        private System.Windows.Forms.ColumnHeader colTotal;
        private System.Windows.Forms.ColumnHeader colApproved;
        private System.Windows.Forms.ColumnHeader colAuthorised;
        private System.Windows.Forms.ContextMenuStrip contextMenuOptions;
        private System.Windows.Forms.ToolStripMenuItem contextMenuOptionsAuthorise;
        private System.Windows.Forms.ToolStripMenuItem contextMenuOptionsApprove;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem contextMenuOptionsCancel;
        private System.Windows.Forms.ToolStripMenuItem contextMenuOptionsDeny;
        private System.Windows.Forms.ColumnHeader colStaffMember;
    }
}
