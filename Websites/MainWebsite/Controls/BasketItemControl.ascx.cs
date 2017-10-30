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

namespace Heavenskincare.WebsiteTemplate.Controls
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
            
            string image = _item.Image.ToLower();
            bool isNail = false;

            if (String.IsNullOrEmpty(image))
            {
                if (_item.Product.PrimaryProduct.Description == "Nails")
                {
                    ProductCost costItem = ProductCosts.Get(_item.ItemID);
                    tdImage.InnerHtml = String.Format("<a href=\"/Products/HeavenNails.aspx\"><img " +
                        "src=\"https://static.heavenskincare.com/Images/Products/Nails/{0}.png\" alt=\"\" border=\"0\" " +
                        "width=\"33\" height=\"64\"/></a>",
                        costItem.SKU);
                    isNail = true;
                }
            }
            else
            {
                image = SharedUtils.ResizeImage(image, 89);

                tdImage.InnerHtml = String.Format("<a href=\"/Products/Product.aspx?ID={0}\"><img " +
                    "src=\"https://static.heavenskincare.com/Images/Products/{1}\" alt=\"\" border=\"0\" " +
                    "width=\"89\" height=\"64\"/></a>",
                    _item.Product.ID, image);
            }

            string description = String.Format("{0} ", _item.ProductType.Description);

            description += _item.Description;

            if (_item.ItemType == Library.Enums.BasketType.Product && !String.IsNullOrEmpty(_item.Size)) // || _item.ItemType == Library.Enums.BasketType.FreeProduct)
                description += String.Format(" - {0}", _item.Size);

            if (_item.OutOfStock)
                description += String.Format("<br />Out of Stock");

            if (isNail)
            {
                tdDescription.InnerHtml = String.Format("<a href=\"/Products/HeavenNails.aspx\">{0}</a>",
                    description);
            }
            else
            {
                tdDescription.InnerHtml = String.Format("<a href=\"/Products/Product.aspx?ID={0}\">{1}</a>",
                    _item.Product.ID, description);
            }

            if (_item.ItemType == Library.Enums.BasketType.FreeProduct)
            {
                tdPrice.InnerText = "Free";
                tdTotal.InnerText = "Free";
            }
            else
            {
                if (Global.ShowBasketItemsWithVAT)
                {
                    tdPrice.InnerText = SharedUtils.FormatMoney(_item.PriceWithDiscount +
                        SharedUtils.VATCalculate(_item.PriceWithDiscount, GetBasket().VATRate), 
                        GetWebsiteCurrency());
                    tdTotal.InnerText = SharedUtils.FormatMoney(_item.PriceWithDiscount * _item.Quantity +
                        SharedUtils.VATCalculate(_item.PriceWithDiscount * _item.Quantity, 
                        GetBasket().VATRate), GetWebsiteCurrency());
                }
                else
                {
                    tdPrice.InnerText = SharedUtils.FormatMoney(_item.PriceWithDiscount, GetWebsiteCurrency());
                    tdTotal.InnerText = SharedUtils.FormatMoney(_item.PriceWithDiscount * _item.Quantity, GetWebsiteCurrency());
                }
            }

            if (_item.UserDiscount > 0.0m)
            {
                tdPrice.InnerHtml += String.Format("<br /><span style=\"font-size: 0.8em;\">{0}</span>", String.Format(Languages.LanguageStrings.Discounted, _item.UserDiscount, 
                    SharedUtils.FormatMoney(_item.Price, GetWebsiteCurrency())));
            }

            lblQuantity.Text = _item.Quantity.ToString();

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