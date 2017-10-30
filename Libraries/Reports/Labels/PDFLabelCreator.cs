using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Reports.Labels
{
    /// <summary>
    /// Contains the labels/PDF creation logic
    /// </summary>
    public class PDFLabelCreator : BaseReport
    {
        private BaseLabel _label;
        private List<byte[]> _images;
        private List<TextChunk> _textChunks;

        /// <summary>
        /// Useful for debugging the formatting if needed
        /// </summary>
        public bool IncludeLabelBorders { get; set; }
        
        /// <summary>
        /// If true text is repeated on all labels, if false each label has own image/text
        /// </summary>
        public bool Repeat { get; set; }

        public PDFLabelCreator(BaseLabel label)
            : base(UniqueFileName("Label", true))
        {
			FontFactory.RegisterDirectories(); //Register all local fonts
			
            _label = label;
            _images = new List<byte[]>();
            _textChunks = new List<TextChunk>();
            IncludeLabelBorders = true;
            Repeat = false;
        }

        /// <summary>
        /// Add an image to the labels
        /// Currently adds images and then text in that specific order
        /// </summary>
        /// <param name="img"></param>
        public void AddImage(Stream img)
        {
            MemoryStream mem = new MemoryStream();
            CopyStream(img, mem);
            _images.Add(mem.GetBuffer());
        }

        private void CopyStream(Stream input, Stream output)
        {
            byte[] b = new byte[32768];
            int r;
            while ((r = input.Read(b, 0, b.Length)) > 0)
                output.Write(b, 0, r);
        }
        

        /// <summary>
        /// Add a chunk of text to the labels
        /// </summary>
        /// <param name="text">The text to add e.g "I am on a label"</param>
        /// <param name="fontName">The name of the font e.g. "Verdana"</param>
        /// <param name="fontSize">The font size in points e.g. 12</param>
        /// <param name="embedFont">If the font you are using may not be on the target machine, set this to true</param>
        /// <param name="fontStyles">An array of required font styles</param>
        public void AddText(string text, string fontName, int fontSize, bool embedFont = false, params Enums.FontStyle[] fontStyles )
        {
            int fontStyle = 0;
            if (fontStyles != null)
            {
                foreach (Enums.FontStyle item in fontStyles)
                {
                    fontStyle += (int)item;
                }
            }
            
            _textChunks.Add(new TextChunk() { Text = text, FontName = fontName, FontSize = fontSize, FontStyle = fontStyle, EmbedFont = embedFont });
        }
        
        
        /// <summary>
        /// Create the PDF using the defined page size, label type and content provided
        /// Ensure you have added something first using either AddImage() or AddText()
        /// </summary>
        /// <returns></returns>
        public void CreatePDF()
        {

            //Get the itext page size
            Rectangle pageSize;
            switch (_label.PageSize)
            {
                case Enums.PageSize.A4:
                    pageSize = iTextSharp.text.PageSize.A4;
                    break;
                default:
                    pageSize = iTextSharp.text.PageSize.A4;
                    break;
            }

            //Create a new iText document object, define the paper size and the margins required
            Document doc = new Document(pageSize, 
                _label.PageMarginLeft, 
                _label.PageMarginRight, 
                _label.PageMarginTop, 
                _label.PageMarginBottom);

            //Creates the document tells the PdfWriter to use the output stream when Document.Close() is called
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(FileName, FileMode.CreateNew));
            try
            {
                //Open the document to begin adding elements
                doc.Open();
                try
                {
                    //Create a new table with label and gap columns
                    int numOfCols = _label.LabelsPerRow + (_label.LabelsPerRow - 1);
                    PdfPTable tbl = new PdfPTable(numOfCols);
                    try
                    {
                        //Build the column width array, even numbered index columns will be gap columns
                        List<float> colWidths = new List<float>();

                        for (int i = 1; i <= numOfCols; i++)
                        {
                            if (i % 2 > 0)
                            {
                                colWidths.Add(_label.Width);
                            }
                            else
                            {
                                //Even numbered columns are gap columns
                                colWidths.Add(_label.HorizontalGapWidth);
                            }
                        }

                        #region Rows and Columns

                        /* The next 3 lines are the key to making SetWidthPercentage work */
                        /* "size" specifies the size of the page that equates to 100% - even though the values passed are absolute not relative?! */
                        /* (I will never get those 3 hours back) */
                        float w = iTextSharp.text.PageSize.A4.Width - (doc.LeftMargin + doc.RightMargin);
                        float h = iTextSharp.text.PageSize.A4.Height - (doc.TopMargin + doc.BottomMargin);
                        iTextSharp.text.Rectangle size = new iTextSharp.text.Rectangle(w, h);

                        //Set the column widths (in points) - take note of the size parameter mentioned above
                        tbl.SetWidthPercentage(colWidths.ToArray(), size);

                        //Create the rows for the table
                        for (int iRow = 0; iRow < _label.LabelRowsPerPage; iRow++)
                        {
                            List<PdfPCell> rowCells = new List<PdfPCell>();
                            try
                            {
                                //Build the row - even numbered index columns are gaps
                                for (int iCol = 1; iCol <= numOfCols; iCol++)
                                {
                                    if (iCol % 2 > 0)
                                    {

                                        // Create a new Phrase and add the image to it
                                        Phrase cellContent = new Phrase();
                                        try
                                        {
                                            #region If Repeat

                                            if (Repeat)
                                            {
                                                foreach (TextChunk txt in _textChunks)
                                                {
                                                    Font font = FontFactory.GetFont(txt.FontName, BaseFont.CP1250, txt.EmbedFont, txt.FontSize, txt.FontStyle);
                                                    cellContent.Add(new Chunk(txt.Text + "\n", font));
                                                }

                                                foreach (byte[] img in _images)
                                                {
                                                    iTextSharp.text.Image pdfImg = iTextSharp.text.Image.GetInstance(img);
                                                    cellContent.Add(new Chunk(pdfImg, 0, -90));
                                                }
                                            }
                                            else
                                            {
                                                LabelCellArgs args = new LabelCellArgs();

                                                if (GetCellContents != null)
                                                    GetCellContents(this, args);

                                                if (args.Image != null)
                                                {
                                                    iTextSharp.text.Image pdfImg = iTextSharp.text.Image.GetInstance(args.Image);
                                                    try
                                                    {
                                                        if (pdfImg.Width > 91)
                                                        {
                                                            //pdfImg.ScaleToFitLineWhenOverflow = true;
                                                            //pdfImg.ScaleAbsolute(91.0f, 60.0f);
                                                            //pdfImg.ScalePercent(20.0f, 20.0f);
                                                        }

                                                        Chunk chunkImg = new Chunk(args.Image, args.ImageOffsetX, args.ImageOffSetY);
                                                        try
                                                        {
                                                            cellContent.Add(chunkImg);
                                                        }
                                                        finally
                                                        {
                                                            chunkImg = null;
                                                        }
                                                    }
                                                    finally
                                                    {
                                                        pdfImg = null;
                                                    }

                                                    args.Image = null;
                                                }

                                                Font font = FontFactory.GetFont("Verdana", BaseFont.TIMES_ROMAN, true, 8, 0);
                                                try
                                                {
                                                    if (!String.IsNullOrEmpty(args.Text))
                                                    {
                                                        cellContent.Add(new Chunk("\n" + args.Text, font));
                                                    }

                                                    if (!String.IsNullOrEmpty(args.Footer))
                                                    {
                                                        Chunk footer = new Chunk("\n\n\n\n\n\n\n\n\n\n\n\n\n" + args.Footer, font);
                                                        cellContent.Add(footer);
                                                    }
                                                }
                                                finally
                                                {
                                                    font = null;
                                                }
                                            }

                                            #endregion If Repeat

                                            //Create a new cell specifying the content
                                            PdfPCell cell = new PdfPCell(cellContent);
                                            try
                                            {
                                                //Ensure our label height is adhered to
                                                cell.FixedHeight = _label.Height;

                                                //Centre align the content
                                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                                //cell.VerticalAlignment = Element.ALIGN_TOP;
                                                cell.Border = IncludeLabelBorders ? Rectangle.BOX : Rectangle.NO_BORDER;

                                                //Add to the row
                                                rowCells.Add(cell);
                                            }
                                            finally
                                            {
                                                cell = null;
                                            }
                                        }
                                        finally
                                        {
                                            cellContent = null;
                                        }
                                    }
                                    else
                                    {
                                        //Create a empty cell to use as a gap
                                        PdfPCell gapCell = new PdfPCell();
                                        gapCell.FixedHeight = _label.Height;
                                        gapCell.Border = Rectangle.NO_BORDER;
                                        //Add to the row
                                        rowCells.Add(gapCell);
                                    }
                                }

                                //Add the new row to the table
                                tbl.Rows.Add(new PdfPRow(rowCells.ToArray()));

                                //On all but the last row, add a gap row if needed
                                if ((iRow + 1) < _label.LabelRowsPerPage && _label.VerticalGapHeight > 0)
                                {
                                    tbl.Rows.Add(CreateGapRow(numOfCols));
                                }
                            }
                            finally
                            {
                                rowCells = null;
                            }
                        }

                        #endregion Rows and Columns

                        //Add the table to the document
                        doc.Add(tbl);
                    }
                    finally
                    {
                        tbl = null;
                    }
                }
                finally
                {
                    doc.Close();
                    doc.Dispose();
                    doc = null;
                }
            }
            finally
            {
                writer.Dispose();
                writer = null;
            }
        }

        private PdfPRow CreateGapRow(int numOfCols)
        {
            List<PdfPCell> cells = new List<PdfPCell>();

            for (int i = 0; i < numOfCols; i++)
			{
                PdfPCell cell = new PdfPCell();
                cell.FixedHeight = _label.VerticalGapHeight;
                cell.Border = Rectangle.NO_BORDER;
                cells.Add(cell);
			}
            return new PdfPRow(cells.ToArray());
        }

        /// <summary>
        /// Label being used
        /// </summary>
        public BaseLabel Label
        {
            get
            {
                return (_label);
            }
        }

        public event CustomCellContentsHandler GetCellContents;


    }

    /// <summary>
    /// Custom Cell Contents Handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void CustomCellContentsHandler (object sender, LabelCellArgs e);

    /// <summary>
    /// Event Arguments for custom cells
    /// </summary>
    public class LabelCellArgs : EventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LabelCellArgs()
        {
            Image = null;
            Text = String.Empty;
            Footer = String.Empty;
        }

        /// <summary>
        /// Image for Cell
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// Text to accompany image
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Footer if cell is large enough
        /// </summary>
        public string Footer { get; set; }

        /// <summary>
        /// Image offset X
        /// </summary>
        public int ImageOffsetX { get; set; }

        /// <summary>
        /// Image offset Y
        /// </summary>
        public int ImageOffSetY { get; set; }
    }

}
