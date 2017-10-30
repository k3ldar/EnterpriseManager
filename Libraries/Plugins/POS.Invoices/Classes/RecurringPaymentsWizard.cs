using System;

using SharedControls.WizardBase;
using Library.BOL.Invoices;
using Library;
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
