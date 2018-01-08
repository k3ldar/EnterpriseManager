using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Library.Utils;
using Website.Library.Classes;
using Library.BOL.Products;
using Library.BOL.Users;
using Library.BOL.Basket;
using Library.BOL.Countries;
using Library.BOL.CustomWebPages;
using Library.BOL.IPAddresses;

namespace SieraDelta.Website.GeoIP
{
    public partial class UpdateLocation : BaseWebForm
    {
        private const decimal DEFAULT_LL_VALUE = -999999.9999m;

        private decimal _lat = DEFAULT_LL_VALUE;
        private decimal _lon = DEFAULT_LL_VALUE;
        private string _error = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.Categories;
            LeftContainerControl1.SubOptions = GetProductCategories(ProductGroupTypes.Get("Products"));

            _lat = GetFormValue("lat", DEFAULT_LL_VALUE);
            _lon = GetFormValue("lon", DEFAULT_LL_VALUE);
            _error = GetFormValue("error", String.Empty);

            if (!String.IsNullOrEmpty(_error))
            {
                divTownSelect.Visible = false;
                pUserDetails.Visible = false;
                pPrompt.Visible = false;
                pThanks.Visible = false;
                pError.Visible = true;
            }
            else
            {
                pError.Visible = false;
                pThanks.Visible = false;

                if (_lat != DEFAULT_LL_VALUE && _lon != DEFAULT_LL_VALUE)
                {
                    if (!IsPostBack)
                        LoadNearestCities();

                    divTownSelect.Visible = true;
                    pUserDetails.Visible = true;
                    pPrompt.Visible = false;
                    btnSubmit.Text = Languages.LanguageStrings.Submit;
                }
                else
                {
                    divTownSelect.Visible = false;
                    pUserDetails.Visible = false;
                    pPrompt.Visible = true;
                }
            }
        }

        protected string GetUserIP()
        {
            return (Request.ServerVariables["REMOTE_HOST"]);
        }

        private void LoadNearestCities()
        {
            List<IPCity> nearest = IPCity.Get(_lat, _lon, Library.LibraryHelperClass.IPAddressToCountry(Request.ServerVariables["REMOTE_HOST"]));

            foreach (IPCity city in nearest)
            {
                ListItem item = new ListItem(String.Format("{0} {1}", city.City, city.Postcode), city.ID.ToString());
                cityList.Items.Add(item);
            }
        }

        protected string GetLatLong()
        {
            return (String.Format("Latitude {0}<br />Longitude {1}", Math.Round(_lat, 4), Math.Round(_lon, 4)));
        }

        protected string GetReload()
        {
            if (_lat == DEFAULT_LL_VALUE && _lon == DEFAULT_LL_VALUE && String.IsNullOrEmpty(_error))
                return ("true");
            else
                return ("false");
        }

        protected string GetError()
        {
            return (_error);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string locationID = cityList.Items[cityList.SelectedIndex].Value;
            string town = cityList.Items[cityList.SelectedIndex].Text;

            string message = String.Format("Latitude: {0}<br />Longitude: {1}<br />IP Address: {2}<br />Town: {3}<br />Location ID: {4}<p>{5}</p>",
                _lat, _lon, Request.ServerVariables["REMOTE_HOST"], town, locationID, txtAdditionalInfo.Text);

            Global.SendEmail("Updated GeoIP Location", message);

            divTownSelect.Visible = false;
            pUserDetails.Visible = false;
            pPrompt.Visible = false;
            pThanks.Visible = true;
            pError.Visible = false;

        }
    }
}