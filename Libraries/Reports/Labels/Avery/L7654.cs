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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: L7654.cs
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

namespace Reports.Labels
{
    /// <summary>
    /// Dimensions: 45.7mm x 25.4mm 
    /// Per Sheet: 40 per sheet 
    /// Inkjet code: J8654
    /// </summary>
    public class L7654 : BaseLabel
    {
        public L7654()
        {
            _Width = 45.7;
            _Height = 25.4;
            _HorizontalGapWidth = 2.6;
            _VerticalGapHeight = 0;
            
            _PageMarginTop = 21.4;
            _PageMarginBottom = 21.4;
            _PageMarginLeft = 9.7;
            _PageMarginRight = 9.7;

            PageSize = Enums.PageSize.A4;
            LabelsPerRow = 4;
            LabelRowsPerPage = 10;
        }

        public override string ToString()
        {
            return ("Avery Label L7654");
        }
    }
}
