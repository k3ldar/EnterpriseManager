using System.Drawing;
using Languages;
using Library.BOL.Users;
using POS.Base.Plugins;

namespace POS.Staff
{
    class StaffCommissionCard : HomeCard
    {
        #region Private Members

        Forms.CommissionPoolData _tabFormPage;

        #endregion Private Members

        public StaffCommissionCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionStaff(Library.SecurityEnums.SecurityPermissionsStaff.ViewCommissionDetails));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.StaffCommission);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.StaffPageCommission);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tabFormPage == null)
            {
                _tabFormPage = new Forms.CommissionPoolData();
            }

            return (_tabFormPage);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppStaffCommission);
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
            return (6000);
        }

        #region Private Members


        #endregion Private Members
    }
}
