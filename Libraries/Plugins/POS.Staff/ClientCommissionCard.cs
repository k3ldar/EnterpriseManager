using System.Drawing;
using Languages;

using Library;
using Library.BOL.Users;
using POS.Base.Plugins;


namespace POS.Staff
{
    class ClientCommissionCard : HomeCard
    {
        #region Private Members

        Forms.ClientCommissionData _tabFormPage;

        #endregion Private Members

        public ClientCommissionCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.ManageClientCommission));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.ClientCommission);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.CustomerAffCommissionData);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tabFormPage == null)
            {
                _tabFormPage = new Forms.ClientCommissionData();
            }

            return (_tabFormPage);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppCommissionClientData);
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
            return (6010);
        }

        #region Private Members


        #endregion Private Members
    }
}
