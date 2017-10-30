using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library.BOL.Appointments;
using Library.BOL.Users;
using Library.BOL.Therapists;
using Library.Utils;
using Library;

using POS.Base.Classes;
using POS.Base.Forms;

using POS.Diary.Forms;
using POS.Diary.Controls;

namespace POS.Diary.Forms
{
    public partial class CalendarAppointment : BaseForm
    {
        #region Private Members

        private User _User;
        private User _Customer;
        private Therapist _Therapist;
        private Appointment _Appointment;
        private DateTime _Date;

        private bool _clearAll = false;

        #endregion Private Members

        #region Constructors

        public CalendarAppointment()
        {
            InitializeComponent();
        }

        public CalendarAppointment(User user, Therapist therapist, Appointment appointment, DateTime date, bool IsLocked)
            : this()
        {
            _User = user;
            _Therapist = therapist;
            _Appointment = appointment;
            _Date = date;

            ConfirmTherapistCanCompleteTreatments(therapist, appointment);

            monthCalendar1.SelectionStart = date;
            LoadTherapists();
            LoadStatuses();
            LoadDurations(840);
            LoadAppointmentTypes();

            if (_Appointment == null)
            {
                //new
                cmbAppointmentType.SelectedIndex = 0;
                
                cmbStatus.SelectedIndex = 1;
            }
            else
            {
                //existing appointment
                //Therapist therapists = Therapists.Get(_Appointment.EmployeeID);
                LoadTherapistTimes(User.UserGet(_Appointment.EmployeeID));
                cmbDuration.SelectedItem = _Appointment.Duration;
                SetAppointmentType(_Appointment.AppointmentType);

                //load current appointments
                AppointmentTreatment treat = AppointmentTreatments.Get(_Appointment.TreatmentID);

                if (treat != null)
                {
                    SalonAppointment newAppt = new SalonAppointment(treat, _Therapist, _Date, appointment.StartTime, !IsLocked, _Appointment);
                    newAppt.Delete += new SalonAppointment.DeleteAppointmentHandler(newAppt_Delete);
                    flowLayoutTreatments.Controls.Add(newAppt);

                    foreach (Appointment childAppt in appointment.ChildAppointments)
                    {
                        if (childAppt.Status != Enums.AppointmentStatus.Deleted && childAppt.Status != Enums.AppointmentStatus.CancelledByStaff)
                        {
                            SalonAppointment newChildAppt = new SalonAppointment(AppointmentTreatments.Get(childAppt.TreatmentID), childAppt.Therapist, _Date, childAppt.StartTime, !IsLocked, childAppt);
                            newChildAppt.Delete += new SalonAppointment.DeleteAppointmentHandler(newAppt_Delete);
                            flowLayoutTreatments.Controls.Add(newChildAppt);
                        }
                    }
                }

                cmbStartTime.SelectedItem = _Appointment.StartTime;
                _Customer = User.UserGet(_Appointment.UserID);
                txtCustomer.Text = _Customer.UserName;
                txtNotes.Text = _Appointment.Notes;

                foreach (AppointmentStatus stat in cmbStatus.Items)
                {
                    if (stat.ID == (int)_Appointment.Status)
                    {
                        cmbStatus.SelectedItem = stat;
                        break;
                    }
                }
            }

            btnSave.Enabled = !IsLocked;
            btnHistory.Enabled = _Customer != null;
            btnFindCustomer.Enabled = !IsLocked;
            btnAddTreatments.Enabled = !IsLocked;
            btnClearAll.Enabled = !IsLocked;
            txtCustomer.Enabled = !IsLocked;
            cmbAppointmentType.Enabled = !IsLocked;
            cmbDuration.Enabled = !IsLocked && cmbAppointmentType.SelectedIndex != 0;
            cmbStartTime.Enabled = !IsLocked;
            cmbStatus.Enabled = !IsLocked;
            txtNotes.Enabled = !IsLocked;
            monthCalendar1.Enabled = !IsLocked;
            cmbTreatments.Enabled = !IsLocked;

            AppController.ApplicationController.AppointmentIDChanged += User_AppointmentIDChanged;
            AppController.ApplicationController.UserIDChanged += User_UserIDChanged;
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.DiaryApptEdit;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = String.Format(LanguageStrings.AppDiaryApptCreateEdit, 
                _Appointment == null ? LanguageStrings.AppNew : LanguageStrings.AppEdit);

            lblAppointmentType.Text = LanguageStrings.AppDiaryApptType;
            lblCustomer.Text = LanguageStrings.AppCustomer;
            lblDuration.Text = LanguageStrings.AppDiaryDuration;
            lblNotes.Text = LanguageStrings.AppNotes;
            lblStartTime.Text = LanguageStrings.AppDiaryStartTime;
            lblStatus.Text = LanguageStrings.AppDiaryStatus;
            lblTreatments.Text = LanguageStrings.AppDiaryTreatments;

            btnAddTreatments.Text = LanguageStrings.AppMenuButtonAddTreatments;
            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnClearAll.Text = LanguageStrings.AppMenuButtonClearAll;
            btnFindCustomer.Text = LanguageStrings.AppMenuButtonFindCustomer;
            btnHistory.Text = LanguageStrings.AppMenuButtonHistory;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void User_UserIDChanged(object sender, AppController.IDChangedEventArgs e)
        {
            if (_Customer != null)
                if (_Customer.ID == e.OldID)
                    _Customer = User.UserGet(e.NewID);
        }

        private void User_AppointmentIDChanged(object sender, AppController.IDChangedEventArgs e)
        {
            if (_Appointment.ID == e.OldID)
                _Appointment.ID = e.NewID;

            //child appointments
            if (_Appointment.ChildAppointments.Count > 0)
            {
                foreach (Appointment child in _Appointment.ChildAppointments)
                {
                    if (child.ID == e.OldID)
                    {
                        child.ID = e.NewID;
                        break;
                    }
                }
            }

        }

        private void newAppt_Delete(object sender, EventArgs e)
        {
            if (!_clearAll && sender == flowLayoutTreatments.Controls[0])
            {
                ShowInformation(LanguageStrings.AppDiaryApptRemove, LanguageStrings.AppDiaryApptRemoveDescription);
                return;
            }

            //do not actually delete the child appointment, instead change to cancelled
            foreach (SalonAppointment appt in flowLayoutTreatments.Controls)
            {
                if (appt == (SalonAppointment)sender)
                {
                    if (appt.Appointment != null)
                    {
                        appt.Appointment.Status = Enums.AppointmentStatus.Deleted;
                        appt.Appointment.Save(AppController.ActiveUser);
                    }

                    if (!_clearAll)
                        flowLayoutTreatments.Controls.Remove(appt);

                    break;
                }
            }
        }

        private void LoadTherapists()
        {
            if (_Therapist == null)
            {
                User employee = User.UserGet(_Appointment.EmployeeID);

                if (employee != null)
                    ShowWarning(LanguageStrings.AppDiaryEmployeeNotFound,
                        String.Format(LanguageStrings.AppDiaryEmployeeNotFoundDescription, employee.UserName), false);
            }
            else
            {
                LoadTherapistTimes(User.UserGet(_Therapist.EmployeeID));
                LoadTherapistTreatments(_Therapist);
            }
        }

        private void LoadTherapistTreatments(Therapist therapist)
        {
            cmbTreatments.ValueMember = StringConstants.DATA_SOURCE_COLUMN_ID;
            cmbTreatments.DisplayMember = StringConstants.DATA_SOURCE_COLUMN_NAME;
            cmbTreatments.DataSource = therapist.Treatments;
        }

        private void ConfirmTherapistCanCompleteTreatments(Therapist therapist, Appointment appointment)
        {
            if (therapist == null | appointment == null)
                return;

            AppointmentTreatment treatment = AppointmentTreatments.Get(appointment.TreatmentID);

            if (appointment.AppointmentType == 0 && treatment == null)
            {
                ShowError(LanguageStrings.AppDiaryTreatmentInvalid, 
                    String.Format(LanguageStrings.AppDiaryTreatmentInvalidDescription, 
                    appointment.TreatmentName));
            }

            // is the therapist allowed to do this treatment?
            if (treatment != null && !therapist.Treatments.Available(treatment))
            {
                try
                {
                    therapist.Treatments.Add(treatment);
                    treatment.Add(therapist);
                }
                catch (Exception err)
                {
                    if (!err.Message.Contains(StringConstants.ERROR_STORE_DUPLICATE))
                        throw;
                }
            }

            foreach (Appointment child in appointment.ChildAppointments)
            {
                treatment = AppointmentTreatments.Get(child.TreatmentID);

                if (child.AppointmentType == 0 && treatment == null)
                    ShowError(LanguageStrings.AppDiaryTreatmentInvalid, 
                        String.Format(LanguageStrings.AppDiaryTreatmentInvalidDescription, 
                        appointment.TreatmentName));

                if (treatment != null && !therapist.Treatments.Available(treatment))
                {
                    try
                    {
                        therapist.Treatments.Add(treatment);
                        treatment.Add(therapist);
                    }
                    catch (Exception err)
                    {
                        if (!err.Message.Contains(StringConstants.ERROR_STORE_DUPLICATE))
                            throw;
                    }
                }
            }
        }

        private void LoadStatuses()
        {
            cmbStatus.Items.Clear();
            AppointmentStatuses stats = AppointmentStatuses.Get();
            bool CancelAppointments = AppController.ActiveUser.HasPermissionCalendar(
                SecurityEnums.SecurityPermissionsCalendar.CancelAppointments);

            foreach (AppointmentStatus stat in stats)
            {
                switch (stat.ID)
                {
                    case 4:
                    case 5:
                        if (CancelAppointments) // can the user cancel appointments
                            cmbStatus.Items.Add(stat);

                        break;
                    case 8: // sick can only be done via the staff sick wizard from 30/06/17
                        break;
                    default:
                        cmbStatus.Items.Add(stat);
                        break;
                }
            }
        }

        private void LoadTherapistTimes(User user)
        {
            Therapist therapist = Therapist.Get(user.ID);

            if (therapist == null)
                return;

            cmbStartTime.Items.Clear();

            //todo look at overriden working days
            for (Double t = 8.0; t <= 21.75; t = t + 0.25)
            {
                int idx = cmbStartTime.Items.Add(t);

                if (Shared.Utilities.TimeToDouble(_Date.ToString(StringConstants.SYMBOL_DATE_FORMAT_T)) == t)
                    cmbStartTime.SelectedIndex = idx;
            }
        }

        private void LoadDurations(int MaxDuration)
        {
            cmbDuration.Items.Clear();

            int i = 15;

            while (i < MaxDuration)
            {
                int idx = cmbDuration.Items.Add(i);

                if (_Appointment != null)
                    if (_Appointment.Duration == i)
                        cmbDuration.SelectedIndex = idx;

                i += 15;
            }
        }

        private void LoadTherapistTreatments()
        {
            cmbTreatments.ValueMember = StringConstants.DATA_SOURCE_COLUMN_ID;
            cmbTreatments.DisplayMember = StringConstants.DATA_SOURCE_COLUMN_NAME;
            cmbTreatments.DataSource = _Therapist.Treatments;
        }

        private void LoadAppointmentTypes()
        {
            cmbAppointmentType.Items.Clear();
            AppointmentTypes apptTypes = AppointmentTypes.Get();
            bool ManageTimeOff = AppController.ActiveUser.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.ManageStaffTimeOff);

            foreach (AppointmentType type in apptTypes)
            {
                switch (type.ID)
                {
                    case 0: //salon treatments
                        if (_Therapist != null && _Therapist.HasTreatments)
                            cmbAppointmentType.Items.Add(type);

                        break;
                    case 2:
                    case 6:
                    case 7:
                    case 12:
                        if (ManageTimeOff)
                            cmbAppointmentType.Items.Add(type);

                        break;
                    case 14:
                        // do not add this one
                        break;
                    default:
                        //only add beauty treatments if the therapist has treatments listed
                        cmbAppointmentType.Items.Add(type);

                        break;
                }
            }
        }

