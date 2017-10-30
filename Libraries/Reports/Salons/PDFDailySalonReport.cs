using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Text;

using iTextSharp.text;
using iTextSharp.text.pdf;

using Library;
using Library.Utils;
using Library.BOL.Appointments;
using Library.BOL.Users;
using Library.BOL.Therapists;
using Library.BOL.Refunds;
using Library.BOL.Statistics;


namespace Reports.Salons
{
    public class PDFDailySalonReport : BaseReport
    {
        public PDFDailySalonReport(DateTime From, DateTime To, Therapists therapists, string rootPath)
            : base(UniqueFileName("DailySalonReport", true, rootPath))
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

                LoadTakingsBreakdown(myDocument, therapists, From, To);

                LoadAppointments(myDocument, therapists, From, To);

                LoadRefunds(myDocument, From, To);

                LoadInvoiceDetails(myDocument, therapists, From, To);

                LoadInvoiceSummary(myDocument, From, To);

                LoadTreatments(myDocument, therapists, From, To);

                LoadSales(myDocument, therapists, From, To);

                LoadUtilisation(myDocument, therapists, From, To);

                //PrintInvoiceHeader(myDocument, invoice);
                //ParagraphAdd(myDocument);

                //PrintInvoiceAddress(myDocument, invoice);
                //ParagraphAdd(myDocument);

                //PrintInvoiceItems(myDocument, invoice);
                //ParagraphAdd(myDocument);

