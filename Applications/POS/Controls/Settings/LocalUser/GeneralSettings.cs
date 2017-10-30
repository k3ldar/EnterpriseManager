using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Library.BOL.Countries;

using PointOfSale.Classes;
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
