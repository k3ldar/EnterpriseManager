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

using Shared;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class TradeSignup1 : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnNext.Text = Languages.LanguageStrings.Next;

            lblError.Visible = false;

            if (!IsPostBack)
                LoadCountries();
        }

        protected void btnNext_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (VerificationImage1.IsValid)
                {
                    string email = HSCUtils.ReplaceHTMLElements(txtEmail.Text, CaseType.Lower);

                    if (!Shared.Utilities.IsValidEmail(email))
                        throw new Exception(Languages.LanguageStrings.InvalidEmailAddress);

                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtEmail.Text), 0, Languages.LanguageStrings.Email);
                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtName.Text), 0, Languages.LanguageStrings.ContactName);
                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtCompany.Text), 0, Languages.LanguageStrings.CompanyName);
                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtTelephone.Text), 0, Languages.LanguageStrings.Telephone);
                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtAddr1.Text), 0, Languages.LanguageStrings.AddressLine1);
                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtCity.Text), 0, Languages.LanguageStrings.City);
                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtPostCode.Text), 0, Languages.LanguageStrings.Postcode);

                    RaiseNextPage(1);
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

        private string NextLine(string Text)
        {
            string Result = Text;

            if (!String.IsNullOrEmpty(Result))
                Result += "\r\n";

            return (Result);
        }

        private void RaiseNextPage(int Page)
        {
            if (OnNextPage != null)
                OnNextPage(this, new NextPageArgs(Page));
        }

        #endregion Private Methods

        #region Delegates

        

        #endregion Delegates

        #region Events

        public event WizardNextPageDelegate OnNextPage;


        #endregion Events

        #region Properties

        public string Email
        {
            get
            {
                return (txtEmail.Text);
            }
        }

        public string Name
        {
            get
            {
                return (txtName.Text);
            }
        }

        public string Telephone
        {
            get
            {
                return (txtTelephone.Text);
            }
        }

        public string Address
        {
            get
            {
                string Result = txtAddr1.Text;
                Result += NextLine(txtAddr2.Text);
                Result += NextLine(txtAddr3.Text);
                Result += NextLine(txtCounty.Text);
                Result += NextLine(lstCountry.SelectedItem.Text);

                return (Result);
            }
        }

        public string Postcode
        {
            get
            {
                return (txtPostCode.Text);
            }
        }

        public string Company
        {
            get
            {
                return (txtCompany.Text);
            }
        }

        #endregion Properties

        #region Public Methods

        public string GetData()
        {
            string Result = "Trade Contact</br>";

            Result += String.Format("Email: {0}<br />", txtEmail.Text);
            Result += String.Format("Contact: {0}<br />", txtName.Text);
            Result += String.Format("Salon Name: {0}<br />", txtCompany.Text);
            Result += String.Format("Telephone: {0}<br />", txtTelephone.Text);
            Result += String.Format("AddressLine1: {0}<br />", txtAddr1.Text);
            Result += String.Format("AddressLine2: {0}<br />", txtAddr2.Text);
            Result += String.Format("AddressLine3: {0}<br />", txtAddr3.Text);
            Result += String.Format("City: {0}<br />", txtCity.Text);
            Result += String.Format("County: {0}<br />", txtCounty.Text);
            Result += String.Format("Postcode: {0}<br />", txtPostCode.Text);
            Result += String.Format("Country: {0}<br />", lstCountry.SelectedItem.Text);

            return (Result);
        }

        #endregion Public Methods
    }
}