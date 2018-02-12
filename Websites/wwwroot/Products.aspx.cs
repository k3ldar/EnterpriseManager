using System;
using System.Web.UI;
using Library.Utils;
using Library.BOL.Products;
using Library.BOL.Websites;

using Website.Library.Classes;

namespace SieraDelta.Website
{
    public partial class PageProducts : BaseWebForm
    {
        #region Private Members

        private Int64 _groupID;

        #endregion Private Members

        protected void Page_Load(object sender, EventArgs e)
        {
            string SKU = GetFormValue("SKU", String.Empty).ToUpper();

            if (!String.IsNullOrEmpty(SKU) && Library.BOL.Products.Products.IsValidSKU(SKU))
            {
                Library.BOL.Products.Products products = Library.BOL.Products.Products.GetBySKU(SKU);
                DoRedirect(products.First().URL);
            }

            string prodRouteGroupName = (string)Page.RouteData.Values["group"];

            if (!String.IsNullOrEmpty(prodRouteGroupName))
            {
                Library.BOL.Users.User currentUser = GetUser();

                string group = String.Format("{0}{1}",
                    currentUser == null ? Library.MemberLevel.StandardUser.ToString() : currentUser.MemberLevel.ToString(),
                    prodRouteGroupName);

                if (BaseWebApplication.AllRoutes.ContainsKey(group))
                {
                    _groupID = BaseWebApplication.AllRoutes[group];
                }
            }
            else
            {
                _groupID = GetFormValue("GroupID", -1);
            }

            ProductGroup prodGroup = ProductGroups.Get(_groupID);

            if (prodGroup != null)
            {
                if (prodGroup.GroupType.ID == 0)
                    spanSubHeader.Visible = false;
                else
                    spanSubHeader.Visible = true;
            }
            else
            {
                spanSubHeader.Visible = false;
            }

            LeftContainerControl1.SubHeader = Languages.LanguageStrings.Categories;
            LeftContainerControl1.SubOptions = GetProductCategories(_groupID, true, GetUserSession().MobileRedirect);
        }

        protected string GetProductGroupName()
        {
            ProductGroup group = ProductGroups.Get(_groupID);

            if (group != null)
            {
                divTitle.Attributes.Add("class", group.GroupType.Description.Replace(" ", ""));
                return (group.Description.Trim());
            }

            divTitle.Attributes.Add("class", "General");

            return (Languages.LanguageStrings.AllProducts);
        }

        protected string GetProducts(int size)
        {
            Library.BOL.Countries.Country localCountry = WebCountry;

            string Result = "";

            if (_groupID == -1)
            {
                Result = GetProducts(ProductTypes.Get("All"), size);
            }
            else
            {
                int productPage = GetFormValue("Page", 1);

                if (Page.RouteData.Values.ContainsKey("Page"))
                    productPage = SharedUtils.StrToIntDef((string)Page.RouteData.Values["page"], productPage);

                ProductGroup group = ProductGroups.Get(_groupID);
                Library.BOL.Products.Products products = Library.BOL.Products.Products.Get(ProductTypes.Get("All"), productPage, 12, group);
                int priceColumn = ((LocalWebSessionData)GetUserSession().Tag).PriceColumn;

                foreach (Product product in products)
                {
                    string PriceFrom = "";

                    if (ShowPriceData)
                    {
                        decimal priceFrom = product.LowestPrice(SharedWebBase.WebsiteCurrency(Session, Request), priceColumn, WebCountry);

                        if (priceFrom > 999999.0m && !product.FreeProduct)
                        {
                            continue;
                        }

                        if (WebsiteSettings.Tax.PricesIncludeVAT)
                        {
                            priceFrom += SharedUtils.VATCalculate(priceFrom, WebVATRate);
                        }

                        if (product.FreeProduct)
                            PriceFrom = "<strong>Free</strong>";
                        else
                            PriceFrom = String.Format("<strong>{1} {0}</strong>",
                                SharedUtils.FormatMoney(priceFrom, GetWebsiteCurrency(), false),
                                Languages.LanguageStrings.From);
                    }

                    string image = product.Image.ToLower();

                    if (!image.Contains(".png") && !image.Contains(".jpg"))
                        image += "_178.jpg";

                    image = SharedUtils.ResizeImage(image, size);


                    Result += String.Format("<li class=\"professional\"><a href=\"{0}\"><img src=\"/Images/Products/{1}\" alt=\"I\" border=\"0\" width=\"178\" height=\"128\"/>" +
                        "<span class=\"new\" {5}>{6}</span><span class=\"best\" {4}>{7}</span><br />{2}{3}</a></li>\r\n",
                        product.URL, image, product.Name, PriceFrom,
                        product.BestSeller ? " style=\"display:block;\"" : "", product.NewProduct ? " style=\"display:block;\"" : "",
                        Languages.LanguageStrings.NewProduct, Languages.LanguageStrings.BestSeller);

                }
            }

            return (Result);
        }

        protected string GetSubHeader()
        {
            ProductGroup group = ProductGroups.Get(_groupID);

            if (group != null)
            {
                if (group.GroupType.ID == 0)
                    return (String.Empty);
                else
                    return (group.SubHeader.Trim());
            }

            return (Languages.LanguageStrings.AllProducts);
        }

        protected string GetProductTitle()
        {
            ProductGroup group = ProductGroups.Get(_groupID);

            if (group != null)
            {
                if (group.GroupType.ID == 0)
                    return (group.Description.Trim());
                else
                    return (group.MainHeader.Trim());
            }

            return (Languages.LanguageStrings.AllProducts);
        }

        protected string BuildPagination()
        {
            int count = 0;

            if (_groupID == -1)
                count = Library.BOL.Products.Products.GetCount(ProductTypes.Get("All"));
            else
                count = Library.BOL.Products.Products.CountByProduct(ProductGroups.Get(_groupID));

            string prodRouteGroupName = (string)Page.RouteData.Values["group"];

            if (String.IsNullOrEmpty(prodRouteGroupName))
                prodRouteGroupName = "All-Products/";
            else
                prodRouteGroupName = "All-Products/Group/" + prodRouteGroupName + "/";

            int productPage = GetFormValue("Page", 1);

            if (Page.RouteData.Values.ContainsKey("Page"))
                productPage = SharedUtils.StrToIntDef((string)Page.RouteData.Values["page"], productPage);

            return (BuildPagination(count, 12, productPage, "/" + prodRouteGroupName, true));
        }
    }
}