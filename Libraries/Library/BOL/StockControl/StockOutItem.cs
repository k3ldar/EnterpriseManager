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
 *  File: StockOutItem.cs
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
    [Serializable]
    public sealed class StockOutItem : BaseObject
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Product Group Name</param>
        /// <param name="size">Size Description</param>
        /// <param name="date">Date stock moved</param>
        /// <param name="quantity">quantity of stock</param>
        /// <param name="reason">Reason stock moved out</param>
        /// <param name="user">user moving stock</param>
        public StockOutItem (string name, string size, DateTime date, int quantity, string reason, string user)
        {
            Name = name;
            Size = size;
            Date = date;
            Quantity = quantity;
            User = user;
            Reason = reason;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Product Group Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product Size/Description
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Date Stock Moved
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Quantity of stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Reason Stock Moved Out
        /// </summary>
        public string Reason {get; set; }

        /// <summary>
        /// User Moving Stock
        /// </summary>
        public string User { get; set; }

        #endregion Properties
    }
}
