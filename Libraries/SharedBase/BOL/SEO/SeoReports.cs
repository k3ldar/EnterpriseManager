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
 *  File: SeoReports.cs
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

using Shared.Classes;
using SharedBase.BOL.Campaigns;

namespace SharedBase.BOL.SEO
{
    [Serializable]
    public sealed class SeoReports : BaseCollection
    {
        #region Static Methods

        /// <summary>
        /// Hourly data, last 96 records
        /// </summary>
        /// <returns></returns>
        public static SeoReports SEODataHourly()
        {
            if (DAL.DALHelper.AllowCaching)
            {
                string cacheName = "CACHE SEO DATA HOURLY";
                CacheItem cache = DAL.DALHelper.InternalCacheShort.Get(cacheName);

                if (cache == null)
                {
                    cache = new CacheItem(cacheName, DAL.FirebirdDB.SeoReportsHourly());
                    DAL.DALHelper.InternalCacheShort.Add(cacheName, cache);
                }

                return ((SeoReports)cache.Value);
            }

            return (DAL.FirebirdDB.SeoReportsHourly());
        }

        /// <summary>
        /// Gets last 30 days of seo as daily data
        /// </summary>
        /// <returns></returns>
        public static SeoReports SEODataDaily()
        {
            if (DAL.DALHelper.AllowCaching)
            {
                string cacheName = "CACHE SEO DATA DAILY";
                CacheItem cache = DAL.DALHelper.InternalCacheShort.Get(cacheName);

                if (cache == null)
                {
                    cache = new CacheItem(cacheName, DAL.FirebirdDB.SeoReportsDaily());
                    DAL.DALHelper.InternalCacheShort.Add(cacheName, cache);
                }

                return ((SeoReports)cache.Value);
            }

            return (DAL.FirebirdDB.SeoReportsDaily());
        }

        /// <summary>
        /// Gets last 10 weeks of seo as weekly data
        /// </summary>
        /// <returns></returns>
        public static SeoReports SEOWeekly()
        {
            if (DAL.DALHelper.AllowCaching)
            {
                string cacheName = "CACHE SEO DATA Weekly";
                CacheItem cache = DAL.DALHelper.InternalCacheShort.Get(cacheName);

                if (cache == null)
                {
                    cache = new CacheItem(cacheName, DAL.FirebirdDB.SeoReportsWeekly());
                    DAL.DALHelper.InternalCacheShort.Add(cacheName, cache);
                }

                return ((SeoReports)cache.Value);
            }

            return (DAL.FirebirdDB.SeoReportsWeekly());
        }

        /// <summary>
        /// Get's last 10 months of Monthly data
        /// </summary>
        /// <returns></returns>
        public static SeoReports SEOMonthly()
        {
            if (DAL.DALHelper.AllowCaching)
            {
                string cacheName = "CACHE SEO DATA MONTHLY";
                CacheItem cache = DAL.DALHelper.InternalCacheShort.Get(cacheName);

                if (cache == null)
                {
                    cache = new CacheItem(cacheName, DAL.FirebirdDB.SeoReportsMonthly());
                    DAL.DALHelper.InternalCacheShort.Add(cacheName, cache);
                }

                return ((SeoReports)cache.Value);
            }

            return (DAL.FirebirdDB.SeoReportsMonthly());
        }

        /// <summary>
        /// Retrieves campaign statistics
        /// </summary>
        /// <param name="campaign"></param>
        /// <returns></returns>
        public static SeoReports SEOCampaign(Campaign campaign)
        {
            return (DAL.FirebirdDB.SeoReportsCampaign(campaign));
        }

        public static SeoReports SEOMonthlyVisitsByCountry(int year, int month)
        {
            if (DAL.DALHelper.AllowCaching)
            {
                string cacheName = String.Format("CACHE SEO DATA VISITS BY COUNTRY, YEAR {0} MONTH {1}", year, month);
                CacheItem cache = DAL.DALHelper.InternalCacheShort.Get(cacheName);

                if (cache == null)
                {
                    cache = new CacheItem(cacheName, DAL.FirebirdDB.SeoReportsMonthlyVisitsByCountry(year, month));
                    DAL.DALHelper.InternalCacheShort.Add(cacheName, cache);
                }

                return ((SeoReports)cache.Value);
            }

            return (DAL.FirebirdDB.SeoReportsMonthlyVisitsByCountry(year, month));
        }

        public static SeoReports SEOMonthlyVisitsByCity(int year, int month)
        {
            if (DAL.DALHelper.AllowCaching)
            {
                string cacheName = String.Format("CACHE SEO DATA VISITS BY CITY, YEAR {0} MONTH {1}", year, month);
                CacheItem cache = DAL.DALHelper.InternalCacheShort.Get(cacheName);

                if (cache == null)
                {
                    cache = new CacheItem(cacheName, DAL.FirebirdDB.SeoReportsMonthlyVisitsByCity(year, month));
                    DAL.DALHelper.InternalCacheShort.Add(cacheName, cache);
                }

                return ((SeoReports)cache.Value);
            }

            return (DAL.FirebirdDB.SeoReportsMonthlyVisitsByCity(year, month));
        }

        public static SeoReports SEOMonthlySalesByCity(int year, int month)
        {
            if (DAL.DALHelper.AllowCaching)
            {
                string cacheName = String.Format("CACHE SEO DATA SALES BY CITY, YEAR {0} MONTH {1}", year, month);
                CacheItem cache = DAL.DALHelper.InternalCacheShort.Get(cacheName);

                if (cache == null)
                {
                    cache = new CacheItem(cacheName, DAL.FirebirdDB.SeoReportsMonthlySalesByCity(year, month));
                    DAL.DALHelper.InternalCacheShort.Add(cacheName, cache);
                }

                return ((SeoReports)cache.Value);
            }

            return (DAL.FirebirdDB.SeoReportsMonthlySalesByCity(year, month));
        }

        public static SeoReports SEOMonthlySalesByCountry(int year, int month)
        {
            if (DAL.DALHelper.AllowCaching)
            {
                string cacheName = String.Format("CACHE SEO DATA SALES BY COUNTRY, YEAR {0} MONTH {1}", year, month);
                CacheItem cache = DAL.DALHelper.InternalCacheShort.Get(cacheName);

                if (cache == null)
                {
                    cache = new CacheItem(cacheName, DAL.FirebirdDB.SeoReportsMonthlySalesByCountry(year, month));
                    DAL.DALHelper.InternalCacheShort.Add(cacheName, cache);
                }

                return ((SeoReports)cache.Value);
            }

            return (DAL.FirebirdDB.SeoReportsMonthlySalesByCountry(year, month));
        }

        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        /// <summary>
        /// Indexer Property
        /// </summary>
        /// <param name="Index">Index of object to return</param>
        /// <returns>Video object</returns>
        public SeoReport this[int Index]
        {
            get
            {
                return ((SeoReport)this.InnerList[Index]);
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
        public int Add(SeoReport value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(SeoReport value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, SeoReport value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(SeoReport value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(SeoReport value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.SEO.SeoReport";
        private const string OBJECT_TYPE_ERROR = "Must be of type SeoReport";


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
