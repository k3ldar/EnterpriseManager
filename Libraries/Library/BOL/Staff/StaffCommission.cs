using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.Invoices;

namespace Library.BOL.Staff
{
    [Serializable]
    public sealed class StaffCommission : BaseCollection
    {
        #region Static Methods

        public static StaffCommission GetPool(Invoice invoice)
        {
            return (DAL.FirebirdDB.StaffCommissionPoolGet(invoice));
        }

        /// <summary>
        /// Retrieves commission data for a commission pool
        /// </summary>
        /// <param name="pool"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="isPaid"></param>
        /// <param name="isNotPaid"></param>
        /// <returns></returns>
        public static StaffCommission Get(CommissionPool pool, DateTime from, DateTime to, bool isPaid, bool isNotPaid)
        {
            return (DAL.FirebirdDB.StaffCommissionPoolGet(pool, from, to, isPaid, isNotPaid));
        }

        /// <summary>
        /// Retrieves commission data for a staff member
        /// </summary>
        /// <param name="pool"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="isPaid"></param>
        /// <param name="isNotPaid"></param>
        /// <returns></returns>
        public static StaffCommission Get(StaffMember staff, DateTime from, DateTime to, bool isPaid, bool isNotPaid)
        {
            return (DAL.FirebirdDB.StaffCommissionClientGet(staff, from, to, isPaid, isNotPaid));
        }

        /// <summary>
        /// Rebuilds commission for invoices within the selected date
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="replace"></param>
        public static void RebuildPoolData(DateTime dateFrom, DateTime dateTo, bool replace)
        {
            DAL.FirebirdDB.StaffCommissionRebuildPoolData(dateFrom, dateTo, replace);
        }


        public static void RebuildClientData(DateTime dateFrom, DateTime dateTo, bool replace)
        {
            DAL.FirebirdDB.StaffCommissionRebuildClientData(dateFrom, dateTo, replace);
        }

        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        /// <summary>
        /// Indexer Property
        /// </summary>
        /// <param name="Index">Index of object to return</param>
        /// <returns>Video object</returns>
        public StaffCommissionItem this[int Index]
        {
            get
            {
                return ((StaffCommissionItem)this.InnerList[Index]);
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
        public int Add(StaffCommissionItem value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(StaffCommissionItem value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, StaffCommissionItem value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(StaffCommissionItem value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(StaffCommissionItem value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Staff.StaffCommissionItem";
        private const string OBJECT_TYPE_ERROR = "Must be of type StaffCommissionItem";


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
