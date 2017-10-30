using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using iTextSharp.text;
using iTextSharp.text.pdf;

using Library.BOL.Appointments;


namespace Reports.Salons
{
    internal sealed class PDFChangedAppointments : BaseReport
    {
        internal PDFChangedAppointments(DateTime fromDate, DateTime toDate, Appointments changedAppointments)
            : base (UniqueFileName("ChangedAppointments.pdf", true))
        {
            CreateDocument(fromDate.Date, toDate.Date, changedAppointments);
        }

        private void CreateDocument(DateTime From, DateTime To, Appointments changedAppointments)
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

                if (changedAppointments.Count == 0)
                {
                    myDocument.Add(new Paragraph("No Appointment Changes Found", FontTextSmall));
                }
                else
                {
                    myDocument.Add(new Paragraph(String.Format("Total Appointments: {0}", changedAppointments.Count)));
                    ParagraphAdd(myDocument);
                    LoadAppointments(myDocument, changedAppointments);
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

        private void PrintHeader(Document document, string Header)
        {
            Image jpg = null;

            if (String.IsNullOrEmpty(RootPath))
                jpg = Image.GetInstance(ImagePath + "ChangedAppointments.jpg");
            else
                jpg = Image.GetInstance(RootPath.ToLower().Replace("staff\\reports\\creports", "images\\") + "ChangedAppointments.jpg");

            document.Add(jpg);

            document.Add(new Paragraph(Header, FontTextBoldLarge));
            ParagraphAdd(document);
        }

        private void LoadAppointments(Document myDocument, Appointments changedAppointments)
        {
            int newPage = 0;

            foreach (Appointment appt in changedAppointments)
            {
                LoadAppointment(myDocument, appt);
                newPage++;

                if (newPage % 3 == 0)
                    myDocument.NewPage();
                else
                    ParagraphAdd(myDocument);
            }
        }

        private void LoadAppointment(Document document, Appointment appointment)
        {
            string apptHeader = String.Format("Appointment: {0}\r\nTherapist: {1}\r\nCustomer: {2}\r\nDate: {3}\r\nDuration: {5} minutes\r\nStatus: {4}\r\nAppointment ID: {6}", 
                appointment.TreatmentName, appointment.EmployeeName, appointment.UserName, 
                appointment.AppointmentAsDateTime().ToString("g"), Shared.Utilities.SplitCamelCase(appointment.Status.ToString()),
                appointment.Duration, appointment.ID);

            document.Add(new Paragraph(apptHeader, FontTextBoldSmall));
            ParagraphAdd(document);

            //create a table
            PdfPTable table = new PdfPTable(3);
            table.HorizontalAlignment = 0;
            table.TotalWidth = 530f;
            table.LockedWidth = true;
            float[] widths = new float[] { 130f, 130f, 270f };
            table.SetWidths(widths);

            table.AddCell(new Phrase("Date/Time Altered", FontTextBoldSmall));
            table.AddCell(new Phrase("Altered By", FontTextBoldSmall));
            table.AddCell(new Phrase("Change", FontTextBoldSmall));

            foreach (AppointmentChangeItem apptChange in appointment.History())
            {
                string changes = apptChange.FindChanges(appointment);

                if (!String.IsNullOrEmpty(changes))
                {
                    table.AddCell(new Phrase(apptChange.LastAltered.ToString("g"), FontTextSmall));
                    table.AddCell(new Phrase(apptChange.AlteredBy, FontTextSmall));
                    table.AddCell(new Phrase(changes, FontTextSmall));
                }
            }

            document.Add(table);
        }
    }
}
