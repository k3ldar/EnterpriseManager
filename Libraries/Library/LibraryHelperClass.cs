using System;
using System.Collections.Generic;


using Shared.Classes;

namespace Library
{
    /// <summary>
    /// Website contains methods that the website uses to interact with BOL
    /// </summary>
    public sealed class LibraryHelperClass
    {
        #region Private Members

        private static bool _initialised = false;

        #endregion Private Members

        #region Properties

        public static string Path
        {
            get
            {
                return (DAL.DALHelper.Path);
            }
        }

        #endregion Properties

        #region Popup

        public string GetPopupData(int PopupID, out string Title)
        {
            return (DAL.FirebirdDB.GetPopupData(PopupID, out Title));
        }

        #endregion Popup

        #region Routine Maintenance

        public void ProcessUnpaidOrders()
        {
            DAL.FirebirdDB.OrdersProcessUnpaid();
        }

        #endregion Routine Maintenance

        public static Int64 GetBasketID(int increment)
        {
            return (DAL.FirebirdDB.BasketGetNextID(increment));
        }

        public static void ResetCache()
        {
            CacheManager.ClearAllCaches();
        }

        public static string MetaKeyWords()
        {
            const string META_CACHE_NAME = "META KEYWORDS";
            CacheItem item = DAL.DALHelper.InternalCache.Get(META_CACHE_NAME);

            if (item != null)
                return ((string)item.Value);

            item = new CacheItem(META_CACHE_NAME, SettingsGetMeta("META_KEYWORDS"));
            DAL.DALHelper.InternalCache.Add(META_CACHE_NAME, item, true);

            return ((string)item.Value);
        }

        #region IP Addresses

        public static int IPAddressToCountryProcessFile(string GeoFile, string GeoTempTable, out int Updated, 
            out int Unchanged, out int Added, out int Unknown, out Int64 NewVersion)
        {
            string GeoPath = System.IO.Path.GetDirectoryName(GeoFile);
            return (DAL.FirebirdDB.IPAddressToCountryProcessFile(GeoPath, GeoFile, GeoTempTable, out Updated, out Unchanged, out Added, out Unknown, out NewVersion));

            //if (Updated > 0)
                
        }

        public static string IPAddressToCountryVersion(Int64 version)
        {
            return (DAL.FirebirdDB.IPAddressToCountryCreateUpdateSQL(version));
        }

        public static string IPAddressToCountry(string IPAddress)
        {
            if (IPAddress == "::1")
                IPAddress = "127.0.0.1";

            if (DAL.DALHelper.AllowCaching)
            {
                CacheItem item = DAL.DALHelper.InternalCache.Get(IPAddress);

                if (item != null)
                    return (((IPAddressData)item.Value).CountryCode);

                item = new CacheItem(IPAddress, new IPAddressData(IPAddress,
                        DAL.FirebirdDB.IPAddressToCountry(IPAddress),
                        false));
                DAL.DALHelper.InternalCache.Add(IPAddress, item, true);

                return (((IPAddressData)item.Value).CountryCode);
            }

            return (DAL.FirebirdDB.IPAddressToCountry(IPAddress));
        }

        public static string IPAddressToCountryA(string IPAddress)
        {
            return (DAL.FirebirdDB.IPAddressToCountryA(IPAddress));
        }

        public static bool IPAddressIsBanned(string IPAddress, out int BanType)
        {
            if (IPAddress == "::1")
                IPAddress = "127.0.0.1";

            BanType = 0;

            CacheItem item = DAL.DALHelper.InternalCache.Get(IPAddress);

            if (item != null)
                return (((IPAddressData)item.Value).IsBanned);

            item = new CacheItem(IPAddress, new IPAddressData(IPAddress,
                    DAL.FirebirdDB.IPAddressToCountry(IPAddress),
                    DAL.FirebirdDB.IPAddressIsBanned(IPAddress, out BanType)));
            DAL.DALHelper.InternalCache.Add(IPAddress, item, true);

            return (((IPAddressData)item.Value).IsBanned);
        }

        #endregion IP Addresses

        #region Settings

        public static bool InitialiseSettings()
        {
            Dictionary<string, string> allSettings = DAL.FirebirdDB.SettingsLoad();

            foreach (KeyValuePair<string, string> kvp in allSettings)
            {
                string cacheName = String.Format("Cached Setting {0}", kvp.Key);
                DAL.DALHelper.InternalCache.Add(cacheName, new CacheItem(kvp.Key, kvp.Value));
            }

            _initialised = true;

            return (_initialised);
        }

