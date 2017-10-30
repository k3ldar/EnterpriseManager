using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.Accounts
{
    [Serializable]
    public sealed class PaymentStatus
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="initialProcessStatus"></param>
        /// <param name="isPaid">Indicates wether the status is paid or not</param>
        /// <param name="providerNamespace">Namespace procider to handle the payment status</param>
        public PaymentStatus(int id, string description, int initialProcessStatus, bool isPaid,
            string providerNamespace, bool isTill, bool isOffice, bool isOnline, bool createInvoice,
            MemberLevel memberLevel)
        {
            ID = id;
            Description = description;
            InitialProcessStatus = initialProcessStatus;
            IsPaid = isPaid;
            ProviderNamespace = providerNamespace;
            IsOffice = isOffice;
            IsOnline = isOnline;
            IsTill = isTill;
            CreateInvoice = createInvoice;
            MemberLevel = memberLevel;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID of status
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Description of status
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Initial process status
        /// </summary>
        public int InitialProcessStatus { get; private set; }

        /// <summary>
        /// Indicates wether the status is paid or not
        /// </summary>
        public bool IsPaid { get; private set; }

        /// <summary>
        /// Namespace which contains code to manipulate the Payment Status
        /// </summary>
        public string ProviderNamespace { get; private set; }

        /// <summary>
        /// Indicates wether the payment can be used for a till
        /// </summary>
        public bool IsTill { get; private set; }

        /// <summary>
        /// Indicates wether payment type can be used in the office
        /// </summary>
        public bool IsOffice { get; private set; }

        /// <summary>
        /// Indicates wether the payment type can be used online
        /// </summary>
        public bool IsOnline { get; private set; }

        /// <summary>
        /// If true an invoice order is created when creating an invoice (order)
        /// </summary>
        public bool CreateInvoice { get; private set; }

        /// <summary>
        /// Minimum member level to which this payment type relies on
        /// </summary>
        public MemberLevel MemberLevel { get; private set; }

        #endregion Properties

        #region Overridden Methods

        public override string ToString()
        {
            return (Description);
        }

        #endregion Overridden Methods
    }
}
