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

using POS.Base.Classes;

namespace POS.Till.Controls
{
    public partial class TillSettings : SharedControls.BaseSettings
    {
        #region Constructors

        public TillSettings()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            rbList.Text = LanguageStrings.AppSettingsTillList;
            rbShowButtons.Text = LanguageStrings.AppSettingsTillButtons;
            cbShowPriceExcludingVAT.Text = LanguageStrings.AppTillShowPriceNoVAT;
            cbHideOutOfStockProducts.Text = LanguageStrings.AppTillHideOutOfStockProducts;
            cbHideZeroStockProducts.Text = LanguageStrings.AppTillHideProductsThatHaveZeroStock;
            cbShowSummaryStatusBar.Text = LanguageStrings.AppTillShowSummaryStatusBar;

            cbShowProductImages.Text = LanguageStrings.AppSettingsTillButtonImages;
            gbButtonOptions.Text = LanguageStrings.AppSettingsTillButtonOptions;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.TillShowButtons = rbShowButtons.Checked;

            AppController.LocalSettings.TillShowButtonImages = cbShowProductImages.Checked;

            AppController.LocalSettings.HideOutOfStockProducts = cbHideOutOfStockProducts.Checked;
            AppController.LocalSettings.HideProductsWithZeroStock = cbHideZeroStockProducts.Checked;
            AppController.LocalSettings.ShowPricesWithoutVAT = cbShowPriceExcludingVAT.Checked;
            AppController.LocalSettings.TillShowSummaryBar = cbShowSummaryStatusBar.Checked;
            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            rbShowButtons.Checked = AppController.LocalSettings.TillShowButtons;
            rbList.Checked = !AppController.LocalSettings.TillShowButtons;

            cbShowProductImages.Checked = AppController.LocalSettings.TillShowButtonImages;
            cbHideOutOfStockProducts.Checked = AppController.LocalSettings.HideOutOfStockProducts;
            cbHideZeroStockProducts.Checked = AppController.LocalSettings.HideProductsWithZeroStock;
            cbShowPriceExcludingVAT.Checked = AppController.LocalSettings.ShowPricesWithoutVAT;
            cbShowSummaryStatusBar.Checked = AppController.LocalSettings.TillShowSummaryBar;
        }

        #endregion Overridden Methods

        private void rbShowButtons_CheckedChanged(object sender, EventArgs e)
        {
            gbButtonOptions.Enabled = rbShowButtons.Checked;
        }

        #region Private Methods


        #endregion Private Methods
    }
}