        private void SetAppointmentType(int AppointmentType)
        {
            foreach (AppointmentType obj in cmbAppointmentType.Items)
            {
                if (obj.ID == AppointmentType)
                {
                    cmbAppointmentType.SelectedItem = obj;
                    break;
                }
            }
        }

        private void cmbTherapist_Format(object sender, ListControlConvertEventArgs e)
        {
            Therapist therapist = (Therapist)e.ListItem;
            e.Value = therapist.EmployeeName;
        }

        private void cmbAppointmentType_Format(object sender, ListControlConvertEventArgs e)
        {
            AppointmentType type = (AppointmentType)e.ListItem;
            e.Value = type.Description;
        }

        private void cmbDuration_Format(object sender, ListControlConvertEventArgs e)
        {
            int i = (int)e.ListItem;

            int h = i / 60;
            int m = (i - (h * 60));

            string duration;

            switch (h)
            {
                case 0:
                    duration = String.Format(LanguageStrings.AppDiaryLunchMins, m);
                    break;
                case 1:
                    if (m == 0)
                        duration = LanguageStrings.AppDiaryLunch1Hour;
                    else
                        duration = String.Format(LanguageStrings.AppDiaryLunch1HourMins, m);
                    break;
                default:
                    if (m == 0)
                        duration = String.Format(LanguageStrings.AppDiaryLunchHours, h);
                    else
                        duration = String.Format(LanguageStrings.AppDiaryLunchHoursMins, h, m);
                    break;
            }

            e.Value = duration;
        }

