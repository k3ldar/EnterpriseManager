using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using lib = Library;
using Website.Library;
using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Products;
using Shared.Classes;

namespace SieraDelta.Website.Controls
{
    public partial class FeaturedProducts : BaseControlClass
    {
        #region Private Members


        #endregion Private Members

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetScrollCount()
        {
            UserSession session = GetUserSession();

            if (session.IsMobileDevice)
            {
                return ("1");
            }
            else
            {
                return ("3");
            }
        }

        protected string GetCarouselProducts(bool clickable = true)
        {
            string currency = String.Format("FEATURED BY CURRENCY {0}", GetWebsiteCurrency().CurrencyCode);

            CacheItem item = GlobalClass.InternalCache.Get(currency);

            if (item != null)
                return ((string)item.Value);


            string Result = String.Empty;
            int priceColumn = ((LocalWebSessionData)GetUserSession().Tag).PriceColumn;

            // if we get this far then the carousel hasn't been built for the currency
            lib.BOL.Products.Products carousel = lib.BOL.Products.Products.GetFeaturedProducts();

            foreach (Product product in carousel)
            {
                string image = product.Image.ToLower();

                if (!image.Contains(".png") && !image.Contains(".jpg"))
                    image += "_200.jpg";

                image = LibUtils.ResizeImage(image, 200);

                if (clickable)
                    Result += String.Format("<li>\r<a href=\"/All-Products/Group/{0}/{1}/\">\r",
                        product.PrimaryGroup.SEODescripton, product.NameSEO);
                else
                    Result += "<li>\r";

                Result += String.Format("<img src=\"/Images/Products/{0}\" " +
                    "alt=\"I\" style=\"border: 0;\" width=\"200\" height=\"145\"/>\r", image);

                if (product.NewProduct)
                    Result += String.Format("<span class=\"new\" style=\"display:block;\">{0}</span>\r",
                        Languages.LanguageStrings.NewProduct);

                if (!product.NewProduct && product.BestSeller)
                    Result += String.Format("<span class=\"best\" style=\"display:block;\">{0}</span>\r",
                        Languages.LanguageStrings.BestSeller);

                if (ShowPriceData)
                {
                    decimal cost = product.LowestPrice(SharedWebBase.WebsiteCurrency(Session, Request), priceColumn, WebCountry);

                    if (BaseWebApplication.PricesIncludeVAT)
                    {
                        cost += SharedUtils.VATCalculate(cost, WebVATRate);
                    }

                    Result += String.Format("<br /><div class=\"textDirection\">{0}<strong>{2} {1}</strong></div>\r</a>\r</li>\r", product.Name,
                        SharedUtils.FormatMoney(cost, GetWebsiteCurrency(), false),
                        Languages.LanguageStrings.From);
                }
                else
                {
                    Result += String.Format("<br /><div class=\"textDirection\">{0}</div>\r</a>\r</li>\r", product.Name);
                }
            }

            item = new CacheItem(currency, Result);
            GlobalClass.InternalCache.Add(currency, item);

            return (Result);
        }

        #endregion Protected Methods
    }
}