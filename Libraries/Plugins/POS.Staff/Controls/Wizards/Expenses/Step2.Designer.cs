namespace POS.Staff.Controls.Wizards.Expenses
{
    partial class Step2
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
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpExpenseDate = new System.Windows.Forms.DateTimePicker();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.cmbExpenseType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.txtReason = new SharedControls.TextBoxEx();
            this.lblReason = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.udQuantity = new System.Windows.Forms.NumericUpDown();
            this.udCost = new System.Windows.Forms.NumericUpDown();
            this.lblCost = new System.Windows.Forms.Label();
            this.gbReceipt = new System.Windows.Forms.GroupBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.picReceipt = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.udTaxPaid = new System.Windows.Forms.NumericUpDown();
            this.lblTaxPaid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udCost)).BeginInit();
            this.gbReceipt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTaxPaid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(3, 50);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(35, 13);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "label1";
            // 
            // dtpExpenseDate
            // 
            this.dtpExpenseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpenseDate.Location = new System.Drawing.Point(3, 67);
            this.dtpExpenseDate.Name = "dtpExpenseDate";
            this.dtpExpenseDate.Size = new System.Drawing.Size(203, 20);
            this.dtpExpenseDate.TabIndex = 3;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(3, 94);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(35, 13);
            this.lblLocation.TabIndex = 4;
            this.lblLocation.Text = "label1";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(3, 111);
            this.txtLocation.MaxLength = 100;
            this.txtLocation.Multiline = true;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(203, 58);
            this.txtLocation.TabIndex = 5;
            // 
            // cmbExpenseType
            // 
            this.cmbExpenseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExpenseType.FormattingEnabled = true;
            this.cmbExpenseType.Location = new System.Drawing.Point(3, 19);
            this.cmbExpenseType.Name = "cmbExpenseType";
            this.cmbExpenseType.Size = new System.Drawing.Size(203, 21);
            this.cmbExpenseType.TabIndex = 1;
            this.cmbExpenseType.SelectedIndexChanged += new System.EventHandler(this.cmbExpenseType_SelectedIndexChanged);
            this.cmbExpenseType.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbExpenseType_Format);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(3, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(35, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "label1";
            // 
            // txtReason
            // 
            this.txtReason.AllowBackSpace = true;
            this.txtReason.AllowCopy = true;
            this.txtReason.AllowCut = true;
            this.txtReason.AllowedCharacters = "abcdefgijklmnopqrstuvw";
            this.txtReason.AllowPaste = true;
            this.txtReason.Location = new System.Drawing.Point(3, 189);
            this.txtReason.MaxLength = 100;
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(203, 58);
            this.txtReason.TabIndex = 7;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(3, 172);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(35, 13);
            this.lblReason.TabIndex = 6;
            this.lblReason.Text = "label1";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(3, 260);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(35, 13);
            this.lblQuantity.TabIndex = 8;
            this.lblQuantity.Text = "label2";
            // 
            // udQuantity
            // 
            this.udQuantity.Location = new System.Drawing.Point(3, 276);
            this.udQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udQuantity.Name = "udQuantity";
            this.udQuantity.Size = new System.Drawing.Size(97, 20);
            this.udQuantity.TabIndex = 9;
            this.udQuantity.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.udQuantity.ValueChanged += new System.EventHandler(this.udQuantity_Leave);
            this.udQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.udQuantity_KeyUp);
            this.udQuantity.Leave += new System.EventHandler(this.udQuantity_Leave);
            // 
            // udCost
            // 
            this.udCost.DecimalPlaces = 2;
            this.udCost.Location = new System.Drawing.Point(109, 276);
            this.udCost.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udCost.Name = "udCost";
            this.udCost.Size = new System.Drawing.Size(97, 20);
            this.udCost.TabIndex = 11;
            this.udCost.ValueChanged += new System.EventHandler(this.udCost_ValueChanged);
            this.udCost.KeyUp += new System.Windows.Forms.KeyEventHandler(this.udCost_KeyUp);
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(109, 260);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(35, 13);
            this.lblCost.TabIndex = 10;
            this.lblCost.Text = "label2";
            // 
            // gbReceipt
            // 
            this.gbReceipt.Controls.Add(this.btnSelect);
            this.gbReceipt.Controls.Add(this.picReceipt);
            this.gbReceipt.Location = new System.Drawing.Point(228, 7);
            this.gbReceipt.Name = "gbReceipt";
            this.gbReceipt.Size = new System.Drawing.Size(335, 346);
            this.gbReceipt.TabIndex = 14;
            this.gbReceipt.TabStop = false;
            this.gbReceipt.Text = "groupBox1";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(6, 33);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(93, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "button1";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // picReceipt
            // 
            this.picReceipt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picReceipt.Location = new System.Drawing.Point(6, 62);
            this.picReceipt.Name = "picReceipt";
            this.picReceipt.Size = new System.Drawing.Size(323, 273);
            this.picReceipt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picReceipt.TabIndex = 0;
            this.picReceipt.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.gif;*.png;*.bmp|All Files|*.*";
            this.openFileDialog1.FilterIndex = 0;
            // 
            // udTaxPaid
            // 
            this.udTaxPaid.DecimalPlaces = 2;
            this.udTaxPaid.Location = new System.Drawing.Point(3, 322);
            this.udTaxPaid.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udTaxPaid.Name = "udTaxPaid";
            this.udTaxPaid.Size = new System.Drawing.Size(97, 20);
            this.udTaxPaid.TabIndex = 13;
            // 
            // lblTaxPaid
            // 
            this.lblTaxPaid.AutoSize = true;
            this.lblTaxPaid.Location = new System.Drawing.Point(3, 306);
            this.lblTaxPaid.Name = "lblTaxPaid";
            this.lblTaxPaid.Size = new System.Drawing.Size(35, 13);
            this.lblTaxPaid.TabIndex = 12;
            this.lblTaxPaid.Text = "label2";
            // 
            // Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.udTaxPaid);
            this.Controls.Add(this.lblTaxPaid);
            this.Controls.Add(this.gbReceipt);
            this.Controls.Add(this.udCost);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.udQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cmbExpenseType);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.dtpExpenseDate);
            this.Controls.Add(this.lblDate);
            this.Name = "Step2";
            ((System.ComponentModel.ISupportInitialize)(this.udQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udCost)).EndInit();
            this.gbReceipt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTaxPaid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpExpenseDate;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.ComboBox cmbExpenseType;
        private System.Windows.Forms.Label lblType;
        private SharedControls.TextBoxEx txtReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown udQuantity;
        private System.Windows.Forms.NumericUpDown udCost;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.GroupBox gbReceipt;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.PictureBox picReceipt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NumericUpDown udTaxPaid;
        private System.Windows.Forms.Label lblTaxPaid;
    }
}