        private void cmbStartTime_Format(object sender, ListControlConvertEventArgs e)
        {
            double t = (double)e.ListItem;
            e.Value = Shared.Utilities.DoubleToTime(t);
        }

        private void cmbAppointmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutTreatments.Visible = cmbAppointmentType.SelectedIndex == 0;
            btnAddTreatments.Visible = cmbAppointmentType.SelectedIndex == 0;
            cmbDuration.Enabled = cmbAppointmentType.SelectedIndex != 0;
            lblTreatments.Visible = cmbAppointmentType.SelectedIndex == 0;
            cmbTreatments.Visible = cmbAppointmentType.SelectedIndex == 0;
            btnClearAll.Visible = cmbAppointmentType.SelectedIndex == 0;

            if (cmbAppointmentType.SelectedIndex == 1)
                LoadDurations(195);
            else
                LoadDurations(840);
        }

        private void cmbTreatment_Format(object sender, ListControlConvertEventArgs e)
        {
            AppointmentTreatment treat = (AppointmentTreatment)e.ListItem;
            e.Value = treat.Name;
        }

        private void cmbStatus_Format(object sender, ListControlConvertEventArgs e)
        {
            AppointmentStatus stat = (AppointmentStatus)e.ListItem;
            e.Value = stat.Description;
        }

