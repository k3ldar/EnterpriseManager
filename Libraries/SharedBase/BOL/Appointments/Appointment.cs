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
 *  File: Appointment.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Web;

using SharedBase.Utils;
using SharedBase.BOL.Users;
using SharedBase.BOL.Therapists;
using SharedBase.BOL.Training;

namespace SharedBase.BOL.Appointments
{
    [Serializable]
    public sealed class Appointment : BaseObject
    {
        #region Private / Protected Members

        private bool _changed;
        private Int64 _id;
        private Int64 _employeeID;
        private string _employeeName;
        private DateTime _appointmentDate;
        private Double _startTime;
        private int _duration;
        private Enums.AppointmentStatus _status;
        private int _appointmentType;
        private int _treatmentID;
        private string _treatmentName;
        private Int64 _userID;
        private string _userName;
        private string _notes;
        private int _column;
        private Int64 _masterAppointment;
        private Appointments _children;
        private User _user;
        private DateTime _created;
        private DateTime _lastAltered;
        private Int64 _lockedBy;
        private string _lockedByName;
        private Course _trainingCourse;

        #endregion Private / Protected Members

        #region Constructor / Destructors

        public Appointment(Int64 ID, Int64 EmployeeID, DateTime AppointmentDate, Double StartTime, 
            int Duration, Enums.AppointmentStatus Status, int AppointmentType, int TreatmentID, 
            string TreatmentName, Int64 UserID, string UserName, string Notes, Int64 MasterAppointment,
            DateTime created, DateTime lastAltered, Int64 lockedBy, DateTime reminderDate)
        {
            _id = ID;
            _employeeID = EmployeeID;
            _employeeName = String.Empty;
            _appointmentDate = AppointmentDate;
            _startTime = StartTime;
            _duration = Duration;
            _status = Status;
            _appointmentType = AppointmentType;
            _treatmentID = TreatmentID;
            _treatmentName = TreatmentName;
            _userID = UserID;
            _userName = UserName;
            _notes = Notes;
            _masterAppointment = MasterAppointment;
            _changed = false;
            _created = created;
            _lastAltered = lastAltered;
            _lockedBy = lockedBy;
            ReminderDate = reminderDate;
       }


        #endregion Constructor / Destructors

        #region Properties

        /// <summary>
        /// Determines who last changed the appointment
        /// </summary>
        public string LastAlteredBy
        {
            get
            {
                return DAL.FirebirdDB.AppointmentLastChangedBy(this);
            }
        }

        /// <summary>
        /// Returns the DatTime the appointment was created
        /// </summary>
        public DateTime Created
        {
            get
            {
                return _created;
            }
        }

        /// <summary>
        /// Returns DateTime appointment last altered
        /// </summary>
        public DateTime LastAltered
        {
            get
            {
                return _lastAltered;
            }
        }

        /// <summary>
        /// Returns the User object for the appointment
        /// </summary>
        public User User
        {
            get
            {
                if (_user == null)
                    _user = DAL.FirebirdDB.UserGet(_userID);

                return _user;
            }
        }

        public int Column
        {
            get
            {
                return _column;
            }

            set
            {
                _column = value;
            }
        }

        public Appointments ChildAppointments
        {
            get
            {
                if (_children == null)
                    _children = DAL.FirebirdDB.AppointmentsGet(this);

                return _children;
            }
        }

        /// <summary>
        /// Gets/Sets the master appointment
        /// </summary>
        public Int64 MasterAppointment
        {
            get
            {
                return _masterAppointment;
            }

            set
            {
                if (value != _masterAppointment)
                {
                    _masterAppointment = value;
                    _changed = true;
                }
            }
        }

        /// <summary>
        /// Appointment Notes
        /// </summary>
        public string Notes
        {
            get
            {
                return _notes;
            }

            set
            {
                if (_notes != value)
                {
                    _notes = value;
                    _changed = true;
                }
            }
        }

        public int Duration
        {
            get
            {
                return _duration;
            }

            set
            {
                if (value < 15)
                    throw new ArgumentException("Duration must be at least 15 minutes");


                if (_duration != value)
                {
                    _duration = value;
                    _changed = true;
                }
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    _changed = true;
                }
            }
        }

