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
 *  File: AdminCountryAddressSettings.cs
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

using SharedBase;
using SharedBase.BOL.Countries;

namespace POS.WebsiteAdministration.Forms.CountryAdmin
{
    public partial class AdminCountryAddressSettings : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private Country _country;

        #endregion Private Members

        #region Constructors

        public AdminCountryAddressSettings(ref Country country)
        {
            InitializeComponent();

            cbTelephoneShow.Tag = cbTelephoneMandatory;
            cbBusinessNameShow.Tag = cbBusinessNameMandatory;
            cbAddress1Show.Tag = cbAddress1Mandatory;
            cbAddress2Show.Tag = cbAddress2Mandatory;
            cbAddress3Show.Tag = cbAddress3Mandatory;
            cbCityShow.Tag = cbCityMandatory;
            cbCountyShow.Tag = cbCountyMandatory;
            cbPostcodeShow.Tag = cbPostcodeMandatory;

            _country = country;
            LoadCountryAddressSettings();
        }

        #endregion Constructors

        #region Static Methods

        public static bool ShowAddressSettings(IWin32Window owner, ref Country country)
        {
            bool Result = false;

            AdminCountryAddressSettings frm = new AdminCountryAddressSettings(ref country);
            try
            {
                Result = frm.ShowDialog(owner) == DialogResult.OK;
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }

            return (Result);
        }

        #endregion Static Methods

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.CountriesAddress;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppCountryAddressOptionsAdminister;

            lblDescription.Text = LanguageStrings.AppCountryAddressOptionsDescription;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;

            cbAddress1Mandatory.Text = LanguageStrings.AppCountryAddressOptionsAddr1Mandatory;
            cbAddress1Show.Text = LanguageStrings.AppCountryAddressOptionsAddr1Show;
            cbAddress2Mandatory.Text = LanguageStrings.AppCountryAddressOptionsAddr2Mandatory;
            cbAddress2Show.Text = LanguageStrings.AppCountryAddressOptionsAddr2Show;
            cbAddress3Mandatory.Text = LanguageStrings.AppCountryAddressOptionsAddr3Mandatory;
            cbAddress3Show.Text = LanguageStrings.AppCountryAddressOptionsAddr3Show;
            cbBusinessNameMandatory.Text = LanguageStrings.AppCountryAddressOptionsBusNameMandatory;
            cbBusinessNameShow.Text = LanguageStrings.AppCountryAddressOptionsBusNameShow;
            cbCityMandatory.Text = LanguageStrings.AppCountryAddressOptionsCityMandatory;
            cbCityShow.Text = LanguageStrings.AppCountryAddressOptionsCityShow;
            cbCountyMandatory.Text = LanguageStrings.AppCountryAddressOptionsCountyMandatory;
            cbCountyShow.Text = LanguageStrings.AppCountryAddressOptionsCountyShow;
            cbPostcodeMandatory.Text = LanguageStrings.AppCountryAddressOptionsPostCodeMandatory;
            cbPostcodeShow.Text = LanguageStrings.AppCountryAddressOptionsPostCodeShow;

            cbTelephoneMandatory.Text = LanguageStrings.AppCountryAddressOptionsTelephoneMandatory;
            cbTelephoneShow.Text = LanguageStrings.AppCountryAddressOptionsTelephoneShow;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void ShowCheckBoxChecked(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            CheckBox counter = (CheckBox)cb.Tag;

            counter.Enabled = cb.Checked;

            if (!counter.Enabled)
                counter.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // update the country
            AddressOptions newOptions = (AddressOptions)0;

            if (cbTelephoneMandatory.Checked)
                newOptions |= AddressOptions.TelephoneMandatory;

            if (cbTelephoneShow.Checked)
                newOptions |= AddressOptions.TelephoneShow;

            if (cbAddress1Mandatory.Checked)
                newOptions |= AddressOptions.AddressLine1Mandatory;

            if (cbAddress1Show.Checked)
                newOptions |= AddressOptions.AddressLine1Show;

            if (cbAddress2Mandatory.Checked)
                newOptions |= AddressOptions.AddressLine2Mandatory;

            if (cbAddress2Show.Checked)
                newOptions |= AddressOptions.AddressLine2Show;

            if (cbAddress3Mandatory.Checked)
                newOptions |= AddressOptions.AddressLine3Mandatory;

            if (cbAddress3Show.Checked)
                newOptions |= AddressOptions.AddressLine3Show;

            if (cbCityMandatory.Checked)
                newOptions |= AddressOptions.CityMandatory;

            if (cbCityShow.Checked)
                newOptions |= AddressOptions.CityShow;

            if (cbCountyMandatory.Checked)
                newOptions |= AddressOptions.CountyMandatory;

            if (cbCountyShow.Checked)
                newOptions |= AddressOptions.CountyShow;

            if (cbPostcodeMandatory.Checked)
                newOptions |= AddressOptions.PostCodeMandatory;

            if (cbPostcodeShow.Checked)
                newOptions |= AddressOptions.PostCodeShow;

            _country.AddressSettings = newOptions;
        }

        private void LoadCountryAddressSettings()
        {
            cbTelephoneShow.Checked = _country.AddressSettings.HasFlag(AddressOptions.TelephoneShow);
            cbTelephoneMandatory.Checked = _country.AddressSettings.HasFlag(AddressOptions.TelephoneMandatory);
            cbAddress1Mandatory.Checked = _country.AddressSettings.HasFlag(AddressOptions.AddressLine1Mandatory);
            cbAddress1Show.Checked = _country.AddressSettings.HasFlag(AddressOptions.AddressLine1Show);
            cbAddress2Mandatory.Checked = _country.AddressSettings.HasFlag(AddressOptions.AddressLine2Mandatory);
            cbAddress2Show.Checked = _country.AddressSettings.HasFlag(AddressOptions.AddressLine2Show);
            cbAddress3Mandatory.Checked = _country.AddressSettings.HasFlag(AddressOptions.AddressLine3Mandatory);
            cbAddress3Show.Checked = _country.AddressSettings.HasFlag(AddressOptions.AddressLine3Show);
            cbBusinessNameMandatory.Checked = _country.AddressSettings.HasFlag(AddressOptions.BusinessNameMandatory);
            cbBusinessNameShow.Checked = _country.AddressSettings.HasFlag(AddressOptions.BusinessNameShow);
            cbCityMandatory.Checked = _country.AddressSettings.HasFlag(AddressOptions.CityMandatory);
            cbCityShow.Checked = _country.AddressSettings.HasFlag(AddressOptions.CityShow);
            cbCountyMandatory.Checked = _country.AddressSettings.HasFlag(AddressOptions.CountyMandatory);
            cbCountyShow.Checked = _country.AddressSettings.HasFlag(AddressOptions.CountyShow);
            cbPostcodeMandatory.Checked = _country.AddressSettings.HasFlag(AddressOptions.PostCodeMandatory);
            cbPostcodeShow.Checked = _country.AddressSettings.HasFlag(AddressOptions.PostCodeShow);
        }

        #endregion Private Methods
    }
}
