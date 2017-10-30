using System;
using System.Globalization;
using System.Windows.Forms;
using POS.Base.Classes;

namespace POS.TrainingSchedule.Forms
{
    public partial class TrainingScheduleForm : Base.Controls.BaseTabControl
    {
        public TrainingScheduleForm()
        {
            InitializeComponent();

            if (!AppController.ApplicationRunning)
                return;

            trainingDiary1.CurrentUser = AppController.ApplicationController.GetUser;
            trainingDiary1.Date = DateTime.Now;
            trainingDiary1.Initialise(AppController.ApplicationController.AllAppointments);
            AppController.ApplicationController.ReplicationComplete += User_ReplicationComplete;
        }

        public override string GetHelpTopic()
        {
            return (HelpTopics.TrainingSchedule);
        }

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

        }

        private void User_ReplicationComplete(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                EventHandler eh = new EventHandler(User_ReplicationComplete);
                this.Invoke(eh, new object[] { sender, e });
            }
            else
            {
                trainingDiary1.ForceRefresh(true);
            }
        }

        private void trainingDiary1_AppointmentEdit(object sender, SalonDiary.Controls.EditAppointmentEventArgs e)
        {
            EditTrainingAppointment form = new EditTrainingAppointment(e.Appointment, e.IsLocked);
            try
            {
                form.ShowDialog(this);
            }
            finally
            {
                form.Dispose();
                form = null;
            }
        }

        private void trainingDiary1_ScheduleNewTrainingDays(object sender, EventArgs e)
        {
            NewTrainingCourseWizard wizard = new NewTrainingCourseWizard();
            try
            {
                wizard.ShowDialog(this);
                trainingDiary1.LoadAppointments(AppController.ApplicationController.AllAppointments);
                trainingDiary1.ForceRefresh(true);
            }
            finally
            {
                wizard.Dispose();
                wizard = null;
            }
        }

        private void TrainingSchedule_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppController.LocalSettings.TrainingDiaryTop = Top;
            AppController.LocalSettings.TrainingDiaryLeft = Left;
            AppController.LocalSettings.TrainingDiaryWidth = Width;
            AppController.LocalSettings.TrainingDiaryHeight = Height;
        }
    }
}