        private Therapist GetAppointmentTherapist(int Index)
        {
            SalonAppointment salonAppt = (SalonAppointment)flowLayoutTreatments.Controls[Index];
            return (salonAppt.Therapist);
        }

        private double GetAppointmentStartTime(int Index)
        {
            SalonAppointment salonAppt = (SalonAppointment)flowLayoutTreatments.Controls[Index];
            return (salonAppt.StartTime);
        }

        private Appointment GetAppointment(int Index)
        {
            SalonAppointment salonAppt = (SalonAppointment)flowLayoutTreatments.Controls[Index];
            return (salonAppt.Appointment);
        }

        private AppointmentTreatment GetAppointmentTreatment(int Index)
        {
            SalonAppointment salonAppt = (SalonAppointment)flowLayoutTreatments.Controls[Index];
            return (salonAppt.Treatment);
        }

        private int GetAppointmentCount()
        {
            return (flowLayoutTreatments.Controls.Count);
        }

        private AppointmentTreatment GetFirstAppointment()
        {
            AppointmentTreatment Result = null;

            if (flowLayoutTreatments.Controls.Count > 0)
            {
                SalonAppointment salonAppt = (SalonAppointment)flowLayoutTreatments.Controls[0];
                Result = salonAppt.Treatment;
            }

            return (Result);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAppointmentType.SelectedIndex == -1)
                {
                    ShowError(LanguageStrings.AppDiaryApptType, LanguageStrings.AppDiaryApptTypeSelect);
                    cmbAppointmentType.DroppedDown = true;
                    return;
                }

                AppointmentType type = (AppointmentType)cmbAppointmentType.SelectedItem;

                if (type.ID == 0 && flowLayoutTreatments.Controls.Count < 1)
                {
                    ShowError(LanguageStrings.AppDiaryTreatments, LanguageStrings.AppDiaryApptMustHave1Treatment);
                    return;
                }

                AppointmentTreatment treat = GetFirstAppointment();

                if (type.ID == 0 && !_Therapist.AllowTreatments(monthCalendar1.SelectionStart))
                {
                    ShowError(LanguageStrings.AppDiaryTreatments, LanguageStrings.AppDiaryStaffNowWorking);
                    return;
                }

                int apptType = type.ID;

