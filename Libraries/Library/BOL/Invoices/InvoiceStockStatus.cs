using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BOL.Invoices
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
                return (_itemsWithoutStock);
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
