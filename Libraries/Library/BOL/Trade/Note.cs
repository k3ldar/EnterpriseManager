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
 *  File: Note.cs
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

using Library;
using Library.BOL.Users;

namespace Library.BOL.Trade
{
    [Serializable]
    public sealed class ClientNote : BaseObject
    {
        #region Private / Protected Members

        private Int64 _ID;
        private Client _client;
        private Users.User _user;
        private string _Notes;
        private DateTime _NoteDateTime;
        private Enums.ClientAction _Action;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public ClientNote(Int64 ID, Client client, Users.User user, string Notes, DateTime NoteDateTime, Enums.ClientAction Action)
        {
            _ID = ID;
            _client = client;
            _user = user;
            _Notes = Notes;
            _NoteDateTime = NoteDateTime;
            _Action = Action;
        }

        #endregion Constructors / Destructors

        #region Properties

        public Int64 ID
        {
            get
            {
                return (_ID);
            }
        }

        public Users.User User
        {
            get
            {
                return (_user);
            }
        }

        public Client Client
        {
            get
            {
                return (_client);
            }
        }

        public string Notes
        {
            get
            {
                return (_Notes);
            }
        }

        public DateTime NotesDate
        {
            get
            {
                return (_NoteDateTime);
            }
        }

        public Enums.ClientAction Action
        {
            get
            {
                return (_Action);
            }
        }

        #endregion Properties
    }
}
