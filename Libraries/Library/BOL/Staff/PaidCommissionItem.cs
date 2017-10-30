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
