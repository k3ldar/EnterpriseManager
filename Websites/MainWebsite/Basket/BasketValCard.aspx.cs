﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.Utils;
using Library;

using Library.BOL.Accounts;
using Library.BOL.Orders;
using Library.BOL.Invoices;

namespace Heavenskincare.WebsiteTemplate.Basket
{
    public partial class BasketValCard : BaseWebForm
    {
        #region Private Members

        private Order _order = null;

        #endregion Private Members

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            // valid=false&trans_id=130875&code=A&resp_code=10&message=DATA+NOT+CHECKED+%3a+9999&ip=94.195.236.73&cv2avs=DATA+NOT+CHECKED&test_status=true&hash=bf555b3770642acd204c602cdb0f80b0

            if (GetFormValue("valid") == "false" || GetFormValue("code").ToUpper() != "A")
            {
                //transaction not authorised
                TransactionNotAuthorised();
            }
            else
            {
                // last couple of checks
                if (GetFormValue("code").ToUpper() == "A" && GetFormValue("valid") == "true")
                {
                    // all worked, create an invoice etc
                    int InvoiceID = Shared.Utilities.StrToInt(GetFormValue("trans_id"), -1);

                    try
                    {
                        _order = Orders.Get(InvoiceID);

                        if (_order == null)
                        {
                            string Msg = String.Format("Order #{0} has been paid but could not be found when it was time to automatically set it as paid.\n\nPlease check paynet to confirm payment and adjust payment status.", InvoiceID);
                            Global.SendEMail(Global.WebsiteEmail, Global.WebsiteEmail, "Order Paid but not Found", Msg);
                        }
                        else
                        {
                            _order.Paid(null, PaymentStatuses.Get("Paynet Paid"), String.Format("{0} : {1} : {2}", GetFormValue("ip"), GetFormValue("cv2avs"), GetFormValue("message")), GetAffiliateID());

                            if (ValidateHashCode())
                            {
                                PaymentReceived();
                            }
                            else
                            {
                                PaymentReceivedHashWrong();
                                string Msg = String.Format("Order #{0} had an invalid Hash, this is a potential fraudulant transaction.\n\nPlease check paynet to confirm payment.", InvoiceID);
                                Global.SendEMail(Global.WebsiteEmail, Global.WebsiteEmail, "Transaction Query - Hash", Msg);
                            }

                            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;

                            if (localData.Basket.ClearBasketOnPayment)
                                localData.Basket.Empty();

                            string script = GetAffiliateExternalPurchase();

                            if (!String.IsNullOrEmpty(script))
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aff", script, false);
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        if (err.Message.IndexOf("alid Invoice ID") > 0)
                        {
                            pPaymentText.InnerHtml = String.Format(Languages.LanguageStrings.PaynetReceivedNoOrder + "</a>", "<a href=\"/ContactUs.aspx\">");
                        }
                        else if (err.Message.Contains("Invalid Process Status Change At trigger"))
                        {
                            PaymentReceived();
                        }
                        else
                            throw;
                    }
                }
            }
        }

        #endregion Protected Methods

        #region Private Methods

        private void PaymentReceived()
        {
            pPaymentText.InnerHtml = String.Format(Languages.LanguageStrings.OrderCompletePaynet + "</a>.", "<a href=\"/Members/Address.aspx\">");
        }

        private void PaymentReceivedHashWrong()
        {
            pPaymentText.InnerHtml = String.Format(Languages.LanguageStrings.OrderCompletePaynet + "</a>.", "<a href=\"/Members/Address.aspx\">");
        }

