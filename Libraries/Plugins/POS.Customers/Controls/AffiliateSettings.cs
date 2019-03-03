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
 *  File: AffiliateSettings.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Languages;
using SharedBase.BOL.Websites;
using POS.Base.Classes;

namespace POS.Customers.Controls
{
    public partial class AffiliateSettings : SharedControls.BaseSettings
    {
        #region Constructors

        public AffiliateSettings()
        {
            InitializeComponent();

            LoadWebsites();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblURL.Text = LanguageStrings.AppAffiliatePrimaryURL;
            cbGenerateExternal.Text = LanguageStrings.AppAffiliateGenerateExternalLinks;
            lblMaxDays.Text = LanguageStrings.AppAffiliateMaximumLiveDays;
            rbYearlyPayments.Text = LanguageStrings.AppCommissionYearlyPayments;
            rbContinuousPayments.Text = LanguageStrings.AppCommissionContinualPayments;
            lblWait.Text = LanguageStrings.AppWait;
            lblWaitDescription.Text = LanguageStrings.AppCommissionWaitDescription;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.AffiliateURL = (string)cmbWebsites.SelectedItem;
            AppController.LocalSettings.AffiliateExternalLinks = cbGenerateExternal.Checked;
            SharedBase.LibraryHelperClass.SettingsSet(StringConstants.AFFILIATE_LIVE_DAYS, udMaxDays.Value.ToString());

            if (rbContinuousPayments.Checked)
            {
                SharedBase.LibraryHelperClass.SettingsSet(StringConstants.COMMISSION_AFFILIATE_MONTHS, udMonthsToWait.Value.ToString());
            }
            else
            {
                string m = Convert.ToString(dtpYearly.Value.Month + 20);
                string d = Convert.ToString(dtpYearly.Value.Day + 20);

                SharedBase.LibraryHelperClass.SettingsSet(StringConstants.COMMISSION_AFFILIATE_MONTHS, m + d);
                SharedBase.LibraryHelperClass.SettingsSet(StringConstants.COMMISSION_AFFILIATE_MIN_WAiT, udMonthsToWait.Value.ToString());
            }
            return (base.SettingsSave());
        }

        public override void SettingsLoaded()
        {
            int months = Shared.Utilities.StrToIntDef(SharedBase.LibraryHelperClass.SettingsGet(
                StringConstants.COMMISSION_AFFILIATE_MONTHS, StringConstants.SYMBOL_THREE), 3);
            int minMonths = Shared.Utilities.StrToIntDef(SharedBase.LibraryHelperClass.SettingsGet(
                StringConstants.COMMISSION_AFFILIATE_MIN_WAiT, StringConstants.SYMBOL_TWO), 2);

            if (months > 12)
            {
                udMonthsToWait.Value = minMonths;
                rbYearlyPayments.Checked = true;

                string m = months.ToString().Substring(0, 2);
                string d = months.ToString().Substring(2, 2);

                dtpYearly.Value = new DateTime(2016, Convert.ToInt32(m) - 20, Convert.ToInt32(d) - 20);
            }
            else
            {
                udMonthsToWait.Value = months;
                rbContinuousPayments.Checked = true;
            }

            cbGenerateExternal.Checked = AppController.LocalSettings.AffiliateExternalLinks;
            udMaxDays.Value = Shared.Utilities.StrToDecimal(SharedBase.LibraryHelperClass.SettingsGet(
                StringConstants.AFFILIATE_LIVE_DAYS, StringConstants.SYMBOL_SEVEN), 7);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadWebsites()
        {
            Websites allWebsites = Websites.All();
            cmbWebsites.Items.Clear();

            foreach (Website site in allWebsites)
            {
                int idx = cmbWebsites.Items.Add(site.URL);

                if (site.URL == AppController.LocalSettings.AffiliateURL)
                {
                    cmbWebsites.SelectedIndex = idx;
                }
            }
        }

        #endregion Private Methods
    }
}
