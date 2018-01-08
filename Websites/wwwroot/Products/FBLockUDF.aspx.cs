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

namespace SieraDelta.Website.Products
{
    public partial class FBLockUDF : BaseWebFormProduct
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.RedirectPermanent("https://github.com/k3ldar/fbLockUDF", true);
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.Categories;
            LeftContainerControl1.SubOptions = GetProductCategories(ProductGroupTypes.Get("Products"));

            Product = Library.BOL.Products.Products.Get(11);

            MediaLinks1.ProductLink = Product;

            //translated data
            //UpdateCustomTranslatedPageData("Firebird Stored Procedure Generator Features", divFeaturesTranslated);
            //UpdateCustomTranslatedPageData("Firebird Stored Procedure Generator Description", divDescriptionTranslated);

            Library.BOL.Downloads.Download downloadFile = Library.BOL.Downloads.Downloads.Get(12, 0);
            FileDownload1.Refresh(downloadFile);
        }
    }
}