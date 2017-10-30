using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;

using POS.StockControl.Classes;
using Library.BOL.StockControl;
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
