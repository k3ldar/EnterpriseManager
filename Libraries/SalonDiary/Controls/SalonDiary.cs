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
 *  File: SalonDiary.cs
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
using System.Windows.Forms;
using System.Threading;

using Calendar;

using SharedControls.Interfaces;

using Shared;
using Shared.Classes;

using Library;
using Library.BOLEvents;
using Library.BOL.Users;
using Library.BOL.Appointments;
using Library.BOL.Therapists;

using Languages;

using SalonDiary.Classes;

#pragma warning disable IDE0018 // Variable declaration can be inlined
#pragma warning disable IDE0017 // Object initialization can be simplified
#pragma warning disable IDE0018 // Variable declaration can be inlined
#pragma warning disable IDE0029 // Null check can be simplified
#pragma warning disable IDE0017 // Object initialization can be simplified
#pragma warning disable IDE0028 // Collection initialization can be simplified
#pragma warning disable IDE1006 // Naming rule violation: These words must begin with upper case characters
#pragma warning disable IDE1005 // Delegate invocation can be simplified

namespace SalonDiary.Controls
{
    public partial class SalonDiary : SharedControls.BaseControl, INotifyAction, IDisposable
    {
        #region Private / Protected Members

        private object _lockObject = new object();

        private User _user;

        private DateTime _selectedDate;
        private string _configFile = String.Empty;
        private bool _printing = false;
        private bool _isLoading = true;
        private int _earliestStart;

        private int _mouseColumn;
        private DateTime _mouseDate;
        private bool _showGhosts = false;
        private bool _imageOverlays;
        private bool _imageOverlaysNoTreatments = true;
        private bool _imageOverlaysOverridden = true;
        private bool _imageOverlaysNotes = true;
        private bool _imageOverlaysHasCancelled = true;
        private bool _imageOverlaysLocked = true;
        private bool _imageOverlaysLinked = true;

        private bool _weekStartsMonday;
        private bool _ignoreWorkingHours;
        private bool _showCancelledAppointments;
        private Library.BOL.Appointments.Appointment _copyAppointment;
        private bool _isCopyAppointment;
        private int _appointmentLockTime = 30;
        private int _birthdayNotification = 14;
        private bool _autoCompleteOnPayment = true;
        private bool _autoCompleteAppointments = true;
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
        private Color _appointmentDeleted = Color.Black;
        private Color _appointmentDeletedText = Color.White;

        private bool _cacheAppointments;

        private SalonUtilisationThread _salonUtilisationThread;
        private string _salonUtilization;

        #region Calendar


        private CalendarStyle _style;

        private List<Calendar.Appointment> m_Appointments;

        private SpecialDates _specialDates;

        private Appointments _allAppointments;

        private Therapists _employees;
        private Int64 _topID;
        private DateTime _lastUpdateChecked;
        private DateTime _dateLastChanged;
        private int _group;

        #endregion Calendar

        #endregion Private / Protected Members

        #region Constructors

        public SalonDiary()
        {
#if DEBUG
            DebugData = new List<DebugInfo>();
            
            LoadDebugString("SalonDiary Loading");
#endif
            _lastMinuteCheck = DateTime.Now.Minute;
            _salonUtilisationThread = new SalonUtilisationThread();
            InitializeComponent();
            _lastUpdateChecked = DateTime.Now.Date.AddMinutes(-1);

            m_Appointments = new List<Calendar.Appointment>();

            _salonUtilisationThread.OnUtilisation += new UtilisationEventHandler(_salonUtilisationThread_OnUtilisation);
            Appointments.OnNewAppointment += Appointments_OnNewAppointment;

            ShowNameFirst = true;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                SetCalendarDate(DateTime.Now);

                this.dayView1.ResolveAppointments += new Calendar.ResolveAppointmentsEventHandler(this.dayView1_ResolveAppointments);
                this.dayView1.NewAppointment += new Calendar.NewAppointmentEventHandler(this.dayView1_NewAppointment);
                this.dayView1.AppointmentMove += new System.EventHandler<Calendar.AppointmentEventArgs>(this.dayView1_AppointmentMove);
                this.dayView1.MultiCount += new Calendar.MultiCountEventHandler(this.dayView1_MultiCount);
                this.dayView1.MultiHeader += new Calendar.MultiGetEventHandler(this.dayView1_MultiHeader);
                this.dayView1.AppointmentMoved += new System.EventHandler<Calendar.AppointmentEventArgs>(this.dayView1_AppointmentMoved);
                this.dayView1.ToolTipShow += new Calendar.TooltipEventHandler(this.dayView1_ToolTipShow);
                this.dayView1.WorkingHours += new Calendar.WorkingHoursEventHandler(this.dayView1_WorkingHours);
                this.dayView1.AfterDrawAppointment += new Calendar.AfterDrawAppointmentEventHandler(this.dayView1_AfterDrawAppointment);
                this.dayView1.DoubleClick += new System.EventHandler(this.dayView1_DoubleClick);
                this.dayView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dayView1_MouseMove);
                this.dayView1.AfterDrawHeader += new AfterDrawHeaderEventHandler(dayView1_AfterDrawHeader);
                this.dayView1.AppointmentSelected += new AppointmentSelectedEventHandler(dayView1_AppointmentSelected);
                this.monthCalendar1.MinDateChanged += new System.EventHandler(this.monthCalendar1_MinDateChanged);
            }
        }

        #endregion Constructors

        public void Initialise(Appointments allAppointments)
        {
#if DEBUG
            LoadDebugString(String.Format("Initialise - Appointment Count: {0}", allAppointments.Count));
#endif
            #region Calendar

            _specialDates = SpecialDates.Get();

            BuildCalendarAppointmentListFromCache(allAppointments);


            #endregion Calendar

            _isLoading = false;
            ForceRefresh(false);
            tmrRefreshFromDatabase.Enabled = true;
        }

        #region Calendar

        #region Private Methods

        private void Appointments_OnNewAppointment(object sender, NewAppointmentArgs e)
        {
#if DEBUG
            LoadDebugString(String.Format("Appointments_OnNewAppointment - Appointment: {0}", 
                e.Appointment.ToString()));
#endif
            RefreshCalendarAppointmentList();
        }


