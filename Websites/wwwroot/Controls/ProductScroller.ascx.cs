using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SieraDelta.Website.Library.Classes;

using SieraDelta.Library;
using SieraDelta.Library.Utils;
using SieraDelta.Library.BOL.Products;

namespace SieraDelta.Website.Controls
{
    public partial class ProductScroller : BaseControlClass
    {
        #region Private Members

        private int _visibleProductCount = 4;

        #endregion Private Members

        #region Protected Methods

        protected string GetProducts()
        {
            string formatting = String.Empty;

            if (CenterText)
            {
                formatting += "text-align: center;";
            }

            return (GetCarouselProducts(ProductTypes.Get("WebDefender Server"), ShowPrices, ShowNew, ShowBest, Clickable, formatting));
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion Protected Members

        #region Properties

        /// <summary>
        /// Determines wether the text is centered
        /// </summary>
        public bool CenterText { get; set; }

        /// <summary>
        /// Depicts the number of products visible on the scroller
        /// </summary>
        public int VisibleProductCount 
        {
            get
            {
                return (_visibleProductCount);
            }

            set
            {
                switch (value)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        _visibleProductCount = value;
                        break;
                    default:
                        _visibleProductCount = 4;
                        break;
                }
            }
        }

        /// <summary>
        /// Determines wether the header is shown or not
        /// </summary>
        public bool ShowHeader
        {
            get
            {
                return (hHeader.Visible);
            }

            set
            {
                hHeader.Visible = value;
            }
        }

        /// <summary>
        /// Determines wether the New Product box is shown
        /// </summary>
        public bool ShowNew { get; set; }

        /// <summary>
        /// Determines wether the best seller box is shown
        /// </summary>
        public bool ShowBest { get; set; }

        /// <summary>
        /// Determines wether price information is shown
        /// </summary>
        public bool ShowPrices { get; set; }

        /// <summary>
        /// Determines wether the products have a URL or just for display
        /// </summary>
        public bool Clickable { get; set; }

        #endregion Properties

        #region Protected Methods

        protected string GetScrollerWidth()
        {
            string Result = "{0}px";

            switch (VisibleProductCount)
            {
                case 1:
                    Result = String.Format(Result, 270);
                    break;
                case 2:
                    Result = String.Format(Result, 490);
                    break;
                case 3:
                    Result = String.Format(Result, 710);
                    break;
                case 4:
                    Result = String.Format(Result, 970);
                    break;
            }

            return (Result);
        }

        #endregion Protected Methods
    }
}