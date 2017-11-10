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
 *  File: CustomLabel.cs
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
    [Serializable]
    public class CustomLabel : BaseLabel
    {
        public CustomLabel() { }

        public CustomLabel(double labelWidth, double labelHeight, double horizontalGap, double verticalGap,
            double marginTop, double marginBottom, double marginLeft, double marginRight, int rows, int columns)
        {
            _Width = labelWidth;
            _Height = labelHeight;
            _HorizontalGapWidth = horizontalGap;
            _VerticalGapHeight = verticalGap;

            _PageMarginTop = marginTop;
            _PageMarginBottom = marginBottom;
            _PageMarginLeft = marginLeft;
            _PageMarginRight = marginRight;

            LabelsPerRow = rows;
            LabelRowsPerPage = columns;
        }


        /// <summary>
        /// The width of 1 label
        /// </summary>
        public double LabelWidth
        {
            get 
            { 
                return (_Width); 
            }

            set
            {
                _Width = value;
            }
        }

        /// <summary>
        /// The height of 1 label
        /// </summary>
        public double LabelHeight
        {
            get 
            { 
                return (_Height); 
            }

            set
            {
                _Height = value;
            }
        }

        /// <summary>
        /// The width of the horizontal gap between labels
        /// </summary>
        public double HorizontalGap
        {
            get 
            { 
                return (_HorizontalGapWidth); 
            }

            set
            {
                _HorizontalGapWidth = value;
            }
        }

        /// <summary>
        /// The height of the vertical gap between labels
        /// </summary>
        public double VerticalGap
        {
            get
            {
                return (_VerticalGapHeight);
            }

            set
            {
                _VerticalGapHeight = value;
            }
        }

        /// <summary>
        /// The left page margin
        /// </summary>
        public double MLeft
        {
            get 
            { 
                return (_PageMarginLeft); 
            }

            set
            {
                _PageMarginLeft = value;
            }
        }

        /// <summary>
        /// The right page margin
        /// </summary>
        public double MRight
        {
            get 
            { 
                return (_PageMarginRight); 
            }

            set
            {
                _PageMarginRight = value;
            }
        }

        /// <summary>
        /// The top page margin
        /// </summary>
        public double MTop
        {
            get 
            { 
                return (_PageMarginTop); 
            }

            set
            {
                _PageMarginTop = value;
            }
        }

        /// <summary>
        /// The bottom page margin
        /// </summary>
        public double MBottom
        {
            get 
            { 
                return (_PageMarginBottom); 
            }

            set
            {
                _PageMarginBottom = value;
            }
        }
    }
}
