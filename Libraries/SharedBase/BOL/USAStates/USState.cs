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
 *  File: USState.cs
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

namespace SharedBase.BOL.USAStates
{
    [Serializable]
    public sealed class USState : BaseObject
    {
        #region Private / Protected Members

        private Int64 _ID;
        private string _Name;
        private string _RedirectURL;
        private bool _ShowPrices;
        private string _StateCode;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public USState(Int64 ID, string Name, string RedirectURL, bool ShowPrices, string StateCode)
        {
            _ID = ID;
            _Name = Name;
            _RedirectURL = RedirectURL;
            _ShowPrices = ShowPrices;
            _StateCode = StateCode;
        }

        #endregion Constructors / Destructors

        #region Properties

        public Int64 ID
        {
            get
            {
                return _ID;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
        }

        public string RedirectURL
        {
            get
            {
                return _RedirectURL;
            }
        }

        public bool ShowPrices
        {
            get
            {
                return _ShowPrices;
            }
        }

        public string StateCode
        {
            get
            {
                return _StateCode;
            }
        }

        #endregion Properties
    }
}
