using System.Drawing;
using Languages;

using Library;
using Library.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.Administration
{
    class ProductsCard : HomeCard
    {
        #region Private Members

        Forms.Products.AdminProducts _tabFormPage;

        #endregion Private Members

        public ProductsCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerProducts));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.Products);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.Products);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tabFormPage == null)
            {
                _tabFormPage = new Forms.Products.AdminProducts(AppController.ActiveUser, AppController.Administration);
            }

            return (_tabFormPage);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppProducts);
        }

        public override int StatusPanelCount()
        {
            return (_tabFormPage.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_tabFormPage.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_tabFormPage.GetStatusHint(index));
        }

        public override int SortOrder()
        {
            return (2000);
        }

        #region Private Members


        #endregion Private Members
    }
}
