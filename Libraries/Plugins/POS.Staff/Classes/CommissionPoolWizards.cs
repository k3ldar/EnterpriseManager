using System;
using System.Collections.Generic;
using System.Text;

using Languages;
using Library.BOL.Staff;
using SharedControls.WizardBase;

namespace POS.Staff.Classes
{
    internal static class CommissionPoolsWizards
    {
        internal static void GenerateCommissionPoolData()
        {
            bool Result = WizardForm.ShowWizard(LanguageStrings.AppCommissionRegenerate,
               new Controls.Wizards.Commission.PoolGenerate.Step1());
        }

        internal static void CommissionPoolPay()
        {
            PayCommissionSettings settings = new PayCommissionSettings(POS.Base.Classes.AppController.LocalCurrency);

            WizardForm.ShowWizard(LanguageStrings.AppCommissionPayCommission,
               new Controls.Wizards.Commission.PoolPayCommission.Step1(settings),
               new Controls.Wizards.Commission.PoolPayCommission.Step2(settings),
               new Controls.Wizards.Commission.PoolPayCommission.Step3(settings),
               new Controls.Wizards.Commission.PoolPayCommission.Step4(settings),
               new Controls.Wizards.Commission.PoolPayCommission.Step5(settings));
        }

        internal static void CommissionPoolPay(StaffCommission commisionItems)
        {
            PayCommissionSettings settings = new PayCommissionSettings(POS.Base.Classes.AppController.LocalCurrency);
            settings.CommissionItems = commisionItems;
            settings.Pool = CommissionPools.Get(commisionItems[0].CommissionPoolID);

            WizardForm.ShowWizard(LanguageStrings.AppCommissionPayCommission,
               new Controls.Wizards.Commission.PoolPayCommission.Step2(settings),
               new Controls.Wizards.Commission.PoolPayCommission.Step3(settings),
               new Controls.Wizards.Commission.PoolPayCommission.Step4(settings),
               new Controls.Wizards.Commission.PoolPayCommission.Step5(settings));
        }
    }
}
