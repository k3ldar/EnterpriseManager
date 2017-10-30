using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Library.Utils;
using Library.BOL.Products;
using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Products
{
    public partial class ProductsS : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DoRedirect(String.Format("/Products.aspx?GroupID={0}", GetFormValue("GroupID", -1)));
        }

        private bool IsValidProductSKU(string SKU)
        {
            bool IsValidSKU = Library.BOL.Products.Products.IsValidSKU(SKU);

            return (IsValidSKU);
        }

        protected string GetProductGroupName()
        {
            string Result = Languages.LanguageStrings.AllProducts;

            ProductGroup group = ProductGroups.Get(GetFormValue("GroupID", -1));

            if (group != null)
                Result = group.Description;

            return (Result);
        }

        protected string GetProductTitle(int ProductID)
        {
            string Result = Languages.LanguageStrings.AllProducts;

            ProductGroup group = ProductGroups.Get(ProductID);

            if (group != null)
                Result = group.Description;

            return (Result);
        }

        protected string BuildPagination()
        {
            string Result = "";

            bool allProducts = GetFormValue("GroupID", -1) == -1;
            int Count = 0;

            if (allProducts)
                Count = Library.BOL.Products.Products.GetCount(ProductTypes.Get("Stratosphere"));
            else
                Count = Library.BOL.Products.Products.CountByProduct(ProductGroups.Get(GetFormValue("GroupID", 1)));

            if (allProducts)
                Result = BuildPagination(Count, 12, GetFormValue("Page", 1), "/Products/ProductsS.aspx");
            else
                Result = BuildPagination(Count, 12, GetFormValue("Page", 1), "/Products/ProductsS.aspx", "GroupID=" + GetFormValue("GroupID"));

            return (Result);
        }
    }
}