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
using Library.Utils;

namespace Website.Library.Classes
{
	/// <summary>
	/// Description of abstract BaseSettingsClass.
	/// </summary>
	public abstract class BaseSettingsClass
	{
		#region Constructor
		
		/// <summary>
		/// Constructor for the BaseSettingsClass
		/// </summary>
		public BaseSettingsClass()
		{
			boardOptions = new Options();
		}
		

		#endregion Constructor
	
		#region Protected Static Members
		
		protected static int numOfReference;
		
	
		#endregion Protected Static Members
	
		#region Protected Members
		
		protected string loadError = string.Empty;
		protected Options boardOptions;
		
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
