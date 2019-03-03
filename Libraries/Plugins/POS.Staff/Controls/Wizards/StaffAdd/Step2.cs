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

using Languages;
using SharedBase;
using SharedBase.BOL.Countries;
using SharedBase.BOL.Staff;

namespace POS.Staff.Controls.Wizards.StaffAdd
{
    public partial class Step2 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private StaffMember _staffMember;

        #endregion Private Members

        #region Constructors

        public Step2(StaffMember staff)
        {
            InitializeComponent();

            _staffMember = staff;

            LoadCountries();
            LoadGenderTypes();
            LoadMaritalStatuses();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblNationality.Text = LanguageStrings.AppStaffNationality;
            lblGender.Text = LanguageStrings.AppStaffGender;
            lblMaritalStatus.Text = LanguageStrings.AppStaffMaritalStatus;
            lblDateOfBirth.Text = LanguageStrings.AppStaffDateOfBirth;
        }

        public override bool NextClicked()
        {
            _staffMember.MaritalStatus = (MaritalStatus)cmbMaritalStatus.SelectedIndex;
            _staffMember.Nationality = ((Country)cmbNationality.SelectedItem).ID;
            _staffMember.Gender = (GenderType)cmbGender.SelectedIndex;
            _staffMember.DateOfBirth = dtpDateOfBirth.Value;

            return base.NextClicked();
        }

        public override bool CanGoNext()
        {
            if (cmbGender.SelectedIndex == -1)
                return (false);

            if (cmbMaritalStatus.SelectedIndex == -1)
                return (false);

            if (cmbNationality.SelectedIndex == -1)
                return (false);

            return base.CanGoNext();
        }

        public override void PageShown()
        {
            if (dtpDateOfBirth.Value.Date == DateTime.Now.Date)
                dtpDateOfBirth.Value = dtpDateOfBirth.Value.AddYears(-18);

            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.StaffCreateStep2;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadCountries()
        {
            Countries countries = Countries.Get();

            cmbNationality.Items.Clear();

            foreach (Country country in countries)
            {
                int idx = cmbNationality.Items.Add(country);

                if (country.ID == POS.Base.Classes.AppController.LocalCountry.ID)
                    cmbNationality.SelectedIndex = idx;
            }
        }


        private void LoadGenderTypes()
        {
            cmbGender.Items.Clear();

            foreach (GenderType gender in Enum.GetValues(typeof(GenderType)))
            {
                cmbGender.Items.Add(POS.Base.EnumTranslations.Translate(gender));
            }
        }

        private void LoadMaritalStatuses()
        {
            cmbMaritalStatus.Items.Clear();

            foreach (MaritalStatus status in Enum.GetValues(typeof(MaritalStatus)))
            {
                cmbMaritalStatus.Items.Add(POS.Base.EnumTranslations.Translate(status));
            }
        }

        private void cmbNationality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainWizardForm != null)
                MainWizardForm.UpdateUI();
        }

        private void cmbCountry_Format(object sender, ListControlConvertEventArgs e)
        {
            Country country = (Country)e.ListItem;
            e.Value = country.Name;
        }

        #endregion Private Methods
    }
}
