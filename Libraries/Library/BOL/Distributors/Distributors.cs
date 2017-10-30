using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;

namespace Library.BOL.Distributors
{
    [Serializable]
    public sealed class Distributors : BaseCollection
    {
        #region Static Methods

        /// <summary>
        /// Returns a page of salons that are available to the public
        /// </summary>
        /// <param name="PageNumber">Current Page number</param>
        /// <param name="PageSize">Size of the Page of Salons</param>
        /// <returns>Salons collection</returns>
        public static Distributors Get(int PageNumber, int PageSize)
        {
            return (DAL.FirebirdDB.DistributorsGet(PageNumber, PageSize));
        }


        /// <summary>
        /// Returns the number of salons
        /// </summary>
        /// <returns>int Number of publicly available salons</returns>
        public static int GetCount()
        {
            return (DAL.FirebirdDB.DistributorsCount());
        }

        /// <summary>
        /// Creates a new distributor
        /// </summary>
        /// <param name="SalonName"></param>
        /// <returns></returns>
        public static Distributor Create(string DistributorName)
        {
            return (DAL.FirebirdDB.AdminDistributorsCreate(DistributorName));
        }

        #endregion Static Methods

        #region Public Methods

        public Distributor Find(Int64 DistributorID)
        {
            Distributor Result = null;

            foreach (Distributor dist in this)
            {
                if (dist.ID == DistributorID)
                {
                    Result = dist;
                    break;
                }
            }


            return (Result);
        }

        #endregion Public Methods

        #region Generic CollectionBase Code

        #region Properties

        /// <summary>
        /// Indexer Property
        /// </summary>
        /// <param name="Index">Index of object to return</param>
        /// <returns>Video object</returns>
        public Distributor this[int Index]
        {
            get
            {
                return ((Distributor)this.InnerList[Index]);
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
        public int Add(Distributor value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(Distributor value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, Distributor value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(Distributor value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Distributor value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Distributors.Distributor";
        private const string OBJECT_TYPE_ERROR = "Must be of type Distributor";


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