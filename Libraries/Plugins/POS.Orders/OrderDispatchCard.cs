/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: OrderDispatchCard.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
