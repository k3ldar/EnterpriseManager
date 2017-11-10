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
 *  File: StaffLeaveRequest.cs
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

using Library.BOL.Appointments;
using Library.BOL.Therapists;
using Library.BOL.Users;
using Shared;

namespace Library.BOL.Staff
{
    [Serializable]
    public sealed class StaffLeaveRequest : BaseObject
	{
		#region Constructors

		/// <summary>
		/// Standard constructor for StaffLeaveRequest
		/// </summary>
		/// <param name="iD">Property Description for Field ID</param>
		/// <param name="userID">Property Description for Field USER_ID</param>
		/// <param name="dateRequested">Property Description for Field DATE_REQUESTED</param>
		/// <param name="dateFrom">Property Description for Field DATE_FROM</param>
		/// <param name="dateTo">Property Description for Field DATE_TO</param>
		/// <param name="totalTime">Property Description for Field TOTAL_TIME</param>
		/// <param name="authorisedBy">Property Description for Field AUTHORISED_BY</param>
		/// <param name="approvedBy">Property Description for Field GRANTED_BY</param>
		/// <param name="notes">Property Description for Field NOTES</param>
		public StaffLeaveRequest (Int64 iD, Int64 userID, 
			DateTime dateRequested, DateTime dateFrom, DateTime dateTo, 
			double totalTime, Int64 authorisedBy, Int64 approvedBy,
            string notes, DateTime dateAuthorised, DateTime dateApproved, LeaveOptions status)
		{
			ID = iD;
			UserID = userID;
			DateRequested = dateRequested;
			DateFrom = dateFrom;
			DateTo = dateTo;
			TotalTime = totalTime;
			AuthorisedBy = authorisedBy;
			ApprovedBy = approvedBy;
			Notes = notes;
            DateAuthorised = dateAuthorised;
            DateApproved = dateApproved;
            Status = status;
		}

		#endregion Constructors

		#region Public Methods

		/// <summary>
		/// Saves the current record
		/// </summary>
        public override void Save()
		{
			Library.DAL.FirebirdDB.StaffLeaveRequestUpdate(this);
		}

		/// <summary>
		/// Deletes the current record
		/// </summary>
		public new bool Delete()
		{
            return (Library.DAL.FirebirdDB.StaffLeaveRequestDelete(this));
		}

        /// <summary>
        /// User authorises leave
        /// </summary>
        /// <param name="authorisingUser"></param>
        public void Authorise(User authorisingUser)
        {
            if (CanAuthorise(authorisingUser))
            {
                this.AuthorisedBy = authorisingUser.ID;
                this.Status = LeaveOptions.None;

                Therapist ther = Therapist.Get(UserID);

                //add leave to diary
                int duration = 0;
                double start;
                double finish;
                Appointment master = null;

                for (DateTime date = this.DateFrom; date <= DateTo; )
                {
                    if (ther.WorkingDay(date, out start, out finish, out duration))
                    {
                        CreateLeaveAppointmentForDay(date, ref master, start, duration, authorisingUser);
                    }
                    else
                    {
                        double s = ther.StartTime;
                        duration = 0;

                        while (s < ther.EndTime)
                        {
                            s += 0.25;
                            duration += 15;
                        }

                        // not working on the day, add with normal hours so can be blocked for future
                        CreateLeaveAppointmentForDay(date, ref master, ther.StartTime, duration, authorisingUser);
                    }

                    date = date.AddDays(1);
                }

                this.Save();
            }
            else
                throw new Exception(Consts.ERROR_INVALID_PERMISSIONS);
        }

        /// <summary>
        /// Determines whether the request can be authorised
        /// </summary>
        /// <param name="authorisingUser"></param>
        /// <returns></returns>
        public bool CanAuthorise(User authorisingUser)
        {
            bool Result = Status == LeaveOptions.None && !IsAuthorised && IsApproved &&
                (authorisingUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.AuthoriseLeave) ||
                authorisingUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.AuthoriseAllLeave));

