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
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: Countries.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Globalization;

using Shared.Classes;

namespace SharedBase.BOL.Countries
{
    [Serializable]
    public sealed class Countries : BaseCollection
    {
        #region Static Methods

        public static Double ShippingCosts(string CountryCode)
        {
            return (DAL.FirebirdDB.GetShippingCosts(CountryCode));
        }

        public static Double ShippingCosts(int UserID, int AddressID)
        {
            return (DAL.FirebirdDB.GetShippingCosts(UserID, AddressID));
        }

        public static Double ShippingCostsDefault(string CountryCode)
        {
            return (DAL.FirebirdDB.GetShippingCostsDefault(CountryCode));
        }

        public static Countries Get()
        {
            if (DAL.DALHelper.AllowCaching)
            {
                CacheItem item = DAL.DALHelper.InternalCache.Get("All Cached Countries");

                if (item == null)
                {
                    Countries countries = DAL.FirebirdDB.CountriesGet();

                    item = new CacheItem("All Cached Countries", countries);

                    foreach (Country country in countries)
                    {
                        string name = String.Format("Individual Country By Code {0}", country.CountryCode);
                        CacheItem countryItem = DAL.DALHelper.InternalCache.Get(name);

                        if (countryItem == null)
                            DAL.DALHelper.InternalCache.Add(name, new CacheItem(name, country));

                        name = String.Format("Individual Country By ID {0}", country.ID);
                        countryItem = DAL.DALHelper.InternalCache.Get(name);

                        if (countryItem == null)
                            DAL.DALHelper.InternalCache.Add(name, new CacheItem(name, country));

                        //name = String.Format("Individual Country By Culture {0}", country.ID);
                        //countryItem = DAL.DALHelper.InternalCache.Get(name);

                        //if (countryItem == null)
                        //    DAL.DALHelper.InternalCache.Add(name, new CacheItem(name, country));
                    }
                }

                return ((Countries)item.Value);
            }

            return (DAL.FirebirdDB.CountriesGet());
        }

        public static Country Get(int CountryID)
        {
            if (DAL.DALHelper.AllowCaching)
            {
                string name = String.Format("Individual Country By ID {0}", CountryID);
                CacheItem countryItem = DAL.DALHelper.InternalCache.Get(name);

                if (countryItem == null)
                {
                    Country country = DAL.FirebirdDB.CountryGet(CountryID);
                    countryItem = new CacheItem(name, country);
                    DAL.DALHelper.InternalCache.Add(name, countryItem);
                }

                return ((Country)countryItem.Value);
            }

            return (DAL.FirebirdDB.CountryGet(CountryID));
        }

        /// <summary>
        /// Retrieves the country code base on the current culture
        /// </summary>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static Country Get(CultureInfo cultureInfo)
        {
            if (DAL.DALHelper.AllowCaching)
            {
                string name = String.Format("Individual Country By Culture {0}", cultureInfo.Name.ToLower());
                CacheItem countryItem = DAL.DALHelper.InternalCache.Get(name);

                if (countryItem == null)
                {
                    Country country = DAL.FirebirdDB.CountryGet(cultureInfo);
                    countryItem = new CacheItem(name, country);
                    DAL.DALHelper.InternalCache.Add(name, countryItem);
                }

                return ((Country)countryItem.Value);
            }

            return (DAL.FirebirdDB.CountryGet(cultureInfo));
        }

        public static Country Get(string CountryCode)
        {
            if (DAL.DALHelper.AllowCaching)
            {
                string name = String.Format("Individual Country By Code {0}", CountryCode);
                CacheItem countryItem = DAL.DALHelper.InternalCache.Get(name);

                if (countryItem == null)
                {
                    Country country = DAL.FirebirdDB.CountryGet(CountryCode);
                    countryItem = new CacheItem(name, country);
                    DAL.DALHelper.InternalCache.Add(name, countryItem);
                }

                return ((Country)countryItem.Value);
            }

            return (DAL.FirebirdDB.CountryGet(CountryCode));
        }


        public static Countries GetLocalized()
        {
            Countries Result = new Countries();

            Countries allCountries = DAL.FirebirdDB.CountriesGet();

            foreach (Country country in allCountries)
            {
                if (country.CanLocalize)
                    Result.Add(country);
            }

            return (Result);
        }

        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        /// <summary>
        /// Indexer Property
        /// </summary>
        /// <param name="Index">Index of object to return</param>
        /// <returns>Country object</returns>
        public Country this[int Index]
        {
            get
            {
                return ((Country)this.InnerList[Index]);
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
        public int Add(Country value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(Country value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, Country value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(Country value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Country value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Countries.Country";
        private const string OBJECT_TYPE_ERROR = "Must be of type Country";


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