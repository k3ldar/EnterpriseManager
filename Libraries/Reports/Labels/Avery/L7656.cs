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
 *  File: L7656.cs
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
    /// Dimensions: 46mm x 11.1mm 
    /// Per Sheet: 84 per sheet 
    /// Inkjet code: J8657
    /// </summary>
    public class L7656 : BaseLabel
    {        
        public L7656()
        {
            _Width = 46;
            _Height = 11.1;
            _HorizontalGapWidth = 4.7;
            _VerticalGapHeight = 1.6;

            _PageMarginTop = 15.9;
            _PageMarginBottom = 15.9;
            _PageMarginLeft = 6;
            _PageMarginRight = 6;

            PageSize = Enums.PageSize.A4;
            LabelsPerRow = 4;
            LabelRowsPerPage = 21;
        }

        public override string ToString()
        {
            return ("Avery Label L7656");
        }
    }
}
