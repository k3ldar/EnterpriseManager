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
 *  File: AdminStaffEdit.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  07/06/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SieraDelta.Languages;

using SieraDelta.Library;
using SieraDelta.Library.Utils;
using SieraDelta.Library.BOL.Users;
using SieraDelta.Library.BOL.Invoices;
using SieraDelta.Library.BOL.Orders;
using SieraDelta.Library.BOL.Countries;
using SieraDelta.Library.BOL.Appointments;
using SieraDelta.Library.BOL.Therapists;
using SieraDelta.Library.BOL.Staff;

using SieraDelta.POS.Classes;

namespace SieraDelta.POS.Administration.Forms.Staff
{
    public partial class AdminStaffEdit : SieraDelta.POS.Forms.BaseForm
    {
        #region Private Members

        private WebsiteAdministration _Admin;
        private User _staffMember;
        private Therapist _therapist;

        #endregion Private Members

        #region Constructors

        public AdminStaffEdit(WebsiteAdministration admin)
        {
            _Admin = admin;

            InitializeComponent();
            tvStaffMembers.AllowNoNodeSelected = false;
            
            LoadStaffMembers();
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppStaffMemberEdit;

            tabPageDiary.Text = LanguageStrings.AppDiary;
            tabPagePermissions.Text = LanguageStrings.AppPermissions;
            tabPageTreatments.Text = LanguageStrings.AppTreatments;
            tabPageUserDetails.Text = LanguageStrings.AppDetails;
            tabPageWorkingHours.Text = LanguageStrings.AppWorkingHours;

            btnAdd.Text = LanguageStrings.AppMenuButtonAdd;
            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnCreateDiary.Text = LanguageStrings.AppMenuButtonCreateDiary;
            btnDeleteDiary.Text = LanguageStrings.AppMenuButtonDeleteDiary;
            btnRemove.Text = LanguageStrings.AppMenuButtonRemove;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;
            btnWorkingHoursCreate.Text = LanguageStrings.AppMenuButtonNew;
            btnWorkingHoursDelete.Text = LanguageStrings.AppMenuButtonDelete;
            btnWorkingHoursUpdate.Text = LanguageStrings.AppMenuButtonUpdate;

            lblAddressLine1.Text = LanguageStrings.AddressLine1;
            lblAddressLine2.Text = LanguageStrings.AddressLine2;
            lblAddressLine3.Text = LanguageStrings.AddressLine3;
            lblAssignedPermissions.Text = LanguageStrings.AppAssignedPermissions;
            lblAvailableTreatments.Text = LanguageStrings.AppAvailableTreatments;
            lblBusinessName.Text = LanguageStrings.BusinessName;
            lblCity.Text = LanguageStrings.City;
            lblCountry.Text = LanguageStrings.Country;
            lblCounty.Text = LanguageStrings.County;
            lblCurrentWorkingRules.Text = LanguageStrings.AppWorkingRulesCurrent;
            lblEmail.Text = LanguageStrings.AppEmail;
            lblEmployeeName.Text = LanguageStrings.AppStaffName;
            lblEvery.Text = LanguageStrings.AppEvery;
            lblFinishHour.Text = LanguageStrings.AppWorkingFinishHour;
            lblFirstName.Text = LanguageStrings.FirstName;
            lblFrequency.Text = LanguageStrings.AppFrequency;
            lblLastName.Text = LanguageStrings.LastName;
            lblLunchDuration.Text = LanguageStrings.AppStaffLunchDuration;
            lblLunchStart.Text = LanguageStrings.AppStaffLunchStart;
            lblMemberLevel.Text = LanguageStrings.AppMemberLevel;
            lblPostCode.Text = LanguageStrings.Postcode;
            lblRepeatFrequency.Text = LanguageStrings.AppRepeatFrequency;
            lblRepeatOption.Text = LanguageStrings.AppRepeatOption;
            lblStartDate.Text = LanguageStrings.AppWorkingStartDate;
            lblStartHour.Text = LanguageStrings.AppWorkingStartHour;
            lblTelephone.Text = LanguageStrings.Telephone;
            lblWorkingFinishTime.Text = LanguageStrings.AppWorkingFinishTime;
            lblWorkingStartTime.Text = LanguageStrings.AppWorkingStartTime;
            
        }

