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
 *  File: Attendee.cs
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

using SharedBase.BOL.Salons;

namespace SharedBase.BOL.Training
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
