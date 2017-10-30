using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.USAStates
{
    [Serializable]
    public sealed class USState : BaseObject
    {
        #region Private / Protected Members

        private Int64 _ID;
        private string _Name;
        private string _RedirectURL;
        private bool _ShowPrices;
        private string _StateCode;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public USState(Int64 ID, string Name, string RedirectURL, bool ShowPrices, string StateCode)
        {
            _ID = ID;
            _Name = Name;
            _RedirectURL = RedirectURL;
            _ShowPrices = ShowPrices;
            _StateCode = StateCode;
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

        public string Name
        {
            get
            {
                return (_Name);
            }
        }

        public string RedirectURL
        {
            get
            {
                return (_RedirectURL);
            }
        }

        public bool ShowPrices
        {
            get
            {
                return (_ShowPrices);
            }
        }

        public string StateCode
        {
            get
            {
                return (_StateCode);
            }
        }

        #endregion Properties
    }
}
