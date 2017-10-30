using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.Users;
using Library.BOL.Treatments;

namespace Library.BOL.Appointments
{
    [Serializable]
	public sealed class WaitingList : BaseObject
    {
        #region Private Members

        private User _staffMember;

        private AppointmentTreatments _treatments;

        private User _customer;

        #endregion Private Members

        #region Constructors

        /// <summary>
		/// Standard constructor for WaitingList
		/// </summary>
		/// <param name="iD">Property Description for Field ID</param>
		/// <param name="userID">Property Description for Field USER_ID</param>
		/// <param name="staffID">Property Description for Field STAFF_ID</param>
		/// <param name="notes">Property Description for Field NOTES</param>
		/// <param name="expires">Property Description for Field EXPIRES</param>
		/// <param name="lastReviewed">Property Description for Field LAST_REVIEWED</param>
		/// <param name="reviewedBy">Property Description for Field REVIEWED_BY</param>
		/// <param name="preferredDate">Property Description for Field PREFERRED_DATE</param>
		/// <param name="preferredTime">Property Description for Field PREFERRED_TIME</param>
		public WaitingList (Int64 iD, Int64 userID, 
			Int64 staffID, string notes, DateTime expires, 
			DateTime lastReviewed, Int64 reviewedBy, DateTime preferredDate, 
			double preferredTime)
		{
			ID = iD;
			UserID = userID;
			StaffID = staffID;
			Notes = notes;
			Expires = expires;
			LastReviewed = lastReviewed;
			ReviewedBy = reviewedBy;
			PreferredDate = preferredDate;
			PreferredTime = preferredTime;
		}

        public WaitingList ()
        {
            ID = -1;
            UserID = -1;
            StaffID = -1;
            Notes = String.Empty;
            Expires = DateTime.Now.AddDays(30);
            PreferredDate = DateTime.Now.AddDays(1);
            PreferredTime = 0.00d;
        }

		#endregion Constructors

		#region Public Methods

		/// <summary>
		/// Saves the current record
		/// </summary>
        public override void Save()
		{
			DAL.FirebirdDB.WaitingListUpdate(this);
		}

		/// <summary>
		/// Deletes the current record
		/// </summary>
        public new bool Delete()
		{
            return (DAL.FirebirdDB.WaitingListDelete(this));
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
			return (String.Format("WS_APPOINTMENT_WAIT_LIST_LONG Record {0}", ID));
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
        /// Gets the Customer record
        /// </summary>
        public User Customer
        {
            get
            {
                if (_customer == null)
                    _customer = User.UserGet(UserID);

                return (_customer);
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                _customer = value;
                UserID = _customer.ID;
            }
        }


		/// <summary>
		/// Property Description for Field STAFF_ID
		/// </summary>
		public Int64 StaffID { get; set; }

        /// <summary>
        /// Gets the staff member record
        /// </summary>
        public User StaffMember
        {
            get
            {
                if (_staffMember == null)
                    _staffMember = User.UserGet(StaffID);

                return (_staffMember);
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                _staffMember = value;
                StaffID = _staffMember.ID;
            }
        }

		/// <summary>
		/// Property Description for Field NOTES
		/// </summary>
		public string Notes { get; set; }

		/// <summary>
		/// Property Description for Field EXPIRES
		/// </summary>
		public DateTime Expires { get; set; }

		/// <summary>
		/// Property Description for Field LAST_REVIEWED
		/// </summary>
		public DateTime LastReviewed { get; set; }

		/// <summary>
		/// Property Description for Field REVIEWED_BY
		/// </summary>
		public Int64 ReviewedBy { get; set; }

		/// <summary>
		/// Property Description for Field PREFERRED_DATE
		/// </summary>
		public DateTime PreferredDate { get; set; }

		/// <summary>
		/// Property Description for Field PREFERRED_TIME
		/// </summary>
		public double PreferredTime { get; set; }

        /// <summary>
        /// List of treatments for the users
        /// </summary>
        public AppointmentTreatments Treatments
        {
            get
            {
                if (_treatments == null)
                    _treatments = AppointmentTreatments.Get(this);

                return (_treatments);
            }
        }

		#endregion Properties
	}
}