/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: PDFInvoicePaid.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Globalization;

using iTextSharp.text;
using iTextSharp.text.pdf;

using SharedBase.Utils;
using SharedBase.BOL.Invoices;
using SharedBase.BOL.Coupons;

namespace Reports.Accounts
{
    public class PDFInvoicePaid : BaseReport
    {
        #region Constructors / Destructors

        public PDFInvoicePaid(Invoice invoice, string header, string footer, 
            string paymentReceived, string culture, bool hideVAT, 
            string orderPreparedBy, int orderPreparedAlignment,
            bool invoiceShowProductDiscount)
            : base(UniqueFileName("Invoice", true))
        {
            string currentCulture = SetCurrentCulture(culture);

            try
            {
                CreateDocument(invoice, header, footer, paymentReceived, hideVAT, 
                    orderPreparedBy, orderPreparedAlignment, invoiceShowProductDiscount);
            }
            finally
            {
                SetCurrentCulture(currentCulture);
            }
        }

        public PDFInvoicePaid(Invoices invoices, string header, string footer, string paymentReceived, string culture,
            bool showVAT, string orderPreparedBy, int orderPreparedAlignment, bool invoiceShowProductDiscount)
            : base(UniqueFileName("Invoice", true))
        {
            string currentCulture = SetCurrentCulture(culture);

            try
            {
                Document myDocument = new Document(PageSize.A4);

                try
                {
                    PdfWriter.GetInstance(myDocument, new FileStream(FileName, FileMode.Create));

                    myDocument.Open();
                    int InvCount = invoices.Count;
                    int CurrInv = 1;

                    foreach (Invoice inv in invoices)
                    {
                        PrintHeader(myDocument, header);

                        PrintInvoiceHeader(myDocument, inv);
                        ParagraphAdd(myDocument);

                        PrintInvoiceAddress(myDocument, inv);
                        ParagraphAdd(myDocument);

                        PrintInvoiceItems(myDocument, inv, showVAT, invoiceShowProductDiscount);
                        ParagraphAdd(myDocument);

                        PrintFooter(myDocument, footer, paymentReceived, orderPreparedBy, orderPreparedAlignment);

                        if (CurrInv < InvCount)
                            myDocument.NewPage();

                        CurrInv++;
                    }
                }
                catch (DocumentException de)
                {
                    Console.Error.WriteLine(de.Message);
                }
                catch (IOException ioe)
                {
                    Console.Error.WriteLine(ioe.Message);
                }
                finally
                {
                    myDocument.Close();
                    myDocument.Dispose();
                    myDocument = null;
                }
            }
            finally
            {
                SetCurrentCulture(currentCulture);
            }
        }

        #endregion Constructors / Destructors

        /// <summary>
        /// Set's the culture for the POS
        /// </summary>
        private string SetCurrentCulture(string culture)
        {
            string Result = Thread.CurrentThread.CurrentCulture.Name;

            //set ui and thread culture 
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            return (Result);
        }

        private void CreateDocument(Invoice invoice, string header, string footer, 
            string paymentReceived, bool hideVAT,
            string orderPreparedBy, int orderPreparedAlignment,
            bool invoiceShowProductDiscount)
        {
            Document myDocument = new Document(PageSize.A4);

            try
            {
                PdfWriter.GetInstance(myDocument, new FileStream(FileName, FileMode.Create));

                myDocument.Open();

                PrintHeader(myDocument, header);

                PrintInvoiceHeader(myDocument, invoice);
                ParagraphAdd(myDocument);

                PrintInvoiceAddress(myDocument, invoice);
                ParagraphAdd(myDocument);

                PrintInvoiceItems(myDocument, invoice, hideVAT, invoiceShowProductDiscount);
                ParagraphAdd(myDocument);

                Coupon cpn = Coupons.ValidateCoupon(invoice.CouponName);

                if (cpn != null)
                    PrintPromotionCode(myDocument, cpn);

                if (invoice.Version == 6)
                    PrintNotes(myDocument, invoice);

                PrintFooter(myDocument, footer, paymentReceived, orderPreparedBy, orderPreparedAlignment);
            }
            catch (DocumentException de)
            {
                Console.Error.WriteLine(de.Message);
            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine(ioe.Message);
            }
            finally
            {
                myDocument.Close();
                myDocument.Dispose();
                myDocument = null;
            }
        }

