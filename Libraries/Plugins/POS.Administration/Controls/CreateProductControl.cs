using System;
using System.Reflection;
using System.Windows.Forms;

using Library;
using Library.BOL.Products;

using Languages;
using POS.Base.Classes;


namespace POS.Administration.Controls
{
    public partial class CreateProductControl : SharedControls.BaseControl
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public CreateProductControl()
        {
            InitializeComponent();

            if (AppController.ApplicationRunning)
            {
                LoadPrimaryTypes();
                LoadGroups();
                cmbGroup.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbGroup_Format);
                cmbPrimaryType.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbPrimaryType_Format);
            }
        }

        #endregion Constructors

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblPrimaryProduct.Text = Languages.LanguageStrings.AppPrimaryProduct;
            lblProductName.Text = Languages.LanguageStrings.AppProductName;
            lblPrimaryGroup.Text = Languages.LanguageStrings.AppProductGroup;
        }


        #region Public Methods

        public Product Create(WebsiteAdministration admin)
        {
            Product Result = null;

            try
            {
                if (String.IsNullOrEmpty(txtProductName.Text))
                {
                    ShowError(LanguageStrings.AppProductNewProduct, LanguageStrings.AppProductNameMissing);
                    return (Result);
                }

                if (cmbGroup.SelectedIndex == -1)
                {
                    ShowError(LanguageStrings.AppProductNewProduct, LanguageStrings.AppProductNewSelectGroup);
                    return (Result);
                }

                if (cmbPrimaryType.SelectedIndex == -1)
                {
                    ShowError(LanguageStrings.AppProductNewProduct, LanguageStrings.AppProductNewSelectPrimaryType);
                    return (Result);
                }

                Result = admin.ProductInsert(txtProductName.Text.Trim(), 
                    (ProductType)cmbPrimaryType.Items[cmbPrimaryType.SelectedIndex],
                    (ProductGroup)cmbGroup.Items[cmbGroup.SelectedIndex]);

            }
            catch (Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_VIOLATION_PRODUCT_PRODUCT_NAME))
                {
                    ShowError(Languages.LanguageStrings.AppCreateProduct,
                        String.Format(Languages.LanguageStrings.AppCreateProductExistsGroup, txtProductName.Text,
                        ((ProductType)cmbPrimaryType.Items[cmbPrimaryType.SelectedIndex]).Description));
                }
                else
                {
                    ErrorHandling.LogError(MethodBase.GetCurrentMethod(), err);
                    ShowError(Languages.LanguageStrings.AppError,
                        String.Format(Languages.LanguageStrings.AppErrorCreatingProduct, err.Message));
                }
            }

            return (Result);
        }

        #endregion public Methods

        #region Private Methods

        private void LoadGroups()
        {
            cmbGroup.Items.Clear();

            foreach (ProductGroup group in ProductGroups.Get(MemberLevel.StandardUser, false))
            {
                cmbGroup.Items.Add(group);
            }

            if (cmbGroup.Items.Count > 0)
                cmbGroup.SelectedIndex = 0;
        }

        private void LoadPrimaryTypes()
        {
            cmbPrimaryType.Items.Clear();

            foreach (ProductType item in ProductTypes.Get())
            {
                cmbPrimaryType.Items.Add(item);
            }

            if (cmbPrimaryType.Items.Count > 0)
                cmbPrimaryType.SelectedIndex = 0;
        }

        private void cmbPrimaryType_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductType primary = (ProductType)e.ListItem;
            e.Value = primary.Description;
        }

        private void cmbGroup_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductGroup group = (ProductGroup)e.ListItem;
            e.Value = group.Description;
        }

        #endregion Private Methods
    }
}
