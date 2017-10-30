using System.Drawing;
using Languages;

using Library;
using Library.BOL.Users;
using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.Administration
{
    class SystemEmailCard : HomeCard
    {
        #region Private Members

        Forms.Emails.AdminSystemEmails _tabFormPage;

        #endregion Private Members

        public SystemEmailCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerSystemEmails));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.SystemEmails);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.AdminSystemEmails);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tabFormPage == null)
            {
                _tabFormPage = new Forms.Emails.AdminSystemEmails();
            }

            return (_tabFormPage);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppSystemEmails);
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
