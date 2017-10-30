using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.RSS
{
    [Serializable]
    public sealed class RSSItem
    {
        #region Private / Protected Members

        private string _title;
        private string _description;
        private string _link;
        private DateTime _published;

        #endregion Private / Protected Members

        #region Constructors

        public RSSItem(string title, string description, string link, DateTime publicationDate)
        {
            _title = title;
            _description = description;
            _link = link;
            _published = publicationDate;
        }

        #endregion Constructors

        #region Properties

        public string Title
        {
            get { return (_title); }
        }

        public string Description
        {
            get { return (_description); }
        }

        public string Link
        {
            get { return (_link); }
        }

        public DateTime PublishedDate
        {
            get { return (_published); }
        }

        #endregion Properties

        #region Public Static Methods


        #endregion Public Static Methods
    }
}