        public static bool SettingsExist(string name)
        {
            if (DAL.DALHelper.AllowCaching)
            {
                string cacheName = String.Format("Cached Setting {0}", name.ToUpper());

                CacheItem item = DAL.DALHelper.InternalCache.Get(cacheName);

                if (item != null)
                    return (true);

                bool value = DAL.FirebirdDB.SettingsExist(name);

                DAL.DALHelper.InternalCache.Add(cacheName, new CacheItem(name, value));

                return (value);
            }
            else
            {
                return (DAL.FirebirdDB.SettingsExist(name));
            }
        }

        public static double SettingsGetDouble(string name, double defaultValue)
        {
            return (Convert.ToDouble(SettingsGet(name, defaultValue.ToString())));
        }

        public static int SettingsGetInt(string name, int defaultValue)
        {
            return (Convert.ToInt32(SettingsGet(name, defaultValue.ToString())));
        }

        public static bool SettingsGetBool(string Name, bool defaultValue)
        {
            bool Result = false;

            switch (SettingsGet(Name, defaultValue.ToString()).ToLower())
            {
                case "yes":
                case "true":
                    Result = true;
                    break;
            }

            return (Result);
        }

        public static void SettingsSetMeta(string Name, string value)
        {
            Name = Name.ToUpper();

            if (DAL.DALHelper.AllowCaching)
            {
                Name = String.Format("Cached Setting {0}", Name);
                DAL.DALHelper.InternalCache.Add(Name, new CacheItem(Name, value), true);
            }

            DAL.FirebirdDB.SettingsSetMeta(Name, value);
        }

        public static string SettingsGetMeta(string name, string defaultValue = "")
        {
            string cacheName = String.Format("Cached Setting {0}", name.ToUpper());

            if (DAL.DALHelper.AllowCaching)
            {
                CacheItem item = DAL.DALHelper.InternalCache.Get(cacheName);

                if (item != null)
                    return ((string)item.Value);

                if (_initialised)
                    return (defaultValue);
            }

            name = name.ToUpper();

            string Result = defaultValue;

            if (DAL.FirebirdDB.SettingsExistMeta(name))
                Result = DAL.FirebirdDB.SettingsGetMeta(name);

            if (DAL.DALHelper.AllowCaching && !String.IsNullOrEmpty(Result))
            {
                DAL.DALHelper.InternalCache.Add(cacheName, new CacheItem(cacheName, Result));
            }

            return (Result);
        }

        public static string SettingsGet(string name, string defaultValue = "")
        {
            string cacheName = String.Format("Cached Setting {0}", name.ToUpper());

            if (DAL.DALHelper.AllowCaching)
            {
                CacheItem item = DAL.DALHelper.InternalCache.Get(cacheName);

                if (item != null)
                    return ((string)item.Value);
                else if (_initialised)
                    return (defaultValue);
            }

            name = name.ToUpper();

            string Result = defaultValue;

            try
            {
                if (DAL.FirebirdDB.SettingsExist(name))
                    Result = DAL.FirebirdDB.SettingsGet(name);

                if (DAL.DALHelper.AllowCaching)
                {
                    DAL.DALHelper.InternalCache.Add(cacheName, new CacheItem(cacheName, Result));
                    DAL.FirebirdDB.SettingsSet(name, Result);
                }
            }
            catch
            {
                // do nothing, the default will be returned
            }

            return (Result);
        }

        public static DateTime SettingsGetDateTime(string name, DateTime defaultValue)
        {
            string date = SettingsGet(name, Shared.Utilities.DateTimeToStr(defaultValue, "en-GB"));
            try
            {
                return (Shared.Utilities.StrToDateTime(date));
            }
            catch
            {
                return (defaultValue);
            }
        }

        public static decimal SettingsGetDecimal(string name, decimal defaultValue)
        {
            return (Convert.ToDecimal(SettingsGet(name, defaultValue.ToString())));
        }

        public static void SettingsSet(string Name, string Value)
        {
            string name = String.Format("Cached Setting {0}", Name.ToUpper());

            if (DAL.DALHelper.AllowCaching)
            {
                DAL.DALHelper.InternalCache.Add(name, new CacheItem(name, Value), true);
            }

            DAL.FirebirdDB.SettingsSet(Name, Value);
        }

        #endregion Settings

    }

    internal class IPAddressData
    {
        internal IPAddressData(string ipAddress, string countryCode, bool isBanned)
        {
            IPAddress = ipAddress;
            IsBanned = isBanned;
            CountryCode = countryCode;
        }

        internal string CountryCode { get; private set; }

        internal string IPAddress { get; private set; }

        internal bool IsBanned { get; private set; }
    }
}
