using System.Drawing;
using Languages;

using Library;
using Library.BOL.Users;
using POS.Base.Plugins;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable IDE1017 // Object Initialization can be simplified

namespace POS.Invoices
{
    public class UnpaidOrdersCard : HomeCard
    {
        #region Private Members

        Forms.UnpaidOrderForm _unpaidOrders;

        #endregion Private Members

        public UnpaidOrdersCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.ViewUnpaidOrders));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.OrderUnpaid);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.InvoiceOrdersUnpaid);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_unpaidOrders == null)
            {
                _unpaidOrders = new Forms.UnpaidOrderForm();
            }

            return (_unpaidOrders);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppUnpaidOrders);
        }

        public override int StatusPanelCount()
        {
            return (_unpaidOrders.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_unpaidOrders.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_unpaidOrders.GetStatusHint(index));
        }

        public override int SortOrder()
        {
            return (200);
        }

        #region Private Members


        #endregion Private Members
    }
}
