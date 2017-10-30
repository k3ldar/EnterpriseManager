using System;
using System.Windows.Forms;

using Languages;
using POS.Base.Classes;
using Library.BOL.Products;

namespace POS.Administration.Forms.Products
{
    public partial class EditProductItem : POS.Base.Forms.BaseForm
    {
        #region Constructors

        public EditProductItem()
        {
            InitializeComponent();
        }

        public EditProductItem(ProductCost productCost, bool allowCancel)
            : this()
        {
            adminProductItemEdit1.Refresh(productCost);

            btnCancel.Enabled = allowCancel;
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.ProductEditItem;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppProductEditItem;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                adminProductItemEdit1.Save();
                PluginManager.RaiseEvent(StringConstants.PLUGIN_EVENT_PRODUCT_ADD_REMOVE_UPDATE);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_LOCK_CONFLICT))
                {
                    ShowError(LanguageStrings.AppLockConflict, LanguageStrings.AppLockConflictStatement);
                }
                else if (err.Message.Contains(StringConstants.ERROR_INVALID_SKU))
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppErrorInvalidSKU);
                }
                else if (err.Message.Contains(StringConstants.ERROR_DIPLICATE_SKU))
                {
                    ProductCost cost = ProductCosts.GetBySKU(adminProductItemEdit1.SKU);
                    ShowError(LanguageStrings.AppError, String.Format(LanguageStrings.AppErrorDuplicateSKU, cost.Product.Name, cost.Size));
                }
                else
                {
                    ShowError(LanguageStrings.AppError, err.Message);
                }
            }
        }

        #endregion Private Methods
    }
}
