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
 *  File: EmailStatusReport.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections;

namespace Library.BOL.Mail
{
	/// <summary>
	/// Class contains report information for the current send attempt
	/// </summary>
    [Serializable]
    public sealed class EmailStatusReport : BaseCollection
	{
		#region Constructor
		
		/// <summary>
		/// Contructor
		/// </summary>
		public EmailStatusReport()
		{
			starttime = DateTime.Now;
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="report"></param>
		public EmailStatusReport(StatusReportEntry report) : this()
		{
			this.Add(report);
		}
		
		#endregion
		
		#region Private Members
		
		private const string OBJECT_TYPE = "Library.BOL.Mail.StatusReportEntry";
		private const string OBJECT_TYPE_ERROR = "Must be of type StatusReportEntry";
		private int index = 0;
		private DateTime starttime;
		private DateTime endtime;
		private bool complete = false;
		private int unsentMessages = 0;
		private int queuesize = 0;
		
		#endregion
	
		#region Public Properties
		
		/// <summary>
		/// Indicates that the report is complete
		/// </summary>
		public bool Complete
		{
			get
			{
				return complete;
			}
		}
		
		/// <summary>
		/// Get the report start time
		/// </summary>
		public DateTime StartTime
		{
			get
			{
				return starttime;
			}
		}
		
		/// <summary>
		/// Gte the report end time
		/// </summary>
		public DateTime EndTime
		{
			get
			{
				return endtime;
			}
		}
		
		/// <summary>
		/// Get the length of time in seconds it took to send the email and generate the report
		/// </summary>
		public int Duration
		{
			get
			{
				if (endtime > starttime)
				{
					TimeSpan dur = endtime - starttime;
					return (dur.Hours*60*60) + (dur.Minutes*60) + dur.Seconds;
				}
				else
					return -1;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public StatusReportEntry this[int index]
		{
			get  
			{ 
				return((StatusReportEntry) List[index]);
			}
			set
			{ 
				List[index] = value;
			}
		}
		
		/// <summary>
		/// Get the number of unsent messages
		/// </summary>
		public int UnsentMessages
		{
			get
			{
				return unsentMessages;
			}
			set
			{
				unsentMessages = value;
			}
		}
		
		/// <summary>
		/// Get the number of items in the queue
		/// </summary>
		public int InitialQueueSize
		{
			get
			{
				return queuesize;
			}
			set
			{
				queuesize = value;
			}
		}
		
		#endregion
		
		#region Public Methods
		
		/// <summary>
		/// Marks the object as complete
		/// </summary>
		/// <returns>Completion Time</returns>
		public DateTime ReportComplete()
		{
			endtime = DateTime.Now;
			complete = true;
			return endtime;
		}
		
		/// <summary>
		/// Adds an item to the collection
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public int Add(StatusReportEntry value) 
		{
			StatusReportEntry msg = value;
			msg.ID = index + 1;
			index++;
			return(List.Add(msg));
		}
	
		/// <summary>
		/// Returns the index of an item within the collection
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public int IndexOf(StatusReportEntry value) 
		{
			return(List.IndexOf(value));
		}
		
		/// <summary>
		/// Inserts an item into the collection
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		public void Insert(int index, StatusReportEntry value) 
		{
			List.Insert(index, value);
		}
	
	
		/// <summary>
		/// Removes an item from the collection
		/// </summary>
		/// <param name="value"></param>
		public void Remove(StatusReportEntry value) 
		{
			index--;
			List.Remove(value);
		}
	
	
		/// <summary>
		/// Indicates the existence of an item within the collection
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Contains(StatusReportEntry value) 
		{
			// If value is not of type OBJECT_TYPE, this will return false.
			return(List.Contains(value));
		}
		
		#endregion
		
		#region Overridden Methods
	
		/// <summary>
		/// When Inserting an Item
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		protected override void OnInsert(int index, Object value) 
		{
			if (value.GetType() != Type.GetType(OBJECT_TYPE))
				throw new ArgumentException(OBJECT_TYPE_ERROR, "value");
		}
	
	
		/// <summary>
		/// When removing an item
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		protected override void OnRemove(int index, Object value) 
		{
			if (value.GetType() != Type.GetType(OBJECT_TYPE))
				throw new ArgumentException(OBJECT_TYPE_ERROR, "value");
		}
	
	
		/// <summary>
		/// When Setting an Item
		/// </summary>
		/// <param name="index"></param>
		/// <param name="oldValue"></param>
		/// <param name="newValue"></param>
		protected override void OnSet(int index, Object oldValue, Object newValue)
		{
			if (newValue.GetType() != Type.GetType(OBJECT_TYPE))
				throw new ArgumentException(OBJECT_TYPE_ERROR, "newValue");
		}
	
	
		/// <summary>
		/// Validates an object
		/// </summary>
		/// <param name="value"></param>
		protected override void OnValidate(Object value) 
		{
			if (value.GetType() != Type.GetType(OBJECT_TYPE))
				throw new ArgumentException(OBJECT_TYPE_ERROR);
		}
	
	
		#endregion Overridden Methods
		
	}
}
