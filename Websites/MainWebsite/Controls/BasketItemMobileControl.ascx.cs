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

namespace Heavenskincare.WebsiteTemplate.Controls
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

            string image = _item.Image.ToLower();
            image = SharedUtils.ResizeImage(image, 89);

            pImage.InnerHtml = String.Format("<a href=\"/Products/Product.aspx?ID={0}\"><img " +
                "src=\"https://static.heavenskincare.com/Images/Products/{0}\" " +
                "alt=\"\" border=\"0\" width=\"89\" height=\"64\"/></a>", _item.Product.ID, image);

            string description = String.Format("{0} ", _item.ProductType.Description);

            description += _item.Description;

            if (_item.ItemType == Library.Enums.BasketType.Product && !String.IsNullOrEmpty(_item.Size)) // || _item.ItemType == Library.Enums.BasketType.FreeProduct)
                description += String.Format(" - {0}", _item.Size);

            if (_item.OutOfStock)
                description += String.Format("<br />Out of Stock");

            pDescription.InnerHtml = String.Format("<a href=\"/Products/Product.aspx?ID={0}\">{1}</a>", 
                _item.Product.ID, description);

            if (_item.ItemType == Library.Enums.BasketType.FreeProduct)
            {
                pQtyAndPrice.InnerText = "Free";
                pTotal.InnerText = "Free";
            }
            else
            {
                if (Global.ShowBasketItemsWithVAT)
                {
                    pQtyAndPrice.InnerHtml = String.Format("{0} x {1}", _item.Quantity, SharedUtils.FormatMoney(_item.PriceWithDiscount, GetWebsiteCurrency()));
                    pTotal.InnerText = SharedUtils.FormatMoney(_item.PriceWithDiscount * _item.Quantity, GetWebsiteCurrency());
                }
                else
                {
                    pQtyAndPrice.InnerHtml = String.Format("{0} x {1}", _item.Quantity, SharedUtils.FormatMoney(SharedUtils.VATRemove(_item.PriceWithDiscount, WebVATRate), GetWebsiteCurrency()));
                    pTotal.InnerText = SharedUtils.FormatMoney(SharedUtils.VATRemove(_item.PriceWithDiscount, WebVATRate) * _item.Quantity, GetWebsiteCurrency());
                }
            }

            if (_item.UserDiscount > 0.0m)
            {
                pQtyAndPrice.InnerHtml += String.Format("<br /><span style=\"font-size: 0.8em;\">{0}</span>", String.Format(Languages.LanguageStrings.Discounted, _item.UserDiscount,
                    SharedUtils.FormatMoney(_item.Price, GetWebsiteCurrency())));
            }

            btnDecreaseQuantity.Visible = _item.ItemType != Library.Enums.BasketType.GiftWrap;
            btnIncreaseQuantity.Visible = _item.ItemType != Library.Enums.BasketType.GiftWrap;
        }

        protected void btnRemoveItem_Click(object sender, ImageClickEventArgs e)
        {
            if (_item != null)
            {
                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
                localData.Basket.Delete(_item);
                DoRedirect("/Basket/Basket.aspx", true);
            }
        }

        protected void btnIncreaseQuantity_Click(object sender, EventArgs e)
        {
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            ProductCost item = ProductCosts.Get(_item.ItemID);
            localData.Basket.Add(item, 1, GetUser(), Library.Enums.BasketType.Product, 
                localData.Basket.Currency.PriceColumn);
            UpdateBasketItemTotals();
            DoRedirect("/Basket/Basket.aspx");
        }

        protected void btnDecreaseQuantity_Click(object sender, EventArgs e)
        {
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            ProductCost item = ProductCosts.Get(_item.ItemID);
            localData.Basket.DecreaseQuantity(item, --_item.Quantity, GetUser(), localData.Basket.Currency.PriceColumn);
            UpdateBasketItemTotals();
            DoRedirect("/Basket/Basket.aspx");
        }

        private void UpdateBasketItemTotals()
        {
            //for each item in the basket, reset the price depending on the new price option
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;

            foreach (BasketItem item in localData.Basket.Items)
            {
                item.Price = ProductCosts.Get(item.ItemID).PriceGet(localData.PriceColumn, WebCountry);
            }

            localData.Basket.Reset(localData.PriceColumn);
        }

    }
}