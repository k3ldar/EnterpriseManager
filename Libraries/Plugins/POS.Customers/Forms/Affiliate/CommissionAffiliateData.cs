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
 *  File: CommissionAffiliateData.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Drawing;
using System.Windows.Forms;

using Languages;
using Library.BOL.Affiliate;
using Library.BOL.Users;
using Library.Utils;

namespace POS.Customers.Forms
{
    public partial class AffiliateData : POS.Base.Controls.BaseTabControl
    {
        #region Constructors

        public AffiliateData()
        {
            InitializeComponent();

            statusStripAffiliate.Visible = false;
            gridCommission.Height += 25;

            DueSoonBack = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonBackColor);
            DueSoonFore = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonForeColor);
            OverdueBack = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionOverDueBackColor);
            OverdueFore = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionOverDueForeColor);
            SelectedBack = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionSelectedBackColor);
            SelectedFore = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionSelectedForeColor);

            if (POS.Base.Classes.AppController.ApplicationRunning)
                LoadUsers();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblSelectUser.Text = LanguageStrings.AppAffiliateSelectUser;
            lblDateFrom.Text = LanguageStrings.AppDateFrom;
            lblDateTo.Text = LanguageStrings.AppDateTo;

            rbAll.Text = LanguageStrings.AppAll;
            rbPaid.Text = LanguageStrings.AppPaid;
            rbUnpaid.Text = LanguageStrings.AppUnpaid;

            menuStripSelectAll.Text = LanguageStrings.AppMenuSelectAll;
            menuStripUnselectAll.Text = LanguageStrings.AppMenuUnSelectAll;
            menuStripInvert.Text = LanguageStrings.AppMenuInvertSelection;

            btnSearch.Text = LanguageStrings.Search;
        }

        public override int GetStatusCount()
        {
            return (statusStripAffiliate.Items.Count);
        }

        public override string GetStatusHint(int index)
        {
            return (statusStripAffiliate.Items[index].ToolTipText);
        }

        public override string GetStatusText(int index)
        {
            return (statusStripAffiliate.Items[index].Text);
        }

        #endregion Overridden Methods

        #region Properties

        private Color OverdueBack { get; set; }

        private Color OverdueFore { get; set; }

        private Color DueSoonBack { get; set; }

        private Color DueSoonFore { get; set; }

        private Color SelectedBack { get; set; }

        private Color SelectedFore { get; set; }

        #endregion Properties

        #region Private Methods

        private void LoadUsers()
        {
            cmbUsers.Items.Clear();
            cmbUsers.Items.Add(new User(-1, LanguageStrings.AppAll));

            foreach (User user in AffiliatedItems.GetAffiliateUsers())
                cmbUsers.Items.Add(user);

            cmbUsers.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                User user = (User)cmbUsers.SelectedItem;

                if (user.ID == -1)
                    user = null;

                bool isPaid = rbAll.Checked | rbPaid.Checked;
                bool isUnpaid = rbAll.Checked | rbUnpaid.Checked;

                AffiliateCommission affiliateData = AffiliateCommission.Get(user, dtpFrom.Value, dtpTo.Value, isPaid, isUnpaid);

                gridCommission.DataSource = affiliateData;

                decimal commissionDue = 0;
                decimal invoiceTotal = 0;
                decimal commissionableTotal = 0;

                foreach (AffiliateCommissionItem item in affiliateData)
                {
                    commissionDue += item.CommissionDue;
                    invoiceTotal += item.InvoiceTotal;
                    commissionableTotal += item.CommissionableTotal;
                }

                toolStripStatusCount.Text = String.Format(LanguageStrings.AppCount, affiliateData.Count);
                toolStripStatusTotal.Text = String.Format(LanguageStrings.AppCommissionDue,
                    SharedUtils.FormatMoney(commissionDue, POS.Base.Classes.AppController.LocalCurrency));
                toolStripStatusInvoiceTotal.Text = String.Format(LanguageStrings.AppInvoiceTotal,
                    SharedUtils.FormatMoney(invoiceTotal, POS.Base.Classes.AppController.LocalCurrency));
                toolStripStatusCommissionableTotal.Text = String.Format(LanguageStrings.AppCommissionableTotal,
                    SharedUtils.FormatMoney(commissionableTotal, POS.Base.Classes.AppController.LocalCurrency));

                toolStripStatusCount.Visible = true;
                toolStripStatusTotal.Visible = true;
                toolStripStatusInvoiceTotal.Visible = true;
                toolStripStatusCommissionableTotal.Visible = true;

                gridCommission.Columns[0].Visible = false;
                gridCommission.Columns[1].Visible = false;
                gridCommission.Columns[2].HeaderText = LanguageStrings.AppUser;
                gridCommission.Columns[3].Visible = false;
                gridCommission.Columns[4].HeaderText = LanguageStrings.AppDateAllocated;
                gridCommission.Columns[5].Visible = false;
                gridCommission.Columns[6].HeaderText = LanguageStrings.AppPercentage;
                gridCommission.Columns[7].HeaderText = String.Format(LanguageStrings.AppInvoiceTotal, String.Empty);
                gridCommission.Columns[8].HeaderText = String.Format(LanguageStrings.AppCommissionableTotal, String.Empty);
                gridCommission.Columns[9].HeaderText = String.Format(LanguageStrings.AppCommissionDue, String.Empty);
                gridCommission.Columns[10].HeaderText = LanguageStrings.AppDatePaid;
                gridCommission.Columns[11].HeaderText = LanguageStrings.AppDateDue;
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void cmbUsers_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((User)e.ListItem).UserName;
        }

        private void gridCommission_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                switch (e.ColumnIndex)
                {
                    case 7:
                    case 8:
                    case 9:
                        e.Value = Library.Utils.SharedUtils.FormatMoney((decimal)e.Value, POS.Base.Classes.AppController.LocalCurrency);

                        break;
                }

                e.CellStyle.BackColor = Color.White;
                e.CellStyle.ForeColor = Color.Black;
                e.CellStyle.SelectionBackColor = Color.Navy;
                e.CellStyle.SelectionForeColor = Color.White;

                AffiliateCommissionItem item = (AffiliateCommissionItem)gridCommission.Rows[e.RowIndex].DataBoundItem;

                if (item.Selected)
                {
                    e.CellStyle.BackColor = SelectedBack;
                    e.CellStyle.ForeColor = SelectedFore;
                }
                else
                {
                    if (!item.IsPaid)
                    {
                        if (item.DateDue < DateTime.Now)
                        {
                            e.CellStyle.BackColor = OverdueBack;
                            e.CellStyle.ForeColor = OverdueFore;
                        }
                        else
                        {
                            if (item.DateDue > DateTime.Now && item.DateDue <= DateTime.Now.AddDays(POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonDays))
                            {
                                e.CellStyle.BackColor = DueSoonBack;
                                e.CellStyle.ForeColor = DueSoonFore;
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError, err.Message);
            }
        }

        private void menuStripSelectAll_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                foreach (DataGridViewRow row in gridCommission.Rows)
                {
                    AffiliateCommissionItem item = (AffiliateCommissionItem)row.DataBoundItem;
                    item.Selected = true;
                }

                gridCommission.Invalidate();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void menuStripUnselectAll_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                foreach (DataGridViewRow row in gridCommission.Rows)
                {
                    AffiliateCommissionItem item = (AffiliateCommissionItem)row.DataBoundItem;
                    item.Selected = false;
                }

                gridCommission.Invalidate();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void menuStripInvert_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                foreach (DataGridViewRow row in gridCommission.Rows)
                {
                    AffiliateCommissionItem item = (AffiliateCommissionItem)row.DataBoundItem;
                    item.Selected = !item.Selected;
                }

                gridCommission.Invalidate();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void menuStripPayCommission_Click(object sender, EventArgs e)
        {
            User pool = (User)cmbUsers.SelectedItem;

            AffiliateCommission commisionItems = new AffiliateCommission();

            foreach (DataGridViewRow row in gridCommission.Rows)
            {
                AffiliateCommissionItem item = (AffiliateCommissionItem)row.DataBoundItem;

                if (item.Selected && !item.IsPaid)
                    commisionItems.Add(item);
            }

            if (commisionItems.Count == 0)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppErrorCommissionSelectItems);
                return;
            }

            Classes.AffiliateCommissionWizards.CommissionAffiliatePay(commisionItems);
        }

        private void gridCommission_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            gridCommission.Invalidate();
        }

        #endregion Private Methods
    }
}
