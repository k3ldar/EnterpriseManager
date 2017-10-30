using System;
using System.Globalization;
using System.Windows.Forms;

using Languages;

using Library;
using Library.BOL.Products;

using POS.Administration.Classes;

namespace POS.Administration.Forms.Categories
{
    public partial class ProductCostCategoryTypeForm : Base.Forms.BaseForm
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public ProductCostCategoryTypeForm()
        {
            InitializeComponent();
        }

        public ProductCostCategoryTypeForm(ref ProductCostType productCostType)
            : this()
        {
            ProdCostType = productCostType;
            IsNew = ProdCostType == null;

            if (!IsNew)
            {
                Description = productCostType.Description;
            }

            foreach (ProductCostItemType type in Enum.GetValues(typeof(ProductCostItemType)))
            {
                int idx = cmbItemType.Items.Add(type);

                if (!IsNew && ProdCostType.ItemType == type)
                {
                    cmbItemType.SelectedIndex = idx;
                    cmbItemType.Enabled = false;
                }
            }

            if (cmbItemType.SelectedIndex == -1)
                cmbItemType.SelectedIndex = 0;
        }

        #endregion Constructors

        #region Properties

        protected ProductCostType ProdCostType { get; set; }

        protected bool IsNew { get; set; }

        /// <summary>
        /// description
        /// </summary>
        protected string Description
        {
            get
            {
                return (txtName.Text);
            }

            set
            {
                txtName.Text = value;
            }
        }

        protected ProductCostItemType ItemType { get; set; }

        #endregion Properties

        #region Overridden Methods

        protected override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            this.Text = LanguageStrings.AppProductCostType;
            lblName.Text = LanguageStrings.Description;
            lblItemType.Text = LanguageStrings.AppItemType;
            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnOK.Text = LanguageStrings.AppMenuButtonOK;
        }

        #endregion Overridden Methods

        #region Static Methods

        public static bool ShowCategoryForm(ref ProductCostType productCostType)
        {
            bool Result = false;

            ProductCostCategoryTypeForm frm = new ProductCostCategoryTypeForm(ref productCostType);
            try
            {
                Result = frm.ShowDialog() == DialogResult.OK;

                productCostType = frm.ProdCostType;
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
