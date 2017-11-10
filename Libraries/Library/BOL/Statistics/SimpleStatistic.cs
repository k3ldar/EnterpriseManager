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
 *  File: SimpleStatistic.cs
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

namespace Library.BOL.Statistics
{
    [Serializable]
    public sealed class SimpleStatistic
    {
        #region Constructor

        public SimpleStatistic(string productName, string URL, string title, 
            int hashTagCount, string description)
        {
            Description = productName;
            Name1 = URL;
            Name2 = title;
            Name3 = description;
            Count = hashTagCount;
        }

        public SimpleStatistic (string sku, string productName, string productSize, int count)
        {
            Name1 = sku;
            Name2 = productName;
            Name3 = productSize;
            Count = count;
        }

        public SimpleStatistic (string description, int count)
        {
            Count = count;
            Description = description;
        }

        public SimpleStatistic(string description, int count, decimal value1)
        {
            Count = count;
            Description = description;
            Value1 = value1;
        }


        public SimpleStatistic(string description, decimal value1, decimal value2)
        {
            Description = description;
            Value1 = value1;
            Value2 = value2;
        }

        public SimpleStatistic(string description, string other, int count, decimal value1, decimal value2, DateTime dateValue)
            : this(description, value1, value2)
        {
            Count = count;
            StringValue1 = other;
            DateValue = dateValue;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Website Description
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Additional string value
        /// </summary>
        public string StringValue1 { get; private set; }

        /// <summary>
        /// Website Count
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Variable decimal Value, optional
        /// </summary>
        public decimal Value1 { get; private set; }

        /// <summary>
        /// Variable decimal value, optional
        /// </summary>
        public decimal Value2 { get; private set; }

        /// <summary>
        /// Variable DateTime value, optional
        /// </summary>
        public DateTime DateValue { get; private set; }


        public string Name1 { get; private set; }

        public string Name2 { get; private set; }


        public string Name3 { get; private set; }

        #endregion Properties
    }
}
