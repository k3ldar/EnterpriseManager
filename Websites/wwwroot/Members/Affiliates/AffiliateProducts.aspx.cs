using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.BOL.Affiliate;
using Library.BOL.Users;

using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Members.Affiliates
{
    public partial class AffiliateProducts : BaseWebForm
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string countryCode = GetFormValue("Country", "GB");
            string affiliateID = GetFormValue("Affiliate", String.Empty);
            int imageSize = GetFormValue("ImageSize", 148);

            switch (imageSize)
            {
                case 89:
                case 148:
                case 178:
                case 200:
                case 288:
                    break;
                default:
                    Response.Write("Invalid Image Size");
                    Response.End();
                    return;
            }

            if (String.IsNullOrEmpty(affiliateID))
            {
                Response.Write("Invalid Affiliate ID");
                Response.End();
            }

            User user = AffiliatedItems.GetAffiliateUser(affiliateID);

            if (user == null)
            {
                Response.Write("Invalid Affiliate ID");
                Response.End();
            }

            Library.BOL.Affiliate.AffiliateProducts items = Library.BOL.Affiliate.AffiliateProducts.GetAffiliateProducts(
                countryCode, affiliateID, imageSize, Request.Url.GetLeftPart(UriPartial.Authority));
            Response.Write("id,title,description,price,sale_​​price,condition,link,availability,image_link\r\n");

            foreach (AffiliateProduct product in items)
            {
                Response.Write(String.Format("{0},", product.SKU.Trim()));
                Response.Write(String.Format("\"{0}\",", PrepareString(product.Title).Trim()));
                Response.Write(String.Format("\"{0}\",", PrepareString(product.Description).Trim()));
                Response.Write(String.Format("{0},", product.Price));
                Response.Write(String.Format("{0},", product.DiscountPrice));
                Response.Write("new,");
                Response.Write(String.Format("{0},", product.ProductLink.Trim()));
                Response.Write(String.Format("{0},", product.Availability.Trim()));
                Response.Write(String.Format("{0}", product.ImageLink.Trim()));
                Response.Write("\r\n");
            }

            Response.End();
        }

        private string PrepareString(string s)
        {
            string Result = s.Replace("\n", "");
            Result = Result.Replace("\r\r", "\r");
            Result = Result.Replace("\r", " ");
            Result = Library.Utils.HSCUtils.HTMLEncode(Result);
            return (Library.Utils.HSCUtils.PreProcessPost(Result));
        }
    }
}