        private void PrintHeader(Document document, string header)
        {
            Image jpg;

            if (header.Contains(":\\"))
            {
                jpg = Image.GetInstance(header);
                document.Add(jpg);
            }
        }

        private void PrintFooter(Document document, string footer, string paymentReceived,
            string orderPreparedBy, int orderPreparedAlignment)
        {
            Paragraph p = new Paragraph(String.Format(" \r\n\n{0}\r ", paymentReceived), FontTextBold);
            p.Alignment = 1;
            document.Add(p);

            p = new Paragraph(footer, FontText);
            p.Alignment = 1;
            document.Add(p);

            if (!String.IsNullOrEmpty(orderPreparedBy))
            {
                p = new Paragraph(String.Format("\r\n\r\n{0}", orderPreparedBy), FontText);
                p.Alignment = orderPreparedAlignment;
                document.Add(p);
            }
        }

        private void PrintPromotionCode(Document document, Coupon coupon)
        {
            if (coupon != null && coupon.VoucherType == SharedBase.Enums.InvoiceVoucherType.Footprint)
            {
                Paragraph p = new Paragraph(String.Format("{0}: {1}", Languages.LanguageStrings.PromotionCode, coupon.Name), FontText);
                document.Add(p);
            }
        }

        private void PrintNotes(Document document, Invoice invoice)
        {
            if (!String.IsNullOrEmpty(invoice.Notes))
            {
                Paragraph p = new Paragraph(String.Format("{1}\r\n{0}", invoice.Notes, Languages.LanguageStrings.Notes), FontText);
                document.Add(p);
            }
        }

        private void PrintInvoiceHeader(Document document, Invoice inv)
        {
            document.Add(new Paragraph(String.Format("{1}{0}", inv.DisplayID, Languages.LanguageStrings.InvoicePrefix), FontTextBoldLarge));

            Phrase p = new Phrase();
            p.Add(new Chunk(String.Format("\n{0}: ", Languages.LanguageStrings.Date), FontTextBoldLarge));
            p.Add(new Chunk(inv.PurchaseDateTime.ToString("d"), FontTextLarge));
            p.Add(new Chunk("\n"));
            Paragraph para = new Paragraph();
            para.Add(p);
            document.Add(para);
        }

        private void PrintInvoiceAddress(Document document, Invoice inv)
        {
            string Address = inv.User.Address(false);
            string AddressShip = inv.Address(false);
            bool Same = Address == AddressShip;

            PdfPTable tblAddr = new PdfPTable(Same ? 1 : 2);
            tblAddr.HorizontalAlignment = 0;
            tblAddr.WidthPercentage = 100f;

            PdfPCell cAddr = new PdfPCell(new Phrase(Languages.LanguageStrings.Address, FontTextBoldLarge));
            PdfPCell cAddrShip;

            BorderRemove(ref cAddr);
            tblAddr.AddCell(cAddr);

            if (!Same)
            {
                cAddrShip = new PdfPCell(new Phrase(Languages.LanguageStrings.DeliveryAddress, FontTextBoldLarge));
                BorderRemove(ref cAddrShip);
                tblAddr.AddCell(cAddrShip);
            }

            cAddr = new PdfPCell(new Phrase(inv.User.Address(false), FontText));
            BorderRemove(ref cAddr);
            tblAddr.AddCell(cAddr);

            if (!Same)
            {
                cAddrShip = new PdfPCell(new Phrase(inv.Address(false), FontText));
                BorderRemove(ref cAddrShip);
                tblAddr.AddCell(cAddrShip);
            }

            document.Add(tblAddr);


            Phrase Addr = new Phrase();
            Addr.Add(new Chunk(String.Format("\n{0}: ", Languages.LanguageStrings.Telephone), FontTextBold));
            Addr.Add(new Chunk(inv.User.Telephone, FontText));
            Addr.Add(new Chunk(String.Format("\n{0}: ", Languages.LanguageStrings.Email), FontTextBold));
            Addr.Add(new Chunk(inv.User.Email.ToLower(), FontText));
            Paragraph para = new Paragraph();
            para.Add(Addr);
            document.Add(para);

        }

