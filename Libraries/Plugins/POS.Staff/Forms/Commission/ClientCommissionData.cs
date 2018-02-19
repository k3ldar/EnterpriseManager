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
 *  File: ClientCommissionData.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library.BOL.Staff;
using Library.Utils;
using POS.Base.Controls;

namespace POS.Staff.Forms
{
    public partial class ClientCommissionData : BaseTabControl
    {
        #region Constructors

        public ClientCommissionData()
        {
            InitializeComponent();

            DueSoonBack = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonBackColor);
            DueSoonFore = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonForeColor);
            OverdueBack = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionOverDueBackColor);
            OverdueFore = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionOverDueForeColor);
            SelectedBack = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionSelectedBackColor);
            SelectedFore = ColorTranslator.FromHtml(POS.Base.Classes.AppController.LocalSettings.CommissionSelectedForeColor);

            LoadStaff();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            this.Text = LanguageStrings.AppCommissionClientData;
            lblSelectStaff.Text = LanguageStrings.StaffMember;
            lblDateFrom.Text = LanguageStrings.AppDateFrom;
            lblDateTo.Text = LanguageStrings.AppDateTo;

            rbAll.Text = LanguageStrings.AppAll;
            rbPaid.Text = LanguageStrings.AppPaid;
            rbUnpaid.Text = LanguageStrings.AppUnpaid;

            menuStripSelectAll.Text = LanguageStrings.AppMenuSelectAll;
            menuStripUnselectAll.Text = LanguageStrings.AppMenuUnSelectAll;
            menuStripInvert.Text = LanguageStrings.AppMenuInvertSelection;

            menuStripSelectOverdue.Text = LanguageStrings.AppMenuSelectOverdue;
            menuStripSelectDueSoon.Text = LanguageStrings.AppMenuSelectDueSoon;

            btnSearch.Text = LanguageStrings.Search;
        }

        public override int GetStatusCount()
        {
            return (statusStrip1.Items.Count);
        }

        public override string GetStatusHint(int index)
        {
            return (statusStrip1.Items[index].ToolTipText);
        }

        public override string GetStatusText(int index)
        {
            return (statusStrip1.Items[index].Text);
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

        private void LoadStaff()
        {
            cmbStaff.Items.Clear();

            cmbStaff.Items.Add(new StaffMember(-1));

            foreach (StaffMember staff in StaffMembers.All())
                cmbStaff.Items.Add(staff);

            cmbStaff.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                StaffMember staff = (StaffMember)cmbStaff.SelectedItem;

                if (staff.UserID == -1)
                    staff = null;

                bool isPaid = rbAll.Checked | rbPaid.Checked;
                bool isUnpaid = rbAll.Checked | rbUnpaid.Checked;

                StaffCommission poolData = StaffCommission.Get(staff, dtpFrom.Value, dtpTo.Value, isPaid, isUnpaid);

                gridCommission.DataSource = poolData;

                decimal commissionDue = 0;
                decimal invoiceTotal = 0;
                decimal commissionableTotal = 0;

                foreach (StaffCommissionItem item in poolData)
                {
                    commissionDue += item.CommissionDue;
                    invoiceTotal += item.InvoiceTotal;
                    commissionableTotal += item.CommissionableTotal;
                }

                toolStripStatusCount.Text = String.Format(LanguageStrings.AppCount, poolData.Count);
                toolStripStatusTotal.Text = String.Format(LanguageStrings.AppCommissionDue, SharedUtils.FormatMoney(commissionDue, POS.Base.Classes.AppController.LocalCurrency));
                toolStripStatusInvoiceTotal.Text = String.Format(LanguageStrings.AppInvoiceTotal, SharedUtils.FormatMoney(invoiceTotal, POS.Base.Classes.AppController.LocalCurrency));
                toolStripStatusCommissionableTotal.Text = String.Format(LanguageStrings.AppCommissionableTotal, SharedUtils.FormatMoney(commissionableTotal, POS.Base.Classes.AppController.LocalCurrency));

                toolStripStatusCount.Visible = true;
                toolStripStatusTotal.Visible = true;
                toolStripStatusInvoiceTotal.Visible = true;
                toolStripStatusCommissionableTotal.Visible = true;

                gridCommission.Columns[0].Visible = false;
                gridCommission.Columns[1].Visible = false;
                gridCommission.Columns[2].HeaderText = LanguageStrings.StaffMember;
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

        private void cmbStaff_Format(object sender, ListControlConvertEventArgs e)
        {
            StaffMember staff = (StaffMember)e.ListItem;

            if (staff.UserID == -1)
                e.Value = LanguageStrings.AppAll;
            else
                e.Value = staff.UserRecord.UserName;
        }

        private void gridCommission_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.ForeColor = Color.Black;
                e.CellStyle.SelectionBackColor = Color.Navy;
                e.CellStyle.SelectionForeColor = Color.White;

                StaffCommissionItem item = (StaffCommissionItem)gridCommission.Rows[e.RowIndex].DataBoundItem;

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
                    StaffCommissionItem item = (StaffCommissionItem)row.DataBoundItem;
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
                    StaffCommissionItem item = (StaffCommissionItem)row.DataBoundItem;
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
                    StaffCommissionItem item = (StaffCommissionItem)row.DataBoundItem;
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
            StaffCommission commissionItems = new StaffCommission();

            foreach (DataGridViewRow row in gridCommission.Rows)
            {
                StaffCommissionItem item = (StaffCommissionItem)row.DataBoundItem;

                if (item.Selected && !item.IsPaid && ((item.DateDue < DateTime.Now || (item.DateDue > DateTime.Now && item.DateDue <= DateTime.Now.AddDays(POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonDays)))))
                    commissionItems.Add(item);
            }

            if (commissionItems.Count == 0)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppErrorCommissionSelectItems);
                return;
            }

            DateTime payDate = commissionItems[commissionItems.Count - 1].DateDue;

            if (Classes.ClientCommission.PayClientCommission(ref payDate))
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    foreach (StaffCommissionItem item in commissionItems)
                    {
                        item.Paid(POS.Base.Classes.AppController.ActiveUser, payDate, Library.CommissionPaymentType.Account);
                    }

                    gridCommission.Invalidate();
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }

        private void menuStripSelectOverdue_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                foreach (DataGridViewRow row in gridCommission.Rows)
                {
                    StaffCommissionItem item = (StaffCommissionItem)row.DataBoundItem;
                    item.Selected = !item.IsPaid && item.DateDue < DateTime.Now;
                }

                gridCommission.Invalidate();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void menuStripSelectDueWithin1Month_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                foreach (DataGridViewRow row in gridCommission.Rows)
                {
                    StaffCommissionItem item = (StaffCommissionItem)row.DataBoundItem;
                    item.Selected = !item.IsPaid && item.DateDue > DateTime.Now && item.DateDue <= DateTime.Now.AddDays(POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonDays);
                }

                gridCommission.Invalidate();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void gridCommission_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            gridCommission.Invalidate();
        }

        #endregion Private Methods
    }
}
