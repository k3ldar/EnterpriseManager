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
 *  File: RecurringInvoice.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using SharedBase.BOL.Users;

namespace SharedBase.BOL.Invoices
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
