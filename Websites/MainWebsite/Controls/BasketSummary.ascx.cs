using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

using Library;
using Library.BOL.Products;
using Library.BOL.Users;
using Library.BOL.Basket;
using Library.Utils;
using Library.BOL.Countries;

namespace Heavenskincare.WebsiteTemplate.Controls
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
            _product = Library.BOL.Products.Products.Get(GetFormValue("ID", 1));
            basketSummary.Visible = _isVisible;
            btnViewBag.Text = Languages.LanguageStrings.ViewShoppingBag;

            if (_product == null)
                DoRedirect("/Products.aspx?GroupID=1", true);
        }

        protected string GetProductName()
        {
            string Result = _product.Name;

            return (Result);
        }

        protected string GetProductImage()
        {
            string Result = _product.Image;

            Result = HSCUtils.ResizeImage(Result, 89);

            return (Result);
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
            DoRedirect("/Basket/Basket.aspx");
        }

        #endregion Protected Methods
    }
}