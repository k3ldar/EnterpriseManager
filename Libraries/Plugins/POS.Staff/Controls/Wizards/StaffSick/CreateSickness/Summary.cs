using System;

using Languages;

using Library;
using Library.BOL.Appointments;
using Library.BOL.Staff;
using Library.BOL.Therapists;

using POS.Staff.Classes;

#pragma warning disable IDE0018 // Inline variable declaration

namespace POS.Staff.Controls.Wizards.StaffSick.CreateSickness
{
    public partial class Summary : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private SicknessWizardSettings _returnToWork;

        #endregion Private Members

        #region Constructors

        public Summary()
        {
            InitializeComponent();
        }

        public Summary(SicknessWizardSettings returnToWork)
            : this()
        {
            _returnToWork = returnToWork;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblCancelAppointments.Text = String.Format(LanguageStrings.AppSicknessCancelledAppointments,
                _returnToWork.CancelledCount);
            lblRescheduledAppointments.Text = String.Format(LanguageStrings.AppSicknessRescheduledAppointments,
                _returnToWork.RescheduledCount);
            lblStaffName.Text = String.Format(LanguageStrings.AppStaffNameSelected, 
                _returnToWork.Staff.UserRecord.UserName);
            lblSummary.Text = LanguageStrings.AppSicknessAddSummary;
        }

        public override bool SkipPage()
        {
            
            return (false);
        }

        public override void PageShown()
        {
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.StaffSickStep4;
        }

        public override bool BeforeFinish()
        {
            foreach (SicknessAppointment appt in _returnToWork.AppointmentUpdates)
            {
                if (appt.Cancelled)
                {
                    appt.Appt.Status = Library.Enums.AppointmentStatus.CancelledByStaff;
                    appt.Appt.Notes += String.Format(LanguageStrings.AppSicknessAppointmentNotesCancel,
                        POS.Base.Classes.AppController.ActiveUser.UserName);
                }
                else
                {
                    appt.Appt.Notes += String.Format(LanguageStrings.AppSicknessAppointmentNotesMoved,
                        POS.Base.Classes.AppController.ActiveUser.UserName);
                    appt.Appt.UpdateTherapist(appt.NewTherapist);
                    appt.Appt.AppointmentDate = appt.NewDateTime;
                    appt.Appt.StartTime = appt.NewTime;
                }

                appt.Appt.Save(POS.Base.Classes.AppController.ActiveUser);
            }

            CreateSickAppointment();

            if (!_returnToWork.Continuation)
            {
                StaffSickRecords.Create(_returnToWork.Staff.UserID, _returnToWork.DateFrom,
                    _returnToWork.DateNotified, String.Empty, _returnToWork.Reason, _returnToWork.Certificate,
                    _returnToWork.PreBooked, POS.Base.Classes.AppController.ActiveUser.ID);
            }

            return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void CreateSickAppointment()
        {
            double start;
            double finish;
            int duration;

            Therapist ther = Therapists.Get(_returnToWork.Staff.UserID);
            Appointment appt = null;
            string notes = String.Format(LanguageStrings.AppSicknessAppointmentSickCreated,
                POS.Base.Classes.AppController.ActiveUser.UserName);

            if (ther.WorkingDay(_returnToWork.DateFrom, out start, out finish, out duration))
            {
                appt = new Appointment(-1, ther.EmployeeID, _returnToWork.DateFrom, start, duration, 
                    Enums.AppointmentStatus.Confirmed, 8, 0, notes, ther.EmployeeID, 
                    ther.EmployeeName, String.Empty, -1, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));
            }
            else
            {
                appt = new Appointment(-1, ther.EmployeeID, _returnToWork.DateFrom, start, duration,
                    Enums.AppointmentStatus.Confirmed, 8, 0, notes, ther.EmployeeID,
                    ther.EmployeeName, String.Empty, -1, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));
            }

            appt.Notes = String.Format(LanguageStrings.AppDiaryBookedByOn,
                POS.Base.Classes.AppController.ActiveUser.UserName, DateTime.Now.ToShortDateString(), notes);

            appt.Save(POS.Base.Classes.AppController.ActiveUser);
        }

        #endregion Private Methods


    }
}
