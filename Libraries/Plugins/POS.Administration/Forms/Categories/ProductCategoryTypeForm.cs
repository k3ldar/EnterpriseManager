using System;
using System.Globalization;
using System.Windows.Forms;

using Languages;

using Library.BOL.Products;

using POS.Administration.Classes;

namespace POS.Administration.Forms.Categories
{
    public partial class ProductCategoryTypeForm : BaseCategoryEditAddForm
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public ProductCategoryTypeForm()
            :base (CategoryType.ProductTypes)
        {
            InitializeComponent();
        }

        public ProductCategoryTypeForm(ref ProductType productType)
            : this()
        {
            ProdType = productType;
            IsNew = ProdType == null;

            if (!IsNew)
            {
                Description = productType.Description;
                cbPrimary.Checked = productType.PrimaryType;
            }
        }

        #endregion Constructors

        #region Properties

        private ProductType ProdType { get; set; }

        #endregion Properties

        #region Overridden Methods

        protected override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            this.Text = LanguageStrings.AppProductType;
            cbPrimary.Text = LanguageStrings.AppPrimary;
        }

        protected override void btnOKClick(object sender, EventArgs e)
        {
            if (IsNew)
            {
                ProdType = ProductTypes.Create(Description, cbPrimary.Checked);
            }
            else
            {
                ProdType.Description = Description;
                ProdType.PrimaryType = cbPrimary.Checked;
                ProdType.Save();
            }

            DialogResult = DialogResult.OK;
        }

        #endregion Overridden Methods

        #region Static Methods

        public static bool ShowCategoryForm(ref ProductType productType)
        {
            bool Result = false;

            ProductCategoryTypeForm frm = new ProductCategoryTypeForm(ref productType);
            try
            {
                Result = frm.ShowDialog() == DialogResult.OK;

                productType = frm.ProdType;
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }

            return (Result);
        }

        #endregion Static Methods
    }
}
