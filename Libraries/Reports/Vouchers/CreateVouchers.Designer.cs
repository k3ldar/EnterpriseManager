namespace Reports.Vouchers
{
    partial class CreateVouchers
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLabelSize = new System.Windows.Forms.ComboBox();
            this.cmbVoucherAmount = new System.Windows.Forms.ComboBox();
            this.btnCreateLabels = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbTestPrinting = new System.Windows.Forms.CheckBox();
            this.cbShowLines = new System.Windows.Forms.CheckBox();
            this.cbCustomLabel = new System.Windows.Forms.CheckBox();
            this.gbCustomLabel = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblRows = new System.Windows.Forms.Label();
            this.upDownRows = new System.Windows.Forms.NumericUpDown();
            this.lblColumns = new System.Windows.Forms.Label();
            this.upDownColumns = new System.Windows.Forms.NumericUpDown();
            this.grpLabelSize = new System.Windows.Forms.GroupBox();
            this.upDownLabelVGap = new Reports.Controls.NumericUpDownEx();
            this.upDownLabelHGap = new Reports.Controls.NumericUpDownEx();
            this.upDownLabelHeight = new Reports.Controls.NumericUpDownEx();
            this.upDownLabelWidth = new Reports.Controls.NumericUpDownEx();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gbPageMargins = new System.Windows.Forms.GroupBox();
            this.upDownMarginRight = new Reports.Controls.NumericUpDownEx();
            this.upDownMarginLeft = new Reports.Controls.NumericUpDownEx();
            this.upDownMarginBottom = new Reports.Controls.NumericUpDownEx();
            this.upDownMarginTop = new Reports.Controls.NumericUpDownEx();
            this.lblMarginRight = new System.Windows.Forms.Label();
            this.lblMarginLeft = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbGenerateLabels = new System.Windows.Forms.ProgressBar();
            this.lblLabelGeneration = new System.Windows.Forms.Label();
            this.pbOverall = new System.Windows.Forms.ProgressBar();
            this.cmbBarcodeType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gbCustomLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownColumns)).BeginInit();
            this.grpLabelSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownLabelVGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownLabelHGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownLabelHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownLabelWidth)).BeginInit();
            this.gbPageMargins.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownMarginRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownMarginLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownMarginBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownMarginTop)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Voucher Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Avery Label Type";
            // 
            // cmbLabelSize
            // 
            this.cmbLabelSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLabelSize.FormattingEnabled = true;
            this.cmbLabelSize.Location = new System.Drawing.Point(19, 74);
            this.cmbLabelSize.Name = "cmbLabelSize";
            this.cmbLabelSize.Size = new System.Drawing.Size(237, 21);
            this.cmbLabelSize.TabIndex = 3;
            this.cmbLabelSize.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbLabelSize_Format);
            // 
            // cmbVoucherAmount
            // 
            this.cmbVoucherAmount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoucherAmount.FormattingEnabled = true;
            this.cmbVoucherAmount.Location = new System.Drawing.Point(19, 30);
            this.cmbVoucherAmount.Name = "cmbVoucherAmount";
            this.cmbVoucherAmount.Size = new System.Drawing.Size(237, 21);
            this.cmbVoucherAmount.TabIndex = 1;
            this.cmbVoucherAmount.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbVoucherAmount_Format);
            // 
            // btnCreateLabels
            // 
            this.btnCreateLabels.Location = new System.Drawing.Point(181, 156);
            this.btnCreateLabels.Name = "btnCreateLabels";
            this.btnCreateLabels.Size = new System.Drawing.Size(75, 23);
            this.btnCreateLabels.TabIndex = 9;
            this.btnCreateLabels.Text = "Create";
            this.btnCreateLabels.UseVisualStyleBackColor = true;
            this.btnCreateLabels.Click += new System.EventHandler(this.btnCreateLabels_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(181, 307);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // cbTestPrinting
            // 
            this.cbTestPrinting.AutoSize = true;
            this.cbTestPrinting.Checked = true;
            this.cbTestPrinting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTestPrinting.Location = new System.Drawing.Point(19, 156);
            this.cbTestPrinting.Name = "cbTestPrinting";
            this.cbTestPrinting.Size = new System.Drawing.Size(103, 17);
            this.cbTestPrinting.TabIndex = 6;
            this.cbTestPrinting.Text = "Test For Printing";
            this.cbTestPrinting.UseVisualStyleBackColor = true;
            // 
            // cbShowLines
            // 
            this.cbShowLines.AutoSize = true;
            this.cbShowLines.Location = new System.Drawing.Point(19, 180);
            this.cbShowLines.Name = "cbShowLines";
            this.cbShowLines.Size = new System.Drawing.Size(81, 17);
            this.cbShowLines.TabIndex = 7;
            this.cbShowLines.Text = "Show Lines";
            this.cbShowLines.UseVisualStyleBackColor = true;
            // 
            // cbCustomLabel
            // 
            this.cbCustomLabel.AutoSize = true;
            this.cbCustomLabel.Location = new System.Drawing.Point(19, 204);
            this.cbCustomLabel.Name = "cbCustomLabel";
            this.cbCustomLabel.Size = new System.Drawing.Size(90, 17);
            this.cbCustomLabel.TabIndex = 8;
            this.cbCustomLabel.Text = "Custom Label";
            this.cbCustomLabel.UseVisualStyleBackColor = true;
            this.cbCustomLabel.CheckedChanged += new System.EventHandler(this.cbCustomLabel_CheckedChanged);
            // 
            // gbCustomLabel
            // 
            this.gbCustomLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCustomLabel.Controls.Add(this.btnSave);
            this.gbCustomLabel.Controls.Add(this.lblRows);
            this.gbCustomLabel.Controls.Add(this.upDownRows);
            this.gbCustomLabel.Controls.Add(this.lblColumns);
            this.gbCustomLabel.Controls.Add(this.upDownColumns);
            this.gbCustomLabel.Controls.Add(this.grpLabelSize);
            this.gbCustomLabel.Controls.Add(this.gbPageMargins);
            this.gbCustomLabel.Location = new System.Drawing.Point(292, 13);
            this.gbCustomLabel.Name = "gbCustomLabel";
            this.gbCustomLabel.Size = new System.Drawing.Size(424, 317);
            this.gbCustomLabel.TabIndex = 13;
            this.gbCustomLabel.TabStop = false;
            this.gbCustomLabel.Text = "Custom Label Settings";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(337, 183);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(13, 188);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(34, 13);
            this.lblRows.TabIndex = 4;
            this.lblRows.Text = "Rows";
            // 
            // upDownRows
            // 
            this.upDownRows.Location = new System.Drawing.Point(81, 186);
            this.upDownRows.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.upDownRows.Name = "upDownRows";
            this.upDownRows.Size = new System.Drawing.Size(120, 20);
            this.upDownRows.TabIndex = 5;
            this.upDownRows.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Location = new System.Drawing.Point(13, 162);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(47, 13);
            this.lblColumns.TabIndex = 2;
            this.lblColumns.Text = "Columns";
            // 
            // upDownColumns
            // 
            this.upDownColumns.Location = new System.Drawing.Point(81, 160);
            this.upDownColumns.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.upDownColumns.Name = "upDownColumns";
            this.upDownColumns.Size = new System.Drawing.Size(120, 20);
            this.upDownColumns.TabIndex = 3;
            this.upDownColumns.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // grpLabelSize
            // 
            this.grpLabelSize.Controls.Add(this.upDownLabelVGap);
            this.grpLabelSize.Controls.Add(this.upDownLabelHGap);
            this.grpLabelSize.Controls.Add(this.upDownLabelHeight);
            this.grpLabelSize.Controls.Add(this.upDownLabelWidth);
            this.grpLabelSize.Controls.Add(this.label5);
            this.grpLabelSize.Controls.Add(this.label6);
            this.grpLabelSize.Controls.Add(this.label7);
            this.grpLabelSize.Controls.Add(this.label8);
            this.grpLabelSize.Location = new System.Drawing.Point(217, 19);
            this.grpLabelSize.Name = "grpLabelSize";
            this.grpLabelSize.Size = new System.Drawing.Size(201, 134);
            this.grpLabelSize.TabIndex = 1;
            this.grpLabelSize.TabStop = false;
            this.grpLabelSize.Text = "Label Size";
            // 
            // upDownLabelVGap
            // 
            this.upDownLabelVGap.DecimalPlaces = 1;
            this.upDownLabelVGap.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownLabelVGap.Location = new System.Drawing.Point(85, 99);
            this.upDownLabelVGap.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            65536});
            this.upDownLabelVGap.Name = "upDownLabelVGap";
            this.upDownLabelVGap.Size = new System.Drawing.Size(110, 20);
            this.upDownLabelVGap.SizeValue = "mm";
            this.upDownLabelVGap.TabIndex = 7;
            // 
            // upDownLabelHGap
            // 
            this.upDownLabelHGap.DecimalPlaces = 1;
            this.upDownLabelHGap.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownLabelHGap.Location = new System.Drawing.Point(85, 71);
            this.upDownLabelHGap.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            65536});
            this.upDownLabelHGap.Name = "upDownLabelHGap";
            this.upDownLabelHGap.Size = new System.Drawing.Size(110, 20);
            this.upDownLabelHGap.SizeValue = "mm";
            this.upDownLabelHGap.TabIndex = 5;
            this.upDownLabelHGap.Value = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            // 
            // upDownLabelHeight
            // 
            this.upDownLabelHeight.DecimalPlaces = 1;
            this.upDownLabelHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownLabelHeight.Location = new System.Drawing.Point(85, 45);
            this.upDownLabelHeight.Minimum = new decimal(new int[] {
            35,
            0,
            0,
            65536});
            this.upDownLabelHeight.Name = "upDownLabelHeight";
            this.upDownLabelHeight.Size = new System.Drawing.Size(110, 20);
            this.upDownLabelHeight.SizeValue = "mm";
            this.upDownLabelHeight.TabIndex = 3;
            this.upDownLabelHeight.Value = new decimal(new int[] {
            466,
            0,
            0,
            65536});
            // 
            // upDownLabelWidth
            // 
            this.upDownLabelWidth.DecimalPlaces = 1;
            this.upDownLabelWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownLabelWidth.Location = new System.Drawing.Point(85, 18);
            this.upDownLabelWidth.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.upDownLabelWidth.Name = "upDownLabelWidth";
            this.upDownLabelWidth.Size = new System.Drawing.Size(110, 20);
            this.upDownLabelWidth.SizeValue = "mm";
            this.upDownLabelWidth.TabIndex = 1;
            this.upDownLabelWidth.Value = new decimal(new int[] {
            655,
            0,
            0,
            65536});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Vertical Gap";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Horizontal Gap";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Height";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Width";
            // 
            // gbPageMargins
            // 
            this.gbPageMargins.Controls.Add(this.upDownMarginRight);
            this.gbPageMargins.Controls.Add(this.upDownMarginLeft);
            this.gbPageMargins.Controls.Add(this.upDownMarginBottom);
            this.gbPageMargins.Controls.Add(this.upDownMarginTop);
            this.gbPageMargins.Controls.Add(this.lblMarginRight);
            this.gbPageMargins.Controls.Add(this.lblMarginLeft);
            this.gbPageMargins.Controls.Add(this.label4);
            this.gbPageMargins.Controls.Add(this.label3);
            this.gbPageMargins.Location = new System.Drawing.Point(6, 19);
            this.gbPageMargins.Name = "gbPageMargins";
            this.gbPageMargins.Size = new System.Drawing.Size(201, 134);
            this.gbPageMargins.TabIndex = 0;
            this.gbPageMargins.TabStop = false;
            this.gbPageMargins.Text = "Page Margins";
            // 
            // upDownMarginRight
            // 
            this.upDownMarginRight.DecimalPlaces = 1;
            this.upDownMarginRight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownMarginRight.Location = new System.Drawing.Point(75, 99);
            this.upDownMarginRight.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            65536});
            this.upDownMarginRight.Minimum = new decimal(new int[] {
            35,
            0,
            0,
            65536});
            this.upDownMarginRight.Name = "upDownMarginRight";
            this.upDownMarginRight.Size = new System.Drawing.Size(120, 20);
            this.upDownMarginRight.SizeValue = "mm";
            this.upDownMarginRight.TabIndex = 7;
            this.upDownMarginRight.Value = new decimal(new int[] {
            72,
            0,
            0,
            65536});
            // 
            // upDownMarginLeft
            // 
            this.upDownMarginLeft.DecimalPlaces = 1;
            this.upDownMarginLeft.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownMarginLeft.Location = new System.Drawing.Point(75, 71);
            this.upDownMarginLeft.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            65536});
            this.upDownMarginLeft.Minimum = new decimal(new int[] {
            35,
            0,
            0,
            65536});
            this.upDownMarginLeft.Name = "upDownMarginLeft";
            this.upDownMarginLeft.Size = new System.Drawing.Size(120, 20);
            this.upDownMarginLeft.SizeValue = "mm";
            this.upDownMarginLeft.TabIndex = 5;
            this.upDownMarginLeft.Value = new decimal(new int[] {
            72,
            0,
            0,
            65536});
            // 
            // upDownMarginBottom
            // 
            this.upDownMarginBottom.DecimalPlaces = 1;
            this.upDownMarginBottom.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownMarginBottom.Location = new System.Drawing.Point(75, 45);
            this.upDownMarginBottom.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            65536});
            this.upDownMarginBottom.Minimum = new decimal(new int[] {
            35,
            0,
            0,
            65536});
            this.upDownMarginBottom.Name = "upDownMarginBottom";
            this.upDownMarginBottom.Size = new System.Drawing.Size(120, 20);
            this.upDownMarginBottom.SizeValue = "mm";
            this.upDownMarginBottom.TabIndex = 3;
            this.upDownMarginBottom.Value = new decimal(new int[] {
            151,
            0,
            0,
            65536});
            // 
            // upDownMarginTop
            // 
            this.upDownMarginTop.DecimalPlaces = 1;
            this.upDownMarginTop.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownMarginTop.Location = new System.Drawing.Point(75, 18);
            this.upDownMarginTop.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            65536});
            this.upDownMarginTop.Minimum = new decimal(new int[] {
            35,
            0,
            0,
            65536});
            this.upDownMarginTop.Name = "upDownMarginTop";
            this.upDownMarginTop.Size = new System.Drawing.Size(120, 20);
            this.upDownMarginTop.SizeValue = "mm";
            this.upDownMarginTop.TabIndex = 1;
            this.upDownMarginTop.Value = new decimal(new int[] {
            151,
            0,
            0,
            65536});
            // 
            // lblMarginRight
            // 
            this.lblMarginRight.AutoSize = true;
            this.lblMarginRight.Location = new System.Drawing.Point(6, 101);
            this.lblMarginRight.Name = "lblMarginRight";
            this.lblMarginRight.Size = new System.Drawing.Size(32, 13);
            this.lblMarginRight.TabIndex = 6;
            this.lblMarginRight.Text = "Right";
            // 
            // lblMarginLeft
            // 
            this.lblMarginLeft.AutoSize = true;
            this.lblMarginLeft.Location = new System.Drawing.Point(6, 73);
            this.lblMarginLeft.Name = "lblMarginLeft";
            this.lblMarginLeft.Size = new System.Drawing.Size(25, 13);
            this.lblMarginLeft.TabIndex = 4;
            this.lblMarginLeft.Text = "Left";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Bottom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Top";
            // 
            // pbGenerateLabels
            // 
            this.pbGenerateLabels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbGenerateLabels.Location = new System.Drawing.Point(19, 249);
            this.pbGenerateLabels.Name = "pbGenerateLabels";
            this.pbGenerateLabels.Size = new System.Drawing.Size(237, 23);
            this.pbGenerateLabels.TabIndex = 11;
            this.pbGenerateLabels.Visible = false;
            // 
            // lblLabelGeneration
            // 
            this.lblLabelGeneration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLabelGeneration.AutoSize = true;
            this.lblLabelGeneration.Location = new System.Drawing.Point(19, 230);
            this.lblLabelGeneration.Name = "lblLabelGeneration";
            this.lblLabelGeneration.Size = new System.Drawing.Size(93, 13);
            this.lblLabelGeneration.TabIndex = 10;
            this.lblLabelGeneration.Text = "Generating Labels";
            this.lblLabelGeneration.Visible = false;
            // 
            // pbOverall
            // 
            this.pbOverall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbOverall.Location = new System.Drawing.Point(19, 279);
            this.pbOverall.Maximum = 18;
            this.pbOverall.Name = "pbOverall";
            this.pbOverall.Size = new System.Drawing.Size(237, 23);
            this.pbOverall.TabIndex = 12;
            this.pbOverall.Visible = false;
            // 
            // cmbBarcodeType
            // 
            this.cmbBarcodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBarcodeType.FormattingEnabled = true;
            this.cmbBarcodeType.Items.AddRange(new object[] {
            "2D Barcode",
            "2 of 5 - 1D Barcode",
            "3 of 9 - 1D Barcode"});
            this.cmbBarcodeType.Location = new System.Drawing.Point(19, 115);
            this.cmbBarcodeType.Name = "cmbBarcodeType";
            this.cmbBarcodeType.Size = new System.Drawing.Size(237, 21);
            this.cmbBarcodeType.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Barcode Type";
            // 
            // CreateVouchers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 342);
            this.Controls.Add(this.cmbBarcodeType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pbOverall);
            this.Controls.Add(this.lblLabelGeneration);
            this.Controls.Add(this.pbGenerateLabels);
            this.Controls.Add(this.gbCustomLabel);
            this.Controls.Add(this.cbCustomLabel);
            this.Controls.Add(this.cbShowLines);
            this.Controls.Add(this.cbTestPrinting);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreateLabels);
            this.Controls.Add(this.cmbVoucherAmount);
            this.Controls.Add(this.cmbLabelSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateVouchers";
            this.Text = "Create Voucher Codes";
            this.gbCustomLabel.ResumeLayout(false);
            this.gbCustomLabel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownColumns)).EndInit();
            this.grpLabelSize.ResumeLayout(false);
            this.grpLabelSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownLabelVGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownLabelHGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownLabelHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownLabelWidth)).EndInit();
            this.gbPageMargins.ResumeLayout(false);
            this.gbPageMargins.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownMarginRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownMarginLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownMarginBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownMarginTop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLabelSize;
        private System.Windows.Forms.ComboBox cmbVoucherAmount;
        private System.Windows.Forms.Button btnCreateLabels;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox cbTestPrinting;
        private System.Windows.Forms.CheckBox cbShowLines;
        private System.Windows.Forms.CheckBox cbCustomLabel;
        private System.Windows.Forms.GroupBox gbCustomLabel;
        private System.Windows.Forms.GroupBox gbPageMargins;
        private System.Windows.Forms.Label lblMarginRight;
        private System.Windows.Forms.Label lblMarginLeft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Controls.NumericUpDownEx upDownMarginTop;
        private Controls.NumericUpDownEx upDownMarginRight;
        private Controls.NumericUpDownEx upDownMarginLeft;
        private Controls.NumericUpDownEx upDownMarginBottom;
        private System.Windows.Forms.GroupBox grpLabelSize;
        private Controls.NumericUpDownEx upDownLabelVGap;
        private Controls.NumericUpDownEx upDownLabelHGap;
        private Controls.NumericUpDownEx upDownLabelHeight;
        private Controls.NumericUpDownEx upDownLabelWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.NumericUpDown upDownRows;
        private System.Windows.Forms.Label lblColumns;
        private System.Windows.Forms.NumericUpDown upDownColumns;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ProgressBar pbGenerateLabels;
        private System.Windows.Forms.Label lblLabelGeneration;
        private System.Windows.Forms.ProgressBar pbOverall;
        private System.Windows.Forms.ComboBox cmbBarcodeType;
        private System.Windows.Forms.Label label9;
    }
}