using System;
using System.Reflection;
using System.Windows.Forms;

using Library;
using Library.BOL.Products;

using Languages;
using POS.Base.Classes;

namespace POS.Administration.Controls
{
    public partial class CreateProductGroupControl : SharedControls.BaseControl
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public CreateProductGroupControl()
        {
            InitializeComponent();

            if (AppController.ApplicationRunning)
            {
                LoadPrimaryTypes();
                cmbPrimaryType.Format += new ListControlConvertEventHandler(cmbPrimaryType_Format);
            }
        }

        #endregion Constructors

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblGroupName.Text = LanguageStrings.AppProductGroupName;
            lblPrimaryProductGroup.Text = LanguageStrings.AppProductGroupPrimaryType;
        }


        #region Public Methods

        public ProductGroup Create(WebsiteAdministration admin)
        {
            ProductGroup Result = null;

            try
            {
                if (String.IsNullOrEmpty(txtProductGroupName.Text))
                {
                    ShowError(LanguageStrings.AppProductNewProduct, LanguageStrings.AppProductNameMissing);
                    return (Result);
                }

                if (cmbPrimaryType.SelectedIndex == -1)
                {
                    ShowError(LanguageStrings.AppProductNewProduct, LanguageStrings.AppProductNewSelectPrimaryType);
                    return (Result);
                }

                Result = admin.ProductGroupCreate(txtProductGroupName.Text,
                    (ProductGroupType)cmbPrimaryType.Items[cmbPrimaryType.SelectedIndex]);
            }
            catch (Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_VIOLATION_UNIQUE_KEY))
                {
                    ShowError(LanguageStrings.AppError,
                        String.Format(LanguageStrings.AppCreateProductGroupExists, txtProductGroupName.Text,
                        ((ProductType)cmbPrimaryType.Items[cmbPrimaryType.SelectedIndex]).Description));
                }
                else
                {
                    ErrorHandling.LogError(MethodBase.GetCurrentMethod(), err);
                    ShowError(LanguageStrings.AppError,
                        String.Format(LanguageStrings.AppErrorCreatingProductGroup, err.Message));
                }
            }

            return (Result);
        }

        #endregion public Methods

        #region Private Methods

        private void LoadPrimaryTypes()
        {
            cmbPrimaryType.Items.Clear();

            foreach (ProductGroupType item in ProductGroupTypes.Get())
            {
                cmbPrimaryType.Items.Add(item);
            }

            cmbPrimaryType.SelectedIndex = 0;
        }

        private void cmbPrimaryType_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductGroupType primary = (ProductGroupType)e.ListItem;
            e.Value = primary.Description;
        }

        #endregion Private Methods
    }
}