                if (treat == null || apptType != 0)
                {
                    if (_Customer == null)
                        _Customer = User.UserGet(_Therapist.EmployeeID);
                }

                if (_Customer == null)
                {
                    if (ShowHardConfirm(LanguageStrings.AppSelectCustomer, LanguageStrings.AppSelectCustomerDescription))
                        btnFindCustomer_Click(this, e);
                    return;
                }

                if (apptType == 0 && treat == null)
                {
                    ShowError(LanguageStrings.AppDiaryTreatment, LanguageStrings.AppDiaryTreatmentSelect);
                    return;
                }

                int duration;

                if (apptType == 0)
                {
                    duration = treat.Duration;

                    // store credit card details for appointments with a treatment duration more than xx minutes, as
                    // specified in user settings, if the dialog is cancelled then return to the main return out of this screen
                    if (duration > AppController.LocalSettings.CreditCardAppointmentMinutes)
                    {
                        if (!Forms.CreditCardDetails.UserHasCreditCardDetails(_Customer))
                        {
                            ShowError(LanguageStrings.AppDiaryCard, LanguageStrings.AppDiaryCardRequired);
                            return;
                        }
                    }
                }
                else
                {
                    if (cmbDuration.SelectedItem == null)
                    {
                        ShowError(LanguageStrings.AppDiaryDuration, LanguageStrings.AppDiaryDurationSelect);
                        cmbDuration.DroppedDown = true;
                        return;
                    }

                    duration = (int)cmbDuration.SelectedItem;
                }

                if (apptType == 1)
                {
                    if (duration > AppController.LocalSettings.DiaryMaximumLunchDuration)
                    {
                        ShowError(LanguageStrings.AppDiaryDuration, LanguageStrings.AppDiaryDurationExceedsAdmin);
                        duration = AppController.LocalSettings.DiaryMaximumLunchDuration;
                    }
                }

                AppointmentStatus status = (AppointmentStatus)cmbStatus.SelectedItem;

                if (status == null)
                {
                    ShowError(LanguageStrings.AppDiaryStatus, LanguageStrings.AppDiaryStatusSelect);
                    cmbStatus.DroppedDown = true;
                    return;
                }

                double starttime = 9.00;

                if (apptType == 0)
                {
                    starttime = GetAppointmentStartTime(0);

                    if (starttime == 0.0)
                        starttime = (double)cmbStartTime.SelectedItem;
                }
                else
                {
                    if (cmbStartTime.SelectedIndex == -1)
                    {
                        ShowError(LanguageStrings.AppDiaryStartTime, LanguageStrings.AppDiaryStartTimeRequired);
                        cmbStartTime.DroppedDown = true;
                        return;
                    }

                    starttime = (double)cmbStartTime.SelectedItem;
                }


                // is the maximum_available reached for date/time for this appointment
                if (type.ID == 0 && !Appointments.IsMaximumAllowed(treat, monthCalendar1.SelectionStart, starttime))
                {
                    ShowError(LanguageStrings.AppDiaryMaxAllowed, LanguageStrings.AppDiaryMaxAllowedDescription);
                    return;
                }

                double NewStart;

                if (_Appointment == null)
                {
                    //new
                    _Appointment = new Appointment(-1, apptType == 0 ? GetAppointmentTherapist(0).EmployeeID : _Therapist.EmployeeID, 
                        monthCalendar1.SelectionStart, starttime, duration,
                        (Enums.AppointmentStatus)status.ID, apptType, treat == null ? 0 : treat.ID, 
                        treat == null ? LanguageStrings.AppUnknown : treat.Name,
                        _Customer.ID, _Customer.UserName, txtNotes.Text, -1, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));
                    _Appointment.ID = Appointments.Create(_Appointment, AppController.ActiveUser);

                    NewStart = _Appointment.StartTime + ((_Appointment.Duration / 15) * .25);

