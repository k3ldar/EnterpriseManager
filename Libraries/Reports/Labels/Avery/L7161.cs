using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Labels
{
    /// <summary>
    /// Dimensions: 63.5mm x 46.6mm 
    /// Per Sheet: 18 per sheet 
    /// Inkjet code: J8160
    /// </summary>
    public class L7161 : BaseLabel
    {
        public L7161()
        {
            _Width = 63.5;
            _Height = 46.6;
            _HorizontalGapWidth = 2.5;
            _VerticalGapHeight = 0;

            _PageMarginTop = 8.5;
            _PageMarginBottom = 8.5;
            _PageMarginLeft = 7;
            _PageMarginRight = 7;

            PageSize = Enums.PageSize.A4;
            LabelsPerRow = 3;
            LabelRowsPerPage = 6;
        }

        public override string ToString()
        {
            return ("Avery Label L7161 (18 x 3)");
        }
    }
}
