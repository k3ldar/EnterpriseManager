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
 *  File: RecurringInvocesControl.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using Languages;
using SharedBase.BOL.Invoices;
using POS.Base.Classes;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace POS.Invoices.Controls
{
    public partial class RecurringInvocesControl : Base.Controls.BaseOptionsControl
    {
        #region Constructors

        public RecurringInvocesControl()
        {
            InitializeComponent();

            LoadRecurringPayments();

            RebuildContextMenu(toolStripMain, contextMenuRecurring);
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            this.Text = LanguageStrings.AppCustomersAdministration;

            colHeaderDescription.Text = LanguageStrings.Description;
            colHeaderBusinessName.Text = LanguageStrings.BusinessName;
            colHeaderUsername.Text = LanguageStrings.AppCustomer;
            colHeaderNextRun.Text = LanguageStrings.NextRun;
            colHeaderFrequency.Text = LanguageStrings.AppFrequency;
            colHeaderPeriod.Text = LanguageStrings.AppRepeatFrequency;
            colHeaderDiscount.Text = LanguageStrings.Discount;

            foreach (ListViewItem item in lstRecurringInvoices.Items)
            {
                RecurringInvoice inv = (RecurringInvoice)item.Tag;
                item.SubItems[5].Text = Base.EnumTranslations.Translate(inv.Type);
            }
        }

        protected override void OnRefreshClicked()
        {
            base.OnRefreshClicked();

            LoadRecurringPayments();
        }

        protected override void OnSaveClicked()
        {
            base.OnSaveClicked();
        }

        protected override void OnCreateClicked()
        {
            RecurringInvoice inv = null;

            if (Classes.RecurringPaymentsWizard.RecurringPaymentUpdate(ref inv))
            {
                ListViewItem item = new ListViewItem(inv.Description);
                item.Tag = inv;

                item.SubItems.Add(inv.Customer.BusinessName);
                item.SubItems.Add(inv.Customer.UserName);
                item.SubItems.Add(inv.NextRun.ToShortDateString());
                item.SubItems.Add(inv.Frequency.ToString());
                item.SubItems.Add(Base.EnumTranslations.Translate(inv.Type));
                item.SubItems.Add(inv.Discount.ToString() + StringConstants.SYMBOL_PERCENT);

                lstRecurringInvoices.Items.Add(item);
            }
        }

        protected override void OnDeleteClicked()
        {
            if (lstRecurringInvoices.SelectedItems.Count > 0)
            {
                if (ShowQuestion(LanguageStrings.AppDelete, LanguageStrings.AppDeleteRecurringPaymentConfirm))
                {
                    RecurringInvoice inv = (RecurringInvoice)lstRecurringInvoices.SelectedItems[0].Tag;
                    inv.Delete();
                    lstRecurringInvoices.Items.Remove(lstRecurringInvoices.SelectedItems[0]);
                }
            }
            else
            {
                ShowInformation(LanguageStrings.AppDelete, LanguageStrings.AppDeleteRecurringPayment);
            }
        }

        protected override void OnEditClicked()
        {
            foreach (ListViewItem item in lstRecurringInvoices.SelectedItems)
            {
                RecurringInvoice inv = (RecurringInvoice)item.Tag;

                if (Classes.RecurringPaymentsWizard.RecurringPaymentUpdate(ref inv))
                {
                    item.Text = inv.Description;
                    item.SubItems[1].Text = inv.Customer.BusinessName;
                    item.SubItems[2].Text = inv.Customer.UserName;
                    item.SubItems[3].Text = inv.NextRun.ToShortDateString();
                    item.SubItems[4].Text = inv.Frequency.ToString();
                    item.SubItems[5].Text = Base.EnumTranslations.Translate(inv.Type);
                    item.SubItems[6].Text = inv.Discount.ToString() + StringConstants.SYMBOL_PERCENT;
                }
            }

            UpdateUI();
        }

        #endregion Overridden Methods

        #region Public Methods

        public override int GetStatusCount()
        {
            return (1);
        }

        public override string GetStatusText(int index)
        {
            return (String.Format(LanguageStrings.AppRecurringInvoicesCount, lstRecurringInvoices.Items.Count));
        }

        public override string GetStatusHint(int index)
        {
            return (String.Empty);
        }

        #endregion Public Methods

        #region Private Methods

        private void UpdateUI()
        {
            AllowAddNew = true;
            AllowDelete = lstRecurringInvoices.SelectedItems.Count > 0;
            AllowEdit = AllowDelete;
            AllowRefresh = true;
            

            base.UpdateUI(AllowDelete);
        }

        private void lstUsers_DoubleClick(object sender, EventArgs e)
        {
            OnEditClicked();
        }
        
        private void LoadRecurringPayments()
        {
            lstRecurringInvoices.BeginUpdate();
            try
            {
                lstRecurringInvoices.Items.Clear();

                foreach (RecurringInvoice invoice in RecurringInvoices.All())
                {
                    ListViewItem item = new ListViewItem(invoice.Description);
                    item.Tag = invoice;

                    item.SubItems.Add(invoice.Customer.BusinessName);
                    item.SubItems.Add(invoice.Customer.UserName);
                    item.SubItems.Add(invoice.NextRun.ToShortDateString());
                    item.SubItems.Add(invoice.Frequency.ToString());
                    item.SubItems.Add(POS.Base.EnumTranslations.Translate(invoice.Type));
                    item.SubItems.Add(invoice.Discount.ToString() + StringConstants.SYMBOL_PERCENT);

                    lstRecurringInvoices.Items.Add(item);
                }
            }
            finally
            {
                lstRecurringInvoices.EndUpdate();
            }

            UpdateUI();
        }

        private void lstRecurringInvoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        #endregion Private Methods
    }
}
