using System;
using System.Collections.Generic;
using System.Collections;

using Library.Utils;
using Library.BOL.Users;
using Library.BOL.Therapists;
using Library.BOLEvents;

namespace Library.BOL.Appointments
{
    [Serializable]
    public sealed class Appointments : BaseCollection
    {
        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Appointments.Appointment";
        private const string OBJECT_TYPE_ERROR = "Must be of type Appointment";
        private Therapist _therapist;


        #endregion Private Members

        #region Constructors / Destructors

        public Appointments(Therapist therapist)
        {
            _therapist = therapist;
        }

        public Appointments(Therapist therapist, Appointment appointment)
            : this(therapist)
        {
            this.Add(appointment);
        }

        public Appointments()
        {
        }

        #endregion Constructors / Destructors

        #region Properties

        public Therapist Options
        {
            get
            {
                return (_therapist);
            }
        }

        #endregion Properties

        #region Private Methods

        #endregion Private Methods

        #region Public Methods

        /// <summary>
        /// Determines wether a user has appointments on a specific day
        /// 
        /// Excludes lunch appointments
        /// </summary>
        /// <returns>true if the user has appointments on the date, otherwise false</returns>
        public bool UserHasAppointments(User user, DateTime date)
        {
            bool Result = false;

            foreach (Appointment appt in this)
            {
                if (appt.AppointmentDate.Date == date.Date && appt.EmployeeID == user.ID
                    && appt.AppointmentType != 1 && (appt.Status != Enums.AppointmentStatus.CancelledByStaff || 
                    appt.Status != Enums.AppointmentStatus.CancelledByUser))
                {
                    switch (appt.Status)
                    {
                        case Enums.AppointmentStatus.CancelledByUser:
                        case Enums.AppointmentStatus.CancelledByStaff:
                            continue;

                        default:
                            return (true);
                    }
                }
            }

            return (Result);
        }

        public bool IsWorking(double AppointmentTime)
        {
            return (AppointmentTime >= _therapist.StartTime && AppointmentTime < _therapist.EndTime);
        }

        public Appointment Find(Int64 AppointmentID)
        {
            Appointment Result = null;

            foreach (Appointment appt in this)
            {
                if (appt.ID == AppointmentID)
                {
                    Result = appt;
                    break;
                }
            }

            return (Result);
        }

        /// <summary>
        /// Returns the number of appointment slots for the day
        /// </summary>
        /// <returns></returns>
        public int TotalAppointmentSlots()
        {
            int Result = 0;

            foreach (Appointment appt in this)
            {
                Result += appt.Duration;
            }

            if (Result > 0)
                Result = Result / 25;

            return (Result);
        }

        /// <summary>
        /// Returns an appointment which matches the Time
        /// </summary>
        /// <param name="Time">Time of the appointment</param>
        /// <returns></returns>
        public Appointment AppointmentStart(string Time)
        {
            Appointment Result = null;

            foreach (Appointment appt in this)
            {
                if (Shared.Utilities.DoubleToTime(appt.StartTime) == Time)
                {
                    Result = appt;
                    break;
                }
            }

            return (Result);
        }

        /// <summary>
        /// Returns an appointment which matches the Time
        /// </summary>
        /// <param name="Time">Time of the appointment</param>
        /// <returns></returns>
        public Appointment AppointmentStart(string Time, Appointment appointment)
        {
            Appointment Result = null;

            foreach (Appointment appt in this)
            {
                if ((appointment != appt) && (Shared.Utilities.DoubleToTime(appt.StartTime) == Time))
                {
                    Result = appt;
                    break;
                }
            }

            return (Result);
        }


        /// <summary>
        /// Determines if any appointments clash
        /// </summary>
        /// <returns>true if any appointments clash, false if no appointments clash</returns>
        public bool AppointmentsClash()
        {
            bool Result = false;

            foreach (Appointment appt in this)
            {

                //get appointment as double
                Double d = (appt.StartTime + (((appt.Duration - 5) * 1.666666666666667) / 100));

                foreach (Appointment ap in this)
                {
                    if (appt.ID != ap.ID)
                    {
                        if (ap.StartTime >= appt.StartTime && ap.StartTime <= d)
                        {
                            Result = true;
                            return (Result);
                        }
                    }
                }
            }

            return (Result);
        }

