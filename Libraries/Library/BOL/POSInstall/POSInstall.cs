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
