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
 *  File: Products.cs
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

using Library.BOL.Celebrities;
using Library.BOL.Statistics;

namespace Library.BOL.Products
{
    [Serializable]
    public sealed class Products : BaseCollection
    {
        #region Properties

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Returns the First product in the list
        /// </summary>
        /// <returns>Product Item</returns>
        public Product First()
        {
            Product Result = null;

            foreach (Product product in this)
            {
                Result = product;
                break;
            }

            return (Result);
        }

        #endregion Public Methods

        #region Static Methods

        public static SimpleStatistics TopProducts(int quantity)
        {
            if (quantity < 1)
                throw new ArgumentOutOfRangeException(nameof(quantity));

            if (CacheAvailable)
            {
                CacheItem Result = CachedItemGet(Consts.CACHE_NAME_PRODUCTS_TOP);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(Consts.CACHE_NAME_PRODUCTS_TOP, DAL.FirebirdDB.ProductsGetTopProducts(quantity));
                    CachedItemAdd(Consts.CACHE_NAME_PRODUCTS_TOP, Result);
                }

                return ((SimpleStatistics)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductsGetTopProducts(quantity));
        }

        public static SimpleStatistics FeaturedProducts()
        {
            return (DAL.FirebirdDB.AdminProductsStatsFeaturedProducts());
        }

        public static SimpleStatistics DuplicateSKUCodes()
        {
            return (DAL.FirebirdDB.AdminProductsStatsSKUDuplicateCodes());
        }

        public static SimpleStatistics InvalidSKUCodes()
        {
            return (DAL.FirebirdDB.AdminProductsStatsSKUInvalidCodes());
        }

        public static ProductCosts GetDiscounted()
        {
            if (CacheAvailable)
            {
                CacheItem Result = CachedItemGet(Consts.CACHE_NAME_PRODUCTS_DISCOUNTED);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(Consts.CACHE_NAME_PRODUCTS_DISCOUNTED, DAL.FirebirdDB.DiscountedProducts());
                    CachedItemAdd(Consts.CACHE_NAME_PRODUCTS_DISCOUNTED, Result);
                }

                return ((ProductCosts)Result.Value);
            }
            else
                return (DAL.FirebirdDB.DiscountedProducts());
        }

        /// <summary>
        /// Returns the number of products publicly visible
        /// </summary>
        /// <returns>int - Count of products</returns>
        public static int GetCount(ProductType primaryProductType)
        {
            if (CacheAvailable)
            {
                CacheItem Result = CachedItemGet(Consts.CACHE_NAME_PRODUCTS_COUNT);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(Consts.CACHE_NAME_PRODUCTS_COUNT, DAL.FirebirdDB.ProductsCount(primaryProductType));
                    CachedItemAdd(Consts.CACHE_NAME_PRODUCTS_COUNT, Result);
                }

                return ((int)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductsCount(primaryProductType));
        }

        /// <summary>
        /// Returns the number of products that are on offer
        /// </summary>
        /// <returns></returns>
        public static int CountOffers()
        {
            if (CacheAvailable)
            {
                CacheItem Result = CachedItemGet(Consts.CACHE_NAME_PRODUCTS_COUNT_OFFERS);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(Consts.CACHE_NAME_PRODUCTS_COUNT_OFFERS, DAL.FirebirdDB.ProductsCountOffers());
                    CachedItemAdd(Consts.CACHE_NAME_PRODUCTS_COUNT_OFFERS, Result);
                }

                return ((int)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductsCountOffers());
        }

        /// <summary>
        /// Returns the number of products within a product group
        /// </summary>
        /// <param name="ProductGroup">Product Group ID</param>
        /// <returns>int - Count of products for specified product group</returns>
        public static int CountByProduct(ProductGroup ProductGroup)
        {
            if (ProductGroup == null)
                return (0);

            if (CacheAvailable)
            {
                string cacheName = String.Format(Consts.CACHE_NAME_PRODUCTS_COUNT_BY_PRODUCT_GROUP, ProductGroup.ID);

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.ProductsCountByProduct(ProductGroup.ID));
                    CachedItemAdd(cacheName, Result);
                }

