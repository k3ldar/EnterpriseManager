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
    public partial class SunTechBuySafe : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get values passed by suntech
            Int64 orderID = GetFormValue("Td", -1);
            string orderNumber = GetFormValue("buysafeno", String.Empty);
            string merchantID = GetFormValue("web", String.Empty);
            string approveCode = GetFormValue("ApproveCode", String.Empty);
            string last4Card = GetFormValue("Card_NO", String.Empty);
            string finalAmount = GetFormValue("Mn", String.Empty);
            string webName = HttpUtility.UrlDecode(GetFormValue("webname", String.Empty));
            string name = HttpUtility.UrlDecode(GetFormValue("Name", String.Empty));
            string errMessage = HttpUtility.UrlDecode(GetFormValue("errmsg", String.Empty));
            string cardType = GetFormValue("Card_Type", String.Empty);
            string chkValue = GetFormValue("ChkValue", String.Empty);
            string errCode = GetFormValue("errcode", String.Empty);
            string checkValueInternal = PaymentOptionSunTechBuySafe.CreateCheckValue(orderNumber, finalAmount, errCode);

            try
            {
                // validate check value so not fraudulant
                if (checkValueInternal != chkValue)
                    throw new Exception("Invalid Check Value");

                // 00 is a success codde, anything else is a fail (no details in documentation)
                if (errCode != "00")
                    throw new Exception(String.Format("Payment Failed: {0}", errMessage));

                // get the order
                Order order = Orders.Get(orderID);

                if (order == null)
                    throw new Exception("Order not found");

                // mark order as paid
                order.Paid(GetUser(), PaymentStatuses.Get(StringConstants.PAYMENT_STATUS_BUY_SAFE_PAID),
                    String.Format("BuySafeNo: {0}; Approve: {1}", orderNumber, approveCode), GetAffiliateID());

                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;

                if (localData.Basket.ClearBasketOnPayment)
                    localData.Basket.Empty();
            }
            catch (Exception err)
            {
                BaseWebApplication.SendEmail("Payment Failed", String.Format("orderID: {0}<br /> orderNumber: {1}<br />" +
                    "merchantID: {2}<br />approveCode: {3}<br />last4: {4}<br />webName: {5}<br />" +
                    "name: {6}<br />errMessage: {7}<br />cardType: {8}<br />chkValue: {9}<br />errcode: {10}<br /><br />" +
                    "internal Chk: {11}<br />Checks Match: {12}<br /><br />Error Message: {13}",
                    orderID, orderNumber, merchantID, approveCode, last4Card,
                    webName, name, errMessage, cardType, chkValue, errCode, checkValueInternal,
                    checkValueInternal == chkValue, err.Message));
                DoRedirect("/Basket/BasketPaymentFailed.aspx");
            }
            finally
            {
                // set custom page data
                if (Library.BOL.CustomWebPages.CustomPages.UseCustomPages)
                {
                    CustomPage customPage = CustomPages.Get("Payment Type - Buy Safe");

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