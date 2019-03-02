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
 *  File: AppointmentTreatments.cs
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
using System.Text;
using SharedBase.BOL.Therapists;
using SharedBase.BOL.Users;

namespace SharedBase.BOL.Appointments
{
    [Serializable]
    public sealed class AppointmentTreatments : BaseCollection
    {
        #region Static Methods

        /// <summary>
        /// Returns all treatments available to a therapist
        /// </summary>
        /// <param name="therapist">Therapist </param>
        /// <returns></returns>
        public static AppointmentTreatments Get(Therapist therapist)
        {
            return (DAL.FirebirdDB.AppointmentTreatmentsGet(therapist, true));
        }

        /// <summary>
        /// Returns all treatments associated with a waiting list
        /// </summary>
        /// <param name="waitingList">Waiting list being sought</param>
        /// <returns>AppointmentTreatments collection</returns>
        public static AppointmentTreatments Get(WaitingList waitingList)
        {
            return (DAL.FirebirdDB.AppointmentTreatmentsGet(waitingList));
        }

        /// <summary>
        /// Returns all treatments that a user has previously had
        /// </summary>
        /// <param name="user">User object to retrieve appointments</param>
        /// <param name="LastUserInfo">If true retrieves information on the last therapist to complete treatment</param>
        /// <returns>AppointmentTreatments collection</returns>
        public static AppointmentTreatments Get(User user, bool LastUserInfo = false)
        {
            return (DAL.FirebirdDB.AppointmentTreatmentsGet(user, LastUserInfo));
        }

        /// <summary>
        /// Returns an individual Treatment
        /// </summary>
        /// <param name="TreatmentID">Unique ID of Treatment</param>
        /// <returns>Treatment</returns>
        public static AppointmentTreatment Get(int TreatmentID)
        {
            return (DAL.FirebirdDB.AppointmentTreatmentGet(TreatmentID));
        }

        /// <summary>
        /// Returns all treatments
        /// </summary>
        /// <returns></returns>
        public static AppointmentTreatments Get()
        {
            return (DAL.FirebirdDB.AppointmentTreatmentsGet());
        }

        /// <summary>
        /// Creates a new Appointment Treatment
        /// </summary>
        /// <param name="newTreatment"></param>
        public static void Create(AppointmentTreatment newTreatment)
        {
            DAL.FirebirdDB.AppointmentTreatmentCreate(newTreatment);
        }

        #endregion Static Methods

        #region Public Methods

        public AppointmentTreatment Find(string Name)
        {
            AppointmentTreatment Result = null;

            foreach (AppointmentTreatment treat in this)
            {
                if (treat.Name.ToLower() == Name.ToLower())
                {
                    Result = treat;
                    break;
                }
            }

            return (Result);
        }

        public AppointmentTreatment Find(AppointmentTreatment Treatment)
        {
            AppointmentTreatment Result = null;

            foreach (AppointmentTreatment treat in this)
            {
                if (treat.ID == Treatment.ID)
                {
                    Result = treat;
                    break;
                }
            }

            return (Result);
        }

        public bool Available(AppointmentTreatment Treatment)
        {
            bool Result = false;

            foreach (AppointmentTreatment treat in this)
            {
                if (treat.ID == Treatment.ID)
                {
                    Result = true;
                    break;
                }
            }

            return (Result);
        }

        public void Save()
        {
            DAL.FirebirdDB.AppointmentTreatmentsSave(this);
        }

        /// <summary>
        /// total time needed for all treatments in the list
        /// </summary>
        /// <returns></returns>
        public int TotalTreatmentTime()
        {
            int Result = 0;

            foreach (AppointmentTreatment treat in this)
            {
                Result += treat.Duration;
            }

            return (Result);
        }

        #endregion Public Methods

        #region Generic CollectionBase Code

        #region Properties

        public AppointmentTreatment this[int Index]
        {
            get
            {
                return ((AppointmentTreatment)this.InnerList[Index]);
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
        public int Add(AppointmentTreatment value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(AppointmentTreatment value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, AppointmentTreatment value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(AppointmentTreatment value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(AppointmentTreatment value)
        {
            foreach (AppointmentTreatment item in this)
            {
                if (item.ID == value.ID)
                    return (true);
            }

            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "SharedBase.BOL.Appointments.AppointmentTreatment";
        private const string OBJECT_TYPE_ERROR = "Must be of type AppointmentTreatment";


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
