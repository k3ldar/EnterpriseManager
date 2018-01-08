using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;

using Library.BOL.Users;
using Library.BOL.Invoices;
using Library.BOL.DatabaseUpdates;
using Library.BOL.DeliveryAddress;
using Library.Utils;
using Website.Library.Classes.Reports;

namespace SieraDelta.Website.Reports
{
    public class CustomerReport : BasePDFReport
    {
        #region Private / Protected Members

        private User _user;
        private List<string> _ipAddresses;
        private List<string> _sessions;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public CustomerReport(string FileName, string Email)
            : base(UniqueFileName(FileName, false))
        {
            CreateDocument(Email);
        }

        #endregion Constructors / Destructors

        private void CreateDocument(string Email)
        {
            _user = User.UserGet(Email);
            _sessions = new List<string>();
            _ipAddresses = new List<string>();

            Document myDocument = new Document(PageSize.A4);

            try
            {
                PdfWriter pdfWriter = PdfWriter.GetInstance(myDocument, new FileStream(FileName, FileMode.Create));
                TwoColumnHeaderFooter pageeventhandler = new TwoColumnHeaderFooter();
                pageeventhandler.Title = "Heaven Skincare Ltd - Customer Report";
                pageeventhandler.SubTitle = String.Format("{0} ({1})", _user.UserName, _user.Email);

                pdfWriter.PageEvent = pageeventhandler;

                myDocument.Open();
                myDocument.SetMargins(myDocument.LeftMargin, myDocument.RightMargin, myDocument.TopMargin + 30, myDocument.BottomMargin);

                PrintHeader(myDocument);

                PrintUser(myDocument);

                PrintDeliveryAddresses(myDocument);

                PrintInvoices(myDocument);

                PrintFooter(myDocument);

            }
            catch (DocumentException de)
            {
                Console.Error.WriteLine(de.Message);
            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine(ioe.Message);
            }

            myDocument.Close();
        }

        private void PrintHeader(Document document)
        {
            //document.Add(new Paragraph(String.Format("Customer Report - {0}", _user.UserName), FontTextBoldLarge));
        }

        private void PrintUser(Document document)
        {
            Phrase p = new Phrase();

            p.Add(new Chunk("\nID: ", FontTextBold));
            p.Add(new Chunk(_user.ID.ToString(), FontText));
            p.Add(new Chunk("\n"));

            p.Add(new Chunk("\nFirst Name: ", FontTextBold));
            p.Add(new Chunk(_user.FirstName, FontText));
            p.Add(new Chunk("\n"));

            p.Add(new Chunk("\nLast Name: ", FontTextBold));
            p.Add(new Chunk(_user.LastName, FontText));
            p.Add(new Chunk("\n"));

            p.Add(new Chunk("\nEmail Address: ", FontTextBold));
            p.Add(new Chunk(_user.Email, FontTextLarge));
            p.Add(new Chunk("\n"));

            p.Add(new Chunk("\nDate Of Birth: ", FontTextBold));
            p.Add(new Chunk(_user.BirthDate.ToShortDateString(), FontText));
            p.Add(new Chunk("\n"));

            p.Add(new Chunk("\nAddress:\n", FontTextBold));
            p.Add(new Chunk(_user.Address(false), FontText));
            p.Add(new Chunk("\n"));

            Paragraph para = new Paragraph();
            para.Add(p);
            document.Add(para);

            ShowUpdates(document, "WS_MEMBERS", _user.ID);
        }

        private void PrintInvoices(Document document)
        {
            foreach (Invoice invoice in _user.Invoices)
            {
                document.NewPage();

                PrintInvoiceHeader(document, invoice);
                ParagraphAdd(document);

                PrintInvoiceAddress(document, invoice);
                ParagraphAdd(document);

                PrintInvoiceItems(document, invoice);
                ParagraphAdd(document);

                ShowUpdates(document, "WS_INVOICE_ORDERS", invoice.ID);

                //if (!_sessions.Contains(invoice.UserSession) && invoice.UserSession != "" && !invoice.UserSession.Contains("@"))
                //{
                //    _sessions.Add(invoice.UserSession);

                //    PrintSessionInfo(document, invoice.UserSession);
                //}

                //foreach (string IPAddress in _ipAddresses)
                //{
                //    PrintIPHistory(document, IPAddress);
                //}
            }
        }

