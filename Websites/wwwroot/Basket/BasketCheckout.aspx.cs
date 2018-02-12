using System;
using System.Threading;

using Library.Utils;
using Library.BOL.Orders;
using Library.BOL.Basket;
using Library.BOL.Coupons;
using Library.BOL.DeliveryAddress;
using Library.BOL.Accounts;
using Library.BOL.Websites;

using Website.Library.Classes;

#pragma warning disable IDE1006

namespace SieraDelta.Website.Basket
{
    public partial class BasketCheckout : BaseWebFormMember
    {
        private ShoppingBasket _basket;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnConfirm.Text = Languages.LanguageStrings.ConfirmOrder;

            dCreditCard.Visible = WebsiteSettings.PaymentGateways.ShowPaymentCard;
            pPayByCheque.Visible = WebsiteSettings.PaymentGateways.ShowPaymentCheque;
            pPaypal.Visible = WebsiteSettings.PaymentGateways.ShowPaymentPaypal;
            pPaypoint.Visible = WebsiteSettings.PaymentGateways.ShowPaymentPaypoint;
            pTelephone.Visible = WebsiteSettings.PaymentGateways.ShowPaymentTelephone;
            pPayByCashOnDelivery.Visible = WebsiteSettings.PaymentGateways.ShowPaymentCashOnDelivery;
            pPayByDirectBankTransfer.Visible = WebsiteSettings.PaymentGateways.ShowPaymentDirectBankTransfer;

            // is the credit card option in test mode
            if (WebsiteSettings.PaymentGateways.Payflow.PayflowTestMode)
            {
                Library.BOL.Users.User user = GetUser();
                dCreditCard.Visible = user == null ? false : user.MemberLevel >= Library.MemberLevel.StaffMember;
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
                        DoRedirect("/Shopping/Basket/", true);

                    if (!_basket.HasItems() && Session["INVOICE_NUMBER"] != null)
                    {
                        DoRedirect("/Shopping/Basket/");
                    }
                }
                catch (Exception err)
                {
                    if (err.Message.IndexOf("Invalid shopping basket") > 0)
                    {
                        DoRedirect("/Shopping/Basket/");
                    }
                }

                if (CookieGetValue("SIERADELTA_TEST_COOKIE", "invalid") == "invalid")
                    DoRedirect("/Account/Cookies/");

                if (!UserIsLoggedOn())
                    DoRedirect("/Shopping/Basket/");

                // confirm user has the right postage option for country
                SetPostageOption();

