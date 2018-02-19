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
 *  File: TagLine.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BOL.TagLines
{
    [Serializable]
    public sealed class TagLine : BaseObject
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">ID of TagLine</param>
        /// <param name="text">TagLine text</param>
        public TagLine (Int64 id, string text)
        {
            ID = id;
            Text = text;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void Save()
        {
            DAL.FirebirdDB.TagLineSave(this);
            TagLines.Reset();
        }

        #endregion Overridden Methods

        #region Properties

        /// <summary>
        /// ID of Tagline
        /// </summary>
        public Int64 ID { get; private set; }

        /// <summary>
        /// Tagline Text
        /// </summary>
        public string Text { get; set; }

        #endregion Properties
    }
}