        /// <summary>
        /// Determines if an appointment exceeds the employees working hours
        /// </summary>
        /// <param name="appt"></param>
        /// <returns></returns>
        public bool ExceedsWorkingHours(Appointment appt)
        {
            bool Result = false;

            double finalTime = _therapist.EndTime;
            double duration = (appt.Duration / 15) * 0.25;
            double apptEndTime = appt.StartTime + duration;

            Result = apptEndTime > finalTime;
            

            return (Result);
        }

        
        /// <summary>
        /// Determines if any appointments clash with a specific appointment
        /// </summary>
        /// <param name="appt">Appoint to see if anything clashes with</param>
        /// <returns>true if any appointments clash, false if no appointments clash</returns>
        public int AppointmentsClash(Appointment appt)
        {
            int Result = 1;

            //get appointment as double
            Double apptDuration = (appt.StartTime + (((appt.Duration -1) * 1.666666666666667) / 100));

            foreach (Appointment ap in this)
            {
                switch (ap.Status)
                {
                    case Enums.AppointmentStatus.CancelledByUser:
                    case Enums.AppointmentStatus.CancelledByStaff:
                        break;
                    default:
                        if (appt.ID != ap.ID)
                        {
                            Double thisApptDuration = (ap.StartTime + (((ap.Duration -1) * 1.666666666666667) / 100));

                            if ((ap.StartTime >= appt.StartTime && ap.StartTime <= apptDuration) || (appt.StartTime <= thisApptDuration && appt.StartTime >= ap.StartTime))
                            {
                                Result++;
                            }
                        }
                        break;
                }
            }

            if (Result == 0)
                Result = 1; // must include this appointment

            return (Result);
        }

        /// <summary>
        /// Determines if any appointments clash with a specific appointment treatement type
        /// </summary>
        /// <param name="appt">Appoint to see if anything clashes with</param>
        /// <param name="treatment">Treatment to be compared against</param>
        /// <returns>true if any appointments clash, false if no appointments clash</returns>
        public int AppointmentsClash(Appointment appt, AppointmentTreatment treatment)
        {
            int Result = 0;

            //get appointment as double
            Double apptDuration = (appt.StartTime + (((appt.Duration - 5) * 1.666666666666667) / 100));

            foreach (Appointment ap in this)
            {
                if (appt.ID != ap.ID && ap.TreatmentID == treatment.ID && ap.AppointmentType == 0 && ((int)ap.Status < 4 || (int)ap.Status > 5))
                {
                    Double thisApptDuration = (ap.StartTime + (((ap.Duration - 5) * 1.666666666666667) / 100));

                    if ((ap.StartTime >= appt.StartTime && ap.StartTime <= apptDuration) || (appt.StartTime <= thisApptDuration && appt.StartTime >= ap.StartTime))
                    {
                        Result++;
                    }
                }
            }

            return (Result);
        }

        /// <summary>
        /// Determines if any appointments clash within a specific time
        /// </summary>
        /// <param name="Time">Time to see if appointment clashes</param>
        /// <returns>true if any appointments clash within the time specified, false if no appointments clash within the specified time</returns>
        public int AppointmentsClash(Double Time)
        {
            int Result = 0;

            foreach (Appointment appt in this)
            {
                //get appointment as double
                Double apptFinish = (appt.StartTime + (((appt.Duration) * 1.666666666666667) / 100));

                if (Time > appt.StartTime && Time <= apptFinish)
                {
                    foreach (Appointment ap in this)
                    {
                        if (appt.ID != ap.ID)
                        {
                            Double thisApptFinish = (ap.StartTime + (((ap.Duration) * 1.666666666666667) / 100));

                            if ((((apptFinish > thisApptFinish || ap.StartTime > apptFinish) && (thisApptFinish < apptFinish)) && 
                                (apptFinish > ap.StartTime) && 
                                (Time < ap.StartTime || Time > ap.StartTime)  && (Time <= thisApptFinish)) || 
                                ((Time < apptFinish) && (ap.StartTime > appt.StartTime) && (ap.StartTime < apptFinish)))
                            {
                                if (AppointmentCountByTime(Time) > 1)
                                    Result++;
                            }
                        }
                    }
                }
            }

            return (Result);
        }


        public bool AppointmentsClash(Appointment appointment, double Time)
        {
            bool Result = false;

            foreach (Appointment appt in this)
            {
                if (appt.ID != appointment.ID)
                {
                    Double d = (appt.StartTime + (((appt.Duration - 5) * 1.666666666666667) / 100));

                    if (Time >= appt.StartTime && Time <= d)
                    {
                        Result = true;
                        break;
                    }
                }
            }

            return (Result);
        }

        /// <summary>
        /// Determines wether an appointment overlaps with an appointment in this list
        /// </summary>
        /// <param name="appointment"></param>
        /// <param name="Time"></param>
        /// <returns></returns>
        public bool AppointmentOverlaps(Appointment appointment, double Time)
        {
            bool Result = false;

            foreach (Appointment appt in this)
            {
                if (appt.ID != appointment.ID)
                {
                    Double d = (appt.StartTime + (((appt.Duration - 5) * 1.666666666666667) / 100));

                    if (Time >= appt.StartTime && Time <= d && AppointmentPartOf(Time))
                    {
                        Result = true;
                        break;
                    }
                }
            }

            return (Result);
        }

