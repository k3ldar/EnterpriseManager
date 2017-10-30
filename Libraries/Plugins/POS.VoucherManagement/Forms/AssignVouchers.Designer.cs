namespace POS.VoucherManagement.Forms
{
    partial class AssignVouchers
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnMarkAllAsSold = new System.Windows.Forms.Button();
            this.rbStatusMarkUnsold = new System.Windows.Forms.RadioButton();
            this.rbStatusVerify = new System.Windows.Forms.RadioButton();
            this.lstVouchers = new System.Windows.Forms.ListBox();
            this.lblScanBarcode = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.cbAddIfNotFound = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 9);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(182, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Manages Vouchers In The Database";
            // 
            // btnMarkAllAsSold
            // 
            this.btnMarkAllAsSold.Location = new System.Drawing.Point(662, 12);
            this.btnMarkAllAsSold.Name = "btnMarkAllAsSold";
            this.btnMarkAllAsSold.Size = new System.Drawing.Size(115, 23);
            this.btnMarkAllAsSold.TabIndex = 2;
            this.btnMarkAllAsSold.Text = "Mark All As Sold";
            this.btnMarkAllAsSold.UseVisualStyleBackColor = true;
            this.btnMarkAllAsSold.Click += new System.EventHandler(this.btnMarkAllAsSold_Click);
            // 
            // rbStatusMarkUnsold
            // 
            this.rbStatusMarkUnsold.AutoSize = true;
            this.rbStatusMarkUnsold.Location = new System.Drawing.Point(15, 36);
            this.rbStatusMarkUnsold.Name = "rbStatusMarkUnsold";
            this.rbStatusMarkUnsold.Size = new System.Drawing.Size(100, 17);
            this.rbStatusMarkUnsold.TabIndex = 3;
            this.rbStatusMarkUnsold.Text = "Mark As Unsold";
            this.rbStatusMarkUnsold.UseVisualStyleBackColor = true;
            this.rbStatusMarkUnsold.CheckedChanged += new System.EventHandler(this.rbStatusVerify_CheckedChanged);
            // 
            // rbStatusVerify
            // 
            this.rbStatusVerify.AutoSize = true;
            this.rbStatusVerify.Checked = true;
            this.rbStatusVerify.Location = new System.Drawing.Point(124, 36);
            this.rbStatusVerify.Name = "rbStatusVerify";
            this.rbStatusVerify.Size = new System.Drawing.Size(84, 17);
            this.rbStatusVerify.TabIndex = 4;
            this.rbStatusVerify.TabStop = true;
            this.rbStatusVerify.Text = "Verify Status";
            this.rbStatusVerify.UseVisualStyleBackColor = true;
            this.rbStatusVerify.CheckedChanged += new System.EventHandler(this.rbStatusVerify_CheckedChanged);
            // 
            // lstVouchers
            // 
            this.lstVouchers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstVouchers.FormattingEnabled = true;
            this.lstVouchers.Location = new System.Drawing.Point(15, 101);
            this.lstVouchers.Name = "lstVouchers";
            this.lstVouchers.Size = new System.Drawing.Size(762, 212);
            this.lstVouchers.TabIndex = 5;
            // 
            // lblScanBarcode
            // 
            this.lblScanBarcode.AutoSize = true;
            this.lblScanBarcode.Location = new System.Drawing.Point(15, 69);
            this.lblScanBarcode.Name = "lblScanBarcode";
            this.lblScanBarcode.Size = new System.Drawing.Size(75, 13);
            this.lblScanBarcode.TabIndex = 6;
            this.lblScanBarcode.Text = "Scan Barcode";
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(148, 69);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(46, 13);
            this.lblBarcode.TabIndex = 7;
            this.lblBarcode.Text = "barcode";
            // 
            // cbAddIfNotFound
            // 
            this.cbAddIfNotFound.AutoSize = true;
            this.cbAddIfNotFound.Checked = true;
            this.cbAddIfNotFound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAddIfNotFound.Location = new System.Drawing.Point(309, 36);
            this.cbAddIfNotFound.Name = "cbAddIfNotFound";
            this.cbAddIfNotFound.Size = new System.Drawing.Size(149, 17);
            this.cbAddIfNotFound.TabIndex = 8;
            this.cbAddIfNotFound.Text = "Add Voucher if Not Found";
            this.cbAddIfNotFound.UseVisualStyleBackColor = true;
            // 
            // AssignVouchers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbAddIfNotFound);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.lblScanBarcode);
            this.Controls.Add(this.lstVouchers);
            this.Controls.Add(this.rbStatusVerify);
            this.Controls.Add(this.rbStatusMarkUnsold);
            this.Controls.Add(this.btnMarkAllAsSold);
            this.Controls.Add(this.lblDescription);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "AssignVouchers";
            this.Size = new System.Drawing.Size(789, 325);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnMarkAllAsSold;
        private System.Windows.Forms.RadioButton rbStatusMarkUnsold;
        private System.Windows.Forms.RadioButton rbStatusVerify;
        private System.Windows.Forms.ListBox lstVouchers;
        private System.Windows.Forms.Label lblScanBarcode;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.CheckBox cbAddIfNotFound;
    }
}