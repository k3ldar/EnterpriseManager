namespace POS.Staff.Forms
{
    partial class ClientCommissionData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusInvoiceTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusCommissionableTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStripPayCommission = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStripInvert = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripUnselectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStripSelectOverdue = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripSelectDueSoon = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.gridCommission = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rbPaid = new System.Windows.Forms.RadioButton();
            this.rbUnpaid = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.cmbStaff = new System.Windows.Forms.ComboBox();
            this.lblSelectStaff = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.contextMenuGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCommission)).BeginInit();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(4, 17);
            this.toolStripStatusLabel3.Visible = false;
            // 
            // toolStripStatusInvoiceTotal
            // 
            this.toolStripStatusInvoiceTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusInvoiceTotal.Name = "toolStripStatusInvoiceTotal";
            this.toolStripStatusInvoiceTotal.Size = new System.Drawing.Size(4, 17);
            this.toolStripStatusInvoiceTotal.Visible = false;
            // 
            // toolStripStatusTotal
            // 
            this.toolStripStatusTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusTotal.Name = "toolStripStatusTotal";
            this.toolStripStatusTotal.Size = new System.Drawing.Size(4, 17);
            this.toolStripStatusTotal.Visible = false;
            // 
            // toolStripStatusCount
            // 
            this.toolStripStatusCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusCount.Name = "toolStripStatusCount";
            this.toolStripStatusCount.Size = new System.Drawing.Size(4, 17);
            this.toolStripStatusCount.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusCount,
            this.toolStripStatusTotal,
            this.toolStripStatusInvoiceTotal,
            this.toolStripStatusCommissionableTotal,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 273);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // toolStripStatusCommissionableTotal
            // 
            this.toolStripStatusCommissionableTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusCommissionableTotal.Name = "toolStripStatusCommissionableTotal";
            this.toolStripStatusCommissionableTotal.Size = new System.Drawing.Size(4, 17);
            this.toolStripStatusCommissionableTotal.Visible = false;
            // 
            // menuStripPayCommission
            // 
            this.menuStripPayCommission.Name = "menuStripPayCommission";
            this.menuStripPayCommission.Size = new System.Drawing.Size(213, 22);
            this.menuStripPayCommission.Text = "Pay Commission";
            this.menuStripPayCommission.Click += new System.EventHandler(this.menuStripPayCommission_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(210, 6);
            // 
            // menuStripInvert
            // 
            this.menuStripInvert.Name = "menuStripInvert";
            this.menuStripInvert.Size = new System.Drawing.Size(213, 22);
            this.menuStripInvert.Text = "Invert Selection";
            this.menuStripInvert.Click += new System.EventHandler(this.menuStripInvert_Click);
            // 
            // menuStripUnselectAll
            // 
            this.menuStripUnselectAll.Name = "menuStripUnselectAll";
            this.menuStripUnselectAll.Size = new System.Drawing.Size(213, 22);
            this.menuStripUnselectAll.Text = "Unselect All";
            this.menuStripUnselectAll.Click += new System.EventHandler(this.menuStripUnselectAll_Click);
            // 
            // menuStripSelectAll
            // 
            this.menuStripSelectAll.Name = "menuStripSelectAll";
            this.menuStripSelectAll.Size = new System.Drawing.Size(213, 22);
            this.menuStripSelectAll.Text = "Select All";
            this.menuStripSelectAll.Click += new System.EventHandler(this.menuStripSelectAll_Click);
            // 
            // contextMenuGrid
            // 
            this.contextMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripSelectAll,
            this.menuStripUnselectAll,
            this.menuStripInvert,
            this.toolStripMenuItem1,
            this.menuStripSelectOverdue,
            this.menuStripSelectDueSoon,
            this.toolStripMenuItem2,
            this.menuStripPayCommission});
            this.contextMenuGrid.Name = "contextMenuStrip1";
            this.contextMenuGrid.Size = new System.Drawing.Size(214, 148);
            // 
            // menuStripSelectOverdue
            // 
            this.menuStripSelectOverdue.Name = "menuStripSelectOverdue";
            this.menuStripSelectOverdue.Size = new System.Drawing.Size(213, 22);
            this.menuStripSelectOverdue.Text = "Select Overdue";
            this.menuStripSelectOverdue.Click += new System.EventHandler(this.menuStripSelectOverdue_Click);
            // 
            // menuStripSelectDueSoon
            // 
            this.menuStripSelectDueSoon.Name = "menuStripSelectDueSoon";
            this.menuStripSelectDueSoon.Size = new System.Drawing.Size(213, 22);
            this.menuStripSelectDueSoon.Text = "Select Due within 1 month";
            this.menuStripSelectDueSoon.Click += new System.EventHandler(this.menuStripSelectDueWithin1Month_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(210, 6);
            // 
            // gridCommission
            // 
            this.gridCommission.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCommission.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridCommission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCommission.ContextMenuStrip = this.contextMenuGrid;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridCommission.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridCommission.Location = new System.Drawing.Point(3, 58);
            this.gridCommission.Name = "gridCommission";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCommission.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridCommission.Size = new System.Drawing.Size(786, 234);
            this.gridCommission.TabIndex = 5;
            this.gridCommission.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCommission_CellEndEdit);
            this.gridCommission.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridCommission_CellFormatting);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(701, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "button1";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rbPaid
            // 
            this.rbPaid.AutoSize = true;
            this.rbPaid.Location = new System.Drawing.Point(663, 24);
            this.rbPaid.Name = "rbPaid";
            this.rbPaid.Size = new System.Drawing.Size(85, 17);
            this.rbPaid.TabIndex = 8;
            this.rbPaid.Text = "radioButton3";
            this.rbPaid.UseVisualStyleBackColor = true;
            // 
            // rbUnpaid
            // 
            this.rbUnpaid.AutoSize = true;
            this.rbUnpaid.Location = new System.Drawing.Point(572, 24);
            this.rbUnpaid.Name = "rbUnpaid";
            this.rbUnpaid.Size = new System.Drawing.Size(85, 17);
            this.rbUnpaid.TabIndex = 7;
            this.rbUnpaid.Text = "radioButton2";
            this.rbUnpaid.UseVisualStyleBackColor = true;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(481, 24);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(85, 17);
            this.rbAll.TabIndex = 6;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "radioButton1";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(320, 25);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(144, 20);
            this.dtpTo.TabIndex = 5;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(153, 24);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(144, 20);
            this.dtpFrom.TabIndex = 3;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(317, 9);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(35, 13);
            this.lblDateTo.TabIndex = 4;
            this.lblDateTo.Text = "label2";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(150, 9);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(35, 13);
            this.lblDateFrom.TabIndex = 2;
            this.lblDateFrom.Text = "label1";
            // 
            // cmbStaff
            // 
            this.cmbStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaff.FormattingEnabled = true;
            this.cmbStaff.Location = new System.Drawing.Point(8, 23);
            this.cmbStaff.Name = "cmbStaff";
            this.cmbStaff.Size = new System.Drawing.Size(130, 21);
            this.cmbStaff.TabIndex = 1;
            this.cmbStaff.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbStaff_Format);
            // 
            // lblSelectStaff
            // 
            this.lblSelectStaff.AutoSize = true;
            this.lblSelectStaff.Location = new System.Drawing.Point(5, 9);
            this.lblSelectStaff.Name = "lblSelectStaff";
            this.lblSelectStaff.Size = new System.Drawing.Size(62, 13);
            this.lblSelectStaff.TabIndex = 0;
            this.lblSelectStaff.Text = "Select Staff";
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlToolbar.Controls.Add(this.btnSearch);
            this.pnlToolbar.Controls.Add(this.rbPaid);
            this.pnlToolbar.Controls.Add(this.rbUnpaid);
            this.pnlToolbar.Controls.Add(this.rbAll);
            this.pnlToolbar.Controls.Add(this.dtpTo);
            this.pnlToolbar.Controls.Add(this.dtpFrom);
            this.pnlToolbar.Controls.Add(this.lblDateTo);
            this.pnlToolbar.Controls.Add(this.lblDateFrom);
            this.pnlToolbar.Controls.Add(this.cmbStaff);
            this.pnlToolbar.Controls.Add(this.lblSelectStaff);
            this.pnlToolbar.Location = new System.Drawing.Point(3, 1);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(786, 51);
            this.pnlToolbar.TabIndex = 4;
            // 
            // ClientCommissionData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gridCommission);
            this.Controls.Add(this.pnlToolbar);
            this.MinimumSize = new System.Drawing.Size(792, 295);
            this.Name = "ClientCommissionData";
            this.Size = new System.Drawing.Size(792, 295);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCommission)).EndInit();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusInvoiceTotal;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusTotal;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusCount;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusCommissionableTotal;
        private System.Windows.Forms.ToolStripMenuItem menuStripPayCommission;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuStripInvert;
        private System.Windows.Forms.ToolStripMenuItem menuStripUnselectAll;
        private System.Windows.Forms.ToolStripMenuItem menuStripSelectAll;
        private System.Windows.Forms.ContextMenuStrip contextMenuGrid;
        private System.Windows.Forms.DataGridView gridCommission;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rbPaid;
        private System.Windows.Forms.RadioButton rbUnpaid;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.ComboBox cmbStaff;
        private System.Windows.Forms.Label lblSelectStaff;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.ToolStripMenuItem menuStripSelectOverdue;
        private System.Windows.Forms.ToolStripMenuItem menuStripSelectDueSoon;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}