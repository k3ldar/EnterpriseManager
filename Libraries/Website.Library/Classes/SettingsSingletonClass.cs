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
// The Original Code is part of dnfBB.
// 
// The Initial Developer of the Original Code is Simon Bosanquet.
// 
// Portions created by Simon Bosanquet are 
// Copyright (C) 2005 - 2007.  Simon Bosanquet. All Rights Reserved.
// 
// All Rights Reserved.
// 
// Contributor(s): Simon Bosanquet.

#endregion License

using System;

namespace Website.Library.Classes
{
	/// <summary>
	/// Description of BoardSettingsSingletonClass.
	/// </summary>
	internal sealed class BoardSettingsSingletonClass : BaseSettingsClass
	{
		#region Private Constants
		
		private const string DB_STRING_SETTINGS_CATEGORY = "Board";
		private const string DB_STRING_BOARD_TITLE = "Title";
		private const string DB_STRING_BOARD_DESCRIPTION = "Description";
		private const string DB_STRING_LOGIN_DAYS = "Login Days";
		private const string DB_STRING_USE_INTERNAL_CACHE = "Use Internal Cache";
		private const string DB_STRING_SHOW_SMILIES = "Show Smilies in Title";
		private const string DB_STRING_ALLOW_AVATARS = "Allow User Avatars";
		private const string DB_STRING_HIDE_EMAIL_ADDRESS = "Hide EMail Addresses";
		private const string DB_STRING_SHOW_QUICK_SEARCH = "Show Quick Search";
		private const string DB_STRING_LOCK_FORUMS = "Lock Forums";
		private const string DB_STRING_REQUIRE_POST_VALIDATION = "Require Post Validation";
		
		#endregion
		
		#region Private Static Members
		
		private static BoardSettingsSingletonClass instance;
		
		#endregion
		
		#region Private Members
		
		private string _Title = "DNFBB";
		private string _description = "Board Description";
		private bool _internalcache = true;
		private bool _showsmiliesintitles = false;
		private string _url;
		private int _LoginDays = 30;		
		private int _majorversion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major;
		private int _minorversion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor;

        private string _versiondescription = ""; 
		
        
        private bool _allowavatars = false;
		private bool _hideemailaddresses = true;
		private bool _showquicksearch = true;
		private bool _forumlocked = false;
		private bool _requirepostvalidation = false;
		private string _boardPath = "";

		private int _maxRequestLength = (int)Math.Pow(2,22); // Defaults to 4 Meg - This value is set in web.config 

        #endregion

        #region Constructor

        /// <summary>
		/// Private constructor for BoardSettingsSingletonClass.
		/// </summary>
		private BoardSettingsSingletonClass()
		{
			loadError = LoadSettings();
		}
		
		#endregion
		
		#region Public Static Methods
		
		/// <summary>
		/// Return the instance of the email settings singleton class
		/// </summary>
		public static BoardSettingsSingletonClass GetInstance()
		{
			if (instance == null)
			{
				numOfReference++;
				instance = new BoardSettingsSingletonClass();
			}
				return instance;
		}
		

		#endregion
				
		#region Public Properties
		
		/// <summary>
		/// Maximum request length - Determins maximum file transfer size
		/// </summary>
		/// <description>
		/// Set the http-runtime parameter in web.config it you want to increase this value
		/// </description>
		/// <example>
		/// <configuration>
 	 	/// 	<system.web>
		/// 	<httpRuntime
   		/// 		executionTimeout = "HH:MM:SS" 
   		///			maxRequestLength = "number" 
   		///			requestLengthDiskThreshold = "number" 
   		///			useFullyQualifiedRedirectUrl = "[True|False]" 
   		///			minFreeThreads = "number" 
   		///			minLocalRequestFreeThreads = "number" 
   		///			appRequestQueueLimit = "number"
   		///			enableKernelOutputCache = "[True|False]" 
   		///			enableVersionHeader = "[True|False]" 
   		///			apartmentThreading = "[True|False]"
   		///			requireRootedSaveAsPath = "[True|False]"
   		///			enable = "[True|False]" 
   		///			sendCacheControlHeader = "[True|False]" 
   		///			shutdownTimeout = "HH:MM:SS"
   		///			delayNotificationTimeout = "HH:MM:SS"
   		///			waitChangeNotification = "number" 
   		/// 		maxWaitChangeNotification = "number" 
   		///			requestPriority = "[Normal|High|Critical]" 
   		///			enableHeaderChecking = "[True|False]" 
		///			/>
		/// 	</system.web>
		/// </configuration>
		/// </example>
		public int MaxRequestLength
		{
			get
			{
				return _maxRequestLength ;
			}
			set
			{
				_maxRequestLength  = value;
			}
		}
		
