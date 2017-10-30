using System;

using Library.BOL.Users;

namespace Library.BOL.Staff
{
    [Serializable]
	public sealed class StaffMember : BaseObject
    {
        #region Private Members

        private StaffLeave _staffLeave;
        private User _staffMember;

        #endregion Private Members

        #region Constructors

        public StaffMember(Int64 id)
        {
            UserID = id;
        }

        public StaffMember()
        {
            EmergencyContactName = String.Empty;
            EmergencyContactRelationship = String.Empty;
            EmergencyContactTelephone = String.Empty;

            TelephoneHome = String.Empty;
            TelephoneMobile = String.Empty;
            TelephoneOther = String.Empty;
            TelephoneWork = String.Empty;

            DrivingLicenceNotes = String.Empty;
            DrivingLicenceNumber = String.Empty;
        }

        public StaffMember(User user, string title,
            string location, bool partTime, decimal weeklyHours,
            string payrollNumber, PayPeriod payPeriod, decimal leaveEntitlement,
            bool entitlementType, bool leaveAccrues, bool leaveCarryOver,
            GenderType gender, MaritalStatus maritalStatus, int nationality, DateTime dateOfBirth,
            string emergencyContactName, string emergencyContactTelephone, string emergencyContactRelationship,
            string drivingLicenceNumber, DateTime drivingLicenceExpire, string telephoneHome, string telephoneMobile,
            string telephoneWork, string telephoneOther, DateTime dateJoined, DateTime dateProbationEnd,
            DateTime datePermanent, Int64 properties, string drivingLicenceNotes, DateTime lastUpdated,
            EmploymentType employmentType, decimal commissionRate, decimal managerCommissionRate)
            : this(user.ID, title,
            location, partTime, weeklyHours,
            payrollNumber, payPeriod, leaveEntitlement,
            entitlementType, leaveAccrues, leaveCarryOver,
            gender, maritalStatus, nationality, dateOfBirth,
            emergencyContactName, emergencyContactTelephone, emergencyContactRelationship,
            drivingLicenceNumber, drivingLicenceExpire, telephoneHome, telephoneMobile,
            telephoneWork, telephoneOther, dateJoined, dateProbationEnd,
            datePermanent, properties, drivingLicenceNotes, lastUpdated,
            employmentType, commissionRate, managerCommissionRate)
        {
            _staffMember = user;
        }

        public StaffMember(User user)
            : this(user.ID, String.Empty, String.Empty, false, 37.5m, String.Empty, PayPeriod.Monthly, 
                    0, false, false, false, 0, MaritalStatus.Single, 0, DateTime.Now.AddYears(-18), String.Empty,
                    String.Empty, String.Empty, String.Empty, DateTime.Now, String.Empty, String.Empty,
                    String.Empty, String.Empty, DateTime.Now.AddYears(-1000), DateTime.Now.AddYears(-1000), 
                    DateTime.Now.AddYears(-1000), 0, String.Empty, DateTime.Now.AddDays(-500),
                    EmploymentType.Voluntary, 0, 0)
        {
            _staffMember = user;
        }

