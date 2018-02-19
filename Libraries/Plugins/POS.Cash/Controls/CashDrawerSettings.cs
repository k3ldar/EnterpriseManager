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
 *  File: CashDrawerSettings.cs
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

namespace POS.CashManager.Classes
{
    public partial class CashDrawerSettings : SharedControls.BaseSettings
    {
        public CashDrawerSettings()
        {
            InitializeComponent();
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblSpotChecks.Text = Languages.LanguageStrings.AppBypassSpotChecks;
            lblTimes.Text = Languages.LanguageStrings.AppTimes;
            cbCashDrawerForceChecks.Text = Languages.LanguageStrings.AppForceChecks;
            cbCashDrawBypassStart.Text = Languages.LanguageStrings.AppBypassStartOfDayChecks;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.CashDrawerBypassStartOfDay = cbCashDrawBypassStart.Checked;
            AppController.LocalSettings.CashDrawerForceChecks = cbCashDrawerForceChecks.Checked;
            AppController.LocalSettings.CashDrawerMaximumBypassCount = (int)udCashDrawBypassCount.Value;

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            cbCashDrawBypassStart.Checked = AppController.LocalSettings.CashDrawerBypassStartOfDay;
            cbCashDrawerForceChecks.Checked = AppController.LocalSettings.CashDrawerForceChecks;
            udCashDrawBypassCount.Value = AppController.LocalSettings.CashDrawerMaximumBypassCount;
        }

        #endregion Overridden Methods

    }
}
