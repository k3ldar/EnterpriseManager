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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: AdminSalonTreatmentEdit.cs
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
using System.IO;
using System.Text;
using System.Windows.Forms;

using Languages;

using SharedBase;
using SharedBase.Utils;
using SharedBase.BOL.Users;
using SharedBase.BOL.Therapists;
using SharedBase.BOL.Appointments;

using POS.Base.Classes;


using POS.Base;

namespace POS.Administration.Forms.Treatments
{
    public partial class AdminSalonTreatmentEdit : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private WebsiteAdministration _admin;
        private AppointmentTreatment _treatment;

        #endregion Private Members

        #region Constructors

        public AdminSalonTreatmentEdit(WebsiteAdministration admin, AppointmentTreatment treatment)
        {
            _admin = admin;
            _treatment = treatment;

            InitializeComponent();

            LoadImages();
            LoadTreatmentLengths();
            SetTreatmentLength();
            txtName.Text = _treatment.Name;
            txtCost.Text = _treatment.Cost.ToString();
            udMaximum.Value = _treatment.MaximumTreatments;
            cbactive.Checked = _treatment.IsActive;
            cbFollowOn.Checked = _treatment.RequireFollowOn;

            cmbImages.SelectedIndex = cmbImages.Items.IndexOf(_treatment.Image);

            LoadTherapists();
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            tabControl1_SelectedIndexChanged(this, e);
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppSalonTreatmentEditAdmin;

            lblAssignedTherapists.Text = LanguageStrings.AppSalonTreatmentAssignedTherapists;
            lblAvailableTherapists.Text = LanguageStrings.AppSalonTreatmentAvailableTherapists;
            lblCost.Text = LanguageStrings.AppCost;
            lblLength.Text = LanguageStrings.AppSalonTreatmentLength;
            lblMaxAvailable.Text = LanguageStrings.AppSalonTreatmentMaximumAvailable;
            lblTreatmentName.Text = LanguageStrings.AppSalonTreatmentName;

            tabPageSettings.Text = LanguageStrings.AppSettings;
            tabPageStaff.Text = LanguageStrings.AppStaffMembers;
            tabPageImage.Text = LanguageStrings.Picture;

            btnAdd.Text = LanguageStrings.AppMenuButtonAdd;
            btnRemove.Text = LanguageStrings.AppMenuButtonRemove;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadTherapists()
        {
            Therapists therapists = Therapists.Get();

            foreach (Therapist therapist in therapists)
            {
                if (_treatment.TherapistAssigned(therapist))
                    lstAssigned.Items.Add(therapist);
                else
                    lstAvailable.Items.Add(therapist);
            }
        }

        private void LoadTreatmentLengths()
        {
            cmbTreatmentLength.Items.Clear();

            for (int i = 1; i <= 16; i++)
            {
                int time = i * 15;
                cmbTreatmentLength.Items.Add(time);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //set properties
            _treatment.Duration = (int)cmbTreatmentLength.Items[cmbTreatmentLength.SelectedIndex];

            if (Shared.Utilities.StrToDblDef(txtCost.Text, -0.01) < 0.00)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppTreatmentCostInvalid);
                return;
            }

            _treatment.Cost = Convert.ToDecimal(txtCost.Text);
            _treatment.IsActive = cbactive.Checked;
            _treatment.RequireFollowOn = cbFollowOn.Checked;
            _treatment.Name = txtName.Text;
            _treatment.MaximumTreatments = (int)udMaximum.Value;

            if (cmbImages.SelectedIndex > -1)
                _treatment.Image = (string)cmbImages.SelectedItem;

            _treatment.Save();


            //Add users
            foreach (object obj in lstAssigned.Items)
            {
                _treatment.Add((Therapist)obj);
            }

            foreach (object obj in lstAvailable.Items)
            {
                _treatment.Remove((Therapist)obj);
            }

            PluginManager.RaiseEvent(StringConstants.PLUGIN_EVENT_TREATMENT_ADD_REMOVE_UPDATE);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void SetTreatmentLength()
        {
            for (int i = 0; i < cmbTreatmentLength.Items.Count; i++)
            {
                if ((int)cmbTreatmentLength.Items[i] == _treatment.Duration)
                {
                    cmbTreatmentLength.SelectedIndex = i;
                    break;
                }
            }
        }

        private void cmbTreatmentLength_Format(object sender, ListControlConvertEventArgs e)
        {
            int time = (int)e.ListItem;
            int hours = (int)time / 60;
            int mins = (time - (hours * 60));

            if (hours == 0)
            {
                e.Value = String.Format(LanguageStrings.AppMinutes, mins);
            }
            else
            {
                if (mins == 0)
                    e.Value = String.Format(LanguageStrings.AppHours, hours);
                else
                    e.Value = String.Format(LanguageStrings.AppHoursAndMinutes, hours, mins);
            }
        }

        private void lstAvailable_Format(object sender, ListControlConvertEventArgs e)
        {
            Therapist therapist = (Therapist)e.ListItem;
            e.Value = therapist.EmployeeName;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstAvailable.SelectedItem != null)
            {
                lstAssigned.Items.Add(lstAvailable.SelectedItem);
                lstAvailable.Items.Remove(lstAvailable.SelectedItem);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstAssigned.SelectedItem != null)
            {
                lstAvailable.Items.Add(lstAssigned.SelectedItem);
                lstAssigned.Items.Remove(lstAssigned.SelectedItem);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageSettings)
                HelpTopic = HelpTopics.SalonTreatmentEdit;
            else if (tabControl1.SelectedTab == tabPageStaff)
                HelpTopic = HelpTopics.SalonTreatmentEditStaff;
            else if (tabControl1.SelectedTab == tabPageImage)
                HelpTopic = HelpTopics.SalonTreatmentEditImage;
        }

        private void LoadImages()
        {
            cmbImages.Items.Clear();

            string folder = AppController.POSFolder(ImageTypes.Treatments);
            string[] files = Directory.GetFiles(folder, StringConstants.IMAGE_SEARCH_TREATMENTS);

            foreach (string file in files)
            {
                cmbImages.Items.Add(Path.GetFileName(file));
            }
        }

        private void cmbImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            string imageFile = AppController.POSFolder(ImageTypes.Treatments) +
                (string)cmbImages.SelectedItem;

            if (File.Exists(imageFile))
            {
                picTreatmentImage.ImageLocation = imageFile;
            }
        }

        #endregion Private Methods
    }
}
