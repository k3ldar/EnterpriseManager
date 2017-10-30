using System.Drawing;

using Languages;

using Library;
using Library.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.Administration
{
    class ProductGroupCard : HomeCard
    {
        #region Private Members

        Forms.Products.AdminProductGroups _tabFormPage;

        #endregion Private Members

        public ProductGroupCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerProducts));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.ProductGroups);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.ProductGroups);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tabFormPage == null)
            {
                _tabFormPage = new Forms.Products.AdminProductGroups(AppController.Administration);
            }

            return (_tabFormPage);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppProductGroups);
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
            return (2010);
        }

        #region Private Members


        #endregion Private Members
    }
}
