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
 *  File: BaseReport.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Xml;

using Languages;
using Library.BOL.Invoices;
using Library.BOL.Orders;

using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Reports
{
    public class BaseReport
    {
        private string _fileName;
        private string _rootPath;
        private string _rootFontUnicode;

        public BaseReport(string FileName)
        {
            _fileName = FileName;
            
            //Full path to the Unicode Arial file
            _rootFontUnicode = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");

            if (!File.Exists(_rootFontUnicode))
                _rootFontUnicode = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
        }

        #region Printing

        public void View()
        {
            Process proc = new Process();
            try
            {
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.Verb = "open";
                proc.StartInfo.CreateNoWindow = true;

                proc.StartInfo.FileName = GetXMLValue("Application", "Adobe");
                proc.StartInfo.Arguments = String.Format("\"{0}\"", @_fileName);
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.CreateNoWindow = true;

                try
                {
                    proc.Start();
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                }
                catch (Exception err)
                {
                    if (err.Message.Contains("system cannot find the file specified"))
                    {
                        System.Windows.Forms.MessageBox.Show("Adobe has not been correctly configured", "View/Print Report");
                    }
                    else
                        throw;
                }
            }
            finally
            {
                proc.Close();
                proc.Dispose();
                proc = null;
            }
        }

        public void Print()
        {
            Thread NewPrintThread = new Thread(new ThreadStart(DoPrint));
            NewPrintThread.Priority = ThreadPriority.BelowNormal; // Set priority to low
            NewPrintThread.IsBackground = true; // Set it to a background thread
            NewPrintThread.Name = "Replication Thread"; // Name the thread
            NewPrintThread.Start();
        }

        private void DoPrint()
        {
            Process proc = new Process();
            try
            {
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.Verb = "print";
                proc.StartInfo.CreateNoWindow = true;

                proc.StartInfo.FileName = GetXMLValue("Application", "Adobe");
                proc.StartInfo.Arguments = " /p \"" + @_fileName + "\"";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.CreateNoWindow = true;

                try
                {
                    proc.Start();
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                }
                catch (Exception err)
                {
                    if (err.Message.Contains("system cannot find the file specified"))
                    {
                        System.Windows.Forms.MessageBox.Show("Adobe has not been correctly configured", "View/Print Report");
                    }
                    else
                        throw;
                }
            }
            finally
            {
                proc.Close();
                proc.Dispose();
                proc = null;
            }
        }

        #endregion Printing

        #region Pdf / PdfTable / PdfCell Manipulation

        internal void BorderRemoveTopLeft(ref PdfPCell cell)
        {
            cell.BorderColorTop = BaseColor.WHITE;
            cell.BorderColorLeft = BaseColor.WHITE;
        }

        internal void BorderRemoveBottomLeft(ref PdfPCell cell)
        {
            cell.BorderColorBottom = BaseColor.WHITE;
            cell.BorderColorLeft = BaseColor.WHITE;
        }

        internal void BorderRemoveTopRight(ref PdfPCell cell)
        {
            cell.BorderColorTop = BaseColor.WHITE;
            cell.BorderColorRight = BaseColor.WHITE;
        }

        internal void BorderRemoveBottomRight(ref PdfPCell cell)
        {
            cell.BorderColorBottom = BaseColor.WHITE;
            cell.BorderColorRight = BaseColor.WHITE;
        }

        internal void BorderRemove(ref PdfPCell cell)
        {
            cell.BorderColor = BaseColor.WHITE;
            cell.HorizontalAlignment = 0;
        }

        internal void BorderRoundEdge(ref PdfPCell cell)
        {
            cell.Border = PdfPCell.NO_BORDER;
            cell.CellEvent = new RoundedBorder();
        }

        internal PdfPTable TableAdd(Document document, PdfPTable subTable, float paddingTopBottom = 2.5f, 
            float paddingLeftRight = 2.5f, bool absolutePosition = false, float topPosition = 0,
            float leftPosition = 0, float width = 200f, PdfWriter pdfWriter = null)
        {
            PdfPTable Result = new PdfPTable(1);
            Result.HorizontalAlignment = subTable.HorizontalAlignment;
            Result.WidthPercentage = subTable.WidthPercentage;
            Result.SpacingBefore = subTable.SpacingBefore;
            Result.SpacingAfter = subTable.SpacingAfter;
            
            subTable.WidthPercentage = 100f;
            subTable.SpacingAfter = 3f;
            subTable.SpacingBefore = 3f;

            PdfPCell cell = new PdfPCell();
            cell.PaddingBottom = paddingTopBottom;
            cell.PaddingTop = paddingTopBottom;
            cell.PaddingRight = paddingLeftRight;
            cell.PaddingLeft = paddingLeftRight;

            BorderRoundEdge(ref cell);
            cell.AddElement(subTable);
            Result.AddCell(cell);

            if (absolutePosition && topPosition > 0 && leftPosition > 0 && pdfWriter != null)
            {
                Result.LockedWidth = true;
                Result.TotalWidth = width;
                Result.WriteSelectedRows(0, -1, leftPosition, topPosition, pdfWriter.DirectContent);
            }
            else
            {
                if (document != null)
                    document.Add(Result);
            }

            return (Result);
        }

        internal void ParagraphAdd(Document document)
        {
            document.Add(new Paragraph("\n"));
        }

        internal PdfPCell NewCell(Phrase phrase, int Colspan, int Align, Borders borders, float padding,
            float borderPadding, IPdfPCellEvent cellEvent = null)
        {
            PdfPCell Result = new PdfPCell(phrase);
            Result.CellEvent = cellEvent;
            Result.Colspan = Colspan;

            Result.BorderColor = BaseColor.WHITE;
            Result.PaddingBottom = padding + 1;
            Result.PaddingLeft = padding;
            Result.PaddingRight = padding;
            Result.PaddingTop = padding;

            if (borders.HasFlag(Reports.Borders.Bottom))
            {
                Result.BorderColorBottom = BaseColor.BLACK;
                Result.BorderWidthBottom = 0.5f;
                //Result.PaddingBottom = borderPadding;
            }
            else
                Result.BorderWidthBottom = 0.0f;

            if (borders.HasFlag(Reports.Borders.Left))
            {
                Result.BorderColorLeft = BaseColor.BLACK;
                Result.BorderWidthLeft = 0.5f;
                //Result.PaddingLeft = borderPadding;
            }
            else
                Result.BorderWidthLeft = 0.0f;

            if (borders.HasFlag(Reports.Borders.Right))
            {
                Result.BorderColorRight = BaseColor.BLACK;
                Result.BorderWidthRight = 0.5f;
                //Result.PaddingRight = borderPadding;
            }
            else
                Result.BorderWidthRight = 0.0f;

            if (borders.HasFlag(Reports.Borders.Top))
            {
                Result.BorderColorTop = BaseColor.BLACK;
                Result.BorderWidthTop = 0.5f;
                //Result.PaddingTop = borderPadding;
            }
            else
                Result.BorderWidthTop = 0.0f;

            
            Result.HorizontalAlignment = Align;

            return (Result);
        }

        internal PdfPCell NewCell(Phrase phrase, int Colspan, bool Borders, int Align)
        {
            PdfPCell Result = new PdfPCell(phrase);
            Result.Colspan = Colspan;

            Result.HorizontalAlignment = Align;
            Borders borders = Reports.Borders.None;

            if (Borders)
            {
                borders = Reports.Borders.Top | Reports.Borders.Bottom | Reports.Borders.Left | Reports.Borders.Right;
                borders &= ~Reports.Borders.None;
            }

            return (NewCell(phrase, Colspan, Align, borders, 2, 2));
        }

        internal PdfPCell NewCell(Phrase phrase, int Colspan, bool Borders)
        {
            return (NewCell(phrase, Colspan, Borders, 0));
        }


        #endregion Pdf / PdfTable / PdfCell Manipulation

        #region Properties

        #region Fonts

        internal iTextSharp.text.Font FontVerdana
        {
            get
            {
                return (FontFactory.GetFont("Verdana", 11, Font.NORMAL, iTextSharp.text.BaseColor.BLACK));
            }
        }

        internal iTextSharp.text.Font FontTextSmall
        {
            get
            {
                BaseFont bfTimes = BaseFont.CreateFont(_rootFontUnicode, BaseFont.IDENTITY_H, false);

                return (new iTextSharp.text.Font(bfTimes, 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK));
            }
        }

        internal iTextSharp.text.Font FontHeader
        {
            get
            {
                BaseFont bfTimes = BaseFont.CreateFont(_rootFontUnicode, BaseFont.IDENTITY_H, false);

                return (new iTextSharp.text.Font(bfTimes, 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK));
            }
        }

        internal iTextSharp.text.Font FontText
        {
            get
            {
                BaseFont bfTimes = BaseFont.CreateFont(_rootFontUnicode, BaseFont.IDENTITY_H, false);

                return (new iTextSharp.text.Font(bfTimes, 12, Font.NORMAL, iTextSharp.text.BaseColor.BLACK));
            }
        }

        internal iTextSharp.text.Font FontTextGrey
        {
            get
            {
                BaseFont bfTimes = BaseFont.CreateFont(_rootFontUnicode, BaseFont.IDENTITY_H, false);

                return (new iTextSharp.text.Font(bfTimes, 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.DARK_GRAY));
            }
        }

        internal iTextSharp.text.Font FontTextBold
        {
            get
            {
                BaseFont bfTimes = BaseFont.CreateFont(_rootFontUnicode, BaseFont.IDENTITY_H, false);

                return (new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.BOLD, 
                    iTextSharp.text.BaseColor.BLACK));
            }
        }

        internal iTextSharp.text.Font FontTextLarge
        {
            get
            {
                BaseFont bfTimes = BaseFont.CreateFont(_rootFontUnicode, BaseFont.IDENTITY_H, false);

                return (new iTextSharp.text.Font(bfTimes, 14, iTextSharp.text.Font.NORMAL, 
                    iTextSharp.text.BaseColor.BLACK));
            }
        }

        internal iTextSharp.text.Font FontTextBoldLarge
        {
            get
            {
                BaseFont bfTimes = BaseFont.CreateFont(_rootFontUnicode, BaseFont.IDENTITY_H, false);

                return (new iTextSharp.text.Font(bfTimes, 14, iTextSharp.text.Font.BOLD, 
                    iTextSharp.text.BaseColor.BLACK));
            }
        }


        public iTextSharp.text.Font FontTextBoldSmall
        {
            get
            {
                BaseFont bfTimes = BaseFont.CreateFont(_rootFontUnicode, BaseFont.IDENTITY_H, false);

                return (new iTextSharp.text.Font(bfTimes, 10, iTextSharp.text.Font.BOLD, 
                    iTextSharp.text.BaseColor.BLACK));
            }
        }


        #endregion Fonts

        #region Paths

        public string RootPath
        {
            get
            {
                return (_rootPath);
            }

            set
            {
                _rootPath = value;
            }
        }

        public string FileName
        {
            get
            {
                return (_fileName);
            }
        }

        public static string CurrentPath
        {
            get
            {
                string Result = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                Result = Path.GetDirectoryName(Result);
                return (Result.Substring(6));
            }
        }

        internal string ImagePath
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

        internal iTextSharp.text.Font FontTextVariable(float size, bool isBold = false)
        {
            BaseFont bfTimes = BaseFont.CreateFont(_rootFontUnicode, BaseFont.IDENTITY_H, false);

            int fontType = iTextSharp.text.Font.NORMAL;

            if (isBold)
                fontType = iTextSharp.text.Font.BOLD;

            iTextSharp.text.Font font = new iTextSharp.text.Font(bfTimes, size, fontType, iTextSharp.text.BaseColor.BLACK);
            return (font);
        }

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

        public static string UniqueFileName(string Prefix, bool UseTimeStamp, string rootPath = "")
        {
            string Result = "";

            if (String.IsNullOrEmpty(rootPath))
            {
                if (UseTimeStamp)
                    Result = String.Format("{0}\\Invoices\\{2}{1}.pdf", CurrentPath, DateTime.Now.ToString("ddMMyyhhmmss"), Prefix);
                else
                    Result = String.Format("{0}\\Invoices\\{1}.pdf", CurrentPath, Prefix);
            }
            else
            {
                
                if (UseTimeStamp)
                    Result = String.Format("{0}\\{2}{1}.pdf", rootPath, DateTime.Now.ToString("ddMMyyhhmmss"), Prefix);
                else
                    Result = String.Format("{0}\\{1}.pdf", rootPath, Prefix);
            }
            return (Result);
        }

        #endregion Static Methods
    }

    [Flags]
    public enum Borders
    {
        None = 1,

        Top = 2,

        Bottom = 4,

        Left = 8,

        Right = 16
    }

    public class ExtendedBorderFix : IPdfPCellEvent
    {
        private int _offsetVertical = 6;
        private int _offsetHorizontal = 6;

        public ExtendedBorderFix(int offsetVertical, int offsetHorizontal)
        {
            _offsetHorizontal = offsetHorizontal;
            _offsetVertical = offsetVertical;
        }

        public void CellLayout(PdfPCell cell, Rectangle rect, PdfContentByte[] canvas)
        {
            PdfContentByte lineCanvas = canvas[PdfPTable.LINECANVAS];

            if (cell.BorderWidthTop > 0.0f)
            {
                lineCanvas.MoveTo(rect.Left, rect.Top);
                lineCanvas.LineTo(rect.Right, rect.Top);
            }

            if (cell.BorderWidthRight > 0.0f)
            {
                lineCanvas.MoveTo(rect.Right, rect.Top - _offsetVertical);
                lineCanvas.LineTo(rect.Right, rect.Bottom + _offsetVertical);
            }

            if (cell.BorderWidthLeft > 0.0f)
            {
                lineCanvas.MoveTo(rect.Left, rect.Top - _offsetVertical);
                lineCanvas.LineTo(rect.Left, rect.Bottom + _offsetVertical);
            }

            if (cell.BorderWidthBottom > 0.0f)
            {
                lineCanvas.MoveTo(rect.Left, rect.Bottom);
                lineCanvas.LineTo(rect.Right, rect.Bottom);
            }

            lineCanvas.Stroke();
        }
    }

    public class RoundedBorder : IPdfPCellEvent
    {
        public void CellLayout(PdfPCell cell, Rectangle rect, PdfContentByte[] canvas)
        {
            PdfContentByte cb = canvas[PdfPTable.BACKGROUNDCANVAS];
            cb.RoundRectangle(
              rect.Left + 1.8f,
              rect.Bottom + 1.8f,
              rect.Width - 3.6f,
              rect.Height - 3.6f, 4
            );
            cb.Stroke();
        }
    }


    public class InvoiceHeaderFooter : PdfPageEventHelper
    {
        private BaseReport _baseReport;
        private Invoice _invoice;
        private string _vatRegNumber;
        private bool _showPageNumberOf;
        private string _footer;

        private BaseFont _baseFont;
        private PdfContentByte cb;
        private PdfTemplate footerTemplate;

        public InvoiceHeaderFooter(BaseReport baseReport, Invoice invoice, string vatRegNumber, 
            bool showPageNumbersOf, string footer)
        {
            _baseReport = baseReport;
            _invoice = invoice;
            _vatRegNumber = vatRegNumber;
            _showPageNumberOf = showPageNumbersOf;
            _footer = footer;
        }

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                //Full path to the Unicode Arial file
                string rootFontUnicode = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), 
                    "ARIALUNI.TTF");

                if (!File.Exists(rootFontUnicode))
                    rootFontUnicode = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), 
                        "ARIAL.TTF");

                _baseFont = BaseFont.CreateFont(rootFontUnicode, BaseFont.IDENTITY_H, false); 
                cb = writer.DirectContent;
                footerTemplate = cb.CreateTemplate(50, 50);
            }
            catch (DocumentException)
            {

            }
            catch (IOException)
            {

            }
        }

        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            base.OnEndPage(writer, document);
            iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 
                10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

            iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 
                10f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

            string pageOf = String.Format(LanguageStrings.PageOf, writer.PageNumber, String.Empty);

            //Add page to footer
            {
                cb.BeginText();
                cb.SetFontAndSize(_baseFont, 10);

                if (!String.IsNullOrEmpty(_vatRegNumber))
                {
                    cb.SetTextMatrix(document.LeftMargin + 4, document.PageSize.GetBottom(30));
                    cb.ShowText(String.Format(LanguageStrings.VatRegNumber, _vatRegNumber));
                }

                if (!String.IsNullOrEmpty(_footer))
                {
                    float middleStart = (((document.Right) - document.Left) / 2) - 
                        ((_baseFont.GetWidthPoint(_footer, 10) / 2) - document.RightMargin);
                    cb.SetTextMatrix(middleStart, document.PageSize.GetBottom(30));
                    cb.ShowText(_footer);
                }

                if (_invoice != null)
                {
                    float pageNumWidth = _baseFont.GetWidthPoint(pageOf, 10);
                    cb.SetTextMatrix(document.PageSize.GetRight(pageNumWidth + 60), document.PageSize.GetBottom(30));
                    cb.ShowText(pageOf);
                    float len = _baseFont.GetWidthPoint(pageOf, 10);
                    cb.AddTemplate(footerTemplate, document.PageSize.GetRight(pageNumWidth + 60) + pageNumWidth, 
                        document.PageSize.GetBottom(30));
                }
                    
                cb.EndText();
            }

            //Move the pointer and draw line to separate footer section from rest of page
            cb.MoveTo(40, document.PageSize.GetBottom(50));
            cb.LineTo(document.PageSize.Width - 40, document.PageSize.GetBottom(50));
            cb.Stroke();
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(_baseFont, 10);
            footerTemplate.SetTextMatrix(0, 0);
            footerTemplate.ShowText((writer.PageNumber - 1).ToString());
            footerTemplate.EndText();
        }
    }

    public class OrderHeaderFooter : PdfPageEventHelper
    {
        private BaseReport _baseReport;
        private Order _order;
        private string _vatRegNumber;
        private bool _showPageNumberOf;
        private string _footer;

        private BaseFont _baseFont;
        private PdfContentByte cb;
        private PdfTemplate footerTemplate;


        public OrderHeaderFooter(BaseReport baseReport, Order order, string vatRegNumber,
            bool showPageNumbersOf, string footer)
        {
            _baseReport = baseReport;
            _order = order;
            _vatRegNumber = vatRegNumber;
            _showPageNumberOf = showPageNumbersOf;
            _footer = footer;
        }

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                //Full path to the Unicode Arial file
                string rootFontUnicode = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts),
                    "ARIALUNI.TTF");

                if (!File.Exists(rootFontUnicode))
                    rootFontUnicode = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts),
                        "ARIAL.TTF");

                _baseFont = BaseFont.CreateFont(rootFontUnicode, BaseFont.IDENTITY_H, false);
                cb = writer.DirectContent;
                footerTemplate = cb.CreateTemplate(50, 50);
            }
            catch (DocumentException)
            {

            }
            catch (IOException)
            {

            }
        }

        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            base.OnEndPage(writer, document);
            iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA,
                10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

            iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA,
                10f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

            string pageOf = String.Format(LanguageStrings.PageOf, writer.PageNumber, String.Empty);

            //Add page to footer
            {
                cb.BeginText();
                cb.SetFontAndSize(_baseFont, 10);

                if (!String.IsNullOrEmpty(_vatRegNumber))
                {
                    cb.SetTextMatrix(document.LeftMargin + 4, document.PageSize.GetBottom(30));
                    cb.ShowText(String.Format(LanguageStrings.VatRegNumber, _vatRegNumber));
                }

                if (!String.IsNullOrEmpty(_footer))
                {
                    float middleStart = (((document.Right) - document.Left) / 2) -
                        ((_baseFont.GetWidthPoint(_footer, 10) / 2) - document.RightMargin);
                    cb.SetTextMatrix(middleStart, document.PageSize.GetBottom(30));
                    cb.ShowText(_footer);
                }

                if (_order != null)
                {
                    float pageNumWidth = _baseFont.GetWidthPoint(pageOf, 10);
                    cb.SetTextMatrix(document.PageSize.GetRight(pageNumWidth + 60), document.PageSize.GetBottom(30));
                    cb.ShowText(pageOf);
                    float len = _baseFont.GetWidthPoint(pageOf, 10);
                    cb.AddTemplate(footerTemplate, document.PageSize.GetRight(pageNumWidth + 60) + pageNumWidth,
                        document.PageSize.GetBottom(30));
                }

                cb.EndText();
            }

            //Move the pointer and draw line to separate footer section from rest of page
            cb.MoveTo(40, document.PageSize.GetBottom(50));
            cb.LineTo(document.PageSize.Width - 40, document.PageSize.GetBottom(50));
            cb.Stroke();
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(_baseFont, 10);
            footerTemplate.SetTextMatrix(0, 0);
            footerTemplate.ShowText((writer.PageNumber - 1).ToString());
            footerTemplate.EndText();
        }
    }
}
