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
 *  File: MissingLink.cs
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

namespace Library.BOL.MissingLinks
{
    [Serializable]
    public sealed class MissingLink
    {
        #region Private / Protected Members

        private Int64 _Id;
        private string _DeprectedLink;
        private string _RedirectLink;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public MissingLink(Int64 ID, string DeprecatedLink, string RedirectLink)
        {
            _Id = ID;
            _DeprectedLink = DeprecatedLink;
            _RedirectLink = RedirectLink;
        }

        #endregion Constructors / Destructors

        #region Properties

        public Int64 ID
        {
            get
            {
                return (_Id);
            }
        }

        public string DeprecatedLink
        {
            get
            {
                return (_DeprectedLink);
            }

            set
            {
                _DeprectedLink = value;
            }
        }

        public string RedirectLink
        {
            get
            {
                return (_RedirectLink);
            }

            set
            {
                _RedirectLink = value;
            }
        }

        #endregion Properties

        #region Public Methods

        public void Save()
        {
            DAL.FirebirdDB.AdminMissingLinkUpdate(this);
        }

        public void Delete()
        {
            DAL.FirebirdDB.AdminMissingLinkDelete(this);
        }

        #endregion Public Methods
    }
}
