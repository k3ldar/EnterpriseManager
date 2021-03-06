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
 *  File: Stock.cs
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

using Library;
using SharedBase.BOL.Users;
using SharedBase.BOL.Products;

namespace SharedBase.BOL.StockControl
{
    [Serializable]
    public sealed class Stock : BaseCollection
    {
        #region Static Methods

        public static Stock Get()
        {
            return DAL.FirebirdDB.StockItemsGet();
        }

        public static Stock Get(User user, bool CurrentStoreTill)
        {
            if (CurrentStoreTill)
                return DAL.FirebirdDB.StockItemsGet(user, DAL.DALHelper.StoreID, DAL.DALHelper.TillID);
            else
                return DAL.FirebirdDB.StockItemsGet();
        }

        public static Stock Get(User user, int StoreID)
        {
            return DAL.FirebirdDB.StockItemsGet(user, StoreID, 1);
        }

        public static Stock Get(User user, int storeID, int stockType)
        {
            return DAL.FirebirdDB.StockItemsGetFiltered(user, storeID, stockType);
        }

        public static string GetStockLocations(ProductCost productCost)
        {
            string Result = String.Empty;


            Stock currentStock = DAL.FirebirdDB.StockItemGet(productCost);

            foreach (StockItem item in currentStock)
            {
                if (item.Available > 0)
                {
                    SharedBase.BOL.Locations.StoreLocation location = SharedBase.BOL.Locations.Locations.Get(item.StoreID);
                    Result += String.Format("{0} has a quantity of {1}\r\n", location.StoreName, item.Available);
                }
            }

            return Result;
        }


        public static void CreateStock(StockItem stockCreated, User currentUser, int quantity)
        {
            DAL.FirebirdDB.StockCreate(stockCreated, currentUser, quantity);
        }

        #endregion Static Methods

        #region Public Methods

        public void Save()
        {
            foreach (StockItem item in this)
            {
                if (item.Changed)
                    DAL.FirebirdDB.StockItemSaveChanges(item);
            }
        }

        public void Audit(User CurrentUser, Stock CurrentStock, bool Partial)
        {
            DAL.FirebirdDB.StockAudit(this, CurrentStock, CurrentUser, Partial);
        }

        public StockItem Find(Int64 ID)
        {
            StockItem Result = null;

            foreach (StockItem item in this)
            {
                if (item.ID == ID)
                {
                    Result = item;
                    break;
                }
            }

            return Result;
        }

        public void StockInAudit(User CurrentUser)
        {
            DAL.FirebirdDB.StockItemAddStockInAudit(this, CurrentUser);
        }

        public void StockOutAudit(User CurrentUser, string Reason)
        {
            DAL.FirebirdDB.StockItemAddStockOutAudit(this, CurrentUser, Reason);
        }

        #endregion Public Methods

        #region Generic CollectionBase Code

        #region Properties

        public StockItem this[int Index]
        {
            get
            {
                return (StockItem)this.InnerList[Index];
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
        public int Add(StockItem value)
        {
            return List.Add(value);
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(StockItem value)
        {
            return List.IndexOf(value);
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, StockItem value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(StockItem value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(StockItem value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return List.Contains(value);
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "SharedBase.BOL.StockControl.StockItem";
        private const string OBJECT_TYPE_ERROR = "Must be of type StockItem";


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
