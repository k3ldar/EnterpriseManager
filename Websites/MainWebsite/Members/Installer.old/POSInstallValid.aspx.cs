using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Heavenskincare.Website.Library.Classes;
using Heavenskincare.Library.BOL.POSInstall;

namespace Heavenskincare.WebsiteTemplate.Website.Members.Installer.POS
{
    public partial class POSInstallValid : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string storeID = GetFormValue("StoreID", "-999");


            try
            {
                if (POSInstaller.InstallValid(storeID))
                    Response.Write("true");
                else
                    Response.Write("false");
            }
            catch (Exception err)
            {
                Response.Write(String.Format("true", err.Message));
            }

            Response.End();
        }

    }
}
