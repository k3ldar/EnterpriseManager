using System.Drawing;
using Languages;

using Library;
using Library.BOL.Users;
using POS.Base.Plugins;

namespace POS.Administration
{
    class CategoriesCard : HomeCard
    {
        #region Private Members

        Forms.Categories.CategoriesTab _tabFormPage;

        #endregion Private Members

        public CategoriesCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ManageCategoryTypes));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.CardFiles);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.CategoryTypes);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tabFormPage == null)
            {
                _tabFormPage = new Forms.Categories.CategoriesTab();
            }

            return (_tabFormPage);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppTypesAndCateogories);
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

        #region Private Members


        #endregion Private Members
    }
}