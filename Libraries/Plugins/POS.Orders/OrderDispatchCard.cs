using System;
using System.Drawing;
using Languages;

using Library;
using Library.BOL.Invoices;
using Library.BOL.Users;
using Library.BOL.Statistics;

using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.Orders
{
    public class OrderDispatchCard : HomeCard
    {
        #region Private Members

        Controls.OrderDispatchControl _orderDispatch;

        #endregion Private Members

        public OrderDispatchCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.DispatchOrders));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.OrderDispatch);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (HelpTopics.Diary);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_orderDispatch == null)
            {
                _orderDispatch = new Controls.OrderDispatchControl();
            }

            return (_orderDispatch);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppOrderDispatch);
        }

        public override int StatusPanelCount()
        {
            return (0);
        }

        public override string StatusPanelText(int index)
        {
            return (String.Empty);
        }

        public override string StatusPanelHint(int index)
        {
            return (String.Empty);
        }

        public override int GetNotificationCount()
        {
            int Result = 0;
            try
            {
                SimpleStatistics stats = Invoices.InvoicesGetStats(AppController.ActiveUser, -1, -1, false, ProcessStatuses.Processing);

                foreach (SimpleStatistic stat in stats)
                    Result += stat.Count;

            }
            catch (Exception err)
            {
                Shared.EventLog.Add(err);
            }

            return (Result);
        }

        public override int SortOrder()
        {
            return (150);
        }

        public override void EventRaised(NotificationEventArgs e)
        {
            base.EventRaised(e);

            switch (e.EventName)
            {
                case StringConstants.PLUGIN_EVENT_ORDER_PROCESS_STATUS_CHANGED:
                    GetNotificationCount();
                    break;
            }
        }
    }
}
