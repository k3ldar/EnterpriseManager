namespace POS.WebsiteAdministration.Forms.CountryAdmin
{
    partial class AdminEditCountries
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
            this.gbCountry = new System.Windows.Forms.GroupBox();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.txtLanguageName = new System.Windows.Forms.TextBox();
            this.lblLanguageName = new System.Windows.Forms.Label();
            this.cmbLocalizedCulture = new System.Windows.Forms.ComboBox();
            this.lblDefaultCurrency = new System.Windows.Forms.Label();
            this.btnAddress = new System.Windows.Forms.Button();
            this.cbCanLocalize = new System.Windows.Forms.CheckBox();
            this.lblCurrencySymbol = new System.Windows.Forms.Label();
            this.txtCurrencySymbol = new System.Windows.Forms.TextBox();
            this.gbPriceOptions = new System.Windows.Forms.GroupBox();
            this.rbPrice3 = new System.Windows.Forms.RadioButton();
            this.rbPrice2 = new System.Windows.Forms.RadioButton();
            this.rbPrice1 = new System.Windows.Forms.RadioButton();
            this.txtVATRate = new System.Windows.Forms.TextBox();
            this.lblTaxRate = new System.Windows.Forms.Label();
            this.txtCostMultiplier = new System.Windows.Forms.TextBox();
            this.txtCurrencyConversion = new System.Windows.Forms.TextBox();
            this.txtShipping = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.spnSortOrder = new System.Windows.Forms.NumericUpDown();
            this.lblCostMultiplier = new System.Windows.Forms.Label();
            this.cbShowPrices = new System.Windows.Forms.CheckBox();
            this.lblCurrencyConversionRate = new System.Windows.Forms.Label();
            this.lblShippingCosts = new System.Windows.Forms.Label();
            this.lblSortOrder = new System.Windows.Forms.Label();
            this.lstCountries = new System.Windows.Forms.ListBox();
            this.lblDefaultTaxRate = new System.Windows.Forms.Label();
            this.udDefaultTax = new System.Windows.Forms.NumericUpDown();
            this.gbCountry.SuspendLayout();
            this.gbPriceOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnSortOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udDefaultTax)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCountry
            // 
            this.gbCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbCountry.Controls.Add(this.cmbCurrency);
            this.gbCountry.Controls.Add(this.txtLanguageName);
            this.gbCountry.Controls.Add(this.lblLanguageName);
            this.gbCountry.Controls.Add(this.cmbLocalizedCulture);
            this.gbCountry.Controls.Add(this.lblDefaultCurrency);
            this.gbCountry.Controls.Add(this.btnAddress);
            this.gbCountry.Controls.Add(this.cbCanLocalize);
            this.gbCountry.Controls.Add(this.lblCurrencySymbol);
            this.gbCountry.Controls.Add(this.txtCurrencySymbol);
            this.gbCountry.Controls.Add(this.gbPriceOptions);
            this.gbCountry.Controls.Add(this.txtVATRate);
            this.gbCountry.Controls.Add(this.lblTaxRate);
            this.gbCountry.Controls.Add(this.txtCostMultiplier);
            this.gbCountry.Controls.Add(this.txtCurrencyConversion);
            this.gbCountry.Controls.Add(this.txtShipping);
            this.gbCountry.Controls.Add(this.lblDescription);
            this.gbCountry.Controls.Add(this.spnSortOrder);
            this.gbCountry.Controls.Add(this.lblCostMultiplier);
            this.gbCountry.Controls.Add(this.cbShowPrices);
            this.gbCountry.Controls.Add(this.lblCurrencyConversionRate);
            this.gbCountry.Controls.Add(this.lblShippingCosts);
            this.gbCountry.Controls.Add(this.lblSortOrder);
            this.gbCountry.Controls.Add(this.lstCountries);
            this.gbCountry.Location = new System.Drawing.Point(12, 12);
            this.gbCountry.Name = "gbCountry";
            this.gbCountry.Size = new System.Drawing.Size(697, 429);
            this.gbCountry.TabIndex = 0;
            this.gbCountry.TabStop = false;
            this.gbCountry.Text = "Country";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(324, 384);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(111, 21);
            this.cmbCurrency.TabIndex = 23;
            this.cmbCurrency.SelectedIndexChanged += new System.EventHandler(this.cmbCurrency_SelectedIndexChanged);
            this.cmbCurrency.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbCurrency_Format);
            // 
            // txtLanguageName
            // 
            this.txtLanguageName.Location = new System.Drawing.Point(575, 364);
            this.txtLanguageName.MaxLength = 40;
            this.txtLanguageName.Name = "txtLanguageName";
            this.txtLanguageName.Size = new System.Drawing.Size(116, 20);
            this.txtLanguageName.TabIndex = 18;
            this.txtLanguageName.TextChanged += new System.EventHandler(this.value_Changed);
            // 
            // lblLanguageName
            // 
            this.lblLanguageName.AutoSize = true;
            this.lblLanguageName.Location = new System.Drawing.Point(574, 348);
            this.lblLanguageName.Name = "lblLanguageName";
            this.lblLanguageName.Size = new System.Drawing.Size(86, 13);
            this.lblLanguageName.TabIndex = 17;
            this.lblLanguageName.Text = "Language Name";
            // 
            // cmbLocalizedCulture
            // 
            this.cmbLocalizedCulture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalizedCulture.FormattingEnabled = true;
            this.cmbLocalizedCulture.Location = new System.Drawing.Point(576, 321);
            this.cmbLocalizedCulture.Name = "cmbLocalizedCulture";
            this.cmbLocalizedCulture.Size = new System.Drawing.Size(115, 21);
            this.cmbLocalizedCulture.TabIndex = 16;
            this.cmbLocalizedCulture.SelectedIndexChanged += new System.EventHandler(this.cmbLocalizedCulture_SelectedIndexChanged);
            // 
            // lblDefaultCurrency
            // 
            this.lblDefaultCurrency.AutoSize = true;
            this.lblDefaultCurrency.Location = new System.Drawing.Point(321, 368);
            this.lblDefaultCurrency.Name = "lblDefaultCurrency";
            this.lblDefaultCurrency.Size = new System.Drawing.Size(86, 13);
            this.lblDefaultCurrency.TabIndex = 19;
            this.lblDefaultCurrency.Text = "Default Currency";
            // 
            // btnAddress
            // 
            this.btnAddress.Location = new System.Drawing.Point(441, 382);
            this.btnAddress.Name = "btnAddress";
            this.btnAddress.Size = new System.Drawing.Size(114, 23);
            this.btnAddress.TabIndex = 21;
            this.btnAddress.Text = "Address";
            this.btnAddress.UseVisualStyleBackColor = true;
            this.btnAddress.Click += new System.EventHandler(this.btnAddress_Click);
            // 
            // cbCanLocalize
            // 
            this.cbCanLocalize.AutoSize = true;
            this.cbCanLocalize.Location = new System.Drawing.Point(575, 298);
            this.cbCanLocalize.Name = "cbCanLocalize";
            this.cbCanLocalize.Size = new System.Drawing.Size(65, 17);
            this.cbCanLocalize.TabIndex = 15;
            this.cbCanLocalize.Text = "Localize";
            this.cbCanLocalize.UseVisualStyleBackColor = true;
            this.cbCanLocalize.CheckedChanged += new System.EventHandler(this.cbCanLocalize_CheckedChanged);
            // 
            // lblCurrencySymbol
            // 
            this.lblCurrencySymbol.AutoSize = true;
            this.lblCurrencySymbol.Location = new System.Drawing.Point(574, 248);
            this.lblCurrencySymbol.Name = "lblCurrencySymbol";
            this.lblCurrencySymbol.Size = new System.Drawing.Size(86, 13);
            this.lblCurrencySymbol.TabIndex = 13;
            this.lblCurrencySymbol.Text = "Currency Symbol";
            // 
            // txtCurrencySymbol
            // 
            this.txtCurrencySymbol.Location = new System.Drawing.Point(576, 267);
            this.txtCurrencySymbol.MaxLength = 20;
            this.txtCurrencySymbol.Name = "txtCurrencySymbol";
            this.txtCurrencySymbol.Size = new System.Drawing.Size(115, 20);
            this.txtCurrencySymbol.TabIndex = 14;
            this.txtCurrencySymbol.TextChanged += new System.EventHandler(this.value_Changed);
            // 
            // gbPriceOptions
            // 
            this.gbPriceOptions.Controls.Add(this.rbPrice3);
            this.gbPriceOptions.Controls.Add(this.rbPrice2);
            this.gbPriceOptions.Controls.Add(this.rbPrice1);
            this.gbPriceOptions.Location = new System.Drawing.Point(321, 255);
            this.gbPriceOptions.Name = "gbPriceOptions";
            this.gbPriceOptions.Size = new System.Drawing.Size(247, 106);
            this.gbPriceOptions.TabIndex = 12;
            this.gbPriceOptions.TabStop = false;
            this.gbPriceOptions.Text = "Price Option";
            // 
            // rbPrice3
            // 
            this.rbPrice3.AutoSize = true;
            this.rbPrice3.Location = new System.Drawing.Point(7, 66);
            this.rbPrice3.Name = "rbPrice3";
            this.rbPrice3.Size = new System.Drawing.Size(31, 17);
            this.rbPrice3.TabIndex = 2;
            this.rbPrice3.TabStop = true;
            this.rbPrice3.Text = "3";
            this.rbPrice3.UseVisualStyleBackColor = true;
            this.rbPrice3.CheckedChanged += new System.EventHandler(this.value_Changed);
            // 
            // rbPrice2
            // 
            this.rbPrice2.AutoSize = true;
            this.rbPrice2.Location = new System.Drawing.Point(7, 43);
            this.rbPrice2.Name = "rbPrice2";
            this.rbPrice2.Size = new System.Drawing.Size(31, 17);
            this.rbPrice2.TabIndex = 1;
            this.rbPrice2.TabStop = true;
            this.rbPrice2.Text = "2";
            this.rbPrice2.UseVisualStyleBackColor = true;
            this.rbPrice2.CheckedChanged += new System.EventHandler(this.value_Changed);
            // 
            // rbPrice1
            // 
            this.rbPrice1.AutoSize = true;
            this.rbPrice1.Location = new System.Drawing.Point(7, 20);
            this.rbPrice1.Name = "rbPrice1";
            this.rbPrice1.Size = new System.Drawing.Size(31, 17);
            this.rbPrice1.TabIndex = 0;
            this.rbPrice1.TabStop = true;
            this.rbPrice1.Text = "1";
            this.rbPrice1.UseVisualStyleBackColor = true;
            this.rbPrice1.CheckedChanged += new System.EventHandler(this.value_Changed);
            // 
            // txtVATRate
            // 
            this.txtVATRate.Location = new System.Drawing.Point(323, 205);
            this.txtVATRate.Name = "txtVATRate";
            this.txtVATRate.Size = new System.Drawing.Size(131, 20);
            this.txtVATRate.TabIndex = 10;
            this.txtVATRate.TextChanged += new System.EventHandler(this.value_Changed);
            // 
            // lblTaxRate
            // 
            this.lblTaxRate.AutoSize = true;
            this.lblTaxRate.Location = new System.Drawing.Point(323, 189);
            this.lblTaxRate.Name = "lblTaxRate";
            this.lblTaxRate.Size = new System.Drawing.Size(54, 13);
            this.lblTaxRate.TabIndex = 9;
            this.lblTaxRate.Text = "TAX Rate";
            // 
            // txtCostMultiplier
            // 
            this.txtCostMultiplier.Location = new System.Drawing.Point(323, 163);
            this.txtCostMultiplier.Name = "txtCostMultiplier";
            this.txtCostMultiplier.Size = new System.Drawing.Size(131, 20);
            this.txtCostMultiplier.TabIndex = 8;
            this.txtCostMultiplier.Visible = false;
            this.txtCostMultiplier.TextChanged += new System.EventHandler(this.value_Changed);
            // 
            // txtCurrencyConversion
            // 
            this.txtCurrencyConversion.Location = new System.Drawing.Point(323, 121);
            this.txtCurrencyConversion.Name = "txtCurrencyConversion";
            this.txtCurrencyConversion.Size = new System.Drawing.Size(131, 20);
            this.txtCurrencyConversion.TabIndex = 6;
            this.txtCurrencyConversion.Visible = false;
            this.txtCurrencyConversion.TextChanged += new System.EventHandler(this.value_Changed);
            // 
            // txtShipping
            // 
            this.txtShipping.Location = new System.Drawing.Point(323, 81);
            this.txtShipping.Name = "txtShipping";
            this.txtShipping.Size = new System.Drawing.Size(131, 20);
            this.txtShipping.TabIndex = 4;
            this.txtShipping.TextChanged += new System.EventHandler(this.value_Changed);
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Location = new System.Drawing.Point(486, 19);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(205, 206);
            this.lblDescription.TabIndex = 22;
            // 
            // spnSortOrder
            // 
            this.spnSortOrder.Location = new System.Drawing.Point(323, 36);
            this.spnSortOrder.Name = "spnSortOrder";
            this.spnSortOrder.Size = new System.Drawing.Size(131, 20);
            this.spnSortOrder.TabIndex = 2;
            this.spnSortOrder.ValueChanged += new System.EventHandler(this.value_Changed);
            // 
            // lblCostMultiplier
            // 
            this.lblCostMultiplier.AutoSize = true;
            this.lblCostMultiplier.Location = new System.Drawing.Point(323, 146);
            this.lblCostMultiplier.Name = "lblCostMultiplier";
            this.lblCostMultiplier.Size = new System.Drawing.Size(72, 13);
            this.lblCostMultiplier.TabIndex = 7;
            this.lblCostMultiplier.Text = "Cost Multiplier";
            this.lblCostMultiplier.Visible = false;
            // 
            // cbShowPrices
            // 
            this.cbShowPrices.AutoSize = true;
            this.cbShowPrices.Location = new System.Drawing.Point(323, 231);
            this.cbShowPrices.Name = "cbShowPrices";
            this.cbShowPrices.Size = new System.Drawing.Size(85, 17);
            this.cbShowPrices.TabIndex = 11;
            this.cbShowPrices.Text = "Show Prices";
            this.cbShowPrices.UseVisualStyleBackColor = true;
            this.cbShowPrices.CheckedChanged += new System.EventHandler(this.value_Changed);
            this.cbShowPrices.TextChanged += new System.EventHandler(this.value_Changed);
            // 
            // lblCurrencyConversionRate
            // 
            this.lblCurrencyConversionRate.AutoSize = true;
            this.lblCurrencyConversionRate.Location = new System.Drawing.Point(323, 104);
            this.lblCurrencyConversionRate.Name = "lblCurrencyConversionRate";
            this.lblCurrencyConversionRate.Size = new System.Drawing.Size(131, 13);
            this.lblCurrencyConversionRate.TabIndex = 5;
            this.lblCurrencyConversionRate.Text = "Currency Conversion Rate";
            this.lblCurrencyConversionRate.Visible = false;
            // 
            // lblShippingCosts
            // 
            this.lblShippingCosts.AutoSize = true;
            this.lblShippingCosts.Location = new System.Drawing.Point(323, 64);
            this.lblShippingCosts.Name = "lblShippingCosts";
            this.lblShippingCosts.Size = new System.Drawing.Size(77, 13);
            this.lblShippingCosts.TabIndex = 3;
            this.lblShippingCosts.Text = "Shipping Costs";
            // 
            // lblSortOrder
            // 
            this.lblSortOrder.AutoSize = true;
            this.lblSortOrder.Location = new System.Drawing.Point(323, 19);
            this.lblSortOrder.Name = "lblSortOrder";
            this.lblSortOrder.Size = new System.Drawing.Size(55, 13);
            this.lblSortOrder.TabIndex = 1;
            this.lblSortOrder.Text = "Sort Order";
            // 
            // lstCountries
            // 
            this.lstCountries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstCountries.FormattingEnabled = true;
            this.lstCountries.Location = new System.Drawing.Point(6, 19);
            this.lstCountries.Name = "lstCountries";
            this.lstCountries.Size = new System.Drawing.Size(308, 394);
            this.lstCountries.TabIndex = 0;
            this.lstCountries.SelectedIndexChanged += new System.EventHandler(this.lstCountries_SelectedIndexChanged);
            this.lstCountries.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstCountries_Format);
            // 
            // lblDefaultTaxRate
            // 
            this.lblDefaultTaxRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDefaultTaxRate.AutoSize = true;
            this.lblDefaultTaxRate.Location = new System.Drawing.Point(14, 452);
            this.lblDefaultTaxRate.Name = "lblDefaultTaxRate";
            this.lblDefaultTaxRate.Size = new System.Drawing.Size(91, 13);
            this.lblDefaultTaxRate.TabIndex = 1;
            this.lblDefaultTaxRate.Text = "Default TAX Rate";
            // 
            // udDefaultTax
            // 
            this.udDefaultTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.udDefaultTax.DecimalPlaces = 2;
            this.udDefaultTax.Location = new System.Drawing.Point(154, 450);
            this.udDefaultTax.Name = "udDefaultTax";
            this.udDefaultTax.Size = new System.Drawing.Size(120, 20);
            this.udDefaultTax.TabIndex = 2;
            // 
            // AdminEditCountries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.udDefaultTax);
            this.Controls.Add(this.lblDefaultTaxRate);
            this.Controls.Add(this.gbCountry);
            this.Name = "AdminEditCountries";
            this.Size = new System.Drawing.Size(721, 480);
            this.gbCountry.ResumeLayout(false);
            this.gbCountry.PerformLayout();
            this.gbPriceOptions.ResumeLayout(false);
            this.gbPriceOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnSortOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udDefaultTax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCountry;
        private System.Windows.Forms.ListBox lstCountries;
        private System.Windows.Forms.NumericUpDown spnSortOrder;
        private System.Windows.Forms.Label lblCostMultiplier;
        private System.Windows.Forms.CheckBox cbShowPrices;
        private System.Windows.Forms.Label lblCurrencyConversionRate;
        private System.Windows.Forms.Label lblShippingCosts;
        private System.Windows.Forms.Label lblSortOrder;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtCostMultiplier;
        private System.Windows.Forms.TextBox txtCurrencyConversion;
        private System.Windows.Forms.TextBox txtShipping;
        private System.Windows.Forms.TextBox txtVATRate;
        private System.Windows.Forms.Label lblTaxRate;
        private System.Windows.Forms.Label lblDefaultTaxRate;
        private System.Windows.Forms.NumericUpDown udDefaultTax;
        private System.Windows.Forms.GroupBox gbPriceOptions;
        private System.Windows.Forms.RadioButton rbPrice3;
        private System.Windows.Forms.RadioButton rbPrice2;
        private System.Windows.Forms.RadioButton rbPrice1;
        private System.Windows.Forms.Label lblCurrencySymbol;
        private System.Windows.Forms.TextBox txtCurrencySymbol;
        private System.Windows.Forms.CheckBox cbCanLocalize;
        private System.Windows.Forms.Button btnAddress;
        private System.Windows.Forms.Label lblDefaultCurrency;
        private System.Windows.Forms.ComboBox cmbLocalizedCulture;
        private System.Windows.Forms.TextBox txtLanguageName;
        private System.Windows.Forms.Label lblLanguageName;
        private System.Windows.Forms.ComboBox cmbCurrency;
    }
}