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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: WaitingLists.cs
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


namespace Library.BOL.Appointments
{
    [Serializable]
    public sealed class WaitingLists : BaseCollection
	{
		#region Static Methods


		/// <summary>
		/// Inserts an instance of WaitingList into the database
		/// </summary>
		/// <returns>WaitingList instance</returns>
		public static WaitingList InsertUpdate(WaitingList item)
		{
            return (DAL.FirebirdDB.WaitingListInsertUpdate(item));
		}

		/// <summary>
		/// Returns all records from table WS_APPOINTMENT_WAIT_LIST_LONG
		/// </summary>
		/// <returns>WaitingLists collection of WaitingList items</returns>
		public static WaitingLists All()
		{
            return (DAL.FirebirdDB.WaitingListSelectAll());
		}

		/// <summary>
		/// Returns a page of records from table WS_APPOINTMENT_WAIT_LIST_LONG
		/// </summary>
		/// <param name="page"></param>
		/// <param name="pageSize"></param>
		/// <returns>WaitingLists collection of WaitingList items</returns>
		public static WaitingLists Page(int page, int pageSize)
		{
            return (DAL.FirebirdDB.WaitingListPage(page, pageSize));
		}

		/// <summary>
		/// Returns a specific record from table WS_APPOINTMENT_WAIT_LIST_LONG
		/// </summary>
		/// <param name="id"></param>
		/// <returns>WaitingList item if found, otherwise null</returns>
		public static WaitingList Get(int item)
		{
            return (DAL.FirebirdDB.WaitingListSelect(item));
		}

		/// <summary>
		/// Returns the total number of records for table WS_APPOINTMENT_WAIT_LIST_LONG
		/// </summary>
		/// <returns>int, number of records within table</returns>
		public static int CountAll()
		{
            return (DAL.FirebirdDB.WaitingListCount());
		}

		#endregion Static Methods

		#region Generic CollectionBase Code

		#region Properties

		/// <summary>
		/// Indexer Property
		/// </summary>
		/// <param name="Index">Index of object to return</param>
		/// <returns>WaitingList object</returns>
		public WaitingList this[int Index]
		{
			get
			{
				return ((WaitingList)this.InnerList[Index]);
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
		public int Add(WaitingList value)
		{
			return (List.Add(value));
		}

		/// <summary>
		/// Returns the index of an item within the collection
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public int IndexOf(WaitingList value)
		{
			return (List.IndexOf(value));
		}

		/// <summary>
		/// Inserts an item into the collection
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		public void Insert(int index, WaitingList value)
		{
			List.Insert(index, value);
		}


		/// <summary>
		/// Removes an item from the collection
		/// </summary>
		/// <param name="value"></param>
		public void Remove(WaitingList value)
		{
			List.Remove(value);
		}


		/// <summary>
		/// Indicates the existence of an item within the collection
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Contains(WaitingList value)
		{
			// If value is not of type OBJECT_TYPE, this will return false.
			return (List.Contains(value));
		}

		#endregion Public Methods

		#region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Appointments.WaitingList";
		private const string OBJECT_TYPE_ERROR = "Must be of type WaitingList";


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