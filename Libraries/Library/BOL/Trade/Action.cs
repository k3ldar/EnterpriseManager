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
 *  File: Action.cs
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

using Library.BOL.Users;

namespace Library.BOL.Trade
{
    [Serializable]
    public sealed class ClientAction : BaseObject
    {
        #region Private / Protected Members

        private Int64 _ID;
        private Enums.ClientAction _action;
        private DateTime _expires;
        private string _staffName;
        private Client _client;
        private ClientNotes _notes;

        private User _user;
        private DateTime _actionDate;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public ClientAction(Int64 ID, Enums.ClientAction Action, DateTime Expires, string StaffName)
        {
            _ID = ID;
            _action = Action;
            _expires = Expires;
            _staffName = StaffName;
        }

        public ClientAction(Int64 ID, Enums.ClientAction Action, DateTime Expires, User user, DateTime ActionDate, string StaffName)
        {
            _ID = ID;
            _action = Action;
            _expires = Expires;
            _user = user;
            _actionDate = ActionDate;
            _staffName = StaffName;
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

        public string StaffName
        {
            get
            {
                return (_staffName);
            }
        }

        public Enums.ClientAction Action
        {
            get
            {
                return (_action);
            }
        }

        public DateTime Expires
        {
            get
            {
                return (_expires);
            }
        }

        public User User
        {
            get
            {
                return (_user);
            }
        }

        public DateTime ActionedDate
        {
            get
            {
                return (_actionDate);
            }
        }

        public ClientNotes Notes
        {
            get
            {
                if (_notes == null)
                    _notes = DAL.FirebirdDB.TradeClientNotesGet(this);

                return (_notes);
            }
        }

        public Client Client
        {
            get
            {
                return (_client);
            }

            set
            {
                _client = value;
            }
        }


        public bool IsActionComplete
        {
            get
            {
                return (ActionedDate.Year != 1);
            }
        }
        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Completes the action
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Notes"></param>
        public void Complete(User user, string Notes)
        {
            DAL.FirebirdDB.TradeClientActionsComplete(this, user, Notes);

            if (_client != null)
                _client.Refresh();
        }

        /// <summary>
        /// Adds new notes to action
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Notes"></param>
        public void Add(User user, string Notes)
        {
            DAL.FirebirdDB.TradeClientNotesAdd(_client, user, Notes, this);

            if (_client != null)
                _client.Refresh();
        }

        #endregion Public Methods

        #region Public Static Methods

        public static ClientAction Create(Client client, Enums.ClientAction ActionType)
        {
            ClientAction action = DAL.FirebirdDB.TradeClientActionCreate(client, ActionType);

            if (client != null)
                client.Refresh();

            return (action);
        }

        #endregion Public Static Methods
    }
}
