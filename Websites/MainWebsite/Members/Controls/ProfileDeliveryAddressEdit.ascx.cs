using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library;
using Library.BOL.Countries;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.DeliveryAddress;

using Shared;

namespace Heavenskincare.WebsiteTemplate.Members.Controls
{
    public partial class ProfileDeliveryAddressEdit : BaseControlClass
    {
        private DeliveryAddress _address;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnDelete.Text = Languages.LanguageStrings.Delete;
            btnUpdate.Text = Languages.LanguageStrings.Update;
            cbConfirmDelete.Text = Languages.LanguageStrings.ConfirmDelete;

            lblError.Visible = false;
            _address = GetUser().DeliveryAddresses.Find(GetFormValue("ID", -1));

            if (_address == null)
                DoRedirect("/Members/Index.aspx", true);

            if (!IsPostBack)
            {
                LoadCountries();
                txtName.Text = _address.Name;
                txtAddr1.Text = _address.AddressLine1;
                txtAddr2.Text = _address.AddressLine2;
                txtAddr3.Text = _address.AddressLine3;
                txtCity.Text = _address.City;
                txtCounty.Text = _address.County;
                txtPostCode.Text = _address.PostCode;
            }
        }

        protected void btnUpdate_Click(object sender, System.EventArgs e)
        {
            try
            {
                Country country = Countries.Get(Convert.ToInt32(lstCountry.SelectedItem.Value));

                ValidateDetails(HSCUtils.ReplaceHTMLElements(txtName.Text, CaseType.Proper), 0, Languages.LanguageStrings.Name);

                if (country.AddressSettings.HasFlag(AddressOptions.AddressLine1Mandatory))
                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtAddr1.Text, CaseType.Proper), 0, Languages.LanguageStrings.AddressLine1);

                if (country.AddressSettings.HasFlag(AddressOptions.AddressLine2Mandatory))
                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtAddr2.Text, CaseType.Proper), 0, Languages.LanguageStrings.AddressLine2);

                if (country.AddressSettings.HasFlag(AddressOptions.AddressLine3Mandatory))
                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtAddr3.Text, CaseType.Proper), 0, Languages.LanguageStrings.AddressLine3);

                if (country.AddressSettings.HasFlag(AddressOptions.CityMandatory))
                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtCity.Text, CaseType.Proper), 0, Languages.LanguageStrings.City);

                if (country.AddressSettings.HasFlag(AddressOptions.CountyMandatory))
                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtCounty.Text, CaseType.Proper), 0, Languages.LanguageStrings.County);

                if (country.AddressSettings.HasFlag(AddressOptions.PostCodeMandatory))
                    ValidateDetails(HSCUtils.ReplaceHTMLElements(txtPostCode.Text, CaseType.Proper), 0, Languages.LanguageStrings.Postcode);

                _address.Name = HSCUtils.ReplaceHTMLElements(txtName.Text, CaseType.Proper);
                _address.AddressLine1 = HSCUtils.ReplaceHTMLElements(txtAddr1.Text, CaseType.Proper);
                _address.AddressLine2 = HSCUtils.ReplaceHTMLElements(txtAddr2.Text, CaseType.Proper);
                _address.AddressLine3 = HSCUtils.ReplaceHTMLElements(txtAddr3.Text, CaseType.Proper);
                _address.City = HSCUtils.ReplaceHTMLElements(txtCity.Text, CaseType.Proper);
                _address.County = HSCUtils.ReplaceHTMLElements(txtCounty.Text, CaseType.Proper);
                _address.PostCode = HSCUtils.ReplaceHTMLElements(txtPostCode.Text, CaseType.Upper);
                _address.Country = Countries.Get(Convert.ToInt32(lstCountry.SelectedItem.Value));
                _address.Save();

                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
                GetBasket().Reset(localData.PriceColumn);
                SharedWebBase.ResetDeliveryAddress(Session, GetUserSession());

                if (GetFormValue("redirect") != "")
                    DoRedirect(GetFormValue("redirect"));
                else
                    DoRedirect("/Members/Index.aspx?profileUpdated=true", true);
            }
            catch (System.Exception Err)
            {
                lblError.Visible = true;
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
                    itm.Selected = country.CountryCode == _address.Country.CountryCode;
                }
            }

            UpdateAddressFields();
        }

        private void UpdateAddressFields()
        {
            Country country = Countries.Get(Convert.ToInt32(lstCountry.SelectedItem.Value));

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
            txtPostCode.Visible = country.AddressSettings.HasFlag(AddressOptions.PostCodeShow);
        }

        #endregion Private Methods

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbConfirmDelete.Checked)
                {
                    GetUser().DeliveryAddresses.Delete(_address);
                    DoRedirect("/Members/DeliveryAddress.aspx", true);
                }
            }
            catch (System.Exception Err)
            {
                lblError.Visible = true;
                lblError.Text = Err.Message;
            }
        }

        protected void lstCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAddressFields();
        }
    }
}