using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

using Library;
using Library.BOL.Users;
using Library.BOL.Therapists;
using Library.BOL.Appointments;

using Languages;

#pragma warning disable IDE0018 // Variable declaration can be inlined
#pragma warning disable IDE0029 // Null check can be simplified
#pragma warning disable IDE0017 // Object initialization can be simplified
#pragma warning disable IDE0028 // Collection initialization can be simplified
#pragma warning disable IDE1006 // Naming rule violation: These words must begin with upper case characters
#pragma warning disable IDE1005 // Delegate invocation can be simplified

namespace SalonDiary.Controls
{
    public partial class NewAppointments : SharedControls.BaseControl
    {
        #region New Appointments

        private Appointments _newAppts;
        private List<Calendar.Appointment> m_Appointments;
        private Appointments _appointments;
        private User _user;
        private Therapist _therapist;


        #endregion New Appointments

        public NewAppointments()
        {
            InitializeComponent();
            m_Appointments = new List<Calendar.Appointment>();
            _appointments = new Appointments();
        }

        #region properties

        /// <summary>
        /// Currently logged on user
        /// </summary>
        public User User
        {
            set
            {
                _user = value;
            }
        }

        #endregion properties

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblNewAppointments.Text = LanguageStrings.AppDiaryNewAppointment;
            colEmployee.Text = LanguageStrings.AppEmployee;
            colDate.Text = LanguageStrings.AppDate;
        }

        #endregion Overridden Methods

        private void dayView2_Click(object sender, EventArgs e)
        {

        }

        #region New Appointments

        /// <summary>
        /// Refreshes new appointments
        /// </summary>
        public override void Refresh()
        {

            lstNewAppointments.Items.Clear();
            _newAppts = Appointments.GetRequested();

            foreach (Library.BOL.Appointments.Appointment appt in _newAppts)
            {
                ListViewItem item = new ListViewItem();
                item.Text = appt.EmployeeName;
                item.SubItems.Add(appt.AppointmentAsDateTime().ToString());
                item.SubItems.Add(appt.ID.ToString());
                lstNewAppointments.Items.Add(item);
            }
        }

