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
 *  File: BonusPaymentWizard.cs
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
