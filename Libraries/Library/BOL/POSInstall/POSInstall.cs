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
 *  File: POSInstall.cs
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

namespace Library.BOL.POSInstall
{
    [Serializable]
    public sealed class POSInstall 
    {
        #region Constructors

        public POSInstall (bool allowed, string remoteDatabase, string server, int storeID, int tillID)
        {
            Allowed = allowed;
            RemoteDatabase = remoteDatabase;
            Server = server;
            StoreID = storeID;
            TillID = tillID;
        }


        public POSInstall (bool allowed, string servers)
        {
            Allowed = allowed;
            Servers = servers;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Delimeted list of servers for user
        /// </summary>
        public string Servers { get; set; }

        /// <summary>
        /// Install is allowed
        /// </summary>
        public bool Allowed { get; set; }

        /// <summary>
        /// Remote Database
        /// </summary>
        public string RemoteDatabase { get; private set; }

        /// <summary>
        /// Server Name
        /// </summary>
        public string Server { get; private set; }

        /// <summary>
        /// Store ID
        /// </summary>
        public int StoreID { get; private set; }

        /// <summary>
        /// Till ID
        /// </summary>
        public int TillID { get; private set; }

        #endregion Properties

    }
}
