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
