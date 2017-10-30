using System;
using System.Collections.Generic;
#if !ANDROID
using System.Web;
#endif

namespace Library.BOL.Helpdesk
{
    [Serializable]
    public sealed class TicketPriority
    {
        #region Private / Protected Members

        private int _ID;
        private string _Description;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public TicketPriority(int ID, string Description)
        {
            _ID = ID;
            _Description = Description;
        }

        #endregion Constructors / Destructors

        #region Properties

        public int ID
        {
            get
            {
                return (_ID);
            }
        }

        public string Description
        {
            get
            {
                return (_Description);
            }
        }

        #endregion Properties
    }
}