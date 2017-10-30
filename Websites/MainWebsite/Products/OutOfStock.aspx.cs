using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Library.BOL.Products;
using Library.BOL.Users;
using Library.BOL.Basket;
using Library.Utils;
using Website.Library.Classes;
using Library.BOL.Countries;

namespace Heavenskincare.WebsiteTemplate.Products
{
    public partial class OutOfStock : BaseWebForm
    {
        #region Private / Protected Members

        private Product _product;
        private ProductCost _item;

        #endregion Private / Protected Members

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Global.OutOfStockAllowNotifyUser)
                DoRedirect("/Products.aspx");

            LeftContainerControl1.SubHeader = Languages.LanguageStrings.Categories;
            LeftContainerControl1.SubOptions = GetProductCategories(false, false);

            _item = ProductCosts.Get(GetFormValue("ItemID", -1));

            if (_item == null || !_item.OutOfStock)
                DoRedirect("/Products.aspx");

            _product = _item.Product;

            if (_product == null)
                DoRedirect("/Products.aspx", true);

            OutOfStockNotification1.SetItem(_item);
        }

        protected string GetProductDescription()
        {
            string Result = _product.Description;

            Result = HSCUtils.PreProcessPost(Result);

            return (Result);
        }

        protected string GetProductCostName()
        {
            string Result = String.Format("{0} - {1}", _product.Name, _item.Size);

            return (Result);
        }

        protected string GetProductGroupLink()
        {
            string Result = "<a href=\"/Products.aspx?GroupID={0}\">{1}</a>";

            ProductGroup group = _product.ProductGroups.First();

            if (group != null)
                Result = String.Format(Result, group.ID, group.Description);

            return (Result);
        }

        protected string GetProductGroupName()
        {
            string Result = "{0}";

            Result = String.Format(Result, _product.PrimaryGroup.Description);

            return (Result);
        }

        protected string GetProductImage()
        {
            string Result = _product.Image;

            //if (!Result.Contains(".png") && !Result.Contains(".jpg"))
            //    Result += "_288.jpg";

            Result = String.Format("{1}/{0}", HSCUtils.ResizeImage(Result, 288), 
                TreatAsStratosphereProduct(_product.PrimaryProduct) ? "Stratosphere" : "Product");

            
            return (Result);
        }

        #endregion Protected Methods
    }
}