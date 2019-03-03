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
 *  File: L7160.cs
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
    /// Dimensions: 63.5mm x 38.1mm 
    /// Per Sheet: 21 per sheet 
    /// Inkjet code: J8160
    /// </summary>
    public class L7160 : BaseLabel
    {
        public L7160()
        {
            _Width = 63.5;
            _Height = 38.1;
            _HorizontalGapWidth = 2.5;
            _VerticalGapHeight = 0;
            
            _PageMarginTop = 15.1;
            _PageMarginBottom = 15.1;
            _PageMarginLeft = 7.2;
            _PageMarginRight = 7.2;

            PageSize = Enums.PageSize.A4;
            LabelsPerRow = 3;
            LabelRowsPerPage = 7;
        }

        public override string ToString()
        {
            return ("Avery Label L7160");
        }
    }
}
