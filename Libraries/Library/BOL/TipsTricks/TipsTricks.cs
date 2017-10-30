using System;
using System.Collections.Generic;
#if !ANDROID
using System.Web;
#endif
using System.Collections;

namespace Library.BOL.TipsTricks
{
    [Serializable]
    public sealed class TipsTricks : BaseCollection
    {
        #region Static Methods

        /// <summary>
        /// Returns the total number of Tips & Tricks
        /// </summary>
        /// <returns>int - Count of Tips & Tricks</returns>
        public static int GetCount()
        {
            return (DAL.FirebirdDB.TipsTricksCount());
        }

        /// <summary>
        /// Returns a collection of Tips & Tricks that are publicly viewable
        /// </summary>
        /// <param name="PageNumber">Current Page Number</param>
        /// <param name="PageSize">Size of page  - number of records to retrieve for the page</param>
        /// <returns>TipsTricks collection</returns>
        public static TipsTricks Get(int PageNumber, int PageSize)
        {
            return (DAL.FirebirdDB.TipsTricksGet(PageNumber, PageSize));
        }

        /// <summary>
        /// Returns an individual tip
        /// </summary>
        /// <param name="TipID">ID of Tip to retrieve</param>
        /// <returns>TipsTrick object if found, otherwise null</returns>
        public static TipsTrick Get(int TipID)
        {
            return (DAL.FirebirdDB.TipsTrickGet(TipID));
        }

        #endregion Static Methods

        #region Public Methods

        /// <summary>
        /// Returns the first tip in the collection
        /// </summary>
        /// <returns>TipsTrick if found, otherwise null</returns>
        public TipsTrick First()
        {
            TipsTrick Result = null;

            foreach (TipsTrick tip in this)
            {
                Result = tip;
                break;
            }

            return (Result);
        }

        #endregion Public Methods

        #region Generic CollectionBase Code

        #region Properties

        public TipsTrick this[int Index]
        {
            get
            {
                return ((TipsTrick)this.InnerList[Index]);
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
        public int Add(TipsTrick value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(TipsTrick value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, TipsTrick value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(TipsTrick value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(TipsTrick value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.TipsTricks.TipsTrick";
        private const string OBJECT_TYPE_ERROR = "Must be of type TipsTrick";


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