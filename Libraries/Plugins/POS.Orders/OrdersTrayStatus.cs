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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: OrdersTrayStatus.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using Languages;

using Library;
using Library.BOL.Invoices;
using Library.BOL.Statistics;

using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.Orders
{

    public class OrdersTrayStatus : TrayNotification
    {
        #region Constructors

        public OrdersTrayStatus(BasePlugin parent)
            : base(parent)
        {
            this.UpdateFrequency = new TimeSpan(0, 0, 15);
            this.CanBlink = false;
            this.Position = 0;
        }

        #endregion Constructors

        #region Overridden Methods

        public override string HintText()
        {
            return (String.Empty);
        }

        public override string StatusText()
        {
            string Result = String.Empty;
            try
            {
                SimpleStatistics stats = Invoices.InvoicesGetStats(AppController.ActiveUser, -1, -1, false, ProcessStatuses.Processing);

                int total = 0;

                foreach (SimpleStatistic stat in stats)
                    total += stat.Count;

                Result = StringConstants.PREFIX_AND_SPACE + LanguageStrings.AppOrdersOutstanding;
                Result = String.Format(Result, total);
            }
            catch (Exception err)
            {
                Result = LanguageStrings.AppErrorShowingStats +
                    StringConstants.SYMBOL_HYPHON_SPACES + err.Message;
            }

            return (Result);
        }

        public override string Name()
        {
            return (LanguageStrings.AppPluginTrayInvoicesOrders);
        }

        public override void DoubleClick()
        {

        }

        public override bool CanLoad()
        {
            return (true);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {

        }

        public override void Load()
        {

        }

        #endregion Overridden Methods
    }
}
