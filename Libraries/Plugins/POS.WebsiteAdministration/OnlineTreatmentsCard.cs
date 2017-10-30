using System.Drawing;

using Languages;

using Library;
using Library.BOL.Users;

using POS.Base.Plugins;

namespace POS.WebsiteAdministration
{
    class OnlineTreatmentsCard : HomeCard
    {
        #region Private Members

        Forms.Treatments.AdminTreatments _tabFormPage;

        #endregion Private Members

        public OnlineTreatmentsCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            // if there are no websites, then don't show
            if (WebsiteAdministrationPluginModule.WebsiteCount == 0)
                return (false);

            return (user.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.AdministerTreatments));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.OnlineTreatments);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.WebTreatments);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tabFormPage == null)
            {
                _tabFormPage = new Forms.Treatments.AdminTreatments();
            }

            return (_tabFormPage);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppTreatmentsOnline);
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
            return (30005);
        }

        #region Private Members


        #endregion Private Members
    }
}
