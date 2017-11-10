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
 *  File: FinalStep.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
