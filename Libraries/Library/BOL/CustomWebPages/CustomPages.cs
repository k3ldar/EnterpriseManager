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
 *  File: CustomPages.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Threading;

using Shared.Classes;

using Library.BOL.Countries;
using Library.BOL.Products;

namespace Library.BOL.CustomWebPages
{
    [Serializable]
    public sealed class CustomPages : BaseCollection
    {
        #region Static Properties


        #endregion Static Properties

        #region Static Methods

        /// <summary>
        /// Returns an individual Custom Static Page
        /// </summary>
        /// <param name="title">Title of page to return</param>
        /// <param name="country">Country for who's custom page is to be returned</param>
        /// <returns>CustomPage object if found, otherwise null</returns>
        public static CustomPage Get(string title, Country country, int webSiteID)
        {
            if (country == null)
                throw new ArgumentNullException(nameof(country));

            if (String.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));

            if (!country.CanLocalize)
            {
                if (Websites.WebsiteSettings.Languages.UseCustomPages)
                {
                    webSiteID = 0;
                    country = Countries.Countries.Get(0);
                }
            }

            if (CacheAvailable)
            {
                string cacheName = String.Format(Consts.CACHE_NAME_CUSTOM_PAGE_GET_TITLE,
                    title, country.Name, webSiteID);

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.CustomPageGet(title, country, CustomPagesType.WebPage, webSiteID));
                    CachedItemAdd(cacheName, Result);
                }

                return ((CustomPage)Result.Value);
            }
            else
                return (DAL.FirebirdDB.CustomPageGet(title, country, CustomPagesType.WebPage, webSiteID));
        }

        public static CustomPage Get(string title)
        {
            if (Websites.WebsiteSettings.Languages.UseCustomPages)
            {
                Country country = Countries.Countries.Get(Thread.CurrentThread.CurrentUICulture);
                int websiteID = DAL.DALHelper.WebsiteID;

                CustomPage Result = Get(title, country, DAL.DALHelper.WebsiteID);

                if (Result == null)
                {
                    return (Get(title, Countries.Countries.Get(0), 0));
                }

                return (Result);
            }
            else
            {
                return (Get(title, Countries.Countries.Get(0), 0));
            }
        }

        /// <summary>
        /// Returns translated page data for a product
        /// </summary>
        /// <param name="country"></param>
        /// <param name="product"></param>
        /// <param name="pageType"></param>
        /// <returns></returns>
        public static CustomPage Get(Country country, Product product, CustomPagesType pageType)
        {
            if (CacheAvailable)
            {
                string cacheName = String.Format(Consts.CACHE_NAME_CUSTOM_PAGE_COUNTRY_TYPE,
                    country.Name, product.ID, pageType.ToString());

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.CustomPageGet(country, product, pageType));
                    CachedItemAdd(cacheName, Result);
                }

                return ((CustomPage)Result.Value);
            }
            else
                return (DAL.FirebirdDB.CustomPageGet(country, product, pageType));
        }

        /// <summary>
        /// Retrieves a collection of all custom pages
        /// </summary>
        /// <returns>CustomPages collection</returns>
        public static CustomPages GetAll(int websiteID)
        {
            if (CacheAvailable)
            {
                string cacheName = String.Format(Consts.CACHE_NAME_CUSTOM_PAGE_ALL_BY_WEBSITE,
                    websiteID);

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.CustomPagesGet(websiteID));
                    CachedItemAdd(cacheName, Result);
                }

                return ((CustomPages)Result.Value);
            }
            else
                return (DAL.FirebirdDB.CustomPagesGet(websiteID));
        }

        #endregion Static Methods

        #region Public Methods

        public CustomPage Find(string title)
        {
            foreach (CustomPage page in this)
            {
                if (page.Title == title)
                {
                    return (page);
                }
            }

            return (null);
        }

        #endregion Public Methods

        #region Generic CollectionBase Code

        #region Properties

        public CustomPage this[int Index]
        {
            get
            {
                return ((CustomPage)this.InnerList[Index]);
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
        public int Add(CustomPage value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(CustomPage value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, CustomPage value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(CustomPage value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(CustomPage value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.CustomWebPages.CustomPage";
        private const string OBJECT_TYPE_ERROR = "Must be of type CustomPage";


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
