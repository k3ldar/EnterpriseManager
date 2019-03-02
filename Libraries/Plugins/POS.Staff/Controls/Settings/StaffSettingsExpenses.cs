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
 *  File: StaffSettingsExpenses.cs
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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

using Languages;
using SharedBase.Utils;
using POS.Base.Classes;

namespace POS.Staff.Controls.Settings
{
    public partial class StaffSettingsExpenses : SharedControls.BaseSettings
    {
        public StaffSettingsExpenses()
        {
            InitializeComponent();
        }

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblFirstCurrency.Text = SharedUtils.GetCurrencySymbol(AppController.LocalCulture);
            lblSecondCurrency.Text = SharedUtils.GetCurrencySymbol(AppController.LocalCulture);
            lblFirstFor.Text = LanguageStrings.AppExpensesFirstMileage;
            lblFirstMiles.Text = LanguageStrings.AppExpensesFirstMileageType;
            lblSecondFor.Text = LanguageStrings.AppExpensesMileageRemaining;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.ExpensesMileageFirstX = udFirstMiles.Value;
            AppController.LocalSettings.ExpensesMileageRate1 = udFirstRate.Value;
            AppController.LocalSettings.ExpensesMileageRate2 = udSecondRate.Value;

            return (base.SettingsSave());
        }

        public override void SettingsLoaded()
        {
            udFirstMiles.Value = AppController.LocalSettings.ExpensesMileageFirstX;
            udFirstRate.Value = AppController.LocalSettings.ExpensesMileageRate1;
            udSecondRate.Value = AppController.LocalSettings.ExpensesMileageRate2;
        }

        public override void SettingShown()
        {
            AppController.ActiveHelpTopic = Base.Classes.HelpTopics.StaffExpensesSettings;
        }

        #endregion Overridden Methods

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
