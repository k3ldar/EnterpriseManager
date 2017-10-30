using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library.Utils;

using PointOfSale.Classes;
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
