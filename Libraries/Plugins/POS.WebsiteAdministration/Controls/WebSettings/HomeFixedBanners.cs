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
 *  File: HomeFixedBanners.cs
 *
 *  Purpose:  Fixed Home page banners
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Globalization;

using POS.Base.Classes;
using Languages;

#pragma warning disable IDE1006

namespace POS.WebsiteAdministration.Controls.WebSettings
{
    public partial class HomeFixedBanners : BaseWebSetting
    {
        public HomeFixedBanners()
        {
            InitializeComponent();
        }

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblDescription.Text = LanguageStrings.AppHomeFixedBannerDesc;
            cbShowHomeFixedBanners.Text = LanguageStrings.AppHomeFixedBannersShow;
        }

        public override void Reload()
        {
            string setting = String.Format(StringConstants.WEB_SETTING_HOME_FIXED_BANNER_SHOW, Website.ID);
            cbShowHomeFixedBanners.Checked = SharedBase.LibraryHelperClass.SettingsGetBool(setting, false);
        }
        public override string HelpString()
        {
            return (HelpTopics.WebsiteSettingFixedBanners);
        }

        private void cbShowHomeFixedBanners_CheckedChanged(object sender, System.EventArgs e)
        {
            string setting = String.Format(StringConstants.WEB_SETTING_HOME_FIXED_BANNER_SHOW, Website.ID);
            SharedBase.LibraryHelperClass.SettingsSet(setting, cbShowHomeFixedBanners.Checked.ToString());
        }
    }
}
