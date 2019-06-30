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
 *  File: CommissionSplit.cs
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

using SharedBase.BOL.Basket;

namespace SharedBase.BOL.Staff
{
    [Serializable]
    public sealed class CommissionSplit
    {
        public CommissionSplit(StaffMember staff, Currency localCurrency)
        {
            Staff = staff;
            LocalCurrency = localCurrency;
        }

        #region Properties

        internal StaffMember Staff { get; set; }

        internal decimal PreviousAllocation { get; set; }

        private Currency LocalCurrency { get; set; }

        public string StaffName
        {
            get
            {
                SharedBase.BOL.Users.User user = SharedBase.BOL.Users.User.UserGet(Staff.UserID);
                return user.UserName;
            }
        }

        public string Allocation
        {
            get
            {
                return SharedBase.Utils.SharedUtils.FormatMoney(CurrentAllocation, LocalCurrency);
            }
        }

        public string Previous
        {
            get
            {
                return SharedBase.Utils.SharedUtils.FormatMoney(PreviousAllocation, LocalCurrency);
            }
        }
        
        public decimal CurrentAllocation { get; set; }

        #endregion Properties

        #region Private Methods

        public void NormaliseValues()
        {
            CurrentAllocation = Math.Round(CurrentAllocation, 2);
        }

        #endregion Private Methods
    }
}
