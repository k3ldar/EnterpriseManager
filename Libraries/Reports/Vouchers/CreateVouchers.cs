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
 *  File: CreateVouchers.cs
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
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

using Reports.Labels;
using SharedBase.Utils;
using SharedBase.BOL.Products;
using SharedBase.BOL.Countries;
using SharedBase.BOLEvents;

using SharedControls.Forms;

using ThoughtWorks.QRCode.Codec;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation
#pragma warning disable IDE0016 // null check simplified
#pragma warning disable IDE0028 // collection simplified

namespace Reports.Vouchers
{
    public partial class CreateVouchers : BaseForm
    {
        #region Private Members

        private int _labelNumber;
        private Country _country;
        private CultureInfo _culture;

        #endregion Private Members

        #region Constructors

        public CreateVouchers(CultureInfo culture)
        {
            InitializeComponent();
            _culture = culture;
            cmbBarcodeType.SelectedIndex = 0;

            this.Width = 284;
        }

        #endregion Constructors

        #region Properties

        public  Country VoucherCountry
        {
            get
            {
                return (_country);
            }

            set
            {
                _country = value;
                LoadExistingVoucherAmounts();
                LoadAveryLabels();
                LoadCustomLabel();
            }
        }

        #endregion Properties

        #region Private Methods

        private void LoadAveryLabels()
        {
            cmbLabelSize.Items.Add(new Reports.Labels.L7161());
            cmbLabelSize.Items.Add(new Reports.Labels.L7160());
            cmbLabelSize.SelectedIndex = 0;
        }

        private void LoadExistingVoucherAmounts()
        {
            Product product = SharedBase.BOL.Products.Products.Get(224);
            ProductCosts costs = null;

            if (product == null)
            {
                costs = new ProductCosts();
                
                costs.Add(new ProductCost(-1, new Product(), String.Empty, "50", 50.00m, 5, false, ProductCostTypes.Get("Vouchers"), 
                    String.Empty, false, false, 0.00m, 0.00m, 0.00m, String.Empty, SharedBase.ProductCostItemType.Voucher, -1, 0,
                    Convert.ToDecimal(SharedBase.DAL.DALHelper.DefaultVATRate), 0.0));
            }
            else
            {
                costs = ProductCosts.All(product);
            }

            foreach (ProductCost cost in costs)
            {
                cmbVoucherAmount.Items.Add(cost);
            }

            cmbVoucherAmount.SelectedIndex = 0;
        }

        private void cmbLabelSize_Format(object sender, ListControlConvertEventArgs e)
        {
            BaseLabel lbl = (BaseLabel)e.ListItem;
            e.Value = lbl.ToString();
        }

        private void btnCreateLabels_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            pbGenerateLabels.Visible = true;
            pbOverall.Visible = true;
            pbOverall.Value = 0;
            lblLabelGeneration.Visible = true;
            try
            {
                _labelNumber = 1;
                PDFLabelCreator creator = null;

                if (cbCustomLabel.Checked)
                {
                    creator = new PDFLabelCreator((BaseLabel)new CustomLabel(Convert.ToDouble(upDownLabelWidth.Value),
                        Convert.ToDouble(upDownLabelHeight.Value),
                        Convert.ToDouble(upDownLabelHGap.Value),
                        Convert.ToDouble(upDownLabelVGap.Value),
                        Convert.ToDouble(upDownMarginTop.Value),
                        Convert.ToDouble(upDownMarginBottom.Value),
                        Convert.ToDouble(upDownMarginLeft.Value),
                        Convert.ToDouble(upDownMarginRight.Value), 
                        Convert.ToInt32(upDownRows.Value), 
                        Convert.ToInt32(upDownColumns.Value)));
                }
                else
                    creator = new PDFLabelCreator((BaseLabel)cmbLabelSize.SelectedItem);

                creator.Repeat = false;
                creator.IncludeLabelBorders = cbShowLines.Checked;
                creator.GetCellContents += creator_GetCellContents;

                creator.CreatePDF();

                creator.View();
            }
            finally
            {
                pbGenerateLabels.Visible = false;
                pbOverall.Visible = false;
                lblLabelGeneration.Visible = false;
                this.Cursor = Cursors.Arrow;
            }
        }

