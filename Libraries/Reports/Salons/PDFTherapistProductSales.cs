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
 *  File: PDFTherapistProductSales.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Text;

using iTextSharp.text;
using iTextSharp.text.pdf;

using SharedBase;
using SharedBase.Utils;
using SharedBase.BOL.Appointments;
using SharedBase.BOL.Users;
using SharedBase.BOL.Therapists;
using SharedBase.BOL.Refunds;
using SharedBase.BOL.Statistics;

namespace Reports.Salons
{
    class PDFTherapistProductSales : BaseReport
    {
        public PDFTherapistProductSales(DateTime From, DateTime To, Therapists therapists, string rootPath)
            : base(UniqueFileName("DailyProductSaleReport", true, rootPath))
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

                LoadDailySales(myDocument, therapists, From, To);

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
                jpg = Image.GetInstance(RootPath.ToLower().Replace("staff\\reports\\creports", "images\\") + "SalonReportHeader.jpg");

            document.Add(jpg);

            document.Add(new Paragraph(Header, FontTextBoldLarge));
            ParagraphAdd(document);
        }

        private void LoadDailySales(Document document, Therapists therapists, DateTime From, DateTime To)
        {
            int pageTotal = 0;
            int page = 1;

            Therapists therapistsSorted = new Therapists();

            for (int i = 0; i < therapists.Count; i++)
            {
                bool add = false;
                Therapist therapist = therapists[i];//.TotalProducts(From, To);
                Takings takings = therapist.TotalProducts(From, To);
                therapist.Tag = takings.Count;

                for (int j = 0; j < therapistsSorted.Count; j++)
                {
                    Therapist therapistSorted = therapistsSorted[j];

                    int sortedCount = (int)therapistSorted.Tag;

                    if (takings.Count >= sortedCount)
                    {
                        add = true;
                        int idx = j > 0 ? j : 0;
                        therapistsSorted.Insert(idx, therapist);
                        break;
                    }
                }

                if (!add)
                    therapistsSorted.Add(therapist);
            }

            foreach (Therapist therapist in therapistsSorted)
            {
                Takings takings = therapist.TotalProducts(From, To);

                if (takings.Count > 0)
                {
                    pageTotal += 8;

                    ParagraphAdd(document);

                    if ((pageTotal + takings.Count) > 52)
                    {
                        page++;
                        pageTotal = 8;
                        document.NewPage();
                    }

                    document.Add(new Paragraph(String.Format("Product Sales - {0}", therapist.EmployeeName), FontTextBoldSmall));
                    ParagraphAdd(document);

                    //create a table
                    PdfPTable table = new PdfPTable(4);
                    table.HorizontalAlignment = 0;
                    table.TotalWidth = 530f;
                    table.LockedWidth = true;
                    float[] widths = new float[] { 350f, 60f, 60f, 60f };
                    table.SetWidths(widths);

                    table.AddCell(new Phrase("Product", FontTextBoldSmall));
                    table.AddCell(new Phrase("Quantity", FontTextBoldSmall));
                    table.AddCell(new Phrase("Unit Price", FontTextBoldSmall));
                    table.AddCell(new Phrase("Total Price", FontTextBoldSmall));

                    decimal totalSales = 0.00m;
                    decimal totalProducts = 0m;
                    decimal totalProductPrice = 0.00m;

                    foreach (TherapistTakings taking in takings)
                    {
                        table.AddCell(new Phrase(taking.Item, FontTextSmall));
                        table.AddCell(new Phrase(taking.ItemCount.ToString(), FontTextSmall));
                        table.AddCell(new Phrase(SharedUtils.FormatMoney(taking.ItemCost,
                            SharedBase.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
                        table.AddCell(new Phrase(SharedUtils.FormatMoney(taking.ItemCost * taking.ItemCount,
                            SharedBase.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));

                        totalSales += Convert.ToDecimal(taking.ItemCost * taking.ItemCount);
                        totalProducts += taking.ItemCount;
                        totalProductPrice += taking.ItemCost * taking.ItemCount;

                        pageTotal += 1;
                    }

                    table.AddCell(new Phrase("Summary", FontTextBoldSmall));
                    table.AddCell(new Phrase(totalProducts.ToString(), FontTextBoldSmall));
                    table.AddCell(new Phrase(String.Empty, FontTextBoldSmall));
                    table.AddCell(new Phrase(SharedUtils.FormatMoney(totalSales,
                        SharedBase.BOL.Basket.Currencies.Get("GBP")), FontTextBoldSmall));

                    document.Add(table);
                }
                else
                {
                    pageTotal += 6;
                    ParagraphAdd(document);
                    document.Add(new Paragraph(String.Format("No product sales found for {0}", therapist.EmployeeName), FontTextSmall));
                }
            }

            ParagraphAdd(document);
        }

   }
}
