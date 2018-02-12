using System;

using Shared.Classes;
using lib = Library;
using Library.BOL.Basket;
using Library.BOL.Websites;

#pragma warning disable IDE1006
#pragma warning disable IDE0029

namespace Website.Library.Classes.Web
{
    public static class DebugInfo
    {
        public static void PrintDebugInfo(System.Web.SessionState.HttpSessionState Session, 
            System.Web.HttpRequest Request, System.Web.HttpResponse Response)
        {
            UserSession session = (UserSession)Session[StringConstants.SESSION_NAME_USER_SESSION];
            LocalWebSessionData localData = (LocalWebSessionData)session.Tag;

            Response.Write("<h1>Session</h1>");
            Response.Write(String.Format("DISCOUNTCOUPON: {0}<br />", localData.DiscountCoupon));
            Response.Write(String.Format("INVOICE_NUMBER: {0}<br />", 
                Session["INVOICE_NUMBER"] == null ? "null" : Session["INVOICE_NUMBER"]));
            Response.Write(String.Format("CREDIT_CARD_DETAILS: {0}<br />", 
                Session["CREDIT_CARD_DETAILS"] == null ? "null" : Session["CREDIT_CARD_DETAILS"]));
            Response.Write(String.Format("DeliveryAddressID: {0}<br />", 
                localData.DeliveryAddressID == -1 ? "null" : localData.DeliveryAddressID.ToString()));
            Response.Write(String.Format("Discount_Ammount: {0}<br />", 
                Session["Discount_Ammount"] == null ? "null" : Session["Discount_Ammount"]));
            Response.Write(String.Format("token: {0}<br />", Session["token"] == null ? "null" : Session["token"]));
            Response.Write(String.Format("CurrentPage: {0}<br />", 
                Session["CurrentPage"] == null ? "null" : Session["CurrentPage"]));
            Response.Write(String.Format("Discount_Ammount: {0}<br />", 
                Session["Discount_Ammount"] == null ? "null" : Session["Discount_Ammount"]));
            Response.Write(String.Format("USER_DISCOUNT: {0}<br />", 
                Session["USER_DISCOUNT"] == null ? "null" : Session["USER_DISCOUNT"]));
            Response.Write(String.Format("SHOPPINGBASKET_ID: {0}<br />", 
                Session["SHOPPINGBASKET_ID"] == null ? "null" : Session["SHOPPINGBASKET_ID"]));
            Response.Write(String.Format("PRODUCT_FILTER: {0}<br />", 
                Session["PRODUCT_FILTER"] == null ? "null" : Session["PRODUCT_FILTER"]));
            //Response.Write(String.Format("{1}: {0}<br />", 
            //    Session[StringConstants.SESSION_NAME_CURRENT_USER] == null ? "null" : Session["CURRENT_USER"], 
            //    StringConstants.SESSION_NAME_CURRENT_USER));
            Response.Write(String.Format("Culture: {0}<br />", localData.Culture.ToString()));
            //Response.Write(String.Format("{1}: {0}<br />", Session[StringConstants.SESSION_NAME_WEBSITE_WEBSITE_PRICE] == null ? "null" : Session[StringConstants.SESSION_NAME_WEBSITE_WEBSITE_PRICE], StringConstants.SESSION_NAME_WEBSITE_WEBSITE_PRICE));
            //Response.Write(String.Format("{1}: {0}<br />", 
            //    Session[StringConstants.SESSION_NAME_CURRENT_USER] == null ? "null" : Session["CURRENT_USER"], StringConstants.SESSION_NAME_CURRENT_USER));
            Response.Write(String.Format("COUNTRYCODE: {0}<br />", localData.CountryCode));
            Response.Write(String.Format("WEB_VAT_RATE: {0}<br />", localData.VATRate));
            Response.Write(String.Format("FLAG: {0}<br />", Session["FLAG"] == null ? "null" : Session["FLAG"]));
            Response.Write(String.Format("DCCODE: {0}<br />", Session["DCCODE"] == null ? "null" : Session["DCCODE"]));
            Response.Write(String.Format("MEMBER_LEVEL: {0}<br />", localData.MemberLevel));
            Response.Write(String.Format("LASTERROR: {0}<br />", Session["LASTERROR"] == null ? "null" : Session["LASTERROR"]));
            Response.Write(String.Format("WEBSITE_COUNTRY: {0}<br />", Session["WEBSITE_COUNTRY"] == null ? "null" : Session["WEBSITE_COUNTRY"]));
            Response.Write(String.Format("IP Address: {0}<br />", Request.ServerVariables["REMOTE_HOST"]));
            Response.Write(String.Format("Is Mobile Device: {0}<br .>", session.IsMobileDevice));
            Response.Write(String.Format("Country From IP: {0}<br />", lib.LibraryHelperClass.IPAddressToCountry(Request.ServerVariables["REMOTE_HOST"])));
            Response.Write(String.Format("{1}: {0}<br />", ((Currency)Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY]).ToString(), StringConstants.SESSION_NAME_USER_BASKET_CURRENCY));

            Response.Write("<h1>Culture</h1>");
            Response.Write(String.Format("Website Culture: {0}<br />", WebsiteSettings.Languages.WebsiteCulture));
            Response.Write(String.Format("Website Culture Override: {0}<br />", WebsiteSettings.WebsiteCultureOverride));
            Response.Write(String.Format("Website DAL Culture Override: {0}<br />", lib.DAL.DALHelper.CultureOverride));
            Response.Write("<h1>Basket</h1>");

