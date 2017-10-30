namespace Reports.Stock
{
    partial class StockReports
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStoreLocations = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStockTypes = new System.Windows.Forms.ComboBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbOptions = new System.Windows.Forms.ComboBox();
            this.lblStockInOut = new System.Windows.Forms.Label();
            this.cmbStockInOutDate = new System.Windows.Forms.ComboBox();
            this.cbInOutFromDate = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpSetDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Store Location";
            // 
            // cmbStoreLocations
            // 
            this.cmbStoreLocations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStoreLocations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStoreLocations.FormattingEnabled = true;
            this.cmbStoreLocations.Location = new System.Drawing.Point(13, 30);
            this.cmbStoreLocations.Name = "cmbStoreLocations";
            this.cmbStoreLocations.Size = new System.Drawing.Size(253, 21);
            this.cmbStoreLocations.TabIndex = 1;
            this.cmbStoreLocations.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbStoreLocations_Format);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Stock Type";
            // 
            // cmbStockTypes
            // 
            this.cmbStockTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStockTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStockTypes.FormattingEnabled = true;
            this.cmbStockTypes.Location = new System.Drawing.Point(13, 73);
            this.cmbStockTypes.Name = "cmbStockTypes";
            this.cmbStockTypes.Size = new System.Drawing.Size(253, 21);
            this.cmbStockTypes.TabIndex = 3;
            this.cmbStockTypes.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbStockTypes_Format);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(187, 323);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 13;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(106, 323);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Options";
            // 
            // cmbOptions
            // 
            this.cmbOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOptions.FormattingEnabled = true;
            this.cmbOptions.Items.AddRange(new object[] {
            "Show all stock",
            "Hide stock where there are none available",
            "Only show stock that is low or out of stock",
            "Stock In",
            "Stock Out",
            "Current stock by Size"});
            this.cmbOptions.Location = new System.Drawing.Point(13, 117);
            this.cmbOptions.Name = "cmbOptions";
            this.cmbOptions.Size = new System.Drawing.Size(253, 21);
            this.cmbOptions.TabIndex = 5;
            this.cmbOptions.SelectedIndexChanged += new System.EventHandler(this.cmbOptions_SelectedIndexChanged);
            // 
            // lblStockInOut
            // 
            this.lblStockInOut.AutoSize = true;
            this.lblStockInOut.Location = new System.Drawing.Point(13, 148);
            this.lblStockInOut.Name = "lblStockInOut";
            this.lblStockInOut.Size = new System.Drawing.Size(95, 13);
            this.lblStockInOut.TabIndex = 6;
            this.lblStockInOut.Text = "Stock In/Out Date";
            // 
            // cmbStockInOutDate
            // 
            this.cmbStockInOutDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStockInOutDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStockInOutDate.FormattingEnabled = true;
            this.cmbStockInOutDate.Location = new System.Drawing.Point(13, 165);
            this.cmbStockInOutDate.Name = "cmbStockInOutDate";
            this.cmbStockInOutDate.Size = new System.Drawing.Size(253, 21);
            this.cmbStockInOutDate.TabIndex = 7;
            // 
            // cbInOutFromDate
            // 
            this.cbInOutFromDate.AutoSize = true;
            this.cbInOutFromDate.Location = new System.Drawing.Point(16, 249);
            this.cbInOutFromDate.Name = "cbInOutFromDate";
            this.cbInOutFromDate.Size = new System.Drawing.Size(75, 17);
            this.cbInOutFromDate.TabIndex = 10;
            this.cbInOutFromDate.Text = "From Date";
            this.cbInOutFromDate.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Set Report Date";
            // 
            // dtpSetDate
            // 
            this.dtpSetDate.Location = new System.Drawing.Point(13, 286);
            this.dtpSetDate.Name = "dtpSetDate";
            this.dtpSetDate.Size = new System.Drawing.Size(200, 20);
            this.dtpSetDate.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Size";
            // 
            // txtSize
            // 
            this.txtSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSize.Location = new System.Drawing.Point(16, 215);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(250, 20);
            this.txtSize.TabIndex = 9;
            // 
            // StockReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(281, 358);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpSetDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbInOutFromDate);
            this.Controls.Add(this.cmbStockInOutDate);
            this.Controls.Add(this.lblStockInOut);
            this.Controls.Add(this.cmbOptions);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.cmbStockTypes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbStoreLocations);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockReports";
            this.Text = "Stock Reports";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStoreLocations;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStockTypes;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbOptions;
        private System.Windows.Forms.Label lblStockInOut;
        private System.Windows.Forms.ComboBox cmbStockInOutDate;
        private System.Windows.Forms.CheckBox cbInOutFromDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpSetDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSize;
    }
}