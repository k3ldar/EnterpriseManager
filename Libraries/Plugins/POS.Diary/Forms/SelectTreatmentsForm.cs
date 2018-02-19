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
 *  File: SelectTreatmentsForm.cs
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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library.BOL.Treatments;
using Library.BOL.Therapists;
using Library.BOL.Users;
using Library.BOL.Appointments;

namespace POS.Diary.Forms
{
    public partial class SelectTreatmentsForm : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private Therapist _therapist;
        private User _user;
        private AppointmentTreatments _currentTreatments;
        private AppointmentTreatments _therapistTreatments;

        #endregion Private Members

        #region Constructors

        public SelectTreatmentsForm(Therapist therapist, User user, AppointmentTreatments currentTreatments)
        {
            _therapist = therapist;
            _user = user;
            _currentTreatments = currentTreatments;
            _therapistTreatments = _therapist.Treatments;

            InitializeComponent();

            LoadTherapistTreatments();
            LoadCurrentTreatments();

            if (_user == null)
                tabControlTreatments.TabPages.Remove(tabPagePreviousTreatments);
            else
                LoadUserTreatments();
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            tabControlTreatments_SelectedIndexChanged(this, e);
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppTreatmentSelect;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;

            lblFilter.Text = LanguageStrings.AppFilter;
            lblSelectedTreatments.Text = LanguageStrings.AppTreatmentsSelected;

            tabPageAllTreatments.Text = LanguageStrings.AppTreatmentsAll;
            tabPagePreviousTreatments.Text = LanguageStrings.AppTreatmentsPrevious;
        }

        #endregion Overridde Methods

        #region Private Methods

        private void LoadCurrentTreatments()
        {
            lstSelected.Items.Clear();

            foreach (AppointmentTreatment treat in _currentTreatments)
                lstSelected.Items.Add(treat);
        }

        private void LoadUserTreatments()
        {
            AppointmentTreatments prevTreats = AppointmentTreatments.Get(_user, true);

            foreach (AppointmentTreatment treat in prevTreats)
            {
                if (treat.IsActive)
                    lstPreviousTreatments.Items.Add(treat);
            }

            if (prevTreats.Count == 0)
                tabControlTreatments.TabPages.Remove(tabPagePreviousTreatments);
        }

        private void LoadTherapistTreatments()
        {
            lstAllTreatments.Items.Clear();

            foreach (AppointmentTreatment treat in _therapistTreatments)
            {
                if (treat.IsActive)
                    lstAllTreatments.Items.Add(treat);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _currentTreatments.Clear();

            foreach (AppointmentTreatment treat in lstSelected.Items)
                _currentTreatments.Add(treat);

            if (_currentTreatments.Count == 0)
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            else
                DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            lstAllTreatments.Items.Clear();

            foreach (AppointmentTreatment treat in _therapistTreatments)
            {
                if (treat.IsActive)
                    if (treat.Name.ToLower().Contains(txtFilter.Text.ToLower()) || String.IsNullOrEmpty(txtFilter.Text))
                        lstAllTreatments.Items.Add(treat);
            }
        }

        private void lstAllTreatments_Format(object sender, ListControlConvertEventArgs e)
        {
            AppointmentTreatment treat = (AppointmentTreatment)e.ListItem;

            if (sender == lstPreviousTreatments)
                e.Value = String.Format(LanguageStrings.AppTreatmentsUserPrevious, 
                    treat.Name, treat.LastTreatedBy, treat.LastTreated.ToShortDateString());
            else
                e.Value = treat.Name;
        }

        private void lstSelected_DoubleClick(object sender, EventArgs e)
        {
            lstSelected.Items.Remove(lstSelected.SelectedItem);
        }

        private void lstAllTreatments_DoubleClick(object sender, EventArgs e)
        {
            AppointmentTreatment selTreat = (AppointmentTreatment)lstAllTreatments.SelectedItem;

            if (selTreat == null)
                return;

            foreach (AppointmentTreatment treat in lstSelected.Items)
            {
                if (selTreat.ID == treat.ID)
                    return;
            }

            if (lstAllTreatments.SelectedItem != null)
                lstSelected.Items.Add(lstAllTreatments.SelectedItem);
        }

        private void lstPreviousTreatments_DoubleClick(object sender, EventArgs e)
        {
            AppointmentTreatment selTreat = (AppointmentTreatment)lstPreviousTreatments.SelectedItem;

            if (selTreat == null)
                return;

            foreach (AppointmentTreatment treat in lstSelected.Items)
            {
                if (selTreat.ID == treat.ID)
                    return;
            }

            lstSelected.Items.Add(lstPreviousTreatments.SelectedItem);
        }

        private void tabControlTreatments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlTreatments.SelectedTab == tabPageAllTreatments)
                HelpTopic = POS.Base.Classes.HelpTopics.DiarySelectTreatmentAll;
            else if (tabControlTreatments.SelectedTab == tabPagePreviousTreatments)
                HelpTopic = POS.Base.Classes.HelpTopics.DiarySelectTreatmentPrevious;
        }

        #endregion Private Methods
    }
}
