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
 *  File: StaffMembers.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections;
using System.Globalization;
using System.Text;

namespace Library.BOL.Staff
{
    [Serializable]
    public sealed class StaffMembers : BaseCollection
	{
		#region Static Methods

		/// <summary>
		/// Inserts an instance of StaffMember into the database
		/// </summary>
		/// <returns>StaffMember instance</returns>
		public static StaffMember InsertUpdate(StaffMember item)
		{
            return (DAL.FirebirdDB.StaffMemberInsertUpdate(item));
		}

		/// <summary>
		/// Returns all records from table STAFF_MEMBERS
		/// </summary>
		/// <returns>StaffMembers collection of StaffMember items</returns>
		public static StaffMembers All()
		{
            return (DAL.FirebirdDB.StaffMemberSelectAll());
		}


		/// <summary>
		/// Returns a specific record from table STAFF_MEMBERS
		/// </summary>
        /// <param name="staffMember"></param>
		/// <returns>StaffMember item if found, otherwise null</returns>
		public static StaffMember Get(Users.User staffMember)
		{
            return (DAL.FirebirdDB.StaffMemberSelect(staffMember));
		}

		/// <summary>
		/// Returns the total number of records for table STAFF_MEMBERS
		/// </summary>
		/// <returns>int, number of records within table</returns>
		public static int CountAll()
		{
            return (DAL.FirebirdDB.StaffMemberCount());
		}

		#endregion Static Methods

		#region Generic CollectionBase Code

		#region Properties

		/// <summary>
		/// Indexer Property
		/// </summary>
		/// <param name="Index">Index of object to return</param>
		/// <returns>StaffMember object</returns>
		public StaffMember this[int Index]
		{
			get
			{
                return ((StaffMember)this.InnerList[Index]);
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
		public int Add(StaffMember value)
		{
			return (List.Add(value));
		}

		/// <summary>
		/// Returns the index of an item within the collection
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public int IndexOf(StaffMember value)
		{
			return (List.IndexOf(value));
		}

		/// <summary>
		/// Inserts an item into the collection
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		public void Insert(int index, StaffMember value)
		{
			List.Insert(index, value);
		}


		/// <summary>
		/// Removes an item from the collection
		/// </summary>
		/// <param name="value"></param>
		public void Remove(StaffMember value)
		{
			List.Remove(value);
		}


		/// <summary>
		/// Indicates the existence of an item within the collection
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Contains(StaffMember value)
		{
			// If value is not of type OBJECT_TYPE, this will return false.
			return (List.Contains(value));
		}

		#endregion Public Methods

		#region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Staff.StaffMember";
		private const string OBJECT_TYPE_ERROR = "Must be of type StaffMember";


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