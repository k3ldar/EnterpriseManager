using System;

#if !ANDROID
using System.Web;
#endif

namespace Library.BOL.Helpdesk
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