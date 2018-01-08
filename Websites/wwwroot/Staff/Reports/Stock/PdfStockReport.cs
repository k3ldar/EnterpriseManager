using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Text;

using iTextSharp.text;
using iTextSharp.text.pdf;

using Library;
using Library.Utils;
using Library.BOL.Products;
using Library.BOL.StockControl;

using Website.Library.Classes.Reports;

namespace SieraDelta.Website.Staff.Reports.Stock
{
    public class PdfStockReport : BasePDFReport
    {
        public PdfStockReport(string location, Library.BOL.StockControl.Stock stock)
            : base(UniqueFileName("StockControl", true))
        {
            CreateDocument(location, stock);
        }

        private void CreateDocument(string location, Library.BOL.StockControl.Stock stock)
        {
            Document myDocument = new Document(PageSize.A4);

            try
            {
                PdfWriter.GetInstance(myDocument, new FileStream(FileName, FileMode.Create));

                myDocument.Open();

                PrintHeader(myDocument, String.Format("Stock Report - Location: {0}; Date: {1}", location, DateTime.Now.ToShortDateString()));

                decimal TotalCost = LoadStockDetails(myDocument, stock);

                PrintFooter(myDocument, TotalCost);
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

        private void PrintHeader(Document document, string Header)
        {
            Image jpg = Image.GetInstance(ImagePath + "StockReportHeader.jpg");
            document.Add(jpg);

            document.Add(new Paragraph(Header, FontTextBoldLarge));
            ParagraphAdd(document);
        }

        private void PrintFooter(Document document, decimal totalCost)
        {
            document.Add(new Paragraph("Summary", FontTextBoldSmall));
            ParagraphAdd(document);

            //create a table
            PdfPTable table = new PdfPTable(2);
            table.HorizontalAlignment = 0;
            table.TotalWidth = 230f;
            table.LockedWidth = true;
            float[] widths = new float[] { 100f, 130f };
            table.SetWidths(widths);

            table.AddCell(new Phrase("Retail Price", FontTextBoldSmall));
            table.AddCell(new Phrase(SharedUtils.FormatMoney(totalCost, Library.BOL.Basket.Currencies.Get("en-GB")), FontTextBoldSmall));

            document.Add(table);

            ParagraphAdd(document);
        }

        private decimal LoadStockDetails(Document document, Library.BOL.StockControl.Stock stock)
        {
            decimal Result = 0.00m;

            if (stock.Count > 0)
            {
                //create a table
                PdfPTable table = new PdfPTable(6);
                table.HorizontalAlignment = 0;
                table.TotalWidth = 530f;
                table.LockedWidth = true;
                float[] widths = new float[] { 30f, 180f, 180f, 40f, 55f, 45f };
                table.SetWidths(widths);

                table.AddCell(new Phrase("SKU", FontTextBoldSmall));
                table.AddCell(new Phrase("Product", FontTextBoldSmall));
                table.AddCell(new Phrase("Size", FontTextBoldSmall));
                table.AddCell(new Phrase("Quantity", FontTextBoldSmall));
                table.AddCell(new Phrase("Type", FontTextBoldSmall));
                table.AddCell(new Phrase("Price", FontTextBoldSmall));

                foreach (Library.BOL.StockControl.StockItem stockItem in stock)
                {
                    table.AddCell(new Phrase(stockItem.SKU, FontTextSmall));
                    table.AddCell(new Phrase(stockItem.Name, FontTextSmall));
                    table.AddCell(new Phrase(stockItem.Size, FontTextSmall));
                    table.AddCell(new Phrase(stockItem.Available < 0 ? "0" : stockItem.Available.ToString(), FontTextSmall));
                    table.AddCell(new Phrase(stockItem.ProductType.Description, FontTextSmall));

                    table.AddCell(new Phrase(SharedUtils.FormatMoney(stockItem.Cost, Library.BOL.Basket.Currencies.Get("en-GB")), FontTextSmall));
                    Result += (stockItem.Cost * stockItem.Available);
                }

                document.Add(table);
            }
            else
            {
                document.Add(new Paragraph("No Refunds Found", FontTextSmall));
            }

            ParagraphAdd(document);

            return (Result);
        }
    }
}