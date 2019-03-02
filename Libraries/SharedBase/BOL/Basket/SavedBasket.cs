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
 *  File: SavedBasket.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

namespace SharedBase.BOL.Basket
{
    [Serializable]
    public sealed class SavedBasket : BaseObject
    {
        #region Constructors

        public SavedBasket(Int64 basketID, Int64 userID, string description, string voucherCode)
        {
            BasketID = basketID;
            UserID = userID;
            Description = description;
            VoucherCode = voucherCode;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID of the basket
        /// </summary>
        public Int64 BasketID { get; set; }

        /// <summary>
        /// User who products are being sold to
        /// </summary>
        public Int64 UserID { get; set; }

        /// <summary>
        /// Description of saved basket
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Voucher Code entered on the basket
        /// </summary>
        public string VoucherCode { get; set; }

        #endregion Properties
    }
}
