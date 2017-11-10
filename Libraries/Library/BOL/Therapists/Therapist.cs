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
 *  File: Therapist.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;

#if !ANDROID
using System.Web;
#endif

using Library.BOL.Users;
using Library.BOL.Appointments;
using Library.Utils;
using Library.BOL.Accounts;

namespace Library.BOL.Therapists
{
    [Serializable]
    public sealed class Therapist : BaseObject
    {
        #region Private consts

        private Int64 _EmployeeID;
        private string _EmployeeName;
        private bool _AllowMonday;
        private bool _AllowTuesday;
        private bool _AllowWednesday;
        private bool _AllowThursday;
        private bool _AllowFriday;
        private bool _AllowSaturday;
        private bool _AllowSunday;
        private double _StartTime;
        private double _EndTime;
        private double _LunchStart;
        private int _LunchDuration;
        private bool _AllowBookCurrentDay;
        private bool _PublicDiary;
        private AppointmentTreatments _Treatments;
        private WorkingDays _workingDays;
        private AppointmentGroup _group;

        #endregion Private consts

        #region Constructor / Destructor

        public Therapist (Int64 EmployeeID, string EmployeeName)
        {
            _EmployeeID = EmployeeID;
            _EmployeeName = EmployeeName;
        }

        public Therapist(Int64 EmployeeID, string EmployeeName, bool AllowMonday, bool AllowTuesday, 
            bool AllowWednesday, bool AllowThursday, bool AllowFriday, bool AllowSaturday, 
            bool AllowSunday, double StartTime, double EndTime, double LunchStart, 
            int LunchDuration, bool AllowBookCurrentDay, bool PublicDiary, AppointmentGroup group)
        {
            _EmployeeID = EmployeeID;
            _EmployeeName = EmployeeName;
            _AllowMonday = AllowMonday;
            _AllowTuesday = AllowTuesday;
            _AllowWednesday = AllowWednesday;
            _AllowThursday = AllowThursday;
            _AllowFriday = AllowFriday;
            _AllowSaturday = AllowSaturday;
            _AllowSunday = AllowSunday;
            _StartTime = StartTime;
            _EndTime = EndTime;
            _LunchStart = LunchStart;
            _LunchDuration = LunchDuration;
            _AllowBookCurrentDay = AllowBookCurrentDay;
            _PublicDiary = PublicDiary;
            _group = group;
        }

        #endregion Constructor / Destructor

        #region Public Methods

        /// <summary>
        /// Refreshes working hours
        /// </summary>
        public void RefreshWorkingHours()
        {
            _workingDays = null;
        }

        /// <summary>
        /// Returns the total duration allowed for the employee
        /// </summary>
        /// <returns></returns>
        public int EmployeeDuration()
        {
            int Result = (int)Math.Round(((_EndTime - _StartTime) * 4) * 15, 0);

            return (Result);
        }

        public override void Save()
        {
            DAL.FirebirdDB.TherapistSave(this);
            CacheClear();
        }

        public void ResetWorkingDays()
        {
            _workingDays = null;
        }

        /// <summary>
        /// Resets cached Data
        /// </summary>
        public void ResetCachedData()
        {
            _workingDays = null;
            _Treatments = null;
        }

        /// <summary>
        /// Indicates wether the employee has appointments on a given date
        /// </summary>
        /// <param name="date">Date to check</param>
        /// <returns>true if employee has appointments, otherwise false</returns>
        public bool HasAppointments(DateTime date, bool treatmentsOnly = false)
        {
            Appointments.Appointments _appts = Appointments.Appointments.Get(date, this, false);
            int count = 0;

            foreach (Appointment appt in _appts)
            {
                switch (appt.AppointmentType)
                {
                    case 0: // treatment
                        count++;
                        break;
                    case 1: // lunch
                        break;
                    default:
                        if (!treatmentsOnly)
                            count++;
                        break;
                }
            }

            return (count > 0);
        }

