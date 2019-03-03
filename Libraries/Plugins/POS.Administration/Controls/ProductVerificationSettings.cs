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
 *  File: ProductVerificationSettings.cs
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
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Shared;
using POS.Base.Classes;

namespace POS.Administration.Controls
{
    public partial class ProductVerificationSettings : SharedControls.BaseSettings
    {
        public ProductVerificationSettings()
        {
            InitializeComponent();
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            cbVerifyGiftWrap.Text = Languages.LanguageStrings.AppGiftWrapVerify;
            cbVerifyFeaturedProduct.Text = Languages.LanguageStrings.AppFeaturedProductVerify;
            lblGiftWrapMin.Text = Languages.LanguageStrings.AppMinimumPrice;
            lblGiftWrapMax.Text = Languages.LanguageStrings.AppMaximumPrice;
            cbVerifyCarousel.Text = Languages.LanguageStrings.AppCarouselVerify;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.FeaturedProductCheck = cbVerifyFeaturedProduct.Checked;
            AppController.LocalSettings.GiftWrapChecks = cbVerifyGiftWrap.Checked;

            if (cbVerifyGiftWrap.Checked)
            {
                AppController.LocalSettings.GiftWrapLowest = Utilities.CheckMinMax(Utilities.StrToDecimal(txtGiftWrapMin.Text, -0.01m, null), 1.00m, 50.00m);
                AppController.LocalSettings.GiftWrapMaximum = Utilities.CheckMinMax(Utilities.StrToDecimal(txtGiftWrapMax.Text, -0.01m, null), 1.00m, 50.00m);
            }

            AppController.LocalSettings.CarouselChecks = cbVerifyCarousel.Checked;

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            cbVerifyFeaturedProduct.Checked = AppController.LocalSettings.FeaturedProductCheck;
            cbVerifyGiftWrap.Checked = AppController.LocalSettings.GiftWrapChecks;
            txtGiftWrapMin.Text = AppController.LocalSettings.GiftWrapLowest.ToString();
            txtGiftWrapMax.Text = AppController.LocalSettings.GiftWrapMaximum.ToString();
            cbVerifyCarousel.Checked = AppController.LocalSettings.CarouselChecks;
        }

        #endregion Overridden Methods

        private void cbVerifyGiftWrap_CheckedChanged(object sender, EventArgs e)
        {
            lblGiftWrapMax.Enabled = cbVerifyGiftWrap.Checked;
            lblGiftWrapMin.Enabled = cbVerifyGiftWrap.Checked;
            txtGiftWrapMax.Enabled = cbVerifyGiftWrap.Checked;
            txtGiftWrapMin.Enabled = cbVerifyGiftWrap.Checked;
        }

    }
}
