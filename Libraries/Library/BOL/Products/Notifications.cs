using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.Products
{
    [Serializable]
    public sealed class Notifications : BaseCollection
    {
        #region Static Methods

        /// <summary>
        /// Adds a new notification
        /// </summary>
        /// <param name="item">Product Cost Item which is out of stock</param>
        /// <param name="email">Email of user who wants notifications</param>
        public static void Add(ProductCost item, string email)
        {
            DAL.FirebirdDB.ProductNotificationAdd(item, email);
        }

        /// <summary>
        /// Removes a notification for a user
        /// </summary>
        /// <param name="item">Product Cost Item which is out of stock</param>
        /// <param name="email">Email of user who wants notifications</param>
        public static void Remove(ProductCost item, string email)
        {
            DAL.FirebirdDB.ProductNotificationRemove(item, email);
        }

        /// <summary>
        /// Determines whether a notification exists
        /// </summary>
        /// <param name="item">Product Cost Item which is out of stock</param>
        /// <param name="email">Email of user who wants notifications</param>
        /// <returns>true if the notification exists, otherwise false</returns>
        public static bool Exists(ProductCost item, string email)
        {
            return (DAL.FirebirdDB.ProductNotificationExists(item, email));
        }

        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        public Notification this[int Index]
        {
            get
            {
                return ((Notification)this.InnerList[Index]);
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
        public int Add(Notification value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(Notification value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, Notification value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(Notification value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Notification value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Products.Notification";
        private const string OBJECT_TYPE_ERROR = "Must be of type Notification";


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
