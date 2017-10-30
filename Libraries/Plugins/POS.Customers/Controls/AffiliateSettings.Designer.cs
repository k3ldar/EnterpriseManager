namespace POS.Customers.Controls
{
    partial class AffiliateSettings
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
            this.lblURL = new System.Windows.Forms.Label();
            this.cbGenerateExternal = new System.Windows.Forms.CheckBox();
            this.lblMaxDays = new System.Windows.Forms.Label();
            this.udMaxDays = new System.Windows.Forms.NumericUpDown();
            this.dtpYearly = new System.Windows.Forms.DateTimePicker();
            this.lblWaitDescription = new System.Windows.Forms.Label();
            this.udMonthsToWait = new System.Windows.Forms.NumericUpDown();
            this.lblWait = new System.Windows.Forms.Label();
            this.rbYearlyPayments = new System.Windows.Forms.RadioButton();
            this.rbContinuousPayments = new System.Windows.Forms.RadioButton();
            this.cmbWebsites = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMonthsToWait)).BeginInit();
            this.SuspendLayout();
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(4, 4);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(35, 13);
            this.lblURL.TabIndex = 0;
            this.lblURL.Text = "label1";
            // 
            // cbGenerateExternal
            // 
            this.cbGenerateExternal.AutoSize = true;
            this.cbGenerateExternal.Location = new System.Drawing.Point(7, 63);
            this.cbGenerateExternal.Name = "cbGenerateExternal";
            this.cbGenerateExternal.Size = new System.Drawing.Size(80, 17);
            this.cbGenerateExternal.TabIndex = 2;
            this.cbGenerateExternal.Text = "checkBox1";
            this.cbGenerateExternal.UseVisualStyleBackColor = true;
            // 
            // lblMaxDays
            // 
            this.lblMaxDays.AutoSize = true;
            this.lblMaxDays.Location = new System.Drawing.Point(7, 103);
            this.lblMaxDays.Name = "lblMaxDays";
            this.lblMaxDays.Size = new System.Drawing.Size(35, 13);
            this.lblMaxDays.TabIndex = 3;
            this.lblMaxDays.Text = "label1";
            // 
            // udMaxDays
            // 
            this.udMaxDays.Location = new System.Drawing.Point(10, 120);
            this.udMaxDays.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.udMaxDays.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.udMaxDays.Name = "udMaxDays";
            this.udMaxDays.Size = new System.Drawing.Size(120, 20);
            this.udMaxDays.TabIndex = 4;
            this.udMaxDays.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // dtpYearly
            // 
            this.dtpYearly.CustomFormat = "dd MMMM";
            this.dtpYearly.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYearly.Location = new System.Drawing.Point(33, 220);
            this.dtpYearly.Name = "dtpYearly";
            this.dtpYearly.Size = new System.Drawing.Size(179, 20);
            this.dtpYearly.TabIndex = 7;
            // 
            // lblWaitDescription
            // 
            this.lblWaitDescription.AutoSize = true;
            this.lblWaitDescription.Location = new System.Drawing.Point(163, 278);
            this.lblWaitDescription.Name = "lblWaitDescription";
            this.lblWaitDescription.Size = new System.Drawing.Size(35, 13);
            this.lblWaitDescription.TabIndex = 10;
            this.lblWaitDescription.Text = "label2";
            // 
            // udMonthsToWait
            // 
            this.udMonthsToWait.Location = new System.Drawing.Point(70, 276);
            this.udMonthsToWait.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.udMonthsToWait.Name = "udMonthsToWait";
            this.udMonthsToWait.Size = new System.Drawing.Size(67, 20);
            this.udMonthsToWait.TabIndex = 9;
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.Location = new System.Drawing.Point(16, 278);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(29, 13);
            this.lblWait.TabIndex = 8;
            this.lblWait.Text = "Wait";
            // 
            // rbYearlyPayments
            // 
            this.rbYearlyPayments.AutoSize = true;
            this.rbYearlyPayments.Location = new System.Drawing.Point(10, 196);
            this.rbYearlyPayments.Name = "rbYearlyPayments";
            this.rbYearlyPayments.Size = new System.Drawing.Size(85, 17);
            this.rbYearlyPayments.TabIndex = 6;
            this.rbYearlyPayments.TabStop = true;
            this.rbYearlyPayments.Text = "radioButton2";
            this.rbYearlyPayments.UseVisualStyleBackColor = true;
            // 
            // rbContinuousPayments
            // 
            this.rbContinuousPayments.AutoSize = true;
            this.rbContinuousPayments.Location = new System.Drawing.Point(10, 168);
            this.rbContinuousPayments.Name = "rbContinuousPayments";
            this.rbContinuousPayments.Size = new System.Drawing.Size(85, 17);
            this.rbContinuousPayments.TabIndex = 5;
            this.rbContinuousPayments.TabStop = true;
            this.rbContinuousPayments.Text = "radioButton1";
            this.rbContinuousPayments.UseVisualStyleBackColor = true;
            // 
            // cmbWebsites
            // 
            this.cmbWebsites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWebsites.FormattingEnabled = true;
            this.cmbWebsites.Location = new System.Drawing.Point(7, 21);
            this.cmbWebsites.Name = "cmbWebsites";
            this.cmbWebsites.Size = new System.Drawing.Size(450, 21);
            this.cmbWebsites.TabIndex = 1;
            // 
            // AffiliateSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbWebsites);
            this.Controls.Add(this.dtpYearly);
            this.Controls.Add(this.lblWaitDescription);
            this.Controls.Add(this.udMonthsToWait);
            this.Controls.Add(this.lblWait);
            this.Controls.Add(this.rbYearlyPayments);
            this.Controls.Add(this.rbContinuousPayments);
            this.Controls.Add(this.udMaxDays);
            this.Controls.Add(this.lblMaxDays);
            this.Controls.Add(this.cbGenerateExternal);
            this.Controls.Add(this.lblURL);
            this.Name = "AffiliateSettings";
            ((System.ComponentModel.ISupportInitialize)(this.udMaxDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMonthsToWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.CheckBox cbGenerateExternal;
        private System.Windows.Forms.Label lblMaxDays;
        private System.Windows.Forms.NumericUpDown udMaxDays;
        private System.Windows.Forms.DateTimePicker dtpYearly;
        private System.Windows.Forms.Label lblWaitDescription;
        private System.Windows.Forms.NumericUpDown udMonthsToWait;
        private System.Windows.Forms.Label lblWait;
        private System.Windows.Forms.RadioButton rbYearlyPayments;
        private System.Windows.Forms.RadioButton rbContinuousPayments;
        private System.Windows.Forms.ComboBox cmbWebsites;
    }
}
