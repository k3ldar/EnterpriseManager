using System;
using System.Collections.Generic;
#if !ANDROID
using System.Web;
#endif

namespace Library.BOL.TipsTricks
{
    [Serializable]
    public sealed class TipsTrick : BaseObject
    {
        #region Private / Protected Members

        private int _ID;
        private string _Name;
        private bool _ShowOnWeb;
        private int _PopUpID;
        private string _Description;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public TipsTrick(int ID, string Name, bool ShowOnWeb, int PopupID, string Description)
        {
            _ID = ID;
            _Name = Name;
            _ShowOnWeb = ShowOnWeb;
            _PopUpID = PopupID;
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

            set
            {
                _ID = value;
            }
        }

        public string Name
        {
            get
            {
                return (_Name);
            }

            set
            {
                _Name = value;
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

        public int PopUpID
        {
            get
            {
                return (_PopUpID);
            }

            set
            {
                _PopUpID = value;
            }
        }

        public string Description
        {
            get
            {
                return (_Description);
            }

            set
            {
                _Description = value;
            }
        }

        #endregion Properties

        #region Public Methods

        public override void Save()
        {
            DAL.FirebirdDB.AdminTipsTricksUpdate(this);
        }

        public override void Delete()
        {
            DAL.FirebirdDB.AdminTipsTricksDelete(this);
        }

        #endregion Public Methods
    }
}