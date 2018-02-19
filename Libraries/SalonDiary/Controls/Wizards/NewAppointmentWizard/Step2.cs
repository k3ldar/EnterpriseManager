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
 *  File: Step2.cs
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

using SalonDiary.Classes;
using Languages;
using Library.BOL.Therapists;
using Library.BOL.Appointments;
using SharedControls.WizardBase;

namespace SalonDiary.Controls.Wizards.NewAppointmentWizard
{
    public partial class Step2 : BaseWizardPage
    {
        #region Private Members

        private NewAppointmentOptionsDiary _options;

        #endregion Private Members

        #region Constructors

        public Step2(NewAppointmentOptionsDiary options)
        {
            InitializeComponent();
            _options = options;

            monthCalendar1.MinDate = DateTime.Now;

            LoadStartTimes();
            LoadTherapists();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblPreferredDate.Text = LanguageStrings.PreferredDate;
            lblPreferredStartTime.Text = LanguageStrings.PreferredStartTime;
            lblPreferredTherapist.Text = LanguageStrings.PreferredTherapists;
        }

        public override bool NextClicked()
        {
            _options.Staff.Clear();

            Therapist therapist = (Therapist)cmbTherapist.Items[cmbTherapist.SelectedIndex];

            if (therapist.EmployeeID == -1)
            {
                foreach (Therapist ther in cmbTherapist.Items)
                {
                    if (ther.EmployeeID != -1)
                    {
                        _options.Staff.Add(ther);
                    }
                }
            }
            else
            {
                _options.Staff.Add(therapist);
            }

            _options.PreferredDate = monthCalendar1.SelectionStart;
            _options.PreferredStartTime = Shared.Utilities.TimeToDouble((string)cmbStartTime.Items[cmbStartTime.SelectedIndex]);

            return base.NextClicked();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadTherapists()
        {
            cmbTherapist.Items.Clear();
            Therapists therapists = Therapists.Get();

            cmbTherapist.Items.Add(new Therapist(-1, Languages.LanguageStrings.AnyTherapist));

            foreach (Therapist ther in therapists)
            {
                if (ther.HasTreatments)
                {
                    if (ther.CompareTreatments(_options.Treatments))
                    {
                        cmbTherapist.Items.Add(ther);
                    }
                }
            }

            cmbTherapist.SelectedIndex = 0;
        }

        private void LoadStartTimes()
        {
            cmbStartTime.Items.Clear();

            for (Double t = 9.0; t <= 20.00; t = t + 0.25)
            {
                cmbStartTime.Items.Add(Shared.Utilities.DoubleToTime(t));
            }

            cmbStartTime.SelectedIndex = 0;
        }

        private void cmbTherapist_Format(object sender, ListControlConvertEventArgs e)
        {
            Therapist therapist = (Therapist)e.ListItem;
            e.Value = therapist.EmployeeName;
        }

        #endregion Private Methods
    }
}
