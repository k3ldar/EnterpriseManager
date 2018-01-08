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

namespace SieraDelta.Website.Products
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
                DoRedirect("/All-Products/");

            LeftContainerControl1.SubHeader = Languages.LanguageStrings.Categories;
            LeftContainerControl1.SubOptions = GetProductCategories(ProductGroupTypes.Get("Products"));

            _item = ProductCosts.Get(GetFormValue("ItemID", -1));

            if (_item == null || !_item.OutOfStock)
                DoRedirect("All-Products/");

            _product = _item.Product;

            if (_product == null)
                DoRedirect("/All-Products/", true);

            OutOfStockNotification1.SetItem(_item);
        }

        protected string GetProductDescription()
        {
            string Result = _product.Description;

            //SieraDeltaUtils u = new SieraDeltaUtils();
            Result = SharedUtils.PreProcessPost(Global.RootURL, Result);

            return (Result);
        }

        protected string GetProductCostName()
        {
            string Result = String.Format("{0} - {1}", _product.Name, _item.Size);

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

            Result = String.Format("Products/{0}", SharedUtils.ResizeImage(Result, 288));

            
            return (Result);
        }

        #endregion Protected Methods
    }
}