#if DEBUG
        private void LoadDebugString(string s)
        {
            using (TimedLock.Lock(_lockObject))
            {
                DebugData.Add(new DebugInfo(String.Format("{0} : {1}", DateTime.Now.ToString("g"), s)));
            }

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

        private void BuildTherapistList(int group)
        {
#if DEBUG
            LoadDebugString(String.Format("BuildTherapistList - Group: {0}", group));
#endif

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            _employees = Therapists.Get();
            lstTherapists.Items.Clear();
            cmbTherapists.Items.Clear();

            foreach (Therapist therapist in _employees)
            {
                if (therapist.ShowInDiary && (group == 0 || therapist.Group.ID == group))
                {
                    lstTherapists.Items.Add(therapist);
                    cmbTherapists.Items.Add(therapist);
                }
            }

            if (cmbTherapists.Items.Count == 0)
                return;

            cmbTherapists.SelectedIndex = 0;

            for (int i = 0; i < lstTherapists.Items.Count; ++i)
            {
                if (String.IsNullOrEmpty(AutoHideUsers))
                {
                    EmployeeSelect(i, true);
                }
                else
                {
                    EmployeeSelect(i, !AutoHideUsers.Contains(String.Format(StringConstants.THERAPIST_LIST, EmployeeName(i))));
                }
            }
        }

        private void dayView1_MultiCount(object sender, TeamViewCountEventArgs e)
        {
#if DEBUG
            LoadDebugString(String.Format("dayView1_MultiCount - Count: {0}", e.Count));
#endif

            if (dayView1.ViewType == DayView.DayViewType.TeamView)
            {
                e.Count = lstTherapists.CheckedItems.Count;

                //if (lstTherapists.CheckedItems.Count == 0)
                //    dayView1.Visible = false;
            }
            else
                e.Count = 7; //days to show
        }

        private void dayView1_MultiHeader(object sender, TeamViewGetEventArgs e)
        {
#if DEBUG
            LoadDebugString(String.Format("dayview1_MultiHeader - Index: {0}; Header: {1}", e.Index, e.HeaderText));
#endif
            if (dayView1.ViewType == DayView.DayViewType.TeamView)
            {
                if (lstTherapists.CheckedItems.Count == 0)
                    e.HeaderText = LanguageStrings.AppDiaryNoPersonSelected;
                else
                {
                    Therapist therapist = (Therapist)lstTherapists.CheckedItems[e.Index];
                    e.HeaderText = therapist.EmployeeName;
                }
            }
#if DEBUG
            LoadDebugString(String.Format("dayview1_MultiHeader - Column: {0}; Text: {1}", e.Index, e.HeaderText));
#endif
        }

        private void lstTherapists_Format(object sender, ListControlConvertEventArgs e)
        {
            Therapist therapist = (Therapist)e.ListItem;
            e.Value = therapist.EmployeeName;
        }

        private void lstTherapists_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstTherapists.CheckedItems.Count == 0)
                lstTherapists.SetItemChecked(0, true);

            ForceRefresh(false);
            ResetSalonUtilisation();
        }

        private void dayView1_MouseMove(object sender, MouseEventArgs e)
        {
            //int Col = 0;

            //if (dayView1.ViewType == DayView.DayViewType.SingleView)
            //{
            //    toolStripStatusLabel1.Text = dayView1.GetTimeAt(e.X, e.Y, ref Col).ToString();
            //}
            //else
            //{
            //    DateTime time = dayView1.GetTimeAt(e.X, e.Y, ref Col);

            //    if (Col > lstTherapists.Items.Count - 1)
            //        Col -= 1;

            //    if (Col < 0)
            //        return;

            //    Therapist therapist = (Therapist)lstTherapists.CheckedItems[Col];

            //    toolStripStatusLabel1.Text = String.Format("{0} - {1}", therapist.EmployeeName, time.ToString());
            //}
        }

        private void dayView1_ResolveAppointments(object sender, ResolveAppointmentsEventArgs args)
        {
#if DEBUG
            LoadDebugString("dayView1_resolveAppointments");
            LoadDebugString(String.Format("Arguments - Start: {0}; End: {1}; Column: {2}; Count: {3}",
                args.StartDate.ToString("g"), args.EndDate.ToString("g"), args.Column, args.Appointments.Count));
#endif
            this.Cursor = Cursors.WaitCursor;
            try
            {
                List<Calendar.Appointment> m_Apps = new List<Calendar.Appointment>();

                foreach (Calendar.Appointment m_App in m_Appointments)
                {
                    if (m_App.StartDate.Date >= args.StartDate.Date && m_App.EndDate.Date <= args.EndDate // normal appointments
                        || (m_App.AllDayEvent && Shared.Utilities.DateWithin(m_App.StartDate, m_App.EndDate, args.StartDate, dayView1.ViewType == DayView.DayViewType.TeamView ? args.StartDate : dayView1.StartDate.AddDays(7))))
                    {
                        if (m_App.Object != null)
                        {
                            Library.BOL.Appointments.Appointment ap = (Library.BOL.Appointments.Appointment)m_App.Object;

                            if ((ap.Status == Enums.AppointmentStatus.Deleted) || 
                                (ap.Status == Enums.AppointmentStatus.CancelledByStaff || 
                                ap.Status == Enums.AppointmentStatus.CancelledByUser) && !ShowCancelled)
                            {
#if DEBUG
                                LoadDebugString(String.Format("dayView1_resolveAppointments - appointment not included as cancelled or deleted: {0}", ap.ToString()));
#endif
                                continue;
                            }

                            if (dayView1.SelectedAppointment != null)
                            {
                                if (ap.ID != dayView1.SelectedAppointment.ID)
                                    m_App.Column = GetEmployeeColumn(ap.EmployeeID);
                            }
                            else
                                m_App.Column = GetEmployeeColumn(ap.EmployeeID);

                            if (m_App.Column == -1)
                            {
#if DEBUG
                                LoadDebugString(String.Format("dayView1_resolveAppointments - appointment not included as column undetermined: {0}", m_App.Object.ToString()));
#endif
                                continue;
                            }
                        }
                        else
                        {
                            if (m_App.AllDayEvent)
                                m_App.Column = args.Column;
                        }

                        m_Apps.Add(m_App);
                    }
                }

                args.Appointments = m_Apps;
#if DEBUG
            LoadDebugString("dayView1_resolveAppointments END");
#endif
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private int GetEmployeeColumn(Int64 EmployeeID)
        {
            int Result = 0;

            if (dayView1.ViewType == DayView.DayViewType.TeamView)
            {
                foreach (Therapist therapist in lstTherapists.CheckedItems)
                {
                    if (therapist.EmployeeID == EmployeeID)
                    {
                        return (Result);
                    }

                    ++Result;
                }
            }
            else
            {
                Therapist therapist = (Therapist)cmbTherapists.SelectedItem;

                if (therapist != null)
                {
                    if (EmployeeID == therapist.EmployeeID)
                        return (100);
                }
            }

            return (-1);
        }

        public void BuildCalendarLunchTimes(Progress progress)
        {
            return;
            //ProgressEventArgs args = new ProgressEventArgs(lstTherapists.Items.Count, 0);
            //progress.RaiseOnProgress(args);

            //foreach (Therapist therapist in lstTherapists.Items)
            //{
            //    for (int i = 0; i < 100; ++i)
            //    {
            //        AddDinnerTime(_appointments, therapist, DateTime.Now.AddDays(i));
            //    }

            //    args.Percent = args.Percent + 1;
            //    progress.RaiseOnProgress(args);
            //}
        }

        /// <summary>
        /// Builds Calendar appointment List from Database
        /// </summary>
        /// <param name="dateFrom">First Calendar Date</param>
        /// <param name="dateTo">Last Calendar Date</param>
        private void BuildCalendarAppointmentList(DateTime dateFrom, DateTime dateTo)
        {
#if DEBUG
            LoadDebugString(String.Format("BuildCalendarAppointmentList - From: {0}; To: {1}",
                dateFrom.ToString("g"), dateTo.ToString("g")));
#endif

            _lastUpdateChecked = DateTime.Now.AddMinutes(-40);
            m_Appointments.Clear();
            _topID = 0;
            //_allAppointments = allAppointments;

            Appointments appointments = Appointments.Get(dateFrom, dateTo, _showCancelledAppointments);

#if DEBUG
            LoadDebugString(String.Format("BuildCalendarAppointmentList - {0} appointments retrieved between {1} and {2}", 
                appointments.Count, dateFrom.ToString("g"), dateTo.ToString("g")));
#endif

            foreach (Library.BOL.Appointments.Appointment appt in appointments)
            {
                Calendar.Appointment calAppt = new Calendar.Appointment();
                calAppt.ID = appt.ID;
                //calAppt.Column = i;
                calAppt.Title = appt.TreatmentName + StringConstants.LINE_FEED + appt.UserName;
                calAppt.StartDate = Shared.Utilities.DoubleToDate(appt.AppointmentDate, appt.StartTime);
                calAppt.EndDate = Shared.Utilities.DoubleToDate(appt.AppointmentDate, appt.StartTime, appt.Duration);
                calAppt.Object = appt;
                UpdateCalendarAppointment(appt, calAppt);
                m_Appointments.Add(calAppt);

                if (appt.ID > _topID)
                    _topID = appt.ID;
            }


            foreach (SpecialDate date in _specialDates)
            {
                Calendar.Appointment calAppt = new Calendar.Appointment();
                calAppt.ID = date.ID;
                calAppt.Title = date.Description;
                calAppt.StartDate = date.DateStart;
                calAppt.EndDate = date.DateEnd;
                calAppt.AllDayEvent = true;
                calAppt.Locked = true;
                m_Appointments.Add(calAppt);
            }

#if DEBUG
            LoadDebugString("BuildCalendarAppointmentList END");
#endif
        }

        /// <summary>
        /// Builds the calendar appointments from cache
        /// </summary>
        /// <param name="allAppointments"></param>
        private void BuildCalendarAppointmentListFromCache(Appointments allAppointments)
        {
#if DEBUG
            LoadDebugString(String.Format("BuildCalendarAppointmentListFromCache - Appointment Count: {0}", allAppointments.Count));
#endif

            _lastUpdateChecked = DateTime.Now.AddMinutes(-1);
            m_Appointments.Clear();
            _topID = 0;
            _allAppointments = allAppointments;


            foreach (Library.BOL.Appointments.Appointment appt in _allAppointments)
            {
                Calendar.Appointment calAppt = new Calendar.Appointment();
                calAppt.ID = appt.ID;
                calAppt.Title = appt.TreatmentName + StringConstants.LINE_FEED + appt.UserName;
                calAppt.StartDate = Shared.Utilities.DoubleToDate(appt.AppointmentDate, appt.StartTime);
                calAppt.EndDate = Shared.Utilities.DoubleToDate(appt.AppointmentDate, appt.StartTime, appt.Duration);
                calAppt.Object = appt;
                UpdateCalendarAppointment(appt, calAppt);
                m_Appointments.Add(calAppt);

                if (appt.ID > _topID)
                    _topID = appt.ID;
            }


            foreach (SpecialDate date in _specialDates)
            {
                Calendar.Appointment calAppt = new Calendar.Appointment();
                calAppt.ID = date.ID;
                calAppt.Title = date.Description;
                calAppt.StartDate = date.DateStart;
                calAppt.EndDate = date.DateEnd;
                calAppt.AllDayEvent = true;
                calAppt.Locked = true;
                m_Appointments.Add(calAppt);
            }
#if DEBUG
            LoadDebugString("BuildCalendarAppointmentListFromCache");
#endif
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


                if (CacheAppointments)
                {
                    Library.BOL.Appointments.Appointment h_ap = null;

                    //remove appointments that need to be replicated
                    foreach (Calendar.Appointment ap in m_Appointments)
                    {
                        if (ap.ID < 0)
                        {
                            h_ap = (Library.BOL.Appointments.Appointment)ap.Object;
                            _allAppointments.Remove(h_ap.ID);

#if DEBUG
            LoadDebugString(String.Format("BuildCalendarAppointmentList - Appointment Removed for Replication: {0}", 
                ap.Object.ToString()));
#endif

                            if (_allAppointments.Contains(h_ap))
                            {
                                ShowError(LanguageStrings.AppError, LanguageStrings.AppDiaryErrorSynch);
                            }
                        }
                    }

                    for (int i = m_Appointments.Count - 1; i > 0; --i)
                    {
                        Calendar.Appointment ap = (Calendar.Appointment)m_Appointments[i];

                        if (ap.ID < 0)
                        {
#if DEBUG
                            LoadDebugString(String.Format("BuildCalendarAppointmentList Remove Appointment 1: {0}", ap.Object.ToString()));
#endif
                            m_Appointments.Remove(ap);
                        }
                    }

                    Library.BOL.Appointments.Appointments appts = Library.BOL.Appointments.Appointments.GetNew(_topID, _lastUpdateChecked);
                    _lastUpdateChecked = DateTime.Now.AddMinutes(-40);

                    foreach (Library.BOL.Appointments.Appointment appt in appts)
                    {
                        //remove this appointment if it already exists
                        if (_allAppointments.Remove(appt.ID))
                        {
                            //remove from diaryview list
                            foreach (Calendar.Appointment m_ap in m_Appointments)
                            {
                                h_ap = (Library.BOL.Appointments.Appointment)m_ap.Object;

                                if (h_ap != null && h_ap.ID == appt.ID)
                                {
#if DEBUG
                                    LoadDebugString(String.Format("BuildCalendarAppointmentList Remove Appointment 2: {0}", m_ap.Object.ToString()));
#endif
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
                                h_ap = (Library.BOL.Appointments.Appointment)m_ap.Object;

                                if (h_ap != null && h_ap.ID == appt.ID)
                                {
#if DEBUG
                                    LoadDebugString(String.Format("BuildCalendarAppointmentList Remove Appointment 3: {0}", m_ap.Object.ToString()));
#endif
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
#if DEBUG
                        LoadDebugString(String.Format("BuildCalendarAppointmentList Top ID: {0}", _topID));
#endif
                    }
                }
                else
                {
                    DateTime endDate = dayView1.StartDate;

                    if (!TeamView)
                        endDate = dayView1.StartDate.AddDays(6);

                    BuildCalendarAppointmentList(dayView1.StartDate, endDate);

                    if (Shared.Classes.ThreadManager.Exists("Auto Update Calendar Thread"))
                    {
                        Shared.Classes.ThreadManager.Cancel("Auto Update Calendar Thread");
                    }

                    AutoUpdateThread autoUpdateThread = new AutoUpdateThread();
                    autoUpdateThread.ThreadFinishing += autoUpdateThread_ThreadFinishing;
                    Shared.Classes.ThreadManager.ThreadStart(autoUpdateThread, "Auto Update Calendar Thread", ThreadPriority.Lowest);
                }
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

            ResetSalonUtilisation();

#if DEBUG
            LoadDebugString("BuildCalendarAppointmentList END");
#endif
        }

        private void autoUpdateThread_ThreadFinishing(object sender, ThreadManagerEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    if (this.Disposing)
                        return;

                    ThreadManagerEventDelegate tmed = new ThreadManagerEventDelegate(autoUpdateThread_ThreadFinishing);
                    this.Invoke(tmed, new object[] { sender, e });
                }
                else
                {
                    if (!e.Thread.Cancelled)
                        RefreshCalendarAppointmentList();
                }
            }
            catch (InvalidAsynchronousStateException)
            { 
                // do nothing...
            }
        }

        private Library.BOL.Appointments.Appointment AddDinnerTime(Appointments appointments, Therapist therapist, DateTime date)
        {
            Library.BOL.Appointments.Appointment Result = null;
#if DEBUG
            LoadDebugString("AddDinnerTime");
#endif

            // don't add for past dates
            if (date.Date < DateTime.Now.Date.AddDays(-1))
                return (Result);

            if (therapist.AllowCreateAppointment(date))
            {
                // special case for lunch break
                foreach (Library.BOL.Appointments.Appointment appt in appointments)
                {
                    if (appt.AppointmentType == 1 && appt.AppointmentDate == date)
                        return (appt);
                }

                double lunchStart = therapist.LunchStart;
                if (therapist.AppointmentNextTimeSlot(date, ref lunchStart))
                {
                    Result = new Library.BOL.Appointments.Appointment(-1, therapist.EmployeeID, date, lunchStart, therapist.LunchDuration,
                        Enums.AppointmentStatus.Completed, 1, 0, LanguageStrings.AppDiaryLunchBreak, therapist.EmployeeID, therapist.EmployeeName, String.Empty, -1, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));
                    Result.Status = Enums.AppointmentStatus.Confirmed;
                    Result.Save(_user);
                    _allAppointments.Add(Result);
                }
            }

            return (Result);
        }

        private void UpdateCalendarAppointment(Library.BOL.Appointments.Appointment appt, Calendar.Appointment calAppt)
        {
#if DEBUG
            LoadDebugString(String.Format("UpdatecalendarAppointment: {0}", appt.ToString()));
#endif
            if (appt == null || calAppt == null)
                return;

            //is it locked by a user
            calAppt.Locked = appt.IsLocked;

            //can't change past appointments
            if (appt.AppointmentAsDateTime() <= DateTime.Now.AddMinutes(-_appointmentLockTime))
                calAppt.Locked = true;

            if (_user.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.ShowDebugInformation))
                calAppt.Title = appt.GetAppointmentText(ShowNameFirst) + StringConstants.LINE_FEED + 
                    String.Format(StringConstants.APPOINTMENT_ID, appt.ID.ToString()) + StringConstants.LINE_FEED;
            else
                calAppt.Title = appt.GetAppointmentText(ShowNameFirst);

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

            // lastly the color of the appointment can change depending on the appointment type
            switch (appt.AppointmentType)
            {
                case 1: // lunch break
                    calAppt.Color = Color.BlueViolet;
                    calAppt.UseCustomHatchStyle = true;
                    calAppt.CustomHatch = System.Drawing.Drawing2D.HatchStyle.LargeCheckerBoard;
                    break;
                case 5: // office
                    calAppt.CustomHatch = System.Drawing.Drawing2D.HatchStyle.Percent75;
                    calAppt.UseCustomHatchStyle = true;
                    calAppt.Color = Color.MidnightBlue;
                    break;
                case 3: // training
                case 14: // external training
                    calAppt.CustomHatch = System.Drawing.Drawing2D.HatchStyle.DottedGrid;
                    calAppt.UseCustomHatchStyle = true;
                    calAppt.Color = Color.Tomato;
                    break;
                case 13: // front desk
                    calAppt.Color = Color.SlateGray;
                    calAppt.UseCustomHatchStyle = true;
                    calAppt.CustomHatch = System.Drawing.Drawing2D.HatchStyle.HorizontalBrick;
                    break;
                case 6: // not working
                    calAppt.Color = Color.DarkOliveGreen;
                    calAppt.UseCustomHatchStyle = true;
                    calAppt.CustomHatch = System.Drawing.Drawing2D.HatchStyle.WideUpwardDiagonal;
                    break;
                //Result.Add(new AppointmentType(0, "Beauty Treatment"));
                //Result.Add(new AppointmentType(2, "Annual Leave"));
                //Result.Add(new AppointmentType(4, "Clean Salon"));
                //Result.Add(new AppointmentType(7, "Unpaid Break"));
                //Result.Add(new AppointmentType(8, "Sick Day"));
                //Result.Add(new AppointmentType(9, "Product Manufacture"));
                //Result.Add(new AppointmentType(10, "Internal Meeting"));
                //Result.Add(new AppointmentType(11, "Meeting with client"));
                //Result.Add(new AppointmentType(12, "Working Off Site"));
                default:
                    break;
            }
        }

        private bool SetCalendarDate(DateTime date)
        {
#if DEBUG
            LoadDebugString(String.Format("SetCalendarDate - Date: {0}", date.ToString("g")));
            using (TimedLock.Lock(_lockObject))
            {
                DateTime current = DateTime.Now;

                for (int i = DebugData.Count - 1; i > 0; i--)
                {
                    if (DebugData[i].RemoveTime < current)
                        DebugData.Remove(DebugData[i]);
                }
            }

#endif
            monthCalendar1.ResetDateInfo();
            ResetSalonUtilisation();

            bool Result = false;

            // make sure we are not going past minimum date
            if (date.Date < monthCalendar1.MinDate.Date)
                date = monthCalendar1.MinDate;

            _selectedDate = date;

            if (dayView1.ViewType == DayView.DayViewType.SingleView && _weekStartsMonday)
            {
                while (date.DayOfWeek != DayOfWeek.Monday)
                {
                    date = date.AddDays(-1);
                }

                Result = dayView1.StartDate.Date != date.Date;
                dayView1.StartDate = date;
            }
            else
            {
                Result = dayView1.StartDate.Date != date.Date;
                dayView1.StartDate = date;
            }

            monthCalendar1.SelectDate(_selectedDate);

            if (Result)
            {
                ForceRefresh(true);
            }


            if (TeamView)
            {
                //monthCalendar1.SelectedDates[0] = date < monthCal.MinDate ? monthCal.MinDate : date;
                //monthCal.SelectionEnd = date < monthCal.MinDate ? monthCal.MinDate : date;

                Pabo.Calendar.DateItem calItem = new Pabo.Calendar.DateItem();
                calItem.Date = date;
                calItem.BackColor1 = Color.Orange;
                monthCalendar1.AddDateInfo(calItem);
            }
            else
            {
                Therapist therapist = (Therapist)cmbTherapists.SelectedItem;

                for (int i = 0; i < 7; ++i)
                {
                    Pabo.Calendar.DateItem calItem = new Pabo.Calendar.DateItem();
                    calItem.Date = date.AddDays(i);
                    calItem.BackColor1 = Color.Orange;
                    monthCalendar1.AddDateInfo(calItem);
                }
            }

            if (TeamView)
                lblCurrentDate.Text = dayView1.StartDate.ToString(StringConstants.DATE_FORMAT, Thread.CurrentThread.CurrentUICulture);
            else
                lblCurrentDate.Text = String.Format(StringConstants.DATE_RANGE,
                    dayView1.StartDate.ToString(StringConstants.DATE_FORMAT, Thread.CurrentThread.CurrentUICulture),
                    dayView1.StartDate.AddDays(6).ToString(StringConstants.DATE_FORMAT, Thread.CurrentThread.CurrentUICulture));

            return (Result);
        }

        private void monthCal_DateChanged(object sender, DateRangeEventArgs e)
        {
            _earliestStart = 12;

            if (e.Start.Date != dayView1.StartDate.Date)
            {
                if (SetCalendarDate(e.Start))
                    ForceRefresh(true);
            }
        }

        private void dayView1_AppointmentMove(object sender, AppointmentEventArgs e)
        {
#if DEBUG
            LoadDebugString(String.Format("dayview1_AppointmentMove - Appointment: {0}", e.Appointment.Object.ToString()));
#endif

            //e.Appointment.Color = System.Drawing.Color.Aqua;
        }

        private void dayView1_NewAppointment(object sender, NewAppointmentEventArgs e)
        {
#if DEBUG
            LoadDebugString(String.Format("dayView1_NewAppointment - Column: {0}; Title: {1}; Start: {2}; End: {3}", 
               e.Column, e.Title, e.StartDate.ToString("g"), e.EndDate.ToString("g")));
#endif
        }

        private void dayView1_AppointmentMoved(object sender, AppointmentEventArgs e)
        {
#if DEBUG
            LoadDebugString(String.Format("dayview1_AppointmentMoved - {0}", e.Appointment.Object.ToString()));
#endif

            Library.BOL.Appointments.Appointment appt = (Library.BOL.Appointments.Appointment)e.Appointment.Object;

            bool AllowTreatments = true;
            
            if (!e.Appointment.Locked && appt != null && e.Appointment.StartDate >= DateTime.Now)
            {
                Therapist newtherapist;

                if (dayView1.ViewType == DayView.DayViewType.TeamView)
                    newtherapist = (Therapist)lstTherapists.CheckedItems[appt != null ? e.Appointment.Column : dayView1.SelectedColumn];
                else
                    newtherapist = (Therapist)cmbTherapists.Items[cmbTherapists.SelectedIndex];

                if (!CanWorkOnDay(e.Appointment.StartDate, e.Appointment.EndDate, newtherapist, true, out AllowTreatments) && !_ignoreWorkingHours)
                {
                    VerifyAppointmentLength(e.Appointment, (Library.BOL.Appointments.Appointment)e.Appointment.Object);
                    ForceRefresh(false);
                    return;
                }

                //in multiview has it been swapped to a new user?
                if (dayView1.ViewType == DayView.DayViewType.TeamView)
                {

                    if (newtherapist.EmployeeID != appt.EmployeeID)
                    {
                        appt.EmployeeID = newtherapist.EmployeeID;
                    }
                }

                if (appt.AppointmentType == 0 && !Appointments.IsMaximumAllowed(AppointmentTreatments.Get(appt.TreatmentID),
                    e.Appointment.StartDate, Shared.Utilities.TimeToDouble(e.Appointment.StartDate.ToString(StringConstants.DIARY_TIME_FORMAT)), 
                    (int)appt.ID))
                {
                    ShowError(LanguageStrings.AppDiaryMaxAllowed, LanguageStrings.AppDiaryMaxTreatments);
                    ForceRefresh(false);
                    return;
                }

                if (appt.AppointmentType == 0 && !AllowTreatments)
                {
                    ShowError(LanguageStrings.AppDiaryTreatments, 
                        String.Format(LanguageStrings.AppDiaryNoTreatmentsOnDay, newtherapist.EmployeeName));
                    ForceRefresh(false);
                    return;
                }

                appt.StartTime = Shared.Utilities.TimeToDouble(e.Appointment.StartDate.ToString(StringConstants.DIARY_TIME_FORMAT));
                appt.AppointmentDate = e.Appointment.StartDate;

                double NewStart = appt.StartTime + ((appt.Duration / 15) * .25);
                TimeSpan ts = e.Appointment.EndDate - e.Appointment.StartDate;

                //allow resize of treatments for admins and all other treatments
                if ((appt.AppointmentType == 0 && _user.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.ResizeTreatments)) || appt.AppointmentType != 0)
                {
                    appt.Duration = (int)ts.TotalMinutes;
                    VerifyAppointmentLength(e.Appointment, appt);
                }
                else
                {
                    e.Appointment.EndDate = Shared.Utilities.DoubleToDate(appt.AppointmentDate, appt.StartTime, appt.Duration);
                    VerifyAppointmentLength(e.Appointment, appt);

                    dayView1.Refresh();
                }

                if (appt.Duration == 0)
                    appt.Duration = 15;

                foreach (Library.BOL.Appointments.Appointment childAppt in appt.ChildAppointments)
                {
                    if (childAppt.EmployeeID == appt.EmployeeID)
                    {
                        childAppt.StartTime = NewStart;
                        childAppt.AppointmentDate = appt.AppointmentDate;
                        NewStart = childAppt.StartTime + ((childAppt.Duration / 15) * .25);
                        childAppt.EmployeeID = appt.EmployeeID;
                        childAppt.Save(_user);
                    }
                }

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
            ResetSalonUtilisation();
        }

        private void cmbTherapists_Format(object sender, ListControlConvertEventArgs e)
        {
            Therapist therapist = (Therapist)e.ListItem;
            e.Value = therapist.EmployeeName;
        }

        private void dayView1_DoubleClick(object sender, EventArgs e)
        {
            Calendar.Appointment appt = dayView1.SelectedAppointment;

#if DEBUG
            LoadDebugString(String.Format("dayView1_DoubleClick - Appointment: ", appt == null ? "No Appointment Selected" : appt.Object.ToString()));
#endif

            if (appt != null && appt.AllDayEvent)
                return;

            Therapist newtherapist = null;

            if (dayView1.ViewType == DayView.DayViewType.TeamView)
                newtherapist = (Therapist)lstTherapists.CheckedItems[appt != null ? appt.Column : dayView1.SelectedColumn];
            else
                newtherapist = (Therapist)cmbTherapists.Items[cmbTherapists.SelectedIndex];

            DateTime start = dayView1.SelectionStart;

            if (appt == null)
            {
                bool AllowTreatments;

                if (!CanWorkOnDay(start, start.AddMinutes(15), newtherapist, true, out AllowTreatments) && !_ignoreWorkingHours)
                {
                    if (!newtherapist.AllowBookCurrentDay && start.ToShortDateString() == DateTime.Now.ToShortDateString())
                        ShowInformation(LanguageStrings.AppDiaryBookAppointment, String.Format(LanguageStrings.AppDiaryBookApptFailCurrentDay, newtherapist.EmployeeName));
                    else
                        ShowInformation(LanguageStrings.AppDiaryBookAppointment, String.Format(LanguageStrings.AppDiaryBookApptFailDate, newtherapist.EmployeeName, start.ToString(StringConstants.DIARY_DATE_DAY)));

                    return;
                }

                // do not allow appointments in the past.
                if (start < DateTime.Now)
                {
                    ShowError(LanguageStrings.AppDiaryBookAppointment, LanguageStrings.AppDiaryBookApptInPast);
                    return;
                }

                RaiseCreateAppointment(start, newtherapist);
            }
            else
            {
                Library.BOL.Appointments.Appointment ap = (Library.BOL.Appointments.Appointment)appt.Object;

                if (ap.MasterAppointment != -1)
                {
                    ap = _allAppointments.Find((int)ap.MasterAppointment);

                    if (ap == null)
                        return;
                }

                RaiseEditAppointment(ap, appt.Locked || ap.AppointmentDate < DateTime.Now.Date);
            }

            ForceRefresh(true);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _earliestStart = 12;

            ForceRefresh(false);
            ResetSalonUtilisation();
        }

        private void VerifyAppointmentLength(Calendar.Appointment appointment, Library.BOL.Appointments.Appointment appt)
        {
            double NewStart = appt.StartTime + ((appt.Duration / 15) * .25);
            TimeSpan ts = appointment.EndDate - appointment.StartDate;

            appt.Duration = (int)ts.TotalMinutes;

            if (appt.AppointmentType == 1) //lunch break
            {
                if (appt.Duration > MaxLunchDuration)
                {
                    appt.Duration = MaxLunchDuration;
                    appointment.EndDate = appointment.StartDate.AddMinutes(MaxLunchDuration);
                }
            }
        }

        private void dayView1_ToolTipShow(object sender, TooltipEventArgs e)
        {
#if DEBUG
            LoadDebugString(String.Format("dayView1_ToolTipshow: {0}", e.Appointment == null ? "No Appointment" : e.Appointment.Object.ToString()));
#endif
            try
            {
                Library.BOL.Appointments.Appointment diaryAppt = null;

                if (e.Appointment != null && e.Appointment.AllDayEvent)
                {
                    e.AllowShow = false;
                    return;
                }

                if (e.Appointment != null)
                    diaryAppt = (Library.BOL.Appointments.Appointment)e.Appointment.Object;

                if (diaryAppt == null)
                {
                    Therapist therapist = null;

                    if (dayView1.ViewType == DayView.DayViewType.SingleView)
                        therapist = (Therapist)cmbTherapists.SelectedItem;
                    else
                        therapist = (Therapist)lstTherapists.CheckedItems[e.Column];

                    if (e.IsHeader)
                    {
                        e.Icon = ToolTipIcon.None;
                        e.ShowBalloon = false;
                        e.Text = String.Format(LanguageStrings.AppDiaryEditWrokingHours, therapist.EmployeeName, 
                            e.CurrentCellDateTime.ToShortDateString());
                        return;
                    }
                    else
                    {
                        e.Icon = ToolTipIcon.None;
                        e.ShowBalloon = false;
                        bool AllowTreatments;

                        if (CanWorkOnDay(e.CurrentCellDateTime, e.CurrentCellDateTime.AddMinutes(15), therapist, true, out AllowTreatments))
                            e.Text = LanguageStrings.AppDiaryApptAddDblClick;
                        else
                            e.Text = LanguageStrings.AppDiaryApptCanNotCreate;
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

                    e.Text += String.Format("{0}{1}",
                        diaryAppt.AllowSendReminder() ? LanguageStrings.AppDiaryReminderNotSent : LanguageStrings.AppDiaryReminderSent,
                        StringConstants.CARRIAGE_RETURN_AND_LINE_FEED);

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
            Library.BOL.Appointments.Appointment appt = (Library.BOL.Appointments.Appointment)e.Appointment.Object;
            if (e.Appointment.AllDayEvent || appt.Duration < 30 || e.Rectangle.Width < 60 || _printing)
                return;

            if (_imageOverlays && !_printing)
            {
                int offset = 1;

                if (appt.User.VIPCustomer)
                {
                    imageAppointmentOverlays.Draw(e.Graphics, new Point(e.Rectangle.Right - (18 * offset), e.Rectangle.Bottom - 18), 10);
                    ++offset;
                }

                if (appt.MasterAppointment != -1 && _imageOverlaysLinked)
                {
                    imageAppointmentOverlays.Draw(e.Graphics, new Point(e.Rectangle.Right - (18 * offset), e.Rectangle.Bottom - 18), 9);
                    return;
                }

                if (appt.AppointmentType == 0)
                {
                    if (appt.User.History != null && (appt.User.History.CancelledOrNoShow() && _imageOverlaysHasCancelled))
                    {
                        imageAppointmentOverlays.Draw(e.Graphics, new Point(e.Rectangle.Right - (18 * offset), e.Rectangle.Bottom - 18), 1);
                        ++offset;
                    }

                    if (!String.IsNullOrEmpty(appt.User.Notes) && _imageOverlaysNotes)
                    {
                        imageAppointmentOverlays.Draw(e.Graphics, new Point(e.Rectangle.Right - (18 * offset), e.Rectangle.Bottom - 18), 0);
                        ++offset;
                    }
                }

                if (e.Appointment.Locked && _imageOverlaysLocked)
                {
                    imageAppointmentOverlays.Draw(e.Graphics, new Point(e.Rectangle.Right - (18 * offset), e.Rectangle.Bottom - 18), 7);
                    ++offset;
                }
            }
        }

        private void dayView1_AppointmentSelected(object sender, AppointmentSelectedEventArgs e)
        {
#if DEBUG
            LoadDebugString(String.Format("dayView1_AppointmentSelected - Selected: {1}; Appointment: {0}", 
                e.Appointment == null ? "No Appointment" : e.Appointment.Object.ToString(), e.Selected));
#endif
            if (e.Appointment == null)
            {
                RaiseAppointmentAfterSelect(null);
                return;
            }

            if (e.Selected)
            {
                e.Appointment.Color = _appointmentSelected;

                //change border of all related appointments
            }
            else
            {
                UpdateCalendarAppointment((Library.BOL.Appointments.Appointment)e.Appointment.Object, e.Appointment);
            }

            RaiseAppointmentAfterSelect((Library.BOL.Appointments.Appointment)e.Appointment.Object);
        }

        private void dayView1_AfterDrawHeader(object sender, AfterDrawHeaderEventArgs e)
        {
            if (_imageOverlays && !_printing)
            {
                Therapist theraist = GetTherapist(e.Column);

                DateTime start;
                DateTime finish;
                bool canTreat;

                if (theraist.WorkingOverride(e.Date, out start, out finish, out canTreat))
                {
                    if (!canTreat && _imageOverlaysNoTreatments)
                        e.Graphics.DrawImage(imageHeaderOverlays.Images[1], new Point(e.Rectangle.Right - 18, e.Rectangle.Height - 18));
                    else
                        if (_imageOverlaysOverridden)
                            e.Graphics.DrawImage(imageHeaderOverlays.Images[0], new Point(e.Rectangle.Right - 18, e.Rectangle.Height - 18));

                }
            }
        }

        private void dayView1_WorkingHours(object sender, WorkingHoursEventArgs e)
        {
#if DEBUG
            LoadDebugString(String.Format("dayview1_WorkingHours START- Column: {0}; Date: {1}; CanWork: {2}; Start: {3}:{4}; Finish: {5}:{6}", 
                e.Column, e.Date.ToString("g"), e.CanWork, e.WorkingHourStart, e.WorkingMinuteStart, e.WorkingHourFinish, e.WorkingMinuteFinish));
#endif

            int Col = e.Column;
            Therapist therapist;
            bool AllowTreatments;

            if (dayView1.ViewType == DayView.DayViewType.SingleView)
            {
                therapist = (Therapist)cmbTherapists.SelectedItem;
            }
            else
            {
                if (Col > lstTherapists.CheckedItems.Count - 1)
                    Col -= 1;

                if (Col < 0)
                    return;

                therapist = (Therapist)lstTherapists.CheckedItems[Col];
            }

            if (therapist != null)
            {
                DateTime start;
                DateTime finish;

                if (therapist.WorkingOverride(e.Date, out start, out finish, out AllowTreatments))
                {
                    e.WorkingHourStart = start.Hour;
                    e.WorkingMinuteStart = start.Minute;
                    e.WorkingHourFinish = finish.Hour;
                    e.WorkingMinuteFinish = finish.Minute;
                }
                else
                {
                    e.CanWork = CanWorkOnDay(e.Date, e.Date.AddMinutes(15), therapist, false, out AllowTreatments);
                    start = Shared.Utilities.DoubleToDate(e.Date, therapist.StartTime);
                    finish = Shared.Utilities.DoubleToDate(e.Date, therapist.EndTime);
                    e.WorkingHourStart = start.Hour;
                    e.WorkingMinuteStart = start.Minute;
                    e.WorkingHourFinish = finish.Hour;
                    e.WorkingMinuteFinish = finish.Minute;
                }
            }

            if (e.WorkingHourStart < _earliestStart)
                _earliestStart = e.WorkingHourStart;

            if (_printing)
            {
                e.WorkingHourStart = _earliestStart;
            }
#if DEBUG
            LoadDebugString(String.Format("dayview1_WorkingHours END - Column: {0}; Date: {1}; CanWork: {2}; Start: {3}:{4}; Finish: {5}:{6}",
                e.Column, e.Date.ToString("g"), e.CanWork, e.WorkingHourStart, e.WorkingMinuteStart, e.WorkingHourFinish, e.WorkingMinuteFinish));
#endif

        }

        private bool CanWorkOnDay(DateTime startDateTime, DateTime finishDateTime, Therapist therapist, 
            bool IncludeTime, out bool AllowTreatments)
        {
#if DEBUG
            LoadDebugString(String.Format("CanWorkOnDay - Therapist: {0}; IncludeTime: {1}; Start: {2}; Finish: {3}", 
                therapist.ToString(), IncludeTime, startDateTime.ToString("g"), finishDateTime.ToString("g")));
#endif

            bool Result = false;
            AllowTreatments = true;

            switch (startDateTime.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    Result = therapist.AllowFriday;
                    break;
                case DayOfWeek.Saturday:
                    Result = therapist.AllowSaturday;
                    break;
                case DayOfWeek.Sunday:
                    Result = therapist.AllowSunday;
                    break;
                case DayOfWeek.Monday:
                    Result = therapist.AllowMonday;
                    break;
                case DayOfWeek.Tuesday:
                    Result = therapist.AllowTuesday;
                    break;
                case DayOfWeek.Wednesday:
                    Result = therapist.AllowWednesday;
                    break;
                case DayOfWeek.Thursday:
                    Result = therapist.AllowThursday;
                    break;
            }

            if (Result && IncludeTime)
            {
                DateTime Start = Shared.Utilities.DoubleToDate(startDateTime, therapist.StartTime);
                DateTime Finish = Shared.Utilities.DoubleToDate(finishDateTime, therapist.EndTime);

                Result = (startDateTime >= Start && finishDateTime <= Finish);
            }

            if (!Result)
            {
                //check working hours override
                DateTime start;
                DateTime finish;

                Result = therapist.WorkingOverride(startDateTime.Date, out start, out finish, out AllowTreatments);

                if (Result)
                {
                    Result = (startDateTime >= start && finishDateTime <= finish);
                }

            }

            return (Result);
        }

        #endregion Private Methods

        #region Overridden Methods

        #endregion Overridden Methods

        #region Context Menu

        private void CalendarMenu_Opening(object sender, CancelEventArgs e)
        {
            Calendar.Appointment appt = dayView1.SelectedAppointment;
            appointmentHistoryToolStripMenuItem.Enabled = _user.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.ViewHistory);
            pasteAppointmentToolStripMenuItem.Enabled = _copyAppointment != null && dayView1.SelectedAppointment == null;
            copyAppointmentToolStripMenuItem.Enabled = dayView1.SelectedAppointment != null;
            moveAppointmentToolStripMenuItem.Enabled = dayView1.SelectedAppointment != null;

            Therapist newtherapist;
            bool allowTreatments;
            int column = 0;

            if (dayView1.ViewType == DayView.DayViewType.TeamView)
                newtherapist = (Therapist)lstTherapists.CheckedItems[appt != null ? appt.Column : dayView1.SelectedColumn];
            else
                newtherapist = (Therapist)cmbTherapists.Items[cmbTherapists.SelectedIndex];

            calenderMenuCreateAppointment.Enabled = appt == null &&
                CanWorkOnDay(dayView1.GetTimeAt(ref column), dayView1.GetTimeAt(ref column), newtherapist, true, out allowTreatments);
            calendarMenuStatus.Enabled = appt != null && !appt.AllDayEvent;
            calendarMenuClient.Enabled = calendarMenuStatus.Enabled;
            calendarMenuClientNotes.Enabled = calendarMenuStatus.Enabled;
            calendarMenuEditAppointment.Enabled = calendarMenuStatus.Enabled;
            calendarMenuCloneAppointment.Enabled = calendarMenuStatus.Enabled;

            if (appt != null)
            {
                Library.BOL.Appointments.Appointment treat = (Library.BOL.Appointments.Appointment)appt.Object;

                if (treat != null)
                {
                    lockAppointmentToolStripMenuItem.Enabled = !treat.IsLocked && 
                        _user.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.LockAppointments);
                    unlockAppointmentToolStripMenuItem.Enabled = treat.IsLocked && 
                        (treat.LockedBy == _user.ID || _user.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.UnlockAnyAppointment));
                    calendarMenuTakePayment.Enabled = treat.AppointmentType == 0 && treat.Status == Enums.AppointmentStatus.Arrived;

                    if (treat.MasterAppointment != -1 && treat.Status != Enums.AppointmentStatus.CancelledByStaff)
                    {
                        treat = _allAppointments.Find(treat.MasterAppointment);

                        if (treat == null) //not synchronised yet
                            return;
                    }


                    if (treat.Status == Enums.AppointmentStatus.Completed && _user.MemberLevel < MemberLevel.AdminUpdateDelete)
                        calendarMenuStatus.Enabled = false;
                    else
                    {
                        switch (treat.Status)
                        {
                            case Enums.AppointmentStatus.Requested:
                                calendarMenuStatusRequested.Checked = true;
                                break;
                            case Enums.AppointmentStatus.Confirmed:
                                calendarMenuStatusConfirmed.Checked = true;
                                break;
                            case Enums.AppointmentStatus.Arrived:
                                calendarMenuStatusArrived.Checked = true;
                                break;
                            case Enums.AppointmentStatus.CancelledByUser:
                                calendarMenuStatusCancelledByUser.Checked = true;
                                break;
                            case Enums.AppointmentStatus.CancelledByStaff:
                                calendarMenuStatusCancelledByStaff.Checked = true;
                                break;
                            case Enums.AppointmentStatus.NoShow:
                                calendarMenuStatusNoShow.Checked = true;
                                break;
                            case Enums.AppointmentStatus.Completed:
                                calendarMenuStatusCompleted.Checked = true;
                                break;
                        }
                    }
                }
                else
                {
                    calendarMenuTakePayment.Enabled = false;
                    lockAppointmentToolStripMenuItem.Enabled = false;
                    unlockAppointmentToolStripMenuItem.Enabled = false;
                }
            }
            else
            {
                calendarMenuTakePayment.Enabled = false;
                lockAppointmentToolStripMenuItem.Enabled = false;
                unlockAppointmentToolStripMenuItem.Enabled = false;
            }
        }

        private void calendarMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            foreach (ToolStripMenuItem item in calendarMenuStatus.DropDownItems)
                item.Checked = false;
        }

        private void lockAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calendar.Appointment appt = dayView1.SelectedAppointment;

            if (appt == null)
            {
                ShowInformation(LanguageStrings.AppAppointmentLock, LanguageStrings.AppAppointmentLockSelect);
            }
            else
            {
                appt.Locked = true;
                Library.BOL.Appointments.Appointment salonAppt =
                    (Library.BOL.Appointments.Appointment)appt.Object;
                salonAppt.LockedBy = _user.ID;
                salonAppt.Save(_user);
                ForceRefresh(false);
            }
        }

        private void unlockAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calendar.Appointment appt = dayView1.SelectedAppointment;

            appt.Locked = false;
            Library.BOL.Appointments.Appointment salonAppt =
                (Library.BOL.Appointments.Appointment)appt.Object;
            salonAppt.LockedBy = -1;
            salonAppt.Save(_user);
            ForceRefresh(false);
        }

        private void calendarMenuStatusRequested_Click(object sender, EventArgs e)
        {
            UpdateStatus(Enums.AppointmentStatus.Requested);
        }

        private void calendarMenuStatusConfirmed_Click(object sender, EventArgs e)
        {
            UpdateStatus(Enums.AppointmentStatus.Confirmed);
        }

        private void calendarMenuStatusArrived_Click(object sender, EventArgs e)
        {
            UpdateStatus(Enums.AppointmentStatus.Arrived);
        }

        private void calendarMenuStatusCancelledByUser_Click(object sender, EventArgs e)
        {
            UpdateStatus(Enums.AppointmentStatus.CancelledByUser);
        }

        private void calendarMenuStatusCancelledByStaff_Click(object sender, EventArgs e)
        {
            UpdateStatus(Enums.AppointmentStatus.CancelledByStaff);
        }

        private void calendarMenuStatusNoShow_Click(object sender, EventArgs e)
        {
            UpdateStatus(Enums.AppointmentStatus.NoShow);
        }

        private void calendarMenuStatusCompleted_Click(object sender, EventArgs e)
        {
            UpdateStatus(Enums.AppointmentStatus.Completed);
        }

        private void calendarMenuClient_Click(object sender, EventArgs e)
        {
            Calendar.Appointment appt = dayView1.SelectedAppointment;
            Library.BOL.Appointments.Appointment treat = null;

            if (appt != null)
                treat = (Library.BOL.Appointments.Appointment)appt.Object;

            if (treat != null)
            {
                RaiseShowAppointmentUser(treat);
            }
        }

        private void calendarMenuClientNotes_Click(object sender, EventArgs e)
        {
            Calendar.Appointment appt = dayView1.SelectedAppointment;
            Library.BOL.Appointments.Appointment treat = (Library.BOL.Appointments.Appointment)appt.Object;

            if (treat != null)
            {
                RaiseShowAppointmentUserNotes(treat);
            }
        }

        private void calendarMenuCloneAppointment_Click(object sender, EventArgs e)
        {
            Calendar.Appointment appt = dayView1.SelectedAppointment;
            Library.BOL.Appointments.Appointment treat = (Library.BOL.Appointments.Appointment)appt.Object;

            if (treat != null)
            {
                monthCalendar1.SelectDate(RaiseCloneAppointment(treat));
                SetCalendarDate(monthCalendar1.SelectedDates[0]);
                ForceRefresh(true);
                dayView1.Focus();
            }

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Therapist therapist in _employees)
                therapist.ResetCachedData();

            ForceRefresh(true);
        }

        private void appointmentHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dayView1.SelectedAppointment != null && dayView1.SelectedAppointment.Object != null)
            {
                Library.BOL.Appointments.Appointment appt = (Library.BOL.Appointments.Appointment)dayView1.SelectedAppointment.Object;
                RaiseShowAppointmentHistory(appt);
            }
        }

        private void moveAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _isCopyAppointment = false;

            if (dayView1.SelectedAppointment == null)
            {
                ShowError(LanguageStrings.AppDiaryApptMove, LanguageStrings.AppDiaryApptMoveFailed);
                return;
            }

            _copyAppointment = (Library.BOL.Appointments.Appointment)dayView1.SelectedAppointment.Object;

            if (_copyAppointment.MasterAppointment != -1)
            {
                if (!ShowQuestion(LanguageStrings.AppDiaryApptMove, LanguageStrings.AppDiaryApptMoveChild))
                {
                    _copyAppointment = Appointments.Get(_copyAppointment.MasterAppointment);
                }
            }
        }

        private void copyAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dayView1.SelectedAppointment == null)
            {
                ShowError(LanguageStrings.AppDiaryApptCopy, LanguageStrings.AppDiaryApptCopyFailed);
                return;
            }

            _isCopyAppointment = true;
            _copyAppointment = (Library.BOL.Appointments.Appointment)dayView1.SelectedAppointment.Object;

            if (_copyAppointment.MasterAppointment != -1)
            {
                if (!ShowQuestion(LanguageStrings.AppDiaryApptCopy, LanguageStrings.AppDiaryApptCopyChild))
                {
                    _copyAppointment = Appointments.Get(_copyAppointment.MasterAppointment);
                }
            }
        }

        private void pasteAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime newDate = dayView1.SelectionStart;
                double newTime = Shared.Utilities.TimeToDouble(newDate.ToString(StringConstants.DIARY_TIME_FORMAT));
                Therapist therapist;

                if (dayView1.ViewType == DayView.DayViewType.SingleView)
                    therapist = (Therapist)cmbTherapists.Items[cmbTherapists.SelectedIndex];
                else
                    therapist = (Therapist)lstTherapists.CheckedItems[dayView1.SelectedColumn];

                if (_isCopyAppointment)
                {

                    //clone the appointment
                    Library.BOL.Appointments.Appointment cloned = new Library.BOL.Appointments.Appointment(-1, therapist.EmployeeID, newDate, newTime,
                        _copyAppointment.Duration, Library.Enums.AppointmentStatus.Confirmed, _copyAppointment.AppointmentType,
                        _copyAppointment.TreatmentID, _copyAppointment.TreatmentName, _copyAppointment.UserID, _copyAppointment.UserName,
                        _copyAppointment.Notes, -1, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));
                    Appointments.Create(cloned, _user);

                    double NewStart = cloned.StartTime + ((cloned.Duration / 15) * .25);


                    foreach (Library.BOL.Appointments.Appointment sub in _copyAppointment.ChildAppointments)
                    {
                        Library.BOL.Appointments.Appointment clonedChild = new Library.BOL.Appointments.Appointment(-1, therapist.EmployeeID, newDate, NewStart,
                            sub.Duration, Library.Enums.AppointmentStatus.Confirmed, sub.AppointmentType,
                            sub.TreatmentID, sub.TreatmentName, sub.UserID, sub.UserName,
                            sub.Notes, cloned.ID, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));
                        Appointments.Create(clonedChild, _user);
                        NewStart = clonedChild.StartTime + ((clonedChild.Duration / 15) * .25);
                    }
                }
                else
                {
                    //moving appointment
                    _copyAppointment.StartTime = newTime;
                    _copyAppointment.UpdateTherapist(therapist);
                    _copyAppointment.AppointmentDate = newDate.Date;
                    _copyAppointment.Save(_user);

                    UpdateCalendarAppointment(_copyAppointment);

                    double NewStart = _copyAppointment.StartTime + ((_copyAppointment.Duration / 15) * .25);


                    foreach (Library.BOL.Appointments.Appointment sub in _copyAppointment.ChildAppointments)
                    {
                        sub.StartTime = NewStart;
                        sub.AppointmentDate = newDate;
                        sub.UpdateTherapist(therapist);
                        sub.Save(_user);
                        NewStart = sub.StartTime + ((sub.Duration / 15) * .25);

                        UpdateCalendarAppointment(sub);
                    }

                }

                _copyAppointment = null;
                ForceRefresh(true);
                dayView1.Focus();
            }
            catch (Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_FOREIGN_KEY_NOT_EXIST))
                {
                    ShowError(LanguageStrings.AppDiaryApptErrorCopyMove, LanguageStrings.AppDiaryApptErrorCopyMoveFail);
                }
                else
                    throw;
            }
        }

        #endregion Context Menu

        private void UpdateCalendarAppointment(Library.BOL.Appointments.Appointment appointment)
        {
#if DEBUG
            LoadDebugString(String.Format("UpdateCalendarAppointment - Appointment: ", appointment == null ? "No Appointment Selected" : appointment.ToString()));
#endif

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
            Calendar.Appointment appt = dayView1.SelectedAppointment;

#if DEBUG
            LoadDebugString(String.Format("UpdateStatus - Status: {0}; Appointment: {1}", 
                status.ToString(), appt.Object.ToString()));
#endif

            if (appt == null || appt.Object == null)
                return;

            Library.BOL.Appointments.Appointment treat = (Library.BOL.Appointments.Appointment)appt.Object;

            if (treat.MasterAppointment > -1 && treat.Status != Enums.AppointmentStatus.CancelledByStaff)
            {

                treat = _allAppointments.Find(treat.MasterAppointment);

                if (treat == null)
                {
                    treat = (Library.BOL.Appointments.Appointment)appt.Object;
                }
            }

            if (treat != null)
            {
                treat.Status = status;
                treat.Save(_user);
                UpdateCalendarAppointment(treat);

                ForceRefresh(true);
            }

            switch (status)
            {
                case Enums.AppointmentStatus.CancelledByStaff:
                case Enums.AppointmentStatus.CancelledByUser:
                    // start a waiting list thread
                    WaitingListThread checkWaitingList = new WaitingListThread(treat);
                    checkWaitingList.ThreadFinishing += checkWaitingList_ThreadFinishing;
                    Shared.Classes.ThreadManager.ThreadStart(checkWaitingList, 
                        StringConstants.THREAD_NAME_CHECK_WAIT_LIST, ThreadPriority.Lowest);

                    break;

                case Enums.AppointmentStatus.Arrived:
                    User user = treat.User;

                    if (Shared.Utilities.DateWithin(user.BirthDate, BirthdayNotification))
                        ShowInformation(LanguageStrings.AppDiaryBirthday, String.Format(LanguageStrings.AppDiaryBirthdayClose,
                            user.FirstName, user.BirthDate.ToString(StringConstants.DIARY_DATE_BIRTH_DATE)));

                    break;
            }

            RaiseAppointmentStatusChanged(treat);
        }

        #endregion Calendar

        #region Properties
        
