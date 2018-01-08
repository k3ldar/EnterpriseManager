using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

namespace SieraDelta.Website.Staff.Admin.GeoUpdate
{
    public partial class GeoUpdate : BaseWebFormStaff
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (GetFormValue("ForceLoad") == "Yes")
            //{
            //    string geoPath = String.Format("{0}Admin\\GeoUpdate\\", Shared.Utilities.AddTrailingBackSlash(Global.RootPath));
            //    string encPath = String.Format("{0}Download\\Files\\GeoIP\\", Shared.Utilities.AddTrailingBackSlash(Global.RootPath));
            //    string fileVersions = String.Format("{0}Download\\Versions.xml", Shared.Utilities.AddTrailingBackSlash(Global.RootPath));

            //    string dbConnection = Library.DAL.DALHelper.ConnectionString();

            //    GeoIP.GeoIP geo = new GeoIP.GeoIP(geoPath, dbConnection, "WS_IPTOCOUNTRY_EXTERNAL");
            //    try
            //    {
            //        geo.RunForce();

            //        Response.Write(String.Format("Count: {0}</br />Add: {1}</br />Unchanged: {2}</br />Unknown: {3}</br />Updated: {4}</br />Version: {5}</br />", 
            //            geo.Count, geo.Added, geo.Unchanged, geo.Unknown, geo.Updated, geo.NewVersion));
            //        Response.End();
            //    }
            //    catch (Exception err)
            //    {
            //        Response.Write(err.Message);
            //        Response.Write(err.StackTrace.ToString().Replace("\n", "<br />"));
            //        Response.End();
            //    }
            //    finally
            //    {
            //        geo = null;
            //    }
            //}
        }
    }
}