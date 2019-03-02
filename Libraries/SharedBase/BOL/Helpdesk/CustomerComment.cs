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
 *  File: CustomerComment.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

#if !ANDROID
using System.Web;
#endif

namespace SharedBase.BOL.Helpdesk
{
    [Serializable]
    public sealed class CustomerComment : BaseObject
    {
        #region Private / Protected Members

        private int _ID;
        private int _UserID;
        private string _UserName;
        private string _Comments;
        private bool _ShowOnWeb;

        #endregion Private / Protected Members

        #region Constructor / Destructor

        public CustomerComment(int ID, int UserID, string UserName, string Comments, bool ShowOnWeb)
        {
            _ID = ID;
            _UserID = UserID;
            _UserName = UserName;
            _Comments = Comments;
            _ShowOnWeb = ShowOnWeb;
        }

        #endregion Constructor / Destructor

        #region Properties

        public int ID
        {
            get
            {
                return (_ID);
            }
        }

        public int UserID
        {
            get
            {
                return (_UserID);
            }

            set
            {
                _UserID = value;
            }
        }

        public string UserName
        {
            get
            {
                return (_UserName);
            }

            set
            {
                _UserName = value;
            }
        }

        public string Comments
        {
            get
            {
                return (_Comments);
            }

            set
            {
                _Comments = value;
            }
        }

        public bool ShowOnWeb
        {
            get
            {
                return (_ShowOnWeb);
            }

            set
            {
                _ShowOnWeb = value;
            }
        }

        #endregion Properties

        #region Public Methods

        public override void Save()
        {
            DAL.FirebirdDB.AdminHelpdeskCustomerCommentUpdate(this);
        }

        public override void Delete()
        {
            DAL.FirebirdDB.AdminHelpdeskCustomercommentDelete(this);
        }

        #endregion Public Methods
    }
}