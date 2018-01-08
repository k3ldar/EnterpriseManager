using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Library;
using Library.BOL.Products;
using Website.Library.Classes;

namespace SieraDelta.Website.Staff.Admin.Products
{
    public partial class Index : BaseWebFormAdmin
    {
        private WebsiteAdministration _admin;

        protected void Page_Load(object sender, EventArgs e)
        {
            _admin = new WebsiteAdministration(GetUser());
            LoadProducts();
        }

        protected void LoadProducts()
        {
            Library.BOL.Products.Products products = _admin.ProductsGet(GetFormValue("Page", 1), 12);

            foreach (Product prod in products)
            {
                HtmlTableRow row = new HtmlTableRow();
                tblProducts.Rows.Add(row);

                HtmlTableCell prodName = new HtmlTableCell();
                prodName.InnerHtml = prod.Name;
                row.Cells.Add(prodName);

                HtmlTableCell prodSKU = new HtmlTableCell();
                prodSKU.InnerText = prod.SKU;
            }
        }

        protected string BuildPagination()
        {
            string Result = "";

            int Count = 0;

            Count = _admin.ProductCount;

            Result = BuildPagination(Count, 12, GetFormValue("Page", 1), "/Staff/Admin/Products/Index.aspx", true);

            return (Result);
        }

    }
}