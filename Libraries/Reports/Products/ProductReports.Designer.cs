namespace Reports.Products
{
    partial class ProductReportsForm
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
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.lblReportType = new System.Windows.Forms.Label();
            this.lblNumberOfDays = new System.Windows.Forms.Label();
            this.udDays = new System.Windows.Forms.NumericUpDown();
            this.btnView = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.udDays)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(13, 29);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(259, 21);
            this.cmbReportType.TabIndex = 1;
            this.cmbReportType.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbReportType_Format);
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Location = new System.Drawing.Point(13, 13);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(35, 13);
            this.lblReportType.TabIndex = 0;
            this.lblReportType.Text = "label1";
            // 
            // lblNumberOfDays
            // 
            this.lblNumberOfDays.AutoSize = true;
            this.lblNumberOfDays.Location = new System.Drawing.Point(13, 63);
            this.lblNumberOfDays.Name = "lblNumberOfDays";
            this.lblNumberOfDays.Size = new System.Drawing.Size(35, 13);
            this.lblNumberOfDays.TabIndex = 2;
            this.lblNumberOfDays.Text = "label2";
            // 
            // udDays
            // 
            this.udDays.Location = new System.Drawing.Point(13, 79);
            this.udDays.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.udDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udDays.Name = "udDays";
            this.udDays.Size = new System.Drawing.Size(88, 20);
            this.udDays.TabIndex = 3;
            this.udDays.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(197, 226);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "button1";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // ProductReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.udDays);
            this.Controls.Add(this.lblNumberOfDays);
            this.Controls.Add(this.lblReportType);
            this.Controls.Add(this.cmbReportType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductReportsForm";
            this.ShowIcon = false;
            this.Text = "ProductReports";
            ((System.ComponentModel.ISupportInitialize)(this.udDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.Label lblNumberOfDays;
        private System.Windows.Forms.NumericUpDown udDays;
        private System.Windows.Forms.Button btnView;
    }
}