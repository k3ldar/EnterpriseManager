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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: PdfStockInReport.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using iTextSharp.text;
using iTextSharp.text.pdf;

using Library.Utils;

namespace Reports.Stock
{
    public class PdfStockInReport : BaseReport
    {
        public PdfStockInReport(string location, Library.BOL.StockControl.StockIn stock, DateTime date, bool fromDate)
            : base(UniqueFileName("StockIn", true))
        {
            CreateDocument(location, stock, date, fromDate);
        }

        private void CreateDocument(string location, Library.BOL.StockControl.StockIn stock, DateTime date, bool fromDate)
        {
            Document myDocument = new Document(PageSize.A4);

            try
            {
                PdfWriter.GetInstance(myDocument, new FileStream(FileName, FileMode.Create));

                myDocument.Open();

                PrintHeader(myDocument, String.Format("Stock In Report - Location: {0}; Date: {1}", location, DateTime.Now.ToShortDateString()));

                LoadStockDetails(myDocument, stock, date, fromDate);
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
            Image jpg = Image.GetInstance(ImagePath + "StockReportHeader.jpg");
            document.Add(jpg);

            document.Add(new Paragraph(Header, FontTextBoldLarge));
            ParagraphAdd(document);
        }

        private void LoadStockDetails(Document document, Library.BOL.StockControl.StockIn stock, DateTime date, bool fromDate)
        {
            if (stock.Count > 0)
            {
                //create a table
                PdfPTable table = new PdfPTable(5);
                table.HorizontalAlignment = 0;
                table.TotalWidth = 530f;
                table.LockedWidth = true;
                float[] widths = new float[] { 130f, 130f, 100f, 40f, 130f };
                table.SetWidths(widths);

                table.AddCell(new Phrase("Name", FontTextBoldSmall));
                table.AddCell(new Phrase("Detail", FontTextBoldSmall));
                table.AddCell(new Phrase("Date", FontTextBoldSmall));
                table.AddCell(new Phrase("Quantity", FontTextBoldSmall));
                table.AddCell(new Phrase("User", FontTextBoldSmall));

                foreach (Library.BOL.StockControl.StockInItem stockItem in stock)
                {
                    if ((fromDate && stockItem.Date.Date >= date.Date) || (stockItem.Date.Date == date.Date) || (date.Year == 1900))
                    {
                        table.AddCell(new Phrase(stockItem.Name, FontTextSmall));
                        table.AddCell(new Phrase(stockItem.Size, FontTextSmall));
                        table.AddCell(new Phrase(stockItem.Date.ToString("g"), FontTextSmall));
                        table.AddCell(new Phrase(stockItem.Quantity.ToString(), FontTextSmall));
                        table.AddCell(new Phrase(stockItem.User, FontTextSmall));
                    }
                }

                document.Add(table);
            }
            else
            {
                document.Add(new Paragraph("No Stock In Items Found", FontTextSmall));
            }

            ParagraphAdd(document);
        }
    }
}
