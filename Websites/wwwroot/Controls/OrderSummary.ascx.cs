using System;

using Library.BOL.Basket;
using Library.BOL.Countries;
using Website.Library.Classes;

using Languages;

namespace SieraDelta.Website.Controls
{
    public partial class OrderSummary : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divOrderDetails.InnerHtml = String.Format("<h3>{0}</h3>{1}", 
                LanguageStrings.OrderDetails, GetOrderSummary());
            divBillingAddress.InnerHtml = String.Format("<h3>{0}</h3>{1}", 
                LanguageStrings.BillingAddress1, GetUser().Address(true));
            divDeliveryAddress.InnerHtml = String.Format("<h3>{0}</h3>{1}", 
                LanguageStrings.DeliveryAddress, 
                GetBasket().ShippingAddress == null ? LanguageStrings.AppNotApplicable : GetBasket().ShippingAddress.Address(true));
        }

        private string GetOrderSummary()
        {
            string Result = "<table border=\"0\" width=\"100%\">";

            ShoppingBasket basket = GetBasket();
            Country country = WebCountry;

            Result += String.Format("<tr><td>{0} {1}</td><td><span>{2}</span></td></tr>", basket.Items.Count, 
                LanguageStrings.Items, 
                Library.Utils.SharedUtils.FormatMoney(basket.SubTotalAmount, GetWebsiteCurrency()));

            Result += String.Format("<tr><td>{0}</td><td><span>{1}</span></td></tr>", LanguageStrings.PostageAndPackaging,
                Library.Utils.SharedUtils.FormatMoney(basket.ShippingCosts, GetWebsiteCurrency()));

            if (!Library.DAL.DALHelper.HideVATOnWebsiteAndInvoices)
            {
                Result += String.Format("<tr><td>{0}</td><td><span>{1}</span></td></tr>", LanguageStrings.VAT,
                    Library.Utils.SharedUtils.FormatMoney(basket.VATAmount, GetWebsiteCurrency()));
            }

            if (basket.DiscountAmount > 0.00m)
                Result += String.Format("<tr><td>{0}</td><td><span>{1}</span></td></tr>", LanguageStrings.Discount,
                    Library.Utils.SharedUtils.FormatMoney(basket.DiscountAmount, GetWebsiteCurrency()));

            Result += String.Format("<tr><td><strong>{0}</strong></td><td><span><strong>{1}</strong></span></td></tr>", LanguageStrings.TotalToPay,
                    Library.Utils.SharedUtils.FormatMoney(basket.TotalAmount, GetWebsiteCurrency()));

            Result += "</Table>";

            return (Result);
        }
    }
}