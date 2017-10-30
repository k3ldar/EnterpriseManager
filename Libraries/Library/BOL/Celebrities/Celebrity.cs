using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.Celebrities
{
    [Serializable]
    public sealed class Celebrity : BaseObject
    {
        #region Private / Protected Members

        private Int64 _ID;
        private string _Name;
        private string _Image;
        private string _Description;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public Celebrity(Int64 ID, string Name, string Image, string Description)
        {
            _ID = ID;
            _Name = Name;
            _Image = Image;
            _Description = Description;
        }

        #endregion Constructors / Destructors

        #region Properties

        public Int64 ID
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

        public string Image
        {
            get
            {
                return (_Image);
            }

            set
            {
                _Image = value;
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
            if (ID == -1)
                this.ID = DAL.FirebirdDB.CelebrityCreate(Name, Description, Image);
            else
                DAL.FirebirdDB.CelebrityUpdate(this);
        }

        public override void Delete()
        {
            DAL.FirebirdDB.CelebrityDelete(this);
        }

        #endregion Public Methods


        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("Celebrity: {0}; Description: {1}; Name: {2}; Image: {3}", ID, _Description, _Name, _Image));
        }

        #endregion Overridden Methods

    }
}
