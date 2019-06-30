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
 *  File: Update.cs
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

namespace SharedBase.BOL.DatabaseUpdates
{
    [Serializable]
    public sealed class Update : BaseObject
    {
        #region Private Members

        private Int64 _id;
        private DateTime _updated;
        private string _column;
        private string _oldValue;
        private string _newValue;

        #endregion Private Members

        #region Constructors

        public Update(Int64 ID, DateTime Updated, string Column, string OldValue, string NewValue)
        {
            _id = ID;
            _updated = Updated;
            _column = Column;
            _oldValue = OldValue;
            _newValue = NewValue;
        }

        #endregion Constructors

        #region Properties

        public Int64 ID
        {
            get
            {
                return _id;
            }
        }

        public DateTime Updated
        {
            get
            {
                return _updated;
            }
        }

        public string Column
        {
            get
            {
                return _column;
            }
        }

        public string OldValue
        {
            get
            {
                return _oldValue;
            }
        }

        public string NewValue
        {
            get 
            { 
                return _newValue; 
            }
        }

        #endregion Properties
    }
}