		/// <summary>
		/// Standard constructor for StaffMember
		/// </summary>
		/// <param name="userID">Property Description for Field USER_ID</param>
		/// <param name="title">Property Description for Field TITLE</param>
		/// <param name="location">Property Description for Field LOCATION</param>
		/// <param name="partTime">Property Description for Field PART_TIME</param>
		/// <param name="weeklyHours">Property Description for Field WEEKLY_HOURS</param>
		/// <param name="payrollNumber">Property Description for Field PAYROLL_NUMBER</param>
		/// <param name="payPeriod">Property Description for Field PAY_PERIOD</param>
		/// <param name="leaveEntitlement">Property Description for Field LEAVE_ENTITLEMENT</param>
		/// <param name="entitlementType">Property Description for Field ENTITLEMENT_TYPE</param>
		/// <param name="leaveAccrues">Property Description for Field LEAVE_ACCRUES</param>
		/// <param name="leaveCarryOver">Property Description for Field LEAVE_CARRY_OVER</param>
		/// <param name="gender">Property Description for Field GENDER</param>
		/// <param name="maritalStatus">Property Description for Field MARITAL_STATUS</param>
		/// <param name="nationality">Property Description for Field NATIONALITY</param>
		/// <param name="dateOfBirth">Property Description for Field DATE_OF_BIRTH</param>
		/// <param name="emergencyContactName">Property Description for Field EMERGENCY_CONTACT_NAME</param>
		/// <param name="emergencyContactTelephone">Property Description for Field EMERGENCY_CONTACT_TELEPHONE</param>
		/// <param name="emergencyContactRelationship">Property Description for Field EMERGENCY_CONTACT_RELATIONSHIP</param>
		/// <param name="drivingLicenceNumber">Property Description for Field DL_NUMBER</param>
		/// <param name="drivingLicenceExpire">Property Description for Field DL_EXPIRE</param>
		/// <param name="telephoneHome">Property Description for Field TEL_HOME</param>
		/// <param name="telephoneMobile">Property Description for Field TEL_MOBILE</param>
		/// <param name="telephoneWork">Property Description for Field TEL_WORK</param>
		/// <param name="telephoneOther">Property Description for Field TEL_OTHER_1</param>
		/// <param name="dateJoined">Property Description for Field DATE_JOINED</param>
		/// <param name="dateProbationEnd">Property Description for Field DATE_PROBATION_END</param>
		/// <param name="datePermanent">Property Description for Field DATE_PERMANENT</param>
		/// <param name="properties">Property Description for Field PROPERTIES</param>
		public StaffMember (Int64 userID, string title, 
			string location, bool partTime, decimal weeklyHours,
            string payrollNumber, PayPeriod payPeriod, decimal leaveEntitlement, 
			bool entitlementType, bool leaveAccrues, bool leaveCarryOver,
            GenderType gender, MaritalStatus maritalStatus, int nationality, DateTime dateOfBirth, 
            string emergencyContactName, string emergencyContactTelephone, string emergencyContactRelationship, 
            string drivingLicenceNumber, DateTime drivingLicenceExpire, string telephoneHome, string telephoneMobile, 
            string telephoneWork, string telephoneOther, DateTime dateJoined, DateTime dateProbationEnd,
            DateTime datePermanent, Int64 properties, string drivingLicenceNotes, DateTime lastUpdated,
            EmploymentType employmentType, decimal commissionRate, decimal managerCommissionRate)
		{
			UserID = userID;
			Title = title;
			Location = location;
			PartTime = partTime;
			WeeklyHours = weeklyHours;
			PayrollNumber = payrollNumber;
			PayPeriod = payPeriod;
			LeaveEntitlement = leaveEntitlement;
			EntitlementType = entitlementType;
			LeaveAccrues = leaveAccrues;
			LeaveCarryOver = leaveCarryOver;
			Gender = gender;
			MaritalStatus = maritalStatus;
			Nationality = nationality;
			DateOfBirth = dateOfBirth;
			EmergencyContactName = emergencyContactName;
			EmergencyContactTelephone = emergencyContactTelephone;
			EmergencyContactRelationship = emergencyContactRelationship;
			DrivingLicenceNumber = drivingLicenceNumber;
			DrivingLicenceExpire = drivingLicenceExpire;
			TelephoneHome = telephoneHome;
			TelephoneMobile = telephoneMobile;
			TelephoneWork = telephoneWork;
			TelephoneOther = telephoneOther;
			DateJoined = dateJoined;
			DateProbationEnd = dateProbationEnd;
			DatePermanent = datePermanent;
			Properties = properties;
            DrivingLicenceNotes = drivingLicenceNotes;
            LastUpdated = lastUpdated;
            EmploymentType = employmentType;
            CommissionRate = commissionRate;
            ManagerCommissionRate = managerCommissionRate;
		}

		#endregion Constructors

		#region Public Methods

		/// <summary>
		/// Saves the current record
		/// </summary>
        public override void Save()
		{
            DAL.FirebirdDB.StaffMemberUpdate(this);
            CacheClear();
		}

		/// <summary>
		/// Deletes the current record
		/// </summary>
        public new bool Delete()
		{
			return (DAL.FirebirdDB.StaffMemberDelete(this));
		}


		/// <summary>
		/// Reloads the current record
		/// </summary>
		public void Reload()
		{
            _staffLeave = null;
		}


        public decimal LeaveRemaining()
        {
            decimal Result = LeaveEntitlement;

#warning finish this off - go through all leave records and see what is used

            return (Result);
        }


        public Users.Users GetStaff()
        {
            return (Staff.ManagerGetStaff(this));
        }

		#endregion Public Methods

		#region Overridden Methods

		/// <summary>
		/// Returns the String for the class
		/// </summary>
		public override string ToString()
		{
			return (String.Format("STAFF_MEMBERS Record {0}", UserID));
		}

		#endregion Overridden Methods

		#region Properties

		/// <summary>
		/// Property Description for Field USER_ID
		/// </summary>
		public Int64 UserID { get; set; }

		/// <summary>
		/// Property Description for Field TITLE
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Property Description for Field LOCATION
		/// </summary>
		public string Location { get; set; }

