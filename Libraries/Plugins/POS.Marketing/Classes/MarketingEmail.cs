using System;
using System.Collections.Generic;
using System.Text;

using Library;
using POS.Marketing.Controls;
using SharedControls.WizardBase;

namespace POS.Marketing.Classes
{
    public static class MarketingEmail
    {
        public static bool Run()
        {
            EmailWizardSettings settings = new EmailWizardSettings();

            bool Result = WizardForm.ShowWizard(Languages.LanguageStrings.AppCreateMarketingCampaign,
                new Controls.CreateEmailIntro(settings),
                new Controls.CreateEmailStep1(settings),
                new Controls.CreateEmailStep2(settings),
                new Controls.CreateEmailStep3(settings),
                new Controls.CreateEmailStep4(settings),
                new Controls.CreateEmailStep5(settings),
                new Controls.CreateEmailStep6HomeImage(settings),
                new Controls.CreateEmailStep7PageImage(settings),
                new Controls.CreateEmailStep8(settings),
                new Controls.CreateEmailStep9(settings),
                new Controls.CreateEmailStep10(settings, 1),
                new Controls.CreateEmailStep10(settings, 2),
                new Controls.CreateEmailStep10(settings, 3),
                new Controls.CreateEmailStep10(settings, 4),
                new Controls.CreateEmailStep10(settings, 5),
                new Controls.CreateEmailStep10(settings, 6),
                new Controls.CreateEmailStep10(settings, 7),
                new Controls.CreateEmailStep10(settings, 8),
                new Controls.CreateEmailStep10(settings, 9),
                new Controls.CreateEmailStep11(settings),
                new Controls.CreateEmailStep12(settings),
                new Controls.CreateEmailStep13(settings),
                new Controls.CreateEmailStep14(settings),
                new Controls.CreateEmailStep15(settings)
                );

            return (Result);
        }
    }
}
