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
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: RSSItem.cs
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
