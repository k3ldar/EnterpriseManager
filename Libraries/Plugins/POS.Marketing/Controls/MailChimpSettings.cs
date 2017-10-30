using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using POS.Base.Classes;
using POS.Marketing.Classes;

namespace POS.Marketing.Controls
{
    public partial class MailChimpSettings : SharedControls.BaseSettings
    {
        #region Constructors

        public MailChimpSettings()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblAPIKey.Text = String.Format(LanguageStrings.AppAPIKey, StringConstants.MAIL_CHIMP);
            btnTest.Text = LanguageStrings.AppMenuButtonTest;

            gbDefaultOptions.Text = LanguageStrings.AppOptions;
            cbAddFooter.Text = LanguageStrings.AppAddFooter;
            cbGoogleAnalytics.Text = LanguageStrings.AppGoogleAnalytics;
            cbPostToFaceBook.Text = LanguageStrings.AppPostToFacebook;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.MailChimpAPI = txtMailChimpAPIKey.Text;
            AppController.LocalSettings.MailChimpFooter = cbAddFooter.Checked;

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            txtMailChimpAPIKey.Text = AppController.LocalSettings.MailChimpAPI;
            cbAddFooter.Checked = AppController.LocalSettings.MailChimpFooter;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnTest_Click(object sender, EventArgs e)
        {
            MailChimpWrapper wrapper = new MailChimpWrapper(txtMailChimpAPIKey.Text);
            try
            {
                IEnumerable<MailChimp.Net.Models.List> lists = wrapper.ListsGet();
                ShowInformation(LanguageStrings.AppMailChimp, LanguageStrings.AppMailChimpTestSuccessful);
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError, err.Message);
            }
            finally
            {
                wrapper = null;
            }
        }

        #endregion Private Methods
    }
}
