using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using SalonDiary.Classes;
using Languages;
using Library.BOL.Appointments;
using Library.BOL.Therapists;
using SharedControls.WizardBase;


namespace SalonDiary.Controls.Wizards.WaitingListWizard
{
    public partial class Summary : BaseWizardPage
    {
        #region Private Members

        private WaitingListWizardOptions _options;

        private NewAppointmentOptionsDiary _appointFindOptions;

        #endregion Private Members

        #region Constructors

        public Summary()
        {
            InitializeComponent();
            _appointFindOptions = new NewAppointmentOptionsDiary();
            _appointFindOptions.AppointmentFound += _appointFindOptions_AppointmentFound;
            _appointFindOptions.AppointmentSearchFinished += _appointFindOptions_AppointmentSearchFinished;
        }

        public Summary(WaitingListWizardOptions options)
            : this()
        {
            _options = options;
        }

        #endregion Constructors

        #region Overridden Methods

        public override bool BeforeFinish()
        {
            if (lvAppointments.SelectedItems.Count > 0)
            {
                ListViewItem item = lvAppointments.SelectedItems[0];

                if (ShowQuestion(LanguageStrings.AppNewAppointment, 
                    String.Format(LanguageStrings.AppWaitListCreateAppointment, 
                        _options.WaitingListItem.Customer.UserName, 
                        ((Therapist)item.Tag).EmployeeName,
                        item.SubItems[1].Text, 
                        item.SubItems[2].Text)))
                {
                    // create appointment
                    Therapist selTherapist = (Therapist)item.Tag;
                    Int64 masterID = -1;
                    double startTime = Shared.Utilities.TimeToDouble(item.SubItems[2].Text);

                    foreach (AppointmentTreatment treat in _options.WaitingListItem.Treatments)
                    {
                        Appointment appt = new Appointment(-1, selTherapist.EmployeeID, Convert.ToDateTime(item.SubItems[1].Text),
                            startTime, treat.Duration, Library.Enums.AppointmentStatus.Requested,
                            0, treat.ID, treat.Name, _options.WaitingListItem.UserID, _options.WaitingListItem.Customer.UserName,
                            String.Empty, masterID, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));
                        Library.BOL.Appointments.Appointments.Create(appt, _options.WaitingListItem.Customer);

                        //get master id for next appointment (if there is one)
                        if (masterID == -1)
                            masterID = appt.ID;

                        //add the duration to the time
                        startTime += ((appt.Duration / 15) * .25);
                    }

                    if (_options.WaitingListItem.ID != -1)
                        _options.WaitingListItem.Delete();

                    return (true);
                }
            }

            WaitingLists.InsertUpdate(_options.WaitingListItem);

            return (true);
        }

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblDescription.Text = LanguageStrings.AppWaitListSelectApptDescription;

            columnHeaderDate.Text = LanguageStrings.Date;
            columnHeaderTherapist.Text = LanguageStrings.AppSalonTherapist;
            columnHeaderTime.Text = LanguageStrings.AppTime;
        }

        public override void PageShown()
        {
            _appointFindOptions.Diary = _options.Diary;
            _appointFindOptions.MaximumDays = 30;
            _appointFindOptions.PreferredDate = _options.WaitingListItem.PreferredDate;
            _appointFindOptions.PreferredStartTime = _options.WaitingListItem.PreferredTime == 0.0 ? 9.0 : 
                _options.WaitingListItem.PreferredTime;
            _appointFindOptions.Staff.Clear();

            Therapists staffMembers = Therapists.Get();

            if (_options.WaitingListItem.StaffID == -1)
            {
                foreach (Therapist therapist in staffMembers)
                {
                    // can the therapist do the treatments
                    if (!therapist.CompareTreatments(_options.WaitingListItem.Treatments))
                        continue;

                    _appointFindOptions.Staff.Add(therapist);
                }
            }
            else
            {
                _appointFindOptions.Staff.Add(Therapist.Get(_options.WaitingListItem.StaffID));
            }

            _appointFindOptions.Treatments = _options.WaitingListItem.Treatments;
            lvAppointments.Items.Clear();
            _appointFindOptions.FindAppointments();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void _appointFindOptions_AppointmentSearchFinished(object sender, EventArgs e)
        {
            
        }

        private void _appointFindOptions_AppointmentFound(object sender, NewWizardAppointmentEventArgs e)
        {
            ListViewItem item = new ListViewItem();
            item.Text = e.Therapist.EmployeeName;
            item.SubItems.Add(e.Date.ToShortDateString());
            item.SubItems.Add(Shared.Utilities.DoubleToTime(e.StartTime));
            item.Tag = e.Therapist;
            lvAppointments.Items.Add(item);


            Application.DoEvents();
        }

        #endregion Private Methods
    }
}
