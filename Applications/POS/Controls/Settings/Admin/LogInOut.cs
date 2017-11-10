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
 *  File: LogInOut.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using POS.Base.Classes;

namespace PointOfSale.Controls.Settings.Admin
{
    public partial class LogInOut : SharedControls.BaseSettings
    {
        public LogInOut()
        {
            InitializeComponent();

            udTimeout.Value = AppController.LocalSettings.AutoLogoutTimeOut / 60;
            cbAutoLogout.Checked = AppController.LocalSettings.AutoLogout;

            cbAutoLogout_CheckedChanged(this, EventArgs.Empty);
        }


        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            cbAutoLogout.Text = Languages.LanguageStrings.AppAutoLogout;
            lblLogoutDesc1.Text = Languages.LanguageStrings.AppLogoutAfter;
            lblLogoutDesc2.Text = Languages.LanguageStrings.AppMinutesOfInactivity;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.AutoLogout = cbAutoLogout.Checked;
            AppController.LocalSettings.AutoLogoutTimeOut = (uint)udTimeout.Value * 60;

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
        }

        #endregion Overridden Methods

        #region Private Methods

        private void cbAutoLogout_CheckedChanged(object sender, EventArgs e)
        {
            lblLogoutDesc1.Enabled = cbAutoLogout.Checked;
            lblLogoutDesc2.Enabled = cbAutoLogout.Checked;
            udTimeout.Enabled = cbAutoLogout.Checked;
        }

        #endregion Private Methods

    }
}
