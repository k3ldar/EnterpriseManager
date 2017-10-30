using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.Utils;
using Library;
using Library.BOL.Orders;
using Library.BOL.Countries;
using Library.BOL.Basket;
using Library.BOL.Coupons;
using Library.BOL.DeliveryAddress;
using Library.BOL.Accounts;
using Library.BOL.CustomWebPages;
using Library.BOL.SEO;
using Shared.Classes;

using Website.Library.Classes.PaymentOptions;

namespace Heavenskincare.WebsiteTemplate.Basket
{
    public partial class BasketCheckout : BaseWebFormMember
    {
        private ShoppingBasket _basket;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnConfirm.Text = Languages.LanguageStrings.ConfirmOrder;

            dCreditCard.Visible = Global.ShowPaymentCard && PaymentMethodAccepted(PaymentStatuses.Get("Credit Card Not Paid"));
            pPayByCheque.Visible = Global.ShowPaymentCheque && PaymentMethodAccepted(PaymentStatuses.Get("Cheque Not Paid"));
            pPaypal.Visible = Global.ShowPaymentPaypal && PaymentMethodAccepted(PaymentStatuses.Get("Paypal Not Paid"));
            pPaypoint.Visible = Global.ShowPaymentPaypoint && PaymentMethodAccepted(PaymentStatuses.Get("Paynet Not Paid"));
            pTelephone.Visible = Global.ShowPaymentTelephone && PaymentMethodAccepted(PaymentStatuses.Get("Phone Not Paid"));
            pPayByCashOnDelivery.Visible = Global.ShowPaymentCashOnDelivery && 
                PaymentMethodAccepted(PaymentStatuses.Get("Cash On Delivery"));
            pPayByDirectBankTransfer.Visible = Global.ShowPaymentDirectBankTransfer && 
                PaymentMethodAccepted(PaymentStatuses.Get("Direct Bank Transfer"));
            pSunTechWebATM.Visible = Global.ShowPaymentSunTechWebATM && 
                PaymentMethodAccepted(PaymentStatuses.Get("SunTech WebATM - Not Paid"));
            pSunTech24Payment.Visible = Global.ShowPaymentSunTech24Payment && 
                PaymentMethodAccepted(PaymentStatuses.Get("SunTech 24Payment - Not Paid"));
            pSunTechBuySafe.Visible = Global.ShowPaymentSunTechBuySafe && 
                PaymentMethodAccepted(PaymentStatuses.Get("SunTech BuySafe - Not Paid"));
            pTestPurchase.Visible = Global.ShowPaymentTestPurchase &&
                PaymentMethodAccepted(PaymentStatuses.Get("Test Purchase"));

            if (String.IsNullOrEmpty(Languages.LanguageStrings.FreeOffers))
                spFreeOffers.Visible = false;

            Library.BOL.Users.User user = GetUser();

            if (String.IsNullOrEmpty(Languages.LanguageStrings.FreeOffers))
                spFreeOffers.Visible = false;
            
            // is the credit card option in test mode
            if (dCreditCard.Visible && Global.PayflowTestMode)
            {
                dCreditCard.Visible = user == null ? false : user.MemberLevel >= Library.MemberLevel.StaffMember;
            }

            if (pSunTechWebATM.Visible && PaymentOptionSunTechWebATM.TestMode)
            {
                pSunTechWebATM.Visible = user == null ? false : user.MemberLevel >= Library.MemberLevel.StaffMember;
            }

            if (pSunTechBuySafe.Visible && PaymentOptionSunTechBuySafe.TestMode)
            {
                pSunTechBuySafe.Visible = user == null ? false : user.MemberLevel >= Library.MemberLevel.StaffMember;
            }

            if (pSunTech24Payment.Visible && PaymentOptionSunTech24Payment.TestMode)
            {
                pSunTech24Payment.Visible = user == null ? false : user.MemberLevel >= Library.MemberLevel.StaffMember;
            }

            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            _basket = localData.Basket;
            _basket.Reset(localData.PriceColumn);

