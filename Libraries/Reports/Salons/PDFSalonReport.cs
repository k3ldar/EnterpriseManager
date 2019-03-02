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
 *  File: PDFSalonReport.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;

using SharedBase.Utils;
using SharedBase.BOL.Users;
using SharedBase.BOL.Therapists;
using SharedBase.BOL.Refunds;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation
#pragma warning disable IDE0016 // null check simplified

namespace Reports.Salons
{
    public class PDFSalonReport : BaseReport
    {
        public PDFSalonReport(DateTime From, DateTime To, Therapists therapists, string rootPath = "")
            : base(UniqueFileName("SalonReport", true, rootPath))
        {
            RootPath = rootPath;
            CreateDocument(From.Date, To.Date, therapists);
        }

        private void CreateDocument(DateTime From, DateTime To, Therapists therapists)
        {
            Document myDocument = new Document(PageSize.A4);

            try
            {
                PdfWriter.GetInstance(myDocument, new FileStream(FileName, FileMode.Create));

                myDocument.Open();

                if (From == To)
                    PrintHeader(myDocument, String.Format("Report Date - {0}", From.ToShortDateString()));
                else
                    PrintHeader(myDocument, String.Format("Report Dates - {0} to {1}", From.ToShortDateString(), To.ToShortDateString()));

                LoadAppointments(myDocument, therapists, From, To);

                LoadRefunds(myDocument, From, To);

                //PrintInvoiceHeader(myDocument, invoice);
                //ParagraphAdd(myDocument);

                //PrintInvoiceAddress(myDocument, invoice);
                //ParagraphAdd(myDocument);

                //PrintInvoiceItems(myDocument, invoice);
                //ParagraphAdd(myDocument);

                //PrintFooter(myDocument);
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

        private void PrintHeader(Document document, string Header)
        {
            Image jpg = null;

            if (String.IsNullOrEmpty(RootPath))
                jpg = Image.GetInstance(ImagePath + "SalonReportHeader.jpg");
            else
                jpg = Image.GetInstance(RootPath.Replace("Reports\\cReports", "images\\") + "SalonReportHeader.jpg");

            document.Add(jpg);

            document.Add(new Paragraph(Header, FontTextBoldLarge));
            ParagraphAdd(document);
        }

        private void LoadRefunds(Document document, DateTime From, DateTime To)
        {
            document.Add(new Paragraph("Refunds", FontTextBold));
            ParagraphAdd(document);
            
            Refunds refunds = Refunds.Get(From, To);

            if (refunds.Count > 0)
            {
                //create a table
                PdfPTable table = new PdfPTable(6);
                table.HorizontalAlignment = 0;
                table.TotalWidth = 530f;
                table.LockedWidth = true;
                float[] widths = new float[] { 100f, 60f, 60f, 60f, 60f, 190f };
                table.SetWidths(widths);

                table.AddCell(new Phrase("Employee", FontTextBold));
                table.AddCell(new Phrase("Invoice ID", FontTextBold));
                table.AddCell(new Phrase("Amount", FontTextBold));
                table.AddCell(new Phrase("Date", FontTextBold));
                table.AddCell(new Phrase("Customer", FontTextBold));
                table.AddCell(new Phrase("Reason", FontTextBold));

                foreach (Refund refund in refunds)
                {
                    table.AddCell(new Phrase(User.UserGet((int)refund.Employee).UserName, FontText));
                    table.AddCell(new Phrase(refund.InvoiceID.ToString(), FontText));
                    table.AddCell(new Phrase(SharedUtils.FormatMoney(refund.Amount,
                        SharedBase.BOL.Basket.Currencies.Get("GBP")), FontText));
                    table.AddCell(new Phrase(refund.Date.ToString("g"), FontText));
                    table.AddCell(new Phrase(User.UserGet((int)refund.User).UserName, FontText));
                    table.AddCell(new Phrase(refund.Reason, FontText));
                }

                document.Add(table);
            }
            else
            {
                document.Add(new Paragraph("No Refunds Found", FontTextSmall));
            }

            ParagraphAdd(document);
        }

        private void LoadAppointments(Document document, Therapists therapists, DateTime From, DateTime To)
        {
            document.Add(new Paragraph("Activity", FontTextBold));
            ParagraphAdd(document);

            //create a table
            PdfPTable table = new PdfPTable(8);
            table.HorizontalAlignment = 0;
            table.TotalWidth = 530f;
            table.LockedWidth = true;
            float[] widths = new float[] { 100f, 60f, 60f, 60f, 50f, 80f, 60f, 60f };
            table.SetWidths(widths);

            table.AddCell(new Phrase("Employee", FontTextBold));
            table.AddCell(new Phrase("Confirmed", FontTextBold));
            table.AddCell(new Phrase("Cancelled", FontTextBold));
            table.AddCell(new Phrase("Completed", FontTextBold));
            table.AddCell(new Phrase("No Show", FontTextBold));
            table.AddCell(new Phrase("Appointments", FontTextBold));
            table.AddCell(new Phrase("Products", FontTextBold));
            table.AddCell(new Phrase("Refunds", FontTextBold));

            int TotalConfirmed = 0;
            int TotalCancelled = 0;
            int TotalCompleted = 0;
            int TotalNoShow = 0;
            decimal TotalAppointments = 0.00m;
            decimal TotalSales = 0.00m;
            decimal TotalRefunds = 0.00m;

            foreach (Therapist therapist in therapists)
            {
                int Confirmed = therapist.TotalAppoinments(From, To, SharedBase.Enums.AppointmentStatus.Confirmed);
                int Cancelled = therapist.TotalAppoinments(From, To, SharedBase.Enums.AppointmentStatus.CancelledByStaff) +
                    therapist.TotalAppoinments(From, To, SharedBase.Enums.AppointmentStatus.CancelledByUser);
                int Completed = therapist.TotalAppoinments(From, To, SharedBase.Enums.AppointmentStatus.Completed);
                int NoShow = therapist.TotalAppoinments(From, To, SharedBase.Enums.AppointmentStatus.NoShow);
                decimal Appointments = therapist.TotalSales(From, To, SharedBase.ProductCostItemType.Treatment);
                decimal Sales = therapist.TotalSales(From, To, SharedBase.ProductCostItemType.Product);
                decimal Refunds = therapist.TotalRefunds(From, To);

                TotalConfirmed += Confirmed;
                TotalCancelled += Cancelled;
                TotalCompleted += Completed;
                TotalNoShow += NoShow;
                TotalAppointments += Appointments;
                TotalSales += Sales;
                TotalRefunds += Refunds;

                table.AddCell(new Phrase(therapist.EmployeeName, FontTextSmall));
                table.AddCell(new Phrase(Confirmed.ToString(), FontTextSmall));
                table.AddCell(new Phrase(Cancelled.ToString(), FontTextSmall));
                table.AddCell(new Phrase(Completed.ToString(), FontTextSmall));
                table.AddCell(new Phrase(NoShow.ToString(), FontTextSmall));
                table.AddCell(new Phrase(SharedUtils.FormatMoney(Appointments,
                    SharedBase.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
                table.AddCell(new Phrase(SharedUtils.FormatMoney(Sales,
                    SharedBase.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
                table.AddCell(new Phrase(SharedUtils.FormatMoney(Refunds,
                    SharedBase.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
            }

            //totals
            table.AddCell(new Phrase("Total", FontTextBold));
            table.AddCell(new Phrase(TotalConfirmed.ToString(), FontTextBold));
            table.AddCell(new Phrase(TotalCancelled.ToString(), FontTextBold));
            table.AddCell(new Phrase(TotalCompleted.ToString(), FontTextBold));
            table.AddCell(new Phrase(TotalNoShow.ToString(), FontTextBold));
            table.AddCell(new Phrase(SharedUtils.FormatMoney(TotalAppointments,
                SharedBase.BOL.Basket.Currencies.Get("GBP")), FontTextBold));
            table.AddCell(new Phrase(SharedUtils.FormatMoney(TotalSales,
                SharedBase.BOL.Basket.Currencies.Get("GBP")), FontTextBold));
            table.AddCell(new Phrase(SharedUtils.FormatMoney(TotalRefunds,
                SharedBase.BOL.Basket.Currencies.Get("GBP")), FontTextBold));
            document.Add(table);
            ParagraphAdd(document);
        }
    }
}
