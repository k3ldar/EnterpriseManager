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
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: AffiliateCommissionWizards.cs
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
