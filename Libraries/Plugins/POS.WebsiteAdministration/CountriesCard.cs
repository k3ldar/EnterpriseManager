using System.Drawing;

using Languages;

using Library;
using Library.BOL.Users;

using POS.Base.Plugins;


namespace POS.WebsiteAdministration
{
    class CountriesCard : HomeCard
    {
        #region Private Members

        Forms.CountryAdmin.AdminEditCountries _tabFormPage;

        #endregion Private Members

        public CountriesCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.AdministerCountries));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.Countries);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.Countries);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tabFormPage == null)
            {
                _tabFormPage = new Forms.CountryAdmin.AdminEditCountries();
            }

            return (_tabFormPage);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppCountries);
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
            return (30000);
        }

        #region Private Members


        #endregion Private Members
    }
}
