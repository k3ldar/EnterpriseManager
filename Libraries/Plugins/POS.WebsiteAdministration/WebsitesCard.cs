using System.Drawing;
using Languages;

using Library;
using Library.BOL.Users;

using POS.Base.Plugins;

namespace POS.WebsiteAdministration
{
    class WebsitesCard : HomeCard
    {
        #region Private Members

        Forms.AdminWebsites _tabFormPage;

        #endregion Private Members

        public WebsitesCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.AdministerWebsites));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.Websites);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.WebDistributors);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tabFormPage == null)
            {
                _tabFormPage = new Forms.AdminWebsites();
            }

            return (_tabFormPage);
        }

        public override string GetName()
        {
            return (LanguageStrings.Websites);
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
            return (20000);
        }

        #region Private Members


        #endregion Private Members
    }
}