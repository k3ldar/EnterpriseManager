using System.Drawing;
using Languages;

using Library;
using Library.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.WebsiteAdministration
{
    class UpdateDistributorDetailsCard : HomeCard
    {
        #region Private Members

        Forms.Distributors.AdminSalonUpdates _tabFormPage;

        #endregion Private Members

        public UpdateDistributorDetailsCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            // if there are no websites, then don't show
            if (WebsiteAdministrationPluginModule.WebsiteCount == 0)
                return (false);

            return (user.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.AdministerDistributors));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.UpdateDistributorDetails);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.WebSalonUpdate);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tabFormPage == null)
            {
                _tabFormPage = new Forms.Distributors.AdminSalonUpdates(AppController.ActiveUser);
            }

            return (_tabFormPage);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppDistributorUpdates);
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

        public override Color ButtonFromColor()
        {
            return (Color.Purple);
        }

        public override Color ButtonToColor()
        {
            return (Color.MediumPurple);
        }

        public override int SortOrder()
        {
            return (30060);
        }

        #region Private Members


        #endregion Private Members
    }
}
