using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using lib = Library;
using Library.BOL.Products;
using Library.BOL.Users;
using Library.BOL.Basket;
using Library.Utils;
using Website.Library.Classes;
using Library.BOL.Countries;

namespace Website.Library.Classes
{
    public class BaseWebFormProduct : BaseWebForm
    {
        #region Properties

        /// <summary>
        /// Product for page
        /// </summary>
        public Product Product { get; set; }

        #endregion Properties

        #region Protected Methods

        /// <summary>
        /// Retrieves the product group name
        /// </summary>
        /// <returns></returns>
        protected string GetProductGroupName()
        {
            string Result = "{0}";

            Result = String.Format(Result, Product.PrimaryGroup.Description.Trim());

            return (Result);
        }

        /// <summary>
        /// Retrieves a link and description for primary product group
        /// </summary>
        /// <returns></returns>
        protected string GetPrimaryProductGroup()
        {
            string Result = "<a href=\"/All-Products/Group/{0}/\">{1}</a>";

            ProductGroup group = Product.PrimaryGroup;

            if (group != null)
                Result = String.Format(Result, group.SEODescripton, group.Description.Trim());

            return (Result);
        }

        /// <summary>
        /// Retrieves the name of the product
        /// </summary>
        /// <returns></returns>
        protected string GetProductName()
        {
            string Result = Product.Name.Trim();

            return (Result);
        }

        protected string GetFullVideoLink()
        {
            string Result = Product.VideoLink;

            if (!Result.StartsWith("http"))
            {
                //assume a you tube link here
                Result = String.Format("https://www.youtube.com/watch?v={0}", Result);
            }

            return (Result);
        }

        protected string GetVideoLink()
        {
            string Result = Product.VideoLink;

            if (Result.ToLower().StartsWith("https://www.facebook.com/video") || 
                Result.ToLower().StartsWith("http://www.facebook.com/video"))
            {
                //its from facebook
                string fbReference = Result.Replace("video.php?v=", "v/"); // Result.Substring(Result.IndexOf("v=") + 2);
                Result = String.Format("<object width=\"640\" height=\"390\" ><param name=\"allowfullscreen\" value=\"true\" /> " +
                    "<param name=\"allowscriptaccess\" value=\"always\" /> <param name=\"movie\" value=\"{0}\" /> " +
                    "<embed src=\"{0}\" type=\"application/x-shockwave-flash\" allowscriptaccess=\"always\" " +
                    "allowfullscreen=\"true\" width=\"640\" height=\"390\"></embed></object>", fbReference);
            }
            else
                if (!Result.ToLower().StartsWith("http"))
                {
                    //assume a you tube link here
                    Result = String.Format("<iframe width=\"640\" height=\"390\" src=\"https://www.youtube.com/embed/{0}\" frameborder=\"0\"></iframe>", Result);
                }

            return (Result);
        }

        protected void LoadPoductTypes(DropDownList list)
        {
            list.Items.Clear();

            Product.UpdateProductCosts(GetUser(), WebCountry);
            ListItem item = null;

            foreach (ProductCost cost in Product.ProductCosts)
            {
                int priceColumn = ((LocalWebSessionData)GetUserSession().Tag).PriceColumn;
                decimal prodCost = cost.PriceGet(priceColumn, WebCountry);

                if (prodCost > 0.00m)
                {
                    if (BaseWebApplication.PricesIncludeVAT)
                    {
                        prodCost += SharedUtils.VATCalculate(prodCost, WebVATRate);
                    }

                    if (cost.ProductCostType.ID == ProductCostTypes.Get(0).ID)
                    {
                        item = new ListItem(String.Format("{0} ({1})", GetTranslatedDescription(cost.Size),
                            SharedUtils.FormatMoney(prodCost, GetWebsiteCurrency(), false)), cost.ID.ToString());
                    }
                    else
                    {
                        item = new ListItem(String.Format("{2} {0} ({1})", GetTranslatedDescription(cost.Size),
                            SharedUtils.FormatMoney(prodCost, GetWebsiteCurrency(), false),
                            cost.ProductCostType.Description),
                            cost.ID.ToString());
                    }

                    list.Items.Add(item);
                }
            }

            UpdateNotificationSettings();
        }

        protected void LoadQuantities(DropDownList list)
        {
            list.Items.Clear();
            User user = GetUser();
            int Count = 3;

            if (user != null && user.MemberLevel >= lib.MemberLevel.Reseller)
                Count = 20;

            for (int i = 1; i <= Count; i++)
            {
                ListItem item = new ListItem(i.ToString());
                list.Items.Add(item);
            }
        }

        protected virtual void UpdateNotificationSettings()
        {

        }

        #endregion Protected Methods
    }
}
