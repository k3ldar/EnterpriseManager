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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: CurrencyWatchSettings.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using POS.Base.Classes;

using Languages;

namespace POS.CurrencyWatch.Controls
{
    public partial class CurrencyWatchSettings : SharedControls.BaseSettings
    {
        #region Constructors

        public CurrencyWatchSettings()
        {
            InitializeComponent();

            LoadCurrencies();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblAvailableCurrencies.Text = LanguageStrings.AppAvailableCurrencies;
            lblBaseCurrency.Text = LanguageStrings.AppBaseCurrency;
            lblMinutes.Text = String.Format(LanguageStrings.AppMinutes, String.Empty);
            lblUpdateEvery.Text = LanguageStrings.AppUpdateEvery;

            colHeaderCurrency.Text = LanguageStrings.AppCurrency;
            colHeaderName.Text = LanguageStrings.AppName;
            colHeaderWatch.Text = LanguageStrings.AppWatch;
            colHeaderPrimary.Text = LanguageStrings.AppPrimary;
        }

        public override bool SettingsSave()
        {
            if (lvCurrencies.CheckedItems.Count == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    lvCurrencies.Items[i].Checked = true;
                }
            }

            AppController.LocalSettings.CurrencyBase = lstCurrencies.Items[lstCurrencies.SelectedIndex].ToString().Split(StringConstants.SYMBOL_HASH_CHAR)[0];
            AppController.LocalSettings.CurrencyWatchUpdateMinutes = (int)udUpdateMinutes.Value;
            AppController.LocalSettings.CurrencyWatching = String.Empty;
            AppController.LocalSettings.CurrencySelected = String.Empty;


            foreach (ListViewItem item in lvCurrencies.Items)
            {
                if (item.Checked)
                    AppController.LocalSettings.CurrencyWatching += String.Format(StringConstants.PREFIX_AND_SUFFIX, item.SubItems[1].Text, StringConstants.SYMBOL_SEMI_COLON);

                if (item.SubItems[3].Text == LanguageStrings.Yes)
                    AppController.LocalSettings.CurrencySelected = item.SubItems[1].Text;
            }

            if (String.IsNullOrEmpty(AppController.LocalSettings.CurrencySelected))
                AppController.LocalSettings.CurrencySelected = lvCurrencies.Items[0].SubItems[1].Text;

            return (base.SettingsSave());
        }

        public override void SettingsLoaded()
        {
            udUpdateMinutes.Value = AppController.LocalSettings.CurrencyWatchUpdateMinutes;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadCurrencies()
        {
            lstCurrencies.Items.Clear();
            lvCurrencies.Items.Clear();

            string[] allCurrencies = StringConstants.YAHOO_CURRENCIES.Split(StringConstants.SYMBOL_SEMI_COLON_CHAR);
            string currencies = String.Empty;

            foreach (string currency in allCurrencies)
            {
                if (String.IsNullOrEmpty(currency))
                    continue;

                string[] currencyNameSymbol = currency.Split(StringConstants.SYMBOL_HASH_CHAR);
                int index = lstCurrencies.Items.Add(currency);

                if (currencyNameSymbol[0] == AppController.LocalSettings.CurrencyBase)
                    lstCurrencies.SelectedIndex = index;
            }
        }

        private void LoadAvailableCurrencies()
        {
            lvCurrencies.Items.Clear();

            string[] allCurrencies = StringConstants.YAHOO_CURRENCIES.Split(StringConstants.SYMBOL_SEMI_COLON_CHAR);
            string currencies = String.Empty;

            foreach (string currency in allCurrencies)
            {
                if (String.IsNullOrEmpty(currency))
                    continue;

                string[] currencyNameSymbol = currency.Split(StringConstants.SYMBOL_HASH_CHAR);

                if (currency != (string)lstCurrencies.Items[lstCurrencies.SelectedIndex])
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = String.Empty;
                    item.SubItems.Add(currencyNameSymbol[0]);
                    item.SubItems.Add(currencyNameSymbol[1]);
                    item.SubItems.Add(currencyNameSymbol[0] == AppController.LocalSettings.CurrencySelected ? LanguageStrings.Yes : String.Empty);
                    item.Checked = AppController.LocalSettings.CurrencyWatching.Contains(currencyNameSymbol[0]);

                    lvCurrencies.Items.Add(item);
                }
            }
        }
        private void lvCurrencies_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvCurrencies.Items)
            {
                item.SubItems[3].Text = String.Empty;
            }

            if (lvCurrencies.SelectedItems.Count > 0)
            {
                lvCurrencies.SelectedItems[0].SubItems[3].Text = LanguageStrings.Yes;
                lvCurrencies.SelectedItems[0].Checked = true;
            }
        }

        private void lstCurrencies_Format(object sender, ListControlConvertEventArgs e)
        {
            string selected = (string)e.ListItem;

            string[] parts = selected.Split(StringConstants.SYMBOL_HASH_CHAR);
            e.Value = parts[1];
        }

        private void lstCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAvailableCurrencies();
        }

        #endregion Private Methods
    }
}
