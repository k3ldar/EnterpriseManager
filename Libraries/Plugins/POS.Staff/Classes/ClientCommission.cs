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
 *  File: ClientCommission.cs
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
