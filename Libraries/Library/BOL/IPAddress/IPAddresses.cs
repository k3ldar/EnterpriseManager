using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

using SieraDelta.Shared;

namespace Library.BOL.IPAddresses
{
    [Serializable]
    public sealed class IPAddresses : BaseCollection
    {
        #region Private Static Members

        private static IPAddresses _list;

        #endregion Private Static Members

        #region Constructors

        public IPAddresses ()
        {
            LastUpdated = DateTime.Now.AddDays(-9);
            HighestID = Int64.MinValue;
        }

        #endregion Constructors

        #region Static Methods

        /// <summary>
        /// Retrieves an instance of the local AddressList
        /// </summary>
        /// <returns></returns>
        public static IPAddresses Instance()
        {
            if (_list == null)
            {
                _list = IPAddresses.Load();

                if (_list != null)
                {
                    foreach (IPAddress address in _list)
                    {
                        if (address.ID > _list.HighestID)
                            _list.HighestID = address.ID;
                    }
                }
            }

            return (_list);
        }

        /// <summary>
        /// Loads a list of addresses from selected data store
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>AddressList object</returns>
        public static IPAddresses Load()
        {
            IPAddresses Result = null;

            string fileName = SieraDelta.Shared.Utilities.CurrentPath(true) + "AddressList.Data";


            if (File.Exists(fileName))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(IPAddresses));
                    try
                    {
                        StreamReader reader = new StreamReader(fileName);
                        try
                        {
                            Result = (IPAddresses)serializer.Deserialize(reader);
                        }
                        finally
                        {
                            reader.Close();
                            reader.Dispose();
                            reader = null;
                        }
                    }
                    finally
                    {
                        serializer = null;
                    }

                    Result.LastUpdated = DateTime.FromFileTimeUtc(SieraDelta.Shared.XML.GetXMLValue("AddressListSaved", "LastSaved", DateTime.Now.AddDays(-8).ToFileTimeUtc()));

                    TimeSpan span = DateTime.Now - Result.LastUpdated;

