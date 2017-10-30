
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
