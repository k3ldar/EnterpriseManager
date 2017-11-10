/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: KBGroup.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
