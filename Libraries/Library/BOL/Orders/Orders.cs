using System;
using System.Collections;
using System.Collections.Generic;
#if !ANDROID
using System.Web;
#endif

using Library.BOL.Users;

namespace Library.BOL.Orders
{
    [Serializable]
    public sealed class Orders : BaseCollection
    {
        #region Static Methods

        /// <summary>
        /// Retrieves a list of cancelled or unpaid orders for a date range
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public static Orders GetUnpaid(DateTime dateFrom, DateTime dateTo)
        {
            return (DAL.FirebirdDB.OrdersUnpaid(dateFrom, dateTo));
        }

        public static Order Get(Int64 OrderID)
        {
            return (DAL.FirebirdDB.OrderGet(OrderID));
        }

        public static Orders GetProcessing()
        {
            ProcessStatuses status = ProcessStatuses.Processing;
            return (DAL.FirebirdDB.AdminOrdersGet(-1, -1, false, status));
        }

        /// <summary>
        /// Returns the number of orders for a user
        /// </summary>
        /// <param name="user">User to check how many orders they have</param>
        /// <returns>int 0 if none otherwise the number of orders</returns>
        public static int GetCount(User user)
        {
            return (DAL.FirebirdDB.OrdersGetCount(user));
        }

        public static Orders Get(User user)
        {
            return (DAL.FirebirdDB.OrdersGet(user));
        }

        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        public Order this[int Index]
        {
            get
            {
                return ((Order)this.InnerList[Index]);
            }

            set
            {
                this.InnerList[Index] = value;
            }
        }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Finds an orde by Order number
        /// </summary>
        /// <param name="OrderID">int OrderID of order to find</param>
        /// <returns>Order object if found otherwise null</returns>
        public Order Find(int OrderID)
        {
            Order Result = null;

            foreach (Order order in this)
            {
                if (order.ID == OrderID)
                {
                    Result = order;
                    break;
                }
            }

            return (Result);
        }

        /// <summary>
        /// Adds an item to the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Add(Order value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(Order value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, Order value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(Order value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Order value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Orders.Order";
        private const string OBJECT_TYPE_ERROR = "Must be of type Order";


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