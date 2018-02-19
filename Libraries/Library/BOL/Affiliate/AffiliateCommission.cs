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
 *  File: AffiliateCommission.cs
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

using Library.BOL.Invoices;
using Library.BOL.Users;

namespace Library.BOL.Affiliate
{
    [Serializable]
    public sealed class AffiliateCommission : BaseCollection
    {
        #region Static Methods

        //public static AffiliateCommission GetPool(Invoice invoice)
        //{
        //    return (DAL.FirebirdDB.StaffCommissionPoolGet(invoice));
        //}

        /// <summary>
        /// Retrieves commission data for a commission pool
        /// </summary>
        /// <param name="pool"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="isPaid"></param>
        /// <param name="isNotPaid"></param>
        /// <returns></returns>
        public static AffiliateCommission Get(User user, DateTime from, DateTime to, bool isPaid, bool isNotPaid)
        {
            return (DAL.FirebirdDB.AffiliatedCommissionGet(user, from, to, isPaid, isNotPaid));
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
        //public static AffiliateCommission Get(StaffMember staff, DateTime from, DateTime to, bool isPaid, bool isNotPaid)
        //{
        //    return (DAL.FirebirdDB.StaffCommissionClientGet(staff, from, to, isPaid, isNotPaid));
        //}

        /// <summary>
        /// Rebuilds commission for invoices within the selected date
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="replace"></param>
        //public static void RebuildPoolData(DateTime dateFrom, DateTime dateTo, bool replace)
        //{
        //    DAL.FirebirdDB.StaffCommissionRebuildPoolData(dateFrom, dateTo, replace);
        //}


        //public static void RebuildClientData(DateTime dateFrom, DateTime dateTo, bool replace)
        //{
        //    DAL.FirebirdDB.StaffCommissionRebuildClientData(dateFrom, dateTo, replace);
        //}

        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        /// <summary>
        /// Indexer Property
        /// </summary>
        /// <param name="Index">Index of object to return</param>
        /// <returns>Video object</returns>
        public AffiliateCommissionItem this[int Index]
        {
            get
            {
                return ((AffiliateCommissionItem)this.InnerList[Index]);
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
        public int Add(AffiliateCommissionItem value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(AffiliateCommissionItem value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, AffiliateCommissionItem value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(AffiliateCommissionItem value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(AffiliateCommissionItem value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Affiliate.AffiliateCommissionItem";
        private const string OBJECT_TYPE_ERROR = "Must be of type AffiliateCommissionItem";


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
