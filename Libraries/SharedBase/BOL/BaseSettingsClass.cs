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
 *  File: BaseSettingsClass.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

namespace SharedBase.BOL
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
