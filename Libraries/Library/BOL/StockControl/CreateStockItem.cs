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
 *  File: CreateStockItem.cs
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
    public sealed class CreateStockItem : BaseObject
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="main">Main Product Cost item</param>
        /// <param name="sub">Sub Product Cost item</param>
        /// <param name="quantity">Quanityt of sub product cost used in production</param>
        public CreateStockItem (Int64 main, Int64 sub, double quantity)
        {
            MainProductCost = main;
            SubProductCost = sub;
            Quantity = quantity;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Main Product Cost Item
        /// </summary>
        public Int64 MainProductCost { get; private set; }

        /// <summary>
        /// Sub Product Cost Item used to create the product
        /// </summary>
        public Int64 SubProductCost { get; private set; }

        /// <summary>
        /// Quantity of sub product cost items used
        /// </summary>
        public double Quantity { get; set; }

        #endregion Properties
    }
}
