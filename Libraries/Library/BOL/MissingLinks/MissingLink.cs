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