        /// <summary>
        /// Checks to ensure the employee can have appointments created on a specified date
        /// </summary>
        /// <param name="Date">Date appointment required</param>
        /// <param name="Time">Time of appointment</param>
        /// <returns>bool, true if appointment allowed, otherwise false.</returns>
        public bool AllowCreateAppointment(DateTime Date, double Time = 0.0, bool ignorePast = false)
        {
            bool Result = false;

            // past date not allowed
            if (!ignorePast && (Date.Date < DateTime.Now.Date))
                return (Result);

            if ((Time == 0.0) || (Time > 0.0 && (Time >= StartTime && Time < EndTime)))
            {
                //check user options
                switch (Date.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        Result = _AllowMonday;
                        break;
                    case DayOfWeek.Tuesday:
                        Result = _AllowTuesday;
                        break;
                    case DayOfWeek.Wednesday:
                        Result = _AllowWednesday;
                        break;
                    case DayOfWeek.Thursday:
                        Result = _AllowThursday;
                        break;
                    case DayOfWeek.Friday:
                        Result = _AllowFriday;
                        break;
                    case DayOfWeek.Saturday:
                        Result = _AllowSaturday;
                        break;
                    case DayOfWeek.Sunday:
                        Result = _AllowSunday;
                        break;
                }

                // if current date is today check if allowed
                if (Date.Date == DateTime.Now)
                    Result = _AllowBookCurrentDay;
            }

            bool AllowTreatments;

            //is the working day overridden?
            if (!Result)
                Result = WorkingDays.WorkingOverride(Date, out AllowTreatments);

            return (Result);
        }

        /// <summary>
        /// Determines if its a working day for a therapist
        /// </summary>
        /// <param name="workingDay">DateTime to check</param>
        /// <param name="start">if a working day then the starttime</param>
        /// <param name="finish">if a working day then the end time</param>
        /// <param name="duration">Duration of the working day in minutes</param>
        /// <returns>true if a working day, otherwise false</returns>
        public bool WorkingDay(DateTime workingDay, out double start, out double finish, out int duration)
        {
            bool Result = false;
            bool treatments;
            DateTime Start;
            DateTime Finish;
            start = 0.0;
            finish = 0.0;

            if (WorkingOverride(workingDay, out Start, out Finish, out treatments))
            {
                start = Shared.Utilities.DateToDouble(Start);
                finish = Shared.Utilities.DateToDouble(Finish);
                Result = true;
            }
            else
            {
                if (AllowCreateAppointment(workingDay))
                {
                    start = StartTime;
                    finish = EndTime;
                    Result = true;
                }
            }


            //duration
            double s = start;
            duration = 0;

            while (s < finish)
            {
                s += 0.25;
                duration += 15;
            }

            return (Result);
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
            if (_workingDays == null)
                _workingDays = DAL.FirebirdDB.TherapistsWorkingDaysGet(this);

            return (_workingDays.WorkingOverride(workingDay, out start, out finish, out AllowTreatments));
        }

        /// <summary>
        /// Determines if therapist can do treatments on working day
        /// </summary>
        /// <param name="workingDay">The working day</param>
        /// <returns>true if allowed to do treatments on working day, otherwise false</returns>
        public bool AllowTreatments(DateTime workingDay)
        {
            bool Result = true;

            WorkingDay wDay = WorkingDays.Get(workingDay);

            if (wDay != null && !wDay.AllowTreatments)
                Result = false;
            
            return (Result);
        }

