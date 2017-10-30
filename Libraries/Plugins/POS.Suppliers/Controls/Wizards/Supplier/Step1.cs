using System;
using System.Windows.Forms;

using POS.Base.Classes;
using POS.Suppliers.Classes;

using Languages;

using Library.BOL.Countries;
using System.Globalization;

namespace POS.Suppliers.Controls.Wizards.Supplier
{
    public partial class Step1 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private SupplierWizard _supplier;

        #endregion Private Members

        #region Constructors

        public Step1()
        {
            InitializeComponent();

            LoadCountries();
        }

        public Step1(SupplierWizard supplier)
            : this()
        {
            Supplier = supplier;
        }

        #endregion Constructors

        #region Properties

        public SupplierWizard Supplier
        {
            get
            {
                return (_supplier);
            }

            set
            {
                _supplier = value;

                if (_supplier.Supplier != null)
                {
                    txtBusinessName.Text = _supplier.Supplier.BusinessName;
                    txtAddressLine1.Text = _supplier.Supplier.Addressline1;
                    txtAddressLine2.Text = _supplier.Supplier.Addressline2;
                    txtAddressLine3.Text = _supplier.Supplier.Addressline3;
                    txtCity.Text = _supplier.Supplier.City;
                    txtCounty.Text = _supplier.Supplier.County;
                    txtPostcode.Text = _supplier.Supplier.Postcode;

                    for (int i = 0; i < cmbCountry.Items.Count; i++)
                    {
                        Country country = (Country)cmbCountry.Items[i];

                        if (country.ID == _supplier.Supplier.Country.ID)
                        {
                            cmbCountry.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        #endregion Properties

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblBusinessName.Text = LanguageStrings.BusinessName;
            lblAddressLine1.Text = LanguageStrings.AddressLine1;
            lblAddressLine2.Text = LanguageStrings.AddressLine2;
            lblAddressLine3.Text = LanguageStrings.AddressLine3;
            lblCity.Text = LanguageStrings.City;
            lblCounty.Text = LanguageStrings.County;
            lblPostCode.Text = LanguageStrings.Postcode;
            lblCountry.Text = LanguageStrings.Country;
        }

        public override void PageShown()
        {
            AppController.ActiveHelpTopic = HelpTopics.SuppliersEditStep1;
        }

        public override bool CanGoNext()
        {
            return (!String.IsNullOrWhiteSpace(txtBusinessName.Text) &&
                !String.IsNullOrWhiteSpace(txtPostcode.Text));
        }

        public override bool NextClicked()
        {
            Country country = (Country)cmbCountry.SelectedItem;

            if (_supplier.IsNew)
            {
                _supplier.Supplier = new Library.BOL.Suppliers.Supplier(-1,
                    txtBusinessName.Text,
                    txtAddressLine1.Text,
                    txtAddressLine2.Text,
                    txtAddressLine3.Text,
                    txtCity.Text,
                    txtCounty.Text,
                    txtPostcode.Text,
                    country,
                    String.Empty,
                    Library.SupplierStatus.Active,
                    0,
                    0);
            }
            else
            {
                _supplier.Supplier.BusinessName = txtBusinessName.Text;
                _supplier.Supplier.Addressline1 = txtAddressLine1.Text;
                _supplier.Supplier.Addressline2 = txtAddressLine2.Text;
                _supplier.Supplier.Addressline3 = txtAddressLine3.Text;
                _supplier.Supplier.City = txtCity.Text;
                _supplier.Supplier.County = txtCounty.Text;
                _supplier.Supplier.Country = country;
                _supplier.Supplier.Postcode = txtPostcode.Text;
            }

            return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadCountries()
        {
            foreach (Country country in Countries.Get())
            {
                int idx = cmbCountry.Items.Add(country);

                if (country.ID == AppController.LocalCountry.ID)
                {
                    cmbCountry.SelectedIndex = idx;
                }
            }
        }

        private void cmbCountry_Format(object sender, ListControlConvertEventArgs e)
        {
            Country country = (Country)e.ListItem;
            e.Value = country.Name;
        }

        private void txtBusinessName_TextChanged(object sender, EventArgs e)
        {
            if (MainWizardForm != null)
                MainWizardForm.UpdateUI();
        }

        #endregion Private Methods
    }
}
