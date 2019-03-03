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
 *  File: TrainingDiary.cs
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
using System.Threading;
using System.Text;
using System.Windows.Forms;

using Calendar;

using SharedBase;
using SharedBase.Utils;
using SharedBase.BOL.Users;
using SharedBase.BOL.Appointments;
using SharedBase.BOL.Therapists;
using SharedBase.BOL.Basket;
using SharedBase.BOL.Products;
using SharedBase.BOL.Orders;
using SharedBase.BOL.Invoices;
using SharedBase.BOL.Countries;
using SharedBase.BOL.StockControl;
using SharedBase.BOLEvents;

using Languages;

using SalonDiary.Classes;
using SharedControls;


namespace SalonDiary.Controls
{
    public partial class TrainingDiary : BaseControl
    {
        #region Private / Protected Members

        private User _user;
        private DateTime _selectedDate;
        private bool _isLoading = true;
        private bool _weekStartsMonday;
        private int _appointmentLockTime = 30;
        private int _scrollAmount;
        private DateTime _mimimumDate;
        private int _lastMinuteCheck;

        private Color _appointmentSelected = Color.Aqua;
        private Color _appointmentSelectedText = Color.Black;
        private Color _appointmentRequested = ColorTranslator.FromHtml("#0099CC");
        private Color _appointmentRequestedText = Color.Black;
        private Color _appointmentConfirmed = ColorTranslator.FromHtml("#66FF66");
        private Color _appointmentConfirmedText = Color.Black;
        private Color _appointmentCancelledByUser = ColorTranslator.FromHtml("#CC0066");
        private Color _appointmentCancelledByUserText = System.Drawing.Color.White;
        private Color _appointmentCancelledByStaff = ColorTranslator.FromHtml("#CC0066");
        private Color _appointmentCancelledbyStaffText = System.Drawing.Color.Black;
        private Color _appointmentNoShow = ColorTranslator.FromHtml("#FF00FF");
        private Color _appointmentNoShowText = Color.Black;
        private Color _appointmentCompleted = ColorTranslator.FromHtml("#FF9966");
        private Color _appointmentCompletedText = Color.Black;
        private Color _appointmentArrived = ColorTranslator.FromHtml("#FF9900");
        private Color _appointmentArrivedText = Color.Black;

        #region Calendar


        private CalendarStyle _style;

        private List<Calendar.Appointment> m_Appointments;

        private Appointments _allAppointments;

        private Int64 _topID;
        private DateTime _lastUpdateChecked;

        #endregion Calendar

        #endregion Private / Protected Members

        #region Constructors

        public TrainingDiary()
        {
            _lastMinuteCheck = DateTime.Now.Minute;
            InitializeComponent();
            _lastUpdateChecked = DateTime.Now.Date.AddMinutes(-1);
            m_Appointments = new List<Calendar.Appointment>();
        }

        #endregion Constructors

        public void LoadAppointments(Appointments allAppointments)
        {
            BuildCalendarAppointmentList(allAppointments);
        }

        public void Initialise(Appointments allAppointments)
        {
            BuildCalendarAppointmentList(allAppointments);

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                SetCalendarDate(DateTime.Now);
                this.dayViewTrainingDiary.ResolveAppointments += new Calendar.ResolveAppointmentsEventHandler(this.dayView1_ResolveAppointments);
                this.dayViewTrainingDiary.ResolveAppointments += new Calendar.ResolveAppointmentsEventHandler(this.dayView1_ResolveAppointments);
                this.dayViewTrainingDiary.AppointmentMoved += new System.EventHandler<Calendar.AppointmentEventArgs>(this.dayView1_AppointmentMoved);
                this.dayViewTrainingDiary.ToolTipShow += new Calendar.TooltipEventHandler(this.dayView1_ToolTipShow);
                this.dayViewTrainingDiary.AfterDrawAppointment += new Calendar.AfterDrawAppointmentEventHandler(this.dayView1_AfterDrawAppointment);
                this.dayViewTrainingDiary.DoubleClick += new System.EventHandler(this.dayView1_DoubleClick);
                this.dayViewTrainingDiary.AppointmentSelected += new AppointmentSelectedEventHandler(dayView1_AppointmentSelected);
                this.monthCalendar1.MinDateChanged += new System.EventHandler(this.monthCalendar1_MinDateChanged);
            }

            _isLoading = false;
            ForceRefresh(false);
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnScheduleTraining.Text = LanguageStrings.AppDiaryScheduleTraining;
        }

        #endregion Overridden Methods

        #region Calendar

        #region Private Methods

#if DEBUG
        private void LoadDebugString(string s)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("{0} - {1}", Environment.TickCount, s));
        }
