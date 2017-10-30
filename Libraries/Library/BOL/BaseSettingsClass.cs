using System;

namespace Library.BOL
{
	/// <summary>
	/// Description of abstract BaseSettingsClass.
	/// </summary>
    [Serializable]
	public abstract class BaseSettingsClass
	{
		#region Constructor
		
		/// <summary>
		/// Constructor for the BaseSettingsClass
		/// </summary>
		public BaseSettingsClass()
		{
		}
		

		#endregion Constructor
	
		#region Protected Static Members
		
		protected static int numOfReference;
		
	
		#endregion Protected Static Members
	
		#region Protected Members
		
		protected string loadError = string.Empty;
		
		#endregion Protected Members
		
		#region Public Static Properties
				
		/// <summary>
		/// Get the number of references associated with this class
		/// </summary>
		public static int References
		{
			get
			{
				return numOfReference;
			}
		}
		

		/// <summary>
		/// Get/Set current session
		/// </summary>
//		public static UserSession Session
//		{
//			get
//			{
//				return session;
//			}
//
//
//			set
//			{
//				session = value;
//			}
//		}
		

		#endregion Public Static Properties
	
		#region Public Properties
		
		/// <summary>
		/// Get the load error message.  If there isn't an error then string.empty is returned.
		/// </summary>
		public string LoadError
		{
			get
			{
				return loadError;
			}
		}
		
		#endregion
		
		#region Public Abstract Methods
		
		/// <summary>
		/// Reset the paramters to their default values
		/// </summary>
		public abstract void ResetParameters();
		
		#endregion
	}
}