        /// <summary>
        /// Determines wether therapist can work on the day
        /// </summary>
        /// <param name="startDateTime">Start date time to be checked</param>
        /// <param name="finishDateTime">Finish date time to be checked</param>
        /// <param name="IncludeTime">Determines wether to check just the date or date/time</param>
        /// <param name="AllowTreatments">Can the therapist do treatments on the day</param>
        /// <returns></returns>
        public bool CanWorkOnDay(DateTime startDateTime, DateTime finishDateTime, bool IncludeTime, out bool AllowTreatments)
        {
            bool Result = false;
            AllowTreatments = true;

            switch (startDateTime.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    Result = _AllowFriday;
                    break;
                case DayOfWeek.Saturday:
                    Result = _AllowSaturday;
                    break;
                case DayOfWeek.Sunday:
                    Result = _AllowSunday;
                    break;
                case DayOfWeek.Monday:
                    Result = _AllowMonday;
                    break;
                case DayOfWeek.Tuesday:
                    Result = _AllowTuesday;
                    break;
                case DayOfWeek.Wednesday:
                    Result = _AllowWednesday;
                    break;
                case DayOfWeek.Thursday:
                    Result = _AllowThursday;
                    break;
            }

            if (Result && IncludeTime)
            {
                DateTime Start = Shared.Utilities.DoubleToDate(startDateTime, _StartTime);
                DateTime Finish = Shared.Utilities.DoubleToDate(finishDateTime, _EndTime);

                Result = (startDateTime >= Start && finishDateTime <= Finish);
            }

            if (!Result)
            {
                //check working hours override
                DateTime start;
                DateTime finish;

                Result = WorkingOverride(startDateTime.Date, out start, out finish, out AllowTreatments);

                if (Result)
                {
                    Result = (startDateTime >= start && finishDateTime <= finish);
                }

            }

            return (Result);
        }

        /// <summary>
        /// Compares therapists treatments with list of treatments
        /// </summary>
        /// <param name="treatments">List of treatments to compare to</param>
        /// <returns>Returns true if therapist has all Treatments list in treatments, otherwise false</returns>
        public bool CompareTreatments(AppointmentTreatments treatments)
        {
            bool Result = false;

            int found = 0;

            foreach (AppointmentTreatment treat in treatments)
            {
                foreach (AppointmentTreatment currTreat in Treatments)
                {
                    if (treat.ID == currTreat.ID)
                    {
                        found++;
                        break;
                    }
                }
            }

            Result = found == treatments.Count;
            return (Result);
        }

        /// <summary>
        /// Retreives the next free time slot in the diary (if it exists)
        /// </summary>
        /// <param name="start">time to start checking</param>
        /// <returns></returns>
        public bool AppointmentNextTimeSlot(DateTime date, ref double start)
        {
            double starttime;
            double finishtime;
            int duration;

            WorkingDay(date, out starttime, out finishtime, out duration);

            if (date.Date == DateTime.Now.Date && Convert.ToInt32(start) < DateTime.Now.Hour)
            {
                start = Shared.Utilities.TimeToDouble(String.Format("{0}:00", DateTime.Now.Hour + 1));
            }

            if (starttime == finishtime)
            {
                return (false);
            }
            else
            {
                Appointments.Appointments _appts = Appointments.Appointments.Get(date, _EmployeeID);

                while (_appts.AppointmentCountByTime(start) > 0 && start <= finishtime)
                {
                    start += 0.25;
                }

                return (start < finishtime);
            }
        }

        public bool AppointmentNextTimeSlot(DateTime date, int duration, ref double start)
        {
            bool Result = false;

            bool canTreat = false;

            if (date.Date == DateTime.Now.Date && Convert.ToInt32(start) < DateTime.Now.Hour)
            {
                start = Shared.Utilities.TimeToDouble(String.Format("{0}:00", DateTime.Now.Hour + 1));
            }

            if (CanWorkOnDay(date, date, false, out canTreat))
            {
                if (canTreat)
                {
                    //therapist can work on the specified day and do treatments, need to find next time slot

                    //get all appointments for this therapist/date
                    Appointments.Appointments appts = Appointments.Appointments.Get(date, this, true);

                    // what is the end working time for this date, for this therapist
                    double tStartTime;
                    double tEndTime;
                    int tDuration;
                    double tempStart = start;

                    if (!WorkingDay(date, out tStartTime, out tEndTime, out tDuration))
                        return (false);
                    
                    //get first working slot
                    while (tempStart < tEndTime)
                    {
                        if (AppointmentNextTimeSlot(date, ref tempStart))
                        {
                            DateTime startTime = Shared.Utilities.DoubleToDate(date, tempStart);
                            DateTime finishTime = Shared.Utilities.DoubleToDate(date, tempStart, duration);

                            if (appts.AllowCreateAppointment(date, tempStart, duration))
                            {
                                start = tempStart;
                                return (true);
                            }
                        }

                        tempStart += 0.25;
                    }
                }
            }


            return (Result);
        }

