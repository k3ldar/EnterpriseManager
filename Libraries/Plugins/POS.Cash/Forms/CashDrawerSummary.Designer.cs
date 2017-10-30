namespace POS.CashManager.Forms
{
    partial class CashDrawerSummary
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
            this.lvCashDrawSummary = new SharedControls.Classes.ListViewEx();
            this.chDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOK = new System.Windows.Forms.Button();
            this.lblLocation = new System.Windows.Forms.Label();
            this.cmbStoreLocation = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lvCashDrawSummary
            // 
            this.lvCashDrawSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCashDrawSummary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDescription,
            this.chValue});
            this.lvCashDrawSummary.HideSelection = false;
            this.lvCashDrawSummary.Location = new System.Drawing.Point(12, 37);
            this.lvCashDrawSummary.MultiSelect = false;
            this.lvCashDrawSummary.Name = "lvCashDrawSummary";
            this.lvCashDrawSummary.Size = new System.Drawing.Size(445, 188);
            this.lvCashDrawSummary.TabIndex = 0;
            this.lvCashDrawSummary.UseCompatibleStateImageBehavior = false;
            this.lvCashDrawSummary.View = System.Windows.Forms.View.Details;
            // 
            // chDescription
            // 
            this.chDescription.Text = "Description";
            this.chDescription.Width = 321;
            // 
            // chValue
            // 
            this.chValue.Text = "Value";
            this.chValue.Width = 120;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(382, 231);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(13, 13);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 2;
            this.lblLocation.Text = "Location";
            // 
            // cmbStoreLocation
            // 
            this.cmbStoreLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStoreLocation.FormattingEnabled = true;
            this.cmbStoreLocation.Location = new System.Drawing.Point(67, 10);
            this.cmbStoreLocation.Name = "cmbStoreLocation";
            this.cmbStoreLocation.Size = new System.Drawing.Size(220, 21);
            this.cmbStoreLocation.TabIndex = 3;
            this.cmbStoreLocation.SelectedIndexChanged += new System.EventHandler(this.cmbStoreLocation_SelectedIndexChanged);
            this.cmbStoreLocation.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbStoreLocation_Format);
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate.Location = new System.Drawing.Point(303, 11);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(154, 20);
            this.dtpDate.TabIndex = 4;
            // 
            // CashDrawerSummary
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 266);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cmbStoreLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lvCashDrawSummary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CashDrawerSummary";
            this.SaveState = true;
            this.Text = "Cash Drawer Summary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharedControls.Classes.ListViewEx lvCashDrawSummary;
        private System.Windows.Forms.ColumnHeader chDescription;
        private System.Windows.Forms.ColumnHeader chValue;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ComboBox cmbStoreLocation;
        private System.Windows.Forms.DateTimePicker dtpDate;
    }
}