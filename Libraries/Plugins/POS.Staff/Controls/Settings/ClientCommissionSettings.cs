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
 *  File: ClientCommissionSettings.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library;
using POS.Base.Classes;

namespace POS.Staff.Controls.Settings
{
    public partial class ClientCommissionSettings : SharedControls.BaseSettings
    {
        #region Constructors

        public ClientCommissionSettings()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            rbYearlyPayments.Text = LanguageStrings.AppCommissionYearlyPayments;
            rbContinuousPayments.Text = LanguageStrings.AppCommissionContinualPayments;
            lblWait.Text = LanguageStrings.AppWait;
            lblWaitDescription.Text = LanguageStrings.AppCommissionWaitDescription;

        }

        public override bool SettingsSave()
        {
            if (rbContinuousPayments.Checked)
            {
                Library.LibraryHelperClass.SettingsSet(StringConstants.COMMISSION_CLIENT_MONTHS, udMonthsToWait.Value.ToString());
            }
            else
            {
                string m = Convert.ToString(dtpYearly.Value.Month + 20);
                string d = Convert.ToString(dtpYearly.Value.Day + 20);

                Library.LibraryHelperClass.SettingsSet(StringConstants.COMMISSION_CLIENT_MONTHS, m + d);
                Library.LibraryHelperClass.SettingsSet(StringConstants.COMMISSION_CLIENT_MIN_WAiT, udMonthsToWait.Value.ToString());
            }

            return (base.SettingsSave());
        }

        public override void SettingsLoaded()
        {
            int months = Shared.Utilities.StrToIntDef(Library.LibraryHelperClass.SettingsGet(StringConstants.COMMISSION_CLIENT_MONTHS, StringConstants.SYMBOL_THREE), 3);
            int minMonths = Shared.Utilities.StrToIntDef(Library.LibraryHelperClass.SettingsGet(StringConstants.COMMISSION_CLIENT_MIN_WAiT, StringConstants.SYMBOL_TWO), 2);

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
        }

        #endregion Overridden Methods

        #region Private Methods

        private void rbYearlyPayments_CheckedChanged(object sender, EventArgs e)
        {
            dtpYearly.Enabled = rbYearlyPayments.Checked;
        }

        #endregion Private Methods
    }
}
