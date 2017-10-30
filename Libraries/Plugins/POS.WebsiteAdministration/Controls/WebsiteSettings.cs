using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using POS.Base.Classes;

namespace POS.WebsiteAdministration.Controls
{
    public partial class WebsiteSettings : SharedControls.BaseSettings
    {
        public WebsiteSettings()
        {
            InitializeComponent();
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            cbWebsiteMenus.Text = Languages.LanguageStrings.AppShowWebsiteMenus;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.ShowWebsiteMenuItem = cbWebsiteMenus.Checked;

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            cbWebsiteMenus.Checked = AppController.LocalSettings.ShowWebsiteMenuItem;
        }

        #endregion Overridden Methods
    }
}