            ShoppingBasket basket = localData.Basket;

            Response.Write(String.Format("Country: {0}<br />", basket.Country == null ? "null" : basket.Country.ToString()));
            Response.Write(String.Format("CouponCode: {0}<br />", basket.DiscountCouponName));
            Response.Write(String.Format("Currency: {0}<br />", basket.Currency == null ? "null" : basket.Currency.ToString()));
            Response.Write(String.Format("CurrencyAccepted: {0}<br />", basket.CurrencyAccepted.ToString()));
            Response.Write(String.Format("Discount: {0}<br />", basket.Discount.ToString()));
            Response.Write(String.Format("DiscountAmount: {0}<br />", basket.DiscountAmount.ToString()));
            Response.Write(String.Format("DiscountCost: {0}<br />", basket.DiscountCost));
            Response.Write(String.Format("DiscountCouponName: {0}<br />", basket.DiscountCouponName));
            Response.Write(String.Format("FreeShipping: {0}<br />", basket.FreeShipping.ToString()));
            Response.Write(String.Format("FreeShippingAmount: {0}<br />", basket.FreeShippingAmount.ToString()));
            Response.Write(String.Format("GiftWrappingPrice: {0}<br />", basket.GiftWrappingPrice));
            Response.Write(String.Format("IgnoreBasketQuantityRestrictions: {0}<br />", basket.IgnoreBasketQuantityRestrictions.ToString()));
            Response.Write(String.Format("IgnoreCostMultiplier: {0}<br />", basket.IgnoreCostMultiplier.ToString()));
            Response.Write(String.Format("IgnoreSalonDiscount: {0}<br />", basket.IgnoreAutoDiscount.ToString()));
            Response.Write(String.Format("MaximumItemQuantity: {0}<br />", basket.MaximumItemQuantity.ToString()));
            Response.Write(String.Format("MultiCurrency: {0}<br />", basket.MultiCurrency.ToString()));
            Response.Write(String.Format("OverrideVATRate: {0}<br />", basket.OverrideVATRate.ToString()));
            Response.Write(String.Format("ShippingAddress: {0}<br />", basket.ShippingAddress == null ? "null" : basket.ShippingAddress.ToString()));
            Response.Write(String.Format("ShippingAmount: {0}<br />", basket.ShippingCosts.ToString()));
            Response.Write(String.Format("ShippingCost: {0}<br />", basket.ShippingCost));
            Response.Write(String.Format("SubTotalAmount: {0}<br />", basket.SubTotalAmount.ToString()));
            Response.Write(String.Format("SubTotalCost: {0}<br />", basket.SubTotalCost));
            Response.Write(String.Format("SubTotalMinusVAT: {0}<br />", basket.SubTotalMinusVAT.ToString()));
            Response.Write(String.Format("SubTotalMinusVATCost: {0}<br />", basket.SubTotalMinusVATCost));
            Response.Write(String.Format("SubTotalMinusVATDecimal: {0}<br />", basket.SubTotalMinusVATDecimal.ToString()));
            Response.Write(String.Format("TotalAmount: {0}<br />", basket.TotalAmount.ToString()));
            Response.Write(String.Format("TotalCost: {0}<br />", basket.TotalCost));
            Response.Write(String.Format("User: {0}<br />", basket.User == null ? "null" : basket.User.ToString()));
            Response.Write(String.Format("VATAmount: {0}<br />", basket.VATAmount.ToString()));
            Response.Write(String.Format("VATCost: {0}<br />", basket.VATCost));
            Response.Write(String.Format("VATRate: {0}<br />", basket.VATRate.ToString()));
            Response.Write(String.Format("VoucherType: {0}<br />", basket.VoucherType.ToString()));

            Response.Write("<h1>Global Settings</h1>");
            Response.Write(String.Format("FreeShipping: {0} <br />", WebsiteSettings.ShoppingCart.FreeShippingAllow.ToString()));

            Response.Write(String.Format("FreeShippingSpend: {0} <br /><br />", WebsiteSettings.ShoppingCart.FreeShippingAmount.ToString()));

            Response.Write(String.Format("WebFarm: {0} <br />", WebsiteSettings.WebFarm.IsWebFarm));
            Response.Write(String.Format("WebFarm Master: {0} <br />", WebsiteSettings.WebFarm.WebFarmMaster()));
            Response.Write(String.Format("WebFarm Master IP: {0} <br />", WebsiteSettings.WebFarm.WebFarmMasterIP));
            Response.Write(String.Format("WebFarm Mutex: {0} <br />", WebsiteSettings.WebFarm.WebFarmMutexName));
            Response.Write(String.Format("Process ID: {0} <br />", System.Diagnostics.Process.GetCurrentProcess().Id));

            Response.Write("<h1>Memory Caching</h1>");

            int cacheCount = CacheManager.GetCount();

            Response.Write(String.Format("Cache Count: {0}<br />", cacheCount));

            for (int i = 0; i < cacheCount; i++)
            {
                Response.Write(String.Format("Cache Name: {0}; Count: {1}; Max Age {2}<br />", 
                    CacheManager.GetCacheName(i), CacheManager.GetCacheCount(i), CacheManager.GetCacheAge(i)));
            }


            Response.Write("<h1>Threads</h1>");

            for (int i = 0; i < ThreadManager.ThreadCount; i++ )
            {
                ThreadManager thread = ThreadManager.Get(i);

                Response.Write(thread.ToString() + String.Format("  Start Time: {0}; <br />", 
                    thread.TimeStart.ToString("g")));
            }
        }
    }
}
