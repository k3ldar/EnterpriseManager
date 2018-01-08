using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

namespace SieraDelta.Website.Papers
{
    public partial class FirebirdReplicationForHighAvailability : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.RedirectPermanent("https://sicarterblog.wordpress.com/2017/07/14/replication-for-high-availability/", true);
        }
    }
}