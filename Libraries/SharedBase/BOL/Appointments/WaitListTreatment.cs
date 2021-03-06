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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: WaitListTreatment.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  07/06/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;

using SharedBase.DAL;

namespace SharedBase.BOL.Appointments
{
	/// <summary>
	/// Wrapper for Firebird table WS_WAIT_LIST_LONG_TO_TREAT
	/// 
	/// Automatically generated by FBSPGen (http://www.sieradelta.com/Products/FBSPGen.aspx)
	/// </summary>
	public class WaitListTreatment
	{
		#region Constructors

		/// <summary>
		/// Standard constructor for WaitListTreatment
		/// </summary>
		/// <param name="iD">Property Description for Field ID</param>
		/// <param name="waitListId">Property Description for Field WAIT_LIST_ID</param>
		/// <param name="treatmentId">Property Description for Field TREATMENT_ID</param>
		public WaitListTreatment (Int64 iD, Int64 waitListId, 
			int treatmentId)
		{
			ID = iD;
			WaitListId = waitListId;
			TreatmentId = treatmentId;

		}

		#endregion Constructors

		#region Public Methods

		/// <summary>
		/// Saves the current record
		/// </summary>
		public void Save()
		{
#warning finish
            //FirebirdDB.WaitListTreatmentUpdate(this);
		}

		/// <summary>
		/// Deletes the current record
		/// </summary>
		public bool Delete()
		{
#warning finish
            //return (SharedBase.DAL.FirebirdDataBase.WaitListTreatmentDelete(this));
            return false;
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
			return String.Format("WS_WAIT_LIST_LONG_TO_TREAT Record {0}", ID);
		}

		#endregion Overridden Methods

		#region Properties

		/// <summary>
		/// Property Description for Field ID
		/// </summary>
		public Int64 ID { get; internal set; }

		/// <summary>
		/// Property Description for Field WAIT_LIST_ID
		/// </summary>
		public Int64 WaitListId { get; set; }

		/// <summary>
		/// Property Description for Field TREATMENT_ID
		/// </summary>
		public int TreatmentId { get; set; }

		#endregion Properties
	}
}