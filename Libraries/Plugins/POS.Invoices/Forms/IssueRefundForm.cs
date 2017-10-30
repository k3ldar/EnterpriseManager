﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library.BOL.Users;
using Library.BOL.Invoices;
using Library.BOL.Countries;
using Library.BOL.Refunds;
using Library.Utils;

using POS.Base.Classes;
using POS.Base.Forms;
using POS.Base.Plugins;

namespace POS.Invoices.Forms
{
    public partial class IssueRefundForm : BaseForm
    {
        #region Private Members

        private User _customer;

        #endregion Private Members

        #region Constructors

        public IssueRefundForm()
        {
            InitializeComponent();
            lblUser.Text = LanguageStrings.AppUserSelect;
        }

        public IssueRefundForm(Invoice Invoice, bool AllowViewInvoice = false)
        {
            _customer = Invoice.User;
            InitializeComponent();
            cmbInvoices.Items.Add(Invoice);
            cmbInvoices.SelectedIndex = 0;
            cmbInvoices_SelectedIndexChanged(this, EventArgs.Empty);
            cmbInvoices.Enabled = false;
            btnViewInvoice.Enabled = AllowViewInvoice;
            lblUser.Text = LanguageStrings.AppUserSelect;
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.InvoiceIssueRefund;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnCancel.Text = LanguageStrings.AppCancel;
            btnIssueRefund.Text = LanguageStrings.AppRefundIssue;
            btnSelectUser.Text = LanguageStrings.AppUserSelect;
            btnViewInvoice.Text = LanguageStrings.AppInvoiceView;

            lblInvoiceAmountDesc.Text = LanguageStrings.AppInvoiceAmount;
            lblReason.Text = LanguageStrings.AppRefundReason;
            lblRefundAmount.Text = LanguageStrings.AppRefundAmount;
            lblSelectInvoice.Text = LanguageStrings.AppInvoiceSelect;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void button1_Click(object sender, EventArgs e)
        {
            SelectUser selUser = new SelectUser(false);
            try
            {
                selUser.ShowDialog(this);
                _customer = selUser.SelectedUser;

                if (_customer != null)
                {
                    lblUser.Text = _customer.UserName;

                    cmbInvoices.Items.Clear();

                    foreach (Invoice inv in _customer.Invoices)
                    {
                        if (inv.ID > -1)
                            cmbInvoices.Items.Add(inv);
                    }

                    cmbInvoices.Enabled = true;
                }
            }
            finally
            {
                selUser.Dispose();
                selUser = null;
            }
        }

        private void cmbInvoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            Invoice inv = (Invoice)cmbInvoices.SelectedItem;
            lblInvoiceAmount.Text = inv.TotalCostStr;
            txtRefundAmount.Enabled = true;
            btnViewInvoice.Enabled = true;
            btnSelectUser.Enabled = false;
            lblUser.Text = _customer.UserName;
        }

        private void cmbInvoices_Format(object sender, ListControlConvertEventArgs e)
        {
            Invoice inv = (Invoice)e.ListItem;
            e.Value = AppController.LocalSettings.InvoicePrefix + inv.ID.ToString();
        }

        private void txtReason_TextChanged(object sender, EventArgs e)
        {
            btnIssueRefund.Enabled = txtReason.Text != String.Empty;
        }

        private void btnViewInvoice_Click(object sender, EventArgs e)
        {
            PluginManager.RaiseEvent(new NotificationEventArgs(StringConstants.PLUGIN_EVENT_VIEW_INVOICE, (Invoice)cmbInvoices.SelectedItem));
        }

        private void txtRefundAmount_TextChanged(object sender, EventArgs e)
        {
            Invoice inv = (Invoice)cmbInvoices.SelectedItem;

            decimal refund = Shared.Utilities.StrToDecimal(txtRefundAmount.Text, -0.01m, null);
            txtReason.Enabled = refund > 0.00m && inv.TotalCost >= refund;
        }

        private void btnIssueRefund_Click(object sender, EventArgs e)
        {
            Invoice inv = (Invoice)cmbInvoices.SelectedItem;

            decimal refund = Shared.Utilities.StrToDecimal(txtRefundAmount.Text, -0.01m, null);

            if (refund > 0.00m && inv.TotalCost >= refund)
            {
                Refund.Create(_customer, AppController.ActiveUser, inv, refund, txtReason.Text);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
                ShowError(LanguageStrings.AppRefundCreate, LanguageStrings.AppRefundInvalid);
        }

        #endregion Private Methods
    }
}
