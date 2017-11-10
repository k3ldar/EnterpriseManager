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
 *  File: AppointmentHistoryItem.cs
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

namespace Library.BOL.Users
{
    /// <summary>
    /// Appointment history item.
    /// </summary>
    [Serializable]
    public sealed class AppointmentHistoryItem : BaseObject
    {
        #region Private Members

        private string _timeFrame;
        private string _status;
        private int _count;

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="timeFrame">Time Frame of Appointment</param>
        /// <param name="status">Status of Appointment</param>
        /// <param name="count">Count of Time Frame/Status</param>
        public AppointmentHistoryItem(string timeFrame, string status, int count)
        {
            _timeFrame = timeFrame;
            _status = status;
            _count = count;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Timeframe of appointment (6 months or older)
        /// </summary>
        public string TimeFrame
        {
            get
            {
                return (_timeFrame);
            }
        }

        /// <summary>
        /// Status of appointment
        /// </summary>
        public string Status
        {
            get
            {
                return (_status);
            }
        }

        /// <summary>
        /// Count of appointment types for time frame
        /// </summary>
        public int Count
        {
            get
            {
                return (_count);
            }
        }

        #endregion Properties

    }
}
