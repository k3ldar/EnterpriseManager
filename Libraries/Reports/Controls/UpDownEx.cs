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
 *  File: UpDownEx.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace Reports.Controls
{
    /// <summary>
    /// Extended UpDown Control to show size
    /// </summary>
    public class NumericUpDownEx : NumericUpDown
    {
        public NumericUpDownEx()
        {
            SizeValue = "mm";
            DecimalPlaces = 1;
            Maximum = 100.0M;
            Minimum = 0.0M;
            Increment = 0.1M;
        }

        protected override void UpdateEditText()
        {
            this.Text = String.Format("{0} {1}", Value, SizeValue);
        }

        /// <summary>
        /// Size to appended to end of value
        /// </summary>
        public string SizeValue
        {
            get;
            set;
        }
    }
}