#endif
        private void cbAlwaysShowMonday_CheckedChanged(object sender, EventArgs e)
        {
            SetCalendarDate(monthCalendar1.SelectedDates[0]);
            ForceRefresh(false);
        }

        private void cbShowCancelled_CheckedChanged(object sender, EventArgs e)
        {
            ForceRefresh(false);
        }

        private void dayView1_ResolveAppointments(object sender, ResolveAppointmentsEventArgs args)
        {
#if DEBUG
            LoadDebugString("dayView1_resolveAppointments");
#endif
            List<Calendar.Appointment> m_Apps = new List<Calendar.Appointment>();

            foreach (Calendar.Appointment m_App in m_Appointments)
            {
                if (m_App.StartDate.Date >= args.StartDate.Date && m_App.EndDate.Date <= args.EndDate)
                {
                    if (m_App.Object != null)
                    {
                        SharedBase.BOL.Appointments.Appointment ap = (SharedBase.BOL.Appointments.Appointment)m_App.Object;

                        if (ap.AppointmentType != 14 || ap.Status == Enums.AppointmentStatus.CancelledByStaff)
                            continue;

                    }

                    m_Apps.Add(m_App);
                }
            }

            args.Appointments = m_Apps;
#if DEBUG
            LoadDebugString("dayView1_resolveAppointments END");
#endif
        }

        private void BuildCalendarAppointmentList(Appointments allAppointments)
        {
            _lastUpdateChecked = DateTime.Now.AddMinutes(-1);
            m_Appointments.Clear();
            _topID = 0;
            _allAppointments = allAppointments;


            foreach (SharedBase.BOL.Appointments.Appointment appt in _allAppointments)
            {
                if (appt.ID > _topID)
                    _topID = appt.ID;

                if ((appt.AppointmentType != 14) || (appt.Status == Enums.AppointmentStatus.CancelledByStaff) 
                    || (appt.Status == Enums.AppointmentStatus.CancelledByUser))
                    continue;

                Calendar.Appointment calAppt = new Calendar.Appointment();
                calAppt.ID = appt.ID;
                //calAppt.Column = i;
                calAppt.Title = appt.TreatmentName + StringConstants.LINE_FEED + appt.UserName;
                calAppt.StartDate = Shared.Utilities.DoubleToDate(appt.AppointmentDate, appt.StartTime);
                calAppt.EndDate = Shared.Utilities.DoubleToDate(appt.AppointmentDate, appt.StartTime, appt.Duration);
                calAppt.Object = appt;
                UpdateCalendarAppointment(appt, calAppt);
                m_Appointments.Add(calAppt);
            }
        }

        public void RefreshCalendarAppointmentList()
        {
#if DEBUG
            LoadDebugString("BuildCalendarAppointmentList");
#endif
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                    return;

                SharedBase.BOL.Appointments.Appointment h_ap = null;

                //remove appointments that need to be replicated
                foreach (Calendar.Appointment ap in m_Appointments)
                {
                    if (ap.ID < 0)
                    {
                        h_ap = (SharedBase.BOL.Appointments.Appointment)ap.Object;
                        _allAppointments.Remove(h_ap.ID);

                        if (_allAppointments.Contains(h_ap))
                        {
                            ShowError(LanguageStrings.Error, LanguageStrings.AppDiaryErrorSynch);
                        }
                    }
                }

                for (int i = m_Appointments.Count - 1; i > 0; --i)
                {
                    Calendar.Appointment ap = (Calendar.Appointment)m_Appointments[i];
                    if (ap.ID < 0)
                        m_Appointments.Remove(ap);
                }

                SharedBase.BOL.Appointments.Appointments appts = SharedBase.BOL.Appointments.Appointments.GetNew(_topID, _lastUpdateChecked);
                _lastUpdateChecked = DateTime.Now.AddMinutes(-40);

                foreach (SharedBase.BOL.Appointments.Appointment appt in appts)
                {
                    //remove this appointment if it already exists
                    if (_allAppointments.Remove(appt.ID))
                    {
                        //remove from diaryview list
                        foreach (Calendar.Appointment m_ap in m_Appointments)
                        {
                            h_ap = (SharedBase.BOL.Appointments.Appointment)m_ap.Object;

                            if (h_ap != null && h_ap.ID == appt.ID)
                            {
                                m_Appointments.Remove(m_ap);
                                break;
                            }
                        }
                    }
                    else
                    {
                        //need to remove the diary appt
                        //remove from diaryview list

                        foreach (Calendar.Appointment m_ap in m_Appointments)
                        {
                            h_ap = (SharedBase.BOL.Appointments.Appointment)m_ap.Object;

                            if (h_ap != null && h_ap.ID == appt.ID)
                            {
                                m_Appointments.Remove(m_ap);
                                _allAppointments.Remove(m_ap.ID);
                                break;
                            }
                        }
                    }

                    Calendar.Appointment calAppt = new Calendar.Appointment();
                    calAppt.ID = appt.ID;

                    //calAppt.Column = i;
                    calAppt.Title = appt.TreatmentName + StringConstants.LINE_FEED + appt.UserName;
                    calAppt.StartDate = Shared.Utilities.DoubleToDate(appt.AppointmentDate, appt.StartTime);
                    calAppt.EndDate = Shared.Utilities.DoubleToDate(appt.AppointmentDate, appt.StartTime, appt.Duration);
                    calAppt.Object = appt;
                    UpdateCalendarAppointment(appt, calAppt);
                    m_Appointments.Add(calAppt);
                    _allAppointments.Add(appt);

                    if (appt.ID > _topID)
                        _topID = appt.ID;
                }
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

#if DEBUG
            LoadDebugString("BuildCalendarAppointmentList END");
#endif
        }

        private void UpdateCalendarAppointment(SharedBase.BOL.Appointments.Appointment appt, Calendar.Appointment calAppt)
        {
#if DEBUG
            LoadDebugString("UpdatecalendarAppointment");
#endif
            if (appt == null || calAppt == null)
                return;

            //is it locked by a user
            calAppt.Locked = appt.IsLocked;

            //calAppt.AllDayEvent = false;

            //can't change past appointments
            if (appt.AppointmentAsDateTime() <= DateTime.Now.AddMinutes(-_appointmentLockTime))
                calAppt.Locked = true;

            if (_user.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.ShowDebugInformation))
                calAppt.Title = String.Format(StringConstants.APPOINTMENT_ID, appt.ID.ToString()) + appt.AppointmentText;
            else
                calAppt.Title = appt.AppointmentText;

            //set the color
            switch (appt.Status)
            {
                case Enums.AppointmentStatus.Requested: // requested
                    calAppt.Color = _appointmentRequested;
                    calAppt.TextColor = _appointmentRequestedText;
                    break;
                case Enums.AppointmentStatus.Confirmed: // confirmed
                    calAppt.Color = _appointmentConfirmed;
                    calAppt.TextColor = _appointmentConfirmedText;
                    break;
                case Enums.AppointmentStatus.CancelledByUser: // Cancelled by user
                    calAppt.Color = _appointmentCancelledByUser;
                    calAppt.TextColor = _appointmentCancelledByUserText;
                    break;
                case Enums.AppointmentStatus.CancelledByStaff: // cancelled by staff
                    calAppt.Color = _appointmentCancelledByStaff;
                    calAppt.TextColor = _appointmentCancelledbyStaffText;
                    break;
                case Enums.AppointmentStatus.NoShow: // no show
                    calAppt.Color = _appointmentNoShow;
                    calAppt.TextColor = _appointmentNoShowText;
                    break;
                case Enums.AppointmentStatus.Completed: // completed
                    calAppt.Color = _appointmentCompleted;
                    calAppt.TextColor = _appointmentCompletedText;
                    calAppt.Locked = calAppt.Locked | (appt.AppointmentType == 0 || appt.AppointmentAsDateTime() <= DateTime.Now);
                    break;
                case Enums.AppointmentStatus.Arrived: // arrived
                    calAppt.Color = _appointmentArrived;
                    calAppt.TextColor = _appointmentArrivedText;
                    break;
                default:
                    calAppt.Color = Color.Black;
                    calAppt.TextColor = Color.White;
                    break;
            }

            switch (this.Style)
            {
                case CalendarStyle.Pink:
                    calAppt.BorderColor = Color.FromArgb(206, 235, 48);
                    break;
                case CalendarStyle.Grey:
                    calAppt.BorderColor = Color.FromArgb(60, 60, 60);
                    break;
            }
        }

        private bool SetCalendarDate(DateTime date)
        {
#if DEBUG
            LoadDebugString("SetCalendarDate");
#endif
            monthCalendar1.ResetDateInfo();

            bool Result = false;

            // make sure we are not going past minimum date
            if (date.Date < monthCalendar1.MinDate.Date)
                date = monthCalendar1.MinDate;

            _selectedDate = date;

            if (dayViewTrainingDiary.ViewType == DayView.DayViewType.SingleView && _weekStartsMonday)
            {
                while (date.DayOfWeek != DayOfWeek.Monday)
                {
                    date = date.AddDays(-1);
                }

                Result = dayViewTrainingDiary.StartDate.Date != date.Date;
                dayViewTrainingDiary.StartDate = date;
            }
            else
            {
                Result = dayViewTrainingDiary.StartDate.Date != date.Date;
                dayViewTrainingDiary.StartDate = date;
            }

            monthCalendar1.SelectDate(_selectedDate);

            if (Result)
            {
                ForceRefresh(false);
            }

            for (int i = 0; i < 7; ++i)
            {
                Pabo.Calendar.DateItem calItem = new Pabo.Calendar.DateItem();
                calItem.Date = date.AddDays(i);
                calItem.BackColor1 = Color.Orange;
                monthCalendar1.AddDateInfo(calItem);
            }

            lblCurrentDate.Text = String.Format(StringConstants.DATE_RANGE, 
                dayViewTrainingDiary.StartDate.ToString(StringConstants.DATE_FORMAT),
                dayViewTrainingDiary.StartDate.AddDays(6).ToString(StringConstants.DATE_FORMAT));

            return (Result);
        }

        private void monthCal_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (e.Start.Date != dayViewTrainingDiary.StartDate.Date)
            {
                if (SetCalendarDate(e.Start))
                    ForceRefresh(false);
            }
        }

        private void dayView1_AppointmentMoved(object sender, AppointmentEventArgs e)
        {
#if DEBUG
            LoadDebugString("dayview1_AppointmentMoved");
#endif

            SharedBase.BOL.Appointments.Appointment appt = (SharedBase.BOL.Appointments.Appointment)e.Appointment.Object;

            if (!e.Appointment.Locked && appt != null && e.Appointment.StartDate >= DateTime.Now)
            {
                if (appt.AppointmentType == 0 && !Appointments.IsMaximumAllowed(AppointmentTreatments.Get(appt.TreatmentID),
                    e.Appointment.StartDate, Shared.Utilities.TimeToDouble(e.Appointment.StartDate.ToString(StringConstants.DIARY_TIME_FORMAT)), (int)appt.ID))
                {
                    ShowError(LanguageStrings.AppDiaryMaxAllowed, LanguageStrings.AppDiaryMaxTraining);
                    ForceRefresh(false);
                    return;
                }

                appt.StartTime = Shared.Utilities.TimeToDouble(e.Appointment.StartDate.ToString(StringConstants.DIARY_TIME_FORMAT));
                appt.AppointmentDate = e.Appointment.StartDate;

                double NewStart = appt.StartTime + ((appt.Duration / 15) * .25);
                TimeSpan ts = e.Appointment.EndDate - e.Appointment.StartDate;

                //allow resize of treatments for admins and all other treatments
                if ((appt.AppointmentType == 0 && _user.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.ResizeTreatments)) || 
                    appt.AppointmentType != 0)
                {
                    appt.Duration = (int)ts.TotalMinutes;
                    VerifyAppointmentLength(e.Appointment, appt);
                }
                else
                {
                    e.Appointment.EndDate = Shared.Utilities.DoubleToDate(appt.AppointmentDate, appt.StartTime, appt.Duration);
                    VerifyAppointmentLength(e.Appointment, appt);

                    dayViewTrainingDiary.Refresh();
                }

                if (appt.Duration == 0)
                    appt.Duration = 15;

                if (appt.AppointmentType == 1 && appt.ID == -1)
                {
                    Int64 newID = Appointments.Create(appt, _user);
                    appt.ID = newID;
                }
                else
                {
                    try
                    {
                        appt.Save(_user);
                    }
                    catch (Exception err)
                    {
                        if (err.Message.Contains(StringConstants.ERROR_UPDATE_CONFLICT))
                        {
                            Thread.Sleep(1000);
                            appt.Save(_user);
                        }
                    }
                }
            }

            ForceRefresh(true);
        }

        private void dayView1_DoubleClick(object sender, EventArgs e)
        {
#if DEBUG
            LoadDebugString("dayView1_DoubleClick");
#endif

            Calendar.Appointment appt = dayViewTrainingDiary.SelectedAppointment;

            if (appt == null)
                return;

            DateTime start = dayViewTrainingDiary.SelectionStart;

            SharedBase.BOL.Appointments.Appointment ap = (SharedBase.BOL.Appointments.Appointment)appt.Object;

            RaiseEditAppointment(ap, appt.Locked || ap.AppointmentDate < DateTime.Now.Date);

            ForceRefresh(true);
        }

        private void VerifyAppointmentLength(Calendar.Appointment appointment, SharedBase.BOL.Appointments.Appointment appt)
        {
            double NewStart = appt.StartTime + ((appt.Duration / 15) * .25);
            TimeSpan ts = appointment.EndDate - appointment.StartDate;

            appt.Duration = (int)ts.TotalMinutes;
        }

        private void dayView1_ToolTipShow(object sender, TooltipEventArgs e)
        {
#if DEBUG
            LoadDebugString("dayView1_ToolTipshow");
#endif
            try
            {
                SharedBase.BOL.Appointments.Appointment diaryAppt = null;

                if (e.Appointment != null && e.Appointment.AllDayEvent)
                {
                    e.AllowShow = false;
                    return;
                }

                if (e.Appointment != null)
                    diaryAppt = (SharedBase.BOL.Appointments.Appointment)e.Appointment.Object;

                if (diaryAppt == null)
                {
                    if (e.IsHeader)
                    {
                        return;
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (_user.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.ShowDebugInformation))
                    {
                        e.Text = String.Format(LanguageStrings.AppDiaryDebugID + StringConstants.CARRIAGE_RETURN_AND_LINE_FEED, diaryAppt.ID);
                        e.Text += String.Format(StringConstants.PREFIX_AND_SUFFIX_SPACE + StringConstants.CARRIAGE_RETURN_AND_LINE_FEED,
                            diaryAppt.MasterAppointment == -1 ? LanguageStrings.AppDiaryApptMaster : LanguageStrings.AppDiaryApptChild,
                            diaryAppt.MasterAppointment == -1 ? String.Empty : diaryAppt.MasterAppointment.ToString());
                        e.Text += String.Format(LanguageStrings.AppDiaryApptCreated + StringConstants.CARRIAGE_RETURN_AND_LINE_FEED, diaryAppt.Created.ToString(StringConstants.DIARY_DATE_FORMAT));
                        e.Text += String.Format(LanguageStrings.AppDiaryApptLastAltered + StringConstants.CARRIAGE_RETURN_AND_LINE_FEED, diaryAppt.LastAltered.ToString(StringConstants.DIARY_DATE_FORMAT));
                        e.Text += String.Format(LanguageStrings.AppDiaryApptLastAlteredBy + StringConstants.CARRIAGE_RETURN_AND_LINE_FEED, diaryAppt.LastAlteredBy);
                        e.Text += String.Format(LanguageStrings.AppDiaryApptEmployeeID + StringConstants.CARRIAGE_RETURN_AND_LINE_FEED, diaryAppt.EmployeeID);
                        e.Text += String.Format(LanguageStrings.AppDiaryApptClientID + StringConstants.CARRIAGE_RETURN_AND_LINE_FEED, diaryAppt.UserID);
                    }

                    e.Icon = ToolTipIcon.Info;
                    e.ShowBalloon = false;

                    if (diaryAppt.IsLocked)
                    {
                        e.Text += String.Format(LanguageStrings.AppDiaryApptLockedBy + StringConstants.CARRIAGE_RETURN_AND_LINE_FEED, diaryAppt.LockedByName);
                    }

                    if (diaryAppt.AppointmentType == 0)
                    {
                        e.Title = String.Format(LanguageStrings.AppDiaryApptUser, diaryAppt.UserName);
                        e.Text += String.Format(LanguageStrings.AppDiaryApptHintTreatment, diaryAppt.TreatmentName,
                            diaryAppt.EmployeeName, diaryAppt.UserName, diaryAppt.StatusText,
                            Shared.Utilities.DoubleToTime(diaryAppt.StartTime),
                            Shared.Utilities.FormatPhoneNumber(diaryAppt.User.Telephone));
                    }
                    else
                    {
                        if (diaryAppt.AppointmentText.Contains(StringConstants.CARRIAGE_RETURN))
                            e.Title = diaryAppt.AppointmentText.Substring(0, diaryAppt.AppointmentText.IndexOf(StringConstants.CARRIAGE_RETURN));
                        else
                            e.Title = diaryAppt.AppointmentText;

                        e.Text += String.Format(LanguageStrings.AppDiaryApptEmployee, diaryAppt.EmployeeName);
                    }

                    if (diaryAppt.Notes != String.Empty)
                        e.Text += String.Format(StringConstants.CARRIAGE_RETURN + StringConstants.CARRIAGE_RETURN +
                            LanguageStrings.AppDiaryNotes, diaryAppt.Notes);

                    if (diaryAppt.User.VIPCustomer)
                        e.Text += StringConstants.CARRIAGE_RETURN + StringConstants.CARRIAGE_RETURN + LanguageStrings.ApptDiaryVIPCustomer;
                }

                if (e.CurrentCellDateTime < DateTime.Now)
                {
                    e.AllowShow = true;

                    if (diaryAppt == null)
                        e.Text = LanguageStrings.AppDiaryBookApptInPast;

                    return;
                }
            }
            catch (Exception err)
            {
                e.AllowShow = true;
                e.Icon = ToolTipIcon.Error;
                e.Title = LanguageStrings.AppDiaryHintError;
                e.Text = err.Message;
            }
        }

        private void dayView1_AfterDrawAppointment(object sender, AfterDrawAppointmentEventArgs e)
        {

        }

        private void dayView1_AppointmentSelected(object sender, AppointmentSelectedEventArgs e)
        {
            if (e.Appointment == null)
                return;

            if (e.Selected)
            {
                e.Appointment.Color = _appointmentSelected;

                //change border of all related appointments
            }
            else
            {
                UpdateCalendarAppointment((SharedBase.BOL.Appointments.Appointment)e.Appointment.Object, e.Appointment);
            }
        }

        #endregion Private Methods

        #region Overridden Methods

        #endregion Overridden Methods

        private void UpdateCalendarAppointment(SharedBase.BOL.Appointments.Appointment appointment)
        {
            foreach (Calendar.Appointment calAppt in m_Appointments)
            {
                if (calAppt.Object == appointment)
                {
                    calAppt.Title = appointment.TreatmentName + StringConstants.LINE_FEED + appointment.UserName;
                    calAppt.StartDate = Shared.Utilities.DoubleToDate(appointment.AppointmentDate, appointment.StartTime);
                    calAppt.EndDate = Shared.Utilities.DoubleToDate(appointment.AppointmentDate, appointment.StartTime, appointment.Duration);
                    UpdateCalendarAppointment(appointment, calAppt);
                    break;
                }
            }
        }

        private void UpdateStatus(Enums.AppointmentStatus status)
        {
#if DEBUG
            LoadDebugString("UpdateStatus");
#endif

            Calendar.Appointment appt = dayViewTrainingDiary.SelectedAppointment;

            if (appt == null || appt.Object == null)
                return;

            SharedBase.BOL.Appointments.Appointment treat = (SharedBase.BOL.Appointments.Appointment)appt.Object;

            if (treat.MasterAppointment > -1 && treat.Status != Enums.AppointmentStatus.CancelledByStaff)
            {

                treat = _allAppointments.Find(treat.MasterAppointment);

                if (treat == null)
                {
                    treat = (SharedBase.BOL.Appointments.Appointment)appt.Object;
                }
            }

            if (treat != null)
            {
                treat.Status = status;
                treat.Save(_user);
                UpdateCalendarAppointment(treat);

                ForceRefresh(true);
            }
        }


        #endregion Calendar

        #region Properties

        /// <summary>
        /// Currently logged on user
        /// </summary>
        public User CurrentUser
        {
            get
            {
                return (_user);
            }

            set
            {
                _user = value;
            }
        }

        /// <summary>
        /// Delay in miliseconds until tooltip is shown
        /// </summary>
        public int ToolTipDelay
        {
            get
            {
                return (dayViewTrainingDiary.TooltipDelay);
            }

            set
            {
                dayViewTrainingDiary.TooltipDelay = value;
            }
        }

        /// <summary>
        /// Determines how much the calendar will scroll in 1/4 hour increments
        /// </summary>
        public int ScrollAmount
        {
            get
            {
                return (_scrollAmount);
            }

            set
            {
                _scrollAmount = value;
                dayViewTrainingDiary.ScrollRows = value;
            }
        }

        /// <summary>
        /// Determines if minutes are shown on hour labels
        /// </summary>
        public bool ShowMinutes
        {
            get
            {
                return (dayViewTrainingDiary.ShowMinutes);
            }

            set
            {
                dayViewTrainingDiary.ShowMinutes = value;
            }
        }

        /// <summary>
        /// Indicates that the working week starts on a Monday
        /// </summary>
        public bool WeekStartsOnMonday
        {
            get
            {
                return (_weekStartsMonday);
            }

            set
            {
                _weekStartsMonday = value;
                SetCalendarDate(_selectedDate);
                ForceRefresh(false);
            }
        }

        /// <summary>
        /// Determines the minimum Date to show appointments from
        /// </summary>
        public DateTime MinimumDate
        {
            get
            {
                return (_mimimumDate);
            }

            set
            {
                _mimimumDate = value;
                monthCalendar1.MinDate = value;
            }
        }

        /// <summary>
        /// Sets or gets the Start Date for the diary
        /// </summary>
        public DateTime Date
        {
            get
            {
                return (dayViewTrainingDiary.StartDate);
            }

            set
            {
                SetCalendarDate(value.Date);
                ForceRefresh(false);
            }
        }

        /// <summary>
        /// Sets/Gets the style of calendar
        /// </summary>
        public CalendarStyle Style
        {
            get
            {
                return (_style);
            }

            set
            {
                _style = value;

                switch (value)
                {
                    case CalendarStyle.Office11:
                        dayViewTrainingDiary.Renderer = new Office11Renderer(dayViewTrainingDiary);
                        break;
                    case CalendarStyle.Office12:
                        dayViewTrainingDiary.Renderer = new Office12Renderer(dayViewTrainingDiary);
                        break;
                    case CalendarStyle.Grey:
                        dayViewTrainingDiary.Renderer = new GreyRenderer(dayViewTrainingDiary);
                        break;
                    case CalendarStyle.Pink:
                        dayViewTrainingDiary.Renderer = new PinkRenderer(dayViewTrainingDiary);
                        break;
                    case CalendarStyle.Rounded:
                        dayViewTrainingDiary.Renderer = new RoundedRender(dayViewTrainingDiary);
                        break;
                    default:
                        dayViewTrainingDiary.Renderer = new BlueRenderer(dayViewTrainingDiary);
                        break;
                }

                ForceRefresh(false);
            }
        }

        #region Colours

        public Color AppointmentSelected
        {
            get
            {
                return (_appointmentSelected);
            }

            set
            {
                _appointmentSelected = value;
            }
        }

        public Color AppointmentSelectedText
        {
            get
            {
                return (_appointmentSelectedText);
            }

            set
            {
                _appointmentSelectedText = value;
            }
        }

        public Color AppointmentRequested
        {
            get
            {
                return (_appointmentRequested);
            }

            set
            {
                _appointmentRequested = value;
            }
        }

        public Color AppointmentRequestedText
        {
            get
            {
                return (_appointmentRequestedText);
            }

            set
            {
                _appointmentRequestedText = value;
            }
        }

        public Color AppointmentConfirmed
        {
            get
            {
                return (_appointmentConfirmed);
            }

            set
            {
                _appointmentConfirmed = value;
            }
        }

        public Color AppointmentConfirmedText
        {
            get
            {
                return (_appointmentConfirmedText);
            }

            set
            {
                _appointmentConfirmedText = value;
            }
        }

        public Color AppointmentCancelledByUser
        {
            get
            {
                return (_appointmentCancelledByUser);
            }

            set
            {
                _appointmentCancelledByUser = value;
            }
        }

        public Color AppointmentCancelledByUserText
        {
            get
            {
                return (_appointmentCancelledByUserText);
            }

            set
            {
                _appointmentCancelledByUserText = value;
            }
        }

        public Color AppointmentCancelledByStaff
        {
            get
            {
                return (_appointmentCancelledByStaff);
            }

            set
            {
                _appointmentCancelledByStaff = value;
            }
        }

        public Color AppointmentCancelledbyStaffText
        {
            get
            {
                return (_appointmentCancelledbyStaffText);
            }

            set
            {
                _appointmentCancelledbyStaffText = value;
            }
        }

        public Color AppointmentNoShow
        {
            get
            {
                return (_appointmentNoShow);
            }

            set
            {
                _appointmentNoShow = value;
            }
        }

        public Color AppointmentNoShowText
        {
            get
            {
                return (_appointmentNoShowText);
            }

            set
            {
                _appointmentNoShowText = value;
            }
        }

        public Color AppointmentCompleted
        {
            get
            {
                return (_appointmentCompleted);
            }

            set
            {
                _appointmentCompleted = value;
            }
        }

        public Color AppointmentCompletedText
        {
            get
            {
                return (_appointmentCompletedText);
            }

            set
            {
                _appointmentCompletedText = value;
            }
        }

        public Color AppointmentArrived
        {
            get
            {
                return (_appointmentArrived);
            }

            set
            {
                _appointmentArrived = value;
            }
        }

        public Color AppointmentArrivedText
        {
            get
            {
                return (_appointmentArrivedText);
            }

            set
            {
                _appointmentArrivedText = value;
            }
        }

        #endregion


        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Forces a complete refresh of the calendar
        /// </summary>
        public void ForceRefresh(bool ReloadFromDatabase)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {

                if (_isLoading)
                    return;
#if DEBUG
            LoadDebugString("ForceRefresh");
#endif

                if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                {
                    dayViewTrainingDiary.SelectedAppointment = null;

                    if (ReloadFromDatabase)
                        RefreshCalendarAppointmentList();

                    dayViewTrainingDiary.Focus();
                    dayViewTrainingDiary.Invalidate();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Forces an appointment to change it's ID
        /// </summary>
        /// <param name="oldID">ID of appointment</param>
        /// <param name="newID">New ID for appointment</param>
        public void AppointmentIDChanged(Int64 oldID, Int64 newID)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                foreach (Calendar.Appointment ap in m_Appointments)
                {
                    if (ap.ID == oldID)
                    {
                        ap.ID = newID;
                        SharedBase.BOL.Appointments.Appointment h_ap = (SharedBase.BOL.Appointments.Appointment)ap.Object;
                        h_ap.ID = newID;
                        UpdateCalendarAppointment(h_ap, ap);

                        if (h_ap.MasterAppointment == oldID)
                        {
                            h_ap.MasterAppointment = newID;
                        }

                        ForceRefresh(false);
                        break;
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        #endregion Public Methods

        #region Events

        #region Event Wrappers

        private void RaiseEditAppointment(SharedBase.BOL.Appointments.Appointment Appointment, bool IsLocked)
        {
#if DEBUG
            LoadDebugString("DoEditAppointment");
#endif
            if (AppointmentEdit != null)
                AppointmentEdit(this, new EditAppointmentEventArgs(Appointment, IsLocked));

            ForceRefresh(true);
        }

        private void RaiseMinimumDateChanged()
        {
            if (MinimumDateChanged != null)
                MinimumDateChanged(this, EventArgs.Empty);
        }

        private DateTime RaiseCreateAppointment(DateTime DateTime, Therapist Therapist)
        {
            CreateAppointmentEventArgs args = new CreateAppointmentEventArgs(DateTime, Therapist);

            if (AppointmentCreate != null)
                AppointmentCreate(this, args);

            return (args.AppointmentDateTime);
        }

        private void RaiseScheduleTrainingCourse()
        {
            if (ScheduleNewTrainingDays != null)
                ScheduleNewTrainingDays(this, EventArgs.Empty);
        }

        #endregion Event Wrappers

        #region Delegates

        public delegate void EditAppointmentEventHandler(object sender, EditAppointmentEventArgs e);

        public delegate void CreateAppointmentEventHandler(object sender, CreateAppointmentEventArgs e);

        public delegate void AppointmentStatusChangedEventHandler(object sender, AppointmentStatusChangedEventArgs e);

        #endregion Delegates

        /// <summary>
        /// Event called when user wants to edit an existing appointment
        /// </summary>
        public event EditAppointmentEventHandler AppointmentEdit;

        /// <summary>
        /// Event when user wants to create an appointment
        /// </summary>
        public event CreateAppointmentEventHandler AppointmentCreate;

        /// <summary>
        /// Event raised when the minimum date changes
        /// </summary>
        public event EventHandler MinimumDateChanged;

        /// <summary>
        /// Event raised when user clicks the Schedule New Training Days icon
        /// </summary>
        public event EventHandler ScheduleNewTrainingDays;

        #endregion Events

        #region Private Methods

        private void cbImageOverlays_CheckedChanged(object sender, EventArgs e)
        {
            ForceRefresh(false);
        }

        private void dayView1_HeaderClicked(object sender, HeaderClickEventArgs e)
        {
#if DEBUG
            LoadDebugString("dayView1_HeaderClicked");
#endif
        }

        private void imgPrevious_Click(object sender, EventArgs e)
        {
            SetCalendarDate(_selectedDate.AddDays(-7));
        }

        private void imgNext_Click(object sender, EventArgs e)
        {
            SetCalendarDate(_selectedDate.AddDays(7));
        }

        private void monthCalendar1_DayClick(object sender, Pabo.Calendar.DayClickEventArgs e)
        {
            DateTime selected = DateTime.Parse(e.Date);
            monthCalendar1.ActiveMonth.Month = selected.Month;
            monthCalendar1.ActiveMonth.Year = selected.Year;
            SetCalendarDate(selected);
        }

        private void monthCalendar1_FooterClick(object sender, Pabo.Calendar.ClickEventArgs e)
        {
            SetCalendarDate(DateTime.Now);
        }

        private void monthCalendar1_MinDateChanged(object sender, EventArgs e)
        {
            RaiseMinimumDateChanged();
        }

        private void dayViewTrainingDiary_MultiCount(object sender, TeamViewCountEventArgs e)
        {
            e.Count = 7; // 7 days
        }

        private void dayViewTrainingDiary_WorkingHours(object sender, WorkingHoursEventArgs e)
        {
            e.CanWork = true;
            e.WorkingHourStart = 9;
            e.WorkingMinuteStart = 0;
            e.WorkingHourFinish = 18;
            e.WorkingMinuteFinish = 0;
        }

        private void monthCalendar1_DaySelected(object sender, Pabo.Calendar.DaySelectedEventArgs e)
        {

        }

        private void btnScheduleTraining_Click(object sender, EventArgs e)
        {
            RaiseScheduleTrainingCourse();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calendar.Appointment appt = dayViewTrainingDiary.SelectedAppointment;

            if (appt == null)
                return;

            DateTime start = dayViewTrainingDiary.SelectionStart;

            SharedBase.BOL.Appointments.Appointment ap = (SharedBase.BOL.Appointments.Appointment)appt.Object;

            if (ap.MasterAppointment > -1)
                ap = SharedBase.BOL.Appointments.Appointments.Get(ap.MasterAppointment);

            RaiseEditAppointment(ap, appt.Locked || ap.AppointmentDate < DateTime.Now.Date);

            ForceRefresh(true);
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calendar.Appointment appt = dayViewTrainingDiary.SelectedAppointment;

            if (appt == null)
                return;

            DateTime start = dayViewTrainingDiary.SelectionStart;

            SharedBase.BOL.Appointments.Appointment ap = (SharedBase.BOL.Appointments.Appointment)appt.Object;

            if (ap.MasterAppointment > -1)
                ap = SharedBase.BOL.Appointments.Appointments.Get(ap.MasterAppointment);

            ap.Status = Enums.AppointmentStatus.CancelledByStaff;
            ap.Save(CurrentUser);

            foreach (SharedBase.BOL.Appointments.Appointment childAppt in ap.ChildAppointments)
            {
                childAppt.Status = Enums.AppointmentStatus.CancelledByStaff;
                childAppt.Save(CurrentUser);
            }

            ForceRefresh(true);
        }

        private void contextMenuStripDiary_Opening(object sender, CancelEventArgs e)
        {
            Calendar.Appointment appt = dayViewTrainingDiary.SelectedAppointment;

            cancelToolStripMenuItem.Enabled = appt != null;
            editToolStripMenuItem.Enabled = appt != null;
        }

        private void TrainingDiary_Enter(object sender, EventArgs e)
        {
            ForceRefresh(true);
        }

        #endregion Private Methods
    }
}
