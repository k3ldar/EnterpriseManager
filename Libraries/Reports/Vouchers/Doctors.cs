using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Heavenskincare.Reports.Vouchers
{
    public class Doctors : BaseReport
    {
        public Doctors(string voucherCode, int id)
            : base(String.Format("T:\\Custom\\doctors\\{0}.pdf", id))
        {
            CreateDocument(voucherCode);
        }

        private void CreateDocument(string voucherCode)
        {
            Document myDocument = new Document(PageSize.A4);
            myDocument.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());

            try
            {
                PdfWriter.GetInstance(myDocument, new FileStream(FileName, FileMode.Create));

                myDocument.Open();

                PrintHeader(myDocument, voucherCode);
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

        private void PrintHeader(Document document, string voucherCode)
        {
            Image jpg = Image.GetInstance("t:\\custom\\Doctors Unique Ticket back.jpg");
            jpg.ScaleToFit(document.PageSize.Width - 20, document.PageSize.Height - 70);

            //If you want to choose image as background then,

            jpg.Alignment = iTextSharp.text.Image.UNDERLYING;

            //If you want to give absolute/specified fix position to image.
            jpg.SetAbsolutePosition(40, 69);

            document.Add(jpg);

            document.Add(new Paragraph("\r\n\r\n", FontText));
            document.Add(new Paragraph("\r\n\r\n", FontText));

            Paragraph p = new Paragraph(voucherCode, FontText);
            p.Alignment = Element.ALIGN_MIDDLE;
            p.SpacingBefore = 220;
            //p.FirstLineIndent = 120;
            p.IndentationLeft = 585;
            p.IndentationRight = 0;
            document.Add(p);


            Font link = FontFactory.GetFont("Arial", 18, Font.BOLD | Font.UNDERLINE, iTextSharp.text.BaseColor.BLUE);
            Anchor anchor = new Anchor("http://america.heavenskincare.com/offers/offerdc.aspx", link);
            anchor.Reference = "http://america.heavenskincare.com/Offers/OfferDC.aspx?code=" + voucherCode;

            p = new Paragraph("\r\n");
            p.Alignment = Element.ALIGN_MIDDLE;
            p.IndentationLeft = 50;
            p.SpacingBefore = 106;
            p.Add(anchor);

            document.Add(p);

        }
    }
}
