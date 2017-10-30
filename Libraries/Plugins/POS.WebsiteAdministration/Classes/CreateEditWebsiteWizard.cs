using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library.BOL.Websites;

namespace POS.WebsiteAdministration.Classes
{
    public static class CreateEditWebsiteWizard
    {
        public static bool EditWebsite(Website website)
        {
            WebsiteWizardSettings settings = new WebsiteWizardSettings();
            settings.Website = website;

            return (SharedControls.WizardBase.WizardForm.ShowWizard(
                Languages.LanguageStrings.AppWebsiteEdit,
                new Controls.Wizards.Website.WebsiteAddUpdateStep1(settings)));
        }

        public static bool CreateWebsite(ref Website website)
        {
            WebsiteWizardSettings settings = new WebsiteWizardSettings();
            
            if (SharedControls.WizardBase.WizardForm.ShowWizard(
                Languages.LanguageStrings.AppWebsiteEdit,
                new Controls.Wizards.Website.WebsiteAddUpdateStep1(settings)))
            {
                website = settings.Website;
                return (true);
            }
            else
            {
                return (false);
            }
        }
    }

    public class WebsiteWizardSettings
    {
        public Website Website { get; set; }
    }
}
