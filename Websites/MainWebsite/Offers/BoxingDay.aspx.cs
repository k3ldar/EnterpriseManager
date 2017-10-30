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
    public partial class BoxingDay : BaseWebFormOffers
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageAvailable = Global.BoxingDayPageStart;
            PageExpires = Global.BoxingDayPageEnd;

            string[] skuList = Global.BoxingDayPageSKUCodes.Split(';');

            if (skuList.Length == 0)
                DoRedirect("/Index.aspx", true);

            LoadProductSKUs(skuList);
        }

        #region Private Methods

        private void LoadProductSKUs(string[] skuList)
        {
            foreach (string sku in skuList)
            {
                Heavenskincare.WebsiteTemplate.Controls.BuyItNow bin = (Heavenskincare.WebsiteTemplate.Controls.BuyItNow)LoadControl("~/Controls/BuyItNow.ascx");
                bin.UseProductName = true;
                bin.PriceFontColour = "purple";
                bin.Product = Library.BOL.Products.ProductCosts.GetBySKU(sku);

                divBuyItNowItems.Controls.Add(bin);
            }
        }

        #endregion Private Methds

    }
}