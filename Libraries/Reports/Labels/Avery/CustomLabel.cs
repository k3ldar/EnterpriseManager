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
