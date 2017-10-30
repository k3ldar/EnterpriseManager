using System;
using System.Collections.Generic;
using System.Text;

using Languages;
using Library.BOL.Staff;
using SharedControls.WizardBase;

namespace POS.Staff.Classes
{
    internal static class BonusPaymentWizard
    {
        internal static void GenerateBonusPayment()
        {
            PayCommissionSettings settings = new PayCommissionSettings(POS.Base.Classes.AppController.LocalCurrency);

            WizardForm.ShowWizard(LanguageStrings.AppCommissionBonusPaymentWizard,
               new Controls.Wizards.Commission.BonusPayments.Step1(settings),
               new Controls.Wizards.Commission.BonusPayments.Step2(settings),
               new Controls.Wizards.Commission.BonusPayments.Step3(settings),
               new Controls.Wizards.Commission.BonusPayments.Step4(settings),
               new Controls.Wizards.Commission.BonusPayments.Step5(settings));

        }
    }
}
