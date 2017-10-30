

using System;

namespace Library.BOL.Mail
{
	#region EventArgs


	/// <summary>
	/// Error Event Arguments
	/// </summary>
	public sealed class EmailEventArgs: EventArgs
	{
		#region Private Members

		int _messagesRemaining = 0;
		int _messagesSent = 0;
		string _message = string.Empty;

		#endregion Private Members

		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		public EmailEventArgs()
		{
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Sent"></param>
		/// <param name="Remaining"></param>
		public EmailEventArgs(int Sent, int Remaining)
		{
			_messagesSent = Sent;
			_messagesRemaining = Remaining;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Sent"></param>
		/// <param name="Remaining"></param>
		/// <param name="Message"></param>
		public EmailEventArgs(int Sent, int Remaining, string Message) : this (Sent, Remaining)
		{
			_message = Message;
		}

		#endregion Constructor

		#region Properties

		/// <summary>
		/// Gets/Sets the number of emails sent
		/// </summary>
		public int MessagesSent
		{
			get
			{
				return _messagesSent;
			}
			set
			{
				_messagesSent = value;
			}
		}
		
		/// <summary>
		/// Gets/Sets the number of emails waiting to be sent
		/// </summary>
		public int MessagesRemaining
		{
			get
			{
				return _messagesRemaining;
			}
			set
			{
				_messagesRemaining = value;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string Message
		{
			get
			{
				return _message;
			}
			set 
			{
				_message = value;
			}
		}
		
		/// <summary>
		/// Gets the total number of emails
		/// </summary>
		public int MessagesTotal
		{
			get
			{
				return _messagesSent + _messagesRemaining;
			}
		}

		#endregion Properties
	}
	
	/// <summary>
	/// Email Status Report Event Arguments
	/// </summary>
	public sealed class EmailStatusReportEventArgs : EventArgs
	{
		#region Private Members

		int _index = 0;
		DateTime _starttime;
		TimeSpan _duration;
		int _sent;
		bool _status; 

		#endregion Private Members

		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="StatusReportPosition"></param>
		/// <param name="StartTime"></param>
		/// <param name="Duration"></param>
		/// <param name="NumberSent"></param>
		/// <param name="Status"></param>
		public EmailStatusReportEventArgs(int StatusReportPosition, DateTime StartTime, TimeSpan Duration, int NumberSent, bool Status) 
			: this(StatusReportPosition)
		{
			_starttime = StartTime;
			_duration = Duration;
			_sent = NumberSent;
			_status = Status;
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="StatusReportPosition"></param>
		public EmailStatusReportEventArgs(int StatusReportPosition)
		{
			_index = StatusReportPosition;
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public EmailStatusReportEventArgs()
		{
			
		}

		#endregion Constructor

		#region Properties

		/// <summary>
		/// Index of status report
		/// </summary>
		public int Index
		{
			get
			{
				return _index;
			}
		}

		/// <summary>
		/// Gets/Sets the status Report Start Time
		/// </summary>
		public DateTime StartTime
		{
			get
			{
				return _starttime;
			}
			set
			{
				_starttime = value;
			}
		}
		
		/// <summary>
		/// Gets/Sets the time taken to send email
		/// </summary>
		public TimeSpan Duration
		{
			get
			{
				return _duration;
			}
			set
			{
				_duration = value;
			}
		}
		
		/// <summary>
		/// Gets/Sets the number of emails transmitted during this report
		/// </summary>
		public int NumberSent
		{
			get
			{
				return _sent;
			}
			set
			{
				_sent = value;
			}
		}
		
		/// <summary>
		/// Gets/Sets the status report was fully generated
		/// </summary>
		public bool Status
		{
			get
			{
				return _status;
			}
			set
			{
				_status = value;
			}
		}
		
		#endregion Properties
	}

	#endregion EventArgs

	#region Delegates

	
	/// <summary>
	/// Email Sent delegate, for successful transmission of an email to the server
	/// </summary>
	public delegate void EventEmailSent(object sender, EmailEventArgs e);

	/// <summary>
	/// Email Report Selection Changed
	/// </summary>
	public delegate void EventEmailReportChanged(object sender, EmailStatusReportEventArgs e);
	
	#endregion Delegates
}
