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
 *  File: ProductCostTypes.cs
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

namespace SharedBase.BOL.Products
{
    [Serializable]
    public sealed class ProductCostTypes : BaseCollection
    {
        #region Static Methods

        public static ProductCostType Create(string description, ProductCostItemType itemType)
        {
            return (DAL.FirebirdDB.ProductCostTypeInsert(description, itemType));
        }

        /// <summary>
        /// Returns a collection of product group types
        /// </summary>
        /// <returns>ProductGroupTypes collection</returns>
        public static ProductCostTypes Get(bool forceRefresh = false)
        {
            CacheItem cachedResult = DAL.DALHelper.InternalCache.Get(Consts.CACHE_NAME_PRODUCT_COST_TYPES);

            if (forceRefresh && cachedResult != null)
            {
                DAL.DALHelper.InternalCache.Remove(cachedResult);
                cachedResult = null;
            }

            if (DAL.DALHelper.AllowCaching && cachedResult == null)
            {
                cachedResult = new CacheItem(Consts.CACHE_NAME_PRODUCT_COST_TYPES, DAL.FirebirdDB.ProductCostTypesGet());
                DAL.DALHelper.InternalCache.Add(Consts.CACHE_NAME_PRODUCT_COST_TYPES, cachedResult);
            }


            if (cachedResult != null)
                return ((ProductCostTypes)cachedResult.Value);
            else
                return (DAL.FirebirdDB.ProductCostTypesGet());
        }

        /// <summary>
        /// Returns a product group type based on it's name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ProductCostType Get(string name)
        {
            foreach (ProductCostType pcType in Get())
            {
                if (pcType.Description == name)
                    return (pcType);
            }

            return (DAL.FirebirdDB.ProductCostTypeGet(name));
        }

        /// <summary>
        /// Returns a product group type based on it's name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ProductCostType Get(int id)
        {
            foreach (ProductCostType pcType in Get())
            {
                if (pcType.ID == id)
                    return (pcType);
            }

            return (DAL.FirebirdDB.ProductCostTypeGet(id));
        }

        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        /// <summary>
        /// Indexer Property
        /// </summary>
        /// <param name="Index">Index of object to return</param>
        /// <returns>ProductType object</returns>
        public ProductCostType this[int Index]
        {
            get
            {
                return ((ProductCostType)this.InnerList[Index]);
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
        public int Add(ProductCostType value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(ProductCostType value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, ProductCostType value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(ProductCostType value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(ProductCostType value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "SharedBase.BOL.Products.ProductCostType";
        private const string OBJECT_TYPE_ERROR = "Must be of type ProductCostType";


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
