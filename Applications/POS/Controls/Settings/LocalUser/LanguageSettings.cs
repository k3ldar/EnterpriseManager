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
 *  File: LanguageSettings.cs
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
using POS.Base.Classes;

#pragma warning disable IDE1006

namespace PointOfSale.Controls.Settings.LocalUser
{
    public partial class LanguageSettings : SharedControls.BaseSettings
    {
        public LanguageSettings()
        {
            InitializeComponent();

#if LANGUAGES
            cbShowLanguageMenu.Visible = true;
#else
            cbShowLanguageMenu.Visible = false;
#endif
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblDefaultCurrency.Text = LanguageStrings.AppSettingsDefaultCurrency;
            cbShowLanguageMenu.Text = LanguageStrings.AppShowLanguageMenu;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.CustomCulture = (
                (CultureInfo)cmbCurrency.Items[cmbCurrency.SelectedIndex]).Name;
            AppController.LocalSettings.ShowLanguageMenu = cbShowLanguageMenu.Checked;
            Library.DAL.DALHelper.CultureOverride = AppController.LocalSettings.CustomCulture;
            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            LoadCurrencies();
            cbShowLanguageMenu.Checked = AppController.LocalSettings.ShowLanguageMenu;
        }

        #endregion Overridden Methods

        #region Private Methods

        /// <summary>
        /// Load availale currencies
        /// </summary>
        private void LoadCurrencies()
        {
            cmbCurrency.Items.Clear();

            foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures))
            {
                int idx = cmbCurrency.Items.Add(culture);

                if (culture.Name == AppController.LocalSettings.CustomCulture)
                    cmbCurrency.SelectedIndex = idx;
            }
        }

        private void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            CultureInfo culture = (CultureInfo)cmbCurrency.Items[cmbCurrency.SelectedIndex];
            lblCurrency.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN, culture.Name,
                Library.Utils.SharedUtils.FormatMoney(0.00m, AppController.LocalCurrency));
        }

        private void cmbCurrency_Format(object sender, ListControlConvertEventArgs e)
        {
            CultureInfo culture = (CultureInfo)e.ListItem;

            e.Value = culture.NativeName;
        }


        #endregion Private Methods
    }
}