#if DEBUG
        /// <summary>
        /// Contains Debug Data
        /// </summary>
        internal List<DebugInfo> DebugData { get; set; }
#endif

        /// <summary>
        /// Determines wether appointments are cached or read directly from the database
        /// </summary>
        public bool CacheAppointments 
        {
            get
            {
                return (_cacheAppointments);
            }

            set
            {
                _cacheAppointments = value;
                RaiseCacheAppointmentsChanged();
            }
        }

        /// <summary>
        /// Maximum Length of a lunch break
        /// </summary>
        public int MaxLunchDuration { get; set; }

        /// <summary>
        /// Automatically de-selectes users from the list
        /// </summary>
        public string AutoHideUsers
        {
            set;
            get;
        }

        /// <summary>
        /// Delay in miliseconds until tooltip is shown
        /// </summary>
        public int ToolTipDelay
        {
            get
            {
                return (dayView1.TooltipDelay);
            }

            set
            {
                dayView1.TooltipDelay = value;
            }
        }

        /// <summary>
        /// Gets/Sets the visible groups
        /// </summary>
        public int Group
        {
            get
            {
                return (_group);
            }

            set
            {
                _group = value;
                BuildTherapistList(_group);

                dayView1.Visible = cmbTherapists.Items.Count > 0;
            }
        }

        /// <summary>
        /// Shows or hides ghost appointments
        /// </summary>
        public bool ShowGhostAppointments
        {
            get
            {
                return (_showGhosts);
            }

            set
            {
                _showGhosts = value;

                ShowHideGhostAppointments();
            }
        }

        /// <summary>
        /// Returns the number of incomplete appointments for today's date
        /// </summary>
        public int IncompleteAppointments
        {
            get
            {
                int Result = 0;

                foreach (Library.BOL.Appointments.Appointment appt in _allAppointments)
                {
                    if (appt.AppointmentDate == DateTime.Now.Date)
                    {
                        switch (appt.Status)
                        {
                            case Enums.AppointmentStatus.Arrived:
                            case Enums.AppointmentStatus.Confirmed:
                            case Enums.AppointmentStatus.Requested:
                                ++Result;
                                break;
                        }
                    }
                }

                return (Result);
            }
        }

        /// <summary>
        /// Retrieves a collection of selected therapists
        /// </summary>
        public Therapists SelectedTherapists
        {
            get
            {
                Therapists Result = new Therapists();

                if (dayView1.ViewType == DayView.DayViewType.TeamView)
                {
                    for (int i = 0; i < lstTherapists.CheckedIndices.Count; i++)
                    {
                        Therapist therapist = (Therapist)lstTherapists.CheckedItems[i];
                        Result.Add(therapist);
                    }
                }
                else
                {
                    Result.Add((Therapist)cmbTherapists.Items[cmbTherapists.SelectedIndex]);
                }

                return (Result);
            }
        }

        /// <summary>
        /// Determines wether appointment status is changed to Complete when taking payment
        /// </summary>
        public bool AutoCompleteOnPayment
        {
            get
            {
                return (_autoCompleteOnPayment);
            }

            set
            {
                _autoCompleteOnPayment = value;
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
                dayView1.ScrollRows = value;
            }
        }

        /// <summary>
        /// Determines when to notify staff of clients birthday
        /// </summary>
        public int BirthdayNotification
        {
            get
            {
                return (_birthdayNotification);
            }

            set
            {
                if (value < 0)
                    value = 0;

                if (value > 120)
                    value = 30;

                _birthdayNotification = value;
            }
        }

        /// <summary>
        /// Determines when the appointment is automatically locked
        /// </summary>
        public int AppointmentLockTime
        {
            get
            {
                return (_appointmentLockTime);
            }

            set
            {
                if (value < 0)
                    value = 0;

                if (value > 120)
                    value = 120;

                _appointmentLockTime = value;
            }
        }

        /// <summary>
        /// Configuration File for Settings
        /// </summary>
        public string ConfigFile
        {
            get
            {
                return (_configFile);
            }

            set
            {
                _configFile = value;
            }
        }

        /// <summary>
        /// Determines if minutes are shown on hour labels
        /// </summary>
        public bool ShowMinutes
        {
            get
            {
                return (dayView1.ShowMinutes);
            }

            set
            {
                dayView1.ShowMinutes = value;
            }
        }

        /// <summary>
        /// The current user logged onto the system
        /// </summary>
        public User User
        {
            get
            {
                return (_user);
            }

            set
            {
                _user = value;

                if (_user != null)
                {
                    appointmentHistoryToolStripMenuItem.Visible = _user.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.ViewAppointmentHistory);
                    apptHistoryToolStripSeparator.Visible = _user.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.ViewAppointmentHistory);
                }

