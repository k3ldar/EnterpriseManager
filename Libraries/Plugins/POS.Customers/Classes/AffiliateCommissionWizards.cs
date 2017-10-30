using System;
using System.Collections.Generic;
using System.Text;

using Languages;
using Library.BOL.Affiliate;
using SharedControls.WizardBase;

namespace POS.Customers.Classes
{
    internal static class AffiliateCommissionWizards
    {
        internal static void CommissionAffiliatePay()
        {
            PayAffiliateCommissionSettings settings = new PayAffiliateCommissionSettings(POS.Base.Classes.AppController.LocalCurrency);

            WizardForm.ShowWizard(LanguageStrings.AppCommissionPayCommission,
               new Controls.Wizards.Affiliate.PayCommission.Step1(settings),
               new Controls.Wizards.Affiliate.PayCommission.Step2(settings),
               new Controls.Wizards.Affiliate.PayCommission.Step3(settings));
        }

        internal static void CommissionAffiliatePay(AffiliateCommission commisionItems)
        {
            PayAffiliateCommissionSettings settings = new PayAffiliateCommissionSettings(POS.Base.Classes.AppController.LocalCurrency);
            settings.CommissionItems = commisionItems;
            //settings.Pool = CommissionPools.Get(commisionItems[0].CommissionPoolID);

            WizardForm.ShowWizard(LanguageStrings.AppCommissionPayCommission,
               new Controls.Wizards.Affiliate.PayCommission.Step2(settings),
               new Controls.Wizards.Affiliate.PayCommission.Step3(settings));
        }
    }
}
