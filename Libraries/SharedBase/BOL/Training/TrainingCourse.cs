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
 *  File: TrainingCourse.cs
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

namespace SharedBase.BOL.Training
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
