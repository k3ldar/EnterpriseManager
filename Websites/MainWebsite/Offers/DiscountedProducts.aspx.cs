using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.BOL.Products;
using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Offers
{
    public partial class DiscountedProducts : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductCosts discountedProducts = Library.BOL.Products.Products.GetDiscounted();

            if (discountedProducts.Count == 0)
                DoRedirect("/Index.aspx", true);

            foreach (ProductCost item in discountedProducts)
            {
                Heavenskincare.WebsiteTemplate.Controls.DiscountedProductItem bi = (Heavenskincare.WebsiteTemplate.Controls.DiscountedProductItem)LoadControl("~/Controls/DiscountedProductItem.ascx");
                bi.PriceFontColour = ColorTranslator.ToHtml(Color.FromArgb(227, 148, 183));
                bi.ProductCostItem = item;
                divDiscountedProducts.Controls.Add(bi);
            }

        }
    }
}