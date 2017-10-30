namespace POS.HelpDesk.Forms
{
    partial class Tickets
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rbClosed = new System.Windows.Forms.RadioButton();
            this.rbOnHold = new System.Windows.Forms.RadioButton();
            this.rbOpen = new System.Windows.Forms.RadioButton();
            this.lstTickets = new SharedControls.Classes.ListViewEx();
            this.colHeaderKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderDepartment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderReplies = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderLastUpdated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderLastUpdatedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblFindTicket = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 287);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1010, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(90, 17);
            this.toolStripStatusLabelCount.Text = "0 Tickets Found";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(925, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rbClosed
            // 
            this.rbClosed.AutoSize = true;
            this.rbClosed.Location = new System.Drawing.Point(174, 8);
            this.rbClosed.Name = "rbClosed";
            this.rbClosed.Size = new System.Drawing.Size(57, 17);
            this.rbClosed.TabIndex = 10;
            this.rbClosed.TabStop = true;
            this.rbClosed.Text = "Closed";
            this.rbClosed.UseVisualStyleBackColor = true;
            // 
            // rbOnHold
            // 
            this.rbOnHold.AutoSize = true;
            this.rbOnHold.Location = new System.Drawing.Point(84, 8);
            this.rbOnHold.Name = "rbOnHold";
            this.rbOnHold.Size = new System.Drawing.Size(64, 17);
            this.rbOnHold.TabIndex = 9;
            this.rbOnHold.TabStop = true;
            this.rbOnHold.Text = "On Hold";
            this.rbOnHold.UseVisualStyleBackColor = true;
            // 
            // rbOpen
            // 
            this.rbOpen.AutoSize = true;
            this.rbOpen.Checked = true;
            this.rbOpen.Location = new System.Drawing.Point(13, 8);
            this.rbOpen.Name = "rbOpen";
            this.rbOpen.Size = new System.Drawing.Size(51, 17);
            this.rbOpen.TabIndex = 8;
            this.rbOpen.TabStop = true;
            this.rbOpen.Text = "Open";
            this.rbOpen.UseVisualStyleBackColor = true;
            // 
            // lstTickets
            // 
            this.lstTickets.AllowColumnReorder = true;
            this.lstTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTickets.CausesValidation = false;
            this.lstTickets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderKey,
            this.colHeaderDepartment,
            this.colHeaderUser,
            this.colHeaderTitle,
            this.colHeaderReplies,
            this.colHeaderLastUpdated,
            this.colHeaderLastUpdatedBy});
            this.lstTickets.FullRowSelect = true;
            this.lstTickets.Location = new System.Drawing.Point(0, 40);
            this.lstTickets.Name = "lstTickets";
            this.lstTickets.OwnerDraw = true;
            this.lstTickets.SaveName = "SupportTickets";
            this.lstTickets.ShowToolTip = false;
            this.lstTickets.Size = new System.Drawing.Size(1010, 244);
            this.lstTickets.TabIndex = 7;
            this.lstTickets.UseCompatibleStateImageBehavior = false;
            this.lstTickets.View = System.Windows.Forms.View.Details;
            this.lstTickets.DoubleClick += new System.EventHandler(this.lstTickets_DoubleClick);
            // 
            // colHeaderKey
            // 
            this.colHeaderKey.Text = "Ticket Key";
            this.colHeaderKey.Width = 120;
            // 
            // colHeaderDepartment
            // 
            this.colHeaderDepartment.Text = "Department";
            this.colHeaderDepartment.Width = 100;
            // 
            // colHeaderUser
            // 
            this.colHeaderUser.Text = "User";
            this.colHeaderUser.Width = 180;
            // 
            // colHeaderTitle
            // 
            this.colHeaderTitle.Text = "Title";
            this.colHeaderTitle.Width = 330;
            // 
            // colHeaderReplies
            // 
            this.colHeaderReplies.Text = "Replies";
            // 
            // colHeaderLastUpdated
            // 
            this.colHeaderLastUpdated.Text = "Last Updated";
            this.colHeaderLastUpdated.Width = 100;
            // 
            // colHeaderLastUpdatedBy
            // 
            this.colHeaderLastUpdatedBy.Text = "Last Updated By";
            this.colHeaderLastUpdatedBy.Width = 180;
            // 
            // lblFindTicket
            // 
            this.lblFindTicket.AutoSize = true;
            this.lblFindTicket.Location = new System.Drawing.Point(269, 10);
            this.lblFindTicket.Name = "lblFindTicket";
            this.lblFindTicket.Size = new System.Drawing.Size(95, 13);
            this.lblFindTicket.TabIndex = 14;
            this.lblFindTicket.Text = "Find Ticket by Key";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(407, 8);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(177, 20);
            this.txtKey.TabIndex = 15;
            // 
            // Tickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.lblFindTicket);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.rbClosed);
            this.Controls.Add(this.rbOnHold);
            this.Controls.Add(this.rbOpen);
            this.Controls.Add(this.lstTickets);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "Tickets";
            this.Size = new System.Drawing.Size(1010, 309);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rbClosed;
        private System.Windows.Forms.RadioButton rbOnHold;
        private System.Windows.Forms.RadioButton rbOpen;
        private SharedControls.Classes.ListViewEx lstTickets;
        private System.Windows.Forms.ColumnHeader colHeaderKey;
        private System.Windows.Forms.ColumnHeader colHeaderDepartment;
        private System.Windows.Forms.ColumnHeader colHeaderUser;
        private System.Windows.Forms.ColumnHeader colHeaderTitle;
        private System.Windows.Forms.ColumnHeader colHeaderReplies;
        private System.Windows.Forms.ColumnHeader colHeaderLastUpdated;
        private System.Windows.Forms.ColumnHeader colHeaderLastUpdatedBy;
        private System.Windows.Forms.Label lblFindTicket;
        private System.Windows.Forms.TextBox txtKey;
    }
}