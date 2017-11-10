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
 *  File: AppointmentHistory.cs
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
using Library.Utils;

namespace Library.BOL.Users
{
    /// <summary>
    /// Appointment History collection
    /// </summary>
    [Serializable]
    public sealed class AppointmentHistory : BaseCollection
    {
        #region Private Members

        private int _noShow = 0;

        #endregion Private Members

        #region Public Methods

        /// <summary>
        /// Retrievies the users history as a block of text 
        /// </summary>
        /// <returns>string, appointment history</returns>
        public string Text()
        {
            string Result = "";

            Result = String.Format("{0} {1} {2}\r", Shared.Utilities.BufferText("Time Frame", 25), Shared.Utilities.BufferText("Status", 25), "Count");

            foreach (AppointmentHistoryItem item in this)
            {
                Result += String.Format("{0} {1} {2}\r", Shared.Utilities.BufferText(item.TimeFrame, 25), Shared.Utilities.BufferText(item.Status, 25), item.Count);
            }

            return (Result);
        }

        /// <summary>
        /// Determines wether the user has a history of appointments
        /// </summary>
        /// <returns></returns>
        public bool HasHistory()
        {
            return (this.Count > 0);
        }

        /// <summary>
        /// Determines wether the user has "Cancelled" or "No Showed" appointments in the last 6 months
        /// </summary>
        /// <returns></returns>
        public bool CancelledOrNoShow()
        {
            bool Result = false;

            switch (_noShow)
            {
                case 0:
                    foreach (AppointmentHistoryItem item in this)
                    {
                        if (item.TimeFrame == "Last 6 Months")
                            if (item.Status == "Cancelled by User" || item.Status == "No Show")
                            {
                                return (true);
                            }
                    }
                    Result = false;
                    break;
                case 1:
                    Result = true;
                    break;
                case 2:
                    Result = false;
                    break;
            }

            return (Result);
        }

        #endregion Public Methods

        #region Generic CollectionBase Code

        #region Properties

        public AppointmentHistoryItem this[int Index]
        {
            get
            {
                return ((AppointmentHistoryItem)this.InnerList[Index]);
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
        public int Add(AppointmentHistoryItem value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(AppointmentHistoryItem value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, AppointmentHistoryItem value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(AppointmentHistoryItem value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(AppointmentHistoryItem value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Users.AppointmentHistoryItem";
        private const string OBJECT_TYPE_ERROR = "Must be of type AppointmentHistoryItem";


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
