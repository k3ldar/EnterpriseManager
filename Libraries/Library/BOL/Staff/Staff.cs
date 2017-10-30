using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.Users;

namespace Library.BOL.Staff
{
    /// <summary>
    /// Class for managing staff memberss
    /// </summary>
    [Serializable]
    public sealed class Staff
    {
        /// <summary>
        /// Get's the staff members manager
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static User ManagerGet(User user)
        {
            if (user.MemberLevel < MemberLevel.StaffMember)
                throw new Exception(Consts.ERROR_NOT_STAFF);

            return (DAL.FirebirdDB.StaffMemberManagerGet(user));
        }

        /// <summary>
        /// Sets an employees manager
        /// </summary>
        /// <param name="staffMember"></param>
        /// <param name="manager"></param>
        public static void ManagerSet(User staffMember, User manager)
        {
            DAL.FirebirdDB.StaffMemberManagerSet(staffMember, manager);
        }

        /// <summary>
        /// Removes the member of staff manager
        /// </summary>
        /// <param name="staffMember"></param>
        public static void ManagerRemove(User staffMember)
        {
            DAL.FirebirdDB.StaffMemberManagerRemove(staffMember);
        }

        /// <summary>
        /// Gets all people who report to the manager
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public static Users.Users ManagerGetStaff(StaffMember manager)
        {
            return (DAL.FirebirdDB.StaffMemberManagerSubStaff(manager));
        }

        /// <summary>
        /// Number of leave requests that require approval
        /// </summary>
        /// <param name="requestingUser"></param>
        /// <returns></returns>
        public static int TotalLeaveAuthorisationRequests(User requestingUser)
        {
            int Result = 0;

            StaffLeave leave = StaffLeave.AuthorisationRequests();

            Result = leave.Count;

            return (Result);
        }

        /// <summary>
        /// Number of leave requests that require approval
        /// </summary>
        /// <param name="requestingUser"></param>
        /// <returns></returns>
        public static int TotalLeaveApprovalRequests(User requestingUser)
        {
            int Result = 0;

            StaffLeave leave = StaffLeave.ApprovalRequests();

            Result = leave.Count;

            return (Result);
        }

        /// <summary>
        /// Number of leave requests that require approval
        /// </summary>
        /// <param name="requestingUser"></param>
        /// <returns></returns>
        public static int TotalLeaveRequests(User requestingUser)
        {
            return (0);
        }
    }
}
