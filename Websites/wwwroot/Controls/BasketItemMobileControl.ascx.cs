using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class BasketItemMobileControl : BaseControlClass
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

            pImage.InnerHtml = String.Format("<img src=\"/Images/Products/{0}\" alt=\"\" border=\"0\" width=\"89\" height=\"64\"/>", image);

            pDescription.InnerText = String.Format("{0} ", _item.ProductType.Description);

            pDescription.InnerHtml += _item.Description;

            if (_item.ItemType == ProductCostItemType.Product && !String.IsNullOrEmpty(_item.Description)) // || _item.ItemType == Library.Enums.BasketType.FreeProduct)
                pDescription.InnerHtml += String.Format(" - {0}", _item.Description);

            if (_item.OutOfStock)
                pDescription.InnerHtml += String.Format("<br />Out of Stock");

            if (_item.ItemType == ProductCostItemType.FreeProduct)
            {
                pQtyAndPrice.InnerText = "Free";
                pTotal.InnerText = "Free";
            }
            else
            {
                pQtyAndPrice.InnerHtml = String.Format("{0} x {1}", _item.Quantity, SharedUtils.FormatMoney(_item.Price, GetWebsiteCurrency()));
                
                pTotal.InnerText = SharedUtils.FormatMoney(_item.Price * _item.Quantity, GetWebsiteCurrency());
            }

            if (_item.UserDiscount > 0.0m)
            {
                pQtyAndPrice.InnerHtml += String.Format("<br /><span style=\"font-size: 0.8em;\">{0}</span>", String.Format(Languages.LanguageStrings.Discounted, _item.UserDiscount,
                    SharedUtils.FormatMoney(_item.Price, GetWebsiteCurrency())));
            }

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