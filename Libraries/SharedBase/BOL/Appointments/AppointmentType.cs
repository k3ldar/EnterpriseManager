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
 *  File: AppointmentType.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Web;

namespace SharedBase.BOL.Appointments
{
    [Serializable]
    public sealed class AppointmentType : BaseObject
    {
        #region Private Members

        private int _ID;
        private string _Description;

        #endregion Private Members

        #region Properties

        public int ID
        {
            get
            {
                return _ID;
            }
        }

        public string Description
        {
            get
            {
                return _Description;
            }
        }

        #endregion Properties

        #region Constructors / Destructors

        public AppointmentType(int ID, string Description)
        {
            _ID = ID;
            _Description = Description;
        }

        #endregion Constructors / Destructors

        #region Overridden Methods

        public override string ToString()
        {
            return String.Format("AppointmentType: {0}; Description: {1}", ID, _Description);
        }

        #endregion Overridden Methods

    }
}