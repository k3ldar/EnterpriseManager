namespace POS.Staff.Forms
{
    partial class CommissionPoolData
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
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rbPaid = new System.Windows.Forms.RadioButton();
            this.rbUnpaid = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.cmbPools = new System.Windows.Forms.ComboBox();
            this.lblSelectPool = new System.Windows.Forms.Label();
            this.gridCommission = new System.Windows.Forms.DataGridView();
            this.contextMenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStripSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripUnselectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripInvert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStripPayCommission = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusInvoiceTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusCommissionableTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCommission)).BeginInit();
            this.contextMenuGrid.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.pnlToolbar.Controls.Add(this.cmbPools);
            this.pnlToolbar.Controls.Add(this.lblSelectPool);
            this.pnlToolbar.Location = new System.Drawing.Point(3, 1);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(771, 51);
            this.pnlToolbar.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(686, 14);
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
            this.rbPaid.Location = new System.Drawing.Point(654, 24);
            this.rbPaid.Name = "rbPaid";
            this.rbPaid.Size = new System.Drawing.Size(85, 17);
            this.rbPaid.TabIndex = 8;
            this.rbPaid.Text = "radioButton3";
            this.rbPaid.UseVisualStyleBackColor = true;
            // 
            // rbUnpaid
            // 
            this.rbUnpaid.AutoSize = true;
            this.rbUnpaid.Location = new System.Drawing.Point(563, 24);
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
            this.rbAll.Location = new System.Drawing.Point(472, 24);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(85, 17);
            this.rbAll.TabIndex = 6;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "radioButton1";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(303, 23);
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
            this.lblDateTo.Location = new System.Drawing.Point(300, 7);
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
            // cmbPools
            // 
            this.cmbPools.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPools.FormattingEnabled = true;
            this.cmbPools.Location = new System.Drawing.Point(8, 23);
            this.cmbPools.Name = "cmbPools";
            this.cmbPools.Size = new System.Drawing.Size(130, 21);
            this.cmbPools.TabIndex = 1;
            this.cmbPools.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbPools_Format);
            // 
            // lblSelectPool
            // 
            this.lblSelectPool.AutoSize = true;
            this.lblSelectPool.Location = new System.Drawing.Point(5, 9);
            this.lblSelectPool.Name = "lblSelectPool";
            this.lblSelectPool.Size = new System.Drawing.Size(81, 13);
            this.lblSelectPool.TabIndex = 0;
            this.lblSelectPool.Text = "Select Location";
            // 
            // gridCommission
            // 
            this.gridCommission.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCommission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCommission.ContextMenuStrip = this.contextMenuGrid;
            this.gridCommission.Location = new System.Drawing.Point(3, 58);
            this.gridCommission.Name = "gridCommission";
            this.gridCommission.Size = new System.Drawing.Size(771, 234);
            this.gridCommission.TabIndex = 2;
            this.gridCommission.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCommission_CellEndEdit);
            this.gridCommission.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridCommission_CellFormatting);
            // 
            // contextMenuGrid
            // 
            this.contextMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripSelectAll,
            this.menuStripUnselectAll,
            this.menuStripInvert,
            this.toolStripMenuItem1,
            this.menuStripPayCommission});
            this.contextMenuGrid.Name = "contextMenuStrip1";
            this.contextMenuGrid.Size = new System.Drawing.Size(164, 98);
            // 
            // menuStripSelectAll
            // 
            this.menuStripSelectAll.Name = "menuStripSelectAll";
            this.menuStripSelectAll.Size = new System.Drawing.Size(163, 22);
            this.menuStripSelectAll.Text = "Select All";
            this.menuStripSelectAll.Click += new System.EventHandler(this.menuStripSelectAll_Click);
            // 
            // menuStripUnselectAll
            // 
            this.menuStripUnselectAll.Name = "menuStripUnselectAll";
            this.menuStripUnselectAll.Size = new System.Drawing.Size(163, 22);
            this.menuStripUnselectAll.Text = "Unselect All";
            this.menuStripUnselectAll.Click += new System.EventHandler(this.menuStripUnselectAll_Click);
            // 
            // menuStripInvert
            // 
            this.menuStripInvert.Name = "menuStripInvert";
            this.menuStripInvert.Size = new System.Drawing.Size(163, 22);
            this.menuStripInvert.Text = "Invert Selection";
            this.menuStripInvert.Click += new System.EventHandler(this.menuStripInvert_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
            // 
            // menuStripPayCommission
            // 
            this.menuStripPayCommission.Name = "menuStripPayCommission";
            this.menuStripPayCommission.Size = new System.Drawing.Size(163, 22);
            this.menuStripPayCommission.Text = "Pay Commission";
            this.menuStripPayCommission.Click += new System.EventHandler(this.menuStripPayCommission_Click);
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
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // toolStripStatusCount
            // 
            this.toolStripStatusCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusCount.Name = "toolStripStatusCount";
            this.toolStripStatusCount.Size = new System.Drawing.Size(4, 17);
            this.toolStripStatusCount.Visible = false;
            // 
            // toolStripStatusTotal
            // 
            this.toolStripStatusTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusTotal.Name = "toolStripStatusTotal";
            this.toolStripStatusTotal.Size = new System.Drawing.Size(4, 17);
            this.toolStripStatusTotal.Visible = false;
            // 
            // toolStripStatusInvoiceTotal
            // 
            this.toolStripStatusInvoiceTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusInvoiceTotal.Name = "toolStripStatusInvoiceTotal";
            this.toolStripStatusInvoiceTotal.Size = new System.Drawing.Size(4, 17);
            this.toolStripStatusInvoiceTotal.Visible = false;
            // 
            // toolStripStatusCommissionableTotal
            // 
            this.toolStripStatusCommissionableTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusCommissionableTotal.Name = "toolStripStatusCommissionableTotal";
            this.toolStripStatusCommissionableTotal.Size = new System.Drawing.Size(4, 17);
            this.toolStripStatusCommissionableTotal.Visible = false;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(4, 17);
            this.toolStripStatusLabel3.Visible = false;
            // 
            // CommissionPoolData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gridCommission);
            this.Controls.Add(this.pnlToolbar);
            this.MinimumSize = new System.Drawing.Size(792, 295);
            this.Name = "CommissionPoolData";
            this.Size = new System.Drawing.Size(792, 295);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCommission)).EndInit();
            this.contextMenuGrid.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.ComboBox cmbPools;
        private System.Windows.Forms.Label lblSelectPool;
        private System.Windows.Forms.DataGridView gridCommission;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.RadioButton rbPaid;
        private System.Windows.Forms.RadioButton rbUnpaid;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusTotal;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusInvoiceTotal;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusCommissionableTotal;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ContextMenuStrip contextMenuGrid;
        private System.Windows.Forms.ToolStripMenuItem menuStripSelectAll;
        private System.Windows.Forms.ToolStripMenuItem menuStripUnselectAll;
        private System.Windows.Forms.ToolStripMenuItem menuStripInvert;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuStripPayCommission;
    }
}