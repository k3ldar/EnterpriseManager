using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Offers
{
    public partial class Mothersday : BaseWebFormOffers
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageExpires = new DateTime(2050, 3, 31, 23, 59, 59);
        }
    }
}