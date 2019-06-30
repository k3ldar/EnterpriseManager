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
 *  File: WorkingDays.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

namespace SharedBase.BOL.Therapists
{
    [Serializable]
    public sealed class WorkingDays : BaseCollection
    {
        #region Constants

        private const int MAXIMUM_ITERATIONS = 250;

        #endregion Constants

        #region Public Methods

        /// <summary>
        /// Creates a new workingDay object
        /// </summary>
        /// <param name="therapist">Therapist who owns the WorkingDay</param>
        /// <returns>WorkingDay</returns>
        public WorkingDay Create(Therapist therapist)
        {
            WorkingDay Result = null;

            Result = DAL.FirebirdDB.TherapistWorkingDaysCreate(therapist);
            Insert(0, Result);
            return Result;
        }

        /// <summary>
        /// Determines wether the therapist has overriden working day
        /// </summary>
        /// <param name="workingDay">Date of working day.</param>
        /// <param name="AllowTreatments">Determines if therapist can do treatments on specific day</param>
        /// <returns>true if working day is overriden, otherwise false</returns>
        public bool WorkingOverride(DateTime workingDay, out bool AllowTreatments)
        {
            DateTime start;
            DateTime finish;

            return WorkingOverride(workingDay, out start, out finish, out AllowTreatments);
        }

        /// <summary>
        /// Determines wether the therapist has overriden working day
        /// </summary>
        /// <param name="workingDay">The working day</param>
        /// <param name="start">start date/time</param>
        /// <param name="finish">finish date/time</param>
        /// <returns>true if working day is overriden, otherwise false</returns>
        public bool WorkingOverride(DateTime workingDay, out DateTime start, out DateTime finish, out bool AllowTreatments)
        {
            start = DateTime.Now;
            finish = DateTime.Now;
            AllowTreatments = true;

            for (int i = this.Count -1; i >= 0; i--)
            {
                WorkingDay day = this[i];

                int iteration = 0;
                DateTime date = day.Date;

                do
                {
                    switch (day.RepeatOption)
                    {
                        case Enums.AppointmentRepeatType.NoRepeat:
                            iteration = 1000000;
                            break;
                        case Enums.AppointmentRepeatType.Week:
                            date = date.AddDays(7 * day.RepeatDuration);
                            break;
                        case Enums.AppointmentRepeatType.Month:
                            date = date.AddMonths(day.RepeatDuration);
                            break;
                        case Enums.AppointmentRepeatType.Year:
                            date = date.AddYears(day.RepeatDuration);
                            break;
                    }

                    if (workingDay.Date == day.Date || date == workingDay.Date)
                    {
                        start = Shared.Utilities.DoubleToDate(workingDay, day.StartTime);
                        finish = Shared.Utilities.DoubleToDate(workingDay, day.FinishTime);
                        AllowTreatments = day.AllowTreatments;
                        return true;
                    }

                    ++iteration;

                } while (iteration < MAXIMUM_ITERATIONS && date <= workingDay);
            }


            return false;
        }

        public WorkingDay Get(DateTime workingDay)
        {
            foreach (WorkingDay day in this)
            {
                int iteration = 0;
                DateTime date = day.Date;

                do
                {
                    switch (day.RepeatOption)
                    {
                        case Enums.AppointmentRepeatType.NoRepeat:
                            iteration = 1000000;
                            break;
                        case Enums.AppointmentRepeatType.Week:
                            date = date.AddDays(7 * day.RepeatDuration);
                            break;
                        case Enums.AppointmentRepeatType.Month:
                            date = date.AddMonths(day.RepeatDuration);
                            break;
                        case Enums.AppointmentRepeatType.Year:
                            date = date.AddYears(day.RepeatDuration);
                            break;
                    }

                    if (workingDay.Date == day.Date || date.Date == workingDay.Date)
                    {
                        return day;
                    }

                    ++iteration;

                } while (iteration < MAXIMUM_ITERATIONS && date <= workingDay);
            }

            return null;
        }

        /// <summary>
        /// Determines wether the therapist can work at the date time specified
        /// </summary>
        /// <param name="startDateTime">DateTime to see if the therapist can work</param>
        /// <returns>Returns True if the therapist can work, otherwise false</returns>
        public bool CanWork(DateTime startDateTime)
        {
            bool Result = false;

            foreach (WorkingDay day in this)
            {
                int iteration = 0;
                DateTime date = day.Date;

                do
                {
                    switch (day.RepeatOption)
                    {
                        case Enums.AppointmentRepeatType.NoRepeat:
                            iteration = 1000000;
                            break;
                        case Enums.AppointmentRepeatType.Week:
                            date = date.AddDays(7 * day.RepeatDuration);
                            break;
                        case Enums.AppointmentRepeatType.Month:
                            date = date.AddMonths(day.RepeatDuration);
                            break;
                        case Enums.AppointmentRepeatType.Year:
                            date = date.AddYears(day.RepeatDuration);
                            break;
                    }

                    if (startDateTime.Date == day.Date || date == startDateTime.Date)
                    {
                        return true;
                    }

                    ++iteration;

                } while (iteration < MAXIMUM_ITERATIONS && date <= startDateTime);
            }
            
            return Result;
        }

        #endregion Public Methods

        #region Generic CollectionBase Code

        #region Properties

        public WorkingDay this[int Index]
        {
            get
            {
                return (WorkingDay)this.InnerList[Index];
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
        public int Add(WorkingDay value)
        {
            value.Owner = this;
            return List.Add(value);
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(WorkingDay value)
        {
            return List.IndexOf(value);
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, WorkingDay value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(WorkingDay value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(WorkingDay value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return List.Contains(value);
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "SharedBase.BOL.Therapists.WorkingDay";
        private const string OBJECT_TYPE_ERROR = "Must be of type WorkingDay";


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