                //paypal not allowed for salon owners
                Library.BOL.Users.User user = GetUser();
            }
        }

        protected string GetOrderTotal()
        {
            //SieraDeltaUtils u = new SieraDeltaUtils();
            string Result = SharedUtils.FormatMoney(_basket.TotalAmount, GetWebsiteCurrency(), false);

            //if (GetUser().Country.Culture.ToLower() != Thread.CurrentThread.CurrentUICulture.Name)
            //{
            //    string ISOCurrency = "";
            //    string CurrencySymbol = SharedUtils.GetCurrencySymbol(Thread.CurrentThread.CurrentUICulture.Name, out ISOCurrency);
            //    //Result += String.Format("<p><strong>Please note, although the price displayed is in {1} ({2}) the actual ammount you will be charged will be {0}.</strong></p>",
            //      //  SharedUtils.FormatMoney(_basket.TotalAmmount, "en-GB", 1.0, WebCountry.Multiplier, false, false), ISOCurrency, CurrencySymbol);
            //}

            return (Result);
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_basket.HasItems())
                {
                    DoRedirect("/Shopping/Basket/");
                }
            }
            catch (Exception err)
            {
                if (err.Message.IndexOf("Invalid shopping basket") > 0)
                {
                    DoRedirect("/Shopping/Basket/Confirm-Order/");
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
            else
            {
                PayMethod = PaymentStatuses.Get("Unknown");
            }

            Int64 DeliveryAddress = -1;
            _basket.User = GetUser();

            if (_basket.ProductsHaveShipping())
            {
                //just in case it never picked up the delivery address #Bug reported 28/09/2011
                if (Session["DeliveryAddressID"] == null)
                {
                    _basket.ShippingAddress = GetUser().DeliveryAddresses.First();
                    Session["DeliveryAddressID"] = _basket.ShippingAddress.ID;
                }
                else
                    DeliveryAddress = (Int64)Session["DeliveryAddressID"];

                _basket.ShippingAddress = DeliveryAddresses.Get(DeliveryAddress);
            }

            Order order = null;
            // if the user double clicks the order has already been created, can we code around stupidity?

            if (Session["INVOICE_NUMBER"] == null || (int)Session["INVOICE_NUMBER"] == 0)
            {
                //create order
                order = _basket.ConvertToOrder(PayMethod, Session.SessionID, Request.ServerVariables["REMOTE_HOST"],
                    Thread.CurrentThread.CurrentUICulture.Name);
                Session["INVOICE_NUMBER"] = order.ID;
            }
            else
            {
                order = Orders.Get((int)Session["INVOICE_NUMBER"]);

                if (order == null)
                    DoRedirect("/Shopping/Basket/");

                PayMethod = order.Status;
            }

            PaymentStatuses.ExecutePaymentMethod(order, PayMethod, Session, Request, Response, GetUserSession());

            //switch (PayMethod.ID)
            //{
            //case 2: //Enums.PaymentStatus.PaypalNotPaid:
            //    PayWithPaypal();
            //    break;
            //case 3: //Enums.PaymentStatus.PhoneNotPaid:
            //    DoRedirect("", true);
            //    break;
            //case 4: //Enums.PaymentStatus.ChequeNotPaid:
            //    DoRedirect("", true);
            //    break;
            //case 5: //Enums.PaymentStatus.PaynetNotPaid:
            //    PayWithPaypoint();
            //    break;
            //case 13: //Enums.PaymentStatus.CreditCardNotPaid:
            //    PayWithPayflow();
            //    break;

            //case 6: //Enums.PaymentStatus.PaypalPaid:
            //case 9: //Enums.PaymentStatus.PaynetPaid:
            //case 7: //Enums.PaymentStatus.PhonePaid:
            //case 8: //Enums.PaymentStatus.ChequePaid:
            //    DoRedirect("/Account/Invoices/", true);
            //    break;

            //    default:
            //        throw new Exception("Unknown payment status");
            //}
        }

        //private void PayWithPayflow()
        //{
        //    int invoiceID = (int)Session["INVOICE_NUMBER"];

        //    Order order = Orders.Get(invoiceID);

        //    PayByPayFlow(order, CreditCardPaymentControl1.GetCardDetails());
        //}

        //private void PayWithPaypal()
        //{
        //    if (UserIsLoggedOn())
        //    {
        //        int InvoiceID = (int)Session["INVOICE_NUMBER"];

        //        Order order = Orders.Get(InvoiceID);

        //        PayByPayPal(order);
        //    }
        //    else
        //        DoRedirect("/Shopping/Basket/SignIn/");
        //}

        //private void PayWithPaypoint()
        //{
        //    if (UserIsLoggedOn())
        //    {
        //        int InvoiceID = (int)Session["INVOICE_NUMBER"];

        //        Order order = Orders.Get(InvoiceID);

        //        PayByPayPoint(order);
        //    }
        //    else
        //        DoRedirect("/Shopping/Basket/SignIn/");
        //}

        private void btnCheque_Click(object sender, System.EventArgs e)
        {
            DoRedirect("/Shopping/Basket/Order-Complete/Payment-Type/cpo/");
        }

        private void SetPostageOption()
        {
            Int64 delAddress = -1;
            decimal ShippingCostsDelivery = 0.00m;

            if (_basket.ProductsHaveShipping())
            {
                if (Session["DeliveryAddressID"] == null)
                    DoRedirect("/Shopping/Basket/Delivery-Address/");
                else
                    delAddress = (Int64)Session["DeliveryAddressID"];

                if (delAddress == -1)
                    DoRedirect("/Shopping/Basket/Delivery-Address/");

                //get postage cost
                ShippingCostsDelivery = GetUser().Country.ShippingCosts;
            }

            if (ShippingCostsDelivery > 0.0m)
            {
                //are the shipping cost different to what the user selected?
                if (_basket.ShippingCosts != ShippingCostsDelivery)
                {
                    //is there an offer with free postage?
                    Coupon cpn = Coupons.Get(_basket.DiscountCouponName);
                }
            }
        }
    }
}