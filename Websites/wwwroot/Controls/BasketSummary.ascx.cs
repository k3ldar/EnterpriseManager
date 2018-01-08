using System;

using Website.Library.Classes;
using Library.BOL.Products;

namespace SieraDelta.Website.Controls
{
    public partial class BasketSummary : BaseControlClass
    {
        #region Private Members

        private bool _isVisible = false;
        private Product _product;

        #endregion Private Members

        #region Properties


        public override bool Visible
        {
            get
            {
                return (_isVisible);
            }

            set
            {
                _isVisible = value;
                basketSummary.Visible = _isVisible;
            }
        }

        #endregion Properties

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            // can we look up the product using route name?
            string prodRouteName = (string)Page.RouteData.Values["name"];

            if (BaseWebApplication.AllRoutes.ContainsKey(prodRouteName))
            {
                Int64 id = BaseWebApplication.AllRoutes[prodRouteName];
                _product = Library.BOL.Products.Products.Get(id);
            }

            basketSummary.Visible = _isVisible;
            btnViewBag.Text = Languages.LanguageStrings.ViewShoppingBag;

            if (_product == null)
                DoRedirect("/All-Products/", true);
        }

        protected string GetProductName()
        {
            string Result = _product.Name;

            return (Result);
        }

        protected string GetProductImage()
        {
            return (Library.Utils.SharedUtils.ResizeImage(_product.Image, 89));
        }

        protected string GetAutoHide()
        {
            return (Global.BasketSummaryAutoHide.ToString().ToLower());
        }

        protected string AutoHideTimeOut()
        {
            int Result = Global.BasketSummaryTimeOut * 1000;

            return (Result.ToString());
        }

        protected void btnViewBag_Click(object sender, EventArgs e)
        {
            DoRedirect("/Shopping/Basket/");
        }

        #endregion Protected Methods
    }
}