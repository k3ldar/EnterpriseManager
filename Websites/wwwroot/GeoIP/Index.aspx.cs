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
    public partial class Index : BaseWebForm
    {
        private decimal _latValue = 52.9333m;
        private decimal _lonValue = 1.100m;
        private string _city = "Salthouse";
        private string _country = "United Kingdom";
        private string _ipAddress = "70.38.12.72";
        private string _region;
        private string _postCode;
        private string _metroCode;
        private string _areaCode;
        private string _numeric;
        private string _startBlock;
        private string _endBlock;

        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.Categories;
            LeftContainerControl1.SubOptions = GetProductCategories(ProductGroupTypes.Get("Products"));

            btnLookup.Text = Languages.LanguageStrings.LookupIPAddress;

            if (IsPostBack)
            {
                if (String.IsNullOrEmpty(txtIPAddress.Text) || !Shared.Utilities.ValidateIPAddress(txtIPAddress.Text.Trim()))
                {
                    _ipAddress = Request.ServerVariables["REMOTE_HOST"];
                }

                _ipAddress = txtIPAddress.Text;
            }
            else
            {
                _ipAddress = Request.ServerVariables["REMOTE_HOST"];
                txtIPAddress.Text = _ipAddress;
            }

            if (!Shared.Utilities.ValidateIPAddress(_ipAddress) || _ipAddress.Contains(":"))
            {
                _ipAddress = "105.58.65.32";
                txtIPAddress.Text = _ipAddress;
            }

            
            IPCity ipData = IPCity.Get(Request.ServerVariables["REMOTE_HOST"], _ipAddress);

            _latValue = ipData.Latitude;
            _lonValue = ipData.Longitude;
            _country = ipData.Country;
            _city = ipData.City;
            _region = ipData.Region;
            _postCode = ipData.Postcode;
            _metroCode = ipData.MetroCode;
            _areaCode = ipData.AreaCode;
            _numeric = ipData.Numeric.ToString();
            _startBlock = ipData.StartBlock.ToString();
            _endBlock = ipData.EndBlock.ToString();

            pOwnIP.Visible = txtIPAddress.Text == Request.ServerVariables["REMOTE_HOST"];
        }

        protected string GetUserIP()
        {
            return (Request.ServerVariables["REMOTE_HOST"]);
        }

        protected decimal GetLatValue()
        {
            return (_latValue);
        }

        protected decimal GetLonValue()
        {
            return (_lonValue);
        }

        protected string GetCity()
        {
            return (_city);
        }

        protected string GetCountry()
        {
            return (_country);
        }

        protected string GetIPAddress()
        {
            return (_ipAddress);
        }

        protected string GetRegion()
        {
            return (_region);
        }

        protected string GetPostCode()
        {
            return (_postCode);
        }

        protected string GetMetroCode()
        {
            return (_metroCode);
        }

        protected string GetAreaCode()
        {
            return (_areaCode);
        }

        protected string GetNumeric()
        {
            return (_numeric);
        }

        protected string GetStartBlock()
        {
            return (_startBlock);
        }

        protected string GetEndBlock()
        {
            return (_endBlock);
        }
    }
}