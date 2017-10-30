using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.Users;
using Library.BOL.Invoices;

namespace Library.BOL.Refunds
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
