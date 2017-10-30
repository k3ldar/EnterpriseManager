using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Products;
using Library.Utils;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class DiscountedProductItem : BaseControlClass
    {
        private string _image;
        private string _priceFontColour = "#0000FF";
        private ProductCost _productCost;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Properties

        /// <summary>
        /// Color of the price text
        /// </summary>
        public string PriceFontColour
        {
            get
            {
                return (_priceFontColour);
            }

            set
            {
                _priceFontColour = value;
            }
        }

        /// <summary>
        /// The product being sold
        /// </summary>
        public ProductCost ProductCostItem
        {
            get
            {
                return (_productCost);
            }

            set
            {
                _productCost = value;

                if (_productCost != null)
                {
                    if (imgProduct.Src == String.Empty)
                        imgProduct.Alt = String.Empty;
                    else
                        imgProduct.Alt = _productCost.Size;

                    string rootPath = Global.RootURL;

                    if (System.IO.File.Exists(String.Format("{0}\\Images\\Stratosphere\\{1}", Global.Path, _productCost.Barcode)))
                        Image = String.Format("{0}/Images/Products/{1}", Global.RootURL, _productCost.Barcode);
                    else
                        Image = String.Format("{0}/Images/Products/{1}", Global.RootURL, _productCost.Barcode);

                    decimal cost = _productCost.PriceGet(((LocalWebSessionData)GetUserSession().Tag).PriceColumn, WebCountry);

                    if (_productCost.Discount > 0.00m)
                        cost = (cost / 100) * (100 - _productCost.Discount);

                    if (BaseWebApplication.PricesIncludeVAT)
                    {
                        cost += SharedUtils.VATCalculate(cost, WebVATRate);
                    }

                    hrAnchor.Name = String.Format("#{0}", _productCost.Size.Replace(" ", ""));

                    pProductDescription.InnerHtml = String.Format("<strong>{0} {1}</strong>",
                        _productCost.AdditionalText, _productCost.Size);

                    pPriceDiscount.InnerHtml = String.Format("<strong><font color=\"{2}\">Now Only {0}</font></strong>&nbsp;&nbsp; <Label class=\"binSmallText\">{1}</Label>",
                        SharedUtils.FormatMoney(cost, GetWebsiteCurrency(), false),
                        _productCost.Discount > 0.00m ? String.Format("<span><strong>Save {0}%</strong></span>", _productCost.Discount) : "", PriceFontColour);

                    if (_productCost.OutOfStock)
                        btnAddToBasket.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Image to be shown for the product
        /// </summary>
        public string Image
        {
            get
            {
                return (_image);
            }

            set
            {
                _image = value;

                imgProduct.Src = _image;
            }
        }

        #endregion Properties

        protected void btnAddToBasket_Click(object sender, ImageClickEventArgs e)
        {
            int qty = Convert.ToInt32(lstQuantity.SelectedValue);

            if (_productCost != null && qty > 0)
            {
                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
                localData.Basket.Add(_productCost, qty, GetUser(), localData.PriceColumn);
            }

        }
    }
}