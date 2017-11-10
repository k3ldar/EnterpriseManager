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
 *  File: FAQItem.cs
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
