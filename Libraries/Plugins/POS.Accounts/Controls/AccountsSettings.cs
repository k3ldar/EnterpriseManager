using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using POS.Base.Classes;

using Languages;

namespace POS.Accounts.Controls
{
    public partial class AccountsSettings : SharedControls.BaseSettings
    {
        #region Constructors

        public AccountsSettings()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblAccountYearEnd.Text = LanguageStrings.AppAccountsYearEnd;
            lblAccountYearStart.Text = LanguageStrings.AppAccountsYearStart;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.AccountYearStart = dtpAccountYearStart.Value;
            AppController.LocalSettings.AccountYearEnd = dtpAccountYearEnd.Value;

            return (base.SettingsSave());
        }

        public override void SettingsLoaded()
        {
            dtpAccountYearStart.Value = AppController.LocalSettings.AccountYearStart;
            dtpAccountYearEnd.Value = AppController.LocalSettings.AccountYearEnd;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void dtpAccountYearStart_ValueChanged(object sender, EventArgs e)
        {
            dtpAccountYearEnd.Value = dtpAccountYearStart.Value.AddYears(1).AddDays(-1);
        }


        #endregion Private Methods
    }
}
