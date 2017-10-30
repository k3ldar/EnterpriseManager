using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BOL.StockControl
{
    /// <summary>
    /// Stock In Item
    /// </summary>
    [Serializable]
    public sealed class StockInItem : BaseObject
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Product Group Name</param>
        /// <param name="size">Size Description</param>
        /// <param name="date">Date stock moved</param>
        /// <param name="quantity">quantity of stock</param>
        /// <param name="user">user moving stock</param>
        public StockInItem (string name, string size, DateTime date, int quantity, string user)
        {
            Name = name;
            Size = size;
            Date = date;
            Quantity = quantity;
            User = user;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Product Group Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product Size/Description
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Date Stock Moved
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Quantity of stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// User Moving Stock
        /// </summary>
        public string User { get; set; }

        #endregion Properties
    }
}
