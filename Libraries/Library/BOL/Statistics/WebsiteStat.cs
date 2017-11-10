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
 *  File: WebsiteStat.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  07/06/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SieraDelta.Library.BOL.Statistics
{
    public sealed class WebsiteStat
    {
        #region Constructor

        public WebsiteStat (string description, int count)
        {
            Count = count;
            Description = description;
        }

        public WebsiteStat(string description, int count, decimal value1)
        {
            Count = count;
            Description = description;
            Value1 = value1;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Website Description
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Website Count
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Variable double Value, optional
        /// </summary>
        public decimal Value1 { get; private set; }

        #endregion Properties
    }
}
