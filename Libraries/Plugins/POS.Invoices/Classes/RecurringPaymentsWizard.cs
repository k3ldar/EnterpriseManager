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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: RecurringPaymentsWizard.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using SharedControls.WizardBase;
using SharedBase.BOL.Invoices;
using SharedBase;
using Languages;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation
#pragma warning disable IDE0016 // null check simplified

namespace POS.Invoices.Classes
{
    internal static class RecurringPaymentsWizard
    {
        internal static bool RecurringPaymentUpdate(ref RecurringInvoice invoice)
        {
            RecurringPaymentOptions options = new RecurringPaymentOptions();
            options.IsNew = invoice == null;
            options.Invoice = invoice == null ? 
                new RecurringInvoice(-1, String.Empty, null, DateTime.Now.Date.AddMonths(1),
                RecurringType.Month, 1, 0, RecurringInvoiceOptions.None, null)
                : invoice;

            bool Result = WizardForm.ShowWizard(LanguageStrings.AppCreateRecurringInvoice,
                new Controls.Wizards.RecurringPayments.Step1(options),
                new Controls.Wizards.RecurringPayments.Step2(options),
                new Controls.Wizards.RecurringPayments.FinalStep(options));

            invoice = options.Invoice;

            return (Result);
        }
    }

    public class RecurringPaymentOptions
    {
        public bool IsNew { get; set; }
        public RecurringInvoice Invoice { get; set; }
    }
}