            return (Result);
        }

        /// <summary>
        /// Request is being approved
        /// </summary>
        /// <param name="approvingUser"></param>
        public void Approve(User approvingUser)
        {
            if (CanApprove(approvingUser))
            {
                this.ApprovedBy = approvingUser.ID;
                this.Status = LeaveOptions.None;
                this.Save();
            }
            else
                throw new Exception(Consts.ERROR_INVALID_PERMISSIONS);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="approvingUser"></param>
        /// <returns></returns>
        public bool CanApprove(User approvingUser)
        {
            bool Result = Status == LeaveOptions.None && !IsAuthorised && !IsApproved &&
                (approvingUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.ApproveLeave) ||
                approvingUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.ApproveAllLeave));

            return (Result);
        }

        /// <summary>
        /// Request is being cancelled
        /// </summary>
        /// <param name="cancellingUser"></param>
        public void Cancel(User cancellingUser)
        {
            if (cancellingUser.ID == this.UserID ||
                cancellingUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.CancelAllLeave))
            {
                this.Status = LeaveOptions.Cancelled;
                Notes += String.Format(Consts.STAFF_LEAVE_NOTES_CANCELLED, cancellingUser.UserName, DateTime.Now.ToString("g"));
                this.Save();
            }
            else
            {
                throw new Exception(Consts.ERROR_INVALID_PERMISSIONS);
            }
        }

        /// <summary>
        /// Determines whether the request can be cancelled
        /// </summary>
        /// <param name="activeUser"></param>
        /// <returns></returns>
        public bool CanCancel(User activeUser)
        {
            bool Result = (this.Status != LeaveOptions.Cancelled && this.Status != LeaveOptions.Denied) && 
                ((activeUser.ID == UserID && (!IsApproved && !IsAuthorised)) ||
                activeUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.CancelAllLeave));

            return (Result);
        }

        /// <summary>
        /// Request is being denied
        /// </summary>
        /// <param name="denyingUser"></param>
        /// <param name="reason"></param>
        public void Deny(User denyingUser, string reason)
        {
            if (CanDeny(denyingUser))
            {
                this.Status = LeaveOptions.Denied;
                Notes += String.Format(Consts.STAFF_LEAVE_NOTES_DENIED, denyingUser.UserName, DateTime.Now.ToString("g"), reason);
                this.Save();
            }
            else
                throw new Exception(Consts.ERROR_INVALID_PERMISSIONS);
        }

        /// <summary>
        /// Determines whether the user can deny the request
        /// </summary>
        /// <param name="denyingUser"></param>
        /// <returns></returns>
        public bool CanDeny(User denyingUser)
        {
            bool Result = this.Status == LeaveOptions.None && 
                (
                    (!this.IsAuthorised &&
                        (
                            denyingUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.AuthoriseLeave) ||
                            denyingUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.AuthoriseAllLeave)
                        )
                    ) ||
                    (!this.IsApproved &&
                        (
                            denyingUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.ApproveLeave) ||
                            denyingUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.ApproveAllLeave)
                        )
                    )
                );

            return (Result);
        }

		/// <summary>
		/// Reloads the current record
		/// </summary>
		public void Reload()
		{
			throw new NotImplementedException();
		}

		#endregion Public Methods

		#region Overridden Methods

		/// <summary>
		/// Returns the String for the class
		/// </summary>
		public override string ToString()
		{
			return (String.Format("STAFF_LEAVE Record {0}", ID));
		}

		#endregion Overridden Methods

		#region Properties

		/// <summary>
		/// Property Description for Field ID
		/// </summary>
		public Int64 ID { get; internal set; }

		/// <summary>
		/// Property Description for Field USER_ID
		/// </summary>
		public Int64 UserID { get; set; }

		/// <summary>
		/// Property Description for Field DATE_REQUESTED
		/// </summary>
		public DateTime DateRequested { get; set; }

		/// <summary>
		/// Property Description for Field DATE_FROM
		/// </summary>
		public DateTime DateFrom { get; set; }

		/// <summary>
		/// Property Description for Field DATE_TO
		/// </summary>
		public DateTime DateTo { get; set; }

		/// <summary>
		/// Property Description for Field TOTAL_TIME
		/// </summary>
        public double TotalTime { get; set; }

		/// <summary>
		/// Property Description for Field AUTHORISED_BY
		/// </summary>
		public Int64 AuthorisedBy { get; set; }

		/// <summary>
		/// Property Description for Field GRANTED_BY
		/// </summary>
		public Int64 ApprovedBy { get; set; }

		/// <summary>
		/// Property Description for Field NOTES
		/// </summary>
		public string Notes { get; set; }

        /// <summary>
        /// Determines if request is approved
        /// </summary>
        public bool IsApproved 
        { 
            get
            {
                return (ApprovedBy > -1);
            }
        }

        /// <summary>
        /// Determines wether the request is authorised
        /// </summary>
        public bool IsAuthorised
        {
            get
            {
                return (AuthorisedBy > -1);
            }
        }

        /// <summary>
        /// Date request authorised
        /// </summary>
        public DateTime DateAuthorised {get; private set; }

        /// <summary>
        /// Date request approved
        /// </summary>
        public DateTime DateApproved { get; private set; }

        /// <summary>
        /// Status
        /// </summary>
        public LeaveOptions Status { get; set; }

		#endregion Properties

        #region Private Methods

        private void CreateLeaveAppointmentForDay(DateTime date, ref Appointment master, double startTime, 
            int duration, User authorising)
        {
            string notes = String.Empty;

            User approver = User.UserGet(ApprovedBy);

            notes += String.Format("Approved By: {0} on {1}",
                approver.UserName, Utilities.FormatDate(DateApproved, 
                System.Threading.Thread.CurrentThread.CurrentUICulture.Name));


            notes += "\r\n\r\n";
            notes += String.Format("Authorised By: {0} on {1}",
                authorising.UserName, Utilities.FormatDate(DateTime.Now, 
                System.Threading.Thread.CurrentThread.CurrentUICulture.Name));

            if (master == null)
            {
                master = new Appointment(-1, UserID, date, startTime, duration, Enums.AppointmentStatus.Confirmed, 2, 0, String.Empty,
                    UserID, String.Empty, String.Empty, -1, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));
                master.Notes = notes;
                master.LockedBy = authorising.ID;
                master.Save(authorising);
            }
            else
            {
                Appointment appt = new Appointment(-1, UserID, date, startTime, duration, Enums.AppointmentStatus.Confirmed, 2, 0, String.Empty,
                    UserID, String.Empty, String.Empty, master.ID, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));
                appt.Notes = notes;
                appt.LockedBy = authorising.ID;
                appt.Save(authorising);
            }
        }

        #endregion Private Methods
    }
}