        private void PrintInvoiceItems(Document document, Invoice inv, bool hideVAT,
            bool invoiceShowProductDiscount)
        {
            PdfPTable tblAddr = new PdfPTable(6);
            tblAddr.HorizontalAlignment = 0;
            tblAddr.WidthPercentage = 100f;

            tblAddr.AddCell(NewCell(new Phrase(Languages.LanguageStrings.Item, FontTextBold), 3, false));
            tblAddr.AddCell(NewCell(new Phrase(Languages.LanguageStrings.Price, FontTextBold), 1, false, 2));
            tblAddr.AddCell(NewCell(new Phrase(Languages.LanguageStrings.Quantity, FontTextBold), 1, false, 2));
            tblAddr.AddCell(NewCell(new Phrase(Languages.LanguageStrings.Total, FontTextBold), 1, false, 2));

            foreach (InvoiceItem item in inv.InvoiceItems)
            {
                string description = item.Description;

                if (invoiceShowProductDiscount && item.UserDiscount > 0.00m)
                {
                    description = String.Format(Languages.LanguageStrings.AppProductDiscount, description, item.UserDiscount);
                }

                tblAddr.AddCell(NewCell(new Phrase(description, FontText), 3, false));
                tblAddr.AddCell(NewCell(new Phrase(item.CostStr, FontText), 1, false, 2));
                tblAddr.AddCell(NewCell(new Phrase(item.Quantity.ToString(), FontText), 1, false, 2));
                tblAddr.AddCell(NewCell(new Phrase(item.PriceStr, FontText), 1, false, 2));
            }

            tblAddr.AddCell(NewCell(new Phrase("Subtotal", FontText), 5, false, 2));
            tblAddr.AddCell(NewCell(new Phrase(inv.InvoiceItems.SubTotalStr, FontText), 1, false, 2));

            if (inv.Discount > 0 || !String.IsNullOrEmpty(inv.CouponName))
            {
                if (inv.VoucherType == SharedBase.Enums.InvoiceVoucherType.Percent)
                {
                    tblAddr.AddCell(NewCell(new Phrase(String.Format("{1} ({2}) @ {0}%", inv.Discount, 
                        Languages.LanguageStrings.Discount, inv.CouponName), FontText), 5, false, 2));
                    tblAddr.AddCell(NewCell(new Phrase(inv.DiscountAmountStr, FontText), 1, false, 2));
                }
                else
                {
                    tblAddr.AddCell(NewCell(new Phrase(String.Format("{0} ({1})", 
                        Languages.LanguageStrings.Discount, inv.CouponName), FontText), 5, false, 2));
                    tblAddr.AddCell(NewCell(new Phrase(inv.DiscountAmountStr, FontText), 1, false, 2));
                }
            }

            if (!hideVAT)
            {
                tblAddr.AddCell(NewCell(new Phrase(String.Format("{1} @ {0}%", inv.VATRate, 
                    Languages.LanguageStrings.VAT), FontText), 5, false, 2));
                tblAddr.AddCell(NewCell(new Phrase(inv.VatAmountStr, FontText), 1, false, 2));
            }

            tblAddr.AddCell(NewCell(new Phrase(Languages.LanguageStrings.PostageAndPackaging, FontText), 5, false, 2));
            tblAddr.AddCell(NewCell(new Phrase(inv.ShippingCostsStr, FontText), 1, false, 2));

            tblAddr.AddCell(NewCell(new Phrase(Languages.LanguageStrings.Total, FontTextBold), 5, false, 2));
            tblAddr.AddCell(NewCell(new Phrase(inv.TotalCostStr, FontTextBold), 1, false, 2));

            document.Add(tblAddr);
        }
    }
}
