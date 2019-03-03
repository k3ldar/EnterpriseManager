/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: AdminEditCountries.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Globalization;
using System.Windows.Forms;

using Languages;

using SharedBase.BOL.Basket;
using SharedBase.BOL.Countries;

using POS.Base.Classes;

namespace POS.WebsiteAdministration.Forms.CountryAdmin
{
    public partial class AdminEditCountries : POS.Base.Controls.BaseTabControl
    {
        #region Private Members

        private Country _selectedCountry = null;
        private bool _changed = false;

        #endregion Private Members

        #region Constructors

        public AdminEditCountries()
        {
            InitializeComponent();

            if (!AppController.ApplicationRunning)
                return;

            LoadCultures();

            AppController.ApplicationController.ActiveControlChanged += User_ActiveControlChanged;
            LoadCountries();
            LoadCurrencies();

            udDefaultTax.Value = Convert.ToDecimal(SharedBase.DAL.DALHelper.DefaultVATRate);
            lstCountries.SelectedIndex = 0;
            HintControl = lblDescription;

            rbPrice1.Text = SharedBase.LibraryHelperClass.SettingsGet(StringConstants.PRICE_DESCRIPTION_1, StringConstants.PRICE_1);
            rbPrice2.Text = SharedBase.LibraryHelperClass.SettingsGet(StringConstants.PRICE_DESCRIPTION_2, StringConstants.PRICE_2);
            rbPrice3.Text = SharedBase.LibraryHelperClass.SettingsGet(StringConstants.PRICE_DESCRIPTION_3, StringConstants.PRICE_3);

        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            btnAddress.Text = LanguageStrings.AppMenuButtonAddress;

            gbCountry.Text = LanguageStrings.AppCountry;
            gbPriceOptions.Text = LanguageStrings.AppCountriesPriceOptions;

            cbCanLocalize.Text = LanguageStrings.AppCountriesCanLocalize;
            cbShowPrices.Text = LanguageStrings.AppCountriesShowPrices;

            lblCostMultiplier.Text = LanguageStrings.AppCountriesCostMultiplier;
            lblCurrencyConversionRate.Text = LanguageStrings.AppCountriesCurrencyConversionRate;
            lblCurrencySymbol.Text = LanguageStrings.AppCountriesCurrencySymbol;
            lblDefaultCurrency.Text = LanguageStrings.AppCountriesDefaultCurrency;
            lblDefaultTaxRate.Text = LanguageStrings.AppCountriesDefaultTaxRate;
            lblDescription.Text = LanguageStrings.AppDescription;
            lblLanguageName.Text = LanguageStrings.AppCountriesLanguageName;
            lblShippingCosts.Text = LanguageStrings.AppShippingCosts;
            lblSortOrder.Text = LanguageStrings.AppSortOrder;
            lblTaxRate.Text = LanguageStrings.AppTaxRate;
        }

        #endregion Overridden Methods

        #region Private Methods

        void User_ActiveControlChanged(object sender, EventArgs e)
        {
            lblDescription.Text = GetHintText(this.Name.ToString(), this.ActiveControl.Name.ToString());
        }

        /// <summary>
        /// Loads available cultures
        /// </summary>
        private void LoadCultures()
        {
            cmbLocalizedCulture.Items.Clear();

            foreach (string culture in LanguageWrapper.GetInstalledLanguages(Shared.Utilities.CurrentPath(true)))
            {
                cmbLocalizedCulture.Items.Add(culture);
            }
        }

        private void LoadCurrencies()
        {
            Currencies currencies = Currencies.Get();
            cmbCurrency.Items.Clear();

            foreach (Currency currency in currencies)
            {
                cmbCurrency.Items.Add(currency);
            }
        }

        private void SelectCurrency(string currency)
        {
            for (int i = 0; i < cmbCurrency.Items.Count - 1; i++)
            {
                Currency cur = (Currency)cmbCurrency.Items[i];

                if (cur.CurrencyCode == currency)
                {
                    cmbCurrency.SelectedIndex = i;
                    break;
                }
            }
        }

        private void LoadCountries()
        {
            lstCountries.Items.Clear();

            SharedBase.BOL.Countries.Countries countries = SharedBase.BOL.Countries.Countries.Get();

            foreach (Country country in countries)
            {
                lstCountries.Items.Add(country);
            }
        }

