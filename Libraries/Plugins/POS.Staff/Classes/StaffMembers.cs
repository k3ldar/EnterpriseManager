using System;
using System.Collections.Generic;
using System.Text;

using Languages;

using Library.BOL.Appointments;
using Library.BOL.Staff;
using Library.BOL.Users;

using SharedControls.WizardBase;

namespace POS.Staff.Classes
{
    internal static class StaffMembers
    {
        /// <summary>
        /// Loads the wizard to create a new employee
        /// </summary>
        /// <returns></returns>
        internal static bool CreateNewEmployee()
        {
            StaffMember staff = new StaffMember();

            bool Result = WizardForm.ShowWizard(LanguageStrings.AppStaffAddStaffMember,
                new Controls.Wizards.StaffAdd.Step1(staff),
                new Controls.Wizards.StaffAdd.Step2(staff),
                new Controls.Wizards.StaffAdd.Step3(staff),
                new Controls.Wizards.StaffAdd.Step4(staff),
                new Controls.Wizards.StaffAdd.Step5(staff));

            return (Result);
        }

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

            Users staff = user.StaffRecord.GetStaff();

            if (staff.Count > 0)
            {
                response = String.Format(LanguageStrings.AppStaffEmployeeHasAssignedStaff, staff.Count);
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