        //private void PrintIPHistory(Document document, string IPAddress)
        //{
        //    Updates updates = Updates.GetWebLogByIP(IPAddress);

        //    if (updates.Count == 0)
        //    {
        //        document.Add(new Paragraph("No IP Address Data Found", FontTextSmall));
        //    }
        //    else
        //    {
        //        Phrase p = new Phrase();
        //        p.Add(new Chunk(String.Format("IP Address History: {0}\n", IPAddress), FontTextBold));
        //        p.Add(new Chunk("\n"));
        //        Paragraph para = new Paragraph();
        //        para.Add(p);
        //        document.Add(para);

        //        PdfPTable table = new PdfPTable(5);
        //        table.HorizontalAlignment = 0;
        //        table.TotalWidth = 530f;
        //        table.LockedWidth = true;
        //        float[] widths = new float[] { 42f, 100f, 184f, 47f, 157f };
        //        table.SetWidths(widths);

        //        table.AddCell(new Phrase("ID", FontTextBold));
        //        table.AddCell(new Phrase("Updated", FontTextBold));
        //        table.AddCell(new Phrase("Path", FontTextBold));
        //        table.AddCell(new Phrase("CountryCode", FontTextBold));
        //        table.AddCell(new Phrase("User Session", FontTextBold));

        //        foreach (Update update in updates)
        //        {
        //            table.AddCell(new Phrase(update.ID.ToString(), FontTextSmall));
        //            table.AddCell(new Phrase(update.Updated.ToString("dd/MM/yyyy HH:mm:ss"), FontTextSmall));
        //            table.AddCell(new Phrase(update.Column, FontTextSmall));
        //            table.AddCell(new Phrase(update.OldValue, FontTextSmall));
        //            table.AddCell(new Phrase(update.NewValue, FontTextSmall));
        //        }

        //        document.Add(table);
        //    }
        //}

        //private void PrintSessionInfo(Document document, string Session)
        //{
        //    Updates updates = Updates.GetWebLog(Session);

        //    if (updates.Count == 0)
        //    {
        //        document.Add(new Paragraph("No Session Data Found", FontTextSmall));
        //    }
        //    else
        //    {
        //        Phrase p = new Phrase();
        //        p.Add(new Chunk(String.Format("\nSession: {0}\n", Session), FontTextBold));
        //        p.Add(new Chunk("\n"));
        //        Paragraph para = new Paragraph();
        //        para.Add(p);
        //        document.Add(para);

        //        PdfPTable table = new PdfPTable(5);
        //        table.HorizontalAlignment = 0;
        //        table.TotalWidth = 530f;
        //        table.LockedWidth = true;
        //        float[] widths = new float[] { 42f, 100f, 274f, 47f, 67f };
        //        table.SetWidths(widths);

        //        table.AddCell(new Phrase("ID", FontTextBold));
        //        table.AddCell(new Phrase("Updated", FontTextBold));
        //        table.AddCell(new Phrase("Path", FontTextBold));
        //        table.AddCell(new Phrase("CountryCode", FontTextBold));
        //        table.AddCell(new Phrase("IP Address", FontTextBold));

        //        foreach (Update update in updates)
        //        {
        //            table.AddCell(new Phrase(update.ID.ToString(), FontTextSmall));
        //            table.AddCell(new Phrase(update.Updated.ToString("dd/MM/yyyy HH:mm:ss"), FontTextSmall));
        //            table.AddCell(new Phrase(update.Column, FontTextSmall));
        //            table.AddCell(new Phrase(update.OldValue, FontTextSmall));
        //            table.AddCell(new Phrase(update.NewValue, FontTextSmall));

        //            if (!_ipAddresses.Contains(update.NewValue))
        //                _ipAddresses.Add(update.NewValue);
        //        }

        //        document.Add(table);
        //    }
        //}