        /// <summary>
        /// Returns total sales for a date period for therapist
        /// </summary>
        /// <param name="From">Date From</param>
        /// <param name="To">Date To</param>
        /// <param name="Type">Type of sales</param>
        /// <returns>Double - total value of sales for the day</returns>
        public decimal TotalSales(DateTime From, DateTime To, ProductCostItemType Type)
        {
            decimal Result = DAL.FirebirdDB.TherapistSales(this, From, To, Type);

            return (Result);
        }

        public decimal TotalRefunds(DateTime From, DateTime To)
        {
            return (DAL.FirebirdDB.TherapistRefunds(this, From, To));
        }

        /// <summary>
        /// Returns all sales data for a therapist for period
        /// </summary>
        /// <param name="From">Date from</param>
        /// <param name="To">Date to</param>
        /// <returns>TherapistTakings object</returns>
        public TherapistTakings TotalDiscounts(DateTime From, DateTime To)
        {
            return (DAL.FirebirdDB.TherapistTakings(this, From, To));
        }

        /// <summary>
        /// Total product sales for a therapist by date range
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public Takings TotalProducts(DateTime from, DateTime to)
        {
            return (DAL.FirebirdDB.TherapistTakingsProducts(this, from, to));
        }

        /// <summary>
        /// Returns all sales information for a therapist for a specified date period
        /// </summary>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <returns></returns>
        public Takings Sales(DateTime From, DateTime To)
        {
            return (DAL.FirebirdDB.TherapistSales(this, From, To));
        }

        public decimal TotalSales(DateTime From, DateTime To, PaymentStatus PaymentStatus)
        {
            return (DAL.FirebirdDB.TherapistSales(this, From, To, PaymentStatus));
        }

        /// <summary>
        /// Returns total appointment for therapist
        /// </summary>
        /// <param name="From">Date From</param>
        /// <param name="To">Date To</param>
        /// <param name="Status">Appointment Status</param>
        /// <returns>total number of appointments for time period</returns>
        public int TotalAppoinments(DateTime From, DateTime To, Enums.AppointmentStatus Status)
        {
            int Result = DAL.FirebirdDB.TherapistsAppointments(this, From, To, Status);

            return (Result);
        }

        #endregion Public Methods

        #region Properties

        /// <summary>
        /// Determines which location a therapist belongs to
        /// </summary>
        public AppointmentGroup Group
        {
            get
            {
                return (_group);
            }

            set
            {
                _group = value;
            }
        }

        /// <summary>
        /// Indicates wether the diary is public and viewable on the website
        /// </summary>
        public bool PublicDiary
        {
            get
            {
                return (_PublicDiary);
            }

            set
            {
                _PublicDiary = value;
            }
        }

        /// <summary>
        /// Retrieves all treatments available to the therapist
        /// </summary>
        public AppointmentTreatments Treatments
        {
            get
            {
                if (_Treatments == null)
                    _Treatments = DAL.FirebirdDB.AppointmentTreatmentsGet(this, true);

                return (_Treatments);
            }
        }

        /// <summary>
        /// Internal employee ID
        /// </summary>
        public Int64 EmployeeID
        {
            get
            {
                return (_EmployeeID);
            }
        }

        /// <summary>
        /// Name of the employee
        /// </summary>
        public string EmployeeName
        {
            get
            {
                return (_EmployeeName);
            }

            set
            {
                _EmployeeName = value;
            }
        }

        public string EmployeeEmail
        {
            get
            {
                User user = User.UserGet(_EmployeeID);
                return (user.Email);
            }
        }

        public bool AllowMonday
        {
            get
            {
                return (_AllowMonday);
            }

            set
            {
                _AllowMonday = value;
            }
        }

        public bool AllowTuesday
        {
            get
            {
                return (_AllowTuesday);
            }

            set
            {
                _AllowTuesday = value;
            }
        }

