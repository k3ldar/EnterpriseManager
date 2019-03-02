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
 *  File: AppointmentOptions.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  07/06/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Web;

using SharedBase.BOL.Therapists;
using SharedBase.BOL.Users;

namespace SharedBase.BOL.Appointments
{
    [Serializable]
    public class AppointmentOptions
    {
        #region Private / Protected Members

        private long _employeeID;
        private string _employeeName;
        private bool _allowMonday;
        private bool _allowTuesday;
        private bool _allowWednesday;
        private bool _allowThursday;
        private bool _allowFriday;
        private bool _allowSaturday;
        private bool _allowSunday;
        private double _startTime;
        private double _endTime;
        private double _lunchStart;
        private int _lunchDuration;
        private bool _allowBookCurrentDay;
        private bool _publicDiary;

        #endregion Private / Protected Members

        #region Public Methods

        public void Save()
        {
        }

        /// <summary>
        /// Checks to ensure the employee can have appointments created on a specified date
        /// </summary>
        /// <param name="Date">Date appointment required</param>
        /// <param name="Time">Time of appointment</param>
        /// <returns>bool, true if appointment allowed, otherwise false.</returns>
        public bool AllowCreateAppointment(DateTime Date, double Time = 0.0)
        {
            bool Result = false;

            // past date not allowed
            if (Date < DateTime.Now)
                return (Result);

            if (Time > 0.0 && (Time >= StartTime && Time < EndTime))
            {
                //check user options
                switch (Date.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        Result = _allowMonday;
                        break;
                    case DayOfWeek.Tuesday:
                        Result = _allowTuesday;
                        break;
                    case DayOfWeek.Wednesday:
                        Result = _allowWednesday;
                        break;
                    case DayOfWeek.Thursday:
                        Result = _allowThursday;
                        break;
                    case DayOfWeek.Friday:
                        Result = _allowFriday;
                        break;
                    case DayOfWeek.Saturday:
                        Result = _allowSaturday;
                        break;
                    case DayOfWeek.Sunday:
                        Result = _allowSunday;
                        break;
                }

                // if current date is today check if allowed
                if (Date.Date == DateTime.Now)
                    Result = _allowBookCurrentDay;
            }
            return (Result);
        }

        #endregion Public Methods

        #region Constructor / Destructor

        public AppointmentOptions(long EmployeeID, string EmployeeName, bool AllowMonday, bool AllowTuesday, bool AllowWednesday, bool AllowThursday,
            bool AllowFriday, bool AllowSaturday, bool AllowSunday, double StartTime, double EndTime, double LunchStart,
            int LunchDuration, bool AllowBookCurrentDay, bool PublicDiary)
        {
            _employeeID = EmployeeID;
            _employeeName = EmployeeName;
            _allowMonday = AllowMonday;
            _allowTuesday = AllowTuesday;
            _allowWednesday = AllowWednesday;
            _allowThursday = AllowThursday;
            _allowFriday = AllowFriday;
            _allowSaturday = AllowSaturday;
            _allowSunday = AllowSunday;
            _startTime = StartTime;
            _endTime = EndTime;
            _lunchStart = LunchStart;
            _lunchDuration = LunchDuration;
            _allowBookCurrentDay = AllowBookCurrentDay;
            _publicDiary = PublicDiary;
        }

        public AppointmentOptions(Therapist therapist)
        {
            _employeeID = therapist.EmployeeID;
            _employeeName = therapist.EmployeeName;
            _allowMonday = therapist. AllowMonday;
            _allowTuesday = therapist.AllowTuesday;
            _allowWednesday = therapist.AllowWednesday;
            _allowThursday = therapist.AllowThursday;
            _allowFriday = therapist.AllowFriday;
            _allowSaturday = therapist.AllowSaturday;
            _allowSunday = therapist.AllowSunday;
            _startTime = therapist.StartTime;
            _endTime = therapist.EndTime;
            _lunchStart = therapist.LunchStart;
            _lunchDuration = therapist.LunchDuration;
            _allowBookCurrentDay = therapist.AllowBookCurrentDay;
            _publicDiary = therapist.PublicDiary;
        }

        #endregion Constructor / Destructor

        #region Properties

        public long EmployeeID
        {
            get
            {
                return (_employeeID);
            }
        }

        public string EmployeeName
        {
            get
            {
                return (_employeeName);
            }
        }

        public bool AllowMonday
        {
            get
            {
                return (_allowMonday);
            }

            set
            {
                _allowMonday = value;
            }
        }

        public bool AllowTuesday
        {
            get
            {
                return (_allowTuesday);
            }

            set
            {
                _allowTuesday = value;
            }
        }

        public bool AllowWednesday
        {
            get
            {
                return (_allowWednesday);
            }

            set
            {
                _allowWednesday = value;
            }
        }

        public bool AllowThursday
        {
            get
            {
                return (_allowThursday);
            }

            set
            {
                _allowThursday = value;
            }
        }

        public bool AllowFriday
        {
            get
            {
                return (_allowFriday);
            }

            set
            {
                _allowFriday = value;
            }
        }

        public bool AllowSaturday
        {
            get
            {
                return (_allowSaturday);
            }

            set
            {
                _allowSaturday = value;
            }
        }

        public bool AllowSunday
        {
            get
            {
                return (_allowSunday);
            }

            set
            {
                _allowSunday = value;
            }
        }

        public double StartTime
        {
            get
            {
                return (_startTime);
            }

            set
            {
                _startTime = value;
            }
        }

        public double EndTime
        {
            get
            {
                return (_endTime);
            }

            set
            {
                _endTime = value;
            }
        }

        public double LunchStart
        {
            get
            {
                return (_lunchStart);
            }

            set
            {
                _lunchStart = value;
            }
        }

        public int LunchDuration
        {
            get
            {
                return (_lunchDuration);
            }

            set
            {
                _lunchDuration = value;
            }
        }

        public bool AllowBookCurrentDay
        {
            get
            {
                return (_allowBookCurrentDay);
            }

            set
            {
                _allowBookCurrentDay = value;
            }
        }


        #endregion Properties

        #region Static Methods

#warning finish
        //public static AppointmentOptions Create(User Employee)
        //{
        //    return (DAL.FirebirdDB.AppointmentOptionsCreate(Employee));
        //}

        //public static void Delete(User Employee)
        //{
        //    DAL.FirebirdDB.AppointmentOptionsDelete(Employee);
        //}

        //public static AppointmentOptions Get(User Employee)
        //{
        //    return (DAL.FirebirdDB.AppointmentOptionsGet(Employee.ID));
        //}

        #endregion Static Methods
    }
}