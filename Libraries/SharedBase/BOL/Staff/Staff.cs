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
 *  File: Staff.cs
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

using SharedBase.BOL.Users;

namespace SharedBase.BOL.Staff
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
