﻿using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Basket;
using Library.BOL.Users;
using Library.BOL.Invoices;
using Library.BOL.Websites;

#pragma warning disable IDE1006

namespace SieraDelta.Website.Members
{
    public partial class InvoiceView : BaseWebFormMember
    {
        private Library.BOL.Invoices.Invoice _invoice;
        private Currency _currency = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyAccount;
            LeftContainerControl1.SubOptions = GetAccountOptions();
            btnCancel.Text = Languages.LanguageStrings.CancelInvoice;
            pVAT.Visible = !Library.DAL.DALHelper.HideVATOnWebsiteAndInvoices;

            User user = GetUser();

            _invoice = user.Invoices.Find(SharedUtils.StrToIntDef((string)Page.RouteData.Values["invoice"], -1));

            if (_invoice == null)
                DoRedirect("/Account/Invoices/", true);

            BuildItems();

            ShowCancelButton();

            if (_invoice.ConversionRate == 1.0)
                pConversionRate.Visible = false;


            if (_invoice.DiscountAmount == 0.00m)
                pDiscount.Visible = false;
        }

        protected string GetInvoiceNumber()
        {
            return (_invoice.ID.ToString());
        }

        protected string GetConversionRate()
        {
            return (String.Format("{1}1 = {0}", SharedUtils.FormatMoney(1.0m, _invoice.Currency), 
                Shared.Utilities.GetCurrencySymbol(WebsiteSettings.Languages.WebsiteCulture)));
        }

        protected string GetDiscount()
        {
            string Result = "";

            if (_invoice.VoucherType == Library.Enums.InvoiceVoucherType.Percent)
                Result = String.Format("{0} @ {1}%", _invoice.CouponName, _invoice.Discount);
            else
                Result = String.Format("{0}", _invoice.CouponName);

            Result += String.Format(" {0}", SharedUtils.FormatMoney(_invoice.DiscountAmount, _invoice.Currency));

            if (_invoice.Culture != WebsiteSettings.Languages.WebsiteCulture.Name)
                Result += String.Format(" ({0})", SharedUtils.FormatMoney(_invoice.DiscountAmount, _invoice.Currency));

            return (Result);
        }

        protected string GetTrackingReference()
        {
            string Result = "";

            if (_invoice.TrackingReference != "")
            {
                Result = String.Format("<p><strong>{2}</strong> <a href=\"{1}\" target=\"_blank\">{0}</a></p>",
                    _invoice.TrackingReference, _invoice.TrackingURL,
                    Languages.LanguageStrings.OrderTrackingReference);
            }

            return (Result);
        }

        protected string GetInvoiceDate()
        {
            return (Shared.Utilities.DateTimeToStr(_invoice.PurchaseDateTime, _invoice.Culture));
        }

        protected string GetInvoiceSubtotal()
        {
            return (SharedUtils.FormatMoney(_invoice.InvoiceItems.SubTotal, _invoice.Currency));
        }

        protected string GetInvoicePostage()
        {
            string Result = SharedUtils.FormatMoney(_invoice.ShippingCosts, _invoice.Currency);

            if (_invoice.Culture != WebsiteSettings.Languages.WebsiteCulture.Name)
                Result += String.Format(" ({0})", SharedUtils.FormatMoney(_invoice.ShippingCosts, _invoice.Currency));

            return (Result);
        }

        protected string GetInvoiceVATRate()
        {
            return (_invoice.VATRate.ToString());
        }

        protected string GetInvoiceVAT()
        {
            string Result = SharedUtils.FormatMoney(_invoice.VATAmount, _invoice.Currency);

            if (_invoice.Culture != WebsiteSettings.Languages.WebsiteCulture.Name)
                Result += String.Format(" ({0})", SharedUtils.FormatMoney(_invoice.VATAmount, _invoice.Currency));

            return (Result);
        }

        protected string GetInvoiceTotal()
        {
            string Result = SharedUtils.FormatMoney(_invoice.TotalCost, _invoice.Currency);

            if (_invoice.Culture != WebsiteSettings.Languages.WebsiteCulture.Name)
                Result += String.Format(" ({0})", SharedUtils.FormatMoney(_invoice.TotalCost, _invoice.Currency));

            return (Result);
        }

        protected string GetInvoiceStatus(int Mode)
        {
            if (Mode == 0)
                return (EnumTranslations.TranslatedText(_invoice.Status));
            else
                return (EnumTranslations.TranslatedText(_invoice.ProcessStatus));
        }

        private Currency GetOrderCurrency()
        {
            if (_currency == null)
                _currency = Currencies.Get(new CultureInfo(_invoice.Culture));

            return (_currency);
        }

        private void ShowCancelButton()
        {
            btnCancel.Visible = false;

            if (_invoice.Status.IsPaid)
            {
                if (_invoice.ProcessStatus == Library.ProcessStatus.OrderReceived ||
                    _invoice.ProcessStatus == Library.ProcessStatus.Processing)
                {
                    btnCancel.Visible = false; //TODO turn on code by changing to true
                }
                else
                    btnCancel.Visible = false;
            }
            else
                btnCancel.Visible = false;
        }

        private void BuildItems()
        {
            foreach (InvoiceItem item in _invoice.InvoiceItems)
            {
                HtmlTableRow r = new HtmlTableRow();
                tblItems.Rows.Add(r);

                HtmlTableCell cDescription = new HtmlTableCell();
                r.Cells.Add(cDescription);
                cDescription.ColSpan = 2;
                cDescription.InnerText = item.Description;

                HtmlTableCell cPrice = new HtmlTableCell();
                r.Cells.Add(cPrice);

                cPrice.InnerText = SharedUtils.FormatMoney(item.Cost, _invoice.Currency);

                HtmlTableCell cQuantity = new HtmlTableCell();
                r.Cells.Add(cQuantity);
                cQuantity.InnerText = item.Quantity.ToString();

                HtmlTableCell cTotal = new HtmlTableCell();
                r.Cells.Add(cTotal);

                cTotal.InnerText = SharedUtils.FormatMoney(item.Cost * item.Quantity, _invoice.Currency);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            DoRedirect(String.Format("/Members/Invoice/CancelInvoice.aspx?ID={0}", _invoice.ID));
        }
    }
}