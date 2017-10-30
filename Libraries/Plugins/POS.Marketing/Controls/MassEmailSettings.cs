using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace POS.Marketing.Controls
{
    public partial class MassEmailSettings : SharedControls.BaseSettings
    {
        public MassEmailSettings()
        {
            InitializeComponent();
        }

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblSelectOptions.Text = Languages.LanguageStrings.AppSelectOptionLeft;
        }
    }
}
