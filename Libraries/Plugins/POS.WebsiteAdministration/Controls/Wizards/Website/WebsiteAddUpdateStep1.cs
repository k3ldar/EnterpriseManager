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
 *  File: WebsiteAddUpdateStep1.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Globalization;

using Languages;
using POS.WebsiteAdministration.Classes;

#pragma warning disable IDE1006

namespace POS.WebsiteAdministration.Controls.Wizards.Website
{
    public partial class WebsiteAddUpdateStep1 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private WebsiteWizardSettings _settings;

        #endregion Private Members

        #region Constructors

        public WebsiteAddUpdateStep1()
        {
            InitializeComponent();
        }

        public WebsiteAddUpdateStep1(WebsiteWizardSettings settings)
            :this()
        {
            _settings = settings;

            if (settings != null && settings.Website != null)
            {
                txtFTPHost.Text = settings.Website.FtpHost;
                txtFTPPassword.Text = settings.Website.FtpPassword;
                txtFTPUsername.Text = settings.Website.FtpUserName;
                txtWebsite.Text = settings.Website.URL;
                udFTPPort.Value = settings.Website.FtpPort;
                txtRootPath.Text = settings.Website.RootPath;
            }
        }

        public override void PageShown()
        {
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.WebSiteAddWebsite;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            lblFTPHost.Text = LanguageStrings.AppFTPHost;
            lblFTPPassword.Text = LanguageStrings.AppFTPPassword;
            lblFTPPort.Text = LanguageStrings.AppFTPPort;
            lblFTPUsername.Text = LanguageStrings.AppFTPUsername;
            lblWebsite.Text = LanguageStrings.Website;
            lblRootPath.Text = LanguageStrings.AppFTPRootPath;

            btnTestFTP.Text = LanguageStrings.AppMenuButtonTest;
        }

        public override bool BeforeFinish()
        {
            try
            {
                if (String.IsNullOrEmpty(txtWebsite.Text))
                    throw new Exception(LanguageStrings.AppWebsiteInvalid);

                if (String.IsNullOrEmpty(txtFTPHost.Text) ||
                    String.IsNullOrEmpty(txtFTPPassword.Text) ||
                    String.IsNullOrEmpty(txtFTPUsername.Text) ||
                    String.IsNullOrEmpty(txtRootPath.Text))
                {
                    throw new Exception(LanguageStrings.AppFTPInvalidSettings);
                }

                if (_settings.Website == null)
                {
                    _settings.Website = Library.BOL.Websites.Websites.Create(txtWebsite.Text, txtFTPHost.Text,
                        (int)udFTPPort.Value, txtFTPUsername.Text, txtFTPPassword.Text, txtRootPath.Text);
                }
                else
                {
                    _settings.Website.URL = txtWebsite.Text;
                    _settings.Website.FtpHost = txtFTPHost.Text;
                    _settings.Website.FtpPassword = txtFTPPassword.Text;
                    _settings.Website.FtpPort = (int)udFTPPort.Value;
                    _settings.Website.FtpUserName = txtFTPUsername.Text;
                    _settings.Website.RootPath = txtRootPath.Text;
                }

                return (true);
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError, err.Message);
                return (false);
            }
        }

        public override bool CanGoFinish()
        {
            return base.CanGoFinish();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnTestFTP_Click(object sender, EventArgs e)
        {
            Library.BOL.Websites.Website website = new Library.BOL.Websites.Website(-1, 
                txtWebsite.Text,
                txtFTPHost.Text, 
                (int)udFTPPort.Value, 
                txtFTPUsername.Text, 
                Library.BOL.Websites.Website.EncryptPassword(txtFTPPassword.Text),
                Base.Classes.StringConstants.SYMBOL_FORWARD_SLASH);

            try
            {
                if (website.TestFTPConnection())
                    ShowInformation(LanguageStrings.AppFTPConnection, LanguageStrings.AppFTPConnectSuccess);
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError, 
                    String.Format(LanguageStrings.AppFTPConnectionError, err.Message));
            }
        }

        #endregion Private Methods
    }
}
