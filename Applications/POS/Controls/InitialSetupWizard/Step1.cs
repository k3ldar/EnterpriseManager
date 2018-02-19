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
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: Step1.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using Languages;
using PointOfSale.Classes;
using POS.Base.Classes;

using Library.BOL.Countries;

using System.Globalization;

#pragma warning disable IDE1006

namespace PointOfSale.Controls.InitialSetupWizard
{
    public partial class Step1 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private InitialSetupSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step1()
        {
            InitializeComponent();

#if LANGUAGES
            LoadLanguages();
#else
            lblSelectLanguage.Visible = false;
            cmbLanguage.Visible = false;
#endif

            LoadCurrencies();
            LoadCountries();
        }

        internal Step1(InitialSetupSettings settings)
            : this()
        {
            _settings = settings;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblHeader.Text = String.Format(LanguageStrings.AppInitialSetupWelcome, Application.ProductName);
            lblSelectLanguage.Text = LanguageStrings.SelectLanguage;
            lblDefaultCurrency.Text = LanguageStrings.AppSettingsDefaultCurrency;
            lblCountry.Text = LanguageStrings.Country;
            lblHelp.Text = LanguageStrings.PressF1;
        }

        public override void PageShown()
        {
            AppController.ActiveHelpTopic = HelpTopics.InitialStep1;
        }

        public override bool NextClicked()
        {
            Country country = (Country)cmbDefaultCountry.Items[cmbDefaultCountry.SelectedIndex];
            AppController.LocalSettings.DefaultCountry = country.CountryCode;
            string[] parts = ((string)cmbCurrency.SelectedItem).Split(StringConstants.SYMBOL_HASH_CHAR);
            AppController.LocalSettings.CurrencyBase = parts[0];

            return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadLanguages()
        {
            cmbLanguage.Items.Clear();

            string[] languages = Languages.LanguageWrapper.GetInstalledLanguages(
                AppController.POSFolder(FolderType.Languages, true));

            foreach (string lang in languages)
            {
                try
                {
                    CultureInfo ci = new CultureInfo(lang);
                    cmbLanguage.Items.Add(ci);
                }
                catch
                {
                    // do nothing, not a valid culture
                }
            }

            cmbLanguage.SelectedIndex = 0;
        }

        private void cmbLanguage_Format(object sender, ListControlConvertEventArgs e)
        {
            CultureInfo ci = (CultureInfo)e.ListItem;
            e.Value = ci.NativeName;
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            CultureInfo culture = (CultureInfo)cmbLanguage.Items[cmbLanguage.SelectedIndex];
            AppController.LocalSettings.CustomUICulture = culture.Name;
            AppController.LocalSettings.CustomCulture = culture.Name;
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;

            if (MainWizardForm != null)
                this.MainWizardForm.UpdateLanguage(culture, LanguageStrings.Cancel, LanguageStrings.Previous,
                    LanguageStrings.Next, LanguageStrings.AppMenuButtonFinish);
        }

        /// <summary>
        /// Load availale currencies
        /// </summary>
        private void LoadCurrencies()
        {
            cmbCurrency.Items.Clear();

            string[] currencies = StringConstants.YAHOO_CURRENCIES.Split(StringConstants.SYMBOL_SEMI_COLON_CHAR);


            foreach (string currency in currencies)
            {
                if (String.IsNullOrEmpty(currency))
                    continue;

                int idx = cmbCurrency.Items.Add(currency);

                if (currency.Contains("GBP"))
                    cmbCurrency.SelectedIndex = idx;
            }
        }

        private void cmbCurrency_Format(object sender, ListControlConvertEventArgs e)
        {
            string[] parts = ((string)e.ListItem).Split(StringConstants.SYMBOL_HASH_CHAR);

            e.Value = parts[1];
        }

        /// <summary>
        /// Loads all countries and set's default
        /// </summary>
        private void LoadCountries()
        {
            cmbDefaultCountry.Items.Clear();
            Countries countries = Countries.Get();

            foreach (Country country in countries)
            {
                int idx = cmbDefaultCountry.Items.Add(country);

                if (country.CountryCode == AppController.LocalSettings.DefaultCountry)
                    cmbDefaultCountry.SelectedIndex = idx;
            }
        }

        private void cmbDefaultCountry_Format(object sender, ListControlConvertEventArgs e)
        {
            Country country = (Country)e.ListItem;
            e.Value = country.Name;
        }

        #endregion Private Methods
    }
}
