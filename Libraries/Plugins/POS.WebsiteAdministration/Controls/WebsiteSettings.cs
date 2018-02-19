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
 *  File: WebsiteSettings.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Languages;
using POS.Base.Classes;

namespace POS.WebsiteAdministration.Controls
{
    public partial class WebsiteSettings : SharedControls.BaseSettings
    {
        public WebsiteSettings()
        {
            InitializeComponent();
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            cbWebsiteMenus.Text = LanguageStrings.AppShowWebsiteMenus;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.ShowWebsiteMenuItem = cbWebsiteMenus.Checked;

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            cbWebsiteMenus.Checked = AppController.LocalSettings.ShowWebsiteMenuItem;
        }

        #endregion Overridden Methods
    }
}