        private bool ValidateHashCode()
        {
            bool Result = false;

            //java-bin/Callback?valid=true&trans_id=secpay&auth_code=1234&amount=76.38
            string s = Request.Path;
            s += "?";
            s += Request.QueryString.ToString();
            s = s.Substring(0, s.IndexOf("hash"));
            s += "chall3ng3 Auth0r1ty 13A";

            s = Shared.Utilities.HashStringMD5(s);

            Result = s == GetFormValue("hash");

            if (!Result)
            {
                if (GetFormValue("resp_code") != "5" || GetFormValue("resp_code") != "10")
                {
                    string Msg = String.Format("Transaction Failed\n\nValid: {0}\n\nTransID: {1}\n\nCode: {2}\n\nResp Code: {7}\n\nMessage: {3}\n\nIP Addres: {4}\n\nCV2: {5}\n\nHash: {6}\n\nHash2: {8}",
                        GetFormValue("valid"), GetFormValue("trans_id"), GetFormValue("code"), GetFormValue("message"), GetFormValue("ip"), GetFormValue("cv2avs"), GetFormValue("hash"), GetFormValue("resp_code"), s);
                    Global.SendEMail(Global.WebsiteEmail, Global.WebsiteEmail, "Transaction Failed - Hash", Msg);
                }
            }

            return (Result);
        }

        private void TransactionNotAuthorised()
        {
            pPaymentText.InnerHtml = String.Format(Languages.LanguageStrings.PaynetNotAuthorised1 + "</a>", "<a href=\"/ContactUs.aspx\">");
            //valid=false&trans_id=320&code=N&resp_code=10&message=DATA+NOT+CHECKED+%3a+9999&ip=94.195.236.73&cv2avs=DATA+NOT+CHECKED&test_status=true&hash=bf555b3770642acd204c602cdb0f80b0

            string ExtraMessage = String.Format(Languages.LanguageStrings.PaynetNotAuthorised2 + "</a>", 
                String.Format("<a href=\"/Members/BasketPayByPaypal.aspx?Order={0}\">", GetFormValue("trans_id")));

            switch (GetFormValue("message"))
            {
                case "SECURITY CODE MATCH ONLY":
                    break;
                case "ADDRESS MATCH ONLY":
                    break;
                case "NO DATA MATCHES":
                    break;
                case "DATA NOT CHECKED":
                    break;
                default:
                    ExtraMessage = String.Empty;
                    break;
            }

            pPaymentText.InnerHtml += String.Format("<p> {0} </p>", ExtraMessage);

            if (GetFormValue("resp_code") != "5")
            {
                string Msg = String.Format("Transaction Failed\n\nValid: {0}\n\nTransID: {1}\n\nCode: {2}\n\nResp Code: {7}\n\nMessage: {3}\n\nIP Addres: {4}\n\nCV2: {5}\n\nHash: {6}",
                    GetFormValue("valid"), GetFormValue("trans_id"), GetFormValue("code"), GetFormValue("message"), GetFormValue("ip"), GetFormValue("cv2avs"), GetFormValue("hash"), GetFormValue("resp_code"));
                Global.SendEMail(Global.WebsiteEmail, Global.WebsiteEmail, "Transaction Failed", Msg);
            }
        }


        protected string GetAffiliateExternalPurchase()
        {
            if (Global.AffiliateIncludeExternal)
            {
                if (_order == null)
                    return (String.Empty);

                Invoice invoice = Invoices.Get(_order);

                if (invoice == null)
                    return (String.Empty);

                string Result = String.Format("<script type=\"text/javascript\">{0}</script>", Global.AffiliatePurchaseHeader);
                Result = Result.Replace("[ORDER_ID]", invoice.ID.ToString());
                Result = Result.Replace("[CURRENCY]", invoice.Currency.CurrencyCode);

                decimal subTotal = invoice.TotalCost;

                if (invoice.Version < Consts.INVOICE_VERSION_VAT_ADD)
                {
                    subTotal = SharedUtils.VATRemove(subTotal, invoice.VATRate);
                }

                subTotal = subTotal - (invoice.ShippingCosts + invoice.DiscountAmount + invoice.VATAmount);
                Result = Result.Replace("[TOTAL]", Math.Round(subTotal, 2).ToString());
                Result = Result.Replace("[CODE]", invoice.CouponName);

                return (Result);
            }
            else
            {
                return (String.Empty);
            }
        }

        #endregion Private Methods

    }
}