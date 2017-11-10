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
 *  File: StaffExpensesControl.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using Languages;

using Shared;

using Library;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.Staff;

using POS.Base;
using POS.Base.Classes;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace POS.Staff.Forms
{
    public partial class StaffExpensesControl : POS.Base.Controls.BaseOptionsControl
    {
        #region Private Members

        private ToolStripComboBox _cmbStaff;
        private ToolStripComboBox _cmbType;

        #endregion Private Members

        #region Constructors

        public StaffExpensesControl()
        {
            InitializeComponent();

            AddStaffToolbar();
            AddStatusToolbar();
            AppController.ApplicationController.OnUserChanged += POSApplication_OnUserChanged;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lvExpensesColAmount.Text = LanguageStrings.AppCost;
            lvExpensesColDate.Text = LanguageStrings.Date;
            lvExpensesColQuantity.Text = LanguageStrings.Quantity;
            lvExpensesColReceipt.Text = LanguageStrings.AppStaffExpensesHasReceipt;
            lvExpensesColStaffMember.Text = LanguageStrings.StaffMember;
            lvExpensesColStatus.Text = LanguageStrings.Status;
            lvExpensesColType.Text = LanguageStrings.AppType;
            lvExpensesColApprovedBy.Text = LanguageStrings.AppApprovedBy;
            lvExpensesColApprovedDate.Text = LanguageStrings.AppApprovedByDate;
            lvExpensesColReason.Text = LanguageStrings.AppReason;
            lvExpensesColTaxPaid.Text = LanguageStrings.AppTaxPaid;

            pumExpensesApprove.Text = LanguageStrings.AppMenuAppApproved;
            pumExpensesDecline.Text = LanguageStrings.AppMenuDeclined;
            pumExpensesEdit.Text = LanguageStrings.AppMenuEdit;
            pumExpensesNew.Text = LanguageStrings.AppMenuNew;
            pumExpensesViewReceipt.Text = LanguageStrings.AppMenuViewReceipt;

            if (_cmbStaff != null)
            {
                //_cmbStaff.SelectedIndexChanged -= _cmbStaff_SelectedIndexChanged;
                User user = (User)_cmbStaff.Items[0];
                user.FirstName = LanguageStrings.AppAll;
            }
        }

        protected override void OnEditClicked()
        {
            pumExpensesEdit_Click(this, EventArgs.Empty);
        }

        protected override void OnCreateClicked()
        {
            StaffExpense expense = null;

            if (Classes.ExpensesWizard.ExpensesCreateWizard(ref expense))
            {
                ListViewItem item = new ListViewItem(
                    Utilities.FormatDate(expense.ExpenseDate, AppController.LocalCulture.Name));
                item.SubItems.Add(User.UserGet(expense.StaffId).UserName);
                item.SubItems.Add(SharedUtils.FormatMoney(expense.ExpenseAmount,
                    AppController.LocalCurrency, true));
                item.SubItems.Add(EnumTranslations.Translate(expense.ExpenseType));
                item.SubItems.Add(expense.ExpenseQuantity.ToString());

                item.SubItems.Add(String.IsNullOrWhiteSpace(expense.ReceiptImage) ?
                    LanguageStrings.No : LanguageStrings.Yes);
                item.SubItems.Add(EnumTranslations.Translate(expense.Status));
                item.SubItems.Add(String.Empty);
                item.SubItems.Add(String.Empty);
                item.SubItems.Add(expense.Reason);
                item.SubItems.Add(SharedUtils.FormatMoney(expense.TaxPaid,
                    AppController.LocalCurrency, true));

                item.Tag = expense;
                item.ForeColor = Color.Black;
                lvExpenses.Items.Insert(0, item);
            }
        }

        protected override void OnRefreshClicked()
        {
            this.Cursor = Cursors.WaitCursor;
            lvExpenses.BeginUpdate();
            try
            {
                //load all items for this user or if the user authorises, allow settings from options
                User user = _cmbStaff.SelectedIndex == 0 ? null : (User)_cmbStaff.SelectedItem;

                lvExpenses.Items.Clear();
                bool allTypes = _cmbType == null || _cmbType.SelectedIndex == 0;

                foreach (StaffExpense expense in StaffExpenses.All(user))
                {
                    if (!allTypes && _cmbType.SelectedItem.GetType() == typeof(EmployeeExpenseStatus) &&
                        expense.Status != (EmployeeExpenseStatus)_cmbType.SelectedItem)
                    {
                        continue;
                    }

                    ListViewItem item = new ListViewItem(
                        Utilities.FormatDate(expense.ExpenseDate, AppController.LocalCulture.Name));
                    item.SubItems.Add(User.UserGet(expense.StaffId).UserName);
                    item.SubItems.Add(SharedUtils.FormatMoney(expense.ExpenseAmount,
                        AppController.LocalCurrency, true));
                    item.SubItems.Add(EnumTranslations.Translate(expense.ExpenseType));
                    item.SubItems.Add(expense.ExpenseQuantity.ToString());

                    item.SubItems.Add(String.IsNullOrWhiteSpace(expense.ReceiptImage) ?
                        LanguageStrings.No : LanguageStrings.Yes);
                    item.SubItems.Add(EnumTranslations.Translate(expense.Status));
                    item.SubItems.Add(expense.ApprovedBy == -1 ? String.Empty : User.UserGet(expense.ApprovedBy).UserName);
                    item.SubItems.Add(expense.ApprovedBy == -1 ? String.Empty :
                        Utilities.FormatDate(expense.ApprovedDate, AppController.LocalCulture.Name));
                    item.SubItems.Add(expense.Reason);
                    item.SubItems.Add(SharedUtils.FormatMoney(expense.TaxPaid,
                        AppController.LocalCurrency, true));

                    item.Tag = expense;

                    switch (expense.Status)
                    {
                        case Library.EmployeeExpenseStatus.Approved:
                            item.ForeColor = Color.DarkGreen;
                            break;
                        case Library.EmployeeExpenseStatus.Declined:
                            item.ForeColor = Color.Red;
                            break;
                        case Library.EmployeeExpenseStatus.Paid:
                            item.ForeColor = Color.Blue;
                            break;
                        case Library.EmployeeExpenseStatus.Submitted:
                            item.ForeColor = Color.Black;
                            break;
                    }

                    lvExpenses.Items.Add(item);
                }

                AllowDelete = false;
                AllowEdit = false;
                IsEditing = false;
                AllowRefresh = true;

                UpdateUI(lvExpenses.SelectedItems.Count > 0);
            }
            finally
            {
                lvExpenses.EndUpdate();
                this.Cursor = Cursors.Arrow;
            }
        }

        #endregion Overridden Methods

        #region Private Methods

        private void POSApplication_OnUserChanged(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionStaff(
                Library.SecurityEnums.SecurityPermissionsStaff.ApproveExpenses))
            {
                _cmbStaff.Enabled = true;
                _cmbStaff.SelectedIndex = 0;
            }
            else
            {
                for (int i = 0; i < _cmbStaff.Items.Count; i++)
                {
                    User user = (User)_cmbStaff.Items[i];

                    if (user.ID == AppController.ActiveUser.ID)
                    {
                        _cmbStaff.SelectedIndex = i;
                        break;
                    }
                }

                _cmbStaff.Enabled = false;
            }
        }

        private void AddStaffToolbar()
        {
            _cmbStaff = new ToolStripComboBox();
            _cmbStaff.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbStaff.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            _cmbStaff.ComboBox.DrawItem += ComboBox_DrawItem;
            _cmbStaff.AutoSize = false;
            _cmbStaff.Items.Add(new User(-1, LanguageStrings.AppAny));
            _cmbStaff.SelectedIndex = 0;
            _cmbStaff.SelectedIndexChanged += _cmbStaff_SelectedIndexChanged;

            int minWidth = 120;

            foreach (User staff in User.StaffMembers(false))
            {
                _cmbStaff.Items.Add(staff);

                Size len = Shared.Utilities.MeasureText(staff.UserName, _cmbStaff.Font);

                if (len.Width > minWidth)
                    minWidth = len.Width;
            }

            _cmbStaff.Size = new Size(minWidth + 10, _cmbStaff.Size.Height);

            AddToolbarSeperator();
            AddToolbarCombo(_cmbStaff);

            POSApplication_OnUserChanged(this, EventArgs.Empty);
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.State.HasFlag(DrawItemState.Selected))
            {
                e.DrawFocusRectangle();
            }


            User user = (User)_cmbStaff.Items[e.Index];

            e.Graphics.DrawString(
                user.UserName,
                _cmbStaff.Font,
                Brushes.Black,
                new PointF(e.Bounds.X, e.Bounds.Y));
        }

        private void ComboBoxType_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.State.HasFlag(DrawItemState.Selected))
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
            }
            else
            {
                e.DrawBackground();
            }


            string text = String.Empty;

            if (_cmbType.Items[e.Index].GetType() == typeof(string))
            {
                text = (string)_cmbType.Items[e.Index];
            }
            else
            {
                EmployeeExpenseStatus type = (EmployeeExpenseStatus)_cmbType.Items[e.Index];
                text = EnumTranslations.Translate(type);
            }

            e.Graphics.DrawString(
                text,
                _cmbStaff.Font,
                Brushes.Black,
                new PointF(e.Bounds.X, e.Bounds.Y));
        }

        private void _cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvExpenses.Focus();
            OnRefreshClicked();
        }

        private void AddStatusToolbar()
        {
            _cmbType = new ToolStripComboBox();
            _cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbType.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            _cmbType.ComboBox.DrawItem += ComboBoxType_DrawItem;
            _cmbType.AutoSize = true;
            _cmbType.SelectedIndexChanged += _cmbStaff_SelectedIndexChanged;
            _cmbType.Items.Add(LanguageStrings.AppAny);
            _cmbType.SelectedIndex = 0;

            foreach (EmployeeExpenseStatus status in Enum.GetValues(typeof(EmployeeExpenseStatus)))
            {
                _cmbType.Items.Add(status);
            }

            _cmbType.SelectedIndex = 0;

            AddToolbarSeperator();
            AddToolbarCombo(_cmbType);
        }

        #region Pop up Menu

        private void pumExpenses_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StaffExpense expense = null;

            if (lvExpenses.SelectedItems.Count > 0)
                expense = (StaffExpense)lvExpenses.SelectedItems[0].Tag;

            bool canManage = AppController.ActiveUser.HasPermissionStaff(
                Library.SecurityEnums.SecurityPermissionsStaff.ApproveExpenses);

            pumExpensesApprove.Enabled = canManage && 
                expense != null && 
                expense.Status == Library.EmployeeExpenseStatus.Submitted;
            pumExpensesDecline.Enabled = canManage && 
                expense != null && 
                expense.Status == Library.EmployeeExpenseStatus.Submitted;

            pumExpensesViewReceipt.Enabled = expense != null && !String.IsNullOrWhiteSpace(expense.ReceiptImage);

            pumExpensesEdit.Enabled = expense != null && 
                (expense.Status == Library.EmployeeExpenseStatus.Declined ||
                AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.EditExpenses));
        }

        private void pumExpensesNew_Click(object sender, EventArgs e)
        {
            OnCreateClicked();
        }

        private void pumExpensesViewReceipt_Click(object sender, EventArgs e)
        {
            if (lvExpenses.SelectedItems.Count > 0)
            {
                StaffExpense expense = (StaffExpense)lvExpenses.SelectedItems[0].Tag;
                POS.Base.Forms.ViewImageForm.ShowImage(LanguageStrings.AppExpensesViewReceipt, expense.Receipt);
            }
        }

        private void pumExpensesApprove_Click(object sender, EventArgs e)
        {
            if (lvExpenses.SelectedItems.Count > 0)
            {
                StaffExpense expense = (StaffExpense)lvExpenses.SelectedItems[0].Tag;
                expense.Approve(AppController.ActiveUser);
                lvExpenses.SelectedItems[0].SubItems[6].Text = EnumTranslations.Translate(Library.EmployeeExpenseStatus.Approved);
                lvExpenses.SelectedItems[0].SubItems[7].Text = AppController.ActiveUser.UserName;
                lvExpenses.SelectedItems[0].SubItems[8].Text = Utilities.FormatDate(DateTime.Now, AppController.LocalCulture.Name);
                lvExpenses.SelectedItems[0].ForeColor = Color.DarkGreen;
            }
        }

        private void pumExpensesDecline_Click(object sender, EventArgs e)
        {
            if (lvExpenses.SelectedItems.Count > 0)
            {
                StaffExpense expense = (StaffExpense)lvExpenses.SelectedItems[0].Tag;
                expense.Decline(AppController.ActiveUser);
                lvExpenses.SelectedItems[0].SubItems[6].Text = EnumTranslations.Translate(Library.EmployeeExpenseStatus.Declined);
                lvExpenses.SelectedItems[0].SubItems[7].Text = AppController.ActiveUser.UserName;
                lvExpenses.SelectedItems[0].SubItems[8].Text = Utilities.FormatDate(DateTime.Now, AppController.LocalCulture.Name);
                lvExpenses.SelectedItems[0].ForeColor = Color.Red;
            }
        }

        private void pumExpensesEdit_Click(object sender, EventArgs e)
        {
            if (lvExpenses.SelectedItems.Count > 0)
            {
                StaffExpense expense = (StaffExpense)lvExpenses.SelectedItems[0].Tag;

                if (Classes.ExpensesWizard.ExpensesCreateWizard(ref expense))
                {
                    lvExpenses.SelectedItems[0].SubItems[6].Text = EnumTranslations.Translate(Library.EmployeeExpenseStatus.Submitted);
                    lvExpenses.SelectedItems[0].SubItems[7].Text = String.Empty;
                    lvExpenses.SelectedItems[0].SubItems[8].Text = String.Empty;
                    lvExpenses.SelectedItems[0].ForeColor = Color.Black;
                }
            }
        }

        #endregion Pop up Menu

        private void lvExpenses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvExpenses.SelectedItems.Count > 0)
            {
                StaffExpense expense = (StaffExpense)lvExpenses.SelectedItems[0].Tag;

                AllowEdit = expense.Status == EmployeeExpenseStatus.Declined;
                UpdateUI(true);
            }
        }

        #endregion Private Methods
    }
}
