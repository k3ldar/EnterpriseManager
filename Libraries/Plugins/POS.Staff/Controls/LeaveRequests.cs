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
 *  File: LeaveRequests.cs
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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using SharedControls.Classes;
using Languages;
using Library;
using Library.BOL.Staff;
using Library.BOL.Users;
using POS.Base.Classes;
using Shared;

namespace POS.Staff.Controls
{
    public partial class LeaveRequests : SharedControls.BaseControl
    {
        #region Private Members

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

        public LeaveRequests()
        {
            InitializeComponent();

            _staffMembers = new Users();
            
            if (AppController.ApplicationRunning)
            {
                LoadLeaveYears();
            }

            HideApproved = false;
            HideAuthorised = false;
            HideDenied = false;
            HideCancelled = false;
            HideRequested = false;
            _allStaff = false;

            AutoRefresh = true;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            grpLeaveRequests.Text = LanguageStrings.AppStaffLeaveRequests;
            lblLeaveYear.Text = LanguageStrings.AppStaffLeaveYear;

            colStaffMember.Text = LanguageStrings.AppMenuStaffMember;
            colApproved.Text = LanguageStrings.AppApproved;
            colAuthorised.Text = LanguageStrings.AppAuthorised;
            colFrom.Text = LanguageStrings.AppDateFrom;
            colTo.Text = LanguageStrings.AppDateTo;
            colTotal.Text = LanguageStrings.Total;

            contextMenuOptionsAuthorise.Text = LanguageStrings.AppMenuAuthoriseLeave;
            contextMenuOptionsApprove.Text = LanguageStrings.AppMenuApproveLeave;
            contextMenuOptionsCancel.Text = LanguageStrings.AppMenuCancel;
            contextMenuOptionsDeny.Text = LanguageStrings.AppMenuDeny;

            UpdateSummary(StaffMember);
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (this.Parent != null)
                lvLeaveRequests.SaveName = this.Parent.GetType().ToString();
        }

        #endregion Overridden Methods

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

                DateTime selRange = (DateTime)cmbLeaveYear.SelectedItem;
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

        private void LoadLeaveYears()
        {
            cmbLeaveYear.Items.Clear();

            for (int currYear = DateTime.Now.Year - 4; currYear <= DateTime.Now.Year + 
                AppController.LocalSettings.LeaveAllowBookFuture; currYear++)
            {
                DateTime from = new DateTime(currYear, AppController.LocalSettings.LeaveYearStarts.Month, 
                    AppController.LocalSettings.LeaveYearStarts.Day);

                int idx = cmbLeaveYear.Items.Add(from);

                if (Shared.Utilities.DateWithin(from, from.AddYears(1).AddDays(-1), DateTime.Now))
                    cmbLeaveYear.SelectedIndex = idx;
            }
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

        private void cmbLeaveYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DesignMode && (StaffMember != null || AllStaff))
                LoadLeave(false);
        }

