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
 *  File: Step2.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  10/11/2017  Simon Carter        Add ability to load existing settings
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using Languages;
using PointOfSale.Classes;
using POS.Base.Classes;

using System.Globalization;

namespace PointOfSale.Controls.InitialSetupWizard
{
    public partial class Step2 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private InitialSetupSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step2()
        {
            InitializeComponent();
        }

        internal Step2(InitialSetupSettings settings)
            : this()
        {
            _settings = settings;

            txtBusinessName.Text = _settings.BusinessName;
            txtAddress.Text = _settings.Address;
            txtEmail.Text = _settings.Email;
            txtRegistrationNumber.Text = _settings.RegistrationNumber;
            txtTelephone.Text = _settings.Telephone;
            txtVATNumber.Text = _settings.VatNumber;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblHeader.Text = LanguageStrings.AppCompanyDetails;
            lblBusinessName.Text = LanguageStrings.BusinessName;
            lblAddress.Text = LanguageStrings.Address;
            lblEmail.Text = LanguageStrings.Email;
            lblTelephone.Text = LanguageStrings.TelephoneNumber;
            lblCompanyRegistration.Text = LanguageStrings.CompanyRegistrationNumber;
            lblVatNo.Text = LanguageStrings.VATRegistrationNumber;
        }

        public override void PageShown()
        {
            AppController.ActiveHelpTopic = HelpTopics.InitialStep2;
        }

        public override bool NextClicked()
        {
            _settings.BusinessName = txtBusinessName.Text;
            _settings.Address = txtAddress.Text;
            _settings.Email = txtEmail.Text;
            _settings.RegistrationNumber = txtRegistrationNumber.Text;
            _settings.Telephone = txtTelephone.Text;
            _settings.VatNumber = txtVATNumber.Text;

            if (string.IsNullOrEmpty(_settings.EmailUser))
                _settings.EmailUser = txtEmail.Text;

            return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        #endregion Private Methods
    }
}
