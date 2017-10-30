namespace POS.Invoices.Forms
{
    partial class SavedBasketOrdersForm
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
            this.lblSavedOrders = new System.Windows.Forms.Label();
            this.lstSavedOrders = new SharedControls.Classes.ListViewEx();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOpenSelected = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.colCustomer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStaff = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lblSavedOrders
            // 
            this.lblSavedOrders.AutoSize = true;
            this.lblSavedOrders.Location = new System.Drawing.Point(13, 13);
            this.lblSavedOrders.Name = "lblSavedOrders";
            this.lblSavedOrders.Size = new System.Drawing.Size(72, 13);
            this.lblSavedOrders.TabIndex = 0;
            this.lblSavedOrders.Text = "Saved Orders";
            // 
            // lstSavedOrders
            // 
            this.lstSavedOrders.AllowColumnReorder = true;
            this.lstSavedOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSavedOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCustomer,
            this.colStaff,
            this.colDate});
            this.lstSavedOrders.FullRowSelect = true;
            this.lstSavedOrders.Location = new System.Drawing.Point(16, 30);
            this.lstSavedOrders.Name = "lstSavedOrders";
            this.lstSavedOrders.OwnerDraw = true;
            this.lstSavedOrders.SaveName = "";
            this.lstSavedOrders.ShowToolTip = false;
            this.lstSavedOrders.Size = new System.Drawing.Size(631, 186);
            this.lstSavedOrders.TabIndex = 1;
            this.lstSavedOrders.UseCompatibleStateImageBehavior = false;
            this.lstSavedOrders.View = System.Windows.Forms.View.Details;
            this.lstSavedOrders.SelectedIndexChanged += new System.EventHandler(this.lstSavedOrders_SelectedIndexChanged);
            this.lstSavedOrders.DoubleClick += new System.EventHandler(this.lstSavedOrders_DoubleClick);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(541, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOpenSelected
            // 
            this.btnOpenSelected.Location = new System.Drawing.Point(429, 226);
            this.btnOpenSelected.Name = "btnOpenSelected";
            this.btnOpenSelected.Size = new System.Drawing.Size(106, 23);
            this.btnOpenSelected.TabIndex = 3;
            this.btnOpenSelected.Text = "Open Selected";
            this.btnOpenSelected.UseVisualStyleBackColor = true;
            this.btnOpenSelected.Click += new System.EventHandler(this.btnOpenSelected_Click);
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(317, 226);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(106, 23);
            this.btnDeleteSelected.TabIndex = 4;
            this.btnDeleteSelected.Text = "Delete Selected";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // colCustomer
            // 
            this.colCustomer.Width = 219;
            // 
            // colDate
            // 
            this.colDate.Width = 177;
            // 
            // colStaff
            // 
            this.colStaff.Width = 224;
            // 
            // SavedBasketOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(659, 261);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.btnOpenSelected);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lstSavedOrders);
            this.Controls.Add(this.lblSavedOrders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SavedBasketOrdersForm";
            this.SaveState = true;
            this.Text = "SavedBasketOrdersForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSavedOrders;
        private SharedControls.Classes.ListViewEx lstSavedOrders;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOpenSelected;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.ColumnHeader colCustomer;
        private System.Windows.Forms.ColumnHeader colStaff;
        private System.Windows.Forms.ColumnHeader colDate;
    }
}