/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: Step5.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  10/11/2017  Simon Carter        Add ability to load existing settings
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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

            txtEmailHost.Text = _settings.EmailHost;
            txtEmailPassword.Text = _settings.EmailPassword;
            udEmailPort.Value = Shared.Utilities.CheckMinMax(_settings.EmailPort, 1, 65535);
            txtEmailUsername.Text = _settings.EmailUser;
            cbUseSSL.Checked = _settings.EmailSSL;

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
