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
    public partial class BuyItNow : BaseControlClass
    {
        private string _image;
        private string _priceFontColour = "#0000FF";
        private string _fontColour = "#000;";
        private ProductCost _productCost;
        private string _contains;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(GetUserSession().IsBrowserMobile)
            {

            }
            else
            {
                divDescription.Style.Add("width", "570px");
                divDescription.Style.Add("float", "right");
            }
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
        /// Colour of normal text
        /// </summary>
        public string FontColour
        {
            get
            {
                return (_fontColour);
            }

            set
            {
                _fontColour = value;
            }
        }

        /// <summary>
        /// Description about what the product contains
        /// </summary>
        public string Contains
        {
            get
            {
                return (_contains);
            }

            set
            {
                _contains = value;

                pContains.InnerHtml = _contains;
            }
        }

        /// <summary>
        /// Uses the product description name in the title if true
        /// </summary>
        public bool UseProductName { set; get; }

        /// <summary>
        /// The product being sold
        /// </summary>
        public ProductCost Product
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

                    decimal cost = _productCost.PriceGet(((LocalWebSessionData)GetUserSession().Tag).PriceColumn, WebCountry);

                    if (_productCost.Discount > 0.00m)
                    {
                        cost = (cost / 100) * (100 - _productCost.Discount);
                    }

                    if (BaseWebApplication.PricesIncludeVAT)
                    {
                        cost += SharedUtils.VATCalculate(cost, WebVATRate);
                    }

                    hrAnchor.Name = String.Format("#{0}", _productCost.Size.Replace(" ", ""));

                    string saving = String.Empty;

                    if (_productCost.Saving > 0.00)
                    {
                        saving = String.Format(Languages.LanguageStrings.ProductSaving, _productCost.Saving);
                    }

                    if (UseProductName)
                        pProductDescription.InnerHtml = String.Format("<strong><a href=\"/Products/Product.aspx?id={6}\">{0} {1}</a> - <font color=\"{4}\">Only {2}</font> {5}</strong><br /> <Label class=\"binSmallText\">{3}</Label>",
                            _productCost.Product.Name, _productCost.Size, SharedUtils.FormatMoney(cost, GetWebsiteCurrency(), false),
                            _productCost.OutOfStock ? "<span><strong>Out of Stock</strong></span>" : "", PriceFontColour, saving,
                            _productCost.ProductID);
                    else
                        pProductDescription.InnerHtml = String.Format("<strong><a href=\"/Products/Product.aspx?id={5}\">{0}</a> - <font color=\"{3}\">Only {1}</font> {4}</strong><br /> <Label class=\"binSmallText\">{2}</Label>",
                            _productCost.Size, SharedUtils.FormatMoney(cost, GetWebsiteCurrency(), false),
                            _productCost.OutOfStock ? "<span><strong>Out of Stock</strong></span>" : "", PriceFontColour, saving,
                            _productCost.ProductID);

                    if (_productCost.OutOfStock)
                        btnAddToBasket.Enabled = false;

                    if (String.IsNullOrEmpty(Image))
                        Image = "https://static.heavenskincare.com/Images/Products/" + HSCUtils.ResizeImage(_productCost.Product.Image, 148);

                    if (String.IsNullOrEmpty(Contains))
                        Contains = _productCost.Product.Ingredients.Replace("\r\n", ", ");

                    lblQuantity.Style.Add("color", _fontColour);
                    pProductDescription.Style.Add("color", _fontColour);
                    pContains.Style.Add("color", _fontColour);
                }
            }
        }

        /// <summary>
        /// The ID of the product being sold
        /// </summary>
        public Int64 ProductID
        {
            set
            {
                Product = ProductCosts.Get(value);
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