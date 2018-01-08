using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Website.Library.Classes;
using Library.BOL.Basket;
using Library.BOL.Products;
using Library.Utils;

namespace SieraDelta.Website.Controls
{
    public partial class BasketItemControl : BaseControlClass
    {
        private BasketItem _item;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Refresh(BasketItem basketItem)
        {
            _item = basketItem;
            
            //SieraDeltaUtils u = new SieraDeltaUtils();

            string image = _item.Image.ToLower();
            image = SharedUtils.ResizeImage(image, 89);

            tdImage.InnerHtml = String.Format("<img src=\"/Images/Products/{0}\" alt=\"\" border=\"0\" width=\"89\" height=\"64\"/>", image);

            tdDescription.InnerText = "";

            tdDescription.InnerText = String.Format("{0} ", _item.ProductType.Description);

            tdDescription.InnerHtml += _item.Description;

            if (_item.ItemType == ProductCostItemType.Product && !String.IsNullOrEmpty(_item.Description)) // || _item.ItemType == Library.Enums.BasketType.FreeProduct)
                tdDescription.InnerHtml += String.Format(" - {0}", _item.Description);

            if (_item.OutOfStock)
                tdDescription.InnerHtml += String.Format("<br />Out of Stock");

            if (_item.ItemType == ProductCostItemType.FreeProduct)
            {
                tdPrice.InnerText = "Free";
                tdTotal.InnerText = "Free";
            }
            else
            {
                tdPrice.InnerText = SharedUtils.FormatMoney(_item.Price, GetWebsiteCurrency());
                tdTotal.InnerText = SharedUtils.FormatMoney(_item.Price * _item.Quantity, GetWebsiteCurrency());
            }

            if (_item.UserDiscount > 0.0m)
            {
                tdPrice.InnerHtml += String.Format("<br /><span style=\"font-size: 0.8em;\">{0}</span>", String.Format(Languages.LanguageStrings.Discounted, _item.UserDiscount,
                    SharedUtils.FormatMoney(_item.Price, GetWebsiteCurrency())));
            }

            lblQuantity.Text = _item.Quantity.ToString();

            btnDecreaseQuantity.Visible = _item.ItemType != ProductCostItemType.GiftWrap;
            btnIncreaseQuantity.Visible = _item.ItemType != ProductCostItemType.GiftWrap;
        }

        protected void btnRemoveItem_Click(object sender, ImageClickEventArgs e)
        {
            if (_item != null)
            {
                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
                localData.Basket.Delete(_item);
                DoRedirect("/Shopping/Basket/", true);
            }
        }

        protected void btnIncreaseQuantity_Click(object sender, EventArgs e)
        {
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            ProductCost item = ProductCosts.Get(_item.ItemID);
            localData.Basket.Add(item, 1, GetUser(), ProductCostItemType.Product,
                localData.Basket.Currency.PriceColumn);

            UpdateBasketItemTotals();
            DoRedirect("/Shopping/Basket/");
        }

        protected void btnDecreaseQuantity_Click(object sender, EventArgs e)
        {
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            ProductCost item = ProductCosts.Get(_item.ItemID);
            localData.Basket.DecreaseQuantity(item, --_item.Quantity, GetUser(), localData.Basket.Currency.PriceColumn);
            UpdateBasketItemTotals();
            DoRedirect("/Shopping/Basket/");
        }

        private void UpdateBasketItemTotals()
        {
            //for each item in the basket, reset the price depending on the new price option
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;

            foreach (BasketItem item in localData.Basket.Items)
            {
                item.Price = ProductCosts.Get(item.ItemID).PriceGet(localData.Basket.Country);
            }

            localData.Basket.Reset(localData.PriceColumn);
        }
    }
}