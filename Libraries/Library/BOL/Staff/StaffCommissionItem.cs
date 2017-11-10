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
 *  File: StaffCommissionItem.cs
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

namespace Library.BOL.Staff
{
    [Serializable]
    public sealed class StaffCommissionItem
    {
        #region Constructors

        public StaffCommissionItem(decimal commissionDue, DateTime dateAllocated, DateTime dateDue)
        {
            CommissionDue = commissionDue;
            DateDue = dateDue;
            DateAllocated = dateAllocated;
            Selected = false;
        }

        public StaffCommissionItem(Int64 id, Int64 commissionPoolID, int invoiceID,
            DateTime dateAllocated, bool isPaid, decimal percentage, decimal invoiceTotal,
            decimal commissionableTotal, decimal commissionDue, DateTime datePaid, DateTime dateDue)
            : this (commissionDue, dateAllocated, dateDue)
        {
            ID = id;
            CommissionPoolID = commissionPoolID;
            InvoiceID = invoiceID;
            DateAllocated = dateAllocated;
            IsPaid = isPaid;
            Percentage = percentage;
            InvoiceTotal = invoiceTotal;
            CommissionableTotal = commissionableTotal;
            DatePaid = datePaid;
            Selected = false;
        }

        public StaffCommissionItem(Int64 id, Users.User staff, int invoiceID,
            DateTime dateAllocated, bool isPaid, decimal percentage, decimal invoiceTotal,
            decimal commissionableTotal, decimal commissionDue, DateTime datePaid, DateTime dateDue)
            : this(commissionDue, dateAllocated, dateDue)
        {
            ID = id;
            InvoiceID = invoiceID;
            DateAllocated = dateAllocated;
            IsPaid = isPaid;
            Percentage = percentage;
            InvoiceTotal = invoiceTotal;
            CommissionableTotal = commissionableTotal;
            DatePaid = datePaid;
            Selected = false;
            StaffMember = staff;

            if (staff != null)
                UserName = staff.UserName;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID
        /// </summary>
        public Int64 ID { get; private set; }

        /// <summary>
        /// Commission Pool ID
        /// </summary>
        public Int64 CommissionPoolID { get; private set; }

        /// <summary>
        /// Staff User name
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Invoice ID
        /// </summary>
        public int InvoiceID { get; private set; }

        /// <summary>
        /// Date commission allocated
        /// </summary>
        public DateTime DateAllocated { get; private set; }

        /// <summary>
        /// Has it been paid
        /// </summary>
        public bool IsPaid { get; private set; }

        /// <summary>
        /// Percentage given
        /// </summary>
        public decimal Percentage { get; private set; }

        /// <summary>
        /// Total invoice amount
        /// </summary>
        public decimal InvoiceTotal { get; private set; }

        /// <summary>
        /// Total of Commissionable amount
        /// </summary>
        public decimal CommissionableTotal { get; private set; }

        /// <summary>
        /// Total amount of commission due
        /// </summary>
        public decimal CommissionDue { get; set; }

        /// <summary>
        /// Date payment was made
        /// </summary>
        public DateTime DatePaid { get; private set; }

        /// <summary>
        /// Date payment due
        /// </summary>
        public DateTime DateDue { get; private set; }

        /// <summary>
        /// Indicates the item has been selected or not
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// Staff member who payment is owed to
        /// </summary>
        internal Users.User StaffMember { get; set; }

        #endregion Properties

        #region Public Methods

        public void Paid(Users.User authorising, DateTime datePaid, Library.CommissionPaymentType paymentType)
        {
            DatePaid = datePaid;
            IsPaid = true;

            DAL.FirebirdDB.StaffCommissionUpdate(this, authorising, paymentType);
        }

        public void SetDateDue(DateTime dueDate)
        {
            DateDue = dueDate;
        }

        #endregion Public Methods
    }
}