                //PrintFooter(myDocument);
            }
            finally
            {
                myDocument.Close();
                myDocument.Dispose();
                myDocument = null;
            }
        }

        private void LoadUtilisation(Document document, Therapists therapists, DateTime From, DateTime To)
        {

            if (From.Date == To.Date)
                return;

            double totalHours = 0.00;
            double totalLunch = 0.00;
            double totalTreatments = 0.00;
            double totalOtherHours = 0.00;
            double totalAnnualLeave = 0.00;
            double totalSickLeave = 0.00;
            double totalCleaning = 0.00;
            double totalTraining = 0.00;
            double totalNotWorking = 0.00;
            double totalOffice = 0.00;
            double totalFrontdesk = 0.00;
            int totalDays = 0;
            bool canTreat = true;


            document.SetPageSize(PageSize.A4.Rotate());
            document.NewPage();

            document.Add(new Paragraph("Employee Utilisation\n ", FontTextBoldSmall));

            //create a table
            PdfPTable table = new PdfPTable(14);
            table.HorizontalAlignment = 0;
            table.TotalWidth = 750f;
            table.LockedWidth = true;
            //float[] widths = new float[] { 100f, 60f, 60f, 60f, 60f, 60f, 60f, 60f };
            //table.SetWidths(widths);

            table.AddCell(new Phrase("Employee", FontTextBoldSmall));
            table.AddCell(new Phrase("Days Available", FontTextBoldSmall));
            table.AddCell(new Phrase("Hours Available", FontTextBoldSmall));
            table.AddCell(new Phrase("Front Desk", FontTextBoldSmall));
            table.AddCell(new Phrase("Treatments", FontTextBoldSmall));
            table.AddCell(new Phrase("Lunch", FontTextBoldSmall));
            table.AddCell(new Phrase("Holiday", FontTextBoldSmall));
            table.AddCell(new Phrase("Other", FontTextBoldSmall));
            table.AddCell(new Phrase("Sick", FontTextBoldSmall));
            table.AddCell(new Phrase("Cleaning", FontTextBoldSmall));
            table.AddCell(new Phrase("Training", FontTextBoldSmall));
            table.AddCell(new Phrase("Not Working", FontTextBoldSmall));
            table.AddCell(new Phrase("Office", FontTextBoldSmall));
            table.AddCell(new Phrase("Utilisation", FontTextBoldSmall));

            foreach (Therapist therapist in therapists)
            {
                DateTime currentDate = From;

                double hours = 0.00;
                double lunch = 0.00;
                double treatments = 0.00;
                double otherHours = 0.00;
                double annualLeave = 0.00;
                double sickLeave = 0.00;
                double cleaning = 0.00;
                double training = 0.00;
                double notWorking = 0.00;
                double office = 0.00;
                double frontDesk = 0.00;
                int days = 0;

                do
                {

                    DateTime start;
                    DateTime finish;

                    if (therapist.WorkingOverride(currentDate, out start, out finish, out canTreat))
                    {
                        TimeSpan sp = finish - start;
                        hours += sp.TotalHours;

                        if (sp.TotalHours > 0.00)
                            days += 1;
                    }
                    else
                    {
                        if (therapist.AllowCreateAppointment(currentDate, 0.0, true))
                        {
                            days += 1;
                            hours += therapist.EndTime - therapist.StartTime;
                        }
                    }

                    foreach (Appointment appt in Appointments.Get(currentDate, therapist, false))
                    {
                        switch (appt.AppointmentType)
                        {
                            case 0:
                                treatments += (double)appt.Duration / 60;
                                break;
                            case 1:
                                lunch += (double)appt.Duration / 60;
                                break;
                            case 2:
                                annualLeave += (double)appt.Duration / 60;
                                break;
                            case 3:
                                training += (double)appt.Duration / 60;
                                break;
                            case 4:
                                cleaning += (double)appt.Duration / 60;
                                break;
                            case 5:
                                office += (double)appt.Duration / 60;
                                break;
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                                otherHours += (double)appt.Duration / 60;
                                break;
                            case 6:
                            case 7:
                                hours -= (double)appt.Duration / 60;
                                notWorking += (double)appt.Duration / 60;
                                break;
                            case 8:
                                hours -= (double)appt.Duration / 60;
                                sickLeave += (double)appt.Duration / 60;
                                break;
                            case 13:
                                frontDesk += (double)appt.Duration / 60;
                                break;
                        }
                    }


                    currentDate = currentDate.AddDays(1);

                } while (currentDate.Date <= To.Date);

                totalHours += hours;
                totalLunch += lunch;
                totalTreatments += treatments;
                totalOtherHours += otherHours;
                totalAnnualLeave += annualLeave;
                totalSickLeave += sickLeave;
                totalCleaning += cleaning;
                totalTraining += training;
                totalNotWorking += notWorking;
                totalOffice += office;
                totalFrontdesk += frontDesk;
                totalDays += days;

                double total = treatments + cleaning + training + office + otherHours + frontDesk;
                double utilisation = Math.Round(hours > 0.00 ? (total / (hours - lunch)) * 100 : 0.00, 2);

                table.AddCell(new Phrase(therapist.EmployeeName, FontTextSmall));
                table.AddCell(new Phrase(days.ToString(), FontTextSmall));
                table.AddCell(new Phrase(hours.ToString(), FontTextSmall));
                table.AddCell(new Phrase(frontDesk.ToString(), FontTextSmall));
                table.AddCell(new Phrase(treatments.ToString(), FontTextSmall));
                table.AddCell(new Phrase(lunch.ToString(), FontTextSmall));
                table.AddCell(new Phrase(annualLeave.ToString(), FontTextSmall));
                table.AddCell(new Phrase(otherHours.ToString(), FontTextSmall));
                table.AddCell(new Phrase(sickLeave.ToString(), FontTextSmall));
                table.AddCell(new Phrase(cleaning.ToString(), FontTextSmall));
                table.AddCell(new Phrase(training.ToString(), FontTextSmall));
                table.AddCell(new Phrase(notWorking.ToString(), FontTextSmall));
                table.AddCell(new Phrase(office.ToString(), FontTextSmall));
                table.AddCell(new Phrase(String.Format("{0}%", utilisation), FontTextSmall));
            }

            double totalTime = totalTreatments + totalCleaning + totalTraining + totalOffice + totalOtherHours;
            double totalUtilisation = Math.Round(totalHours > 0.00 ? (totalTime / (totalHours - totalLunch)) * 100 : 0.00, 2);
            table.AddCell(new Phrase("", FontTextSmall));
            table.AddCell(new Phrase(totalDays.ToString(), FontTextBoldSmall));
            table.AddCell(new Phrase(totalHours.ToString(), FontTextBoldSmall));
            table.AddCell(new Phrase(totalFrontdesk.ToString(), FontTextBoldSmall));
            table.AddCell(new Phrase(totalTreatments.ToString(), FontTextBoldSmall));
            table.AddCell(new Phrase(totalLunch.ToString(), FontTextBoldSmall));
            table.AddCell(new Phrase(totalAnnualLeave.ToString(), FontTextBoldSmall));
            table.AddCell(new Phrase(totalOtherHours.ToString(), FontTextBoldSmall));
            table.AddCell(new Phrase(totalSickLeave.ToString(), FontTextBoldSmall));
            table.AddCell(new Phrase(totalCleaning.ToString(), FontTextBoldSmall));
            table.AddCell(new Phrase(totalTraining.ToString(), FontTextBoldSmall));
            table.AddCell(new Phrase(totalNotWorking.ToString(), FontTextBoldSmall));
            table.AddCell(new Phrase(totalOffice.ToString(), FontTextBoldSmall));
            table.AddCell(new Phrase(String.Format("{0}%", totalUtilisation), FontTextBoldSmall));

            document.Add(table);
        }

        private void PrintHeader(Document document, string Header)
        {
            Image jpg = null;

            if (String.IsNullOrEmpty(RootPath))
                jpg = Image.GetInstance(ImagePath + "SalonReportHeader.jpg");
            else
                jpg = Image.GetInstance(RootPath.ToLower().Replace("staff\\reports\\creports", "images\\") + "SalonReportHeader.jpg");

            document.Add(jpg);

            document.Add(new Paragraph(Header, FontTextBoldLarge));
            ParagraphAdd(document);
        }

        private void LoadRefunds(Document document, DateTime From, DateTime To)
        {

            Refunds refunds = Refunds.Get(From, To);

            if (refunds.Count > 0)
            {
                document.NewPage();
                document.Add(new Paragraph("Refunds", FontTextBoldSmall));
                ParagraphAdd(document);

                //create a table
                PdfPTable table = new PdfPTable(6);
                table.HorizontalAlignment = 0;
                table.TotalWidth = 530f;
                table.LockedWidth = true;
                float[] widths = new float[] { 100f, 60f, 60f, 60f, 60f, 190f };
                table.SetWidths(widths);

                table.AddCell(new Phrase("Employee", FontTextBoldSmall));
                table.AddCell(new Phrase("Invoice ID", FontTextBoldSmall));
                table.AddCell(new Phrase("Amount", FontTextBoldSmall));
                table.AddCell(new Phrase("Date", FontTextBoldSmall));
                table.AddCell(new Phrase("Customer", FontTextBoldSmall));
                table.AddCell(new Phrase("Reason", FontTextBoldSmall));

                foreach (Refund refund in refunds)
                {
                    table.AddCell(new Phrase(User.UserGet((int)refund.Employee).UserName, FontTextSmall));
                    table.AddCell(new Phrase(refund.InvoiceID.ToString(), FontTextSmall));
                    table.AddCell(new Phrase(SharedUtils.FormatMoney(refund.Amount,
                        Library.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
                    table.AddCell(new Phrase(refund.Date.ToString("g"), FontTextSmall));
                    table.AddCell(new Phrase(User.UserGet((int)refund.User).UserName, FontTextSmall));
                    table.AddCell(new Phrase(refund.Reason, FontTextSmall));
                }

                document.Add(table);
            }
            else
            {
                document.Add(new Paragraph("No Refunds Found", FontTextSmall));
            }

            ParagraphAdd(document);
        }

        private void LoadTreatments(Document document, Therapists therapists, DateTime From, DateTime To)
        {
            Library.BOL.Statistics.Statistics stats = new Library.BOL.Statistics.Statistics();

            Takings takings = stats.SalonTreatmentSummary(From, To);

            if (takings.Count > 0)
            {
                if (From.Date != To.Date)
                    document.NewPage();

                document.Add(new Paragraph("Treatment Summary\n ", FontTextBoldSmall));

                //create a table
                PdfPTable table = new PdfPTable(2);
                table.HorizontalAlignment = 0;
                table.TotalWidth = 270f;
                table.LockedWidth = true;
                float[] widths = new float[] { 210f, 60f };
                table.SetWidths(widths);

                table.AddCell(new Phrase("Treatment", FontTextBoldSmall));
                table.AddCell(new Phrase("Count", FontTextBoldSmall));

                foreach (TherapistTakings sale in takings)
                {
                    table.AddCell(new Phrase(sale.Item.Replace("()", ""), FontTextSmall));
                    table.AddCell(new Phrase(sale.Count.ToString(), FontTextSmall));
                }

                document.Add(table);
                ParagraphAdd(document);
            }
        }


        private void LoadSales(Document document, Therapists therapists, DateTime From, DateTime To)
        {
            Library.BOL.Statistics.Statistics stats = new Library.BOL.Statistics.Statistics();

            Takings takings = stats.SalonProductSummary(From, To);

            if (takings.Count > 0)
            {
                if (From.Date != To.Date)
                    document.NewPage();

                document.Add(new Paragraph("Product Summary\n ", FontTextBoldSmall));

                //create a table
                PdfPTable table = new PdfPTable(2);
                table.HorizontalAlignment = 0;
                table.TotalWidth = 270f;
                table.LockedWidth = true;
                float[] widths = new float[] { 210f, 60f };
                table.SetWidths(widths);

                table.AddCell(new Phrase("Product", FontTextBoldSmall));
                table.AddCell(new Phrase("Count", FontTextBoldSmall));

                foreach (TherapistTakings sale in takings)
                {
                    table.AddCell(new Phrase(sale.Item.Replace("()", ""), FontTextSmall));
                    table.AddCell(new Phrase(sale.Count.ToString(), FontTextSmall));
                }

                document.Add(table);
                ParagraphAdd(document);
            }
        }

        private void LoadInvoiceSummary(Document document, DateTime From, DateTime To)
        {
            Library.BOL.Statistics.Statistics stats = new Library.BOL.Statistics.Statistics();

            Takings takings = stats.SalonSalesSummary(From, To);

            if (takings.Count > 0)
            {
                if (From.Date != To.Date)
                    document.NewPage();

                document.Add(new Paragraph("Invoice Summary\n ", FontTextBoldSmall));

                //create a table
                PdfPTable table = new PdfPTable(6);
                table.HorizontalAlignment = 0;
                table.TotalWidth = 430f;
                table.LockedWidth = true;
                float[] widths = new float[] { 45f, 50f, 100f, 140f, 45f, 50f };
                table.SetWidths(widths);

                table.AddCell(new Phrase("Invoice", FontTextBoldSmall));
                table.AddCell(new Phrase("Date", FontTextBoldSmall));
                table.AddCell(new Phrase("Staff", FontTextBoldSmall));
                table.AddCell(new Phrase("Customer", FontTextBoldSmall));
                table.AddCell(new Phrase("Total Cost", FontTextBoldSmall));
                table.AddCell(new Phrase("Type", FontTextBoldSmall));

                foreach (TherapistTakings sale in takings)
                {
                    table.AddCell(new Phrase(sale.InvoiceID.ToString(), FontTextSmall));
                    table.AddCell(new Phrase(sale.StartDate.ToShortDateString(), FontTextSmall));
                    table.AddCell(new Phrase(sale.TherapistName, FontTextSmall));
                    table.AddCell(new Phrase(sale.CustomerName, FontTextSmall));
                    table.AddCell(new Phrase(SharedUtils.FormatMoney(sale.InvoiceTotal,
                        Library.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
                    table.AddCell(new Phrase(sale.SaleType, FontTextSmall));
                }

                document.Add(table);
                ParagraphAdd(document);
            }
        }

        private void LoadInvoiceDetails(Document document, Therapists therapists, DateTime From, DateTime To)
        {
            foreach (Therapist therapist in therapists)
            {
                Takings takings = therapist.Sales(From, To);

                if (takings.Count > 0)
                {
                    //document.NewPage();
                    document.Add(new Paragraph(String.Format("{0}\n ", therapist.EmployeeName), FontTextBoldSmall));

                    //create a table
                    PdfPTable table = new PdfPTable(8);
                    table.HorizontalAlignment = 0;
                    table.TotalWidth = 530f;
                    table.LockedWidth = true;
                    float[] widths = new float[] { 45f, 50f, 50f, 60f, 60f, 170f, 45f, 50f };
                    table.SetWidths(widths);

                    table.AddCell(new Phrase("Invoice", FontTextBoldSmall));
                    table.AddCell(new Phrase("Total", FontTextBoldSmall));
                    table.AddCell(new Phrase("Type", FontTextBoldSmall));
                    table.AddCell(new Phrase("Discount", FontTextBoldSmall));
                    table.AddCell(new Phrase("Voucher", FontTextBoldSmall));
                    table.AddCell(new Phrase("Item", FontTextBoldSmall));
                    table.AddCell(new Phrase("Quantity", FontTextBoldSmall));
                    table.AddCell(new Phrase("Cost", FontTextBoldSmall));

                    foreach (TherapistTakings sale in takings)
                    {
                        table.AddCell(new Phrase(sale.InvoiceID.ToString(), FontTextSmall));
                        table.AddCell(new Phrase(SharedUtils.FormatMoney(sale.InvoiceTotal,
                            Library.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
                        table.AddCell(new Phrase(sale.SaleType, FontTextSmall));
                        table.AddCell(new Phrase(SharedUtils.FormatMoney(sale.DiscountTotal,
                            Library.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
                        table.AddCell(new Phrase(SharedUtils.FormatMoney(sale.VoucherTotal,
                            Library.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
                        table.AddCell(new Phrase(sale.Item.Replace("()", ""), FontTextSmall));
                        table.AddCell(new Phrase(sale.ItemCount.ToString(), FontTextSmall));
                        table.AddCell(new Phrase(SharedUtils.FormatMoney(sale.ItemCost,
                            Library.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
                    }

                    document.Add(table);
                    ParagraphAdd(document);
                }
            }
        }

        private void LoadAppointments(Document document, Therapists therapists, DateTime From, DateTime To)
        {
            document.Add(new Paragraph("Activity\n ", FontTextBoldSmall));
            //ParagraphAdd(document);

            //create a table
            PdfPTable table = new PdfPTable(8);
            table.HorizontalAlignment = 0;
            table.TotalWidth = 520f;
            table.LockedWidth = true;
            float[] widths = new float[] { 100f, 60f, 60f, 60f, 60f, 60f, 60f, 60f };
            table.SetWidths(widths);

            table.AddCell(new Phrase("Employee", FontTextBoldSmall));
            table.AddCell(new Phrase("Confirmed", FontTextBoldSmall));
            table.AddCell(new Phrase("Cancelled", FontTextBoldSmall));
            table.AddCell(new Phrase("Completed", FontTextBoldSmall));
            table.AddCell(new Phrase("No Show", FontTextBoldSmall));
            table.AddCell(new Phrase("Arrived", FontTextBoldSmall));
            table.AddCell(new Phrase("Refunds", FontTextBoldSmall));
            table.AddCell(new Phrase("Total Takings", FontTextBoldSmall));

            int TotalConfirmed = 0;
            int TotalCancelled = 0;
            int TotalCompleted = 0;
            int TotalNoShow = 0;
            int TotalArrived = 0;
            decimal TotalRefunds = 0.00m;
            decimal TotalTakings = 0.00m;

            foreach (Therapist therapist in therapists)
            {
                TherapistTakings takings = therapist.TotalDiscounts(From, To);
                int Confirmed = therapist.TotalAppoinments(From, To, Enums.AppointmentStatus.Confirmed);
                int Cancelled = therapist.TotalAppoinments(From, To, Enums.AppointmentStatus.CancelledByStaff) +
                    therapist.TotalAppoinments(From, To, Enums.AppointmentStatus.CancelledByUser);
                int Completed = therapist.TotalAppoinments(From, To, Enums.AppointmentStatus.Completed);
                int NoShow = therapist.TotalAppoinments(From, To, Enums.AppointmentStatus.NoShow);
                int Arrived = therapist.TotalAppoinments(From, To, Enums.AppointmentStatus.Arrived);
                decimal Refunds = therapist.TotalRefunds(From, To);

                TotalTakings += takings.Card + takings.Cash + takings.Cheque;
                TotalConfirmed += Confirmed;
                TotalCancelled += Cancelled;
                TotalCompleted += Completed;
                TotalNoShow += NoShow;
                TotalRefunds += Refunds;
                TotalArrived += Arrived;

                table.AddCell(new Phrase(therapist.EmployeeName, FontTextSmall));
                table.AddCell(new Phrase(Confirmed.ToString(), FontTextSmall));
                table.AddCell(new Phrase(Cancelled.ToString(), FontTextSmall));
                table.AddCell(new Phrase(Completed.ToString(), FontTextSmall));
                table.AddCell(new Phrase(NoShow.ToString(), FontTextSmall));
                table.AddCell(new Phrase(Arrived.ToString(), FontTextSmall));
                table.AddCell(new Phrase(SharedUtils.FormatMoney(Refunds, 
                    Library.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
                table.AddCell(new Phrase(SharedUtils.FormatMoney((takings.Card + takings.Cash + takings.Cheque) 
                    /*- (takings.VoucherTotal + takings.DiscountTotal)*/,
                    Library.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
            }

            //totals
            table.AddCell(new Phrase("Total", FontTextBold));
            table.AddCell(new Phrase(TotalConfirmed.ToString(), FontTextBoldSmall));
            table.AddCell(new Phrase(TotalCancelled.ToString(), FontTextBoldSmall));
            table.AddCell(new Phrase(TotalCompleted.ToString(), FontTextBoldSmall));
            table.AddCell(new Phrase(TotalNoShow.ToString(), FontTextBoldSmall));
            table.AddCell(new Phrase(TotalArrived.ToString(), FontTextBoldSmall));
            table.AddCell(new Phrase(SharedUtils.FormatMoney(TotalRefunds,
                Library.BOL.Basket.Currencies.Get("GBP")), FontTextBoldSmall));
            table.AddCell(new Phrase(SharedUtils.FormatMoney(TotalTakings,
                Library.BOL.Basket.Currencies.Get("GBP")), FontTextBoldSmall));
            document.Add(table);
            ParagraphAdd(document);
        }

        private void LoadTakingsBreakdown(Document document, Therapists therapists, DateTime From, DateTime To)
        {
            document.Add(new Paragraph("Takings - Breakdown\n ", FontTextBoldSmall));
            //ParagraphAdd(document);

            //create a table
            PdfPTable table = new PdfPTable(9);
            table.HorizontalAlignment = 0;
            table.TotalWidth = 530f;
            table.LockedWidth = true;
            float[] widths = new float[] { 120f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 60f };
            table.SetWidths(widths);

            table.AddCell(new Phrase("Employee", FontTextBoldSmall));
            table.AddCell(new Phrase("Invoices", FontTextBoldSmall));
            table.AddCell(new Phrase("Cash", FontTextBoldSmall));
            table.AddCell(new Phrase("Cheque", FontTextBoldSmall));
            table.AddCell(new Phrase("Card", FontTextBoldSmall));
            table.AddCell(new Phrase("Discounts", FontTextBoldSmall));
            table.AddCell(new Phrase("Vouchers", FontTextBoldSmall));
            table.AddCell(new Phrase("Products", FontTextBoldSmall));
            table.AddCell(new Phrase("Treatments", FontTextBoldSmall));

            int TotalInvoices = 0;
            decimal TotalCash = 0.00m;
            decimal TotalCheque = 0.00m;
            decimal TotalCard = 0.00m;
            decimal TotalDiscounts = 0.00m;
            decimal TotalVouchers = 0.00m;
            decimal TotalTreatments = 0.00m;
            decimal TotalProducts = 0.00m;

            foreach (Therapist therapist in therapists)
            {
                TherapistTakings takings = therapist.TotalDiscounts(From, To);

                TotalCash += takings.Cash;
                TotalCard += takings.Card;
                TotalCheque += takings.Cheque;
                TotalDiscounts += takings.DiscountTotal;
                TotalVouchers += takings.VoucherTotal;
                TotalTreatments += takings.Treatments;
                TotalProducts += takings.Products;
                TotalInvoices += takings.InvoiceCount;

                table.AddCell(new Phrase(therapist.EmployeeName, FontTextSmall));
                table.AddCell(new Phrase(takings.InvoiceCount.ToString(), FontTextSmall));
                table.AddCell(new Phrase(SharedUtils.FormatMoney(takings.Cash,
                    Library.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
                table.AddCell(new Phrase(SharedUtils.FormatMoney(takings.Cheque,
                    Library.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
                table.AddCell(new Phrase(SharedUtils.FormatMoney(takings.Card,
                    Library.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
                table.AddCell(new Phrase(SharedUtils.FormatMoney(takings.DiscountTotal,
                    Library.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
                table.AddCell(new Phrase(SharedUtils.FormatMoney(takings.VoucherTotal,
                    Library.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
                table.AddCell(new Phrase(SharedUtils.FormatMoney(takings.Products,
                    Library.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
                table.AddCell(new Phrase(SharedUtils.FormatMoney(takings.Treatments,
                    Library.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
            }

            //totals
            table.AddCell(new Phrase("Total", FontTextBoldSmall));
            table.AddCell(new Phrase(TotalInvoices.ToString(), FontTextBoldSmall));
            table.AddCell(new Phrase(SharedUtils.FormatMoney(TotalCash,
                Library.BOL.Basket.Currencies.Get("GBP")), FontTextBoldSmall));
            table.AddCell(new Phrase(SharedUtils.FormatMoney(TotalCheque,
                Library.BOL.Basket.Currencies.Get("GBP")), FontTextBoldSmall));
            table.AddCell(new Phrase(SharedUtils.FormatMoney(TotalCard,
                Library.BOL.Basket.Currencies.Get("GBP")), FontTextBoldSmall));
            table.AddCell(new Phrase(SharedUtils.FormatMoney(TotalDiscounts,
                Library.BOL.Basket.Currencies.Get("GBP")), FontTextBoldSmall));
            table.AddCell(new Phrase(SharedUtils.FormatMoney(TotalVouchers,
                Library.BOL.Basket.Currencies.Get("GBP")), FontTextBoldSmall));
            table.AddCell(new Phrase(SharedUtils.FormatMoney(TotalProducts,
                Library.BOL.Basket.Currencies.Get("GBP")), FontTextBoldSmall));
            table.AddCell(new Phrase(SharedUtils.FormatMoney(TotalTreatments,
                Library.BOL.Basket.Currencies.Get("GBP")), FontTextBoldSmall));

            document.Add(table);
            ParagraphAdd(document);

            table = new PdfPTable(2);
            table.HorizontalAlignment = 0;
            table.TotalWidth = 230f;
            table.LockedWidth = true;
            widths = new float[] { 130f, 100f };
            table.SetWidths(widths);

            table.AddCell(new Phrase("Total Invoices", FontTextBoldSmall));
            table.AddCell(new Phrase(TotalInvoices.ToString(), FontTextBoldSmall));

            table.AddCell(new Phrase("Total Cash", FontTextBoldSmall));
            table.AddCell(new Phrase(SharedUtils.FormatMoney(TotalCash,
                Library.BOL.Basket.Currencies.Get("GBP")), FontTextBoldSmall));

            table.AddCell(new Phrase("Total Card", FontTextBoldSmall));
            table.AddCell(new Phrase(SharedUtils.FormatMoney(TotalCard,
                Library.BOL.Basket.Currencies.Get("GBP")), FontTextBoldSmall));

            table.AddCell(new Phrase("Total Cheque", FontTextBoldSmall));
            table.AddCell(new Phrase(SharedUtils.FormatMoney(TotalCheque,
                Library.BOL.Basket.Currencies.Get("GBP")), FontTextBoldSmall));

            table.AddCell(new Phrase("Total Discounts", FontTextBoldSmall));
            table.AddCell(new Phrase(SharedUtils.FormatMoney(TotalDiscounts,
                Library.BOL.Basket.Currencies.Get("GBP")), FontTextBoldSmall));

            table.AddCell(new Phrase("Total Vouchers", FontTextBoldSmall));
            table.AddCell(new Phrase(SharedUtils.FormatMoney(TotalVouchers,
                Library.BOL.Basket.Currencies.Get("GBP")), FontTextBoldSmall));

            table.AddCell(new Phrase("Total Takings", FontTextBoldSmall));
            table.AddCell(new Phrase(SharedUtils.FormatMoney((TotalCard + TotalCash + TotalCheque),
                Library.BOL.Basket.Currencies.Get("GBP")), FontTextBoldSmall));

            document.Add(table);
        }
    }
}