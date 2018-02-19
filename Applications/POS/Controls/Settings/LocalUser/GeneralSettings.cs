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
 *  File: GeneralSettings.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using Library.BOL.Countries;

using POS.Base.Classes;

namespace PointOfSale.Controls.Settings.LocalUser
{
    public partial class GeneralSettings : SharedControls.BaseSettings
    {
        #region Constructors

        public GeneralSettings()
        {
            InitializeComponent();

            LoadCountries();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblDefaultCountry.Text = Languages.LanguageStrings.AppSettingsDefaultCountry;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.DefaultCountry = ((Country)cmbDefaultCountry.Items[cmbDefaultCountry.SelectedIndex]).CountryCode;
            AppController.UpdateCountry();

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {

        }

        #endregion Overridden Methods

        #region Private Methods


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
            e.Value = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN_BRACKETS, country.Name, country.CountryCode);
        }


        #endregion Private Methods
    }
}