        public Int64 UserID
        {
            get
            {
                return _userID;
            }

            set
            {
                if (_userID != value)
                {
                    _userID = value;
                    _changed = true;
                }
            }
        }
   
        public string TreatmentName
        {
            get
            {
                string Result = _treatmentName;

                if (Result == String.Empty)
                    Result = "Unknown";

                return Result;
            }

            set
            {
                if (_treatmentName != value)
                {
                    _treatmentName = value;
                    _changed = true;
                }
            }
        }

        public int TreatmentID
        {
            get
            {
                return _treatmentID;
            }

            set
            {
                if (_treatmentID != value)
                {
                    _treatmentID = value;
                    _changed = true;
                }
            }
        }

        public Double StartTime
        {
            get
            {
                return _startTime;
            }

            set
            {
                if (_startTime != value)
                {
                    _startTime = value;
                    _changed = true;
                }
            }
        }

        public int AppointmentType
        {
            get
            {
                return _appointmentType;
            }

            set
            {
                if (_appointmentType != value)
                {
                    _appointmentType = value;
                    _changed = true;
                }
            }
        }

        public Int64 ID
        {
            get 
            {
                return _id;
            }

            set 
            {
                _id = value;
            }
        }

        public DateTime AppointmentDate
        {
            get
            {
                return _appointmentDate;
            }

            set
            {
                if (_appointmentDate.Date != value.Date)
                {
                    _appointmentDate = value;
                    //reset time to zero
                    _appointmentDate = _appointmentDate.AddHours(-value.Hour);
                    _appointmentDate = _appointmentDate.AddMinutes(-value.Minute);
                    _changed = true;
                }
            }
        }

        public string StatusText
        {
            get
            {
                string Result = Shared.Utilities.SplitCamelCase(_status.ToString());

                return Result;
            }
        }

        public Enums.AppointmentStatus Status
        {
            get
            {
                return _status;
            }

            set
            {
                if (_status != value)
                {
                    Enums.AppointmentStatus oldStatus = _status;
                    _status = value;

                    foreach (Appointment sub in this.ChildAppointments)
                    {
                        if (sub.Status != Enums.AppointmentStatus.Deleted && 
                            sub.Status == oldStatus) //child appointments can be cancelled etc
                        {
                            sub.Status = _status;
                        }
                    }

                    Hooks.Hooks.HookNotification(HookEvent.AppointmentStatusChanged,
                        String.Format("User: {0}; Status: {1}; Treatment: {2}", 
                        this.User.UserName, _status.ToString(), this.TreatmentName));

                    _changed = true;
                }
            }
        }

        public Int64 EmployeeID
        {
            get
            {
                return _employeeID;
            }

            set
            {
                if (_employeeID != value)
                {
                    _employeeID = value;
                    _employeeName = "";
                    _changed = true;
                }
            }
        }

        public string EmployeeName
        {
            get
            {
                if (_employeeName == String.Empty)
                {
                    User user = DAL.FirebirdDB.UserGet(_employeeID);
                    _employeeName = user.UserName;
                }

                return _employeeName;
            }
        }

        public string AppointmentLink
        {
            get
            {
                return GetHTMLAppointmentText();
            }
        }

        public string AppointmentText
        {
            get
            {
                return GetAppointmentText(true);
            }
        }

        /// <summary>
        /// Returns Therapist object for this appointment
        /// </summary>
        public Therapist Therapist
        {
            get
            {
                return Therapists.Therapist.Get(_employeeID);
            }
        }

        /// <summary>
        /// Indicates wether the appointment is locked by a user or not
        /// </summary>
        public bool IsLocked
        {
            get
            {
                return _lockedBy != -1;
            }
        }

        /// <summary>
        /// User ID of user who has locked the appointment
        /// </summary>
        public Int64 LockedBy
        {
            get
            {
                return _lockedBy;
            }

            set
            {
                if (_lockedBy != value)
                {
                    _changed = true;
                    _lockedBy = value;
                }
            }
        }