        private void cmbLeaveYear_Format(object sender, ListControlConvertEventArgs e)
        {
            DateTime date = (DateTime)e.ListItem;

            e.Value = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN, 
                date.ToShortDateString(), date.AddYears(1).AddDays(-1).ToShortDateString());

        }

        private void lvLeaveRequests_ToolTipShow(object sender, ToolTipEventArgs e)
        {
            if (e.ListViewItem == null)
            {
                e.AllowShow = false;
                return;
            }

            StaffLeaveRequest request = (StaffLeaveRequest)e.ListViewItem.Tag;

            e.Title = LanguageStrings.AppStaffLeaveRequest;

            e.Text = String.Format(LanguageStrings.AppStaffLeaveRequestedHint,
                Utilities.DateToStr(request.DateRequested, AppController.LocalCulture),
                String.IsNullOrEmpty(request.Notes) ? LanguageStrings.AppStaffLeaveNoNotes : request.Notes);

            if (request.IsApproved)
            {
                User approver = User.UserGet(request.ApprovedBy);

                e.Text += StringConstants.SYMBOL_CRLF_DOUBLE;
                e.Text += String.Format(LanguageStrings.AppStaffLeaveApprovedBy,
                    approver.UserName, Utilities.DateToStr(request.DateApproved, AppController.LocalCulture));
            }

            if (request.IsAuthorised)
            {
                User authoriser = User.UserGet(request.AuthorisedBy);

                e.Text += StringConstants.SYMBOL_CRLF_DOUBLE;
                e.Text += String.Format(LanguageStrings.AppStaffLeaveAuthorisedBy,
                    authoriser.UserName, Utilities.DateToStr(request.DateAuthorised, AppController.LocalCulture));
            }
        }

        private void contextMenuOptionsAuthorise_Click(object sender, EventArgs e)
        {
            if (lvLeaveRequests.SelectedItems.Count > 0)
            {
                StaffLeaveRequest leave = (StaffLeaveRequest)lvLeaveRequests.SelectedItems[0].Tag;
                leave.Authorise(AppController.ActiveUser);

                if (AllStaff)
                {
                    lvLeaveRequests.Items.Remove(lvLeaveRequests.SelectedItems[0]);
                }
                else
                {
                    lvLeaveRequests.SelectedItems[0].SubItems[5].Text = LanguageStrings.Yes;
                    SetLeaveColor(leave, lvLeaveRequests.SelectedItems[0]);
                }

                LoadLeave(true);
                RaiseStatusChanged();
            }
        }

        private void contextMenuOptionsApprove_Click(object sender, EventArgs e)
        {
            if (lvLeaveRequests.SelectedItems.Count > 0)
            {
                StaffLeaveRequest leave = (StaffLeaveRequest)lvLeaveRequests.SelectedItems[0].Tag;
                leave.Approve(AppController.ActiveUser);

                if (AllStaff)
                {
                    lvLeaveRequests.Items.Remove(lvLeaveRequests.SelectedItems[0]);
                }
                else
                {
                    lvLeaveRequests.SelectedItems[0].SubItems[4].Text = LanguageStrings.Yes;
                    SetLeaveColor(leave, lvLeaveRequests.SelectedItems[0]);
                }

                LoadLeave(true);
                RaiseStatusChanged();
            }
        }

        private void contextMenuOptionsCancel_Click(object sender, EventArgs e)
        {
            if (lvLeaveRequests.SelectedItems.Count > 0)
            {
                if (ShowQuestion(LanguageStrings.AppStaffLeave, LanguageStrings.AppStaffLeaveConfirmCancel))
                {
                    StaffLeaveRequest leave = (StaffLeaveRequest)lvLeaveRequests.SelectedItems[0].Tag;
                    leave.Cancel(AppController.ActiveUser);
                    SetLeaveColor(leave, lvLeaveRequests.SelectedItems[0]);

                    LoadLeave(true);
                    RaiseStatusChanged();
                }
            }
        }

        private void contextMenuOptionsDeny_Click(object sender, EventArgs e)
        {
            if (lvLeaveRequests.SelectedItems.Count > 0)
            {
                InputBoxResult Result = InputBox.Show(LanguageStrings.AppStaffLeaveConfirmDeny, LanguageStrings.AppStaffLeave);
                
                if (Result.ReturnCode == DialogResult.OK)
                {
                    if (String.IsNullOrEmpty(Result.Text))
                    {
                        ShowError(LanguageStrings.AppStaffLeave, LanguageStrings.AppStaffLeaveConfirmDenyReason);
                        return;
                    }

                    StaffLeaveRequest leave = (StaffLeaveRequest)lvLeaveRequests.SelectedItems[0].Tag;
                    leave.Deny(AppController.ActiveUser, Result.Text);
                    SetLeaveColor(leave, lvLeaveRequests.SelectedItems[0]);

                    LoadLeave(true);
                    RaiseStatusChanged();
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

        private void RaiseStatusChanged()
        {
            if (StatusUpdated != null)
                StatusUpdated(this, EventArgs.Empty);
        }

        #endregion Private Methods

        #region Events

        public event EventHandler StatusUpdated;

        #endregion Events
    }
}
