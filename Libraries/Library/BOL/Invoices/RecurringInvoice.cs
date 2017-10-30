using System;

using Library.BOL.Users;

namespace Library.BOL.Invoices
{
    public class RecurringInvoice : BaseObject
    {
        #region Private Members

        private RecurringInvoiceItems _items;

        #endregion Private Members

        #region Constructors

        public RecurringInvoice()
        {

        }

        public RecurringInvoice(Int64 id, string description, User user, DateTime nextRun,
            RecurringType type, int frequency, decimal discount,
            RecurringInvoiceOptions options, RecurringInvoiceItems items)
        {
            ID = id;
            Description = description;
            Customer = user;
            NextRun = nextRun;
            Type = type;
            Frequency = frequency;
            Discount = discount;
            _items = items;
            Options = options;
        }

        #endregion Constructors

        #region Properties

        public Int64 ID { get; internal set; }

        public string Description { get; set; }

        public User Customer { get; set; }

        public DateTime NextRun { get; set; }

        public RecurringType Type { get; set; }

        public int Frequency { get; set; }

        public decimal Discount { get; set; }

        public RecurringInvoiceItems Items
        {
            get
            {
                if (_items == null)
                    _items = DAL.FirebirdDB.RecurringInvoiceItemsGet(this);

                return (_items);
            }
        }

        /// <summary>
        /// Recurring Invoice Options
        /// </summary>
        public RecurringInvoiceOptions Options { get; set; }

        #endregion Properties

        #region Overridden Methds

        public override void Save()
        {
            DAL.FirebirdDB.RecurringInvoiceSave(this);
            _items = null;
        }

        public override void Delete()
        {
            DAL.FirebirdDB.RecurringInvoiceDelete(this);
        }

        public override string ToString()
        {
            return (String.Format("RecurringInvoice {0}; ID: {1}", Description, ID));
        }

        #endregion Overridden Methods

        #region Public Methods

        #endregion Public Methods
    }
}