#if DEBUG
                LoadDebugString(String.Format("User Changed: {0}", value == null ? "No User" : value.ToString()));
#endif
            }
        }

        /// <summary>
        /// Shows or hides cancelled appointments
        /// </summary>
        public bool ShowCancelled
        {
            get
            {
                return (_showCancelledAppointments);
            }

            set
            {
#if DEBUG
                LoadDebugString(String.Format("ShowCancelled: {0}", value.ToString()));
#endif
                _showCancelledAppointments = value;
                ForceRefresh(false);
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
        /// Ignores working hours for employee, allowing appointments to be set at any time
        /// </summary>
        public bool IgnoreWorkingHours
        {
            get
            {
                return (_ignoreWorkingHours);
            }

            set
            {
                _ignoreWorkingHours = value;
                ForceRefresh(false);
            }
        }

        /// <summary>
        /// Switches between single employee and multiple employees on the same day
        /// </summary>
        public bool TeamView
        {
            get
            {
                return (dayView1.ViewType == DayView.DayViewType.TeamView);
            }

            set
            {
#if DEBUG
                LoadDebugString(String.Format("TeamView: {0}", value.ToString()));
#endif
                if (value)
                    dayView1.ViewType = DayView.DayViewType.TeamView;
                else
                    dayView1.ViewType = DayView.DayViewType.SingleView;

                if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                {
                    SetCalendarDate(_selectedDate);
                    cmbTherapists.Visible = dayView1.ViewType == DayView.DayViewType.SingleView;
                    lstTherapists.Visible = dayView1.ViewType == DayView.DayViewType.TeamView;
                }

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
                return (dayView1.StartDate);
            }

            set
            {
#if DEBUG
                LoadDebugString(String.Format("SetDate: {0}", value.ToString("g")));
#endif
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
#if DEBUG
                LoadDebugString(String.Format("Style: {0}", value.ToString()));
#endif
                _style = value;

                switch (value)
                {
                    case CalendarStyle.Office11:
                        dayView1.Renderer = new Office11Renderer(dayView1);
                        break;
                    case CalendarStyle.Office12:
                        dayView1.Renderer = new Office12Renderer(dayView1);
                        break;
                    case CalendarStyle.Grey:
                        dayView1.Renderer = new GreyRenderer(dayView1);
                        break;
                    case CalendarStyle.Pink:
                        dayView1.Renderer = new PinkRenderer(dayView1);
                        break;
                    case CalendarStyle.Rounded:
                        dayView1.Renderer = new RoundedRender(dayView1);
                        break;
                    default:
                        dayView1.Renderer = new BlueRenderer(dayView1);
                        break;
                }

                ForceRefresh(false);
            }
        }

        /// <summary>
        /// Retrieves the selected therapist ID in single view
        /// </summary>
        public int SelectedTherapist
        {
            get
            {
                return (cmbTherapists.SelectedIndex);
            }
        }

        /// <summary>
        /// Returns the number of employees in the list
        /// </summary>
        public int EmployeeCount
        {
            get
            {
                return (_employees.Count);
            }
        }

        public bool CompleteNonTreatmentAppointments
        {
            get
            {
                return (_autoCompleteAppointments);
            }

            set
            {
                _autoCompleteAppointments = value;
            }
        }

        /// <summary>
        /// Determines wether the customer name is shown on first line or the treatment name
        /// </summary>
        public bool ShowNameFirst { get; set; }


        public Library.BOL.Appointments.Appointment SelectedAppointment
        {
            get
            {
                Calendar.Appointment calAppt = dayView1.SelectedAppointment;

                if (calAppt == null)
                    return (null);

                Library.BOL.Appointments.Appointment appt = _allAppointments.Find(calAppt.ID);

                return (appt);
            }

            set
            {
                foreach (Calendar.Appointment calAppt in m_Appointments)
                {
                    if (calAppt.ID == value.ID)
                    {
                        dayView1.SelectedAppointment = calAppt;
                        break;
                    }
                }
            }
        }

        #region Image Overlays

        /// <summary>
        /// Shows image overlays, shown if true, otherwise hidden
        /// </summary>
        public bool ShowImageOverlays
        {
            get
            {
                return (_imageOverlays);
            }

            set
            {
                _imageOverlays = value;
                ForceRefresh(false);
            }
        }

        public bool ImageOverlaysNoTreatments
        {
            get { return (_imageOverlaysNoTreatments); }

            set
            {
                _imageOverlaysNoTreatments = value;
            }
        }

        public bool ImageOverlaysOverridden
        {
            get { return (_imageOverlaysOverridden); }

            set
            {
                _imageOverlaysOverridden = value;
            }
        }

        public bool ImageOverlaysNotes
        {
            get { return (_imageOverlaysNotes); }

            set
            {
                _imageOverlaysNotes = value;
            }
        }

        public bool ImageOverlaysHasCancelled
        {
            get { return (_imageOverlaysHasCancelled); }

            set
            {
                _imageOverlaysHasCancelled = value;
            }
        }

        public bool ImageOverlaysLocked
        {
            get { return (_imageOverlaysLocked); }

            set
            {
                _imageOverlaysLocked = value;
            }
        }

        public bool ImageOverlaysLinked
        {
            get { return (_imageOverlaysLinked); }

            set
            {
                _imageOverlaysLinked = value;
            }
        }

        #endregion ImageOverlays

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

        public Color AppointmentDeleted 
        {
            get
            {
                return (_appointmentDeleted);
            }

            set
            {
                _appointmentDeleted = value;
            }
        }

        public Color AppointmentDeletedText
        {
            get
            {
                return (_appointmentDeletedText);
            }

            set
            {
                _appointmentDeletedText = value;
            }
        }

        #endregion


        #endregion Properties

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblUtilisationHeader.Text = LanguageStrings.AppDiaryUtilisationHeader;
            monthCalendar1.Culture = culture;

            SetCalendarDate(_selectedDate);
            dayView1.Invalidate();
        }

        protected override void OnLoad(EventArgs e)
        {
            RaiseWaitingListUpdated();
            base.OnLoad(e);
        }

        #endregion Overridden Methods

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
            LoadDebugString(String.Format("ForceRefresh - Reload: {0}", ReloadFromDatabase.ToString()));
#endif

                if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                {
                    dayView1.SelectedAppointment = null;
                    bool debug = false;

                    if ((ReloadFromDatabase && CacheAppointments) || (!CacheAppointments))
                    {
                        debug = true;
                        RefreshCalendarAppointmentList();
                    }

                    if (!debug)
                    {

                    }
                    dayView1.Focus();
                    dayView1.Invalidate();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Determines wether an employee is selected in multi view
        /// </summary>
        /// <param name="Index">Index of employee</param>
        /// <returns>bool, true if selected, otherwise false</returns>
        public bool EmployeeSelected(int Index)
        {
            if (Index > lstTherapists.Items.Count - 1)
                return (false);

            return (lstTherapists.GetItemChecked(Index));
        }

        /// <summary>
        /// Selects an employee in multi view
        /// </summary>
        /// <param name="Index">Index of employee</param>
        public void EmployeeSelect(int Index, bool selected)
        {
            if (Index > cmbTherapists.Items.Count - 1)
                return;

            lstTherapists.SetItemChecked(Index, selected);
        }

        /// <summary>
        /// Retrieves the name of the employee at the selected index
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public string EmployeeName(int Index)
        {
            if (Index > cmbTherapists.Items.Count -1)
                return (String.Empty);
            Therapist employee = (Therapist)cmbTherapists.Items[Index];
            return (employee.EmployeeName.Trim());
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
#if DEBUG
                LoadDebugString(String.Format("AppointmentIDChanged: From: {0}; To: {1}", oldID.ToString(), newID.ToString()));
#endif

                foreach (Calendar.Appointment ap in m_Appointments)
                {
                    if (ap.ID == oldID)
                    {
                        ap.ID = newID;
                        Library.BOL.Appointments.Appointment h_ap = (Library.BOL.Appointments.Appointment)ap.Object;
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

        /// <summary>
        /// Raise waiting list updated event
        /// </summary>
        internal void RaiseWaitingListUpdated()
        {
            if (WaitingListUpdated != null)
                WaitingListUpdated(this, EventArgs.Empty);
        }

        internal User RaiseSelectUser()
        {
            User Result = null;

            if (OnSelectUser != null)
            {
                SelectUserEventArgs args = new SelectUserEventArgs();
                OnSelectUser(this, args);
                Result = args.User;
            }

            return (Result);
        }

        private void RaisePayNow(Library.BOL.Appointments.Appointment appointment)
        {
            if (appointment.MasterAppointment > -1)
                appointment = Appointments.Get(appointment.MasterAppointment);

            if (PayNow != null)
                PayNow(this, new AppointmentPayNowEventArgs(appointment));
        }

        private DateTime RaiseCloneAppointment(Library.BOL.Appointments.Appointment Appointment)
        {
#if DEBUG
            LoadDebugString(String.Format("DoCloneAppointment: {0}", Appointment.ToString()));
#endif

            CloneAppointmentEventArgs args = new CloneAppointmentEventArgs(Appointment);

            if (AppointmentClone != null)
                AppointmentClone(this, args);

            ResetSalonUtilisation();

            return (args.ClonedDate);
        }

        private void RaiseEditAppointment(Library.BOL.Appointments.Appointment Appointment, 
            bool IsLocked)
        {
#if DEBUG
            LoadDebugString(String.Format("DoEditAppointment - Locked: {0}; Appointment: {1}",
                IsLocked.ToString(), Appointment.ToString()));
#endif

            if (AppointmentEdit != null)
                AppointmentEdit(this, new EditAppointmentEventArgs(Appointment, IsLocked));

            ResetSalonUtilisation();
            ForceRefresh(true);
        }

        private void RaiseMinimumDateChanged()
        {
            if (MinimumDateChanged != null)
                MinimumDateChanged(this, EventArgs.Empty);
        }

        private DateTime RaiseCreateAppointment(DateTime DateTime, Therapist Therapist)
        {
#if DEBUG
            LoadDebugString(String.Format("RaiseCreateAppointment: DateTime: {0}; Therapist: {1}", 
                DateTime.ToString("g"), Therapist.ToString()));
#endif
            CreateAppointmentEventArgs args = new CreateAppointmentEventArgs(DateTime, Therapist);

            if (AppointmentCreate != null)
                AppointmentCreate(this, args);

            ResetSalonUtilisation();

            return (args.AppointmentDateTime);
        }

        private void RaiseShowAppointmentUser(Library.BOL.Appointments.Appointment Appointment)
        {
#if DEBUG
            LoadDebugString(String.Format("DoShowAppointmentUser - {0}", Appointment.ToString()));
#endif

            if (AppointmentUserShow != null)
                AppointmentUserShow(this, new AppointmentUserEventArgs(Appointment));
        }

        /// <summary>
        /// Raises appointment selected event
        /// </summary>
        /// <param name="appointment"></param>
        private void RaiseAppointmentAfterSelect(Library.BOL.Appointments.Appointment appointment)
        {
#if DEBUG
            LoadDebugString(String.Format("RaiseAppointmentAfterSelect - {0}", appointment == null ? "No Appointment Selected" : appointment.ToString()));
#endif

            if (AppointmentAfterSelect != null)
                AppointmentAfterSelect(this, new SalonAppointmentEventArgs(appointment));
        }

        private void RaiseShowAppointmentHistory(Library.BOL.Appointments.Appointment Appointment)
        {
#if DEBUG
            LoadDebugString(String.Format("RaiseShowAppointmentHistory - {0}", Appointment.ToString()));
#endif

            if (AppointmentShowHistory != null)
                AppointmentShowHistory(this, new SalonAppointmentEventArgs(Appointment));
        }

        private void RaiseShowAppointmentUserNotes(Library.BOL.Appointments.Appointment Appointment)
        {
#if DEBUG
            LoadDebugString(String.Format("RaiseShowAppointmentUserNotes - {0}", Appointment.ToString()));
#endif

            if (AppointmentUserNotesShow != null)
                AppointmentUserNotesShow(this, new AppointmentUserEventArgs(Appointment));
        }

        private void RaiseCacheAppointmentsChanged()
        {
#if DEBUG
            LoadDebugString("RaiseCacheAppointmentsChanged");
#endif
            if (CachedAppointmentsChanged != null)
                CachedAppointmentsChanged(this, EventArgs.Empty);
        }

        private void RaiseAppointmentStatusChanged(Library.BOL.Appointments.Appointment Appointment)
        {
#if DEBUG
            LoadDebugString(String.Format("RaiseAppointmentStatusChanged - {0}", Appointment.ToString()));
#endif

            if (AppointmentStatusChanged != null)
                AppointmentStatusChanged(this, new AppointmentStatusChangedEventArgs(Appointment));

            ResetSalonUtilisation();
        }

        private void RaiseEditEmployee(Therapist Therapist)
        {
#if DEBUG
            LoadDebugString(String.Format("RaiseEditEmployee - {0}", Therapist.ToString()));
#endif

            if (EditEmployee != null)
                EditEmployee(this, new EditEmployeeEventArgs(Therapist));

            Therapist.ResetWorkingDays();
            ResetSalonUtilisation();
        }

        private void RaiseEditWorkingHours(Therapist Therapist, DateTime Date)
        {
#if DEBUG
            LoadDebugString(String.Format("RaiseEditWorkingHours - Date: {0}; Therapist: {1}", 
                Date.ToString("g"), Therapist.ToString()));
#endif

            if (EditWorkingHours != null)
                EditWorkingHours(this, new EditWorkingHoursEventArgs(Therapist, Date));

            Therapist.ResetWorkingDays();
            ResetSalonUtilisation();
        }

        private bool RaiseNotesGet(string Title, bool Required, out string Notes)
        {
            NotesGetEventArgs args = new NotesGetEventArgs(Title, Required);

            if (NotesGet != null)
                NotesGet(this, args);

            Notes = args.Notes;
            return (args.Result);
        }


        internal ISMSSend RaiseGetSMSInterace()
        {
            SMSSendEventArgs args = new SMSSendEventArgs();

            if (OnRequestSMSInterface != null)
                OnRequestSMSInterface(this, args);

            return (args.SendInterface);
        }

        #endregion Event Wrappers

        #region Delegates

        public delegate void EditAppointmentEventHandler(object sender, EditAppointmentEventArgs e);

        public delegate void CreateAppointmentEventHandler(object sender, CreateAppointmentEventArgs e);

        public delegate void CloneAppointmentEventHandler(object sender, CloneAppointmentEventArgs e);

        public delegate void AppointmentShowUserEventHandler(object sender, AppointmentUserEventArgs e);

        public delegate void AppointmentShowNotesEventHandler(object sender, AppointmentUserEventArgs e);

        public delegate void AppointmentStatusChangedEventHandler(object sender, AppointmentStatusChangedEventArgs e);

        public delegate void EditEmployeeEventHandler(object sender, EditEmployeeEventArgs e);

        public delegate void EditWorkingHoursEventHandler(object sender, EditWorkingHoursEventArgs e);

        public delegate void NotesGetEventHandler(object sender, NotesGetEventArgs e);

        #endregion Delegates

        /// <summary>
        /// Event called when PayNow menu option selected
        /// </summary>
        public event PayNowEventHandler PayNow;

        /// <summary>
        /// Event called when appointment notes are required
        /// </summary>
        public event NotesGetEventHandler NotesGet;

        /// <summary>
        /// Event called when the status of the appointment has changed
        /// </summary>
        public event AppointmentStatusChangedEventHandler AppointmentStatusChanged;

        /// <summary>
        /// Event called when working hours should be edited
        /// </summary>
        public event EditWorkingHoursEventHandler EditWorkingHours;

        /// <summary>
        /// Event called when an Employee needs editing
        /// </summary>
        public event EditEmployeeEventHandler EditEmployee;

        /// <summary>
        /// Event called when appointment user notes to be shown
        /// </summary>
        public event AppointmentShowNotesEventHandler AppointmentUserNotesShow;

        /// <summary>
        /// Event called when appointment user is to be shown
        /// </summary>
        public event AppointmentShowUserEventHandler AppointmentUserShow;

        /// <summary>
        /// Event called when user wants to edit an existing appointment
        /// </summary>
        public event EditAppointmentEventHandler AppointmentEdit;

        /// <summary>
        /// Event when user wants to create an appointment
        /// </summary>
        public event CreateAppointmentEventHandler AppointmentCreate;

        /// <summary>
        /// Event when user wants to clone an existing appointment
        /// </summary>
        public event CloneAppointmentEventHandler AppointmentClone;

        /// <summary>
        /// Event called when history for the appointment needs to be displayed
        /// </summary>
        public event SalonAppointmentEventHandler AppointmentShowHistory;

        /// <summary>
        /// Appointment has been selected
        /// 
        /// if null appointment then no appointment selected
        /// </summary>
        public event SalonAppointmentEventHandler AppointmentAfterSelect;

        /// <summary>
        /// Event raised when the minimum date changes
        /// </summary>
        public event EventHandler MinimumDateChanged;

        /// <summary>
        /// Event raised when cache appointments property changes
        /// </summary>
        public event EventHandler CachedAppointmentsChanged;

        /// <summary>
        /// Event raised when a user needs to be selected
        /// </summary>
        public event SelectUserEventDelegate OnSelectUser;

        /// <summary>
        /// Event raised when waiting list is updated
        /// </summary>
        public event EventHandler WaitingListUpdated;

        /// <summary>
        /// Event raised when interface for sending sms message is needed
        /// </summary>
        public event SMSSenderDelegate OnRequestSMSInterface;

        #endregion Events

        private void cbImageOverlays_CheckedChanged(object sender, EventArgs e)
        {
            ForceRefresh(false);
        }

        #region Printing

        public void Print()
        {
            if (dayView1.ViewType == DayView.DayViewType.TeamView)
                printDocument1.DocumentName = String.Format(LanguageStrings.AppDiaryPrintName, dayView1.StartDate.ToShortDateString());
            else
            {
                if (cmbTherapists.SelectedIndex == -1)
                {
                    ShowInformation(LanguageStrings.AppDiaryPrint, LanguageStrings.AppDiaryPrintSelectStaff);
                }
                else
                {
                    Therapist ther = (Therapist)cmbTherapists.Items[cmbTherapists.SelectedIndex];
                    printDocument1.DocumentName = String.Format(LanguageStrings.AppDiaryPrintWeek, ther.EmployeeName, dayView1.StartDate.ToShortDateString());
                }
            }


            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            CalendarStyle oldStyle = Style;
            try
            {
                _printing = true;
                try
                {
                    //print in grey
                    Style = CalendarStyle.Grey;

                    System.Drawing.Printing.PrintDocument pd = (System.Drawing.Printing.PrintDocument)sender;
                    int startHour = dayView1.StartHour;
                    int hourHeight = dayView1.HalfHourHeight * 2;
                    int headerHeight = 20;
                    int totalHeight = headerHeight + hourHeight * 24;
                    dayView1.StartHour = _earliestStart - 1;

                    Rectangle rectArea = new Rectangle(e.MarginBounds.Left, e.MarginBounds.Left, e.MarginBounds.Width, totalHeight);
                    PaintEventArgs paintEvent = new PaintEventArgs(e.Graphics, rectArea);

                    dayView1.Print(paintEvent);

                    dayView1.StartHour = startHour;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format(LanguageStrings.AppDiaryPrintError, ex.Message.ToString()));
                }
            }
            finally
            {
                _printing = false;
                Style = oldStyle;
            }
        }

        private void printDocument1_QueryPageSettings(object sender, System.Drawing.Printing.QueryPageSettingsEventArgs e)
        {
            e.PageSettings.Landscape = false;
        }

        #endregion Printing

        private void dayView1_HeaderClicked(object sender, HeaderClickEventArgs e)
        {
#if DEBUG
            LoadDebugString(String.Format("dayView1_HeaderClicked - Column: {0}; Date: {1}",
                e.Column, e.CurrentDate.ToString("g")));
#endif

            if (e.CurrentDate.Date < DateTime.Now.Date)
            {
                ShowInformation(LanguageStrings.AppDiaryWorkingHours, LanguageStrings.AppDiaryWorkingHoursPastChange);
                return;
            }

            Therapist newtherapist = null;

            if (dayView1.ViewType == DayView.DayViewType.TeamView)
                newtherapist = (Therapist)lstTherapists.CheckedItems[e.Column];
            else
                newtherapist = (Therapist)cmbTherapists.Items[cmbTherapists.SelectedIndex];

            RaiseEditWorkingHours(newtherapist, e.CurrentDate);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            RaiseEditEmployee(GetTherapist(_mouseColumn));
        }

        private void changeWorkingHoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RaiseEditWorkingHours(GetTherapist(_mouseColumn), _mouseDate);
        }

        /// <summary>
        /// Rturns the selected therapist
        /// </summary>
        /// <param name="Index">Index of therapist (default zero)</param>
        /// <returns>Therapist object</returns>
        private Therapist GetTherapist(int Index = 0)
        {
            Therapist Result = null;

            if (Index > -1)
            {
                if (dayView1.ViewType == DayView.DayViewType.TeamView)
                    Result = (Therapist)lstTherapists.CheckedItems[Index];
                else
                    Result = (Therapist)cmbTherapists.Items[cmbTherapists.SelectedIndex];
            }

            return (Result);
        }

        private void CreateAllDayAppointment(string Message, int AppointmentType, bool RequiresNotes = false, bool addLunch = false)
        {
            //put employee on annual leave/not working for the day

            Therapist therapist = GetTherapist(_mouseColumn);

            if (therapist.HasAppointments(_mouseDate) || _mouseDate.Date < DateTime.Now.Date)
            {
                if (_mouseDate.Date < DateTime.Now.Date)
                    ShowInformation(Message, LanguageStrings.AppDiaryApptChangePastDates);
                else
                    ShowInformation(Message, String.Format(LanguageStrings.AppDiaryApptCanNotBook,
                        Message, therapist.EmployeeName, _mouseDate.ToShortDateString()));

                return;
            }

            double start;
            double finish;
            int duration;

            if (therapist.WorkingDay(_mouseDate, out start, out finish, out duration))
            {
                string notes = String.Empty;
                bool notesResult = RaiseNotesGet(Message, RequiresNotes, out notes);

                if ((!notesResult && RequiresNotes) || (!notesResult))
                    return;

                if (addLunch)
                {
                    Library.BOL.Appointments.Appointment lunch = AddDinnerTime(Appointments.Get(_mouseDate, therapist.EmployeeID), therapist, _mouseDate);

                    double Start = start;
                    int Duration = (int)((lunch.StartTime - start) * 60);
                    Library.BOL.Appointments.Appointment appt = new Library.BOL.Appointments.Appointment(
                       -1, therapist.EmployeeID, _mouseDate, start, Duration, Enums.AppointmentStatus.Confirmed, AppointmentType, 0, Message,
                       therapist.EmployeeID, therapist.EmployeeName, String.Empty, -1, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));
                    appt.Notes = String.Format(LanguageStrings.AppDiaryBookedByOn, 
                        _user.UserName, DateTime.Now.ToShortDateString(), notes);
                    appt.Save(_user);

                    Start = lunch.StartTime + (lunch.Duration / 60);
                    Duration = (int)((finish - Start) * 60);
                    appt = new Library.BOL.Appointments.Appointment(
                       -1, therapist.EmployeeID, _mouseDate, Start, Duration, Enums.AppointmentStatus.Confirmed, AppointmentType, 0, Message,
                        therapist.EmployeeID, therapist.EmployeeName, String.Empty, -1, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));
                    appt.Notes = String.Format(LanguageStrings.AppDiaryBookedByOn, 
                        _user.UserName, DateTime.Now.ToShortDateString(), notes);
                    appt.Save(_user);

                }
                else
                {
                    Library.BOL.Appointments.Appointment appt = new Library.BOL.Appointments.Appointment(
                       -1, therapist.EmployeeID, _mouseDate, start, duration, Enums.AppointmentStatus.Confirmed, AppointmentType, 0, Message,
                       therapist.EmployeeID, therapist.EmployeeName, String.Empty, -1, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));
                    appt.Notes = String.Format(LanguageStrings.AppDiaryBookedByOn, 
                        _user.UserName, DateTime.Now.ToShortDateString(), notes);

                    appt.Save(_user);
                    _allAppointments.Add(appt);
                }

                ForceRefresh(true);
            }

            if (duration == 0)
                ShowError(LanguageStrings.AppDiaryNotWorking, String.Format(LanguageStrings.AppDiaryApptNotBookAllDay,
                    Message, therapist.EmployeeName, _mouseDate.ToShortDateString()));
        }

        private void notWorkingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAllDayAppointment(LanguageStrings.AppDiaryNotWorking, 6);
        }

        private void dayView1_BeforeContextMenuShow(object sender, ContextMenuEventArgs e)
        {
            _mouseColumn = e.Column;
            _mouseDate = e.ColumnDateTime;
        }

        private void imgPrevious_Click(object sender, EventArgs e)
        {
            if (TeamView)
                SetCalendarDate(_selectedDate.AddDays(-1));
            else
                SetCalendarDate(_selectedDate.AddDays(-7));
        }

        private void imgNext_Click(object sender, EventArgs e)
        {
            if (TeamView)
                SetCalendarDate(_selectedDate.AddDays(1));
            else
                SetCalendarDate(_selectedDate.AddDays(7));
        }

        private void workingOffSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAllDayAppointment(LanguageStrings.AppDiaryApptOffSite, 12, true);
        }

        private void trainingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAllDayAppointment(LanguageStrings.AppDiaryApptTraining, 3, true);
        }

        private void frontDeskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAllDayAppointment(LanguageStrings.AppDiaryApptFrontDesk, 13, false, true);
        }

        private void dayView1_BeforeAppointmentMove(object sender, AppointmentMoveEventArgs args)
        {
            Library.BOL.Appointments.Appointment appt = (Library.BOL.Appointments.Appointment)args.Appointment.Object;

            if (appt.AppointmentDate < DateTime.Now.Date)
                args.AllowMove = false;
        }

        private void takePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dayView1.SelectedAppointment == null)
                return;

            Library.BOL.Appointments.Appointment appt = (Library.BOL.Appointments.Appointment)dayView1.SelectedAppointment.Object;

            if (appt.MasterAppointment > -1)
                appt = Appointments.Get(appt.MasterAppointment);

            if (AutoCompleteOnPayment)
            {
                appt.Status = Enums.AppointmentStatus.Completed;
                appt.Save(_user);
            }

            RaisePayNow(appt);
        }

        private void monthCalendar1_DaySelected(object sender, Pabo.Calendar.DaySelectedEventArgs e)
        {
            //DateTime selected = DateTime.Parse(e.Days[0]);
            //monthCalendar1.ActiveMonth.Month = selected.Month;
            //monthCalendar1.ActiveMonth.Year = selected.Year;
            //monthCalendar1.SelectDate(selected);
            //SetCalendarDate(selected);
            //_earliestStart = 12;
        }

        private void monthCalendar1_DayClick(object sender, Pabo.Calendar.DayClickEventArgs e)
        {
            DateTime selected = DateTime.Parse(e.Date);
            monthCalendar1.ActiveMonth.Month = selected.Month;
            monthCalendar1.ActiveMonth.Year = selected.Year;
            //monthCalendar1.SelectDate(selected);
            SetCalendarDate(selected);
            _earliestStart = 12;
        }

        private void monthCalendar1_FooterClick(object sender, Pabo.Calendar.ClickEventArgs e)
        {
            SetCalendarDate(DateTime.Now);
        }

        private void tmrRefreshFromDatabase_Tick(object sender, EventArgs e)
        {
            //are we going to update calendar usage stats
            TimeSpan ts = new TimeSpan(0, 0, 8);

            if (DateTime.Now - _dateLastChanged >= ts)
            {
                _dateLastChanged = DateTime.Now.AddDays(1);
                UpdateSalonUtilisation();
            }

            if (DateTime.Now.Minute != _lastMinuteCheck)
            {
                _lastMinuteCheck = DateTime.Now.Minute;
                dayView1.Invalidate();
            }
        }

        private void monthCalendar1_MinDateChanged(object sender, EventArgs e)
        {
            RaiseMinimumDateChanged();
        }

        #region Salon Utilisation

        public void ResetSalonUtilisation()
        {
            _dateLastChanged = DateTime.Now;
            lblSalonUtilisation.Visible = false;
            lblUtilisationHeader.Visible = false;
            _salonUtilisationThread.Stop();
            _salonUtilization = String.Empty;
        }

        public void UpdateSalonUtilisation()
        {
            Therapists therapists = new Therapists();
            DateTime endDate;

            //get a list of therapists
            if (dayView1.ViewType == DayView.DayViewType.SingleView)
            {
                if (cmbTherapists.SelectedItem == null)
                {
                    if (cmbTherapists.Items.Count > 0)
                        cmbTherapists.SelectedIndex = 0;
                    else
                        return;
                }

                therapists.Add((Therapist)cmbTherapists.SelectedItem);
                endDate = dayView1.StartDate.AddDays(7);
            }
            else
            {
                endDate = dayView1.StartDate;
                foreach (Therapist ther in lstTherapists.CheckedItems)
                {
                    therapists.Add(ther);
                }
            }

            _salonUtilisationThread.Start(therapists, dayView1.StartDate, endDate);
            lblSalonUtilisation.Text = LanguageStrings.AppDiaryUtilisationCalculating;
            lblSalonUtilisation.Visible = true;
            lblUtilisationHeader.Visible = true;
        }

        private void _salonUtilisationThread_OnUtilisation(object sender, UtilisationEventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    UtilisationEventHandler ueh = new UtilisationEventHandler(_salonUtilisationThread_OnUtilisation);
                    this.Invoke(ueh, new object[] { sender, e });
                }
                catch
                { //ignore
                }
            }
            else
            {
                double total = e.Treatments + e.OtherHours;
                double percent = Math.Round(e.Hours > 0.00 ? (total / (e.Hours - e.Lunch)) * 100 : 0.00, 2);

                if (e.Name == StringConstants.TOTAL)
                {
                    lblSalonUtilisation.Text = String.Format(LanguageStrings.AppDiaryUtilisationTotal,
                        e.Hours - e.Lunch, total, percent);
                }
                else
                {
                    if (dayView1.ViewType == DayView.DayViewType.SingleView)
                        _salonUtilization += String.Format(LanguageStrings.AppDiaryUtilisation + StringConstants.CARRIAGE_RETURN,
                            e.Date.ToShortDateString(), e.Hours - e.Lunch, total, percent);
                    else
                        _salonUtilization += String.Format(LanguageStrings.AppDiaryUtilisation + StringConstants.CARRIAGE_RETURN,
                            e.Name, e.Hours - e.Lunch, total, percent);
                }

                toolTip1.SetToolTip(lblSalonUtilisation, _salonUtilization);
            }
        }

        #endregion Salon Utilisation

        #region Ghost Appointments

        public void ShowHideGhostAppointments()
        {

        }

        #endregion Ghost Appointments

        private void SalonDiary_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
                UpdateSalonUtilisation();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            if (e.AssociatedControl == lblSalonUtilisation)
            {


            }
        }

        private void contextMenuStripHeader_Opening(object sender, CancelEventArgs e)
        {
            bool ManageTimeOff = _user.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.ManageStaffTimeOff);

            bool therapistSelected = false;

            if (cmbTherapists.Visible)
                therapistSelected = cmbTherapists.SelectedIndex > -1;

            notWorkingToolStripMenuItem.Enabled = therapistSelected && ManageTimeOff;
            workingOffSiteToolStripMenuItem.Enabled = therapistSelected && ManageTimeOff;
        }

        private void calendarMenuStatus_DropDownOpening(object sender, EventArgs e)
        {
            bool CancelAppointments = _user.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.CancelAppointments);
            calendarMenuStatusCancelledByStaff.Enabled = CancelAppointments && _user.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.CancelledByStaffMenu);
            calendarMenuStatusCancelledByUser.Enabled = CancelAppointments;
        }

        private void btnWaitingList_Click(object sender, EventArgs e)
        {
            WaitingListWizardWrapper.ShowWaitingListWizard(this);
            dayView1.Focus();
        }

        #region New Appointment Wizard

        private void btnNewAppointmentWizard_Click(object sender, EventArgs e)
        {
            Classes.NewAppointWizardWrapper.ShowNewAppointmentWizard(this);
            dayView1.Focus();
        }

        #endregion New Appointment Wizard

        #region Send Reminders

        private void btnSendRemindersWizard_Click(object sender, EventArgs e)
        {
            Classes.SendRemindersWizardWrapper.ShowSendRemindersWizard(this);
            dayView1.Focus();
        }

        #endregion Send Reminders

        #region Debug Only

        private void getDebugDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if DEBUG
            try
            {
                using (TimedLock.Lock(_lockObject))
                {
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        string data = String.Empty;
                        DateTime current = DateTime.Now;

                        for (int i = DebugData.Count - 1; i > 0; i--)
                        {
                            if (DebugData[i].RemoveTime < current)
                                DebugData.Remove(DebugData[i]);
                            else
                                data += String.Format("{0}\r\n", DebugData[i].Data);

                        }

                        Clipboard.SetText(data);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Arrow;
                    }

                    ShowInformation("Debug Information", "Debug Data has been copied to the clipboard\r\n\r\nNow email it to Simon with a small note of what you were doing and what went wrong, please!");
                }
            }
            catch (Exception error)
            {
                Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), error, sender, e);
                ShowError("Error Copying Data", error.Message);
            }
