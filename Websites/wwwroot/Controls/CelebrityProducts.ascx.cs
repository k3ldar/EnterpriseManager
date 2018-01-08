using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SieraDelta.Website.Library.Classes;
using SieraDelta.Library.Utils;
using SieraDelta.Library.BOL.Products;

namespace SieraDelta.Website.Controls
{
    public partial class CelebrityProducts : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetCelebrityProducts()
        {
            string Result = "";
            //SieraDeltaUtils u = new SieraDeltaUtils();
            SieraDelta.Library.BOL.Products.Products celebproducts = SieraDelta.Library.BOL.Products.Products.Get(SieraDelta.Library.BOL.Celebrities.Celebrities.Get(GetFormValue("ID", -1)));

            foreach (Product product in celebproducts)
            {
                string image = product.Image.ToLower();

                if (!image.Contains(".png") && !image.Contains(".jpg"))
                    image += "_200.jpg";

                image = SieraDeltaUtils.ResizeImage(image, 200);

                Result += String.Format("<li>\r<a href=\"/Products/Product.aspx?ID={0}\">\r", product.ID);
                Result += String.Format("<img src=\"http://www.SieraDelta.com/Images/Product/{0}\" alt=\"\" border=\"0\" width=\"200\" height=\"145\"/>\r", image);

                if (product.NewProduct)
                    Result += String.Format("<span class=\"new\" style=\"display:block;\">{0}</span>\r", SieraDelta.Languages.LanguageStrings.NewProduct);
                else
                    Result += String.Format("<span class=\"new\">{0}</span>\r", SieraDelta.Languages.LanguageStrings.NewProduct);

                if (product.BestSeller)
                    Result += String.Format("<span class=\"best\" style=\"display:block;\">{0}</span>\r", SieraDelta.Languages.LanguageStrings.BestSeller);
                else
                    Result += String.Format("<span class=\"best\">{0}</span>\r", SieraDelta.Languages.LanguageStrings.BestSeller);

                Result += String.Format("<br />{0}<strong>{2} {1}</strong>\r</a>\r</li>\r", product.Name, SieraDeltaUtils.FormatMoney(product.LowestPrice(WebCountry), WebCountry, Thread.CurrentThread.CurrentUICulture.Name),
                    SieraDelta.Languages.LanguageStrings.From);
            }

            return (Result);
        }
    }
}