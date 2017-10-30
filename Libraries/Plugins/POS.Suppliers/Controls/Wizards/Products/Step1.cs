using System;
using System.Windows.Forms;
using System.Globalization;

using Languages;

using Library;
using Library.BOL.Suppliers;

using POS.Base;
using POS.Base.Classes;
using POS.Suppliers.Classes;

namespace POS.Suppliers.Controls.Wizards.Products
{
    public partial class Step1 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private SupplierProductWizard _wizard;

        #endregion Private Members

        #region Constructors

        public Step1()
        {
            InitializeComponent();

            LoadAssetTypes();
        }

        public Step1(SupplierProductWizard wizard)
            : this()
        {
            _wizard = wizard;

            if (wizard.IsNew)
            {
                cmbAssetType.SelectedIndex = 0;
            }
            else
            {
                txtMake.Text = wizard.Product.Make;
                txtModel.Text = wizard.Product.Model;
                txtName.Text = wizard.Product.Name;
                txtNotes.Text = wizard.Product.Notes;
                txtSKU.Text = wizard.Product.SKU;
                udNetCost.Value = wizard.Product.NetCost;

                for (int i = 0; i < cmbAssetType.Items.Count; i++)
                {
                    AssetType type = (AssetType)cmbAssetType.Items[i];

                    if (type == wizard.Product.AssetType)
                    {
                        cmbAssetType.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblAssetType.Text = LanguageStrings.AppProductType;
            lblMake.Text = LanguageStrings.AppProductMake;
            lblModel.Text = LanguageStrings.AppProductModel;
            lblName.Text = LanguageStrings.AppName;
            lblNotes.Text = LanguageStrings.Notes;
            lblSKU.Text = LanguageStrings.AppSKU;
            lblCost.Text = LanguageStrings.AppCost;
        }

        public override bool CanGoFinish()
        {
            return (!String.IsNullOrEmpty(txtName.Text));
        }

        public override bool BeforeFinish()
        {
            if (_wizard.IsNew)
            {
                _wizard.Product = new SupplierProduct(-1, _wizard.Supplier,
                    txtName.Text, txtMake.Text, txtModel.Text,
                    txtSKU.Text, txtNotes.Text, 0, udNetCost.Value,
                    (AssetType)cmbAssetType.SelectedItem);
            }
            else
            {
                _wizard.Product.AssetType = (AssetType)cmbAssetType.SelectedItem;
                _wizard.Product.Make = txtMake.Text;
                _wizard.Product.Model = txtModel.Text;
                _wizard.Product.Name = txtName.Text;
                _wizard.Product.Notes = txtNotes.Text;
                _wizard.Product.SKU = txtSKU.Text;
                _wizard.Product.NetCost = udNetCost.Value;
            }

            SupplierProducts.InsertUpdate(_wizard.Product);

            return (true);
        }

        public override void PageShown()
        {
            AppController.ActiveHelpTopic = HelpTopics.SupplierProductStep1;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadAssetTypes()
        {
            cmbAssetType.Items.Clear();

            foreach (AssetType assetType in Enum.GetValues(typeof(AssetType)))
            {
                cmbAssetType.Items.Add(assetType);
            }
        }

        private void cmbAssetType_Format(object sender, ListControlConvertEventArgs e)
        {
            AssetType assetType = (AssetType)e.ListItem;
            e.Value = EnumTranslations.Translate(assetType);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (MainWizardForm != null)
                MainWizardForm.UpdateUI();
        }

        private void udNetCost_Enter(object sender, EventArgs e)
        {
            udNetCost.Select(0, udNetCost.Text.Length);
        }

        #endregion Private Methods
    }
}
