using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Languages;
using Library;
using Library.BOL.Basket;
using Library.BOL.Products;
using Library.BOL.Countries;
using Library.BOL.TagLines;
using Library.Utils;
using Shared.Classes;
using Website.Library;
using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Offers
{
    public partial class SpecialOffers : BaseWebFormOffers
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageAvailable = Global.SpecialOffersPageStart;
            PageExpires = Global.SpecialOffersPageEnd;
            LeftContainerControl1.Visible = Global.SOToolbar;

            string[] skuList = Global.SpecialOffersPageSKUCodes.Split(';');

            if (skuList.Length == 0)
                DoRedirect("/Index.aspx", true);

            if (!Global.SOToolbar)
                divMainContent.Style.Add("float", "left");

            LoadProductSKUs(skuList);
        }

        #region Private Methods

        private void LoadProductSKUs(string[] skuList)
        {
            foreach (string sku in skuList)
            {
                Heavenskincare.WebsiteTemplate.Controls.BuyItNow bin = (Heavenskincare.WebsiteTemplate.Controls.BuyItNow)LoadControl("~/Controls/BuyItNow.ascx");
                bin.UseProductName = true;
                bin.PriceFontColour = Global.SOPriceColor;
                bin.Product = Library.BOL.Products.ProductCosts.GetBySKU(sku);

                divBuyItNowItems.Controls.Add(bin);
            }
        }

        #endregion Private Methds
    }
}