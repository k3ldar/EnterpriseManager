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
using Library.Utils;
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
