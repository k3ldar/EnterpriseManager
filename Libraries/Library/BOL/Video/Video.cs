using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.Video
{
    [Serializable]
    public sealed class Video : BaseObject
    {
        #region Private / Protected Members

        private int _ID;
        private string _VideoReference;
        private string _Description;


        #endregion Private / Protected Members

        #region Constructors / Destructors

        public Video(int ID, string VideoReference, string Description)
        {
            _ID = ID;
            _VideoReference = VideoReference;
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

        public string VideoReference
        {
            get
            {
                return (_VideoReference);
            }

            set
            {
                _VideoReference = value;
            }
        }

        #endregion Properties

        #region Public Methods

        public override void Save()
        {
            if (ID == -1)
                this.ID = DAL.FirebirdDB.VideoCreate(Description, VideoReference);
            else
                DAL.FirebirdDB.VideoUpdate(this);
        }

        public override void Delete()
        {
            DAL.FirebirdDB.VideoDelete(this);
        }

        #endregion Public Methods

        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("Video: {0}; Description: {1}", ID, _Description));
        }

        #endregion Overridden Methods

    }
}
