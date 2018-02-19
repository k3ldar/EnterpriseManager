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
 *  File: PaidCommissionItem.cs
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

using Library.BOL.Users;

namespace Library.BOL.Staff
{
    [Serializable]
    public sealed class PaidCommissionItem : BaseObject
    {
        #region Constructors

        public PaidCommissionItem(Int64 id, User staffMember, decimal amount, DateTime datePaid, 
            Int64 employeePaying, CommissionPaymentType paymentType, string employeePayingName)
        {
            ID = id;
            StaffMember = staffMember;
            Amount = amount;
            DatePaid = datePaid;
            PaymentType = paymentType;
            PayingID = employeePaying;
            PayingName = employeePayingName;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID for record
        /// </summary>
        public Int64 ID { get; private set; }

        /// <summary>
        /// Staff member receiving payment
        /// </summary>
        public User StaffMember { get; private set; }

        /// <summary>
        /// Amount of commission being paid
        /// </summary>
        public decimal Amount { get; private set; }

        /// <summary>
        /// Date Commission Paid
        /// </summary>
        public DateTime DatePaid { get; private set; }

        /// <summary>
        /// Payment Type
        /// </summary>
        public CommissionPaymentType PaymentType { get; private set; }

        /// <summary>
        /// ID of employee making the payment
        /// </summary>
        internal Int64 PayingID { get; set; }

        /// <summary>
        /// Employee Paying Name
        /// </summary>
        public string PayingName { get; private set; }

        #endregion Properties
    }
}
