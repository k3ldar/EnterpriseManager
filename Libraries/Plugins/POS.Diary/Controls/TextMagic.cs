using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Library.BOL.Countries;
using POS.Base.Classes;

namespace POS.Diary.Controls
{
    public partial class TextMagic : SharedControls.BaseSettings
    {
        #region Constructors

        public TextMagic()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblAPIKey.Text = Languages.LanguageStrings.AppAPIKeyInput;
            lblSenderName.Text = Languages.LanguageStrings.AppSenderName;
            lblUserName.Text = Languages.LanguageStrings.Username;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.TextMagicAPI = txtAPIKEy.Text;
            AppController.LocalSettings.TextMagicSender = txtSenderName.Text;
            AppController.LocalSettings.TextMagicUsername = txtUserName.Text;

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            txtAPIKEy.Text = AppController.LocalSettings.TextMagicAPI;
            txtSenderName.Text = AppController.LocalSettings.TextMagicSender;
            txtUserName.Text = AppController.LocalSettings.TextMagicUsername;
        }

        #endregion Overridden Methods
    }
}
