using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.Users;

namespace Library.BOL.News
{
    [Serializable]
    public sealed class NewsItem
    {
        #region Private / Protected Members

        private int _ID;
        private DateTime _DateTime;
        private string _Title;
        private string _Text;
        private string _Image;
        private string _URL;

        #endregion Private / Protected Members

        #region Constructors

        public NewsItem(int ID, DateTime DateTime, string Title, string Text, string Image, string URL)
        {
            _ID = ID;
            _DateTime = DateTime;
            _Title = Title;
            _Text = Text;
            _Image = Image;
            _URL = URL;
        }

        #endregion Constructors

        #region Properties

        public int ID
        {
            get
            {
                return (_ID);
            }
        }

        public DateTime DateTime
        {
            get
            {
                return (_DateTime);
            }

            set
            {
                _DateTime = value;
            }
        }

        public string Title
        {
            get
            {
                return (_Title);
            }

            set
            {
                _Title = value;
            }
        }

        public string Text
        {
            get
            {
                return (_Text);
            }

            set
            {
                Text = value;
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

        public string URL
        {
            get
            {
                return (_URL);
            }

            set
            {
                _URL = value;
            }
        }

        #endregion Properties

        #region Public Methods

        public void Save(User user)
        {
            Utils.LibUtils.CanUpdate(user);
        }

        public void Delete(User user)
        {
            Utils.LibUtils.CanDelete(user);
        }

        #endregion Public Methods
    }
}
