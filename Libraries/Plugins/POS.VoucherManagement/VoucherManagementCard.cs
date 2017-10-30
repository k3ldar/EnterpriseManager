using System.Drawing;
using Languages;

using Library;
using Library.BOL.Users;
using POS.Base.Plugins;


namespace POS.VoucherManagement
{
    public class VoucherManagementCard : HomeCard
    {
        #region Private Members

        Forms.AssignVouchers _assignVouchers;

        #endregion Private Members

        public VoucherManagementCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerVoucherManagement));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.voucher_icon_vouchers);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.VoucherAssign);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_assignVouchers == null)
            {
                _assignVouchers = new Forms.AssignVouchers();
            }

            return (_assignVouchers);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppPluginVoucherManagement);
        }

        public override int StatusPanelCount()
        {
            return (_assignVouchers.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_assignVouchers.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_assignVouchers.GetStatusHint(index));
        }

        #region Private Members


        #endregion Private Members
    }
}
