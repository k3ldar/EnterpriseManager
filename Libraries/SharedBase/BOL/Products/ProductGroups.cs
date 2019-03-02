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
 *  File: ProductGroups.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
#if !ANDROID
using System.Web;
#endif
using System.Collections;

using Shared.Classes;

namespace SharedBase.BOL.Products
{
    [Serializable]
    public sealed class ProductGroups : BaseCollection
    {
        #region Private Members

        #endregion Private Members

        #region Public Methods

        public ProductGroup First()
        {
            ProductGroup Result = null;

            foreach (ProductGroup group in this)
            {
                Result = group;
                break;
            }

            return (Result);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Returns a collection of Product Groups visible on the website
        /// </summary>
        /// <returns>ProductGroups collection</returns>
        public static ProductGroups Get(MemberLevel MemberLevel, bool visibleOnWebsite)
        {
            CacheItem cachedResult = DAL.DALHelper.InternalCache.Get(String.Format(Consts.CACHE_NAME_PRODUCT_GROUPS, MemberLevel.ToString()));

            if (DAL.DALHelper.AllowCaching && cachedResult == null)
            {
                cachedResult = new CacheItem(String.Format(Consts.CACHE_NAME_PRODUCT_GROUPS, MemberLevel.ToString()), 
                    DAL.FirebirdDB.ProductGroupsGet(MemberLevel, visibleOnWebsite));
                DAL.DALHelper.InternalCache.Add(String.Format(Consts.CACHE_NAME_PRODUCT_GROUPS, MemberLevel.ToString()), cachedResult);
            }


            if (cachedResult != null)
                return ((ProductGroups)cachedResult.Value);
            else
                return (DAL.FirebirdDB.ProductGroupsGet(MemberLevel, visibleOnWebsite));
        }

        /// <summary>
        /// Returns a collection of Product Groups visible on the website
        /// </summary>
        /// <returns>ProductGroups collection</returns>
        public static ProductGroups Get(ProductGroupType groupType, MemberLevel MemberLevel)
        {
            if (groupType == null)
                throw new ArgumentNullException(nameof(groupType));

            if (CacheAvailable)
            {
                string cacheName = String.Format(Consts.CACHE_NAME_PRODUCT_GROUPS_GET, groupType.ID, MemberLevel.ToString());

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.ProductGroupsGet(groupType, MemberLevel));
                    CachedItemAdd(cacheName, Result);
                }
                    
                return ((ProductGroups)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductGroupsGet(groupType, MemberLevel));
        }


        /// <summary>
        /// Returns an individual ProductGroup item
        /// </summary>
        /// <param name="ProductGroupID">ID of ProductGroup to retrieve</param>
        /// <returns>ProductGroup if found, otherwise null</returns>
        public static ProductGroup Get(Int64 ProductGroupID)
        {
            if (ProductGroupID == -1)
                return (null);

            if (CacheAvailable)
            {
                string cacheName = String.Format("Product Group Get {0}", ProductGroupID);

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.ProductGroupGet(ProductGroupID));
                    CachedItemAdd(cacheName, Result);
                }

                return ((ProductGroup)Result.Value);
            }
            else
            {
                return (DAL.FirebirdDB.ProductGroupGet(ProductGroupID));
            }
        }


        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        public ProductGroup this[int Index]
        {
            get
            {
                return ((ProductGroup)this.InnerList[Index]);
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
        public int Add(ProductGroup value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(ProductGroup value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, ProductGroup value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(ProductGroup value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(ProductGroup value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "SharedBase.BOL.Products.ProductGroup";
        private const string OBJECT_TYPE_ERROR = "Must be of type ProductGroup";


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