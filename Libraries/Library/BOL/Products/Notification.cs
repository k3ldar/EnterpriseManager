using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.Products
{
    /// <summary>
    /// Notification object for out of stock product items
    /// </summary>
    [Serializable]
    public sealed class Notification : BaseObject
    {
        #region Constructors

        public Notification(Int64 id, ProductCost productCost, string email)
        {
            ID = id;
            ProductCost = productCost;
            Email = email;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID for notification
        /// </summary>
        public Int64 ID { get; private set; }

        /// <summary>
        /// Product Cost Item for which this notification relates
        /// </summary>
        public ProductCost ProductCost { get; private set; }

        /// <summary>
        /// Email address to receive notification
        /// </summary>
        public string Email { get; private set; }

        #endregion Properties
    }
}
