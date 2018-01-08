using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Basket;
using Library.BOL.Products;

namespace SieraDelta.Website.Controls
{
    public partial class OfferBuyItNow : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //SieraDeltaUtils u = new SieraDeltaUtils();
                lstProductTypes.Items.Clear();
                ProductCosts costs = ProductCosts.Get();

                foreach (ProductCost cost in costs)
                {
                    ListItem item = new ListItem(String.Format("{0} {1} ({2})", cost.Product.Name, cost.Size, 
                        SharedUtils.FormatMoney(cost.PriceGet(WebCountry), GetWebsiteCurrency())), cost.ID.ToString());
                    lstProductTypes.Items.Add(item);
                }
            }
        }


        protected void btnAddToBasket_Click(object sender, ImageClickEventArgs e)
        {
            //SieraDeltaUtils u = new SieraDeltaUtils();
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            ListItem item = lstProductTypes.Items[lstProductTypes.SelectedIndex];
            localData.Basket.Add(ProductCosts.Get(SharedUtils.StrToIntDef(item.Value, 0)), 1, GetUser(),
                Library.ProductCostItemType.Product, localData.Basket.Currency.PriceColumn);
            DoRedirect("/Shopping/Basket/");
        }
    }
}