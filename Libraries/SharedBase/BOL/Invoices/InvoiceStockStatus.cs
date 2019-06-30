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
 *  File: InvoiceStockStatus.cs
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

namespace SharedBase.BOL.Invoices
{
    /// <summary>
    /// Class to hold stock availability for an invoice
    /// </summary>
    [Serializable]
    public sealed class InvoiceStockStatus : IDisposable
    {
        #region Private Members

        private List<string> _itemsWithoutStock = new List<string>();

        #endregion Private Members

        #region Properties

        /// <summary>
        /// Indicates wether all stock is available or not
        /// </summary>
        public bool AllStockAvailable { get; set; }

        /// <summary>
        /// List of items without stock
        /// </summary>
        public List<string> MissingStock
        {
            get
            {
                return _itemsWithoutStock;
            }
        }

        #endregion Properties

        #region Public Methods

        public void Dispose()
        {
#if DEBUG
            System.GC.SuppressFinalize(this);
#endif
            _itemsWithoutStock = null;
        }

        #endregion Public Methods
    }
}
