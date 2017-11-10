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
 *  File: BaseLabel.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  10/11/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
 *  File: BaseLabel.cs
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
    /// The base class for a Label, all the actual label definition classes derive from this
    /// Dimensions and margins are defined in mm but converted to Points when read back (for use in iTextSharp)
    /// </summary>
    public abstract class BaseLabel
    {
        /// <summary>
        /// The width of 1 label
        /// </summary>
        protected double _Width;
        public float Width
        {
            get { return mmToPoint(_Width); }
        }

        /// <summary>
        /// The height of 1 label
        /// </summary>
        protected double _Height;
        public float Height
        {
            get { return mmToPoint(_Height); }
        }

        /// <summary>
        /// The width of the horizontal gap between labels
        /// </summary>
        protected double _HorizontalGapWidth;
        public float HorizontalGapWidth
        {
            get { return mmToPoint(_HorizontalGapWidth); }
        }

        /// <summary>
        /// The height of the vertical gap between labels
        /// </summary>
        protected double _VerticalGapHeight;
        public float VerticalGapHeight
        {
            get { return mmToPoint(_VerticalGapHeight); }
        }

        /// <summary>
        /// The left page margin
        /// </summary>
        protected double _PageMarginLeft;
        public float PageMarginLeft
        {
            get { return mmToPoint(_PageMarginLeft); }
        }

        /// <summary>
        /// The right page margin
        /// </summary>
        protected double _PageMarginRight;
        public float PageMarginRight
        {
            get { return mmToPoint(_PageMarginRight); }
        }

        /// <summary>
        /// The top page margin
        /// </summary>
        protected double _PageMarginTop;
        public float PageMarginTop
        {
            get { return mmToPoint(_PageMarginTop); }
        }

        /// <summary>
        /// The bottom page margin
        /// </summary>
        protected double _PageMarginBottom;
        public float PageMarginBottom
        {
            get { return mmToPoint(_PageMarginBottom); }
        }

        /* page definitions */
        
        /// <summary>
        /// The paper size
        /// </summary>
        public Enums.PageSize PageSize { get; set; }
        
        
        /// <summary>
        /// The number of labels running across the page
        /// </summary>
        public int LabelsPerRow { get; set; }
        
        
        /// <summary>
        /// The number of labels running down the page
        /// </summary>
        public int LabelRowsPerPage { get; set; }


        /// <summary>
        /// iTextSharp uses points as its units
        /// </summary>
        /// <param name="mm">Millimetres to convert</param>
        /// <returns>millimetres converted to points represented by a float</returns>
        private float mmToPoint(double mm)
        {
            return (float)((mm / 25.4) * 72);
        }

    }
}
