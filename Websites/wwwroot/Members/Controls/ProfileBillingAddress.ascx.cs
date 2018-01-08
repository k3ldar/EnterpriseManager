using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Users;
using Library.BOL.Countries;
using Library.Utils;

namespace SieraDelta.Website.Members.Controls
{
    public partial class ProfileBillingAddress : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            btnSubmit.Text = Languages.LanguageStrings.Submit;

            if (!IsPostBack)
            {
                LoadCountries();
                User user = GetUser();
                txtBusinessName.Text = user.BusinessName;
                txtAddr1.Text = user.AddressLine1;
                txtAddr2.Text = user.AddressLine2;
                txtAddr3.Text = user.AddressLine3;
                txtCity.Text = user.City;
                txtCounty.Text = user.County;
                txtPostcode.Text = user.PostCode;
                SetCountry(user.Country.ID);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //SieraDeltaUtils u = new SieraDeltaUtils();

                ValidateDetails(SharedUtils.ReplaceHTMLElements(txtAddr1.Text), 0, Languages.LanguageStrings.AddressLine1);
                ValidateDetails(SharedUtils.ReplaceHTMLElements(txtCity.Text), 0, Languages.LanguageStrings.City);
                ValidateDetails(SharedUtils.ReplaceHTMLElements(txtCounty.Text), 0, Languages.LanguageStrings.County);
                ValidateDetails(SharedUtils.ReplaceHTMLElements(txtPostcode.Text), 0, Languages.LanguageStrings.Postcode);

                User user = GetUser();
                user.BusinessName = SharedUtils.ReplaceHTMLElements(txtBusinessName.Text);
                user.AddressLine1 = SharedUtils.ReplaceHTMLElements(txtAddr1.Text);
                user.AddressLine2 = SharedUtils.ReplaceHTMLElements(txtAddr2.Text);
                user.AddressLine3 = SharedUtils.ReplaceHTMLElements(txtAddr3.Text);
                user.City = SharedUtils.ReplaceHTMLElements(txtCity.Text);
                user.County = SharedUtils.ReplaceHTMLElements(txtCounty.Text);
                user.PostCode = SharedUtils.ReplaceHTMLElements(txtPostcode.Text);
                user.Country = Countries.Get(SharedUtils.StrToInt(lstCountry.SelectedValue, -1));
                user.Save();
                Session["COUNTRYCODE"] = user.Country.CountryCode;

                Session["FLAG"] = null;
                Session["USASTATE"] = null;
                DoRedirect("/Members/Index.aspx?profileUpdated=true", true);
            }
            catch (Exception err)
            {
                lblError.Text = err.Message;
                lblError.Visible = true;
            }
        }

        private void LoadCountries()
        {
            lstCountry.Items.Clear();

            Countries countries = Countries.Get();

            foreach (Country country in countries)
            {
                if (country.ShowOnWeb)
                {
                    ListItem item = new ListItem(country.Name, country.ID.ToString());
                    lstCountry.Items.Add(item);
                }
            }
        }

        private void SetCountry(int CountryID)
        {
            foreach (ListItem item in lstCountry.Items)
            {
                item.Selected = item.Value == CountryID.ToString();
            }
        }
    }
}