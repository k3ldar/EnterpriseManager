using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.Helpdesk
{
    [Serializable]
    public sealed class KBGroup
    {
        #region Private Members

        private int _id;
        private string _groupName;
        private string _groupDescription;
        private int _order;
        private int _viewCount;
        private KBGroup _parent;
        private int _memberLevel;

        #endregion Private Members

        #region Constructors

        public KBGroup(int ID, string Name, string Description, int Order, int ViewCount, KBGroup Parent, int MemberLevel)
        {
            _id = ID;
            _groupName = Name;
            _groupDescription = Description;
            _order = Order;
            _viewCount = ViewCount;
            _parent = Parent;
            _memberLevel = MemberLevel;
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

        public string Name
        {
            get
            {
                return (_groupName);
            }
        }

        public KBGroup Parent
        {
            get
            {
                if (_parent == null)
                    _parent = DAL.FirebirdDB.FAQGetParent(this);

                return (_parent);
            }
        }

        public string Description
        {
            get
            {
                return (_groupDescription);
            }
        }

        public FAQItems Items
        {
            get
            {
                return (DAL.FirebirdDB.FAQItemsGet(this));
            }
        }

        #endregion Properties

        #region Public Methods

        public KBGroups SubGroups(Users.User user)
        {
            return (DAL.FirebirdDB.FAQGet(user, this));
        }

        #endregion Public Methods
    }
}
