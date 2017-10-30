using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Campaigns;
using Library.BOL.Users;
using Library.Utils;

namespace Heavenskincare.WebsiteTemplate.Members.Controls
{
    public partial class CompetitionRegistration : BaseControlClass
    {
        private Campaign _campaign;
        private string _competitionName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Visible = false;
                User user = GetUser();

                if (user != null)
                {
                    txtName.Text = user.UserName;
                    txtName.Enabled = false;

                    txtEmail.Text = user.Email;
                    txtEmail.Enabled = false;

                    if (user.BirthDate.Year > 1900)
                    {
                        txtDateOfBirth.Text = user.BirthDate.ToString("dd/nn/yyyy");
                        txtDateOfBirth.Enabled = false;
                    }
                }
            }
        }

        #region Properties

        /// <summary>
        /// Name of the competition to register with
        /// </summary>
        public string CompetitionName
        {
            get
            {
                return (_competitionName);
            }

            set
            {
                _competitionName = value;

                _campaign = Campaign.Get(_competitionName);
            }
        }

        #endregion Properties

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = true;
            try
            {
                lblMessage.Style.Clear();
                lblMessage.Style.Add("width", "100%");
                lblMessage.Style.Add("text-align", "center");

                //validate details
                if (_campaign == null)
                    throw new Exception(Languages.LanguageStrings.InvalidCompetition);

                string[] fullName = txtName.Text.Split(' ');

                if (fullName.Count() == 1)
                    throw new Exception(Languages.LanguageStrings.PleaseEnterFirstLastName);

                string firstName = fullName[0];
                string lastName = fullName[fullName.Count() - 1];
                string email = txtEmail.Text;
                DateTime dateOfBirth = new DateTime(1800, 1, 1);

                if (!Shared.Utilities.IsValidEmail(email))
                    throw new Exception(Languages.LanguageStrings.InvalidEmailAddress);

                if (!String.IsNullOrEmpty(txtDateOfBirth.Text))
                    dateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);

                Users.RegisterUserForCompetition(firstName, lastName, email, dateOfBirth, cbReceiveEmails.Checked, GetCountry(), _campaign);

                lblMessage.Style.Add("color", "black");
                lblMessage.InnerText = Languages.LanguageStrings.RegistrationSuccess;
            }
            catch (Exception err)
            {
                lblMessage.Style.Add("color", "red");

                if (err.Message.Contains("The string was not recognized as a valid DateTime"))
                    lblMessage.InnerText = Languages.LanguageStrings.InvalidDateOfBirth;
                else if (err.Message.Contains("EMAIL; Can not be null"))
                    lblMessage.InnerText = Languages.LanguageStrings.InvalidEmailAddress;
                else
                    lblMessage.InnerText = err.Message;
            }
        }

        protected void btnUnregister_Click(object sender, EventArgs e)
        {

        }
    }
}