using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Heavenskincare.Website.Library.Classes;
using Heavenskincare.Library.BOL.Products;
using Heavenskincare.Library.Utils;
using Heavenskincare.Library.BOL.Countries;
using Heavenskincare.Library.BOL.Users;

namespace Heavenskincare.Website.Admin
{
    public partial class SiteMaster : BaseMasterClassWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string BaseURL()
        {
            return (Heavenskincare.Website.Library.GlobalClass.RootURL);
        }

        protected string GetFeaturedProduct()
        {
            string Result;
            HSCUtils u = new HSCUtils();
            Product featured = Heavenskincare.Library.BOL.Products.Products.GetFeatured();

            Result = String.Format("<a href=\"/Products/Product.aspx?ID={0}\">", featured.ID);
            Result += String.Format("<img src=\"http://www.heavenskincare.com/Images/Product/{0}_148.jpg\" alt=\"\" border=\"0\" width=\"148\" height=\"114\"/>", featured.Image);

            if (ShowPriceData)
                Result += String.Format("{0}<strong>from {1}</strong></a>", featured.Name, u.FormatMoney(featured.LowestPrice(), Countries.Get(CountryCode)));
            else
                Result += String.Format("{0}</a>", featured.Name);

            return (Result);
        }

        protected string GetUserName()
        {
            string Result = "";

            User currentUser = GetUser();

            if (currentUser != null)
                Result = currentUser.UserName;

            return (Result);
        }

    }
}
