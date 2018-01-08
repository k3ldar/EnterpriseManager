using System;
using System.Web.UI.WebControls;
using Library;
using Library.BOL.Countries;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.Trade;

using Website.Library.Classes;
using Shared;

namespace SieraDelta.Website.Members.Controls
{
    public partial class CreateAccount : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCreateAccount.Text = Languages.LanguageStrings.CreateAccount;

            lblError.Visible = false;
            
            if (!IsPostBack)
            {
                LoadCountries();
                UpdateCountrySettings();
            }
        }

        protected void btnCreateAccount_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (VerificationImage1.IsValid)
                {
                    //SieraDeltaUtils u = new SieraDeltaUtils();
                    string email = SharedUtils.ReplaceHTMLElements(txtEmail.Text, CaseType.Lower);

                    if (!SharedUtils.IsValidEmail(email))
                        throw new Exception(Languages.LanguageStrings.InvalidEmailAddress);


                    ValidateAddressSettings();

                    User user = Library.BOL.Users.User.UserCreateAccount(SharedUtils.ReplaceHTMLElements(txtFirstName.Text, CaseType.Proper),
                        SharedUtils.ReplaceHTMLElements(txtLastName.Text, CaseType.Proper), SharedUtils.ReplaceHTMLElements(txtTelephone.Text, CaseType.Ignore),
                        email, SharedUtils.ReplaceHTMLElements(txtPassword.Text, CaseType.Ignore),
                        SharedUtils.ReplaceHTMLElements(txtPasswordConfirm.Text, CaseType.Ignore), SharedUtils.ReplaceHTMLElements(txtCompany.Text, CaseType.Proper),
                        SharedUtils.ReplaceHTMLElements(txtAddr1.Text, CaseType.Proper), SharedUtils.ReplaceHTMLElements(txtAddr2.Text, CaseType.Proper),
                        SharedUtils.ReplaceHTMLElements(txtAddr3.Text, CaseType.Proper), SharedUtils.ReplaceHTMLElements(txtCity.Text, CaseType.Proper),
                        SharedUtils.ReplaceHTMLElements(txtCounty.Text, CaseType.Proper), 
                        SharedUtils.ReplaceHTMLElements(txtPostCode.Text, CaseType.Upper),
                        Convert.ToInt32(lstCountry.SelectedItem.Value), cbTelephoneOffers.Checked, cbEmailOffers.Checked, cbPostalOffers.Checked, 
                        Library.Enums.UserRecordType.Default, DateTime.Parse("01/01/1900"), "");
                    user.Save();

                    if (Library.BOL.Users.User.UserLogUserOn(user))
                    {
                        SharedWebBase.CookieSetValue(Request, Response, String.Format("SD{0}Session", Global.DistributorWebsite), 
                            user.ID.ToString(), DateTime.Now.AddDays(60));

                        Session["CURRENT_USER"] = user;

                        SharedWebBase.UserLogin(Session, user, Request, Response, GetUserSession());
                        RaiseAfterCreateAccount(true);
                    }
                    else
                        RaiseAfterCreateAccount(false);
                }
            }
            catch (System.Exception Err)
            {
                lblError.Visible = true;

                if (Err.Message.IndexOf("IDX_WS_MEMBERS_EMAIL") > 1)
                    lblError.Text = Languages.LanguageStrings.EmailAlreadyRegistered;
                else
                    lblError.Text = Err.Message;
            }
        }

        #region Public Methods

        public void Refresh(Client client)
        {
            txtEmail.Text = client.Email;
            txtCompany.Text = client.Company;
            txtPostCode.Text = client.Postcode;
            txtTelephone.Text = client.Telephone;

            string[] seperators = new string[] { "\r\n" };
            string[] address = client.Address.Split(seperators, StringSplitOptions.None);

            try
            {
                txtAddr1.Text = address[0];
                txtAddr2.Text = address[1];
                txtAddr3.Text = address[2];
                txtCity.Text = address[3];
                txtCounty.Text = address[4];
            }
            catch
            {
                //ignore its only the address part
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void LoadCountries()
        {
            Countries countries = Countries.Get();
            lstCountry.Items.Clear();

            foreach (Country country in countries)
            {
                if (country.ShowOnWeb)
                {
                    ListItem itm = new ListItem(country.Name, country.ID.ToString());
                    lstCountry.Items.Add(itm);
                    itm.Selected = country.CountryCode == CountryCode;
                }
            }
        }

        private void RaiseAfterCreateAccount(bool LoginFailed)
        {
            if (AfterCreateAccount != null)
                AfterCreateAccount(this, new CreateAccountArgs(LoginFailed));
        }

        private void UpdateCountrySettings()
        {
            Country country = Countries.Get(Convert.ToInt32(lstCountry.SelectedItem.Value));

            lblTelephone.Visible = country.HasOption(AddressOptions.TelephoneShow);
            txtTelephone.Visible = country.HasOption(AddressOptions.TelephoneShow);
            lblOfferTelephone.Visible = country.HasOption(AddressOptions.TelephoneShow);
            cbTelephoneOffers.Visible = country.HasOption(AddressOptions.TelephoneShow);

            lblBusinessName.Visible = country.HasOption(AddressOptions.BusinessNameShow);
            txtCompany.Visible = country.HasOption(AddressOptions.BusinessNameShow);

            lblAddr1.Visible = country.HasOption(AddressOptions.AddressLine1Show);
            txtAddr1.Visible = country.HasOption(AddressOptions.AddressLine1Show);
            cbPostalOffers.Visible = country.HasOption(AddressOptions.AddressLine1Show);
            lblOfferPostal.Visible = country.HasOption(AddressOptions.AddressLine1Show);

            lblAddr2.Visible = country.HasOption(AddressOptions.AddressLine2Show);
            txtAddr2.Visible = country.HasOption(AddressOptions.AddressLine2Show);

            lblAddr3.Visible = country.HasOption(AddressOptions.AddressLine3Show);
            txtAddr3.Visible = country.HasOption(AddressOptions.AddressLine3Show);

            lblCity.Visible = country.HasOption(AddressOptions.CityShow);
            txtCity.Visible = country.HasOption(AddressOptions.CityShow);

            lblCounty.Visible = country.HasOption(AddressOptions.CountyShow);
            txtCounty.Visible = country.HasOption(AddressOptions.CountyShow);

            //lblState.Visible = country.HasOption(AddressOptions.);
            //txtst.Visible = country.HasOption(AddressOptions.);

            lblPostCode.Visible = country.HasOption(AddressOptions.PostCodeShow);
            txtPostCode.Visible = country.HasOption(AddressOptions.PostCodeShow);

        }

        private void ValidateAddressSettings()
        {
            Country country = Countries.Get(Convert.ToInt32(lstCountry.SelectedItem.Value));

            if (country.HasOption(AddressOptions.TelephoneShow) && country.HasOption(AddressOptions.TelephoneMandatory))
                ValidateDetails(txtTelephone.Text, 0, Languages.LanguageStrings.TelephoneNumber);

            if (country.HasOption(AddressOptions.BusinessNameShow) && country.HasOption(AddressOptions.BusinessNameMandatory))
                ValidateDetails(txtCompany.Text, 0, Languages.LanguageStrings.BusinessName);

            if (country.HasOption(AddressOptions.AddressLine1Show) && country.HasOption(AddressOptions.AddressLine1Mandatory))
                ValidateDetails(txtAddr1.Text, 0, Languages.LanguageStrings.AddressLine1);

            if (country.HasOption(AddressOptions.AddressLine2Show) && country.HasOption(AddressOptions.AddressLine2Mandatory))
                ValidateDetails(txtAddr2.Text, 0, Languages.LanguageStrings.AddressLine2);

            if (country.HasOption(AddressOptions.AddressLine3Show) && country.HasOption(AddressOptions.AddressLine3Mandatory))
                ValidateDetails(txtAddr3.Text, 0, Languages.LanguageStrings.AddressLine3);

            if (country.HasOption(AddressOptions.CityShow) && country.HasOption(AddressOptions.CityMandatory))
                ValidateDetails(txtCity.Text, 0, Languages.LanguageStrings.City);

            if (country.HasOption(AddressOptions.CountyShow) && country.HasOption(AddressOptions.CountyMandatory))
                ValidateDetails(txtCounty.Text, 0, Languages.LanguageStrings.County);

            if (country.HasOption(AddressOptions.PostCodeShow) && country.HasOption(AddressOptions.PostCodeMandatory))
                ValidateDetails(txtPostCode.Text, 0, Languages.LanguageStrings.Postcode);
        }

        #endregion Private Methods

        #region Delegate Arguments

        public class CreateAccountArgs : EventArgs
        {
            private bool _LoggedIn;

            private User _Account;

            public CreateAccountArgs(User Account)
            {
                _Account = Account;
            }

            public User NewAccount
            {
                get
                {
                    return (_Account);
                }
            }

            public CreateAccountArgs(bool LoggedIn)
            {
                _LoggedIn = LoggedIn;
            }

            public bool LoggedIn
            {
                get
                {
                    return (_LoggedIn);
                }
            }
        }

        #endregion Delegate Arguments
        
        #region Delegates

        public delegate void AfterCreateAccountDelegate(object sender, CreateAccountArgs e);

        #endregion Delegates

        #region Events

        public event AfterCreateAccountDelegate AfterCreateAccount;


        #endregion Events


        protected void lstCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCountrySettings();
        }
    }
}