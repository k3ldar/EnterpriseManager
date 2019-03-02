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
 *  File: Refund.cs
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
using SharedBase.BOL.Invoices;

namespace SharedBase.BOL.Refunds
{
    [Serializable]
    public sealed class Refund
    {
        private Int64 _id;
        private Int64 _user;
        private int _invoiceID;
        private decimal _amount;
        private DateTime _date;
        private Int64 _employee;
        private string _reason;

        #region Constructors

        public Refund(Int64 ID, Int64 User, int InvoiceID, decimal Amount, DateTime Date, 
            Int64 Employee, string Reason)
        {
            _id = ID;
            _user = User;
            _invoiceID = InvoiceID;
            _amount = Amount;
            _date = Date;
            _employee = Employee;
            _reason = Reason;
        }

        #endregion Constructors

        #region Properties

        public Int64 ID
        {
            get { return (_id); }
        }

        public Int64 User
        {
            get { return (_user); }
        }

        public int InvoiceID
        {
            get { return (_invoiceID); }
        }

        public decimal Amount
        {
            get { return (_amount); }
        }

        public DateTime Date
        {
            get { return (_date); }
        }

        public Int64 Employee
        {
            get { return (_employee); }
        }

        public string Reason
        {
            get { return (_reason); }
        }

        #endregion Properties

        #region Static Methods

        public static Int64 Create(User client, User employee, Invoice invoice, 
            decimal refundAmount, string reason)
        {
            return (DAL.FirebirdDB.RefundCreate(client, employee, invoice, refundAmount, reason));
        }

        #endregion Static Methods
    }
}
