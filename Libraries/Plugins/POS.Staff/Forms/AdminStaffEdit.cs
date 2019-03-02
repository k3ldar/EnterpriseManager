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
 *  File: AdminStaffEdit.cs
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
using SharedBase.Utils;
using SharedBase.BOL.Trade;
using SharedBase.BOL.Users;
using SharedBase.BOL.Countries;
using SharedBase.BOL.Appointments;
using SharedBase.BOL.Therapists;
using SharedBase.BOL.Staff;

using POS.Base.Classes;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace POS.Staff.Forms
{
    public partial class AdminStaffEdit : POS.Base.Controls.BaseTabControl
    {
        #region Private Members

        private User _staffMember;
        private Therapist _therapist;
        private StringFormat _tabStringFormat;

        #endregion Private Members

        #region Constructors

        public AdminStaffEdit()
        {
            InitializeComponent();

            if (!AppController.ApplicationRunning)
                return;

            LoadPayPeriods();
            LoadEmploymentTypes();
            LoadGenderTypes();
            LoadMaritalStatuses();
            LoadCountries();

            _tabStringFormat = new StringFormat();
            _tabStringFormat.Alignment = StringAlignment.Center;
            _tabStringFormat.LineAlignment = StringAlignment.Center;

            dtpDateJoined.Format = DateTimePickerFormat.Custom;
            dtpDateOfBirth.Format = DateTimePickerFormat.Custom;
            dtpDatePermanent.Format = DateTimePickerFormat.Custom;
            dtpDateProbationEnds.Format = DateTimePickerFormat.Custom;
            dtpDLExpires.Format = DateTimePickerFormat.Custom;

            tvStaffMembers.AllowNoNodeSelected = false;

            if (AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.ManageOwnStaffOnly))
                AddStaffMember(AppController.ActiveUser, null);
            else
                LoadStaffMembers(false);

            tabStaff.SizeMode = TabSizeMode.Fixed;
            tabStaff.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        public AdminStaffEdit(WebsiteAdministration admin, User staffMember)
            : this()
        {

        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppStaffMemberEdit;

            tsbAddStaff.Text = LanguageStrings.AppStaffAddStaffMember;
            tsbRemoveStaff.Text = LanguageStrings.AppStaffRemoveStaffMember;
            tsbSave.Text = LanguageStrings.Save;
            tssbRefresh.Text = LanguageStrings.ButtonRefresh;

            tabPageDiary.Text = LanguageStrings.AppDiary;
            tabPagePermissions.Text = LanguageStrings.AppPermissions;
            tabPageTreatments.Text = LanguageStrings.AppTreatments;
            tabPageUserDetails.Text = LanguageStrings.AppDetails;
            tabPageWorkingHours.Text = LanguageStrings.AppWorkingHours;
            tabPageContactDetails.Text = LanguageStrings.AppStaffContactDetails;
            tabPageEmergencyContact.Text = LanguageStrings.AppStaffEmergencyContactDetails;
            tabPageEmploymentDetails.Text = LanguageStrings.AppStaffEmploymentDetails;
            tabPageLeave.Text = LanguageStrings.AppStaffLeave;
            tabPageLicenceDetails.Text = LanguageStrings.AppStaffLicenceDetails;
            tabPagePersonal.Text = LanguageStrings.AppStaffPersonalDetails;
            tabPageSickness.Text = LanguageStrings.AppStaffSicknessDetails;
            tabPageUserDetails.Text = LanguageStrings.AppDetails;


            btnAdd.Text = LanguageStrings.AppMenuButtonAdd;
            //btnCreateDiary.Text = LanguageStrings.AppMenuButtonCreateDiary;
            //btnDeleteDiary.Text = LanguageStrings.AppMenuButtonDeleteDiary;
            btnRemove.Text = LanguageStrings.AppMenuButtonRemove;
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

            // staff record
            lblEmergencContact1.Text = LanguageStrings.AppStaffEmergencyContact1;
            lblEmergencContact2.Text = LanguageStrings.AppStaffEmergencyContact2;
            lblEmergencRelation.Text = LanguageStrings.AppStaffEmergencyRelation;
            lblEmergencyName.Text = LanguageStrings.AppStaffEmergencyName;

            lblDLExpires.Text = LanguageStrings.Expires;
            lblDLNotes.Text = LanguageStrings.Notes;
            lblDLNumber.Text = LanguageStrings.AppStaffLicenceNumber;

            lblContactHome.Text = LanguageStrings.AppStaffContactHome;
            lblContactMobile.Text = LanguageStrings.AppStaffContactMobile;
            lblContactOther.Text = LanguageStrings.AppStaffContactOther;
            lblContactWork.Text = LanguageStrings.AppStaffContactWork;

            lblJobTitle.Text = LanguageStrings.AppStaffJobTitle;
            lblLocation.Text = LanguageStrings.AppStaffLocation;
            cbPartTime.Text = LanguageStrings.AppStaffPartTime;
            lblWeeklyHours.Text = LanguageStrings.AppStaffWeeklyHours;
            lblPayrollNumber.Text = LanguageStrings.AppStaffPayRollNumber;
            lblPayPeriod.Text = LanguageStrings.AppStaffPayPeriod;
            lblDateJoined.Text = LanguageStrings.AppStaffDateJoined;
            lblDatePermanent.Text = LanguageStrings.AppStaffDatePermanent;
            lblDateProbationEnds.Text = LanguageStrings.AppStaffProbationEnds;
            lblEmploymentType.Text = LanguageStrings.AppStaffEmploymentType;

            lblNationality.Text = LanguageStrings.AppStaffNationality;
            lblGender.Text = LanguageStrings.AppStaffGender;
            lblMaritalStatus.Text = LanguageStrings.AppStaffMaritalStatus;
            lblDateOfBirth.Text = LanguageStrings.AppStaffDateOfBirth;

            lblLeaveEntitlement.Text = LanguageStrings.AppStaffLeaveEntitlement;
            cbLeaveAccrues.Text = LanguageStrings.AppStaffLeaveAccrues;
            cbLeaveCarriesOver.Text = LanguageStrings.AppStaffLeaveCarriesOver;
            rbLeaveDays.Text = LanguageStrings.Days;
            rbLeaveHours.Text = LanguageStrings.Hours;

            dtpDateJoined.CustomFormat = Shared.Utilities.DateFormat(false, true);
            dtpDateOfBirth.CustomFormat = dtpDateJoined.CustomFormat;
            dtpDatePermanent.CustomFormat = dtpDateJoined.CustomFormat;
            dtpDateProbationEnds.CustomFormat = dtpDateJoined.CustomFormat;
            dtpDLExpires.CustomFormat = dtpDateJoined.CustomFormat;
            dtWorkingHoursDate.CustomFormat = dtpDateJoined.CustomFormat;

            tabPageCommission.Text = LanguageStrings.AppStaffCommission;


            tabPageClients.Text = LanguageStrings.AppClients;
            lblCommisionStaffRate.Text = LanguageStrings.AppStaffCommissionRate;
            lblCommisionManagerRate.Text = LanguageStrings.AppStaffManagerCommissionRate;
            lvClients.Columns[0].Text = LanguageStrings.Name;
            lvClients.Columns[1].Text = LanguageStrings.Telephone;
            lvClients.Columns[2].Text = LanguageStrings.CompanyName;
            lvClients.Columns[3].Text = LanguageStrings.State;
            lvClients.Columns[4].Text = LanguageStrings.Address;


            colWorkingHoursDay.Text = LanguageStrings.AppDay;
            colWorkingHoursRepeat.Text = LanguageStrings.AppRepeatOption;
            colWorkingHoursStart.Text = LanguageStrings.AppStartDate;
            colWorkingHoursRepeatFrequency.Text = LanguageStrings.AppFrequency;
            colWorkingHoursTreatments.Text = LanguageStrings.AppAllowTreatments;

            //sickness records
            chSicknessFinished.Text = LanguageStrings.AppSicknessDateFinished;
            chSicknessNotified.Text = LanguageStrings.AppSicknessDateNotified;
            chSicknessStarted.Text = LanguageStrings.AppSicknessDateStarted;
            chSicknessReason.Text = LanguageStrings.AppSicknessReasonProvided;
            chSicknessTotal.Text = LanguageStrings.AppSicknessTotalTime;
            chSicknessSelfCertified.Text = LanguageStrings.AppSicknessSelfCertified;
            pumSicknessView.Text = LanguageStrings.AppMenuView;
            pumSicknessNew.Text = LanguageStrings.AppMenuNew;
            pumSicknessReturnToWork.Text = LanguageStrings.AppMenuReturnToWork;
            pumSicknessStatistics.Text = LanguageStrings.AppSicknessStatisticsTitle;
            pumSicknessCancel.Text = LanguageStrings.AppMenuCancel;

            Size tabSize = tabStaff.ItemSize;

            foreach (TabPage page in tabStaff.TabPages)
            {
                Size fontSize = Shared.Utilities.MeasureText(page.Text, tabStaff.Font);
                int newWidth = Shared.Utilities.CheckMinMax(fontSize.Width, tabSize.Width, 200);

                if (tabSize.Width < (fontSize.Width + 30))
                    tabSize.Width = fontSize.Width + 30;

                if (tabSize.Height != fontSize.Height + 12)
                    tabSize.Height = fontSize.Height + 12;
            }

            tabStaff.ItemSize = tabSize;

        }

        public override string GetHelpTopic()
        {
            if (tabStaff.SelectedTab == tabPageUserDetails)
                return (POS.Base.Classes.HelpTopics.StaffPageDetails);
            else if (tabStaff.SelectedTab == tabPageContactDetails)
                return (POS.Base.Classes.HelpTopics.StaffPageContact);
            else if (tabStaff.SelectedTab == tabPageEmploymentDetails)
                return (POS.Base.Classes.HelpTopics.StaffPageEmployment);
            else if (tabStaff.SelectedTab == tabPagePersonal)
                return (POS.Base.Classes.HelpTopics.StaffPagePersonal);
            else if (tabStaff.SelectedTab == tabPageLeave)
                return (POS.Base.Classes.HelpTopics.StaffPageLeave);
            else if (tabStaff.SelectedTab == tabPageSickness)
                return (POS.Base.Classes.HelpTopics.StaffPageSickness);
            else if (tabStaff.SelectedTab == tabPageEmergencyContact)
                return (POS.Base.Classes.HelpTopics.StaffPageEmergencyContact);
            else if (tabStaff.SelectedTab == tabPageLicenceDetails)
                return (POS.Base.Classes.HelpTopics.StaffPageLicence);
            else if (tabStaff.SelectedTab == tabPageDiary)
                return (POS.Base.Classes.HelpTopics.StaffPageDiary);
            else if (tabStaff.SelectedTab == tabPageWorkingHours)
                return (POS.Base.Classes.HelpTopics.StaffPageWorkingHours);
            else if (tabStaff.SelectedTab == tabPageTreatments)
                return (POS.Base.Classes.HelpTopics.StaffPageTreatments);
            else if (tabStaff.SelectedTab == tabPagePermissions)
                return (POS.Base.Classes.HelpTopics.StaffPagePermissions);
            else if (tabStaff.SelectedTab == tabPageCommission)
                return (POS.Base.Classes.HelpTopics.StaffPageCommission);
            else if (tabStaff.SelectedTab == tabPageClients)
                return (POS.Base.Classes.HelpTopics.StaffPageClients);

            return (String.Empty);
        }

        public override void BeforeTabShow()
        {
        }

        public override void AfterTabShow()
        {
            this.Cursor = Cursors.Arrow;
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

        /// <summary>
        /// Indicates the member of staff has changed
        /// </summary>
        private bool CurrentStaffChanged { get; set; }

        /// <summary>
        /// Indicates that the staff record has changed for the user, so will need updating
        /// </summary>
        private bool CurrentStaffRecordChanged { get; set; }

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
                UpdateStatusBar();
            }
        }

        #endregion Properties

        #region Private Methods

        private void LoadStaffMembers(bool forceRefresh)
        {
            Cursor oldCursor = this.Cursor;

            this.Cursor = Cursors.WaitCursor;
            tvStaffMembers.BeginUpdate();
            try
            {
                Users staffMembers = User.StaffMembers(forceRefresh);
                bool manageOwnStaffOnly = AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.ManageOwnStaffOnly);
                tvStaffMembers.Nodes.Clear();

                foreach (User staff in staffMembers)
                {
                    if (staff.MemberLevel == MemberLevel.System)
                        continue;

                    if (manageOwnStaffOnly)
                    {
                        if (staff.Manager != null && staff.Manager.ID == POS.Base.Classes.AppController.ActiveUser.ID)
                        {
                            AddStaffMember(staff, staffMembers);
                        }
                    }
                    else if (staff.Manager == null)
                    {
                        AddStaffMember(staff, staffMembers);
                    }
                }

                if (tvStaffMembers.Nodes.Count > 0)
                {
                    tvStaffMembers.SelectedNode = tvStaffMembers.Nodes[0];
                }
            }
            finally
            {
                tvStaffMembers.EndUpdate();
                this.Cursor = oldCursor;
            }
        }

        private void AddStaffMember(User staff, Users staffMembers)
        {
            TreeNode node = new TreeNode();
            node.Tag = staff;
            node.Text = staff.UserName;
            tvStaffMembers.Nodes.Add(node);
            LoadManagedUsers(staffMembers, staff, node);
        }

        private void LoadManagedUsers(Users allStaff, User currentStaff, TreeNode currentNode)
        {
            if (allStaff == null)
                return;

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

        private void LoadMaritalStatuses()
        {
            cmbMaritalStatus.Items.Clear();

            foreach (MaritalStatus status in Enum.GetValues(typeof(MaritalStatus)))
            {
                cmbMaritalStatus.Items.Add(Base.EnumTranslations.Translate(status));
            }
        }

        private void LoadEmploymentTypes()
        {
            cmbEmploymentType.Items.Clear();

            foreach (EmploymentType employmentType in Enum.GetValues(typeof(EmploymentType)))
            {
                cmbEmploymentType.Items.Add(Base.EnumTranslations.Translate(employmentType));
            }
        }

        private void LoadGenderTypes()
        {
            cmbGender.Items.Clear();

            foreach (GenderType gender in Enum.GetValues(typeof(GenderType)))
            {
                cmbGender.Items.Add(Base.EnumTranslations.Translate(gender));
            }
        }

        private void LoadPayPeriods()
        {
            cmbPayPeriod.Items.Clear();

            foreach (PayPeriod period in Enum.GetValues(typeof(PayPeriod)))
            {
                cmbPayPeriod.Items.Add(Base.EnumTranslations.Translate(period));
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
            cmbNationality.Items.Clear();

            foreach (Country country in countries)
            {
                cmbCountry.Items.Add(country);
                cmbNationality.Items.Add(country);
            }
        }

        private void LoadUser()
        {
            this.Cursor = Cursors.WaitCursor;
            try
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

                foreach (Country country in cmbCountry.Items)
                {
                    if (country.ID == CurrentStaffMember.Country.ID)
                    {
                        cmbCountry.SelectedIndex = cmbCountry.Items.IndexOf(country);
                        break;
                    }
                }

                cmbMemberLevel.SelectedIndex = ((int)CurrentStaffMember.MemberLevel) - 6;

                LoadStaffRecord(CurrentStaffMember.StaffRecord);
                CurrentStaffRecordChanged = false;
                CurrentStaffChanged = false;
                LoadStaffDiaryOptions();
                LoadStaffTreatments();
                LoadUserClients();

                UpdateUI();
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        private void LoadUserClients()
        {
            Clients clients = Clients.Get(CurrentStaffMember);
            lvClients.Items.Clear();

            foreach (Client client in clients)
            {
                ListViewItem item = new ListViewItem(client.Name);
                item.SubItems.Add(client.Telephone);
                item.SubItems.Add(client.Company);
                item.SubItems.Add(Shared.Utilities.SplitCamelCase(client.State.ToString()));
                item.SubItems.Add(client.Address);
                item.Tag = client;
                lvClients.Items.Add(item);
            }
        }

        private void LoadStaffRecord(StaffMember staffRecord)
        {
            txtEmergencyContactName.Text = staffRecord.EmergencyContactName;
            txtEmergencyRelation.Text = staffRecord.EmergencyContactRelationship;
            string[] telephone = staffRecord.EmergencyContactTelephone.Split('#');
            txtEmergencyTel1.Text = telephone[0];

            if (telephone.Length > 1)
                txtEmergencyTel2.Text = telephone[1];

            txtDLNumber.Text = staffRecord.DrivingLicenceNumber;
            txtDLNotes.Text = staffRecord.DrivingLicenceNotes;
            dtpDLExpires.Value = staffRecord.DrivingLicenceExpire < dtpDLExpires.Value ? dtpDLExpires.MinDate : staffRecord.DrivingLicenceExpire;

            txtContactHome.Text = staffRecord.TelephoneHome;
            txtContactMobile.Text = staffRecord.TelephoneMobile;
            txtContactOther.Text = staffRecord.TelephoneOther;
            txtContactWork.Text = staffRecord.TelephoneWork;

            txtJobTitle.Text = staffRecord.Title;
            txtLocation.Text = staffRecord.Location;
            cbPartTime.Checked = staffRecord.PartTime;
            udWeeklyHours.Value = staffRecord.WeeklyHours;
            txtPayrollNumber.Text = staffRecord.PayrollNumber;
            cmbPayPeriod.SelectedIndex = (int)staffRecord.PayPeriod;
            cmbEmploymentType.SelectedIndex = (int)staffRecord.EmploymentType;

            cmbGender.SelectedIndex = (int)staffRecord.Gender;
            cmbMaritalStatus.SelectedIndex = (int)staffRecord.MaritalStatus;
            dtpDateOfBirth.Value = staffRecord.DateOfBirth;

            foreach (Country country in cmbCountry.Items)
            {
                if (country.ID == staffRecord.Nationality)
                {
                    cmbNationality.SelectedIndex = cmbCountry.Items.IndexOf(country);
                    break;
                }
            }


            // commission
            udCommissionStaff.Value = staffRecord.CommissionRate;
            udCommissionManager.Value = staffRecord.ManagerCommissionRate;
            LoadCommissionDetails();

            // leave
            udLeaveEntitlement.Value = staffRecord.LeaveEntitlement;
            cbLeaveCarriesOver.Checked = staffRecord.LeaveCarryOver;
            cbLeaveAccrues.Checked = staffRecord.LeaveAccrues;

            if (staffRecord.EntitlementType)
                rbLeaveHours.Checked = true;
            else
                rbLeaveDays.Checked = true;
        }

        private void LoadStaffDiaryOptions()
        {
            _therapist = null;

            try
            {
                _therapist = Therapist.Get(CurrentStaffMember.ID);

                if (_therapist == null)
                {
                    _therapist = Therapist.Create(CurrentStaffMember);
                }
            }
            catch (Exception err)
            {
                if (!err.Message.Contains(StringConstants.ERROR_THERAPIST_NOT_FOUND))
                    throw;
            }

            //btnCreateDiary.Visible = _therapist == null;
            gbWorkingDays.Visible = _therapist != null;
            gbWorkingHours.Visible = _therapist != null;
            gbOptions.Visible = _therapist != null;
            gbLunch.Visible = _therapist != null;
            lblEmployeeName.Visible = _therapist != null;
            txtEmployeeName.Visible = _therapist != null;
            //btnDeleteDiary.Visible = _therapist != null;
            gbGroup.Visible = _therapist != null;
            //btnDeleteDiary.Top = btnCreateDiary.Top;

            if (_therapist == null)
            {
                tabStaff.TabPages.Remove(tabPageWorkingHours);
                tabStaff.TabPages.Remove(tabPageTreatments);
                tabStaff.TabPages.Remove(tabPageTreatments);
            }
            else
            {
                if (!tabStaff.TabPages.Contains(tabPageWorkingHours))
                    tabStaff.TabPages.Add(tabPageWorkingHours);
                if (!tabStaff.TabPages.Contains(tabPageTreatments))
                    tabStaff.TabPages.Add(tabPageTreatments);
                if (!tabStaff.TabPages.Contains(tabPageTreatments))
                    tabStaff.TabPages.Add(tabPageTreatments);
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
                SelectComboItem(cmbStartTime, Shared.Utilities.DoubleToTime(_therapist.StartTime));
                SelectComboItem(cmbFinishTime, Shared.Utilities.DoubleToTime(_therapist.EndTime));
                SelectComboItem(cmbLunchStart, Shared.Utilities.DoubleToTime(_therapist.LunchStart));
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

        private void LoadCommissionDetails()
        {
            // load commission records
        }

        private void StaffRecordChanged(object sender, EventArgs e)
        {
            if (!CurrentStaffRecordChanged)
            {
                CurrentStaffRecordChanged = true;
                UpdateUI();
            }
        }

        private void StaffDetailsChanged(object sender, EventArgs e)
        {
            if (!CurrentStaffChanged)
            {
                CurrentStaffChanged = true;
                UpdateUI();
            }
        }

        private void cmbCountry_Format(object sender, ListControlConvertEventArgs e)
        {
            Country country = (Country)e.ListItem;
            e.Value = country.Name;
        }

        private void cmbMemberLevel_Format(object sender, ListControlConvertEventArgs e)
        {
            MemberLevel memberlevel = (MemberLevel)Convert.ToInt32(e.ListItem);
            e.Value = memberlevel.ToString();
        }

        private void SaveStaffRecord()
        {
            try
            {
                StaffMember staffRecord = CurrentStaffMember.StaffRecord;

                staffRecord.EmergencyContactName = txtEmergencyContactName.Text;
                staffRecord.EmergencyContactRelationship = txtEmergencyRelation.Text;
                staffRecord.EmergencyContactTelephone = String.Format(
                    POS.Base.Classes.StringConstants.EMERGENCY_CONTACT_DATA,
                    txtEmergencyTel1.Text, txtEmergencyTel2.Text);

                staffRecord.DrivingLicenceNumber = txtDLNumber.Text;
                staffRecord.DrivingLicenceNotes = txtDLNotes.Text;
                staffRecord.DrivingLicenceExpire = dtpDLExpires.Value;

                staffRecord.TelephoneHome = txtContactHome.Text;
                staffRecord.TelephoneMobile = txtContactMobile.Text;
                staffRecord.TelephoneOther = txtContactOther.Text;
                staffRecord.TelephoneWork = txtContactWork.Text;

                staffRecord.Title = txtJobTitle.Text;
                staffRecord.Location = txtLocation.Text;
                staffRecord.PartTime = cbPartTime.Checked;
                staffRecord.WeeklyHours = udWeeklyHours.Value;
                staffRecord.PayrollNumber = txtPayrollNumber.Text;
                staffRecord.PayPeriod = (PayPeriod)cmbPayPeriod.SelectedIndex;
                staffRecord.EmploymentType = (EmploymentType)cmbEmploymentType.SelectedIndex;

                staffRecord.Gender = (GenderType)cmbGender.SelectedIndex;
                staffRecord.MaritalStatus = (MaritalStatus)cmbMaritalStatus.SelectedIndex;

                staffRecord.DateOfBirth = dtpDateOfBirth.Value;

                Country country = (Country)cmbNationality.Items[cmbNationality.SelectedIndex];
                staffRecord.Nationality = country.ID;

                staffRecord.LeaveEntitlement = udLeaveEntitlement.Value;
                staffRecord.LeaveCarryOver = cbLeaveCarriesOver.Checked;
                staffRecord.LeaveAccrues = cbLeaveAccrues.Checked;

                staffRecord.EntitlementType = rbLeaveHours.Checked;

                // commission
                staffRecord.CommissionRate = udCommissionStaff.Value;
                staffRecord.ManagerCommissionRate = udCommissionManager.Value;

                staffRecord.Save();

                CurrentStaffRecordChanged = false;
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

                MemberLevel newLevel = (MemberLevel)Convert.ToInt32(cmbMemberLevel.Items[cmbMemberLevel.SelectedIndex]);

                if (newLevel < MemberLevel.StaffMember && _therapist != null)
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

                    _therapist.EndTime = Shared.Utilities.TimeToDouble(
                        (string)cmbFinishTime.Items[cmbFinishTime.SelectedIndex]);
                    _therapist.StartTime = Shared.Utilities.TimeToDouble(
                        (string)cmbStartTime.Items[cmbStartTime.SelectedIndex]);

                    _therapist.PublicDiary = cbPublicDiary.Checked;
                    _therapist.LunchStart = Shared.Utilities.TimeToDouble(
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
                        //Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err, sender, e);
                    }
                }

                //is it the currently logged on user?
                if (CurrentStaffMember.ID == AppController.ActiveUser.ID)
                {
                    AppController.ApplicationController.GetUser = User.UserGet(CurrentStaffMember.ID);
                }

                CurrentStaffChanged = false;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AppointmentTreatments treatments = new AppointmentTreatments();

            foreach (object item in lbAvailableTreatments.SelectedItems)
            {
                AppointmentTreatment treatment = (AppointmentTreatment)item;
                treatment.Status = ChangeState.Add;
                treatments.Add(treatment);
                lbTherapistTreatments.Items.Add(item);
                CurrentStaffChanged = true;
                UpdateUI();
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
                CurrentStaffChanged = true;
                UpdateUI();
            }

            foreach (AppointmentTreatment treat in treatments)
                lbTherapistTreatments.Items.Remove(treat);
        }

        private void LoadWorkingHours()
        {
            if (_therapist == null)
            {
                tabStaff.TabPages.Remove(tabPageWorkingHours);
            }
            else
            {
                _therapist.ResetWorkingDays();

                cmbWorkingHoursRepeatOption.Items.Clear();

                foreach (string item in Enum.GetNames(typeof(Enums.AppointmentRepeatType)))
                {
                    cmbWorkingHoursRepeatOption.Items.Add(item);
                }

                grpWorkingHours.Enabled = false;

                lvWorkingHours.BeginUpdate();
                try
                {
                    lvWorkingHours.Items.Clear();

                    foreach (WorkingDay day in _therapist.WorkingDays)
                    {
                        ListViewItem item = new ListViewItem(day.Date.ToShortDateString());
                        item.Tag = day;
                        day.Tag = item;
                        day.OnDelete += day_OnDelete;
                        day.OnSave += day_OnSave;
                        item.SubItems.Add(day.Date.ToString(StringConstants.DATE_DAY));
                        item.SubItems.Add(day.RepeatOption == Enums.AppointmentRepeatType.NoRepeat ?
                            LanguageStrings.AppNo : day.RepeatOption.ToString());
                        item.SubItems.Add(day.RepeatDuration.ToString());
                        item.SubItems.Add(day.AllowTreatments ? LanguageStrings.AppYes : LanguageStrings.AppNo);

                        lvWorkingHours.Items.Add(item);
                    }
                }
                finally
                {
                    lvWorkingHours.EndUpdate();
                }

                grpWorkingHours.Enabled = false;
                btnWorkingHoursDelete.Enabled = false;
                btnWorkingHoursUpdate.Enabled = false;
            }
        }

        void day_OnDelete(object sender, SharedBase.BOLEvents.WorkingDayEventArgs e)
        {
            ListViewItem item = (ListViewItem)e.Day.Tag;

            if (item == null)
                return;

            lvWorkingHours.Items.Remove(item);
        }

        void day_OnSave(object sender, SharedBase.BOLEvents.WorkingDayEventArgs e)
        {
            ListViewItem item = (ListViewItem)e.Day.Tag;

            if (item == null)
                return;

            item.Text = e.Day.Date.ToShortDateString();

            item.SubItems[1].Text = e.Day.Date.ToString(StringConstants.DATE_DAY);
            item.SubItems[2].Text = e.Day.RepeatOption == Enums.AppointmentRepeatType.NoRepeat ?
                LanguageStrings.AppNo : e.Day.RepeatOption.ToString();
            item.SubItems[3].Text = e.Day.RepeatDuration.ToString();
            item.SubItems[4].Text = e.Day.AllowTreatments ? LanguageStrings.AppYes : LanguageStrings.AppNo;
        }

        private void lvWorkingHours_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvWorkingHours.SelectedItems.Count == 0)
                return;

            WorkingDay day = (WorkingDay)lvWorkingHours.SelectedItems[0].Tag;

            grpWorkingHours.Enabled = day != null;
            btnWorkingHoursDelete.Enabled = day != null;
            btnWorkingHoursUpdate.Enabled = day != null;

            if (grpWorkingHours.Enabled)
            {
                string dt = Shared.Utilities.DoubleToTime(day.StartTime);
                dtWorkingHoursDate.Value = day.Date;
                SelectComboItem(cmbWorkingHoursStart, Shared.Utilities.DoubleToTime(day.StartTime));
                SelectComboItem(cmbWorkingHoursFinish, Shared.Utilities.DoubleToTime(day.FinishTime));
                SelectComboItem(cmbWorkingHoursRepeatOption, day.RepeatOption.ToString());
                txtFrequency.Text = day.RepeatDuration.ToString();
                cbAllowTreatments.Checked = day.AllowTreatments;
            }
        }

        private void btnWorkingHoursUpdate_Click(object sender, EventArgs e)
        {
            if (!tabStaff.TabPages.Contains(tabPageWorkingHours))
                return;

            if (lvWorkingHours.SelectedItems.Count == 0)
                return;

            WorkingDay day = (WorkingDay)lvWorkingHours.SelectedItems[0].Tag;

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
                day.StartTime = Shared.Utilities.TimeToDouble((string)cmbWorkingHoursStart.Items[cmbWorkingHoursStart.SelectedIndex]);
                day.FinishTime = Shared.Utilities.TimeToDouble((string)cmbWorkingHoursFinish.Items[cmbWorkingHoursFinish.SelectedIndex]);
                day.RepeatOption = (Enums.AppointmentRepeatType)Enum.Parse(typeof(Enums.AppointmentRepeatType), Option, true);
                day.RepeatDuration = Shared.Utilities.StrToIntDef(txtFrequency.Text, 1);
                day.AllowTreatments = cbAllowTreatments.Checked;

                day.Save();
            }
        }

        private void btnWorkingHoursCreate_Click(object sender, EventArgs e)
        {
            lvWorkingHours.SelectedItems.Clear();
            WorkingDay day = _therapist.WorkingDays.Create(_therapist);

            ListViewItem newItem = new ListViewItem(day.Date.ToShortDateString());

            newItem.SubItems.Add(day.Date.ToString(StringConstants.DATE_DAY));
            newItem.SubItems.Add(day.RepeatOption == Enums.AppointmentRepeatType.NoRepeat ?
                LanguageStrings.AppNo : day.RepeatOption.ToString());
            newItem.SubItems.Add(day.RepeatDuration.ToString());
            newItem.SubItems.Add(day.AllowTreatments ? LanguageStrings.AppYes : LanguageStrings.AppNo);

            day.Tag = newItem;
            day.OnDelete += day_OnDelete;
            day.OnSave += day_OnSave;
            newItem.Tag = day;
            lvWorkingHours.Items.Add(newItem);
            newItem.Selected = true;
        }

        private void btnWorkingHoursDelete_Click(object sender, EventArgs e)
        {
            if (lvWorkingHours.SelectedItems.Count == 0)
                return;

            WorkingDay day = (WorkingDay)lvWorkingHours.SelectedItems[0].Tag;

            if (day != null)
            {
                if (ShowHardConfirm(LanguageStrings.AppWorkingHoursDelete,
                    LanguageStrings.AppWorkingHoursDeletePromt))
                {
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
        }

        private void cmbGroup_Format(object sender, ListControlConvertEventArgs e)
        {
            AppointmentGroup grp = (AppointmentGroup)e.ListItem;
            e.Value = grp.Description;
        }

        private void cmbMemberLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void RemoveStaffMember(User user)
        {
            string response = String.Empty;

            if (!POS.Staff.Classes.StaffMembers.CanDowngradeAccount(user, ref response))
            {
                ShowError(LanguageStrings.Error, response);
            }
            else
            {
                response = CurrentStaffMember.UserName;

                if (ShowQuestion(LanguageStrings.AppStaffRemoveStaffMember, String.Format(LanguageStrings.AppStaffRemovePrompt, response)))
                {
                    user.MemberLevel = MemberLevel.FormerStaffMember;
                    user.Save();
                    LoadStaffMembers(true);
                    UpdateUI();
                    ShowInformation(LanguageStrings.AppStaffRemoveStaffMember,
                        String.Format(LanguageStrings.AppStaffRemoved, response));
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
                        SharedBase.BOL.Staff.Staff.ManagerSet((User)draggedNode.Tag, (User)targetNode.Tag);
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

            CurrentStaffMember = (User)e.Node.Tag;
            permissions1.User = CurrentStaffMember;
            leaveRequests1.StaffMember = CurrentStaffMember;

            LoadLunchDurations();
            LoadStartFinishTimes();
            LoadUser();
            LoadTreatments();
            LoadWorkingHours();
            LoadGroups();
            LoadStaffSickness();

            CurrentStaffChanged = false;
            CurrentStaffRecordChanged = false;

            if (tabStaff.SelectedTab == tabPageCommission)
                LoadStaffCommission();

            UpdateUI();

            POS.Base.Classes.PluginManager.RaiseEvent(
                new Base.Plugins.NotificationEventArgs(StringConstants.PLUGIN_EVENT_UPDATE_STATUS_BAR));
        }

        private void tvStaffMembers_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (CurrentStaffChanged || CurrentStaffRecordChanged)
            {
                if (ShowQuestion(LanguageStrings.AppStaffStaffChanges,
                    String.Format(LanguageStrings.AppStaffStaffChangesPrompt, CurrentStaffMember.UserName)))
                {
                    SaveStaff();
                }

                CurrentStaffRecordChanged = false;
                CurrentStaffChanged = false;
                UpdateUI();
            }
            else
            {
                if (CurrentStaffMember != null)
                {
                    CurrentStaffMember.StaffRecord.Reload();
                    leaveRequests1.LoadLeave(false);
                    LoadWorkingHours();
                }
            }
        }

        private void tvStaffMembers_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (CurrentStaffChanged || CurrentStaffRecordChanged)
            {
                ShowInformation(LanguageStrings.AppEmployeeMove, LanguageStrings.AppEmployeeMovePreventedEditing);
            }
            else
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void tvStaffMembers_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void UpdateUI()
        {
            tsbAddStaff.Enabled = true;
            tsbRemoveStaff.Enabled = true;
            tsbSave.Enabled = CurrentStaffChanged || CurrentStaffRecordChanged;
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveStaff();
        }

        private void SaveStaff()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // details changed
                if (CurrentStaffChanged)
                    SaveStaffDetails();

                if (CurrentStaffRecordChanged)
                    SaveStaffRecord();

                UpdateUI();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void UpdateStatusBar()
        {
            StaffMember staff = CurrentStaffMember.StaffRecord;

            statusLabelAnniversary.Text = String.Format(LanguageStrings.AppStaffWorkAniversary,
                staff.DateJoined.ToString(POS.Base.Classes.StringConstants.DATE_WORK_ANIVERSARY));
            statusLabelLeaveRemaining.Text = String.Format(LanguageStrings.AppStaffLeaveRemaining,
                staff.LeaveRemaining(), staff.EntitlementType ? LanguageStrings.Hours : LanguageStrings.Days);

            statusLabelSpare.Visible = false;
        }

        private void tsbAddStaff_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.CreateNewStaffMember))
            {
                if (Classes.StaffMembers.CreateNewEmployee())
                    LoadStaffMembers(true);
            }
            else
                ShowError(LanguageStrings.AppStaffMemberCreate, LanguageStrings.AppPermissionCreateStaffMember);
        }

        private void tsbRemoveStaff_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.RemoveStaffMembers))
            {
                RemoveStaffMember(CurrentStaffMember);
            }
            else
                ShowError(LanguageStrings.AppStaffMemberRemove, LanguageStrings.AppPermissionRemoveStaffMember);
        }

        private void tssbRefresh_Click(object sender, EventArgs e)
        {
            LoadStaffMembers(true);
        }


        public override void BeforeTabHide()
        {
            if (tsbSave.Enabled && CurrentStaffMember != null)
            {
                if (ShowQuestion(LanguageStrings.AppStaffMemberEdit,
                    String.Format(LanguageStrings.AppStaffManageClosingPrompt, CurrentStaffMember.UserName)))
                {
                    SaveStaff();
                }

                CurrentStaffChanged = false;
                CurrentStaffRecordChanged = false;
                UpdateUI();
            }
        }


        #region Commission

        private void udCommissionStaff_ValueChanged(object sender, EventArgs e)
        {
            if (udCommissionManager.Value > udCommissionStaff.Value)
                udCommissionManager.Value = udCommissionStaff.Value;

            udCommissionManager.Maximum = udCommissionStaff.Value;

            StaffRecordChanged(sender, e);
        }

        private void tabPageCommission_Enter(object sender, EventArgs e)
        {
            LoadStaffCommission();
        }

        private void LoadStaffCommission()
        {
            lblCommissionDetails.Text = String.Empty;

            lvCommissionPayments.Items.Clear();

            decimal commissionDue = 0;

            foreach (PaidCommissionItem commission in PaidCommission.Get(CurrentStaffMember))
            {
                commissionDue += commission.Amount;

                ListViewItem item = new ListViewItem(Shared.Utilities.FormatDate(commission.DatePaid,
                    System.Threading.Thread.CurrentThread.CurrentUICulture.Name,
                    System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern));
                item.Tag = commission;
                item.SubItems.Add(Library.Utils.SharedUtils.FormatMoney(commission.Amount,
                    POS.Base.Classes.AppController.LocalCurrency));
                item.SubItems.Add(commission.PayingName);
                item.SubItems.Add(commission.PaymentType.ToString());
                lvCommissionPayments.Items.Add(item);
            }

            lblCommissionDetails.Text = String.Format(String.Format(LanguageStrings.AppCommissionDue,
                SharedUtils.FormatMoney(commissionDue, POS.Base.Classes.AppController.LocalCurrency)));
        }

        #endregion Commission

        #region Sickness

        private void LoadStaffSickness()
        {
            lvSicknessRecords.Items.Clear();
            StaffSickRecords sick = StaffSickRecords.All(CurrentStaffMember);

            foreach (StaffSickRecord record in sick)
            {
                ListViewItem item = new ListViewItem(Utilities.DateToStr(record.DateNotified, AppController.LocalCulture));
                item.Tag = record;
                item.SubItems.Add(record.ReasonCited);
                item.SubItems.Add(Utilities.DateToStr(record.DateStarted, AppController.LocalCulture));
                item.SubItems.Add(record.DateFinished == DateTime.MinValue ?
                    String.Empty : Utilities.DateToStr(record.DateFinished, AppController.LocalCulture));

                if (record.DateFinished > DateTime.MinValue)
                {
                    TimeSpan span = record.DateFinished - record.DateStarted;
                    item.SubItems.Add(String.Format(LanguageStrings.AppSicknessTotalDays, Math.Round(span.TotalDays, 2)));
                }
                else if (record.DateStarted > DateTime.Now)
                {
                    item.SubItems.Add(LanguageStrings.AppNotApplicable);

                    if (record.PreBooked)
                        item.ForeColor = Color.DarkGreen;
                    else
                        item.ForeColor = Color.Red;
                }
                else
                {
                    TimeSpan span = DateTime.Now - record.DateStarted;
                    item.SubItems.Add(String.Format(LanguageStrings.AppSicknessTotalDays, Math.Round(span.TotalDays, 2)));
                    item.ForeColor = Color.DarkBlue;
                }

                item.SubItems.Add(record.Certificate ? LanguageStrings.AppNo : LanguageStrings.AppYes);

                if (record.Properties.HasFlag(SickOptions.Cancelled))
                {
                    item.Font = new Font(item.Font, item.Font.Style | FontStyle.Strikeout);
                }

                lvSicknessRecords.Items.Add(item);
            }
        }

        private void pumSickness_Opening(object sender, CancelEventArgs e)
        {
            if (!POS.Base.Classes.AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.BookStaffOffSick))
            {
                pumSicknessCancel.Enabled = false;
                pumSicknessNew.Enabled = false;
                pumSicknessReturnToWork.Enabled = false;
                pumSicknessStatistics.Enabled = false;
                pumSicknessView.Enabled = false;
                return;
            }

            StaffSickRecord record = lvSicknessRecords.SelectedItems.Count > 0 ?
                (StaffSickRecord)lvSicknessRecords.SelectedItems[0].Tag : null;
            pumSicknessView.Enabled = lvSicknessRecords.SelectedItems.Count > 0;

            pumSicknessReturnToWork.Enabled = pumSicknessView.Enabled &&
                record != null &&
                record.DateStarted <= DateTime.Now &&
                !record.Properties.HasFlag(SickOptions.Cancelled) &&
                    record.DateFinished == DateTime.MinValue;
            pumSicknessCancel.Enabled = pumSicknessView.Enabled &&
                record != null &&
                record.DateFinished == DateTime.MinValue &&
                record.PreBooked &&
                !record.Properties.HasFlag(SickOptions.Cancelled);
        }

        private void pumSicknessReturnToWork_Click(object sender, EventArgs e)
        {
            StaffSickRecord record = (StaffSickRecord)lvSicknessRecords.SelectedItems[0].Tag;
            if (Classes.SickLeaveWizard.SickLeaveReturn(CurrentStaffMember.StaffRecord, record))
                LoadStaffSickness();
        }

        private void pumSicknessView_Click(object sender, EventArgs e)
        {
            if (lvSicknessRecords.SelectedItems.Count == 0)
                return;

            ViewSickRecord vsr = new ViewSickRecord((StaffSickRecord)lvSicknessRecords.SelectedItems[0].Tag);
            try
            {
                vsr.ShowDialog(this);
            }
            finally
            {
                vsr.Close();
                vsr.Dispose();
                vsr = null;
            }
        }

        private void pumSicknessNew_Click(object sender, EventArgs e)
        {
            if (Classes.SickLeaveWizard.SickLeaveAdd(CurrentStaffMember.StaffRecord, false, CurrentStaffMember.StaffRecord))
                LoadStaffSickness();
        }

        private void pumSicknessCancel_Click(object sender, EventArgs e)
        {
            if (ShowQuestion(LanguageStrings.AppSicknessCancel, LanguageStrings.AppSicknessCancelQuestion))
            {
                StaffSickRecord record = (StaffSickRecord)lvSicknessRecords.SelectedItems[0].Tag;
                record.Properties = SickOptions.Cancelled;
                record.Save();
            }
        }

        private void pumSicknessStatistics_Click(object sender, EventArgs e)
        {
            string sickStatistics;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                StaffSickRecords sick = StaffSickRecords.All(CurrentStaffMember);
                StaffSicknessStatistics stats = new StaffSicknessStatistics();
                sick.Statistics(ref stats, new DateTime(DateTime.Now.Year,
                    AppController.LocalSettings.LeaveYearStarts.Month, AppController.LocalSettings.LeaveYearStarts.Day,
                    0, 0, 0));

                sickStatistics = String.Format(LanguageStrings.AppSicknessStatistics,
                    Math.Round(stats.TotalDays, 2), stats.TotalTimes, stats.Prebooked, stats.Cancelled, stats.SelfCertified,
                    Math.Round(stats.PreviousTotalDays, 2), stats.PreviousTotalTimes, stats.PreviousPrebooked,
                    stats.PreviousCancelled, stats.PreviousSelfCertified);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

            ShowInformation(LanguageStrings.AppSicknessStatisticsTitle, sickStatistics);
        }

        private void lvSicknessRecords_DoubleClick(object sender, EventArgs e)
        {
            if (lvSicknessRecords.SelectedItems.Count == 0)
                pumSicknessNew_Click(sender, e);
            else
                pumSicknessView_Click(sender, e);
        }

        #endregion Sickness

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string helpTopic = GetHelpTopic();

            AppController.ActiveHelpTopic = helpTopic;
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Brush txt_brush;
            Brush box_brush;
            Pen box_pen;

            // We draw in the TabRect rather than on e.Bounds
            // so we can use TabRect later in MouseDown.
            Rectangle tabHeaderRect = tabStaff.GetTabRect(e.Index);

            // Allow room for margins.
            RectangleF layout_rect = new RectangleF(
                tabHeaderRect.Left + 4,
                tabHeaderRect.Y,
                tabHeaderRect.Width - 15,
                tabHeaderRect.Height);


            Brush tabBrush = e.State == DrawItemState.Selected ? Brushes.LightBlue : Brushes.LightGray;

            e.Graphics.FillRectangle(tabBrush, tabHeaderRect);

            // Draw the background.
            // Pick appropriate pens and brushes.
            if (e.State == DrawItemState.Selected)
            {
#if LINEAR_TAB
                using (LinearGradientBrush aGB = new LinearGradientBrush(tabHeaderRect,
                    Color.LightBlue, Color.DarkBlue, LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(aGB, tabHeaderRect);
                }
#else
                RectangleF headerLineRect = new RectangleF(
                    tabHeaderRect.Left,
                    tabHeaderRect.Top,
                    tabHeaderRect.Width,
                    3);

                e.Graphics.FillRectangle(Brushes.DarkBlue, headerLineRect);
#endif
            }

            txt_brush = Brushes.Black;
            box_brush = Brushes.Silver;
            box_pen = Pens.Black;

            // Draw the tab's text centered.
            e.Graphics.DrawString(
                tabStaff.TabPages[e.Index].Text,
                tabStaff.Font,
                txt_brush,
                layout_rect,
                _tabStringFormat);
        }

        #endregion Private Methods
    }
}
