using System;
using System.Windows.Forms;

using POS.Base.Plugins;
using Languages;
using Library;
using Library.BOL.Staff;
using Library.BOL.Therapists;
using Library.BOL.Users;
using POS.Base.Classes;

namespace POS.Staff.Forms
{
    public partial class StaffRequestLeave : Base.Forms.BaseForm
    {
        #region Constructors

        public StaffRequestLeave()
        {
            InitializeComponent();
            dtpDateFrom.Format = DateTimePickerFormat.Custom;
            dtpDateTo.Format = DateTimePickerFormat.Custom;

            LoadStaffMembers();

            cbApproved.Enabled = POS.Base.Classes.AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.ApproveAllLeave) ||
                POS.Base.Classes.AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.ApproveLeave);
            cbAuthorised.Enabled = POS.Base.Classes.AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.AuthoriseAllLeave) ||
                POS.Base.Classes.AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.AuthoriseLeave);
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.StaffRequestLeave;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppStaffLeaveRequest;

            lblDateFrom.Text = LanguageStrings.AppDateFrom;
            lblDateTo.Text = LanguageStrings.AppDateTo;
            lblStaffMember.Text = LanguageStrings.StaffMember;

            cbFullDay.Text = LanguageStrings.AppFullDay;
            cbApproved.Text = LanguageStrings.AppApproved;
            cbAuthorised.Text = LanguageStrings.AppAuthorised;

            lblNotes.Text = LanguageStrings.Notes;
            lblCalculation.Text = String.Empty;

            dtpDateFrom.CustomFormat = Shared.Utilities.DateFormat(!cbFullDay.Checked, true);
            dtpDateTo.CustomFormat = dtpDateFrom.CustomFormat;
            CalculateTime();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadStaffMembers()
        {
            Users staffMembers = User.StaffMembers(false);
            cmbStaff.Items.Clear();

            foreach (User staff in staffMembers)
            {
                if (staff.MemberLevel == MemberLevel.System)
                    continue;

                if (staff.ID == POS.Base.Classes.AppController.ActiveUser.ID ||
                    POS.Base.Classes.AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.AddLeaveForAllStaff) ||
                    ((staff.Manager != null && staff.Manager.ID == POS.Base.Classes.AppController.ActiveUser.ID)))
                {
                    int idx = cmbStaff.Items.Add(staff);

                    if (staff.ID == POS.Base.Classes.AppController.ActiveUser.ID)
                        cmbStaff.SelectedIndex = idx;
                }
            }
        }

        private void cbFullDay_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateFrom.CustomFormat = Shared.Utilities.DateFormat(!cbFullDay.Checked, true);
            dtpDateTo.CustomFormat = dtpDateFrom.CustomFormat;
            CalculateTime();
        }

        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            User currentSelection = (User)cmbStaff.Items[cmbStaff.SelectedIndex];
            StaffMember staff = currentSelection.StaffRecord;
            lblRemaining.Text = String.Format(LanguageStrings.AppStaffLeaveRemaining,
                staff.LeaveRemaining(), staff.EntitlementType ? LanguageStrings.Hours : LanguageStrings.Days);

            CalculateTime();
        }

        private void cmbStaff_Format(object sender, ListControlConvertEventArgs e)
        {
            User user = (User)e.ListItem;
            e.Value = user.UserName;
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            dtpDateFrom.Value = dtpDateFrom.Value.AddSeconds(-dtpDateFrom.Value.Second);
            dtpDateTo.Value = dtpDateTo.Value.AddSeconds(-dtpDateTo.Value.Second);
            User user = (User)cmbStaff.SelectedItem;
            Therapist ther = Therapist.Get(user.ID);

            decimal remaining = user.StaffRecord.LeaveRemaining();
            //decimal requestedTimeHours;
            double totalHours = HoursRequested(ther);
            double totalDays = DaysRequested(ther);

            if (!user.StaffRecord.EntitlementType) // days
            {
                if ((decimal)totalDays > user.StaffRecord.LeaveRemaining())
                {
                    if (AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.AllowToBookOverQuota))
                    {
                        if (!ShowWarning(LanguageStrings.AppStaffLeaveRequest, String.Format(LanguageStrings.AppStaffLeaveOverQuotaNotEnoughDays, remaining, totalDays)))
                            return;
                    }
                    else
                    {
                        ShowError(LanguageStrings.AppStaffLeaveRequest, String.Format(LanguageStrings.AppStaffLeaveRefusedNotEnoughDays, remaining, totalDays));
                        return;
                    }
                }
            }
            else
            {
                if (totalHours > (double)user.StaffRecord.LeaveRemaining())
                {
                    if (AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.AllowToBookOverQuota))
                    {
                        if (!ShowWarning(LanguageStrings.AppStaffLeaveRequest, String.Format(LanguageStrings.AppStaffLeaveOverQuotaNotEnoughHours, remaining, totalHours)))
                            return;
                    }
                    else
                    {
                        ShowError(LanguageStrings.AppStaffLeaveRequest, String.Format(LanguageStrings.AppStaffLeaveRefusedNotEnoughHours, remaining, totalHours));
                        return;
                    }
                }
            }

            // if the staff member has appointments on the days refuse
            if (ther != null)
            {
                for (DateTime date = dtpDateFrom.Value.AddHours(-dtpDateFrom.Value.Hour); date <= dtpDateTo.Value;)
                {
                    if (ther.HasAppointments(date, true))
                    {
                        ShowError(LanguageStrings.AppStaffLeaveRequest, String.Format(LanguageStrings.AppStaffLeaveRefusedAppointments, date.ToShortDateString()));
                        return;
                    }

                    date = date.AddDays(1);
                }
            }


            // add the request
            StaffLeave.Create(user.ID, DateTime.Now, dtpDateFrom.Value, dtpDateTo.Value,
                user.StaffRecord.EntitlementType ? totalHours : totalDays, 
                cbAuthorised.Checked ? POS.Base.Classes.AppController.ActiveUser.ID : -1,
                cbApproved.Checked ? POS.Base.Classes.AppController.ActiveUser.ID : -1, txtNotes.Text);
            user.StaffRecord.Reload();

            if (!cbAuthorised.Checked)
            {
                ShowInformation(LanguageStrings.AppStaffLeaveRequest, LanguageStrings.AppStaffLeaveRequestRequireAuthorising);
            }
            else if (!cbApproved.Checked)
            {
                ShowInformation(LanguageStrings.AppStaffLeaveRequest, LanguageStrings.AppStaffLeaveRequestRequireApproval);
            }
            else
            {
                ShowInformation(LanguageStrings.AppStaffLeaveRequest, LanguageStrings.AppStaffLeaveRequestApproved);
            }

            POS.Base.Classes.PluginManager.RaiseEvent(new NotificationEventArgs(StringConstants.PLUGIN_EVENT_LEAVE_ADD));
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private double DaysRequested(Therapist ther)
        {
            // get working hours for requested time
            double Result = 0;

            for (DateTime date = dtpDateFrom.Value; date <= dtpDateTo.Value; )
            {
                DateTime startTime = dtpDateFrom.Value.AddSeconds(-dtpDateFrom.Value.Second);
                DateTime finishTime = dtpDateTo.Value.AddSeconds(-dtpDateTo.Value.Second);

                // what are the users working hours for the day?
                int duration = 0;
                double start;
                double finish;
                bool sameDay = dtpDateFrom.Value.Date == dtpDateTo.Value.Date;

                if (ther.WorkingDay(date, out start, out finish, out duration))
                {
                    TimeSpan span = dtpDateTo.Value - dtpDateFrom.Value;
                    double daysHours = (((duration / 15) / 4));

                    Result++;

                    if (!cbFullDay.Checked)
                    {
                        if (date.Date == dtpDateFrom.Value.Date)
                        {
                            //if the request is more than half the working day, minus lunch break, then counted as a full day
                            // if it's less than half the day minus lunch break, then half day
                            double workingHours = (dtpDateFrom.Value.Hour - start) + (((double)dtpDateFrom.Value.Minute)/100);

                            if (sameDay)
                                workingHours += finish - dtpDateTo.Value.Hour;

                            //if ((workingHours >= (daysHours / 2)))
                            //    Result += 1.0;
                            //else 
                                if (workingHours >= (daysHours / 2))
                                    Result -= 0.5;
                        }

                        if (!sameDay && date.Date == dtpDateTo.Value.Date)
                        {
                            //if the request is more than half the working day, minus lunch break, then counted as a full day
                            // if it's less than half the day minus lunch break, then half day
                            double workingHours = (finish - dtpDateTo.Value.Hour);

                            //workingHours += finish - dtpDateTo.Value.Hour;

                            if ((workingHours >= (daysHours / 2)))
                                Result -= 0.5;
                            //else if (workingHours < (daysHours / 2))
                            //    Result += 1.0;
                        }
                    }
                }

                date = date.AddDays(1);
            }

            return (Result);
        }

        private double HoursRequested(Therapist ther)
        {
            // get working hours for requested time
            double Result = 0;

            for (DateTime date = dtpDateFrom.Value.Date; date <= dtpDateTo.Value.Date; )
            {
                DateTime startTime = dtpDateFrom.Value.AddSeconds(-dtpDateFrom.Value.Second);
                DateTime finishTime = dtpDateTo.Value.AddSeconds(-dtpDateTo.Value.Second);
                int duration = 0;
                double start;
                double finish;
                bool sameDay = dtpDateFrom.Value.Date == dtpDateTo.Value.Date;

                if (ther.WorkingDay(date, out start, out finish, out duration))
                    Result += (finish - start);

                if (!cbFullDay.Checked)
                {
                    if (dtpDateFrom.Value.Date == dtpDateTo.Value.Date)
                    {
                        TimeSpan span = dtpDateTo.Value - dtpDateFrom.Value;

                        Result = (((int)(span.TotalMinutes) / 15)) * .25;

                        if (Math.Truncate(Result) > 0.00)
                            Result += .25;

                        return (Result);
                    }
                    else
                    {
                        if (date.Date == dtpDateFrom.Value.Date)
                        {
                            //remove hours from start of day to request leave time
                            Result -= (dtpDateFrom.Value.Hour - start);

                            if (dtpDateFrom.Value.Minute > 0)
                            {
                                Result -= ((dtpDateFrom.Value.Minute / 15) * .25);
                            }
                        }

                        if (date.Date == dtpDateTo.Value.Date)
                        {
                            Result -= (finish - dtpDateTo.Value.Hour);

                            if (dtpDateTo.Value.Minute > 0)
                            {
                                Result -= ((dtpDateTo.Value.Minute / 15) * .25);
                            }
                        }
                    }
                }

                date = date.AddDays(1);
            }

            return (Result);
        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpDateFrom.ValueChanged -= dtpDateFrom_ValueChanged;
            try
            {
                if (dtpDateTo.Value.Date < dtpDateFrom.Value.Date)
                    dtpDateTo.Value = dtpDateFrom.Value;

                dtpDateTo.MinDate = dtpDateFrom.Value.AddMinutes(30);

                User user = (User)cmbStaff.SelectedItem;
                Therapist ther = Therapist.Get(user.ID);
                int duration = 0;
                double start;
                double finish;

                if (ther.WorkingDay(dtpDateFrom.Value, out start, out finish, out duration))
                {
                    if (Shared.Utilities.TimeToDouble(dtpDateFrom.Value) > finish)
                        dtpDateFrom.Value = Shared.Utilities.DoubleToDate(dtpDateFrom.Value.Date, finish);
                    else if (dtpDateFrom.Value.Hour < start)
                        dtpDateFrom.Value = Shared.Utilities.DoubleToDate(dtpDateFrom.Value.Date, start);
                }
            }
            finally
            {
                dtpDateFrom.ValueChanged += dtpDateFrom_ValueChanged;
            }

            CalculateTime();
        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            dtpDateTo.ValueChanged -= dtpDateTo_ValueChanged;
            try
            {
                User user = (User)cmbStaff.SelectedItem;
                Therapist ther = Therapist.Get(user.ID);
                int duration = 0;
                double start;
                double finish;

                if (ther.WorkingDay(dtpDateTo.Value, out start, out finish, out duration))
                {
                    if (Shared.Utilities.TimeToDouble(dtpDateTo.Value) > finish)
                    {
                        UpdateDateTimePicker(dtpDateTo, Shared.Utilities.DoubleToDate(dtpDateTo.Value.Date, finish));
                    }
                    else if (dtpDateTo.Value.Hour < start)
                    {
                        UpdateDateTimePicker(dtpDateTo, Shared.Utilities.DoubleToDate(dtpDateTo.Value.Date, start));
                    }
                }
            }
            finally
            {
                dtpDateTo.ValueChanged += dtpDateTo_ValueChanged;
            }

            CalculateTime();
        }

        private void UpdateDateTimePicker(DateTimePicker picker, DateTime dateTime)
        {
            if (dateTime < picker.MinDate)
                picker.Value = picker.MinDate;
            else if (dateTime > picker.MaxDate)
                picker.Value = picker.MaxDate;
            else
                picker.Value = dateTime;
        }

        private void CalculateTime()
        {
            dtpDateFrom.Value = dtpDateFrom.Value.AddSeconds(-dtpDateFrom.Value.Second);
            dtpDateTo.Value = dtpDateTo.Value.AddSeconds(-dtpDateTo.Value.Second);
            User user = (User)cmbStaff.SelectedItem;
            Therapist ther = Therapist.Get(user.ID);

            if (user.StaffRecord.EntitlementType)
            {
                // user calculates in hours
                lblCalculation.Text = String.Format(LanguageStrings.AppStaffLeaveHours, HoursRequested(ther));
            }
            else
            {
                // user calculates in days
                double days = DaysRequested(ther);

                if (days > 1.0)
                    lblCalculation.Text = String.Format(LanguageStrings.AppStaffLeaveDays, days);
                else
                    lblCalculation.Text = String.Format(LanguageStrings.AppStaffLeaveDay, days);
            }
        }

        #endregion Private Methods
    }
}
