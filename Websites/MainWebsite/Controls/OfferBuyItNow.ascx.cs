using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Basket;
using Library.BOL.Products;
using Library;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class OfferBuyItNow : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                lstProductTypes.Items.Clear();
                ProductCosts costs = ProductCosts.Get();

                foreach (ProductCost cost in costs)
                {
                    decimal itemCost = cost.PriceGet(((LocalWebSessionData)GetUserSession().Tag).PriceColumn, WebCountry);
                    
                    if (BaseWebApplication.PricesIncludeVAT)
                    {
                        itemCost += SharedUtils.VATCalculate(itemCost, WebVATRate);
                    }

                    ListItem item = new ListItem(String.Format("{0} {1} ({2})", cost.Product.Name, cost.Size,
                        SharedUtils.FormatMoney(itemCost, GetWebsiteCurrency(), false)), cost.ID.ToString());
                    lstProductTypes.Items.Add(item);
                }
            }
        }


        protected void btnAddToBasket_Click(object sender, ImageClickEventArgs e)
        {
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            
            ListItem item = lstProductTypes.Items[lstProductTypes.SelectedIndex];
            localData.Basket.Add(ProductCosts.Get(Shared.Utilities.StrToIntDef(item.Value, 0)), 1, GetUser(),
                Enums.BasketType.Product, localData.Basket.Currency.PriceColumn);
            DoRedirect("/Basket/Basket.aspx");
        }
    }
}