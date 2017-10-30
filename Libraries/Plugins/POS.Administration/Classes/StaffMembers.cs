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
