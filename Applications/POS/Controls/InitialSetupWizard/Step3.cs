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
 *  File: Step3.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

using Languages;
using PointOfSale.Classes;
using POS.Base.Classes;

using System.Globalization;

using Plasmoid.Extensions;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace PointOfSale.Controls.InitialSetupWizard
{
    public partial class Step3 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private InitialSetupSettings _settings;
        private StringFormat _headerStringFormat;
        private Font _headerFont;

        #endregion Private Members

        #region Constructors

        public Step3()
        {
            InitializeComponent();

            _headerFont = new Font(this.Font.FontFamily, 9.0f);
            _headerStringFormat = new StringFormat();
            _headerStringFormat.Alignment = StringAlignment.Center;
            _headerStringFormat.LineAlignment = StringAlignment.Center;
        }

        internal Step3(InitialSetupSettings settings)
            : this()
        {
            _settings = settings;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblHeader.Text = LanguageStrings.AppCompanyLogo;

            selectImageFiles.Filter = String.Format(StringConstants.IMAGE_SEARCH_FILTER,
                LanguageStrings.AppAll);
        }

        public override void PageShown()
        {
            AppController.ActiveHelpTopic = HelpTopics.InitialStep3;
        }

        #endregion Overridden Methods

        #region Private Methods


        #region Drag Drop Panel

        private void pnlDragDrop_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = pnlDragDrop.ClientRectangle;

            e.Graphics.FillRectangle(Brushes.White, rect);
            rect.Inflate(-6, -6);

            using (Pen borderPen = new Pen(Brushes.DarkGray, 5))
            {
                borderPen.DashStyle = DashStyle.Dash;
                borderPen.Width = 2;
                e.Graphics.DrawRoundedRectangle(borderPen, rect, 3);
            }

            // draw header text
            e.Graphics.DrawString(
                LanguageStrings.AppImageDropOrSelect,
                _headerFont,
                Brushes.Black,
                rect,
                _headerStringFormat);
        }

        private void pnlDragDrop_DoubleClick(object sender, EventArgs e)
        {
            if (selectImageFiles.ShowDialog(this) == DialogResult.OK)
            {
                ProcessFiles(selectImageFiles.FileNames);
            }
        }

        private void ProcessFiles(string[] allFiles)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                foreach (string file in allFiles)
                {
                    string path = System.IO.Path.GetDirectoryName(file);

                    string fileNoExt = System.IO.Path.GetFileNameWithoutExtension(file);

                    if (fileNoExt.EndsWith(StringConstants.IMAGE_DEFAULT))
                    {
                        ShowError(LanguageStrings.AppError, LanguageStrings.AppImagesProcessInvalidName);
                        continue;
                    }

                    string fileExt = System.IO.Path.GetExtension(file);

                    int[,] sizes = new int[,] { { 178, 121 }, { 66, 66 }, { 220, 110 },
                        { 835, 221 }, { 178, 121 }, { 107, 73 } };

                    Bitmap image = null;
                    try
                    {
                        image = new Bitmap(file);

                        // image must be at least as big as the biggest sized image
                        int width = sizes[0, 0];
                        int height = sizes[0, 1];

                        if (image.Width < width || (height > 0 && image.Height < height))
                        {
                            ShowError(LanguageStrings.AppError, 
                                String.Format(LanguageStrings.AppImagesProcessTooSmall, width, height));
                            continue;
                        }

                        pictureLogo.ImageLocation = file;
                    }
                    catch (Exception err)
                    {
                        ShowError(LanguageStrings.AppError, err.Message);
                    }
                    finally
                    {
                        image.Dispose();
                        image = null;
                    }

                    _settings.Logo = file;

                    // once we have 1 matching file, move on as only need one
                    break;
                }
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void pnlDragDrop_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void pnlDragDrop_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Assign the file names to a string array, in 
                // case the user has selected multiple files.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                ProcessFiles(files);
            }
        }

        #endregion Drag Drop Panel


        private Bitmap ResizeImage(Image image, int width, int height)
        {
            if (height == 0)
            {
                // resize but keep aspect ration based on with
                height = ResizeKeepAspect(new Size(image.Width, image.Height), width);
            }

            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return (destImage);
        }

        public int ResizeKeepAspect(Size src, int maxWidth)
        {
            double ratioW = (double)maxWidth / (double)src.Width;

            return (Convert.ToInt32(src.Height * ratioW));
        }


        #endregion Private Methods
    }
}