        /// <summary>
        /// Returns the name of the person who has locked the appointment
        /// </summary>
        public string LockedByName
        {
            get
            {
                if (String.IsNullOrEmpty(_lockedByName))
                    _lockedByName = Users.User.UserGet(_lockedBy).UserName;

                return _lockedByName;
            }
        }


        public Course TrainingCourse
        {
            get
            {
                if (_appointmentType != 14)
                    return null;

                if (_trainingCourse == null)
                    _trainingCourse = Course.Get(ID);

                return _trainingCourse;
            }
        }

        /// <summary>
        /// Date Reminder Sent
        /// </summary>
        public DateTime ReminderDate { get; private set; }

        #endregion Properties

        #region Private Methods

        private string GetHTMLAppointmentText()
        {
            string Result = "";

            switch (AppointmentType)
            {
                case 0: // beauty treatment
                    Result = String.Format("<span class=\"DiaryTreatment\">{0}</span><br /><span class=\"DiaryUser\">{1}</span>", TreatmentName, UserName);
                    break;
                default:
                    AppointmentTypes types = AppointmentTypes.Get();
                    foreach (AppointmentType type in types)
                    {
                        if (type.ID == _appointmentType)
                        {
                            Result = String.Format("<span class=\"DiaryTreatment\">{0}</span>", type.Description);
                            break;
                        }
                    }

                    if (UserName != EmployeeName)
                        Result += String.Format("<br /><span class=\"DiaryUser\">{0}</span>", UserName);

                    break;
            }


            if (Notes != String.Empty)
                Result += String.Format("<br /><span class=\"DiaryNotes\">{0}</span>", Notes);

            Result = String.Format("<div class=\"AppointmentEntry\">{0}</div>", Result);

            return Result;
        }

        #endregion Private Methods

        #region Public Methods

        /// <summary>
        /// Indicates wether a reminder has been sent or not
        /// </summary>
        /// <returns></returns>
        public bool AllowSendReminder()
        {
            bool Result = false;

            if (ReminderDate.Year < 2000)
            {
                if (this.MasterAppointment == -1 && this.AppointmentType == 0)
                    Result = true;
            }

            return Result;
        }

        public void ReminderSent(User user)
        {
            ReminderDate = DateTime.Now;
            _changed = true;
            Save(user);
        }


        /// <summary>
        /// Retrieves the text to be displayed on the appointment
        /// </summary>
        /// <param name="showNameFirst"></param>
        /// <returns></returns>
        public string GetAppointmentText(bool showNameFirst)
        {
            string Result = "";


            switch (AppointmentType)
            {
                case 0: // beauty treatment
                    if (showNameFirst)
                        Result = String.Format("{1}\n{0}", TreatmentName, UserName);
                    else
                        Result = String.Format("{0}\n{1}", TreatmentName, UserName);

                    //if (User.VIPCustomer)
                    //    Result += " (VIP)";

                    break;
                case 14: // training appointment
                    Result = String.Format("Training Course\n\nTrainer: {0}\n\nCourse: {1}", UserName, Notes);

                    if (TrainingCourse != null)
                    {
                        Result += String.Format("\n\nTotal Attendees: {0}\n\nSpaces Available: {1}",
                            TrainingCourse.TotalAttendees, TrainingCourse.SpacesAvailable);

                        if (TrainingCourse.CourseAttendees.Count > 0)
                        {
                            Result += "\n\nAttendees:\n\n";

                            foreach (Attendee attendingSalon in TrainingCourse.CourseAttendees)
                            {
                                Result += String.Format("{0} - Total Attending: {1}\n\n",
                                    attendingSalon.Salon.Name, attendingSalon.NumberOfAttendees);
                            }
                        }
                    }

                    break;
                default:
                    AppointmentTypes types = AppointmentTypes.Get();

                    foreach (AppointmentType type in types)
                    {
                        if (type.ID == _appointmentType)
                        {
                            Result = type.Description;
                            break;
                        }
                    }

                    break;
            }

            if (_appointmentType != 14 && Notes != String.Empty)
                Result += "\r\n\r\n" + Notes;

            return Result;
        }