        /// <summary>
        /// Retreives an appointment by appointment ID
        /// </summary>
        /// <param name="AppointmentID">ID of the appointment to retrieve</param>
        /// <returns></returns>
        public Appointment AppointmentGet(int AppointmentID)
        {
            Appointment Result = null;

            foreach (Appointment appt in this)
            {
                if (appt.ID == AppointmentID)
                {
                    Result = appt;
                    break;
                }
            }

            return (Result);
        }

        public int AppointmentCountByTime(Double StartTime)
        {
            int Result = 0;

            foreach (Appointment appt in this)
            {
                switch (appt.Status)
                {
                    case Enums.AppointmentStatus.CancelledByStaff:
                    case Enums.AppointmentStatus.CancelledByUser:
                        break;
                    default:
                        Double d = (appt.StartTime + (((appt.Duration - 5) * 1.666666666666667) / 100));
                        if (StartTime >= appt.StartTime && StartTime <= d)
                        {
                            Result++;
                        }

                        break;
                }
            }

            return (Result);
        }

        /// <summary>
        /// Returns true if an appointment is part of the time slot
        /// </summary>
        /// <param name="StartTime"></param>
        /// <returns>true if an appointment starts at the time, false if no appointment exists</returns>
        public bool AppointmentPartOf(Double StartTime)
        {
            bool Result = false;

            foreach (Appointment appt in this)
            {
                Double d = (appt.StartTime + (((appt.Duration - 5) * 1.666666666666667) / 100));
                if (StartTime >= appt.StartTime && StartTime <= d)
                {
                    Result = true;
                    break;
                }
            }

            return (Result);
        }

        /// <summary>
        /// Checks to see if user can create an appointment
        /// </summary>
        /// <param name="Date">Date appointment required</param>
        /// <param name="StartTime">Time appointment required</param>
        /// <param name="duration">Duration of appointment</param>
        /// <returns>bool, returns true if appointment can be created, otherwise false.</returns>
        public bool AllowCreateAppointment(DateTime Date, double StartTime, int Duration, int AppointmentID, out string ErrorText)
        {
            bool Result = false;
            ErrorText = String.Empty;

            Appointment appt = new Appointment(AppointmentID, -1, Date, StartTime, Duration, 0, 0, 0, "Test Appointment", -1, "Test Appointment", "", -1, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));
            Result = AppointmentsClash(appt) == 1;

            if (!Result)
                ErrorText = "Appointment Clashes with existing appointment";

            if (Result)
            {
                Result = !ExceedsWorkingHours(appt);
                ErrorText = "Appointment duration will exceed therapists working hours";
            }

            if (Result)
            {
                switch (Date.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        Result = Options.AllowMonday;
                        break;
                    case DayOfWeek.Tuesday:
                        Result = Options.AllowTuesday;
                        break;
                    case DayOfWeek.Wednesday:
                        Result = Options.AllowWednesday;
                        break;
                    case DayOfWeek.Thursday:
                        Result = Options.AllowThursday;
                        break;
                    case DayOfWeek.Friday:
                        Result = Options.AllowFriday;
                        break;
                    case DayOfWeek.Saturday:
                        Result = Options.AllowSaturday;
                        break;
                    case DayOfWeek.Sunday:
                        Result = Options.AllowSunday;
                        break;
                }

                if (!Result)
                    ErrorText = "Therapist does not work on a " + Date.DayOfWeek.ToString();
            }

            return (Result);
        }

        /// <summary>
        /// Checks to see if user can create an appointment
        /// </summary>
        /// <param name="Date">Date appointment required</param>
        /// <param name="StartTime">Time appointment required</param>
        /// <param name="duration">Duration of appointment</param>
        /// <returns>bool, returns true if appointment can be created, otherwise false.</returns>
        public bool AllowCreateAppointment(DateTime Date, double StartTime, int Duration)
        {
            bool Result = false;

            Appointment appt = new Appointment(-1, -1, Date, StartTime, Duration, 0, 0, 0, "Test Appointment", -1, "Test Appointment", "", -1, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));
            Result = AppointmentsClash(appt) == 1;

            if (Result)
            {
                Result = !ExceedsWorkingHours(appt);
            }

