using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library.BOL.Appointments;
using Library.BOL.Staff;
using Library.BOL.Therapists;

namespace POS.Staff.Forms
{
    public partial class StaffSickSelectNewAppointment : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private bool _finished = false;
        private NewAppointmentOptions _options;
        Appointment _appointment;

        #endregion Private Members

        #region Constructors

        public StaffSickSelectNewAppointment()
        {
            InitializeComponent();
        }

        public StaffSickSelectNewAppointment(Appointment appt)
            : this()
        {
            _appointment = appt;

            
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.StaffSickSelectAppointment;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppAppointmentSelectNewDateTime;
            
            lblInformation.Text = _finished ? LanguageStrings.AppDiarySelectDesiredAppointment : 
                LanguageStrings.AddDiarySearchingForAppointments;

            columnHeaderDate.Text = LanguageStrings.Date;
            columnHeaderTherapist.Text = LanguageStrings.AppSalonTherapist;
            columnHeaderTime.Text = LanguageStrings.AppTime;

            btnOK.Text = LanguageStrings.AppMenuButtonOK;
        }

        #endregion Overridden Methods

        #region Properties

        public Therapist newTherapist { get; private set; }

        public DateTime newDate { get; private set; }

        public double newTime { get; private set; }

        #endregion Properties

        #region Private Methods

        private void SearchAppointments()
        {
            _options = new NewAppointmentOptions();
            _options.MaximumAppointments = 10;
            _options.AppointmentFound += _options_AppointmentFound;
            _options.AppointmentSearchFinished += _options_AppointmentSearchFinished;

            AppointmentTreatment treat = AppointmentTreatments.Get(_appointment.TreatmentID);

            if (treat != null)
                _options.Treatments.Add(treat);

            foreach (Appointment appt in _appointment.ChildAppointments)
                _options.Treatments.Add(AppointmentTreatments.Get(appt.TreatmentID));

            Therapists allTherapists = Therapists.Get();

            foreach (Therapist ther in allTherapists)
            {
                if (ther.Treatments.Find(_appointment.TreatmentName) != null)
                    _options.Staff.Add(ther);
            }

            _options.PreferredStartTime = _appointment.StartTime;
            _options.PreferredDate = DateTime.Now.Date;
            _options.MaximumDays = 30;

            lvAppointments.Items.Clear();
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            _options.FindAppointments();
        }


        private void _options_AppointmentSearchFinished(object sender, EventArgs e)
        {
            lblInformation.Text = LanguageStrings.AppDiarySelectDesiredAppointment;
            this.Cursor = Cursors.Arrow;
            _finished = true;
        }

        private void _options_AppointmentFound(object sender, NewWizardAppointmentEventArgs e)
        {
            ListViewItem item = new ListViewItem();
            
            item.Text = e.Therapist.EmployeeName;
            item.SubItems.Add(e.Date.ToShortDateString());
            item.SubItems.Add(Shared.Utilities.DoubleToTime(e.StartTime));
            item.Tag = e;
            lvAppointments.Items.Add(item);

            Application.DoEvents();
        }

        private void StaffSickSelectNewAppointment_Shown(object sender, EventArgs e)
        {
            SearchAppointments();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvAppointments.SelectedItems.Count == 0)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppDiaryNoApptSelected);
                return;
            }

            NewWizardAppointmentEventArgs args = (NewWizardAppointmentEventArgs)lvAppointments.SelectedItems[0].Tag;
            newTherapist = args.Therapist;
            newDate = args.Date;
            newTime = args.StartTime;

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        #endregion Private Methods
    }
}
