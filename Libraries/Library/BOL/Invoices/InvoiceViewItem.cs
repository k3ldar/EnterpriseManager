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
 *  File: InvoiceViewItem.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
