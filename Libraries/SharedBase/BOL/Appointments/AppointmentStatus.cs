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
 *  File: AppointmentStatus.cs
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

namespace SharedBase.BOL.Appointments
{
    [Serializable]
    public sealed class AppointmentStatus : BaseObject
    {
        #region Private / Protected Members

        private int _ID;
        private string _Description;
        private int _SortOrder;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public AppointmentStatus(int ID, string Description, int SortOrder)
        {
            _ID = ID;
            _Description = Description;
            _SortOrder = SortOrder;
        }

        #endregion Constructors / Destructors

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

        public int SortOrder
        {
            get
            {
                return _SortOrder;
            }
        }

        #endregion Properties

        #region Overridden Methods

        public override string ToString()
        {
            return String.Format("Status: {0}; ID: {1}", _Description, ID);
        }

        #endregion Overridden Methods

    }
}
