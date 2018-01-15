using System;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Countries;
using Library.Utils;
using Library.BOL.DeliveryAddress;
using Shared;

namespace SieraDelta.Website.Members.Controls
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
            _address = GetUser().DeliveryAddresses.Find(SharedUtils.StrToIntDef((string)Page.RouteData.Values["id"], -1));

            if (_address == null)
                DoRedirect("/Account/", true);

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
                //SieraDeltaUtils u = new SieraDeltaUtils();

                ValidateDetails(SharedUtils.ReplaceHTMLElements(txtName.Text, CaseType.Proper), 0, Languages.LanguageStrings.Name);
                ValidateDetails(SharedUtils.ReplaceHTMLElements(txtAddr1.Text, CaseType.Proper), 0, Languages.LanguageStrings.AddressLine1);
                ValidateDetails(SharedUtils.ReplaceHTMLElements(txtCity.Text, CaseType.Proper), 0, Languages.LanguageStrings.City);
                ValidateDetails(SharedUtils.ReplaceHTMLElements(txtCounty.Text, CaseType.Proper), 0, Languages.LanguageStrings.County);
                ValidateDetails(SharedUtils.ReplaceHTMLElements(txtPostCode.Text, CaseType.Proper), 0, Languages.LanguageStrings.Postcode);

                _address.Name = SharedUtils.ReplaceHTMLElements(txtName.Text, CaseType.Proper);
                _address.AddressLine1 = SharedUtils.ReplaceHTMLElements(txtAddr1.Text, CaseType.Proper);
                _address.AddressLine2 = SharedUtils.ReplaceHTMLElements(txtAddr2.Text, CaseType.Proper);
                _address.AddressLine3 = SharedUtils.ReplaceHTMLElements(txtAddr3.Text, CaseType.Proper);
                _address.City = SharedUtils.ReplaceHTMLElements(txtCity.Text, CaseType.Proper);
                _address.County = SharedUtils.ReplaceHTMLElements(txtCounty.Text, CaseType.Proper);
                _address.PostCode = SharedUtils.ReplaceHTMLElements(txtPostCode.Text, CaseType.Upper);
                _address.Country = Countries.Get(Convert.ToInt32(lstCountry.SelectedItem.Value));
                _address.Save();

                if (GetFormValue("redirect") != "")
                    DoRedirect(GetFormValue("redirect"));
                else
                    DoRedirect("/Account/?profileUpdated=true", true);
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
        }

        #endregion Private Methods

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbConfirmDelete.Checked)
                {
                    GetUser().DeliveryAddresses.Delete(_address);
                    DoRedirect("/Account/Address/Delivery/", true);
                }
            }
            catch (System.Exception Err)
            {
                lblError.Visible = true;
                lblError.Text = Err.Message;
            }
        }
    }
}