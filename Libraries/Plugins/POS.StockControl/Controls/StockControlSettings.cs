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
 *  File: StockControlSettings.cs
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

using POS.StockControl.Classes;
using SharedBase.BOL.StockControl;
using POS.Base.Classes;

namespace POS.StockControl.Controls
{
    public partial class StockControlSettings : SharedControls.BaseSettings
    {
        #region Constructors

        public StockControlSettings()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblStockLowIndicator1.Text = LanguageStrings.AppStockLowDescription1;
            lblStockLowIndicator2.Text = LanguageStrings.AppStockLowDescription2;

            gbColors.Text = LanguageStrings.AppColors;
            csLowStock.Description = LanguageStrings.AppStockColorLow;
            csVeryLow.Description = LanguageStrings.AppStockColorVeryLow;
            csVeryLowSelected.Description = LanguageStrings.AppStockColorVeryLowSelected;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.StockLevelLow = (int)spnLowStockLevel.Value;

            AppController.LocalSettings.StockColorVeryLowSelected = csVeryLowSelected.Color.ToArgb().ToString();
            AppController.LocalSettings.StockColorVeryLow = csVeryLow.Color.ToArgb().ToString();
            AppController.LocalSettings.StockColorLow = csLowStock.Color.ToArgb().ToString();

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            spnLowStockLevel.Value = AppController.LocalSettings.StockLevelLow;

            csVeryLowSelected.Color = ColorTranslator.FromHtml(AppController.LocalSettings.StockColorVeryLowSelected);
            csVeryLow.Color = ColorTranslator.FromHtml(AppController.LocalSettings.StockColorVeryLow);
            csLowStock.Color = ColorTranslator.FromHtml(AppController.LocalSettings.StockColorLow);
        }

        #endregion Overridden Methods
    }
}
