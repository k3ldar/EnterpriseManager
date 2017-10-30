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
