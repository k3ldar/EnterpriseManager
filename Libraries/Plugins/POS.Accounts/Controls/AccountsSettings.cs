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
 *  File: AccountsSettings.cs
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

using POS.Base.Classes;

using Languages;

namespace POS.Accounts.Controls
{
    public partial class AccountsSettings : SharedControls.BaseSettings
    {
        #region Constructors

        public AccountsSettings()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblAccountYearEnd.Text = LanguageStrings.AppAccountsYearEnd;
            lblAccountYearStart.Text = LanguageStrings.AppAccountsYearStart;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.AccountYearStart = dtpAccountYearStart.Value;
            AppController.LocalSettings.AccountYearEnd = dtpAccountYearEnd.Value;

            return (base.SettingsSave());
        }

        public override void SettingsLoaded()
        {
            dtpAccountYearStart.Value = AppController.LocalSettings.AccountYearStart;
            dtpAccountYearEnd.Value = AppController.LocalSettings.AccountYearEnd;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void dtpAccountYearStart_ValueChanged(object sender, EventArgs e)
        {
            dtpAccountYearEnd.Value = dtpAccountYearStart.Value.AddYears(1).AddDays(-1);
        }


        #endregion Private Methods
    }
}
