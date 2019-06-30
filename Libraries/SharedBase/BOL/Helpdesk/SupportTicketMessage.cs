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
 *  File: SupportTicketMessage.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
#if !ANDROID
using System.Web;
#endif

namespace SharedBase.BOL.Helpdesk
{
    [Serializable]
    public sealed class SupportTicketMessage
    {
        #region Private / Protected Members

        private int _ID;
        private SupportTicket _supportTicket;
        private string _Content;
        private DateTime _CreateDate;
        private string _Username;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public SupportTicketMessage(int ID, SupportTicket supportTicket, string Content, DateTime CreateDate, string UserName)
        {
            _ID = ID;
            _supportTicket = supportTicket;
            _Content = Content;
            _CreateDate = CreateDate;
            _Username = UserName;
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

        public SupportTicket supportTicket
        {
            get
            {
                return _supportTicket;
            }
        }

        public string Content
        {
            get
            {
                return _Content;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return _CreateDate;
            }
        }

        public string Username
        {
            get
            {
                return _Username;
            }
        }


        #endregion Properties
    }
}