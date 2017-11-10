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
 *  File: AppointmentGroup.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

namespace Library.BOL.Appointments
{
    [Serializable]
    public sealed class AppointmentGroup : BaseObject
    {
        #region Private Consts


        #endregion Private Consts

        #region Constructors

        public AppointmentGroup(int id, string description)
        {
            ID = id;
            Description = description;
        }

        #endregion Constructors

        #region Properties

        public int ID { get; }

        public string Description { get; set; }

        #endregion Properties

        #region Overridden Methods

        public override void Save()
        {
            DAL.FirebirdDB.AppointmentGroupUpdate(this);
        }

        public override void Delete()
        {
            DAL.FirebirdDB.AppointmentGroupDelete(this);
        }

        #endregion Overridden Methods
    }
}
