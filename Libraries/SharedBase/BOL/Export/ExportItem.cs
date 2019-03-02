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
 *  File: ExportItem.cs
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

namespace SharedBase.BOL.Export
{
    [Serializable]
    public sealed class ExportItem : BaseObject
    {
        public ExportItem(Int64 id, string tableName, string columnName, string description, ImportExportOptions options)
        {
            ID = id;
            Table = tableName;
            Column = columnName;
            Description = description;
            Options = options;
            Selected = false;
        }

        #region Properties

        /// <summary>
        /// Unique ID
        /// </summary>
        public Int64 ID { get; internal set; }

        /// <summary>
        /// Table Name
        /// </summary>
        public string Table { get; internal set; }

        /// <summary>
        /// Columnn Name
        /// </summary>
        public string Column { get; internal set; }

        /// <summary>
        /// Description of column
        /// </summary>
        public string Description { get; internal set; }

        /// <summary>
        /// Import Export Options
        /// </summary>
        public ImportExportOptions Options { get; internal set; }

        /// <summary>
        /// Indicates whether the item is selected or not
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// Position, user defined
        /// </summary>
        public int Position { get; set; }

        #endregion Properties
    }
}