                    for (int i = 1; i < GetAppointmentCount(); i++)
                    {
                        AppointmentTreatment childTreat = GetAppointmentTreatment(i);

                        if (_Appointment != null && childTreat.ID != _Appointment.TreatmentID)
                        {
                            //does the appointment already exist?
                            Appointment newChild = GetAppointment(i);

                            if (newChild == null)
                            {
                                newChild = new Appointment(-1, GetAppointmentTherapist(i).EmployeeID, _Appointment.AppointmentDate,
                                    GetAppointmentStartTime(i) == 0.0 ? NewStart : GetAppointmentStartTime(i),
                                    childTreat.Duration, _Appointment.Status, _Appointment.AppointmentType, childTreat.ID, childTreat.Name,
                                    _Appointment.UserID, _Appointment.UserName, String.Empty, _Appointment.ID, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));

                                newChild.ID = Appointments.Create(newChild, AppController.ActiveUser);
                            }
                            else
                            {
                                newChild.TreatmentID = childTreat.ID;
                                newChild.TreatmentName = childTreat.Name;
                                newChild.StartTime = GetAppointmentStartTime(i) == 0.0 ? NewStart : GetAppointmentStartTime(i);
                                newChild.EmployeeID = GetAppointmentTherapist(i).EmployeeID;
                            }

                            NewStart = newChild.StartTime + ((newChild.Duration / 15) * .25);
                        }
                    }

                }
                else
                {
                    //update
                    _Appointment.Status = (Enums.AppointmentStatus)status.ID;
                    _Appointment.EmployeeID = apptType == 0 ? GetAppointmentTherapist(0).EmployeeID : _Therapist.EmployeeID;


                    if (apptType == 0) //salon treatment
                        _Appointment.StartTime = GetAppointmentStartTime(0) == 0.0 ? starttime : GetAppointmentStartTime(0);
                    else
                        _Appointment.StartTime = starttime;

                    _Appointment.AppointmentDate = monthCalendar1.SelectionStart;
                    _Appointment.TreatmentID = treat == null ? 0 : treat.ID;
                    _Appointment.TreatmentName = treat == null ? String.Empty : treat.Name;
                    _Appointment.UserID = _Customer.ID;
                    _Appointment.UserName = _Customer.UserName;
                    _Appointment.Duration = duration;
                    _Appointment.AppointmentType = apptType;
                    _Appointment.MasterAppointment = -1;
                    _Appointment.Notes = txtNotes.Text;


                    NewStart = _Appointment.StartTime + ((_Appointment.Duration / 15) * .25);

                    for (int i = 1; i < GetAppointmentCount(); i++)
                    {
                        AppointmentTreatment childTreat = GetAppointmentTreatment(i);

                        if (_Appointment != null && childTreat.ID != _Appointment.TreatmentID)
                        {
                            Appointment newChild = GetAppointment(i);

                            if (newChild == null)
                            {
                                newChild = new Appointment(-1, GetAppointmentTherapist(i).EmployeeID, _Appointment.AppointmentDate,
                                    GetAppointmentStartTime(i) == 0.0 ? NewStart : GetAppointmentStartTime(i),
                                    childTreat.Duration, _Appointment.Status, _Appointment.AppointmentType, childTreat.ID, childTreat.Name,
                                    _Appointment.UserID, _Appointment.UserName, String.Empty, _Appointment.ID, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));

                                newChild.ID = Appointments.Create(newChild, AppController.ActiveUser);

                            }
                            else
                            {
                                newChild.TreatmentID = childTreat.ID;
                                newChild.TreatmentName = childTreat.Name;
                                newChild.StartTime = GetAppointmentStartTime(i) == 0.0 ? NewStart : GetAppointmentStartTime(i);
                                newChild.EmployeeID = GetAppointmentTherapist(i).EmployeeID;
                                newChild.Status = _Appointment.Status;
                            }

                            NewStart = newChild.StartTime + ((newChild.Duration / 15) * .25);

                        }
                    }

                    _Appointment.Save(AppController.ActiveUser);
                }

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception error)
            {

                if (error.Message.Contains(StringConstants.ERROR_APPOINTMENT_NOT_FOUND))
                {
                    ShowError(LanguageStrings.AppDiaryApptErrorSave, LanguageStrings.AppDiaryApptUpdateFailedNew);
                }
                else if (error.Message.Contains(StringConstants.ERROR_FOREIGN_KEY_NOT_EXIST))
                {
                    ShowError(LanguageStrings.AppDiaryApptErrorSave, LanguageStrings.AppDiaryApptUpdateFailedNew);
                }
                else
                {
                    Library.ErrorHandling.LogError(MethodBase.GetCurrentMethod(), error, sender, e);
                    throw;
                }
            }
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            SelectUser selUser = new SelectUser(false);
            try
            {
                selUser.ShowDialog(this);
                _Customer = selUser.SelectedUser;

                if (_Customer != null)
                {
                    txtCustomer.Text = _Customer.UserName;

                    AppointmentHistory history = _Customer.History;

                    if (history.HasHistory() && history.CancelledOrNoShow())
                    {
                        AppointmentHistoryForm frm = new AppointmentHistoryForm(_Customer);
                        frm.ShowDialog(this);
                    }

                    btnHistory.Enabled = true;
                }
            }
            finally
            {
                selUser.Dispose();
                selUser = null;
            }
        }

        private void lstTreatments_Format(object sender, ListControlConvertEventArgs e)
        {
            AppointmentTreatment treat = (AppointmentTreatment)e.ListItem;
            e.Value = treat.Name;
        }

        private void lstTreatments_SelectedValueChanged(object sender, EventArgs e)
        {
            AppointmentTreatment treat = GetFirstAppointment();

            if (treat != null)
                cmbDuration.SelectedIndex = cmbDuration.Items.IndexOf(treat.Duration);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (_Customer != null)
            {
                AppointmentHistoryForm frm = new AppointmentHistoryForm(_Customer);
                try
                {
                    frm.ShowDialog(this);
                }
                finally
                {
                    frm.Dispose();
                    frm = null;
                }
            }
            else
            {
                ShowError(LanguageStrings.AppDiaryViewHistory, LanguageStrings.AppSelectCustomerDescription);
            }
        }

        private void btnAddTreatments_Click(object sender, EventArgs e)
        {
            AppointmentTreatments current = new AppointmentTreatments();

            foreach (SalonAppointment sAppt in flowLayoutTreatments.Controls)
                if (sAppt.Treatment != null)
                    current.Add(sAppt.Treatment);

            SelectTreatmentsForm treats = new SelectTreatmentsForm(_Therapist, _Customer, current);
            try
            {
                if (treats.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //load the appointments
                    flowLayoutTreatments.Controls.Clear();
                    int count = 0;

                    foreach (AppointmentTreatment treat in current)
                    {
                        SalonAppointment newAppt = new SalonAppointment(treat, _Therapist,
                            _Date, count > 0 ? 0.0 : Shared.Utilities.TimeToDouble(
                            _Date.ToString(StringConstants.SYMBOL_DATE_FORMAT_T)), btnSave.Enabled, null);
                        newAppt.Delete += new SalonAppointment.DeleteAppointmentHandler(newAppt_Delete);
                        flowLayoutTreatments.Controls.Add(newAppt);
                        ++count;
                    }

                    SalonAppointment First = (SalonAppointment)flowLayoutTreatments.Controls[0];

                    if (First == null || First.Treatment == null)
                        cmbDuration.SelectedIndex = -1;
                    else
                        cmbDuration.SelectedItem = First.Treatment.Duration;
                }
            }
            finally
            {
                treats.Dispose();
                treats = null;
            }
        }

        private void cmbTreatments_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (cmbTreatments.SelectedItem != null)
                {
                    e.Handled = true;
                }
            }
        }

        private void cmbTreatments_Format(object sender, ListControlConvertEventArgs e)
        {
            AppointmentTreatment treat = (AppointmentTreatment)e.ListItem;
            e.Value = treat.Name;
        }

        private void cmbTreatments_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        private void cmbTreatments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTreatments.Focused)
            {
                AppointmentTreatment treat = _Therapist.Treatments.Find(cmbTreatments.Text);

                if (treat != null)
                {
                    SalonAppointment newAppt = new SalonAppointment(treat, _Therapist,
                        _Date, GetFirstAppointment() == null ? Shared.Utilities.TimeToDouble(_Date.ToString(StringConstants.SYMBOL_DATE_FORMAT_T)) : 0.0, btnSave.Enabled, null);
                    newAppt.Delete += new SalonAppointment.DeleteAppointmentHandler(newAppt_Delete);
                    flowLayoutTreatments.Controls.Add(newAppt);
                    cmbTreatments.Text = String.Empty;
                }
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            _clearAll = true;
            try
            {
                foreach (SalonAppointment sAppt in flowLayoutTreatments.Controls)
                    if (sAppt.Treatment != null)
                        sAppt.DeleteAppointment();

                flowLayoutTreatments.Controls.Clear();
            }
            finally
            {
                _clearAll = false;
            }
        }

        #endregion Private Methods
    }
}
