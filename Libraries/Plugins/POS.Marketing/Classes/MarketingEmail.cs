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
 *  File: MarketingEmail.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
