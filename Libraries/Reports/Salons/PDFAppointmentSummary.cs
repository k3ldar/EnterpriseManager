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
 *  File: PDFAppointmentSummary.cs
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

using SharedBase.BOL.Appointments;
using SharedBase.BOL.Statistics;

namespace Reports.Salons
{
    class PDFAppointmentSummary : BaseReport
    {
        internal PDFAppointmentSummary(DateTime fromDate, DateTime toDate)
            : base(UniqueFileName("AppointmentSummary.pdf", true))
        {
            CreateDocument(fromDate.Date, toDate.Date);
        }

        private void CreateDocument(DateTime From, DateTime To)
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

                Statistics stats = new Statistics();

                SimpleStatistics apptStats = stats.GetAppointmentTotals(From, To);

                LoadAppointmentStats(myDocument, apptStats);
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
                jpg = Image.GetInstance(ImagePath + "AppointmentSummary.jpg");
            else
                jpg = Image.GetInstance(RootPath.ToLower().Replace("staff\\reports\\creports", "images\\") + "ChangedAppointments.jpg");

            document.Add(jpg);

            document.Add(new Paragraph(Header, FontTextBoldLarge));
            ParagraphAdd(document);
        }

        private void LoadAppointmentStats(Document myDocument, SimpleStatistics statistics)
        {
            //create a table
            PdfPTable table = new PdfPTable(2);
            table.HorizontalAlignment = 0;
            table.TotalWidth = 430f;
            table.LockedWidth = true;
            float[] widths = new float[] { 300f, 130f };
            table.SetWidths(widths);

            table.AddCell(new Phrase("Status", FontTextBoldSmall));
            table.AddCell(new Phrase("Quanity", FontTextBoldSmall));

            foreach (SimpleStatistic stat in statistics)
            {
                table.AddCell(new Phrase(stat.Description, FontTextSmall));
                table.AddCell(new Phrase(stat.Count.ToString(), FontTextSmall));
            }

            myDocument.Add(table);
        }
    }
}
