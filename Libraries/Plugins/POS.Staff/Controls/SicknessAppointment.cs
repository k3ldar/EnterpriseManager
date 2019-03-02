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
 *  File: SicknessAppointment.cs
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
using SharedBase.BOL.Therapists;

namespace POS.Staff.Controls
{
    public partial class SicknessAppointment : UserControl
    {
        #region Consctructors

        public SicknessAppointment()
        {
            InitializeComponent();
        }

        public SicknessAppointment(Appointment appt)
            : this()
        {
            Appt = appt;

            lblCustomerContact.Text = String.Format(LanguageStrings.AppSickCustomerContact, 
                appt.User.Telephone);
            lblCustomerName.Text = String.Format(LanguageStrings.AppSickCustomerName,
                appt.User.UserName);
            lblReschedule.Text = String.Format(LanguageStrings.AppSickReschedule,
                LanguageStrings.AppSickRescheduleNotSet);
            lblTreatment.Text = String.Format(LanguageStrings.AppSickCustomerTreatment,
                appt.TreatmentName);

            rbCancel.Text = LanguageStrings.AppCancel;
            rbReschedule.Text = LanguageStrings.AppReschedule;
            btnSelect.Text = LanguageStrings.AppMenuButtonSelect;

            if (appt.AppointmentType != 0)
            {
                rbCancel.Checked = true;
                rbReschedule.Enabled = false;
            }
        }

        #endregion Constructors

        #region Properties

        public Appointment Appt { get; set; }

        public bool Cancelled { get; set; }

        public Therapist NewTherapist { get; set; }

        public DateTime NewDateTime { get; set; }

        public double NewTime { get; set; }

        public bool IsProcessed
        {
            get
            {
                if (Cancelled)
                    return (true);

                return (NewTherapist != null) ;
            }
        }
        #endregion Proerties

        #region Private Methods

        private void rbReschedule_CheckedChanged(object sender, EventArgs e)
        {
            btnSelect.Enabled = true;
            Cancelled = false;
            lblReschedule.Text = String.Format(LanguageStrings.AppSickReschedule,
                LanguageStrings.AppSickRescheduleNotSet);
        }

        private void rbCancel_CheckedChanged(object sender, EventArgs e)
        {
            btnSelect.Enabled = false;
            Cancelled = true;
            lblReschedule.Text = String.Format(LanguageStrings.AppSickReschedule,
                LanguageStrings.AppCancelled);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Forms.StaffSickSelectNewAppointment frm = new Forms.StaffSickSelectNewAppointment(Appt);
            try
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    NewDateTime = frm.newDate;
                    NewTherapist = frm.newTherapist;
                    NewTime = frm.newTime;
                }
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }
        }

        #endregion Private Methods
    }
}
