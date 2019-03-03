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
 *  File: Contact.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;

using SharedBase.DAL;

namespace SharedBase.BOL.ContactDetails
{
	/// <summary>
	/// Wrapper for Firebird table CONTACT_DETAILS
	/// 
	/// Automatically generated by FBSPGen (http://www.sieradelta.com/Products/FBSPGen.aspx)
	/// </summary>
	public class Contact
	{
		#region Constructors

		/// <summary>
		/// Standard constructor for Contact
		/// </summary>
		/// <param name="iD">Property Description for Field ID</param>
		/// <param name="contactName">Property Description for Field CONTACT_NAME</param>
		/// <param name="contactType">Property Description for Field CONTACT_TYPE</param>
		/// <param name="contactValue">Property Description for Field CONTACT_VALUE</param>
		public Contact (Int64 iD, string contactName,
            ContactDetailsType contactType, string contactValue)
		{
			ID = iD;
			ContactName = contactName;
			ContactType = contactType;
			ContactValue = contactValue;

		}

		#endregion Constructors

		#region Public Methods

		/// <summary>
		/// Saves the current record
		/// </summary>
		public void Save()
		{
            SharedBase.DAL.FirebirdDB.ContactUpdate(this);
		}

		/// <summary>
		/// Deletes the current record
		/// </summary>
		public bool Delete()
		{
			return (SharedBase.DAL.FirebirdDB.ContactDelete(this));
		}


		/// <summary>
		/// Reloads the current record
		/// </summary>
		public void Reload()
		{
			throw new NotImplementedException();
		}

		#endregion Public Methods

		#region Overridden Methods

		/// <summary>
		/// Returns the String for the class
		/// </summary>
		public override string ToString()
		{
			return (String.Format("CONTACT_DETAILS Record {0}", ID));
		}

		#endregion Overridden Methods

		#region Properties

		/// <summary>
		/// Property Description for Field ID
		/// </summary>
		public Int64 ID { get; internal set; }

		/// <summary>
		/// Property Description for Field CONTACT_NAME
		/// </summary>
		public string ContactName { get; set; }

		/// <summary>
		/// Property Description for Field CONTACT_TYPE
		/// </summary>
		public ContactDetailsType ContactType { get; set; }

		/// <summary>
		/// Property Description for Field CONTACT_VALUE
		/// </summary>
		public string ContactValue { get; set; }

		#endregion Properties
	}
}