using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library;
using POS.Base.Classes;

namespace POS.Staff.Controls.Settings
{
    public partial class CommissionPoolSettings : SharedControls.BaseSettings
    {
        #region Constructors

        public CommissionPoolSettings()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            rbYearlyPayments.Text = LanguageStrings.AppCommissionYearlyPayments;
            rbContinuousPayments.Text = LanguageStrings.AppCommissionContinualPayments;
            lblWait.Text = LanguageStrings.AppWait;
            lblWaitDescription.Text = LanguageStrings.AppCommissionWaitDescription;

        }

        public override bool SettingsSave()
        {
            if (rbContinuousPayments.Checked)
            {
                Library.LibraryHelperClass.SettingsSet(StringConstants.COMMISSION_POOL_MONTHS, udMonthsToWait.Value.ToString());
            }
            else
            {
                string m = Convert.ToString(dtpYearly.Value.Month + 20);
                string d = Convert.ToString(dtpYearly.Value.Day + 20);

                Library.LibraryHelperClass.SettingsSet(StringConstants.COMMISSION_POOL_MONTHS, m + d);
                Library.LibraryHelperClass.SettingsSet(StringConstants.COMMISSION_POOL_MIN_WAiT, udMonthsToWait.Value.ToString());
            }

            return (base.SettingsSave());
        }

        public override void SettingsLoaded()
        {
            int months = Shared.Utilities.StrToIntDef(Library.LibraryHelperClass.SettingsGet(StringConstants.COMMISSION_POOL_MONTHS, StringConstants.SYMBOL_THREE), 3);
            int minMonths = Shared.Utilities.StrToIntDef(Library.LibraryHelperClass.SettingsGet(StringConstants.COMMISSION_POOL_MIN_WAiT, StringConstants.SYMBOL_TWO), 2);

            if (months > 12)
            {
                udMonthsToWait.Value = minMonths;
                rbYearlyPayments.Checked = true;

                string m = months.ToString().Substring(0, 2);
                string d = months.ToString().Substring(2, 2);

                dtpYearly.Value = new DateTime(2016, Convert.ToInt32(m) - 20, Convert.ToInt32(d) - 20);
            }
            else
            {
                udMonthsToWait.Value = months;
                rbContinuousPayments.Checked = true;
            }
        }

        #endregion Overridden Methods

        #region Private Methods

        private void rbYearlyPayments_CheckedChanged(object sender, EventArgs e)
        {
            dtpYearly.Enabled = rbYearlyPayments.Checked;
        }

        #endregion Private Methods
    }
}