        private void lstNewAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstNewAppointments.SelectedItems)
            {
                string id = item.SubItems[2].Text;
                Library.BOL.Appointments.Appointment appt = _newAppts.Find(Convert.ToInt64(id));
                LoadAppointment(appt);
                dayView2.Focus();

                break;
            }
        }

        private void LoadAppointment(Appointment appt)
        {
            _therapist = appt.Therapist;
            dayView2.StartDate = appt.AppointmentDate;
            DateTime start;
            DateTime finish;
            bool AllowTreatments;

            if (_therapist.WorkingOverride(appt.AppointmentAsDateTime(), out start, out finish, out AllowTreatments))
            {
                dayView2.WorkingHourStart = start.Hour;
                dayView2.WorkingMinuteStart = start.Minute;
                dayView2.WorkingHourEnd = finish.Hour;
                dayView2.WorkingMinuteEnd = finish.Minute;
            }
            else
            {
                _therapist.CanWorkOnDay(appt.AppointmentAsDateTime(), appt.AppointmentAsDateTime().AddMinutes(15), false, out AllowTreatments);
                start = Shared.Utilities.DoubleToDate(appt.AppointmentAsDateTime(), _therapist.StartTime);
                finish = Shared.Utilities.DoubleToDate(appt.AppointmentAsDateTime(), _therapist.EndTime);
                dayView2.WorkingHourStart = start.Hour;
                dayView2.WorkingMinuteStart = start.Minute;
                dayView2.WorkingHourEnd = finish.Hour;
                dayView2.WorkingMinuteEnd = finish.Minute;
            }

            m_Appointments.Clear();
            _appointments.Clear();
            List<Calendar.Appointment> m_Apps = new List<Calendar.Appointment>();

            Appointments appointments = Appointments.Get(dayView2.StartDate, _therapist, false);

            foreach (Library.BOL.Appointments.Appointment appointment in appointments)
            {
                Calendar.Appointment calAppt = new Calendar.Appointment();
                calAppt.ID = appointment.ID;
                calAppt.Title = appointment.TreatmentName + StringConstants.LINE_FEED + appointment.UserName;
                calAppt.StartDate = Shared.Utilities.DoubleToDate(appointment.AppointmentDate, appointment.StartTime);
                calAppt.EndDate = Shared.Utilities.DoubleToDate(appointment.AppointmentDate, appointment.StartTime, appointment.Duration);
                UpdateCalendarAppointment(appointment, calAppt);
                m_Appointments.Add(calAppt);
                _appointments.Add(appointment);
            }
        }

        #endregion New Appointments

        private void UpdateCalendarAppointment(Library.BOL.Appointments.Appointment appt, Calendar.Appointment calAppt)
        {
            //can't change past appointments
            if (appt.AppointmentAsDateTime() <= DateTime.Now.AddHours(-DateTime.Now.Hour))
                calAppt.Locked = true;

            calAppt.Title = appt.AppointmentText;

            //set the color
            switch (appt.Status)
            {
                case Enums.AppointmentStatus.Requested: // requested
                    calAppt.Color = ColorTranslator.FromHtml("#0099CC");
                    break;
                case Enums.AppointmentStatus.Confirmed: // confirmed
                    calAppt.Color = ColorTranslator.FromHtml("#66FF66");
                    break;
                case Enums.AppointmentStatus.CancelledByUser: // Cancelled by user
                    calAppt.Color = ColorTranslator.FromHtml("#CC0066");
                    calAppt.TextColor = System.Drawing.Color.White;
                    break;
                case Enums.AppointmentStatus.CancelledByStaff: // cancelled by staff
                    calAppt.Color = ColorTranslator.FromHtml("#CC0066");
                    calAppt.TextColor = System.Drawing.Color.Black;
                    break;
                case Enums.AppointmentStatus.NoShow: // no show
                    calAppt.Color = ColorTranslator.FromHtml("#FF00FF");
                    break;
                case Enums.AppointmentStatus.Completed: // completed
                    calAppt.Color = ColorTranslator.FromHtml("#FF9966");
                    calAppt.Locked = appt.AppointmentType == 0 || appt.AppointmentAsDateTime() <= DateTime.Now;
                    break;
                case Enums.AppointmentStatus.Arrived: // arrived
                    calAppt.Color = ColorTranslator.FromHtml("#FF9900");
                    break;
                default:
                    calAppt.Color = System.Drawing.Color.Gray;
                    break;
            }
        }

        private void dayView2_ResolveAppointments(object sender, Calendar.ResolveAppointmentsEventArgs args)
        {
            List<Calendar.Appointment> m_Apps = new List<Calendar.Appointment>();

            foreach (Calendar.Appointment m_App in m_Appointments)
                m_Apps.Add(m_App);

            args.Appointments = m_Apps;
        }

        private void dayView2_AfterDrawAppointment(object sender, Calendar.AfterDrawAppointmentEventArgs e)
        {
            Library.BOL.Appointments.Appointment appt = _appointments.Find(e.Appointment.ID);

            if (appt != null)
            {
                User user = User.UserGet(appt.UserID);
                ImageAttributes attr = new ImageAttributes();

                if (appt.MasterAppointment == -1 && appt.AppointmentType != 1)
                {
                    int totalImages = 1;

                    if (e.Appointment.Locked)
                    {
                        e.Graphics.DrawImage(imageAppointmentOverlays.Images[7], new Point(e.Rectangle.Right - (totalImages * 26), e.Rectangle.Bottom - 26));
                        ++totalImages;
                    }

                    if (user.Notes != String.Empty)
                    {
                        e.Graphics.DrawImage(imageAppointmentOverlays.Images[0], new Point(e.Rectangle.Right - (totalImages * 26), e.Rectangle.Bottom - 26));
                        ++totalImages;
                    }

                    if (appt.Notes != String.Empty)
                    {
                        e.Graphics.DrawImage(imageAppointmentOverlays.Images[6], new Point(e.Rectangle.Right - (totalImages * 26), e.Rectangle.Bottom - 26));
                        ++totalImages;
                    }

                    switch (appt.AppointmentType)
                    {
                        case 0: //treatment
                            if (user.History.CancelledOrNoShow())
                            {
                                e.Graphics.DrawImage(imageAppointmentOverlays.Images[1], new Point(e.Rectangle.Right - (totalImages * 26), e.Rectangle.Bottom - 26));
                                ++totalImages;
                            }
                            break;
                        case 2: // annual leave
                            e.Graphics.DrawImage(imageAppointmentOverlays.Images[4], new Point(e.Rectangle.Right - (totalImages * 26), e.Rectangle.Bottom - 26));
                            ++totalImages;
                            break;
                        case 3: // training
                            e.Graphics.DrawImage(imageAppointmentOverlays.Images[5], new Point(e.Rectangle.Right - (totalImages * 26), e.Rectangle.Bottom - 26));
                            ++totalImages;
                            break;
                        case 10:
                            e.Graphics.DrawImage(imageAppointmentOverlays.Images[3], new Point(e.Rectangle.Right - (totalImages * 26), e.Rectangle.Bottom - 26));
                            ++totalImages;
                            break;
                        case 11:
                            e.Graphics.DrawImage(imageAppointmentOverlays.Images[2], new Point(e.Rectangle.Right - (totalImages * 26), e.Rectangle.Bottom - 26));
                            ++totalImages;
                            break;
                    }
                }
            }
        }

        private void dayView2_AppointmentMoved(object sender, Calendar.AppointmentEventArgs e)
        {
            Library.BOL.Appointments.Appointment appt = Appointments.Get((int)e.Appointment.ID);
            bool AllowTreatments = true;
            if (!e.Appointment.Locked && appt != null && e.Appointment.StartDate >= DateTime.Now)
            {
                if (!_therapist.CanWorkOnDay(e.Appointment.StartDate, e.Appointment.EndDate, true, out AllowTreatments))
                {
                    ForceRefresh();
                    return;
                }

                if (appt.AppointmentType == 0 && !Appointments.IsMaximumAllowed(AppointmentTreatments.Get(appt.TreatmentID), e.Appointment.StartDate,
                    Shared.Utilities.TimeToDouble(e.Appointment.StartDate.ToString(StringConstants.DIARY_TIME_FORMAT)), (int)appt.ID))
                {
                    ShowError(LanguageStrings.AppDiaryMaxAllowed, LanguageStrings.AppDiaryMaxTreatments);
                    return;
                }

                if (appt.AppointmentType == 0 && !AllowTreatments)
                {
                    ShowError(LanguageStrings.AppDiaryTreatments, 
                        String.Format(LanguageStrings.AppDiaryBookApptFailCurrentDay, _therapist.EmployeeName));
                    return;
                }

                appt.StartTime = Shared.Utilities.TimeToDouble(e.Appointment.StartDate.ToString(StringConstants.DIARY_TIME_FORMAT));
                appt.AppointmentDate = e.Appointment.StartDate;

                double NewStart = appt.StartTime + ((appt.Duration / 15) * .25);

                foreach (Library.BOL.Appointments.Appointment childAppt in appt.ChildAppointments)
                {
                    childAppt.StartTime = NewStart;
                    childAppt.AppointmentDate = appt.AppointmentDate;
                    NewStart = childAppt.StartTime + ((childAppt.Duration / 15) * .25);
                    childAppt.EmployeeID = appt.EmployeeID;
                    childAppt.Save(_user);
                }

                appt.Save(_user);
            }

            Refresh();
            ForceRefresh();
        }

        /// <summary>
        /// Forces a complete refresh of the calendar
        /// </summary>
        public void ForceRefresh()
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                dayView2.Refresh();
                dayView2.Focus();
            }
        }

        private void confirmAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calendar.Appointment appt = dayView2.SelectedAppointment;

            if (appt != null)
            {
                Library.BOL.Appointments.Appointment treat = _appointments.Find(appt.ID);

                if (treat != null)
                {
                    treat.Status = Enums.AppointmentStatus.Confirmed;
                    treat.Save(_user);
                    Refresh();
                    ForceRefresh();
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Calendar.Appointment appt = dayView2.SelectedAppointment;

            if (appt != null)
            {
                Library.BOL.Appointments.Appointment treat = _appointments.Find(appt.ID);

                confirmAppointmentToolStripMenuItem.Enabled = treat.Status == Enums.AppointmentStatus.Requested;
                cancelAppointmentToolStripMenuItem.Enabled = treat.Status == Enums.AppointmentStatus.Requested;
            }
            else
                e.Cancel = true;
        }

        private void cancelAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calendar.Appointment appt = dayView2.SelectedAppointment;
            Library.BOL.Appointments.Appointment treat = _appointments.Find(appt.ID);

            if (treat != null)
            {
                treat.Status = Enums.AppointmentStatus.CancelledByStaff;
                treat.Save(_user);
                Refresh();
                ForceRefresh();
            }
        }

        private void editAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calendar.Appointment appt = dayView2.SelectedAppointment;
            Library.BOL.Appointments.Appointment treat = _appointments.Find(appt.ID);

            if (treat != null)
            {
                DoRaiseEditAppointment(treat);
            }
        }

        private void viewClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calendar.Appointment appt = dayView2.SelectedAppointment;
            Library.BOL.Appointments.Appointment treat = _appointments.Find(appt.ID);

            if (treat != null)
            {
                DoRaiseEditUser(treat.User);
            }
        }

        internal void DoRaiseEditUser(Library.BOL.Users.User User)
        {
            if (EditUser != null)
                EditUser(this, new SalonUserEventArgs(User));
        }

        internal void DoRaiseEditAppointment(Library.BOL.Appointments.Appointment Appointment)
        {
            if (EditAppointment != null)
                EditAppointment(this, new EditAppointmentEventArgs(Appointment, false));
        }

        public delegate void SalonAppointmentEventHandler(object sender, EditAppointmentEventArgs e);
        public delegate void SalonUserEventHandler(object sender, SalonUserEventArgs e);

        public event SalonAppointmentEventHandler EditAppointment;
        public event SalonUserEventHandler EditUser;
    }



}
