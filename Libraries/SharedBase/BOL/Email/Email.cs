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
 *  File: Email.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using SharedBase.BOL;

namespace SharedBase.BOL.Mail
{
	/// <summary>
	/// Summary description for Email.
	/// </summary>
    [Serializable]
    public sealed class Email : BaseObject
	{
		#region Private Members
		
		private Int64 _emailID;
		private string _username;
		private string _toEmail;
		private string _fromName;
		private string _fromEmail;
		private string _subject;
		private string _message;
		private int _priority;
		private DateTime _queueDate;

		#endregion Private Members

		#region Constructor / Destructor

		/// <summary>
		/// Constructor for feeds which include posts
		/// </summary>
		public Email(Int64 EmailID, string Username, string ToEmail, string FromName, 
		             string FromEmail, string Subject, string Message, int Priority, DateTime QueueDate)
		{
			_emailID = EmailID;
			_username = Username;
			_toEmail = ToEmail;
			_fromName = FromName;
			_fromEmail = FromEmail;
			_subject = Subject;
			_message = Message;
			_priority = Priority;
			_queueDate = QueueDate;
		}

		#endregion Constructor / Destructor

		#region Overridden Public Methods

		/// <summary>
		/// Saves the current object
		/// </summary>
		public override void Save()
		{
            //FirebirdDB.AdminUserGroupSave(this);
			throw new Exception("Not Implemented");
		}

		
		/// <summary>
		/// Forces the object to revert previous unchanged state, rolls back any changes
		/// </summary>
		public override void Refresh()
		{
			throw new Exception("Not Implemented");
		}

		#endregion Overridden Public Methods

		#region Properties
		
		
		/// <summary>
		/// 
		/// </summary>
		public DateTime QueueDate
		{
			get
			{
				return _queueDate;
			}
		}

		
		/// <summary>
		/// 
		/// </summary>
		public Int64 EmailID
		{
			get
			{
				return _emailID;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public int Priority
		{
			get
			{
				return _priority;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string Sender
		{
			get
			{
				return _fromEmail;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string FromName
		{
			get
			{
				return _fromName;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string Recipient
		{
			get
			{
				return _toEmail;
			}
		}

		/// <summary>
		/// Subject, retrieves the subject of the feed item.
		/// </summary>
		public string Subject
		{
			get
			{
				return (_subject.Replace("\r", " ").Replace("\n", " ").Replace("\r\n", " "));
			}
		}

		/// <summary>
		/// UserName, retrieves the name of the use who the email is for.
		/// </summary>
		public string UserName
		{
			get
			{
				return (_username);
			}
		}

		/// <summary>
		/// Message, retrieves the email message.
		/// </summary>
		public string Message
		{
			get
			{
				return (_message);
			}
		}

		#endregion Properties

        #region Public Methods

        public void MarkSent(string sendResult)
        {
            DAL.FirebirdDB.EmailMarkSent(this, sendResult);
        }

        public void RecordSentAttempt(string sendResult)
        {
            DAL.FirebirdDB.EmailRecordSentAttempt(this, sendResult);
        }

        #endregion Public Methods
    }
}
