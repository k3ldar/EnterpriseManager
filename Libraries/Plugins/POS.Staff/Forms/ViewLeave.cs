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
 *  File: ViewLeave.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Languages;

using Shared;

using SharedBase;
using SharedBase.BOL.Users;
using SharedBase.BOL.Staff;

using POS.Base.Classes;
using POS.Base;
using System.Globalization;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace POS.Staff.Forms
{
    public partial class ViewLeave : Base.Controls.BaseOptionsControl
    {
        #region Private Members

        private ToolStripComboBox _cmbStaff;
        private ToolStripComboBox _cmbType;
        private ToolStripComboBox _cmbLeaveYears;

        private bool _allStaff;

        private Users _staffMembers;

        /// <summary>
        /// Number of hours used (taken)
        /// </summary>
        private double _used;

        /// <summary>
        /// Number of hours booked (authorised/approved but not taken)
        /// </summary>
        private double _booked;

        #endregion Private Members

        #region Constructors

        public ViewLeave()
        {
            InitializeComponent();

            _staffMembers = new Users();

            HideApproved = false;
            HideAuthorised = false;
            HideDenied = false;
            HideCancelled = false;
            HideRequested = false;
            _allStaff = false;

            AutoRefresh = false;

            if (AppController.ApplicationRunning)
            {
                StaffMember = AppController.ActiveUser;
                AddLeaveYearsToolbar();
                AddStaffToolbar();
                AddStatusToolbar();
                AppController.ApplicationController.OnUserChanged += POSApplication_OnUserChanged;
            }

            AllowAddNew = true;
            IsEditing = false;
            AllowDelete = false;
            AllowEdit = false;
            AllowRefresh = true;
            UpdateUI(false);
        }

        #endregion Constructors

        #region Properties

        public bool AutoRefresh { get; set; }

        /// <summary>
        /// Gets or sets the member of staff
        /// </summary>
        public User StaffMember
        {
            get
            {
                if (AllStaff || _staffMembers.Count != 1)
                    return (null);
                else
                    return (_staffMembers.First());
            }

            set
            {
                if (AllStaff)
                    return;

                colStaffMember.Width = 0;

                _staffMembers.Clear();

                if (value != null)
                    _staffMembers.Add(value);

                if (_staffMembers.Count > 0 && AutoRefresh)
                {
                    LoadLeave(false);
                }
            }
        }

        public bool AllStaff
        {
            get
            {
                return (_allStaff);
            }

            set
            {
                _allStaff = value;

                if (DesignMode)
                    return;

                if (value)
                {
                    colStaffMember.Width = 120;
                    _staffMembers.Clear();

                    foreach (User user in User.StaffMembers(false))
                    {
                        _staffMembers.Add(user);
                    }

                    if (AutoRefresh)
                        LoadLeave(false);
                }
                else
                {
                    colStaffMember.Width = 0;
                }
            }
        }

        public bool ShowCheckBoxes
        {
            get
            {
                return (lvLeaveRequests.CheckBoxes);
            }

            set
            {
                lvLeaveRequests.CheckBoxes = value;
            }
        }

        public bool HideAuthorised { get; set; }

        public bool HideApproved { get; set; }

        public bool HideDenied { get; set; }

        public bool HideCancelled { get; set; }

        public bool HideRequested { get; set; }

        #endregion Properties

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            //lblLeaveYear.Text = LanguageStrings.AppStaffLeaveYear;

            colStaffMember.Text = LanguageStrings.AppMenuStaffMember;
            colApproved.Text = LanguageStrings.AppApproved;
            colAuthorised.Text = LanguageStrings.AppAuthorised;
            colFrom.Text = LanguageStrings.AppDateFrom;
            colTo.Text = LanguageStrings.AppDateTo;
            colTotal.Text = LanguageStrings.Total;
            colDateRequested.Text = LanguageStrings.AppDateRequested;

            contextMenuOptionsAuthorise.Text = LanguageStrings.AppMenuAuthoriseLeave;
            contextMenuOptionsApprove.Text = LanguageStrings.AppMenuApproveLeave;
            contextMenuOptionsCancel.Text = LanguageStrings.AppMenuCancel;
            contextMenuOptionsDeny.Text = LanguageStrings.AppMenuDeny;

            UpdateSummary(StaffMember);

            if (_cmbStaff != null)
            {
                User user = new User(-1, LanguageStrings.AppAny);
                _cmbStaff.Items[0] = user;
            }
        }

        protected override void OnRefreshClicked()
        {
            if (_cmbType == null)
                return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                AllStaff = _cmbStaff.SelectedIndex < 1;

                if (!AllStaff)
                    StaffMember = (User)_cmbStaff.SelectedItem;

                if (_cmbType.SelectedIndex > 0)
                {
                    EmployeeLeaveStatus status = (EmployeeLeaveStatus)_cmbType.SelectedItem;

                    HideApproved = status != EmployeeLeaveStatus.Approved;
                    HideAuthorised = status != EmployeeLeaveStatus.Authorised;
                    HideCancelled = status != EmployeeLeaveStatus.Cancelled;
                    HideDenied = status != EmployeeLeaveStatus.Denied;
                    HideRequested = status != EmployeeLeaveStatus.Requested;
                }
                else
                {
                    HideApproved = false;
                    HideAuthorised = false;
                    HideCancelled = false;
                    HideDenied = false;
                    HideRequested = false;
                }

                LoadLeave(false);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        protected override void OnCreateClicked()
        {
            StaffRequestLeave frm = new StaffRequestLeave();
            try
            {
                frm.ShowDialog(ParentForm);
                OnRefreshClicked();
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }
        }

        #endregion Overridden Methods

        #region Public Methods

        public void ApproveAllChecked()
        {
            foreach (ListViewItem item in lvLeaveRequests.CheckedItems)
            {
                StaffLeaveRequest leave = (StaffLeaveRequest)item.Tag;

                if (leave.CanApprove(AppController.ActiveUser))
                {
                    leave.Approve(AppController.ActiveUser);

                    if (AllStaff)
                    {
                        lvLeaveRequests.Items.Remove(item);
                    }
                    else
                    {
                        item.SubItems[4].Text = LanguageStrings.Yes;
                        SetLeaveColor(leave, item);
                    }
                }
            }
        }

        public void AuthoriseAllChecked()
        {
            foreach (ListViewItem item in lvLeaveRequests.CheckedItems)
            {
                StaffLeaveRequest leave = (StaffLeaveRequest)item.Tag;

                if (leave.CanAuthorise(AppController.ActiveUser))
                {
                    leave.Authorise(AppController.ActiveUser);

                    if (AllStaff)
                    {
                        lvLeaveRequests.Items.Remove(item);
                    }
                    else
                    {
                        item.SubItems[5].Text = LanguageStrings.Yes;
                        SetLeaveColor(leave, item);
                    }
                }
            }
        }

        public void LoadLeave(bool updateStatusOnly)
        {
            lvLeaveRequests.BeginUpdate();
            try
            {
                if (!updateStatusOnly)
                    lvLeaveRequests.Items.Clear();

                DateTime selRange = (DateTime)_cmbLeaveYears.SelectedItem;
                _used = 0.0;
                _booked = 0.0;

                foreach (User staff in _staffMembers)
                {
                    foreach (StaffLeaveRequest request in staff.StaffRecord.AnnualLeave)
                    {
                        if (Utilities.DateWithin(selRange, selRange.AddYears(1).AddDays(-1), request.DateFrom) ||
                            Utilities.DateWithin(selRange, selRange.AddYears(1).AddDays(-1), request.DateTo))
                        {
                            if (request.Status == LeaveOptions.None)
                            {
                                if (request.IsAuthorised && request.DateTo < DateTime.Now)
                                    _used += request.TotalTime;

                                if (request.IsAuthorised && request.DateFrom > DateTime.Now)
                                    _booked += request.TotalTime;
                            }

                            if (updateStatusOnly)
                                continue;

                            if (request.IsAuthorised && HideAuthorised & (request.IsApproved && HideApproved))
                                continue;

                            if (request.IsApproved && HideApproved & (request.IsAuthorised && HideAuthorised))
                                continue;

                            if (request.Status == LeaveOptions.Cancelled && HideCancelled)
                                continue;

                            if (request.Status == LeaveOptions.Denied && HideDenied)
                                continue;

                            if (request.Status == LeaveOptions.None && HideRequested && !request.IsAuthorised && !request.IsApproved)
                                continue;

                            ListViewItem leaveRequest = lvLeaveRequests.Items.Add(staff.UserName);
                            leaveRequest.SubItems.Add(Utilities.DateToStr(request.DateFrom, AppController.LocalCulture));
                            leaveRequest.SubItems.Add(Utilities.DateToStr(request.DateTo, AppController.LocalCulture));

                            if (staff.StaffRecord.EntitlementType)
                                leaveRequest.SubItems.Add(String.Format(LanguageStrings.AppStaffLeaveHours, request.TotalTime));
                            else
                                leaveRequest.SubItems.Add(String.Format(LanguageStrings.AppStaffLeaveDays, request.TotalTime));

                            leaveRequest.SubItems.Add(request.IsApproved ? LanguageStrings.Yes : LanguageStrings.No);
                            leaveRequest.SubItems.Add(request.IsAuthorised ? LanguageStrings.Yes : LanguageStrings.No);
                            leaveRequest.SubItems.Add(Utilities.FormatDate(request.DateRequested, 
                                AppController.LocalCulture.Name));
                            leaveRequest.Tag = request;

                            SetLeaveColor(request, leaveRequest);
                        }
                    }
                }

                UpdateSummary(StaffMember);
            }
            finally
            {
                lvLeaveRequests.EndUpdate();
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void POSApplication_OnUserChanged(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionStaff(
                SharedBase.SecurityEnums.SecurityPermissionsStaff.ApproveExpenses))
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

        private void AddLeaveYearsToolbar()
        {
            _cmbLeaveYears = new ToolStripComboBox();
            _cmbLeaveYears.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbLeaveYears.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            _cmbLeaveYears.ComboBox.DrawItem += ComboLeaveYears_DrawItem;
            _cmbLeaveYears.AutoSize = false;

            for (int currYear = DateTime.Now.Year - 4; currYear <= DateTime.Now.Year +
                AppController.LocalSettings.LeaveAllowBookFuture; currYear++)
            {
                DateTime from = new DateTime(currYear, AppController.LocalSettings.LeaveYearStarts.Month,
                    AppController.LocalSettings.LeaveYearStarts.Day);

                int idx = _cmbLeaveYears.Items.Add(from);

                if (Shared.Utilities.DateWithin(from, from.AddYears(1).AddDays(-1), DateTime.Now))
                    _cmbLeaveYears.SelectedIndex = idx;
            }

            string cmbWidth = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN,
                DateTime.Now.ToShortDateString(), 
                DateTime.Now.AddYears(1).AddDays(-1).ToShortDateString());
            Size sz = Shared.Utilities.MeasureText(cmbWidth, _cmbLeaveYears.Font);
            _cmbLeaveYears.Size = new Size(sz.Width + 40, _cmbLeaveYears.Size.Height);
            _cmbLeaveYears.SelectedIndexChanged += _cmbStaff_SelectedIndexChanged;

            AddToolbarSeperator();
            AddToolbarCombo(_cmbLeaveYears);
        }

        private void AddStaffToolbar()
        {
            _cmbStaff = new ToolStripComboBox();
            _cmbStaff.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbStaff.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            _cmbStaff.ComboBox.DrawItem += ComboBox_DrawItem;
            _cmbStaff.AutoSize = false;
            _cmbStaff.SelectedIndexChanged += _cmbStaff_SelectedIndexChanged;
            _cmbStaff.Items.Add(new User(-1, LanguageStrings.AppAll));

            int minWidth = 120;

            foreach (User staff in User.StaffMembers(false))
            {
                int idx = _cmbStaff.Items.Add(staff);

                Size len = Shared.Utilities.MeasureText(staff.UserName, _cmbStaff.Font);

                if (len.Width > minWidth)
                    minWidth = len.Width;

                if (staff.ID == AppController.ActiveUser.ID)
                    _cmbStaff.SelectedIndex = idx;
            }

            _cmbStaff.Size = new Size(minWidth + 10, _cmbStaff.Size.Height);

            AddToolbarSeperator();
            AddToolbarCombo(_cmbStaff);
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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


            User user = (User)_cmbStaff.Items[e.Index];

            e.Graphics.DrawString(
                user.UserName,
                _cmbStaff.Font,
                Brushes.Black,
                new PointF(e.Bounds.X, e.Bounds.Y));
        }

        private void ComboLeaveYears_DrawItem(object sender, DrawItemEventArgs e)
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


            DateTime date = (DateTime)_cmbLeaveYears.Items[e.Index];

            string value = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN,
                date.ToShortDateString(), date.AddYears(1).AddDays(-1).ToShortDateString());

            e.Graphics.DrawString(
                value,
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
                EmployeeLeaveStatus type = (EmployeeLeaveStatus)_cmbType.Items[e.Index];
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

            foreach (EmployeeLeaveStatus status in Enum.GetValues(typeof(EmployeeLeaveStatus)))
            {
                _cmbType.Items.Add(status);
            }

            _cmbType.SelectedIndex = 0;

            AddToolbarSeperator();
            AddToolbarCombo(_cmbType);
        }

        private void SetLeaveColor(StaffLeaveRequest request, ListViewItem item)
        {
            switch (request.Status)
            {
                case LeaveOptions.Cancelled:
                    item.Font = new Font(item.Font, FontStyle.Strikeout);
                    item.ForeColor = Color.Black;
                    break;

                case LeaveOptions.Denied:
                    item.ForeColor = Color.Red;
                    break;

                default:
                    if (request.IsAuthorised)
                        item.ForeColor = Color.Black;
                    else if (request.IsApproved)
                        item.ForeColor = Color.Blue;
                    else
                        item.ForeColor = Color.Green;

                    break;
            }
        }

        private void UpdateSummary(User staffMember)
        {
            if (DesignMode || staffMember == null)
                return;

            if (staffMember.StaffRecord.EntitlementType)
                lblSummary.Text = String.Format(LanguageStrings.AppLeaveSummaryHours,
                    staffMember.StaffRecord.LeaveEntitlement,
                    _used, _booked);
            else
                lblSummary.Text = String.Format(LanguageStrings.AppLeaveSummaryDays,
                    staffMember.StaffRecord.LeaveEntitlement,
                    _used, _booked);
        }

        private void lvLeaveRequests_ToolTipShow(object sender, ToolTipEventArgs e)
        {

        }

        private void contextMenuOptionsAuthorise_Click(object sender, EventArgs e)
        {
            if (lvLeaveRequests.SelectedItems.Count > 0)
            {
                ListViewItem item = lvLeaveRequests.SelectedItems[0];
                StaffLeaveRequest request = (StaffLeaveRequest)item.Tag;
                request.Authorise(AppController.ActiveUser);
                item.SubItems[5].Text = LanguageStrings.Yes;
                SetLeaveColor(request, item);
            }
        }

        private void contextMenuOptionsApprove_Click(object sender, EventArgs e)
        {
            if (lvLeaveRequests.SelectedItems.Count > 0)
            {
                ListViewItem item = lvLeaveRequests.SelectedItems[0];
                StaffLeaveRequest request = (StaffLeaveRequest)item.Tag;
                request.Approve(AppController.ActiveUser);
                item.SubItems[4].Text = LanguageStrings.Yes;
                SetLeaveColor(request, item);
            }
        }

        private void contextMenuOptionsCancel_Click(object sender, EventArgs e)
        {
            if (lvLeaveRequests.SelectedItems.Count > 0)
            {
                ListViewItem item = lvLeaveRequests.SelectedItems[0];
                StaffLeaveRequest request = (StaffLeaveRequest)item.Tag;
                request.Cancel(AppController.ActiveUser);
                SetLeaveColor(request, item);
            }
        }

        private void contextMenuOptionsDeny_Click(object sender, EventArgs e)
        {
            if (lvLeaveRequests.SelectedItems.Count > 0)
            {
                string notes = String.Empty;

                if (POS.Base.Forms.Notes.ShowNotes(ref notes, true, LanguageStrings.AppLeaveReasnDenied))
                {
                    ListViewItem item = lvLeaveRequests.SelectedItems[0];
                    StaffLeaveRequest request = (StaffLeaveRequest)item.Tag;
                    request.Deny(AppController.ActiveUser, notes);
                    SetLeaveColor(request, item);
                }
            }
        }

        private void contextMenuOptions_Opening(object sender, CancelEventArgs e)
        {
            if (lvLeaveRequests.SelectedItems.Count > 0)
            {
                StaffLeaveRequest leave = (StaffLeaveRequest)lvLeaveRequests.SelectedItems[0].Tag;

                contextMenuOptionsDeny.Enabled = leave.CanDeny(AppController.ActiveUser);
                contextMenuOptionsApprove.Enabled = leave.CanApprove(AppController.ActiveUser);
                contextMenuOptionsAuthorise.Enabled = leave.CanAuthorise(AppController.ActiveUser);
                contextMenuOptionsCancel.Enabled = leave.CanCancel(AppController.ActiveUser);
            }
            else
            {
                contextMenuOptionsApprove.Enabled = false;
                contextMenuOptionsAuthorise.Enabled = false;
                contextMenuOptionsCancel.Enabled = false;
                contextMenuOptionsDeny.Enabled = false;
            }
        }

        #endregion Private Methods
    }
}
