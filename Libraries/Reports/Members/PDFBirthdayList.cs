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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: PDFBirthdayList.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;

using SharedBase.Utils;
using SharedBase.BOL.Users;

using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using ThoughtWorks.QRCode.Codec.Util;


namespace Reports.Members
{
    public class PDFBirthdayList : BaseReport
    {
        #region Constructors / Destructors

        public PDFBirthdayList()
            : base(UniqueFileName("Birthday", true))
        {
        }

        public void GenerateDocument(Users selectedUsers)
        {
            Document myDocument = new Document(PageSize.A4);

            try
            {
                Users users = selectedUsers;

                PdfWriter.GetInstance(myDocument, new FileStream(FileName, FileMode.Create));

                myDocument.Open();
                int UserCount = users.Count;
                int CurrUser = 1;

                foreach (User user in users)
                {
                    if (user.ValidAddress())
                    {
                        PrintHeader(myDocument);

                        PrintUserName(myDocument, user);

                        if (CurrUser < UserCount)
                            myDocument.NewPage();
                    }

                    CurrUser++;
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

        #endregion Constructors / Destructors

        public static void ConfirmList(Users selectedUsers)
        {
            try
            {
                PDFBirthdayList lst = new PDFBirthdayList();
                lst.GenerateDocument(selectedUsers);
                lst.View();
            }
            catch (Exception err)
            {
                if (err.Message.Contains("The document has no pages"))
                {
                    System.Windows.Forms.MessageBox.Show("No users selected !");
                }
                else
                {
                    SharedBase.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
                    throw;
                }
            }
        }

        private void PrintQRImage(Document document, string data)
        {
            ParagraphAdd(document);
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
            qrCodeEncoder.QRCodeScale = 2;
            qrCodeEncoder.QRCodeVersion = 7;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;

            System.Drawing.Image image;
            image = qrCodeEncoder.Encode(data);
            Image qrCode = Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Bmp);
            qrCode.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
            document.Add(qrCode);

        }

        private void PrintUserName(Document document, User user)
        {
            DateTime now = DateTime.Now.AddMonths(1);
            DateTime expires = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month), 23, 59, 59);
            string voucherCode = SharedBase.BOL.Coupons.Coupons.GenerateCoupon(10, user, expires, expires.AddDays(-80));

            Paragraph p = new Paragraph(user.Address(false), FontVerdana);
            p.SpacingBefore = 55f;
            document.Add(p);

            ParagraphAdd(document);

            string name = String.Format("Dear {0}\n\nAs it's your birthday we would like to give you a £10 gift voucher to spend in store on products or treatments* or online.\n\n", user.FirstName);
            p = new Paragraph(name, FontVerdana);
            document.Add(p);

            p = new Paragraph(String.Format("Your unique voucher code is {0} and is valid until {1}.\n\n", voucherCode, expires.ToLongDateString()), FontVerdana);
            document.Add(p);

            p = new Paragraph(String.Format("You can redeem your voucher online or by visiting our salon\n\n"), FontVerdana);
            document.Add(p);

            p = new Paragraph(String.Format("We hope you have a really lovely birthday\n\n"), FontVerdana);
            document.Add(p);

            ParagraphAdd(document);
            PrintQRImage(document, voucherCode);

            p = new Paragraph("* As you can appreciate, non-attendance at a booked appointment can affect our business and will therefore be " +
                "charged at the full price.  Appointments cancelled within 24 hours will incur a 50% cancellation fee.  " +
                "Please arrive 10 minutes before your appointment.", FontTextGrey);
            p.SpacingBefore = 40f;
            document.Add(p);

        }

        private void PrintHeader(Document document)
        {
            Image jpg = Image.GetInstance(CurrentPath + "\\Images\\BirthdayBackground.jpg");
            jpg.ScaleToFit(document.PageSize.Width - (document.RightMargin + document.LeftMargin), document.PageSize.Height + document.BottomMargin);
            jpg.Alignment = iTextSharp.text.Image.UNDERLYING;
            document.Add(jpg);
        }
    }
}