        /// <summary>
        /// Retrieves all changes for an appointment
        /// </summary>
        /// <param name="appointment">Appointment for changes</param>
        /// <returns>AppointmentChanges collection</returns>
        public AppointmentChanges History()
        {
            return DAL.FirebirdDB.AppointmentChanges(this);
        }

        /// <summary>
        /// Removes all child appointments
        /// </summary>
        public void ClearChildAppointments()
        {
            //Library.DAL.FirebirdDB.AppointmentDeleteChildren(this);
        }

        /// <summary>
        /// Saves the appointment
        /// </summary>
        /// <param name="user">Employee making changes</param>
        public void Save(User user)
        {
            if (!_changed)
                return;

            if (this.ID == -1)
            {
                SharedBase.DAL.FirebirdDB.AppointmentCreate(this, user);
                Hooks.Hooks.HookNotification(HookEvent.AppointmentCreated,
                    String.Format("User: {0}; Staff: {1}; Treatment: {2}", 
                    this.User.UserName, user.UserName, this.TreatmentName));

            }
            else
            {
                int attempts = 0;

                try
                {

                    SharedBase.DAL.FirebirdDB.AppointmentUpdate(this, user);

                    foreach (Appointment sub in this.ChildAppointments)
                        sub.Save(user);
                }
                catch (Exception err)
                {
                    if (err.Message.Contains("lock conflict on no wait transaction"))
                    {
                        if (attempts < DAL.DALHelper.LockConflictAttempts)
                        {
                            attempts++;
                            System.Threading.Thread.Sleep(100);

                            SharedBase.DAL.FirebirdDB.AppointmentUpdate(this, user);

                            foreach (Appointment sub in this.ChildAppointments)
                                sub.Save(user);
                        }
                        else
                            throw; //we tried throw it back to the UI
                    }
                    else
                        throw; //not a lock conflict, throw it back to the UI

                }
            }

            _changed = false;
        }

        /// <summary>
        /// Retrieves the Start DateTime of the appointment
        /// </summary>
        /// <returns>DateTime object</returns>
        public DateTime AppointmentAsDateTime()
        {
            DateTime Result;
            int hour = (int)StartTime;
            int minute = (int)((StartTime - Math.Floor(StartTime)) * 100 / 1.666666666666667);

            Result = new DateTime(AppointmentDate.Year, AppointmentDate.Month, AppointmentDate.Day, hour, minute, 0);

            return Result;
        }

        /// <summary>
        /// Detemines wether the user can cancel an appointemnt or not
        /// </summary>
        /// <returns></returns>
        public bool UserCanCancellAppointment()
        {
            bool Result = false;
            int hour = (int)StartTime;
            int minute = (int)((StartTime - Math.Floor(StartTime)) * 100 / 1.666666666666667);

            DateTime apptTime = new DateTime(AppointmentDate.Year, AppointmentDate.Month, AppointmentDate.Day, hour, minute, 0);

            Result = DateTime.Now < apptTime.Date.AddDays(-2);
            return Result;
        }

        /// <summary>
        /// Changes the therapist who will do the appointment
        /// </summary>
        /// <param name="therapist"></param>
        public void UpdateTherapist(Therapist therapist)
        {
            if (_employeeID != therapist.EmployeeID)
            {
                _employeeID = therapist.EmployeeID;
                _employeeName = therapist.EmployeeName;
                _changed = true;
            }
        }

        /// <summary>
        /// Gets the total number of minutes for this appointment, and any child appointments
        /// </summary>
        /// <returns></returns>
        public int TotalTime()
        {
            int Result = Duration;

            foreach (Appointment sub in this.ChildAppointments)
                Result += sub.Duration;

            return Result;
        }

        #endregion Public Methods

        #region Overridden Methods

        public override string ToString()
        {
            return String.Format("Appointment: {0}; Date: {1}; User: {2}; Employee: {3}; Treatment: {4}; Status: {5}", 
                ID, AppointmentAsDateTime().ToShortDateString(), _userID, _employeeID, _treatmentName, _status);
        }

        #endregion Overridden Methods
    }
}