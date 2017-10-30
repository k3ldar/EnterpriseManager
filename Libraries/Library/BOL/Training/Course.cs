using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.Therapists;
using Library.BOL.Users;

namespace Library.BOL.Training
{
    /// <summary>
    /// Actual Training Course
    /// </summary>
    [Serializable]
    public sealed class Course : BaseObject
    {
        #region Private Members

        private Attendees _attendees;

        #endregion Private Members

        #region Constructors

        public Course (Int64 id, Therapist trainer, TrainingCourse course)
        {
            ID = id;
            Trainer = trainer;
            CourseType = course;
        }

        #endregion Constructors

        #region Overridden Methods

        /// <summary>
        /// Saves the current course
        /// </summary>
        public override void Save()
        {
            DAL.FirebirdDB.TrainingCourseSave(this);
        }

        #endregion Overridden Methods

        #region Properties

        public Int64 ID { get; set; }

        /// <summary>
        /// Course Trainer
        /// </summary>
        public Therapist Trainer { get; set; }

        /// <summary>
        /// Training Course
        /// </summary>
        public TrainingCourse CourseType { get; set; }

        /// <summary>
        /// Returns a list of all course attendees
        /// </summary>
        public Attendees CourseAttendees
        {
            get
            {
                if (_attendees == null)
                    _attendees = Attendees.Get(this);

                return (_attendees);
            }
        }
        
        /// <summary>
        /// Returns the total number of attendees on the course
        /// </summary>
        public int TotalAttendees
        {
            get
            {
                int Result = 0;

                foreach (Attendee attendee in CourseAttendees)
                    Result += attendee.NumberOfAttendees;

                return (Result);
            }
        }

        /// <summary>
        /// returns the total number of places available on the course
        /// </summary>
        public int SpacesAvailable
        {
            get
            {
                return (CourseType.MaximumAttendees - TotalAttendees);
            }
        }

        #endregion Properties

        #region Static Methods

        /// <summary>
        /// Retrieves an individual training course
        /// </summary>
        /// <param name="id">id of Training Course</param>
        /// <returns></returns>
        public static Course Get(Int64 id)
        {
            return (DAL.FirebirdDB.TrainingCoursesGet(id));
        }

        /// <summary>
        /// Create a new Course for an appointment
        /// </summary>
        /// <param name="appointment">Appointment for course</param>
        /// <param name="course">Training Course</param>
        /// <param name="trainer">Trainer</param>
        /// <returns></returns>
        public static Course Create(Appointments.Appointment appointment, TrainingCourse course, Therapist trainer)
        {
            return (DAL.FirebirdDB.TrainingCoursesCreate(appointment, course, trainer));
        }

        #endregion Static Methods
    }
}
