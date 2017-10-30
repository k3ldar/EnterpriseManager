using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Products;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class FeaturedProducts : BaseControlClass
    {
        private static DateTime _carouselLastBuilt;
        private static string _carousel = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetCarouselProducts()
        {
            if (Library.DAL.DALHelper.AllowCaching && ((!String.IsNullOrEmpty(_carousel)) && (DateTime.Now - _carouselLastBuilt < Library.DAL.DALHelper.CacheLimit)))
                return (_carousel);

            string Result = "";
            Library.BOL.Products.Products carousel = Library.BOL.Products.Products.GetCarousel();
            int priceColumn = ((LocalWebSessionData)GetUserSession().Tag).PriceColumn;

            foreach (Product product in carousel)
            {
                string image = product.Image.ToLower();

                if (!image.Contains(".png") && !image.Contains(".jpg"))
                    image += "_200.jpg";

                image = HSCUtils.ResizeImage(image, 200);

                if (TreatAsStratosphereProduct(product.PrimaryProduct))
                    Result += String.Format("<li>\r<a href=\"/Products/Stratosphere.aspx?ID={0}\">\r", product.ID);
                else
                    Result += String.Format("<li>\r<a href=\"/Products/Product.aspx?ID={0}\">\r", product.ID);

                Result += String.Format("<img src=\"https://static.heavenskincare.com/Images/Products/{0}\" alt=\"\" border=\"0\" width=\"200\" height=\"145\"/>\r", 
                    image);

                if (product.NewProduct)
                    Result += String.Format("<span class=\"new\" style=\"display:block;\">{0}</span>\r", 
                        Languages.LanguageStrings.NewProduct);
                else
                    Result += String.Format("<span class=\"new\">{0}</span>\r", Languages.LanguageStrings.NewProduct);

                if (product.BestSeller)
                    Result += String.Format("<span class=\"best\" style=\"display:block;\">{0}</span>\r", 
                        Languages.LanguageStrings.BestSeller);
                else
                    Result += String.Format("<span class=\"best\">{0}</span>\r", Languages.LanguageStrings.BestSeller);

                if (ShowPriceData)
                {
                    decimal cost = product.LowestPrice(SharedWebBase.WebsiteCurrency(Session, Request), priceColumn, WebCountry);
                    
                    if (BaseWebApplication.PricesIncludeVAT)
                    {
                        cost += SharedUtils.VATCalculate(cost, WebVATRate);
                    }

                    Result += String.Format("<br />{0}<strong>{2} {1}</strong>\r</a>\r</li>\r", product.Name,
                        SharedUtils.FormatMoney(cost, GetWebsiteCurrency(), false),
                        Languages.LanguageStrings.From);
                }
                else
                    Result += String.Format("<br />{0}\r</a>\r</li>\r", product.Name);
            }

            _carousel = Result;
            _carouselLastBuilt = DateTime.Now;
            return (Result);
        }
    }
}