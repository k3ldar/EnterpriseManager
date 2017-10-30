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


namespace Reports.Stock
{
    public class PdfStockReport : BaseReport
    {
        private DateTime _reportDate;

        public PdfStockReport(string location, Library.BOL.StockControl.Stock stock, 
            int stockOptions, DateTime reportDate, string size = "")
            : base(UniqueFileName("StockControl", true))
        {
            _reportDate = reportDate;
            CreateDocument(location, stock, stockOptions, size);
        }

        private void CreateDocument(string location, Library.BOL.StockControl.Stock stock, 
            int stockOptions, string size)
        {
            Document myDocument = new Document(PageSize.A4);

            try
            {
                PdfWriter.GetInstance(myDocument, new FileStream(FileName, FileMode.Create));

                myDocument.Open();

                PrintHeader(myDocument, String.Format("Stock Report - Location: {0}; Date: {1}", location, _reportDate.ToShortDateString()), size);

                decimal TotalCost = LoadStockDetails(myDocument, stock, stockOptions);

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
            finally
            {
                myDocument.Close();
                myDocument.Dispose();
                myDocument = null;
            }
        }

        private void PrintHeader(Document document, string Header, string size)
        {
            Image jpg = Image.GetInstance(ImagePath + "StockReportHeader.jpg");
            document.Add(jpg);

            document.Add(new Paragraph(Header, FontTextBoldLarge));

            if (!String.IsNullOrEmpty(size))
                document.Add(new Paragraph(String.Format("Size: {0}", size), FontTextBold));

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
            table.AddCell(new Phrase(SharedUtils.FormatMoney(totalCost,
                Library.BOL.Basket.Currencies.Get("GBP")), FontTextBoldSmall));

            document.Add(table);

            ParagraphAdd(document);
        }

        private decimal LoadStockDetails(Document document, Library.BOL.StockControl.Stock stock, int stockOptions)
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
                    if ((stockOptions == 1 && stockItem.Available > 0) || (stockOptions == 0) || 
                        (stockOptions == 2 && (stockItem.Available <= (stockItem.MinLevel + 15))) ||
                        (stockOptions == 5))
                    {

                        Phrase phSize = new Phrase(stockItem.Available < 0 ? "0" : stockItem.Available.ToString(), FontTextSmall);
                        PdfPCell cellSize = new PdfPCell(phSize);

                        if (stockItem.Available <= stockItem.MinLevel)
                        {
                            cellSize.BackgroundColor = BaseColor.RED;
                        }
                        else if (stockItem.Available <= (stockItem.MinLevel + 15))
                        {
                            cellSize.BackgroundColor = BaseColor.ORANGE;
                        }

                        table.AddCell(new Phrase(stockItem.SKU, FontTextSmall));
                        table.AddCell(new Phrase(stockItem.Name, FontTextSmall));
                        table.AddCell(new Phrase(stockItem.Size, FontTextSmall));
                        table.AddCell(cellSize);
                        table.AddCell(new Phrase(stockItem.ProductType.Description, FontTextSmall));

                        table.AddCell(new Phrase(SharedUtils.FormatMoney(stockItem.Cost,
                            Library.BOL.Basket.Currencies.Get("GBP")), FontTextSmall));
                        Result += (stockItem.Cost * (stockItem.Available < 0 ? 0 : stockItem.Available));
                    }
                }

                document.Add(table);
            }
            else
            {
                document.Add(new Paragraph("No Stock Details Found", FontTextSmall));
            }

            ParagraphAdd(document);

            return (Result);
        }
    }
}