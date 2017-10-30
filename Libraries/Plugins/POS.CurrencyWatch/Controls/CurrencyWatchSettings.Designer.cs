namespace POS.CurrencyWatch.Controls
{
    partial class CurrencyWatchSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrencyWatchSettings));
            this.lblBaseCurrency = new System.Windows.Forms.Label();
            this.lstCurrencies = new System.Windows.Forms.ComboBox();
            this.lblUpdateEvery = new System.Windows.Forms.Label();
            this.udUpdateMinutes = new System.Windows.Forms.NumericUpDown();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.lblAvailableCurrencies = new System.Windows.Forms.Label();
            this.lvCurrencies = new SharedControls.Classes.ListViewEx();
            this.colHeaderWatch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderCurrency = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderPrimary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.udUpdateMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBaseCurrency
            // 
            this.lblBaseCurrency.AutoSize = true;
            this.lblBaseCurrency.Location = new System.Drawing.Point(3, 7);
            this.lblBaseCurrency.Name = "lblBaseCurrency";
            this.lblBaseCurrency.Size = new System.Drawing.Size(76, 13);
            this.lblBaseCurrency.TabIndex = 0;
            this.lblBaseCurrency.Text = "Base Currency";
            // 
            // lstCurrencies
            // 
            this.lstCurrencies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstCurrencies.FormattingEnabled = true;
            this.lstCurrencies.Location = new System.Drawing.Point(129, 4);
            this.lstCurrencies.Name = "lstCurrencies";
            this.lstCurrencies.Size = new System.Drawing.Size(328, 21);
            this.lstCurrencies.TabIndex = 1;
            this.lstCurrencies.SelectedIndexChanged += new System.EventHandler(this.lstCurrencies_SelectedIndexChanged);
            this.lstCurrencies.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstCurrencies_Format);
            // 
            // lblUpdateEvery
            // 
            this.lblUpdateEvery.AutoSize = true;
            this.lblUpdateEvery.Location = new System.Drawing.Point(3, 50);
            this.lblUpdateEvery.Name = "lblUpdateEvery";
            this.lblUpdateEvery.Size = new System.Drawing.Size(72, 13);
            this.lblUpdateEvery.TabIndex = 2;
            this.lblUpdateEvery.Text = "Update Every";
            // 
            // udUpdateMinutes
            // 
            this.udUpdateMinutes.Location = new System.Drawing.Point(129, 48);
            this.udUpdateMinutes.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.udUpdateMinutes.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udUpdateMinutes.Name = "udUpdateMinutes";
            this.udUpdateMinutes.Size = new System.Drawing.Size(83, 20);
            this.udUpdateMinutes.TabIndex = 3;
            this.udUpdateMinutes.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Location = new System.Drawing.Point(218, 50);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(44, 13);
            this.lblMinutes.TabIndex = 4;
            this.lblMinutes.Text = "Minutes";
            // 
            // lblAvailableCurrencies
            // 
            this.lblAvailableCurrencies.AutoSize = true;
            this.lblAvailableCurrencies.Location = new System.Drawing.Point(3, 89);
            this.lblAvailableCurrencies.Name = "lblAvailableCurrencies";
            this.lblAvailableCurrencies.Size = new System.Drawing.Size(103, 13);
            this.lblAvailableCurrencies.TabIndex = 6;
            this.lblAvailableCurrencies.Text = "Available Currencies";
            // 
            // lvCurrencies
            // 
            this.lvCurrencies.CheckBoxes = true;
            this.lvCurrencies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderWatch,
            this.colHeaderCurrency,
            this.colHeaderName,
            this.colHeaderPrimary});
            this.lvCurrencies.FullRowSelect = true;
            this.lvCurrencies.Location = new System.Drawing.Point(6, 105);
            this.lvCurrencies.Name = "lvCurrencies";
            this.lvCurrencies.Size = new System.Drawing.Size(451, 235);
            this.lvCurrencies.TabIndex = 7;
            this.lvCurrencies.UseCompatibleStateImageBehavior = false;
            this.lvCurrencies.View = System.Windows.Forms.View.Details;
            this.lvCurrencies.DoubleClick += new System.EventHandler(this.lvCurrencies_DoubleClick);
            // 
            // colHeaderWatch
            // 
            this.colHeaderWatch.Text = "Watch";
            // 
            // colHeaderCurrency
            // 
            this.colHeaderCurrency.Text = "Currency";
            this.colHeaderCurrency.Width = 70;
            // 
            // colHeaderName
            // 
            this.colHeaderName.Text = "Name";
            this.colHeaderName.Width = 250;
            // 
            // colHeaderPrimary
            // 
            this.colHeaderPrimary.Text = "Primary";
            // 
            // CurrencyWatchSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvCurrencies);
            this.Controls.Add(this.lblAvailableCurrencies);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.udUpdateMinutes);
            this.Controls.Add(this.lblUpdateEvery);
            this.Controls.Add(this.lstCurrencies);
            this.Controls.Add(this.lblBaseCurrency);
            this.Name = "CurrencyWatchSettings";
            ((System.ComponentModel.ISupportInitialize)(this.udUpdateMinutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBaseCurrency;
        private System.Windows.Forms.ComboBox lstCurrencies;
        private System.Windows.Forms.Label lblUpdateEvery;
        private System.Windows.Forms.NumericUpDown udUpdateMinutes;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Label lblAvailableCurrencies;
        private SharedControls.Classes.ListViewEx lvCurrencies;
        private System.Windows.Forms.ColumnHeader colHeaderWatch;
        private System.Windows.Forms.ColumnHeader colHeaderCurrency;
        private System.Windows.Forms.ColumnHeader colHeaderName;
        private System.Windows.Forms.ColumnHeader colHeaderPrimary;
    }
}
