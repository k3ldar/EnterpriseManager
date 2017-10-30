using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Base.Classes
{
    /// <summary>
    /// Toast action class for notifications
    /// </summary>
    public sealed class PluginToastAction
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="uniqueID"></param>
        /// <param name="method"></param>
        /// <param name="data">Custom Data</param>
        public PluginToastAction(string uniqueID, Action<object> method, object data)
        {
            UniqueID = uniqueID;
            Method = method;
            Data = data;
        }

        #region Properties

        /// <summary>
        /// Unique Identifier
        /// </summary>
        public string UniqueID { get; private set; }

        /// <summary>
        /// Method to call if toast action clicked
        /// </summary>
        public Action<object> Method { get; private set; }

        /// <summary>
        /// Data to be suplied as parameter
        /// </summary>
        public object Data { get; private set; }

        #endregion Properties
    }
}
