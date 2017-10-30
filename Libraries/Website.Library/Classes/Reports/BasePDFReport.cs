using System;
using System.Xml;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Website.Library.Classes.Reports
{
    public class BasePDFReport
    {
        private string _FileName;

        public BasePDFReport(string FileName)
        {
            _FileName = FileName;
        }

        #region Pdf / PdfTable / PdfCell Manipulation

        public void RemoveBorder(ref PdfPCell cell)
        {
            cell.BorderColor = BaseColor.WHITE;
            cell.HorizontalAlignment = 0;
        }

        public void ParagraphAdd(Document document)
        {
            document.Add(new Paragraph("\n\n"));
        }

        public PdfPCell NewCell(Phrase phrase, int Colspan, bool Borders, int Align)
        {
            PdfPCell Result = new PdfPCell(phrase);
            Result.Colspan = Colspan;

            if (!Borders)
                RemoveBorder(ref Result);

            Result.HorizontalAlignment = Align;

            return (Result);
        }

        public PdfPCell NewCell(Phrase phrase, int Colspan, bool Borders)
        {
            return (NewCell(phrase, Colspan, Borders, 0)); 
        }


        #endregion Pdf / PdfTable / PdfCell Manipulation

        #region Properties

        #region Fonts

        public iTextSharp.text.Font FontTextSmall
        {
            get
            {
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);

                iTextSharp.text.Font font = new iTextSharp.text.Font(bfTimes, 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                return (font);
            }
        }

        public iTextSharp.text.Font FontHeader
        {
            get
            {
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);

                iTextSharp.text.Font font = new iTextSharp.text.Font(bfTimes, 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                return (font);
            }
        }

        public iTextSharp.text.Font FontText
        {
            get
            {
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);

                iTextSharp.text.Font font = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                return (font);
            }
        }

        public iTextSharp.text.Font FontTextBold
        {
            get
            {
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);

                iTextSharp.text.Font font = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                return (font);
            }
        }

        public iTextSharp.text.Font FontTextBoldSmall
        {
            get
            {
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);

                iTextSharp.text.Font font = new iTextSharp.text.Font(bfTimes, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                return (font);
            }
        }


        public iTextSharp.text.Font FontTextLarge
        {
            get
            {
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);

                iTextSharp.text.Font font = new iTextSharp.text.Font(bfTimes, 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                return (font);
            }
        }

        public iTextSharp.text.Font FontTextBoldLarge
        {
            get
            {
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);

                iTextSharp.text.Font font = new iTextSharp.text.Font(bfTimes, 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                return (font);
            }
        }

        #endregion Fonts

        #region Paths

        public string FileName
        {
            get
            {
                return (_FileName);
            }
        }

        public static string CurrentPath
        {
            get
            {
                string Result = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                Result = Path.GetDirectoryName(Result);
                Result = Result.Substring(6);
                Result = Result.Substring(0, Result.Length - 4);
                return (Result);
            }
        }

        public string ImagePath
        {
            get
            {
                string Result = CurrentPath + @"\Images\";
                return (Result);
            }
        }

        #endregion Paths

        #endregion Properties

        #region Internal Methods

        internal string GetXMLValue(string ParentName, string KeyName)
        {
            string Result = "";


            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(CurrentPath + @"\\HSCConfig.xml");
            XmlNode Root = xmldoc.DocumentElement;

            if (Root != null & Root.Name == "SieraDelta")
            {
                for (int i = 0; i <= Root.ChildNodes.Count - 1; i++)
                {
                    XmlNode Child = Root.ChildNodes[i];

                    if (Child.Name == ParentName)
                    {
                        for (int j = 0; j <= Child.ChildNodes.Count - 1; j++)
                        {
                            XmlNode Item = Child.ChildNodes[j];

                            if (Item.Name == KeyName)
                            {
                                Result = Item.InnerText;
                                return (Result);
                            }
                        }
                    }
                }
            }

            return (Result);
        }

        #endregion Internal Methods

        #region Static Methods

        public static string UniqueFileName(string Prefix, bool UseTimeStamp)
        {
            string Result = "";
            
            if (UseTimeStamp)
                Result = String.Format("{0}\\Staff\\Reports\\cReports\\{2}{1}.pdf", CurrentPath, DateTime.Now.ToString("ddMMyyhhmmss"), Prefix);
            else
                Result = String.Format("{0}\\Staff\\Reports\\cReports\\{1}.pdf", CurrentPath, Prefix);

            return (Result);
        }

        #endregion Static Methods

    }

    public class TwoColumnHeaderFooter : PdfPageEventHelper
    {
        // This is the contentbyte object of the writer
        PdfContentByte cb;

        // we will put the final number of pages in a template
        PdfTemplate template;

        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;

        // This keeps track of the creation time
        DateTime PrintTime = DateTime.Now;

        #region Properties
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _SubTitle;
        public string SubTitle
        {
            get { return (_SubTitle); }
            set { _SubTitle = value; }
        }

        private string _HeaderLeft;
        public string HeaderLeft
        {
            get { return _HeaderLeft; }
            set { _HeaderLeft = value; }
        }

        private string _HeaderRight;
        public string HeaderRight
        {
            get { return _HeaderRight; }
            set { _HeaderRight = value; }
        }

        private Font _HeaderFont;
        public Font HeaderFont
        {
            get { return _HeaderFont; }
            set { _HeaderFont = value; }
        }

        private Font _FooterFont;
        public Font FooterFont
        {
            get { return _FooterFont; }
            set { _FooterFont = value; }
        }
        #endregion

        // we override the onOpenDocument method
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                template = cb.CreateTemplate(50, 50);
            }
            catch
            {

            }
        }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            Rectangle pageSize = document.PageSize;

            if (Title != string.Empty)
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 15);
                cb.SetRGBColorFill(50, 50, 200);
                cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetTop(40));
                cb.ShowText(Title);
                cb.EndText();
            }


            if (SubTitle != String.Empty)
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 12);
                cb.SetRGBColorFill(50, 50, 200);
                cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetTop(50));
                cb.ShowText(SubTitle);
                cb.EndText();
            }


            if (HeaderLeft + HeaderRight != string.Empty)
            {
                PdfPTable HeaderTable = new PdfPTable(2);
                HeaderTable.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                HeaderTable.TotalWidth = pageSize.Width - 80;
                HeaderTable.SetWidthPercentage(new float[] { 45, 45 }, pageSize);

                PdfPCell HeaderLeftCell = new PdfPCell(new Phrase(8, HeaderLeft, HeaderFont));
                HeaderLeftCell.Padding = 5;
                HeaderLeftCell.PaddingBottom = 8;
                HeaderLeftCell.BorderWidthRight = 0;
                HeaderTable.AddCell(HeaderLeftCell);

                PdfPCell HeaderRightCell = new PdfPCell(new Phrase(8, HeaderRight, HeaderFont));
                HeaderRightCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                HeaderRightCell.Padding = 5;
                HeaderRightCell.PaddingBottom = 8;
                HeaderRightCell.BorderWidthLeft = 0;
                HeaderTable.AddCell(HeaderRightCell);

                cb.SetRGBColorFill(0, 0, 0);
                HeaderTable.WriteSelectedRows(0, -1, pageSize.GetLeft(40), pageSize.GetTop(50), cb);
            }
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);

            int pageN = writer.PageNumber;
            String text = "Page " + pageN + " of ";
            float len = bf.GetWidthPoint(text, 8);

            Rectangle pageSize = document.PageSize;

            cb.SetRGBColorFill(100, 100, 100);

            cb.BeginText();
            cb.SetFontAndSize(bf, 8);
            cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetBottom(30));
            cb.ShowText(text);
            cb.EndText();

            cb.AddTemplate(template, pageSize.GetLeft(40) + len, pageSize.GetBottom(30));

            cb.BeginText();
            cb.SetFontAndSize(bf, 8);
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT,
                "Created On " + PrintTime.ToString(),
                pageSize.GetRight(40),
                pageSize.GetBottom(30), 0);
            cb.EndText();
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            template.BeginText();
            template.SetFontAndSize(bf, 8);
            template.SetTextMatrix(0, 0);
            template.ShowText("" + (writer.PageNumber - 1));
            template.EndText();
        }

    }
}
