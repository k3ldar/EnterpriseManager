using System;
using System.Text;

namespace Library.BOL.Invoices
{
    [Serializable]
    public sealed class InvoiceViewItem
    {
        #region Constructors

        public InvoiceViewItem(string sku, string description, decimal price, decimal quantity, decimal cost,
            string itemType, string salesPerson, decimal userDiscount, decimal userDiscountValue,
            decimal productDiscount, decimal productDiscountValue)
        {
            SKU = sku;
            Description = description;
            Price = price;
            Quantity = quantity;
            Cost = cost;
            ItemType = itemType;
            SalesPerson = salesPerson;
            UserDiscount = userDiscount;
            UserDiscountValue = userDiscountValue;
            ProductDiscount = productDiscount;
            ProductDiscountValue = productDiscountValue;
        }

        #endregion Constructors

        #region Properties

        public string SKU { get; private set; }

        public string Description { get; private set; }

        public decimal Cost { get; private set; }

        public decimal Quantity { get; private set; }

        public decimal Price { get; private set; }

        public string ItemType { get; private set; }

        public string SalesPerson { get; private set; }

        public decimal UserDiscount { get; private set; }

        public decimal UserDiscountValue { get; private set; }

        public decimal ProductDiscount { get; private set; }

        public decimal ProductDiscountValue { get; private set; }

        #endregion Properties
    }
}
