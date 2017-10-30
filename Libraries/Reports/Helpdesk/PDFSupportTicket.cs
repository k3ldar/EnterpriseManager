using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;

using Library.Utils;
using Library.BOL.Helpdesk;

namespace Reports.Helpdesk
{
    public class PDFSupportTicket : BaseReport
    {
        #region Constructors / Destructors

        public PDFSupportTicket(SupportTicket Ticket)
            : base(UniqueFileName(Ticket.TicketKey, false))
        {
            CreateDocument(Ticket);
        }

        #endregion Constructors / Destructors

        private void CreateDocument(SupportTicket Ticket)
        {
            Document myDocument = new Document(PageSize.A4);

            try
            {
                PdfWriter.GetInstance(myDocument, new FileStream(FileName, FileMode.Create));

                myDocument.Open();

                PrintHeader(myDocument, Ticket);
                PrintTickets(myDocument, Ticket);

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

        private void PrintTickets(Document document, SupportTicket Ticket)
        {
            foreach (SupportTicketMessage Msg in Ticket.Messages)
            {
                Phrase tMsg = new Phrase();

                tMsg.Add(new Chunk(Msg.Username, FontTextBold));
                tMsg.Add(new Chunk(String.Format("  ({0})\n", Msg.CreateDate.ToString("g")), FontTextSmall));
                tMsg.Add(new Chunk(Msg.Content + "\n\n", FontText));

                Paragraph para = new Paragraph();
                para.Add(tMsg);
                document.Add(para);

            }
        }

        private void PrintHeader(Document document, SupportTicket Ticket)
        {
            Phrase Addr = new Phrase();
            Addr.Add(new Chunk(String.Format("Support Ticket: {0}", Ticket.TicketKey), FontTextBoldLarge));

            Addr.Add(new Chunk("\n\nCreated By: ", FontTextBold));
            Addr.Add(new Chunk(Ticket.CreatedBy, FontText));

            Addr.Add(new Chunk("\nCreated By Email: ", FontTextBold));
            Addr.Add(new Chunk(Ticket.CreatedByEmail, FontText));

            Addr.Add(new Chunk("\nDate Created: ", FontTextBold));
            Addr.Add(new Chunk(Ticket.Created.ToString("g"), FontText));

            Addr.Add(new Chunk("\nPriority: ", FontTextBold));
            Addr.Add(new Chunk(Ticket.Priority, FontText));

            Addr.Add(new Chunk("\nDepartment: ", FontTextBold));
            Addr.Add(new Chunk(Ticket.Department + "\n\n", FontText));

            Paragraph para = new Paragraph();
            para.Add(Addr);
            document.Add(para);
        }
}


}
