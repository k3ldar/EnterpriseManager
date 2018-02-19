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
 *  File: FinalStep.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Languages;
using PointOfSale.Classes;
using POS.Base.Classes;

using System.Globalization;

namespace PointOfSale.Controls.InitialSetupWizard
{
    public partial class FinalStep : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private InitialSetupSettings _settings;

        #endregion Private Members

        #region Constructors

        public FinalStep()
        {
            InitializeComponent();
        }

        internal FinalStep(InitialSetupSettings settings)
            : this()
        {
            _settings = settings;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblHeader.Text = LanguageStrings.InitialSetupFinalTitle;
        }

        public override void PageShown()
        {
            AppController.ActiveHelpTopic = HelpTopics.InitialFinal;

            lblDetails.Text = String.Format(LanguageStrings.InitialSetupFinal,
                AppController.LocalSettings.DefaultCountry,
                System.Threading.Thread.CurrentThread.CurrentUICulture.DisplayName,
                AppController.LocalSettings.CurrencyBase,
                String.IsNullOrWhiteSpace(_settings.BusinessName) ? LanguageStrings.NotSet : _settings.BusinessName,
                String.IsNullOrWhiteSpace(_settings.Telephone) ? LanguageStrings.NotSet : _settings.Telephone,
                String.IsNullOrWhiteSpace(_settings.Email) ? LanguageStrings.NotSet : _settings.Email,
                String.IsNullOrWhiteSpace(_settings.Address) ? LanguageStrings.NotSet : _settings.Address,
                String.IsNullOrWhiteSpace(_settings.Logo) ? LanguageStrings.NotSet : LanguageStrings.Set,
                _settings.Website == null ? LanguageStrings.NotSet : _settings.Website.URL,
                _settings.Website == null || (_settings.Website != null && String.IsNullOrEmpty(_settings.Website.FtpHost)) ?
                    LanguageStrings.NotSet : _settings.FTPTested ? LanguageStrings.SetAndTested : LanguageStrings.SetNotTested,
                String.IsNullOrEmpty(_settings.EmailHost) ? LanguageStrings.NotSet :
                    _settings.EmailTested ? LanguageStrings.SetAndTested : LanguageStrings.SetNotTested);
        }

        public override bool BeforeFinish()
        {
            AppController.LocalSettings.BusinessAddress = _settings.Address;
            AppController.LocalSettings.BusinessEmail = _settings.Email;
            AppController.LocalSettings.BusinessName = _settings.BusinessName;
            AppController.LocalSettings.BusinessRegNo = _settings.RegistrationNumber;
            AppController.LocalSettings.BusinessVatNo = _settings.VatNumber;
            AppController.LocalSettings.BusinessTelephone = _settings.Telephone;

            if (_settings.Website != null && _settings.Website.ID == -1)
                _settings.Website.Save();

            AppController.LocalSettings.EmailPassword = _settings.EmailPassword;
            AppController.LocalSettings.EmailPort = _settings.EmailPort;
            AppController.LocalSettings.EmailServer = _settings.EmailHost;
            AppController.LocalSettings.EmailSSL = _settings.EmailSSL;
            AppController.LocalSettings.EmailUser = _settings.EmailUser;

            if (_settings.EmailTested)
            {
                Shared.Communication.Email email = new Shared.Communication.Email(_settings.EmailUser, _settings.EmailHost,
                    _settings.EmailUser, _settings.EmailPassword, _settings.EmailPort, _settings.EmailSSL);
                email.Save();
            }

            ImageData imgData = new ImageData(ImageTypes.Logo, AppController.POSFolder(ImageTypes.Logo));

            if (AppController.POSFolder(ImageTypes.Logo) +
                ImageTypes.Logo.ToString() +
                StringConstants.IMAGE_DEFAULT
                + StringConstants.FILE_EXTENSION_JPG != _settings.Logo)
            {
                imgData.GenerateImages(_settings.Logo);
            }

            AppController.SaveSettings();

            return base.BeforeFinish();
        }

        #endregion Overridden Methods

        #region Private Methods

        #endregion Private Methods
    }
}
