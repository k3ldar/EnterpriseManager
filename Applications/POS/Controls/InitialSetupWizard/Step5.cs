using System;

using Languages;
using PointOfSale.Classes;
using POS.Base.Classes;

using System.Globalization;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace PointOfSale.Controls.InitialSetupWizard
{
    public partial class Step5 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private InitialSetupSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step5()
        {
            InitializeComponent();
        }

        internal Step5(InitialSetupSettings settings)
            : this()
        {
            _settings = settings;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblHeader.Text = LanguageStrings.AppEmailConnection;

            lblEmailHost.Text = LanguageStrings.EmailHost;
            lblEmailPassword.Text = LanguageStrings.EmailPassword;
            lblEmailPort.Text = LanguageStrings.EmailPort;
            lblEmailUsername.Text = LanguageStrings.Username;
            cbUseSSL.Text = LanguageStrings.EmailSSL;

            btnTestEmail.Text = LanguageStrings.AppMenuButtonTest;
        }

        public override void PageShown()
        {
            AppController.ActiveHelpTopic = HelpTopics.InitialStep5;
        }

        public override bool NextClicked()
        {
            try
            {
                _settings.EmailHost = txtEmailHost.Text;
                _settings.EmailPassword = txtEmailPassword.Text;
                _settings.EmailPort = (int)udEmailPort.Value;
                _settings.EmailUser = txtEmailUsername.Text;
                _settings.EmailSSL = cbUseSSL.Checked;

                return (true);
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError, err.Message);
                return (false);
            }
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnTestEmail_Click(object sender, EventArgs e)
        {
            try
            {
                Shared.Communication.Email email = new Shared.Communication.Email(txtEmailUsername.Text,
                    txtEmailHost.Text, txtEmailUsername.Text, txtEmailPassword.Text, (int)udEmailPort.Value,
                    cbUseSSL.Checked);

                if (email.SendTestEmail())
                {
                    _settings.EmailTested = true;
                    ShowInformation(LanguageStrings.AppEmailConnection,
                        LanguageStrings.AppEmailConnectSuccess);
                }
                else
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppEmailInvalidSettings);
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError,
                    String.Format(LanguageStrings.AppEmailConnectionError, err.Message));
            }
        }

        #endregion Private Methods
    }
}
