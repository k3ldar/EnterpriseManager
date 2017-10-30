using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Countries;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.Trade;
using Library.BOL.USAStates;
using Library.BOL.SEO;

using Shared;
using Shared.Classes;

namespace Heavenskincare.WebsiteTemplate.Members.Controls
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
                LoadStates();
                IsUSAAddress();
            }
        }

        protected void btnCreateAccount_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (VerificationImage1.IsValid)
                {
                    string email = HSCUtils.ReplaceHTMLElements(txtEmail.Text, CaseType.Lower);

                    if (!Shared.Utilities.IsValidEmail(email))
                        throw new Exception(Languages.LanguageStrings.InvalidEmailAddress);

                    User user = Library.BOL.Users.User.UserCreateAccount(HSCUtils.ReplaceHTMLElements(txtFirstName.Text, CaseType.Proper),
                        HSCUtils.ReplaceHTMLElements(txtLastName.Text, CaseType.Proper), HSCUtils.ReplaceHTMLElements(txtTelephone.Text, CaseType.Ignore),
                        email, HSCUtils.ReplaceHTMLElements(txtPassword.Text, CaseType.Ignore),
                        HSCUtils.ReplaceHTMLElements(txtPasswordConfirm.Text, CaseType.Ignore), HSCUtils.ReplaceHTMLElements(txtCompany.Text, CaseType.Proper),
                        HSCUtils.ReplaceHTMLElements(txtAddr1.Text, CaseType.Proper), HSCUtils.ReplaceHTMLElements(txtAddr2.Text, CaseType.Proper),
                        HSCUtils.ReplaceHTMLElements(txtAddr3.Text, CaseType.Proper), HSCUtils.ReplaceHTMLElements(txtCity.Text, CaseType.Proper),
                        lstState.Visible ? lstState.SelectedItem.Text : HSCUtils.ReplaceHTMLElements(txtCounty.Text, CaseType.Proper), 
                        HSCUtils.ReplaceHTMLElements(txtPostCode.Text, CaseType.Upper),
                        Convert.ToInt32(lstCountry.SelectedItem.Value), cbTelephoneOffers.Checked, cbEmailOffers.Checked, cbPostalOffers.Checked, 
                        Library.Enums.UserRecordType.Default, DateTime.Parse("01/01/1900"), "");
                    user.Save();

                    try
                    {
                        if (!String.IsNullOrEmpty(Global.MailChimpAPI))
                        {
#warning Need to integrate Mail Chimp Here

                            //if (cbEmailOffers.Checked)
                            //    wrapper.SubscriberAdd(Global.MailChimpList, user.Email);
                        }
                    }
                    catch (Exception err)
                    {
                        Global.SendEmail(err.Message);
                    }

                    if (Library.BOL.Users.User.UserLogUserOn(user))
                    {
                        HttpCookie cookie = new HttpCookie(String.Format("{0}{1}Session", 
                            BaseWebApplication.CookiePrefix, Global.DistributorWebsite),
                            HttpUtility.UrlEncode(Shared.Utilities.Encrypt(user.ID.ToString())));

                        if (!Request.IsLocal)
                            cookie.Domain = BaseWebApplication.CookieRootURL;

                        cookie.Expires = DateTime.Now.AddDays(60);
                        Response.Cookies.Add(cookie);

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
                Shared.EventLog.Add(Err);
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

        private void LoadStates()
        {
            USStates states = USStates.Get();
            lstState.Items.Clear();

            foreach (USState state in states)
            {
                ListItem itm = new ListItem(state.Name, state.ID.ToString());
                lstState.Items.Add(itm);
            }
        }

        private void RaiseAfterCreateAccount(bool LoginFailed)
        {
            if (AfterCreateAccount != null)
                AfterCreateAccount(this, new CreateAccountArgs(LoginFailed));
        }

        private void IsUSAAddress()
        {
            if (lstCountry.SelectedItem.Text == "United States of America")
            {
                lblCounty.Visible = false;
                txtCounty.Visible = false;
                lblState.Visible = true;
                lstState.Visible = true;
                lblAddr2.Visible = false;
                lblAddr3.Visible = false;
                txtAddr2.Visible = false;
                txtAddr3.Visible = false;
            }
            else
            {
                lblCounty.Visible = true;
                txtCounty.Visible = true;
                lblState.Visible = false;
                lstState.Visible = false;
                lblAddr2.Visible = true;
                lblAddr3.Visible = true;
                txtAddr2.Visible = true;
                txtAddr3.Visible = true;
            }
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
            IsUSAAddress();
        }
    }
}