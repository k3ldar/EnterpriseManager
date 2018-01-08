using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SieraDelta.Website.Library.Classes;
using SieraDelta.Library.BOL.Products;
using SieraDelta.Library.Utils;

namespace SieraDelta.Website.Controls
{
    public partial class BuyItNowStratosphere : BaseControlClass
    {
        private string _image;
        private string _priceFontColour = "#0000FF";
        private ProductCost _productCost;
        private string _contains;

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

                pContains.InnerText = _contains;
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
                    //SieraDeltaUtils u = new SieraDeltaUtils();

                    if (imgProduct.Src == String.Empty)
                        imgProduct.Alt = String.Empty;
                    else
                        imgProduct.Alt = _productCost.Size;

                    double cost = _productCost.PriceGet(WebCountry);

                    if (WebCountry.VATRate == 0.00)
                        cost = SieraDeltaUtils.VATRemove(cost);

                    hrAnchor.Name = String.Format("#{0}", _productCost.Size.Replace(" ", ""));

                    if (UseProductName)
                        pProductDescription.InnerHtml = String.Format("<strong>{0} {1} - <font color=\"{4}\">Only {2}</font></strong><br /> <Label class=\"binSmallText\">{3}</Label>",
                            _productCost.Product.Name, _productCost.Size, SieraDeltaUtils.FormatMoney(cost, WebCulture, WebCountry.ConversionRate, WebCountry.Multiplier, false, true),
                            _productCost.OutOfStock ? "<span><strong>Out of Stock</strong></span>" : "", PriceFontColour);
                    else
                        pProductDescription.InnerHtml = String.Format("<strong>{0} - <font color=\"{3}\">Only {1}</font></strong><br /> <Label class=\"binSmallText\">{2}</Label>",
                            _productCost.Size, SieraDeltaUtils.FormatMoney(cost, WebCulture, WebCountry.ConversionRate, WebCountry.Multiplier, false, true),
                            _productCost.OutOfStock ? "<span><strong>Out of Stock</strong></span>" : "", PriceFontColour);

                    if (_productCost.OutOfStock)
                        btnAddToBasket.Enabled = false;
                }
            }
        }

        /// <summary>
        /// The ID of the product being sold
        /// </summary>
        public int ProductID
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
                int priceOption = (int)Session["WEBSITE_PRICE"];
                SharedWebBase.GetShoppingBasket(Session, Request, Response).Add(_productCost, qty, GetUser(),
                    SieraDelta.Library.Enums.BasketType.Product, priceOption);
            }

        }
    }
}