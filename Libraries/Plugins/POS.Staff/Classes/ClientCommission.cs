using System;
using System.Collections.Generic;
using System.Text;

using Languages;
using Library.BOL.Staff;
using SharedControls.WizardBase;

namespace POS.Staff.Classes
{
    internal static class ClientCommission
    {
        internal static void GenerateClientCommissionData()
        {
            bool Result = WizardForm.ShowWizard(LanguageStrings.AppCommissionClientGenerate,
               new Controls.Wizards.Commission.ClientGenerate.Step1());
        }

        internal static bool PayClientCommission(ref DateTime datePaid)
        {
            Controls.Wizards.Commission.ClientPay.Step1 step1 = new Controls.Wizards.Commission.ClientPay.Step1();
            step1.PayDate = datePaid;

            bool Result = WizardForm.ShowWizard(LanguageStrings.AppCommissionClientPay, step1);

            if (Result)
                datePaid = step1.PayDate;

            return (Result);
        }
    }
}
