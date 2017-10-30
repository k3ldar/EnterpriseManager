using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Library;
using Library.BOL.Basket;
using Library.Utils;
using Website.Library.Classes;
using Library.BOL.Countries;
using Library.BOL.USAStates;
using Library.BOL.SEO;
using Shared.Classes;

namespace Heavenskincare.WebsiteTemplate.Basket
{
    public partial class PageBasket : BaseWebForm
    {
        private ShoppingBasket _basket = null;
        private string _extraMessage = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Global.HideShoppingCart)
            {
                DoRedirect("/Index.aspx", true);
            }

            trVAT.Visible = !Library.DAL.DALHelper.HideVATOnWebsiteAndInvoices;
            tdTotal.InnerHtml = String.Format("<strong>{0}:</strong>", Languages.LanguageStrings.TotalToPay);
            tdPostage.InnerHtml = String.Format("<strong>{0}:</strong>", Languages.LanguageStrings.PostageAndPackaging);
            tdSubTotal.InnerHtml = String.Format("<strong>{0}:</strong>", Languages.LanguageStrings.SubTotal2);
            btnApplyVoucherCode.Text = Languages.LanguageStrings.ApplyCode;
            btnCheckoutBasket.Text = Languages.LanguageStrings.Checkout;
            btnContinueShopping.Text = Languages.LanguageStrings.ContinueShopping;
            btnAddGiftWrapping.Text = Languages.LanguageStrings.GiftWrap;

            string RedirectURL = GetRedirectURL();
            
            if (RedirectURL != "")
            {
                Response.Redirect(RedirectURL, true);
                return;
            }

            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            _basket = localData.Basket;
            _basket.ClearBasketOnPayment = BaseWebApplication.ClearBasketOnPayment;

            _basket.Reset(localData.PriceColumn);

            string resultText = String.Empty;

            if (!String.IsNullOrEmpty(_basket.DiscountCouponName))
                _basket.ValidateCouponCode(_basket.DiscountCouponName, ref resultText);

            decimal giftWrapPrice = _basket.GiftWrappingPrice;

            if (giftWrapPrice > 0.0m)
            {
                if (BaseWebApplication.PricesIncludeVAT)
                {
                    giftWrapPrice += SharedUtils.VATCalculate(giftWrapPrice, WebVATRate);
                }

                tdGiftWrapMessage.InnerText = String.Format(Languages.LanguageStrings.GiftWrapMessge, 
                    SharedUtils.FormatMoney(giftWrapPrice, GetWebsiteCurrency()));
            }

#if ADD_TEST_ITEM
            #region DEBUG ONLY TO AUTOMATICALLY ADD AN ITEM TO BASKET FOR TESTING

            if (GetUser() != null && GetUser().ID == 0 && _basket.Items.Count < 100)
            {
                Library.BOL.Products.ProductCost item = Library.BOL.Products.ProductCosts.Get(91, GetUser());

                _basket.Add(item, 1, GetUser(), SharedWebBase.WebsiteCurrency(Session, Request).PriceColumn);
            }

            #endregion DEBUG ONLY TO AUTOMATICALLY ADD AN ITEM TO BASKET FOR TESTING
#endif

            if ((_basket.User != null && _basket.User.MemberLevel >= Library.MemberLevel.Distributor && 
                _basket.User.AutoDiscount > 0))
            {
                trVoucher.Visible = false;
            }

            UserSession session = GetUserSession();

            if (session.MobileRedirect)
            {
                BuildMobileBasketItems();
            }
            else
            {
                BuildBasketItems();
                SetTotals();
            }

            tblBasket.Visible = !session.MobileRedirect;
            divBasketMobile.Visible = session.MobileRedirect;

            // gift wrapping
            trGiftWrap.Visible = Global.AllowGiftwrapAtCheckout && _basket.GiftWrappingProductAvailable();


            if (!IsPostBack)
            {
                txtVoucher.Text = GetVoucherString();
            }

            string message = GetFormValue("message", String.Empty);

            if (!String.IsNullOrEmpty(message))
            {
                _extraMessage = message;
            }

