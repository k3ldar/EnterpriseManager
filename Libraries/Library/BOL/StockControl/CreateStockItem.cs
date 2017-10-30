using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BOL.StockControl
{
    [Serializable]
    public sealed class CreateStockItem : BaseObject
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="main">Main Product Cost item</param>
        /// <param name="sub">Sub Product Cost item</param>
        /// <param name="quantity">Quanityt of sub product cost used in production</param>
        public CreateStockItem (Int64 main, Int64 sub, double quantity)
        {
            MainProductCost = main;
            SubProductCost = sub;
            Quantity = quantity;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Main Product Cost Item
        /// </summary>
        public Int64 MainProductCost { get; private set; }

        /// <summary>
        /// Sub Product Cost Item used to create the product
        /// </summary>
        public Int64 SubProductCost { get; private set; }

        /// <summary>
        /// Quantity of sub product cost items used
        /// </summary>
        public double Quantity { get; set; }

        #endregion Properties
    }
}
