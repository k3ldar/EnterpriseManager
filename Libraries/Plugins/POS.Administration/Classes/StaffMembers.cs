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
 *  File: StaffMembers.cs
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

using Languages;

using Library.BOL.Appointments;
using Library.BOL.Users;

namespace POS.Administration.Classes
{
    internal static class StaffMembers
    {
        /// <summary>
        /// Determines wether the Employee can be downgraded to normal user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        internal static bool CanDowngradeAccount(User user, ref string response)
        {
            response = String.Empty;

            int futureAppointments = Appointments.FutureAppointments(user);

            if (futureAppointments > 0)
            {
                response = String.Format(LanguageStrings.AppStaffEmployeeHasFutureAppointments, futureAppointments);
                return (false);
            }

            return (true);
        }

        /// <summary>
        /// Determines wether the Employee can have their diary deleted or not
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        internal static bool CanDeleteDiary(User user, ref string response)
        {
            response = String.Empty;

            int futureAppointments = Appointments.FutureAppointments(user);

            if (futureAppointments > 0)
            {
                response = String.Format(LanguageStrings.AppStaffEmployeeDeleteDiary, futureAppointments);
                return (false);
            }

            return (true);
        }

        #region Private Methods

        #endregion Private Methods
    }
}