            divMessage.Visible = !String.IsNullOrEmpty(_extraMessage);
        }

        protected string GetBasketMessage()
        {
            return (_extraMessage);
        }

        protected string GetVoucherString()
        {
            return (Languages.LanguageStrings.VoucherCodeEnter);
        }


        protected void BuildMobileBasketItems()
        {
            if (_basket.HasItems())
            {
                btnCheckoutBasket.Enabled = true;
                divBasketMobile.Controls.Clear();

                foreach (BasketItem item in _basket.Items)
                {
                    Heavenskincare.WebsiteTemplate.Controls.BasketItemMobileControl bi = (Heavenskincare.WebsiteTemplate.Controls.BasketItemMobileControl)LoadControl("~/Controls/BasketItemMobileControl.ascx");
                    bi.Refresh(item);
                    divBasketMobile.Controls.Add(bi);
                }
            }
            else
            {
                divBasketMobile.InnerHtml += String.Format("<p>{0}</p>", Languages.LanguageStrings.BasketHasNoItems);
            }

            Heavenskincare.WebsiteTemplate.Controls.BasketMobileTotals bmt = (Heavenskincare.WebsiteTemplate.Controls.BasketMobileTotals)LoadControl("~/Controls/BasketMobileTotals.ascx");
            divBasketMobile.Controls.Add(bmt);
        }

        protected void BuildBasketItems()
        {
            if (_basket.HasItems())
            {
                btnCheckoutBasket.Enabled = true;

                foreach (BasketItem item in _basket.Items)
                {
                    HtmlTableRow r = new HtmlTableRow();
                    tblBasket.Rows.Insert(1, r);
				    HtmlTableCell c = CreateCell(r, "");
                    c.ColSpan = 6;

                    Heavenskincare.WebsiteTemplate.Controls.BasketItemControl bi = (Heavenskincare.WebsiteTemplate.Controls.BasketItemControl)LoadControl("~/Controls/BasketItemControl.ascx");
                    bi.Refresh(item);
                    c.Controls.Add(bi);
                }
            }
            else
            {
                btnCheckoutBasket.Enabled = false;

                if (!IsPostBack)
                {
                    HtmlTableRow r = new HtmlTableRow();
                    tblBasket.Rows.Insert(1, r);
                    HtmlTableCell c = CreateCell(r, "");
                    c.ColSpan = 6;
                    c.InnerText = Languages.LanguageStrings.BasketHasNoItems;
                }
            }
        }

        protected void SetTotals()
        {
            string Result = String.Empty;

            if (Global.ShowBasketSubTotalWithVAT)
                Result = String.Format("<strong>{0}</strong>", SharedUtils.FormatMoney(_basket.SubTotalAmount + _basket.VATAmount, GetWebsiteCurrency()));
            else
                Result = String.Format("<strong>{0}</strong>", SharedUtils.FormatMoney(_basket.SubTotalMinusVAT, GetWebsiteCurrency()));

            tdSubTotalAmount.InnerHtml = Result;

            Result = String.Format("<strong>{0}</strong>", SharedUtils.FormatMoney(_basket.VATAmount, GetWebsiteCurrency()));
            tdVatAmount.InnerHtml = Result;

            Result = String.Format("<strong>{0}</strong>", SharedUtils.FormatMoney(_basket.ShippingCosts, GetWebsiteCurrency()));
            tdPostageAmount.InnerHtml = Result;

            Result = String.Format("<strong>{0}</strong>", SharedUtils.FormatMoney(_basket.TotalAmount, GetWebsiteCurrency()));
            tdTotalAmmount.InnerHtml = Result;

            trDiscount.Visible = (_basket.VoucherType == Enums.InvoiceVoucherType.Footprint) || 
                (_basket.VoucherType == Enums.InvoiceVoucherType.SpecialOffer) ||
                (_basket.VoucherType == Enums.InvoiceVoucherType.FreeProduct) ||
                (_basket.Discount > 0) ||
                (_basket.User != null && _basket.User.MemberLevel >= Library.MemberLevel.Distributor && 
                _basket.User.AutoDiscount > 0);

            if (trDiscount.Visible)
            {
                switch (_basket.VoucherType)
                {
                    case Enums.InvoiceVoucherType.Percent:
                        Result = String.Format("<strong>{2} ({0} @ {1}%):</strong>", 
                            _basket.DiscountCouponName, _basket.Discount, Languages.LanguageStrings.Discount);
                        break;
                    case Enums.InvoiceVoucherType.Value:
                        Result = String.Format("<strong>{1}: {0}:</strong>", _basket.DiscountCouponName,
                            Languages.LanguageStrings.DiscountCode);
                        break;
                    case Enums.InvoiceVoucherType.Footprint:
                    case Enums.InvoiceVoucherType.SpecialOffer:
                    case Enums.InvoiceVoucherType.FreeProduct:
                        Result = String.Format("<strong>{1}: {0}</strong>", _basket.DiscountCouponName,
                            Languages.LanguageStrings.PromotionCode);
                        break;
                }

                tdDiscountRate.InnerHtml = Result;
            }

            switch (_basket.VoucherType)
            {
                case Enums.InvoiceVoucherType.Percent:
                case Enums.InvoiceVoucherType.Value:
                    Result = String.Format("<strong>{0}</strong>", SharedUtils.FormatMoney(_basket.DiscountAmount, GetWebsiteCurrency()));
                    break;
                case Enums.InvoiceVoucherType.Footprint:
                    Result = String.Empty;
                    break;
            }

            tdDiscount.InnerHtml = Result;

            Result = String.Format("<strong>{1} ({0}%):</strong>", _basket.VATRate, 
                Languages.LanguageStrings.VAT);
            tdVatRate.InnerHtml = Result;
        }

        protected string GetDiscount()
        {
            string Result = "";


            return (Result);
        }

        protected void btnApplyVoucherCode_Click(object sender, EventArgs e)
        {
            if (txtVoucher.Text != GetVoucherString() && txtVoucher.Text != "")
            {
                string resultText = String.Empty;

                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;

                if (_basket.ValidateCouponCode(txtVoucher.Text, ref resultText))
                {
                    localData.DiscountCoupon = txtVoucher.Text;
                }
                else
                {
                    localData.DiscountCoupon = String.Empty;
                    txtVoucher.Text = String.Empty;
                }

                _extraMessage = resultText;
                divMessage.Visible = !String.IsNullOrEmpty(_extraMessage);

                if (!divMessage.Visible)
                    DoRedirect("/Basket/Basket.aspx", true);
                else
                    DoRedirect("/Basket/Basket.aspx?message=" + resultText);
            }
            else
            {
                DoRedirect("/Basket/Basket.aspx?message=invalid coupon code", true);
            }
        }

        protected void btnCheckoutBasket_Click(object sender, EventArgs e)
        {
            Session["INVOICE_NUMBER"] = null;

            if (!_basket.IsEmpty())
                DoRedirect("/Basket/BasketSignin.aspx", true);
        }

        protected void btnContinueShopping_Click(object sender, EventArgs e)
        {
            DoRedirect("/Products.aspx");
        }

        protected void btnAddGiftWrapping_Click(object sender, EventArgs e)
        {
            if (_basket.GiftWrappingIncluded())
                _basket.GiftWrappingRemove();
            else
                _basket.GiftWrappingAdd(_basket.Currency.PriceColumn);

            DoRedirect("/Basket/Basket.aspx", true);
        }
    }
}