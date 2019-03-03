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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: PluginToastAction.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
