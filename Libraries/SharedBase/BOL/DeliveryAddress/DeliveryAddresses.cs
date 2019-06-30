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
 *  File: DeliveryAddresses.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections;
using System.Collections.Generic;
#if !ANDROID
using System.Web;
#endif

using SharedBase.BOL.Users;

namespace SharedBase.BOL.DeliveryAddress
{
    [Serializable]
    public sealed class DeliveryAddresses : BaseCollection
    {
        #region Static Methods

        public static DeliveryAddress Get(Int64 DeliveryAddressID)
        {
            return DAL.FirebirdDB.MembersAddressGet(DeliveryAddressID);
        }

        public static DeliveryAddress Get(int DeliveryAddressID)
        {
            return DAL.FirebirdDB.MembersAddressGet(DeliveryAddressID);
        }

        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        /// <summary>
        /// Indexer Property
        /// </summary>
        /// <param name="Index">Index of object to return</param>
        /// <returns>Video object</returns>
        public DeliveryAddress this[int Index]
        {
            get
            {
                return (DeliveryAddress)this.InnerList[Index];
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
        public int Add(DeliveryAddress value)
        {
            return List.Add(value);
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(DeliveryAddress value)
        {
            return List.IndexOf(value);
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, DeliveryAddress value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(DeliveryAddress value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(DeliveryAddress value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return List.Contains(value);
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "SharedBase.BOL.DeliveryAddress.DeliveryAddress";
        private const string OBJECT_TYPE_ERROR = "Must be of type DeliveryAddress";


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

        #region Public Methods

        public DeliveryAddress Find(int ID)
        {
            DeliveryAddress Result = null;

            foreach (DeliveryAddress addr in this)
            {
                if (addr.ID == ID)
                {
                    Result = addr;
                    break;
                }
            }

            return Result;
        }

        public void Delete(DeliveryAddress Address)
        {
            if (Address.InUse)
                throw new Exception("Address can not be deleted as it is in use with an order/invoice");

            DAL.FirebirdDB.MembersAddressDelete(Address);
            Remove(Address);
        }

        /// <summary>
        /// Creates a new delivery address based on users current address
        /// </summary>
        /// <param name="user">User who's address should be used</param>
        public DeliveryAddress Create(User user)
        {
            return Create(user.ID, user.UserName, user.AddressLine1, user.AddressLine2, user.AddressLine3, user.City,
                user.County, user.PostCode, user.Country.ID);
        }

        /// <summary>
        /// Create a new delivery address and adds it to the collection
        /// </summary>
        /// <param name="MemberID"></param>
        /// <param name="Name"></param>
        /// <param name="AddressLine1"></param>
        /// <param name="AddressLine2"></param>
        /// <param name="AddressLine3"></param>
        /// <param name="City"></param>
        /// <param name="County"></param>
        /// <param name="PostCode"></param>
        /// <param name="Country"></param>
        public DeliveryAddress Create(Int64 MemberID, string Name, string AddressLine1,
            string AddressLine2, string AddressLine3, string City, string County,
            string PostCode, int Country)
        {
            DeliveryAddress Result = DAL.FirebirdDB.MembersAddressCreate(MemberID, Name, AddressLine1,
                AddressLine2, AddressLine3, City, County, PostCode, Country);

            Add(Result);

            return Result;
        }

        public DeliveryAddress First()
        {
            DeliveryAddress Result = null;

            foreach (DeliveryAddress addr in this)
            {
                Result = addr;
                break;
            }

            return Result;
        }

        #endregion Public Methods
    }
}