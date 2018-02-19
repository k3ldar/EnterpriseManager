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
 *  File: NewCourseOptions.cs
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

using Library.BOL.Appointments;
using Library.BOL.Users;
using Library.BOL.Training;
using Library.BOL.Therapists;

namespace SalonDiary.Classes
{
    public class NewCourseOptions
    {
        #region Private Members

        private User _currentUser;
        private Appointments _allAppointments;

        #endregion Private Members

        #region Constructors

        public NewCourseOptions(User currentUser, Appointments allAppointments)
        {
            _currentUser = currentUser;
            _allAppointments = allAppointments;
            ChangeWorkingHours = true;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Course Trainer
        /// </summary>
        public Therapist Trainer { get; set; }

        /// <summary>
        /// Training course being scheduled
        /// </summary>
        public TrainingCourse Course { get; set; }

        /// <summary>
        /// Date and time of first day of the course
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Training Course runs on consecutive Days
        /// </summary>
        public bool ConsecutiveDays { get; set; }

        /// <summary>
        /// Individual course dates if ConsecutiveDays == false
        /// </summary>
        public DateTime[] CourseDates { get; set; }

        /// <summary>
        /// Does not book a course on a Saturday
        /// </summary>
        public bool ExcludeSaturday { get; set; }

        /// <summary>
        /// Does not book a course on a Sunday
        /// </summary>
        public bool ExcludeSunday { get; set; }

        /// <summary>
        /// if true will automatically change working hours for trainer
        /// </summary>
        public bool ChangeWorkingHours { get; set; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Creates the course based on the settings
        /// </summary>
        public void CreateCourse()
        {
            DateTime start = StartDate;

            string day1Desc = Course.CourseLength == 1 ? "{0} - 1 Day Course" : "{0} - Day 1";

            Appointment day1 = new Appointment(-1, Trainer.EmployeeID, start.Date, 9.0, 540,
                Library.Enums.AppointmentStatus.Confirmed, 14, -1,
                Course.Name, Trainer.EmployeeID, Trainer.EmployeeName, String.Format(day1Desc, Course.Name),
                -1, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));

            day1.ID = Appointments.Create(day1, _currentUser);
            Library.BOL.Training.Course.Create(day1, Course, Trainer);

            if (ChangeWorkingHours)
                SetWorkingHours(Trainer, start);

            RaiseCreateAppointment(day1);

            start = start.AddDays(1);

            for (int i = 2; i <= Course.CourseLength; i++)
            {
                if (ConsecutiveDays)
                {
                    while (ExcludeSaturday && start.DayOfWeek == DayOfWeek.Saturday)
                        start = start.AddDays(1);

                    while (ExcludeSunday && start.DayOfWeek == DayOfWeek.Sunday)
                        start = start.AddDays(1);
                }
                else
                {
                    start = CourseDates[i];
                }

                if (ChangeWorkingHours)
                    SetWorkingHours(Trainer, start);

                Appointment newDay = new Appointment(-1, Trainer.EmployeeID, start.Date, 9.0, 540,
                    Library.Enums.AppointmentStatus.Confirmed, 14, -1,
                    Course.Name, Trainer.EmployeeID, Trainer.EmployeeName, String.Format("{0} - Day {1}", Course.Name, i),
                    day1.ID, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));

                newDay.ID = Appointments.Create(newDay, _currentUser);
                RaiseCreateAppointment(newDay);
                start = start.AddDays(1);
            }
        }

        /// <summary>
        /// Determines wether the trainer has appointments on specified dates
        /// </summary>
        /// <returns></returns>
        public bool TrainerHasAppointments()
        {
            bool Result = false;

            DateTime start = StartDate;

            // is there an appointment for this trainer on this date?
            Result = _allAppointments.UserHasAppointments(User.UserGet(Trainer.EmployeeID), start);

            if (Result)
                return (Result);

            start = start.AddDays(1);

            for (int i = 2; i <= Course.CourseLength; i++)
            {
                if (ConsecutiveDays)
                {
                    while (ExcludeSaturday && start.DayOfWeek == DayOfWeek.Saturday)
                        start = start.AddDays(1);

                    while (ExcludeSunday && start.DayOfWeek == DayOfWeek.Sunday)
                        start = start.AddDays(1);
                }
                else
                {
                    start = CourseDates[i];
                }

                //is there an appointment for the trainer on this date?
                Result = _allAppointments.UserHasAppointments(User.UserGet(Trainer.EmployeeID), start);

                if (Result)
                    break;

                start = start.AddDays(1);
            }

            return (Result);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Set's working hours for the user to match that of the course
        /// </summary>
        /// <param name="trainer">trainer who's working hours are being changed</param>
        /// <param name="date">Date of training</param>
        private void SetWorkingHours(Therapist trainer, DateTime date)
        {
            WorkingDay workingDay = trainer.WorkingDays.Create(trainer);
            workingDay.AllowTreatments = false;
            workingDay.Date = date.Date;
            workingDay.FinishTime = 18.0;
            workingDay.StartTime = 9.0;
            workingDay.RepeatOption = Library.Enums.AppointmentRepeatType.NoRepeat;
            workingDay.RepeatDuration = 0;
            workingDay.Save();
        }

        #endregion Private Methods

        #region Delegates

        public delegate void AppointmentCreated(object sender, Appointment appointment);

        #endregion Delegates

        #region Event Wrappers

        private void RaiseCreateAppointment(Appointment appointment)
        {
            if (CreateAppointment != null)
                CreateAppointment(this, appointment);
        }

        #endregion Event Wrappers

        #region Events

        public event AppointmentCreated CreateAppointment;

        #endregion Events
    }
}
