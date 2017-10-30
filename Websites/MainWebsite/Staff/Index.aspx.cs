using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.BOL.Countries;
using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Staff
{
    public partial class Index : BaseWebFormSalesAdvisor
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ipAddress = GetFormValue("IPAddress", String.Empty);

            if (!String.IsNullOrEmpty(ipAddress))
            {
                string countryCode = Library.LibraryHelperClass.IPAddressToCountry(ipAddress);
                Country country = Countries.Get(countryCode);
                pIPAddress.InnerText = String.Format("IP Address {0} belongs to {1}", ipAddress, country.Name);
            }
        }
    }
}