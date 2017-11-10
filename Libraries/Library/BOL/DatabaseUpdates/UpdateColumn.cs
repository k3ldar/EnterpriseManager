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
 *  File: UpdateColumn.cs
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

using Shared;

namespace Library.BOL.DatabaseUpdates
{
    [Serializable]
    public sealed class UpdateColumn
    {
        #region Internal Methods

        internal void Update(string columnValues, string friendlyName)
        {
            FriendlyName = friendlyName;

            string[] items = columnValues.Split('#');

            Name = items[0];
            ColumnType = (ColumnType)Enum.Parse(typeof(ColumnType), items[1], true);
            
            switch (items.Length)
            {
                case 3:
                    MaxValue = items[2];
                    DecimalPlaces = 0;
                    break;
                case 4:
                    MinValue = items[2];
                    MaxValue = items[3];
                    DecimalPlaces = 0;
                    break;
            }
        }

        #endregion Internal Methods

        #region Public Properties

        public string Name { get; set; }

        public string FriendlyName { get; set; }

        public ColumnType ColumnType { get; set; }

        public string MinValue { get; set; }

        public string MaxValue { get; set; }

        public int DecimalPlaces { get; set; }

        public object Value { get; set; }

        #endregion Internal Methods

        #region Public Methods

        public bool GetMinMax(ref decimal minimum, ref decimal maximum)
        {
            if (ColumnType != ColumnType.Decimal)
                throw new Exception("Invalid Column Type");

            minimum = Shared.Utilities.StrToDecimal(MinValue, minimum);
            maximum = Shared.Utilities.StrToDecimal(MaxValue, maximum);
            return (true);
        }


        public bool GetMinMax(ref int minimum, ref int maximum)
        {
            if (ColumnType != ColumnType.Integer)
                throw new Exception("Invalid Column Type");

            minimum = Shared.Utilities.StrToInt(MinValue, minimum);
            maximum = Shared.Utilities.StrToInt(MaxValue, maximum);
            return (true);
        }

        public bool GetMinMax(ref Int64 minimum, ref Int64 maximum)
        {
            if (ColumnType != ColumnType.Int64)
                throw new Exception("Invalid Column Type");

            minimum = Shared.Utilities.StrToInt64(MinValue, minimum);
            maximum = Shared.Utilities.StrToInt64(MaxValue, maximum);
            return (true);
        }

        public int MaxLength(int defaultValue)
        {
            if (ColumnType != ColumnType.String)
                throw new Exception("Invalid Column Type");

            return (Shared.Utilities.StrToInt(MaxValue, defaultValue));
        }

        public decimal GetValue()
        {
            if (ColumnType != Shared.ColumnType.Decimal)
                throw new Exception("Invalid Column Type");

            return ((decimal)Value);
        }

        #endregion Public Methods
    }
}