        private void lstCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_changed)
            {
                //_selectedCountry.Multiplier = Shared.Utilities.StrToDblDef(txtCostMultiplier.Text, 0.00);
                //_selectedCountry.ConversionRate = Shared.Utilities.StrToDblDef(txtCurrencyConversion.Text, 1.0);
                _selectedCountry.ShippingCosts = Shared.Utilities.StrToDecimal(txtShipping.Text, 18.00m, null);
                _selectedCountry.ShowPrices = cbShowPrices.Checked;
                _selectedCountry.VATRate = Shared.Utilities.StrToDblDef(txtVATRate.Text, 20.0);
                _selectedCountry.CurrencySymbol = txtCurrencySymbol.Text;
                _selectedCountry.DefaultCurrency = ((Currency)cmbCurrency.SelectedItem).CurrencyCode;
                _selectedCountry.CanLocalize = cbCanLocalize.Checked;
                _selectedCountry.LocalizedCulture = (string)cmbLocalizedCulture.Items[cmbLocalizedCulture.SelectedIndex];
                _selectedCountry.LocalizedLanguage = txtLanguageName.Text;

                if (rbPrice1.Checked)
                    _selectedCountry.PriceColumn = 0;
                else if (rbPrice2.Checked)
                    _selectedCountry.PriceColumn = 1;
                else if (rbPrice3.Checked)
                    _selectedCountry.PriceColumn = 2;

                _selectedCountry.Save();
            }

            if (lstCountries.SelectedIndex > -1)
            {
                _selectedCountry = (Country)lstCountries.Items[lstCountries.SelectedIndex];

                //txtCostMultiplier.Text = _selectedCountry.Multiplier.ToString();
                //txtCurrencyConversion.Text = _selectedCountry.ConversionRate.ToString();
                txtShipping.Text = _selectedCountry.ShippingCosts.ToString();
                cbShowPrices.Checked = _selectedCountry.ShowPriceData();
                txtVATRate.Text = _selectedCountry.VATRate.ToString();
                txtCurrencySymbol.Text = _selectedCountry.CurrencySymbol;
                cbCanLocalize.Checked = _selectedCountry.CanLocalize;
                txtLanguageName.Text = _selectedCountry.LocalizedLanguage;
                SelectCurrency(_selectedCountry.DefaultCurrency);

                for (int i = 0; i < cmbLocalizedCulture.Items.Count; i++)
                {
                    string culture = (string)cmbLocalizedCulture.Items[i];

                    if (culture.ToUpper() == _selectedCountry.LocalizedCulture.ToUpper())
                    {
                        cmbLocalizedCulture.SelectedIndex = i;
                        break;
                    }
                }

                switch (_selectedCountry.PriceColumn)
                {
                    case 0:
                        rbPrice1.Checked = true;
                        break;

                    case 1:
                        rbPrice2.Checked = true;
                        break;

                    case 2:
                        rbPrice3.Checked = true;
                        break;
                }
            }

            _changed = false;
        }

        private void lstCountries_Format(object sender, ListControlConvertEventArgs e)
        {
            Country country = (Country)e.ListItem;
            e.Value = country.Name;
        }

        private void value_Changed(object sender, EventArgs e)
        {
            _changed = true;
        }

        private void btnAddress_Click(object sender, EventArgs e)
        {
            _changed = AdminCountryAddressSettings.ShowAddressSettings(this, ref _selectedCountry);
        }

        private void cmbLocalizedCulture_SelectedIndexChanged(object sender, EventArgs e)
        {
            _changed = true;
        }

        private void cbCanLocalize_CheckedChanged(object sender, EventArgs e)
        {
            _changed = true;
            cmbLocalizedCulture.Enabled = cbCanLocalize.Checked;
            txtLanguageName.Enabled = cbCanLocalize.Checked;
        }

        private void cmbCurrency_Format(object sender, ListControlConvertEventArgs e)
        {
            Currency currency = (Currency)e.ListItem;
            e.Value = currency.CurrencyCode;
        }

        private void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selCurrency = ((Currency)cmbCurrency.SelectedItem).CurrencyCode;

            if (selCurrency != _selectedCountry.DefaultCurrency)
                _changed = true;
        }

        #endregion Private Methods
    }
}
