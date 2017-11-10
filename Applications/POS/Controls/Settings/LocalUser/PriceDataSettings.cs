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
 *  File: PriceDataSettings.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Languages;

using POS.Base.Classes;

namespace PointOfSale.Controls.Settings.LocalUser
{
    public partial class PriceDataSettings : SharedControls.BaseSettings
    {
        #region Constructors

        public PriceDataSettings()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblPrice1Desc.Text = LanguageStrings.AppSettingsPriceData1Description;
            lblPrice2Desc.Text = LanguageStrings.AppSettingsPriceData2Description;
            lblPrice3Desc.Text = LanguageStrings.AppSettingsPriceData3Description;
        }

        public override bool SettingsSave()
        {
            // price settings
            Library.LibraryHelperClass.SettingsSet(StringConstants.PRICE_DESCRIPTION_1, txtPrice1Description.Text);
            Library.LibraryHelperClass.SettingsSet(StringConstants.PRICE_DESCRIPTION_2, txtPrice2Description.Text);
            Library.LibraryHelperClass.SettingsSet(StringConstants.PRICE_DESCRIPTION_3, txtPrice3Description.Text);

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            txtPrice1Description.Text = Library.LibraryHelperClass.SettingsGet(StringConstants.PRICE_DESCRIPTION_1, StringConstants.PRICE_1);
            txtPrice2Description.Text = Library.LibraryHelperClass.SettingsGet(StringConstants.PRICE_DESCRIPTION_2, StringConstants.PRICE_2);
            txtPrice3Description.Text = Library.LibraryHelperClass.SettingsGet(StringConstants.PRICE_DESCRIPTION_3, StringConstants.PRICE_3);
        }

        #endregion Overridden Methods

        #region Private Methods


        #endregion Private Methods
    }
}