#endif
        }

        #endregion Debug Only

        #region Notifications

        private void checkWaitingList_ThreadFinishing(object sender, Shared.ThreadManagerEventArgs e)
        {
            if (this.InvokeRequired)
            {
                if (this.Disposing)
                    return;

                ThreadManagerEventDelegate tmed = new ThreadManagerEventDelegate(checkWaitingList_ThreadFinishing);
                this.Invoke(tmed, new object[] { sender, e });
            }
            else
            {
                WaitingListThread thread = (WaitingListThread)e.Thread;

                if (thread.AvailableList.Count > 0)
                {
                    string message = String.Empty;

                    foreach (WaitingList listItem in thread.AvailableList)
                    {
                        message += listItem.Customer.UserName + StringConstants.CARRIAGE_RETURN_AND_LINE_FEED;
                    }

                    message = String.Format(LanguageStrings.AppDiaryWaitListApptCanBeFilled, message);

                    SharedControls.Forms.Notification notify = new SharedControls.Forms.Notification(
                        this, String.Empty, message);
                    notify.BackColor = System.Drawing.Color.Black;
                    notify.TextColor = System.Drawing.Color.White;
                    notify.Font = new System.Drawing.Font(notify.Font.Name, 9.0f);
                    notify.OpacitySpeed = 0.2;
                    notify.FadeOut = true;
                    notify.AutomaticallyClose = 45;

                    notify.NotifyPosition = Shared.NotificationPosition.BottomRight;

                    notify.NotifyEffect = Shared.NotificationEffect.Slide;
                    notify.Show();
                }
            }
        }

        public void NotifyCancelled(object sender, EventArgs e)
        {
            
        }

        public void NotifyClicked(object sender, EventArgs e)
        {
            ((SharedControls.Forms.Notification)sender).Close();
            WaitingListWizardWrapper.ShowWaitingListWizard(this);
            ForceRefresh(true);
        }

        public void NotifyFocus(object sender, EventArgs e)
        {
            this.Focus();
        }

        public void NotifyTimeOut(object sender, EventArgs e)
        {
            
        }

        #endregion Notifications

        #region IDisposable

        void IDisposable.Dispose()
        {
            if (Shared.Classes.ThreadManager.Exists("Auto Update Calendar Thread"))
            {
                Shared.Classes.ThreadManager.Cancel("Auto Update Calendar Thread");
            }
        }

        #endregion IDisposable
    }

#if DEBUG

    internal class DebugInfo
    {
        internal DebugInfo(string s)
        {
            Data = s;
            RemoveTime = DateTime.Now.AddMinutes(10);
        }

    #region Properties

        /// <summary>
        /// Debug Information
        /// </summary>
        internal string Data { get; private set; }

        /// <summary>
        /// Date/Time debug info to be removed
        /// </summary>
        internal DateTime RemoveTime { get; private set; }

        #endregion Properties
    }

#endif
}
