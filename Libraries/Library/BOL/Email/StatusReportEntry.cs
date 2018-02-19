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
 *  File: StatusReportEntry.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

namespace Library.BOL.Mail
{
	/// <summary>
	/// Class representing Single entry in the Send status report
	/// </summary>
    [Serializable]
    public sealed class StatusReportEntry : BaseObject
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