        public bool AllowWednesday
        {
            get
            {
                return (_AllowWednesday);
            }

            set
            {
                _AllowWednesday = value;
            }
        }

        public bool AllowThursday
        {
            get
            {
                return (_AllowThursday);
            }

            set
            {
                _AllowThursday = value;
            }
        }

        public bool AllowFriday
        {
            get
            {
                return (_AllowFriday);
            }

            set
            {
                _AllowFriday = value;
            }
        }

        public bool AllowSaturday
        {
            get
            {
                return (_AllowSaturday);
            }

            set
            {
                _AllowSaturday = value;
            }
        }

        public bool AllowSunday
        {
            get
            {
                return (_AllowSunday);
            }

            set
            {
                _AllowSunday = value;
            }
        }

        public double StartTime
        {
            get
            {
                return (_StartTime);
            }

            set
            {
                _StartTime = value;
            }
        }

        /// <summary>
        /// Determines wether the therapist is shown in the diary
        /// </summary>
        public bool ShowInDiary
        {
            get
            {
                bool Result = _AllowWednesday | _AllowTuesday | _AllowThursday | _AllowSunday | _AllowSaturday | _AllowMonday | _AllowFriday;

                if (!Result)
                    Result = WorkingDays.Count > 0;

                return (Result);
            }
        }

        public double EndTime
        {
            get
            {
                return (_EndTime);
            }

            set
            {
                _EndTime = value;
            }
        }

        public double LunchStart
        {
            get
            {
                return (_LunchStart);
            }

            set
            {
                _LunchStart = value;
            }
        }

        public int LunchDuration
        {
            get
            {
                return (_LunchDuration);
            }

            set
            {
                _LunchDuration = value;
            }
        }

        /// <summary>
        /// Allow users to book appointments on the current day
        /// </summary>
        public bool AllowBookCurrentDay
        {
            get
            {
                return (_AllowBookCurrentDay);
            }

            set
            {
                _AllowBookCurrentDay = value;
            }
        }

        /// <summary>
        /// Overridden working days
        /// </summary>
        public WorkingDays WorkingDays
        {
            get
            {
                if (_workingDays == null)
                    _workingDays = DAL.FirebirdDB.TherapistsWorkingDaysGet(this);

                return (_workingDays);
            }
        }

        /// <summary>
        /// Indicates wether the therapist has any treatments assigned.
        /// </summary>
        public bool HasTreatments
        {
            get
            {
                return (Treatments.Count > 0);
            }
        }

        /// <summary>
        /// User defined object
        /// </summary>
        public new object Tag { get; set; }

        #endregion Properties

        #region Static Methods

        /// <summary>
        /// Retrieves the Therapist object based on an ID
        /// </summary>
        /// <param name="TherapistID">Therapist ID to return</param>
        /// <returns>Therapist object if it exists, otherwise null</returns>
        public static Therapist Get(Int64 TherapistID)
        {
            return (DAL.FirebirdDB.TherapistGet(TherapistID));
        }

        /// <summary>
        /// Converts a User to a Therapist
        /// </summary>
        /// <param name="user">User to convert</param>
        /// <returns>Therapist object if it exists, otherwise null</returns>
        public static Therapist Get(User user)
        {
            return (DAL.FirebirdDB.TherapistGet(user.ID));
        }

        /// <summary>
        /// Deletes a Therapist
        /// </summary>
        /// <param name="therapist">Therapist to be deleted</param>
        public static void Delete(Therapist therapist)
        {
            DAL.FirebirdDB.TherapistDelete(therapist);
        }

        /// <summary>
        /// Creates a therapist based on a current User
        /// </summary>
        /// <param name="Employee">User to create a therapist from</param>
        /// <returns>Therapist object for Employee</returns>
        public static Therapist Create(User Employee)
        {
            return (DAL.FirebirdDB.TherapistCreate(Employee));
        }

        #endregion Static Methods

        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("Therapist: {0}; Name: {1}", _EmployeeID, _EmployeeName));
        }

        #endregion Overridden Methods

    }
}