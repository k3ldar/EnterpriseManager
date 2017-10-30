using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using SalonDiary.Classes;
using Languages;
using Library.BOL.Therapists;
using Library.BOL.Appointments;
using Library.BOL.Users;
using SharedControls.WizardBase;

namespace SalonDiary.Controls.Wizards.NewAppointmentWizard
{
    public partial class Step3 : BaseWizardPage
    {
        #region Private Members

        private bool _finished = false;
        private NewAppointmentOptionsDiary _options;

        #endregion Private Members

        #region Constructors

        public Step3(NewAppointmentOptionsDiary options)
        {
            InitializeComponent();
            _options = options;
            _options.AppointmentFound += _options_AppointmentFound;
            _options.AppointmentSearchFinished += _options_AppointmentSearchFinished;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            cbShowInDiary.Text = LanguageStrings.AppDiaryShowWhenFinished;
            lblStatus.Text = _finished ? LanguageStrings.AppDiarySelectDesiredAppointment : LanguageStrings.AddDiarySearchingForAppointments;

            columnHeaderDate.Text = LanguageStrings.Date;
            columnHeaderTherapist.Text = LanguageStrings.AppSalonTherapist;
            columnHeaderTime.Text = LanguageStrings.AppTime;
        }

        public override void PageShown()
        {
            lvAppointments.Items.Clear();
            _finished = false;
            this.MainWizardForm.Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            _options.FindAppointments();
        }

        public override bool BeforeFinish()
        {
            if (!_finished)
            {
                ShowInformation(LanguageStrings.NewAppointment, LanguageStrings.AppDiarySearching);
                return (false);
            }

            if (lvAppointments.SelectedItems.Count == 0)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppDiarySelectAppointment);
                return (false);
            }

            User selectedUser = _options.Diary.RaiseSelectUser();

            if (selectedUser == null)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppUserSelect);
                return (false);
            }

            ListViewItem selItem = lvAppointments.SelectedItems[0];
            Therapist selTherapist = (Therapist)selItem.Tag;
            Int64 masterID = -1;
            double startTime = Shared.Utilities.TimeToDouble(selItem.SubItems[2].Text);

            foreach (AppointmentTreatment treat in _options.Treatments)
            {
                Appointment appt = new Appointment(-1, selTherapist.EmployeeID, Convert.ToDateTime(selItem.SubItems[1].Text), 
                    startTime, treat.Duration, Library.Enums.AppointmentStatus.Requested,
                    0, treat.ID, treat.Name, selectedUser.ID, selectedUser.UserName, String.Empty, 
                    masterID, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));
                Library.BOL.Appointments.Appointments.Create(appt, selectedUser);

                //get master id for next appointment (if there is one)
                if (masterID == -1)
                    masterID = appt.ID;

                //add the duration to the time
                startTime += ((appt.Duration / 15) * .25);
            }


            if (cbShowInDiary.Checked && _options.Diary != null)
                _options.Diary.Date = Convert.ToDateTime(selItem.SubItems[1].Text);

            return (_finished);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void _options_AppointmentSearchFinished(object sender, EventArgs e)
        {
            lblStatus.Text = LanguageStrings.AppDiarySelectDesiredAppointment;
            this.MainWizardForm.Cursor = Cursors.Arrow;
            _finished = true;
        }

        private void _options_AppointmentFound(object sender, NewWizardAppointmentEventArgs e)
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
