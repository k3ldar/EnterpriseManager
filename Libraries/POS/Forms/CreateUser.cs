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
 *  File: CreateUser.cs
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

using Languages;

using SharedBase;
using SharedBase.BOL.Users;
using SharedBase.BOL.Countries;
using SharedBase.BOL.ValidationChecks;
using POS.Base.Classes;

#pragma warning disable IDE1006

namespace POS.Base.Forms
{
    public partial class CreateUser : BaseForm
    {
        private User _User = null;

        #region Properties

        public User SelectedUser
        {
            get
            {
                return (_User);
            }
        }

        #endregion Properties

        public CreateUser()
        {
            InitializeComponent();

            LoadMonths();
            cmbBirthMonth.SelectedIndex = 0;
            cmbBirthDay.SelectedIndex = 0;
        }

        #region Overridden Methods

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.CreateCustomer;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppUserCreate;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnOK.Text = LanguageStrings.AppMenuButtonOK;

            lblAddressLine1.Text = LanguageStrings.AddressLine1;
            lblBirthDate.Text = LanguageStrings.AppUserBirthDate;
            lblCountry.Text = LanguageStrings.AppUserCountry;
            lblCounty.Text = LanguageStrings.AppUserCounty;
            lblEmailAddress.Text = LanguageStrings.AppUserEmail;
            lblFirstName.Text = LanguageStrings.AppUserFirstName;
            lblLastName.Text = LanguageStrings.AppUserLastName;
            lblPostCode.Text = LanguageStrings.AppUserPostcode;
            lblTelephone.Text = LanguageStrings.AppUserTelephone;
            lblTown.Text = LanguageStrings.AppUserTown;

            tabPageDetails.Text = LanguageStrings.AppUserDetails;
            tabPageNotes.Text = LanguageStrings.Notes;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadMonths()
        {
            cmbBirthMonth.Items.Clear();
            DateTime months = new DateTime(2012, 1, 1);

            while (months.Year == 2012)
            {
                cmbBirthMonth.Items.Add(months.ToString(POS.Base.Classes.StringConstants.DATE_FORMAT_MONTH_FULL, CultureInfo.CurrentUICulture));
                months = months.AddMonths(1);
            }
        }

        private void cmbBirthMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currMonth = cmbBirthMonth.SelectedIndex + 1;

            DateTime days = new DateTime(2012, currMonth, 1);

            cmbBirthDay.Items.Clear();

            while (days.Month == currMonth)
            {
                cmbBirthDay.Items.Add(days.Day);
                days = days.AddDays(1);
            }

            cmbBirthDay.SelectedIndex = _User == null ? 0 : _User.BirthDate.Day - 1;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbBirthDay.SelectedIndex == -1 && cmbBirthMonth.SelectedIndex == -1)
            {
                if (!ShowQuestion(LanguageStrings.AppUserDateOfBirth, 
                        LanguageStrings.AppUserDateOfBirthInvalidContinue))
                    return;
                else
                    POSValidation.Add(AppController.ActiveUser, ValidationReasons.IgnoreDateOfBirth,
                        String.Format(LanguageStrings.AppUserDisplay, 
                        Shared.Utilities.MaximumLength(txtFirstName.Text, 100),
                        txtLastName.Text.Substring(0, 100)));
            }

            try
            {
                string email = txtEmail.Text;

                if (String.IsNullOrEmpty(email))
                {
                    if (ShowQuestion(LanguageStrings.AppUserEmail, LanguageStrings.AppUserEmailHasEmail))
                    {
                        ShowInformation(LanguageStrings.AppUserEmail, LanguageStrings.AppUserEmailEnterEmail);
                        return;
                    }
                    else
                    {
                        email = POS.Base.Classes.StringConstants.NO_EMAIL;
                    }
                }

                string password = CreateRandomPassword();
                Country country = (Country)cmbCountry.SelectedItem;

                DateTime birthDate = new DateTime(1800, 1, 1);
                    
                if (cmbBirthDay.SelectedIndex > -1 && cmbBirthMonth.SelectedIndex > -1)
                    birthDate = new DateTime(1800, cmbBirthMonth.SelectedIndex + 1, 
                        cmbBirthDay.SelectedIndex + 1);

                _User = User.UserCreateAccount(txtFirstName.Text, txtLastName.Text, txtTelephone.Text, 
                    email, password, password, String.Empty, txtAddressLine1.Text,
                    String.Empty, String.Empty, txtTown.Text, txtCounty.Text, txtPostCode.Text, 
                    country.ID, false, false, false, Enums.UserRecordType.PosToImport, 
                    birthDate, txtNotes.Text);

                _User.Save();

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception err)
            {
                if (err.Message.Contains(POS.Base.Classes.StringConstants.ERROR_STORE_DUPLICATE))
                    MessageBox.Show(LanguageStrings.AppUserAlreadyExists, LanguageStrings.AppError, MessageBoxButtons.OK);
                else
                    MessageBox.Show(err.Message, LanguageStrings.AppError, MessageBoxButtons.OK);
            }
        }

        private string CreateRandomPassword()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            string AcceptableChars = POS.Base.Classes.StringConstants.USER_PASSWORD_CHARACTERS;
            string Result = String.Empty;

            for (int i = 0; i < 9; i++)
            {
                int ch = rnd.Next(AcceptableChars.Length - 1);
                Result += AcceptableChars.Substring(ch, 1);
            }

            return Result;
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            LoadCountries();
        }

        private void LoadCountries()
        {
            cmbCountry.Items.Clear();
            Countries countries = Countries.Get();

            foreach (Country country in countries)
            {
                cmbCountry.Items.Add(country);                
            }

            foreach (Country country in cmbCountry.Items)
            {
                if (country.CountryCode == AppController.LocalCountry.CountryCode)
                {
                    cmbCountry.SelectedItem = (Object)country;
                    break;
                }
            }
        }

        private void cmbCountry_Format(object sender, ListControlConvertEventArgs e)
        {
            Country country = (Country)e.ListItem;

            e.Value = country.Name;
        }

        private void cmbCountry_Format_1(object sender, ListControlConvertEventArgs e)
        {
            Country ct = (Country)e.ListItem;
            e.Value = ct.Name;
        }

        #endregion Private Methods
    }
}