        protected override void SetPermissions()
        {
            btnSave.Enabled = AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AllowSave);
            cmbMemberLevel.Enabled = AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AlterUserMemberLevel);

            if (!AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerAssignPermissions))
                tabControl1.TabPages.Remove(tabPagePermissions);
        }

        #endregion Overridden Methods

        #region Properties

        /// <summary>
        /// Indicates the member of staff has changed
        /// </summary>
        private bool CurrentStaffChanged { get; set; }

        /// <summary>
        /// Currently viewed staff member
        /// </summary>
        private User CurrentStaffMember
        {
            get
            {
                return (_staffMember);
            }

            set
            {
                _staffMember = value;
                CurrentStaffChanged = false;
            }
        }

        #endregion Properties

        #region Private Methods

        private void LoadStaffMembers()
        {
            Users staffMembers = User.StaffMembers();

            foreach (User staff in staffMembers)
            {
                if (staff.MemberLevel == Enums.MemberLevel.System)
                    continue;

                if (staff.Manager == null)
                {
                    TreeNode node = new TreeNode();
                    node.Tag = staff;
                    node.Text = staff.UserName;
                    tvStaffMembers.Nodes.Add(node);
                    LoadManagedUsers(staffMembers, staff, node);
                }
            }

            tvStaffMembers.SelectedNode = tvStaffMembers.Nodes[0];
        }

        private void LoadManagedUsers(Users allStaff, User currentStaff, TreeNode currentNode)
        {
            foreach (User staff in allStaff)
            {
                if (staff.Manager != null && staff.Manager.ID == currentStaff.ID)
                {
                    TreeNode node = new TreeNode();
                    node.Tag = staff;
                    node.Text = staff.UserName;
                    currentNode.Nodes.Add(node);
                    currentNode.Expand();
                    LoadManagedUsers(allStaff, staff, node);
                }
            }
        }

        private void LoadLunchDurations()
        {
            cmbLunchDuration.Items.Clear();

            for (int i = 0; i < 105; i += 15)
            {
                cmbLunchDuration.Items.Add(String.Format(LanguageStrings.AppMinutes, i));
            }
        }

        private void LoadGroups()
        {
            AppointmentGroups groups = AppointmentGroups.Get();
            cmbGroup.Items.Clear();

            foreach (AppointmentGroup group in groups)
            {
                int idx = cmbGroup.Items.Add(group);

                if (_therapist != null && group.ID == _therapist.Group.ID)
                    cmbGroup.SelectedIndex = idx;
            }
        }

        private void LoadStartFinishTimes()
        {
            DateTime Start = Convert.ToDateTime(String.Format(StringConstants.STAFF_FIRST_START_TIME, DateTime.Now.ToShortDateString()));

            cmbStartTime.Items.Clear();
            cmbWorkingHoursStart.Items.Clear();

            while (Start.Hour <= 19)
            {
                cmbStartTime.Items.Add(Start.ToString(StringConstants.DATE_TIME_HOUR));
                cmbWorkingHoursStart.Items.Add(Start.ToString(StringConstants.DATE_TIME_HOUR));
                Start = Start.AddMinutes(15);
            }

            Start = Convert.ToDateTime(String.Format(StringConstants.STAFF_START_10_AM, DateTime.Now.ToShortDateString()));

            cmbFinishTime.Items.Clear();
            cmbWorkingHoursFinish.Items.Clear();

            while (Start.Hour <= 22)
            {
                cmbFinishTime.Items.Add(Start.ToString(StringConstants.DATE_TIME_HOUR));
                cmbWorkingHoursFinish.Items.Add(Start.ToString(StringConstants.DATE_TIME_HOUR));
                Start = Start.AddMinutes(15);
            }

            Start = Convert.ToDateTime(String.Format(StringConstants.STAFF_START_10_30_AM, DateTime.Now.ToShortDateString()));

            cmbLunchStart.Items.Clear();

            while (Start.Hour < 14)
            {
                cmbLunchStart.Items.Add(Start.ToString(StringConstants.DATE_TIME_HOUR));
                Start = Start.AddMinutes(15);
            }
        }

        private void LoadTreatments()
        {
            AppointmentTreatments treatments = AppointmentTreatments.Get();
            lbTherapistTreatments.Items.Clear();
            lbAvailableTreatments.Items.Clear();

            foreach (AppointmentTreatment treatment in treatments)
            {
                if (_therapist != null && _therapist.Treatments.Available(treatment))
                    lbTherapistTreatments.Items.Add(treatment);
                else
                    lbAvailableTreatments.Items.Add(treatment);
            }
        }

        private void LoadCountries()
        {
            Countries countries = Countries.Get();

            cmbCountry.Items.Clear();

            foreach (Country country in countries)
            {
                cmbCountry.Items.Add(country);
            }
        }

        private void LoadUser()
        {
            txtFirstName.Text = CurrentStaffMember.FirstName;
            txtLastName.Text = CurrentStaffMember.LastName;
            txtEmail.Text = CurrentStaffMember.Email;
            txtTelephone.Text = CurrentStaffMember.Telephone;
            txtBusinessName.Text = CurrentStaffMember.BusinessName;
            txtAddLine1.Text = CurrentStaffMember.AddressLine1;
            txtAddLine2.Text = CurrentStaffMember.AddressLine2;
            txtAddLine3.Text = CurrentStaffMember.AddressLine3;
            txtCity.Text = CurrentStaffMember.City;
            txtCounty.Text = CurrentStaffMember.County;
            txtPostCode.Text = CurrentStaffMember.PostCode;

            cmbCountry.SelectedIndex = cmbCountry.Items.IndexOf(CurrentStaffMember.Country);

            foreach (object obj in cmbCountry.Items)
            {
                Country country = (Country)obj;

                if (country.ID == CurrentStaffMember.Country.ID)
                {
                    cmbCountry.SelectedIndex = cmbCountry.Items.IndexOf(obj);
                    break;
                }
            }

            cmbMemberLevel.SelectedIndex = ((int)CurrentStaffMember.MemberLevel) - 6;

            LoadStaffDiaryOptions();
            LoadStaffTreatments();
        }

        private void LoadStaffDiaryOptions()
        {
            _therapist = null; 

            try
            {
                _therapist = Therapist.Get(CurrentStaffMember.ID);
            }
            catch (Exception err)
            {
                if (!err.Message.Contains(StringConstants.ERROR_THERAPIST_NOT_FOUND))
                    throw;
            }

            btnCreateDiary.Visible = _therapist == null;
            gbWorkingDays.Visible = _therapist != null;
            gbWorkingHours.Visible = _therapist != null;
            gbOptions.Visible = _therapist != null;
            gbLunch.Visible = _therapist != null;
            lblEmployeeName.Visible = _therapist != null;
            txtEmployeeName.Visible = _therapist != null;
            btnDeleteDiary.Visible = _therapist != null;
            gbGroup.Visible = _therapist != null;
            btnDeleteDiary.Top = btnCreateDiary.Top;

            if (_therapist == null)
            {
                tabControl1.TabPages.Remove(tabPageWorkingHours);
                tabControl1.TabPages.Remove(tabPageTreatments);
                tabControl1.TabPages.Remove(tabPageTreatments);
            }
            else
            {
                if (!tabControl1.TabPages.Contains(tabPageWorkingHours))
                    tabControl1.TabPages.Add(tabPageWorkingHours);
                if (!tabControl1.TabPages.Contains(tabPageTreatments))
                    tabControl1.TabPages.Add(tabPageTreatments);
                if (!tabControl1.TabPages.Contains(tabPageTreatments))
                    tabControl1.TabPages.Add(tabPageTreatments);
            }

            if (_therapist != null)
            {
                cbMonday.Checked = _therapist.AllowMonday;
                cbTuesday.Checked = _therapist.AllowTuesday;
                cbWednesday.Checked = _therapist.AllowWednesday;
                cbThursday.Checked = _therapist.AllowThursday;
                cbFriday.Checked = _therapist.AllowFriday;
                cbSaturday.Checked = _therapist.AllowSaturday;
                cbSunday.Checked = _therapist.AllowSunday;
                cbBookCurrentDay.Checked = _therapist.AllowBookCurrentDay;
                cbPublicDiary.Checked = _therapist.PublicDiary;
                SelectComboItem(cmbStartTime, SieraDelta.Shared.Utilities.DoubleToTime(_therapist.StartTime));
                SelectComboItem(cmbFinishTime, SieraDelta.Shared.Utilities.DoubleToTime(_therapist.EndTime));
                SelectComboItem(cmbLunchStart, SieraDelta.Shared.Utilities.DoubleToTime(_therapist.LunchStart));
                SelectComboItem(cmbLunchDuration, String.Format(LanguageStrings.AppMinutes, _therapist.LunchDuration));
                txtEmployeeName.Text = _therapist.EmployeeName;
                //-_ApptOptions.
            }
        }

        private void SelectComboItem(ComboBox combo, string Option)
        {
            for (int i = 0; i < combo.Items.Count; i++)
            {
                if ((string)combo.Items[i] == Option)
                {
                    combo.SelectedIndex = i;
                    break;
                }
            }
        }

        private void LoadStaffTreatments()
        {
            _therapist = Therapist.Get(CurrentStaffMember.ID);
        }

        private void cmbCountry_Format(object sender, ListControlConvertEventArgs e)
        {
            Country country = (Country)e.ListItem;
            e.Value = country.Name;
        }

        private void cmbMemberLevel_Format(object sender, ListControlConvertEventArgs e)
        {
            Enums.MemberLevel memberlevel = (Enums.MemberLevel)Convert.ToInt32(e.ListItem);
            e.Value = memberlevel.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveStaffDetails();
        }

        private void SaveStaffDetails()
        {
            try
            {
                permissions1.Save();

                if (CurrentStaffMember.Password.Length < 6)
                {
                    while (CurrentStaffMember.Password.Length < 6)
                        CurrentStaffMember.Password += StringConstants.SYMBOL_NINE;

                    //send new password
                    CurrentStaffMember.SendPasswordEmail();
                }

                if (txtEmail.Text.Length < 6)
                {
                    ShowInformation(LanguageStrings.AppUserEmail, LanguageStrings.AppUserEmailTooShort);
                    return;
                }

                CurrentStaffMember.FirstName = txtFirstName.Text;
                CurrentStaffMember.LastName = txtLastName.Text;
                CurrentStaffMember.Email = txtEmail.Text;
                CurrentStaffMember.Telephone = txtTelephone.Text;
                CurrentStaffMember.BusinessName = txtBusinessName.Text;
                CurrentStaffMember.AddressLine1 = txtAddLine1.Text;
                CurrentStaffMember.AddressLine2 = txtAddLine2.Text;
                CurrentStaffMember.AddressLine3 = txtAddLine3.Text;
                CurrentStaffMember.City = txtCity.Text;
                CurrentStaffMember.County = txtCounty.Text;
                CurrentStaffMember.Country = (Country)cmbCountry.Items[cmbCountry.SelectedIndex];

                Enums.MemberLevel newLevel = (Enums.MemberLevel)Convert.ToInt32(cmbMemberLevel.Items[cmbMemberLevel.SelectedIndex]);

                if (newLevel < Enums.MemberLevel.StaffMember && _therapist != null)
                {
                    if (ShowHardConfirm(LanguageStrings.AppStaffMember, LanguageStrings.AppStaffMemberRemoveDiaryPrompt))
                    {
                        Therapist.Delete(_therapist);
                    }
                    else
                        return;
                }

                CurrentStaffMember.MemberLevel = newLevel;
                CurrentStaffMember.Save();

                if (btnWorkingHoursUpdate.Enabled)
                    btnWorkingHoursUpdate_Click(this, EventArgs.Empty);

                //treatments
                if (_therapist != null)
                {
                    _therapist.Treatments.Clear();

                    // a change here, both available and assigned and removed appointments will be
                    // added, the treatment now has a new property called status, and this will
                    // identify which items have changed or not, and what the new status will be
                    foreach (AppointmentTreatment treatment in lbTherapistTreatments.Items)
                        _therapist.Treatments.Add(treatment);

                    foreach (AppointmentTreatment treatment in lbAvailableTreatments.Items)
                        if (treatment.Status == ChangeState.Remove)
                            _therapist.Treatments.Insert(0, treatment);


                    //diary
                    _therapist.AllowMonday = cbMonday.Checked;
                    _therapist.AllowTuesday = cbTuesday.Checked;
                    _therapist.AllowWednesday = cbWednesday.Checked;
                    _therapist.AllowThursday = cbThursday.Checked;
                    _therapist.AllowFriday = cbFriday.Checked;
                    _therapist.AllowSaturday = cbSaturday.Checked;
                    _therapist.AllowSunday = cbSunday.Checked;
                    _therapist.AllowBookCurrentDay = cbBookCurrentDay.Checked;

                    _therapist.EndTime = SieraDelta.Shared.Utilities.TimeToDouble(
                        (string)cmbFinishTime.Items[cmbFinishTime.SelectedIndex]);
                    _therapist.StartTime = SieraDelta.Shared.Utilities.TimeToDouble(
                        (string)cmbStartTime.Items[cmbStartTime.SelectedIndex]);

                    _therapist.PublicDiary = cbPublicDiary.Checked;
                    _therapist.LunchStart = SieraDelta.Shared.Utilities.TimeToDouble(
                        (string)cmbLunchStart.Items[cmbLunchStart.SelectedIndex]);

                    string duration = (string)cmbLunchDuration.Items[cmbLunchDuration.SelectedIndex];
                    _therapist.LunchDuration = Convert.ToInt32(duration.Replace(
                        String.Format(LanguageStrings.AppMinutes, String.Empty).Trim(), String.Empty));
                    _therapist.EmployeeName = txtEmployeeName.Text;

                    if (AppController.ActiveUser.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.ChangeGroups))
                        _therapist.Group = (AppointmentGroup)cmbGroup.SelectedItem;

                    try
                    {
                        _therapist.Save();
                    }
                    catch //(Exception err)
                    {
                        ShowError(LanguageStrings.AppError, LanguageStrings.AppStaffSaveError);
                        //SieraDelta.Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err, sender, e);
                    }
                }

                //is it the currently logged on user?
                if (CurrentStaffMember.ID == AppController.ActiveUser.ID)
                {
                    AppController.POSApplication.GetUser = User.UserGet(CurrentStaffMember.ID);
                }

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception error)
            {
                if (error.Message.Contains(StringConstants.ERROR_LOCK_CONFLICT))
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppErrorLockConflictDesc);
                }
                else
                    throw;
            }
        }

        private void lstTreatments_Format(object sender, ListControlConvertEventArgs e)
        {
            AppointmentTreatment treat = (AppointmentTreatment)e.ListItem;
            e.Value = treat.Name;
        }

        private void btnCreateDiary_Click(object sender, EventArgs e)
        {
            Therapist.Create(CurrentStaffMember);
            tabControl1.TabPages.Add(tabPageWorkingHours);
            tabControl1.TabPages.Add(tabPageTreatments);
            LoadStaffDiaryOptions();
            LoadStaffTreatments();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AppointmentTreatments treatments = new AppointmentTreatments();

            foreach (object item in lbAvailableTreatments.SelectedItems)
            {
                AppointmentTreatment treatment = (AppointmentTreatment)item;
                treatment.Status = ChangeState.Add;
                treatments.Add(treatment);
                lbTherapistTreatments.Items.Add(item);
            }

            foreach (AppointmentTreatment treat in treatments)
                lbAvailableTreatments.Items.Remove(treat);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            AppointmentTreatments treatments = new AppointmentTreatments();

            foreach (object item in lbTherapistTreatments.SelectedItems)
            {
                AppointmentTreatment treatment = (AppointmentTreatment)item;
                treatments.Add(treatment);
                treatment.Status = ChangeState.Remove;
                lbAvailableTreatments.Items.Add(item);
            }

            foreach (AppointmentTreatment treat in treatments)
                lbTherapistTreatments.Items.Remove(treat);
        }

        private void btnDeleteDiary_Click(object sender, EventArgs e)
        {
            string response = String.Empty;

            if (!SieraDelta.POS.Administration.Classes.StaffMembers.CanDeleteDiary(CurrentStaffMember, ref response))
            {
                ShowError(LanguageStrings.Error, response);
                return;
            }

            Therapist.Delete(_therapist);
            tabControl1.TabPages.Remove(tabPageWorkingHours);
            _therapist = null;
            LoadUser();
        }

        private void LoadWorkingHours()
        {
            if (_therapist == null)
            {
                tabControl1.TabPages.Remove(tabPageWorkingHours);
            }
            else
            {
                _therapist.ResetWorkingDays();

                cmbWorkingHoursRepeatOption.Items.Clear();

                foreach (var item in Enum.GetNames(typeof(Enums.AppointmentRepeatType)))
                {
                    cmbWorkingHoursRepeatOption.Items.Add(item);
                }

                grpWorkingHours.Enabled = false;

                lstWorkingHours.Items.Clear();


                foreach (WorkingDay day in _therapist.WorkingDays)
                {
                    lstWorkingHours.Items.Add(day);
                }

                grpWorkingHours.Enabled = false;
                btnWorkingHoursDelete.Enabled = false;
                btnWorkingHoursUpdate.Enabled = false;
            }
        }

        private void lstWorkingHours_Format(object sender, ListControlConvertEventArgs e)
        {
            WorkingDay day = (WorkingDay)e.ListItem;
            string repeat = day.RepeatOption == Enums.AppointmentRepeatType.NoRepeat ?
                String.Empty : String.Format(LanguageStrings.AppWorkingHoursRepeatEvery, 
                day.RepeatDuration, day.RepeatOption.ToString());
            e.Value = String.Format(LanguageStrings.AppWorkingHoursDisplay, 
                day.Date.ToShortDateString(), day.Date.ToString(StringConstants.DATE_DAY), 
                repeat, day.AllowTreatments ? LanguageStrings.AppYes : LanguageStrings.AppNo);
        }

        private void lstWorkingHours_SelectedIndexChanged(object sender, EventArgs e)
        {
            WorkingDay day = (WorkingDay)lstWorkingHours.SelectedItem;

            grpWorkingHours.Enabled = day != null;
            btnWorkingHoursDelete.Enabled = day != null;
            btnWorkingHoursUpdate.Enabled = day != null;

            if (grpWorkingHours.Enabled)
            {
                string dt = SieraDelta.Shared.Utilities.DoubleToTime(day.StartTime);
                dtWorkingHoursDate.Value = day.Date;
                SelectComboItem(cmbWorkingHoursStart, SieraDelta.Shared.Utilities.DoubleToTime(day.StartTime));
                SelectComboItem(cmbWorkingHoursFinish, SieraDelta.Shared.Utilities.DoubleToTime(day.FinishTime));
                SelectComboItem(cmbWorkingHoursRepeatOption, day.RepeatOption.ToString());
                txtFrequency.Text = day.RepeatDuration.ToString();
                cbAllowTreatments.Checked = day.AllowTreatments;
            }
        }

        private void btnWorkingHoursUpdate_Click(object sender, EventArgs e)
        {
            if (!tabControl1.TabPages.Contains(tabPageWorkingHours))
                return;

            WorkingDay day = (WorkingDay)lstWorkingHours.SelectedItem;

            if (cmbWorkingHoursRepeatOption.SelectedIndex == -1)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppStaffSelectRepeatOption);
                cmbWorkingHoursRepeatOption.DroppedDown = true;
                return;
            }

            if (day != null)
            {
                string Option = (string)cmbWorkingHoursRepeatOption.Items[cmbWorkingHoursRepeatOption.SelectedIndex];
                day.Date = dtWorkingHoursDate.Value;
                day.StartTime = SieraDelta.Shared.Utilities.TimeToDouble((string)cmbWorkingHoursStart.Items[cmbWorkingHoursStart.SelectedIndex]);
                day.FinishTime = SieraDelta.Shared.Utilities.TimeToDouble((string)cmbWorkingHoursFinish.Items[cmbWorkingHoursFinish.SelectedIndex]);
                day.RepeatOption = (Enums.AppointmentRepeatType)Enum.Parse(typeof(Enums.AppointmentRepeatType), Option, true);
                day.RepeatDuration = SieraDelta.Shared.Utilities.StrToIntDef(txtFrequency.Text, 1);
                day.AllowTreatments = cbAllowTreatments.Checked;

                day.Save();
            }
        }

        private void btnWorkingHoursCreate_Click(object sender, EventArgs e)
        {
            WorkingDay newDay = _therapist.WorkingDays.Create(_therapist);
            lstWorkingHours.Items.Add(newDay);
        }

        private void btnWorkingHoursDelete_Click(object sender, EventArgs e)
        {
            WorkingDay day = (WorkingDay)lstWorkingHours.SelectedItem;

            if (day != null)
                if (ShowHardConfirm(LanguageStrings.AppWorkingHoursDelete, 
                    LanguageStrings.AppWorkingHoursDeletePromt))
                {
                    lstWorkingHours.Items.Remove(day);

                    try
                    {
                        day.Delete();
                    }
                    catch (Exception err)
                    {
                        if (err.Message.Contains(StringConstants.ERROR_UPDATE_CONFLICTS))
                        {
                            ShowError(LanguageStrings.AppWorkingHoursDelete, 
                                LanguageStrings.AppWorkingHoursDeleteError);
                        }
                        else
                            throw;
                    }
                }
        }

        private void cmbGroup_Format(object sender, ListControlConvertEventArgs e)
        {
            AppointmentGroup grp = (AppointmentGroup)e.ListItem;
            e.Value = grp.Description;
        }

        private void cmbMemberLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enums.MemberLevel newLevel = (Enums.MemberLevel)Convert.ToInt32(cmbMemberLevel.Items[cmbMemberLevel.SelectedIndex]);

            if (newLevel < CurrentStaffMember.MemberLevel)
            {
                string response = String.Empty;

                if (!SieraDelta.POS.Administration.Classes.StaffMembers.CanDowngradeAccount(CurrentStaffMember, ref response))
                {
                    ShowError(LanguageStrings.Error, response);
                    cmbMemberLevel.SelectedIndex = ((int)CurrentStaffMember.MemberLevel) - 6;
                    CurrentStaffChanged = true;
                }
            }
        }

        private void tvStaffMembers_DragDrop(object sender, DragEventArgs e)
        {
            tvStaffMembers.AfterSelect -= tvStaffMembers_AfterSelect;
            try
            {
                TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

                Point pt = tvStaffMembers.PointToClient(new System.Drawing.Point(e.X, e.Y));
                TreeNode targetNode = tvStaffMembers.GetNodeAt(pt);

                if (targetNode == null)
                {
                    draggedNode.Remove();
                    tvStaffMembers.Nodes.Add(draggedNode);
                    tvStaffMembers.SelectedNode = draggedNode;
                    ((User)draggedNode.Tag).Manager = null;
                    return;
                }

                TreeNode parentNode = targetNode;

                if (draggedNode != null &&
                    targetNode != null)
                {
                    bool canDrop = true;

                    while (canDrop && (parentNode != null))
                    {
                        canDrop = !Object.ReferenceEquals(draggedNode, parentNode);
                        parentNode = parentNode.Parent;
                    }

                    if (canDrop)
                    {
                        draggedNode.Remove();
                        targetNode.Nodes.Add(draggedNode);
                        tvStaffMembers.SelectedNode = draggedNode;
                        Library.BOL.Staff.Staff.ManagerSet((User)draggedNode.Tag, (User)targetNode.Tag);
                        targetNode.Expand();
                    }
                }
            }
            finally
            {
                tvStaffMembers.AfterSelect += tvStaffMembers_AfterSelect;
            }
        }

        private void tvStaffMembers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (CurrentStaffMember != null && ((User)e.Node.Tag).ID == CurrentStaffMember.ID)
                return;

            e.Node.NodeFont = new Font(tvStaffMembers.Font, FontStyle.Bold);
            e.Node.Text = e.Node.Text;
            CurrentStaffMember = (User)e.Node.Tag;
            permissions1.User = CurrentStaffMember;

            LoadLunchDurations();
            LoadStartFinishTimes();
            LoadCountries();
            LoadUser();
            LoadTreatments();
            LoadWorkingHours();
            LoadGroups();
        }

        private void tvStaffMembers_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (tvStaffMembers.SelectedNode != null)
                tvStaffMembers.SelectedNode.NodeFont = new Font(tvStaffMembers.Font, FontStyle.Regular);

            if (CurrentStaffChanged)
            {
                // details changed
                SaveStaffDetails();
            }
        }

        private void tvStaffMembers_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void tvStaffMembers_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        #endregion Private Methods
    }
}