                return ((int)Result.Value);
            }
            else
            {
                if (ProductGroup != null)
                    return (DAL.FirebirdDB.ProductsCountByProduct(ProductGroup.ID));
                else
                    return (0);
            }
        }

        /// <summary>
        /// Determines wether a SKU code is valid
        /// </summary>
        /// <param name="SKU">SKU code to validate</param>
        /// <returns>bool - true if valid SKU otherwise false</returns>
        public static bool IsValidSKU(string SKU)
        {
            return (DAL.FirebirdDB.ProductIsValidSKU(SKU));
        }

        /// <summary>
        /// Returns the featured product
        /// </summary>
        /// <returns>Returns featured product for product type</returns>
        public static Product GetFeatured()
        {
            if (CacheAvailable)
            {
                CacheItem Result = CachedItemGet(Consts.CACHE_NAME_PRODUCT_FEATURED);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(Consts.CACHE_NAME_PRODUCT_FEATURED, DAL.FirebirdDB.ProductGetFeatured());
                    CachedItemAdd(Consts.CACHE_NAME_PRODUCT_FEATURED, Result);
                }

                return ((Product)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductGetFeatured());
        }

        /// <summary>
        /// Returns all products to be featured in the carousel
        /// </summary>
        /// <returns>Products object</returns>
        public static Products GetCarousel()
        {
            if (CacheAvailable)
            {
                CacheItem Result = CachedItemGet(Consts.CACHE_NAME_PRODUCTS_CAROUSEL);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(Consts.CACHE_NAME_PRODUCTS_CAROUSEL, DAL.FirebirdDB.ProductsGetCarousel());
                    CachedItemAdd(Consts.CACHE_NAME_PRODUCTS_CAROUSEL, Result);
                }

                return ((Products)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductsGetCarousel());
        }

        public static Products GetFeaturedProducts()
        {
            if (CacheAvailable)
            {
                CacheItem Result = CachedItemGet(Consts.CACHE_NAME_PRODUCTS_FEATURED);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(Consts.CACHE_NAME_PRODUCTS_CAROUSEL, DAL.FirebirdDB.ProductsGetFeatured());
                    CachedItemAdd(Consts.CACHE_NAME_PRODUCTS_CAROUSEL, Result);
                }

                return ((Products)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductsGetFeatured());
        }

        public static Products Get(Celebrity celebrity)
        {
            if (CacheAvailable)
            {
                string cacheName = String.Format(Consts.CACHE_NAME_PRODUCTS_CELEBRITY, celebrity.ID);

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.ProductsGet(celebrity));
                    CachedItemAdd(cacheName, Result);
                }

                return ((Products)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductsGet(celebrity));
        }

        /// <summary>
        /// Returns an individual product
        /// </summary>
        /// <param name="ProductID">ID of the product to return</param>
        /// <returns>Product object</returns>
        public static Product Get(Int64 ProductID)
        {
            if (CacheAvailable)
            {
                string cacheName = String.Format(Consts.CACHE_NAME_PRODUCTS_GET_INDIVIDUAL, ProductID);

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.ProductGet(ProductID));
                    CachedItemAdd(cacheName, Result);
                }

                return ((Product)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductGet(ProductID));
        }

        public static Products Get(ProductType primaryProductType, int PageNumber, int PageSize, bool IncludeCosts)
        {
            if (CacheAvailable)
            {
                string cacheName = String.Format(Consts.CACHE_NAME_PRODUCTS_GET_PRODUCT_AND_COSTS,
                    primaryProductType.ID, PageNumber, PageSize, IncludeCosts.ToString());

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.ProductsGet(primaryProductType, PageNumber, PageSize, IncludeCosts));
                    CachedItemAdd(cacheName, Result);
                }

                return ((Products)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductsGet(primaryProductType, PageNumber, PageSize, IncludeCosts));
        }

        /// <summary>
        /// Returns a page of products
        /// </summary>
        /// <param name="PageNumber">Current page</param>
        /// <param name="PageSize">Number of products per page</param>
        /// <returns>Products collection</returns>
        public static Products Get(ProductType primaryProductType, int PageNumber, int PageSize)
        {
            if (primaryProductType == null)
                throw new ArgumentNullException(nameof(primaryProductType));
                    
            if (CacheAvailable)
            {
                string cacheName = String.Format(Consts.CACHE_NAME_PRODUCTS_GET_PRODUCT_BY_TYPE,
                    primaryProductType.ID, PageNumber, PageSize);

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.ProductsGet(primaryProductType, PageNumber, PageSize));
                    
                    CachedItemAdd(cacheName, Result);
                }

                return ((Products)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductsGet(primaryProductType, PageNumber, PageSize));
        }

        /// <summary>
        /// Returns a page of products for a product group
        /// </summary>
        /// <param name="PageNumber">Current page</param>
        /// <param name="PageSize">Number of products per page</param>
        /// <param name="ProductGroup">Productgroup id</param>
        /// <returns>Products collection</returns>
        public static Products Get(ProductType primaryProductType, int PageNumber, int PageSize, ProductGroup ProductGroup)
        {
            if (CacheAvailable)
            {
                string cacheName = String.Format(Consts.CACHE_NAME_PRODUCTS_GET_GROUPANDPRODUCT, 
                    primaryProductType.ID, PageNumber, PageSize, ProductGroup.ID);

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.ProductsGet(primaryProductType, PageNumber, PageSize, ProductGroup));
                    CachedItemAdd(cacheName, Result);
                }

                return ((Products)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductsGet(primaryProductType, PageNumber, PageSize, ProductGroup));
        }


        /// <summary>
        /// Returns all products for a specific SKU
        /// </summary>
        /// <param name="SKU">SKU for products</param>
        /// <returns>Products collection</returns>
        public static Products GetBySKU(string SKU)
        {
            if (CacheAvailable)
            {
                string cacheName = String.Format(Consts.CACHE_NAME_PRODUCTS_GET_BY_SKU,
                    SKU);

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.ProductsGetBySKU(SKU));
                    CachedItemAdd(cacheName, Result);
                }

                return ((Products)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductsGetBySKU(SKU));
        }

        /// <summary>
        /// Returns a page of products on offer
        /// </summary>
        /// <param name="PageNumber">Current Page</param>
        /// <param name="PageSize">Number of products per page</param>
        /// <returns></returns>
        public static Products GetOffers(int PageNumber, int PageSize)
        {
            if (CacheAvailable)
            {
                string cacheName = String.Format(Consts.CACHE_NAME_PRODUCTS_PAGE_OFFERS,
                    PageNumber, PageSize);

                CacheItem Result = CachedItemGet(cacheName);

                if (Result == null)
                {
                    // item not found, add and return
                    Result = new CacheItem(cacheName, DAL.FirebirdDB.ProductsGetOffers(PageNumber, PageSize));
                    CachedItemAdd(cacheName, Result);
                }

                return ((Products)Result.Value);
            }
            else
                return (DAL.FirebirdDB.ProductsGetOffers(PageNumber, PageSize));
        }

        public static Products GetBlackLabel(Users.User user)
        {
            return (DAL.FirebirdDB.ProductGetBlackLabel(user));
        }

        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        public Product this[int Index]
        {
            get
            {
                return ((Product)this.InnerList[Index]);
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
        public int Add(Product value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(Product value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, Product value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(Product value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Product value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Products.Product";
        private const string OBJECT_TYPE_ERROR = "Must be of type Therapist";


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