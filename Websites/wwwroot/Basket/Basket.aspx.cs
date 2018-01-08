using System;
using System.Web.UI.HtmlControls;

using Library;
using Library.BOL.Basket;
using Library.Utils;
using Website.Library.Classes;
using Shared.Classes;

#pragma warning disable IDE1006

namespace SieraDelta.Website.Basket
{
    public partial class PageBasket : BaseWebForm
    {
        private ShoppingBasket _basket = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            tdTotal.InnerHtml = String.Format("<strong>{0}:</strong>", Languages.LanguageStrings.Total);
            tdPostage.InnerHtml = String.Format("<strong>{0}:</strong>", Languages.LanguageStrings.PostageAndPackaging);
            tdSubTotal.InnerHtml = String.Format("<strong>{0}:</strong>", Languages.LanguageStrings.SubTotal);
            btnApplyVoucherCode.Text = Languages.LanguageStrings.ApplyCode;
            btnCheckoutBasket.Text = Languages.LanguageStrings.Checkout;
            btnContinueShopping.Text = Languages.LanguageStrings.ContinueShopping;

            string RedirectURL = GetRedirectURL();
            
            if (RedirectURL != "")
            {
                Response.Redirect(RedirectURL, true);
                return;
            }

            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            _basket = localData.Basket;
            //_basket.Reset();

            //if (GetUser() != null && GetUser().ID == 0 && _basket.Items.Count == 0)
            //{
            //    Library.BOL.Products.ProductCost item = Library.BOL.Products.ProductCosts.Get(1969, GetUser());

            //    _basket.Add(item, 1, GetUser());
            //}

            if ((_basket.User != null && _basket.User.MemberLevel >= Library.MemberLevel.Distributor && _basket.User.AutoDiscount > 0))
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


            trGiftWrap.Visible = false;

            if (!IsPostBack)
            {
                txtVoucher.Text = GetVoucherString();
            }

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
                    SieraDelta.Website.Controls.BasketItemMobileControl bi = (SieraDelta.Website.Controls.BasketItemMobileControl)LoadControl("~/Controls/BasketItemMobileControl.ascx");
                    bi.Refresh(item);
                    divBasketMobile.Controls.Add(bi);
                }
            }
            else
            {
                divBasketMobile.InnerHtml += String.Format("<p>{0}</p>", Languages.LanguageStrings.BasketHasNoItems);
            }

            SieraDelta.Website.Controls.BasketMobileTotals bmt = (SieraDelta.Website.Controls.BasketMobileTotals)LoadControl("~/Controls/BasketMobileTotals.ascx");
            divBasketMobile.Controls.Add(bmt);
        }

        protected void BuildBasketItems()
        {
            //SieraDeltaUtils u = new SieraDeltaUtils();

            if (_basket.HasItems())
            {
                btnCheckoutBasket.Enabled = true;

                foreach (BasketItem item in _basket.Items)
                {
                    HtmlTableRow r = new HtmlTableRow();
                    tblBasket.Rows.Insert(1, r);
				    HtmlTableCell c = CreateCell(r, "");
                    c.ColSpan = 6;

                    SieraDelta.Website.Controls.BasketItemControl bi = (SieraDelta.Website.Controls.BasketItemControl)LoadControl("~/Controls/BasketItemControl.ascx");
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
            //SieraDeltaUtils u = new SieraDeltaUtils();
            string Result = String.Format("<strong>{0}</strong>", SharedUtils.FormatMoney(_basket.SubTotalMinusVAT, GetWebsiteCurrency(), false));
            tdSubTotalAmount.InnerHtml = Result;

            Result = String.Format("<strong>{0}</strong>", SharedUtils.FormatMoney(_basket.VATAmount, GetWebsiteCurrency(), false));
            tdVatAmount.InnerHtml = Result;

            Result = String.Format("<strong>{0}</strong>", SharedUtils.FormatMoney(_basket.ShippingCosts, GetWebsiteCurrency(), false));
            tdPostageAmount.InnerHtml = Result;

            Result = String.Format("<strong>{0}</strong>", SharedUtils.FormatMoney(_basket.TotalAmount, GetWebsiteCurrency(), false));
            tdTotalAmmount.InnerHtml = Result;

            trDiscount.Visible = (_basket.VoucherType == Enums.InvoiceVoucherType.Footprint) || (_basket.Discount > 0) ||
                (_basket.User != null && _basket.User.MemberLevel >= Library.MemberLevel.Distributor && _basket.User.AutoDiscount > 0);

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
                    Result = String.Format("<strong>{0}</strong>", SharedUtils.FormatMoney(_basket.DiscountAmount, GetWebsiteCurrency(), false));
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
            //SieraDeltaUtils u = new SieraDeltaUtils();
            string Result = "";


            return (Result);
        }

        protected void btnApplyVoucherCode_Click(object sender, EventArgs e)
        {
            if (txtVoucher.Text != "")
            {
                string resultText = String.Empty;

                if (_basket.ValidateCouponCode(txtVoucher.Text, ref resultText))
                {
                    Session["DISCOUNTCOUPON"] = txtVoucher.Text;
                }
                else
                    Session["DISCOUNTCOUPON"] = null;

                DoRedirect("/Shopping/Basket/", true);
            }
        }

        protected void btnCheckoutBasket_Click(object sender, EventArgs e)
        {
            if (!_basket.IsEmpty())
                DoRedirect("/Shopping/Basket/SignIn/", true);
        }

        protected void btnContinueShopping_Click(object sender, EventArgs e)
        {
            DoRedirect("/All-Products/");
        }

        protected void btnAddGiftWrapping_Click(object sender, EventArgs e)
        {
            if (_basket.GiftWrappingIncluded())
                _basket.GiftWrappingRemove();
            else
                _basket.GiftWrappingAdd(WebCountry.PriceColumn);

            DoRedirect("/Shopping/Basket/", true);
        }
    }
}