using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using POS.Base.Classes;

namespace POS.Marketing.Controls
{
    public partial class GeneralSettings : SharedControls.BaseSettings
    {
        public GeneralSettings()
        {
            InitializeComponent();
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            cbAutoUpdateMarketingFiles.Text = Languages.LanguageStrings.AppUpdateMarketingFilesAtStart;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.UpdateMarketingFilesAtStart = cbAutoUpdateMarketingFiles.Checked;

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            cbAutoUpdateMarketingFiles.Checked = AppController.LocalSettings.UpdateMarketingFilesAtStart;
        }

        #endregion Overridden Methods

    }
}
