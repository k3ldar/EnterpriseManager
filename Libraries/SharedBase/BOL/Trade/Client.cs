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
 *  File: Client.cs
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
using SharedBase.BOL.Salons;
using SharedBase.BOL.Users;

using SharedBase.ClassExtenders;

using Shared.Classes;

namespace SharedBase.BOL.Trade
{
    [Serializable]
    public sealed class Client : BaseObject
    {
        #region Private / Protected Members

        private Int64 _ID;
        private string _Name;
        private string _CompanyName;
        private string _Telephone;
        private string _EMail;
        private string _Address;
        private string _Postcode;
        //private Int64 _SalonID;
        private string _InitialNotes;
        private Enums.ClientState _State;
        private ClientActions _Actions;
        private bool _InfoPack;
        private bool _Account;
        private bool _Training;
        private bool _Salons;

        private User _accountManager = null;

        #region Caching

        private static CacheManager _cachedUsers = new CacheManager("Trade Clients", new TimeSpan(1, 0, 0));

        #endregion Caching

        #endregion Private / Protected Members

        #region Constructor / Destructor

        public Client(Int64 ID, string Name, string CompanyName, string Telephone, string Email, string Address, string Postcode, 
            string Notes, Enums.ClientState State, ClientActions Actions, bool InfoPack, bool Account, bool Training, bool Salons)
        {
            _ID = ID;
            _Name = Name;
            _CompanyName = CompanyName;
            _Telephone = Telephone;
            _EMail = Email;
            _Address = Address;
            _Postcode = Postcode;
           // _SalonID = SalonID;
            _InitialNotes = Notes;
            _State = State;
            _Actions = Actions;
            _InfoPack = InfoPack;
            _Account = Account;
            _Training = Training;
            _Salons = Salons;
        }

        #endregion Constructor / Destructor

        #region Properties

        public Int64 ID
        {
            get
            {
                return _ID;
            }
        }

        public string Email
        {
            get
            {
                return _EMail;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
        }

        public string Telephone
        {
            get
            {
                return _Telephone;
            }
        }

        public string Address
        {
            get
            {
                return _Address;
            }
        }

        public string Postcode
        {
            get
            {
                return _Postcode;
            }
        }

        public string Company
        {
            get
            {
                return _CompanyName;
            }
        }

        public string InitialNotes
        {
            get
            {
                return _InitialNotes;
            }
        }

        public Enums.ClientState State
        {
            get
            {
                return _State;
            }

            set
            {
                if (_State != value)
                    DAL.FirebirdDB.TradeClientChangeState(this, value);

                _State = value;
            }
        }

        public ClientNotes Notes
        {
            get
            {
                return DAL.FirebirdDB.TradeClientNotesGet(this);
            }
        }

        public User ClientAccount
        {
            get
            {
                CacheItem item = _cachedUsers.Get(_EMail);

                if (item == null)
                {
                    item = new CacheItem(_EMail, User.UserGet(_EMail));
                    _cachedUsers.Add(_EMail, item);
                }

                return (User)item.Value;
            }
        }

        public bool InfoPack
        {
            get
            {
                return _InfoPack;
            }
        }

        public bool Account
        {
            get
            {
                return _Account;
            }
        }

        public bool Training
        {
            get
            {
                return _Training;
            }
        }

        public bool Salons
        {
            get
            {
                return _Salons;
            }
        }

        /// <summary>
        /// The member of staff who is assigned as account manager
        /// </summary>
        public User AccountManager
        {
            get
            {
                if (_accountManager == null)
                {
                    _accountManager = DAL.FirebirdDB.TradeClientManagerGet(this);
                }

                return _accountManager;
            }

            set
            {
                _accountManager = value;

                Hooks.Hooks.HookNotification(HookEvent.TradeClientManagerChanged,
                    String.Format("Client: {0}; Manager: {1}", Name, value.UserName));

                DAL.FirebirdDB.TradeClientManagerSet(this, value);
            }
        }

        #endregion Properties

        #region Public Methods

        public override void Refresh()
        {
            _Actions = DAL.FirebirdDB.TradeClientActionsGet(this);
        }

        public void AddNote(User user, string Notes)
        {
            string[] notes = Notes.Split(240, true);

            for (int i = notes.Length - 1; i >= 0; i--)
                DAL.FirebirdDB.TradeClientNotesAdd(this, user, notes[i], Enums.ClientAction.None);

            Hooks.Hooks.HookNotification(HookEvent.TradeClientNoteAdd,
                String.Format("Client: {0}; Staff: {1}", Name, user.UserName));
        }

        public void AddNote(User user, string Notes, Enums.ClientAction action)
        {
            string[] notes = Notes.Split(240, true);

            for (int i = notes.Length -1; i >= 0; i--)
                DAL.FirebirdDB.TradeClientNotesAdd(this, user, notes[i], action);

            Hooks.Hooks.HookNotification(HookEvent.TradeClientNoteAddAction,
                String.Format("Client: {0}; Staff: {1}; Type: {2}", Name, user.UserName, action.ToString()));
        }

        public ClientAction OpenAction(Enums.ClientAction Action)
        {
            ClientAction Result = null;

            foreach (ClientAction action in _Actions)
            {
                if (action.Action == Action && action.User == null)
                {
                    Result = action;
                    break;
                }
            }

            return Result;
        }

        public ClientAction ClosedAction(Enums.ClientAction Action)
        {
            ClientAction Result = null;

            foreach (ClientAction action in _Actions)
            {
                if (action.Action == Action && action.User != null)
                {
                    Result = action;
                    break;
                }
            }

            return Result;
        }

        public ClientActions ClosedActions(Enums.ClientAction Action)
        {
            ClientActions Result = new ClientActions();

            foreach (ClientAction action in _Actions)
            {
                if (action.User != null && action.Action == Action)
                    Result.Add(action);
            }

            return Result;
        }

        #endregion Public Methods

        #region Overridden Methods

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}", Name, Company, Telephone, Email);
        }

        #endregion Overridden Methods
    }
}
