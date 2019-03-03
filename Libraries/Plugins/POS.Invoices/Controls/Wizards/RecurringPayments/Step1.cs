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
 *  File: Step1.cs
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
using SharedBase;
using POS.Base.Classes;
using POS.Base.Forms;
using POS.Invoices.Classes;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace POS.Invoices.Controls.Wizards.RecurringPayments
{
    public partial class Step1 : BaseWizardPage
    {
        #region Private Members

        private RecurringPaymentOptions _options;

        #endregion Private Members

        #region Constructors

        public Step1()
        {
            InitializeComponent();
        }

        public Step1(RecurringPaymentOptions options)
            : this()
        {
            _options = options;
            btnSelectUser.Enabled = options.IsNew;

            foreach (RecurringType option in Enum.GetValues(typeof(RecurringType)))
            {
                int idx = cmbFrequencyType.Items.Add(option);

                if (_options.Invoice != null && _options.Invoice.Type == option)
                {
                    cmbFrequencyType.SelectedIndex = idx;
                }
            }

            if (cmbFrequencyType.SelectedIndex == -1)
                cmbFrequencyType.SelectedIndex = 2; // default monthly


            if (_options.Invoice != null)
            {
                udDiscount.Value = _options.Invoice.Discount;
                udFrequency.Value = _options.Invoice.Frequency;

                if (_options.Invoice.Customer != null)
                {
                    txtCustomer.Text = String.IsNullOrEmpty(_options.Invoice.Customer.BusinessName) ?
                        _options.Invoice.Customer.UserName : _options.Invoice.Customer.BusinessName;
                }

                txtDescription.Text = _options.Invoice.Description;
                dtpNextRun.Value = _options.Invoice.NextRun;
                cbSendEmailInvoice.Checked = _options.Invoice.Options.HasFlag(RecurringInvoiceOptions.SendEmail);
            }
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnSelectUser.Text = LanguageStrings.AppMenuButtonSelect;

            lblCustomer.Text = LanguageStrings.AppCustomer;
            lblDescription.Text = LanguageStrings.Description;
            lblDiscount.Text = LanguageStrings.Discount;
            lblFrequency.Text = LanguageStrings.AppFrequency;
            lblFrequencyType.Text = LanguageStrings.AppRepeatFrequency;
            lblNextRun.Text = LanguageStrings.NextRun;
            cbSendEmailInvoice.Text = LanguageStrings.SendEmail;
        }

        public override void PageShown()
        {
            AppController.ActiveHelpTopic = HelpTopics.RecurringInvociesCreateStep1;
        }

        public override bool NextClicked()
        {
            if (String.IsNullOrEmpty(txtCustomer.Text))
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppSelectCustomerDescription);
                return (false);
            }

            if (String.IsNullOrEmpty(txtDescription.Text) || txtDescription.Text.Length < 10)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppPleaseEnterADescription);
                return (false);
            }

            _options.Invoice.Discount = udDiscount.Value;
            _options.Invoice.Description = txtDescription.Text;
            _options.Invoice.Frequency = (int)udFrequency.Value;
            _options.Invoice.Type = (RecurringType)cmbFrequencyType.SelectedItem;
            _options.Invoice.NextRun = dtpNextRun.Value.Date;
            _options.Invoice.Options = cbSendEmailInvoice.Checked ? RecurringInvoiceOptions.SendEmail : RecurringInvoiceOptions.None;

            return (base.NextClicked());
        }

        public override bool CanGoNext()
        {
            return base.CanGoNext();
        }

        public override bool BeforeFinish()
        {
            return base.BeforeFinish();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnSelectUser_Click(object sender, EventArgs e)
        {
            SelectUser selUser = new SelectUser(false);
            try
            {
                selUser.ShowDialog(this);
                _options.Invoice.Customer = selUser.SelectedUser;

                if (_options.Invoice.Customer != null)
                {
                    txtCustomer.Text = String.IsNullOrEmpty(_options.Invoice.Customer.BusinessName) ?
                        _options.Invoice.Customer.UserName : _options.Invoice.Customer.BusinessName;
                }
            }
            finally
            {
                selUser.Dispose();
                selUser = null;
            }
        }

        #endregion Private Methods
    }
}
