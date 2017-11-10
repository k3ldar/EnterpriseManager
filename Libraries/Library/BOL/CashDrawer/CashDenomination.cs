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
 *  File: CashDenomination.cs
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

namespace Library.BOL.CashDrawer
{
    [Serializable]
    public sealed class CashDenomination : BaseObject
    {
        #region Constructors

        public CashDenomination(Int64 id, bool isNote, decimal value, decimal linkValue)
        {
            ID = id;
            IsNote = isNote;
            Value = value;
            LinkValue = linkValue;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID for record
        /// </summary>
        public Int64 ID { get; private set; }

        /// <summary>
        /// Indicates wether this is a note or coin
        /// </summary>
        public bool IsNote { get; private set; }

        /// <summary>
        /// Value of currency denomination
        /// </summary>
        public decimal Value { get; private set; }

        /// <summary>
        /// The linked value this denomination is linked to in Cash Drawer Table
        /// </summary>
        public decimal LinkValue { get; private set; }

        #endregion Properties
    }
}