        void creator_GetCellContents(object sender, LabelCellArgs e)
        {
            lblLabelGeneration.Text = String.Format("Generating Label {0}", _labelNumber);
            Progress progress = new Progress();
            progress.OnProgress += progress_OnProgress;

            try
            {
                ProductCost cost = (ProductCost)cmbVoucherAmount.SelectedItem;

                if (cbTestPrinting.Checked)
                {
                    switch (cmbBarcodeType.SelectedIndex)
                    {
                        case 0: // 2D
                            e.Text = SharedBase.Utils.LibUtils.GenerateRandomVoucherCode();
                            break;
                        case 1: // 2 of 5
                            e.Text = SharedBase.Utils.LibUtils.GenerateRandomVoucherCode("", "NNNNNNNNNNNNNNNN");
                            break;
                        case 2: // 3 of 9
                            e.Text = SharedBase.Utils.LibUtils.GenerateRandomVoucherCode("HV", "LLL");
                            break;
                    }
                }
                else
                {
                    switch (cmbBarcodeType.SelectedIndex)
                    {
                        case 0: // 2D
                            e.Text = SharedBase.BOL.Vouchers.Vouchers.CreateVoucher(progress, cost.PriceGet(_country));
                            break;
                        case 1: // 2 of 5
                            e.Text = SharedBase.BOL.Vouchers.Vouchers.CreateVoucher(progress, cost.PriceGet(_country), "", "NNNNNNNNNNNNNNNN");
                            break;
                        case 2: // 3 of 9
                            e.Text = SharedBase.BOL.Vouchers.Vouchers.CreateVoucher(progress, cost.PriceGet(_country), "HV", "LL");
                            break;
                    }
                }

                System.Drawing.Image image = null;

                switch (cmbBarcodeType.SelectedIndex)
                {
                    case 0: //2D Barcode
                        QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                        try
                        {
                            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
                            qrCodeEncoder.QRCodeScale = 2;
                            qrCodeEncoder.QRCodeVersion = 7;
                            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;

                            image = qrCodeEncoder.Encode(e.Text);

                            //System.Drawing.Bitmap original = (System.Drawing.Bitmap)image;
                            //System.Drawing.Bitmap resized = new System.Drawing.Bitmap(original, new System.Drawing.Size(85, 85));
                        }
                        finally
                        {
                            qrCodeEncoder = null;
                        }
                        break;

                    case 1: //2 of 5
                        image = Classes.Barcode2of5.Print2of5Interleaved(e.Text);
                        //System.Drawing.Bitmap original = (System.Drawing.Bitmap)image;
                        //System.Drawing.Bitmap resized = new System.Drawing.Bitmap(original, new System.Drawing.Size(85, 85));
                        //image.Save("barcode2of5.bmp");
                        break;

                    case 2: // 3 of 9
                        image = Classes.Barcode3of9.Print3of9(e.Text);
                        image.Save("barcode3of9.bmp");
                        break;
                }

                if (image.Width > 120)
                {
                    //System.Drawing.Image resized = ResizeImage(image, 150, 45);
                    //resized.Save("t:\\barcode3of9a.bmp");
                    //image.Save("T:\\saved.jpg");
                    //System.Drawing.Bitmap resized = new System.Drawing.Bitmap(image, new System.Drawing.Size(85, 45));
                    //resized.Save("t:\\barcode3of9.bmp");
                    e.Image = iTextSharp.text.Image.GetInstance("barcode3of9.bmp"); //resized, System.Drawing.Imaging.ImageFormat.Gif);
                }
                else
                    e.Image = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Bmp);

                decimal itemCost = cost.PriceGet(_country);
                
                itemCost += SharedUtils.VATCalculate(itemCost, _country.VATRate);

                string amount = String.Format(" - {0}", SharedUtils.FormatMoney(itemCost, 
                    SharedBase.BOL.Basket.Currencies.Get(_culture.Name), false));
                e.Text += amount;
                e.ImageOffsetX = 0;
                e.ImageOffSetY = -102;

                if (sender is PDFLabelCreator)
                {
                    if (((PDFLabelCreator)sender).Label.Height > 42.00)
                    {
                        if (cost.Size.ToLower().Contains("voucher"))
                            e.Footer = "";
                        else
                            e.Footer = String.Format("{0} - {1}", cost.Size, 
                                SharedUtils.FormatMoney(itemCost, SharedBase.BOL.Basket.Currencies.Get(
                                _culture.Name), false));
                    }
                    else
                        e.Footer = String.Empty;
                }
            }
            catch (Exception err)
            {
                ShowError("Error Generating Labels", err.Message);
            }
            finally
            {
                _labelNumber++;

                pbOverall.Value += 1;
            }
        }

        void progress_OnProgress(object sender, ProgressEventArgs e)
        {
            if (pbGenerateLabels.Maximum != e.Max)
                pbGenerateLabels.Maximum = e.Max;

            if (pbGenerateLabels.Value != e.Percent)
                pbGenerateLabels.Value = e.Percent;
        }

        private void cbCustomLabel_CheckedChanged(object sender, EventArgs e)
        {
            this.Width = cbCustomLabel.Checked ? 744 : 284;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CustomLabel saveLabel = new CustomLabel(Convert.ToDouble(upDownLabelWidth.Value),
                        Convert.ToDouble(upDownLabelHeight.Value),
                        Convert.ToDouble(upDownLabelHGap.Value),
                        Convert.ToDouble(upDownLabelVGap.Value),
                        Convert.ToDouble(upDownMarginTop.Value),
                        Convert.ToDouble(upDownMarginBottom.Value),
                        Convert.ToDouble(upDownMarginLeft.Value),
                        Convert.ToDouble(upDownMarginRight.Value), 
                        Convert.ToInt32(upDownRows.Value), 
                        Convert.ToInt32(upDownColumns.Value));

            SerializeObject<CustomLabel>(saveLabel, "CustomLabel.xml");
        }

        private void LoadCustomLabel()
        {
            if (File.Exists("CustomLabel.xml"))
            {
                CustomLabel load = DeSerializeObject<CustomLabel>("CustomLabel.xml");

                try
                {
                    upDownLabelWidth.Value = Convert.ToDecimal(load.LabelWidth);
                    upDownLabelHeight.Value = Convert.ToDecimal(load.LabelHeight);
                    upDownLabelHGap.Value = Convert.ToDecimal(load.HorizontalGap);
                    upDownLabelVGap.Value = Convert.ToDecimal(load.VerticalGap);
                    upDownMarginBottom.Value = Convert.ToDecimal(load.MBottom);
                    upDownMarginLeft.Value = Convert.ToDecimal(load.MLeft);
                    upDownMarginRight.Value = Convert.ToDecimal(load.MRight);
                    upDownMarginTop.Value = Convert.ToDecimal(load.MTop);
                    upDownRows.Value = load.LabelRowsPerPage;
                    upDownColumns.Value = load.LabelRowsPerPage;
                }
                catch
                {
                    File.Delete("CustomLabel.xml");
                }
            }
        }
        
        #endregion Private Methods

        #region Static Methods

        public static System.Drawing.Image ResizeImage(System.Drawing.Image image, int width, int height)
        {
            Bitmap Result = new Bitmap(width, height);
            Result.SetResolution(300, 300);
            Graphics g = Graphics.FromImage(Result);
            try
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;

                // Resize the original
                g.DrawImage(image, 0, 0, width, height);
            }
            finally
            {
                g.Dispose();
            }

            return (Result);
        }

        public static void ShowVoucherForm(Country country, CultureInfo culture)
        {
            try
            {
                CreateVouchers frm = new CreateVouchers(culture);
                try
                {
                    frm.VoucherCountry = country;
                    frm.ShowDialog();
                }
                finally
                {
                    frm.Dispose();
                    frm = null;
                }
            }
            catch (Exception err)
            {
                SharedBase.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
                throw;
            } 
        }

        #endregion Static Methods
        
        #region Overridden Methods

        #endregion Overridden Methods

        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch
            {
                //Log exception here
                throw;
            }
        }


        /// <summary>
        /// Deserializes an xml file into an object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                string attributeXml = string.Empty;

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch
            {
                
            }

            return objectOut;
        }

        private void cmbVoucherAmount_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductCost cost = (ProductCost)e.ListItem;
            decimal itemCost = cost.PriceGet(_country);
            itemCost += SharedUtils.VATCalculate(itemCost, _country.VATRate);

            e.Value = String.Format("{0} - {1}", cost.Size, SharedUtils.FormatMoney(itemCost,
                SharedBase.BOL.Basket.Currencies.Get(_culture.Name), false));
        }
    }
}
