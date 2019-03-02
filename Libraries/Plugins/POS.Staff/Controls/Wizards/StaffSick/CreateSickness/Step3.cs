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
 *  File: Step3.cs
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
using System.Text;
using System.Windows.Forms;

using Languages;
using SharedBase.BOL.Appointments;
using SharedBase.BOL.Staff;

using POS.Staff.Classes;

namespace POS.Staff.Controls.Wizards.StaffSick.CreateSickness
{
    public partial class Step3 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private SicknessWizardSettings _returnToWork;
        private Appointments _staffAppointments;

        #endregion Private Members

        #region Constructors

        public Step3()
        {
            InitializeComponent();
        }

        public Step3(SicknessWizardSettings returnToWork)
            : this()
        {
            _returnToWork = returnToWork;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblAppointments.Text = String.Format(LanguageStrings.AppStaffSickAppointments,
                _returnToWork.Staff.UserRecord.FirstName);
        }

        public override bool SkipPage()
        {
            MainWizardForm.Cursor = Cursors.WaitCursor;
            try
            {
                _staffAppointments = Appointments.Get(_returnToWork.DateFrom, _returnToWork.Staff.UserID);

                foreach (Appointment appt in _staffAppointments)
                {
                    if (appt.AppointmentAsDateTime() < DateTime.Now || appt.Status != SharedBase.Enums.AppointmentStatus.Confirmed)
                        continue;

                    switch (appt.Status)
                    {
                        case SharedBase.Enums.AppointmentStatus.Requested:
                        case SharedBase.Enums.AppointmentStatus.Confirmed:
                            return (false);
                    }
                }
            }
            finally
            {
                MainWizardForm.Cursor = Cursors.Arrow;
            }
                
            return (true);
        }

        public override void PageShown()
        {
            pnlAppointments.Controls.Clear();

            foreach (Appointment appt in _staffAppointments)
            {
                SicknessAppointment apptOption = new SicknessAppointment(appt);
                pnlAppointments.Controls.Add(apptOption);
            }

            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.StaffSickStep3;
        }

        public override bool NextClicked()
        {
            _returnToWork.AppointmentUpdates.Clear();

            foreach (SicknessAppointment update in pnlAppointments.Controls)
            {
                if (!update.IsProcessed)
                {
                    ShowError(LanguageStrings.Error, LanguageStrings.AppSicknessAppointmentUpdate);
                    return (false);
                }

                _returnToWork.AppointmentUpdates.Add(update);
            }

            return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        #endregion Private Methods
    }
}