		/// <summary>
		/// Get/Set the physical path where the board is located and running from
		/// </summary>
		public string PhysicalPath
		{
			get
			{
				return _boardPath;
			}
			set
			{
				_boardPath = value;	
			}
		}
	
		/// <summary>
		/// Get/Set the propery which requires the user to validate their post
		/// </summary>
		public bool RequirePostValidation
		{
			get
			{
				return _requirepostvalidation;
			}
			set
			{
				 _requirepostvalidation = value;
				 //boardOptions.SetBoardSettings(DB_STRING_SETTINGS_CATEGORY, DB_STRING_REQUIRE_POST_VALIDATION,
				 //	util.BoolToStr(_requirepostvalidation));
			}
		}
		

		/// <summary>
		/// Get/Set whether Avatars are allowed on the board
		/// </summary>
		public bool AllowAvatars
		{
			get
			{
				return _allowavatars;
			}
			set
			{
				 _allowavatars = value;
				 //boardOptions.SetBoardSettings(DB_STRING_SETTINGS_CATEGORY, DB_STRING_ALLOW_AVATARS,
					//util.BoolToStr(_allowavatars));
			}
		}
				



		/// <summary>
		/// Get/Set the number of days the user can be logged into the board
		/// </summary>
		public int LoginDays
		{
			get
			{
				return _LoginDays;
			}
			set
			{
				 _LoginDays = value;
				 //boardOptions.SetBoardSettings(session, DB_STRING_SETTINGS_CATEGORY, DB_STRING_LOGIN_DAYS, 
					//_LoginDays.ToString());
			}
		}


		/// <summary>
		/// Get/Set the board title
		/// </summary>
		public string Title
		{
			get 
			{
				return _Title;
			}
			set
			{
				 _Title = value;
				 //boardOptions.SetBoardSettings(DB_STRING_SETTINGS_CATEGORY, DB_STRING_BOARD_TITLE, 
				//_Title);
			}
		}


