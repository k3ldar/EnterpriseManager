using System;
using System.Drawing;
using Languages;

using Library;
using Library.BOL.Users;

using POS.Base.Plugins;

namespace POS.WebsiteAdministration
{
    class MissingLinksCard : HomeCard
    {
        #region Private Members

        Forms.MissingLinks.AdminMissingLinks _tabFormPage;

        #endregion Private Members

        public MissingLinksCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            // if there are no websites, then don't show
            if (WebsiteAdministrationPluginModule.WebsiteCount == 0)
                return (false);

            return (user.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.AdministerMissingLinks));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.MissingLinks);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.WebMissingLinks);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tabFormPage == null)
            {
                _tabFormPage = new Forms.MissingLinks.AdminMissingLinks();
            }

            return (_tabFormPage);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppMissingLinks);
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
            return (30020);
        }

        #region Private Members


        #endregion Private Members
    }
}