                    if (span.TotalDays > 9.5)
                        Result.LastUpdated = DateTime.Now.AddDays(-9);
                }
                catch
                {
                    IPAddresses.Save(Result);
                }
            }
            else
            {
                if (Result != null)
                    IPAddresses.Save(Result);
            }

            return (Result);
        }

        /// <summary>
        /// Saves list to XML File
        /// </summary>
        /// <param name="list">list to be saved</param>
        /// <param name="fileName">fileName to be saved as</param>
        public static void Save(IPAddresses list)
        {
            if (list == null || list.Count == 0)
                return;

            string fileName = SieraDelta.Shared.Utilities.CurrentPath(true) + "AddressList.Data";

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(IPAddresses));
                try
                {
                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        serializer.Serialize(writer, list);
                    }

                    SieraDelta.Shared.XML.SetXMLValue("AddressListSaved", "LastSaved", list.LastUpdated.ToFileTimeUtc().ToString());
                }
                finally
                {
                    serializer = null;
                }
            }
            catch (Exception err)
            {
                SieraDelta.Shared.EventLog.Add(err);
            }
        }

        /// <summary>
        /// Retrieves a list of expired, inactive IP Addresses
        /// </summary>
        /// <returns></returns>
        //public static IPAddresses DAL_Inactive()
        //{
        //    return (DALHelper.GetAccessLayer().AddressGetInactive());
        //}


        //public static void DAL_Update(IPAddresses list)
        //{
        //    IPAddresses latestBanned = DALHelper.GetAccessLayer().AddressGet(AddressType.FailedAudit, true, false);

        //    foreach (Address address in latestBanned)
        //    {
        //        if (list.Find(address.IPAddress) == null)
        //            list.Add(address);
        //    }
        //}

        /// <summary>
        /// Adds an address to the list of IP Addresses
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        //public static bool DAL_AddressAdd(IPAddress address)
        //{
        //    return (DALHelper.GetAccessLayer().AddressAdd(address));
        //}

        /// <summary>
        /// Removes an address from the list of IP Addresses
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        //public static bool DAL_AddressDelete(IPAddress address)
        //{
        //    return (DALHelper.GetAccessLayer().AddressRemove(address));
        //}

        /// <summary>
        /// Retrieves a list of addresses of specific type
        /// </summary>
        /// <param name="type">Type of addresses</param>
        /// <returns></returns>
        //public static IPAddresses DAL_AddressGet(AddressType type, bool active, bool inactive)
        //{
        //    return (DALHelper.GetAccessLayer().AddressGet(type, active, inactive));
        //}

        /// <summary>
        /// Returns the history of an IP Address
        /// </summary>
        /// <param name="ipAddress">IP Address who's history is sought</param>
        /// <returns>AddressList collection</returns>
        //public static IPAddresses DAL_AddressGet(string ipAddress)
        //{
        //    return (DALHelper.GetAccessLayer().AddressHistory(ipAddress));
        //}

        /// <summary>
        /// Returns an address based on it's ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public static IPAddress DAL_AddressGet(Int64 id)
        //{
        //    return (DALHelper.GetAccessLayer().AddressGet(id));
        //}

        public static void CurrentStatistics(ref Int64 currentlyBanned, ref Int64 previouslyBanned)
        {
            DAL.FirebirdDB.WebDefenderStats(ref currentlyBanned, ref previouslyBanned);
        }

        public static void ServiceUpdate(IPAddresses list)
        {
            IPAddresses latestBanned = DAL.FirebirdDB.WebDefenderAddressGet(AddressType.FailedAudit, true, false);

            foreach (IPAddress address in latestBanned)
            {
                if (list.Find(address.IpAddress) == null)
                    list.Add(address);
            }
        }

        /// <summary>
        /// Adds an address to the list of IP Addresses
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static bool ServiceAddressAdd(IPAddress address)
        {
            return (DAL.FirebirdDB.WebDefenderAddressAdd(address));
        }

        /// <summary>
        /// Removes an address from the list of IP Addresses
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static bool ServiceAddressDelete(IPAddress address)
        {
            return (DAL.FirebirdDB.WebDefenderAddressRemove(address));
        }

        /// <summary>
        /// Retrieves a list of addresses of specific type
        /// </summary>
        /// <param name="type">Type of addresses</param>
        /// <returns></returns>
        public static IPAddresses ServiceAddressGet(AddressType type, bool active, bool inactive)
        {
            return (DAL.FirebirdDB.WebDefenderAddressGet(type, active, inactive));
        }

        /// <summary>
        /// Returns the history of an IP Address
        /// </summary>
        /// <param name="ipAddress">IP Address who's history is sought</param>
        /// <returns>AddressList collection</returns>
        public static IPAddresses ServiceAddressGet(string ipAddress)
        {
            return (DAL.FirebirdDB.WebDefenderAddressHistory(ipAddress));
        }

        public static IPAddresses ServiceAddressGetBanned(DateTimeOffset fromDate, Int64 maximumID)
        {
            return (DAL.FirebirdDB.WebDefenderAddressesBanned(fromDate, maximumID));
        }

        /// <summary>
        /// Retrieves a list of expired, inactive IP Addresses
        /// </summary>
        /// <returns></returns>
        public static IPAddresses ServiceInactive()
        {
            return (DAL.FirebirdDB.WebDefenderAddressGetInactive());
        }

        public static IPAddress ServiceAddressGet(Int64 id)
        {
            return (DAL.FirebirdDB.WebDefenderAddressGet(id));
        }

        /// <summary>
        /// Returns an address based on it's ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        #endregion Static Methods

        #region Public Properties

        /// <summary>
        /// date/time list last updated
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// The highest ID in the list
        /// </summary>
        public Int64 HighestID { get; set; }

        /// <summary>
        /// Lowest id in the list
        /// </summary>
        //public Int64 LowestID { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool AddressDelete(IPAddress address)
        {
            IPAddress addr = Find(address.ID);

            if (addr != null)
                this.Remove(address);

            return (true);
        }

        /// <summary>
        /// Retrieves a list of expired, inactive IP Addresses
        /// </summary>
        /// <returns></returns>
        public IPAddresses Inactive()
        {
            IPAddresses Result = new IPAddresses();

            foreach (IPAddress address in this)
            {
                
                if (!address.IsActive)
                    Result.Add(address);
            }

            return (Result);
        }

        public IPAddress AddressGet(Int64 id)
        {
            foreach (IPAddress address in this)
            {
                if (address.ID == id)
                    return (address);
            }

            return (null);
        }

        /// <summary>
        /// Retrieves a list of addresses of specific type
        /// </summary>
        /// <param name="type">Type of addresses</param>
        /// <returns></returns>
        public IPAddresses AddressGet(AddressType type, bool active, bool inactive)
        {
            IPAddresses Result = new IPAddresses();

            foreach (IPAddress address in this)
            {
                if (address.AddressType == type)
                {
                    if (active && address.IsActive)
                        Result.Add(address);
                    else if (inactive && !address.IsActive)
                        Result.Add(address);
                }
            }

            return (Result);
        }


        /// <summary>
        /// Finds an address record with specific IP Address that is currently active
        /// </summary>
        /// <param name="IPAddress">IP Address to find</param>
        /// <returns>null if no record exists, otherwise a record matching IP Address</returns>
        public IPAddress FindActive(string IPAddress)
        {
            IPAddress Result = null;

            foreach (IPAddress item in this)
            {
                if (item.IpAddress == IPAddress)
                {
                    if (item.Expire >= DateTime.Now && item.BlackListed)
                    {
                        Result = item;
                        break;
                    }
                }
            }

            return (Result);
        }

        /// <summary>
        /// Finds an address record with specific IP Address
        /// </summary>
        /// <param name="IPAddress">IP Address to find</param>
        /// <param name="expired">Determines whether the ip address is active or not</param>
        /// <returns>null if no record exists, otherwise a record matching IP Address</returns>
        public IPAddress Find(string IPAddress)
        {
            IPAddress Result = null;

            foreach (IPAddress item in this)
            {
                if (item.IpAddress == IPAddress)
                {
                    Result = item;
                    break;
                }
            }

            return (Result);
        }

        /// <summary>
        /// Finds an address record with specific IP Address
        /// </summary>
        /// <param name="IPAddress">IP Address to find</param>
        /// <returns>null if no record exists, otherwise a record matching IP Address</returns>
        public IPAddress Find(Int64 id)
        {
            IPAddress Result = null;

            for (int i = this.Count - 1; i >= 0; i--)
            {
                IPAddress address = this[i];

                if (address.ID == id)
                {
                    return (address);
                }
            }

            return (Result);
        }

        public int AddressNumberOfBans(IPAddress ipAddress)
        {
            int Result = 0;

            foreach (IPAddress address in this)
            {
                if (address.CanExpire && address.ID != ipAddress.ID && address.IpAddress == ipAddress.IpAddress)
                    Result++; ;
            }

            return (Result);
        }

        /// <summary>
        /// Generates a list of expired addresses
        /// </summary>
        /// <param name="date">date expired</param>
        /// <returns>AddressList collection</returns>
        public IPAddresses Expired()
        {
            IPAddresses Result = new IPAddresses();

            foreach (IPAddress address in this)
            {
                if (address.IsExpired)
                    Result.Add(address);
            }

            return (Result);
        }

        /// <summary>
        /// Determines wether an ip address is black listed or not
        /// </summary>
        /// <param name="IPAddress"></param>
        /// <returns>bool, true if blacklisted, otherwise false</returns>
        public bool BlackListed(string IPAddress)
        {
            bool Result = false;

            foreach (IPAddress address in this)
            {
                if (address.IpAddress == IPAddress)
                {
                    if (address.BlackListed && !address.CanExpire && address.IsActive)
                    {
                        Result = true;
                        break;
                    }
                }
            }

            return (Result);
        }

        ///// <summary>
        ///// Retrieves all Address data for a specific IP Address
        ///// </summary>
        ///// <param name="ipAddress"></param>
        ///// <returns></returns>
        //public IPAddresses History(string ipAddress)
        //{
        //    IPAddresses Result = new IPAddresses();

        //    foreach (IPAddress address in this)
        //    {
        //        if (address.IpAddress == ipAddress)
        //        {
        //            Result.Add(address);
        //        }
        //    }

        //    return (Result);
        //}

        #endregion Public Methods

        #region Generic CollectionBase Code

        #region Properties

        public IPAddress this[int Index]
        {
            get
            {
                return ((IPAddress)this.InnerList[Index]);
            }

            set
            {
                this.InnerList[Index] = value;
            }
        }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Adds an item to the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Add(IPAddress value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(IPAddress value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, IPAddress value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(IPAddress value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(IPAddress value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.IPAddresses.IPAddress";
        private const string OBJECT_TYPE_ERROR = "Must be of type IPAddress";


        #endregion Private Members

        #region Overridden Methods

        /// <summary>
        /// When Inserting an Item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        protected override void OnInsert(int index, Object value)
        {
            if (value.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR, "value");
        }


        /// <summary>
        /// When removing an item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        protected override void OnRemove(int index, Object value)
        {
            if (value.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR, "value");
        }


        /// <summary>
        /// When Setting an Item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        protected override void OnSet(int index, Object oldValue, Object newValue)
        {
            if (newValue.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR, "newValue");
        }


        /// <summary>
        /// Validates an object
        /// </summary>
        /// <param name="value"></param>
        protected override void OnValidate(Object value)
        {
            if (value.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR);
        }


        #endregion Overridden Methods

        #endregion Generic CollectionBase Code
    }
}
