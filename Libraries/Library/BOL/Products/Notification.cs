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
 *  File: Notification.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.Products
{
    /// <summary>
    /// Notification object for out of stock product items
    /// </summary>
    [Serializable]
    public sealed class Notification : BaseObject
    {
        #region Constructors

        public Notification(Int64 id, ProductCost productCost, string email)
        {
            ID = id;
            ProductCost = productCost;
            Email = email;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID for notification
        /// </summary>
        public Int64 ID { get; private set; }

        /// <summary>
        /// Product Cost Item for which this notification relates
        /// </summary>
        public ProductCost ProductCost { get; private set; }

        /// <summary>
        /// Email address to receive notification
        /// </summary>
        public string Email { get; private set; }

        #endregion Properties
    }
}
