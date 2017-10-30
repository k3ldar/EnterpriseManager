using System;
using System.Globalization;
using System.Windows.Forms;

using Languages;
using POS.Base.Classes;

#pragma warning disable IDE1006

namespace PointOfSale.Controls.Settings.LocalUser
{
    public partial class LanguageSettings : SharedControls.BaseSettings
    {
        public LanguageSettings()
        {
            InitializeComponent();

#if LANGUAGES
            cbShowLanguageMenu.Visible = true;
#else
            cbShowLanguageMenu.Visible = false;
#endif
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblDefaultCurrency.Text = LanguageStrings.AppSettingsDefaultCurrency;
            cbShowLanguageMenu.Text = LanguageStrings.AppShowLanguageMenu;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.CustomCulture = (
                (CultureInfo)cmbCurrency.Items[cmbCurrency.SelectedIndex]).Name;
            AppController.LocalSettings.ShowLanguageMenu = cbShowLanguageMenu.Checked;
            Library.DAL.DALHelper.CultureOverride = AppController.LocalSettings.CustomCulture;
            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            LoadCurrencies();
            cbShowLanguageMenu.Checked = AppController.LocalSettings.ShowLanguageMenu;
        }

        #endregion Overridden Methods

        #region Private Methods

        /// <summary>
        /// Load availale currencies
        /// </summary>
        private void LoadCurrencies()
        {
            cmbCurrency.Items.Clear();

            foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures))
            {
                int idx = cmbCurrency.Items.Add(culture);

                if (culture.Name == AppController.LocalSettings.CustomCulture)
                    cmbCurrency.SelectedIndex = idx;
            }
        }

        private void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            CultureInfo culture = (CultureInfo)cmbCurrency.Items[cmbCurrency.SelectedIndex];
            lblCurrency.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN, culture.Name,
                Library.Utils.SharedUtils.FormatMoney(0.00m, AppController.LocalCurrency));
        }

        private void cmbCurrency_Format(object sender, ListControlConvertEventArgs e)
        {
            CultureInfo culture = (CultureInfo)e.ListItem;

            e.Value = culture.NativeName;
        }


        #endregion Private Methods
    }
}
