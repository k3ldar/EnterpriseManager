using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using POS.Base.Classes;

using PointOfSale.Classes;

namespace PointOfSale.Controls.Settings.Admin
{
    public partial class LogInOut : SharedControls.BaseSettings
    {
        public LogInOut()
        {
            InitializeComponent();

            udTimeout.Value = AppController.LocalSettings.AutoLogoutTimeOut / 60;
            cbAutoLogout.Checked = AppController.LocalSettings.AutoLogout;

            cbAutoLogout_CheckedChanged(this, EventArgs.Empty);
        }


        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            cbAutoLogout.Text = Languages.LanguageStrings.AppAutoLogout;
            lblLogoutDesc1.Text = Languages.LanguageStrings.AppLogoutAfter;
            lblLogoutDesc2.Text = Languages.LanguageStrings.AppMinutesOfInactivity;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.AutoLogout = cbAutoLogout.Checked;
            AppController.LocalSettings.AutoLogoutTimeOut = (uint)udTimeout.Value * 60;

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
        }

        #endregion Overridden Methods

        #region Private Methods

        private void cbAutoLogout_CheckedChanged(object sender, EventArgs e)
        {
            lblLogoutDesc1.Enabled = cbAutoLogout.Checked;
            lblLogoutDesc2.Enabled = cbAutoLogout.Checked;
            udTimeout.Enabled = cbAutoLogout.Checked;
        }

        #endregion Private Methods

    }
}
