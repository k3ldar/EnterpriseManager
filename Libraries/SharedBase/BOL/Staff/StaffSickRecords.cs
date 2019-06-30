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
 *  File: StaffSickRecords.cs
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

namespace SharedBase.BOL.Staff
{
    [Serializable]
    public sealed class StaffSickRecords : CollectionBase
	{
		#region Static Methods

		/// <summary>
		/// Creates a new instance of StaffSickRecord
		/// </summary>
		/// <returns>StaffSickRecord instance</returns>
		public static StaffSickRecord Create(Int64 userID, DateTime dateStarted,
            DateTime dateNotified, string notes, string reasonCited, bool certificate, 
            bool preBooked, Int64 userCreating)
		{
            return DAL.FirebirdDB.StaffSickRecordInsert(userID, dateStarted, dateNotified, notes,
                reasonCited, certificate, preBooked, userCreating);
		}

		/// <summary>
		/// Inserts an instance of StaffSickRecord into the database
		/// </summary>
		/// <returns>StaffSickRecord instance</returns>
		public static StaffSickRecord InsertUpdate(StaffSickRecord item)
		{
            return DAL.FirebirdDB.StaffSickRecordInsertUpdate(item);
		}

		/// <summary>
		/// Returns all records from table STAFF_SICK_RECORDS
		/// </summary>
		/// <returns>StaffSickRecords collection of StaffSickRecord items</returns>
		public static StaffSickRecords All(Users.User user)
		{
            return DAL.FirebirdDB.StaffSickRecordSelectAll(user);
		}

		/// <summary>
		/// Returns a page of records from table STAFF_SICK_RECORDS
		/// </summary>
		/// <param name="page"></param>
		/// <param name="pageSize"></param>
		/// <returns>StaffSickRecords collection of StaffSickRecord items</returns>
		public static StaffSickRecords Page(int page, int pageSize)
		{
            return DAL.FirebirdDB.StaffSickRecordPage(page, pageSize);
		}

		/// <summary>
		/// Returns a specific record from table STAFF_SICK_RECORDS
		/// </summary>
		/// <param name="id"></param>
		/// <returns>StaffSickRecord item if found, otherwise null</returns>
		public static StaffSickRecord Get(Int64 item)
		{
            return DAL.FirebirdDB.StaffSickRecordSelect(item);
		}

		/// <summary>
		/// Returns the total number of records for table STAFF_SICK_RECORDS
		/// </summary>
		/// <returns>int, number of records within table</returns>
		public static int CountAll()
		{
            return DAL.FirebirdDB.StaffSickRecordCount();
		}

		#endregion Static Methods

        #region Public Methods

        public void Statistics(ref StaffSicknessStatistics statistics, DateTime leaveYearStarts)
        {
            DateTime leaveYearEnds = leaveYearStarts.AddYears(1).AddMinutes(-1);

            foreach (StaffSickRecord record in this)
            {
                bool currentLeaveYear = Shared.Utilities.DateWithin(leaveYearStarts, 
                    leaveYearEnds, record.DateStarted);

                if (record.Properties.HasFlag(SickOptions.Cancelled))
                {
                    if (currentLeaveYear)
                        statistics.Cancelled++;
                    else
                        statistics.PreviousCancelled++;
                }

                if (!record.Certificate && record.DateFinished > DateTime.MinValue)
                {
                    if (currentLeaveYear)
                        statistics.SelfCertified++;
                    else
                        statistics.PreviousSelfCertified++;
                }

                if (record.DateFinished > DateTime.MinValue)
                {
                    TimeSpan span = record.DateFinished - record.DateStarted;

                    if (currentLeaveYear)
                    {
                        statistics.TotalDays += span.TotalDays;
                        statistics.TotalTimes++;
                    }
                    else
                    {
                        statistics.PreviousTotalDays += span.TotalDays;
                        statistics.PreviousTotalTimes++;
                    }
                }
                else if (record.DateStarted > DateTime.Now)
                {
                    if (record.PreBooked)
                    {
                        if (currentLeaveYear)
                        {
                            statistics.Prebooked++;
                        }
                        else
                        {
                            statistics.PreviousPrebooked++;
                        }
                    }
                }
                else
                {
                    TimeSpan span = DateTime.Now - record.DateStarted;

                    if (currentLeaveYear)
                    {
                        statistics.TotalTimes++;
                        statistics.TotalDays += span.TotalDays;
                    }
                    else
                    {
                        statistics.PreviousTotalTimes++;
                        statistics.PreviousTotalDays += span.TotalDays;

                    }

                    statistics.CurrentlySick = true;
                }
            }

        }

        #endregion Public Methods


        #region Generic CollectionBase Code

        #region Properties

        /// <summary>
		/// Indexer Property
		/// </summary>
		/// <param name="Index">Index of object to return</param>
		/// <returns>StaffSickRecord object</returns>
		public StaffSickRecord this[int Index]
		{
			get
			{
                return (StaffSickRecord)this.InnerList[Index];
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
		public int Add(StaffSickRecord value)
		{
			return List.Add(value);
		}

		/// <summary>
		/// Returns the index of an item within the collection
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public int IndexOf(StaffSickRecord value)
		{
			return List.IndexOf(value);
		}

		/// <summary>
		/// Inserts an item into the collection
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		public void Insert(int index, StaffSickRecord value)
		{
			List.Insert(index, value);
		}


		/// <summary>
		/// Removes an item from the collection
		/// </summary>
		/// <param name="value"></param>
		public void Remove(StaffSickRecord value)
		{
			List.Remove(value);
		}


		/// <summary>
		/// Indicates the existence of an item within the collection
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Contains(StaffSickRecord value)
		{
			// If value is not of type OBJECT_TYPE, this will return false.
			return List.Contains(value);
		}

		#endregion Public Methods

		#region Private Members

        private const string OBJECT_TYPE = "SharedBase.BOL.Staff.StaffSickRecord";
		private const string OBJECT_TYPE_ERROR = "Must be of type StaffSickRecord";


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