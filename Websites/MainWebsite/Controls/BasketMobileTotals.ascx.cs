using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Library.BOL.Basket;
using Library.Utils;
using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class BasketMobileTotals : BaseControlClass
    {
        private ShoppingBasket _basket = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            _basket = GetBasket();
            SetTotalsMobile();
        }


        private void SetTotalsMobile()
        {
            string Result;

            if (Global.ShowBasketSubTotalWithVAT)
                Result = String.Format("<strong>{1}<span>{0}</span></strong>",
                    SharedUtils.FormatMoney(_basket.SubTotalAmount + SharedUtils.VATCalculate(_basket.SubTotalAmount, _basket.VATRate), 
                    GetWebsiteCurrency(), false),
                    Languages.LanguageStrings.Total);
            else
                Result = String.Format("<strong>{1}<span>{0}</span></strong>", 
                    SharedUtils.FormatMoney(_basket.SubTotalMinusVAT, GetWebsiteCurrency(), false),
                    Languages.LanguageStrings.Total);

            pSubTotal.InnerHtml = Result;

            Result = String.Format("<strong>{1} ({2}%)<span>{0}</span></strong>", 
                SharedUtils.FormatMoney(_basket.VATAmount, GetWebsiteCurrency(), false),
                Languages.LanguageStrings.VAT,
                _basket.VATRate);

            pVAT.InnerHtml = Result;

            Result = String.Format("<strong>{1}<span>{0}</span></strong>",
                SharedUtils.FormatMoney(_basket.ShippingCosts, GetWebsiteCurrency(), false),
                Languages.LanguageStrings.PostageAndPackaging);
            pPostage.InnerHtml = Result;

            Result = String.Format("<strong>{1}<span>{0}</span></strong>", 
                SharedUtils.FormatMoney(_basket.TotalAmount, GetWebsiteCurrency(), false),
                Languages.LanguageStrings.SubTotal);
            pTotal.InnerHtml = Result;

            pDiscount.Visible = (_basket.VoucherType == Enums.InvoiceVoucherType.Footprint) || (_basket.Discount > 0) ||
                (_basket.User != null && _basket.User.MemberLevel >= Library.MemberLevel.Distributor && _basket.User.AutoDiscount > 0);

            if (pDiscount.Visible)
            {
                switch (_basket.VoucherType)
                {
                    case Enums.InvoiceVoucherType.Percent:
                        Result = String.Format("<strong>{2} ({0} @ {1}%):<span>{3}</span></strong>",
                            _basket.DiscountCouponName, _basket.Discount, Languages.LanguageStrings.Discount,
                            _basket.DiscountCost);
                        break;
                    case Enums.InvoiceVoucherType.Value:
                        Result = String.Format("<strong>{1}: {0}:<span>{2}</span></strong>", _basket.DiscountCouponName,
                            Languages.LanguageStrings.DiscountCode, _basket.DiscountCost);
                        break;
                    case Enums.InvoiceVoucherType.Footprint:
                        Result = String.Format("<strong>{1}: {0}<span>{2}</span></strong>", _basket.DiscountCouponName,
                            Languages.LanguageStrings.PromotionCode, _basket.DiscountCost);
                        break;
                }

                pDiscount.InnerHtml = Result;
            }
        }

        protected void btnApplyVoucherCode_Click(object sender, EventArgs e)
        {
            if (txtVoucher.Text != "")
            {
                string resultText = String.Empty;
                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;

                if (_basket.ValidateCouponCode(txtVoucher.Text, ref resultText))
                {
                    localData.DiscountCoupon = txtVoucher.Text;
                }
                else
                    localData.DiscountCoupon = String.Empty;

                DoRedirect("/Basket/Basket.aspx", true);
            }
        }

    }
}