using System;
using Library.Utils;

namespace Library.BOL.Mail
{
	/// <summary>
	/// Description of EmailSettingsSingletonClass.
	/// </summary>
    [Serializable]
    public class EmailSettingsSingletonClass : BaseSettingsClass
	{
		#region Private Constants
		
		private const string DB_STRING_SETTINGS_CATEGORY = "Mail";
		private const string DB_STRING_MAX_SEND_ATTEMPTS = "Email Max Send Attempts";
		private const string DB_STRING_REMOVE_SENT_EMAILS = "Remove Sent Emails";
		private const string DB_STRING_TRANSMIT_PERIOD = "Email Transmit Period";
		private const string DB_STRING_EMAIL_ENABLED = "Internal Email Enabled";
		private const string DB_STRING_SMTP_SERVER = "SMTP Server";
		private const string DB_STRING_SMTP_USERNAME = "SMTP Username";
		private const string DB_STRING_SMTP_PASSWORD = "SMTP Password";
		private const string DB_STRING_SMTP_SERVER_PORT = "SMTP Server Port";
		private const string DB_STRING_HTML_EMAILS = "HTML Emails";
		private const string DB_STRING_SSL_SERVER_CONNECTION = "SMTP SSL Connection";
		
		#endregion Private Constants
		
		#region Private Static Members
		
		private static EmailSettingsSingletonClass instance;
		
		#endregion Private Static Members
		
		#region Private Members
		
		private string smtpServer = string.Empty;
		private string smtpUsername = string.Empty;
		private string smtpPassword = string.Empty;
		
		private int smtpPort = 25;
		private int emailSendtime = 5; // 5 Minutes
		
		private bool htmlEmails = false;
		private bool smtpSsl = false;
		private bool emailEnabled = false;	
		private bool emailRemoveSentMail = false;
		
		private Int16 emailMaxSendAttempts = 10;
		
		#endregion Private Members
		
		#region Constructors / Destructors
		
		/// <summary>
		/// Private constructor for EmailSettingsSingletonClass.
		/// </summary>
        private EmailSettingsSingletonClass(string Host, int Port, string UserName, string Password, bool UseSSL)
		{
			loadError = LoadSettings(Host, Port, UserName, Password, UseSSL);
		}
		

		#endregion Constructors / Destructors
		
		#region Public Static Methods
		
		/// <summary>
		/// Return the instance of the email settings singleton class
		/// </summary>
        public static EmailSettingsSingletonClass GetInstance(string Host, int Port, string UserName, string Password, bool UseSSL)
		{
			if (instance == null)
			{
				numOfReference++;
				instance = new EmailSettingsSingletonClass(Host, Port, UserName, Password, UseSSL);
			}
				
            return instance;
		}
		

		#endregion Public Static Methods
				
		#region Public Properties	

		/// <summary>
		/// Get/Set maximum number of send attempts per email
		/// </summary>
		public Int16 EmailMaxSendAttempt
		{
			get
			{
				return emailMaxSendAttempts;
			}
			set
			{
				emailMaxSendAttempts = value;
			}
		}


		/// <summary>
		/// Get/Set option to remove sent mail after transmission
		/// </summary>
		public bool EmailRemoveSentMail
		{
			get
			{
				return emailRemoveSentMail;
			}
			set
			{
				emailRemoveSentMail = value;
			}
		}
		

		/// <summary>
		/// Get/Set period of email transmission in minutes
		/// </summary>
		public int EmailSendPeriod
		{
			get
			{
				return (emailSendtime);
			}
			set
			{
				emailSendtime = value;
			}
		}
				

		/// <summary>
		/// Get/Set Email Enabled
		/// </summary>
		public bool EmailEnabled
		{
			get
			{
				return emailEnabled;
			}
			set
			{
				emailEnabled = value;
			}
		}
		

		/// <summary>
		/// Get/Set SMTP server address
		/// </summary>
		public string SMTPServer
		{
			get
			{
				return smtpServer;
			}
			set
			{
				smtpServer = value;
				//boardOptions.SetBoardSettings(DB_STRING_SETTINGS_CATEGORY, DB_STRING_SMTP_SERVER, 
				//	smtpServer);
			}
		}
		

		/// <summary>
		/// Get/Set SMTP Username
		/// </summary>
		public string SMTPUsername
		{
			get
			{
				return smtpUsername;
			}
			set
			{
				smtpUsername = value;
			}
		}
		

		/// <summary>
		/// Get/Set SMTP Password
		/// </summary>
		public string SMTPPassword
		{
			get
			{
				return smtpPassword;
			}

			set
			{
				smtpPassword = value;
			}
		}
		

		/// <summary>
		/// Get/Set SMTP Server Port
		/// </summary>
		public int SMTPServerPort
		{
			get
			{
				return smtpPort;
			}
			set
			{
				smtpPort = value;
			}
		}
		

		/// <summary>
		/// Get/Set option to enable HTML enabled emails
		/// </summary>
		public bool HTMLEmails
		{
			get
			{
				return htmlEmails;
			}
			set
			{
				htmlEmails = value;
			}
		}
		

		/// <summary>
		/// Get/Set SMTP SSL connection enabled
		/// </summary>
		public bool SMTPSslConnection
		{
			get
			{
				return smtpSsl;
			}
			set
			{
				smtpSsl = value;
			}
		}
	

		#endregion Public Properties
	
		#region Private Methods
		
		/// <summary>
		/// Load settings for the private members
		/// </summary>
		/// <returns>If there is a load error then the exception message is returned otherwise an empty string is returned</returns>
		private string LoadSettings(string Host, int Port, string UserName, string Password, bool UseSSL)
		{
			try
			{		
				emailEnabled = true;
				smtpServer = Host;
				smtpPort = Port;
				try
				{
					smtpUsername = UserName;
					smtpPassword = Password;
				}
				catch // If there is any problem decrypting the user details set them to empty.
				{
					smtpUsername = string.Empty;
					smtpPassword = string.Empty;
				}

				htmlEmails = false;
				smtpSsl = UseSSL;
				emailSendtime = 1;
				emailRemoveSentMail = false; 
				emailMaxSendAttempts = 10;
			}
			catch (Exception E)
			{
				return E.Message;
			}
			
			return string.Empty;
		}
		

		#endregion Private Methods
		
		#region Public Overriden Methods
		
		public override void ResetParameters()
		{
			
		}
		
		#endregion
		
	}
}
