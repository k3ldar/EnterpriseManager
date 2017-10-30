using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BOL.Locations
{
    /// <summary>
    /// Store Location object
    /// </summary>
    [Serializable]
    public sealed class StoreLocation : BaseObject
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Store Identifier</param>
        /// <param name="storeName">Name of Store</param>
        public StoreLocation(int id, string storeName)
        {
            ID = id;
            StoreName = storeName;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Store Location Identifier
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Store Name
        /// </summary>
        public string StoreName { get; set; }

        #endregion Properties
    }
}
