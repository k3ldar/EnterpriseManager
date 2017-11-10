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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: CreateEditWebsiteWizard.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
