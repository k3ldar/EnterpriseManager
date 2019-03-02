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
 *  File: AutoUpdate.cs
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

using SharedBase.BOL.Users;

namespace SharedBase.BOL.DatabaseUpdates
{
    [Serializable]
    public sealed class AutoUpdate : BaseObject
    {
        #region Constructors

        public AutoUpdate (Int64 id, string name, string sql, DateTime runDate, bool complete,
            User createdBy, DateTime createdDate)
        {
            ID = id;
            Name = name;
            SQL = sql;
            RunDate = runDate;
            Complete = complete;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID
        /// </summary>
        public Int64 ID { get; internal set; }

        /// <summary>
        /// Name of rule
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Sql to run
        /// </summary>
        public string SQL { get; private set; }

        /// <summary>
        /// Date and time to run
        /// </summary>
        public DateTime RunDate { get; set; }

        /// <summary>
        /// Indicates wether it is complete or not
        /// </summary>
        public bool Complete { get; private set; }

        /// <summary>
        /// User who created the auto update
        /// </summary>
        public User CreatedBy { get; private set; }

        /// <summary>
        /// Date time created
        /// </summary>
        public DateTime CreatedDate { get; set; }

        #endregion Properties
    }
}
