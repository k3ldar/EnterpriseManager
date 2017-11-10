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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: SalonAppointment.cs
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

using Library.Utils;
using Library.BOL.Therapists;
using Library.BOL.Appointments;

using Languages;
using POS.Base.Classes;

namespace POS.Diary.Controls
{
    public partial class SalonAppointment : UserControl
    {
        #region Private Members

        private Appointment _appointment;
        private DateTime _date;
        private Therapist _therapist;
        private AppointmentTreatment _treatment;
        private double _time;

        #endregion Private Members

        #region Constructors

        public SalonAppointment(AppointmentTreatment treatment, Therapist therapist, DateTime date, 
            double time, bool AllowDelete, Appointment appointment)
        {
            _appointment = appointment;
            _therapist = therapist;
            _date = date;
            _treatment = treatment;
            _time = time;

            InitializeComponent();

            LoadTherapists();
            cmbTreatments.Text = _treatment.Name;
            pictureDelete.Visible = AllowDelete;
            cmbTreatments.Enabled = AllowDelete;
            cmbStartTime.Enabled = AllowDelete;
            cmbTherapist.Enabled = AllowDelete;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Returns the current appointment (if it exists)
        /// </summary>
        public Appointment Appointment
        {
            get
            {
                return (_appointment);
            }
        }

        public Therapist Therapist
        {
            get
            {
                return (_therapist);
            }
        }

        public AppointmentTreatment Treatment
        {
            get
            {
                return ((AppointmentTreatment)cmbTreatments.SelectedItem);
            }
        }

        public double StartTime
        {
            get
            {
                return ((double)cmbStartTime.SelectedItem);
            }
        }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Delete's the current appointment
        /// </summary>
        public void DeleteAppointment()
        {
            RaiseDeleteAppointment();
        }

        #endregion Public Methods

        #region Private Methods

        private void LoadTherapists()
        {
            cmbTherapist.Items.Clear();
            Therapists therapists = Therapists.Get();

            foreach (Therapist therapist in therapists)
            {
                int idx = cmbTherapist.Items.Add(therapist);

                if (_therapist != null && therapist.EmployeeID == _therapist.EmployeeID)
                {
                    cmbTherapist.SelectedIndex = idx;
                    LoadTherapistTimes(therapist);
                    LoadTherapistTreatments(therapist);
                    _therapist = therapist;
                }
            }
        }

        private void LoadTherapistTimes(Therapist therapist)
        {
            cmbStartTime.Items.Clear();
            cmbStartTime.Items.Add((object)0.0);

            //todo look at overriden working days
            for (Double t = 8.0; t <= 21.75; t = t + 0.25)
            {
                int idx = cmbStartTime.Items.Add(t);

                if (_time == t)
                    cmbStartTime.SelectedIndex = idx;
            }

            if (cmbStartTime.SelectedIndex == -1)
                cmbStartTime.SelectedIndex = 0;
        }

        private void LoadTherapistTreatments(Therapist therapist)
        {
            cmbTreatments.ValueMember = StringConstants.DATA_SOURCE_COLUMN_ID;
            cmbTreatments.DisplayMember = StringConstants.DATA_SOURCE_COLUMN_NAME;
            cmbTreatments.DataSource = therapist.Treatments;
        }

        private void cmbTreatments_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (cmbTreatments.DroppedDown)
                {
                    cmbTreatments.DroppedDown = false;
                    e.Handled = true;
                }
            }
        }

        private void cmbTherapist_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currTreatment = cmbTreatments.Text;
            Therapist therapist = (Therapist)cmbTherapist.SelectedItem;
            LoadTherapistTimes(therapist);
            LoadTherapistTreatments(therapist);
            _therapist = therapist;
            cmbTreatments.Text = currTreatment;
        }

        private void cmbTherapist_Format(object sender, ListControlConvertEventArgs e)
        {
            Therapist therapist = (Therapist)e.ListItem;
            e.Value = therapist.EmployeeName;
        }

        private void cmbStartTime_Format(object sender, ListControlConvertEventArgs e)
        {
            double t = (double)e.ListItem;

            if (t == 0.0)
                e.Value = LanguageStrings.AppAutomatic;
            else
                e.Value = Shared.Utilities.DoubleToTime(t);
        }

        private void RaiseDeleteAppointment()
        {
            if (Delete != null)
                Delete(this, EventArgs.Empty);
        }

        private void pictureDelete_Click(object sender, EventArgs e)
        {
            RaiseDeleteAppointment();
        }

        #endregion Private Methods

        #region Events

        public event DeleteAppointmentHandler Delete;

        #endregion Events

        #region Delegates

        public delegate void DeleteAppointmentHandler(object sender, EventArgs e);

        #endregion Delegates
    }
}
