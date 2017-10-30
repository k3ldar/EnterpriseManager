using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Library.BOL.Accounts;
using Library.BOL.CustomWebPages;
using Library.BOL.Orders;

using Website.Library;
using Website.Library.Classes;
using Website.Library.Classes.PaymentOptions;

namespace Heavenskincare.WebsiteTemplate.Basket
{
    public partial class SunTechWebATM : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get values passed by suntech
            Int64 orderID = GetFormValue("Td", -1);
            string orderNumber = GetFormValue("buysafeno", String.Empty);
            string merchantID = GetFormValue("web", String.Empty);
            string finalAmount = GetFormValue("Mn", String.Empty);
            string name = HttpUtility.UrlDecode(GetFormValue("Name", String.Empty));
            string chkValue = GetFormValue("ChkValue", String.Empty);
            string errCode = GetFormValue("errcode", String.Empty);
            string payCode = GetFormValue("Paycode", String.Empty);
            string checkValueInternal = PaymentOptionSunTechWebATM.CreateCheckValue(orderNumber, finalAmount, payCode);

            try
            {
                // validate check value so not fraudulant
                if (checkValueInternal != chkValue)
                    throw new Exception("Invalid Check Value");

                // get the order
                Order order = Orders.Get(orderID);

                Shared.Classes.UserSession session = GetUserSession();

                if (order == null)
                    throw new Exception("Order not found");

                // mark order as paid
                order.Paid(GetUser(), PaymentStatuses.Get(StringConstants.PAYMENT_STATUS_BUY_SAFE_WEB_ATM),
                    String.Format("BuySafeNo: {0}; PayCode: {1}", orderNumber, payCode), GetAffiliateID());

                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;

                if (localData.Basket.ClearBasketOnPayment)
                    localData.Basket.Empty();
            }
            catch (Exception err)
            {
                BaseWebApplication.SendEmail("Payment Failed", String.Format("orderID: {0}<br /> orderNumber: {1}<br />" +
                    "merchantID: {2}<br />" +
                    "name: {3}<br />chkValue: {4}<br />errcode: {5}<br /><br />" +
                    "internal Chk: {6}<br />Checks Match: {7}<br /><br />Error Message: {8}",
                    orderID, orderNumber, merchantID, name, chkValue, errCode, checkValueInternal,
                    checkValueInternal == chkValue, err.Message));
                DoRedirect("/Basket/BasketPaymentFailed.aspx");
            }
            finally
            {
                // set custom page data
                if (Library.BOL.CustomWebPages.CustomPages.UseCustomPages)
                {
                    CustomPage customPage = CustomPages.Get(StringConstants.PAYMENT_STATUS_BUY_SAFE_WEB_ATM);

                    if (customPage != null && customPage.IsActive)
                        divCustomContents.InnerHtml = customPage.PageText;
                    else
                        divCustomContents.InnerHtml = Languages.LanguageStrings.OrderCompleteGeneric;
                }
                else
                    divCustomContents.InnerHtml = Languages.LanguageStrings.OrderCompleteGeneric;
            }
        }
    }
}