		/// <summary>
		/// Get/Set the board description
		/// </summary>
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				 _description = value;
				 //boardOptions.SetBoardSettings(session, DB_STRING_SETTINGS_CATEGORY, DB_STRING_BOARD_DESCRIPTION, 
					//_description);
			}
		}
		

		/// <summary>
		/// Get/Set the board locked status
		/// </summary>
		public bool BoardLocked
		{
			get
			{
				return _forumlocked;
			}
			set
			{
				_forumlocked = value;
				//boardOptions.SetBoardSettings(DB_STRING_SETTINGS_CATEGORY, DB_STRING_LOCK_FORUMS, 
				//	util.BoolToStr(_forumlocked));
			}
		}	
		

		/// <summary>
		/// Get the board version
		/// </summary>
		public string BoardVersion
		{
			get
			{
				return (String.Format("Version {0}.{1} {2}", 
					_majorversion, _minorversion, _versiondescription));
			}
		}


		/// <summary>
		/// Get/Set the board major version number
		/// </summary>
		public int MajorVersion
		{
			get
			{
				return _majorversion;
			}
			set
			{
				 _majorversion = value;
			}
		}


		/// <summary>
		/// Get/Set the board minor version number
		/// </summary>
		public int MinorVersion
		{
			get
			{
				return _minorversion;
			}
			set
			{
				 _minorversion = value;
			}
		}


		/// <summary>
		/// Get/Set whether the users email address should be hidden or not
		/// </summary>
		public bool HideEmailAddresses
		{
			get
			{
				return _hideemailaddresses;
			}
			set
			{
				 _hideemailaddresses = value;
			}
		}


		/// <summary>
		/// Get/Set whether the quick search box should be shown
		/// </summary>
		public bool ShowQuickSearch
		{
			get
			{
				return _showquicksearch;
			}
			set
			{
				 _showquicksearch = value;
				 //boardOptions.SetBoardSettings(DB_STRING_SETTINGS_CATEGORY, DB_STRING_SHOW_QUICK_SEARCH,
				//	util.BoolToStr(_showquicksearch));
			}
		}


		/// <summary>
		/// Get/Set whether smilies should be shown in post titles
		/// </summary>
		public bool ShowSmiliesInTitles
		{
			get
			{
				return _showsmiliesintitles;
			}
			set
			{
				 _showsmiliesintitles = value;
				 //boardOptions.SetBoardSettings(DB_STRING_SETTINGS_CATEGORY, DB_STRING_SHOW_SMILIES,
					//util.BoolToStr(_showsmiliesintitles));
			}
		}


		/// <summary>
		/// Get/Set the board url
		/// </summary>
		public string URL
		{
			get
			{
				return _url;
			}
			set
			{
				 _url = value;
			}
		}
		

		/// <summary>
		/// Get/Set whether the board should be placed in internal cachce
		/// </summary>
		public bool InternalCache
		{
			get
			{
				return _internalcache;
			}
			set
			{
				 _internalcache = value;
				 //boardOptions.SetBoardSettings(DB_STRING_SETTINGS_CATEGORY, 
				//	DB_STRING_USE_INTERNAL_CACHE, util.BoolToStr(_internalcache));
			}
		}
	

		#endregion
	
		#region Private Methods
		
		/// <summary>
		/// Load settings for the private members
		/// </summary>
		/// <returns>If there is a load error then the exception message is returned otherwise an empty string is returned</returns>
		private string LoadSettings()
		{
			try
            {
                //				_Title = boardOptions.GetBoardSettings(DB_STRING_SETTINGS_CATEGORY, DB_STRING_BOARD_TITLE, "DNFBB");
//				_description = boardOptions.GetBoardSettings(DB_STRING_SETTINGS_CATEGORY, DB_STRING_BOARD_DESCRIPTION, _description);
//				_LoginDays = util.StrToIntDef(boardOptions.GetBoardSettings( DB_STRING_SETTINGS_CATEGORY, DB_STRING_LOGIN_DAYS, "30"), 30);
//				_internalcache = util.StrToBool(boardOptions.GetBoardSettings(DB_STRING_SETTINGS_CATEGORY, DB_STRING_USE_INTERNAL_CACHE, "true"));
//				_showsmiliesintitles = util.StrToBool(boardOptions.GetBoardSettings(DB_STRING_SETTINGS_CATEGORY, DB_STRING_SHOW_SMILIES, "false"));
//				_allowavatars = util.StrToBool(boardOptions.GetBoardSettings(DB_STRING_SETTINGS_CATEGORY, DB_STRING_ALLOW_AVATARS, "false"));
//				_hideemailaddresses = util.StrToBool(boardOptions.GetBoardSettings(DB_STRING_SETTINGS_CATEGORY, DB_STRING_HIDE_EMAIL_ADDRESS, "true"));
//				_showquicksearch = util.StrToBool(boardOptions.GetBoardSettings(DB_STRING_SETTINGS_CATEGORY, DB_STRING_SHOW_QUICK_SEARCH, "true"));
//				_forumlocked = util.StrToBool(boardOptions.GetBoardSettings(DB_STRING_SETTINGS_CATEGORY, DB_STRING_LOCK_FORUMS, "false"));
//				_requirepostvalidation = util.StrToBool(boardOptions.GetBoardSettings(DB_STRING_SETTINGS_CATEGORY, DB_STRING_REQUIRE_POST_VALIDATION, "false"));
			}
			catch (Exception E)
			{
				return E.Message;
			}
			
			return string.Empty;
		}
		
		#endregion
		
		#region Public Overriden Methods
		
		public override void ResetParameters()
		{
			
		}
		
		#endregion	
	}
}
