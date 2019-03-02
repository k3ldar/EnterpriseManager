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
 *  File: Currencies.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

using Shared.Classes;

namespace SharedBase.BOL.Basket
{
    [Serializable]
    public sealed class Currencies : BaseCollection
    {
        #region Static Methods

        /// <summary>
        /// Get's an individual currency code
        /// </summary>
        /// <param name="currencyCode"></param>
        /// <returns></returns>
        public static Currency Get(string currencyCode)
        {
            if (currencyCode.Length > 3)
            {
                throw new ArgumentException("Invalid Currency Code");
            }

            string cacheName = String.Format("DAL CURRENCY BY CODE {0}", currencyCode);

            CacheItem item = DAL.DALHelper.InternalCache.Get(cacheName);

            if (item != null)
                return ((Currency)item.Value);

            Currency Result = DAL.FirebirdDB.CurrenciesGetCurrency(currencyCode);
            DAL.DALHelper.InternalCache.Add(cacheName, new CacheItem(cacheName, Result));
            return (Result);        
        }


        public static Currency Get(CultureInfo culture)
        {
            string cacheName = String.Format("DAL CURRENCY {0}", culture);

            CacheItem item = DAL.DALHelper.InternalCache.Get(cacheName);

            if (item != null)
                return ((Currency)item.Value);

            Currency Result = DAL.FirebirdDB.CurrenciesGetCulture(culture);

            DAL.DALHelper.InternalCache.Add(cacheName, new CacheItem(cacheName, Result));
            return (Result);
        }

        /// <summary>
        /// Gets all currency codes
        /// </summary>
        /// <returns></returns>
        public static Currencies Get()
        {
            string cacheName = "All DAL Currencies";
            CacheItem item = DAL.DALHelper.InternalCache.Get(cacheName);

            if (item != null)
                return ((Currencies)item.Value);

            Currencies Result = DAL.FirebirdDB.CurrenciesGetAll();
            DAL.DALHelper.InternalCache.Add(cacheName, new CacheItem(cacheName, Result));

            foreach (Currency currency in Result)
            {
                cacheName = String.Format("DAL CURRENCY {0}", currency.Culture);
                CacheItem currencyCache = DAL.DALHelper.InternalCache.Get(cacheName);

                if (currencyCache == null)
                    DAL.DALHelper.InternalCache.Add(cacheName, new CacheItem(cacheName, currency));
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
        /// <returns>Currency object</returns>
        public Currency this[int Index]
        {
            get
            {
                return ((Currency)this.InnerList[Index]);
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
        public int Add(Currency value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(Currency value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, Currency value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(Currency value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Currency value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Basket.Currency";
        private const string OBJECT_TYPE_ERROR = "Must be of type Currency";


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
