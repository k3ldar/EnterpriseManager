using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Products;

namespace Heavenskincare.WebsiteTemplate.Products
{
    public partial class ChristmasGiftSets : BaseWebFormOffers
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageExpires = new DateTime(2015, 12, 26);
        }

    }
}