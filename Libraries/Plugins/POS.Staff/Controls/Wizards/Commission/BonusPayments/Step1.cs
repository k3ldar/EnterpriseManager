using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library.BOL.Staff;
using POS.Staff.Classes;

namespace POS.Staff.Controls.Wizards.Commission.BonusPayments
{
    public partial class Step1 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private PayCommissionSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step1(PayCommissionSettings settings)
        {
            InitializeComponent();

            _settings = settings;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblEnterPaymentAmount.Text = LanguageStrings.AppCommissionBonusEnterPaymentAmount;
        }

        public override bool NextClicked()
        {
            if (udPaymentAmount.Value < 0.01m)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppCommissionBonusInvalidAmount);
                return (false);
            }

            _settings.TotalPoolValue = udPaymentAmount.Value;

            return (base.NextClicked());
        }

        #endregion Overridden Methods
    }
}
