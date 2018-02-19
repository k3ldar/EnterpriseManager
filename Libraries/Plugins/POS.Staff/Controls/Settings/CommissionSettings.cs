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
 *  File: CommissionSettings.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS.Staff.Controls.Settings
{
    public partial class CommissionSettings : SharedControls.BaseSettings
    {
        public CommissionSettings()
        {
            InitializeComponent();
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            csDueSoonBack.Description = Languages.LanguageStrings.AppDueSoonBackColor;
            csDueSoonFore.Description = Languages.LanguageStrings.AppDueSoonForeColor;
            csOverdueBack.Description = Languages.LanguageStrings.AppOverdueBackColor;
            csOverdueFore.Description = Languages.LanguageStrings.AppOverdueForeColor;
            csSelectedBack.Description = Languages.LanguageStrings.AppSelectedBackColor;
            csSelectedFore.Description = Languages.LanguageStrings.AppSelectedForeColor;

            lblDays.Text = Languages.LanguageStrings.Days;
            lblDueSoon.Text = Languages.LanguageStrings.AppCommissionDataDue;
        }

        public override bool SettingsSave()
        {
            POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonBackColor = csDueSoonBack.Color.ToArgb().ToString();
            POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonForeColor = csDueSoonFore.Color.ToArgb().ToString();
            POS.Base.Classes.AppController.LocalSettings.CommissionOverDueBackColor = csOverdueBack.Color.ToArgb().ToString();
            POS.Base.Classes.AppController.LocalSettings.CommissionOverDueForeColor = csOverdueFore.Color.ToArgb().ToString();
            POS.Base.Classes.AppController.LocalSettings.CommissionSelectedBackColor = csSelectedBack.Color.ToArgb().ToString();
            POS.Base.Classes.AppController.LocalSettings.CommissionSelectedForeColor = csSelectedFore.Color.ToArgb().ToString();

            POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonDays = (int)udDueSoon.Value;

            return (base.SettingsSave());
        }

        public override void SettingsLoaded()
        {
            csDueSoonBack.Color = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonBackColor);
            csDueSoonFore.Color = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonForeColor);
            csOverdueBack.Color = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionOverDueBackColor);
            csOverdueFore.Color = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionOverDueForeColor);
            csSelectedBack.Color = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionSelectedBackColor);
            csSelectedFore.Color = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionSelectedForeColor);
            udDueSoon.Value = POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonDays;
        }

        #endregion Overridden Methods
    }
}