            if (!IsPostBack)
            {
                //are we showing credit cards, if so it's the default selection
                if (dCreditCard.Visible)
                {
                    rbCreditCard.Checked = true;
                }
                else
                {
                    //clear border and right setting
                    dOtherPayments.Style.Clear();
                    dOtherPayments.Attributes.Clear();

                    // if were showing paypoint, it's the default option
                    if (pPaypoint.Visible)
                        rbPaypoint.Checked = true;
                    else
                        // if no paypoint then paypal becomes default
                        rbPaypal.Checked = true;
                }

                try
                {

                    //check if basket is valid
                    if (_basket.TotalAmount == 0.00m)
                        DoRedirect("/Basket/Basket.aspx", true);

                    if (!_basket.HasItems() && Session["INVOICE_NUMBER"] != null)
                    {
                        DoRedirect("/Basket/Basket.aspx");
                    }
                }
                catch (Exception err)
                {
                    if (err.Message.IndexOf("Invalid shopping basket") > 0)
                    {
                        DoRedirect("/Basket/Basket.aspx");
                    }
                }

                if (!_basket.HasItems() && CookieGetValue("HEAVEN_TEST_COOKIE", "invalid") == "invalid")
                    DoRedirect("/Members/Cookies.aspx");

                if (!UserIsLoggedOn())
                    DoRedirect("/Basket/Basket.aspx");

                // confirm user has the right postage option for country
                SetPostageOption();

                if (user.MemberLevel == Library.MemberLevel.Distributor)
                    pPaypal.Visible = false;
            }
        }

        protected string GetOrderTotal()
        {
            string Result = SharedUtils.FormatMoney(_basket.TotalAmount, GetWebsiteCurrency());

            if (GetUser().Country.Culture.ToLower() != Global.WebsiteCulture.Name.ToLower())
            {
                string ISOCurrency = "";
                string CurrencySymbol = Shared.Utilities.GetCurrencySymbol(WebCulture, out ISOCurrency);
            }

            return (Result);
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            UserSession session = GetUserSession();

            try
            {
                session.Sale(Convert.ToDecimal(_basket.TotalAmount), _basket.Currency.CurrencyCode);
            }
            catch (Exception saleErr)
            {
                Shared.EventLog.Add(saleErr);
            }

            try
            {
                if (!_basket.HasItems())
                {
                    DoRedirect("/Basket/Basket.aspx");
                }
            }
            catch (Exception err)
            {
                if (err.Message.IndexOf("Invalid shopping basket") > 0)
                {
                    DoRedirect("/Basket/BasketCheckout.aspx");
                    return;
                }
            }

            if (rbCreditCard.Visible && rbCreditCard.Checked)
            {
                if (!CreditCardPaymentControl1.ValidateNewCard())
                    return;
            }

            //notes
            _basket.DeliveryInstructions = txtNotes.Text;

            //IPPaymethod
            //1 = paid
            //2 = pay by pay pal
            //3 = pay by phone
            //4 = pay by cheque/postal order
            //5 = pay by paypoint
            PaymentStatus PayMethod = PaymentStatuses.Get("Paynet Not Paid");

            //process the payment
            if (rbCreditCard.Visible && rbCreditCard.Checked)
            {
                PayMethod = PaymentStatuses.Get("Credit Card Not Paid");
                Session["CREDIT_CARD_DETAILS"] = CreditCardPaymentControl1.GetCardDetails();
            }
            else if (rbPaypoint.Visible && rbPaypoint.Checked)
            {
                PayMethod = PaymentStatuses.Get("Paynet Not Paid");
            }
            else if (rbPaypal.Visible && rbPaypal.Checked)
            {
                PayMethod = PaymentStatuses.Get("Paypal Not Paid");
            }
            else if (rbCheque.Visible && rbCheque.Checked)
            {
                PayMethod = PaymentStatuses.Get("Cheque Not Paid");
            }
            else if (rbCreditCardPhone.Checked)
            {
                PayMethod = PaymentStatuses.Get("Phone Not Paid");
            }
            else if (rbCOD.Checked)
            {
                PayMethod = PaymentStatuses.Get("Cash On Delivery");
            }
            else if (rbDBT.Checked)
            {
                PayMethod = PaymentStatuses.Get("Direct Bank Transfer");
            }
            else if (rb24Payment.Checked)
            {
                PayMethod = PaymentStatuses.Get("SunTech 24Payment - Not Paid");
            }
            else if (rbBuySafe.Checked)
            {
                PayMethod = PaymentStatuses.Get("SunTech BuySafe - Not Paid");
            }
            else if (rbWebATM.Checked)
            {
                PayMethod = PaymentStatuses.Get("SunTech WebATM - Not Paid");
            }
            else if (rbTestPurchase.Checked)
            {
                PayMethod = PaymentStatuses.Get("Test Purchase");
            }
            else
            {
                PayMethod = PaymentStatuses.Get("Unknown");
            }


            LocalWebSessionData userData = (LocalWebSessionData)session.Tag;
            _basket.User = GetUser();

            //just in case it never picked up the delivery address #Bug reported 28/09/2011
            if (userData.DeliveryAddressID == -1)
            {
                _basket.ShippingAddress = GetUser().DeliveryAddresses.First();

                userData.DeliveryAddressID = _basket.ShippingAddress.ID;
            }

            _basket.ShippingAddress = DeliveryAddresses.Get(userData.DeliveryAddressID);

            Order order = null;


            // if the user double clicks the order has already been created, can we code around stupidity?

            if (Session["INVOICE_NUMBER"] == null || (Int64)Session["INVOICE_NUMBER"] == 0)
            {
                //does the payment method accept the current currency for the country?
                if (!GetPaymentCurrencies(PayMethod).Contains(GetWebsiteCurrency().CurrencyCode))
                {
                    _basket.CurrencyAccepted = false;
                }

                //create order
                order = _basket.ConvertToOrder(PayMethod, Session.SessionID, 
                    Request.ServerVariables["REMOTE_HOST"], WebCountry.Culture);
                Session["INVOICE_NUMBER"] = order.ID;
            }
            else
            {
                order = Orders.Get((Int64)Session["INVOICE_NUMBER"]);

                if (order == null)
                    DoRedirect("/Basket/Basket.aspx");

                PayMethod = order.Status;
            }

            PaymentStatuses.ExecutePaymentMethod(order, PayMethod, Session, Request, Response, GetUserSession());

            if (order != null && !_basket.ClearBasketOnPayment)
            {
                _basket.Empty();
            }
        }

