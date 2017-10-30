using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using POS.Base.Classes;

namespace POS.CashManager.Classes
{
    public partial class CashDrawerSettings : SharedControls.BaseSettings
    {
        public CashDrawerSettings()
        {
            InitializeComponent();
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblSpotChecks.Text = Languages.LanguageStrings.AppBypassSpotChecks;
            lblTimes.Text = Languages.LanguageStrings.AppTimes;
            cbCashDrawerForceChecks.Text = Languages.LanguageStrings.AppForceChecks;
            cbCashDrawBypassStart.Text = Languages.LanguageStrings.AppBypassStartOfDayChecks;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.CashDrawerBypassStartOfDay = cbCashDrawBypassStart.Checked;
            AppController.LocalSettings.CashDrawerForceChecks = cbCashDrawerForceChecks.Checked;
            AppController.LocalSettings.CashDrawerMaximumBypassCount = (int)udCashDrawBypassCount.Value;

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            cbCashDrawBypassStart.Checked = AppController.LocalSettings.CashDrawerBypassStartOfDay;
            cbCashDrawerForceChecks.Checked = AppController.LocalSettings.CashDrawerForceChecks;
            udCashDrawBypassCount.Value = AppController.LocalSettings.CashDrawerMaximumBypassCount;
        }

        #endregion Overridden Methods

    }
}
