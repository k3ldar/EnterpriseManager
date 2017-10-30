using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.Training
{
    [Serializable]
    public sealed class TrainingCourse : BaseObject
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">ID of Course</param>
        /// <param name="name">Name of Course</param>
        /// <param name="maximumAttendees">Maximum Attendees for Course</param>
        /// <param name="additionalAttendeeCost">Cost for extra individual from a salon above MaximumSalonAttendees</param>
        /// <param name="courseLength">Length of Course in days</param>
        /// <param name="maximumSalonAttendees">Maximum number of attendees from an individual salon</param>
        public TrainingCourse (int id, string name, int maximumAttendees, double courseCost, 
            double additionalAttendeeCost, int courseLength, int maximumSalonAttendees)
        {
            ID = id;
            Name = name;
            MaximumAttendees = maximumAttendees;
            CourseCost = courseCost;
            AdditionalAttendeeCost = additionalAttendeeCost;
            CourseLength = courseLength;
            MaximumSalonAttendees = maximumSalonAttendees;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// ID of Training Course
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Name of Course
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cost of course without VAT
        /// </summary>
        public double CourseCost { get; set; }

        /// <summary>
        /// Maximum Attendees
        /// </summary>
        public int MaximumAttendees { get; set; }

        /// <summary>
        /// Additional cost per attendee from a salon
        /// </summary>
        public double AdditionalAttendeeCost { get; set; }

        /// <summary>
        /// Length of course in days
        /// </summary>
        public int CourseLength { get; set; }

        /// <summary>
        /// Maximum number of attendees from an individual salon, inclusive of overall price
        /// </summary>
        public int MaximumSalonAttendees { get; set; }

        #endregion Properties
    }
}