        private string GetPaymentCurrencies(PaymentStatus payMethod)
        {
            string Result = String.Empty;

            try
            {
                Assembly ass = Assembly.LoadFrom(Library.DAL.DALHelper.Path + "\\Website.Library.dll");
                try
                {
                    Type trp = ass.GetType(payMethod.ProviderNamespace);
                    try
                    {
                        object paymentStatusObject = Activator.CreateInstance(trp);
                        BasePaymentOption payOption = (BasePaymentOption)paymentStatusObject;
                        try
                        {
                            Result = payOption.Currencies();
                        }
                        finally
                        {
                            payOption = null;
                        }
                    }
                    finally
                    {
                        trp = null;
                    }
                }
                finally
                {
                    ass = null;
                }
            }
            catch (Exception err)
            {
                if (!err.Message.Contains("Thread was being aborted"))
                {
                    //ErrorHandling.LogError(MethodBase.GetCurrentMethod(), err, order, paymentStatus, webSession,
                    //    webRequest, webResponse, ass, trp, paymentStatus.ProviderNamespace);
                    throw;
                }
            }

            return (Result);
        }

        private bool PaymentMethodAccepted(PaymentStatus payMethod)
        {
            // is it a valid payment method
            if (payMethod == null)
                return (false);

            // is the member level sufficient
            if (payMethod.MemberLevel > GetUser().MemberLevel)
                return (false);

            if (String.IsNullOrEmpty(payMethod.ProviderNamespace))
                return (false);

            try
            {
                Currency currency = GetWebsiteCurrency();
                Assembly ass = Assembly.LoadFrom(Library.DAL.DALHelper.Path + "\\Website.Library.dll");
                try
                {
                    Type trp = ass.GetType(payMethod.ProviderNamespace);
                    try
                    {
                        if (trp == null)
                        {
                            // payment method not found
                            Library.ErrorHandling.LogError(MethodBase.GetCurrentMethod(),
                                String.Format("Payment Method not accepted {0}", payMethod.ProviderNamespace),
                                payMethod);
                            return (false);
                        }
                        else
                        {
                            object paymentStatusObject = Activator.CreateInstance(trp);
                            BasePaymentOption payOption = (BasePaymentOption)paymentStatusObject;
                            try
                            {
                                return (payOption.Currencies().Contains(currency.CurrencyCode));
                            }
                            finally
                            {
                                payOption = null;
                            }
                        }
                    }
                    finally
                    {
                        trp = null;
                    }
                }
                finally
                {
                    ass = null;
                }
            }
            catch (Exception err)
            {
                if (!err.Message.Contains("Thread was being aborted"))
                {
                    //ErrorHandling.LogError(MethodBase.GetCurrentMethod(), err, order, paymentStatus, webSession,
                    //    webRequest, webResponse, ass, trp, paymentStatus.ProviderNamespace);
                    throw;
                }
            }

            return (false);
        }

        private void btnCheque_Click(object sender, System.EventArgs e)
        {
            DoRedirect("/Basket/BasketOrderComplete.aspx?InternalPaymentType=cpo");
        }

        private void SetPostageOption()
        {
            UserSession session = GetUserSession();
            LocalWebSessionData userData = (LocalWebSessionData)session.Tag;

            if (userData.DeliveryAddressID == -1)
                DoRedirect("/Basket/BasketDeliveryAddress.aspx");
        }
    }
}