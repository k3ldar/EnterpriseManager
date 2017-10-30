using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Website.Library.Classes;
using Library.BOL.Users;
using Library.BOL.Countries;
using Library.Utils;

using Shared;

namespace Heavenskincare.WebsiteTemplate.Members.Controls
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
                Country country = Countries.Get(Convert.ToInt32(lstCountry.SelectedItem.Value));

                if (country.AddressSettings.HasFlag(AddressOptions.BusinessNameMandatory))
                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtBusinessName.Text, CaseType.Proper), 0, 
                        Languages.LanguageStrings.BusinessName);

                if (country.AddressSettings.HasFlag(AddressOptions.AddressLine1Mandatory))
                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtAddr1.Text, CaseType.Proper), 0, 
                        Languages.LanguageStrings.AddressLine1);

                if (country.AddressSettings.HasFlag(AddressOptions.AddressLine2Mandatory))
                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtAddr2.Text, CaseType.Proper), 0, 
                        Languages.LanguageStrings.AddressLine2);

                if (country.AddressSettings.HasFlag(AddressOptions.AddressLine3Mandatory))
                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtAddr3.Text, CaseType.Proper), 0, 
                        Languages.LanguageStrings.AddressLine3);

                if (country.AddressSettings.HasFlag(AddressOptions.CityMandatory))
                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtCity.Text, CaseType.Proper), 0, 
                        Languages.LanguageStrings.City);

                if (country.AddressSettings.HasFlag(AddressOptions.CountyMandatory))
                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtCounty.Text, CaseType.Proper), 0, 
                        Languages.LanguageStrings.County);

                if (country.AddressSettings.HasFlag(AddressOptions.PostCodeMandatory))
                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtPostcode.Text, CaseType.Proper), 0, 
                        Languages.LanguageStrings.Postcode);

                User user = GetUser();
                user.BusinessName = HSCUtils.ReplaceHTMLElements(txtBusinessName.Text);
                user.AddressLine1 = HSCUtils.ReplaceHTMLElements(txtAddr1.Text);
                user.AddressLine2 = HSCUtils.ReplaceHTMLElements(txtAddr2.Text);
                user.AddressLine3 = HSCUtils.ReplaceHTMLElements(txtAddr3.Text);
                user.City = HSCUtils.ReplaceHTMLElements(txtCity.Text);
                user.County = HSCUtils.ReplaceHTMLElements(txtCounty.Text);
                user.PostCode = HSCUtils.ReplaceHTMLElements(txtPostcode.Text);
                user.Country = Countries.Get(Shared.Utilities.StrToInt(lstCountry.SelectedValue, -1));
                user.Save();

                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
                localData.VATRate = user.Country.VATRate;

                Session["FLAG"] = null;

                GetBasket().Reset(localData.PriceColumn);

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

            UpdateAddressFields();
        }

        private void UpdateAddressFields()
        {
            Country country = Countries.Get(Convert.ToInt32(lstCountry.SelectedItem.Value));

            lblBusinessName.Visible = country.AddressSettings.HasFlag(AddressOptions.BusinessNameShow);
            txtBusinessName.Visible = country.AddressSettings.HasFlag(AddressOptions.BusinessNameShow);

            lblAddressLine1.Visible = country.AddressSettings.HasFlag(AddressOptions.AddressLine1Show);
            txtAddr1.Visible = country.AddressSettings.HasFlag(AddressOptions.AddressLine1Show);

            lblAddressLine2.Visible = country.AddressSettings.HasFlag(AddressOptions.AddressLine2Show);
            txtAddr2.Visible = country.AddressSettings.HasFlag(AddressOptions.AddressLine2Show);

            lblAddressLine3.Visible = country.AddressSettings.HasFlag(AddressOptions.AddressLine3Show);
            txtAddr3.Visible = country.AddressSettings.HasFlag(AddressOptions.AddressLine3Show);

            lblCity.Visible = country.AddressSettings.HasFlag(AddressOptions.CityShow);
            txtCity.Visible = country.AddressSettings.HasFlag(AddressOptions.CityShow);

            lblCounty.Visible = country.AddressSettings.HasFlag(AddressOptions.CountyShow);
            txtCounty.Visible = country.AddressSettings.HasFlag(AddressOptions.CountyShow);

            lblPostCode.Visible = country.AddressSettings.HasFlag(AddressOptions.PostCodeShow);
            txtPostcode.Visible = country.AddressSettings.HasFlag(AddressOptions.PostCodeShow);
        }

        protected void lstCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAddressFields();
        }

    }
}