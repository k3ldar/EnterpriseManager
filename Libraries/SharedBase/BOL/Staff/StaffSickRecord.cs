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
 *  File: StaffSickRecord.cs
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

namespace SharedBase.BOL.Staff
{
    [Serializable]
    public sealed class StaffSickRecord : BaseObject
	{
		#region Constructors

		/// <summary>
		/// Standard constructor for StaffSickRecord
		/// </summary>
		/// <param name="iD">Property Description for Field ID</param>
		/// <param name="userID">Property Description for Field USER_ID</param>
		/// <param name="dateStarted">Property Description for Field DATE_STARTED</param>
		/// <param name="dateFinished">Property Description for Field DATE_FINISHED</param>
		/// <param name="dateNotified">Property Description for Field DATE_NOTIFIED</param>
		/// <param name="returnInterviewCompleted">Property Description for Field RETURN_INTERVIEW_COMPLETED</param>
		/// <param name="returnInterviewer">Property Description for Field RETURN_INTERVIEWER</param>
		/// <param name="notes">Property Description for Field NOTES</param>
		/// <param name="reasonCited">Property Description for Field REASON_CITED</param>
		/// <param name="certificate">Property Description for Field CERTIFICATE</param>
		/// <param name="preBooked">Property Description for Field PRE_BOOKED</param>
		/// <param name="properties">Property Description for Field PROPERTIES</param>
		public StaffSickRecord (Int64 iD, Int64 userID, 
			DateTime dateStarted, DateTime dateFinished, DateTime dateNotified, 
			bool returnInterviewCompleted, Int64 returnInterviewer, string notes, 
			string reasonCited, bool certificate, bool preBooked,
            SickOptions properties)
		{
			ID = iD;
			UserID = userID;
			DateStarted = dateStarted;
			DateFinished = dateFinished;
			DateNotified = dateNotified;
			ReturnInterviewCompleted = returnInterviewCompleted;
			ReturnInterviewer = returnInterviewer;
			Notes = notes;
			ReasonCited = reasonCited;
			Certificate = certificate;
			PreBooked = preBooked;
			Properties = properties;

		}

        public StaffSickRecord(Int64 iD, Int64 userID, DateTime dateStarted, DateTime dateNotified,
            string notes, string reasonCited, bool certificate, bool preBooked)
        {
            ID = iD;
            UserID = userID;
            DateStarted = dateStarted;
            DateNotified = dateNotified;
            Notes = notes;
            ReasonCited = reasonCited;
            Certificate = certificate;
            PreBooked = preBooked;
        }

		#endregion Constructors

		#region Public Methods

		/// <summary>
		/// Saves the current record
		/// </summary>
		public override void Save()
		{
            DAL.FirebirdDB.StaffSickRecordUpdate(this);
		}

		/// <summary>
		/// Deletes the current record
		/// </summary>
		public new bool Delete()
		{
			return (DAL.FirebirdDB.StaffSickRecordDelete(this));
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
			return (String.Format("STAFF_SICK_RECORDS Record {0}", ID));
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
		/// Property Description for Field DATE_STARTED
		/// </summary>
		public DateTime DateStarted { get; set; }

		/// <summary>
		/// Property Description for Field DATE_FINISHED
		/// </summary>
		public DateTime DateFinished { get; set; }

		/// <summary>
		/// Property Description for Field DATE_NOTIFIED
		/// </summary>
		public DateTime DateNotified { get; set; }

		/// <summary>
		/// Property Description for Field RETURN_INTERVIEW_COMPLETED
		/// </summary>
		public bool ReturnInterviewCompleted { get; set; }

		/// <summary>
		/// Property Description for Field RETURN_INTERVIEWER
		/// </summary>
		public Int64 ReturnInterviewer { get; set; }

		/// <summary>
		/// Property Description for Field NOTES
		/// </summary>
		public string Notes { get; set; }

		/// <summary>
		/// Property Description for Field REASON_CITED
		/// </summary>
		public string ReasonCited { get; set; }

		/// <summary>
		/// Property Description for Field CERTIFICATE
		/// </summary>
		public bool Certificate { get; set; }

		/// <summary>
		/// Property Description for Field PRE_BOOKED
		/// </summary>
		public bool PreBooked { get; set; }

		/// <summary>
		/// Property Description for Field PROPERTIES
		/// </summary>
        public SickOptions Properties { get; set; }

		#endregion Properties
	}
}