		/// <summary>
		/// Property Description for Field PART_TIME
		/// </summary>
		public bool PartTime { get; set; }

		/// <summary>
		/// Property Description for Field WEEKLY_HOURS
		/// </summary>
		public decimal WeeklyHours { get; set; }

		/// <summary>
		/// Property Description for Field PAYROLL_NUMBER
		/// </summary>
		public string PayrollNumber { get; set; }

		/// <summary>
		/// Property Description for Field PAY_PERIOD
		/// </summary>
        public PayPeriod PayPeriod { get; set; }

        /// <summary>
        /// Type of employment
        /// </summary>
        public EmploymentType EmploymentType { get; set; }

		/// <summary>
		/// Property Description for Field LEAVE_ENTITLEMENT
		/// </summary>
		public decimal LeaveEntitlement { get; set; }

		/// <summary>
		/// Property Description for Field ENTITLEMENT_TYPE
		/// </summary>
		public bool EntitlementType { get; set; }

		/// <summary>
		/// Property Description for Field LEAVE_ACCRUES
		/// </summary>
		public bool LeaveAccrues { get; set; }

		/// <summary>
		/// Property Description for Field LEAVE_CARRY_OVER
		/// </summary>
		public bool LeaveCarryOver { get; set; }

		/// <summary>
		/// Property Description for Field GENDER
		/// </summary>
		public GenderType Gender { get; set; }

		/// <summary>
		/// Property Description for Field MARITAL_STATUS
		/// </summary>
        public MaritalStatus MaritalStatus { get; set; }

		/// <summary>
		/// Property Description for Field NATIONALITY
		/// </summary>
		public int Nationality { get; set; }

		/// <summary>
		/// Property Description for Field DATE_OF_BIRTH
		/// </summary>
		public DateTime DateOfBirth { get; set; }

		/// <summary>
		/// Property Description for Field EMERGENCY_CONTACT_NAME
		/// </summary>
		public string EmergencyContactName { get; set; }

		/// <summary>
		/// Property Description for Field EMERGENCY_CONTACT_TELEPHONE
		/// </summary>
		public string EmergencyContactTelephone { get; set; }

		/// <summary>
		/// Property Description for Field EMERGENCY_CONTACT_RELATIONSHIP
		/// </summary>
		public string EmergencyContactRelationship { get; set; }

		/// <summary>
		/// Property Description for Field DL_NUMBER
		/// </summary>
		public string DrivingLicenceNumber { get; set; }

		/// <summary>
		/// Property Description for Field DL_EXPIRE
		/// </summary>
		public DateTime DrivingLicenceExpire { get; set; }

        /// <summary>
        /// Driving licence notes
        /// </summary>
        public string DrivingLicenceNotes { get; set; }

		/// <summary>
		/// Property Description for Field TEL_HOME
		/// </summary>
		public string TelephoneHome { get; set; }

		/// <summary>
		/// Property Description for Field TEL_MOBILE
		/// </summary>
		public string TelephoneMobile { get; set; }

		/// <summary>
		/// Property Description for Field TEL_WORK
		/// </summary>
		public string TelephoneWork { get; set; }

		/// <summary>
		/// Property Description for Field TEL_OTHER_1
		/// </summary>
		public string TelephoneOther { get; set; }

		/// <summary>
		/// Property Description for Field DATE_JOINED
		/// </summary>
		public DateTime DateJoined { get; set; }

		/// <summary>
		/// Property Description for Field DATE_PROBATION_END
		/// </summary>
		public DateTime DateProbationEnd { get; set; }

		/// <summary>
		/// Property Description for Field DATE_PERMANENT
		/// </summary>
		public DateTime DatePermanent { get; set; }

		/// <summary>
		/// Property Description for Field PROPERTIES
		/// </summary>
		public Int64 Properties { get; set; }

        /// <summary>
        /// Date/Time the record was last updated
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Annual Leave Requests for staff member
        /// </summary>
        public StaffLeave AnnualLeave
        {
            get
            {
                if (_staffLeave == null)
                    _staffLeave = StaffLeave.All(_staffMember);

                return (_staffLeave);
            }
        }

        /// <summary>
        /// Level of commission paid to the staff member
        /// </summary>
        public decimal CommissionRate { get; set; }

        /// <summary>
        /// Amount of commission paid to the employee's manager
        /// </summary>
        public decimal ManagerCommissionRate { get; set;}


        public User UserRecord
        {
            get
            {
                if (_staffMember == null)
                    _staffMember = User.UserGet(UserID);

                return (_staffMember);
            }
        }

		#endregion Properties
	}
}