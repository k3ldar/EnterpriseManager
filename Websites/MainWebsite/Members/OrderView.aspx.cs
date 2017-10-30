using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.Orders;
using Library.BOL.Countries;

namespace Heavenskincare.WebsiteTemplate.Members
{
    public partial class OrderView : BaseWebFormMember
    {
        private Order _order;

        protected void Page_Load(object sender, EventArgs e)
        {
            pVAT.Visible = !Library.DAL.DALHelper.HideVATOnWebsiteAndInvoices;
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyAccount;
            LeftContainerControl1.SubOptions = GetAccountOptions();

            pSubTotal.Visible = Global.ShowSubTotalOnOrdersAndInvoices;

            User user = GetUser();

            _order = user.Orders.Find(GetFormValue("ID", -1));

            if (_order == null)
                DoRedirect("/Members/Orders.aspx", true);

            BuildItems();

            if (_order.ConversionRate == 1.0)
                pConversionRate.Visible = false;

            if (_order.DiscountAmount == 0.00m)
                pDiscount.Visible = false;
        }

        protected string GetOrderNumber()
        {
            return (_order.ID.ToString());
        }

        protected string GetOrderDate()
        {
            return (Shared.Utilities.DateTimeToStr(_order.PurchaseDateTime, WebCulture));
        }

        protected string GetConversionRate()
        {
            Country originalCountry = _order.OriginalCountry > -1 ? Countries.Get(_order.OriginalCountry) : _order.User.Country;

            return (String.Format("{1}1 = {0}",
                SharedUtils.FormatMoney(1.0m, _order.Currency),
                Shared.Utilities.GetCurrencySymbol(_order.Culture)));
        }

        protected string GetOrderSubtotal()
        {
            switch (_order.Version)
            {
                case Library.Consts.INVOICE_VERSION_VAT_ADD:
                case Library.Consts.INVOICE_VERSION_VAT_ADD_OPTIONS:
                    return (SharedUtils.FormatMoney(_order.OrderItems.SubTotal, _order.Currency));
                default:
                    if (BaseWebApplication.ShowBasketItemsWithVAT)
                        return (SharedUtils.FormatMoney(_order.OrderItems.SubTotal, _order.Currency));
                    else
                        return (SharedUtils.FormatMoney(SharedUtils.VATRemove(_order.OrderItems.SubTotal, _order.VATRate), _order.Currency));
            }
        }

        protected string GetOrderPostage()
        {
            return (SharedUtils.FormatMoney(_order.ShippingCosts, _order.Currency, false, true));
        }

        protected string GetOrderVATRate()
        {
            return (_order.VATRate.ToString());
        }

        protected string GetOrderVAT()
        {
            return (SharedUtils.FormatMoney(_order.VATAmount, _order.Currency));
        }

        protected string GetDiscount()
        {
            string Result = "";

            if (_order.VoucherType == Library.Enums.InvoiceVoucherType.Percent)
                Result = String.Format("{0} ({1}%)", _order.CouponName, _order.Discount);
            else
                Result = String.Format("{0}", _order.CouponName);

            Result += String.Format(" {0}", SharedUtils.FormatMoney(_order.DiscountAmount, _order.Currency));

            return (Result);
        }

        protected string GetOrderTotal()
        {
            return (SharedUtils.FormatMoney(_order.TotalCost, _order.Currency, false, true));
        }

        protected string GetOrderStatus(int Mode)
        {
            if (Mode == 0)
                return (EnumTranslations.TranslatedText(_order.Status));
            else
                return (EnumTranslations.TranslatedText(_order.ProcessStatus));
        }


        private void BuildItems()
        {
            foreach (OrderItem item in _order.OrderItems)
            {
                HtmlTableRow r = new HtmlTableRow();
                tblItems.Rows.Add(r);

                HtmlTableCell cDescription = new HtmlTableCell();
                r.Cells.Add(cDescription);
                cDescription.ColSpan = 2;
                cDescription.InnerText = item.Description;

                HtmlTableCell cPrice = new HtmlTableCell();
                r.Cells.Add(cPrice);

                switch (_order.Version)
                {
                    case Library.Consts.INVOICE_VERSION_VAT_ADD:
                    case Library.Consts.INVOICE_VERSION_VAT_ADD_OPTIONS:
                        cPrice.InnerText = SharedUtils.FormatMoney(item.Cost, _order.Currency);

                        break;
                    default:
                        if (Global.ShowBasketItemsWithVAT)
                            cPrice.InnerText = SharedUtils.FormatMoney(item.Cost, _order.Currency);
                        else
                            cPrice.InnerText = SharedUtils.FormatMoney(SharedUtils.VATRemove(item.Cost, _order.VATRate), _order.Currency);

                        break;
                }

                HtmlTableCell cQuantity = new HtmlTableCell();
                r.Cells.Add(cQuantity);
                cQuantity.InnerText = item.Quantity.ToString();

                HtmlTableCell cTotal = new HtmlTableCell();
                r.Cells.Add(cTotal);

                switch (_order.Version)
                {
                    case Library.Consts.INVOICE_VERSION_VAT_ADD:
                    case Library.Consts.INVOICE_VERSION_VAT_ADD_OPTIONS:
                            cTotal.InnerText = SharedUtils.FormatMoney(item.Cost * item.Quantity, _order.Currency);

                        break;
                    default:
                        if (BaseWebApplication.ShowBasketItemsWithVAT)
                            cTotal.InnerText = SharedUtils.FormatMoney(item.Cost * item.Quantity,
                                _order.Currency);
                        else
                            cTotal.InnerText = SharedUtils.FormatMoney(SharedUtils.VATRemove(item.Cost, _order.VATRate) 
                                * item.Quantity, _order.Currency);

                        break;
                }
            }
        }
    }
}