        private void ShowDeletes(Document document, string TableName, string ColumnName, Int64 Key)
        {
            Updates updates = Updates.GetDeleted(TableName, ColumnName, Key);

            Phrase p = new Phrase();

            p.Add(new Chunk("\nDeleted:\n", FontTextBold));
            p.Add(new Chunk("\n"));
            Paragraph para = new Paragraph();
            para.Add(p);
            document.Add(para);


            if (updates.Count == 0)
            {
                document.Add(new Paragraph("No Deletes Found", FontTextSmall));
            }
            else
            {
                PdfPTable table = new PdfPTable(5);
                table.HorizontalAlignment = 0;
                table.TotalWidth = 530f;
                table.LockedWidth = true;
                float[] widths = new float[] { 42f, 100f, 94f, 147f, 147f };
                table.SetWidths(widths);

                table.AddCell(new Phrase("ID", FontTextBold));
                table.AddCell(new Phrase("Updated", FontTextBold));
                table.AddCell(new Phrase("Column", FontTextBold));
                table.AddCell(new Phrase("Old Value", FontTextBold));
                table.AddCell(new Phrase("New Value", FontTextBold));

                foreach (Update update in updates)
                {
                    table.AddCell(new Phrase(update.ID.ToString(), FontTextSmall));
                    table.AddCell(new Phrase(update.Column, FontTextSmall));
                    table.AddCell(new Phrase(update.Updated.ToString("dd/MM/yyyy HH:mm:ss"), FontTextSmall));
                    table.AddCell(new Phrase(update.OldValue, FontTextSmall));
                    table.AddCell(new Phrase(update.NewValue, FontTextSmall));
                }

                document.Add(table);
            }
        }

        private void ShowUpdates(Document document, string TableName, Int64 Key)
        {
            Updates updates = Updates.GetUpdates(TableName, Key);

            if (updates.Count == 0)
            {
                document.Add(new Paragraph("No Updates Found", FontTextSmall));
            }
            else
            {
                Phrase p = new Phrase();
                p.Add(new Chunk("\nUpdates:\n", FontTextBold));
                p.Add(new Chunk("\n"));
                Paragraph para = new Paragraph();
                para.Add(p);
                document.Add(para);

                PdfPTable table = new PdfPTable(5);
                table.HorizontalAlignment = 0;
                table.TotalWidth = 530f;
                table.LockedWidth = true;
                float[] widths = new float[] { 42f, 100f, 94f, 147f, 147f };
                table.SetWidths(widths);

                table.AddCell(new Phrase("ID", FontTextBold));
                table.AddCell(new Phrase("Updated", FontTextBold));
                table.AddCell(new Phrase("Column", FontTextBold));
                table.AddCell(new Phrase("Old Value", FontTextBold));
                table.AddCell(new Phrase("New Value", FontTextBold));

                foreach (Update update in updates)
                {
                    table.AddCell(new Phrase(update.ID.ToString(), FontTextSmall));
                    table.AddCell(new Phrase(update.Column, FontTextSmall));
                    table.AddCell(new Phrase(update.Updated.ToString("dd/MM/yyyy HH:mm:ss"), FontTextSmall));
                    table.AddCell(new Phrase(update.OldValue, FontTextSmall));
                    table.AddCell(new Phrase(update.NewValue, FontTextSmall));
                }

                document.Add(table);
            }
        }

        private void PrintDeliveryAddresses(Document document)
        {
            DeliveryAddresses addresses = _user.DeliveryAddresses;

            document.Add(new Paragraph("Delivery Addresses", FontTextBoldLarge));

            foreach (DeliveryAddress address in addresses)
            {
                Paragraph p = new Paragraph(String.Format("ID: {0}\n{1}", address.ID, address.Address(false)), FontText);
                document.Add(p);

                ShowUpdates(document, "WS_MEMBERS_ADDRESSES", address.ID);

                ParagraphAdd(document);
            }

            ShowDeletes(document, "WS_MEMBERS_ADDRESSES", "MEMBER_ID", (Int64)_user.ID);
        }

        private void PrintFooter(Document document)
        {
            string FooterText = "Heaven Health & Beauty Ltd\n" +
                "13a Market Place, Shifnal, Shropshire, TF11 9AU\n" +
                "Heaven Health & Beauty Ltd. Registered in England No. 3095876\n";
            Paragraph p = new Paragraph(FooterText, FontText);
            p.Alignment = 1;

            document.Add(p);
        }

