using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SieraDelta.Website.Products.Defender
{
    public partial class BannedIPAddresses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // only accept connections from local machine or client connections coming from licenced products
        }
    }
}