using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Website.Library.Classes;
using Library.BOL.CustomWebPages;
using Library.BOL.Products;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class BasketNails : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Refresh(Product product)
        {
            nailDescription.InnerText = product.Name;

            foreach (ProductCost nail in product.ProductCosts)
            {
                Controls.BasketAddNail nc = (Controls.BasketAddNail)LoadControl("~/Controls/BasketAddNail.ascx");
                nc.Refresh(nail);
                nc.AddToBasket += nc_AddToBasket;
                nailProducts.Controls.Add(nc);
            }

        }


        private void nc_AddToBasket(object sender, EventArgs e)
        {
            //if (Global.BasketSummaryShow)
            //    BasketSummary.Visible = true;
        }
    }
}