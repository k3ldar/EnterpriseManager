using System.Drawing;
using Languages;

using Library;
using Library.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable IDE1017 // Object Initialization can be simplified

namespace POS.Invoices
{
    public class OrdersReceivedCard : HomeCard
    {
        #region Private Members

        Controls.OrdersReceivedControl _invoiceReceived;

        #endregion Private Members

        public OrdersReceivedCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.ViewOrdersReceived));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.OrderReceived);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.InvoicesReceived);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_invoiceReceived == null)
            {
                _invoiceReceived = new Controls.OrdersReceivedControl();
            }

            return (_invoiceReceived);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppOrdersReceived);
        }

        public override int StatusPanelCount()
        {
            return (_invoiceReceived.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_invoiceReceived.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_invoiceReceived.GetStatusHint(index));
        }

        public override int SortOrder()
        {
            return (180);
        }

        public override int GetNotificationCount()
        {
            return (AppController.Administration.StatsInvoices(InvoiceStatistics.Received));
        }

        #region Private Members


        #endregion Private Members
    }
}
