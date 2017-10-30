namespace POS.Invoices.Controls
{
    partial class RecurringInvocesControl
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
            this.lstRecurringInvoices = new SharedControls.Classes.ListViewEx();
            this.colHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderBusinessName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderNextRun = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderFrequency = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderPeriod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderDiscount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuRecurring = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // lstRecurringInvoices
            // 
            this.lstRecurringInvoices.AllowColumnReorder = true;
            this.lstRecurringInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRecurringInvoices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderDescription,
            this.colHeaderBusinessName,
            this.colHeaderUsername,
            this.colHeaderNextRun,
            this.colHeaderFrequency,
            this.colHeaderPeriod,
            this.colHeaderDiscount});
            this.lstRecurringInvoices.ContextMenuStrip = this.contextMenuRecurring;
            this.lstRecurringInvoices.FullRowSelect = true;
            this.lstRecurringInvoices.HideSelection = false;
            this.lstRecurringInvoices.Location = new System.Drawing.Point(0, 28);
            this.lstRecurringInvoices.MultiSelect = false;
            this.lstRecurringInvoices.Name = "lstRecurringInvoices";
            this.lstRecurringInvoices.OwnerDraw = true;
            this.lstRecurringInvoices.SaveName = "RecurringInvoices";
            this.lstRecurringInvoices.ShowToolTip = false;
            this.lstRecurringInvoices.Size = new System.Drawing.Size(794, 245);
            this.lstRecurringInvoices.TabIndex = 10;
            this.lstRecurringInvoices.UseCompatibleStateImageBehavior = false;
            this.lstRecurringInvoices.View = System.Windows.Forms.View.Details;
            this.lstRecurringInvoices.SelectedIndexChanged += new System.EventHandler(this.lstRecurringInvoices_SelectedIndexChanged);
            this.lstRecurringInvoices.DoubleClick += new System.EventHandler(this.lstUsers_DoubleClick);
            // 
            // colHeaderDescription
            // 
            this.colHeaderDescription.Text = "Description";
            this.colHeaderDescription.Width = 256;
            // 
            // colHeaderBusinessName
            // 
            this.colHeaderBusinessName.Text = "Business Name";
            this.colHeaderBusinessName.Width = 216;
            // 
            // colHeaderUsername
            // 
            this.colHeaderUsername.Text = "First Name";
            this.colHeaderUsername.Width = 213;
            // 
            // colHeaderNextRun
            // 
            this.colHeaderNextRun.Text = "Last Name";
            this.colHeaderNextRun.Width = 148;
            // 
            // colHeaderFrequency
            // 
            this.colHeaderFrequency.Text = "Frequency";
            this.colHeaderFrequency.Width = 137;
            // 
            // colHeaderPeriod
            // 
            this.colHeaderPeriod.Text = "Period";
            this.colHeaderPeriod.Width = 129;
            // 
            // colHeaderDiscount
            // 
            this.colHeaderDiscount.Text = "Discount";
            this.colHeaderDiscount.Width = 92;
            // 
            // contextMenuRecurring
            // 
            this.contextMenuRecurring.Name = "contextMenuRecurring";
            this.contextMenuRecurring.Size = new System.Drawing.Size(61, 4);
            // 
            // RecurringInvocesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstRecurringInvoices);
            this.Name = "RecurringInvocesControl";
            this.Size = new System.Drawing.Size(797, 276);
            this.Controls.SetChildIndex(this.lstRecurringInvoices, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharedControls.Classes.ListViewEx lstRecurringInvoices;
        private System.Windows.Forms.ColumnHeader colHeaderUsername;
        private System.Windows.Forms.ColumnHeader colHeaderNextRun;
        private System.Windows.Forms.ColumnHeader colHeaderBusinessName;
        private System.Windows.Forms.ColumnHeader colHeaderDescription;
        private System.Windows.Forms.ColumnHeader colHeaderFrequency;
        private System.Windows.Forms.ColumnHeader colHeaderPeriod;
        private System.Windows.Forms.ColumnHeader colHeaderDiscount;
        private System.Windows.Forms.ContextMenuStrip contextMenuRecurring;
    }
}
