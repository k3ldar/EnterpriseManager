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
