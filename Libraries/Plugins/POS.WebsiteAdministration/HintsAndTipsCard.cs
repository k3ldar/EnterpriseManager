using System;
using System.Drawing;
using Languages;
using Library;
using Library.BOL.Users;

using POS.Base.Plugins;

namespace POS.WebsiteAdministration
{
    class HintsAndTipsCard : HomeCard
    {
        #region Private Members

        Forms.TipsAndTricks.AdminTipsAndTricks _tabFormPage;

        #endregion Private Members

        public HintsAndTipsCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            // if there are no websites, then don't show
            if (WebsiteAdministrationPluginModule.WebsiteCount == 0)
                return (false);

            return (user.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.AdministerTipsTricks));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.TipsAndTricks);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.WebTipsAndTricks);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tabFormPage == null)
            {
                _tabFormPage = new Forms.TipsAndTricks.AdminTipsAndTricks();
            }

            return (_tabFormPage);
        }

        public override string GetName()
        {
            return (LanguageStrings.TipsAndTricks);
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
            return (30070);
        }

        #region Private Members


        #endregion Private Members
    }
}
