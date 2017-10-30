using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BOL.Affiliate
{
    [Serializable]
    public sealed class AffiliateCommissionItem
    {
        #region Constructors

        public AffiliateCommissionItem(decimal commissionDue, DateTime dateAllocated, DateTime dateDue)
        {
            CommissionDue = commissionDue;
            DateDue = dateDue;
            DateAllocated = dateAllocated;
            Selected = false;
        }

        public AffiliateCommissionItem(Int64 id, Int64 commissionPoolID, int invoiceID,
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

        public AffiliateCommissionItem(Int64 id, Users.User user, int invoiceID,
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
            User = user;

            if (user != null)
                UserName = user.UserName;
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
        /// User who payment is owed to
        /// </summary>
        internal Users.User User { get; set; }

        #endregion Properties

        #region Public Methods

        public void Paid(Users.User authorising, DateTime datePaid, Library.CommissionPaymentType paymentType)
        {
            DatePaid = datePaid;
            IsPaid = true;

            DAL.FirebirdDB.AffiliateCommissionUpdate(this, authorising, paymentType);
        }

        public void SetDateDue(DateTime dueDate)
        {
            DateDue = dueDate;
        }

        #endregion Public Methods
    }
}
