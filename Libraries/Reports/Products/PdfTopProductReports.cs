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
using Library.BOL.Statistics;

namespace Reports.Products
{
    public class PdfTopProductReports : BaseReport
    {
        public PdfTopProductReports(Library.ProductReportType reportType,
            SimpleStatistics results)
            : base(UniqueFileName("TopProducts", true))
        {
            CreateDocument(results, reportType);
        }

        private void CreateDocument(SimpleStatistics results, Library.ProductReportType reportType)
        {
            Document myDocument = new Document(PageSize.A4);

            try
            {
                PdfWriter.GetInstance(myDocument, new FileStream(FileName, FileMode.Create));

                myDocument.Open();

                PrintHeader(myDocument, String.Format("{0} - ; Date: {1}", 
                    TranslatedEnums.TranslateProductReportType(reportType), DateTime.Now.ToShortDateString()));

                LoadProductDetails(myDocument, results);
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
            Image jpg = Image.GetInstance(ImagePath + "StockReportHeader.jpg");
            document.Add(jpg);

            document.Add(new Paragraph(header, FontTextBoldLarge));

            ParagraphAdd(document);
        }

        private void LoadProductDetails(Document document, SimpleStatistics results)
        {
            if (results.Count > 0)
            {
                //create a table
                PdfPTable table = new PdfPTable(4);
                table.HorizontalAlignment = 0;
                table.TotalWidth = 520f;
                table.LockedWidth = true;

                float[] widths = new float[] { 80f, 180f, 180f, 80f };
                table.SetWidths(widths);


                table.AddCell(new Phrase("SKU", FontTextBoldSmall));
                table.AddCell(new Phrase("Product", FontTextBoldSmall));
                table.AddCell(new Phrase("Size", FontTextBoldSmall));
                table.AddCell(new Phrase("Quantity", FontTextBoldSmall));

                foreach (SimpleStatistic stat in results)
                {
                    table.AddCell(new Phrase(stat.Name1, FontTextSmall));
                    table.AddCell(new Phrase(stat.Name2, FontTextSmall));
                    table.AddCell(new Phrase(stat.Name3, FontTextSmall));
                    table.AddCell(new Phrase(stat.Count.ToString(), FontTextSmall));
                }

                document.Add(table);
            }
            else
            {
                document.Add(new Paragraph("No Product Details Found", FontTextSmall));
            }

            ParagraphAdd(document);
        }
    }
}
