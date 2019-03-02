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
 *  File: Voucher.cs
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

using SharedBase.BOL.Users;

namespace SharedBase.BOL.Vouchers
{
    [Serializable]
    public sealed class Voucher : BaseObject
    {
        public Voucher(string code, decimal amount, User user, DateTime expires)
        {
            Code = code;
            Amount = amount;
            User = user;
            Expires = expires;
        }

        public Voucher(Int64 id, string code, decimal amount, bool hasBeenSold, DateTime expires)
        {
            Code = code;
            Amount = amount;
            Sold = hasBeenSold;
            Expires = expires;
        }

        #region Properties

        public string Code
        {
            set;
            get;
        }

        public decimal Amount
        {
            get;
            set;
        }

        public User User
        {
            get;
            set;
        }

        public bool Sold
        {
            get;
            set;
        }

        public DateTime Expires { get; private set; }

        #endregion Properties

        //#region Public Methods

        //public bool Valid()
        //{
        //    return (_IsActive && DateTime.Now < _Expires && DateTime.Now > StartDateTime && VoucherUsage < MaxUsage);
        //}

        //#endregion Public Methods
    }
}
