using System;
using System.Globalization;
using System.Windows.Forms;

using Languages;

using Library.BOL.Products;

using POS.Administration.Classes;


namespace POS.Administration.Forms.Categories
{
    public partial class ProductGroupCategoryTypeForm : BaseCategoryEditAddForm
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public ProductGroupCategoryTypeForm()
            :base (CategoryType.ProductGroupTypes)
        {
            InitializeComponent();
        }

        public ProductGroupCategoryTypeForm(ref ProductGroupType groupType)
            : this()
        {
            GroupType = groupType;
            IsNew = GroupType == null;

            if (!IsNew)
            {
                Description = groupType.Description;
            }
        }

        #endregion Constructors

        #region Properties

        private ProductGroupType GroupType { get; set; }

        #endregion Properties

        #region Overridden Methods

        protected override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            this.Text = LanguageStrings.AppProductGroupType;
        }

        protected override void btnOKClick(object sender, EventArgs e)
        {
            if (IsNew)
            {
                GroupType = ProductGroupTypes.Create(Description);
            }
            else
            {
                GroupType.Description = Description;
                GroupType.Save();
            }

            DialogResult = DialogResult.OK;
        }

        #endregion Overridden Methods

        #region Static Methods

        public static bool ShowCategoryForm(ref ProductGroupType productGroupType)
        {
            bool Result = false;

            ProductGroupCategoryTypeForm frm = new ProductGroupCategoryTypeForm(ref productGroupType);
            try
            {
                Result = frm.ShowDialog() == DialogResult.OK;

                productGroupType = frm.GroupType;
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