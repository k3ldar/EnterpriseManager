#region License
// dnfBB 
// 
// The contents of this file are subject to the Initial Developer's Public License Version 1.0 
// (the "License"); you may not use this file except in compliance with the License. You may 
// obtain a copy of the License from dnfBB Project website.
// 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT 
// WARRANTY OF ANY KIND, either express or implied. See the License for the specific language 
// governing rights and limitations under the License.
// 
// The Original Code is part of dnfBB .
// 
// The Initial Developer of the Original Code is Simon Bosanquet.
// 
// Portions created by Simon Bosanquet are 
// Copyright (C) 2005 - 2006.  Simon Bosanquet. All Rights Reserved.
// 
// All Rights Reserved.
// 
// Contributor(s): Simon Bosanquet.

#endregion License

using System;

namespace Website.Library.Classes.Status
{
	/// <summary>
	/// Class representing Single entry in the Send status report
	/// </summary>
	public class StatusReportEntry
	{
		
		#region Constructor
		
		/// <summary>
		/// 
		/// </summary>
		public StatusReportEntry()
		{
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Message"></param>
		/// <param name="To"></param>
		public StatusReportEntry(string Message, string To)
		{
			this._subject = Message;
			this._msgTo = To;
			this._id = 0; 
		}
		
		#endregion
		
		#region Private Members
		
		private string _subject = string.Empty;
		private string _msgTo = string.Empty;
		private int _id = -1;
		private DateTime _time = DateTime.Now;
					
		#endregion
					
		#region Publc Properties
			
		/// <summary>
		/// Status Report Message Subject
		/// </summary>
		public string Subject
		{
			get
			{
				return _subject;
			}
			set
			{
				_subject = value;
			}
		}
		
		/// <summary>
		/// Status Report To field
		/// </summary>
		public string To
		{
			get
			{
				return _msgTo;
			}
			set
			{
				_msgTo = value;
			}
		}
		
		/// <summary>
		/// Status Report Message ID
		/// </summary>
		public int ID
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
			}
		}
		
		/// <summary>
		/// Status report message timestamp
		/// </summary>
		public DateTime Time
		{
			get
			{
				return _time;
			}
		}
		
		#endregion
	
	}
	
}
