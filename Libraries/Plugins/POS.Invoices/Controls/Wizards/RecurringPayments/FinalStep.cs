using System;

using SharedControls.WizardBase;

using Languages;

using Library.BOL.Invoices;

using POS.Base.Classes;
using POS.Invoices.Classes;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace POS.Invoices.Controls.Wizards.RecurringPayments
{
    public partial class FinalStep : BaseWizardPage
    {
        #region Private Members

        private RecurringPaymentOptions _options;

        #endregion Private Members

        #region Constructors

        public FinalStep()
        {
            InitializeComponent();
        }

        public FinalStep(RecurringPaymentOptions options)
            : this()
        {
            _options = options;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
        }

        public override void PageShown()
        {
            AppController.ActiveHelpTopic = HelpTopics.RecurringInvociesCreateFinalStep;

            lblSummary.Text = String.Format(LanguageStrings.AppRecurringInvoiceSummary,
                _options.Invoice.Frequency,
                Base.EnumTranslations.Translate(_options.Invoice.Type),
                _options.Invoice.NextRun.ToShortDateString(),
                String.IsNullOrEmpty(_options.Invoice.Customer.BusinessName) ?
                    _options.Invoice.Customer.UserName :
                    _options.Invoice.Customer.BusinessName,
                _options.Invoice.Items.Count,
                _options.Invoice.Discount);

        }

        public override bool BeforeFinish()
        {
            if (_options.Invoice.ID == -1)
            {

                RecurringInvoices.Add(_options.Invoice.Description,
                    _options.Invoice.Customer, _options.Invoice.NextRun,
                    _options.Invoice.Type, _options.Invoice.Frequency,
                    _options.Invoice.Discount, _options.Invoice.Options, 
                    _options.Invoice.Items);
            }
            else
            {
                _options.Invoice.Save();
            }

            return (true);
        }

        public override bool CanGoNext()
        {
            return base.CanGoNext();
        }

        #endregion Overridden Methods
    }
}
