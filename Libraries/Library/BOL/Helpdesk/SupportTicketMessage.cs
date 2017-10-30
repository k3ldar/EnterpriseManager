using System;
using System.Collections.Generic;
#if !ANDROID
using System.Web;
#endif

namespace Library.BOL.Helpdesk
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
                return (_ID);
            }
        }

        public SupportTicket supportTicket
        {
            get
            {
                return (_supportTicket);
            }
        }

        public string Content
        {
            get
            {
                return (_Content);
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return (_CreateDate);
            }
        }

        public string Username
        {
            get
            {
                return (_Username);
            }
        }


        #endregion Properties
    }
}