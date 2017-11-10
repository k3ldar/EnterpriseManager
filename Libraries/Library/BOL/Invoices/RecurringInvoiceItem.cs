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
 *  File: RecurringInvoiceItem.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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