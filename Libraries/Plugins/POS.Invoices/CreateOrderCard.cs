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
    public class CreateOrderCard : HomeCard
    {
        #region Private Members

        Forms.CreateOrder _createOrder;

        #endregion Private Members

        #region Constructors

        public CreateOrderCard(BasePlugin parent)
            : base(parent)
        {

        }

        #endregion Constructors

        #region Overridden Methods

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.CreateOrder));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.Orders);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (HelpTopics.InvoiceCreateOrder);
        }

        public override Base.Controls.BaseControl TabContents()
        {
            if (_createOrder == null)
            {
                _createOrder = new Forms.CreateOrder();
            }

            return (_createOrder);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppCreateInvoice);
        }

        public override int StatusPanelCount()
        {
            return (_createOrder.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_createOrder.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_createOrder.GetStatusHint(index));
        }

        public override int SortOrder()
        {
            return (190);
        }

        public override void EventRaised(NotificationEventArgs e)
        {
            if (e.EventName == StringConstants.PLUGIN_EVENT_PRODUCT_ADD_REMOVE_UPDATE)
            {
                if (_createOrder != null)
                    _createOrder.ProductsUpdated();
            }
        }

        #endregion Overridden Methods

        #region Private Members


        #endregion Private Members
    }
}
