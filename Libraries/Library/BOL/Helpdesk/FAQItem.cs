using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.Helpdesk
{
    [Serializable]
    public sealed class FAQItem : BaseObject
    {
        #region Private Members

        private int _id;
        private string _description;
        private KBGroup _parent;
        private int _viewCount;
        private string _content;

        #endregion Private Members

        #region Constructors

        public FAQItem(int ID, string Description, KBGroup Parent, int ViewCount, string Content)
        {
            _id = ID;
            _description = Description;
            _parent = Parent;
            _viewCount = ViewCount;
            _content = Content;
        }

        #endregion Constructors

        #region Properties

        public int ID
        {
            get
            {
                return (_id);
            }
        }

        public string Description
        {
            get
            {
                return (_description);
            }

            set
            {
                _description = value;
            }
        }

        public KBGroup Parent
        {
            get
            {
                return (_parent);
            }

            set
            {
                _parent = value;
            }
        }

        public int ViewCount
        {
            get
            {
                return (_viewCount);
            }

            set
            {
                _viewCount = value;
                DAL.FirebirdDB.FAQItemSetViewCount(this);
            }
        }

        public string Content
        {
            get
            {
                return (_content);
            }

            set
            {
                _content = value;
            }
        }

        #endregion Properties


        #region Public Methods

        public override void Save()
        {
            DAL.FirebirdDB.FAQItemSave(this);
        }

        public override void Delete()
        {
            DAL.FirebirdDB.FAQItemDelete(this);
        }

        #endregion Public Methods


    }
}
