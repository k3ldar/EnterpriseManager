using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library.BOL.Products;

namespace Library.BOL.Invoices
{
    public sealed class RecurringInvoiceItem : BaseObject
    {
        #region Private Members

        private decimal _quantity;

        #endregion Private Members

        #region Constructors / Destructors

        public RecurringInvoiceItem(Int64 id, RecurringInvoice recurringInvoice, ProductCost productItem, decimal quantity)
        {
            ID = id;
            RecurringInvoice = recurringInvoice;
            ProductItem = productItem;
            _quantity = quantity;
        }

        #endregion Constructors / Destructors

        #region Properties

        public Int64 ID { get; internal set; }

        public RecurringInvoice RecurringInvoice { get; set; }

        public ProductCost ProductItem { get; set; }

        public decimal Quantity
        {
            get
            {
                return (_quantity);
            }

            set
            {
                if (value > 0)
                {
                    _quantity = value;
                    Changed();
                }
            }
        }

        #endregion Properties

        #region Overridden Methods

        public override void Save()
        {
            DAL.FirebirdDB.RecurringInvoiceItemSave(this);
        }

        public override void Delete()
        {
            DAL.FirebirdDB.RecurringInvoiceItemDelete(this);
        }

        #endregion Overridden Methods
    }
}