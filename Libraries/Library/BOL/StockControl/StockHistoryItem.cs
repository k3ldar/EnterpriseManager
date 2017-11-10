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
 *  File: StockHistoryItem.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BOL.StockControl
{
    /// <summary>
    /// Stock history item
    /// </summary>
    [Serializable]
    public sealed class StockHistoryItem
    {
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date">Date of stock change</param>
        /// <param name="user">User making changes</param>
        /// <param name="oldValue">old stock value</param>
        /// <param name="newValue">new stock value</param>
        public StockHistoryItem(DateTime date, string user, int oldValue, int newValue)
        {
            Date = date;
            UserName = user;
            OldTotal = oldValue;
            NewTotal = newValue;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="item">Stock Item</param>
        /// <param name="userID">ID of User </param>
        /// <param name="userName">Name of User</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="date">Date</param>
        /// <param name="storeID">Store</param>
        /// <param name="reason">Reason</param>
        /// <param name="table">Table</param>
        public StockHistoryItem(StockItem item, Int64 userID, string userName, decimal quantity, 
            DateTime date, string store, string reason, string table)
        {
            Item = item;
            UserID = userID;
            UserName = userName;
            Quantity = quantity;
            Date = date;
            Store = store;
            Reason = reason;
            Table = table;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Item of stock being checked
        /// </summary>
        public StockItem Item { get; private set; }

        /// <summary>
        /// ID of user who moved stock
        /// </summary>
        public Int64 UserID { get; private set; }

        /// <summary>
        /// Name of user who moved stock
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Quantity of stock history
        /// </summary>
        public decimal Quantity { get; private set; }

        /// <summary>
        /// Date/Time of stock history
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Store from which stock history is made
        /// </summary>
        public string Store { get; private set; }

        /// <summary>
        /// Reason for stock history
        /// </summary>
        public string Reason { get; private set; }

        /// <summary>
        /// Table from where stock history originated
        /// </summary>
        public string Table { get; private set; }

        /// <summary>
        /// Old Total
        /// </summary>
        public int OldTotal { get; private set; }

        /// <summary>
        /// New Total
        /// </summary>
        public int NewTotal { get; private set; }

        #endregion Properties
    }
}
