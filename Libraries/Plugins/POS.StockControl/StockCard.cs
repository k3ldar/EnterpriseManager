using System;
using System.Drawing;
using Languages;

using Library;
using Library.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.StockControl
{

    public class StockCard : HomeCard
    {
        #region Private Members

        Controls.MainStockControl _stockControl;

        #endregion Private Members

        public StockCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ViewStockControl));
        }

        public override void Closing()
        {
            if (_stockControl == null)
                return;

            _stockControl.Closing();
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.StockControlButton);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (HelpTopics.StockControl);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_stockControl == null)
                _stockControl = new POS.StockControl.Controls.MainStockControl();

            return (_stockControl);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppMenuButtonStockControl);
        }

        public override int StatusPanelCount()
        {
            return (_stockControl.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_stockControl.GetStatusText(index));
        }

        public override int SortOrder()
        {
            return (100);
        }

        public override void EventRaised(NotificationEventArgs e)
        {
            if (_stockControl == null)
                return;

            switch (e.EventName)
            {
                case StringConstants.PLUGIN_EVENT_ORDER_DISPATCHED:
                case StringConstants.PLUGIN_EVENT_PRODUCT_ADD_REMOVE_UPDATE:
                    _stockControl.ProductsUpdated();
                    break;

                case StringConstants.PLUGIN_EVENT_INVOICE_CREATED:
                    _stockControl.InvoiceCreated();
                    break;
            }
        }
    }
}
