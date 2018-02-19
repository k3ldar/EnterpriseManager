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
 *  File: TrainingScheduleForm.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
