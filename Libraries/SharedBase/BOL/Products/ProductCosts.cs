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
 *  File: ProductCosts.cs
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

using SharedBase.BOL.Users;

namespace SharedBase.BOL.Products
{
    [Serializable]
    public sealed class ProductCosts : BaseCollection
    {
        #region Properties

        #endregion Properties

        #region Static Methods

        public static ProductCost GetBySKU(string sku)
        {
            if (CacheAvailable)
            {
                string cacheName = String.Format(Consts.CACHE_NAME_PRODUCT_COSTS_BY_SKU,
                    sku);

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.ProductCostGetSKU(sku));
                    CachedItemAdd(cacheName, Result);
                }

                return ((ProductCost)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductCostGetSKU(sku));
        }
        /// <summary>
        /// Returns a ProductCost item determined by it's barcode
        /// </summary>
        /// <param name="barcode">Barcode</param>
        /// <returns>ProductCostItem if found, otherwise null</returns>
        public static ProductCost GetByBarcode(string barcode)
        {
            return (DAL.FirebirdDB.ProductCostGetByBarcode(barcode));
        }

        /// <summary>
        /// Returns all product costs for users member level
        /// </summary>
        /// <param name="ID">ID of Product</param>
        /// <param name="user">User</param>
        /// <returns></returns>
        public static ProductCost Get(int ID, User user)
        {
            if (CacheAvailable)
            {
                string cacheName = String.Format(Consts.CACHE_NAME_PRODUCT_COSTS_GET_ID_MEMBER,
                    ID, user == null ? MemberLevel.StandardUser.ToString() : user.MemberLevel.ToString());

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.ProductCostGet(ID, user));
                    CachedItemAdd(cacheName, Result);
                }

                return ((ProductCost)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductCostGet(ID, user));
        }

        public static ProductCost Get(int ID)
        {
            if (CacheAvailable)
            {
                string cacheName = String.Format(Consts.CACHE_NAME_PRODUCT_COSTS_GET_ID_INT,
                    ID);

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.ProductCostGet(ID));
                    CachedItemAdd(cacheName, Result);
                }

                return ((ProductCost)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductCostGet(ID));
        }

        public static ProductCost Get(long ID)
        {
            if (CacheAvailable)
            {
                string cacheName = String.Format(Consts.CACHE_NAME_PRODUCT_COSTS_GET_ID,
                    ID);

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.ProductCostGet(Convert.ToInt32(ID)));
                    CachedItemAdd(cacheName, Result);
                }

                return ((ProductCost)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductCostGet(Convert.ToInt32(ID)));
        }

        public static ProductCosts Get()
        {
            if (CacheAvailable)
            {
                string cacheName = Consts.CACHE_NAME_PRODUCT_COSTS_GET_OFFERS;

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.ProductCostsGetFreeOffers());
                    CachedItemAdd(cacheName, Result);
                }

                return ((ProductCosts)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductCostsGetFreeOffers());
        }

        /// <summary>
        /// Returns a collection of all product cost items for a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static ProductCosts All(Product product)
        {
            if (CacheAvailable)
            {
                string cacheName = String.Format(Consts.CACHE_NAME_PRODUCT_COSTS_ALL,
                    product.ID);

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.ProductCostsGet(product, MemberLevel.Admin));
                    CachedItemAdd(cacheName, Result);
                }

                return ((ProductCosts)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductCostsGet(product, MemberLevel.Admin));
        }


        public static ProductCost Get (int id, MemberLevel memberLevel)
        {
            if (CacheAvailable)
            {
                string cacheName = String.Format(Consts.CACHE_NAME_PRODUCT_COSTS_MEMBER_LEVEL,
                   id, memberLevel.ToString());

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.ProductCostGet(id, memberLevel));
                    CachedItemAdd(cacheName, Result);
                }

                return ((ProductCost)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductCostGet(id, memberLevel));
        }

        /// <summary>
        /// Retrieves the gift wrap product if there is one
        /// </summary>
        /// <returns></returns>
        public static ProductCost GiftWrapProduct ()
        {
            if (CacheAvailable)
            {
                string cacheName = Consts.CACHE_NAME_PRODUCT_COSTS_GIFT_WRAP;

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.ProductCostGetGiftWrap());
                    CachedItemAdd(cacheName, Result);
                }

                return ((ProductCost)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductCostGetGiftWrap());
        }

        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        public ProductCost this[int Index]
        {
            get
            {
                return ((ProductCost)this.InnerList[Index]);
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
        public int Add(ProductCost value)
        {
            return (List.Add(value));
        }

        public void Add(ProductCosts costs)
        {
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(ProductCost value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, ProductCost value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(ProductCost value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(ProductCost value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.

            foreach (ProductCost item in this)
            {
                if (item.ID == value.ID)
                    return (true);
            }

            return (false);
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Products.ProductCost";
        private const string OBJECT_TYPE_ERROR = "Must be of type ProductCost";


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