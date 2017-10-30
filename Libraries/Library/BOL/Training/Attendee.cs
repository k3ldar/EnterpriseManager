using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.Salons;

namespace Library.BOL.Training
{
    /// <summary>
    /// Course Attendees
    /// </summary>
    [Serializable]
    public sealed class Attendee : BaseObject
    {
        #region Constructors

        public Attendee (Salon salon, int numberOfAttendees, double totalPaid)
        {
            Salon = salon;
            NumberOfAttendees = numberOfAttendees;
            TotalPaid = totalPaid;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Salon being trained
        /// </summary>
        public Salon Salon { get; set; }

        /// <summary>
        /// Number of people 
        /// </summary>
        public int NumberOfAttendees { get; set; }

        /// <summary>
        /// Total Paid by Salon for Course
        /// </summary>
        public double TotalPaid { get; set; }

        #endregion Properties
    }
}
