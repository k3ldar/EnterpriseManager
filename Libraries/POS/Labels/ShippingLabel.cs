using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

using Library.BOL.Users;
using Library.BOL.DeliveryAddress;
using POS.Base.Classes;

namespace POS.Base.Labels
{
    public class ShippingLabel : BaseLabel
    {
        private string _tempFile;

        public ShippingLabel(User user)
        {
            _tempFile = UniqueFileName();

            CreateShippingLabel(_tempFile, user.Address(false));
        }

        public ShippingLabel(DeliveryAddress address)
        {
            _tempFile = UniqueFileName();

            CreateShippingLabel(_tempFile, address.Address(false));
        }

        public void Print()
        {
            PrintLabel(_tempFile);
        }

        private void PrintLabel(string FileName)
        {
            PrintDocument p = new PrintDocument();
            p.PrinterSettings.PrinterName = GetXMLValue(StringConstants.XML_LABEL_PRINTER, 
                StringConstants.XML_LABEL_NAME);

            foreach (PaperSize size in p.PrinterSettings.PaperSizes)
            {
                if (size.PaperName == StringConstants.LABEL_PAGE_SIZE)
                {
                    p.PrinterSettings.DefaultPageSettings.PaperSize = size;
                    break;
                }
            }

            p.PrinterSettings.DefaultPageSettings.Landscape = true;
            p.PrinterSettings.DefaultPageSettings.Margins.Top = 1;
            p.PrinterSettings.DefaultPageSettings.Margins.Left = 1;
            p.PrinterSettings.DefaultPageSettings.Margins.Bottom = 1;
            p.PrinterSettings.DefaultPageSettings.Margins.Right = 1;

            if (p.PrinterSettings.PaperSources.Count > 0)
                p.PrinterSettings.DefaultPageSettings.PaperSource = p.PrinterSettings.PaperSources[0];

            p.PrintPage += new PrintPageEventHandler(p_PrintPage);

            p.Print();
        }

        void p_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(Image.FromFile(_tempFile), 0, 0);
        }

        private void CreateShippingLabel(string FileName, string Address)
        {
            Bitmap bmp = new Bitmap(String.Format(StringConstants.FILE_LABEL_NAME_3, CurrentPath));
            Graphics g = Graphics.FromImage(bmp);

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            //StringFormat strFormat = new StringFormat();
            //strFormat.Alignment = StringAlignment.Near;

            g.DrawString(Address, new Font(StringConstants.FONT_ARIAL, 13), Brushes.Black, new PointF(10, 138));

            bmp.Save(FileName);
        }

        #region Static Methods

        public static string UniqueFileName()
        {
            string Result = String.Format(StringConstants.FILE_LABEL_NAME_1,
                CurrentPath, DateTime.Now.ToString(StringConstants.FILE_LABEL_NAME_2));

            return (Result);
        }

        #endregion Static Methods

    }
}