            return (Result);
        }

        /// <summary>
        /// Adds an item to the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Add(Appointment value)
        {
            int Result = List.Add(value);

            //calculate the column
            int col = AppointmentCountByTime(value.StartTime) -1;

            if (col < 0)
                col = 0;
            value.Column = col;

            return (Result);
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(Appointment value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, Appointment value)
        {
            List.Insert(index, value);
        }

        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(Appointment value)
        {
            List.Remove(value);
        }

        public bool Remove(Int64 ID)
        {
            bool Result = false;

            foreach (Appointment ap in this)
            {
                if (ap.ID == ID)
                {
                    Remove(ap);
                    Result = true;
                    break;
                }
            }

            return (Result);
        }

        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Appointment value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion

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

        #region Static Methods

        /// <summary>
        /// Returns the number of future appointments for user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>int - number of appointments</returns>
        public static int FutureAppointments(User user)
        {
            return (DAL.FirebirdDB.AppointmentFutureCount(user, DateTime.Now));
        }

        public static bool IsMaximumAllowed(AppointmentTreatment treatment, DateTime date, 
            double time, int AppointmentID = -1)
        {
            // assume appointment can be created
            bool Result = true;

            if (treatment.MaximumTreatments > 0)
            {
                // can only supply x qty of this treatement, is that many already catered for?
                Appointments appts = Appointments.Get(date);

                //create dummy appointment
                Appointment appt = new Appointment(AppointmentID, -1, date, time, treatment.Duration,
                    Enums.AppointmentStatus.Confirmed, 0, treatment.ID, 
                    treatment.Name, -1, "", "", -1, DateTime.Now, DateTime.Now, -1,
                    DateTime.Now.AddYears(-100));

                //do treatment times overlap?
                int clashCount = appts.AppointmentsClash(appt, treatment);

                if (clashCount > treatment.MaximumTreatments)
                    Result = false;
            }

            return (Result);
        }

        public static Int64 Create(Appointment appointment, User user)
        {
            appointment.ID = DAL.FirebirdDB.AppointmentCreate(appointment, user);

            if (OnNewAppointment != null)
                OnNewAppointment(null, new NewAppointmentArgs(appointment));

            Hooks.Hooks.HookNotification(HookEvent.AppointmentCreated,
                String.Format("User: {0}; Staff: {1}; Treatment: {2}", 
                appointment.User.UserName, user.UserName, appointment.TreatmentName));

            return (appointment.ID);
        }

        public static Appointments GetNew(Int64 MaxID, DateTime LastChecked)
        {
            return (DAL.FirebirdDB.AppointmentsGetNew(MaxID, LastChecked));
        }

        public static Appointments Get(DateTime Date, Int64 EmployeeID)
        {
            return (DAL.FirebirdDB.AppointmentsGet(Date, EmployeeID));
        }

        public static Appointments Get(User user, int PageNumber, int PageSize)
        {
            return (DAL.FirebirdDB.AppointmentsGet(user, PageNumber, PageSize));
        }

        public static int GetCount(User user)
        {
            return (DAL.FirebirdDB.AppointmentsGetCount(user));
        }

        public static Appointments Get(DateTime MinimumDate, Progress progress)
        {
            return (DAL.FirebirdDB.AppointmentsGet(MinimumDate, progress));
        }

        public static Appointment Get(Int64 AppointmentID)
        {
            return (DAL.FirebirdDB.AppointmentGet(AppointmentID));
        }

        public static Appointments Get(int PageNumber, int PageSize)
        {
            return (DAL.FirebirdDB.AppointmentsGet(PageNumber, PageSize));
        }

        public static Appointments Get(DateTime AppointmentDate, Therapist therapist, bool ShowCancelledAppointment)
        {
            return (DAL.FirebirdDB.AppointmentsGet(AppointmentDate, therapist, ShowCancelledAppointment));
        }

        public static Appointments Get(DateTime AppointmentDate, bool ShowCancelledAppointments)
        {
            return (DAL.FirebirdDB.AppointmentsGet(AppointmentDate, ShowCancelledAppointments));
        }

        public static Appointments Get(DateTime AppointmentDateStart, DateTime AppointmentDateFinish, bool ShowCancelledAppointments)
        {
            return (DAL.FirebirdDB.AppointmentsGet(AppointmentDateStart, AppointmentDateFinish, ShowCancelledAppointments));
        }

        public static Appointments Get(DateTime AppointmentDate)
        {
            return (DAL.FirebirdDB.AppointmentsGet(AppointmentDate));
        }

        public static Appointments Get(DateTime StartDate, DateTime EndDate, Therapist Therapist)
        {
            return (DAL.FirebirdDB.AppointmentsGet(StartDate, EndDate, Therapist));
        }

        public static Appointments GetRequested()
        {
            return (DAL.FirebirdDB.AppointmentsGetRequested());
        }

        #endregion Static Methods

        #region Static Events

        public static event NewAppointmentHandler OnNewAppointment;

        #endregion Static Events
    }
}