        private void PrintInvoiceHeader(Document document, Invoice inv)
        {
            document.Add(new Paragraph(String.Format("Invoice Number: WI{0}", inv.ID), FontTextBoldLarge));

            Phrase p = new Phrase();
            p.Add(new Chunk("\nDate: ", FontTextBoldLarge));
            p.Add(new Chunk(inv.PurchaseDateTime.ToString("dd/MM/yy"), FontTextLarge));
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

            PdfPCell cAddr = new PdfPCell(new Phrase("Invoice Address", FontTextBoldLarge));
            PdfPCell cAddrShip;

            RemoveBorder(ref cAddr);
            tblAddr.AddCell(cAddr);

            if (!Same)
            {
                cAddrShip = new PdfPCell(new Phrase("Shipping Address", FontTextBoldLarge));
                RemoveBorder(ref cAddrShip);
                tblAddr.AddCell(cAddrShip);
            }

            cAddr = new PdfPCell(new Phrase(inv.User.Address(false), FontText));
            RemoveBorder(ref cAddr);
            tblAddr.AddCell(cAddr);

            if (!Same)
            {
                cAddrShip = new PdfPCell(new Phrase(inv.Address(false), FontText));
                RemoveBorder(ref cAddrShip);
                tblAddr.AddCell(cAddrShip);
            }

            document.Add(tblAddr);


            Phrase Addr = new Phrase();
            Addr.Add(new Chunk("\nTel: ", FontTextBold));
            Addr.Add(new Chunk(inv.User.Telephone, FontText));
            Addr.Add(new Chunk("\nEmail: ", FontTextBold));
            Addr.Add(new Chunk(inv.User.Email.ToLower(), FontText));
            Paragraph para = new Paragraph();
            para.Add(Addr);
            document.Add(para);

        }

        private void PrintInvoiceItems(Document document, Invoice inv)
        {
            PdfPTable tblAddr = new PdfPTable(6);
            tblAddr.HorizontalAlignment = 0;
            tblAddr.WidthPercentage = 100f;

            tblAddr.AddCell(NewCell(new Phrase("Item", FontTextBold), 3, false));
            tblAddr.AddCell(NewCell(new Phrase("Cost", FontTextBold), 1, false, 2));
            tblAddr.AddCell(NewCell(new Phrase("Quantity", FontTextBold), 1, false, 2));
            tblAddr.AddCell(NewCell(new Phrase("Price", FontTextBold), 1, false, 2));

            foreach (InvoiceItem item in inv.InvoiceItems)
            {
                tblAddr.AddCell(NewCell(new Phrase(item.Description, FontText), 3, false));
                tblAddr.AddCell(NewCell(new Phrase(SharedUtils.FormatMoney(item.Cost, inv.Currency), FontText), 1, false, 2));
                tblAddr.AddCell(NewCell(new Phrase(item.Quantity.ToString(), FontText), 1, false, 2));
                tblAddr.AddCell(NewCell(new Phrase(SharedUtils.FormatMoney(item.Price, inv.Currency), FontText), 1, false, 2));
            }

            tblAddr.AddCell(NewCell(new Phrase("Subtotal", FontText), 5, false, 2));
            tblAddr.AddCell(NewCell(new Phrase(SharedUtils.FormatMoney(inv.InvoiceItems.SubTotal, inv.Currency), FontText), 1, false, 2));

            if (inv.Discount > 0)
            {
                tblAddr.AddCell(NewCell(new Phrase(String.Format("Discount @ {0}%", inv.Discount), FontText), 5, false, 2));
                tblAddr.AddCell(NewCell(new Phrase(SharedUtils.FormatMoney(inv.DiscountAmount, inv.Currency), FontText), 1, false, 2));
            }

            tblAddr.AddCell(NewCell(new Phrase(String.Format("VAT @ {0}%", inv.VATRate), FontText), 5, false, 2));
            tblAddr.AddCell(NewCell(new Phrase(SharedUtils.FormatMoney(inv.VATAmount, inv.Currency), FontText), 1, false, 2));

            tblAddr.AddCell(NewCell(new Phrase("Shipping", FontText), 5, false, 2));
            tblAddr.AddCell(NewCell(new Phrase(SharedUtils.FormatMoney(inv.ShippingCosts, inv.Currency), FontText), 1, false, 2));

            tblAddr.AddCell(NewCell(new Phrase("Total", FontTextBold), 5, false, 2));
            tblAddr.AddCell(NewCell(new Phrase(SharedUtils.FormatMoney(inv.TotalCost, inv.Currency), FontTextBold), 1, false, 2));

            document.Add(tblAddr);
        }

    }
}
